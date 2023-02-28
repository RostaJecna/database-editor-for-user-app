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
            this.dragPanel = new System.Windows.Forms.Panel();
            this.windowCloseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bgPicture)).BeginInit();
            this.bgPanel.SuspendLayout();
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
            this.welcomePanel.Location = new System.Drawing.Point(0, 58);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(301, 288);
            this.welcomePanel.TabIndex = 1;
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.Transparent;
            this.dragPanel.Controls.Add(this.windowCloseBtn);
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(301, 58);
            this.dragPanel.TabIndex = 0;
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.dragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            // 
            // windowCloseBtn
            // 
            this.windowCloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.windowCloseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.windowCloseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.windowCloseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.windowCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowCloseBtn.ForeColor = System.Drawing.Color.White;
            this.windowCloseBtn.Location = new System.Drawing.Point(255, 12);
            this.windowCloseBtn.Name = "windowCloseBtn";
            this.windowCloseBtn.Size = new System.Drawing.Size(34, 34);
            this.windowCloseBtn.TabIndex = 0;
            this.windowCloseBtn.Text = "X";
            this.windowCloseBtn.UseVisualStyleBackColor = true;
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
            this.dragPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bgPicture;
        private System.Windows.Forms.Panel bgPanel;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.Label additionalLabel;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Button windowCloseBtn;
    }
}

