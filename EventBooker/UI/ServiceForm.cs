﻿using Bunifu.UI.WinForms;
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

        public ServiceForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            _sessionManager = SessionManager.GetInstance();

            _businessIdioma = new BusinessIdioma();
            _businessBitacoraEvento = new BusinessBitacoraEvento();
            InitializeComponent();
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
    }
}
