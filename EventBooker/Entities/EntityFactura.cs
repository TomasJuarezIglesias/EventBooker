using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityFactura : Entity
    {
        public EntityReserva Reserva { get; set; }
        public EntityCliente Cliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public double ImporteTotal { get; set; }
        public double Impuestos { get; set; }
        public string MetodoPago { get; set; }
        public string Observaciones { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Cliente.Nombre} {Cliente.Apellido} - {Reserva.Fecha.ToString("dd/MM/yyyy")} - {Reserva.Turno}";
        }
    }
}
