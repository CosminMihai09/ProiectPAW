using System.Runtime.InteropServices;

namespace ProiectPAW
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public MainForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            this.FormLoaderPanel.Controls.Clear();
            HomeForm homeForm = new HomeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            homeForm.FormBorderStyle = FormBorderStyle.None;
            this.FormLoaderPanel.Controls.Add(homeForm);
            homeForm.Show();
            this.NavigationPanel.Height = 0;
        }

        private void ClientsButton_Click(object sender, EventArgs e)
        {
            this.NavigationPanel.Height = this.ClientsButton.Height;
            this.NavigationPanel.Top = this.ClientsButton.Top;
            this.NavigationPanel.Left = this.ClientsButton.Left;
            this.ClientsButton.BackColor = Color.FromArgb(46, 51, 73);
            this.LoansButton.BackColor = Color.FromArgb(24, 30, 54);
            this.ExitButton.BackColor = Color.FromArgb(24, 30, 54);

            this.FormLoaderPanel.Controls.Clear();
            ClientForm clientForm = new ClientForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            clientForm.FormBorderStyle = FormBorderStyle.None;
            this.FormLoaderPanel.Controls.Add(clientForm);
            clientForm.Show();
        }

        private void LoansButton_Click(object sender, EventArgs e)
        {
            this.NavigationPanel.Height = this.LoansButton.Height;
            this.NavigationPanel.Top = this.LoansButton.Top;
            this.NavigationPanel.Left = this.LoansButton.Left;
            this.LoansButton.BackColor = Color.FromArgb(46, 51, 73);
            this.ClientsButton.BackColor = Color.FromArgb(24, 30, 54);
            this.ExitButton.BackColor = Color.FromArgb(24, 30, 54);

            this.FormLoaderPanel.Controls.Clear();
            LoanForm loanForm = new LoanForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            loanForm.FormBorderStyle = FormBorderStyle.None;
            this.FormLoaderPanel.Controls.Add(loanForm);
            loanForm.Show();
        }

        private void ClientsButton_Leave(object sender, EventArgs e)
        {
            this.ClientsButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void LoansButton_Leave(object sender, EventArgs e)
        {
            this.LoansButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void ExitButton_Leave(object sender, EventArgs e)
        {
            this.LoansButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomePictureBox_Click(object sender, EventArgs e)
        {
            this.FormLoaderPanel.Controls.Clear();
            HomeForm homeForm = new HomeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            homeForm.FormBorderStyle = FormBorderStyle.None;
            this.FormLoaderPanel.Controls.Add(homeForm);
            homeForm.Show();
            this.NavigationPanel.Height = 0;
        }
    }
}
