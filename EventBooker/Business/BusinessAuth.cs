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
    public class BusinessAuth
    {
        private readonly DataAccessUser dataAccess;

        public BusinessAuth()
        {
            dataAccess = new DataAccessUser();
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

            return new BusinessResponse<EntityUser>(ok, user, mensaje);
        }

        public BusinessResponse<bool> ChangePassword(EntityUser user, string actualPassword, string newPassword, string newPasswordRep)
        {
            if (newPassword != newPasswordRep) return new BusinessResponse<bool>(false, false, "Las nuevas contraseñas no coinciden");

            if (!RegexValidationService.IsValidPassword(newPassword)) return new BusinessResponse<bool>(false, false, "La contraseña debe contener minimo 8 caracteres, una mayuscula y al menos un numero");

            if (user.Password != CryptoManager.EncryptString(actualPassword)) return new BusinessResponse<bool>(false, false, "Contraseñas no coinciden");

            user.Password = CryptoManager.EncryptString(newPassword);

            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? "Error al modificar contraseña" : "Contraseña modificada correctamente");
        }

    }
}
