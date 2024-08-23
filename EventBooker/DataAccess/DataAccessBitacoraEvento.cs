using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessBitacoraEvento
    {
        private readonly DBConnection _connection;

        public DataAccessBitacoraEvento()
        {
            _connection = DBConnection.GetInstance();
        }

        public List<EntityBitacoraEvento> Select(int idUser, DateTime fechaInicio, DateTime fechaFin, string modulo, string evento, int criticidad)
        {
            List<EntityBitacoraEvento> eventos = new List<EntityBitacoraEvento>();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdUser", SqlDbType.Int){ Value =  idUser},
                new SqlParameter("@In_FechaInicio", SqlDbType.DateTime){ Value = fechaInicio },
                new SqlParameter("@In_FechaFin", SqlDbType.DateTime){ Value = fechaFin },
                new SqlParameter("@In_Modulo", SqlDbType.NVarChar){ Value = modulo },
                new SqlParameter("@In_Evento", SqlDbType.NVarChar){ Value = evento },
                new SqlParameter("@In_Criticidad", SqlDbType.Int){ Value = criticidad }
            };

            DataTable data = _connection.Read("SP_SelectBitacoraEvento", parameters);

            foreach (DataRow row in data.Rows) 
            {
                eventos.Add(SqlMapper.MapBitacoraEvento(row));
            }

            return eventos;
        }

    }
}
