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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormRegistrarReserva : ServiceForm
    {
        private readonly BusinessCliente _businessCliente;
        private readonly BusinessReserva _businessReserva;
        private Action<ServiceForm> openChildForm;
        private EntityReserva _reserva;

        public FormRegistrarReserva(Action<ServiceForm> openChildForm, EntityReserva reserva = null)
        {
            InitializeComponent();

            // Intancio Business
            _businessCliente = new BusinessCliente();
            _businessReserva = new BusinessReserva();

            this.openChildForm = openChildForm;
            _reserva = reserva;

            MostrarDatos();
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
        private void BtnSeleccionarServicios_Click(object sender, EventArgs e)
        {
            openChildForm(new FormSeleccionarServicios(openChildForm, _reserva));
        }

        private void BtnRegistrarReserva_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            _reserva.Estado = "Pendiente";
            _reserva.Descripcion = TxtDescripcion.Text;
            _reserva.Invitados = Convert.ToInt32(NumInvitados.Value);

            BusinessResponse<bool> response = _businessReserva.Create(_reserva);
            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                this.Close();
                openChildForm(new FormInicio());
            }
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

        // Evento que desencadena metodo para calcular costos
        private void NumInvitados_ValueChanged(object sender, EventArgs e)
        {
            _reserva.Invitados = Convert.ToInt32(NumInvitados.Value);
            CalcularCostos();
        }

        // Manejo del combo box de clientes
        private void CmbClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbClientes.TextChanged -= CmbClientes_TextChanged;

            EntityCliente cliente = CmbClientes.SelectedItem as EntityCliente;

            _reserva.Cliente = cliente;

            LblNombre.Text = $"Nombre: {cliente.Nombre} {cliente.Apellido}";
            LblDni.Text = $"Dni: {cliente.Dni}";
            LblContacto.Text = $"Contacto: {cliente.Contacto}";

            CmbClientes.Text = string.Empty;
            MostrarDatos();
        }
        
        private void CmbClientes_TextChanged(object sender, EventArgs e)
        {
            CmbClientes.TextChanged -= CmbClientes_TextChanged;

            string searchText = CmbClientes.Text;

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



        private void MostrarDatos()
        {
            BtnRegistrarReserva.Enabled = false;
            PanelCliente.Visible = false;
            PanelDatosEvento.Visible = false;
            PanelServicios.Visible = false;
            PanelListaServicios.Visible = false;

            if (_reserva?.Salon != null)
            {
                LblUbicacion.Text = $"Ubicación: {_reserva.Salon.Ubicacion}";
                LblFecha.Text = $"Fecha: {_reserva.Fecha.ToString("dd/MM/yyyy")} Turno: {_reserva.Turno}";
                LblCapacidad.Text = $"Cantidad Mínima Invitados: {_reserva.Salon.CantidadMinimaInvitados} Capacidad máxima: {_reserva.Salon.Capacidad}";

                PanelCliente.Visible = true;

                List<EntityCliente> clientes = _businessCliente.GetAll().Data;
                EntityCliente clienteSelected = _reserva.Cliente != null ? clientes.FirstOrDefault(c => c.Dni == _reserva.Cliente.Dni) : null;
                _reserva.Cliente = clienteSelected;

                // Setting Combo Box Clientes
                CmbClientes.DataSource = null;
                CmbClientes.DataSource = clientes;
                CmbClientes.SelectedItem = clienteSelected;
                CmbClientes.TextChanged += CmbClientes_TextChanged;
            }

            // Muestra datos del cliente seleccionado
            // Habilita seleccion de servicios y datos del evento
            if (_reserva?.Cliente != null)
            {
                PanelDatosEvento.Visible = true;
                PanelServicios.Visible = true;
                BtnRegistrarReserva.Enabled = true;

                LblNombre.Text = $"Nombre: {_reserva.Cliente.Nombre} {_reserva.Cliente.Apellido}";
                LblDni.Text = $"Dni: {_reserva.Cliente.Dni}";
                LblContacto.Text = $"Contacto: {_reserva.Cliente.Contacto}";
            }

            // Muestra los servicios seleccionados con el valor
            if (_reserva?.Servicios?.Count > 0)
            {
                LblServicios.Text = $"Lista servicios: \r\n";
                foreach (var servicio in _reserva.Servicios)
                {
                    LblServicios.Text += $"{servicio.Descripcion} - ${servicio.Valor} \r\n";
                }

                PanelListaServicios.Visible = true;
            }

            TxtDescripcion.Text = !string.IsNullOrEmpty(_reserva?.Descripcion) ? _reserva?.Descripcion : string.Empty;
            NumInvitados.Value = _reserva?.Invitados != null && _reserva?.Invitados != 0 ? _reserva.Invitados : 0;

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

        private bool ValidateInputs()
        {
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorDescripcion,
                LblErrorCantidadInvitados
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtDescripcion.Text))
            {
                ShowLabelError("Debe ingresar descripción del evento", LblErrorDescripcion);
                ok = false;
            }

            if (NumInvitados.Value > _reserva.Salon.Capacidad || NumInvitados.Value < _reserva.Salon.CantidadMinimaInvitados)
            {
                ShowLabelError($"Fuera de rango de la capacidad", LblErrorCantidadInvitados);
                ok = false;
            }

            return ok;
        }

        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDescripcion.Text))
            {
                _reserva.Descripcion = TxtDescripcion.Text;
            }
        }

        private void NumInvitados_Leave(object sender, EventArgs e)
        {
            if (NumInvitados.Value >= 0)
            {
                _reserva.Invitados = Convert.ToInt32(NumInvitados.Value);
                CalcularCostos();
            }
        }
    }
}
