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

            if (user != null)
            {
                user.Perfil = _businessPerfil.GetByUser(user).Data;
            }

            bool ok = user?.Password == CryptoManager.EncryptString(password) && user?.Username == username;

            string mensaje =
                user?.Username != username ? "MessageUsuarioIncorrecto" :
                user.IsBlock ? "MessageUsuarioBloqueado" :
                !ok ? "MessageContraseñaIncorecta" :
                string.Empty;

            ok = user?.IsBlock == true ? false : ok;

            return new BusinessResponse<EntityUser>(ok, user, mensaje);
        }

        public BusinessResponse<bool> ChangePassword(EntityUser user, string actualPassword, string newPassword, string newPasswordRep)
        {
            if (newPassword != newPasswordRep) return new BusinessResponse<bool>(false, false, "MessageNuevasContraseñasNoCoinciden");

            if (!RegexValidationService.IsValidPassword(newPassword)) return new BusinessResponse<bool>(false, false, "MessageValidacionContraseña");

            if (user.Password != CryptoManager.EncryptString(actualPassword)) return new BusinessResponse<bool>(false, false, "MessageContraseñasNoCoinciden");

            user.Password = CryptoManager.EncryptString(newPassword);

            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? "MessageErrorAlModificar" : "MessageModificadoCorrectamente");
        }

        public BusinessResponse<bool> BlockUser(EntityUser user)
        {
            user.IsBlock = true;
            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(false, ok, ok ? "MessageUsuarioBloqueado" : "MessageErrorAlBloquearUsuario");
        }

        public BusinessResponse<bool> UnblockUser(EntityUser user)
        {
            user.IsBlock = false;
            user.Password = CryptoManager.EncryptString(user.Dni + user.Apellido);

            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, ok ? "MessageDesbloqueadoCorrectamente" : "MessageNoSePudoDesbloquear");
        }

        public BusinessResponse<List<EntityUser>> GetAll()
        {
            return new BusinessResponse<List<EntityUser>>(true, dataAccess.SelectAll());
        }

        public BusinessResponse<bool> Create(EntityUser user)
        {
            user.Password = CryptoManager.EncryptString(user.Password);

            bool ok = dataAccess.Insert(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? $"MessageUsuarioExistenteConDni" : "MessageCreadoCorrectamente");
        }

        public BusinessResponse<bool> Update(EntityUser user)
        {
            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? $"MessageUsuarioExistenteConDni" : "MessageModificadoCorrectamente");
        }

        public BusinessResponse<bool> Delete(Entity entity)
        {
            bool ok = dataAccess.Delete(entity);

            return new BusinessResponse<bool>(ok, ok, !ok ? "MessageErrorAlEliminar" : "MessageEliminadoCorrectamente");
        }
        
    }
}
