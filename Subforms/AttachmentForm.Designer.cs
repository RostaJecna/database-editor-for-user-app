namespace DatabaseEditorForUser.Subforms
{
    partial class AttachmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.searchBarPanel = new System.Windows.Forms.Panel();
            this.refreshTableBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataManagerPanel = new System.Windows.Forms.Panel();
            this.saveRowBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.dataEditorPanel = new System.Windows.Forms.Panel();
            this.sizeMBTextBox = new System.Windows.Forms.TextBox();
            this.sizeMBLabel = new System.Windows.Forms.Label();
            this.attachmentNameTextBox = new System.Windows.Forms.TextBox();
            this.attachmentNameLabel = new System.Windows.Forms.Label();
            this.typeNameLabel = new System.Windows.Forms.Label();
            this.typeNameComboBox = new System.Windows.Forms.ComboBox();
            this.folderIDTextBox = new System.Windows.Forms.TextBox();
            this.folderIDLabel = new System.Windows.Forms.Label();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.folderGridView = new System.Windows.Forms.DataGridView();
            this.refreshBtnTimer = new System.Windows.Forms.Timer(this.components);
            this.searchBarPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.dataManagerPanel.SuspendLayout();
            this.dataEditorPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBarPanel
            // 
            this.searchBarPanel.Controls.Add(this.refreshTableBtn);
            this.searchBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarPanel.Location = new System.Drawing.Point(0, 0);
            this.searchBarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.searchBarPanel.Name = "searchBarPanel";
            this.searchBarPanel.Size = new System.Drawing.Size(800, 54);
            this.searchBarPanel.TabIndex = 0;
            // 
            // refreshTableBtn
            // 
            this.refreshTableBtn.BackColor = System.Drawing.Color.DarkCyan;
            this.refreshTableBtn.FlatAppearance.BorderSize = 0;
            this.refreshTableBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshTableBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshTableBtn.ForeColor = System.Drawing.Color.White;
            this.refreshTableBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Refresh;
            this.refreshTableBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshTableBtn.Location = new System.Drawing.Point(22, 22);
            this.refreshTableBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshTableBtn.Name = "refreshTableBtn";
            this.refreshTableBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.refreshTableBtn.Size = new System.Drawing.Size(128, 32);
            this.refreshTableBtn.TabIndex = 10;
            this.refreshTableBtn.Text = "Refresh";
            this.refreshTableBtn.UseVisualStyleBackColor = false;
            this.refreshTableBtn.Click += new System.EventHandler(this.RefreshTableBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataManagerPanel);
            this.panel2.Controls.Add(this.navigationPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(650, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 396);
            this.panel2.TabIndex = 1;
            // 
            // dataManagerPanel
            // 
            this.dataManagerPanel.Controls.Add(this.saveRowBtn);
            this.dataManagerPanel.Controls.Add(this.backBtn);
            this.dataManagerPanel.Controls.Add(this.dataEditorPanel);
            this.dataManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataManagerPanel.Location = new System.Drawing.Point(0, 0);
            this.dataManagerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.dataManagerPanel.Name = "dataManagerPanel";
            this.dataManagerPanel.Size = new System.Drawing.Size(150, 396);
            this.dataManagerPanel.TabIndex = 1;
            // 
            // saveRowBtn
            // 
            this.saveRowBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.saveRowBtn.FlatAppearance.BorderSize = 0;
            this.saveRowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveRowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRowBtn.ForeColor = System.Drawing.Color.White;
            this.saveRowBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Save;
            this.saveRowBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveRowBtn.Location = new System.Drawing.Point(0, 226);
            this.saveRowBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveRowBtn.Name = "saveRowBtn";
            this.saveRowBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.saveRowBtn.Size = new System.Drawing.Size(128, 32);
            this.saveRowBtn.TabIndex = 9;
            this.saveRowBtn.Text = "Save";
            this.saveRowBtn.UseVisualStyleBackColor = false;
            this.saveRowBtn.Click += new System.EventHandler(this.SaveRowBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Brown;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Back;
            this.backBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backBtn.Location = new System.Drawing.Point(0, 22);
            this.backBtn.Margin = new System.Windows.Forms.Padding(2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.backBtn.Size = new System.Drawing.Size(128, 32);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // dataEditorPanel
            // 
            this.dataEditorPanel.Controls.Add(this.sizeMBTextBox);
            this.dataEditorPanel.Controls.Add(this.sizeMBLabel);
            this.dataEditorPanel.Controls.Add(this.attachmentNameTextBox);
            this.dataEditorPanel.Controls.Add(this.attachmentNameLabel);
            this.dataEditorPanel.Controls.Add(this.typeNameLabel);
            this.dataEditorPanel.Controls.Add(this.typeNameComboBox);
            this.dataEditorPanel.Controls.Add(this.folderIDTextBox);
            this.dataEditorPanel.Controls.Add(this.folderIDLabel);
            this.dataEditorPanel.Location = new System.Drawing.Point(0, 59);
            this.dataEditorPanel.Margin = new System.Windows.Forms.Padding(2);
            this.dataEditorPanel.Name = "dataEditorPanel";
            this.dataEditorPanel.Size = new System.Drawing.Size(128, 163);
            this.dataEditorPanel.TabIndex = 0;
            // 
            // sizeMBTextBox
            // 
            this.sizeMBTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.sizeMBTextBox.Location = new System.Drawing.Point(0, 94);
            this.sizeMBTextBox.Name = "sizeMBTextBox";
            this.sizeMBTextBox.Size = new System.Drawing.Size(128, 20);
            this.sizeMBTextBox.TabIndex = 17;
            // 
            // sizeMBLabel
            // 
            this.sizeMBLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sizeMBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeMBLabel.Location = new System.Drawing.Point(0, 76);
            this.sizeMBLabel.Name = "sizeMBLabel";
            this.sizeMBLabel.Size = new System.Drawing.Size(128, 18);
            this.sizeMBLabel.TabIndex = 16;
            this.sizeMBLabel.Text = "Size (MB):";
            this.sizeMBLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // attachmentNameTextBox
            // 
            this.attachmentNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.attachmentNameTextBox.Location = new System.Drawing.Point(0, 56);
            this.attachmentNameTextBox.Name = "attachmentNameTextBox";
            this.attachmentNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.attachmentNameTextBox.TabIndex = 15;
            // 
            // attachmentNameLabel
            // 
            this.attachmentNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.attachmentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachmentNameLabel.Location = new System.Drawing.Point(0, 38);
            this.attachmentNameLabel.Name = "attachmentNameLabel";
            this.attachmentNameLabel.Size = new System.Drawing.Size(128, 18);
            this.attachmentNameLabel.TabIndex = 14;
            this.attachmentNameLabel.Text = "Attachment name:";
            this.attachmentNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // typeNameLabel
            // 
            this.typeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeNameLabel.Location = new System.Drawing.Point(0, 117);
            this.typeNameLabel.Name = "typeNameLabel";
            this.typeNameLabel.Size = new System.Drawing.Size(128, 18);
            this.typeNameLabel.TabIndex = 13;
            this.typeNameLabel.Text = "Type name:";
            this.typeNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // typeNameComboBox
            // 
            this.typeNameComboBox.FormattingEnabled = true;
            this.typeNameComboBox.Location = new System.Drawing.Point(0, 138);
            this.typeNameComboBox.Name = "typeNameComboBox";
            this.typeNameComboBox.Size = new System.Drawing.Size(128, 21);
            this.typeNameComboBox.TabIndex = 12;
            // 
            // folderIDTextBox
            // 
            this.folderIDTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.folderIDTextBox.Location = new System.Drawing.Point(0, 18);
            this.folderIDTextBox.Name = "folderIDTextBox";
            this.folderIDTextBox.Size = new System.Drawing.Size(128, 20);
            this.folderIDTextBox.TabIndex = 9;
            this.folderIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckIntegerInput);
            // 
            // folderIDLabel
            // 
            this.folderIDLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.folderIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderIDLabel.Location = new System.Drawing.Point(0, 0);
            this.folderIDLabel.Name = "folderIDLabel";
            this.folderIDLabel.Size = new System.Drawing.Size(128, 18);
            this.folderIDLabel.TabIndex = 8;
            this.folderIDLabel.Text = "Folder ID:";
            this.folderIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.deleteBtn);
            this.navigationPanel.Controls.Add(this.editBtn);
            this.navigationPanel.Controls.Add(this.addRowBtn);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(2);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(150, 396);
            this.navigationPanel.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Brown;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.deleteBtn.Location = new System.Drawing.Point(0, 94);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(128, 32);
            this.deleteBtn.TabIndex = 11;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.DarkGray;
            this.editBtn.FlatAppearance.BorderSize = 0;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.editBtn.Location = new System.Drawing.Point(0, 58);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(128, 32);
            this.editBtn.TabIndex = 10;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // addRowBtn
            // 
            this.addRowBtn.BackColor = System.Drawing.Color.DarkGray;
            this.addRowBtn.FlatAppearance.BorderSize = 0;
            this.addRowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRowBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.addRowBtn.Location = new System.Drawing.Point(0, 22);
            this.addRowBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(128, 32);
            this.addRowBtn.TabIndex = 9;
            this.addRowBtn.Text = "Add";
            this.addRowBtn.UseVisualStyleBackColor = false;
            this.addRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.folderGridView);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 54);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(650, 396);
            this.gridPanel.TabIndex = 2;
            // 
            // folderGridView
            // 
            this.folderGridView.AllowUserToAddRows = false;
            this.folderGridView.AllowUserToDeleteRows = false;
            this.folderGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.folderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.folderGridView.Location = new System.Drawing.Point(22, 22);
            this.folderGridView.Margin = new System.Windows.Forms.Padding(2);
            this.folderGridView.MultiSelect = false;
            this.folderGridView.Name = "folderGridView";
            this.folderGridView.ReadOnly = true;
            this.folderGridView.RowHeadersWidth = 51;
            this.folderGridView.RowTemplate.Height = 24;
            this.folderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.folderGridView.Size = new System.Drawing.Size(606, 353);
            this.folderGridView.TabIndex = 1;
            this.folderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FolderColorGridView_CellClick);
            // 
            // refreshBtnTimer
            // 
            this.refreshBtnTimer.Interval = 1000;
            this.refreshBtnTimer.Tick += new System.EventHandler(this.RefreshBtnTimer_Tick);
            // 
            // AttachmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.searchBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AttachmentForm";
            this.Text = "ColorForm";
            this.searchBarPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.dataManagerPanel.ResumeLayout(false);
            this.dataEditorPanel.ResumeLayout(false);
            this.dataEditorPanel.PerformLayout();
            this.navigationPanel.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.folderGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel searchBarPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView folderGridView;
        private System.Windows.Forms.Button refreshTableBtn;
        private System.Windows.Forms.Panel dataManagerPanel;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.Panel dataEditorPanel;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button saveRowBtn;
        private System.Windows.Forms.TextBox folderIDTextBox;
        private System.Windows.Forms.Label folderIDLabel;
        private System.Windows.Forms.Timer refreshBtnTimer;
        private System.Windows.Forms.Label typeNameLabel;
        private System.Windows.Forms.ComboBox typeNameComboBox;
        private System.Windows.Forms.TextBox sizeMBTextBox;
        private System.Windows.Forms.Label sizeMBLabel;
        private System.Windows.Forms.TextBox attachmentNameTextBox;
        private System.Windows.Forms.Label attachmentNameLabel;
    }
}