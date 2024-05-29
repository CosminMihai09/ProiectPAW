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
            try
            {
                InitializeComponent();
                Log("Initialized components");

                viewModel = new LoanViewModel();
                Log("Initialized viewModel");

                BindControls();
                Log("Bound controls");

                InitializeNotificationControl();
                Log("Initialized notification control");

                LoadLoans();
                Log("Loaded loans");

                // Add KeyDown event handler
                LoansDataGridView.KeyDown += LoansDataGridView_KeyDown;
            }
            catch (Exception ex)
            {
                Log("Error in LoanForm constructor: " + ex.Message);
                MessageBox.Show("Error initializing LoanForm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindControls()
        {
            LoansDataGridView.DataSource = viewModel.Loans;
            LoansDataGridView.SelectionChanged += LoansDataGridView_SelectionChanged;

            AmountTextBox.DataBindings.Add("Text", viewModel, "SelectedLoan.Amount", true, DataSourceUpdateMode.OnPropertyChanged);
            InterestRateTextBox.DataBindings.Add("Text", viewModel, "SelectedLoan.InterestRate", true, DataSourceUpdateMode.OnPropertyChanged);
            DurationTextBox.DataBindings.Add("Text", viewModel, "SelectedLoan.DurationMonths", true, DataSourceUpdateMode.OnPropertyChanged);

            ClientComboBox.DataSource = viewModel.Clients;
            ClientComboBox.DisplayMember = "Name";
            ClientComboBox.ValueMember = "ClientId";
            ClientComboBox.DataBindings.Add("SelectedValue", viewModel, "SelectedLoan.ClientId", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadLoans()
        {
            try
            {
                viewModel.LoadLoans();
                LoansDataGridView.DataSource = null;
                LoansDataGridView.DataSource = viewModel.Loans;
            }
            catch (Exception ex)
            {
                Log("Error in LoadLoans: " + ex.Message);
                MessageBox.Show("Error loading loans: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                e.Handled = true;
                ConfirmAndDeleteSelectedLoan();
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
            viewModel.LoadLoans();
            LoansDataGridView.DataSource = null;
            LoansDataGridView.DataSource = viewModel.Loans;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ConfirmAndDeleteSelectedLoan();
        }

        private void ConfirmAndDeleteSelectedLoan()
        {
            if (viewModel.SelectedLoan != null && viewModel.SelectedLoan.LoanId != 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this loan?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var loan = viewModel.context.Loans.Find(viewModel.SelectedLoan.LoanId);
                        if (loan != null)
                        {
                            viewModel.context.Loans.Remove(loan);
                            viewModel.context.SaveChanges();
                            ShowNotification("Loan deleted successfully!");
                            viewModel.SelectedLoan = new LoanViewModelItem();
                            RefreshDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Loan not found. It may have already been deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting loan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void InitializeNotificationControl()
        {
            notificationControl = new NotificationControl();
            notificationControl.Size = new Size(300, 100);
            notificationControl.Location = new Point(10, 10); // Position in the top left corner
            notificationControl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Controls.Add(notificationControl);
            notificationControl.Hide();
        }

        private void ShowNotification(string message)
        {
            notificationControl.SetMessage(message);
            notificationControl.Location = new Point(10, 10); // Ensure it's still positioned in the top left corner
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

        private void Log(string message)
        {
            // Implement your logging logic here. For example, write to a file or console.
            Console.WriteLine(message);
        }
    }

}
