using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityReserva : Entity
    {
        public EntityCliente Cliente { get; set; }
        public EntitySalon Salon { get; set; }
        public List<EntityServicio> Servicios { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Turno { get; set; }
        public int Invitados { get; set; }
        public string Estado { get; set; }
    }
}
