﻿namespace ProiectPAW
{
    partial class LoanForm
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
            LoansLabel = new Label();
            SuspendLayout();
            // 
            // LoansLabel
            // 
            LoansLabel.AutoSize = true;
            LoansLabel.Font = new Font("Segoe UI", 20F);
            LoansLabel.ForeColor = Color.White;
            LoansLabel.Location = new Point(310, 122);
            LoansLabel.Name = "LoansLabel";
            LoansLabel.Size = new Size(86, 37);
            LoansLabel.TabIndex = 1;
            LoansLabel.Text = "Loans";
            // 
            // LoanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(733, 477);
            Controls.Add(LoansLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoanForm";
            Text = "LoanForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LoansLabel;
    }
}