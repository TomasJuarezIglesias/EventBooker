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
    public class DataAccessSalon
    {
        private readonly DBConnection _connection;

        public DataAccessSalon()
        {
            _connection = DBConnection.GetInstance();
        }

        public List<EntitySalon> SelectAll()
        {
            List<EntitySalon> salones = new List<EntitySalon>();

            DataTable data = _connection.Read("SP_SelectSalon");

            foreach (DataRow row in data.Rows)
            {
                salones.Add(SqlMapper.MapSalon(row));
            }

            return salones;
        } 

        public bool Insert(EntitySalon salon)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = salon.Nombre },
                new SqlParameter("@In_Ubicacion", SqlDbType.NVarChar){ Value = salon.Ubicacion },
                new SqlParameter("@In_Precio", SqlDbType.Money){ Value = salon.Precio },
                new SqlParameter("@In_PrecioCubierto", SqlDbType.Money){ Value = salon.PrecioCubierto },
                new SqlParameter("@In_Capacidad", SqlDbType.Int){ Value = salon.Capacidad },
                new SqlParameter("@In_CantidadMinimaInvitados", SqlDbType.Int){ Value = salon.CantidadMinimaInvitados },
            };

            return _connection.Write("SP_CreateSalon", parameters); 
        }

        public bool Update(EntitySalon salon)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@In_Id", SqlDbType.Int){ Value = salon.Id },
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = salon.Nombre },
                new SqlParameter("@In_Ubicacion", SqlDbType.NVarChar){ Value = salon.Ubicacion },
                new SqlParameter("@In_Precio", SqlDbType.Money){ Value = salon.Precio },
                new SqlParameter("@In_PrecioCubierto", SqlDbType.Money){ Value = salon.PrecioCubierto },
                new SqlParameter("@In_Capacidad", SqlDbType.Int){ Value = salon.Capacidad },
                new SqlParameter("@In_CantidadMinimaInvitados", SqlDbType.Int){ Value = salon.CantidadMinimaInvitados },
            };

            return _connection.Write("SP_UpdateSalon", parameters); 
        }

        public bool Delete(Entity entity)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@In_Id", SqlDbType.Int){ Value = entity.Id },
            };

            return _connection.Write("SP_DeleteSalon", parameters); 
        }
    }
}
