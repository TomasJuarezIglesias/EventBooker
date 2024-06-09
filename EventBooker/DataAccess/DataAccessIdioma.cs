using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessIdioma
    {
        private readonly DBConnection connection;

        public DataAccessIdioma()
        {
            connection = DBConnection.GetInstance();        
        }

        public List<EntityIdioma> SelectAll()
        {
            List<EntityIdioma> idiomas = new List<EntityIdioma>();

            DataTable data = connection.Read("SP_SelectIdiomas");

            foreach (DataRow row in data.Rows) 
            {
                idiomas.Add(SqlMapper.MapIdioma(row));
            }

            return idiomas;
        }

    }
}
