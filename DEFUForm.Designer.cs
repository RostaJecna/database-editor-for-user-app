namespace DatabaseEditorForUser
{
    partial class DEFUForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEFUForm));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuAttachmentBtn = new System.Windows.Forms.Button();
            this.menuTypeBtn = new System.Windows.Forms.Button();
            this.menuAccessBtn = new System.Windows.Forms.Button();
            this.menuFolderBtn = new System.Windows.Forms.Button();
            this.menuColorBtn = new System.Windows.Forms.Button();
            this.menuAccountBtn = new System.Windows.Forms.Button();
            this.menuLogoPanel = new System.Windows.Forms.Panel();
            this.menuLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.barPanel = new System.Windows.Forms.Panel();
            this.closeSubformBtn = new System.Windows.Forms.Button();
            this.barTitleLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataManagerPanel = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.mainBigLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.menuPanel.SuspendLayout();
            this.menuLogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuLogoPictureBox)).BeginInit();
            this.barPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.dataManagerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainBigLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(54)))), ((int)(((byte)(101)))));
            this.menuPanel.Controls.Add(this.menuAttachmentBtn);
            this.menuPanel.Controls.Add(this.menuTypeBtn);
            this.menuPanel.Controls.Add(this.menuAccessBtn);
            this.menuPanel.Controls.Add(this.menuFolderBtn);
            this.menuPanel.Controls.Add(this.menuColorBtn);
            this.menuPanel.Controls.Add(this.menuAccountBtn);
            this.menuPanel.Controls.Add(this.menuLogoPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(180, 560);
            this.menuPanel.TabIndex = 0;
            // 
            // menuAttachmentBtn
            // 
            this.menuAttachmentBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuAttachmentBtn.FlatAppearance.BorderSize = 0;
            this.menuAttachmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuAttachmentBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuAttachmentBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Attachment;
            this.menuAttachmentBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAttachmentBtn.Location = new System.Drawing.Point(0, 400);
            this.menuAttachmentBtn.Name = "menuAttachmentBtn";
            this.menuAttachmentBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.menuAttachmentBtn.Size = new System.Drawing.Size(180, 60);
            this.menuAttachmentBtn.TabIndex = 8;
            this.menuAttachmentBtn.Text = "Attachment";
            this.menuAttachmentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAttachmentBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAttachmentBtn.UseVisualStyleBackColor = true;
            this.menuAttachmentBtn.Click += new System.EventHandler(this.MenuAttachmentBtn_Click);
            // 
            // menuTypeBtn
            // 
            this.menuTypeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuTypeBtn.FlatAppearance.BorderSize = 0;
            this.menuTypeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuTypeBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuTypeBtn.Image = global::DatabaseEditorForUser.Properties.Resources.AttachamentType;
            this.menuTypeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuTypeBtn.Location = new System.Drawing.Point(0, 340);
            this.menuTypeBtn.Name = "menuTypeBtn";
            this.menuTypeBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.menuTypeBtn.Size = new System.Drawing.Size(180, 60);
            this.menuTypeBtn.TabIndex = 7;
            this.menuTypeBtn.Text = "Type";
            this.menuTypeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuTypeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuTypeBtn.UseVisualStyleBackColor = true;
            this.menuTypeBtn.Click += new System.EventHandler(this.MenuTypeBtn_Click);
            // 
            // menuAccessBtn
            // 
            this.menuAccessBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuAccessBtn.FlatAppearance.BorderSize = 0;
            this.menuAccessBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuAccessBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuAccessBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Access;
            this.menuAccessBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAccessBtn.Location = new System.Drawing.Point(0, 280);
            this.menuAccessBtn.Name = "menuAccessBtn";
            this.menuAccessBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.menuAccessBtn.Size = new System.Drawing.Size(180, 60);
            this.menuAccessBtn.TabIndex = 4;
            this.menuAccessBtn.Text = "Access";
            this.menuAccessBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAccessBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAccessBtn.UseVisualStyleBackColor = true;
            this.menuAccessBtn.Click += new System.EventHandler(this.MenuAccessBtn_Click);
            // 
            // menuFolderBtn
            // 
            this.menuFolderBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuFolderBtn.FlatAppearance.BorderSize = 0;
            this.menuFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuFolderBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuFolderBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Folder;
            this.menuFolderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuFolderBtn.Location = new System.Drawing.Point(0, 220);
            this.menuFolderBtn.Name = "menuFolderBtn";
            this.menuFolderBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.menuFolderBtn.Size = new System.Drawing.Size(180, 60);
            this.menuFolderBtn.TabIndex = 3;
            this.menuFolderBtn.Text = "Folder";
            this.menuFolderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuFolderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuFolderBtn.UseVisualStyleBackColor = true;
            this.menuFolderBtn.Click += new System.EventHandler(this.MenuFolderBtn_Click);
            // 
            // menuColorBtn
            // 
            this.menuColorBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuColorBtn.FlatAppearance.BorderSize = 0;
            this.menuColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuColorBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuColorBtn.Image = global::DatabaseEditorForUser.Properties.Resources.FolderColor;
            this.menuColorBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuColorBtn.Location = new System.Drawing.Point(0, 160);
            this.menuColorBtn.Name = "menuColorBtn";
            this.menuColorBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.menuColorBtn.Size = new System.Drawing.Size(180, 60);
            this.menuColorBtn.TabIndex = 2;
            this.menuColorBtn.Text = "Color";
            this.menuColorBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuColorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuColorBtn.UseVisualStyleBackColor = true;
            this.menuColorBtn.Click += new System.EventHandler(this.MenuColorBtn_Click);
            // 
            // menuAccountBtn
            // 
            this.menuAccountBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuAccountBtn.FlatAppearance.BorderSize = 0;
            this.menuAccountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuAccountBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuAccountBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Account;
            this.menuAccountBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAccountBtn.Location = new System.Drawing.Point(0, 100);
            this.menuAccountBtn.Name = "menuAccountBtn";
            this.menuAccountBtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.menuAccountBtn.Size = new System.Drawing.Size(180, 60);
            this.menuAccountBtn.TabIndex = 1;
            this.menuAccountBtn.Text = "Account";
            this.menuAccountBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAccountBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAccountBtn.UseVisualStyleBackColor = true;
            this.menuAccountBtn.Click += new System.EventHandler(this.MenuAccountBtn_Click);
            // 
            // menuLogoPanel
            // 
            this.menuLogoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(34)))), ((int)(((byte)(63)))));
            this.menuLogoPanel.Controls.Add(this.menuLogoPictureBox);
            this.menuLogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuLogoPanel.Location = new System.Drawing.Point(0, 0);
            this.menuLogoPanel.Name = "menuLogoPanel";
            this.menuLogoPanel.Size = new System.Drawing.Size(180, 100);
            this.menuLogoPanel.TabIndex = 0;
            // 
            // menuLogoPictureBox
            // 
            this.menuLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuLogoPictureBox.Image = global::DatabaseEditorForUser.Properties.Resources.DEFU;
            this.menuLogoPictureBox.Location = new System.Drawing.Point(24, 20);
            this.menuLogoPictureBox.Name = "menuLogoPictureBox";
            this.menuLogoPictureBox.Size = new System.Drawing.Size(132, 60);
            this.menuLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menuLogoPictureBox.TabIndex = 0;
            this.menuLogoPictureBox.TabStop = false;
            // 
            // barPanel
            // 
            this.barPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(54)))), ((int)(((byte)(101)))));
            this.barPanel.Controls.Add(this.closeSubformBtn);
            this.barPanel.Controls.Add(this.barTitleLabel);
            this.barPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.barPanel.Location = new System.Drawing.Point(180, 0);
            this.barPanel.Name = "barPanel";
            this.barPanel.Size = new System.Drawing.Size(786, 100);
            this.barPanel.TabIndex = 1;
            // 
            // closeSubformBtn
            // 
            this.closeSubformBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.closeSubformBtn.FlatAppearance.BorderSize = 0;
            this.closeSubformBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeSubformBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Cancel;
            this.closeSubformBtn.Location = new System.Drawing.Point(0, 0);
            this.closeSubformBtn.Name = "closeSubformBtn";
            this.closeSubformBtn.Size = new System.Drawing.Size(70, 100);
            this.closeSubformBtn.TabIndex = 1;
            this.closeSubformBtn.UseVisualStyleBackColor = true;
            this.closeSubformBtn.Visible = false;
            this.closeSubformBtn.Click += new System.EventHandler(this.CloseSubformBtn_Click);
            // 
            // barTitleLabel
            // 
            this.barTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.barTitleLabel.AutoSize = true;
            this.barTitleLabel.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barTitleLabel.ForeColor = System.Drawing.Color.White;
            this.barTitleLabel.Location = new System.Drawing.Point(344, 38);
            this.barTitleLabel.Name = "barTitleLabel";
            this.barTitleLabel.Size = new System.Drawing.Size(98, 23);
            this.barTitleLabel.TabIndex = 0;
            this.barTitleLabel.Text = "Homepage";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.dataManagerPanel);
            this.mainPanel.Controls.Add(this.mainBigLogoPictureBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(180, 100);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(786, 460);
            this.mainPanel.TabIndex = 2;
            // 
            // dataManagerPanel
            // 
            this.dataManagerPanel.Controls.Add(this.exportButton);
            this.dataManagerPanel.Controls.Add(this.importBtn);
            this.dataManagerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataManagerPanel.Location = new System.Drawing.Point(602, 0);
            this.dataManagerPanel.Name = "dataManagerPanel";
            this.dataManagerPanel.Size = new System.Drawing.Size(184, 460);
            this.dataManagerPanel.TabIndex = 4;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(34)))), ((int)(((byte)(63)))));
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.ForeColor = System.Drawing.Color.White;
            this.exportButton.Image = global::DatabaseEditorForUser.Properties.Resources.Export;
            this.exportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportButton.Location = new System.Drawing.Point(28, 390);
            this.exportButton.Margin = new System.Windows.Forms.Padding(2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.exportButton.Size = new System.Drawing.Size(128, 42);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(54)))), ((int)(((byte)(101)))));
            this.importBtn.FlatAppearance.BorderSize = 0;
            this.importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.ForeColor = System.Drawing.Color.White;
            this.importBtn.Image = global::DatabaseEditorForUser.Properties.Resources.Import;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importBtn.Location = new System.Drawing.Point(28, 344);
            this.importBtn.Margin = new System.Windows.Forms.Padding(2);
            this.importBtn.Name = "importBtn";
            this.importBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.importBtn.Size = new System.Drawing.Size(128, 42);
            this.importBtn.TabIndex = 8;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // mainBigLogoPictureBox
            // 
            this.mainBigLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainBigLogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.mainBigLogoPictureBox.Image = global::DatabaseEditorForUser.Properties.Resources.Logo;
            this.mainBigLogoPictureBox.Location = new System.Drawing.Point(292, 145);
            this.mainBigLogoPictureBox.Name = "mainBigLogoPictureBox";
            this.mainBigLogoPictureBox.Size = new System.Drawing.Size(204, 169);
            this.mainBigLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainBigLogoPictureBox.TabIndex = 3;
            this.mainBigLogoPictureBox.TabStop = false;
            // 
            // DEFUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 560);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.barPanel);
            this.Controls.Add(this.menuPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(948, 536);
            this.Name = "DEFUForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEFU: Connected";
            this.menuPanel.ResumeLayout(false);
            this.menuLogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuLogoPictureBox)).EndInit();
            this.barPanel.ResumeLayout(false);
            this.barPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.dataManagerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainBigLogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button menuAccountBtn;
        private System.Windows.Forms.Panel menuLogoPanel;
        private System.Windows.Forms.Button menuAccessBtn;
        private System.Windows.Forms.Button menuFolderBtn;
        private System.Windows.Forms.Button menuColorBtn;
        private System.Windows.Forms.Button menuAttachmentBtn;
        private System.Windows.Forms.Button menuTypeBtn;
        private System.Windows.Forms.Panel barPanel;
        private System.Windows.Forms.Label barTitleLabel;
        private System.Windows.Forms.PictureBox menuLogoPictureBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox mainBigLogoPictureBox;
        private System.Windows.Forms.Button closeSubformBtn;
        private System.Windows.Forms.Panel dataManagerPanel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importBtn;
    }
}