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
        [Authorize(Roles = "StoreManager")]
        public ViewResult Library()
        {

            var books = _dbcontext.Books.ToList();

            return View(books);
        }

        [Authorize]
        public ActionResult BookDetails(int id)
        {
            var BookDetails = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);

            if (BookDetails == null)
                return HttpNotFound();

            return View(BookDetails);
        }

        public ActionResult BookForm()
        {
            return View();
        }

        public ActionResult PostSave(Book book)
        {
            if (book.ISBN == 0)
            {
                _dbcontext.Books.Add(book);
            }
            else
            {
                var bookInDB = _dbcontext.Books.Single(b => b.ISBN == book.ISBN);

                bookInDB.Title = book.Title;
                bookInDB.Genre = book.Genre;
                bookInDB.Author = book.Author;
                bookInDB.publishedYear = book.publishedYear;

            }
            _dbcontext.SaveChanges();

            return RedirectToAction("Library", "Books");
        }

        public ActionResult Update(int id)
        {
            var bookInDB = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);

            var viewBookModel = new LibraryBookViewModel
            {
                Book = bookInDB
            };
            return View("BookForm", viewBookModel);
        }
    }
}