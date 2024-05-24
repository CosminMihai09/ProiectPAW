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
            ((System.ComponentModel.ISupportInitialize)ClientsDataGridView).BeginInit();
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
            NameTextBox.Location = new Point(131, 69);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(128, 23);
            NameTextBox.TabIndex = 1;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(464, 112);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(128, 23);
            PhoneTextBox.TabIndex = 2;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(464, 69);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(128, 23);
            EmailTextBox.TabIndex = 3;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(131, 112);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(128, 23);
            AddressTextBox.TabIndex = 4;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.ForeColor = Color.White;
            NameLabel.Location = new Point(87, 72);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 5;
            NameLabel.Text = "Name:";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.ForeColor = Color.White;
            AddressLabel.Location = new Point(77, 115);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(52, 15);
            AddressLabel.TabIndex = 6;
            AddressLabel.Text = "Address:";
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.ForeColor = Color.White;
            PhoneLabel.Location = new Point(420, 115);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(44, 15);
            PhoneLabel.TabIndex = 7;
            PhoneLabel.Text = "Phone:";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.ForeColor = Color.White;
            EmailLabel.Location = new Point(420, 72);
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
            ClientsDataGridView.Size = new Size(733, 302);
            ClientsDataGridView.TabIndex = 9;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(733, 477);
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
    }
}