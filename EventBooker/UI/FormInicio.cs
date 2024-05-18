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
    public partial class FormInicio : ServiceForm
    {
        private SessionManager _sessionManager;
        public FormInicio()
        {
            InitializeComponent();
            _sessionManager = SessionManager.GetInstance();
            LblSaludo.Text = $"Bienvenido {_sessionManager.User.Username}";
        }
    }
}
