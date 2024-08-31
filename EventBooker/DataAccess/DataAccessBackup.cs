using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessBackup
    {
        private readonly DBConnection _connection;

        public DataAccessBackup()
        {
            _connection = DBConnection.GetInstance();
        }

        public void Backup(string path)
        {
            string fileName = $"Eventbooker_Backup_{DateTime.Now.ToString("yyyy_MM_dd")}.bak";
            string fullPath = Path.Combine(path, fileName);
            string query = $"BACKUP DATABASE EventBooker TO DISK = '{fullPath}'";

            _connection.ExectQuery(query);
        }

        public void Restore(string path)
        {
            string query =
                $"USE MASTER \n" +
                $"ALTER DATABASE EventBooker SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n" +
                $"RESTORE DATABASE EventBooker FROM DISK = '{path}' WITH REPLACE \n" +
                $"ALTER DATABASE EventBooker SET MULTI_USER";

            _connection.ExectQuery(query);
        }

    }
}
