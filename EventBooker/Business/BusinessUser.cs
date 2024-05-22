﻿using DataAccess;
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

        public BusinessUser()
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

        public BusinessResponse<bool> BlockUser(EntityUser user, bool isBlockLogin)
        {
            user.IsBlock = !user.IsBlock;
            bool ok = dataAccess.Update(user);

            string bloquearMessage = user.IsBlock ? "Desbloquear" : "Bloquear";

            string message = isBlockLogin ? "El usuario ha sido bloqueado por exceder numero de intentos fallidos" : $"{bloquearMessage} Correctamente";

            if (!ok)
            {
                message = user.IsBlock ? "No se pudo bloquear" : "No se pudo desbloquear";
            }

            return new BusinessResponse<bool>(ok && !isBlockLogin, ok, message);
        }

        public BusinessResponse<List<EntityUser>> GetAll()
        {
            return new BusinessResponse<List<EntityUser>>(true, dataAccess.SelectAll());
        }

        public BusinessResponse<bool> Create(EntityUser user)
        {
            bool ok = dataAccess.Insert(user);

            // Si ok viene false es porque username ya existe => nombre + apellido
            return new BusinessResponse<bool>(ok, ok, !ok ? "Error al guardar" : "Usuario creado correctamente");
        }

        public BusinessResponse<bool> Update(EntityUser user)
        {
            bool ok = dataAccess.Update(user);

            return new BusinessResponse<bool>(ok, ok, !ok ? "Error al modificar" : "Usuario modificado correctamente");
        }

        public BusinessResponse<bool> Delete(Entity entity)
        {
            bool ok = dataAccess.Delete(entity);

            return new BusinessResponse<bool>(ok, ok, !ok ? "No existe" : "Eliminado correctamente");
        }
        
    }
}
