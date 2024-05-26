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
    public partial class FormRealizarReserva : ServiceForm
    {
        private Action<ServiceForm> openChildForm;

        public FormRealizarReserva(Action<ServiceForm> openChildForm)
        {
            this.openChildForm = openChildForm;
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            $"¿Está seguro de que desea cancelar el proceso de reserva?",
            $"Cancelar Reserva",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                openChildForm(new FormInicio());
            }
        }
    }
}
