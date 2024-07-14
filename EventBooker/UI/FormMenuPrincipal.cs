using Business;
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
    public partial class FormMenuPrincipal : ServiceForm
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
            CustomView();
            OpenChildForm(new FormInicio());
            ChangeTranslation();
            CheckPermissions();
        }

        private ServiceForm _activeForm = null;

        // Metodo para abrir los formularios hijos en el panel contenedor
        private void OpenChildForm(ServiceForm childForm)
        {
            _activeForm?.Close();

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelContenedor.Controls.Add(childForm);
            PanelContenedor.Tag = childForm;
            childForm.Show();
        }

        // Personalizar el inicio del form
        private void CustomView()
        {
            PanelAdministrador.Visible = false;
            PanelMaestros.Visible = false;
            PanelCobranza.Visible = false;
        }

        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void HideSubmenu()
        {
            if (PanelAdministrador.Visible)
                PanelAdministrador.Visible = false;

            if (PanelMaestros.Visible)
                PanelMaestros.Visible = false;

            if (PanelCobranza.Visible)
                PanelCobranza.Visible = false;
        }

        private void BtnAdministrador_Click(object sender, EventArgs e)
        {
            ShowSubmenu(PanelAdministrador);
        }

        private void BtnMaestros_Click(object sender, EventArgs e)
        {
            ShowSubmenu(PanelMaestros);
        }

        private void BtnCobranza_Click(object sender, EventArgs e)
        {
            ShowSubmenu(PanelCobranza);
        }

        // Inicio
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInicio());
            HideSubmenu();
        }

        // Administrador

        private void BtnGestionUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionUsuarios());
            HideSubmenu();
        }

        private void BtnPerfiles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionPerfiles(OpenChildForm));
            HideSubmenu();
        }

        // Maestros

        private void BtnGestionSalon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionSalon());
            HideSubmenu();
        }

        private void BtnGestionServicios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionServicio());
            HideSubmenu();
        }

        private void BtnGestionClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionClientes());
            HideSubmenu();
        }

        // Registrar Reserva

        private void BtnRegistrarReserva_Click(object sender, EventArgs e)
        {
            HideSubmenu();
            OpenChildForm(new FormRegistrarReserva(OpenChildForm));
        }

        // Cobranza

        private void BtnCollectDeposit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCollectDeposit());
            HideSubmenu();
        }

        // Usuario

        private void BtnCambiarPassword_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCambiarPassword(this));
            HideSubmenu();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageCerrarSesion")}",
            $"{SearchTraduccion("CaptionCerrarSesion")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                InicioSesion inicioSesion = new InicioSesion();
                inicioSesion.Show();
                this.Close();
            }
        }

        private void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            FormIdioma formIdioma = new FormIdioma(this);
            formIdioma.ShowDialog();
        }

        private void CheckPermissions()
        {
            BtnAdministrador.Visible = _sessionManager.HasPermission(1);
            BtnMaestros.Visible = _sessionManager.HasPermission(2);
            BtnRegistrarReserva.Visible = _sessionManager.HasPermission(3);
            BtnCobranza.Visible = _sessionManager.HasPermission(4);
            BtnReportes.Visible = _sessionManager.HasPermission(5);
        }
    }
}
