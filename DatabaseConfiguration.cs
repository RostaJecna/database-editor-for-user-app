namespace DatabaseEditorForUser
{
    /// <summary>
    ///     Represents the configuration for connecting to a database.
    /// </summary>
    internal class DatabaseConfiguration
    {
        /// <summary>
        ///     Gets or sets the server name.
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the database.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether integrated security is used for authentication.
        /// </summary>
        public bool IntegratedSecurity { get; set; }

        /// <summary>
        ///     Gets or sets the user name for authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     Gets or sets the password for authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseConfiguration" /> class with specified parameters.
        /// </summary>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <param name="userName">The user name for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        public DatabaseConfiguration(string serverName, string databaseName, string userName, string password)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = false;
            UserName = userName;
            Password = password;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseConfiguration" /> class with integrated security.
        /// </summary>
        /// <param name="serverName">The server name.</param>
        /// <param name="databaseName">The name of the database.</param>
        public DatabaseConfiguration(string serverName, string databaseName)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = true;
        }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return IntegratedSecurity
                ? $"DataSource = {ServerName}, InitialCatalog = {DatabaseName}"
                : $"DataSource = {ServerName}, InitialCatalog = {DatabaseName}, IntegratedSecurity = {IntegratedSecurity}" +
                  $"UserID = {UserName}, Password = {Password}";
        }
    }
}