using DatabaseEditorForUser.Graphics;
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
        private static Button activeBtn;
        private Random rnd;

        public DEFUForm()
        {
            InitializeComponent();
            SpaceBeforeButtons(menuPanel);
            rnd = new Random();
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

        private void ActivateButton(object sender, EventArgs e)
        {
            Button selectedBtn = (Button)sender;

            if (activeBtn != null && activeBtn != selectedBtn)
            {
                activeBtn.BackColor = selectedBtn.BackColor;
                activeBtn.Font = selectedBtn.Font;
            }
            else if (activeBtn == selectedBtn)
            {
                return;
            }

            activeBtn = selectedBtn;
            selectedBtn.BackColor = Palettes.GetNextRandom(rnd);
            selectedBtn.Font = new Font(selectedBtn.Font.FontFamily, 10.5F, selectedBtn.Font.Style, selectedBtn.Font.Unit, 0);
        }
    }
}
