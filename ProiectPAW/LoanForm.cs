using ProiectPAW.Classes;
using ProiectPAW.Data;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NotificationControlApp;

namespace ProiectPAW
{
    public partial class LoanForm : Form
    {
        private LoanViewModel viewModel;
        private NotificationControl notificationControl;

        public LoanForm()
        {
            InitializeComponent();
            viewModel = new LoanViewModel();
            BindControls();
            InitializeNotificationControl();
        }

        private void BindControls()
        {
            // Bind DataGridView to Loans list
            LoadLoans();
            LoansDataGridView.SelectionChanged += LoansDataGridView_SelectionChanged;

            // Bind individual fields to SelectedLoan
            AmountTextBox.DataBindings.Add("Text", viewModel, "SelectedLoan.Amount", true, DataSourceUpdateMode.OnPropertyChanged);
            InterestRateTextBox.DataBindings.Add("Text", viewModel, "SelectedLoan.InterestRate", true, DataSourceUpdateMode.OnPropertyChanged);
            DurationTextBox.DataBindings.Add("Text", viewModel, "SelectedLoan.DurationMonths", true, DataSourceUpdateMode.OnPropertyChanged);

            // Bind ComboBox to Clients list and SelectedLoan.ClientId
            ClientComboBox.DataSource = viewModel.Clients;
            ClientComboBox.DisplayMember = "Name";
            ClientComboBox.ValueMember = "ClientId";
            ClientComboBox.DataBindings.Add("SelectedValue", viewModel, "SelectedLoan.ClientId", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadLoans()
        {
            LoansDataGridView.DataSource = viewModel.Loans;
        }

        private void LoansDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (LoansDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = LoansDataGridView.SelectedRows[0];
                int loanId = (int)selectedRow.Cells["LoanId"].Value;
                viewModel.SelectedLoan = viewModel.Loans.FirstOrDefault(l => l.LoanId == loanId);
            }
            else
            {
                viewModel.SelectedLoan = new LoanViewModelItem();
            }
        }

        private void LoansDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true; // Prevent default delete behavior
                DeleteSelectedLoan();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (viewModel.SelectedLoan.LoanId == 0)
                {
                    var loan = new Loan
                    {
                        Amount = viewModel.SelectedLoan.Amount,
                        InterestRate = viewModel.SelectedLoan.InterestRate,
                        DurationMonths = viewModel.SelectedLoan.DurationMonths,
                        ClientId = viewModel.SelectedLoan.ClientId
                    };
                    viewModel.AddLoan(loan);
                    ShowNotification("Loan added successfully!");
                }
                else
                {
                    var loan = new Loan
                    {
                        LoanId = viewModel.SelectedLoan.LoanId,
                        Amount = viewModel.SelectedLoan.Amount,
                        InterestRate = viewModel.SelectedLoan.InterestRate,
                        DurationMonths = viewModel.SelectedLoan.DurationMonths,
                        ClientId = viewModel.SelectedLoan.ClientId
                    };
                    viewModel.UpdateLoan(loan);
                    ShowNotification("Loan updated successfully!");
                }
                RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            LoansDataGridView.DataSource = null;
            LoadLoans();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedLoan();
        }

        private void DeleteSelectedLoan()
        {
            if (viewModel.SelectedLoan != null && viewModel.SelectedLoan.LoanId != 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this loan?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var loan = new Loan
                    {
                        LoanId = viewModel.SelectedLoan.LoanId
                    };
                    viewModel.DeleteLoan(loan);
                    ShowNotification("Loan deleted successfully!");
                    viewModel.SelectedLoan = new LoanViewModelItem();
                    RefreshDataGridView();
                }
            }
        }

        private void InitializeNotificationControl()
        {
            notificationControl = new NotificationControl();
            notificationControl.Size = new Size(300, 100);
            notificationControl.Location = new Point(
                this.ClientSize.Width - notificationControl.Width - 10,
                this.ClientSize.Height - notificationControl.Height - 10);
            notificationControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(notificationControl);
            notificationControl.Hide(); // Hide initially
        }

        private void ShowNotification(string message)
        {
            notificationControl.SetMessage(message);
            notificationControl.Location = new Point(
                this.ClientSize.Width - notificationControl.Width - 10,
                this.ClientSize.Height - notificationControl.Height - 10);
            notificationControl.Show();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                notificationControl.Hide();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
