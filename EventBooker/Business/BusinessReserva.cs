using DataAccess;
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

        public BusinessResponse<bool> Create(EntityReserva reserva)
        {
            bool ok = _dataAccessReserva.Insert(reserva);

            return new BusinessResponse<bool>(ok, ok, ok ? "Reserva registrada con éxito" : "Error al registrar la reserva");
        }
    }
}
