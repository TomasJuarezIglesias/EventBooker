﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessBitacoraEvento
    {
        private readonly DBConnection _connection;

        public DataAccessBitacoraEvento()
        {
            _connection = DBConnection.GetInstance();
        }

        public List<EntityBitacoraEvento> Select(int idUser, DateTime fechaInicio, DateTime fechaFin, string modulo, string evento, int criticidad)
        {
            List<EntityBitacoraEvento> eventos = new List<EntityBitacoraEvento>();

            SqlParameter[] parameters = new SqlParameter[]
            {
                idUser != 0 ? new SqlParameter("@In_IdUser", SqlDbType.Int){ Value =  idUser} : null,
                fechaInicio != DateTime.MinValue ? new SqlParameter("@In_FechaInicio", SqlDbType.DateTime){ Value = fechaInicio } : null,
                fechaFin != DateTime.MinValue ? new SqlParameter("@In_FechaFin", SqlDbType.DateTime){ Value = fechaFin } : null,
                !string.IsNullOrEmpty(modulo) ? new SqlParameter("@In_Modulo", SqlDbType.NVarChar){ Value = modulo } : null,
                !string.IsNullOrEmpty(evento) ? new SqlParameter("@In_Evento", SqlDbType.NVarChar){ Value = evento } : null,
                criticidad != 0 ? new SqlParameter("@In_Criticidad", SqlDbType.Int){ Value = criticidad } : null
            };

            DataTable data = _connection.Read("SP_SelectBitacoraEvento", parameters);

            foreach (DataRow row in data.Rows) 
            {
                eventos.Add(SqlMapper.MapBitacoraEvento(row));
            }

            return eventos;
        }

        public void Insert(EntityBitacoraEvento evento)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdUser", SqlDbType.Int){ Value = evento.User.Id },
                new SqlParameter("@In_Modulo", SqlDbType.NVarChar){ Value = evento.Modulo },
                new SqlParameter("@In_Evento", SqlDbType.NVarChar){ Value = evento.Evento },
                new SqlParameter("@In_Criticidad", SqlDbType.Int){ Value = evento.Criticidad }
            };

            _connection.Write("SP_CreateBitacoraEvento", parameters);
        }

        public List<string> SelectEventos()
        {
            List<string> eventos = new List<string>();

            DataTable data = _connection.Read("SP_SelectEventosBitacoraEventos");

            foreach (DataRow row in data.Rows)
            {
                eventos.Add(row["Eventos"].ToString());
            }

            return eventos;
        }

        public List<string> SelectModulos()
        {
            List<string> Modulos = new List<string>();

            DataTable data = _connection.Read("SP_SelectModulosBitacoraEvento");

            foreach (DataRow row in data.Rows)
            {
                Modulos.Add(row["Modulos"].ToString());
            }

            return Modulos;
        }

        public List<EntityUser> SelectUsers()
        {
            List<EntityUser> users = new List<EntityUser>();

            DataTable data = _connection.Read("SP_SelectUsersBitacoraEventos");

            foreach(DataRow row in data.Rows)
            {
                users.Add(SqlMapper.MapUser(row));
            }

            return users;
        }
    }
}
