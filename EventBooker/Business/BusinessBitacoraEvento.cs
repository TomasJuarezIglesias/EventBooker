using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessBitacoraEvento
    {
        private readonly DataAccessBitacoraEvento _dataAccess;

        public BusinessBitacoraEvento()
        {
            _dataAccess = new DataAccessBitacoraEvento();
        }

        public BusinessResponse<List<EntityBitacoraEvento>> GetAll(int idUser, DateTime fechaInicio, DateTime fechaFin, string modulo, string evento, int criticidad)
        {
            return new BusinessResponse<List<EntityBitacoraEvento>>(true, _dataAccess.Select(idUser, fechaInicio, fechaFin, modulo, evento, criticidad));
        }

        public void Create(EntityBitacoraEvento evento)
        {
            _dataAccess.Insert(evento);
        }

        public BusinessResponse<List<string>> GetEventos()
        {
            return new BusinessResponse<List<string>>(true, _dataAccess.SelectEventos());
        }

        public BusinessResponse<List<string>> GetModulos()
        {
            return new BusinessResponse<List<string>>(true, _dataAccess.SelectModulos());
        }

        public BusinessResponse<List<EntityUser>> GetUsers() 
        {
            return new BusinessResponse<List<EntityUser>>(true, _dataAccess.SelectUsers());
        }

    }
}
