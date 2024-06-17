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
    public partial class FormRegistrarReserva : ServiceForm
    {
        private readonly BusinessCliente _businessCliente;
        private Action<ServiceForm> openChildForm;
        private EntityReserva _reserva;

        public FormRegistrarReserva(Action<ServiceForm> openChildForm, EntityReserva reserva = null)
        {
            InitializeComponent();
            this.openChildForm = openChildForm;
            _reserva = reserva;
            _businessCliente = new BusinessCliente();
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            PanelCliente.Visible = false;
            PanelDatosReserva.Visible = false;
            PanelServicios.Visible = false;


            if (_reserva?.Salon != null)
            {
                LblUbicacion.Text = $"Ubicación: {_reserva.Salon.Ubicacion}";
                LblFecha.Text = $"Fecha: {_reserva.Fecha.ToString("dd/MM/yyyy")} Turno: {_reserva.Turno}";
                LblCapacidad.Text = $"Capacidad: {_reserva.Salon.Capacidad}";

                PanelCliente.Visible = true;

                CmbClientes.DataSource = null;
                CmbClientes.DataSource = _businessCliente.GetAll().Data;
                CmbClientes.SelectedIndex = -1;
            }

            if (_reserva?.Cliente != null)
            {
                PanelDatosReserva.Visible = true;
                PanelServicios.Visible = true;

                LblNombre.Text = $"Nombre: {_reserva.Cliente.Nombre} {_reserva.Cliente.Apellido}";
                LblDni.Text = $"Dni: {_reserva.Cliente.Dni}";
                LblContacto.Text = $"Contacto: {_reserva.Cliente.Contacto}";
            }

            if (_reserva?.Servicios != null)
            {
                LblServicios.Text = string.Empty;

                foreach (var servicio in _reserva.Servicios)
                {
                    LblServicios.Text += $"{servicio.Descripcion} \r\n";
                }
            }

            CalcularCostos();
        }

        private void CalcularCostos()
        {
            double costoTotal = 0;

            if (_reserva?.Salon != null)
            {
                costoTotal += _reserva.Salon.Precio;
                costoTotal += _reserva.Salon.PrecioCubierto * _reserva.Invitados;

            }

            if (_reserva?.Servicios != null)
            {
                foreach (var servicio in _reserva.Servicios)
                {
                    costoTotal += servicio.Valor;
                }
            }

            double costoSenia = costoTotal == 0 ? 0 : ((30 * costoTotal) / 100);

            LblCostoTotal.Text = $"Costo total: ${costoTotal}";
            LblCostoSenia.Text = $"Costo Seña: ${costoSenia}";
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
                this.Close();
                openChildForm(new FormInicio());
            }
        }

        private void BtnSeleccionarSalon_Click(object sender, EventArgs e)
        {
            this.Close();
            openChildForm(new FormSeleccionarSalon(openChildForm, _reserva));
        }

        private void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            this.Close();
            openChildForm(new FormRegistrarCliente(openChildForm, _reserva));
        }

        private void CmbClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EntityCliente cliente = CmbClientes.SelectedItem as EntityCliente;

            _reserva.Cliente = cliente;

            LblNombre.Text = $"Nombre: {cliente.Nombre} {cliente.Apellido}";
            LblDni.Text = $"Dni: {cliente.Dni}";
            LblContacto.Text = $"Contacto: {cliente.Contacto}";
        }

        private void CmbClientes_TextChanged(object sender, EventArgs e)
        {
            string searchText = CmbClientes.Text;

            CmbClientes.TextChanged -= CmbClientes_TextChanged;

            List<EntityCliente> clientes = _businessCliente.GetAll().Data;   

            // Filtrar la lista de clientes según el texto ingresado
            var clientesFiltrados = clientes
                .Where(c => c.ToString().Contains(searchText))
                .ToList();

            // Actualizar el DataSource del ComboBox
            CmbClientes.DataSource = null;
            CmbClientes.DataSource = clientesFiltrados;

            // Mantener el texto ingresado
            CmbClientes.Text = searchText;
            CmbClientes.SelectionStart = searchText.Length;
            CmbClientes.DroppedDown = true;

            CmbClientes.TextChanged += CmbClientes_TextChanged;
        }
    }
}
