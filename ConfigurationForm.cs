using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();

            if (DatabaseSingleton.databaseConfiguration != null)
            {
                serverNameTextBox.Text = DatabaseSingleton.databaseConfiguration.ServerName;
                databaseNameTextBox.Text = DatabaseSingleton.databaseConfiguration.DatabaseName;

                if (!DatabaseSingleton.databaseConfiguration.IntegratedSecurity)
                {
                    userNameTextBox.Text = DatabaseSingleton.databaseConfiguration.UserName;
                    passwordTextBox.Text = DatabaseSingleton.databaseConfiguration.Password;
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serverNameTextBox.Text) || string.IsNullOrWhiteSpace(databaseNameTextBox.Text))
            {
                MessageBox.Show("Complete all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (authenticationCheckBox.Checked && (string.IsNullOrWhiteSpace(userNameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text)))
            {
                MessageBox.Show("Complete all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseSingleton.databaseConfiguration = authenticationCheckBox.Checked ?
                new DatabaseConfiguration(serverNameTextBox.Text, databaseNameTextBox.Text, userNameTextBox.Text, passwordTextBox.Text) :
                new DatabaseConfiguration(serverNameTextBox.Text, databaseNameTextBox.Text);

            Close();
        }

        private void IntegratedSecurityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            userNameTextBox.Enabled = passwordTextBox.Enabled = authenticationCheckBox.Checked;
        }
    }
}
