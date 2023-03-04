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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuLogoPanel = new System.Windows.Forms.Panel();
            this.menuAttachmentBtn = new System.Windows.Forms.Button();
            this.menuTypeBtn = new System.Windows.Forms.Button();
            this.menuAccessBtn = new System.Windows.Forms.Button();
            this.menuFolderBtn = new System.Windows.Forms.Button();
            this.menuColorBtn = new System.Windows.Forms.Button();
            this.menuAccountBtn = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
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
            this.menuPanel.Size = new System.Drawing.Size(198, 478);
            this.menuPanel.TabIndex = 0;
            // 
            // menuLogoPanel
            // 
            this.menuLogoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(34)))), ((int)(((byte)(63)))));
            this.menuLogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuLogoPanel.Location = new System.Drawing.Point(0, 0);
            this.menuLogoPanel.Name = "menuLogoPanel";
            this.menuLogoPanel.Size = new System.Drawing.Size(198, 100);
            this.menuLogoPanel.TabIndex = 0;
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
            this.menuAttachmentBtn.Size = new System.Drawing.Size(198, 60);
            this.menuAttachmentBtn.TabIndex = 8;
            this.menuAttachmentBtn.Text = "Attachment";
            this.menuAttachmentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAttachmentBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAttachmentBtn.UseVisualStyleBackColor = true;
            this.menuAttachmentBtn.Click += new System.EventHandler(this.ActivateButton);
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
            this.menuTypeBtn.Size = new System.Drawing.Size(198, 60);
            this.menuTypeBtn.TabIndex = 7;
            this.menuTypeBtn.Text = "Type";
            this.menuTypeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuTypeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuTypeBtn.UseVisualStyleBackColor = true;
            this.menuTypeBtn.Click += new System.EventHandler(this.ActivateButton);
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
            this.menuAccessBtn.Size = new System.Drawing.Size(198, 60);
            this.menuAccessBtn.TabIndex = 4;
            this.menuAccessBtn.Text = "Access";
            this.menuAccessBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAccessBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAccessBtn.UseVisualStyleBackColor = true;
            this.menuAccessBtn.Click += new System.EventHandler(this.ActivateButton);
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
            this.menuFolderBtn.Size = new System.Drawing.Size(198, 60);
            this.menuFolderBtn.TabIndex = 3;
            this.menuFolderBtn.Text = "Folder";
            this.menuFolderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuFolderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuFolderBtn.UseVisualStyleBackColor = true;
            this.menuFolderBtn.Click += new System.EventHandler(this.ActivateButton);
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
            this.menuColorBtn.Size = new System.Drawing.Size(198, 60);
            this.menuColorBtn.TabIndex = 2;
            this.menuColorBtn.Text = "Color";
            this.menuColorBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuColorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuColorBtn.UseVisualStyleBackColor = true;
            this.menuColorBtn.Click += new System.EventHandler(this.ActivateButton);
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
            this.menuAccountBtn.Size = new System.Drawing.Size(198, 60);
            this.menuAccountBtn.TabIndex = 1;
            this.menuAccountBtn.Text = "Account";
            this.menuAccountBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuAccountBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuAccountBtn.UseVisualStyleBackColor = true;
            this.menuAccountBtn.Click += new System.EventHandler(this.ActivateButton);
            // 
            // DEFUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 478);
            this.Controls.Add(this.menuPanel);
            this.Name = "DEFUForm";
            this.Text = "DEFU: Connected";
            this.menuPanel.ResumeLayout(false);
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
    }
}