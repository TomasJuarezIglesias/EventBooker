﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Patente : IPermiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
