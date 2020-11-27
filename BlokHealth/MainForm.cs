using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlokHealth
{
    public partial class MainForm : Form
    {
        #region Open_instructions
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region Standard_load_function

            // Select Convert Values
            ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;
            ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 0;

            // Procedura Bezpieczeństwa and set varibles
            VariblesDefaultConstructor();
            CheckProgramDiresArchitecture();

            // Prepare Products
            LoadingMyProducts();
            LoadingProductObjects();
            ProductAlphabeticSort();
            SelectActiveProduct();

            //Health Curiosity
            LoadingHealthCuriosity();

            //HealthCuriosityWork
            Timer1.Start();

            //Notebook
            string aSomeText;
            if (!File.Exists(NotebookFilePath))
            {
                StreamWriter sw = File.CreateText(NotebookFilePath);
                sw.Write(NotebookTextBox.Text);
                File.SetAttributes(NotebookFilePath, FileAttributes.Normal);

                sw.Close();
            }
            else
            {
                StreamReader sr = File.OpenText(NotebookFilePath);
                string s = "";

                string[] lines = System.IO.File.ReadAllLines(NotebookFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    s += lines[i];
                    if (i + 1 != lines.Length)
                    {
                        s += "\r\n";
                    }
                }

                aSomeText = s;

                sr.Close();
                NotebookTextBox.Text = aSomeText;
            }

            #endregion
            ControlBox_Loading();
        }

        void CheckProgramDiresArchitecture()
        {
            if (!Directory.Exists(ProgramMainFolderPath))
            {
                Directory.CreateDirectory(ProgramMainFolderPath);
            }

            if (!Directory.Exists(NotebookFileFolderPath))
            {
                Directory.CreateDirectory(NotebookFileFolderPath);
            }

            if (!Directory.Exists(MyProductFolderPath))
            {
                Directory.CreateDirectory(MyProductFolderPath);
            }

            if (!Directory.Exists(ImagesFolderPath))
            {
                Directory.CreateDirectory(ImagesFolderPath);
            }
        }

        #endregion

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
            //this.Close();

            // Jeśli zamykasz całą aplikację:
            Application.Exit();
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

        #region Varibles
        // Calcularor&Convert varibles
        string CalculatorA = "", CalculatorB = "", CalculatorEqual = "1";
        char CalculatorTypeOfOperation = ' ';

        // ListOfProducts varibles
        readonly List<Product> Product = new List<Product>();
        int ProductNumber = 0;

        // HealthCuriosity varibles
        readonly List<string> HealthCuriosity = new List<string>();
        int IndeksOfHealthCuriosty;

        // Paths
        string SystemDriveName = "-";
        string ProgramMainFolderPath;
        string MyProductFolderPath;
        string NotebookFileFolderPath;
        string NotebookFilePath;
        string ImagesFolderPath;

        // Image varibles
        Bitmap ExampleImgBitmap;
        MemoryStream msForExampleImg = new MemoryStream();

        void VariblesDefaultConstructor()
        {
            #region DriveName
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    if (Directory.Exists($@"{d.Name}\Users\{Environment.UserName}") && Directory.Exists($@"{d.Name}\Windows"))
                    { SystemDriveName = d.Name; continue; }
                }
            }
            #endregion

            ProgramMainFolderPath = $@"{SystemDriveName}Users\{Environment.UserName}\BlokHealth";
            MyProductFolderPath = $@"{ProgramMainFolderPath}\MyProducts";
            NotebookFileFolderPath = $@"{ProgramMainFolderPath}\Notatki";
            NotebookFilePath = $@"{NotebookFileFolderPath}\NotatkaBlokHealth.txt";
            ImagesFolderPath = $@"{ProgramMainFolderPath}\Images";
        }

        #endregion

        #region First_panel_(left)

        #region InformationAboutApplication

        private void ButtonInformationAboutApplication_Click(object sender, EventArgs e)
        {
            InformationAboutApplication informationAboutApplication = new InformationAboutApplication();
            informationAboutApplication.Show();
        }

        #endregion

        private void NotebookTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(NotebookFilePath))
            {
                // Create a file to write to.
                StreamWriter sw = File.CreateText(NotebookFilePath);
                sw.WriteLine(NotebookTextBox.Text);

                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(NotebookFilePath, false);
                sw.WriteLine(NotebookTextBox.Text);

                sw.Close();
            }
        }

        #region HealthCuriosity

        void LoadingHealthCuriosity()
        {
            HealthCuriosity.Add("Najlepsza dieta dla Ciebie jest ta, która działa dla Ciebie i możesz się jej trzymać na dłuższą metę.");
            HealthCuriosity.Add("Od setek lat sport stanowi jedną z form aktywności człowieka. Na początku był zarezerwowany dla bogatych elit mających czas i pieniądze na jego uprawianie. Obecnie każdy może się nim zająć i zostać biegaczem w parku, pływakiem na miejskim lub szkolnym basenie oraz piłkarzem na ogólnodostępnym boisku.");
            HealthCuriosity.Add("Błonnik pomaga organizmowi trawić pokarm. Znajduje się w warzywach, pełnych ziarnach i owocach.");
            HealthCuriosity.Add("Witaminy pomagają Twojemu organizmowi zachować zdrowie i zwalczać choroby. Witaminy znajdują się w owocach i warzywach.");
            HealthCuriosity.Add("Cytryna ma więcej cukru niż truskawka. Mają też tak dużo kwasu cytrynowego, że nie zauważamy, jakie są słodkie.");
            HealthCuriosity.Add("Sporty z piłką, frisbee i innymi akcesoriami mogą poprawić Twoją orientację wzrokowo-przestrzenną (a ta przydaje się przy korzystaniu z mapy, omijaniu korków czy pakowaniu walizki). Aktywności wymagające koordynacji pobudzają odpowiedzialne za to obszary mózgu.");
            HealthCuriosity.Add("Banany to nie jedyne owoce z potasem. Awokado ma dwa razy więcej potasu niż banany i jest bogate w jednonienasycone tłuszcze, które łatwo spalają się jako energia.");
            HealthCuriosity.Add("Badania wykazały, że sport jest jednym z czynników odstręczających od palenia tytoniu. Młode osoby bardzo aktywne fizycznie później niż ich rówieśnicy sięgają po pierwszego papierosa. Zwiększają w ten sposób szansę, że w przyszłości będą osobami niepalącymi.");
            HealthCuriosity.Add("Białko, które znajduje się w mięsie, produktach mlecznych, fasoli i rybach, buduje mięśnie i naprawia uszkodzenia w Twoim ciele.");
            HealthCuriosity.Add("Aktywność fizyczna musi być wtopiona w styl życia, nie może być czymś od czasu do czasu, czymś odświętnym, ale powinna towarzyszyć człowiekowi na co dzień i możliwie przez całe życie.");
            HealthCuriosity.Add("Jedz dużo owoców i warzyw. Zaleca się spożycie co najmniej 5 porcji różnych owoców i warzyw dziennie. Mogą one być świeże, mrożone, konserwowane lub suszone. Porcja świeżych, konserwowanych lub mrożonych owoców i warzyw wynosi 80 g. Porcja suszonych owoców wynosi 30g.");
            HealthCuriosity.Add("Zdrowa dieta może sprawić, że skóra będzie błyszczeć.");
            HealthCuriosity.Add("Pomidory nie powinny być przechowywane w lodówce, ponieważ tracą swój smak.");
            HealthCuriosity.Add("Banany z zieloną końcówką są dla Ciebie lepsze niż banany dojrzewające. Banany zawierają dużo cukru i jeśli są spożywane z białkiem, poziom insuliny jest normalizowany.");
            HealthCuriosity.Add("Naklejki na owocach są jadalne. Chociaż logiczną rzeczą do zrobienia jest zdjąć je, są one wykonane z papieru jadalnego, a nawet klej jest spożywczy, na wszelki wypadek, gdybyś przypadkowo zjadł naklejkę.");
            HealthCuriosity.Add("Ogórki składają się w 96 % z wody. Tak jak sałata i cukinia.");
            HealthCuriosity.Add("Na świecie jest około 10 tysięcy różnych rodzajów jabłek.");
        }

        private void ButtonNextHealthCuriosity_Click(object sender, EventArgs e)
        {
            Timer1.Stop();

            if (IndeksOfHealthCuriosty + 1 < HealthCuriosity.Count)
            {
                IndeksOfHealthCuriosty++;
            }
            else
            {
                IndeksOfHealthCuriosty = 0;
            }

            LabelHealthCuriosity.Text = HealthCuriosity[IndeksOfHealthCuriosty];

            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Waiting instruction
            if (IndeksOfHealthCuriosty + 1 < HealthCuriosity.Count)
            {
                IndeksOfHealthCuriosty++;
            }
            else
            {
                IndeksOfHealthCuriosty = 0;
            }

            // Set Text
            LabelHealthCuriosity.Text = HealthCuriosity[IndeksOfHealthCuriosty];
        }

        #endregion

        private void ButtonCwiczennik_Click(object sender, EventArgs e)
        {
            ExerciseDictonary exerciseDictonary = new ExerciseDictonary();
            exerciseDictonary.Show();
        }

        #endregion

        #region Calculator&Converts

        #region Calculator

        private void CalculatorOperation(double liczba)
        {
            if (CalculatorTypeOfOperation == ' ')
            {
                CalculatorA += liczba;
                CalculatorTextBox.Text = CalculatorA;
            }
            else
            {
                CalculatorB += liczba;
                CalculatorTextBox.Text = CalculatorB;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CalculatorOperation(1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CalculatorOperation(2);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CalculatorOperation(3);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CalculatorOperation(4);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            CalculatorOperation(5);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            CalculatorOperation(6);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            CalculatorOperation(7);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            CalculatorOperation(8);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            CalculatorOperation(9);
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            CalculatorOperation(0);
        }

        private void ButtonDecimal_Click(object sender, EventArgs e)
        {
            if (CalculatorTypeOfOperation == ' ')
            {
                if (CalculatorTextBox.Text == "0")
                {
                    CalculatorA += 0;
                }
                CalculatorA += ",";
                CalculatorTextBox.Text = CalculatorA;
            }
            else
            {
                if (CalculatorTextBox.Text == "0")
                {
                    CalculatorB += 0;
                }
                CalculatorB += ",";
                CalculatorTextBox.Text = CalculatorB;
            }
        }

        private void ButtonAddition_Click(object sender, EventArgs e)
        {
            CalculatorTypeOfOperation = '+';
            CalculatorTextBox.Text = "0";
        }

        private void ButtonSubtraction_Click(object sender, EventArgs e)
        {
            CalculatorTypeOfOperation = '-';
            CalculatorTextBox.Text = "0";
        }

        private void ButtonMultiplication_Click(object sender, EventArgs e)
        {
            CalculatorTypeOfOperation = '*';
            CalculatorTextBox.Text = "0";
        }

        private void ButtonDivision_Click(object sender, EventArgs e)
        {
            CalculatorTypeOfOperation = '/';
            CalculatorTextBox.Text = "0";
        }

        private void ButtonClearMemoryOfCalculator_Click(object sender, EventArgs e)
        {
            CalculatorA = "";
            CalculatorB = "";
            CalculatorEqual = "1";
            CalculatorTextBox.Text = "0";
            LabelConvertEquals.Text = "";
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            // Bezpieczniki
            if (CalculatorA == "")
                CalculatorA = "0";

            if (CalculatorB == "")
                CalculatorB = "0";

            switch (CalculatorTypeOfOperation)
            {
                case '+':
                    CalculatorEqual = (Convert.ToDouble(CalculatorA) + Convert.ToDouble(CalculatorB)).ToString();
                    CalculatorTextBox.Text = CalculatorEqual;
                    break;

                case '-':
                    CalculatorEqual = (Convert.ToDouble(CalculatorA) - Convert.ToDouble(CalculatorB)).ToString();
                    CalculatorTextBox.Text = CalculatorEqual;
                    break;

                case '*':
                    CalculatorEqual = (Convert.ToDouble(CalculatorA) * Convert.ToDouble(CalculatorB)).ToString();
                    CalculatorTextBox.Text = CalculatorEqual;
                    break;

                case '/':
                    if (CalculatorB != "0")
                    {
                        CalculatorEqual = (Convert.ToDouble(CalculatorA) / Convert.ToDouble(CalculatorB)).ToString();
                        CalculatorTextBox.Text = CalculatorEqual;
                    }
                    else
                    {
                        CalculatorTextBox.Text = "NIE DZIELIMY PRZEZ 0!";
                        CalculatorA = "";
                        CalculatorB = "";
                        CalculatorEqual = "1";
                    }
                    break;
            }

            CalculatorTypeOfOperation = ' ';
            CalculatorA = CalculatorEqual;
            CalculatorB = "";
        }
        #endregion

        #region Converts

        private void ButtonConvertEqals_Click(object sender, EventArgs e)
        {
            try
            {
                double w = Convert.ToDouble(CalculatorTextBox.Text);
                string TheUnit = "";
                if (ButtonTypeOfConvert.Text == "Energia")
                {
                    TheUnit = "kJ";
                    switch (ComboBoxTypeOfValueBeforeConvert.SelectedIndex)
                    {
                        case 0: //Kilodżule(kJ)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilodżule(kJ)
                                    TheUnit = "kJ";
                                    break;
                                case 1: // Kilokalorie(kcal)
                                    TheUnit = "kcal";
                                    w *= 0.238846;
                                    break;
                                case 2: // Dżule(J)
                                    TheUnit = "J";
                                    w *= 1000;
                                    break;
                                case 3: // Kalorie(cal)
                                    TheUnit = "cal";
                                    w *= 238.85;
                                    break;
                            }
                            break;

                        case 1: //Kilodżule(kcal)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilodżule(kJ)
                                    TheUnit = "kJ";
                                    w /= 0.238846;
                                    break;
                                case 1: // Kilokalorie(kcal)
                                    TheUnit = "kcal";
                                    break;
                                case 2: // Dżule(J)
                                    TheUnit = "J";
                                    w *= 4186.8;
                                    break;
                                case 3: // Kalorie(cal)
                                    TheUnit = "cal";
                                    w *= 1000;
                                    break;
                            }
                            break;

                        case 2: //Dżule(J)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilodżule(kJ)
                                    TheUnit = "kJ";
                                    w /= 1000;
                                    break;
                                case 1: // Kilokalorie(kcal)
                                    TheUnit = "kcal";
                                    w /= 4186.8;
                                    break;
                                case 2: // Dżule(J)
                                    TheUnit = "J";
                                    break;
                                case 3: // Kalorie(cal)
                                    TheUnit = "cal";
                                    w *= 0.238846;
                                    break;
                            }
                            break;

                        case 3: //Kalorie(cal)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilodżule(kJ)
                                    TheUnit = "kJ";
                                    w *= 0.0041868;
                                    break;
                                case 1: // Kilokalorie(kcal)
                                    TheUnit = "kcal";
                                    w *= 1000;
                                    break;
                                case 2: // Dżule(J)
                                    TheUnit = "J";
                                    w *= 4.1868;
                                    break;
                                case 3: // Kalorie(cal)
                                    TheUnit = "cal";
                                    break;


                            }
                            break;

                            //Kilodżule(kJ)
                            //Kilokalorie(kcal)
                            //Dżule(J)
                            //Kalorie(cal)
                    }
                }
                else if (ButtonTypeOfConvert.Text == "Masa")
                {
                    TheUnit = "kg";
                    switch (ComboBoxTypeOfValueBeforeConvert.SelectedIndex)
                    {
                        case 0: //Kilogramy(kg)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    w *= 100;
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    w *= 1000;
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    w *= 1000000;
                                    break;
                                case 4: // Litry_wody(l)
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    w *= 1000;
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    w /= 1000;
                                    break;
                            }
                            break;

                        case 1: //Dekagramy(dag)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    w /= 100;
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    w *= 10;
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    w *= 10000;
                                    break;
                                case 4: // Litry_wody(l)
                                    w /= 100;
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    w *= 10;
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    w /= 100000;
                                    break;
                            }
                            break;

                        case 2: //Gramy(g)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    w /= 1000;
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    w /= 10;
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    w *= 1000;
                                    break;
                                case 4: // Litry_wody(l)
                                    w /= 1000;
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    w /= 1000000;
                                    break;
                            }
                            break;

                        case 3: //Miligramy(kg)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    w /= 1000000;
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    w /= 100;
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    w *= 1000;
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    break;
                                case 4: // Litry_wody(l)
                                    w /= 1000000;
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    w /= 1000;
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    w /= 1000000000;
                                    break;
                            }
                            break;

                        case 4: //Litry_wody(l)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    w *= 100;
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    w *= 1000;
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    w *= 1000000;
                                    break;
                                case 4: // Litry_wody(l)
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    w *= 1000;
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    w /= 1000;
                                    break;
                            }
                            break;

                        case 5: //Mililitry_wody(ml)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    w /= 1000;
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    w /= 10;
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    w *= 1000;
                                    break;
                                case 4: // Litry_wody(l)
                                    w /= 1000;
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    w /= 1000000;
                                    break;
                            }
                            break;

                        case 6: //Tony(t)
                            switch (ComboBoxTypeOfValueAfterConvert.SelectedIndex)
                            {
                                case 0: // Kilogramy(kg)
                                    w *= 1000;
                                    TheUnit = "kg";
                                    break;
                                case 1: // Dekagramy(dag)
                                    TheUnit = "dag";
                                    w *= 100000;
                                    break;
                                case 2: // Gramy(g)
                                    TheUnit = "g";
                                    w *= 1000000;
                                    break;
                                case 3: // Miligramy(mg)
                                    TheUnit = "mg";
                                    w *= 1000000000;
                                    break;
                                case 4: // Litry_wody(l)
                                    TheUnit = "l";
                                    break;
                                case 5: // Mililitry_wody(ml)
                                    TheUnit = "ml";
                                    w *= 1000000;
                                    break;
                                case 6: // Tony(t)
                                    TheUnit = "t";
                                    break;
                            }
                            break;

                            //Spis tresci (indeksy):
                            //-----------------
                            //0.Kilogramy (kg)
                            //1.Dekagramy(dag)
                            //2.Gramy(g)
                            //3.Miligramy(mg)
                            //4.Litry wody(l)
                            //5.Mililitry wody(ml)
                            //6.Tony(t)
                            //-----------------
                    }
                }
                LabelConvertEquals.Text = w.ToString() + TheUnit;
            }
            catch
            {
                LabelConvertEquals.Text = "Nie można wykonać konwersji";
            }
        }
        private void ButtonTypeOfConvert_Click(object sender, EventArgs e)
        {
            if (ButtonTypeOfConvert.Text == "Energia")
            {

                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
                ButtonTypeOfConvert.Text = "Masa";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 0;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;

            }
            else if (ButtonTypeOfConvert.Text == "Masa")
            {
                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(90)))), ((int)(((byte)(74)))));
                ButtonTypeOfConvert.Text = "Energia";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                this.ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilodżule (kJ)",
                "Kilokalorie (kcal)",
                "Dżule (J)",
                "Kalorie (cal)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 0;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                this.ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilodżule (kJ)",
                "Kilokalorie (kcal)",
                "Dżule (J)",
                "Kalorie (cal)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;

            }
        }

        #endregion

        #endregion

        #region ListOfProducts

        #region ChoseLabelValues
        private void LabelValueWartoscEnergetyczna_Click(object sender, EventArgs e)
        {
            CalculatorOperation(Product[ProductNumber].EnergyValue);
            if (ButtonTypeOfConvert.Text == "Masa")
            {
                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(90)))), ((int)(((byte)(74)))));
                ButtonTypeOfConvert.Text = "Energia";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                this.ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilodżule (kJ)",
                "Kilokalorie (kcal)",
                "Dżule (J)",
                "Kalorie (cal)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 1;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                this.ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilodżule (kJ)",
                "Kilokalorie (kcal)",
                "Dżule (J)",
                "Kalorie (cal)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 0;

            }
        }

        private void LabelValueBialko_Click(object sender, EventArgs e)
        {
            CalculatorOperation(Product[ProductNumber].Protein);
            if (ButtonTypeOfConvert.Text == "Energia")
            {

                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
                ButtonTypeOfConvert.Text = "Masa";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 2;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;

            }
        }

        private void LabelValueTluszcz_Click(object sender, EventArgs e)
        {
            CalculatorOperation(Product[ProductNumber].Fat);
            if (ButtonTypeOfConvert.Text == "Energia")
            {

                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
                ButtonTypeOfConvert.Text = "Masa";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 2;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;

            }
        }

        private void LabelValueWeglowodany_Click(object sender, EventArgs e)
        {
            CalculatorOperation(Product[ProductNumber].Carbohydrates);
            if (ButtonTypeOfConvert.Text == "Energia")
            {

                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
                ButtonTypeOfConvert.Text = "Masa";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 2;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;

            }
        }

        private void LabelValueBlonnik_Click(object sender, EventArgs e)
        {
            CalculatorOperation(Product[ProductNumber].Fiber);
            if (ButtonTypeOfConvert.Text == "Energia")
            {

                ButtonTypeOfConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(24)))), ((int)(((byte)(40)))));
                ButtonTypeOfConvert.Text = "Masa";

                ComboBoxTypeOfValueBeforeConvert.Items.Clear();
                ComboBoxTypeOfValueBeforeConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueBeforeConvert.SelectedIndex = 2;

                ComboBoxTypeOfValueAfterConvert.Items.Clear();
                ComboBoxTypeOfValueAfterConvert.Items.AddRange(new object[] {
                "Kilogramy (kg)",
                "Dekagramy (dag)",
                "Gramy (g)",
                "Miligramy (mg)",
                "Litry wody (l)",
                "Mililitry wody (ml)",
                "Tony (t)"
                });
                ComboBoxTypeOfValueAfterConvert.SelectedIndex = 1;

            }
        }

        #endregion

        private void GoNextButton_Click(object sender, EventArgs e)
        {
            if (Product.Count > ProductNumber + 1)
            {
                ProductNumber++;
            }
            else
            {
                ProductNumber = 0;
            }
            SelectActiveProduct();
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            if (ProductNumber > 0)
            {
                ProductNumber--;
            }
            else
            {
                ProductNumber = Product.Count - 1;
            }
            SelectActiveProduct();
        }

        private void ButtonOpenAddProductDialog_Click(object sender, EventArgs e)
        {
            CheckProgramDiresArchitecture();
            AddProductForm addProductForm = new AddProductForm(SystemDriveName, MyProductFolderPath, ImagesFolderPath);
            addProductForm.ShowDialog();
            Product.Clear();
            LoadingMyProducts();
            LoadingProductObjects();
            ProductAlphabeticSort();
            SelectActiveProduct();
        }

        private void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show
                ("Czy napewno chcesz usunąć ten produkt?\n" +
                "Uwaga: Nie będzie się dało go później przywrócić!",
                "Usuwanie produktu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (File.Exists($@"{MyProductFolderPath}\{Product[ProductNumber].Name}.txt"))
                {
                    // Varibles
                    string pathTo_txt_File = $@"{MyProductFolderPath}\{Product[ProductNumber].Name}.txt";
                    string pathToImage = "";

                    StreamReader sr = File.OpenText($@"{MyProductFolderPath}\{Product[ProductNumber].Name}.txt");

                    for (int i = 0; i < 28; i++) //* Numer "28" jest ważny co do linii zapisu argumentu */
                    {
                        if (i == 27)
                        {
                            pathToImage = sr.ReadLine();
                            if (!File.Exists(pathToImage))
                            {
                                pathToImage = "";
                            }
                            break;
                        }
                        sr.ReadLine();
                    }
                    sr.Close();

                    // Usuwanie
                    File.Delete(pathTo_txt_File);
                    if (File.Exists(pathToImage))
                    { File.Delete(pathToImage); }

                    // Wczytywanie ponowne
                    Product.Clear();
                    LoadingMyProducts();
                    LoadingProductObjects();
                    ProductAlphabeticSort();
                    if (ProductNumber >= Product.Count) { ProductNumber = 1; }
                    SelectActiveProduct();

                }
                else { MessageBox.Show("Nie można namieżyć pliku zapisu!", "Zła lokalizacja pliku zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        }

        private void ProductAlphabeticSort()
        {
            Product.Sort(delegate (Product x, Product y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
        }

        void LoadingProductObjects()
        {
            #region Banan
            Product.Add
                (new Product(
                    "Banan",

                    "Banan jest to jadalny owoc tropikalny, jest owocem bogatym w potas i zaleca się spożywanie go sportowcom.",

                    122,

                    1.30,

                    0.37,

                    31.9,

                    2.30,

                    "Witamina C - 18,40 mg\n" +
                    "Witamina B1 - 0,05 mg\n" +
                    "Witamina B2 - 0,05 mg\n" +
                    "Witamina B12 - 0 µg\n" +
                    "Witamina A - 56,0 µg\n" +
                    "Witamina E - 0,14 mg\n" +
                    "Witamina D - 0 µg\n" +
                    "Witamina K - 0, 70 µg",

                    "Wapń - 3, 00 mg\n" +
                    "Żelazo - 0, 60 mg\n" +
                    "Magnez - 37, 0 mg\n" +
                    "Fosfor - 34, 0 mg\n" +
                    "Potas - 499 mg\n" +
                    "Sód - 4, 00 mg\n" +
                    "Cynk - 0, 14 mg",

                    BlokHealth.Properties.Resources.banany,

                    true
                ));
            #endregion

            #region Barszcz_czerwony
            Product.Add
                (new Product(
                    "Barszcz cz.",

                    "Barszcz czerwony to jedna z najpyszniejszych polskich zup. Jest to zupa na bazie esencji buraka czerwonego. Zawiera dużo witamin oraz minerałów.",

                    18,

                    0.1,

                    0.1,

                    4.1,

                    0,

                    "Witamina C\n" +
                    "Witamina B\n" +
                    "Kwas Foliowy\n" +
                    "Witamina B12",

                    "Wapń\n" +
                    "Żelazo\n" +
                    "Magnez\n" +
                    "Fosfor\n" +
                    "Potas\n" +
                    "Sód\n" +
                    "Cynk",

                    BlokHealth.Properties.Resources.barszcz,

                    true
                ));
            #endregion

            #region Brukselka
            Product.Add
                (new Product(
                    "Brukselka",

                    "Brukselka odmiana kapusty warzywnej. Prawdopodobnie powstała ze skrzyżowania jarmużu i kapusty głowiastej w Belgii.",

                    41,

                    3.85,

                    0.40,

                    8.10,

                    3.2,

                    "Witamina C – 70 mg\n" +
                    "Tiamina – 0.122 mg\n" +
                    "Witamina E – 0.62 mg\n" +
                    "Niacyna - 0.680 mg\n" +
                    "Witamina B6  - 0.195 mg\n" +
                    "Kwas foliowy - 61.5 µg\n" +
                    "Witamina A – 760 IU\n" +
                    "Witamina K - 157.3 µg",

                    "Wapń - 42 mg\n" +
                    "Żelazo - 1.30 mg\n" +
                    "Magnez - 21.5 mg\n" +
                    "Fosfor - 60 mg mg\n" +
                    "Potas - 349 mg\n" +
                    "Sód - 23 mg\n" +
                    "Cynk - 0.37 mg",

                    BlokHealth.Properties.Resources.brukselka,

                    true
                ));
            #endregion

            #region CocaCola
            Product.Add
                (new Product(
                    "CocaCola",

                    "Cola to słodki napój gazowany, początkowo wytwarzany z soku z owoców drzewa koli i krzewu koki, zmieszanych z wodą sodową.",

                    37,

                    0.07,

                    0.02,

                    9.56,

                    0.0,

                    "Witamina A - 0\n" +
                    "Witamina C - 0\n" +
                    "Witamina D - 0\n" +
                    "Witamina E - 0\n" +
                    "Witamina K - 0\n" +
                    "Betaina - 0.1 mg",

                    "Wapń - 2 mg\n" +
                    "Żelazo - 0.11 mg\n" +
                    "Magnez - 0 mg\n" +
                    "Fosfor - 10 mg\n" +
                    "Potas - 2 mg\n" +
                    "Sód - 4 mg\n" +
                    "Cynk - 0.02 mg",

                    BlokHealth.Properties.Resources.coca_cola,

                    true
                ));
            #endregion

            #region Fasola_szparagowa
            Product.Add
                (new Product(
                    "Fasola",

                    "Fasolka szparagowa lub inaczej zwyczajna, należy do warzyw chętnie uprawianych na naszych działkach. Jest bowiem nie tylko smaczna, ale też łatwa w uprawie.",

                    31,

                    1.83,

                    0.22,

                    6.97,

                    2.7,

                    "Witamina C – 12.2 mg\n" +
                    "Tiamina – 0.082 mg\n" +
                    "Ryboflawina – 0.104 mg\n" +
                    "Niacyna - 0.734 mg\n" +
                    "Witamina B6  - 0.141 mg\n" +
                    "Foliany -  33 µg\n" +
                    "Witamina A – 690 IU\n" +
                    "Witamina E – 0.41 mg",

                    "Wapń - 37 mg\n" +
                    "Żelazo - 1.03 mg\n" +
                    "Magnez - 25 mg\n" +
                    "Fosfor - 38 mg\n" +
                    "Potas - 211 mg\n" +
                    "Sód - 6 mg\n" +
                    "Cynk - 0.24 mg",

                    BlokHealth.Properties.Resources.fasolka_szparagowa,

                    true
                ));
            #endregion

            #region Gruszki
            Product.Add
                (new Product(
                    "Gruszka",

                    "Gruszki bogate są w: fosfor, wapń, magnez, sód, miedź i żelazo. Gruszki to bogate źródło kwasów owocowych jabłkowego i cytrynowego.",

                    57,

                    0.36,

                    0.14,

                    15.23,

                    3.1,

                    "Witamina C – 4.3 mg\n" +
                    "Tiamina – 0.012 mg\n" +
                    "Ryboflawina – 0.026 mg\n" +
                    "Niacyna - 0.161 mg\n" +
                    "Witamina B6  - 0.029 mg\n" +
                    "Kwas foliowy -  7 µg\n" +
                    "Witamina K - 4.4 µg\n" +
                    "Witamina E – 0.12 mg",

                    "Wapń - 9 mg\n" +
                    "Żelazo - 0.18 mg\n" +
                    "Magnez - 7 mg\n" +
                    "Fosfor - 12 mg\n" +
                    "Potas - 116 mg\n" +
                    "Sód - 1 mg\n" +
                    "Cynk - 0.10 mg",

                    BlokHealth.Properties.Resources.gruszki,

                    true
                ));
            #endregion

            #region Jabłko
            Product.Add
                (new Product(
                    "Jabłko",

                    "Jabłko to jadalny, kulisty owoc drzew z rodzaju jabłoń Malus. Jabłka, są istotnym komercyjnie owocem o soczystym i chrupkim miąższu.",

                    52,

                    0.26,

                    0.17,

                    13.81,

                    2.4,

                    "Witamina E - 0,18 mg\n" +
                    "Witamina K1 - 2,2 µg\n" +
                    "Witamina C - 4,6 mg\n" +
                    "Witamina B1 - 0,017 mg\n" +
                    "Witamina B2 - 0, 026 mg\n" +
                    "Witamina B9 - 3 µg\n" +
                    "Witamina B12 - 0 µg\n" +
                    "Witamina B5 - 0,061 mg",

                    "Wapń - 6 mg\n" +
                    "Żelazo - 0,12 mg\n" +
                    "Magnez - 5 mg\n" +
                    "Fosfor - 11 mg\n" +
                    "Potas - 107 mg\n" +
                    "Sód - 1 mg\n" +
                    "Cynk - 0,04 mg",

                    BlokHealth.Properties.Resources.jabłka,

                    true
                ));
            #endregion

            #region Jajecznica
            Product.Add
                (new Product(
                    "Jajecznica",

                    "Jajecznica to potrawa z rozmąconych, usmażonych na patelni jajek. Jest domeną prostej kuchni, ponieważ nie wymaga umiejętności kulinarnych ani techniki.",

                    149,

                    9.99,

                    10.98,

                    1.61,

                    0,

                    "Witamina C - 0 mg\n" +
                    "Rów. fol. - 36,0 µg\n" +
                    "Witamina B1 - 0,04 mg\n" +
                    "Witamina B2 - 0,38 mg\n" +
                    "Witamina B9 - 36,0 µg\n" +
                    "Witamina B4 - 221 mg\n" +
                    "Witamina B12 - 0,76 µg\n" +
                    "Witamina A	- 161 µg",

                    "Wapń - 66,0 mg\n" +
                    "Żelazo - 1,31 mg\n" +
                    "Magnez - 11,00 mg\n" +
                    "Fosfor - 165 mg\n" +
                    "Potas - 132 mg\n" +
                    "Sód - 145 mg\n" +
                    "Cynk - 1,04 mg",

                    BlokHealth.Properties.Resources.jajecznica,

                    true
                ));
            #endregion

            #region Kajzerka
            Product.Add
                (new Product(
                    "Kajzerka",

                    "Kajzerka jest to mała, okrągła bułka z charakterystycznymi pięcioma promienistymi bruzdami na wierzchu. Masa kajzerki wynosi około 50 gramów, wypiekana jest zazwyczaj z mąki pszennej, słodu, zakwasu lub drożdży, soli i wody.",

                    1077,
                    "kJ",

                    8,

                    3.3,

                    54,

                    2,

                    "Brak Danych",

                    "Brak Danych",

                    BlokHealth.Properties.Resources.kajzerki,

                    true
                ));
            #endregion

            #region Krówka
            Product.Add
                (new Product(
                    "Krówka wan.",

                    "Krówki to rodzaj polskich słodyczy, cukierki mleczne z miękkim, ciągliwym nadzieniem. Konsystencja krówek wynika z czasu przechowywania.",

                    383,

                    1.05,

                    5.45,

                    82.2,

                    0,

                    "Witamina C - 0 mg\n" +
                    "Witamina B1 - 0,01 mg\n" +
                    "Witamina B2 - 0,07 mg\n" +
                    "Witamina B9 - 1,00 µg\n" +
                    "Witamina B12 - 0,08 µg\n" +
                    "Witamina A	- 46,0 µg\n" +
                    "Witamina E	- 0,14 mg\n" +
                    "Witamina K - 0,50 µg",

                    "Wapń - 38,0 mg\n" +
                    "Żelazo - 0,02 mg\n" +
                    "Magnez - 3,00 mg\n" +
                    "Fosfor - 30,0 mg\n" +
                    "Potas - 49,0 mg\n" +
                    "Sód - 47,0 mg\n" +
                    "Cynk - 0,15 mg",

                    BlokHealth.Properties.Resources.krówka_cukierki,

                    true
                ));
            #endregion

            #region Malina
            Product.Add
                (new Product(
                    "Malina",

                    "U różnych odmian uprawnych owoce mogą być koloru od czarnego i purpurowego, przez czerwony, żółty, do białawego.",

                    52,

                    1.20,

                    0.65,

                    11.94,

                    6.5,

                    "Witamina C – 26.2 mg\n" +
                    "Tiamina – 0.032 mg\n" +
                    "Ryboflawina – 0.038 mg\n" +
                    "Niacyna - 0.598 mg\n" +
                    "Witamina B6 - 0.055 mg\n" +
                    "Kwas foliowy - 21 µg\n" +
                    "Witamina E – 0.87 mg\n" +
                    "Witamina K - 7.8 µg",

                    "Wapń – 25 mg\n" +
                    "Żelazo - 0,69 mg\n" +
                    "Magnez - 22 mg\n" +
                    "Fosfor - 29 mg\n" +
                    "Potas - 151 mg\n" +
                    "Sód – 1 mg\n" +
                    "Cynk - 0, 42 mg",

                    BlokHealth.Properties.Resources.maliny,

                    true
                ));
            #endregion

            #region Mango
            Product.Add
                (new Product(
                    "Mango",

                    "Mango to soczyste owoce w typie pestkowca pochodzące z tropikalnych drzew mango, uprawianych głównie dla swoich jadalnych owoców.",

                    60,

                    0.82,

                    0.38,

                    14.98,

                    1.6,

                    "Witamina C – 36,4 mg\n" +
                    "Tiamina – 0,028 mg\n" +
                    "Ryboflawina – 0,038 mg\n" +
                    "Witamina B6  - 0,119 mg\n" +
                    "Kwas foliowy - 43 µg\n" +
                    "Witamina A – 1082 IU\n" +
                    "Witamina E – 0,90 mg\n" +
                    "Witamina K - 4,2 µg",

                    "Wapń - 11 mg\n" +
                    "Żelazo - 0,16 mg\n" +
                    "Magnez - 10 mg\n" +
                    "Fosfor - 14 mg\n" +
                    "Potas - 168 mg\n" +
                    "Sód - 1 mg\n" +
                    "Cynk - 0,09 mg",

                    BlokHealth.Properties.Resources.mango,

                    true
                ));
            #endregion

            #region Mleko
            Product.Add
                (new Product(
                    "Mleko",

                    "Jako produkt żywnościowy dla człowieka najczęstsze zastosowanie ma mleko krowie. Mleko jest mieszaniną wieloskładnikową.",

                    51,

                    3.3,

                    2.0,

                    4.9,

                    0,

                    "Witamina A – 102 IU\n" +
                    "Witamina D – 40 IU\n" +
                    "Witamina E – 0,1 mg\n" +
                    "Witamina K – 0,2 mcg\n" +
                    "Witamina B1 – 0,04 mg\n" +
                    "Witamina B2 – 0,2 mg\n" +
                    "Witamina B3 – 0,1 mg\n" +
                    "Witamina B6 – 0,036 mg",

                    "Wapń - 113 mg\n" +
                    "Żelazo - 0 mg\n" +
                    "Magnez - 10 mg\n" +
                    "Fosfor - 91 mg\n" +
                    "Potas - 143 mg\n" +
                    "Sód - 40 mg\n" +
                    "Cynk - 0.4 mg",

                    BlokHealth.Properties.Resources.mleko,

                    true
                ));
            #endregion

            #region Nerkowce
            Product.Add
                (new Product(
                    "Nerkowce",

                    "Nerkowce mają wiele wartości odżywczych. Te odznaczające się delikatnym, słodkim smakiem orzechy mogą zapobiec rozwojowi cukrzycy typu 2.",

                    533,

                    18.22,

                    43.85,

                    30.19,

                    3.3,

                    "Witamina C – 0,5 mg\n" +
                    "Tiamina – 0,423 mg\n" +
                    "Ryboflawina – 0,058 mg\n" +
                    "Niacyna - 1,062 mg\n" +
                    "Witamina B6 - 0,417 mg\n" +
                    "Kwas foliowy -  25 µg\n" +
                    "Witamina E – 0,90 mg\n" +
                    "Witamina K - 34,1 µg",

                    "Wapń - 37 mg\n" +
                    "Żelazo - 6.68 mg\n" +
                    "Magnez - 292 mg\n" +
                    "Fosfor - 593 mg\n" +
                    "Potas - 660 mg\n" +
                    "Sód - 12 mg\n" +
                    "Cynk - 5.78 mg",

                    BlokHealth.Properties.Resources.orzeszki_nerkowca,

                    true
                ));
            #endregion

            #region Ogórek
            Product.Add
                (new Product(
                    "Ogórek",

                    "Ogórek to rodzaj roślin jednorocznych z rodziny dyniowatych. Obejmuje co najmniej 52 gatunki. Ogórki zawierają kukurbitacyny dające gorzki smak.",

                    13,

                    0.615,

                    0.14,

                    2.90,

                    0.6,

                    "Witamina C – 3.2 mg\n" +
                    "Tiamina – 0.031 mg\n" +
                    "Ryboflawina – 0.025 mg\n" +
                    "Witamina B6  - 0.051 mg\n" +
                    "Kwas foliowy -  14 µg\n" +
                    "Witamina A – 72 IU\n" +
                    "Witamina E – 0.03 mg\n" +
                    "Witamina K - 7.2 µg",

                    "Wapń - 14 mg\n" +
                    "Żelazo - 0.22 mg\n" +
                    "Magnez - 12.5 mg\n" +
                    "Fosfor - 22 mg\n" +
                    "Potas - 140 mg\n" +
                    "Sód - 2 mg\n" +
                    "Cynk - 0.185 mg",

                    BlokHealth.Properties.Resources.ogorek,

                    true
                ));
            #endregion

            #region Pączki
            Product.Add
                (new Product(
                    "Pączki",

                    "Pączek to w kuchni polskiej, wyrób cukierniczy w postaci ciasta drożdżowego z mąki pszennej, uformowanego na kształt spłaszczonej kuli.",

                    426,

                    5.20,

                    22.90,

                    50.80,

                    1.5,

                    "Tiamina – 0.233 mg\n" +
                    "Ryboflawina – 0.198 mg\n" +
                    "Niacyna - 1.512 mg\n" +
                    "Witamina B6 - 0.027 mg\n" +
                    "Kwas foliowy - 70 µg\n" +
                    "Witamina A – 10 IU\n" +
                    "Witamina B12 – 0.24 mg",

                    "Wapń - 60 mg\n" +
                    "Żelazo - 1.06 mg\n" +
                    "Magnez - 17 mg\n" +
                    "Fosfor - 117 mg\n" +
                    "Potas - 102 mg\n" +
                    "Sód - 402 mg\n" +
                    "Cynk - 0.44 mg",

                    BlokHealth.Properties.Resources.paczki,

                    true
                ));
            #endregion

            #region Pizza
            Product.Add
                (new Product(
                    "Pizza",

                    "Pizza to włoska potrawa, rozpowszechniona na całym świecie. Jest to płaski placek z ciasta drożdżowego, z sosem pomidorowym, posypany tartym serem i ziołami.",

                    280,

                    12.86,

                    11.38,

                    31.55,

                    1.7,

                    "Witamina B1 - 0,32 mg\n" +
                    "Witamina B2 - 0,271 mg\n" +
                    "Witamin B6 - 0,152 mg\n" +
                    "Niacyna - 4,028 mg\n" +
                    "Witamina B12 - 0,68 µg\n" +
                    "Witamina C - 0,0 mg\n" +
                    "Witamina A - 57,0 µg",

                    "Wapń - 155 mg\n" +
                    "Żelazo - 2.14 mg\n" +
                    "Magnez - 23 mg\n" +
                    "Fosfor - 218 mg\n" +
                    "Potas - 207 mg\n" +
                    "Sód - 801 mg\n" +
                    "Cynk - 1.68 mg",

                    BlokHealth.Properties.Resources.pizza,

                    true
                ));
            #endregion

            #region Pomidor
            Product.Add
                (new Product(
                    "Pomidor",

                    "Pomidor odpowiada za niepowtarzalny smak wielu dań, a nawet zdążył się wpisać w warzywną „popkulturę” dzięki temu, że wchodzi w skład ketchupu.",

                    18,

                    0.88,

                    0.20,

                    3.89,

                    1.2,

                    "Tiamina – 0.037 mg\n" +
                    "Ryboflawina – 0.019 mg\n" +
                    "Niacyna - 0.594 mg\n" +
                    "Witamina B6  - 0.080 mg\n" +
                    "Kwas foliowy -  15 µg\n" +
                    "Witamina A – 833 IU\n" +
                    "Witamina E – 0.54 mg\n" +
                    "Witamina C - 13.7 mg",

                    "Wapń - 10 mg\n" +
                    "Żelazo - 0.27 mg\n" +
                    "Magnez - 11 mg\n" +
                    "Fosfor - 24 mg\n" +
                    "Potas - 237 mg\n" +
                    "Sód - 5 mg\n" +
                    "Cynk - 0.17 mg",

                    BlokHealth.Properties.Resources.pomidor,

                    true
                ));
            #endregion

            #region Rodzynki
            Product.Add
                (new Product(
                    "Rodzynki",

                    "Rodzynki to suszone winogrona, zaliczane do bakalii. Mogą być spożywane surowe lub używane do pieczenia.",

                    299,

                    3.07,

                    0.46,

                    79.18,

                    3.7,

                    "Witamina C – 2, 3 mg\n" +
                    "Tiamina – 0, 106 mg\n" +
                    "Ryboflawina – 0, 125 mg\n" +
                    "Niacyna - 0, 766 mg\n" +
                    "Witamina B6 - 0, 174 mg\n" +
                    "Kwas foliowy - 5 µg\n" +
                    "Witamina E – 0, 12 mg\n" +
                    "Witamina K - 3, 5 µg",

                    "Wapń - 50 mg\n" +
                    "Żelazo - 1.88 mg\n" +
                    "Magnez - 32 mg\n" +
                    "Fosfor - 101 mg\n" +
                    "Potas - 749 mg\n" +
                    "Sód - 11 mg\n" +
                    "Cynk - 0.22 mg",

                    BlokHealth.Properties.Resources.rodzynki,

                    true
                ));
            #endregion

            #region Rosół
            Product.Add
                (new Product(
                    "Rosół",

                    "Rosół to niezagęszczana zupa będąca wywarem mięsno-warzywnym. Sporządzana z drobiu, ewentualnie z wołowiny, baraniny lub na Górnym Śląsku z gołębi.",

                    15,

                    37.5,

                    1.25,

                    0.625,

                    0.125,

                    "Brak Danych",

                    "Wapń - 2.5 mg\n" +
                    "Żelazo - 0.125 mg\n" +
                    "Fosfor - 17.5 mg\n" +
                    "Potas - 50 mg",

                    BlokHealth.Properties.Resources.rosół,

                    true
                ));
            #endregion

            #region Schabowy
            Product.Add
                (new Product(
                    "Schabowy",

                    "Kotlet schabowy to kotlet panierowany ze schabu przypominający sznycel wiedeński. Jest to jedna z tradycyjnych i najbardziej popularnych potraw w kuchni polskiej.",

                    120,

                    21,

                    4.0,

                    50.80,

                    1.5,

                    "Witamina B1 w 35 %\n" +
                    "Witamina B2 w 12 %\n" +
                    "Witamina B3 w 43 %\n" +
                    "Witamina B5 w 7 %\n" +
                    "Witamina B6 w 36 %\n" +
                    "Witamina B12 w 9 %",

                    "Brak Danych",

                    BlokHealth.Properties.Resources.schabowy,

                    true
                ));
            #endregion

            #region Spaghetti
            Product.Add
                (new Product(
                    "Spaghetti",

                    "W skład spaghetti bolognese wchodzi mięso, warzywa takie jak pietruszka, cebula, marchew, pomidory i seler oraz oliwa i czerwone wino.",

                    150,

                    7.12,

                    5.11,

                    18,

                    1.7,

                    "Kwas foliowy,\n" +
                    "PP\n" +
                    "B,\n" +
                    "A,\n" +
                    "K,\n" +
                    "E",

                    "Wapń\n" +
                    "Żelazo\n" +
                    "Magnez\n" +
                    "Fosfor\n" +
                    "Potas\n" +
                    "Sód\n" +
                    "Cynk",

                    BlokHealth.Properties.Resources.spagetti,

                    true
                ));
            #endregion

            #region Szarlotka
            Product.Add
                (new Product(
                    "Szarlotka",

                    "Szarlotka to pochodzący z Francji wyrób cukierniczy, składający się z półkruchego lub kruchego ciasta oraz owoców.",

                    265,

                    2.40,

                    12.50,

                    37.1,

                    0,

                    "Witamina C	1,70 mg\n" +
                    "Witamina B1 - 0,15 mg\n" +
                    "Witamina B2 - 0,11 mg\n" +
                    "Witamina B9 - 24,0 µg\n" +
                    "Witamina B12 - 0 µg\n" +
                    "Witamina A	- 11,00 µg\n" +
                    "Retinol - 9,00 µg\n" +
                    "Witamina B4 - 0 mg",

                    "Wapń - 7,00 mg\n" +
                    "Żelazo - 1,12 mg\n" +
                    "Magnez - 7,00 mg\n" +
                    "Fosfor - 28,0 mg\n" +
                    "Potas - 79,0 mg\n" +
                    "Sód - 211 mg\n" +
                    "Cynk - 0,19 mg",

                    BlokHealth.Properties.Resources.szarlotka,

                    true
                ));
            #endregion

            #region Śliwki
            Product.Add
                (new Product(
                    "Śliwka",

                    "Owoce są nie tylko smaczne, ale dostarczają naszemu organizmowi wiele wartości odżywczych. Śliwki są wyśmienitym owocem sezonowym.",

                    46,

                    0.70,

                    0.28,

                    11.42,

                    1.4,

                    "Witamina C – 9.5 mg\n" +
                    "Tiamina – 0.028 mg\n" +
                    "Ryboflawina – 0.026 mg\n" +
                    "Niacyna - 0.417 mg\n" +
                    "Witamina B6  - 0.029 mg\n" +
                    "Kwas foliowy -  5 µg\n" +
                    "Witamina E – 0.26 mg\n" +
                    "Witamina A – 345 IU",

                    "Wapń - 6 mg\n" +
                    "Żelazo - 0.17 mg\n" +
                    "Magnez - 7 mg\n" +
                    "Fosfor - 16 mg\n" +
                    "Potas - 157 mg\n" +
                    "Sód - 0 mg\n" +
                    "Cynk - 0.1 mg",

                    BlokHealth.Properties.Resources.śliwki,

                    true
                ));
            #endregion

            #region Winogrona
            Product.Add
                (new Product(
                    "Winogrona",

                    "Winogrona można jeść na surowo lub można je przetwarzać. Główne produkty spożywcze uzyskiwane z winogron to: dżem, sok, galaretka, wino itd.",

                    69,

                    0.72,

                    0.16,

                    18.10,

                    0.9,

                    "Witamina C – 3.2 mg\n" +
                    "Tiamina – 0.069 mg\n" +
                    "Ryboflawina – 0.070 mg\n" +
                    "Niacyna - 0.188 mg\n" +
                    "Witamina B6  - 0.086 mg\n" +
                    "Kwas foliowy -  2 µg\n" +
                    "Witamina E – 0.19 mg\n" +
                    "Witamina K - 14.6 µg",

                    "Wapń - 10 mg\n" +
                    "Żelazo - 0.36 mg\n" +
                    "Magnez - 7 mg\n" +
                    "Fosfor - 20 mg\n" +
                    "Potas - 191 mg\n" +
                    "Sód - 2 mg\n" +
                    "Cynk - 0.07 mg",

                    BlokHealth.Properties.Resources.białe_wingrona,

                    true
                ));
            #endregion

        }

        private void ButtonEditProduct_Click(object sender, EventArgs e)
        {
            CheckProgramDiresArchitecture();
            EditProductForm editProductForm = new EditProductForm(SystemDriveName, MyProductFolderPath, ImagesFolderPath, Product[ProductNumber]);
            editProductForm.ShowDialog();
            Product.Clear();
            LoadingMyProducts();
            LoadingProductObjects();
            ProductAlphabeticSort();
            SelectActiveProduct();
        }

        void SelectActiveProduct()
        {
            // Ustawianie widoczności przycisków / Set buttons visible
            if (Product[ProductNumber].StaticProduct == false)
            {
                ButtonEditProduct.Visible = true;
                ButtonDeleteProduct.Visible = true;
            }
            else if (Product[ProductNumber].StaticProduct == true)
            {
                ButtonEditProduct.Visible = false;
                ButtonDeleteProduct.Visible = false;
            }

            // Load ExampleImage
            if (File.Exists(@Product[ProductNumber].ExampleImagePath))
            {
                try
                {

                    msForExampleImg.SetLength(0);
                    using (FileStream fs = new FileStream(Product[ProductNumber].ExampleImagePath, FileMode.Open))
                    {
                        fs.CopyTo(msForExampleImg);
                    }
                    ExampleImgBitmap = new Bitmap(msForExampleImg, true);
                    PictureBoxImageOfProduct.Image = ExampleImgBitmap;

                }
                catch
                {
                    PictureBoxImageOfProduct.Image = BlokHealth.Properties.Resources.brak_zdjęcia;
                }
            }
            else
            { PictureBoxImageOfProduct.Image = Product[ProductNumber].ExampleImage; }

            // Load Name & Describe
            FoodTitleLabel.Text = Product[ProductNumber].Name;
            LabelDescriptionOfProduct.Text = Product[ProductNumber].Describe;

            // Load Energy Varibles
            LabelValueWartoscEnergetyczna.Text = Product[ProductNumber].EnergyValue.ToString();
            LabelValueWartoscEnergetyczna.Text += " " + Product[ProductNumber].EnergyValueVarible;

            // Load Protein Varibles
            LabelValueBialko.Text = Product[ProductNumber].Protein.ToString();
            LabelValueBialko.Text += " " + Product[ProductNumber].ProteinVarible;

            // Load Fat Varibles
            LabelValueTluszcz.Text = Product[ProductNumber].Fat.ToString();
            LabelValueTluszcz.Text += " " + Product[ProductNumber].FatVarible;

            // Load Carbohydrates Varibles
            LabelValueWeglowodany.Text = Product[ProductNumber].Carbohydrates.ToString();
            LabelValueWeglowodany.Text += " " + Product[ProductNumber].CarbohydratesVarible;

            // Load Fiber Varibles
            LabelValueBlonnik.Text = Product[ProductNumber].Fiber.ToString();
            LabelValueBlonnik.Text += " " + Product[ProductNumber].FiberVarible;

            // Load Vitamins & Minerals
            LabelValueWitaminy.Text = Product[ProductNumber].Vitamins;
            LabelValueMineraly.Text = Product[ProductNumber].Minerals;

        }

        void LoadingMyProducts()
        {
            CheckProgramDiresArchitecture();

            DirectoryInfo dir = new DirectoryInfo(MyProductFolderPath);
            List<string> FilesPathList = new List<string>();
            int i = 1;
            foreach (var Prod in dir.GetFiles())
            {
                FilesPathList.Add(Prod.Name);
                i++;
            }

            FilesPathList.Sort();

            foreach (var THEProductFilePath in FilesPathList)
            {
                //Varibles
                string THEProductName;
                string THEProductDescribe;

                double THEProductEnergyValue;
                string THEProductEnergyValueVarible;

                double THEProductProtein;
                string THEProductProteinVarible;

                double THEProductFat;
                string THEProductFatVarible;

                double THEProductCarbohydrates;
                string THEProductCarbohydratesVarible;

                double THEProductFiber;
                string THEProductFiberVarible;

                string THEProductVitamins;

                string THEProductMinerals;

                String THEProductExampleImagePath;

                // ----------------------------------- //

                System.IO.StreamReader file = new System.IO.StreamReader(MyProductFolderPath + @"\" + THEProductFilePath);

                THEProductName = file.ReadLine();
                THEProductDescribe = file.ReadLine();

                try
                {
                    THEProductEnergyValue = Convert.ToDouble(file.ReadLine());
                }
                catch
                {
                    THEProductEnergyValue = 0;
                }// THEProductEnergyValue
                THEProductEnergyValueVarible = file.ReadLine();

                try
                {
                    THEProductProtein = Convert.ToDouble(file.ReadLine());
                }
                catch
                {
                    THEProductProtein = 0;
                }// THEProductProtein
                THEProductProteinVarible = file.ReadLine();

                try
                {
                    THEProductFat = Convert.ToDouble(file.ReadLine());
                }
                catch
                {
                    THEProductFat = 0;
                }// THEProductFat
                THEProductFatVarible = file.ReadLine();

                try
                {
                    THEProductCarbohydrates = Convert.ToDouble(file.ReadLine());
                }
                catch
                {
                    THEProductCarbohydrates = 0;
                }// THEProductCarbohydrates
                THEProductCarbohydratesVarible = file.ReadLine();

                try
                {
                    THEProductFiber = Convert.ToDouble(file.ReadLine());
                }
                catch
                {
                    THEProductFiber = 0;
                }// THEProductFiber
                THEProductFiberVarible = file.ReadLine();

                #region Vitamins&Minerals

                THEProductVitamins =
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine();

                THEProductMinerals =
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine() + "\n" +
                    file.ReadLine();

                #endregion

                THEProductExampleImagePath = file.ReadLine();

                file.Close();

                #region CreatorOfProduct
                Product.Add(new Product
                (
                    THEProductName,
                    THEProductDescribe,

                    THEProductEnergyValue,
                    THEProductEnergyValueVarible,

                    THEProductProtein,
                    THEProductProteinVarible,

                    THEProductFat,
                    THEProductFatVarible,

                    THEProductCarbohydrates,
                    THEProductCarbohydratesVarible,

                    THEProductFiber,
                    THEProductFiberVarible,

                    THEProductVitamins,

                    THEProductMinerals,

                    THEProductExampleImagePath,

                    false
                ));

                #endregion
            }

        }

        #endregion
        //TODO Wprowadź autoskalowanie paneli
    }
}
