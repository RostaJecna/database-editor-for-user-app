using System;
using System.Windows.Forms;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    /// <summary>
    ///     Represents the AccountForm class, which is a subform for managing accounts in the application.
    /// </summary>
    public partial class AccountForm : Form
    {
        /// <summary>
        ///     Enum representing the panels in the form.
        /// </summary>
        internal enum Panels
        {
            /// <summary>
            ///     Navigation panel.
            /// </summary>
            Navigation,

            /// <summary>
            ///     Data manager panel.
            /// </summary>
            DataManager
        }

        // Fields
        private int refreshBtnTimerCounter;
        private readonly int refreshBtnTimerMaxCooldown;
        private DataGridViewRow selectedRow;
        private bool userIsEditingRow;
        private Account selectedAccount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountForm" /> class.
        /// </summary>
        public AccountForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();
            GetAllDataFromDatabase();

            refreshBtnTimerMaxCooldown = 5;

            SwitchPanelTo(Panels.Navigation);
        }

        /// <summary>
        ///     Changes the default component settings.
        /// </summary>
        private void ChangeDefaultComponent()
        {
            addRowBtn.BackColor = Palettes.GetLast();
            editBtn.BackColor = Palettes.GetLastDarkness(15);

            firstNameLabel.ForeColor = Palettes.GetLast();
            lastNameLabel.ForeColor = Palettes.GetLast();
            emailLabel.ForeColor = Palettes.GetLast();
            passwordLabel.ForeColor = Palettes.GetLast();

            passwordCheckBox.ForeColor = Palettes.GetLastDarkness(15);
        }

        /// <summary>
        ///     Resets the component to its default state.
        /// </summary>
        private void ResetComponentToDefault()
        {
            passwordCheckBox.Checked = true;
            passwordCheckBox.Visible = false;
            passwordLabel.Enabled = true;
            passwordTextBox.Enabled = true;
            userIsEditingRow = false;
        }

        /// <summary>
        ///     Retrieves all data from the database and populates the DataGridView.
        /// </summary>
        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            accountGridView.DataSource = new BindingSource
            {
                DataSource = DaoContainer.Account.GetAll()
            };

            bool hasRows = accountGridView.Rows.Count > 0;
            deleteBtn.Visible = hasRows;
            editBtn.Visible = hasRows;
        }

        /// <summary>
        ///     Sets the refresh cooldown for the refresh button.
        /// </summary>
        private void SetRefreshCooldown()
        {
            refreshBtnTimer.Enabled = true;
            refreshBtnTimer.Start();
            refreshBtnTimerCounter = 0;
            refreshTableBtn.Text = $@"{refreshBtnTimerMaxCooldown - refreshBtnTimerCounter}";
            refreshTableBtn.Enabled = false;
        }

        /// <summary>
        ///     Clears the text boxes.
        /// </summary>
        private void ClearTextBoxes()
        {
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
        }


        /// <summary>
        ///     Fills the text boxes with data from the specified Access object.
        /// </summary>
        private void FillTextBoxesWithData(Account account)
        {
            firstNameTextBox.Text = account.FirstName;
            lastNameTextBox.Text = account.LastName;
            emailTextBox.Text = account.Email;
        }

        /// <summary>
        ///     Switches the panel to the specified one.
        /// </summary>
        /// <param name="panel">The panel to switch to.</param>
        private void SwitchPanelTo(Panels panel)
        {
            switch (panel)
            {
                case Panels.Navigation:
                    navigationPanel.Visible = true;
                    dataManagerPanel.Visible = false;
                    searchBarPanel.Visible = true;
                    break;
                case Panels.DataManager:
                    navigationPanel.Visible = false;
                    dataManagerPanel.Visible = true;
                    searchBarPanel.Visible = false;
                    break;
            }
        }

        /// <summary>
        ///     Handles the CellClick event of the accessGridView control.
        /// </summary>
        private void AccountGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? selectedRow = accountGridView.Rows[e.RowIndex] : null;
        }

        /// <summary>
        ///     Handles the click event of the "Add Row" button.
        ///     Switches the panel to the data manager panel.
        /// </summary>
        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.DataManager);
        }

        /// <summary>
        ///     Handles the click event of the "Back" button.
        ///     Switches the panel to the navigation panel, resets component state, and clears text boxes.
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.Navigation);
            ResetComponentToDefault();
            ClearTextBoxes();
        }

        /// <summary>
        ///     Handles the click event of the "Refresh Table" button.
        ///     Sets a refresh cooldown and retrieves all data from the database to refresh the DataGridView.
        /// </summary>
        private void RefreshTableBtn_Click(object sender, EventArgs e)
        {
            SetRefreshCooldown();
            GetAllDataFromDatabase();
        }

        /// <summary>
        ///     Handles the tick event of the refresh button timer.
        ///     Updates the refresh button text and stops the timer when the cooldown is reached.
        /// </summary>
        private void RefreshBtnTimer_Tick(object sender, EventArgs e)
        {
            if (refreshBtnTimerCounter == refreshBtnTimerMaxCooldown)
            {
                refreshBtnTimer.Enabled = false;
                refreshBtnTimer.Stop();
                refreshBtnTimerCounter = 0;
                refreshTableBtn.Enabled = true;
                refreshTableBtn.Text = @"Refresh";
            }
            else
            {
                refreshBtnTimerCounter++;
                refreshTableBtn.Text = $@"{refreshBtnTimerMaxCooldown - refreshBtnTimerCounter}";
            }
        }

        /// <summary>
        ///     Handles the click event of the "Save Row" button.
        ///     Validates input and saves or edits the account row in the database.
        /// </summary>
        private void SaveRowBtn_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text == string.Empty || lastNameTextBox.Text == string.Empty ||
                emailTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Complete all the fields.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!userIsEditingRow)
            {
                if (passwordTextBox.Text == string.Empty)
                {
                    MessageBox.Show(@"Enter a password.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    DaoContainer.Account.Add(new Account(
                        firstNameTextBox.Text,
                        lastNameTextBox.Text,
                        emailTextBox.Text,
                        passwordTextBox.Text
                    ));

                    SwitchPanelTo(Panels.Navigation);
                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    string hashedPassword = passwordCheckBox.Checked
                        ? selectedAccount.HashedPassword
                        : Account.GetHashedPassword(passwordTextBox.Text);
                    DaoContainer.Account.Edit(new Account(
                        selectedAccount.Id,
                        firstNameTextBox.Text,
                        lastNameTextBox.Text,
                        emailTextBox.Text,
                        hashedPassword,
                        selectedAccount.Registered
                    ));

                    SwitchPanelTo(Panels.Navigation);
                    ResetComponentToDefault();
                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Event handler for the "Edit" button click.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void EditBtn_Click(object sender, EventArgs e)
        {
            userIsEditingRow = true;

            if (selectedRow is null) selectedRow = accountGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;
            selectedAccount = DaoContainer.Account.GetById(id);

            passwordCheckBox.Visible = true;
            passwordTextBox.Enabled = false;
            passwordLabel.Enabled = false;

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxesWithData(selectedAccount);
        }

        /// <summary>
        ///     Event handler for the "Delete" button click.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Are you sure you want to delete this account?", @"Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (selectedRow is null) selectedRow = accountGridView.Rows[0];

                int id = (int)selectedRow.Cells[0].Value;

                try
                {
                    DaoContainer.Account.Delete(id);

                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.Enabled = !passwordCheckBox.Checked;
            passwordLabel.Enabled = !passwordCheckBox.Checked;
        }
    }
}