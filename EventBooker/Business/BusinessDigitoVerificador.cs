using DataAccess;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessDigitoVerificador
    {
        private readonly DataAccessDigitoVerificador _dataAccessDigitoVerificador;

        public BusinessDigitoVerificador()
        {
            _dataAccessDigitoVerificador = new DataAccessDigitoVerificador();
        }

        public BusinessResponse<EntityDigitoVerificador> Get() 
        {
            return new BusinessResponse<EntityDigitoVerificador>(true, _dataAccessDigitoVerificador.Select());
        }

        public BusinessResponse<bool> Update() 
        {
            _dataAccessDigitoVerificador.Update(Calcular().Data);
            return new BusinessResponse<bool>(true, true);
        }

        public BusinessResponse<EntityDigitoVerificador> Calcular() 
        {
            List<string> tablesNames = new List<string> 
            { 
                "Cliente",
                "Factura",
                "Reserva",
                "ReservaServicio",
                "Salon",
                "Servicio",
            };

            string dvh = string .Empty;
            string dvv = string .Empty;

            foreach (string tablesName in tablesNames)
            {
                DataTable dataTable = _dataAccessDigitoVerificador.SelectTable(tablesName);
                dvh += CalcularDVH(dataTable);
                dvv += CalcularDVV(dataTable);
            }

            EntityDigitoVerificador digitoVerificador = new EntityDigitoVerificador 
            {
                DVH = CryptoManager.EncryptString(dvh),
                DVV = CryptoManager.EncryptString(dvv),
            };

            return new BusinessResponse<EntityDigitoVerificador>(true, digitoVerificador);
        }

        private string CalcularDVH(DataTable table)
        {
            string DVHHash = string.Empty;

            string DataConcat = string.Empty;

            foreach (DataRow row in table.Rows)
            {
                DataConcat = string.Empty;

                foreach (DataColumn column in row.Table.Columns)
                {
                    DataConcat += row[column].ToString();
                }

                DVHHash += CryptoManager.EncryptString(DataConcat);
            }

            return CryptoManager.EncryptString(DVHHash);
        }

        private string CalcularDVV(DataTable table)
        {
            string DVVHash = string.Empty;

            string DataConcat = string.Empty;

            foreach (DataColumn column in table.Columns)
            {
                DataConcat = string.Empty;

                foreach (DataRow row in table.Rows)
                {
                    DataConcat += row[column].ToString(); 
                }

                DVVHash += CryptoManager.EncryptString(DataConcat); 
            }

            return CryptoManager.EncryptString(DVVHash);
        }


    }
}
