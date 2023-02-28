namespace DatabaseEditorForUser
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.bgPicture = new System.Windows.Forms.PictureBox();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.additionalLabel = new System.Windows.Forms.Label();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.welcomeSubtitleLabel = new System.Windows.Forms.Label();
            this.welcomeLineLabel = new System.Windows.Forms.Label();
            this.welcomeTitleLabel = new System.Windows.Forms.Label();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.formCloseBtn = new System.Windows.Forms.Button();
            this.welcomeConnectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.bgPanel.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.dragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPicture
            // 
            this.bgPicture.Image = ((System.Drawing.Image)(resources.GetObject("bgPicture.Image")));
            this.bgPicture.Location = new System.Drawing.Point(0, 0);
            this.bgPicture.Name = "bgPicture";
            this.bgPicture.Size = new System.Drawing.Size(405, 404);
            this.bgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgPicture.TabIndex = 0;
            this.bgPicture.TabStop = false;
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgPanel.Controls.Add(this.additionalLabel);
            this.bgPanel.Controls.Add(this.welcomePanel);
            this.bgPanel.Controls.Add(this.dragPanel);
            this.bgPanel.Location = new System.Drawing.Point(405, 0);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(301, 404);
            this.bgPanel.TabIndex = 1;
            this.bgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BgPanel_Paint);
            // 
            // additionalLabel
            // 
            this.additionalLabel.BackColor = System.Drawing.Color.Transparent;
            this.additionalLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additionalLabel.ForeColor = System.Drawing.Color.Gray;
            this.additionalLabel.Location = new System.Drawing.Point(0, 346);
            this.additionalLabel.Name = "additionalLabel";
            this.additionalLabel.Size = new System.Drawing.Size(301, 58);
            this.additionalLabel.TabIndex = 2;
            this.additionalLabel.Text = "Free 30-day trial version";
            this.additionalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackColor = System.Drawing.Color.Transparent;
            this.welcomePanel.Controls.Add(this.welcomeConnectBtn);
            this.welcomePanel.Controls.Add(this.welcomeSubtitleLabel);
            this.welcomePanel.Controls.Add(this.welcomeLineLabel);
            this.welcomePanel.Controls.Add(this.welcomeTitleLabel);
            this.welcomePanel.Location = new System.Drawing.Point(0, 58);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(301, 288);
            this.welcomePanel.TabIndex = 1;
            // 
            // welcomeSubtitleLabel
            // 
            this.welcomeSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeSubtitleLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeSubtitleLabel.ForeColor = System.Drawing.Color.LightGray;
            this.welcomeSubtitleLabel.Location = new System.Drawing.Point(59, 122);
            this.welcomeSubtitleLabel.Name = "welcomeSubtitleLabel";
            this.welcomeSubtitleLabel.Size = new System.Drawing.Size(183, 56);
            this.welcomeSubtitleLabel.TabIndex = 8;
            this.welcomeSubtitleLabel.Text = "Manage your database with a few clicks.\r\n";
            this.welcomeSubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomeLineLabel
            // 
            this.welcomeLineLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLineLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLineLabel.Location = new System.Drawing.Point(41, 93);
            this.welcomeLineLabel.Name = "welcomeLineLabel";
            this.welcomeLineLabel.Size = new System.Drawing.Size(219, 29);
            this.welcomeLineLabel.TabIndex = 7;
            this.welcomeLineLabel.Text = "_________________";
            this.welcomeLineLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // welcomeTitleLabel
            // 
            this.welcomeTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeTitleLabel.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeTitleLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeTitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.welcomeTitleLabel.Location = new System.Drawing.Point(56, 28);
            this.welcomeTitleLabel.Name = "welcomeTitleLabel";
            this.welcomeTitleLabel.Size = new System.Drawing.Size(189, 65);
            this.welcomeTitleLabel.TabIndex = 0;
            this.welcomeTitleLabel.Text = "Database Editor For User";
            this.welcomeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.Transparent;
            this.dragPanel.Controls.Add(this.formCloseBtn);
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(301, 58);
            this.dragPanel.TabIndex = 0;
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.dragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            // 
            // formCloseBtn
            // 
            this.formCloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.formCloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.formCloseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.formCloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.formCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formCloseBtn.ForeColor = System.Drawing.Color.White;
            this.formCloseBtn.Location = new System.Drawing.Point(255, 12);
            this.formCloseBtn.Name = "formCloseBtn";
            this.formCloseBtn.Size = new System.Drawing.Size(34, 34);
            this.formCloseBtn.TabIndex = 0;
            this.formCloseBtn.Text = "X";
            this.formCloseBtn.UseVisualStyleBackColor = true;
            // 
            // welcomeConnectBtn
            // 
            this.welcomeConnectBtn.BackColor = System.Drawing.Color.Transparent;
            this.welcomeConnectBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.welcomeConnectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.welcomeConnectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.welcomeConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.welcomeConnectBtn.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeConnectBtn.ForeColor = System.Drawing.Color.White;
            this.welcomeConnectBtn.Location = new System.Drawing.Point(77, 193);
            this.welcomeConnectBtn.Name = "welcomeConnectBtn";
            this.welcomeConnectBtn.Padding = new System.Windows.Forms.Padding(15);
            this.welcomeConnectBtn.Size = new System.Drawing.Size(147, 82);
            this.welcomeConnectBtn.TabIndex = 9;
            this.welcomeConnectBtn.Text = "Connect To Database";
            this.welcomeConnectBtn.UseVisualStyleBackColor = false;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 404);
            this.Controls.Add(this.bgPanel);
            this.Controls.Add(this.bgPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConnectForm";
            this.Text = "DEFU: Connect";
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).EndInit();
            this.bgPanel.ResumeLayout(false);
            this.welcomePanel.ResumeLayout(false);
            this.dragPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bgPicture;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.Label additionalLabel;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Button formCloseBtn;
        private System.Windows.Forms.Label welcomeTitleLabel;
        private System.Windows.Forms.Label welcomeLineLabel;
        private System.Windows.Forms.Label welcomeSubtitleLabel;
        private System.Windows.Forms.Button welcomeConnectBtn;
    }
}

