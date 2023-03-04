using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    public partial class ConnectForm : Form
    {
        private enum Panels
        {
            Welcome,
            Connection
        }

        Point lastMouseCoor;
        int connectionTimerCounter;
        Task connectionTask;

        public ConnectForm()
        {
            InitializeComponent();
            SwitchPanelTo(Panels.Welcome);
        }

        private void SwitchPanelTo(Panels panel)
        {
            switch(panel)
            {
                case Panels.Welcome:
                    welcomePanel.Visible = true;
                    connectionPanel.Visible = false;
                    break;
                case Panels.Connection:
                    welcomePanel.Visible = false;
                    connectionPanel.Visible = true;
                    break;
            }
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle gradient_rectangle = new Rectangle(0, 0, bgPanel.Width, bgPanel.Height);
            e.Graphics.FillRectangle(new LinearGradientBrush(gradient_rectangle,
                Color.FromArgb(36, 63, 114), Color.FromArgb(3, 7, 12), 65f), gradient_rectangle);
        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouseCoor = e.Location;
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastMouseCoor.X;
                Top += e.Y - lastMouseCoor.Y;
            }
        }

        private void FormCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WelcomeConnectBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.Connection);
            connectionTimer.Enabled = true;
            connectionTimer.Start();

            connectionTask = new Task(() =>
            {
                try
                {
                    DatabaseSingleton.Instance().Open();
                    DatabaseSingleton.status = DatabaseSingleton.Status.Connected;
                }
                catch(Exception ex)
                {
                    DatabaseSingleton.status = DatabaseSingleton.Status.Failure;
                    MessageBox.Show(ex.Message);
                }
            });

            connectionTask.Start();
        }

        private void ConnectionTimer_Tick(object sender, EventArgs e)
        {
            if(DatabaseSingleton.IsConnected())
            {
                DatabaseSingleton.status = DatabaseSingleton.Status.Success;
                Close();
            }
            else if (DatabaseSingleton.IsFailure())
            {
                SwitchPanelTo(Panels.Welcome);
                connectionTimer.Enabled = false;
                connectionTimer.Stop();
                connectionTimerCounter = 0;
                welcomeConnectBtn.Text = "Re-connect To Database";
                DatabaseSingleton.CloseAndDispose();
            }

            switch (connectionTimerCounter)
            {
                case 0:
                    connectionStatusLabel.Text = "Connecting.";
                    connectionTimerCounter++;
                    break;
                case 50:
                    connectionStatusLabel.Text = "Connecting..";
                    connectionTimerCounter++;
                    break;
                case 100:
                    connectionStatusLabel.Text = "Connecting...";
                    connectionTimerCounter++;
                    break;
                case 150:
                    connectionTimerCounter = 0;
                    break;
                default:
                    connectionTimerCounter++;
                    break;
            }
        }
    }
}
