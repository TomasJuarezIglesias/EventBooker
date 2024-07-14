using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Business;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormGestionClientes : ServiceForm
    {
        private readonly BusinessCliente _businessCliente;

        public FormGestionClientes()
        {
            InitializeComponent();
            ChangeTranslation();
            _businessCliente = new BusinessCliente();
            FillDataGridView();
            HidePanelData();
        }


        private void BtnCrear_Click(object sender, EventArgs e)
        {
            HideButtons(BtnCrear);
            ShowPanelData();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                EntityCliente cliente = DataGridViewClientes.SelectedRows[0].DataBoundItem as EntityCliente;

                HideButtons(BtnModificar);
                ShowPanelData();

                TxtNombre.Text = cliente.Nombre;
                TxtApellido.Text = cliente.Apellido;
                TxtDni.Text = cliente.Dni.ToString();
                TxtEmail.Text = cliente.Email;
                TxtContacto.Text = cliente.Contacto.ToString();
                TxtDireccion.Text = CheckShowDireccion.Checked ? cliente.Direccion : CryptoManager.ReversibleDecrypt(cliente.Direccion);

            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageSeleccionarCliente"));
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EntityCliente cliente = DataGridViewClientes.SelectedRows[0].DataBoundItem as EntityCliente;

                DialogResult result = MessageBox.Show(
                $"{SearchTraduccion("MessageDeseaEliminarCliente")}",
                $"{SearchTraduccion("CaptionConfirmarEliminar")}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                // Verifica el resultado de la selección del usuario
                if (result == DialogResult.Yes)
                {
                    RevisarRespuestaServicio(_businessCliente.Delete(cliente));
                    FillDataGridView();
                }
            }
            catch (Exception)
            {
                RevisarRespuestaServicio(new BusinessResponse<bool>(false, false, "MessageSeleccionarCliente"));
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox()) return;

            BusinessResponse<bool> response = new BusinessResponse<bool>(false, false, "");

            if (BtnCrear.Visible)
            {
                EntityCliente cliente = new EntityCliente
                {
                    Dni = Convert.ToInt32(TxtDni.Text.Trim()),
                    Nombre = TxtNombre.Text.Trim(),
                    Apellido = TxtApellido.Text.Trim(),
                    Direccion = CryptoManager.ReversibleEncrypt(TxtDireccion.Text.Trim()),
                    Email = TxtEmail.Text.Trim(),
                    Contacto = Convert.ToInt32(TxtContacto.Text.Trim())
                };

                response = _businessCliente.Create(cliente);

                RevisarRespuestaServicio(response);
            }

            if (BtnModificar.Visible)
            {
                EntityCliente cliente = DataGridViewClientes.SelectedRows[0].DataBoundItem as EntityCliente;

                EntityCliente clienteUpdated = new EntityCliente
                {
                    Id = cliente.Id,
                    Dni = Convert.ToInt32(TxtDni.Text.Trim()),
                    Nombre = TxtNombre.Text.Trim(),
                    Apellido = TxtApellido.Text.Trim(),
                    Direccion = CryptoManager.ReversibleEncrypt(TxtDireccion.Text.Trim()),
                    Email = TxtEmail.Text.Trim(),
                    Contacto = Convert.ToInt32(TxtContacto.Text.Trim())
                };

                response = _businessCliente.Update(clienteUpdated);

                RevisarRespuestaServicio(response);
            }

            if (response.Ok)
            {
                FillDataGridView();
                ShowButtons();
                HidePanelData();
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ShowButtons();
            HideLabelError(new List<BunifuLabel>
            {
                LblErrorNombre,
                LblErrorApellido,
                LblErrorDni,
                LblErrorContacto,
                LblErrorDireccion,
                LblErrorMail
            });
            HidePanelData();
            DataGridViewClientes.CurrentCell = null;
        }


        private void FillDataGridView()
        {
            List<EntityCliente> clientes = _businessCliente.GetAll().Data;

            if (!CheckShowDireccion.Checked)
            {
                foreach (var cliente in clientes)
                {
                    cliente.Direccion = CryptoManager.ReversibleEncrypt(cliente.Direccion);
                }
            }

            DataGridViewClientes.DataSource = null;
            DataGridViewClientes.DataSource = clientes;

            DataGridViewClientes.Columns["Id"].Visible = false;
        }

        private void CheckShowDireccion_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void ShowButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is BunifuButton)
                {
                    control.Visible = true;
                }
            }
        }
        private void HideButtons(BunifuButton button)
        {
            foreach (Control control in this.Controls)
            {
                if (control is BunifuButton && control != button)
                {
                    control.Visible = false;
                }
            }
        }

        private void ShowPanelData()
        {
            PanelData.Visible = true;
            EmptyTextBox();
        }

        private void HidePanelData()
        {
            PanelData.Visible = false;
            EmptyTextBox();
        }

        private void EmptyTextBox()
        {
            TxtDni.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtApellido.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            TxtContacto.Text = string.Empty;
            TxtEmail.Text = string.Empty;
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
                LblErrorMail
            });

            bool ok = true;

            if (string.IsNullOrEmpty(TxtNombre.Text))
            {
                ShowLabelError("Debe Ingresar el nombre", LblErrorNombre, "LblErrorNombre");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtApellido.Text))
            {
                ShowLabelError("Debe Ingresar el apellido", LblErrorApellido, "LblErrorApellido");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtDni.Text))
            {
                ShowLabelError("Debe ingresar dni", LblErrorDni, "LblErrorDni");
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtDni.Text) && !RegexValidationService.IsValidDni(TxtDni.Text))
            {
                ShowLabelError("Formato del dni incorrecto", LblErrorDni, "MessageFormatoDniIncorrecto");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                ShowLabelError("Debe ingresar mail", LblErrorMail, "LblErrorMail");
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtEmail.Text) && !RegexValidationService.IsValidEmail(TxtEmail.Text))
            {
                ShowLabelError("Formato del mail incorrecto", LblErrorMail, "MessageFormatoMailIncorrecto");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtDireccion.Text))
            {
                ShowLabelError("Debe ingresar direccion", LblErrorDireccion, "LblErrorDireccion");
                ok = false;
            }

            if (string.IsNullOrEmpty(TxtContacto.Text))
            {
                ShowLabelError("Debe ingresar contacto", LblErrorContacto, "LblErrorContacto");
                ok = false;
            }

            if (!string.IsNullOrEmpty(TxtContacto.Text) && !RegexValidationService.IsValidContact(TxtContacto.Text))
            {
                ShowLabelError("Formato del contacto incorrecto", LblErrorContacto, "MessageFormatoContactoIncorrecto");
                ok = false;
            }

            return ok;
        }

        private void DataGridViewClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewClientes.CurrentCell = null;
        }
    }
}
