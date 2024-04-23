using System;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    public partial class ConfigurationForm : Form
    {
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

        private void IntegratedSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            userNameTextBox.Enabled = passwordTextBox.Enabled = authenticationCheckBox.Checked;
        }
    }
}