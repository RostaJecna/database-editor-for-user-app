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
    internal static class DatabaseSingleton
    {
        internal enum Status
        {
            None,
            Success,
            Connected,
            Failure
        }

        private static SqlConnection connection = null;
        public static Status status = Status.None;

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
                    status = Status.None;
                }
            }
            finally
            {
                connection = null;
            }
        }

        public static bool IsConnected()
        {
            return status == Status.Connected;
        }

        public static bool IsFailure() 
        {
            return status == Status.Failure;
        }
    }
}
