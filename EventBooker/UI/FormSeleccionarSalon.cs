using Business;
using Entities;
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
    public partial class FormSeleccionarSalon : ServiceForm
    {
        private Action<ServiceForm> openChildForm;
        private readonly BusinessSalon _businessSalon;
        private EntityReserva _reserva;

        public FormSeleccionarSalon(Action<ServiceForm> openChildForm, EntityReserva reserva)
        {
            InitializeComponent();
            ChangeTranslation();

            this.openChildForm = openChildForm;
            _businessSalon = new BusinessSalon();
            _reserva = reserva is null ? new EntityReserva() : reserva;
            FillData();
        }

        private void FillData()
        {
            List<EntitySalon> salones = _businessSalon.GetAll().Data;

            CmbSalon.DataSource = null;
            CmbSalon.DataSource = salones;
            CmbSalon.DisplayMember = "Ubicacion";
            CmbSalon.SelectedIndex = -1;

            if (_reserva?.Salon != null)
            {
                CmbSalon.SelectedItem = salones.FirstOrDefault(s => s.Id == _reserva.Salon.Id);
                FillLabelsSalon();
            }

            DateTimePickerFecha.Value = _reserva?.Fecha != DateTime.MinValue ? _reserva.Fecha : DateTime.Now;
            CmbTurnos.SelectedItem = _reserva?.Turno != null ? _reserva.Turno : null; 
        }

        private void CmbSalon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillLabelsSalon();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (CmbSalon.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarSalon"));
                return;
            }

            if (DateTimePickerFecha.Value.Date < DateTime.Now.Date)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarFechaMayor"));
                return;
            }

            if (CmbTurnos.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageDebeSeleccionarTurno"));
                return;
            }

            EntitySalon salon = CmbSalon.SelectedItem as EntitySalon;

            BusinessResponse<bool> response = _businessSalon.VerificarDisponibilidad(salon, DateTimePickerFecha.Value, CmbTurnos.Text);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                _reserva.Salon = salon;
                _reserva.Fecha = DateTimePickerFecha.Value;
                _reserva.Turno = CmbTurnos.Text;

                this.Close();
                openChildForm(new FormRegistrarReserva(openChildForm, _reserva));
            }
        }

        private void FillLabelsSalon()
        {
            EntitySalon salon = CmbSalon.SelectedItem as EntitySalon;

            LblNombreSalon.Text = $"{SearchTraduccion("LblNombre")} {salon.Nombre}";
            LblUbicacion.Text = $"{SearchTraduccion("LblUbicacion")} {salon.Ubicacion}";
            LblPrecio.Text = $"{SearchTraduccion("LblPrecio")} ${salon.Precio}";
            LblPrecioCubierto.Text = $"{SearchTraduccion("LblPrecioCubierto")} ${salon.PrecioCubierto}";
            LblCapacidad.Text = $"{SearchTraduccion("LblCapacidad")} {salon.Capacidad}";
            LblCantidadMinimaInvitados.Text = $"{SearchTraduccion("LblCantidadMinimaInvitados")} {salon.CantidadMinimaInvitados}";
        }
    }
}
