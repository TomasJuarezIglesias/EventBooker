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
    public partial class ServiceForm : Form, IObserver
    {
        public ServiceForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            SessionManager sessionManager = SessionManager.GetInstance();

            if (sessionManager != null)
            {
                ChangeTranslation(sessionManager.Idioma);
            }

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(1150, 650);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ServiceForm";
            ResumeLayout(false);
        }

        protected void ShowLabelError(string mensaje, BunifuLabel label)
        {
            label.Text = mensaje;
            label.Visible = true;
        }

        protected void HideLabelError(List<BunifuLabel> labels)
        {
            foreach (var label in labels)
            {
                label.Visible = false;
            }
        }

        protected void RevisarRespuestaServicio<T>(BusinessResponse<T> respuesta)
        {
            if (!respuesta.Ok)
            {
                MessageBox.Show(respuesta.Mensaje, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (respuesta.Ok && !string.IsNullOrEmpty(respuesta.Mensaje))
            {
                MessageBox.Show(respuesta.Mensaje, "Great!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Notify(EntityIdioma idioma)
        {
            ChangeTranslation(idioma);
        }

        private void ChangeTranslation(EntityIdioma idioma, Control.ControlCollection collectionPanel = null)
        {
            Control.ControlCollection controlCollection = collectionPanel ?? Controls;

            foreach (Control item in controlCollection)
            {
                if (item is Panel || item is BunifuPanel) ChangeTranslation(idioma, item.Controls);

                if (item.Name.Contains("Form"))
                {
                    // Buscar por name en la tabla junto con el id y setear el text del idioma seleccionado

                }
            }
        }


    }
}
