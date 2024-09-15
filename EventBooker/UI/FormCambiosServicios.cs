using Business;
using Entities;
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
    public partial class FormCambiosServicios : ServiceForm
    {
        private BusinessServicio _businessServicio;

        public FormCambiosServicios()
        {
            InitializeComponent();

            _businessServicio = new BusinessServicio();

            ChangeTranslation();

            FillDataGridView(0, DateTime.MinValue, DateTime.MinValue);
            FillFiltros();
        }

        private void FillDataGridView(int IdServicio, DateTime FechaIni, DateTime FechaFin)
        {
            List<EntityServicioHis> serviciosHis = _businessServicio.GetAllHistorical(IdServicio, FechaIni, FechaFin).Data;

            DataGridViewServicios.DataSource = null;
            DataGridViewServicios.DataSource = serviciosHis;

            DataGridViewServicios.Columns["Id"].Visible = false;
            DataGridViewServicios.Columns["IdServicio"].Visible = false;

            DataGridViewServicios.Columns["Fecha"].HeaderText = SearchTraduccion("DGVColumnaFecha");
            DataGridViewServicios.Columns["Actual"].HeaderText = SearchTraduccion("DGVColumnaActual");
            DataGridViewServicios.Columns["Descripcion"].HeaderText = SearchTraduccion("DGVColumnaDescripcion");
            DataGridViewServicios.Columns["Valor"].HeaderText = SearchTraduccion("DGVColumnaValor");
            DataGridViewServicios.Columns["IsDelete"].HeaderText = SearchTraduccion("DGVColumnaIsDelete");
        }

        private void FillFiltros()
        {
            CmbDescripcion.DataSource = null;
            CmbDescripcion.DataSource = _businessServicio.GetAll(0).Data;
            CmbDescripcion.DisplayMember = "Descripcion";

            CmbDescripcion.SelectedIndex = -1;

            DateTimePickerIni.Value = DateTime.Now.AddMonths(-1);
            DateTimePickerFin.Value = DateTime.Now;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            EntityServicio servicio = CmbDescripcion.SelectedItem as EntityServicio;
            DateTime fechaIni = DateTimePickerIni.Value;
            DateTime fechaFin = DateTimePickerFin.Value;

            if (fechaIni.Date > fechaFin.Date)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageFechaIniMayorFechaFin"));
                return;
            }

            FillDataGridView(servicio is null ? 0 : servicio.Id, fechaIni, fechaFin);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CmbDescripcion.SelectedIndex = -1;

            DateTimePickerIni.Value = DateTime.Now.AddMonths(-1);
            DateTimePickerFin.Value = DateTime.Now;

            FillDataGridView(0, DateTime.MinValue, DateTime.MinValue);
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            if (DataGridViewServicios.SelectedRows.Count == 0)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarCambio"));
                return;
            }

            // Obtén la primera fila seleccionada
            DataGridViewRow selectedRow = DataGridViewServicios.SelectedRows[0];

            EntityServicioHis servicioHis = selectedRow.DataBoundItem as EntityServicioHis;

            EntityServicio servicio = new EntityServicio
            {
                Id = servicioHis.IdServicio,
                Descripcion = servicioHis.Descripcion,
                Valor = servicioHis.Valor,
                IsDelete = servicioHis.IsDelete
            };

            BusinessResponse<bool> response = _businessServicio.Update(servicio);
            RevisarRespuestaServicio(response);

            FillDataGridView(0, DateTime.MinValue, DateTime.MinValue);

            RegistrarEvento("Maestros", "Activacion cambio", 2);
        }

        private void DataGridViewServicios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewServicios.CurrentCell = null;
        }
    }
}
