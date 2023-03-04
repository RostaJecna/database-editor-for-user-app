using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    public partial class DEFUForm : Form
    {
        public DEFUForm()
        {
            InitializeComponent();
            SpaceBeforeButtons(menuPanel);
        }

        private void SpaceBeforeButtons(Panel panel)
        {
            string threeSpaces = new string('\x20', 3);
            foreach (Control control in panel.Controls)
            {
                if(control.GetType() == typeof(Button))
                {
                    control.Text = $"{threeSpaces}{control.Text}";
                }
            }
        }
    }
}
