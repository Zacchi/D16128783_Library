using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryAppDIT.Models;

namespace LibraryAppDIT.Controllers.WebApi
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbcontext;

        public CustomersController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbcontext.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _dbcontext.Customers.SingleOrDefault(cx => cx.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer InsertCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _dbcontext.Customers.SingleOrDefault(cx => cx.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            else 
            {
                customerInDb.Name = customer.Name;
                customerInDb.DOB = customer.DOB;
                customerInDb.Address = customer.Address;
                customerInDb.Email = customer.Email;
                customerInDb.PhoneNumber = customer.PhoneNumber;

                _dbcontext.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _dbcontext.Customers.SingleOrDefault(cx => cx.Id == id);

            if (customerInDb == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);

        else
            _dbcontext.Customers.Remove(customerInDb);
            _dbcontext.SaveChanges();
        }
    }
}

