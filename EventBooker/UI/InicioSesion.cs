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
    public partial class InicioSesion : ServiceForm
    {
        private readonly BusinessAuth _bussinesAuth;
        private SessionManager _sessionManager;
        public InicioSesion()
        {
            InitializeComponent();
            _bussinesAuth = new BusinessAuth();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            bool inputError = false;

            if (string.IsNullOrEmpty(TxtUsername.Text))
            {
                ShowLabelError("Debe ingresar usuario",LblErrorUsuario);   
                inputError = true;
            }
            
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                ShowLabelError("Debe ingresar contraseña", LblErrorPassword);
                inputError = true;
            }

            if (inputError) return;

            BusinessResponse<EntityUser> response = _bussinesAuth.Login(TxtUsername.Text, TxtPassword.Text);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                _sessionManager = SessionManager.Login(response.Data);

            }
        }
    }
}
