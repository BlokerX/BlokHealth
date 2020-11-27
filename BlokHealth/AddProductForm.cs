using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlokHealth
{
    public partial class AddProductForm : Form
    {
        public AddProductForm(string systemDriveName, string FolderOfProducts, string FolderOfImages)
        {
            InitializeComponent();
            MyProductFolderPath = FolderOfProducts;
            ImagesFolderPath = FolderOfImages;
            SystemDriveName = systemDriveName;
        }
        // TODO dodaj ikonę
        private void AddProductForm_Load(object sender, EventArgs e)
        {
            ControlBox_Loading();
            EnergyValueVaribleComboBox.SelectedIndex = 0;
            ProteinVaribleComboBox.SelectedIndex = 0;
            FatVaribleComboBox.SelectedIndex = 0;
            CarbonohydratesVaribleComboBox.SelectedIndex = 0;
            FiberVaribleComboBox.SelectedIndex = 0;
        }

        #region ControlBoxPanel

        #region Drag window

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private bool CloseBox = true;

        private void ControlBox_MouseMove_Drag(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ControlBox_Loading()
        {
            // Icon settings
            if (this.ShowIcon == true)
            {
                ControlBoxIconPanel.Visible = true;
                ControlBoxIcon.Image = this.Icon.ToBitmap();
            }
            else if (this.ShowIcon == false)
            {
                ControlBoxIconPanel.Visible = false;
                ControlBoxTextLabel.Location = new Point(6, 9);
            }

            #region Minimized and maximized settings
            //Close
            if (this.CloseBox == true)
            {
                ControlBoxCloseButton.Visible = true;
            }
            else if (this.CloseBox == false)
            {
                ControlBoxCloseButton.Visible = false;
            }
            //Minimize
            if (this.MinimizeBox == true)
            {
                ControlBoxMinimizeButton.Visible = true;
            }
            else if (this.MinimizeBox == false)
            {
                ControlBoxMinimizeButton.Visible = false;
            }
            //Maximize
            if (this.MaximizeBox == true)
            {
                ControlBoxMaximizeButton.Visible = true;
            }
            else if (this.MaximizeBox == false)
            {
                ControlBoxMaximizeButton.Visible = false;
            }
            #endregion

            ControlBoxTextLabel.Text = this.Text;
        }

        private void ControlBoxPanel_MouseMove(object sender, MouseEventArgs e)
        {
            ControlBox_MouseMove_Drag(e);
        }

        private void PanelControlBox_MouseMove(object sender, MouseEventArgs e)
        {
            ControlBox_MouseMove_Drag(e);
        }

        private void ControlBoxTextLabel_MouseMove(object sender, MouseEventArgs e)
        {
            ControlBox_MouseMove_Drag(e);
        }

        private void ControlBoxTextPanel_MouseMove(object sender, MouseEventArgs e)
        {
            ControlBox_MouseMove_Drag(e);
        }

        private void ControlBoxCloseButton_Click(object sender, EventArgs e)
        {
            // Jeśli zamykasz tylko okno:
            this.Close();

            // Jeśli zamykasz całą aplikację:
            //Application.Exit();
        }

        private void ControlBoxMinimizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void ControlBoxMaximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        #endregion

        // Dziedziczone
        private readonly string SystemDriveName;
        private readonly string MyProductFolderPath;
        private readonly string ImagesFolderPath;

        // Zdjęcia
        Bitmap ExampleImgBitmap;
        MemoryStream msForExampleImg = new MemoryStream();

        // Tutejsze
        private string SourcePathToImage;

        private void ButtonWybierzObrazek_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = SystemDriveName,
                Filter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    msForExampleImg.SetLength(0);
                    try
                    {

                        using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                        {
                            fs.CopyTo(msForExampleImg);
                        }
                        ExampleImgBitmap = new Bitmap(msForExampleImg, true);
                        ExampleImagePictureBox.Image = ExampleImgBitmap;

                        SourcePathToImage = openFileDialog.FileName;
                    }
                    catch
                    {
                        ExampleImgBitmap = new Bitmap(BlokHealth.Properties.Resources.brak_zdjęcia);
                        ExampleImagePictureBox.Image = ExampleImgBitmap;

                        SourcePathToImage = "";
                    }
                }
            }
            catch (System.UnauthorizedAccessException) //TODO System.UnauthorizedAccessException problem
            {
                MessageBox.Show("Ta funkcja aplikacji wymaga dostępu do plików, upewnij się że twój antywirus nie blokuje jej tego!\n",
                                "Brak dostępu do plików",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (System.ArgumentNullException) //TODO System.ArgumentNullException problem
            {
                msForExampleImg.SetLength(0);
                msForExampleImg = new MemoryStream();
                ExampleImgBitmap = new Bitmap(BlokHealth.Properties.Resources.brak_zdjęcia);
                MessageBox.Show("Ta funkcja aplikacji wymaga dostępu do plików, upewnij się że twój antywirus nie blokuje jej tego!\n",
                                "Brak dostępu do plików",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            // Resetowanie ostrzeżeń
            LabelInfoPodajInnaNazwe.Visible = false;
            LabelInfoPodajNazwe.Visible = false;

            // Zabezpieczenie przed szkodliwymi znakami
            ProductNameTextBox.Text = ProductNameTextBox.Text.Trim('/', '\\', ':', '*', '?', '"', '<', '>', '|');

            // Procedura dodawania
            if (ProductNameTextBox.Text != "" && !File.Exists($@"{MyProductFolderPath}\{ProductNameTextBox.Text}.txt"))
            {
                //Zmienne do zapisu
                string pathToImage = "";

                if (File.Exists(SourcePathToImage))
                {
                    System.IO.File.Copy
                    (
                        @SourcePathToImage,
                        $@"{ImagesFolderPath}\{ProductNameTextBox.Text}.png",
                        true
                    );
                    pathToImage = $@"{ImagesFolderPath}\{ProductNameTextBox.Text}.png";
                }

                //Twożenie oraz wpisywanie danych do pliku zrzutu
                StreamWriter sw = File.CreateText($@"{MyProductFolderPath}\{ProductNameTextBox.Text}.txt");

                sw.WriteLine(ProductNameTextBox.Text);
                sw.WriteLine(DescribeTextBox.Text.Replace('\n', ' ').Replace('\r', ' ').Replace("  ", " "));

                sw.WriteLine(EnergyValueTextBox.Text);
                sw.WriteLine(EnergyValueVaribleComboBox.Text);

                sw.WriteLine(ProteinTextBox.Text);
                sw.WriteLine(ProteinVaribleComboBox.Text);

                sw.WriteLine(FatTextBox.Text);
                sw.WriteLine(FatVaribleComboBox.Text);

                sw.WriteLine(CarbonohydratesTextBox.Text);
                sw.WriteLine(CarbonohydratesVaribleComboBox.Text);

                sw.WriteLine(FiberTextBox.Text);
                sw.WriteLine(FiberVaribleComboBox.Text);

                sw.WriteLine(Vitamin1TextBox.Text);
                sw.WriteLine(Vitamin2TextBox.Text);
                sw.WriteLine(Vitamin3TextBox.Text);
                sw.WriteLine(Vitamin4TextBox.Text);
                sw.WriteLine(Vitamin5TextBox.Text);
                sw.WriteLine(Vitamin6TextBox.Text);
                sw.WriteLine(Vitamin7TextBox.Text);
                sw.WriteLine(Vitamin8TextBox.Text);

                sw.WriteLine(Mineral1TextBox.Text);
                sw.WriteLine(Mineral2TextBox.Text);
                sw.WriteLine(Mineral3TextBox.Text);
                sw.WriteLine(Mineral4TextBox.Text);
                sw.WriteLine(Mineral5TextBox.Text);
                sw.WriteLine(Mineral6TextBox.Text);
                sw.WriteLine(Mineral7TextBox.Text);

                if (File.Exists(@pathToImage))
                {
                    sw.WriteLine(pathToImage);
                }

                sw.Close();

                this.Close();
            }
            else if (ProductNameTextBox.Text == "")
            {
                LabelInfoPodajNazwe.Visible = true;
            }
            else if (File.Exists($@"{MyProductFolderPath}\{ProductNameTextBox.Text}.txt"))
            {
                LabelInfoPodajInnaNazwe.Visible = true;
            }
        }

    }
}
