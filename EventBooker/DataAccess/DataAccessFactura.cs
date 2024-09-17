using Entities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessFactura
    {
        private readonly DBConnection connection;

        public DataAccessFactura()
        {
            connection = DBConnection.GetInstance();
        }

        public List<EntityFactura> SelectAll()
        {
            List<EntityFactura> facturas = new List<EntityFactura>();

            DataTable data = connection.Read("SP_SelectFacturas");

            foreach (DataRow row in data.Rows) 
            { 
                EntityFactura factura = SqlMapper.MapFactura(row);

                factura.Cliente = SqlMapper.MapCliente(row);
                factura.Reserva = SqlMapper.MapReserva(row);
                factura.Reserva.Salon = SqlMapper.MapSalon(row);

                factura.Reserva.Servicios = new List<EntityServicio>();

                DataTable dataServicios = connection.Read("SP_SelectReservaServicio", new SqlParameter[]
                {
                    new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = factura.Reserva.Id }
                });

                foreach (DataRow servicio in dataServicios.Rows)
                {
                    factura.Reserva.Servicios.Add(SqlMapper.MapServicio(servicio));
                }

                facturas.Add(factura);
            }

            return facturas;
        }

        public int Insert(EntityFactura factura)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@In_IdReserva", SqlDbType.Int){ Value = factura.Reserva.Id },
                new SqlParameter("@In_IdCliente", SqlDbType.Int){ Value = factura.Cliente.Id },
                new SqlParameter("@In_ImporteTotal", SqlDbType.Money){ Value = factura.ImporteTotal},
                new SqlParameter("@In_Impuestos", SqlDbType.Money){ Value = factura.Impuestos},
                new SqlParameter("@In_MetodoPago", SqlDbType.NVarChar){ Value = factura.MetodoPago},
                new SqlParameter("@In_Observaciones", SqlDbType.NVarChar){ Value = factura.Observaciones}
            };

            return connection.WriteWithReturn("SP_CreateFactura", parameters);
        }
    }
}
