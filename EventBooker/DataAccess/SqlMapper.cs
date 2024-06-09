﻿using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal static class SqlMapper
    {
        public static EntityUser MapUser(DataRow row) => new EntityUser()
        {
            Id = Convert.ToInt32(row["Id"]),
            Username = row["Username"].ToString(),
            Password = row["Password"].ToString(),
            IsBlock = Convert.ToBoolean(row["IsBlock"]),
            Dni = Convert.ToInt32(row["Dni"]),
            Nombre = row["Nombre"].ToString(),
            Apellido = row["Apellido"].ToString(),
            Mail = row["Mail"].ToString()
        };

        public static EntityIdioma MapIdioma(DataRow row) => new EntityIdioma()
        {
            Id = Convert.ToInt32(row["IdIdioma"]),
            Idioma = row["Idioma"].ToString()
        };

        public static EntitySalon MapSalon(DataRow row) => new EntitySalon()
        {
            Id = Convert.ToInt32(row["IdSalon"]),
            Nombre = row["Nombre"].ToString(),
            Ubicacion = row["Ubicacion"].ToString(),
            Precio = Convert.ToDouble(row["Precio"]),
            PrecioCubierto = Convert.ToDouble(row["PrecioCubierto"]),
            Capacidad = Convert.ToInt32(row["Capacidad"]),
            CantidadMinimaInvitados = Convert.ToInt32(row["CantidadMinimaInvitados"])
        };

        public static EntityServicio MapServicio(DataRow row) => new EntityServicio()
        {
            Id = Convert.ToInt32(row["IdServicio"]),
            Descripcion = row["Descripcion"].ToString(),
            Valor = Convert.ToDouble(row["Valor"])
        };
    }
}
