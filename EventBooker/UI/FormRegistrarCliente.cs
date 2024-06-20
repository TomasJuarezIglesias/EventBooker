using Bunifu.UI.WinForms;
using Business;
using Entities;
using Services;
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
    public partial class FormRegistrarCliente : ServiceForm
    {
        private readonly BusinessCliente _businessCliente;
        private Action<ServiceForm> _openChildForm;
        private EntityReserva _reserva;

        public FormRegistrarCliente(Action<ServiceForm> openChildForm, EntityReserva reserva)
        {
            _openChildForm = openChildForm;
            _businessCliente = new BusinessCliente();
            _reserva = reserva;
            InitializeComponent();
        }

        private void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

            EntityCliente cliente = new EntityCliente
            {
                Dni = Convert.ToInt32(TxtDni.Text.Trim()),
                Nombre = TxtNombre.Text.Trim(),
                Apellido = TxtApellido.Text.Trim(),
                Direccion = CryptoManager.ReversibleEncrypt(TxtDireccion.Text.Trim()),
                Email = TxtEmail.Text.Trim(),
                Contacto = Convert.ToInt32(TxtContacto.Text.Trim()),
            };

            BusinessResponse<bool> response = _businessCliente.Create(cliente);

            RevisarRespuestaServicio(response);

            if (response.Ok)
            {
                this.Close();
                _reserva.Cliente = cliente;
                _openChildForm(new FormRegistrarReserva(_openChildForm, _reserva));
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            $"¿Está seguro que desea volver?",
            $"Volver",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // Verifica el resultado de la selección del usuario
            if (result == DialogResult.Yes)
            {
                this.Close();
                _openChildForm(new FormRegistrarReserva(_openChildForm, _reserva));
            }
        }

        private bool ValidateTextBox()
        {
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorNombre,
                LblErrorApellido,
                LblErrorDni,
                LblErrorContacto,
                LblErrorDireccion,
                LblErrorEmail
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtNombre.Text))
            {
                ShowLabelError("Debe Ingresar el nombre", LblErrorNombre);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtApellido.Text))
            {
                ShowLabelError("Debe Ingresar el apellido", LblErrorApellido);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtDni.Text))
            {
                ShowLabelError("Debe ingresar dni", LblErrorDni);
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtDni.Text) && !RegexValidationService.IsValidDni(TxtDni.Text))
            {
                ShowLabelError("Formato del dni incorrecto", LblErrorDni);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                ShowLabelError("Debe ingresar mail", LblErrorEmail);
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtEmail.Text) && !RegexValidationService.IsValidEmail(TxtEmail.Text))
            {
                ShowLabelError("Formato del mail incorrecto", LblErrorEmail);
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtDireccion.Text))
            {
                ShowLabelError("Debe ingresar direccion", LblErrorDireccion);
                ok = false;
            }

            if(string.IsNullOrEmpty(TxtContacto.Text))
            {
                ShowLabelError("Debe ingresar contacto", LblErrorContacto);
                ok = false;
            }

            if(!string.IsNullOrEmpty(TxtContacto.Text) && !RegexValidationService.IsValidContact(TxtContacto.Text))
            {
                ShowLabelError("Formato del contacto incorrecto", LblErrorContacto);
                ok = false;
            }

            return ok;
        }
    }
}
