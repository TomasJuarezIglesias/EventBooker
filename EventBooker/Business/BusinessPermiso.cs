using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessPermiso
    {
        private readonly DataAccessPermiso _dataAccessPermiso;

        public BusinessPermiso()
        {
            _dataAccessPermiso = new DataAccessPermiso();
        }

        public BusinessResponse<List<IPermiso>> GetPermisosPerfil(Entity perfil)
        {
            return new BusinessResponse<List<IPermiso>>(true, _dataAccessPermiso.SelectPermisosPerfil(perfil));
        }
    }
}
