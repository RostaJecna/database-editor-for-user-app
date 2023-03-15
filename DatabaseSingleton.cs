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
            Null,
            Success,
            Connected,
            Failure
        }

        private static SqlConnection connection = null;
        public static Status status = Status.Null;

        public static SqlConnection Instance()
        {
            return connection ?? (connection = new SqlConnection(new SqlConnectionStringBuilder()
            {
                InitialCatalog = ReadSetting("InitialCatalog"),
                IntegratedSecurity = bool.Parse(ReadSetting("IntegratedSecurity")),
                DataSource = ReadSetting("DataSource"),
                UserID = ReadSetting("UserID"),
                Password = ReadSetting("Password"),
                ConnectTimeout = 8
            }.ConnectionString));
        }

        public static void CloseAndDispose()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                    status = Status.Null;
                }
            }
            finally
            {
                connection = null;
            }
        }

        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
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
