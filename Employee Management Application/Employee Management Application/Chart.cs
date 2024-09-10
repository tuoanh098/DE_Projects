using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Application
{
    public partial class Chart : UserControl
    {
        public Chart()
        {
            InitializeComponent();
            displayChart();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void displayChart()
        {
            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 4;

            chart1.Series[0].XValueMember = "active";
            chart1.Series[0].YValueMembers = "active";

            chart1.Series[1].XValueMember = "inactive";
            chart1.Series[1].YValueMembers = "inactive";


            chart1.DataSource = GetChartData(); // Fetch data from the database
            chart1.DataBind();

            int maxTotal = GetTotalFromDatabase();
            chart1.ChartAreas[0].AxisY.Maximum = maxTotal;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tuoan\OneDrive\Máy tính\Employee Management Application\Employee Management Application\Database1.mdf;Integrated Security=True";
        private DataTable GetChartData()
        {
            // Implement your data retrieval logic here


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM mydb"; // Adjust the query as per your table structure
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        private int GetTotalFromDatabase()
        {
            // Implement your data retrieval logic here to fetch the "total" value from the database
            // Replace this with your actual database query
            int total = 0; // Placeholder value

            // Example logic to fetch the total value from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT total FROM mydb"; // Adjust query as per your table structure
                SqlCommand command = new SqlCommand(query, connection);
                total = (int)command.ExecuteScalar(); // Assuming total is an integer value
            }

            return total;
        }
        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Chart_Load(object sender, EventArgs e)
        {
            displayChart();
        }
    }
}
