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
        private ApplicationDbContext _dbcontext;

        public CustomersController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbcontext.Dispose();
        }

        // GET: Customers
        public ViewResult LibraryCustomer()
        {

            var customers = _dbcontext.Customers.ToList();

            return View(customers);
        }
        
        public ActionResult Details(int id)
        {
            var customerDetails = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDetails == null)
                return HttpNotFound();

            return View(customerDetails);
        }




        // GET: Customers
        //public ActionResult LibraryCustomer()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new LibraryBookViewModel
        //    {
        //        Customers = customers

        //    };

        //    return View(viewModel);
        //}
    }
}