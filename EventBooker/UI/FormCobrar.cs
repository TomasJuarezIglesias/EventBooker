using Bunifu.UI.WinForms;
using Business;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormCobrar : ServiceForm
    {
        private readonly BusinessReserva _businessReserva;

        private string Modulo = "Cobranza";
        private Action<ServiceForm> openChildForm;

        public FormCobrar(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();
            this.openChildForm = openChildForm;

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
            var reservas = _businessReserva.GetAll().Data;

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

        private void BtnRealizarCobro_Click(object sender, EventArgs e)
        {
            if (CmbMedioPago.Text == "Tarjeta" && !ValidateInputs()) return;

            if (CmbMedioPago.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarMedioPago"));
                return;
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
            DataGridViewReservas.DataSource = _businessReserva.GetAll().Data;
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
            

            DataGridViewReservas.Columns["Cliente"].Width = 200;

            DataGridViewReservas.Columns["Cliente"].HeaderText = SearchTraduccion("DGVColumnaCliente");
            DataGridViewReservas.Columns["Descripcion"].HeaderText = SearchTraduccion("DGVColumnaDescripcion");
            DataGridViewReservas.Columns["Fecha"].HeaderText = SearchTraduccion("DGVColumnaFecha");
            DataGridViewReservas.Columns["Turno"].HeaderText = SearchTraduccion("DGVColumnaTurno");
            DataGridViewReservas.Columns["Invitados"].HeaderText = SearchTraduccion("DGVColumnaInvitados");
            DataGridViewReservas.Columns["Estado"].HeaderText = SearchTraduccion("DGVColumnaEstado");
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

        private void CmbMedioPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PanelTarjeta.Visible = CmbMedioPago.Text == "Tarjeta";
        }

    }
}
