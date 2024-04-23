using System;
using System.Globalization;
using System.Windows.Forms;
using DatabaseEditorForUser.DAOs;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    /// <summary>
    ///     Represents a form for managing attachments.
    /// </summary>
    public partial class AttachmentForm : Form
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
        private Attachment selectedAttachment;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AttachmentForm" /> class.
        /// </summary>
        public AttachmentForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();
            GetAllDataFromDatabase();

            refreshBtnTimerMaxCooldown = 5;

            SwitchPanelTo(Panels.Navigation);
            FillComboBox(DaoContainer.AttachmentType);
        }

        /// <summary>
        ///     Changes the default component settings.
        /// </summary>
        private void ChangeDefaultComponent()
        {
            addRowBtn.BackColor = Palettes.GetLast();
            editBtn.BackColor = Palettes.GetLastDarkness(15);

            folderIDLabel.ForeColor = Palettes.GetLast();
            attachmentNameLabel.ForeColor = Palettes.GetLast();
            typeNameLabel.ForeColor = Palettes.GetLast();
            sizeMBLabel.ForeColor = Palettes.GetLast();
        }

        /// <summary>
        ///     Fills the combo box with attachment type data from the specified attachment type DAO.
        /// </summary>
        /// <param name="attachmentTypeDao">The attachment type data access object.</param>
        private void FillComboBox(AttachmentTypeDao attachmentTypeDao)
        {
            foreach (AttachmentType attachmentType in attachmentTypeDao.GetAll())
                typeNameComboBox.Items.Add(attachmentType.TypeName);
        }

        /// <summary>
        ///     Resets the form components to their default state.
        /// </summary>
        private void ResetComponentToDefault()
        {
            userIsEditingRow = false;
        }

        /// <summary>
        ///     Retrieves all data from the database and populates the attachment grid view.
        /// </summary>
        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            attachmentGridView.DataSource = new BindingSource
            {
                DataSource = DaoContainer.Attachment.GetAll()
            };

            bool hasRows = attachmentGridView.Rows.Count > 0;
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

        /// <summary>
        ///     Clears the text boxes in the form.
        /// </summary>
        private void ClearTextBox()
        {
            folderIDTextBox.Text = string.Empty;
            attachmentNameTextBox.Text = string.Empty;
            sizeMBTextBox.Text = string.Empty;
        }

        /// <summary>
        ///     Fills the text boxes and combo box with data from the specified attachment.
        /// </summary>
        /// <param name="attachment">The attachment object containing data to fill the text boxes and combo box.</param>
        private void FillTextBoxWithData(Attachment attachment)
        {
            folderIDTextBox.Text = attachment.FolderId.ToString();
            attachmentNameTextBox.Text = attachment.AttachmentName;
            sizeMBTextBox.Text = attachment.SizeMb.ToString(CultureInfo.InvariantCulture);
            typeNameComboBox.SelectedItem = DaoContainer.AttachmentType.GetById(attachment.TypeId).TypeName;
        }

        /// <summary>
        ///     Switches the form panel to the specified panel.
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
        ///     Handles the cell click event in the attachment grid view.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AttachmentColorGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? attachmentGridView.Rows[e.RowIndex] : null;
        }

        /// <summary>
        ///     Handles the click event for adding a new row.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.DataManager);
        }

        /// <summary>
        ///     Handles the click event for going back to the navigation panel.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.Navigation);
            ResetComponentToDefault();
            ClearTextBox();
        }

        /// <summary>
        ///     Handles the click event for refreshing the table.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void RefreshTableBtn_Click(object sender, EventArgs e)
        {
            SetRefreshCooldown();
            GetAllDataFromDatabase();
        }

        /// <summary>
        ///     Handles the tick event for the refresh button timer.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
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
        ///     Handles the click event for saving a row.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveRowBtn_Click(object sender, EventArgs e)
        {
            if (folderIDTextBox.Text == string.Empty || attachmentNameTextBox.Text == string.Empty
                                                     || sizeMBTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Complete all the fields.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (typeNameComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Type name doesn't exist in database.", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!userIsEditingRow)
                try
                {
                    DaoContainer.Attachment.Add(new Attachment(
                        Convert.ToInt32(folderIDTextBox.Text),
                        AttachmentTypeDao.GetIdByName((string)typeNameComboBox.SelectedItem),
                        attachmentNameTextBox.Text,
                        float.Parse(sizeMBTextBox.Text)
                    ));

                    SwitchPanelTo(Panels.Navigation);
                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                    ClearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                try
                {
                    DaoContainer.Attachment.Edit(new Attachment(
                        selectedAttachment.Id,
                        Convert.ToInt32(folderIDTextBox.Text),
                        AttachmentTypeDao.GetIdByName((string)typeNameComboBox.SelectedItem),
                        attachmentNameTextBox.Text,
                        float.Parse(sizeMBTextBox.Text),
                        selectedAttachment.CreatedAt
                    ));

                    SwitchPanelTo(Panels.Navigation);
                    ResetComponentToDefault();
                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                    ClearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        ///     Handles the click event for editing a row.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void EditBtn_Click(object sender, EventArgs e)
        {
            userIsEditingRow = true;

            if (selectedRow is null) selectedRow = attachmentGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;
            selectedAttachment = DaoContainer.Attachment.GetById(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxWithData(selectedAttachment);
        }

        /// <summary>
        ///     Handles the click event for deleting a row.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Are you sure you want to delete this attachment?", @"Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (selectedRow is null) selectedRow = attachmentGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;

            try
            {
                DaoContainer.Attachment.Delete(id);

                GetAllDataFromDatabase();
                SetRefreshCooldown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Handles the key press event for checking integer input in text boxes.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckIntegerInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}