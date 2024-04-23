using System;
using System.Windows.Forms;
using DatabaseEditorForUser.DAOs;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    public partial class FolderForm : Form
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
        private Folder selectedFolder;

        public FolderForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();
            GetAllDataFromDatabase();

            refreshBtnTimerMaxCooldown = 5;

            SwitchPanelTo(Panels.Navigation);
            FillComboBox(DaoContainer.FolderColor);
        }

        private void ChangeDefaultComponent()
        {
            addRowBtn.BackColor = Palettes.GetLast();
            editBtn.BackColor = Palettes.GetLastDarkness(15);

            folderNameLabel.ForeColor = Palettes.GetLast();
            colorNameLabel.ForeColor = Palettes.GetLast();
            isSharedCheckBox.ForeColor = Palettes.GetLastDarkness(15);
        }

        private void FillComboBox(FolderColorDao folderColorDao)
        {
            foreach (FolderColor folderColor in folderColorDao.GetAll()) colorNameComboBox.Items.Add(folderColor.Name);
        }

        private void ResetComponentToDefault()
        {
            userIsEditingRow = false;
            isSharedCheckBox.Checked = false;
        }

        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            folderGridView.DataSource = new BindingSource
            {
                DataSource = DaoContainer.Folder.GetAll()
            };

            bool hasRows = folderGridView.Rows.Count > 0;
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

        private void ClearTextBox()
        {
            folderNameTextBox.Text = string.Empty;
        }

        private void FillTextBoxWithData(Folder folder)
        {
            folderNameTextBox.Text = folder.Name;
            colorNameComboBox.SelectedItem = DaoContainer.FolderColor.GetById(folder.ColorId).Name;
            isSharedCheckBox.Checked = folder.IsShared;
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

        private void FolderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex >= 0 ? selectedRow = folderGridView.Rows[e.RowIndex] : null;
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.DataManager);
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
            if (folderNameTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Entry folder name.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (colorNameComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Color name doesn't exist in database.", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!userIsEditingRow)
                try
                {
                    DaoContainer.Folder.Add(new Folder(
                        folderNameTextBox.Text,
                        FolderColorDao.GetIdByName((string)colorNameComboBox.SelectedItem),
                        isSharedCheckBox.Checked
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
                    DaoContainer.Folder.Edit(new Folder(
                        selectedFolder.Id,
                        folderNameTextBox.Text,
                        FolderColorDao.GetIdByName((string)colorNameComboBox.SelectedItem),
                        isSharedCheckBox.Checked,
                        selectedFolder.CreatedAt
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            userIsEditingRow = true;

            if (selectedRow is null) selectedRow = folderGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;
            selectedFolder = DaoContainer.Folder.GetById(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxWithData(selectedFolder);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Are you sure you want to delete this folder?", @"Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (selectedRow is null) selectedRow = folderGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;

            try
            {
                DaoContainer.Folder.Delete(id);

                GetAllDataFromDatabase();
                SetRefreshCooldown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}