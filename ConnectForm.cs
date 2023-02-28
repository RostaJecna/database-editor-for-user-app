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
        Point lastMouseCoor;

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void BgPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);
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
    }
}
