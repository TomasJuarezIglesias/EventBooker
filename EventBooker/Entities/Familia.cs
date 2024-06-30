using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Familia : IPermiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<IPermiso> Permisos { get; set; }
    }
}
