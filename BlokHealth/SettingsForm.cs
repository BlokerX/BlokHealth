using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlokHealth
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            UpdateTheme();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ControlBox_Loading();
            this.MotywComboBox.SelectedIndex = (int)AppTheme.ChoseTheme;
        }

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

        #region ControlBoxPanel

        #region Drag window

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private readonly bool CloseBox = true;

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

        private void ButtonZastosuj_Click(object sender, EventArgs e)
        {
            AppTheme.ChoseTheme = (AppTheme.ExampleTheme)MotywComboBox.SelectedIndex;
            this.Close();
        }

        private void ButtonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //* Themes *//
        #region Themes

        private void UpdateTheme()
        {
            AppTheme DownloadedTheme = AppTheme.DownloadTheme();
            #region UpdateMainFormTheme

            this.ControlBoxPanel.BackColor = DownloadedTheme.ControlBox;
            this.ControlBoxTextLabel.ForeColor = DownloadedTheme.ControlBoxAppNameColor;
            this.ControlBoxCloseButton.BackgroundImage = DownloadedTheme.CloseImg;
            this.ControlBoxCloseButton.FlatAppearance.BorderColor = DownloadedTheme.ControlBox;
            this.ControlBoxMaximizeButton.BackgroundImage = DownloadedTheme.MaximalizeImg;
            this.ControlBoxMaximizeButton.FlatAppearance.BorderColor = DownloadedTheme.ControlBox;
            this.ControlBoxMinimizeButton.BackgroundImage = DownloadedTheme.MinimalizeImg;
            this.ControlBoxMinimizeButton.FlatAppearance.BorderColor = DownloadedTheme.ControlBox;

            this.CentralPanel.BackColor = DownloadedTheme.CentralPanelSettingsFormBackgroundColor;
            this.LabelUstawienia.ForeColor = DownloadedTheme.LabelUstawieniaSettingsFormForeColor;
            this.LabelMotyw.ForeColor = DownloadedTheme.LabelMotywSettingsFormForeColor;
            this.MotywComboBox.BackColor = DownloadedTheme.MotywComboBoxSettingsFormBackgroundColor;
            this.MotywComboBox.ForeColor = DownloadedTheme.MotywComboBoxSettingsFormForeColor;
            this.ButtonAnuluj.BackColor = DownloadedTheme.ButtonAnulujSettingsFormBackgroundColor;
            this.ButtonAnuluj.ForeColor = DownloadedTheme.ButtonAnulujSettingsFormForeColor;
            this.ButtonZastosuj.BackColor = DownloadedTheme.ButtonZastosujSettingsFormBackgroundColor;
            this.ButtonZastosuj.ForeColor = DownloadedTheme.ButtonZastosujSettingsFormForeColor;

            #endregion
        }

        #endregion

    }
}
