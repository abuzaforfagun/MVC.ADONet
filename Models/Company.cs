using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ADONet.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}