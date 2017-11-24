using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ADONet.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string FirstLine { get; set; }
        public string LastLine { get; set; }
        public City City { get; set; }
        public string PostalCode { get; set; }

    }
}