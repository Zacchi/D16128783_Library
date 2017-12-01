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
        {//WHAT IS THIS FOR?
            _dbcontext.Dispose();
        }

        [Authorize (Roles = "StoreManager")]
        public ActionResult MemberForm()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult PostSave(Customer customer)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewCustomerVM
            //    {
            //        Customer = customer
            //    };

            //    return View("MemberForm", viewModel);
                
            //}

            if (customer.Id == 0)
            {
                _dbcontext.Customers.Add(customer); 
            }
            else
            {
                var customerInDB = _dbcontext.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.DOB = customer.DOB;
                customerInDB.Address = customer.Address;
                customerInDB.Email = customer.Email;
                customerInDB.PhoneNumber = customer.PhoneNumber;
            }

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

            //if (cxDetails == null)
            //    return HttpNotFound();

            return View(cxDetails);
        }

        //Edit
        public ActionResult Update(int id)
        {
            var customerInDB = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            
            var viewCxModel = new NewCustomerVM
            {
                Customer = customerInDB
            };
                return View("MemberForm", viewCxModel);
        }
    }
}