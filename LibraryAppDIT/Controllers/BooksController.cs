using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppDIT.Models;
using LibraryAppDIT.ViewModels;

namespace LibraryAppDIT.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
                private ApplicationDbContext _dbcontext;

        public BooksController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbcontext.Dispose();
        }

        // GET: Customers
        public ViewResult Library()
        {

            var customers = _dbcontext.Books.ToList();

            return View(customers);
        }
        
        public ActionResult BookDetails(int id)
        {
            var BookDetails = _dbcontext.Books.SingleOrDefault(c => c.ISBN == id);

            if (BookDetails == null)
                return HttpNotFound();

            return View(BookDetails);
        }


        //public ActionResult Library()
        //{
        //    var book = new Book() { Title = "Book 1" };

        //    var viewModel = new LibraryBookViewModel
        //    {
        //        Book = book
        //    };

        //    return View(viewModel);
        //}
    }
}