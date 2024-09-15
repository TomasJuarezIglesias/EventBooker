using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityServicio : Entity
    {
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public bool IsAdicional { get; set; }
        public bool IsDelete { get; set; }
    }
}
