using System;
using System.Threading;
using System.Windows.Forms;

namespace BlokHealth
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region ShowIntroForm
            IntroForm introForm = new IntroForm();
            introForm.Show();
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(5);
                Application.DoEvents();
            }
            introForm.Close();
            #endregion
            Application.Run(new MainForm());
        }
    }
}
// (PL): Najlepiej to odpalać na ekranie 16:9
// (ENG): It's best to launch this app on a 16:9 screen
