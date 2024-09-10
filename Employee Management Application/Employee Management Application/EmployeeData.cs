using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Employee_Management_Application
{
    class EmployeeData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public string address { get; set; }
        public string job { get; set; }
        public int EId { get; set; }
        public string eImage { get; set; }

        public SqlConnection conn = new SqlConnection(@"Data Source=TuOanh;Initial Catalog=EmployeeMA;Integrated Security=True");
        public List<EmployeeData> employeeListData(string function, string ID)
        {
            List<EmployeeData> listdata = new List<EmployeeData>();
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                    string selectData = "";
                    if (function == "View")
                        selectData = "SELECT * FROM Employees";
                    else if (function == "Find")
                    {
                        selectData = "SELECT * FROM Employees where EId = '"+ID+"'";
                    }
                    else
                    {
                        return null;
                    }
                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                EmployeeData ed = new EmployeeData();
                                ed.EId = (int)reader["EId"]; // Access by column name
                                ed.firstName = reader["firstName"].ToString();
                                ed.lastName = reader["lastName"].ToString();
                                ed.gender = reader["gender"].ToString();
                                ed.phone = reader["phone"].ToString();
                                ed.email = reader["email"].ToString();
                                ed.salary = (int)reader["salary"];
                                ed.address = reader["address"].ToString();
                                ed.job = reader["job"].ToString();
                                ed.eImage = reader["eImage"].ToString();
                                listdata.Add(ed);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found in Employees table.");
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            return listdata;
        }

    }
}
