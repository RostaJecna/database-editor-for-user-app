using DatabaseEditorForUser.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    public partial class DEFUForm : Form
    {
        private static Button activeBtn;
        private readonly Random rnd;

        public DEFUForm()
        {
            InitializeComponent();
            SpaceBeforeButtons(menuPanel);

            barTitleLabel.Text = barTitleLabel.Text.ToUpper();

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
                activeBtn.ForeColor = selectedBtn.ForeColor;
                activeBtn.Font = selectedBtn.Font;
            }
            else if (activeBtn == selectedBtn)
            {
                return;
            }

            activeBtn = selectedBtn;
            selectedBtn.BackColor = Palettes.GetNextRandom(rnd);
            selectedBtn.ForeColor = Color.White;
            selectedBtn.Font = new Font(selectedBtn.Font.FontFamily, 10.5F, selectedBtn.Font.Style, selectedBtn.Font.Unit, 0);

            DesignPanels(Palettes.GetLast(), Palettes.GetLastDarkness(15), selectedBtn);
        }

        private void DesignPanels(Color barPanelColor, Color menuLogoPanelColor, Button selectedBtn)
        {
            barPanel.BackColor = barPanelColor;
            menuLogoPanel.BackColor = menuLogoPanelColor;

            barTitleLabel.Text = selectedBtn.Text.ToUpper().Replace("\x20", "");
            barTitleLabel.Location = CentreLabelByPanel(barTitleLabel, barPanel);
        }

        private Point CentreLabelByPanel(System.Windows.Forms.Label label, Panel panel)
        {
            int centrePanelX = panel.Size.Width / 2;
            int centrePanelY = panel.Size.Height / 2;

            int centreLabelX = label.Size.Width / 2;
            int centreLabelY = label.Size.Height / 2;

            return new Point(centrePanelX - centreLabelX, centrePanelY - centreLabelY);
        }

        private void MenuAccountBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
        }

        private void MenuColorBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
        }

        private void MenuFolderBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
        }

        private void MenuAccessBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
        }

        private void MenuTypeBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
        }

        private void MenuAttachmentBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
        }
    }
}
