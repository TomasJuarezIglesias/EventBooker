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


        public List<EntityReserva> SelectAll(string estado = null)
        {
            List<EntityReserva> reservas = new List<EntityReserva>();

            SqlParameter[] parameters = null;

            if (estado != null)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_Estado", SqlDbType.NVarChar){ Value = estado }
                };
            }

            DataTable dataReservas = _connection.Read("SP_SelectReserva", parameters);

            foreach (DataRow row in dataReservas.Rows)
            {
                EntityReserva reserva = SqlMapper.MapReserva(row);
                reserva.Cliente = SqlMapper.MapCliente(row);
                reserva.Salon = SqlMapper.MapSalon(row);
                reserva.Servicios = new List<EntityServicio>();

                DataTable dataServicios = _connection.Read("SP_SelectReservaServicio", new SqlParameter[]
                {
                    new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = reserva.Id }
                });

                foreach (DataRow servicio in dataServicios.Rows)
                {
                    reserva.Servicios.Add(SqlMapper.MapServicio(servicio));
                }

                reservas.Add(reserva);
            }

            return reservas;
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

            int idReserva = _connection.WriteWithReturn("SP_CreateReserva", parameters);

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

                    _connection.Write("SP_CreateReservaServicio", parametersServicio);
                }
            }

            return true;
        }

        public bool Update(EntityReserva reserva)
        {
            bool ok;

            ok = _connection.Write("SP_UpdateReserva", new SqlParameter[] {
                new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = reserva.Id },
                new SqlParameter("@In_IdCliente", SqlDbType.Int){ Value = reserva.Cliente.Id },
                new SqlParameter("@In_IdSalon", SqlDbType.Int){ Value = reserva.Salon.Id },
                new SqlParameter("@In_Descripcion", SqlDbType.NVarChar){ Value = reserva.Descripcion },
                new SqlParameter("@In_Fecha", SqlDbType.Date){ Value = reserva.Fecha },
                new SqlParameter("@In_Turno", SqlDbType.NVarChar){ Value = reserva.Turno },
                new SqlParameter("@In_Invitados", SqlDbType.Int){ Value = reserva.Invitados },
                new SqlParameter("@In_Estado", SqlDbType.NVarChar){ Value = reserva.Estado },
            });

            if (!ok) return ok;

            // Elimino todos los servicios de la reserva para insertar los cambios
            _connection.Write("SP_DeleteReservaServicios", new SqlParameter[]
            {
                new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = reserva.Id }
            });

            if (reserva.Servicios?.Count > 0 && ok)
            {
                foreach (var servicio in reserva.Servicios)
                {
                    _connection.Write("SP_CreateReservaServicio", new SqlParameter[]
                    {
                        new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = reserva.Id },
                        new SqlParameter("@In_IdServicio", SqlDbType.Int){ Value =  servicio.Id},
                        new SqlParameter("@In_IsAdicional", SqlDbType.Int){ Value = servicio.IsAdicional }
                    });
                }
            }

            return ok;
        }

        public DataTable GetReporteMes(DateTime fecha)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Fecha", SqlDbType.Date){ Value = fecha }
            };

            return _connection.Read("SP_GenerarReporteReservasMes", parameters);
        }


    }
}
