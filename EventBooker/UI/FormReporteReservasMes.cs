using Business;
using ClosedXML.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
    public partial class FormReporteReservasMes : ServiceForm
    {
        private BusinessReserva _businessReserva;
        public FormReporteReservasMes()
        {
            InitializeComponent();
            ChangeTranslation();

            DateTimePickerMesReporte.Format = DateTimePickerFormat.Custom;
            DateTimePickerMesReporte.CustomFormat = "yyyy-MM";
            DateTimePickerMesReporte.ShowUpDown = true;  // Permite el control de tipo up-down para evitar mostrar el calendario

            _businessReserva = new BusinessReserva();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            DataTable dataTable = _businessReserva.GenerarReporteMes(DateTimePickerMesReporte.Value).Data;

            if (dataTable.Rows.Count == 0)
            {
                // Mostrar error
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageNoHayDatosGenerarReporteReservas"));
                return;
            }

            dataTable.Columns["Fecha"].ColumnName = SearchTraduccion("DGVColumnaFecha");
            dataTable.Columns["Turno"].ColumnName = SearchTraduccion("DGVColumnaTurno");
            dataTable.Columns["Descripcion"].ColumnName = SearchTraduccion("DGVColumnaDescripcion");
            dataTable.Columns["Invitados"].ColumnName = SearchTraduccion("DGVColumnaInvitados");
            dataTable.Columns["NombreSalon"].ColumnName = SearchTraduccion("LblSalon");
            dataTable.Columns["Ubicacion"].ColumnName = SearchTraduccion("LblUbicacion");
            dataTable.Columns["ValorTotal"].ColumnName = SearchTraduccion("LblCostos");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(SearchTraduccion("DDGVColumnaReserva"));

                // Agregar el DataTable al worksheet
                worksheet.Cell(1, 1).InsertTable(dataTable);
                worksheet.AutoFilter.Clear();

                // Formato para la columna de Fecha
                worksheet.Column(1).Style.NumberFormat.Format = "yyyy-MM-dd"; // Formato de fecha personalizado

                // Calcular el total de la columna ValorTotal
                decimal total = 0;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(dataTable.Rows[i][SearchTraduccion("LblCostos")]);
                }

                // Agregar el total al final
                int totalRow = dataTable.Rows.Count + 2;
                worksheet.Cell(totalRow, dataTable.Columns.Count - 1).Value = SearchTraduccion("LblTotal");
                worksheet.Cell(totalRow, dataTable.Columns.Count).Value = total;

                // Formato para la celda de total
                var totalRange = worksheet.Range(totalRow, dataTable.Columns.Count - 1, totalRow, dataTable.Columns.Count);
                totalRange.Style.Font.Bold = true;
                totalRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                // Ajusto columnas a contenidos
                worksheet.Columns().AdjustToContents();

                // Obtener la ruta del escritorio
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"{SearchTraduccion("NombreArchivoReporteReserva")}{DateTime.Now.ToString("yyyy_MM")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                // Guardar el archivo en el escritorio
                workbook.SaveAs(filePath);

                Process.Start(filePath);
                this.Close();

                RegistrarEvento("Reportes", "Generación reporte reservas", 5);
            }
        }
    }
}
