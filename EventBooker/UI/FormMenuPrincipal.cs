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
        private SessionManager _sessionManager;

        public FormMenuPrincipal()
        {
            InitializeComponent();
            OpenChildForm(new FormInicio());
            _sessionManager = SessionManager.GetInstance();
        }

        private ServiceForm _activeForm = null;

        // Metodo para abrir los formularios hijos en el panel contenedor
        private void OpenChildForm(ServiceForm childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelContenedor.Controls.Add(childForm);
            PanelContenedor.Tag = childForm;
            childForm.Show();
        }

        private void BtnRealizarReserva_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormRealizarReserva());
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormInicio());
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "¿Está seguro de que desea cerrar sesión?",
            "Confirmar Cierre de Sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                InicioSesion inicioSesion = new InicioSesion();
                inicioSesion.Show();
                this.Hide();
            }
        }

        private void BtnGestionUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionUsuarios());
        }

        private void BtnCambiarPassword_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCambiarPassword());
        }
    }
}
