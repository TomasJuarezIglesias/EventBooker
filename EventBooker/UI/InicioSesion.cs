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
        private readonly BusinessUser _businessUser;
        private List<EntityUser> _ListaErrorLogeo;

        public InicioSesion()
        {
            InitializeComponent();
            this.KeyPreview = true;
            _businessUser = new BusinessUser();
            _ListaErrorLogeo = new List<EntityUser>();  
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
                ShowLabelError("Debe ingresar usuario",LblErrorUsuario, "LblErrorUsuario", ComboBoxIdiomas.SelectedItem as EntityIdioma);   
                inputError = true;
            }
            
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                ShowLabelError("Debe ingresar contraseña", LblErrorPassword, "LblErrorPassword", ComboBoxIdiomas.SelectedItem as EntityIdioma);
                inputError = true;
            }

            if (inputError) return;


            try
            {
                BusinessResponse<EntityUser> response = _businessUser.VerifyCredentials(TxtUsername.Text, TxtPassword.Text);

                RevisarRespuestaServicio(response, ComboBoxIdiomas.SelectedItem as EntityIdioma);

                if (response.Data?.IsBlock == true) return;

                // Logica para manejo de intentos fallidos
                if (!response.Ok && response.Data?.IsBlock == false)
                {
                    _ListaErrorLogeo.Add(response.Data);

                    if (_ListaErrorLogeo.Where(users => users.Id == response.Data.Id).Count() == 3)
                    {

                        RevisarRespuestaServicio(_businessUser.BlockUser(response.Data), ComboBoxIdiomas.SelectedItem as EntityIdioma);
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
                Console.WriteLine(ex.Message);
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

        private void InicioSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnIngresar_Click(sender, e);
            }
        }
    }
}
