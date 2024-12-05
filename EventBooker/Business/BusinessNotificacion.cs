using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessNotificacion
    {

        private readonly DataAccessNotificacion dataAccessNotificacion;

        public BusinessNotificacion()
        {
            dataAccessNotificacion = new DataAccessNotificacion();
        }

        public BusinessResponse<List<EntityCliente>> GetAll()
        {
            return new BusinessResponse<List<EntityCliente>>(true, dataAccessNotificacion.Select());
        }

        public void Create()
        {
            dataAccessNotificacion.Insert();
        }

        public void Update() 
        {
            dataAccessNotificacion.Update();
        }
    }
}
