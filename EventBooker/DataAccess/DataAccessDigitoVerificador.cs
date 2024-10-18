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
    public class DataAccessDigitoVerificador
    {
        private readonly DBConnection conn;

        public DataAccessDigitoVerificador()
        {
            conn = DBConnection.GetInstance();
        }

        public EntityDigitoVerificador Select()
        {
            DataTable data = conn.Read("SP_SelectDigitoVerificador");

            return data.Rows.Count != 0 
                ? SqlMapper.MapDigitoVerificador(data.Rows[0])
                : new EntityDigitoVerificador();
        }

        public bool Update(EntityDigitoVerificador digitoVerificador)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_DVH", SqlDbType.Char){ Value = digitoVerificador.DVH },
                new SqlParameter("@In_DVV", SqlDbType.Char){ Value = digitoVerificador.DVV }
            };

            return conn.Write("SP_UpdateDigitoVerificador", parameters);
        }

        public DataTable SelectTable(string tableName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_TableName", SqlDbType.NVarChar){ Value = tableName }
            };

            return conn.Read("SP_SelectTable", parameters);
        }
    }
}
