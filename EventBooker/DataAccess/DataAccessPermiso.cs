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
    public class DataAccessPermiso
    {
        private readonly DBConnection _connection;

        public DataAccessPermiso()
        {
            _connection = DBConnection.GetInstance();
        }

        public List<IPermiso> SelectPermisosPerfil(Entity perfil)
        {
            List<IPermiso> permisos = new List<IPermiso>();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id }
            };

            DataTable data = _connection.Read("SP_SelectPermisosPerfil", parameters);

            foreach (DataRow row in data.Rows)
            {
                IPermiso permiso;

                if (Convert.ToBoolean(row["IsFamilia"]))
                {
                    permiso = PermisosFamilia(SqlMapper.MapFamilia(row));
                }
                else
                {
                    permiso = SqlMapper.MapPatente(row);
                }

                permisos.Add(permiso);
            }

            return permisos;
        }

        public Familia PermisosFamilia(IPermiso familia)
        {
            Familia familiaPermisos = (Familia)familia;

            



            return familiaPermisos;
        }
    }
}
