using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessUser
    {
        private readonly DBConnection conn;
        public DataAccessUser()
        {
            conn = DBConnection.GetInstance();
        }

        public List<EntityUser> SelectAll()
        {
            List<EntityUser> users = new List<EntityUser>();

            DataTable data = conn.Read("SP_GetUser");

            foreach (DataRow row in data.Rows)
            {
                users.Add(SqlMapper.MapUser(row));   
            }

            return users;
        }

        public EntityUser SelectByUsername(string username)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@In_username", SqlDbType.NVarChar){ Value = username }
            };

            DataTable data = conn.Read("SP_GetUser", parameters);

            return data.Rows.Count == 0 ? null : SqlMapper.MapUser(data.Rows[0]);
        }

        public bool Insert(EntityUser user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Username", SqlDbType.NVarChar){ Value = user.Username },
                new SqlParameter("@In_Password", SqlDbType.Char){ Value = user.Password},
                new SqlParameter("@In_Dni", SqlDbType.Int){ Value = user.Dni },
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = user.Nombre },
                new SqlParameter("@In_Apellido", SqlDbType.NVarChar){ Value = user.Apellido },
                new SqlParameter("@In_Mail", SqlDbType.NVarChar){ Value = user.Mail }
            };

            return conn.Write("SP_CreateUser", parameters);
        }

        public bool Update(EntityUser user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Id", SqlDbType.Int){ Value = user.Id },
                new SqlParameter("@In_Username", SqlDbType.NVarChar){ Value = user.Username },
                new SqlParameter("@In_Password", SqlDbType.Char){ Value = user.Password },
                new SqlParameter("@In_IsBlock", SqlDbType.Bit){ Value = user.IsBlock },
                new SqlParameter("@In_Dni", SqlDbType.Int){ Value = user.Dni },
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = user.Nombre },
                new SqlParameter("@In_Apellido", SqlDbType.NVarChar){ Value = user.Apellido },
                new SqlParameter("@In_Mail", SqlDbType.NVarChar){ Value = user.Mail }
            };

            return conn.Write("SP_UpdateUser", parameters);
        }

        public bool Delete(Entity entity)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_id", SqlDbType.Int){ Value = entity.Id }
            };

            return conn.Write("SP_DeleteUser", parameters);
        }
    }
}
