using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessFactura
    {
        private readonly DataAccessFactura _dataAccessFactura;

        public BusinessFactura()
        {
            _dataAccessFactura = new DataAccessFactura();   
        }

        public BusinessResponse<int> Create(EntityFactura factura)
        {
            return new BusinessResponse<int>(true, _dataAccessFactura.Insert(factura), "MessageAbonadoCorrectamente");
        }
    }
}
