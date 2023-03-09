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
    public partial class FolderForm : Form
    {
        internal enum Panels
        {
            Navigation,
            DataManager,
        }

        private int refreshBtnTimerCounter;
        private readonly int refreshBtnTimerMaxCooldown;
        private readonly FolderDAO folderDao;
        private readonly FolderColorDAO folderColorDAO;
        private DataGridViewRow selectedRow;
        private bool UserIsEditingRow;
        private Folder selectedFolder;

        public FolderForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();

            folderDao = new FolderDAO();
            GetAllDataFromDatabase();

            refreshBtnTimerMaxCooldown = 5;

            SwitchPanelTo(Panels.Navigation);
            folderColorDAO = new FolderColorDAO();
            FillComboBox(folderColorDAO);
        }

        private void ChangeDefaultComponent()
        {
            addRowBtn.BackColor = Palettes.GetLast();
            editBtn.BackColor = Palettes.GetLastDarkness(15);

            folderNameLabel.ForeColor = Palettes.GetLast();
            colorNameLabel.ForeColor = Palettes.GetLast();
            isSharedCheckBox.ForeColor = Palettes.GetLastDarkness(15);
        }

        private void FillComboBox(FolderColorDAO folderColorDAO)
        {
            foreach (FolderColor folderColor in folderColorDAO.GetAll())
            {
                colorNameComboBox.Items.Add(folderColor.Name);
            }
        }

        private void ResetComponentToDefault()
        {
            UserIsEditingRow = false;
            isSharedCheckBox.Checked = false;
        }

        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            folderGridView.DataSource = new BindingSource()
            {
                DataSource = folderDao.GetAll()
            };
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
            folderNameTextBox.Text = string.Empty;
        }

        private void FillTextBoxWithData(Folder folder)
        {
            folderNameTextBox.Text = folder.Name;
            colorNameComboBox.SelectedItem = folderColorDAO.GetByID(folder.ColorID).Name;
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

        private void FolderColorGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = folderGridView.Rows[e.RowIndex];
            }
        }

        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.DataManager);
            colorNameComboBox.SelectedIndex = 0;
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
            if (folderNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Entry folder name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(colorNameComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Color name doesn't exist in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UserIsEditingRow)
            {
                try
                {
                    folderDao.Add(new Folder(
                        folderNameTextBox.Text,
                        FolderColorDAO.GetIDByName((string)colorNameComboBox.SelectedItem),
                        isSharedCheckBox.Checked
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
                    folderDao.Edit(new Folder(
                        selectedFolder.ID,
                        folderNameTextBox.Text,
                        FolderColorDAO.GetIDByName((string)colorNameComboBox.SelectedItem),
                        isSharedCheckBox.Checked,
                        selectedFolder.CreateAt
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
                selectedRow = folderGridView.Rows[0];
            }

            int id = (int)selectedRow.Cells[0].Value;
            this.selectedFolder = folderDao.GetByID(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxWithData(selectedFolder);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this color?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (selectedRow is null)
                {
                    selectedRow = folderGridView.Rows[0];
                }

                int id = (int)selectedRow.Cells[0].Value;

                try
                {
                    folderDao.Delete(id);

                    GetAllDataFromDatabase();
                    SetRefreshCooldown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
