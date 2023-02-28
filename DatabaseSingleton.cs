using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DatabaseEditorForUser
{
    internal class DatabaseSingleton
    {
        private static SqlConnection connection = null;

        public static SqlConnection Instance()
        {
            return connection ?? (connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]));
        }

        public static void CloseAndDispose()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            finally
            {
                connection = null;
            }
        }
    }
}
