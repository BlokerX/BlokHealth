using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            LabelProductName.Text = TheProduct.Name;
            DescribeTextBox.Text = TheProduct.Describe;

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
                ExampleImagePictureBox.Image = Image.FromFile(@TheProduct.ExampleImagePath);
            }
            else
            {
                ExampleImagePictureBox.Image = BlokHealth.Properties.Resources.brak_zdjęcia;
            }
            // ładowanie comboboksów
        }

        // Dziedziczone
        private readonly string SystemDriveName;
        private readonly string MyProductFolderPath;
        private readonly string ImagesFolderPath;
        private readonly Product TheProduct;

        // Tutejsze
        private string SourcePathToImage = "";

        private void ButtonWybierzObrazek_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog()
            //{
            //    InitialDirectory = SystemDriveName,
            //    Filter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg|All files (*.*)|*.*",
            //    FilterIndex = 1,
            //    RestoreDirectory = true
            //};

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // Wersja z otwieraniem pliku
            //    //ExampleImagePictureBox.Image = Image.FromFile(openFileDialog.FileName);

            //    // Wersja bez otwierania pliku
            //    using (Stream sr = File.OpenRead(@openFileDialog.FileName))
            //    {
            //        ExampleImagePictureBox.Image = Image.FromStream(sr);
            //    }


            //    SourcePathToImage = openFileDialog.FileName;
            //}
            //TODO problem Z użyciem
        }

        private void ButtonSaveDiferencesProduct_Click(object sender, EventArgs e)
        {
            if (File.Exists($@"{MyProductFolderPath}/{TheProduct.Name}.txt"))
            {
                //Zmienne do zapisu
                string pathToImage = "";

                //if (SourcePathToImage != "" && SourcePathToImage != TheProduct.ExampleImagePath && File.Exists(SourcePathToImage))
                //{
                //    File.Delete($@"{ImagesFolderPath}\{TheProduct.Name}.png");
                //    System.IO.File.Copy
                //    (
                //        @SourcePathToImage,
                //        $@"{ImagesFolderPath}\{TheProduct.Name}.png",
                //        false
                //    );
                //    pathToImage = $@"{ImagesFolderPath}\{TheProduct.Name}.png";
                //}
                //TODO problem Z użyciem

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
                        //File.Delete(TheProduct.ExampleImagePath);
                        //TODO problem Z użyciem
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
            //TODO problem Z użyciem
            //SourcePathToImage = "Reset";
            //ExampleImagePictureBox.Image = BlokHealth.Properties.Resources.brak_zdjęcia;
        }
    }
}
