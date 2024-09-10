using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Application
{
    class TimeSheetData
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=TuOanh;Initial Catalog=EmployeeMA;Integrated Security=True");
        public int EId { get; set; }
        public string working_date { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public string timestamp { get; set; }
        public List<TimeSheetData> timeSheetListData(string function, string ID)
        {
            List<TimeSheetData> listdata = new List<TimeSheetData>();
            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                    string selectData;
                    if (function == "View")
                        selectData = "select * from timeSheet";
                    else if (function == "Find")
                        selectData = "SELECT * FROM timeSheet where EId = '" + ID + "'";
                    else
                        return null;
                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TimeSheetData ed = new TimeSheetData();
                                ed.EId = (int)reader["EId"];
                                ed.working_date = reader["working_date"].ToString();
                                ed.status = reader["status"].ToString();
                                ed.reason = reader["reason"].ToString();
                                ed.timestamp = reader["timestamp"].ToString();
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
                    MessageBox.Show("Error: " + ex);
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
