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

        //private void LoadClients()
        //{
        //    var clients = context.Clients.ToList();
        //    dataGridViewClients.DataSource = clients;
        //}

        //private void AddClientButton_Click(object sender, EventArgs e)
        //{
        //    var client = new Client
        //    {
        //        Name = txtName.Text,
        //        Address = txtAddress.Text,
        //        Email = txtEmail.Text,
        //        Phone = txtPhone.Text
        //    };
        //    context.Clients.Add(client);
        //    context.SaveChanges();
        //    LoadClients();
        //}

        //private void UpdateClientButton_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewClients.SelectedRows.Count > 0)
        //    {
        //        int clientId = (int)dataGridViewClients.SelectedRows[0].Cells[0].Value;
        //        var client = context.Clients.Find(clientId);
        //        if (client != null)
        //        {
        //            client.Name = txtName.Text;
        //            client.Address = txtAddress.Text;
        //            client.Email = txtEmail.Text;
        //            client.Phone = txtPhone.Text;
        //            context.SaveChanges();
        //            LoadClients();
        //        }
        //    }
        //}

        //private void  DeleteClientButton_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewClients.SelectedRows.Count > 0)
        //    {
        //        int clientId = (int)dataGridViewClients.SelectedRows[0].Cells[0].Value;
        //        var client = context.Clients.Find(clientId);
        //        if (client != null)
        //        {
        //            context.Clients.Remove(client);
        //            context.SaveChanges();
        //            LoadClients();
        //        }
        //    }
        //}

        //private void ClientForm_Load(object sender, EventArgs e)
        //{
        //    LoadClients();
        //}
    }
}
