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
    public partial class FormReparacionDV : ServiceForm
    {
        private BusinessBackup _businessBackup;

        public FormReparacionDV()
        {
            InitializeComponent();
            ChangeTranslation();

            _businessBackup = new BusinessBackup();
        }

        private void LblRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Backup Files (*.bak)|*.bak";

                if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    _businessBackup.RealizarRestore(openFileDialog.FileName);
                    RegistrarEvento("Login", "Restore", 1);
                    RevisarRespuestaServicio(new BusinessResponse<bool>(true, true, "MessageAplicadoCorrectamente"));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void BtnRecalcularDV_Click(object sender, EventArgs e)
        {
            UpdateDigitoVerificador();
            RevisarRespuestaServicio(new BusinessResponse<bool>(true, true, "MessageAplicadoCorrectamente"));
            RegistrarEvento("Login", "Recalculo DV", 1);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
