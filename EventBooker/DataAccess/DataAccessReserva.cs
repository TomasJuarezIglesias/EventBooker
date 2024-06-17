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
    public class DataAccessReserva
    {
        private readonly DBConnection _connection;

        public DataAccessReserva()
        {
            _connection = DBConnection.GetInstance();
        }

        public bool Insert(EntityReserva reserva)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@In_IdCliente", SqlDbType.Int){ Value = reserva.Cliente.Id },
                new SqlParameter("@In_IdSalon", SqlDbType.Int){ Value = reserva.Salon.Id },
                new SqlParameter("@In_Descripcion", SqlDbType.NVarChar){ Value = reserva.Descripcion },
                new SqlParameter("@In_Fecha", SqlDbType.Date){ Value = reserva.Fecha },
                new SqlParameter("@In_Turno", SqlDbType.NVarChar){ Value = reserva.Turno },
                new SqlParameter("@In_Invitados", SqlDbType.Int){ Value = reserva.Invitados },
                new SqlParameter("@In_Estado", SqlDbType.NVarChar){ Value = reserva.Estado },
            };

            int idReserva = _connection.WriteWithReturn("SP_InsertReserva", parameters);

            if (idReserva == -1) return false;

            if (reserva.Servicios?.Count > 0)
            {
                foreach (var servicio in reserva.Servicios)
                {
                    SqlParameter[] parametersServicio = new SqlParameter[]
                    {
                        new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = idReserva },
                        new SqlParameter("@In_IdServicio", SqlDbType.Int){ Value =  servicio.Id}
                    };

                    _connection.Write("SP_InsertReservaServicio", parametersServicio);
                }
            }

            return true;
        }

    }
}
