﻿using Business;
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
    public partial class FormAgregarServicios : ServiceForm
    {
        private string Modulo = "Cobranza";

        private Action<ServiceForm> openChildForm;
        private List<EntityServicio> _serviciosSeleccionados;
        private EntityReserva _reserva;
        private readonly BusinessServicio _businessServicio;
        private readonly BusinessReserva _businessReserva;

        public FormAgregarServicios(Action<ServiceForm> openChildForm, EntityReserva reserva)
        {
            InitializeComponent();

            this.openChildForm = openChildForm;
            _reserva = reserva;

            // Instancio business
            _businessServicio = new BusinessServicio();
            _businessReserva = new BusinessReserva();

            _serviciosSeleccionados = new List<EntityServicio>();
            
            FillListCheckBox();
            MostrarValores();
        }

        private void BtnAñadirServiciosAdicionales_Click(object sender, EventArgs e)
        {
            BusinessResponse<bool> response = _businessReserva.Update(_reserva);

            if (!response.Ok)
            {
                RevisarRespuestaServicio(response);
                return;
            }

            RevisarRespuestaServicio(new BusinessResponse<bool>(true, true, "MessageServiciosSeleccionadosCorrectamente"));
            UpdateDigitoVerificador();
            this.Close();
            openChildForm(new FormCobrar(openChildForm, _reserva));

            RegistrarEvento(Modulo, "Añadir adicionales", 2);
        }

        private void FillListCheckBox()
        {
            List<EntityServicio> servicios = _businessServicio.GetAll(_reserva.Id).Data;

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

                if (_reserva.Servicios != null)
                {
                    checkBox.Checked = _reserva.Servicios.Exists(s => s.Id == servicio.Id);
                    checkBox.Enabled = servicio.IsAdicional;
                }

                // Asignar el manejador del evento OnCheckedChanged
                checkBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

                // Agrega el CheckBox al panel
                PanelServicios.Controls.Add(checkBox);

                // Incrementa la posición Y para el próximo CheckBox
                positionY += 30;
            }

            if (_reserva.Servicios != null) _serviciosSeleccionados = _reserva.Servicios;

            MostrarValores();
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
                    _serviciosSeleccionados.Remove(_serviciosSeleccionados.FirstOrDefault(s => s.Id == servicio.Id));
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

            LblValores.Text += $"\r\n{SearchTraduccion("MessageValorTotal")} ${valorTotal}";
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            $"{SearchTraduccion("MessageEstaSeguroQueDeseaVolver")}",
            $"{SearchTraduccion("CaptionVolver")}",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                this.Close();
                openChildForm(new FormCobrar(openChildForm, _reserva));
            }
        }

    }
}
