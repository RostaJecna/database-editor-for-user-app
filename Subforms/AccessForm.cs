using System;
using System.Windows.Forms;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    /// <summary>
    ///     Represents a form for managing access to folders.
    /// </summary>
    public partial class AccessForm : Form
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
        private Access selectedAccess;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccessForm" /> class.
        /// </summary>
        public AccessForm()
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

            accountIDLabel.ForeColor = Palettes.GetLast();
            folderIDLabel.ForeColor = Palettes.GetLast();
        }

        /// <summary>
        ///     Resets the component to its default state.
        /// </summary>
        private void ResetComponentToDefault()
        {
            userIsEditingRow = false;
        }

        /// <summary>
        ///     Retrieves all data from the database and populates the DataGridView.
        /// </summary>
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
            accountIDTextBox.Text = string.Empty;
            folderIDTextBox.Text = string.Empty;
        }

        /// <summary>
        ///     Fills the text boxes with data from the specified Access object.
        /// </summary>
        /// <param name="access">The Access object containing the data.</param>
        private void FillTextBoxesWithData(Access access)
        {
            accountIDTextBox.Text = access.AccountId.ToString();
            folderIDTextBox.Text = access.FolderId.ToString();
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(panel), panel, null);
            }
        }

        /// <summary>
        ///     Handles the CellClick event of the accessGridView control.
        /// </summary>
        private void AccessGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? selectedRow = accessGridView.Rows[e.RowIndex] : null;
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
        ///     Validates input and saves or edits the access row in the database.
        /// </summary>
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

        /// <summary>
        ///     Handles the click event of the "Edit" button.
        ///     Sets the userIsEditingRow flag, retrieves the selected access, and switches the panel to the data manager panel.
        /// </summary>
        private void EditBtn_Click(object sender, EventArgs e)
        {
            userIsEditingRow = true;

            if (selectedRow is null) selectedRow = accessGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;
            selectedAccess = DaoContainer.Access.GetById(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxesWithData(selectedAccess);
        }

        /// <summary>
        ///     Handles the click event of the "Delete" button.
        ///     Prompts the user for confirmation before deleting the selected access row from the database.
        /// </summary>
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

        /// <summary>
        ///     Handles the key press event to allow only integer input in certain text boxes.
        /// </summary>
        private void CheckIntegerInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}