﻿using System;
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

        [Authorize (Roles = "StoreManager")]
        public ActionResult NewCx()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerVM
                {
                    Customer = customer
                };

                return View("NewCx", viewModel);
                
            }

            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges(); 
            return RedirectToAction("LibraryCustomer", "Customers");
        }

        // GET: Customers
        [Authorize]
        public ViewResult LibraryCustomer()
        {
            if (User.IsInRole("StoreManager"))
                return View("LibraryCustomer");
            else
                return View("StaffPageView");
        }

        [Authorize]
        public ActionResult CxDetails(int id)
        {
            var cxDetails = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);

            if (cxDetails == null)
                return HttpNotFound();

            return View(cxDetails);
        }
    }
}