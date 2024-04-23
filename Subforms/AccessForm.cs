using System;
using System.Windows.Forms;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    public partial class AccessForm : Form
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
        private Access selectedAccess;

        public AccessForm()
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

            accountIDLabel.ForeColor = Palettes.GetLast();
            folderIDLabel.ForeColor = Palettes.GetLast();
        }

        private void ResetComponentToDefault()
        {
            userIsEditingRow = false;
        }

        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            accessGridView.DataSource = new BindingSource
            {
                DataSource = DaoContainer.Access.GetAll()
            };

            bool hasRows = accessGridView.Rows.Count > 0;
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
            accountIDTextBox.Text = string.Empty;
            folderIDTextBox.Text = string.Empty;
        }

        private void FillTextBoxesWithData(Access access)
        {
            accountIDTextBox.Text = access.AccountId.ToString();
            folderIDTextBox.Text = access.FolderId.ToString();
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

        private void AccessGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? selectedRow = accessGridView.Rows[e.RowIndex] : null;
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
            if (accountIDTextBox.Text == string.Empty || folderIDTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Complete all the fields.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!userIsEditingRow)
                try
                {
                    DaoContainer.Access.Add(new Access(
                        Convert.ToInt32(accountIDTextBox.Text),
                        Convert.ToInt32(folderIDTextBox.Text)
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
            else
                try
                {
                    DaoContainer.Access.Edit(new Access(
                        selectedAccess.Id,
                        Convert.ToInt32(accountIDTextBox.Text),
                        Convert.ToInt32(folderIDTextBox.Text)
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            userIsEditingRow = true;

            if (selectedRow is null) selectedRow = accessGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;
            selectedAccess = DaoContainer.Access.GetById(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxesWithData(selectedAccess);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Are you sure you want to delete this access?", @"Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (selectedRow is null) selectedRow = accessGridView.Rows[0];

                int id = (int)selectedRow.Cells[0].Value;

                try
                {
                    DaoContainer.Access.Delete(id);

                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckIntegerInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}