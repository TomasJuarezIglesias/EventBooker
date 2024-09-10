using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityServicioHis : EntityServicio
    {
        public int IdServicio { get; set; }
        public DateTime Fecha { get; set; }
        public bool Actual { get; set; }
    }
}
