﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public string SelectTraduccion(EntityIdioma idioma, string controlName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdIdioma", SqlDbType.Int){ Value = idioma.Id },
                new SqlParameter("@In_NombreControl", SqlDbType.NVarChar){ Value = controlName }
            };

            DataTable data = connection.Read("SP_SelectTraduccion", parameters);

            return data.Rows.Count == 0 ? string.Empty : data.Rows[0]["Traduccion"].ToString();
        }

    }
}
