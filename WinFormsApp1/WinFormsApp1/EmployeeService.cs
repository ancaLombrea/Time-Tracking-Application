using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp1
{
    internal class EmployeeService
    {
        static HttpClient client = new HttpClient();

        public object JsonSerializerOptions { get; private set; }

        public void createConnection()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8083/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // ******** GET 
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = null;
            HttpResponseMessage response = client.GetAsync("employee").Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);
                employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(resultString);
                return employees;
            }
            return null;
        }
        public List<TimeTracking> GetTimeTracking()
        {
            List<TimeTracking> timeTracking = null;
            HttpResponseMessage response = client.GetAsync("time_tracking").Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);
                timeTracking = System.Text.Json.JsonSerializer.Deserialize<List<TimeTracking>>(resultString);
                return timeTracking;
            }
            return null;
        }


        // ******** GET LAST ID
        public int GetLastIdEmployees()
        {
            List<Employee> employees = null;
            HttpResponseMessage response = client.GetAsync("employee").Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);
                employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(resultString);
                return employees.Count;
            }
            return 0;
        }
        public int GetLastIdTimeTracking()
        {
            List<TimeTracking> timeTracking = null;
            HttpResponseMessage response = client.GetAsync("time_tracking").Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);
                timeTracking = System.Text.Json.JsonSerializer.Deserialize<List<TimeTracking>>(resultString);
                return timeTracking.Count;
            }
            return 3;
        }


        // ******** POST
        public string PostEmployees(Employee employee, double minutes)
        {
            int id = employee.id;
            String name = employee.name;
            String hourlyRate = employee.hourlyRate;
            double h = double.Parse(hourlyRate);
            h = h + minutes;
            DateTime date = employee.enrollDate;
            var employee_new = new Employee()
            {
                id = id,
                name = name,
                hourlyRate = h.ToString(),
                enrollDate = date
            };
            //enrollDate = new DateTime(2014, 07, 03)

            string myEmployeePost = JsonConvert.SerializeObject(employee_new);         
            HttpContent st = new StringContent(myEmployeePost, UnicodeEncoding.UTF8, "application/json");
            var response = client.PostAsync("employee", st).Result;
            string resultContent = response.Content.ReadAsStringAsync().Result;
            return resultContent;
        }


        public string PostTimeTracking(int idTime,Employee employee, string checkin, string checkout, string date)
        {

            TimeSpan hour = DateTime.ParseExact(checkout, "HH:mm:ss", CultureInfo.InvariantCulture) 
                - DateTime.ParseExact(checkin, "HH:mm:ss", CultureInfo.InvariantCulture);  // diferenta dintre check-out si check-in
            double seconds = hour.TotalSeconds;  // timpul in secunde 
            double min = seconds / 60;  // timpul in minute 
            //double min = 60;

            var timetracking = new TimeTracking()
            {
                idTime = idTime,
                minutes = min,
                date = DateTime.Parse(date),
                employee = employee
            };

            string myTimePost = JsonConvert.SerializeObject(timetracking);
            HttpContent st = new StringContent(myTimePost, UnicodeEncoding.UTF8, "application/json");
            var response = client.PostAsync("time_tracking", st).Result;
            string resultContent = response.Content.ReadAsStringAsync().Result;
            return resultContent;
        }

    }
}
