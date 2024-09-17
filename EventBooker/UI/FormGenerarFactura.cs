using Business;
using Entities;
using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility.Drawing;
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
    public partial class FormGenerarFactura : ServiceForm
    {
        private readonly BusinessFactura _businessFactura;

        public FormGenerarFactura()
        {
            InitializeComponent();

            _businessFactura = new BusinessFactura();

            ChangeTranslation();
            FillComboBox();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if (CmbFacturas.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarFactura"));
                return;
            }

            EntityFactura factura = CmbFacturas.SelectedItem as EntityFactura;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Construir la ruta completa del archivo JSON
                    string filePath = Path.Combine(folderDialog.SelectedPath, $"{SearchTraduccion("LblFactura")}_N{factura.Id}_{factura.FechaEmision.ToString("yyyy_MM_dd")}.pdf");

                    GenerarFactura(factura, filePath);
                }
                else
                {
                    RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarCarpeta"));
                    return;
                }
            }

            CmbFacturas.SelectedIndex = -1;
            RevisarRespuestaServicio(new BusinessResponse<bool>(true, true, "MessageFacturaGeneradaCorrectamente"));
        }

        private void FillComboBox()
        {
            CmbFacturas.DataSource = null;
            CmbFacturas.DataSource = _businessFactura.GetAll().Data;
            CmbFacturas.SelectedIndex = -1;
        }

        private void GenerarFactura(EntityFactura factura, string path)
        {
            // Crear documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"{SearchTraduccion("LblFactura")}";

            // Crear página PDF
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Definir las fuentes
            XFont titleFont = new XFont("Verdana", 18, XFontStyleEx.Bold);
            XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
            XFont regularFont = new XFont("Verdana", 10, XFontStyleEx.Regular);

            // Márgenes
            int marginLeft = 40;
            int marginTop = 40;
            int lineHeight = 20;
            int tabOffset = 30;

            // Título de la factura
            gfx.DrawString($"{SearchTraduccion("LblFactura")}", titleFont, XBrushes.Black, new XRect(marginLeft, marginTop, page.Width, lineHeight), XStringFormats.TopLeft);
            gfx.DrawLine(XPens.Black, marginLeft, marginTop + lineHeight + 5, page.Width - marginLeft, marginTop + lineHeight + 5);

            // Información del cliente
            int yPos = marginTop + 2 * lineHeight;
            gfx.DrawString($"{SearchTraduccion("MessageDatosDelCliente")}", headerFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblNombre")} {factura.Cliente.Nombre} {factura.Cliente.Apellido}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblDni")} {factura.Cliente.Dni}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblDireccion")} {factura.Cliente.Direccion}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblMail")} {factura.Cliente.Email}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblContacto")} {factura.Cliente.Contacto}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;

            // Línea de separación
            yPos += lineHeight;
            gfx.DrawLine(XPens.Black, marginLeft, yPos, page.Width - marginLeft, yPos);

            // Detalles de la factura
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("MessageDetalleFactura")}", headerFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblFechaEmision")} {factura.FechaEmision.ToString("dd/MM/yyyy")}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("MessageServicios")}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);

            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblCostoSalon")} {factura.Reserva.Salon.Precio.ToString("C", new System.Globalization.CultureInfo("es-AR"))}", regularFont, XBrushes.Black, new XRect(marginLeft + tabOffset, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblPrecioCubiertoTotal")} {(factura.Reserva.Salon.PrecioCubierto * factura.Reserva.Invitados).ToString("C", new System.Globalization.CultureInfo("es-AR"))}", regularFont, XBrushes.Black, new XRect(marginLeft + tabOffset, yPos, page.Width, lineHeight), XStringFormats.TopLeft);

            foreach (EntityServicio servicio in factura.Reserva.Servicios)
            {
                yPos += lineHeight;
                gfx.DrawString($"{servicio.Descripcion}: {servicio.Valor.ToString("C", new System.Globalization.CultureInfo("es-AR"))}", regularFont, XBrushes.Black, new XRect(marginLeft + tabOffset, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            }

            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblImpuestos")} {factura.Impuestos.ToString("C", new System.Globalization.CultureInfo("es-AR"))} (Iva 21%)", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblImporteTotal")} {factura.ImporteTotal.ToString("C", new System.Globalization.CultureInfo("es-AR"))}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;

            // Información de pago
            yPos += lineHeight;
            gfx.DrawLine(XPens.Black, marginLeft, yPos, page.Width - marginLeft, yPos);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblInformacionDePago")}", headerFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblMetodoDePago")} {factura.MetodoPago}", regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;

            // Observaciones
            yPos += lineHeight;
            gfx.DrawLine(XPens.Black, marginLeft, yPos, page.Width - marginLeft, yPos);
            yPos += lineHeight;
            gfx.DrawString($"{SearchTraduccion("LblObservaciones")}", headerFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width, lineHeight), XStringFormats.TopLeft);
            yPos += lineHeight;
            gfx.DrawString(factura.Observaciones, regularFont, XBrushes.Black, new XRect(marginLeft, yPos, page.Width - marginLeft * 2, lineHeight * 4), XStringFormats.TopLeft);

            // Guardar documento
            document.Save(path);

            Process.Start(path);
        }
    }
}
