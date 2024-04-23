using System;
using System.Windows.Forms;
using DatabaseEditorForUser.Entities;
using DatabaseEditorForUser.Graphics;

namespace DatabaseEditorForUser.Subforms
{
    public partial class ColorForm : Form
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
        private FolderColor selectedFolderColor;

        public ColorForm()
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

            colorNameLabel.ForeColor = Palettes.GetLast();
        }

        private void ResetComponentToDefault()
        {
            userIsEditingRow = false;
        }

        private void GetAllDataFromDatabase()
        {
            selectedRow = null;
            folderColorGridView.DataSource = new BindingSource
            {
                DataSource = DaoContainer.FolderColor.GetAll()
            };

            bool hasRows = folderColorGridView.Rows.Count > 0;
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
            colorNameTextBox.Text = string.Empty;
        }

        private void FillTextBoxWithData(FolderColor folderColor)
        {
            colorNameTextBox.Text = folderColor.Name;
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
            selectedRow = e.RowIndex >= 0 ? selectedRow = folderColorGridView.Rows[e.RowIndex] : null;
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
            if (colorNameTextBox.Text == string.Empty)
            {
                MessageBox.Show(@"Entry color name.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!userIsEditingRow)
                try
                {
                    DaoContainer.FolderColor.Add(new FolderColor(
                        colorNameTextBox.Text
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
                    DaoContainer.FolderColor.Edit(new FolderColor(
                        selectedFolderColor.Id,
                        colorNameTextBox.Text
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

            if (selectedRow is null) selectedRow = folderColorGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;
            selectedFolderColor = DaoContainer.FolderColor.GetById(id);

            SwitchPanelTo(Panels.DataManager);
            FillTextBoxWithData(selectedFolderColor);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Are you sure you want to delete this color?", @"Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (selectedRow is null) selectedRow = folderColorGridView.Rows[0];

            int id = (int)selectedRow.Cells[0].Value;

            try
            {
                DaoContainer.FolderColor.Delete(id);

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