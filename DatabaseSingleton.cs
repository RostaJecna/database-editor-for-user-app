using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;

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

        private static SqlConnection _connection;
        public static Status DbStatus = Status.Null;
        public static DatabaseConfiguration DatabaseConfiguration = null;

        public static SqlConnection Instance()
        {
            if (_connection != null) return _connection;
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = ReadSetting("InitialCatalog"),
                IntegratedSecurity = bool.Parse(ReadSetting("IntegratedSecurity")),
                DataSource = ReadSetting("DataSource"),
                UserID = ReadSetting("UserID"),
                Password = ReadSetting("Password"),
                ConnectTimeout = 8
            };
            if (DatabaseConfiguration != null)
            {
                sqlConnectionStringBuilder.InitialCatalog = DatabaseConfiguration.DatabaseName;
                sqlConnectionStringBuilder.DataSource = DatabaseConfiguration.ServerName;
                sqlConnectionStringBuilder.IntegratedSecurity = DatabaseConfiguration.IntegratedSecurity;

                if (!DatabaseConfiguration.IntegratedSecurity)
                {
                    sqlConnectionStringBuilder.UserID = DatabaseConfiguration.UserName;
                    sqlConnectionStringBuilder.Password = DatabaseConfiguration.Password;
                }
            }

            _connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            return _connection;
        }

        public static void CloseAndDispose()
        {
            try
            {
                if (_connection == null) return;
                _connection.Close();
                _connection.Dispose();
                DbStatus = Status.Null;
            }
            finally
            {
                _connection = null;
            }
        }

        private static string ReadSetting(string key)
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }

        public static bool IsConnected()
        {
            return DbStatus == Status.Connected;
        }

        public static bool IsFailure()
        {
            return DbStatus == Status.Failure;
        }
    }
}