namespace ProiectPAW
{
    partial class HomeForm
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
            ChartPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ChartPictureBox).BeginInit();
            SuspendLayout();
            // 
            // ChartPictureBox
            // 
            ChartPictureBox.Dock = DockStyle.Fill;
            ChartPictureBox.Location = new Point(0, 0);
            ChartPictureBox.Name = "ChartPictureBox";
            ChartPictureBox.Size = new Size(765, 577);
            ChartPictureBox.TabIndex = 0;
            ChartPictureBox.TabStop = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(765, 577);
            Controls.Add(ChartPictureBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeForm";
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)ChartPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox ChartPictureBox;
    }
}