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
    public partial class FormGestionUsuarios : ServiceForm
    {
        private BusinessUser _BusinessUser;
        private BusinessPerfil _BusinessPerfil;

        public FormGestionUsuarios()
        {
            InitializeComponent();
            _BusinessUser = new BusinessUser();
            _BusinessPerfil = new BusinessPerfil();
            ChangeTranslation();
            FillDataGridView();
            HidePanelData();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            HideButtons(BtnCrear);
            ShowPanelData();

            CmbPerfiles.DataSource = null;
            CmbPerfiles.DataSource = _BusinessPerfil.GetAll().Data;
            CmbPerfiles.DisplayMember = "Descripcion";
            CmbPerfiles.SelectedIndex = -1;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

                HideButtons(BtnModificar);
                ShowPanelData();

                TxtNombre.Text = user.Nombre.Trim();
                TxtApellido.Text = user.Apellido.Trim();
                TxtDni.Text = user.Dni.ToString().Trim();
                TxtMail.Text = user.Mail.Trim();

                List<EntityPerfil> perfil = _BusinessPerfil.GetAll().Data;

                CmbPerfiles.DataSource = null;
                CmbPerfiles.DataSource = perfil;
                CmbPerfiles.DisplayMember = "Descripcion";
                CmbPerfiles.SelectedItem = perfil.First( p => p.Id == user.Perfil.Id);
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarUsuario"));
            }
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

            if (CmbPerfiles.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarPerfil"));
                return;
            }

            BusinessResponse<bool> response = new BusinessResponse<bool>(false, false, "");

            if (BtnCrear.Visible)
            {
                EntityUser user = new EntityUser
                {
                    Nombre = TxtNombre.Text.Trim(),
                    Apellido = TxtApellido.Text.Trim(),
                    Dni = Convert.ToInt32(TxtDni.Text.Trim()),
                    Mail = TxtMail.Text.Trim(),
                    Username = TxtDni.Text.Trim() + TxtNombre.Text.Trim(),
                    Password = TxtDni.Text.Trim() + TxtApellido.Text.Trim(),
                    Perfil = CmbPerfiles.SelectedItem as EntityPerfil
                };

                response = _BusinessUser.Create(user);
                RevisarRespuestaServicio(response);
            }

            if (BtnModificar.Visible)
            {
                EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

                // Nueva instancia para no afectar a la lista
                EntityUser userUpdated = new EntityUser
                {
                    Id = user.Id,
                    Nombre = TxtNombre.Text.Trim(),
                    Apellido = TxtApellido.Text.Trim(),
                    Dni = Convert.ToInt32(TxtDni.Text.Trim()),
                    Mail = TxtMail.Text.Trim(),
                    Username = TxtDni.Text.Trim() + TxtNombre.Text.Trim(),
                    Password = user.Password,
                    IsBlock = user.IsBlock,
                    Perfil = CmbPerfiles.SelectedItem as EntityPerfil
                };

                response = _BusinessUser.Update(userUpdated);
                RevisarRespuestaServicio(response);
            }

            

            if (response.Ok)
            {
                FillDataGridView();
                ShowButtons();
                HidePanelData();
                BtnDesbloquear.Visible = false;
            }
        }

        private void BtnDesbloquear_Click(object sender, EventArgs e)
        {
            EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

            if (user is null)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarUsuario"));
                return;
            }

            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageDeseaDesbloquearUsuario")}",
            $"{SearchTraduccion("CaptionConfirmarDesbloquear")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                RevisarRespuestaServicio(_BusinessUser.UnblockUser(user));
                FillDataGridView();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

                DialogResult result = MessageBox.Show(
                $"{SearchTraduccion("MessageDeseaEliminarUsuario")}",
                $"{SearchTraduccion("CaptionConfirmarEliminar")}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Verifica el resultado de la selección del usuario
                if (result == DialogResult.Yes)
                {
                    RevisarRespuestaServicio(_BusinessUser.Delete(user));
                    FillDataGridView();
                }
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarUsuario"));
            }
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ShowButtons();
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorNombre,
                LblErrorApellido,
                LblErrorDni,
                LblErrorMail
            });
            HidePanelData();
            DataGridViewUsuarios.CurrentCell = null;
            BtnDesbloquear.Visible = false;
        }

        private void FillDataGridView()
        {
            List<EntityUser> users = _BusinessUser.GetAll().Data.Where(user => user.Id != SessionManager.GetInstance().User.Id).ToList();

            DataGridViewUsuarios.DataSource = null;
            DataGridViewUsuarios.DataSource = users;

            // Oculto datos
            DataGridViewUsuarios.Columns["Id"].Visible = false;
            DataGridViewUsuarios.Columns["Password"].Visible = false;

            // Cambio de nombre de columnas
            DataGridViewUsuarios.Columns["Username"].HeaderText = SearchTraduccion("DGVColumnaUsuario");
            DataGridViewUsuarios.Columns["IsBlock"].HeaderText = SearchTraduccion("DGVColumnaBloqueado");
            DataGridViewUsuarios.Columns["Dni"].HeaderText = SearchTraduccion("DGVColumnaDni");
            DataGridViewUsuarios.Columns["Nombre"].HeaderText = SearchTraduccion("DGVColumnaNombre");
            DataGridViewUsuarios.Columns["Apellido"].HeaderText = SearchTraduccion("DGVColumnaApellido");
            DataGridViewUsuarios.Columns["Mail"].HeaderText = SearchTraduccion("DGVColumnaMail");
            DataGridViewUsuarios.Columns["Perfil"].HeaderText = SearchTraduccion("DGVColumnaDescripcion");

            LblCantidadUsuarios.Text = $"{SearchTraduccion("LblCantidadUsuarios")} {users.Count}";
            LblUsuariosBloqueados.Text = $"{SearchTraduccion("LblUsuariosBloqueados")} {users.Where(user => user.IsBlock).Count()}";

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
            TxtApellido.Text = string.Empty;
            TxtDni.Text = string.Empty;
            TxtMail.Text = string.Empty;
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
                LblErrorApellido,
                LblErrorDni,
                LblErrorMail
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtNombre.Text))
            {
                ShowLabelError("Debe Ingresar el nombre", LblErrorNombre, "LblErrorNombre");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtApellido.Text))
            {
                ShowLabelError("Debe Ingresar el apellido", LblErrorApellido, "LblErrorApellido");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtDni.Text))
            {
                ShowLabelError("Debe ingresar dni", LblErrorDni, "LblErrorDni");
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtDni.Text) && !RegexValidationService.IsValidDni(TxtDni.Text))
            {
                ShowLabelError("Formato del dni incorrecto", LblErrorDni, "MessageFormatoDniIncorrecto");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtMail.Text))
            {
                ShowLabelError("Debe ingresar mail", LblErrorMail, "LblErrorMail");
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtMail.Text) && !RegexValidationService.IsValidEmail(TxtMail.Text))
            {
                ShowLabelError("Formato del mail incorrecto", LblErrorMail, "MessageFormatoMailIncorrecto");
                ok = false;
            }

            return ok;
        }

        private void DataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

            BtnDesbloquear.Visible = !(PanelData.Visible || user?.IsBlock == false);
        }

        private void DataGridViewUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewUsuarios.CurrentCell = null;
            BtnDesbloquear.Visible = false;
        }
    }
}
