using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class EntityPerfil : Entity
    {
        public string Descripcion { get; set; }
        public List<IPermiso> Permisos { get; set; }


        public override string ToString()
        {
            return Descripcion;
        }
    }
}
