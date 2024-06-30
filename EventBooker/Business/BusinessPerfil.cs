using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
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

    }
}
