﻿using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessUser
    {
        private readonly DataAccessUser dataAccess;

        public BusinessUser()
        {
            dataAccess = new DataAccessUser();
        }


        public EntityUser GetUserByName(string username)
        {
            return dataAccess.SelectByUsername(username);
        }

    }
}
