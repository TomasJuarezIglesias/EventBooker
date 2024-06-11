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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class InicioSesion : ServiceForm
    {
        private SessionManager _sessionManager;
        private readonly BusinessUser _businessUser;
        private List<EntityUser> _ListaErrorLogeo;

        private BusinessIdioma _businessIdioma;
        public InicioSesion()
        {
            InitializeComponent();
            _businessUser = new BusinessUser();
            _ListaErrorLogeo = new List<EntityUser>();  
            _businessIdioma = new BusinessIdioma();
            FillIdiomas();
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
                BusinessResponse<EntityUser> response = _businessUser.VerifyCredentials(TxtUsername.Text, TxtPassword.Text);

                RevisarRespuestaServicio(response);

                if (response.Data?.IsBlock == true) return;

                // Logica para manejo de intentos fallidos
                if (!response.Ok && response.Data?.IsBlock == false)
                {
                    _ListaErrorLogeo.Add(response.Data);

                    if (_ListaErrorLogeo.Where(users => users.Id == response.Data.Id).Count() == 3)
                    {

                        RevisarRespuestaServicio(_businessUser.BlockUser(response.Data));
                    }
                }

                if (response.Ok)
                {
                    EntityIdioma idioma = ComboBoxIdiomas.SelectedItem as EntityIdioma;

                    _sessionManager = SessionManager.Login(response.Data, idioma);

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

        private void FillIdiomas()
        {
            ComboBoxIdiomas.Items.Clear();
            BusinessResponse<List<EntityIdioma>> response = _businessIdioma.GetAll();
            ComboBoxIdiomas.Items.AddRange(response.Data.ToArray());
            ComboBoxIdiomas.DisplayMember = "Idioma";
            ComboBoxIdiomas.SelectedIndex = 0;
        }

        private void ComboBoxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            EntityIdioma idioma = ComboBoxIdiomas.SelectedItem as EntityIdioma;

            IPublisher publisher = new LanguageManager();
            publisher.AddObserver(this);
            publisher.NotifyAll(idioma);
        }
    }
}
