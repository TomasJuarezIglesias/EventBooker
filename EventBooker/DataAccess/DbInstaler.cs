using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [RunInstaller(true)]
    internal class DbInstaler: Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string connectionString = "Data Source=LocalHost; Initial Catalog=EventBooker; Integrated Security=True";

            string scriptPath = Context.Parameters["path"];

            if (System.IO.File.Exists(scriptPath))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string script = System.IO.File.ReadAllText(scriptPath);
                    SqlCommand command = new SqlCommand(script, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState); 
        }
    }
}
