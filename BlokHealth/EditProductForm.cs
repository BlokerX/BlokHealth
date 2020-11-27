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
    public partial class EditProductForm : Form
    {
        public EditProductForm(string systemDriveName, string FolderOfProducts, string FolderOfImages, Product theProduct)
        {
            InitializeComponent();
            TheProduct = theProduct;
            MyProductFolderPath = FolderOfProducts;
            ImagesFolderPath = FolderOfImages;
            SystemDriveName = systemDriveName;
        }
        // TODO dodaj ikonę
        private void EditProductForm_Load(object sender, EventArgs e)
        {
            ControlBox_Loading();

            LabelProductName.Text = TheProduct.Name;
            DescribeTextBox.Text = TheProduct.Describe;

            #region LoadProduct
            EnergyValueTextBox.Text = TheProduct.EnergyValue.ToString();
            if (TheProduct.EnergyValueVarible == "kcal")
            {
                EnergyValueVaribleComboBox.SelectedIndex = 0;
            }
            else if (TheProduct.EnergyValueVarible == "kJ")
            {
                EnergyValueVaribleComboBox.SelectedIndex = 1;
            }

            ProteinTextBox.Text = TheProduct.Protein.ToString();
            if (TheProduct.ProteinVarible == "g")
            {
                ProteinVaribleComboBox.SelectedIndex = 0;
            }

            FatTextBox.Text = TheProduct.Fat.ToString();
            if (TheProduct.FatVarible == "g")
            {
                FatVaribleComboBox.SelectedIndex = 0;
            }

            CarbonohydratesTextBox.Text = TheProduct.Carbohydrates.ToString();
            if (TheProduct.CarbohydratesVarible == "g")
            {
                CarbonohydratesVaribleComboBox.SelectedIndex = 0;
            }

            if (TheProduct.FiberVarible == "g")
            {
                FiberTextBox.Text = TheProduct.Fiber.ToString();
            }
            FiberVaribleComboBox.SelectedIndex = 0;

            string[] vit = TheProduct.Vitamins.Split('\n');

            Vitamin1TextBox.Text = vit[0];
            Vitamin2TextBox.Text = vit[1];
            Vitamin3TextBox.Text = vit[2];
            Vitamin4TextBox.Text = vit[3];
            Vitamin5TextBox.Text = vit[4];
            Vitamin6TextBox.Text = vit[5];
            Vitamin7TextBox.Text = vit[6];
            Vitamin8TextBox.Text = vit[7];

            string[] min = TheProduct.Minerals.Split('\n');

            Mineral1TextBox.Text = min[0];
            Mineral2TextBox.Text = min[1];
            Mineral3TextBox.Text = min[2];
            Mineral4TextBox.Text = min[3];
            Mineral5TextBox.Text = min[4];
            Mineral6TextBox.Text = min[5];
            Mineral7TextBox.Text = min[6];

            if (File.Exists(TheProduct.ExampleImagePath))
            {
                msForExampleImg.SetLength(0);
                using (FileStream fs = new FileStream(TheProduct.ExampleImagePath, FileMode.Open))
                {
                    fs.CopyTo(msForExampleImg);
                }
                ExampleImgBitmap = new Bitmap(msForExampleImg, true);
                ExampleImagePictureBox.Image = ExampleImgBitmap;
            }
            else
            {
                ExampleImagePictureBox.Image = BlokHealth.Properties.Resources.brak_zdjęcia;
            }
            // ładowanie comboboksów
            #endregion
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
        private readonly Product TheProduct;

        // Tutejsze
        private string SourcePathToImage = "";

        // Zdjęcia
        Bitmap ExampleImgBitmap;
        MemoryStream msForExampleImg = new MemoryStream();

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
                    try
                    {
                        msForExampleImg.SetLength(0);
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
                        msForExampleImg.SetLength(0);
                        using (FileStream fs = new FileStream(TheProduct.ExampleImagePath, FileMode.Open))
                        {
                            fs.CopyTo(msForExampleImg);
                        }
                        ExampleImgBitmap = new Bitmap(msForExampleImg, true);
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

        private void ButtonSaveDiferencesProduct_Click(object sender, EventArgs e)
        {
            if (File.Exists($@"{MyProductFolderPath}/{TheProduct.Name}.txt"))
            {
                //Zmienne do zapisu
                string pathToImage = "";

                if (SourcePathToImage != "" && SourcePathToImage != TheProduct.ExampleImagePath && File.Exists(SourcePathToImage))
                {
                    File.Delete($@"{ImagesFolderPath}\{TheProduct.Name}.png");
                    System.IO.File.Copy
                    (
                        @SourcePathToImage,
                        $@"{ImagesFolderPath}\{TheProduct.Name}.png",
                        true
                    );
                    pathToImage = $@"{ImagesFolderPath}\{TheProduct.Name}.png";
                }

                //Twożenie oraz wpisywanie danych do pliku zrzutu
                StreamWriter sw = File.CreateText($@"{MyProductFolderPath}\{TheProduct.Name}.txt");

                sw.WriteLine(TheProduct.Name);
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

                if (SourcePathToImage == "Reset")
                {
                    sw.WriteLine("DomyslnyObraz");
                    if (File.Exists(TheProduct.ExampleImagePath))
                    {
                        File.Delete(TheProduct.ExampleImagePath);
                    }
                }
                else if (File.Exists(@pathToImage))
                {
                    sw.WriteLine(pathToImage);
                }
                else if (File.Exists($@"{TheProduct.ExampleImagePath}"))
                {
                    sw.WriteLine(TheProduct.ExampleImagePath);
                }

                sw.Close();

            }
            else if (!File.Exists($@"{MyProductFolderPath}/{TheProduct.Name}.txt"))
            {
                // Podany plik nie istnieje
            }

            this.Close();
        }

        private void ButtonResetImage_Click(object sender, EventArgs e)
        {
            SourcePathToImage = "Reset";
            ExampleImagePictureBox.Image = BlokHealth.Properties.Resources.brak_zdjęcia;
        }

    }
}
