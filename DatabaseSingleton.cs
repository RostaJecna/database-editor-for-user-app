using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseEditorForUser
{
    /// <summary>
    /// Represents a singleton class responsible for managing database connections.
    /// </summary>
    internal static class DatabaseSingleton
    {
        /// <summary>
        /// Represents the status of the database connection.
        /// </summary>
        internal enum Status
        {
            Null,
            Success,
            Connected,
            Failure
        }

        private static SqlConnection _connection;
        
        /// <summary>
        /// Gets or sets the current status of the database connection.
        /// </summary>
        public static Status DbStatus { get; set; } = Status.Null;
        
        /// <summary>
        /// Gets or sets the configuration for the database connection.
        /// </summary>
        public static DatabaseConfiguration DatabaseConfiguration { get; set; } = null;

        /// <summary>
        /// Gets an instance of the database connection.
        /// </summary>
        /// <returns>An instance of SqlConnection representing the database connection.</returns>
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

        /// <summary>
        /// Closes and disposes the current database connection.
        /// </summary>
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

        /// <summary>
        /// Checks if the database is currently connected.
        /// </summary>
        /// <returns>True if the database is connected; otherwise, false.</returns>
        public static bool IsConnected()
        {
            return DbStatus == Status.Connected;
        }

        /// <summary>
        /// Checks if there was a failure in establishing the database connection.
        /// </summary>
        /// <returns>True if there was a failure; otherwise, false.</returns>
        public static bool IsFailure()
        {
            return DbStatus == Status.Failure;
        }
    }
}
