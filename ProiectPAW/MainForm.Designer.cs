namespace ProiectPAW
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            NavigationPanel = new Panel();
            ExitButton = new Button();
            LoansButton = new Button();
            ClientsButton = new Button();
            UserPanel = new Panel();
            AppNameLabel = new Label();
            HomePictureBox = new PictureBox();
            FormLoaderPanel = new Panel();
            panel1.SuspendLayout();
            UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HomePictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(NavigationPanel);
            panel1.Controls.Add(ExitButton);
            panel1.Controls.Add(LoansButton);
            panel1.Controls.Add(ClientsButton);
            panel1.Controls.Add(UserPanel);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 577);
            panel1.TabIndex = 2;
            // 
            // NavigationPanel
            // 
            NavigationPanel.BackColor = Color.FromArgb(0, 126, 249);
            NavigationPanel.Location = new Point(3, 353);
            NavigationPanel.Name = "NavigationPanel";
            NavigationPanel.Size = new Size(3, 100);
            NavigationPanel.TabIndex = 2;
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.FromArgb(24, 30, 54);
            ExitButton.Dock = DockStyle.Bottom;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.ForeColor = Color.FromArgb(0, 126, 249);
            ExitButton.Location = new Point(0, 525);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(186, 52);
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            ExitButton.Leave += ExitButton_Leave;
            // 
            // LoansButton
            // 
            LoansButton.BackColor = Color.FromArgb(24, 30, 54);
            LoansButton.Dock = DockStyle.Top;
            LoansButton.FlatAppearance.BorderSize = 0;
            LoansButton.FlatStyle = FlatStyle.Flat;
            LoansButton.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoansButton.ForeColor = Color.FromArgb(0, 126, 249);
            LoansButton.Location = new Point(0, 196);
            LoansButton.Name = "LoansButton";
            LoansButton.Size = new Size(186, 52);
            LoansButton.TabIndex = 1;
            LoansButton.Text = "Loans";
            LoansButton.UseVisualStyleBackColor = false;
            LoansButton.Click += LoansButton_Click;
            LoansButton.Leave += LoansButton_Leave;
            // 
            // ClientsButton
            // 
            ClientsButton.BackColor = Color.FromArgb(24, 30, 54);
            ClientsButton.Dock = DockStyle.Top;
            ClientsButton.FlatAppearance.BorderSize = 0;
            ClientsButton.FlatStyle = FlatStyle.Flat;
            ClientsButton.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClientsButton.ForeColor = Color.FromArgb(0, 126, 249);
            ClientsButton.Location = new Point(0, 144);
            ClientsButton.Name = "ClientsButton";
            ClientsButton.Size = new Size(186, 52);
            ClientsButton.TabIndex = 1;
            ClientsButton.Text = "Clients";
            ClientsButton.UseVisualStyleBackColor = false;
            ClientsButton.Click += ClientsButton_Click;
            ClientsButton.Leave += ClientsButton_Leave;
            // 
            // UserPanel
            // 
            UserPanel.Controls.Add(AppNameLabel);
            UserPanel.Controls.Add(HomePictureBox);
            UserPanel.Dock = DockStyle.Top;
            UserPanel.Location = new Point(0, 0);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(186, 144);
            UserPanel.TabIndex = 0;
            // 
            // AppNameLabel
            // 
            AppNameLabel.AutoSize = true;
            AppNameLabel.BackColor = Color.FromArgb(24, 30, 54);
            AppNameLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AppNameLabel.ForeColor = Color.FromArgb(0, 126, 249);
            AppNameLabel.Location = new Point(38, 99);
            AppNameLabel.Name = "AppNameLabel";
            AppNameLabel.Size = new Size(106, 16);
            AppNameLabel.TabIndex = 1;
            AppNameLabel.Text = "Loan Manager";
            // 
            // HomePictureBox
            // 
            HomePictureBox.Image = (Image)resources.GetObject("HomePictureBox.Image");
            HomePictureBox.Location = new Point(60, 22);
            HomePictureBox.Name = "HomePictureBox";
            HomePictureBox.Size = new Size(63, 63);
            HomePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            HomePictureBox.TabIndex = 0;
            HomePictureBox.TabStop = false;
            HomePictureBox.Click += HomePictureBox_Click;
            HomePictureBox.MouseEnter += HomePictureBox_MouseEnter;
            HomePictureBox.MouseLeave += HomePictureBox_MouseLeave;
            // 
            // FormLoaderPanel
            // 
            FormLoaderPanel.Dock = DockStyle.Fill;
            FormLoaderPanel.Location = new Point(186, 0);
            FormLoaderPanel.Name = "FormLoaderPanel";
            FormLoaderPanel.Size = new Size(765, 577);
            FormLoaderPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(951, 577);
            Controls.Add(FormLoaderPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            UserPanel.ResumeLayout(false);
            UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HomePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel UserPanel;
        private Label AppNameLabel;
        private PictureBox HomePictureBox;
        private Button ClientsButton;
        private Panel NavigationPanel;
        private Button ExitButton;
        private Button LoansButton;
        private Panel FormLoaderPanel;
    }
}
