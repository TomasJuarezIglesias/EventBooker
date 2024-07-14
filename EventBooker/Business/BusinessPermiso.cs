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

        public BusinessResponse<List<IPermiso>> GetFamiliaPermisos()
        {
            return new BusinessResponse<List<IPermiso>>(true, _dataAccessPermiso.SelectAllFamilias());
        }

        public BusinessResponse<List<IPermiso>> GetPermisos()
        {
            return new BusinessResponse<List<IPermiso>>(true, _dataAccessPermiso.SelectAllPermisos());
        }

        public BusinessResponse<bool> CreateFamilia(IPermiso familia)
        {
            bool ok = _dataAccessPermiso.InsertFamilia(familia);
            return new BusinessResponse<bool>(ok, ok, ok ? "MessageCreadoCorrectamente" : "MessageErrorAlCrear");
        }

        public BusinessResponse<bool> UpdateFamilia(IPermiso familia)
        {
            bool ok = _dataAccessPermiso.UpdateFamilia(familia);
            return new BusinessResponse<bool>(ok, ok, ok ? "MessageModificadoCorrectamente" : "MessageErrorAlModificar");
        }

        public BusinessResponse<bool> DeleteFamilia(IPermiso familia)
        {
            bool ok = _dataAccessPermiso.DeleteFamilia(familia);
            return new BusinessResponse<bool>(ok, ok, ok ? "MessageEliminadoCorrectamente" : "MessageFamiliaAsignadaAPerfil");
        }
    }
}
