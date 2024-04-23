using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    /// <summary>
    ///     Form for connecting to the database.
    /// </summary>
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

        /// <summary>
        ///     Initializes a new instance of the ConnectForm class.
        /// </summary>
        public ConnectForm()
        {
            InitializeComponent();
            SwitchPanelTo(Panels.Welcome);
        }

        /// <summary>
        ///     Switches the visible panel to the specified one.
        /// </summary>
        /// <param name="panel">The panel to switch to.</param>
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

        /// <summary>
        ///     Handles the Paint event for the background panel.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle gradientRectangle = new Rectangle(0, 0, bgPanel.Width, bgPanel.Height);
            e.Graphics.FillRectangle(new LinearGradientBrush(gradientRectangle,
                Color.FromArgb(36, 63, 114), Color.FromArgb(3, 7, 12), 65f), gradientRectangle);
        }

        /// <summary>
        ///     Handles the MouseDown event for the drag panel.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastMouseCoordinate = e.Location;
        }

        /// <summary>
        ///     Handles the MouseMove event for the drag panel.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - lastMouseCoordinate.X;
            Top += e.Y - lastMouseCoordinate.Y;
        }

        /// <summary>
        ///     Handles the Click event for the close button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FormCloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Handles the Click event for the welcome connect button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
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

        /// <summary>
        ///     Handles the Tick event for the connection timer.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
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

        /// <summary>
        ///     Handles the Click event for the configuration button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ConfigurationBtn_Click(object sender, EventArgs e)
        {
            new ConfigurationForm().ShowDialog();
        }
    }
}