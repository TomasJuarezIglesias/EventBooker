﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityCliente : Entity
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int Contacto { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - {Dni}";
        }
    }
}
