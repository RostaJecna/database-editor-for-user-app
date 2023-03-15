using DatabaseEditorForUser.DAOs;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser.Subforms
{
    public partial class AttachmentForm : Form
    {
        internal enum Panels
        {
            Navigation,
            DataManager
        }

        private int refreshBtnTimerCounter;
        private readonly int refreshBtnTimerMaxCooldown;
        private DataGridViewRow selectedRow;
        private bool UserIsEditingRow;
        private Attachment selectedAttachment;

        public AttachmentForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();
            GetAllDataFromDatabase();

            refreshBtnTimerMaxCooldown = 5;

            SwitchPanelTo(Panels.Navigation);
            FillComboBox(DAOContainer.attachmentType);
        }

        private void ChangeDefaultComponent()
        {
            addRowBtn.BackColor = Palettes.GetLast();
            editBtn.BackColor = Palettes.GetLastDarkness(15);

            folderIDLabel.ForeColor = Palettes.GetLast();
            attachmentNameLabel.ForeColor = Palettes.GetLast();
            typeNameLabel.ForeColor = Palettes.GetLast();
            sizeMBLabel.ForeColor = Palettes.GetLast();
        }

        private void FillComboBox(AttachmentTypeDAO attachmentTypeDAO)
        {
            foreach (AttachmentType attachmentType in attachmentTypeDAO.GetAll())
            {
                typeNameComboBox.Items.Add(attachmentType.TypeName);
            }
        }

        private void ResetComponentToDefault()
        {
            UserIsEditingRow = false;
        }

        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            attachmentGridView.DataSource = new BindingSource()
            {
                DataSource = DAOContainer.attachment.GetAll()
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
            refreshTableBtn.Text = $"{refreshBtnTimerMaxCooldown - refreshBtnTimerCounter}";
            refreshTableBtn.Enabled = false;
        }

        private void ClearTextBox()
        {
            folderIDTextBox.Text = string.Empty;
            attachmentNameTextBox.Text = string.Empty;
            sizeMBTextBox.Text = string.Empty;
        }

        private void FillTextBoxWithData(Attachment attachment)
        {
            folderIDTextBox.Text = attachment.FolderID.ToString();
            attachmentNameTextBox.Text = attachment.AttachmentName;
            sizeMBTextBox.Text = attachment.SizeMB.ToString();
            typeNameComboBox.SelectedItem = DAOContainer.attachmentType.GetByID(attachment.TypeID).TypeName;
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

        private void AttachmentColorGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? attachmentGridView.Rows[e.RowIndex] : null;
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.DataManager);
            typeNameComboBox.SelectedIndex = 0;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.Navigation);
            ResetComponentToDefault();
            ClearTextBox();
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
                refreshTableBtn.Text = "Refresh";
            }
            else
            {
                refreshBtnTimerCounter++;
                refreshTableBtn.Text = $"{refreshBtnTimerMaxCooldown - refreshBtnTimerCounter}";
            }
        }

        private void SaveRowBtn_Click(object sender, EventArgs e)
        {
            if (folderIDTextBox.Text == string.Empty || attachmentNameTextBox.Text == string.Empty
                    || sizeMBTextBox.Text == string.Empty)
            {
                MessageBox.Show("Complete all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (typeNameComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Type name doesn't exist in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UserIsEditingRow)
            {
                try
                {
                    DAOContainer.attachment.Add(new Attachment(
                        Convert.ToInt32(folderIDTextBox.Text),
                        AttachmentTypeDAO.GetIDByName((string)typeNameComboBox.SelectedItem),
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    DAOContainer.attachment.Edit(new Attachment(
                        selectedAttachment.ID,
                        Convert.ToInt32(folderIDTextBox.Text),
                        AttachmentTypeDAO.GetIDByName((string)typeNameComboBox.SelectedItem),
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            UserIsEditingRow = true;

            if (selectedRow is null)
            {
                selectedRow = attachmentGridView.Rows[0];
            }

            int id = (int)selectedRow.Cells[0].Value;
            this.selectedAttachment = DAOContainer.attachment.GetByID(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxWithData(selectedAttachment);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this attachment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (selectedRow is null)
                {
                    selectedRow = attachmentGridView.Rows[0];
                }

                int id = (int)selectedRow.Cells[0].Value;

                try
                {
                    DAOContainer.attachment.Delete(id);

                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckIntegerInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
