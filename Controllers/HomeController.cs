using MVC.ADONet.Models;
using MVC.ADONet.Presistances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ADONet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Company company = new Company();
            company.Name = "DataSoft 2";
            company.Address = new Address
            {
                FirstLine = "20 Floor",
                LastLine = "Adabor",
                PostalCode = "1208",
                City = new City
                {
                    Name = "Dhaka",
                    Country = new Country
                    {
                        Name = "Bangladesh"
                    }
                }
            };
            CompanyHandler companyHandler = new CompanyHandler();
            var addedCompany  = companyHandler.Add(company);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}