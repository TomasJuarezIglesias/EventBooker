﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityUser : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsBlock { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public EntityPerfil Perfil { get; set; }


        public override string ToString()
        {
            return Username; 
        }
    }
}
