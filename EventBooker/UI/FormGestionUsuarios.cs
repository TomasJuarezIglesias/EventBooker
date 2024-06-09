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

        public FormGestionUsuarios()
        {
            InitializeComponent();
            _BusinessUser = new BusinessUser();
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
                EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

                HideButtons(BtnModificar);
                ShowPanelData();

                TxtNombre.Text = user.Nombre.Trim();
                TxtApellido.Text = user.Apellido.Trim();
                TxtDni.Text = user.Dni.ToString().Trim();
                TxtMail.Text = user.Mail.Trim();
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
            }
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

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
                    Password = TxtDni.Text.Trim() + TxtApellido.Text.Trim()
                };

                response = _BusinessUser.Create(user);
                RevisarRespuestaServicio(response);
            }

            if (BtnModificar.Visible)
            {
                EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

                user.Nombre = TxtNombre.Text.Trim();
                user.Apellido = TxtApellido.Text.Trim();
                user.Dni = Convert.ToInt32(TxtDni.Text.Trim());
                user.Mail = TxtMail.Text.Trim();
                user.Username = user.Dni + user.Nombre;

                response = _BusinessUser.Update(user);
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
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
                return;
            }

            DialogResult result = MessageBox.Show(
            $"¿Está seguro de que desea Desbloquear el usuario {user.Username}?",
            $"Confirmar Desbloquear",
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
                $"¿Está seguro de que desea eliminar el usuario {user.Username}?",
                $"Confirmar eliminar",
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
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
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
            DataGridViewUsuarios.Columns["Username"].HeaderText = "Usuario";
            DataGridViewUsuarios.Columns["IsBlock"].HeaderText = "Bloqueado";

            LblCantidadUsuarios.Text = $"Cantidad de usuarios: {users.Count}";
            LblUsuariosBloqueados.Text = $"Usuarios Bloqueados: {users.Where(user => user.IsBlock).Count()}";

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
                ShowLabelError("Debe Ingresar el nombre", LblErrorNombre);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtApellido.Text))
            {
                ShowLabelError("Debe Ingresar el apellido", LblErrorApellido);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtDni.Text))
            {
                ShowLabelError("Debe ingresar dni", LblErrorDni);
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtDni.Text) && !RegexValidationService.IsValidDni(TxtDni.Text))
            {
                ShowLabelError("Formato del dni incorrecto", LblErrorDni);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtMail.Text))
            {
                ShowLabelError("Debe ingresar mail", LblErrorMail);
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtMail.Text) && !RegexValidationService.IsValidEmail(TxtMail.Text))
            {
                ShowLabelError("Formato del mail incorrecto", LblErrorMail);
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
