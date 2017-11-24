using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ADONet.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Address Address { get; set; }


    }
}