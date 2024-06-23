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
    public partial class FormGestionPerfiles : ServiceForm
    {
        private Action<ServiceForm> openChildForm;

        public FormGestionPerfiles(Action<ServiceForm> openChildForm)
        {
            this.openChildForm = openChildForm;
            InitializeComponent();
        }

        private void BtnCrearFamilia_Click(object sender, EventArgs e)
        {
            this.Close();
            openChildForm(new FormGestionFamiliaPermisos());
        }
    }
}
