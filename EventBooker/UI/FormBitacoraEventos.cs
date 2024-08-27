using Business;
using ClosedXML.Excel;
using Entities;
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

            fechaFin.AddDays(1);

            if (user != null)
            {
                TxtNombre.Text = user.Nombre;
                TxtApellido.Text = user.Apellido;
            }


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
            // Convertir los datos del DataGridView a un DataTable
            DataTable dataTable = DataGridViewToDataTable(DataGridViewEventos);

            if (dataTable.Rows.Count == 0)
            {
                // Mostrar error
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageNoHayDatosGenerarReporteBitacoraEventos"));
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(SearchTraduccion("LblBitacoraEventos"));

                // Agregar el DataTable al worksheet
                worksheet.Cell(1, 1).InsertTable(dataTable);
                worksheet.AutoFilter.Clear();

                // Ajusto columnas a contenidos
                worksheet.Columns().AdjustToContents();

                // Obtener la ruta del escritorio
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = $"{SearchTraduccion("NombreArchivoBitacora")}_{DateTime.Now.ToString("yyyy_MM")}.xlsx";
                string filePath = Path.Combine(desktopPath, fileName);

                // Guardar el archivo en el escritorio
                workbook.SaveAs(filePath);

                Process.Start(filePath);
            }
        }

        // Método para convertir DataGridView a DataTable
        private DataTable DataGridViewToDataTable(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Agregar columnas al DataTable
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // Agregar filas al DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            if (dataTable.Columns.Contains("Id"))
            {
                dataTable.Columns.Remove("Id");
            }

            return dataTable;
        }
    }
}
