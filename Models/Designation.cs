using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ADONet.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
    }
}