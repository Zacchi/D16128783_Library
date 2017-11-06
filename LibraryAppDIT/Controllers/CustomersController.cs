using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppDIT.Models;
using LibraryAppDIT.ViewModels;

namespace LibraryAppDIT.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult LibraryCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new LibraryBookViewModel
            {
                Customers = customers

            };

            return View(viewModel);
        }
    }
}