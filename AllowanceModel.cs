using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EmployeeAllowanceApp.Model
{
 public class AllowanceModel
    {
        [PrimaryKey, AutoIncrement]
        public int serialNo { get; set; }
        public long Employeekey { get; set; }

        public int AllowanceId { get; set; }
        
        public DateTime ClockDate { get; set; }

        public string AllowanceName { get; set; }

        public decimal AllowanceAmount { get; set; }
        public bool isUpload { get; set; }


    }
}

