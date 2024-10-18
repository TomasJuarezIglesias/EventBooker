using Bunifu.UI.WinForms;
using Business;
using Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormCollectDeposit : ServiceForm
    {
        private readonly BusinessReserva _businessReserva;

        private string Modulo = "Cobranza";
        public FormCollectDeposit()
        {
            InitializeComponent();
            ChangeTranslation();

            _businessReserva = new BusinessReserva();

            // Configuro inicio del form
            PanelCobro.Visible = false;
            DateTimePickerVencimiento.Format = DateTimePickerFormat.Custom;
            DateTimePickerVencimiento.CustomFormat = "yyyy-MM";
            DateTimePickerVencimiento.ShowUpDown = true;  // Permite el control de tipo up-down para evitar mostrar el calendario

            FillDataGridView();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string searchText = TxtSearchText.Text.Trim();

            // Obtener la fuente de datos actual del DataGridView
            var reservas = _businessReserva.GetAll("Pendiente").Data;

            if (reservas != null)
            {
                // Filtrar por cliente o fecha que contengan el texto de búsqueda
                var filteredReservas = reservas.Where(r =>
                    r.Cliente.ToString().Contains(searchText) ||
                    r.Fecha.ToString("dd/MM/yyyy").Contains(searchText)
                ).ToList();

                // Actualizar el DataSource del DataGridView con los resultados filtrados
                DataGridViewReservas.DataSource = null;
                DataGridViewReservas.DataSource = filteredReservas;
                ChangeVisualDataGridView();
            }
        }

        private void BtnCollectDeposit_Click(object sender, EventArgs e)
        {
            if (CmbMedioPago.Text == "Tarjeta" && !ValidateInputs()) return;

            if (CmbMedioPago.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarMedioPago"));
                return;
            }

            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageDeseaRealizarCobroSenia")}",
            $"{SearchTraduccion("CaptionConfirmarCobro")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado
            if (result == DialogResult.Yes)
            {
                EntityReserva reserva = DataGridViewReservas.SelectedRows[0].DataBoundItem as EntityReserva;

                reserva.Estado = "Confirmado";

                BusinessResponse<bool> response = _businessReserva.Update(reserva);
                UpdateDigitoVerificador();
                RevisarRespuestaServicio(new BusinessResponse<bool>(response.Ok, response.Ok, response.Ok ? "MessagePagoRealizadoSenia" : "MessagePagoRechazado"));

                FillDataGridView();
                PanelCobro.Visible = false;

                // Obtener el path del escritorio
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Path completo para guardar el PDF
                string filePath = Path.Combine(desktopPath, $"{SearchTraduccion("MessageComprobanteReserva")}{reserva.Fecha.ToString("dd_MM_yyyyy")}_{reserva.Turno}.pdf");

                // Generar comprobante de reserva
                GenerarComprobanteDeReserva(reserva, filePath);

                RegistrarEvento(Modulo, "Cobranza de seña", 2);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DataGridViewReservas.CurrentCell = null;
            PanelCobro.Visible = false;
        }


        private void FillDataGridView()
        {
            DataGridViewReservas.DataSource = null;
            DataGridViewReservas.DataSource = _businessReserva.GetAll("Pendiente").Data;
            ChangeVisualDataGridView();
        }

        private void DataGridViewReservas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewReservas.CurrentCell = null;
        }

        private void ChangeVisualDataGridView()
        {
            // Oculto datos
            DataGridViewReservas.Columns["Id"].Visible = false;
            DataGridViewReservas.Columns["Salon"].Visible = false;
            DataGridViewReservas.Columns["Estado"].Visible = false;

            DataGridViewReservas.Columns["Cliente"].Width = 200;

            DataGridViewReservas.Columns["Cliente"].HeaderText = SearchTraduccion("DGVColumnaCliente");
            DataGridViewReservas.Columns["Descripcion"].HeaderText = SearchTraduccion("DGVColumnaDescripcion");
            DataGridViewReservas.Columns["Fecha"].HeaderText = SearchTraduccion("DGVColumnaFecha");
            DataGridViewReservas.Columns["Turno"].HeaderText = SearchTraduccion("DGVColumnaTurno");
            DataGridViewReservas.Columns["Invitados"].HeaderText = SearchTraduccion("DGVColumnaInvitados");
        }

        private void DataGridViewReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EntityReserva reserva = DataGridViewReservas.SelectedRows[0].DataBoundItem as EntityReserva;
            ShowPanel(reserva);
        }

        private void ShowPanel(EntityReserva reserva)
        {
            PanelCobro.Visible = true;
            PanelTarjeta.Visible = false;

            // Limpio datos para realizar pago
            CmbMedioPago.SelectedIndex = -1;
            CmbTipoTarjeta.SelectedIndex = -1;
            TxtNombreTitular.Text = $"{reserva.Cliente.Nombre} {reserva.Cliente.Apellido}";
            TxtNumeroTarjeta.Text = string.Empty;
            DateTimePickerVencimiento.Value = DateTime.Now;

            HideLabelError(new List<BunifuLabel>
            {
                LblErrorNumeroTarjeta,
                LblErrorNombreTitular,
                LblErrorTipoTarjeta
            });

            CalcularCostos(reserva);
        }


        private void CalcularCostos(EntityReserva reserva)
        {
            double costoTotal = 0;

            costoTotal += reserva.Salon.Precio;
            costoTotal += reserva.Salon.PrecioCubierto * reserva.Invitados;

            foreach (var servicio in reserva.Servicios)
            {
                costoTotal += servicio.Valor;
            }

            double costoSenia = costoTotal == 0 ? 0 : ((30 * costoTotal) / 100);

            LblTotal.Text = $"{SearchTraduccion("LblTotal")} ${costoTotal}";
            LblDeposit.Text = $"{SearchTraduccion("LblDeposit")} ${costoSenia}";
        }

        private void CmbMedioPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PanelTarjeta.Visible = CmbMedioPago.Text == "Tarjeta";
        }

        private bool ValidateInputs()
        {
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorNumeroTarjeta,
                LblErrorNombreTitular,
                LblErrorTipoTarjeta
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtNumeroTarjeta.Text))
            {
                ShowLabelError(LblErrorNumeroTarjeta, "LblErrorNumeroTarjeta");
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtNumeroTarjeta.Text) && !RegexValidationService.IsValidCard(TxtNumeroTarjeta.Text))
            {
                ShowLabelError(LblErrorNumeroTarjeta, "MessageVerificarDatosTarjeta");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtNombreTitular.Text))
            {
                ShowLabelError(LblErrorNombreTitular, "LblErrorNombreTitular");
                ok = false;
            }

            if (CmbTipoTarjeta.SelectedIndex == -1)
            {
                ShowLabelError(LblErrorTipoTarjeta, "LblErrorTipoTarjeta");
                ok = false;
            }

            return ok;
        }

        public void GenerarComprobanteDeReserva(EntityReserva reserva, string filePath)
        {
            // Crear un nuevo documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"{SearchTraduccion("MessageComprobanteReservaTitulo")}";

            // Crear una nueva página
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Configurar fuentes
            XFont fontTitle = new XFont("Verdana", 20, XFontStyleEx.Bold);
            XFont fontSubtitle = new XFont("Verdana", 16, XFontStyleEx.Bold);
            XFont fontRegular = new XFont("Verdana", 12, XFontStyleEx.Regular);

            // Escribir el título
            gfx.DrawString($"{SearchTraduccion("MessageComprobanteReservaTitulo")}", fontTitle, XBrushes.Black, new XRect(0, 40, page.Width, 40), XStringFormats.TopCenter);

            int yPosition = 100;
            // Escribir la información de la reserva
            gfx.DrawString($"{SearchTraduccion("MessageInformacionReserva")}", fontSubtitle, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("LblFecha")} {reserva.Fecha.ToString("dd/MM/yyyy")}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("LblTurno")} {reserva.Turno}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("LblSalon")}: {reserva.Salon.Nombre} - {reserva.Salon.Ubicacion}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("MessageCostoSalon")} ${reserva.Salon.Precio}", fontRegular, XBrushes.Black, 40, yPosition);

            // Escribir la descripción del evento
            yPosition += 40;
            gfx.DrawString($"{SearchTraduccion("LblDescripcionEvento")}", fontSubtitle, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("LblDescripcionEvento")} {reserva.Descripcion}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("LblCantidadInvitados")} {reserva.Invitados}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("LblPrecioCubierto")} ${reserva.Salon.PrecioCubierto}", fontRegular, XBrushes.Black, 40, yPosition);


            // Escribir los servicios solicitados
            yPosition += 40;
            gfx.DrawString($"{SearchTraduccion("MessageServiciosSolicitados")}", fontSubtitle, XBrushes.Black, 40, yPosition);
            yPosition += 20;

            //Realizo calculos de costos
            double costoTotal = 0;

            costoTotal += reserva.Salon.Precio;
            costoTotal += reserva.Salon.PrecioCubierto * reserva.Invitados;

            foreach (var servicio in reserva.Servicios)
            {
                // Escribo servicios
                gfx.DrawString($"{servicio.Descripcion}: ${servicio.Valor}", fontRegular, XBrushes.Black, 50, yPosition);
                yPosition += 20;

                costoTotal += servicio.Valor;
            }

            double costoSenia = costoTotal == 0 ? 0 : ((30 * costoTotal) / 100);

            // Escribir el monto abonado y el saldo pendiente
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("MessageEstadoCuenta")}", fontSubtitle, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("MessageMontoTotal")} ${costoTotal}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("MessageMontoAbonado")} ${costoSenia}", fontRegular, XBrushes.Black, 40, yPosition);
            yPosition += 20;
            gfx.DrawString($"{SearchTraduccion("MessageSaldoPendiente")} ${costoTotal - costoSenia}", fontRegular, XBrushes.Black, 40, yPosition);

            // Guardar el documento PDF
            document.Save(filePath);

            // Abrir el PDF con el lector predeterminado
            Process.Start(filePath);
        }

    }
}
