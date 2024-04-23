using System;
using System.Windows.Forms;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    public partial class AccountForm : Form
    {
        internal enum Panels
        {
            Navigation,
            DataManager
        }

        private int refreshBtnTimerCounter;
        private readonly int refreshBtnTimerMaxCooldown;
        private DataGridViewRow selectedRow;
        private bool userIsEditingRow;
        private Account selectedAccount;

        public AccountForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();
            GetAllDataFromDatabase();

            refreshBtnTimerMaxCooldown = 5;

            SwitchPanelTo(Panels.Navigation);
        }

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

        private void ResetComponentToDefault()
        {
            passwordCheckBox.Checked = true;
            passwordCheckBox.Visible = false;
            passwordLabel.Enabled = true;
            passwordTextBox.Enabled = true;
            userIsEditingRow = false;
        }

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

        private void SetRefreshCooldown()
        {
            refreshBtnTimer.Enabled = true;
            refreshBtnTimer.Start();
            refreshBtnTimerCounter = 0;
            refreshTableBtn.Text = $@"{refreshBtnTimerMaxCooldown - refreshBtnTimerCounter}";
            refreshTableBtn.Enabled = false;
        }

        private void ClearTextBoxes()
        {
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
        }

        private void FillTextBoxesWithData(Account account)
        {
            firstNameTextBox.Text = account.FirstName;
            lastNameTextBox.Text = account.LastName;
            emailTextBox.Text = account.Email;
        }

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

        private void AccountGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? selectedRow = accountGridView.Rows[e.RowIndex] : null;
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.DataManager);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.Navigation);
            ResetComponentToDefault();
            ClearTextBoxes();
        }

        private void RefreshTableBtn_Click(object sender, EventArgs e)
        {
            SetRefreshCooldown();
            GetAllDataFromDatabase();
        }

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