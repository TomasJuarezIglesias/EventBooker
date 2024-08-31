using Business;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class FormRespaldos : ServiceForm
    {
        private BusinessBackup _businessBackup;
        private Action<ServiceForm> _openChildForm;

        public FormRespaldos(Action<ServiceForm> openChildForm)
        {
            InitializeComponent();

            ChangeTranslation();

            _businessBackup = new BusinessBackup();

            _openChildForm = openChildForm;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSeleccionarDirBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPathBackup.Text = folderDialog.SelectedPath;
                    BtnAplicarBackup.Enabled = true;
                }
            }
        }

        private void BtnAplicarBackup_Click(object sender, EventArgs e)
        {
            _businessBackup.RealizarBackup(TxtPathBackup.Text);
            TxtPathBackup.Text = string.Empty;
            BtnAplicarBackup.Enabled = false;
            RevisarRespuestaServicio(new BusinessResponse<bool>(true, true, "MessageAplicadoCorrectamente"));
        }

        private void BtnSeleccionarDirRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Backup Files (*.bak)|*.bak";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtPathRestore.Text = openFileDialog.FileName;
                    BtnAplicarRestore.Enabled = true;
                }
            }
        }

        private void BtnAplicarRestore_Click(object sender, EventArgs e)
        {
            _businessBackup.RealizarRestore(TxtPathRestore.Text);
            TxtPathRestore.Text = string.Empty;
            _openChildForm(new FormInicio());
            BtnAplicarRestore.Enabled = false;

            RevisarRespuestaServicio(new BusinessResponse<bool>(true, true, "MessageAplicadoCorrectamente"));
        }
    }
}
