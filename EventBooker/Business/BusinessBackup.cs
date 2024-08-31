using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessBackup
    {
        private readonly DataAccessBackup _dataAccess;

        public BusinessBackup()
        {
            _dataAccess = new DataAccessBackup();
        }

        public void RealizarBackup(string path)
        {
            _dataAccess.Backup(path);
        }

        public void RealizarRestore(string path)
        {
            _dataAccess.Restore(path);
        }

    }
}
