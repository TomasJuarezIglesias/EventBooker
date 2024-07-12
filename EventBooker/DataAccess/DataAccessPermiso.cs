using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

        public List<IPermiso> SelectAllPermisos()
        {
            List<IPermiso> permisos = new List<IPermiso>();

            DataTable data = _connection.Read("SP_SelectPermisos");

            foreach (DataRow row in data.Rows)
            {
                permisos.Add(SqlMapper.MapPatente(row));
            }

            return permisos;
        }

        public List<IPermiso> SelectAllFamilias()
        {
            List<IPermiso> familiasPermisos = new List<IPermiso>();

            DataTable data = _connection.Read("SP_SelectFamilias");

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

                familiasPermisos.Add(permiso);
            }

            return familiasPermisos;

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

            if (familiaPermisos.Permisos is null)
            {
                familiaPermisos.Permisos = new List<IPermiso>();
            }

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdFamilia", SqlDbType.Int){ Value = familiaPermisos.Id }
            };

            DataTable data = _connection.Read("SP_SelectPermisosFamilia", parameters);

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

                familiaPermisos.Permisos.Add(permiso);
            }

            return familiaPermisos;
        }



        public bool InsertFamilia(IPermiso familia)
        {
            bool ok = false;

            Familia familiaPermisos = familia as Familia;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = familia.Nombre }
            };

            familiaPermisos.Id = _connection.WriteWithReturn("SP_CreateFamilia", parameters);

            foreach (IPermiso permiso in familiaPermisos.Permisos)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_IdFamilia", SqlDbType.Int){ Value = familiaPermisos.Id },
                    new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = permiso.Id }
                };

                ok = _connection.Write("SP_CreatePermisoFamilia", parameters);
            }

            return ok;
        }


        public bool UpdateFamilia(IPermiso familia)
        {
            bool ok = false;

            Familia familiaPermisos = familia as Familia;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = familiaPermisos.Id },
                new SqlParameter("@In_Nombre", SqlDbType.NVarChar){ Value = familiaPermisos.Nombre }
            };

            ok = _connection.Write("SP_UpdateFamilia", parameters);

            parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdFamilia", SqlDbType.Int){ Value = familiaPermisos.Id }
            };

            ok = _connection.Write("SP_DeletePermisosFamilia", parameters);

            foreach (IPermiso permiso in familiaPermisos.Permisos)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_IdFamilia", SqlDbType.Int){ Value = familiaPermisos.Id },
                    new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = permiso.Id }
                };

                ok = _connection.Write("SP_CreatePermisoFamilia", parameters);
            }

            return ok;
        }

        public bool DeleteFamilia(IPermiso permiso)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdFamilia", SqlDbType.Int){ Value = permiso.Id }
            };

            return _connection.Write("SP_DeleteFamilia", parameters);
        }
    }
}
