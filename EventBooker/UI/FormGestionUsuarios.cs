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
    public partial class FormGestionUsuarios : ServiceForm
    {
        private BusinessUser _BusinessUser;
        private List<EntityUser> users;
        public FormGestionUsuarios()
        {
            InitializeComponent();
            _BusinessUser = new BusinessUser();
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            users = _BusinessUser.GetAll().Data;
            DataGridViewUsuarios.DataSource = null;
            DataGridViewUsuarios.DataSource = users;
            DataGridViewUsuarios.Columns["Id"].Visible = false;
            DataGridViewUsuarios.Columns["Password"].Visible = false;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                EntityUser user = new EntityUser
                {
                    
                };
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
