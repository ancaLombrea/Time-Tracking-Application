using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        EmployeeService employeeService;
        public Form1()
        {

            InitializeComponent();
            employeeService = new EmployeeService();
            employeeService.createConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var employeeList = employeeService.GetEmployees();

            comboBox1.DataSource = employeeList;
            comboBox1.DisplayMember = "name";
                       
            /*
            var timetrackingList = employeeService.GetTimeTracking();
            comboBox1.DataSource = timetrackingList; 
            comboBox1.DisplayMember = "id_time";
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());
           // MessageBox.Show(employeeService.GetLastIdEmployees().ToString());
            
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            // verific daca e ales ceva din lista 
            if(comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Choose an employee from the list!");
            }
            else
            {
                //string s = employeeService.PostEmployees();
                //MessageBox.Show(s);


                // pun la angajatul ales  
                Employee employee = (Employee)comboBox1.SelectedItem;

                // trebuie sa iau ultimul id de la timetracking cu o metoda 
                int timeid = employeeService.GetLastIdTimeTracking()+1;

                if(textBox_date.Text.Length == 0 || textBox_in.Text.Length == 0 || textBox_out.Text.Length == 0)
                {
                    MessageBox.Show("Complete each field!");                  
                }
                else
                {
                    string str = employeeService.PostTimeTracking(timeid,employee, textBox_in.Text, textBox_out.Text, textBox_date.Text);
                   
                    TimeSpan hour = DateTime.ParseExact(textBox_out.Text, "HH:mm:ss", CultureInfo.InvariantCulture)
                      - DateTime.ParseExact(textBox_in.Text, "HH:mm:ss", CultureInfo.InvariantCulture);  // diferenta dintre check-out si check-in
                    double seconds = hour.TotalSeconds;  // timpul in secunde 
                    double min = seconds / 60;
                    
                    MessageBox.Show(str);
                    string str2 =  employeeService.PostEmployees(employee, min);
                    MessageBox.Show(str2);
                }
                                      
            }
       
        }
    }
}
