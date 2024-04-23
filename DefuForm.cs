using System;
using System.Drawing;
using System.Windows.Forms;
using DatabaseEditorForUser.Graphics;
using DatabaseEditorForUser.Subforms;

namespace DatabaseEditorForUser
{
    public partial class DefuForm : Form
    {
        private const string LogoMaskPath = @"../../Resources/DEFUForm/Logo_mask.png";

        private static Button _activeBtn;
        private static Form _activeForm;

        private readonly Random rnd;

        private readonly Color primaryColor;
        private readonly Color secondaryColor;

        public DefuForm()
        {
            InitializeComponent();
            primaryColor = barPanel.BackColor;
            secondaryColor = menuLogoPanel.BackColor;

            ChangeDefaultComponent();
            AddSpaceBeforeButtons(menuPanel);
            rnd = new Random();
        }

        private static Image RemapImage(Image image, Bitmap mask, Color color)
        {
            if (!(image is Bitmap output)) throw new OperationCanceledException();
            if (image.Size != mask.Size) throw new ArgumentException("Image and mask must be the same size.");

            for (int y = 0; y < output.Height; y++)
            for (int x = 0; x < output.Width; x++)
                if (mask.GetPixel(x, y) == Color.FromArgb(255, 255, 255))
                    output.SetPixel(x, y, color);

            return output;
        }

        private void ChangeDefaultComponent()
        {
            barTitleLabel.Text = barTitleLabel.Text.ToUpper();
            mainBigLogoPictureBox.Image = RemapImage(
                mainBigLogoPictureBox.Image,
                new Bitmap(LogoMaskPath),
                Color.Gainsboro
            );
        }

        private static void AddSpaceBeforeButtons(Control panel)
        {
            string threeSpaces = new string('\x20', 3);
            foreach (Control control in panel.Controls)
                if (control.GetType() == typeof(Button))
                    control.Text = $@"{threeSpaces}{control.Text}";
        }

        private static Point CentreLabelByPanel(Control label, Control panel)
        {
            int centrePanelX = panel.Size.Width / 2;
            int centrePanelY = panel.Size.Height / 2;

            int centreLabelX = label.Size.Width / 2;
            int centreLabelY = label.Size.Height / 2;

            return new Point(centrePanelX - centreLabelX, centrePanelY - centreLabelY);
        }

        private void DesignPanels(Color barPanelColor, Color menuLogoPanelColor, Control selectedBtn)
        {
            barPanel.BackColor = barPanelColor;
            menuLogoPanel.BackColor = menuLogoPanelColor;

            barTitleLabel.Text = selectedBtn.Text.ToUpper().Replace("\x20", "");
            barTitleLabel.Location = CentreLabelByPanel(barTitleLabel, barPanel);
        }

        private void ActivateButton(object sender, EventArgs _)
        {
            Button selectedBtn = (Button)sender;

            if (_activeBtn != null && _activeBtn != selectedBtn)
            {
                _activeBtn.BackColor = selectedBtn.BackColor;
                _activeBtn.ForeColor = selectedBtn.ForeColor;
                _activeBtn.Font = selectedBtn.Font;
            }
            else if (_activeBtn == selectedBtn)
            {
                return;
            }

            _activeBtn = selectedBtn;
            selectedBtn.BackColor = Palettes.GetNextRandom(rnd);
            selectedBtn.ForeColor = Color.White;
            selectedBtn.Font = new Font(selectedBtn.Font.FontFamily, 10.5F, selectedBtn.Font.Style,
                selectedBtn.Font.Unit, 0);

            DesignPanels(Palettes.GetLast(), Palettes.GetLastDarkness(15), selectedBtn);
        }

        private void OpenSubform(Form subform)
        {
            if (_activeForm != null)
            {
                if (_activeForm.GetType() != subform.GetType())
                    _activeForm.Close();
                else
                    return;
            }

            _activeForm = subform;
            subform.TopLevel = false;
            mainPanel.Controls.Add(subform);
            subform.Dock = DockStyle.Fill;
            subform.BringToFront();
            subform.Show();

            dataManagerPanel.Visible = false;
            closeSubformBtn.Visible = true;
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

        private void CloseSubformBtn_Click(object sender, EventArgs e)
        {
            _activeForm?.Close();
            closeSubformBtn.Visible = false;
            dataManagerPanel.Visible = true;
            _activeBtn.BackColor = primaryColor;
            _activeBtn.Font = new Font(_activeBtn.Font.FontFamily, 8.25F, _activeBtn.Font.Style, _activeBtn.Font.Unit, 0);
            _activeBtn = null;
            _activeForm = null;

            barPanel.BackColor = primaryColor;
            menuLogoPanel.BackColor = secondaryColor;
            barTitleLabel.Text = @"Homepage".ToUpper();
            barTitleLabel.Location = CentreLabelByPanel(barTitleLabel, barPanel);
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                @"Importing the database will completely erase the existing database. " +
                @"Are you sure you really want to import a new one?", @"Confirmation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = @"Select the json file to import",
                Filter = @"JSON files (*.json)|*.json"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;
            try
            {
                Importer.Import(ofd.FileName);
                MessageBox.Show(@"The data were inserted into tables.", @"Imported", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Do you want to export this database in json format?",
                @"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                try
                {
                    Exporter.Export();
                    MessageBox.Show($@"The database is exported and saved to the project.
Path: {Exporter.DefaultPath}", @"Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}