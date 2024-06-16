using Business;
using Entities;
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
    public partial class FormSeleccionarServicios : ServiceForm
    {
        private Action<ServiceForm> openChildForm;
        private readonly BusinessServicio _businessServicio;
        private List<EntityServicio> _serviciosSeleccionados;

        public FormSeleccionarServicios(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();
            this.openChildForm = openChildForm;
            _businessServicio = new BusinessServicio();
            _serviciosSeleccionados = new List<EntityServicio>();
            FillListCheckBox();
            MostrarValores();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void FillListCheckBox()
        {
            List<EntityServicio> servicios = _businessServicio.GetAll().Data;

            PanelServicios.Controls.Clear();

            int positionY = 10;

            foreach (var servicio in servicios)
            {
                // Crear un nuevo CheckBox
                CheckBox checkBox = new CheckBox
                {
                    Text = servicio.Descripcion,
                    Tag = servicio,  // Asocia el objeto Servicio con el CheckBox
                    Location = new Point(10, positionY)
                };

                // Asignar el manejador del evento OnCheckedChanged
                checkBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

                // Agrega el CheckBox al panel
                PanelServicios.Controls.Add(checkBox);

                // Incrementa la posición Y para el próximo CheckBox
                positionY += 30;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Asegurarse de que el sender es un CheckBox
            if (sender is CheckBox checkBox)
            {
                // Obtener el objeto Servicio asociado al CheckBox
                EntityServicio servicio = checkBox.Tag as EntityServicio;

                if (checkBox.Checked)
                {
                    _serviciosSeleccionados.Add(servicio);
                }
                else
                {
                    _serviciosSeleccionados.Remove(servicio);
                }

                MostrarValores();
            }
        }

        private void MostrarValores()
        {
            LblValores.AutoSize = true;

            LblValores.Text = string.Empty;
            double valorTotal = 0; 

            foreach (var servicio in _serviciosSeleccionados)
            {
                LblValores.Text += $"{servicio.Descripcion}: ${servicio.Valor} \r\n";
                valorTotal += servicio.Valor;
            }

            LblValores.Text += $"\r\nValor Total: ${valorTotal}";
        }

    }
}
