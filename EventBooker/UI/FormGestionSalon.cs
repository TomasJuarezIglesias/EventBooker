using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
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
    public partial class FormGestionSalon : ServiceForm
    {
        private readonly BusinessSalon _businessSalon;
        private string Modulo = "Maestros";

        public FormGestionSalon()
        {
            InitializeComponent();
            ChangeTranslation();
            _businessSalon = new BusinessSalon();
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
                EntitySalon salon = DataGridViewSalones.SelectedRows[0].DataBoundItem as EntitySalon;

                HideButtons(BtnModificar);
                ShowPanelData();


                TxtNombre.Text = salon.Nombre;
                TxtUbicacion.Text = salon.Ubicacion;
                TxtPrecio.Text = salon.Precio.ToString();
                TxtPrecioCubierto.Text = salon.PrecioCubierto.ToString();
                NumCapacidad.Value = salon.Capacidad;
                NumCantidadMinimaInvitados.Value = salon.CantidadMinimaInvitados;
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarSalon"));
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EntitySalon salon = DataGridViewSalones.SelectedRows[0].DataBoundItem as EntitySalon;

                DialogResult result = MessageBox.Show(
                $"{SearchTraduccion("MessageDeseaEliminarSalon")}",
                $"{SearchTraduccion("CaptionConfirmarEliminar")}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Verifica el resultado de la selección del usuario
                if (result == DialogResult.Yes)
                {
                    RegistrarEvento(Modulo, "Eliminación de salón", 2);
                    
                    RevisarRespuestaServicio(_businessSalon.Delete(salon));
                    FillDataGridView();
                }
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarSalon"));
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

            BusinessResponse<bool> response = new BusinessResponse<bool>(false, false, "");

            if (BtnCrear.Visible)
            {
                EntitySalon salon = new EntitySalon
                {
                    Nombre = TxtNombre.Text.Trim(),
                    Ubicacion = TxtUbicacion.Text.Trim(),
                    Precio = double.Parse(TxtPrecio.Text.Trim()),
                    PrecioCubierto = double.Parse(TxtPrecioCubierto.Text.Trim()),
                    Capacidad = Convert.ToInt32(NumCapacidad.Value),
                    CantidadMinimaInvitados = Convert.ToInt32(NumCantidadMinimaInvitados.Value)
                };

                response = _businessSalon.Create(salon);

                RevisarRespuestaServicio(response);
            }

            if (BtnModificar.Visible)
            {
                EntitySalon salon = DataGridViewSalones.SelectedRows[0].DataBoundItem as EntitySalon;

                EntitySalon salonUpdated = new EntitySalon
                {
                    Id = salon.Id,
                    Nombre = TxtNombre.Text.Trim(),
                    Ubicacion = TxtUbicacion.Text.Trim(),
                    Precio = double.Parse(TxtPrecio.Text.Trim()),
                    PrecioCubierto = double.Parse(TxtPrecioCubierto.Text.Trim()),
                    Capacidad = Convert.ToInt32(NumCapacidad.Value),
                    CantidadMinimaInvitados = Convert.ToInt32(NumCantidadMinimaInvitados.Value)
                };

                response = _businessSalon.Update(salonUpdated);

                RevisarRespuestaServicio(response);
            }



            if (response.Ok)
            {
                RegistrarEvento(Modulo, BtnCrear.Visible ? "Creación de salón" : "Modificación de salón", 3);

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
                LblErrorNombre,
                LblErrorUbicacion,
                LblErrorPrecio,
                LblErrorPrecioCubierto,
                LblErrorCapacidad,
                LblErrorCantidadMinimaInvitados
            });
            HidePanelData();
            DataGridViewSalones.CurrentCell = null;
        }



        private void FillDataGridView()
        {
            List<EntitySalon> salones = _businessSalon.GetAll().Data;

            DataGridViewSalones.DataSource = null;
            DataGridViewSalones.DataSource = salones;

            DataGridViewSalones.Columns["Id"].Visible = false;

            DataGridViewSalones.Columns["PrecioCubierto"].HeaderText = SearchTraduccion("DGVColumnaPrecioCubierto");
            DataGridViewSalones.Columns["CantidadMinimaInvitados"].HeaderText = SearchTraduccion("DGVColumnaCantidadMinimaInvitados");
            DataGridViewSalones.Columns["Nombre"].HeaderText = SearchTraduccion("DGVColumnaNombre");
            DataGridViewSalones.Columns["Ubicacion"].HeaderText = SearchTraduccion("DGVColumnaUbicacion");
            DataGridViewSalones.Columns["Precio"].HeaderText = SearchTraduccion("DGVColumnaPrecio");
            DataGridViewSalones.Columns["Capacidad"].HeaderText = SearchTraduccion("DGVColumnaCapacidad");
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
            TxtNombre.Text = string.Empty;
            TxtUbicacion.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
            TxtPrecioCubierto.Text = string.Empty;
            NumCapacidad.Value = 0; 
            NumCantidadMinimaInvitados.Value = 0;
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
                LblErrorNombre,
                LblErrorUbicacion,
                LblErrorPrecio,
                LblErrorPrecioCubierto,
                LblErrorCapacidad,
                LblErrorCantidadMinimaInvitados
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtNombre.Text))
            {
                ShowLabelError(LblErrorNombre, "LblErrorNombre");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtUbicacion.Text))
            {
                ShowLabelError(LblErrorUbicacion, "LblErrorUbicacion");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtPrecio.Text) || !double.TryParse(TxtPrecio.Text, out double _))
            {
                ShowLabelError(LblErrorPrecio, "LblErrorPrecio");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtPrecioCubierto.Text) || !double.TryParse(TxtPrecioCubierto.Text, out double _))
            {
                ShowLabelError(LblErrorPrecioCubierto, "LblErrorPrecioCubierto");
                ok = false;
            }

            if (NumCapacidad.Value <= 0)
            {
                ShowLabelError(LblErrorCapacidad, "LblErrorCapacidad");
                ok = false;
            }

            if (NumCantidadMinimaInvitados.Value <= 0 || NumCapacidad.Value < NumCantidadMinimaInvitados.Value)
            {
                ShowLabelError(LblErrorCantidadMinimaInvitados, "LblErrorCantidadMinimaInvitados");
                ok = false;
            }

            return ok;
        }


        private void DataGridViewSalones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewSalones.CurrentCell = null;
        }

    }
}
