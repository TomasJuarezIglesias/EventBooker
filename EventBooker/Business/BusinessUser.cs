using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessUser
    {
        private readonly DataAccessUser dataAccess;

        public BusinessUser()
        {
            dataAccess = new DataAccessUser();
        }

        public BusinessResponse<List<EntityUser>> GetAll()
        {
            return new BusinessResponse<List<EntityUser>>(true, dataAccess.SelectAll());
        }

        public BusinessResponse<bool> Create(EntityUser user)
        {
            bool ok = dataAccess.Insert(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? "Error al guardar" : string.Empty);
        }

        public BusinessResponse<bool> Update(EntityUser user)
        {
            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? "Error al modificar" : string.Empty);
        }

        public BusinessResponse<bool> Delete(Entity entity)
        {
            bool ok = dataAccess.Delete(entity);

            return new BusinessResponse<bool>(ok, ok, !ok ? "No existe" : string.Empty);
        }

        public BusinessResponse<bool> BlockUser(EntityUser user) 
        {
            user.IsBlock = !user.IsBlock;
            bool ok = dataAccess.Update(user);

            string message = "El usuario ha sido bloqueado por exceder numero de intentos fallidos";

            if (!ok)
            {
                message = user.IsBlock ? "No se pudo bloquear" : "No se pudo desbloquear";
            }

            return new BusinessResponse<bool>(false, ok, message);
        }
    }
}
