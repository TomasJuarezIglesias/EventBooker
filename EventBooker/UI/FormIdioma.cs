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
    public partial class FormIdioma : ServiceForm
    {
        private IPublisher _publisher;

        public FormIdioma(IObserver observadorMenuPrincipal)
        {
            InitializeComponent();

            // Instancio el publisher con los observadores
            _publisher = new LanguageManager();
            _publisher.AddObserver(this);
            _publisher.AddObserver(observadorMenuPrincipal);

            FillData();
            ChangeTranslation();
        }

        private void FillData()
        {
            List<EntityIdioma> idiomas = _businessIdioma.GetAll().Data;

            CmbIdioma.DataSource = null;
            CmbIdioma.DataSource = idiomas;
            CmbIdioma.DisplayMember = "Idioma";
            CmbIdioma.SelectedItem = idiomas.First(i => i.Id == _sessionManager.Idioma.Id);
        }

        private void BtnCambiar_Click(object sender, EventArgs e)
        {
            // Guardo el cambio en la sesion
            _sessionManager.Idioma = CmbIdioma.SelectedItem as EntityIdioma;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Notifico que se cancelo el cambio de idioma
            _publisher.NotifyAll(_sessionManager.Idioma);
            this.Close();
        }

        private void CmbIdioma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Notifico cambio de idioma
            _publisher.NotifyAll(CmbIdioma.SelectedItem as EntityIdioma);
        }
    }
}
