using System;
using System.Windows.Forms;

namespace BlokHealth
{
    public partial class InformationAboutApplication : Form
    {
        public InformationAboutApplication()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
