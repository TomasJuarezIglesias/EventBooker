﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SessionManager
    {
        public Guid SessionId { get; private set; }
        public DateTime LoginTime { get; private set; }
        public EntityUser User { get; private set; }
        public EntityIdioma Idioma { get; set; }

        private static SessionManager _instance;

        private SessionManager()
        {
            SessionId = Guid.NewGuid();
            LoginTime = DateTime.Now;
        }

        public static SessionManager GetInstance()
        {
            return _instance;
        }

        public static SessionManager Login(EntityUser user, EntityIdioma idioma)
        {
            if (_instance != null) throw new Exception("Hay una sesión en curso");

            if (_instance is null)
            {
                _instance = new SessionManager
                {
                    User = user,
                    Idioma = idioma
                }; 
            }

            return _instance;
        } 

        public static void Logout()
        {
            if (_instance != null) 
            {
                _instance = null;
            }
        }


        public bool HasPermission(int idPermiso, List<IPermiso> permisos = null)
        {
            if (permisos == null) permisos = User.Perfil.Permisos;

            foreach (var permiso in permisos)
            {
                if (permiso is Familia permisoFamilia)
                {
                    return HasPermission(idPermiso, permisoFamilia.Permisos);
                }
                if (permiso.Id == idPermiso) return true;
            }

            return false;
        }
    }
}
