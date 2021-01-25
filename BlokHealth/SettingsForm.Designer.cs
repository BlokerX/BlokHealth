
namespace BlokHealth
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.ControlBoxPanel = new System.Windows.Forms.Panel();
            this.ControlBoxMinimizeButton = new System.Windows.Forms.Button();
            this.ControlBoxMaximizeButton = new System.Windows.Forms.Button();
            this.ControlBoxCloseButton = new System.Windows.Forms.Button();
            this.ControlBoxTextPanel = new System.Windows.Forms.Panel();
            this.ControlBoxTextLabel = new System.Windows.Forms.Label();
            this.ControlBoxIconPanel = new System.Windows.Forms.Panel();
            this.ControlBoxIcon = new System.Windows.Forms.PictureBox();
            this.MotywComboBox = new System.Windows.Forms.ComboBox();
            this.LabelMotyw = new System.Windows.Forms.Label();
            this.ButtonZastosuj = new System.Windows.Forms.Button();
            this.LabelUstawienia = new System.Windows.Forms.Label();
            this.CentralPanel = new System.Windows.Forms.Panel();
            this.ButtonAnuluj = new System.Windows.Forms.Button();
            this.ControlBoxPanel.SuspendLayout();
            this.ControlBoxTextPanel.SuspendLayout();
            this.ControlBoxIconPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControlBoxIcon)).BeginInit();
            this.CentralPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlBoxPanel
            // 
            this.ControlBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ControlBoxPanel.Controls.Add(this.ControlBoxMinimizeButton);
            this.ControlBoxPanel.Controls.Add(this.ControlBoxMaximizeButton);
            this.ControlBoxPanel.Controls.Add(this.ControlBoxCloseButton);
            this.ControlBoxPanel.Controls.Add(this.ControlBoxTextPanel);
            this.ControlBoxPanel.Controls.Add(this.ControlBoxIconPanel);
            this.ControlBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlBoxPanel.Name = "ControlBoxPanel";
            this.ControlBoxPanel.Size = new System.Drawing.Size(310, 30);
            this.ControlBoxPanel.TabIndex = 2;
            this.ControlBoxPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlBoxPanel_MouseMove);
            // 
            // ControlBoxMinimizeButton
            // 
            this.ControlBoxMinimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ControlBoxMinimizeButton.BackgroundImage")));
            this.ControlBoxMinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ControlBoxMinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlBoxMinimizeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ControlBoxMinimizeButton.FlatAppearance.BorderSize = 0;
            this.ControlBoxMinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlBoxMinimizeButton.ForeColor = System.Drawing.Color.Transparent;
            this.ControlBoxMinimizeButton.Location = new System.Drawing.Point(175, 0);
            this.ControlBoxMinimizeButton.Name = "ControlBoxMinimizeButton";
            this.ControlBoxMinimizeButton.Size = new System.Drawing.Size(45, 30);
            this.ControlBoxMinimizeButton.TabIndex = 3;
            this.ControlBoxMinimizeButton.UseVisualStyleBackColor = true;
            this.ControlBoxMinimizeButton.Click += new System.EventHandler(this.ControlBoxMinimizeButton_Click);
            // 
            // ControlBoxMaximizeButton
            // 
            this.ControlBoxMaximizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ControlBoxMaximizeButton.BackgroundImage")));
            this.ControlBoxMaximizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ControlBoxMaximizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlBoxMaximizeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ControlBoxMaximizeButton.FlatAppearance.BorderSize = 0;
            this.ControlBoxMaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlBoxMaximizeButton.ForeColor = System.Drawing.Color.Transparent;
            this.ControlBoxMaximizeButton.Location = new System.Drawing.Point(220, 0);
            this.ControlBoxMaximizeButton.Name = "ControlBoxMaximizeButton";
            this.ControlBoxMaximizeButton.Size = new System.Drawing.Size(45, 30);
            this.ControlBoxMaximizeButton.TabIndex = 2;
            this.ControlBoxMaximizeButton.UseVisualStyleBackColor = true;
            this.ControlBoxMaximizeButton.Click += new System.EventHandler(this.ControlBoxMaximizeButton_Click);
            // 
            // ControlBoxCloseButton
            // 
            this.ControlBoxCloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ControlBoxCloseButton.BackgroundImage")));
            this.ControlBoxCloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ControlBoxCloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlBoxCloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ControlBoxCloseButton.FlatAppearance.BorderSize = 0;
            this.ControlBoxCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ControlBoxCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ControlBoxCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlBoxCloseButton.ForeColor = System.Drawing.Color.Transparent;
            this.ControlBoxCloseButton.Location = new System.Drawing.Point(265, 0);
            this.ControlBoxCloseButton.Name = "ControlBoxCloseButton";
            this.ControlBoxCloseButton.Size = new System.Drawing.Size(45, 30);
            this.ControlBoxCloseButton.TabIndex = 1;
            this.ControlBoxCloseButton.UseVisualStyleBackColor = true;
            this.ControlBoxCloseButton.Click += new System.EventHandler(this.ControlBoxCloseButton_Click);
            // 
            // ControlBoxTextPanel
            // 
            this.ControlBoxTextPanel.AutoSize = true;
            this.ControlBoxTextPanel.Controls.Add(this.ControlBoxTextLabel);
            this.ControlBoxTextPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlBoxTextPanel.Location = new System.Drawing.Point(27, 0);
            this.ControlBoxTextPanel.Name = "ControlBoxTextPanel";
            this.ControlBoxTextPanel.Size = new System.Drawing.Size(4, 30);
            this.ControlBoxTextPanel.TabIndex = 5;
            this.ControlBoxTextPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlBoxTextPanel_MouseMove);
            // 
            // ControlBoxTextLabel
            // 
            this.ControlBoxTextLabel.AutoSize = true;
            this.ControlBoxTextLabel.ForeColor = System.Drawing.Color.White;
            this.ControlBoxTextLabel.Location = new System.Drawing.Point(1, 9);
            this.ControlBoxTextLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ControlBoxTextLabel.Name = "ControlBoxTextLabel";
            this.ControlBoxTextLabel.Size = new System.Drawing.Size(0, 13);
            this.ControlBoxTextLabel.TabIndex = 3;
            this.ControlBoxTextLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlBoxTextLabel_MouseMove);
            // 
            // ControlBoxIconPanel
            // 
            this.ControlBoxIconPanel.Controls.Add(this.ControlBoxIcon);
            this.ControlBoxIconPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ControlBoxIconPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlBoxIconPanel.Name = "ControlBoxIconPanel";
            this.ControlBoxIconPanel.Size = new System.Drawing.Size(27, 30);
            this.ControlBoxIconPanel.TabIndex = 4;
            // 
            // ControlBoxIcon
            // 
            this.ControlBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("ControlBoxIcon.Image")));
            this.ControlBoxIcon.Location = new System.Drawing.Point(7, 6);
            this.ControlBoxIcon.Name = "ControlBoxIcon";
            this.ControlBoxIcon.Size = new System.Drawing.Size(18, 18);
            this.ControlBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ControlBoxIcon.TabIndex = 2;
            this.ControlBoxIcon.TabStop = false;
            // 
            // MotywComboBox
            // 
            this.MotywComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MotywComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MotywComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotywComboBox.FormattingEnabled = true;
            this.MotywComboBox.Items.AddRange(new object[] {
            "Dark Theme (Domyślny)",
            "Light Theme (NEW)"});
            this.MotywComboBox.Location = new System.Drawing.Point(98, 42);
            this.MotywComboBox.Name = "MotywComboBox";
            this.MotywComboBox.Size = new System.Drawing.Size(200, 28);
            this.MotywComboBox.TabIndex = 3;
            // 
            // LabelMotyw
            // 
            this.LabelMotyw.AutoSize = true;
            this.LabelMotyw.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMotyw.ForeColor = System.Drawing.Color.White;
            this.LabelMotyw.Location = new System.Drawing.Point(12, 42);
            this.LabelMotyw.Name = "LabelMotyw";
            this.LabelMotyw.Size = new System.Drawing.Size(80, 25);
            this.LabelMotyw.TabIndex = 4;
            this.LabelMotyw.Text = "Motyw:";
            // 
            // ButtonZastosuj
            // 
            this.ButtonZastosuj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonZastosuj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ButtonZastosuj.FlatAppearance.BorderSize = 0;
            this.ButtonZastosuj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonZastosuj.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonZastosuj.ForeColor = System.Drawing.Color.Snow;
            this.ButtonZastosuj.Location = new System.Drawing.Point(223, 80);
            this.ButtonZastosuj.Name = "ButtonZastosuj";
            this.ButtonZastosuj.Size = new System.Drawing.Size(75, 23);
            this.ButtonZastosuj.TabIndex = 5;
            this.ButtonZastosuj.Text = "Zastosuj";
            this.ButtonZastosuj.UseVisualStyleBackColor = false;
            this.ButtonZastosuj.Click += new System.EventHandler(this.ButtonZastosuj_Click);
            // 
            // LabelUstawienia
            // 
            this.LabelUstawienia.AutoSize = true;
            this.LabelUstawienia.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUstawienia.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.LabelUstawienia.Location = new System.Drawing.Point(8, 4);
            this.LabelUstawienia.Name = "LabelUstawienia";
            this.LabelUstawienia.Size = new System.Drawing.Size(167, 36);
            this.LabelUstawienia.TabIndex = 6;
            this.LabelUstawienia.Text = "Ustawienia";
            // 
            // CentralPanel
            // 
            this.CentralPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.CentralPanel.Controls.Add(this.ButtonAnuluj);
            this.CentralPanel.Controls.Add(this.MotywComboBox);
            this.CentralPanel.Controls.Add(this.LabelUstawienia);
            this.CentralPanel.Controls.Add(this.ButtonZastosuj);
            this.CentralPanel.Controls.Add(this.LabelMotyw);
            this.CentralPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CentralPanel.Location = new System.Drawing.Point(0, 30);
            this.CentralPanel.Name = "CentralPanel";
            this.CentralPanel.Size = new System.Drawing.Size(310, 115);
            this.CentralPanel.TabIndex = 7;
            // 
            // ButtonAnuluj
            // 
            this.ButtonAnuluj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAnuluj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonAnuluj.FlatAppearance.BorderSize = 0;
            this.ButtonAnuluj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAnuluj.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAnuluj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ButtonAnuluj.Location = new System.Drawing.Point(142, 80);
            this.ButtonAnuluj.Name = "ButtonAnuluj";
            this.ButtonAnuluj.Size = new System.Drawing.Size(75, 23);
            this.ButtonAnuluj.TabIndex = 7;
            this.ButtonAnuluj.Text = "Anuluj";
            this.ButtonAnuluj.UseVisualStyleBackColor = false;
            this.ButtonAnuluj.Click += new System.EventHandler(this.ButtonAnuluj_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(310, 145);
            this.Controls.Add(this.CentralPanel);
            this.Controls.Add(this.ControlBoxPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ControlBoxPanel.ResumeLayout(false);
            this.ControlBoxPanel.PerformLayout();
            this.ControlBoxTextPanel.ResumeLayout(false);
            this.ControlBoxTextPanel.PerformLayout();
            this.ControlBoxIconPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ControlBoxIcon)).EndInit();
            this.CentralPanel.ResumeLayout(false);
            this.CentralPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlBoxPanel;
        private System.Windows.Forms.Button ControlBoxMinimizeButton;
        private System.Windows.Forms.Button ControlBoxMaximizeButton;
        private System.Windows.Forms.Button ControlBoxCloseButton;
        private System.Windows.Forms.Panel ControlBoxTextPanel;
        private System.Windows.Forms.Label ControlBoxTextLabel;
        private System.Windows.Forms.Panel ControlBoxIconPanel;
        private System.Windows.Forms.PictureBox ControlBoxIcon;
        private System.Windows.Forms.ComboBox MotywComboBox;
        private System.Windows.Forms.Label LabelMotyw;
        private System.Windows.Forms.Button ButtonZastosuj;
        private System.Windows.Forms.Label LabelUstawienia;
        private System.Windows.Forms.Panel CentralPanel;
        private System.Windows.Forms.Button ButtonAnuluj;
    }
}