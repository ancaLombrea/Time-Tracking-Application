using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    class TimeTracking
    {
        public int idTime { get; set; }

        public double minutes { get; set; }

        public DateTime date { get; set; }

        //public int idEmployee { get; set; }

        public Employee employee { get; set; }
        public int getId(Employee employee) { return employee.id;  }
       

    }
}
