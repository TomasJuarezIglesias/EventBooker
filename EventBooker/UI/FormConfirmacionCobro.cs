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
    public partial class FormConfirmacionCobro : ServiceForm
    {
        private readonly BusinessReserva _businessReserva;
        private readonly BusinessFactura _businessFactura;
        private readonly EntityReserva _reserva;
        private EntityFactura _factura;

        public FormConfirmacionCobro(EntityReserva reserva, string metodoPago)
        {
            InitializeComponent();

            _reserva = reserva;
            _businessReserva = new BusinessReserva();
            _businessFactura = new BusinessFactura();

            ChangeTranslation();
            FillDataReserva(metodoPago);
        }


        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            _reserva.Estado = "Pago";
            _businessReserva.Update(_reserva);

            BusinessResponse<int> response = _businessFactura.Create(_factura);
            RevisarRespuestaServicio(response);
            UpdateDigitoVerificador();
            RegistrarEvento("Cobranza", "Cobranza de evento", 1);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    
            this.Close();
        }

        private void FillDataReserva(string metodoPago)
        {
            double costoEvento = 0;
            double costoSenia = 0;
            double impuestos = 0;


            // Informacion de la reserva
            LblFecha.Text += $" {_reserva.Fecha.ToString("dd/MM/yyyy")}";
            LblTurno.Text += $" {_reserva.Turno}";
            LblSalon.Text += $": {_reserva.Salon.Nombre}";
            MessageCostoSalon.Text += $" ${_reserva.Salon.Precio}";

            // Descripcion del evento
            LblDescripcion.Text += $" {_reserva.Descripcion}";
            LblCantidadInvitados.Text += $" {_reserva.Invitados}";
            LblPrecioCubierto.Text += $" ${_reserva.Salon.PrecioCubierto}";

            // Calculo de costos
            costoEvento += _reserva.Invitados * _reserva.Salon.PrecioCubierto;
            costoEvento += _reserva.Salon.Precio;

            // Servicios 
            List<EntityServicio> serviciosSolicitados = _reserva.Servicios.Where(s => !s.IsAdicional).ToList();
            List<EntityServicio> serviciosAniadidos = _reserva.Servicios.Where(s => s.IsAdicional).ToList();

            // Servicios solicitados
            if (serviciosSolicitados.Count > 0)
            {
                LblServiciosSinSeleccionados.Text = $"{SearchTraduccion("LblListaServicios")} \r\n";
                foreach (var servicio in serviciosSolicitados)
                {
                    costoEvento += servicio.Valor;
                    LblServiciosSinSeleccionados.Text += $"{servicio.Descripcion} - ${servicio.Valor} \r\n";
                }
            }

            // Monto señado calculado sobre los servicios solicitados
            if (_reserva.Estado == "Confirmado")
            {
                costoSenia += costoEvento * 0.3;
                LblMontoSeniado.Text += $" ${costoSenia}";
            }
            else
            {
                LblMontoSeniado.Text += " $0";
            }

            // Servicios añadidos
            if (serviciosAniadidos.Count > 0)
            {
                LblSinServiciosAniadidos.Text = $"{SearchTraduccion("LblListaServicios")} \r\n";
                foreach (var servicio in serviciosAniadidos)
                {
                    costoEvento += servicio.Valor;
                    LblSinServiciosAniadidos.Text += $"{servicio.Descripcion} - ${servicio.Valor} \r\n";
                }
            }

            // Costo del evento incluyendo añadidos
            LblCostoEvento.Text += $" ${costoEvento}";

            // Calculo impuesto iva
            LblImpuestos.Text += $" ${costoEvento * 0.21}";

            // Se agrega el iva y se muestra el costo total
            impuestos += costoEvento * 0.21;
            costoEvento += impuestos;
            LblTotal.Text += $" ${costoEvento}";

            MessageSaldoPendiente.Text += $" ${costoEvento - costoSenia}";

            _factura = new EntityFactura
            {
                Reserva = _reserva,
                Cliente = _reserva.Cliente,
                FechaEmision = DateTime.MinValue,
                ImporteTotal = costoEvento,
                Impuestos = impuestos,
                MetodoPago = metodoPago,
                Observaciones = _reserva.Descripcion
            };
        }

        private void GenerateFactura()
        {

        }

    }
}
