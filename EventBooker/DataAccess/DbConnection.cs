using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class DBConnection
    {
        private static DBConnection _instance;

        private readonly SqlConnection _connection;
        private DBConnection()
        {
            _connection = new SqlConnection("Data Source=LocalHost; Initial Catalog=EventBooker; Integrated Security=True");
        }

        public static DBConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBConnection();
            }

            return _instance;
        }

        private void OpenConnection()
        {
            _connection.Open();
        }

        private void CloseConnection()
        {
            _connection.Close();
        }

        public DataTable Read(string sp, SqlParameter[] parameters = null)
        {
            OpenConnection();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = sp
                }
            };

            if (parameters != null)
            {
                sqlDataAdapter.SelectCommand.Parameters.Clear();
                sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
            }

            sqlDataAdapter.SelectCommand.Connection = _connection;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            CloseConnection();

            return dataTable;
        }

        public bool Write(string sp, SqlParameter[] parameters)
        {
            if (parameters.Length == 0) return false;

            int canInsert = -1;

            OpenConnection();
            SqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = sp,
                    Connection = _connection,
                    Transaction = transaction
                };

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(parameters);

                canInsert = sqlCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }

            CloseConnection();

            return canInsert != -1;
        }


        public int WriteWithReturn(string sp, SqlParameter[] parameters)
        {
            int id = -1;

            if (parameters.Length == 0) return id;

            OpenConnection();
            SqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = sp,
                    Connection = _connection,
                    Transaction = transaction
                };

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddRange(parameters);

                SqlParameter outputParam = new SqlParameter
                {
                    ParameterName = "@Out_Id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(outputParam);

                sqlCommand.ExecuteNonQuery();

                id = Convert.ToInt32(sqlCommand.Parameters["@Out_Id"].Value);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }

            CloseConnection();

            return id;
        }

        public void ExectQuery(string query)
        {
            OpenConnection();

            SqlCommand sqlCommand = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = _connection
            };

            sqlCommand.ExecuteNonQuery();

            CloseConnection();
        }
    }
}
