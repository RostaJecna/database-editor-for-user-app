using System;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    /// <summary>
    ///     Form for configuring database connection settings.
    /// </summary>
    public partial class ConfigurationForm : Form
    {
        /// <summary>
        ///     Initializes a new instance of the ConfigurationForm class.
        /// </summary>
        public ConfigurationForm()
        {
            InitializeComponent();

            if (DatabaseSingleton.DatabaseConfiguration == null) return;
            serverNameTextBox.Text = DatabaseSingleton.DatabaseConfiguration.ServerName;
            databaseNameTextBox.Text = DatabaseSingleton.DatabaseConfiguration.DatabaseName;

            if (!DatabaseSingleton.DatabaseConfiguration.IntegratedSecurity)
            {
                authenticationCheckBox.Checked = true;
                userNameTextBox.Text = DatabaseSingleton.DatabaseConfiguration.UserName;
                passwordTextBox.Text = DatabaseSingleton.DatabaseConfiguration.Password;
            }
        }

        /// <summary>
        ///     Handles the click event for the Save button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serverNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(databaseNameTextBox.Text))
            {
                MessageBox.Show(@"Complete all the fields.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (authenticationCheckBox.Checked && (string.IsNullOrWhiteSpace(userNameTextBox.Text) ||
                                                   string.IsNullOrWhiteSpace(passwordTextBox.Text)))
            {
                MessageBox.Show(@"Complete all the fields.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseSingleton.DatabaseConfiguration = authenticationCheckBox.Checked
                ? new DatabaseConfiguration(serverNameTextBox.Text, databaseNameTextBox.Text, userNameTextBox.Text,
                    passwordTextBox.Text)
                : new DatabaseConfiguration(serverNameTextBox.Text, databaseNameTextBox.Text);

            Close();
        }

        /// <summary>
        ///     Handles the checked changed event for the Integrated Security check box.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void IntegratedSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            userNameTextBox.Enabled = passwordTextBox.Enabled = authenticationCheckBox.Checked;
        }
    }
}