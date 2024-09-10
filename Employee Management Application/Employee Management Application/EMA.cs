using System.Data;
using System.Data.SqlClient;

namespace Employee_Management_Application
{
    public partial class EMA : Form
    {
        private bool isLoggingOut = false;

        public EMA()
        {
            InitializeComponent();
            displayEmployeePanel();
        }
        private void EMA_Load(object sender, EventArgs e)
        {
            management1.Visible = false;
        }
        public void displayEmployeePanel()
        {
            MPanel ed = new MPanel();
            List<string> listData = ed.getEmployeePanel();
            label9.Text = listData[0];
            label6.Text = listData[1];
            label4.Text = listData[2];

        }

        private void EMA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If logging out, don't show the exit confirmation
            if (isLoggingOut)
            {
                return; // Allow the form to close
            }

            // Show a confirmation dialog
            var result = MessageBox.Show("Do you want to exit?", "Announcement", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit(); // Exit the entire application
            }
            else
            {
                e.Cancel = true; // Prevent the form from closing
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            management1.Visible = true;
            chart1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            management1.Visible = false;
            chart1.Visible = true;
            displayEmployeePanel();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void management1_Load(object sender, EventArgs e)
        {

        }

        private void dashBoard1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Help helpform = new Help();
            helpform.StartPosition = FormStartPosition.CenterScreen;
            helpform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Set the flag to indicate logout
            isLoggingOut = true;

            // Create and show the LoginForm
            LoginUI loginForm = new LoginUI();
            loginForm.Show();

            // Close the current EMA form
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
