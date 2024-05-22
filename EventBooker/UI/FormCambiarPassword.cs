using Bunifu.UI.WinForms;
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
    public partial class FormCambiarPassword : ServiceForm
    {
        private SessionManager _sessionManager;
        private ServiceForm _formMenuPrincipal;
        private readonly BusinessAuth _businessAuth;

        public FormCambiarPassword(ServiceForm formMenuPrincipal)
        {
            InitializeComponent();
            _sessionManager = SessionManager.GetInstance();
            _businessAuth = new BusinessAuth();
            _formMenuPrincipal = formMenuPrincipal;
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorActualPass,
                LblErrorNewPass,
                LblErrorNewPassRep
            });

            bool inputError = false;

            if (string.IsNullOrEmpty(TxtActualPass.Text))
            {
                ShowLabelError("Debe ingresar contraseña actual", LblErrorActualPass);
                inputError = true;
            }

            if (string.IsNullOrEmpty(TxtNewPass.Text))
            {
                ShowLabelError("Debe ingresar nueva contraseña", LblErrorNewPass);
                inputError = true;
            }

            if (string.IsNullOrEmpty(TxtNewPassRep.Text))
            {
                ShowLabelError("Debe repetir la nueva contraseña", LblErrorNewPassRep);
                inputError = true;
            }

            if (inputError) return;


            BusinessResponse<bool> response = _businessAuth.ChangePassword(_sessionManager.User, TxtActualPass.Text, TxtNewPass.Text, TxtNewPassRep.Text);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                SessionManager.Logout();
                InicioSesion inicioSesion = new InicioSesion();
                inicioSesion.Show();
                _formMenuPrincipal.Close();
            }
        }
    }
}
