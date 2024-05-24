using ProiectPAW.Classes;
using ProiectPAW.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class LoanForm : Form
    {
        private LoanContext context;
        private int selectedLoanId = -1;

        public LoanForm()
        {
            InitializeComponent();
            context = new LoanContext();
        }
        private void LoadLoans()
        {
            var loans = context.Loans.Include(l => l.Client).ToList();
            LoansDataGridView.DataSource = loans;
        }

        private void LoadClients()
        {
            ClientComboBox.DataSource = context.Clients.ToList();
            ClientComboBox.DisplayMember = "Name";
            ClientComboBox.ValueMember = "ClientId";
        }

        private void LoanForm_Load(object sender, EventArgs e)
        {
            LoadClients();
            LoadLoans();
        }

        private void LoansDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (LoansDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = LoansDataGridView.SelectedRows[0];
                selectedLoanId = (int)selectedRow.Cells["LoanId"].Value;
                AmountTextBox.Text = selectedRow.Cells["Amount"].Value.ToString();
                InterestRateTextBox.Text = selectedRow.Cells["InterestRate"].Value.ToString();
                DurationTextBox.Text = selectedRow.Cells["DurationMonths"].Value.ToString();
                ClientComboBox.SelectedValue = selectedRow.Cells["ClientId"].Value;
            }
            else
            {
                ClearForm();
                selectedLoanId = -1;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (selectedLoanId == -1) // Add new loan
            {
                var loan = new Loan
                {
                    Amount = decimal.Parse(AmountTextBox.Text),
                    InterestRate = decimal.Parse(InterestRateTextBox.Text),
                    DurationMonths = int.Parse(DurationTextBox.Text),
                    ClientId = (int)ClientComboBox.SelectedValue
                };
                context.Loans.Add(loan);
            }
            else // Update existing loan
            {
                var loan = context.Loans.Find(selectedLoanId);
                if (loan != null)
                {
                    loan.Amount = decimal.Parse(AmountTextBox.Text);
                    loan.InterestRate = decimal.Parse(InterestRateTextBox.Text);
                    loan.DurationMonths = int.Parse(DurationTextBox.Text);
                    loan.ClientId = (int)ClientComboBox.SelectedValue;
                    context.Entry(loan).State = EntityState.Modified;
                }
            }
            context.SaveChanges();
            LoadLoans();
            ClearForm();
        }

        private void ClearForm()
        {
            AmountTextBox.Clear();
            InterestRateTextBox.Clear();
            DurationTextBox.Clear();
            DurationTextBox.Text = "";
            ClientComboBox.SelectedIndex = -1;
            selectedLoanId = -1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedLoanId != -1)
            {
                var loan = context.Loans.Find(selectedLoanId);
                if (loan != null)
                {
                    context.Loans.Remove(loan);
                    context.SaveChanges();
                    LoadLoans();
                    ClearForm();
                }
            }
        }
    }
}
