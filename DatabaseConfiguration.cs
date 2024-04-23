namespace DatabaseEditorForUser
{
    internal class DatabaseConfiguration
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public DatabaseConfiguration(string serverName, string databaseName, string userName, string password)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = false;
            UserName = userName;
            Password = password;
        }

        public DatabaseConfiguration(string serverName, string databaseName)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            IntegratedSecurity = true;
        }

        public override string ToString()
        {
            return IntegratedSecurity
                ? $"DataSource = {ServerName}, InitialCatalog = {DatabaseName}"
                : $"DataSource = {ServerName}, InitialCatalog = {DatabaseName}, IntegratedSecurity = {IntegratedSecurity}" +
                  $"UserID = {UserName}, Password = {Password}";
        }
    }
}