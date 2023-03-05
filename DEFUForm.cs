using DatabaseEditorForUser.Graphics;
using DatabaseEditorForUser.Subforms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseEditorForUser
{
    public partial class DEFUForm : Form
    {
        private const string LOGO_MASK_PATH = @"../../Resources/DEFUForm/Logo_mask.png";

        private static Button activeBtn;
        private static Form activeForm;

        private readonly Random rnd;

        public DEFUForm()
        {
            InitializeComponent();
            ChangeDefaultComponent();
            AddSpaceBeforeButtons(menuPanel);
            rnd = new Random();
        }

        private Image RemapImage(Image image, Bitmap mask, Color color)
        {
            Bitmap output = image as Bitmap;

            if (image.Size != mask.Size)
            {
                throw new ArgumentException("Image and mask must be the same size.");
            }

            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    if (mask.GetPixel(x, y) == Color.FromArgb(255, 255, 255))
                    {
                        output.SetPixel(x, y, color);
                    }
                }
            }

            return output;
        }

        private void ChangeDefaultComponent()
        {
            barTitleLabel.Text = barTitleLabel.Text.ToUpper();
            mainBigLogoPictureBox.Image = RemapImage(
                mainBigLogoPictureBox.Image,
                new Bitmap(LOGO_MASK_PATH),
                Color.Gainsboro
                );
        }

        private void AddSpaceBeforeButtons(Panel panel)
        {
            string threeSpaces = new string('\x20', 3);
            foreach (Control control in panel.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Text = $"{threeSpaces}{control.Text}";
                }
            }
        }

        private Point CentreLabelByPanel(System.Windows.Forms.Label label, Panel panel)
        {
            int centrePanelX = panel.Size.Width / 2;
            int centrePanelY = panel.Size.Height / 2;

            int centreLabelX = label.Size.Width / 2;
            int centreLabelY = label.Size.Height / 2;

            return new Point(centrePanelX - centreLabelX, centrePanelY - centreLabelY);
        }

        private void DesignPanels(Color barPanelColor, Color menuLogoPanelColor, Button selectedBtn)
        {
            barPanel.BackColor = barPanelColor;
            menuLogoPanel.BackColor = menuLogoPanelColor;

            barTitleLabel.Text = selectedBtn.Text.ToUpper().Replace("\x20", "");
            barTitleLabel.Location = CentreLabelByPanel(barTitleLabel, barPanel);
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

        private void OpenSubform(Form subform)
        {
            if(activeForm != null)
            {
                if(activeForm.GetType() != subform.GetType())
                {
                    activeForm.Close();
                }
                else
                {
                    return;
                }
            }

            activeForm = subform;
            subform.TopLevel = false;
            mainPanel.Controls.Add(subform);
            subform.Dock = DockStyle.Fill;
            subform.BringToFront();
            subform.Show();
        }

        private void MenuAccountBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
            OpenSubform(new AccountForm());
        }

        private void MenuColorBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
            OpenSubform(new ColorForm());
        }

        private void MenuFolderBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
            OpenSubform(new FolderForm());
        }

        private void MenuAccessBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
            OpenSubform(new AccessForm());
        }

        private void MenuTypeBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
            OpenSubform(new TypeForm());
        }

        private void MenuAttachmentBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, e);
            OpenSubform(new AttachmentForm());
        }
    }
}
