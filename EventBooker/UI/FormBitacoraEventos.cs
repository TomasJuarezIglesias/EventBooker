using Business;
using ClosedXML.Excel;
using Entities;
using PdfSharp;
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
    public partial class FormBitacoraEventos : ServiceForm
    {
        private Action<ServiceForm> openChildForm;

        public FormBitacoraEventos(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();
            ChangeTranslation();
            FillDataGridView(0, DateTime.MinValue, DateTime.MinValue, null, null, 0);
            FillFiltros();
            this.openChildForm = openChildForm;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            EntityUser user = CmbUsuario.SelectedItem as EntityUser;
            string modulo = CmbModulo.SelectedItem as string;
            string evento = CmbEvento.SelectedItem as string;
            int criticidad = Convert.ToInt32(CmbCriticidad.SelectedItem);
            DateTime fechaIni = DateTimePickerIni.Value;
            DateTime fechaFin = DateTimePickerFin.Value;

            if (fechaIni.Date > fechaFin.Date)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageFechaIniMayorFechaFin"));
                return;
            }

            TxtNombre.Text = user != null ? user.Nombre : string.Empty;
            TxtApellido.Text = user != null ? user.Apellido : string.Empty;


            FillDataGridView(user is null ? 0 : user.Id, fechaIni, fechaFin, modulo, evento, criticidad);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            CmbUsuario.SelectedIndex = -1;
            CmbModulo.SelectedIndex = -1;
            CmbEvento.SelectedIndex = -1;
            CmbCriticidad.SelectedIndex = -1;
            DateTimePickerIni.Value = DateTime.Now.AddDays(-3);
            DateTimePickerFin.Value = DateTime.Now;

            FillDataGridView(0, DateTime.MinValue, DateTime.MinValue, null, null, 0);
        }

        private void FillFiltros()
        {
            CmbUsuario.DataSource = null;
            CmbUsuario.DataSource = _businessBitacoraEvento.GetUsers().Data;
            CmbUsuario.SelectedIndex = -1;

            CmbModulo.DataSource = null;
            CmbModulo.DataSource = _businessBitacoraEvento.GetModulos().Data;
            CmbModulo.SelectedIndex = -1;

            CmbEvento.DataSource = null;
            CmbEvento.DataSource = _businessBitacoraEvento.GetEventos().Data;
            CmbEvento.SelectedIndex = -1;

            DateTimePickerIni.Value = DateTime.Now.AddDays(-3);
            DateTimePickerFin.Value = DateTime.Now;
        }

        private void FillDataGridView(int idUser, DateTime fechaInicio, DateTime fechaFin, string modulo, string evento, int criticidad)
        {
            List<EntityBitacoraEvento> eventos = _businessBitacoraEvento.GetAll(idUser, fechaInicio, fechaFin, modulo, evento, criticidad).Data;

            DataGridViewEventos.DataSource = null;
            DataGridViewEventos.DataSource = eventos;

            DataGridViewEventos.Columns["Id"].Visible = false;

            DataGridViewEventos.Columns["User"].HeaderText = SearchTraduccion("DGVColumnaUser");
            DataGridViewEventos.Columns["Fecha"].HeaderText = SearchTraduccion("DGVColumnaFecha");
            DataGridViewEventos.Columns["Modulo"].HeaderText = SearchTraduccion("DGVColumnaModulo");
            DataGridViewEventos.Columns["Evento"].HeaderText = SearchTraduccion("DGVColumnaEvento");
            DataGridViewEventos.Columns["Criticidad"].HeaderText = SearchTraduccion("DGVColumnaCriticidad");
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dataTable = DataGridViewToDataTable(DataGridViewEventos);

            if (dataTable.Rows.Count == 0)
            {
                // Mostrar error
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageNoHayDatosGenerarReporteBitacoraEventos"));
                return;
            }

            // Crear un documento PDF
            PdfDocument pdfDocument = new PdfDocument();
            pdfDocument.Info.Title = SearchTraduccion("LblBitacoraEventos");

            // Crear una página en el documento PDF en formato horizontal (landscape)
            PdfPage pdfPage = pdfDocument.AddPage();
            pdfPage.Width = XUnit.FromMillimeter(297); // Ancho en milímetros para formato A4 horizontal
            pdfPage.Height = XUnit.FromMillimeter(210); // Alto en milímetros para formato A4 horizontal
            XGraphics graphics = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 10, XFontStyleEx.Regular);
            XPen borderPen = new XPen(XColors.Black, 0.5);

            // Definir márgenes y altura de la celda
            double margin = 20;
            double cellHeight = 20;
            double xStart = margin;
            double yStart = margin;
            double pageWidth = pdfPage.Width.Point - margin * 2;
            double pageHeight = pdfPage.Height.Point - margin * 2;

            // Definir el ancho fijo para la columna "Criticidad" (ajustar según sea necesario)
            double criticidadWidth = 60;
            double remainingWidth = pageWidth - criticidadWidth;
            double numberOfColumns = dataTable.Columns.Count - 1; // Excluyendo la columna "Criticidad"
            double columnWidth = numberOfColumns > 0 ? remainingWidth / numberOfColumns : 0;

            // Dibujar el encabezado de la tabla con fondo gris y bordes
            graphics.DrawRectangle(XBrushes.LightGray, xStart, yStart, pageWidth, cellHeight);

            // Dibujar encabezados de columnas
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName == "Criticidad")
                {
                    graphics.DrawRectangle(borderPen, xStart, yStart, criticidadWidth, cellHeight);
                    graphics.DrawString(column.ColumnName, font, XBrushes.Black, new XRect(xStart + 5, yStart + 5, criticidadWidth, cellHeight), XStringFormats.TopLeft);
                    xStart += criticidadWidth;
                }
                else
                {
                    graphics.DrawRectangle(borderPen, xStart, yStart, columnWidth, cellHeight);
                    graphics.DrawString(column.ColumnName, font, XBrushes.Black, new XRect(xStart + 5, yStart + 5, columnWidth, cellHeight), XStringFormats.TopLeft);
                    xStart += columnWidth;
                }
            }

            yStart += cellHeight;
            xStart = margin; // Reinicia la posición horizontal para las celdas de datos

            // Dibujar las filas de la tabla con bordes
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ColumnName == "Criticidad")
                    {
                        graphics.DrawRectangle(borderPen, xStart, yStart, criticidadWidth, cellHeight);
                        graphics.DrawString(row[column].ToString(), font, XBrushes.Black, new XRect(xStart + 5, yStart + 5, criticidadWidth, cellHeight), XStringFormats.TopLeft);
                        xStart += criticidadWidth;
                    }
                    else
                    {
                        graphics.DrawRectangle(borderPen, xStart, yStart, columnWidth, cellHeight);
                        graphics.DrawString(row[column].ToString(), font, XBrushes.Black, new XRect(xStart + 5, yStart + 5, columnWidth, cellHeight), XStringFormats.TopLeft);
                        xStart += columnWidth;
                    }
                }
                yStart += cellHeight;
                xStart = margin; // Reinicia la posición horizontal para la siguiente fila

                // Verifica si la página se ha llenado
                if (yStart + cellHeight > pdfPage.Height.Point - margin)
                {
                    pdfPage = pdfDocument.AddPage();
                    pdfPage.Width = XUnit.FromMillimeter(297); // Ancho en milímetros para formato A4 horizontal
                    pdfPage.Height = XUnit.FromMillimeter(210); // Alto en milímetros para formato A4 horizontal
                    graphics = XGraphics.FromPdfPage(pdfPage);
                    yStart = margin;
                    xStart = margin;

                    // Redefinir los tamaños de columna para la nueva página
                    pageWidth = pdfPage.Width.Point - margin * 2;
                    remainingWidth = pageWidth - criticidadWidth;
                    columnWidth = numberOfColumns > 0 ? remainingWidth / numberOfColumns : 0;
                }
            }

            // Guardar el PDF en el escritorio
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"{SearchTraduccion("NombreArchivoBitacora")}_{DateTime.Now.ToString("yyyy_MM_dd_hh_mm")}.pdf";
            string filePath = Path.Combine(desktopPath, fileName);
            pdfDocument.Save(filePath);

            // Abrir el archivo PDF
            Process.Start(filePath);
        }

        private void DataGridViewEventos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewEventos.SelectedRows.Count > 0)
            {
                // Obtén la primera fila seleccionada
                DataGridViewRow selectedRow = DataGridViewEventos.SelectedRows[0];

                EntityUser user = selectedRow.Cells[0].Value as EntityUser;

                TxtNombre.Text = user.Nombre;
                TxtApellido.Text = user.Apellido;
            }

        }
    }
}
