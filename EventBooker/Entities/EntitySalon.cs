using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntitySalon : Entity
    {
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public double Precio { get; set; }
        public double PrecioCubierto { get; set; }
        public int Capacidad { get; set; }
        public int CantidadMinimaInvitados { get; set; }
    }
}
