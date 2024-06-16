using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessSalon
    {
        private readonly DataAccessSalon _dataAccess;

        public BusinessSalon()
        {
            _dataAccess = new DataAccessSalon();
        }

        public BusinessResponse<List<EntitySalon>> GetAll()
        {
            return new BusinessResponse<List<EntitySalon>>(true, _dataAccess.SelectAll());
        }

        public BusinessResponse<bool> VerificarDisponibilidad(EntitySalon salon, DateTime fecha, string turno)
        {
            bool ok = _dataAccess.Disponibilidad(salon, fecha, turno);

            return new BusinessResponse<bool>(ok, ok, !ok ? "Salon no disponible para fecha y turno seleccionado" : "Salon seleccionado correctamente");
        }

        public BusinessResponse<bool> Create(EntitySalon salon)
        {
            bool ok = _dataAccess.Insert(salon);

            return new BusinessResponse<bool>(ok, ok, ok ? "Creado correctamente" : "Error al crear");
        }

        public BusinessResponse<bool> Update(EntitySalon salon)
        {
            bool ok = _dataAccess.Update(salon);

            return new BusinessResponse<bool>(ok, ok, ok ? "Modificado correctamente" : "Error al modificar");
        }

        public BusinessResponse<bool> Delete(Entity entity)
        {
            bool ok = _dataAccess.Delete(entity);

            return new BusinessResponse<bool>(ok, ok, ok ? "Eliminado correctamente" : "Error al eliminar");
        }

    }
}
