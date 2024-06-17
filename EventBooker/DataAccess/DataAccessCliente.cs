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
    public class DataAccessCliente 
    {
        private readonly DBConnection _connection;

        public DataAccessCliente()
        {
            _connection = DBConnection.GetInstance();
        }

        public List<EntityCliente> SelectAll()
        {
            List<EntityCliente> clientes = new List<EntityCliente>();
            DataTable data = _connection.Read("SP_SelectCliente");

            foreach (DataRow row in data.Rows)
            {
                clientes.Add(SqlMapper.MapCliente(row));
            }

            return clientes;
        }

        public bool Insert(EntityCliente cliente)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Dni", SqlDbType.Int){ Value = cliente.Dni },
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = cliente.Nombre },
                new SqlParameter("@In_Apellido", SqlDbType.NVarChar){ Value = cliente.Apellido },
                new SqlParameter("@In_Direccion", SqlDbType.NVarChar){ Value = cliente.Direccion },
                new SqlParameter("@In_Email", SqlDbType.NVarChar){ Value = cliente.Email },
                new SqlParameter("@In_Contacto", SqlDbType.Int){ Value = cliente.Contacto },
            };

            return _connection.Write("SP_CreateCliente", parameters);
        }
    }
}
