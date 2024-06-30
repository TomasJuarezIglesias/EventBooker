using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessPerfil
    {
        private readonly DBConnection _connection;

        public DataAccessPerfil()
        {
            _connection = DBConnection.GetInstance();
        }


        public EntityPerfil SelectByUser(Entity user)
        {
            SqlParameter[] paramters = new SqlParameter[]
            {
                new SqlParameter("@In_IdUser", SqlDbType.Int){ Value = user.Id }
            };

            DataTable data = _connection.Read("SP_SelectUserPerfil", paramters);

            return SqlMapper.MapPerfil(data.Rows[0]);
        }
    }
}
