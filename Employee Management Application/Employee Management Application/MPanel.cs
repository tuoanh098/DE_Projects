using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Application
{
    internal class MPanel
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=TuOanh;Initial Catalog=EmployeeMA;Integrated Security=True");

        public List<string> getEmployeePanel()
        {
            List<string> data = new List<string>();
            try
            {
                
                conn.Open();
                string ActiveEmployees = "SELECT COUNT(DISTINCT e.EId) AS ActiveEmployees\r\nFROM Employees e\r\nINNER JOIN timeSheet t  ON e.EId = t.EId\r\nWHERE t.Status = 'Working' and DAY(working_date) = DAY(GETDATE());";
                string InctiveEmployees = "SELECT COUNT(DISTINCT e.EId) AS ActiveEmployees\r\nFROM Employees e\r\nINNER JOIN timeSheet t  ON e.EId = t.EId\r\nWHERE t.Status = 'Absent' and DAY(working_date) = DAY(GETDATE());";
                string TotalEmployees = "SELECT COUNT(distinct EId) AS Total FROM Employees";
                SqlCommand command;
                SqlDataReader reader;
                using (command = new SqlCommand(ActiveEmployees, conn))
                {
                    using (reader = command.ExecuteReader()) // Execute the query
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            data.Add(reader[0].ToString());

                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }
                    }
                }
                using (command = new SqlCommand(InctiveEmployees, conn))
                {
                    using (reader = command.ExecuteReader()) // Execute the query
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            data.Add(reader[0].ToString());
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }
                    }
                }
                using (command = new SqlCommand(TotalEmployees, conn))
                {
                    using (reader = command.ExecuteReader()) // Execute the query
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            data.Add(reader[0].ToString()); ;
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return  data;
        }
    }
}
