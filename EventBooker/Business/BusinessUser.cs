using DataAccess;
using Entities;
using Services;
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
        private readonly BusinessPerfil _businessPerfil;

        public BusinessUser()
        {
            dataAccess = new DataAccessUser();
            _businessPerfil = new BusinessPerfil();
        }

        public BusinessResponse<EntityUser> VerifyCredentials(string username, string password)
        {
            EntityUser user = dataAccess.SelectByUsername(username);
            bool ok = user?.Password == CryptoManager.EncryptString(password) && user?.Username == username;

            string mensaje =
                user?.Username != username ? "Usuario Incorrecto" :
                user.IsBlock ? "Usuario Bloqueado" :
                !ok ? "Contraseña Incorrecta" :
                string.Empty;

            ok = user?.IsBlock == true ? false : ok;

            if (ok)
            {
                user.Perfil = _businessPerfil.GetByUser(user).Data;
            }

            return new BusinessResponse<EntityUser>(ok, user, mensaje);
        }

        public BusinessResponse<bool> ChangePassword(EntityUser user, string actualPassword, string newPassword, string newPasswordRep)
        {
            if (newPassword != newPasswordRep) return new BusinessResponse<bool>(false, false, "Las nuevas contraseñas no coinciden");

            if (!RegexValidationService.IsValidPassword(newPassword)) return new BusinessResponse<bool>(false, false, "La contraseña debe contener mínimo 8 caracteres, una mayúscula y al menos un numero");

            if (user.Password != CryptoManager.EncryptString(actualPassword)) return new BusinessResponse<bool>(false, false, "Contraseñas no coinciden");

            user.Password = CryptoManager.EncryptString(newPassword);

            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? "Error al modificar contraseña" : "Contraseña modificada correctamente");
        }

        public BusinessResponse<bool> BlockUser(EntityUser user)
        {
            user.IsBlock = true;
            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(false, ok, ok ? "El usuario ha sido bloqueado por exceder número de intentos fallidos" : "Error al bloquear usuario");
        }

        public BusinessResponse<bool> UnblockUser(EntityUser user)
        {
            user.IsBlock = false;
            user.Password = CryptoManager.EncryptString(user.Dni + user.Apellido);

            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, ok ? "Desbloqueado correctamente" : "No se pudo desbloquear");
        }

        public BusinessResponse<List<EntityUser>> GetAll()
        {
            return new BusinessResponse<List<EntityUser>>(true, dataAccess.SelectAll());
        }

        public BusinessResponse<bool> Create(EntityUser user)
        {
            user.Password = CryptoManager.EncryptString(user.Password);

            bool ok = dataAccess.Insert(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? $"Ya existe usuario con dni: {user.Dni}" : "Usuario creado correctamente");
        }

        public BusinessResponse<bool> Update(EntityUser user)
        {
            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? $"Ya existe usuario con dni: {user.Dni}" : "Usuario modificado correctamente");
        }

        public BusinessResponse<bool> Delete(Entity entity)
        {
            bool ok = dataAccess.Delete(entity);

            return new BusinessResponse<bool>(ok, ok, !ok ? "No existe" : "Eliminado correctamente");
        }
        
    }
}
