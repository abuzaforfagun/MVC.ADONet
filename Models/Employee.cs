using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ADONet.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public Company Company { get; set; }
        public Person Person { get; set; }
        public int Salary { get; set; }
        public Designation Designation { get; set; }

    }
}