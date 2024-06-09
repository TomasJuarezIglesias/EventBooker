using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessServicio
    {
        private readonly DataAccessServicio _dataAccess;

        public BusinessServicio()
        {
            _dataAccess = new DataAccessServicio();
        }

        public BusinessResponse<List<EntityServicio>> GetAll()
        {
            return new BusinessResponse<List<EntityServicio>>(true, _dataAccess.SelectAll());
        }

        public BusinessResponse<bool> Create(EntityServicio servicio)
        {
            bool ok = _dataAccess.Insert(servicio);

            return new BusinessResponse<bool>(ok, ok, ok ? "Creado correctamente" : "Error al crear");
        }

        public BusinessResponse<bool> Update(EntityServicio servicio)
        {
            bool ok = _dataAccess.Update(servicio);

            return new BusinessResponse<bool>(ok, ok, ok ? "Modificado correctamente" : "Error al modificar");
        }

        public BusinessResponse<bool> Delete(Entity entity)
        {
            bool ok = _dataAccess.Delete(entity);

            return new BusinessResponse<bool>(ok, ok, ok ? "Eliminado correctamente" : "Error al eliminar");
        }

    }
}
