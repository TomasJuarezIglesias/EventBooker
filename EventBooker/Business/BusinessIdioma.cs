using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessIdioma
    {
        private readonly DataAccessIdioma _dataAccessIdioma;

        public BusinessIdioma()
        {
            _dataAccessIdioma = new DataAccessIdioma();
        }

        public BusinessResponse<List<EntityIdioma>> GetAll()
        {
            return new BusinessResponse<List<EntityIdioma>>(true, _dataAccessIdioma.SelectAll());
        }

        public BusinessResponse<string> GetTraduccion(EntityIdioma idioma, string NombreControl)
        {
            return new BusinessResponse<string>(true, _dataAccessIdioma.SelectTraduccion(idioma, NombreControl));
        } 
    }
}
