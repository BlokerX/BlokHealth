using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlokHealth
{
    public partial class ExerciseDictonary : Form
    {
        public ExerciseDictonary()
        {
            InitializeComponent();
        }

        private void ExerciseDictonary_Load(object sender, EventArgs e)
        {
            ControlBox_Loading();
            LoadingExercises();
            SelectExercise();
        }

        #region ControlBoxPanel

        #region ProtectForMaximalizeForm
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MAXIMIZEBOX = 0x00010000;
                var cp = base.CreateParams;
                cp.Style &= ~WS_MAXIMIZEBOX;
                return cp;
            }
        }
        #endregion

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

        List<Exercise> ExerciseList = new List<Exercise>();
        int IndexExerciseList = 0;

        void LoadingExercises()
        {
            ExerciseList.Add(new Exercise(
                "Pompki",

                "Rozstaw dłonie na szerokość barków." +
                " Ułóż ciało możliwie w jak najbardziej stabilnej pozycji," +
                " maksymalnie prostując kręgosłup. Nie unoś bioder. " +
                "Wzrok skieruj w podłogę, nie zadzieraj głowy do góry. " +
                "W tym ułożeniu możesz zrobić pompkę. " +
                "Pamiętaj, że całkowicie wykonane ćwiczenie to takie, " +
                "kiedy twoje ręce zegną się w łokciach przynajmniej pod kątem 90 stopni. " +
                "Najlepiej, jeśli klatka piersiowa znajdzie się tuż nad ziemią.",

                "- Klatka piersiowa\n" +
                "- Bicepsy",

                BlokHealth.Properties.Resources.Pompki
            )
            );

            ExerciseList.Add(new Exercise(
                "Przysiady",

                "Stań ze stopami nieco szerzej od szerokości bioder. " +
                "Twoje stopy powinny być skierowane lekko na zewnątrz. " +
                "Trzymaj plecy i szyję prosto i upewnij się, że stopy są mocno osadzone na ziemi. " +
                "Brzuch powinien być napięty. Opuść ciało, kierując biodra w tył, następnie zegnij kolana. " +
                "Plecy wraz z brzuchem trzymaj cały czas spięte. " +
                "Przysiad powinien kończyć się na wysokości nieco poniżej 90 stopni w zgięciu nóg. ",

                "- Mięśnie pośladkowe\n" +
                "- Uda\n" +
                "- Łydki",

                BlokHealth.Properties.Resources.Przysiady
            )
            );

            ExerciseList.Add(new Exercise(
                "Martwy ciąg",

                "Stań prosto, " +
                "stopy rozstawiając dużo szerzej na szerokość barków. " +
                "Wypchnij biodra w tył i ugnij kolana, " +
                "aby złapać sztangę bardzo wąskim nachwytem. " +
                "Wyprostuj się, prowadząc sztangę blisko osi ciała, " +
                "a w końcowej fazie ruchu napinając cały tył. Wróć do startu, " +
                "nie odkładając sztangi na podłogę.\n" +
                "Pamiętaj, liczy się dokładność techniki, a nie szybkość wykonywania ćwiczenia!",

                "- Mięsień najszerszy grzbietu\n" +
                "- Dwugłowy uda\n" +
                "- Mięśnie pośladkowe",

                BlokHealth.Properties.Resources.MartwyCiąg
            )
            );

            ExerciseList.Add(new Exercise(
                "Wyciskanie Sztangi",

                "Połóż się na ławce. " +
                "Stopy ustaw w lekkim rozkroku i mocno zaprzyj o podłoże. " +
                "Chwyć sztangę nachwytem na taką szerokość, " +
                "aby w połowie wykonywania ruchu kąt między ramieniem a przedramieniem wynosił 90 stopni." +
                "Łopatki ściągnięte, barki opuszczone i mocno dociśnięte do ławeczki. " +
                "Zachowaj naturalne ustawienie kręgosłupa – odcinek lędźwiowy lekko uniesiony, pośladki na ławeczce.",

                "- Mięśnie klatki Piersiowej\n" +
                "- Triceps",

                BlokHealth.Properties.Resources.WyciskanieSztangi
            )
            );

        }

        private void SelectExercise()
        {
            LabelTitle.Text = ExerciseList[IndexExerciseList].Name;
            LabelOpisWykonaniaCwiczeniaValue.Text = ExerciseList[IndexExerciseList].Describe;
            LabelAktywnePartieMiesniValue.Text = ExerciseList[IndexExerciseList].PartOfBody;
            ExerciseImage_PB.Image = ExerciseList[IndexExerciseList].ExampleImage;
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            if (IndexExerciseList > 0)
            {
                IndexExerciseList--;
            }
            else
            {
                IndexExerciseList = ExerciseList.Count - 1;
            }
            SelectExercise();
        }

        private void GoNextButton_Click(object sender, EventArgs e)
        {
            if (ExerciseList.Count > IndexExerciseList + 1)
            {
                IndexExerciseList++;
            }
            else
            {
                IndexExerciseList = 0;
            }
            SelectExercise();
        }

    }
}
