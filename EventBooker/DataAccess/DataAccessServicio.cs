using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public List<EntityServicioHis> SelectAllHistorical(int IdServicio, DateTime FechaIni, DateTime FechaFin)
        {
            List<EntityServicioHis> historicoServicios = new List<EntityServicioHis>();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdServicio", SqlDbType.Int) { Value = IdServicio != 0 ? (object)IdServicio : DBNull.Value },
                new SqlParameter("@In_FechaInicio", SqlDbType.Date) { Value = FechaFin != DateTime.MinValue ? (object)FechaIni : DBNull.Value },
                new SqlParameter("@In_FechaFin", SqlDbType.Date) { Value = FechaFin != DateTime.MinValue ? (object)FechaFin : DBNull.Value }
            };

            DataTable data = _connection.Read("SP_SelectServicio_His", parameters);

            foreach (DataRow row in data.Rows)
            {
                historicoServicios.Add(SqlMapper.MapServicioHis(row));
            }

            return historicoServicios;
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
                new SqlParameter("@In_IsDelete", SqlDbType.Bit){ Value = servicio.IsDelete }
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
