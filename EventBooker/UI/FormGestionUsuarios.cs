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
        private List<EntityUser> users;
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
            EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

            if (user is null)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
                return;
            }

            HideButtons(BtnModificar);
            ShowPanelData();

            TxtNombre.Text = user.Nombre;
            TxtApellido.Text = user.Apellido;
            TxtDni.Text = user.Dni.ToString();
            TxtMail.Text = user.Mail;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

            if (BtnCrear.Visible)
            {
                EntityUser user = new EntityUser
                {
                    Nombre = TxtNombre.Text,
                    Apellido = TxtApellido.Text,
                    Dni = Convert.ToInt32(TxtDni.Text),
                    Mail = TxtMail.Text,
                    Username = TxtNombre.Text + TxtApellido.Text,
                    Password = CryptoManager.EncryptString(TxtDni.Text + TxtApellido.Text)
                };

                RevisarRespuestaServicio(_BusinessUser.Create(user));
            }

            if (BtnModificar.Visible)
            {
                EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

                user.Nombre = TxtNombre.Text;
                user.Apellido = TxtApellido.Text;
                user.Dni = Convert.ToInt32(TxtDni.Text);
                user.Mail = TxtMail.Text;
                user.Username = user.Nombre + user.Apellido;

                RevisarRespuestaServicio(_BusinessUser.Update(user));
            }

            FillDataGridView();
            ShowButtons();
            HidePanelData();
        }
        

        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

            if (user is null)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
                return;
            }

            string bloquearMessage = user.IsBlock ? "Desbloquear" : "Bloquear";

            DialogResult result = MessageBox.Show(
            $"¿Está seguro de que desea {bloquearMessage} el usuario {user.Username}?",
            $"Confirmar {bloquearMessage}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                RevisarRespuestaServicio(_BusinessUser.BlockUser(user, false));
                FillDataGridView();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

            if (user is null)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
                return;
            }


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


        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            EntityUser user = DataGridViewUsuarios.SelectedRows[0].DataBoundItem as EntityUser;

            if (user is null)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "Debe seleccionar un usuario"));
                return;
            }


            DialogResult result = MessageBox.Show(
            $"¿Está seguro de que desea resetear la contraseña del usuario {user.Username}?",
            $"Confirmar reset contraseña",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                user.Password = CryptoManager.EncryptString(user.Dni + user.Apellido);

                RevisarRespuestaServicio(_BusinessUser.Update(user));
                FillDataGridView();
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
        }

        private void FillDataGridView()
        {
            users = _BusinessUser.GetAll().Data;
            DataGridViewUsuarios.DataSource = null;
            DataGridViewUsuarios.DataSource = users;
            DataGridViewUsuarios.Columns["Id"].Visible = false;
            DataGridViewUsuarios.Columns["Password"].Visible = false;
        }

        private void ShowPanelData()
        {
            PanelData.Visible = true;

            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtDni.Text = string.Empty;
            TxtMail.Text = string.Empty;
        }

        private void HidePanelData()
        {
            PanelData.Visible = false;

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

    }
}
