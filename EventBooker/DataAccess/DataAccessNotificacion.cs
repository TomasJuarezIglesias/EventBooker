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
    public class DataAccessNotificacion
    {
        private readonly DBConnection connection;

        public DataAccessNotificacion()
        {
            connection = DBConnection.GetInstance();
        }

        public List<EntityCliente> Select()
        {
            List<EntityCliente> clientes = new List<EntityCliente>();

            DataTable dataTable = connection.Read("SP_SelectNotificacionPromo");

            foreach (DataRow row in dataTable.Rows) 
            {
                clientes.Add(SqlMapper.MapCliente(row));
            }

            return clientes;
        }

        public void Insert()
        {
            connection.ExectQuery("EXEC SP_CreateNotificacion");
        }

        public void Update() 
        {
            connection.ExectQuery("EXEC SP_UpdateNotificacion");
        }


    }
}
