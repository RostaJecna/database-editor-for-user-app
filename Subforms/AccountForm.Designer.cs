namespace DatabaseEditorForUser.Subforms
{
    partial class AccountForm
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
            this.accountGridView = new System.Windows.Forms.DataGridView();
            this.rightSidePanel = new System.Windows.Forms.Panel();
            this.dataManagerPanel = new System.Windows.Forms.Panel();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.dataEditorPanel = new System.Windows.Forms.Panel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.saveRowBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.searchBarPanel = new System.Windows.Forms.Panel();
            this.refreshTableBtn = new System.Windows.Forms.Button();
            this.refreshBtnTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountGridView)).BeginInit();
            this.rightSidePanel.SuspendLayout();
            this.dataManagerPanel.SuspendLayout();
            this.dataEditorPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
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
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1067, 554);
            this.mainPanel.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.accountGridView);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 66);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(867, 488);
            this.gridPanel.TabIndex = 2;
            // 
            // accountGridView
            // 
            this.accountGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.accountGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountGridView.Location = new System.Drawing.Point(29, 27);
            this.accountGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accountGridView.MultiSelect = false;
            this.accountGridView.Name = "accountGridView";
            this.accountGridView.ReadOnly = true;
            this.accountGridView.RowHeadersWidth = 51;
            this.accountGridView.RowTemplate.Height = 24;
            this.accountGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountGridView.Size = new System.Drawing.Size(808, 434);
            this.accountGridView.TabIndex = 0;
            this.accountGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountGridView_CellClick);
            // 
            // rightSidePanel
            // 
            this.rightSidePanel.Controls.Add(this.navigationPanel);
            this.rightSidePanel.Controls.Add(this.dataManagerPanel);
            this.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSidePanel.Location = new System.Drawing.Point(867, 66);
            this.rightSidePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightSidePanel.Name = "rightSidePanel";
            this.rightSidePanel.Size = new System.Drawing.Size(200, 488);
            this.rightSidePanel.TabIndex = 1;
            // 
            // dataManagerPanel
            // 
            this.dataManagerPanel.Controls.Add(this.passwordCheckBox);
            this.dataManagerPanel.Controls.Add(this.dataEditorPanel);
            this.dataManagerPanel.Controls.Add(this.saveRowBtn);
            this.dataManagerPanel.Controls.Add(this.backBtn);
            this.dataManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataManagerPanel.Location = new System.Drawing.Point(0, 0);
            this.dataManagerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataManagerPanel.Name = "dataManagerPanel";
            this.dataManagerPanel.Size = new System.Drawing.Size(200, 488);
            this.dataManagerPanel.TabIndex = 10;
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.Checked = true;
            this.passwordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.passwordCheckBox.Location = new System.Drawing.Point(24, 318);
            this.passwordCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(147, 38);
            this.passwordCheckBox.TabIndex = 10;
            this.passwordCheckBox.Text = "Don\'t change password.";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.Visible = false;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.PasswordCheckBox_CheckedChanged);
            // 
            // dataEditorPanel
            // 
            this.dataEditorPanel.Controls.Add(this.passwordTextBox);
            this.dataEditorPanel.Controls.Add(this.passwordLabel);
            this.dataEditorPanel.Controls.Add(this.emailTextBox);
            this.dataEditorPanel.Controls.Add(this.emailLabel);
            this.dataEditorPanel.Controls.Add(this.lastNameTextBox);
            this.dataEditorPanel.Controls.Add(this.lastNameLabel);
            this.dataEditorPanel.Controls.Add(this.firstNameTextBox);
            this.dataEditorPanel.Controls.Add(this.firstNameLabel);
            this.dataEditorPanel.Location = new System.Drawing.Point(0, 73);
            this.dataEditorPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataEditorPanel.Name = "dataEditorPanel";
            this.dataEditorPanel.Size = new System.Drawing.Size(171, 193);
            this.dataEditorPanel.TabIndex = 9;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordTextBox.Location = new System.Drawing.Point(0, 154);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(171, 22);
            this.passwordTextBox.TabIndex = 7;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(0, 132);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(171, 22);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.emailTextBox.Location = new System.Drawing.Point(0, 110);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(171, 22);
            this.emailTextBox.TabIndex = 5;
            // 
            // emailLabel
            // 
            this.emailLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(0, 88);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(171, 22);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email:";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.lastNameTextBox.Location = new System.Drawing.Point(0, 66);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(171, 22);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(0, 44);
            this.lastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(171, 22);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last name:";
            this.lastNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.firstNameTextBox.Location = new System.Drawing.Point(0, 22);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(171, 22);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(0, 0);
            this.firstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(171, 22);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First name:";
            this.firstNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.saveRowBtn.Location = new System.Drawing.Point(0, 272);
            this.saveRowBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveRowBtn.Name = "saveRowBtn";
            this.saveRowBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.saveRowBtn.Size = new System.Drawing.Size(171, 39);
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
            this.backBtn.Location = new System.Drawing.Point(0, 27);
            this.backBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.backBtn.Size = new System.Drawing.Size(171, 39);
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.deleteBtn);
            this.navigationPanel.Controls.Add(this.editBtn);
            this.navigationPanel.Controls.Add(this.addRowBtn);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(200, 488);
            this.navigationPanel.TabIndex = 9;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Brown;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.deleteBtn.Location = new System.Drawing.Point(0, 116);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(171, 39);
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
            this.editBtn.Location = new System.Drawing.Point(0, 71);
            this.editBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(171, 39);
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
            this.addRowBtn.Location = new System.Drawing.Point(0, 27);
            this.addRowBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(171, 39);
            this.addRowBtn.TabIndex = 6;
            this.addRowBtn.Text = "Add";
            this.addRowBtn.UseVisualStyleBackColor = false;
            this.addRowBtn.Click += new System.EventHandler(this.AddRowBtn_Click);
            // 
            // searchBarPanel
            // 
            this.searchBarPanel.Controls.Add(this.refreshTableBtn);
            this.searchBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBarPanel.Location = new System.Drawing.Point(0, 0);
            this.searchBarPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBarPanel.Name = "searchBarPanel";
            this.searchBarPanel.Size = new System.Drawing.Size(1067, 66);
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
            this.refreshTableBtn.Location = new System.Drawing.Point(29, 27);
            this.refreshTableBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshTableBtn.Name = "refreshTableBtn";
            this.refreshTableBtn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.refreshTableBtn.Size = new System.Drawing.Size(171, 39);
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
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.mainPanel.ResumeLayout(false);
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accountGridView)).EndInit();
            this.rightSidePanel.ResumeLayout(false);
            this.dataManagerPanel.ResumeLayout(false);
            this.dataEditorPanel.ResumeLayout(false);
            this.dataEditorPanel.PerformLayout();
            this.navigationPanel.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView accountGridView;
        private System.Windows.Forms.Button refreshTableBtn;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Panel dataManagerPanel;
        private System.Windows.Forms.Button saveRowBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel dataEditorPanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Timer refreshBtnTimer;
        private System.Windows.Forms.CheckBox passwordCheckBox;
    }
}