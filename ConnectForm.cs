using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private Point lastMouseCoordinate;
        private int connectionTimerCounter;
        private Task connectionTask;

        public ConnectForm()
        {
            InitializeComponent();
            SwitchPanelTo(Panels.Welcome);
        }

        private void SwitchPanelTo(Panels panel)
        {
            switch (panel)
            {
                case Panels.Welcome:
                    welcomePanel.Visible = true;
                    connectionPanel.Visible = false;
                    break;
                case Panels.Connection:
                    welcomePanel.Visible = false;
                    connectionPanel.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(panel), panel, null);
            }
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle gradientRectangle = new Rectangle(0, 0, bgPanel.Width, bgPanel.Height);
            e.Graphics.FillRectangle(new LinearGradientBrush(gradientRectangle,
                Color.FromArgb(36, 63, 114), Color.FromArgb(3, 7, 12), 65f), gradientRectangle);
        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouseCoordinate = e.Location;
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - lastMouseCoordinate.X;
            Top += e.Y - lastMouseCoordinate.Y;
        }

        private void FormCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WelcomeConnectBtn_Click(object sender, EventArgs e)
        {
            SwitchPanelTo(Panels.Connection);
            configurationBtn.Enabled = false;
            connectionTimer.Enabled = true;
            connectionTimer.Start();

            connectionTask = new Task(() =>
            {
                try
                {
                    DatabaseSingleton.Instance().Open();
                    DatabaseSingleton.DbStatus = DatabaseSingleton.Status.Connected;
                }
                catch (Exception ex)
                {
                    DatabaseSingleton.DbStatus = DatabaseSingleton.Status.Failure;
                    MessageBox.Show(ex.Message);
                }
            });

            connectionTask.Start();
        }

        private void ConnectionTimer_Tick(object sender, EventArgs e)
        {
            if (DatabaseSingleton.IsConnected())
            {
                DatabaseSingleton.DbStatus = DatabaseSingleton.Status.Success;
                Close();
            }
            else if (DatabaseSingleton.IsFailure())
            {
                SwitchPanelTo(Panels.Welcome);
                connectionTimer.Enabled = false;
                connectionTimer.Stop();
                connectionTimerCounter = 0;
                welcomeConnectBtn.Text = @"Re-connect To Database";
                configurationBtn.Enabled = true;
                DatabaseSingleton.CloseAndDispose();
            }

            switch (connectionTimerCounter)
            {
                case 0:
                    connectionStatusLabel.Text = @"Connecting.";
                    connectionTimerCounter++;
                    break;
                case 50:
                    connectionStatusLabel.Text = @"Connecting..";
                    connectionTimerCounter++;
                    break;
                case 100:
                    connectionStatusLabel.Text = @"Connecting...";
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

        private void ConfigurationBtn_Click(object sender, EventArgs e)
        {
            new ConfigurationForm().ShowDialog();
        }
    }
}