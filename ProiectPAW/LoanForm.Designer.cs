namespace ProiectPAW
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
            LoansDataGridView = new DataGridView();
            DeleteButton = new Button();
            SaveButton = new Button();
            DurationLabel = new Label();
            ClientLabel = new Label();
            InterestRateLabel = new Label();
            AmountLabel = new Label();
            InterestRateTextBox = new TextBox();
            AmountTextBox = new TextBox();
            DurationTextBox = new TextBox();
            ClientComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)LoansDataGridView).BeginInit();
            SuspendLayout();
            // 
            // LoansLabel
            // 
            LoansLabel.AutoSize = true;
            LoansLabel.Font = new Font("Segoe UI", 20F);
            LoansLabel.ForeColor = Color.White;
            LoansLabel.Location = new Point(313, 9);
            LoansLabel.Name = "LoansLabel";
            LoansLabel.Size = new Size(86, 37);
            LoansLabel.TabIndex = 1;
            LoansLabel.Text = "Loans";
            // 
            // LoansDataGridView
            // 
            LoansDataGridView.BackgroundColor = Color.FromArgb(64, 64, 64);
            LoansDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LoansDataGridView.Dock = DockStyle.Bottom;
            LoansDataGridView.Location = new Point(0, 189);
            LoansDataGridView.Name = "LoansDataGridView";
            LoansDataGridView.Size = new Size(765, 388);
            LoansDataGridView.TabIndex = 2;
            LoansDataGridView.SelectionChanged += LoansDataGridView_SelectionChanged;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(678, 106);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 13;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(597, 106);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 12;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DurationLabel
            // 
            DurationLabel.AutoSize = true;
            DurationLabel.ForeColor = Color.White;
            DurationLabel.Location = new Point(242, 66);
            DurationLabel.Name = "DurationLabel";
            DurationLabel.Size = new Size(56, 15);
            DurationLabel.TabIndex = 19;
            DurationLabel.Text = "Duration:";
            // 
            // ClientLabel
            // 
            ClientLabel.AutoSize = true;
            ClientLabel.ForeColor = Color.White;
            ClientLabel.Location = new Point(254, 109);
            ClientLabel.Name = "ClientLabel";
            ClientLabel.Size = new Size(41, 15);
            ClientLabel.TabIndex = 18;
            ClientLabel.Text = "Client:";
            // 
            // InterestRateLabel
            // 
            InterestRateLabel.AutoSize = true;
            InterestRateLabel.ForeColor = Color.White;
            InterestRateLabel.Location = new Point(19, 109);
            InterestRateLabel.Name = "InterestRateLabel";
            InterestRateLabel.Size = new Size(75, 15);
            InterestRateLabel.TabIndex = 17;
            InterestRateLabel.Text = "Interest Rate:";
            // 
            // AmountLabel
            // 
            AmountLabel.AutoSize = true;
            AmountLabel.ForeColor = Color.White;
            AmountLabel.Location = new Point(40, 66);
            AmountLabel.Name = "AmountLabel";
            AmountLabel.Size = new Size(54, 15);
            AmountLabel.TabIndex = 16;
            AmountLabel.Text = "Amount:";
            // 
            // InterestRateTextBox
            // 
            InterestRateTextBox.Location = new Point(96, 106);
            InterestRateTextBox.Name = "InterestRateTextBox";
            InterestRateTextBox.Size = new Size(128, 23);
            InterestRateTextBox.TabIndex = 15;
            // 
            // AmountTextBox
            // 
            AmountTextBox.Location = new Point(96, 63);
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(128, 23);
            AmountTextBox.TabIndex = 14;
            // 
            // DurationTextBox
            // 
            DurationTextBox.Location = new Point(299, 63);
            DurationTextBox.Name = "DurationTextBox";
            DurationTextBox.Size = new Size(128, 23);
            DurationTextBox.TabIndex = 21;
            // 
            // ClientComboBox
            // 
            ClientComboBox.FormattingEnabled = true;
            ClientComboBox.Location = new Point(299, 106);
            ClientComboBox.Name = "ClientComboBox";
            ClientComboBox.Size = new Size(128, 23);
            ClientComboBox.TabIndex = 22;
            // 
            // LoanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(765, 577);
            Controls.Add(ClientComboBox);
            Controls.Add(DurationTextBox);
            Controls.Add(DurationLabel);
            Controls.Add(ClientLabel);
            Controls.Add(InterestRateLabel);
            Controls.Add(AmountLabel);
            Controls.Add(InterestRateTextBox);
            Controls.Add(AmountTextBox);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(LoansDataGridView);
            Controls.Add(LoansLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoanForm";
            Text = "LoanForm";
            ((System.ComponentModel.ISupportInitialize)LoansDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LoansLabel;
        private DataGridView LoansDataGridView;
        private Button DeleteButton;
        private Button SaveButton;
        private Label DurationLabel;
        private Label ClientLabel;
        private Label InterestRateLabel;
        private Label AmountLabel;
        private TextBox InterestRateTextBox;
        private TextBox AmountTextBox;
        private TextBox DurationTextBox;
        private ComboBox ClientComboBox;
    }
}