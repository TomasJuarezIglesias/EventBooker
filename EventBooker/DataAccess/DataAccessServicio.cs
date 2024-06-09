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
    public class DataAccessServicio
    {
        private readonly DBConnection _connection;

        public DataAccessServicio()
        {
            _connection = DBConnection.GetInstance();
        }

        public List<EntityServicio> SelectAll()
        {
            List<EntityServicio> servicios = new List<EntityServicio>();

            DataTable data = _connection.Read("SP_SelectServicio");

            foreach (DataRow row in data.Rows)
            {
                servicios.Add(SqlMapper.MapServicio(row));
            }

            return servicios;
        }

        public bool Insert(EntityServicio servicio)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Descripcion", SqlDbType.NVarChar){ Value = servicio.Descripcion },
                new SqlParameter("@In_Valor", SqlDbType.Money){ Value = servicio.Valor },
            };

            return _connection.Write("SP_CreateServicio", parameters);
        }

        public bool Update(EntityServicio servicio)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Id", SqlDbType.Int){ Value = servicio.Id },
                new SqlParameter("@In_Descripcion", SqlDbType.NVarChar){ Value = servicio.Descripcion },
                new SqlParameter("@In_Valor", SqlDbType.Money){ Value = servicio.Valor },
            };

            return _connection.Write("SP_UpdateServicio", parameters);
        }

        public bool Delete(Entity entity)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Id", SqlDbType.Int){ Value = entity.Id },
            };

            return _connection.Write("SP_DeleteServicio", parameters);
        }

    }
}
