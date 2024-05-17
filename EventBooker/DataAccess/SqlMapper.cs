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
            Password = row["Password"].ToString()
        };
    }
}
