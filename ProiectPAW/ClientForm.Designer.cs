namespace ProiectPAW
{
    partial class ClientForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            NameTextBox = new TextBox();
            PhoneTextBox = new TextBox();
            EmailTextBox = new TextBox();
            AddressTextBox = new TextBox();
            NameLabel = new Label();
            AddressLabel = new Label();
            PhoneLabel = new Label();
            EmailLabel = new Label();
            ClientsDataGridView = new DataGridView();
            SaveButton = new Button();
            DeleteButton = new Button();
            ErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(310, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 37);
            label1.TabIndex = 0;
            label1.Text = "Clients";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(97, 63);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(128, 23);
            NameTextBox.TabIndex = 1;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(299, 106);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(128, 23);
            PhoneTextBox.TabIndex = 2;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(299, 63);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(128, 23);
            EmailTextBox.TabIndex = 3;
            EmailTextBox.Validating += EmailTextBox_Validating;
            EmailTextBox.Validated += EmailTextBox_Validated;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(97, 106);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(128, 23);
            AddressTextBox.TabIndex = 4;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.ForeColor = Color.White;
            NameLabel.Location = new Point(53, 66);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 5;
            NameLabel.Text = "Name:";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.ForeColor = Color.White;
            AddressLabel.Location = new Point(43, 109);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(52, 15);
            AddressLabel.TabIndex = 6;
            AddressLabel.Text = "Address:";
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.ForeColor = Color.White;
            PhoneLabel.Location = new Point(255, 109);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(44, 15);
            PhoneLabel.TabIndex = 7;
            PhoneLabel.Text = "Phone:";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.ForeColor = Color.White;
            EmailLabel.Location = new Point(255, 66);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(39, 15);
            EmailLabel.TabIndex = 8;
            EmailLabel.Text = "Email:";
            // 
            // ClientsDataGridView
            // 
            ClientsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientsDataGridView.Location = new Point(0, 176);
            ClientsDataGridView.Name = "ClientsDataGridView";
            ClientsDataGridView.Size = new Size(735, 302);
            ClientsDataGridView.TabIndex = 9;
            ClientsDataGridView.SelectionChanged += ClientsDataGridView_SelectionChanged;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(567, 147);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 10;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(648, 147);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // ErrorProvider
            // 
            ErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ErrorProvider.ContainerControl = this;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(733, 477);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(ClientsDataGridView);
            Controls.Add(EmailLabel);
            Controls.Add(PhoneLabel);
            Controls.Add(AddressLabel);
            Controls.Add(NameLabel);
            Controls.Add(AddressTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(PhoneTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox NameTextBox;
        private TextBox PhoneTextBox;
        private TextBox EmailTextBox;
        private TextBox AddressTextBox;
        private Label NameLabel;
        private Label AddressLabel;
        private Label PhoneLabel;
        private Label EmailLabel;
        private DataGridView ClientsDataGridView;
        private Button SaveButton;
        private Button DeleteButton;
        private ErrorProvider ErrorProvider;
    }
}