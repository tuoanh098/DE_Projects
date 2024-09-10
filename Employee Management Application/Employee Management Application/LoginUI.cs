using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Employee_Management_Application
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        public SqlConnection conn = new SqlConnection(@"Data Source=TuOanh;Initial Catalog=EmployeeMA;Integrated Security=True");
        private void LoginUI_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string emailRegex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

            // Trim leading and trailing whitespace
            emailRegex = emailRegex.Trim();

            // Check if the entered email matches the regex
            bool isValidEmail = Regex.IsMatch(textBox1.Text, emailRegex);

            // Set the error provider based on validation result
            errorProvider1.SetError(textBox1, isValidEmail ? null : "Invalid email address");
        }

        private void LoginUI_MouseHover(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter your email")
                textBox1.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    MessageBox.Show("Invalid!", "Error");
                else
                    Check_Authentication();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void Check_Authentication()
        {
            string username = textBox1.Text, password = textBox2.Text;
            try
            {
                String querry = "select * from Auth where _email = '" + username + "' and _password = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    password = textBox2.Text;
                    EMA emaForm = new EMA();
                    emaForm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Wrong password or email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally { conn.Close(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Check_Authentication();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Signup signupui = new Signup();
            // Add event handler for Signup form closing
            signupui.Show();
            signupui.FormClosed += SignupFormClosed;
            this.Hide();
        }
        private void SignupFormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the login form back when Signup form closes
            this.Show();
        }
        private void EmaFormClosed(object sender, FormClosedEventArgs e)
        {
            // Close the Login form when the EMA form closes
            this.Close();
        }

        private void EmaFormLogOut(object sender, FormClosedEventArgs e)
        {
            // Close the Login form when the EMA form closes
            this.Show();
        }
        private void LoginUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoginUI_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter your password")
                textBox2.Text = "";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
        }
    }
}
