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
        public ActionResult Library()
        {
            //var book = new List <Book>
            //{
            //      new Book = {Name = "Kite Runner"}, 
            //      new Book = {Name = "Book 2"} 
            //};

            var book = new Book() { Name = "Book 1" };

            var viewModel = new LibraryBookViewModel
            {
                Book = book
            };

            return View(viewModel);
        }
    }
}