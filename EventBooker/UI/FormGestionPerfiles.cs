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
    public partial class FormGestionPerfiles : ServiceForm
    {
        private readonly BusinessPermiso _businessPermiso;
        private readonly BusinessPerfil _businessPerfil;
        private Action<ServiceForm> openChildForm;

        private EntityPerfil EditedPerfil;
        private string Modulo = "Administrador";

        public FormGestionPerfiles(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();
            this.openChildForm = openChildForm;
            ChangeTranslation();

            _businessPerfil = new BusinessPerfil();
            _businessPermiso = new BusinessPermiso();
            HidePanelData();
            FillData();
        }

        private void FillData()
        {
            CmbPerfiles.DataSource = null;
            CmbPerfiles.DataSource = _businessPerfil.GetAll().Data;
            CmbPerfiles.DisplayMember = "Descripcion";
            CmbPerfiles.SelectedIndex = -1;

            BtnEliminar.Visible = false;
        }

        private void ShowPanelData()
        {
            LblErrorNombrePerfil.Visible = false;
            PanelData.Visible = true;
            ConfigListBox();
        }

        private void ConfigListBox()
        {
            // Configuracion listbox 
            ListBoxFamilias.DataSource = null;
            ListBoxFamilias.DataSource =
                _businessPermiso.GetFamiliaPermisos().Data
                .Where(p => !EditedPerfil.Permisos.Any(ef => ef.Id == p.Id))
                .ToList();
            ListBoxFamilias.DisplayMember = "Nombre";
            ListBoxFamilias.SelectedIndex = -1;

            ListBoxPermisos.DataSource = null;
            ListBoxPermisos.DataSource =
                _businessPermiso.GetPermisos().Data
                .Where(p => !EditedPerfil.Permisos.Any(ef => ef.Id == p.Id))
                .ToList();
            ListBoxPermisos.DisplayMember = "Nombre";
            ListBoxPermisos.SelectedIndex = -1;

            if (EditedPerfil != null)
            {
                ListBoxPermisosPerfil.DataSource = null;
                ListBoxPermisosPerfil.DataSource = EditedPerfil.Permisos;
                ListBoxPermisosPerfil.DisplayMember = "Nombre";
                ListBoxPermisosPerfil.SelectedIndex = -1;
            }
        }

        private void HidePanelData()
        {
            LblErrorNombrePerfil.Visible = false;
            PanelData.Visible = false;
            TxtNombrePerfil.Text = string.Empty;

            ListBoxFamilias.DataSource = null;
            ListBoxPermisos.DataSource = null;
            ListBoxPermisosPerfil.DataSource = null;
        }

        private void CmbPerfiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbPerfiles.SelectedIndex == -1) return;

            EntityPerfil perfil = CmbPerfiles.SelectedItem as EntityPerfil;

            EditedPerfil = _businessPerfil.GetAll().Data.First(p => p.Id == perfil.Id) as EntityPerfil;

            TxtNombrePerfil.Text = EditedPerfil.Descripcion;
            BtnEliminar.Visible = true;
            ShowPanelData();
        }

        private void BtnNuevoPerfil_Click(object sender, EventArgs e)
        {
            TxtNombrePerfil.Text = string.Empty;
            BtnEliminar.Visible = false;

            CmbPerfiles.SelectedIndex = -1;
            EditedPerfil = new EntityPerfil();
            EditedPerfil.Permisos = new List<IPermiso>();
            ShowPanelData();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EntityPerfil perfil = CmbPerfiles.SelectedItem as EntityPerfil;

            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageDeseaEliminarPerfil")}",
            $"{SearchTraduccion("CaptionConfirmarEliminar")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                BusinessResponse<bool> response = _businessPerfil.Delete(perfil);
                RevisarRespuestaServicio(response);

                if (response.Ok)
                {
                    RegistrarEvento(Modulo, "Eliminación de perfil", 3);

                    CmbPerfiles.SelectedIndex = -1;
                    HidePanelData();
                    FillData();
                }
            }
        }

        private void BtnCrearFamilia_Click(object sender, EventArgs e)
        {
            this.Close();
            openChildForm(new FormGestionFamiliaPermisos(openChildForm));
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            LblErrorNombrePerfil.Visible = false;

            if (string.IsNullOrEmpty(TxtNombrePerfil.Text))
            {
                ShowLabelError(LblErrorNombrePerfil, "LblErrorNombrePerfil");
                return;
            }

            if (EditedPerfil.Permisos.Count == 0)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarPermisos"));
                return;
            }

            EditedPerfil.Descripcion = TxtNombrePerfil.Text.Trim();

            BusinessResponse<bool> response = EditedPerfil.Id == 0 ? _businessPerfil.Create(EditedPerfil) : _businessPerfil.Update(EditedPerfil);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                RegistrarEvento(Modulo, EditedPerfil.Id == 0 ? "Creación de perfil" : "Modificación de perfil", 3);

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
                CmbPerfiles.SelectedIndex = -1;
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
                permisoExists = familiaPermisos.Permisos.Any(item => ExistsPermiso(item.Id));
            }

            if (permisoExists)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageSeTienePermisoEnLista"));
                return;
            }

            EditedPerfil.Permisos.Add(permisoAgregar);

            ConfigListBox();
        }

        private bool ExistsPermiso(int idPermiso, List<IPermiso> permisos = null)
        {
            if (permisos == null) permisos = EditedPerfil.Permisos;

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

        private void BtnSacar_Click(object sender, EventArgs e)
        {
            if (ListBoxPermisosPerfil.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarPermisos"));
                return;
            }

            IPermiso permisoSelected = ListBoxPermisosPerfil.SelectedItem as IPermiso;

            EditedPerfil.Permisos.Remove(permisoSelected);
            ConfigListBox();
        }

        private void ListBoxPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxPermisos.SelectedIndex != -1)
            {
                ListBoxFamilias.SelectedIndex = -1;
                ListBoxPermisosPerfil.SelectedIndex = -1;
            }
        }

        private void ListBoxFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxFamilias.SelectedIndex != -1)
            {
                ListBoxPermisos.SelectedIndex = -1;
                ListBoxPermisosPerfil.SelectedIndex = -1;
            }
        }

        private void ListBoxPermisosPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxPermisosPerfil.SelectedIndex != -1)
            {
                ListBoxPermisos.SelectedIndex = -1;
                ListBoxFamilias.SelectedIndex = -1;
            }
        }
    }
}
