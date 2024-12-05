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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ServiceForm : Form, IObserver
    {
        protected readonly BusinessIdioma _businessIdioma;
        protected SessionManager _sessionManager;
        protected readonly BusinessBitacoraEvento _businessBitacoraEvento;
        private readonly BusinessDigitoVerificador _businessDigitoVerificador;
        private readonly BusinessNotificacion _businessNotificacion;

        public ServiceForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            _sessionManager = SessionManager.GetInstance();

            _businessIdioma = new BusinessIdioma();
            _businessBitacoraEvento = new BusinessBitacoraEvento();
            _businessDigitoVerificador = new BusinessDigitoVerificador();
            _businessNotificacion = new BusinessNotificacion();

            InitializeComponent();
            SendPromotion();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(1150, 650);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ServiceForm";
            ResumeLayout(false);
        }

        protected void ShowLabelError(BunifuLabel label, string NombreControl = null, EntityIdioma idioma = null)
        {
            label.Text = SearchTraduccion(NombreControl, idioma);
            label.Visible = true;
        }

        protected void HideLabelError(List<BunifuLabel> labels)
        {
            foreach (var label in labels)
            {
                label.Visible = false;
            }
        }

        protected void RevisarRespuestaServicio<T>(BusinessResponse<T> respuesta, EntityIdioma idioma = null)
        {
            if (!respuesta.Ok)
            {
                MessageBox.Show(SearchTraduccion(respuesta.Mensaje, idioma), "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (respuesta.Ok && !string.IsNullOrEmpty(respuesta.Mensaje))
            {
                MessageBox.Show(SearchTraduccion(respuesta.Mensaje, idioma), "Great!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Notify(EntityIdioma idioma)
        {
            ChangeTranslation(idioma);
        }

        protected void ChangeTranslation(EntityIdioma idioma = null, Control.ControlCollection collectionPanel = null)
        {
            if (idioma == null) idioma = _sessionManager.Idioma;

            Control.ControlCollection controlCollection = collectionPanel ?? Controls;

            foreach (Control item in controlCollection)
            {
                if (item is Panel || item is BunifuPanel) ChangeTranslation(idioma, item.Controls);

                if (item is Label || item is BunifuLabel || item is Button || item is BunifuButton || item is CheckBox)
                {
                    // Buscar por name en la tabla junto con el id y setear el text del idioma seleccionado
                    item.Text = _businessIdioma.GetTraduccion(idioma, item.Name).Data;
                }
            }
        }

        protected string SearchTraduccion(string controlName, EntityIdioma idioma = null)
        {
            return _businessIdioma.GetTraduccion(idioma ?? _sessionManager.Idioma, controlName).Data;
        }

        protected void RegistrarEvento(string modulo, string evento, int criticidad)
        {
            _businessBitacoraEvento.Create(new EntityBitacoraEvento
            {
                User = _sessionManager.User,
                Modulo = modulo,
                Evento = evento,
                Criticidad = criticidad
            });
        }


        // Método para convertir DataGridView a DataTable
        protected DataTable DataGridViewToDataTable(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Agregar columnas al DataTable
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // Agregar filas al DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            if (dataTable.Columns.Contains("Id"))
            {
                dataTable.Columns.Remove("Id");
            }

            return dataTable;
        }

        protected bool ValidarDigitoVerificador()
        {
            EntityDigitoVerificador digitoVerificadorCalculado = _businessDigitoVerificador.Calcular().Data;
            EntityDigitoVerificador digitoVerificadorDB = _businessDigitoVerificador.Get().Data;

            return string.Equals(digitoVerificadorCalculado.DVH, digitoVerificadorDB.DVH)
                && string.Equals(digitoVerificadorCalculado.DVV, digitoVerificadorDB.DVV);
        }

        protected void UpdateDigitoVerificador()
        {
            _businessDigitoVerificador.Update();
        }

        private void SendPromotion()
        {
            _businessNotificacion.Create();

            List<EntityCliente> clientes = _businessNotificacion.GetAll().Data;

            if (clientes.Count <= 0)
            {
                return;
            }

            foreach (EntityCliente cliente in clientes)
            {
                // Configuración del mensaje
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mailRemitente");
                mail.To.Add(cliente.Email);
                mail.Subject = "20% OFF En Eventos";

                // Personalizar el cuerpo con el nombre y apellido del cliente
                mail.Body = $"<h1>¡Felicidades {cliente.Nombre} {cliente.Apellido}!</h1>" +
                            "<p>Has recibido un <strong>20% de descuento</strong> para tu próximo evento en el <em>Salón de eventos Azaila</em>.</p>" +
                            "<p>Aprovecha esta oportunidad única para celebrar con nosotros.</p>" +
                            "<p>¡Te esperamos!</p>";
                mail.IsBodyHtml = true;

                // Configuración del cliente SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("mailRemitente", "mypass"),
                    EnableSsl = true
                };

                try
                {
                    // Enviar el correo
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }

            _businessNotificacion.Update();
        }

    }
}
