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

        public BusinessResponse<EntityUser> Login(string username, string password)
        {
            EntityUser user = dataAccess.SelectByUsername(username);
            bool ok = user?.Password == CryptoManager.EncryptString(password) && user?.Username == username;

            return new BusinessResponse<EntityUser>(ok, user, !ok ? "Credenciales Incorrectas" : string.Empty);
        }


    }
}
