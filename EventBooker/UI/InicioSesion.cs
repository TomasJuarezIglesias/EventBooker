using Bunifu.UI.WinForms;
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
        private SessionManager _sessionManager;
        private readonly BusinessUser _bussinesUser;
        private List<EntityUser> _ListaErrorLogeo;

        public InicioSesion()
        {
            InitializeComponent();
            _bussinesUser = new BusinessUser();
            _ListaErrorLogeo = new List<EntityUser>();  
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            HideLabelError(new List<BunifuLabel>()
            {
                LblErrorUsuario,
                LblErrorPassword
            });

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


            try
            {
                BusinessResponse<EntityUser> response = _bussinesUser.VerifyCredentials(TxtUsername.Text, TxtPassword.Text);

                RevisarRespuestaServicio(response);

                if (response.Data?.IsBlock == true) return;

                // Logica para manejo de intentos fallidos
                if (!response.Ok && response.Data?.IsBlock == false)
                {
                    _ListaErrorLogeo.Add(response.Data);

                    if (_ListaErrorLogeo.Where(users => users.Id == response.Data.Id).Count() == 3)
                    {

                        RevisarRespuestaServicio(_bussinesUser.BlockUser(response.Data, true));
                    }
                }

                if (response.Ok)
                {
                    _sessionManager = SessionManager.Login(response.Data);

                    FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
                    menuPrincipal.Show();
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false,false,ex.Message));
            }
            
        }
    }
}
