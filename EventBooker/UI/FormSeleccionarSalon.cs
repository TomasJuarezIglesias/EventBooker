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

        public FormSeleccionarSalon(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();
            this.openChildForm = openChildForm;
            _businessSalon = new BusinessSalon();
            FillComboBox();
            DateTimePickerFecha.Value = DateTime.Now;
        }

        private void FillComboBox()
        {
            List<EntitySalon> salones = _businessSalon.GetAll().Data;

            CmbSalon.DataSource = null;
            CmbSalon.DataSource = salones;
            CmbSalon.DisplayMember = "Ubicacion";
            CmbSalon.SelectedIndex = -1;
        }

        private void CmbSalon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EntitySalon salon = CmbSalon.SelectedItem as EntitySalon;

            LblNombre.Text = $"Nombre: {salon.Nombre}";
            LblUbicacion.Text = $"Ubicación: {salon.Ubicacion}";
            LblPrecio.Text = $"Precio: ${salon.Precio}";
            LblPrecioCubierto.Text = $"Precio Cubierto: ${salon.PrecioCubierto}";
            LblCapacidad.Text = $"Capacidad: {salon.Capacidad}";
            LblCantidadMinimaInvitados.Text = $"Cantidad Minima Invitados: {salon.CantidadMinimaInvitados}";
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if(CmbSalon.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false,false, "Debe seleccionar salón"));
                return;
            }
            
            if(DateTimePickerFecha.Value.Date < DateTime.Now.Date)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false,false, "Debe seleccionar una fecha mayor a la actual"));
                return;
            }

            if(CmbTurnos.SelectedIndex == -1)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false,false, "Debe seleccionar turno"));
                return;
            }

            EntitySalon salon = CmbSalon.SelectedItem as EntitySalon;

            BusinessResponse<bool> response = _businessSalon.VerificarDisponibilidad(salon, DateTimePickerFecha.Value, CmbTurnos.Text);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                // Redirigir a registrar reserva junto con la data seleccionada
            }
        }
    }
}
