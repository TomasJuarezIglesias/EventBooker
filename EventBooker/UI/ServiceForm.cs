using Bunifu.UI.WinForms;
using Business;
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
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(1150, 650);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ServiceForm";
            ResumeLayout(false);
        }

        protected void ShowLabelError(string mensaje, BunifuLabel label)
        {
            label.Text = mensaje;
            label.Visible = true;
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

    }
}
