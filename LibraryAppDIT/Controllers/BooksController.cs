/*By Victor Zacchi
 * DIT: D16128783
 * Masters in Advanced Software Development
 * Year: 1 
 * date: 04/12/2017 */  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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

        public ViewResult Library()
        {
            var books = _dbcontext.Books.Include(b => b.GenreType).ToList();

            if (User.IsInRole("StoreManager"))
                return View(books);
            else
                return View("ViewOnly", books);

        }

         [Authorize(Roles = "StoreManager")]
        public ActionResult BookForm()
        {
            var genreTypes = _dbcontext.GenreTypes.ToList();
            var bookViewModel = new BookFormViewModel
            {
                GenreTypes = genreTypes
            };

            return View(bookViewModel);
        }

        [Authorize(Roles = "StoreManager")]
        public ActionResult BookDetails(int id)
        {
            var BookDetails = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);

            if (BookDetails == null)
                return HttpNotFound();

            return View(BookDetails);
        }

        [ValidateAntiForgeryToken]
        public ActionResult PostSave(Book book)
        {
            if (!ModelState.IsValid)
            {
                var bookViewModel = new BookFormViewModel(book)
                {
                    Book = book,
                    GenreTypes = _dbcontext.GenreTypes.ToList()
                };

                return View("BookForm", bookViewModel);
            }

            if (book.ISBN == 0)
            {
                _dbcontext.Books.Add(book);
            }
            else
            {
                var bookInDB = _dbcontext.Books.Single(b => b.ISBN == book.ISBN);

                bookInDB.Title = book.Title;
                bookInDB.GenreTypeId = book.GenreTypeId;
                bookInDB.Author = book.Author;
                bookInDB.publishedYear = book.publishedYear;

            }
            _dbcontext.SaveChanges();

            return RedirectToAction("Library", "Books");
        }

        public ActionResult Update(int id)
        {
            var bookInDB = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);

            var viewBookModel = new BookFormViewModel(bookInDB)
            {
                GenreTypes = _dbcontext.GenreTypes.ToList()
            };
            return View("BookForm", viewBookModel);
        }
    }
}