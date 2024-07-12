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
    public class DataAccessPerfil
    {
        private readonly DBConnection _connection;

        public DataAccessPerfil()
        {
            _connection = DBConnection.GetInstance();
        }


        public EntityPerfil SelectByUser(Entity user)
        {
            SqlParameter[] paramters = new SqlParameter[]
            {
                new SqlParameter("@In_IdUser", SqlDbType.Int){ Value = user.Id }
            };

            DataTable data = _connection.Read("SP_SelectUserPerfil", paramters);

            return SqlMapper.MapPerfil(data.Rows[0]);
        }

        public List<EntityPerfil> SelectAll()
        {
            List<EntityPerfil> perfiles = new List<EntityPerfil>();

            DataTable data = _connection.Read("SP_SelectPerfiles");

            foreach (DataRow row in data.Rows) 
            {
                perfiles.Add(SqlMapper.MapPerfil(row));
            }

            return perfiles;
        }

        public bool Insert(EntityPerfil perfil)
        {
            bool ok = false;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_descripcion", SqlDbType.NVarChar){ Value = perfil.Descripcion }
            };

            perfil.Id = _connection.WriteWithReturn("SP_CreatePerfil", parameters);

            foreach (IPermiso permiso in perfil.Permisos)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id },
                    new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = permiso.Id }
                };

                ok = _connection.Write("SP_CreatePermisoPerfil", parameters);
            }

            return ok;
        }

        public bool Update(EntityPerfil perfil)
        {
            bool ok = false;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id },
                new SqlParameter("@In_Descripcion", SqlDbType.NVarChar){ Value = perfil.Descripcion }
            };

            ok = _connection.Write("SP_UpdatePerfil", parameters);

            parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value =perfil.Id }
            };

            ok = _connection.Write("SP_DeletePermisoPerfil", parameters);

            foreach (IPermiso permiso in perfil.Permisos)
            {
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id },
                    new SqlParameter("@In_IdPermiso", SqlDbType.Int){ Value = permiso.Id }
                };

                ok = _connection.Write("SP_CreatePermisoPerfil", parameters);
            }

            return ok;
        }

        public bool Delete(Entity perfil)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdPerfil", SqlDbType.Int){ Value = perfil.Id }
            };

            return _connection.Write("SP_DeletePerfil", parameters);   
        }
    }
}
