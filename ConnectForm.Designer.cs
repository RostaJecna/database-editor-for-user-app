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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.bgPicture = new System.Windows.Forms.PictureBox();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.additionalLabel = new System.Windows.Forms.Label();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.formCloseBtn = new System.Windows.Forms.Button();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.welcomeConnectBtn = new System.Windows.Forms.Button();
            this.welcomeSubtitleLabel = new System.Windows.Forms.Label();
            this.welcomeLineLabel = new System.Windows.Forms.Label();
            this.welcomeTitleLabel = new System.Windows.Forms.Label();
            this.connectionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.bgPanel.SuspendLayout();
            this.dragPanel.SuspendLayout();
            this.connectionPanel.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgPicture
            // 
            this.bgPicture.Image = ((System.Drawing.Image)(resources.GetObject("bgPicture.Image")));
            this.bgPicture.Location = new System.Drawing.Point(0, 0);
            this.bgPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bgPicture.Name = "bgPicture";
            this.bgPicture.Size = new System.Drawing.Size(540, 497);
            this.bgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgPicture.TabIndex = 0;
            this.bgPicture.TabStop = false;
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bgPanel.Controls.Add(this.additionalLabel);
            this.bgPanel.Controls.Add(this.dragPanel);
            this.bgPanel.Controls.Add(this.welcomePanel);
            this.bgPanel.Controls.Add(this.connectionPanel);
            this.bgPanel.Location = new System.Drawing.Point(540, 0);
            this.bgPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(401, 497);
            this.bgPanel.TabIndex = 1;
            this.bgPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BgPanel_Paint);
            // 
            // additionalLabel
            // 
            this.additionalLabel.BackColor = System.Drawing.Color.Transparent;
            this.additionalLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additionalLabel.ForeColor = System.Drawing.Color.Gray;
            this.additionalLabel.Location = new System.Drawing.Point(0, 426);
            this.additionalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.additionalLabel.Name = "additionalLabel";
            this.additionalLabel.Size = new System.Drawing.Size(401, 71);
            this.additionalLabel.TabIndex = 2;
            this.additionalLabel.Text = "Free 30-day trial version";
            this.additionalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.Transparent;
            this.dragPanel.Controls.Add(this.formCloseBtn);
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(401, 71);
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
            this.formCloseBtn.Location = new System.Drawing.Point(340, 15);
            this.formCloseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formCloseBtn.Name = "formCloseBtn";
            this.formCloseBtn.Size = new System.Drawing.Size(45, 42);
            this.formCloseBtn.TabIndex = 0;
            this.formCloseBtn.Text = "X";
            this.formCloseBtn.UseVisualStyleBackColor = true;
            this.formCloseBtn.Click += new System.EventHandler(this.FormCloseBtn_Click);
            // 
            // connectionPanel
            // 
            this.connectionPanel.BackColor = System.Drawing.Color.Transparent;
            this.connectionPanel.Controls.Add(this.connectionStatusLabel);
            this.connectionPanel.Location = new System.Drawing.Point(0, 71);
            this.connectionPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(401, 354);
            this.connectionPanel.TabIndex = 3;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.White;
            this.connectionStatusLabel.Location = new System.Drawing.Point(55, 92);
            this.connectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(292, 36);
            this.connectionStatusLabel.TabIndex = 7;
            this.connectionStatusLabel.Text = "Connecting";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackColor = System.Drawing.Color.Transparent;
            this.welcomePanel.Controls.Add(this.welcomeConnectBtn);
            this.welcomePanel.Controls.Add(this.welcomeSubtitleLabel);
            this.welcomePanel.Controls.Add(this.welcomeLineLabel);
            this.welcomePanel.Controls.Add(this.welcomeTitleLabel);
            this.welcomePanel.Location = new System.Drawing.Point(0, 71);
            this.welcomePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(401, 354);
            this.welcomePanel.TabIndex = 1;
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
            this.welcomeConnectBtn.Location = new System.Drawing.Point(103, 238);
            this.welcomeConnectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.welcomeConnectBtn.Name = "welcomeConnectBtn";
            this.welcomeConnectBtn.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.welcomeConnectBtn.Size = new System.Drawing.Size(196, 101);
            this.welcomeConnectBtn.TabIndex = 9;
            this.welcomeConnectBtn.Text = "Connect To Database";
            this.welcomeConnectBtn.UseVisualStyleBackColor = false;
            this.welcomeConnectBtn.Click += new System.EventHandler(this.WelcomeConnectBtn_Click);
            // 
            // welcomeSubtitleLabel
            // 
            this.welcomeSubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeSubtitleLabel.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeSubtitleLabel.ForeColor = System.Drawing.Color.LightGray;
            this.welcomeSubtitleLabel.Location = new System.Drawing.Point(79, 150);
            this.welcomeSubtitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomeSubtitleLabel.Name = "welcomeSubtitleLabel";
            this.welcomeSubtitleLabel.Size = new System.Drawing.Size(244, 69);
            this.welcomeSubtitleLabel.TabIndex = 8;
            this.welcomeSubtitleLabel.Text = "Manage your database with a few clicks.\r\n";
            this.welcomeSubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomeLineLabel
            // 
            this.welcomeLineLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLineLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLineLabel.Location = new System.Drawing.Point(55, 114);
            this.welcomeLineLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomeLineLabel.Name = "welcomeLineLabel";
            this.welcomeLineLabel.Size = new System.Drawing.Size(292, 36);
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
            this.welcomeTitleLabel.Location = new System.Drawing.Point(75, 29);
            this.welcomeTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomeTitleLabel.Name = "welcomeTitleLabel";
            this.welcomeTitleLabel.Size = new System.Drawing.Size(252, 85);
            this.welcomeTitleLabel.TabIndex = 0;
            this.welcomeTitleLabel.Text = "Database Editor For User";
            this.welcomeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectionTimer
            // 
            this.connectionTimer.Interval = 10;
            this.connectionTimer.Tick += new System.EventHandler(this.ConnectionTimer_Tick);
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 497);
            this.Controls.Add(this.bgPanel);
            this.Controls.Add(this.bgPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEFU: Connect";
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).EndInit();
            this.bgPanel.ResumeLayout(false);
            this.dragPanel.ResumeLayout(false);
            this.connectionPanel.ResumeLayout(false);
            this.welcomePanel.ResumeLayout(false);
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
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Timer connectionTimer;
        private System.Windows.Forms.Label connectionStatusLabel;
    }
}

