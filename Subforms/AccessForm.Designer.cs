namespace DatabaseEditorForUser.Subforms
{
    partial class AccessForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.accessGridView = new System.Windows.Forms.DataGridView();
            this.rightSidePanel = new System.Windows.Forms.Panel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.dataManagerPanel = new System.Windows.Forms.Panel();
            this.dataEditorPanel = new System.Windows.Forms.Panel();
            this.folderIDTextBox = new System.Windows.Forms.TextBox();
            this.folderIDLabel = new System.Windows.Forms.Label();
            this.accountIDTextBox = new System.Windows.Forms.TextBox();
            this.accountIDLabel = new System.Windows.Forms.Label();
            this.saveRowBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.searchBarPanel = new System.Windows.Forms.Panel();
            this.refreshTableBtn = new System.Windows.Forms.Button();
            this.refreshBtnTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accessGridView)).BeginInit();
            this.rightSidePanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.dataManagerPanel.SuspendLayout();
            this.dataEditorPanel.SuspendLayout();
            this.searchBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.gridPanel);
            this.mainPanel.Controls.Add(this.rightSidePanel);
            this.mainPanel.Controls.Add(this.searchBarPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.accessGridView);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 54);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(650, 396);
            this.gridPanel.TabIndex = 2;
            // 
            // accessGridView
            // 
            this.accessGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.accessGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.accessGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accessGridView.Location = new System.Drawing.Point(22, 22);
            this.accessGridView.Margin = new System.Windows.Forms.Padding(2);
            this.accessGridView.MultiSelect = false;
            this.accessGridView.Name = "accessGridView";
            this.accessGridView.ReadOnly = true;
            this.accessGridView.RowHeadersWidth = 51;
            this.accessGridView.RowTemplate.Height = 24;
            this.accessGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accessGridView.Size = new System.Drawing.Size(606, 353);
            this.accessGridView.TabIndex = 0;
            this.accessGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccessGridView_CellClick);
            // 
            // rightSidePanel
            // 
            this.rightSidePanel.Controls.Add(this.navigationPanel);
            this.rightSidePanel.Controls.Add(this.dataManagerPanel);
            this.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSidePanel.Location = new System.Drawing.Point(650, 54);
            this.rightSidePanel.Margin = new System.Windows.Forms.Padding(2);
            this.rightSidePanel.Name = "rightSidePanel";
            this.rightSidePanel.Size = new System.Drawing.Size(150, 396);
            this.rightSidePanel.TabIndex = 1;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.deleteBtn);
            this.navigationPanel.Controls.Add(this.editBtn);
            this.navigationPanel.Controls.Add(this.addRowBtn);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(150, 396);
            this.navigationPanel.TabIndex = 9;
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
            this.deleteBtn.TabIndex = 8;
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
            this.editBtn.TabIndex = 7;
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
            this.addRowBtn.TabIndex = 6;
            this.addRowBtn.Text = "Add";
            this.addRowBtn.UseVisualStyleBackColor = false;
            this.addRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // dataManagerPanel
            // 
            this.dataManagerPanel.Controls.Add(this.dataEditorPanel);
            this.dataManagerPanel.Controls.Add(this.saveRowBtn);
            this.dataManagerPanel.Controls.Add(this.backBtn);
            this.dataManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataManagerPanel.Location = new System.Drawing.Point(0, 0);
            this.dataManagerPanel.Name = "dataManagerPanel";
            this.dataManagerPanel.Size = new System.Drawing.Size(150, 396);
            this.dataManagerPanel.TabIndex = 10;
            // 
            // dataEditorPanel
            // 
            this.dataEditorPanel.Controls.Add(this.folderIDTextBox);
            this.dataEditorPanel.Controls.Add(this.folderIDLabel);
            this.dataEditorPanel.Controls.Add(this.accountIDTextBox);
            this.dataEditorPanel.Controls.Add(this.accountIDLabel);
            this.dataEditorPanel.Location = new System.Drawing.Point(0, 59);
            this.dataEditorPanel.Name = "dataEditorPanel";
            this.dataEditorPanel.Size = new System.Drawing.Size(128, 85);
            this.dataEditorPanel.TabIndex = 9;
            // 
            // folderIDTextBox
            // 
            this.folderIDTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.folderIDTextBox.Location = new System.Drawing.Point(0, 56);
            this.folderIDTextBox.Name = "folderIDTextBox";
            this.folderIDTextBox.Size = new System.Drawing.Size(128, 20);
            this.folderIDTextBox.TabIndex = 3;
            this.folderIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckIntegerInput);
            // 
            // folderIDLabel
            // 
            this.folderIDLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.folderIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderIDLabel.Location = new System.Drawing.Point(0, 38);
            this.folderIDLabel.Name = "folderIDLabel";
            this.folderIDLabel.Size = new System.Drawing.Size(128, 18);
            this.folderIDLabel.TabIndex = 2;
            this.folderIDLabel.Text = "Folder ID:";
            this.folderIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // accountIDTextBox
            // 
            this.accountIDTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountIDTextBox.Location = new System.Drawing.Point(0, 18);
            this.accountIDTextBox.Name = "accountIDTextBox";
            this.accountIDTextBox.Size = new System.Drawing.Size(128, 20);
            this.accountIDTextBox.TabIndex = 1;
            this.accountIDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckIntegerInput);
            // 
            // accountIDLabel
            // 
            this.accountIDLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountIDLabel.Location = new System.Drawing.Point(0, 0);
            this.accountIDLabel.Name = "accountIDLabel";
            this.accountIDLabel.Size = new System.Drawing.Size(128, 18);
            this.accountIDLabel.TabIndex = 0;
            this.accountIDLabel.Text = "Account ID:";
            this.accountIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.saveRowBtn.Location = new System.Drawing.Point(0, 149);
            this.saveRowBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveRowBtn.Name = "saveRowBtn";
            this.saveRowBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.saveRowBtn.Size = new System.Drawing.Size(128, 32);
            this.saveRowBtn.TabIndex = 8;
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
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
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
            this.refreshTableBtn.TabIndex = 9;
            this.refreshTableBtn.Text = "Refresh";
            this.refreshTableBtn.UseVisualStyleBackColor = false;
            this.refreshTableBtn.Click += new System.EventHandler(this.RefreshTableBtn_Click);
            // 
            // refreshBtnTimer
            // 
            this.refreshBtnTimer.Interval = 1000;
            this.refreshBtnTimer.Tick += new System.EventHandler(this.RefreshBtnTimer_Tick);
            // 
            // AccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccessForm";
            this.Text = "AccountForm";
            this.mainPanel.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accessGridView)).EndInit();
            this.rightSidePanel.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.dataManagerPanel.ResumeLayout(false);
            this.dataEditorPanel.ResumeLayout(false);
            this.dataEditorPanel.PerformLayout();
            this.searchBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel rightSidePanel;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.Panel searchBarPanel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView accessGridView;
        private System.Windows.Forms.Button refreshTableBtn;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Panel dataManagerPanel;
        private System.Windows.Forms.Button saveRowBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel dataEditorPanel;
        private System.Windows.Forms.TextBox folderIDTextBox;
        private System.Windows.Forms.Label folderIDLabel;
        private System.Windows.Forms.TextBox accountIDTextBox;
        private System.Windows.Forms.Label accountIDLabel;
        private System.Windows.Forms.Timer refreshBtnTimer;
    }
}