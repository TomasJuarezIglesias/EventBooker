using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormInicio : ServiceForm
    {
        private readonly BusinessReserva businessReserva;
        private DataTable ProximosEventos;
        private int EventoActualIndex;

        public FormInicio()
        {
            InitializeComponent();

            ChangeTranslation();
            LblCliente.Text += $":";
            businessReserva = new BusinessReserva();
            GenerarInterfaz();
        }


        private void GenerarInterfaz()
        {
            PanelProximosEventos.Hide();

            ProximosEventos = businessReserva.ProximosEventos().Data;

            if (ProximosEventos.Rows.Count == 0)
            {
                TimerReporte.Enabled = false;
                PanelProximosEventos.Hide();
                return;
            }

            EventoActualIndex = 0;

            MostrarEventoActual();

            TimerReporte.Enabled = true;
            PanelProximosEventos.Show();
        }

        private void TimerReporte_Tick(object sender, EventArgs e)
        {
            EventoActualIndex++;

            if (EventoActualIndex >= ProximosEventos.Rows.Count)
            {
                EventoActualIndex = 0;
            }

            MostrarEventoActual();
        }

        private void MostrarEventoActual()
        {
            DataRow row = ProximosEventos.Rows[EventoActualIndex];

            LblDatoEvento.Text = $" {row["Descripcion"]}";
            LblDatoFecha.Text = $" {Convert.ToDateTime(row["Fecha"]):dd/MM/yyyy} {row["Turno"]}";
            LblDatoUbicacion.Text = $" {row["Ubicacion"]}";
            LblDatoCliente.Text = $" {row["Nombre"]} {row["Apellido"]} - {row["Contacto"]}";
            LblDatoMedioPago.Text = $" {row["MetodoPago"]}";
        }

    }
}
