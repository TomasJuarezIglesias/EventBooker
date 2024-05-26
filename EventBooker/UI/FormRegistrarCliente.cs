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
    public partial class FormRegistrarCliente : ServiceForm
    {
        private Action<ServiceForm> _openChildForm;
        public FormRegistrarCliente(Action<ServiceForm> openChildForm)
        {
            _openChildForm = openChildForm;
            InitializeComponent();
        }

        private void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            _openChildForm(new FormRealizarReserva(_openChildForm));
        }
    }
}
