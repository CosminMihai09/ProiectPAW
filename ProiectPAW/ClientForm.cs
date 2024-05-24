using ProiectPAW.Classes;
using ProiectPAW.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            var client = new Client
            {
                Name = NameTextBox.Text,
                Address = AddressTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text
            };
            context.Clients.Add(client);
            context.SaveChanges();
            LoadClients();
        }

        private void UpdateClientButton_Click(object sender, EventArgs e)
        {
            if (ClientsDataGridView.SelectedRows.Count > 0)
            {
                int clientId = (int)ClientsDataGridView.SelectedRows[0].Cells[0].Value;
                var client = context.Clients.Find(clientId);
                if (client != null)
                {
                    client.Name = NameTextBox.Text;
                    client.Address = AddressTextBox.Text;
                    client.Email = EmailTextBox.Text;
                    client.Phone = PhoneTextBox.Text;
                    context.SaveChanges();
                    LoadClients();
                }
            }
        }

        private void DeleteClientButton_Click(object sender, EventArgs e)
        {
            if (ClientsDataGridView.SelectedRows.Count > 0)
            {
                int clientId = (int)ClientsDataGridView.SelectedRows[0].Cells[0].Value;
                var client = context.Clients.Find(clientId);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                    LoadClients();
                }
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }
    }
}
