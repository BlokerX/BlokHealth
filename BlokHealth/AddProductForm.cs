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
    public partial class AddProductForm : Form
    {
        public AddProductForm(string systemDriveName, string FolderOfProducts, string FolderOfImages)
        {
            InitializeComponent();
            MyProductFolderPath = FolderOfProducts;
            ImagesFolderPath = FolderOfImages;
            SystemDriveName = systemDriveName;
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            EnergyValueVaribleComboBox.SelectedIndex = 0;
            ProteinVaribleComboBox.SelectedIndex = 0;
            FatVaribleComboBox.SelectedIndex = 0;
            CarbonohydratesVaribleComboBox.SelectedIndex = 0;
            FiberVaribleComboBox.SelectedIndex = 0;
        }

        // Dziedziczone
        private readonly string SystemDriveName;
        private readonly string MyProductFolderPath;
        private readonly string ImagesFolderPath;

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

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                SourcePathToImage = openFileDialog.FileName;
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            // Resetowanie ostrzeżeń
            LabelInfoPodajInnaNazwe.Visible = false;
            LabelInfoPodajNazwe.Visible = false;

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
                        false
                    );
                    pathToImage = $@"{ImagesFolderPath}\{ProductNameTextBox.Text}.png";
                }

                //Twożenie oraz wpisywanie danych do pliku zrzutu
                StreamWriter sw = File.CreateText($@"{MyProductFolderPath}\{ProductNameTextBox.Text}.txt");
                // TODO dodać zabezpieczenie przed wpisaniem inntch znaków w nazwie

                sw.WriteLine(ProductNameTextBox.Text);
                sw.WriteLine(DescribeTextBox.Text);//TODO dodaj pominięcie enterów

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
