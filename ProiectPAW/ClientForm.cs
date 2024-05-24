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
using System.Xml.Linq;

namespace ProiectPAW
{
    public partial class ClientForm : Form
    {
        private LoanContext context;
        private int selectedClientId = -1;

        public ClientForm()
        {
            InitializeComponent();
            context = new LoanContext();
        }

        private void LoadClients()
        {
            var clients = context.Clients.ToList();
            ClientsDataGridView.DataSource = clients;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void ClientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ClientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ClientsDataGridView.SelectedRows[0];
                selectedClientId = (int)selectedRow.Cells["ClientId"].Value;
                NameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();
                AddressTextBox.Text = selectedRow.Cells["Address"].Value.ToString();
                EmailTextBox.Text = selectedRow.Cells["Email"].Value.ToString();
                PhoneTextBox.Text = selectedRow.Cells["Phone"].Value.ToString();
            }
            else
            {
                ClearForm();
                selectedClientId = -1;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (selectedClientId == -1)
                {
                    var client = new Client
                    {
                        Name = NameTextBox.Text,
                        Address = AddressTextBox.Text,
                        Email = EmailTextBox.Text,
                        Phone = PhoneTextBox.Text
                    };
                    context.Clients.Add(client);
                }
                else
                {
                    var client = context.Clients.Find(selectedClientId);
                    if (client != null)
                    {
                        client.Name = NameTextBox.Text;
                        client.Address = AddressTextBox.Text;
                        client.Email = EmailTextBox.Text;
                        client.Phone = PhoneTextBox.Text;
                        context.Entry(client).State = EntityState.Modified;
                    }
                }
                context.SaveChanges();
                LoadClients();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            NameTextBox.Clear();
            AddressTextBox.Clear();
            EmailTextBox.Clear();
            PhoneTextBox.Clear();
            selectedClientId = -1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedClientId != -1)
            {
                var client = context.Clients.Find(selectedClientId);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                    LoadClients();
                    ClearForm();
                }
            }
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidEmail(EmailTextBox.Text))
            {
                e.Cancel = true;
                ErrorProvider.SetError(EmailTextBox, "Invalid email address");
            }
        }

        private void EmailTextBox_Validated(object sender, EventArgs e)
        {
            ErrorProvider.SetError(EmailTextBox, "");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

/* Mai ai de facut validari si la celelalte campuri cum ai facut la email. Vezi daca ai cum sa
 * mai departezi putin error providerul ala de text bosuri.
 * Dupa trebuie sa faci acelasi lucru si pentru LoanForm si sa te mai uiti ce cerinte mai are si programul
 * 
 * !!! ATENTIE: Citeste despre EntityFramework ca esti o jigodie si nu stii dar ar fi trebuit sa stii pana acum.
 * Cand rulezi aplicatia se salveaza datele dar dupa se sterg. Banuiesc ca el creaza un fel de temporary DB.