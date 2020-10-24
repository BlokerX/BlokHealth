using System;
using System.Collections.Generic;
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
            LoadingExercises();
            SelectExercise();
        }

        readonly List<Exercise> ExerciseList = new List<Exercise>();
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
                "Przysiad",

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
