using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_Application
{
    public partial class Help : Form
    {
        public Help()
        {
            Label label1 = new Label();
            label1.Text = "Help Page";
            label1.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(10, 10);
            label1.AutoSize = true;

            Label label2 = new Label();
            label2.Text = "Functions:";
            label2.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(10, 40);
            label2.AutoSize = true;

            Label label3 = new Label();
            label3.Text = "Add Employee:\r\nTo add a new employee, click on the \"Add Employee\" button.\r\nFill in the required details such as name, department, and contact information.\r\nClick the \"Save\" button to add the employee to the system.";
            label3.ForeColor = Color.Blue;
            label3.Location = new System.Drawing.Point(10, 70);
            label3.AutoSize = true;

            Label label4 = new Label();
            label4.Text = "Delete Employee:\r\nTo delete an employee, select the employee from the list.\r\nClick on the \"Delete\" button and confirm the action when prompted.";
            label4.Location = new System.Drawing.Point(10, 160);
            label4.AutoSize = true;
            label4.ForeColor = Color.Blue;

            Label label5 = new Label();
            label5.Text = "Find Employee:\r\nTo search for a specific employee, use the search bar at the top.\r\nType the name or ID of the employee you are looking for and press Enter.";
            label5.Location = new System.Drawing.Point(10, 250);
            label5.AutoSize = true;
            label5.ForeColor = Color.Blue;

            Label label6 = new Label();
            label6.Text = "Total Employees:\r\nTo view the total number of employees in the system, navigate to the \"Total Employees\" section.";
            label6.Location = new System.Drawing.Point(10, 340);
            label6.AutoSize = true;
            label6.ForeColor = Color.Blue;

            Label label7 = new Label();
            label7.Text = "Active Employees:\r\nTo view a list of active employees, go to the \"Active Employees\" tab.";
            label7.Location = new System.Drawing.Point(10, 430);
            label7.AutoSize = true;
            label7.ForeColor = Color.Blue;

            Label label8 = new Label();
            label8.Text = "Inactive Employees:\r\nTo view a list of inactive employees, switch to the \"Inactive Employees\" tab.";
            label8.Location = new System.Drawing.Point(10, 520);
            label8.AutoSize = true;
            label8.ForeColor = Color.Blue;

            Label label9 = new Label();
            label9.Text = "Update Timesheet:\r\nTo update an employee's timesheet, select the employee and click on the \"Update Timesheet\" button.\r\nEnter the new timesheet information and save the changes.";
            label9.Location = new System.Drawing.Point(10, 610);
            label9.AutoSize = true;
            label9.ForeColor = Color.Blue;

            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(label5);
            this.Controls.Add(label6);
            this.Controls.Add(label7);
            this.Controls.Add(label8);
            this.Controls.Add(label9);

            this.Size = new Size(765, 620); // Set the form size
            this.MinimumSize = new Size(765, 620); // Set minimum size to prevent resizing
            this.MaximumSize = new Size(765, 620); // Set maximum size to prevent resizing
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Prevent resizing by setting a fixed border style
            this.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Help_Load(object sender, EventArgs e)
        {

        }
    }
}
