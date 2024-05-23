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
            this.NavigationPanel.Height = this.ClientsButton.Height;
            this.NavigationPanel.Top = this.ClientsButton.Top;
            this.NavigationPanel.Left = this.ClientsButton.Left;
            this.ClientsButton.BackColor = Color.FromArgb(46, 51, 73);
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
        //5:01
        //https://www.youtube.com/watch?v=3ox-6NFAt8I&list=PLnduT0vjaiCqB0kBdybP4vD2b0iR8X82z&index=2&ab_channel=CodeCraks
        }

        private void LoansButton_Click(object sender, EventArgs e)
        {
            this.NavigationPanel.Height = this.LoansButton.Height;
            this.NavigationPanel.Top = this.LoansButton.Top;
            this.NavigationPanel.Left = this.LoansButton.Left;
            this.LoansButton.BackColor = Color.FromArgb(46, 51, 73);
            this.ClientsButton.BackColor = Color.FromArgb(24, 30, 54);
            this.ExitButton.BackColor = Color.FromArgb(24, 30, 54);

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
    }
}
