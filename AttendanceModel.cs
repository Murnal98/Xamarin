using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAllowanceApp.Model
{
   public partial class AttendanceModel
    {
        //public string ClockDate { get; set; }

        public long Employeekey { get; set; }

        public string EmployeeName { get; set; }

        public bool IsSelected { get; internal set; }
    }
}
