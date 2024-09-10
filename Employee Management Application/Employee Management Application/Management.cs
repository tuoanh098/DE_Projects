using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Employee_Management_Application
{
    public partial class Management : UserControl
    {

        public SqlConnection conn = new SqlConnection(@"Data Source=TuOanh;Initial Catalog=EmployeeMA;Integrated Security=True");
        public Management()
        {
            InitializeComponent();
        }


        public void displayTimeSheetData()
        {
            TimeSheetData ed = new TimeSheetData();
            List<TimeSheetData> listData = ed.timeSheetListData("View", null);
            dataGridView2.DataSource = listData;
        }
        public void displayEmployeeData()
        {
            EmployeeData ed = new EmployeeData();
            List<EmployeeData> listData = ed.employeeListData("View", null);
            dataGridView1.DataSource = listData;
            dataGridView1.Columns["EId"].DisplayIndex = 0;

        }
        public void findEmployeeData(string ID)
        {
            EmployeeData ed = new EmployeeData();
            List<EmployeeData> listData = ed.employeeListData("Find", ID);
            dataGridView1.DataSource = listData;
        }
        public void findTimeSheetData(string ID)
        {
            TimeSheetData ed = new TimeSheetData();
            List<TimeSheetData> listData = ed.timeSheetListData("Find", ID);
            dataGridView2.DataSource = listData;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Add employee//
        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel5.Visible = false;
        }
        public bool Check_Text()
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0
                || textBox5.Text.Length == 0 || textBox6.Text.Length == 0) { return false; }
            return true;
        }
        private void ClearTextboxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = string.Empty;
        }
        public string Path;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.gif)|*.jpg; *.png;   *.gif | All Files(*.*) | *.* ";
            openFileDialog.Title = "Select an Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Path = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(Path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel5.Visible = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string EId = textBox7.Text;
                conn.Open();
                // Use parameterized queries to prevent SQL injection
                string query = "delete from Employees where EId = @EId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EId", EId);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Delete Employee Successfully!", "Announcement");
                    displayEmployeeData();
                }
                else
                {
                    MessageBox.Show("Delete failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            finally { conn.Close(); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //Get check valid email
                string emailRegex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                bool isValidEmail = Regex.IsMatch(textBox5.Text, emailRegex);
                if (isValidEmail && Check_Text())
                {
                    try
                    {
                        string firstName, lastName, gender, phone, email, address, job;
                        firstName = textBox1.Text;
                        lastName = textBox2.Text;
                        gender = comboBox1.Text;
                        phone = textBox4.Text;
                        email = textBox5.Text; ;
                        address = textBox3.Text;
                        job = textBox6.Text;

                        Image img = Image.FromFile(Path);
                        MemoryStream tmpStream = new MemoryStream();
                        img.Save(tmpStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        tmpStream.Seek(0, SeekOrigin.Begin);
                        byte[] imageData = new byte[img.Size.Height * img.Height];
                        tmpStream.Read(imageData, 0, img.Size.Height * img.Height);

                        conn.Open();
                        // Use parameterized queries to prevent SQL injection
                        string query = "INSERT INTO Employees (firstName, lastName, gender, phone, email, salary, address, job, eImage) " +
                            "VALUES (@firstName, @lastName, @gender, @phone, @email, @salary, @address, @job,  @eImage)";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Add parameters with sanitized values
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@salary", 0);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@job", job);
                        cmd.Parameters.AddWithValue("@eImage", (object)imageData);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        // Execute the query and get affected rows count

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully inserted to database!", "Announcement");
                            displayEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearTextboxes(); // Call a function to clear textboxes
                        pictureBox1.Image = null;
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
                else if (!Check_Text())
                {
                    MessageBox.Show("Please fill in data!");
                }
                else
                {
                    errorProvider1.SetError(textBox5, isValidEmail ? null : "Invalid email address");
                    MessageBox.Show("Check your email !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                displayEmployeeData();
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ID = textBox7.Text.Trim();
            if (dataGridView1.Visible == true)
            {
                findEmployeeData(ID);
            }
            else
            {
                findTimeSheetData(ID);
            }
            findEmployeeData(ID);
            // Get the EId from textbox7 and trim any leading/trailing spaces

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string EId = textBox7.Text;
            string salary = textBox9.Text;
            if (textBox9.Text.Length == 0)
            {
                try
                {
                    string status, reason;
                    DateTime working_date = dateTimePicker1.Value;
                    status = comboBox2.Text;
                    reason = textBox8.Text;
                    conn.Open();

                    string query = "insert into TimeSheet (EId, working_date, status, reason) values" +
                        "(@EId, @working_date, @status, @reason)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EId", EId);
                    cmd.Parameters.AddWithValue("@working_date", working_date);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update Successfully!", "Announcement");
                    }
                    else
                    {
                        MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                finally
                {
                    displayTimeSheetData();
                    dataGridView2.Visible = true;
                    dataGridView1.Visible = false;
                    conn.Close();
                }
            }else
            {
                
                try {
                    conn.Open();
                    string query = @"UPDATE Employees 
                                    SET salary = @salary 
                                    WHERE EId = @EId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EId", EId);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update Successfully!", "Announcement");
                    }
                    else
                    {
                        MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                finally
                {
                    displayEmployeeData();
                    dataGridView1.Visible = true;
                    dataGridView2.Visible = false;
                    conn.Close();
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == true)
            {
                displayEmployeeData();
            }
            else
            {
                displayTimeSheetData();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string formattedDate = dateTime.ToString("dd/MM/yy");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            displayTimeSheetData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            displayEmployeeData();
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
