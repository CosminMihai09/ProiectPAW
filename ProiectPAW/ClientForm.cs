﻿using ProiectPAW.Classes;
using ProiectPAW.Data;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NotificationControlApp;
using System.Data.Entity;

namespace ProiectPAW
{
    public partial class ClientForm : Form
    {
        private ClientViewModel viewModel;
        private NotificationControl notificationControl;

        public ClientForm()
        {
            InitializeComponent();
            viewModel = new ClientViewModel();
            BindControls();
            InitializeNotificationControl();
            LoadClients();
            ClientsDataGridView.KeyDown += ClientsDataGridView_KeyDown;
        }

        private void BindControls()
        {
            ClientsDataGridView.DataSource = viewModel.Clients;
            ClientsDataGridView.SelectionChanged += ClientsDataGridView_SelectionChanged;

            NameTextBox.DataBindings.Add("Text", viewModel, "SelectedClient.Name", true, DataSourceUpdateMode.OnPropertyChanged);
            AddressRichTextBox.DataBindings.Add("Text", viewModel, "SelectedClient.Address", true, DataSourceUpdateMode.OnPropertyChanged);
            EmailTextBox.DataBindings.Add("Text", viewModel, "SelectedClient.Email", true, DataSourceUpdateMode.OnPropertyChanged);
            PhoneTextBox.DataBindings.Add("Text", viewModel, "SelectedClient.Phone", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        internal void LoadClients()
        {
            try
            {
                viewModel.LoadClients();
                var clients = viewModel.Clients.Select(c => new
                {
                    c.ClientId,
                    c.Name,
                    c.Address,
                    c.Email,
                    c.Phone,
                    c.DateAdded,
                    LoanCount = c.Loans.Count
                }).ToList();

                ClientsDataGridView.DataSource = clients;
                ClientsDataGridView.Columns["ClientId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ClientsDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ClientsDataGridView.SelectedRows[0];
                int clientId = (int)selectedRow.Cells["ClientId"].Value;
                viewModel.SelectedClient = viewModel.Clients.FirstOrDefault(c => c.ClientId == clientId);
            }
            else
            {
                viewModel.SelectedClient = new Client();
            }
        }

        private void ClientsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true; // Prevent default delete behavior
                DeleteSelectedClient();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (viewModel.SelectedClient.ClientId == 0)
                {
                    viewModel.SelectedClient.DateAdded = DateTime.Now;
                    viewModel.AddClient(viewModel.SelectedClient);
                    ShowNotification("Client added successfully!");
                }
                else
                {
                    viewModel.UpdateClient(viewModel.SelectedClient);
                    ShowNotification("Client updated successfully!");
                }
                viewModel.LoadClients();
                RefreshDataGridView();
                ClearForm();
            }
        }

        private void RefreshDataGridView()
        {
            ClientsDataGridView.DataSource = null;
            LoadClients();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedClient();
        }

        private void DeleteSelectedClient()
        {
            if (viewModel.SelectedClient != null && viewModel.SelectedClient.ClientId != 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    viewModel.DeleteClient(viewModel.SelectedClient);
                    ShowNotification("Client deleted successfully!");
                    viewModel.SelectedClient = new Client();
                    RefreshDataGridView();
                }
            }
        }

        private void ClearForm()
        {
            NameTextBox.Clear();
            AddressRichTextBox.Clear();
            EmailTextBox.Clear();
            PhoneTextBox.Clear();
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
            notificationControl.Location = new Point(-70, -30);
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

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (viewModel.SelectedClient != null && viewModel.SelectedClient.ClientId != 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|Text files (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (saveFileDialog.FilterIndex == 1)
                        {
                            SerializationHelper.SerializeClientToJson(viewModel.SelectedClient, saveFileDialog.FileName);
                        }
                        else if (saveFileDialog.FilterIndex == 2)
                        {
                            SerializationHelper.SerializeClientToTxt(viewModel.SelectedClient, saveFileDialog.FileName);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No client selected for export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        client.Loans = new List<Loan>();
                        using (var context = new LoanContext())
                        {
                            context.Entry(client).State = EntityState.Detached; // Detach the entity to reset navigation properties

                            // Attach the imported client to the context and mark it as modified
                            var existingClient = context.Clients.Find(client.ClientId);
                            if (existingClient != null)
                            {
                                context.Entry(existingClient).CurrentValues.SetValues(client);
                            }
                            else
                            {
                                context.Clients.Attach(client);
                                context.Entry(client).State = EntityState.Added;
                            }

                            viewModel.SelectedClient = client;

                            context.SaveChanges();
                        }

                        ShowNotification("Client imported successfully!");

                        viewModel.LoadClients();
                        RefreshDataGridView();
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
