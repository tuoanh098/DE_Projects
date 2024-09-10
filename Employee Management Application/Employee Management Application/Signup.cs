using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Employee_Management_Application
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        public SqlConnection conn = new SqlConnection(@"Data Source=TuOanh;Initial Catalog=EmployeeMA;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void Signup_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }
        private void ClearTextboxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Perform validation (if needed)
            try
            {
                bool isValidPassword = textBox4.Text == textBox3.Text;
                string emailRegex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                bool isValidEmail = Regex.IsMatch(textBox2.Text, emailRegex);

                //raise error
                errorProvider1.SetError(textBox4, isValidPassword ? null : "Re-enter password is incorrect !");
                errorProvider1.SetError(textBox2, isValidEmail ? null : "Invalid email address");
                if (isValidPassword && isValidEmail)
                {
                    string email = textBox2.Text;
                    string password = textBox3.Text;
                    try
                    {
                        conn.Open();
                        // Use parameterized queries to prevent SQL injection
                        string query = "INSERT INTO Auth (_email, _password) VALUES (@email, @password)";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Add parameters with sanitized values
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        // Execute the query and get affected rows count

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully inserted!");
                            ClearTextboxes(); // Call a function to clear textboxes
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); // Handle specific SqlException
                    }
                    catch (Exception ex) // Catch other general exceptions
                    {
                        MessageBox.Show("Unexpected error: " + ex.Message);
                    }
                }
                else { MessageBox.Show("Check your email and password!"); }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
