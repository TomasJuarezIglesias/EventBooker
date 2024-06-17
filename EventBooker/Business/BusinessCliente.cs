using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessCliente
    {
        private readonly DataAccessCliente _dataAccessCliente;
        public BusinessCliente()
        {
            _dataAccessCliente = new DataAccessCliente();
        }

        public BusinessResponse<List<EntityCliente>> GetAll()
        {
            return new BusinessResponse<List<EntityCliente>>(true, _dataAccessCliente.SelectAll());
        }

        public BusinessResponse<bool> Create(EntityCliente cliente)
        {
            bool ok = _dataAccessCliente.Insert(cliente);

            return new BusinessResponse<bool>(ok, ok, ok ? "Creado Correctamente" : $"Ya existe cliente con dni: {cliente.Dni}");
        }
    }
}
