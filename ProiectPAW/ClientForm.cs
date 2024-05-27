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
            this.LoadClients();
        }

        internal void LoadClients()
        {
            var clients = context.Clients.Include(c => c.Loans).ToList();
            ClientsDataGridView.DataSource = clients.Select(c => new
            {
                c.ClientId,
                c.Name,
                c.Address,
                c.Email,
                c.Phone,
                c.DateAdded,
                LoanCount = c.Loans.Count
            }).ToList();
        }

        private void ClientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ClientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ClientsDataGridView.SelectedRows[0];
                selectedClientId = (int)selectedRow.Cells["ClientId"].Value;
                NameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();
                AddressRichTextBox.Text = selectedRow.Cells["Address"].Value.ToString();
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
                        Address = AddressRichTextBox.Text,
                        Email = EmailTextBox.Text,
                        Phone = PhoneTextBox.Text,
                        DateAdded = DateTime.Now
                    };
                    context.Clients.Add(client);
                }
                else
                {
                    var client = context.Clients.Find(selectedClientId);
                    if (client != null)
                    {
                        client.Name = NameTextBox.Text;
                        client.Address = AddressRichTextBox.Text;
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
            AddressRichTextBox.Clear();
            EmailTextBox.Clear();
            PhoneTextBox.Clear();
            selectedClientId = -1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.DeleteClient();
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

        //Data validation
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

        private void DeleteClient()
        {
            if (selectedClientId != -1)
            {
                var client = context.Clients.Find(selectedClientId);
                if (client != null)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        context.Clients.Remove(client);
                        context.SaveChanges();
                        LoadClients();
                        ClearForm();
                    }
                }
            }
        }

        //Alt Shortcut
        private void ClientsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.DeleteClient();
            }
        }

        //Data Serialization as .json or .txt
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (selectedClientId != -1)
            {
                var client = context.Clients.Find(selectedClientId);
                if (client != null)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (saveFileDialog.FilterIndex == 1)
                            {
                                SerializationHelper.SerializeClientToJson(client, saveFileDialog.FileName);
                            }
                            else if (saveFileDialog.FilterIndex == 2)
                            {
                                SerializationHelper.SerializeClientToTxt(client, saveFileDialog.FileName);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No client selected for export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Client client = SerializationHelper.DeserializeClientFromJson(openFileDialog.FileName);
                    if (client != null)
                    {
                        NameTextBox.Text = client.Name;
                        AddressRichTextBox.Text = client.Address;
                        EmailTextBox.Text = client.Email;
                        PhoneTextBox.Text = client.Phone;
                    }
                    else
                    {
                        MessageBox.Show("Failed to import client data.", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

/* !!! ATENTIE: Citeste despre EntityFramework ca esti o jigodie si nu stii dar ar fi trebuit sa stii pana acum.
 * Cand rulezi aplicatia se salveaza datele dar dupa se sterg. Banuiesc ca el creaza un fel de temporary DB. */