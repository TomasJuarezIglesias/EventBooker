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
        private IPublisher _publisher;
        private string Modulo = "Login";

        public InicioSesion()
        {
            InitializeComponent();
            this.KeyPreview = true;
            _businessUser = new BusinessUser();
            _ListaErrorLogeo = new List<EntityUser>();

            _publisher = new LanguageManager();
            _publisher.AddObserver(this);
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
                ShowLabelError(LblErrorUsuario, "LblErrorUsuario", ComboBoxIdiomas.SelectedItem as EntityIdioma);   
                inputError = true;
            }
            
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                ShowLabelError(LblErrorPassword, "LblErrorPassword", ComboBoxIdiomas.SelectedItem as EntityIdioma);
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

                        RegistrarEvento(Modulo, "Bloqueo de usuario", 1);

                        return;
                    }
                }

                if (!response.Ok)
                {
                    return;
                }

                // Hago instancia del sesion manager con el idioma seleccionado
                EntityIdioma idioma = ComboBoxIdiomas.SelectedItem as EntityIdioma;

                _sessionManager = SessionManager.Login(response.Data, idioma);

                //Validacion digito verificador
                if (!ValidarDigitoVerificador())
                {
                    if (!_sessionManager.HasPermission(1))
                    {
                        FormSistemaNoDisponible sistemaNodisponible = new FormSistemaNoDisponible();
                        sistemaNodisponible.ShowDialog();

                        SessionManager.Logout();
                        return;
                    }
                    else 
                    {
                        FormSolucionDV formSolucionDV = new FormSolucionDV();

                        if (formSolucionDV.ShowDialog() != DialogResult.OK)
                        {
                            SessionManager.Logout();
                            return;
                        }
                    }
                }

                TxtUsername.Text = string.Empty;
                TxtPassword.Text = string.Empty;

                // Ingreso al menu principal
                FormMenuPrincipal menuPrincipal = new FormMenuPrincipal(this);
                menuPrincipal.Show();
                this.Hide();
                RegistrarEvento(Modulo, "Inicio de sesion", 1);
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

            _publisher.NotifyAll(idioma);
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
