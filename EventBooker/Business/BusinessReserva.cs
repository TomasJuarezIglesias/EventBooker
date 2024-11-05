using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        public BusinessResponse<List<EntityReserva>> GetAll(string estado = null)
        {
            return new BusinessResponse<List<EntityReserva>>(true, _dataAccessReserva.SelectAll(estado));
        }

        public BusinessResponse<bool> Create(EntityReserva reserva)
        {
            bool ok = _dataAccessReserva.Insert(reserva);

            return new BusinessResponse<bool>(ok, ok, ok ? "MessageReservaRegistradaConExito" : "MessageErrorRegistrarReserva");
        }

        public BusinessResponse<bool> Update(EntityReserva reserva)
        {
            bool ok = _dataAccessReserva.Update(reserva);

            return new BusinessResponse<bool>(ok, ok, ok ? "MessageModificadoCorrectamente" : "MessageErrorAlModificar");
        }

        public BusinessResponse<DataTable> GenerarReporteMes(DateTime fecha)
        {
            return new BusinessResponse<DataTable>(true, _dataAccessReserva.GetReporteMes(fecha));
        }

        public BusinessResponse<DataTable> ProximosEventos()
        {
            return new BusinessResponse<DataTable>(true, _dataAccessReserva.GetProximosEventos());
        }
    }
}
