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
        public static DatabaseConfiguration databaseConfiguration = null;

        public static SqlConnection Instance()
        {
            if (connection == null)
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder
                {
                    InitialCatalog = ReadSetting("InitialCatalog"),
                    IntegratedSecurity = bool.Parse(ReadSetting("IntegratedSecurity")),
                    DataSource = ReadSetting("DataSource"),
                    UserID = ReadSetting("UserID"),
                    Password = ReadSetting("Password"),
                    ConnectTimeout = 8
                };
                if (databaseConfiguration != null)
                {
                    scsb.InitialCatalog = databaseConfiguration.DatabaseName;
                    scsb.DataSource = databaseConfiguration.ServerName;
                    scsb.IntegratedSecurity = databaseConfiguration.IntegratedSecurity;

                    if (!databaseConfiguration.IntegratedSecurity)
                    {
                        scsb.UserID = databaseConfiguration.UserName;
                        scsb.Password = databaseConfiguration.Password;
                    }
                }
                connection = new SqlConnection(scsb.ConnectionString);
            }
            return connection;
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
