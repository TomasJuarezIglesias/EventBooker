using Bunifu.UI.WinForms.BunifuButton;
using Bunifu.UI.WinForms;
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
    public partial class FormGestionServicio : ServiceForm
    {
        private readonly BusinessServicio _businessServicio;

        public FormGestionServicio()
        {
            InitializeComponent();
            ChangeTranslation();
            _businessServicio = new BusinessServicio();
            FillDataGridView();
            HidePanelData();
        }


        private void BtnCrear_Click(object sender, EventArgs e)
        {
            HideButtons(BtnCrear);
            ShowPanelData();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                EntityServicio servicio = DataGridViewServicios.SelectedRows[0].DataBoundItem as EntityServicio;

                HideButtons(BtnModificar);
                ShowPanelData();

                TxtDescripcion.Text = servicio.Descripcion;
                TxtValor.Text = servicio.Valor.ToString();

            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageSeleccionarServicio"));
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EntityServicio servicio = DataGridViewServicios.SelectedRows[0].DataBoundItem as EntityServicio;

                DialogResult result = MessageBox.Show(
                $"{SearchTraduccion("MessageDeseaEliminarServicio")}",
                $"{SearchTraduccion("CaptionConfirmarEliminar")}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Verifica el resultado de la selección del usuario
                if (result == DialogResult.Yes)
                {
                    RevisarRespuestaServicio(_businessServicio.Delete(servicio));
                    FillDataGridView();
                }
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageSeleccionarServicio"));
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

            BusinessResponse<bool> response = new BusinessResponse<bool>(false, false, "");

            if (BtnCrear.Visible)
            {
                EntityServicio servicio = new EntityServicio
                {
                    Descripcion = TxtDescripcion.Text.Trim(),
                    Valor = Convert.ToDouble(TxtValor.Text.Trim())
                };

                response = _businessServicio.Create(servicio);

                RevisarRespuestaServicio(response);
            }

            if (BtnModificar.Visible)
            {

                EntityServicio servicio = DataGridViewServicios.SelectedRows[0].DataBoundItem as EntityServicio;

                EntityServicio servicioUpdated = new EntityServicio
                {
                    Id = servicio.Id,
                    Descripcion = TxtDescripcion.Text.Trim(),
                    Valor = Convert.ToDouble(TxtValor.Text.Trim())
                };

                response = _businessServicio.Update(servicioUpdated);

                RevisarRespuestaServicio(response);
            }


            if (response.Ok)
            {
                FillDataGridView();
                ShowButtons();
                HidePanelData();
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ShowButtons();
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorDescripcion,
                LblErrorValor
            });
            HidePanelData();
            DataGridViewServicios.CurrentCell = null;
        }



        private void FillDataGridView()
        {
            List<EntityServicio> servicios = _businessServicio.GetAll().Data;

            DataGridViewServicios.DataSource = null;
            DataGridViewServicios.DataSource = servicios;

            DataGridViewServicios.Columns["Id"].Visible = false;

            DataGridViewServicios.Columns["Descripcion"].HeaderText = SearchTraduccion("DGVColumnaDescripcion");
            DataGridViewServicios.Columns["Valor"].HeaderText = SearchTraduccion("DGVColumnaValor");
        }

        private void ShowPanelData()
        {
            PanelData.Visible = true;
            EmptyTextBox();
        }

        private void HidePanelData()
        {
            PanelData.Visible = false;
            EmptyTextBox();
        }

        private void EmptyTextBox()
        {
            TxtDescripcion.Text = string.Empty;
            TxtValor.Text = string.Empty;
        }

        private void ShowButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is BunifuButton)
                {
                    control.Visible = true;
                }
            }
        }
        private void HideButtons(BunifuButton button)
        {
            foreach (Control control in this.Controls)
            {
                if (control is BunifuButton && control != button)
                {
                    control.Visible = false;
                }
            }
        }

        private bool ValidateTextBox()
        {
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorDescripcion,
                LblErrorValor
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtDescripcion.Text))
            {
                ShowLabelError(LblErrorDescripcion, "LblErrorDescripcion");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtValor.Text) || !double.TryParse(TxtValor.Text, out double _))
            {
                ShowLabelError(LblErrorValor, "LblErrorValor");
                ok = false;
            }


            return ok;
        }

        private void DataGridViewServicios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewServicios.CurrentCell = null;
        }
    }
}
