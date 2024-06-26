﻿using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessReserva
    {
        private readonly DataAccessReserva _dataAccessReserva;

        public BusinessReserva()
        {
            _dataAccessReserva = new DataAccessReserva();
        }

        public BusinessResponse<List<EntityReserva>> GetAll(string estado)
        {
            return new BusinessResponse<List<EntityReserva>>(true, _dataAccessReserva.SelectAll(estado));
        }

        public BusinessResponse<bool> Create(EntityReserva reserva)
        {
            bool ok = _dataAccessReserva.Insert(reserva);

            return new BusinessResponse<bool>(ok, ok, ok ? "Reserva registrada con éxito" : "Error al registrar la reserva");
        }

        public BusinessResponse<bool> Update(EntityReserva reserva)
        {
            bool ok = _dataAccessReserva.Update(reserva);

            return new BusinessResponse<bool>(ok, ok, ok ? "Reserva modificada correctamente" : "Error al modificar la reserva");
        }
    }
}
