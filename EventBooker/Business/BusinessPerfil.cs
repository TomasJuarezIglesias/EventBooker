using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessPerfil
    {
        private readonly DataAccessPerfil _dataAccessPerfil;
        private readonly BusinessPermiso _businessPermiso;

        public BusinessPerfil()
        {
            _dataAccessPerfil = new DataAccessPerfil();
            _businessPermiso = new BusinessPermiso();
        }


        public BusinessResponse<EntityPerfil> GetByUser(Entity user)
        {
            EntityPerfil perfil = _dataAccessPerfil.SelectByUser(user);
            perfil.Permisos = _businessPermiso.GetPermisosPerfil(user).Data;

            return new BusinessResponse<EntityPerfil>(true, perfil);
        }

        public BusinessResponse<List<EntityPerfil>> GetAll()
        {
            List<EntityPerfil> perfiles = _dataAccessPerfil.SelectAll();

            foreach (EntityPerfil perfil in perfiles)
            {
                perfil.Permisos = _businessPermiso.GetPermisosPerfil(perfil).Data;
            }

            return new BusinessResponse<List<EntityPerfil>>(true, perfiles);
        }

        public BusinessResponse<bool> Create(EntityPerfil perfil)
        {
            bool ok = _dataAccessPerfil.Insert(perfil);
            return new BusinessResponse<bool>(ok, ok, ok ? "MessageCreadoCorrectamente" : "MessageErrorAlCrear");
        }

        public BusinessResponse<bool> Update(EntityPerfil perfil)
        {
            bool ok = _dataAccessPerfil.Update(perfil);
            return new BusinessResponse<bool>(ok, ok, ok ? "MessageModificadoCorrectamente" : "MessageErrorAlModificar");
        }

        public BusinessResponse<bool> Delete(EntityPerfil perfil)
        {
            bool ok = _dataAccessPerfil.Delete(perfil);
            return new BusinessResponse<bool>(ok, ok, ok ? "MessageEliminadoCorrectamente" : "MessagePerfilAsignadoAUsuario");
        }

    } 
}
