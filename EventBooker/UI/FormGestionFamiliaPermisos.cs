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
    public partial class FormGestionFamiliaPermisos : ServiceForm
    {
        private readonly BusinessPermiso _businessPermiso;

        private Familia EditedFamily;
        private Action<ServiceForm> openChildForm;

        private string Modulo = "Administrador";
        public FormGestionFamiliaPermisos(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();
            this.openChildForm = openChildForm;
            ChangeTranslation();

            _businessPermiso = new BusinessPermiso();
            HidePanelData();
            FillData();
        }

        private void FillData()
        {
            CmbFamilias.DataSource = null;
            CmbFamilias.DataSource = _businessPermiso.GetFamiliaPermisos().Data;
            CmbFamilias.DisplayMember = "Nombre";
            CmbFamilias.SelectedIndex = -1;

            BtnEliminar.Visible = false;
        }


        private void ShowPanelData()
        {
            LblErrorNombreFamilia.Visible = false;
            PanelData.Visible = true;
            ConfigListBox();
        }

        private void ConfigListBox()
        {
            // Configuracion listbox 
            ListBoxFamilias.DataSource = null;
            ListBoxFamilias.DataSource =
                _businessPermiso.GetFamiliaPermisos().Data
                .Where(p => !EditedFamily.Permisos.Any(ef => ef.Id == p.Id) && p.Id != EditedFamily?.Id)
                .ToList();
            ListBoxFamilias.DisplayMember = "Nombre";
            ListBoxFamilias.SelectedIndex = -1;

            ListBoxPermisos.DataSource = null;
            ListBoxPermisos.DataSource =
                _businessPermiso.GetPermisos().Data
                .Where(p => !EditedFamily.Permisos.Any(ef => ef.Id == p.Id))
                .ToList();
            ListBoxPermisos.DisplayMember = "Nombre";
            ListBoxPermisos.SelectedIndex = -1;

            if (EditedFamily != null)
            {
                ListBoxPermisosFamilia.DataSource = null;
                ListBoxPermisosFamilia.DataSource = EditedFamily.Permisos;
                ListBoxPermisosFamilia.DisplayMember = "Nombre";
                ListBoxPermisosFamilia.SelectedIndex = -1;
            }
        }

        private void HidePanelData()
        {
            LblErrorNombreFamilia.Visible = false;
            PanelData.Visible = false;
            TxtNombreFamilia.Text = string.Empty;

            ListBoxFamilias.DataSource = null;
            ListBoxPermisos.DataSource = null;
            ListBoxPermisosFamilia.DataSource = null;
        }

        private void CmbFamilias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbFamilias.SelectedIndex == -1) return;

            IPermiso familiaSeleccionada = CmbFamilias.SelectedItem as IPermiso;

            EditedFamily = _businessPermiso.GetFamiliaPermisos().Data.First(p => p.Id == familiaSeleccionada.Id) as Familia;

            TxtNombreFamilia.Text = familiaSeleccionada.Nombre;
            BtnEliminar.Visible = true;
            ShowPanelData();
        }

        private void BtnNuevaFamilia_Click(object sender, EventArgs e)
        {
            TxtNombreFamilia.Text = string.Empty;
            BtnEliminar.Visible = false;

            CmbFamilias.SelectedIndex = -1;
            EditedFamily = new Familia();
            EditedFamily.Permisos = new List<IPermiso>();
            ShowPanelData();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            IPermiso familia = CmbFamilias.SelectedItem as IPermiso;

            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageDeseaEliminarFamilia")}",
            $"{SearchTraduccion("CaptionConfirmarEliminar")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                BusinessResponse<bool> response = _businessPermiso.DeleteFamilia(familia);
                RevisarRespuestaServicio(response);

                if (response.Ok)
                {
                    RegistrarEvento(Modulo, "Eliminación de familia de permisos", 3);

                    CmbFamilias.SelectedIndex = -1;
                    HidePanelData();
                    FillData();
                }
            }
        }

        private void BtnNuevoPerfil_Click(object sender, EventArgs e)
        {
            this.Close();
            openChildForm(new FormGestionPerfiles(openChildForm));
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            LblErrorNombreFamilia.Visible = false;

            if (string.IsNullOrEmpty(TxtNombreFamilia.Text))
            {
                ShowLabelError(LblErrorNombreFamilia, "LblErrorNombreFamilia");
                return;
            }

            if (EditedFamily.Permisos.Count == 0)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarPermisos"));
                return;
            }

            EditedFamily.Nombre = TxtNombreFamilia.Text.Trim();

            BusinessResponse<bool> response = EditedFamily.Id == 0 ? _businessPermiso.CreateFamilia(EditedFamily) : _businessPermiso.UpdateFamilia(EditedFamily);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                RegistrarEvento(Modulo, EditedFamily.Id == 0 ? "Creación de familia de permisos" : "Modificación de familia de permisos", 3);

                FillData();
                HidePanelData();
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageDeseaCancelarProceso")}",
            $"{SearchTraduccion("CaptionCancelar")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                CmbFamilias.SelectedIndex = -1;
                BtnEliminar.Visible = false;
                HidePanelData();
            }
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            IPermiso permisoSelected;

            if (ListBoxPermisos.SelectedIndex == -1 && ListBoxFamilias.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarPermisos"));
                return;
            }

            permisoSelected = ListBoxPermisos.SelectedIndex != -1 ? ListBoxPermisos.SelectedItem as IPermiso : ListBoxFamilias.SelectedItem as IPermiso;

            IPermiso permisoAgregar = permisoSelected is Familia
                ?
                _businessPermiso.GetFamiliaPermisos().Data
                .First(p => p.Id == permisoSelected.Id)
                :
                _businessPermiso.GetPermisos().Data
                .First(p => p.Id == permisoSelected.Id);


            bool permisoExists = ExistsPermiso(permisoSelected.Id);

            if (permisoAgregar is Familia familiaPermisos && !permisoExists)
            {
                permisoExists = 
                    (EditedFamily.Permisos.Any(item => ExistsPermiso(item.Id, familiaPermisos.Permisos)) || familiaPermisos.Permisos.Any(item => ExistsPermiso(item.Id)));
            }

            if (permisoExists)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageSeTienePermisoEnLista"));
                return;
            }

            EditedFamily.Permisos.Add(permisoAgregar);

            ConfigListBox();
        }

        private void BtnSacar_Click(object sender, EventArgs e)
        {
            if (ListBoxPermisosFamilia.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarPermisos"));
                return;
            }

            IPermiso permisoSelected = ListBoxPermisosFamilia.SelectedItem as IPermiso;

            EditedFamily.Permisos.Remove(permisoSelected);
            ConfigListBox();
        }

        private void ListBoxPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxPermisos.SelectedIndex != -1)
            {
                ListBoxFamilias.SelectedIndex = -1;
                ListBoxPermisosFamilia.SelectedIndex = -1;
            }
        }

        private void ListBoxFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxFamilias.SelectedIndex != -1)
            {
                ListBoxPermisos.SelectedIndex = -1;
                ListBoxPermisosFamilia.SelectedIndex = -1;
            }
        }

        private void ListBoxPermisosFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxPermisosFamilia.SelectedIndex != -1)
            {
                ListBoxPermisos.SelectedIndex = -1;
                ListBoxFamilias.SelectedIndex = -1;
            }
        }

        private bool ExistsPermiso(int idPermiso, List<IPermiso> permisos = null)
        {
            if (permisos == null) permisos = EditedFamily.Permisos;

            foreach (var permiso in permisos)
            {
                if (permiso is Familia permisoFamilia)
                {
                    return ExistsPermiso(idPermiso, permisoFamilia.Permisos);
                }
                if (permiso.Id == idPermiso) return true;
            }

            return false;
        }

    }
}
