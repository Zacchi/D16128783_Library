
/*By Victor Zacchi
 * DIT: D16128783
 * Masters in Advanced Software Development
 * Year: 1 
 * date: 04/12/2017 */  


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using LibraryAppDIT.Models;

namespace LibraryAppDIT.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _dbcontext;
        
        public BooksController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        public IEnumerable<Book> GetBooks()
        {

            var booksSQL = _dbcontext.Books
                .Include(m => m.GenreType)
                .Where(m => m.ISBN > 0);

            //return _dbcontext.Books.ToList();
            return booksSQL
                .ToList();

        }

        public Book GetBook(int id)
        {
            var book = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);

            if (book == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return book;
        }      

        [HttpPost]
        public Book InsertBook(Book book)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();

            return book;
        }

        [HttpPut]
        public void UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bookInDb = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);

            if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            else
            {
                bookInDb.Title = book.Title;
                bookInDb.GenreType = book.GenreType;
                bookInDb.GenreType = book.GenreType;
                bookInDb.Author = book.Author;
                bookInDb.publishedYear = book.publishedYear;

                _dbcontext.SaveChanges();
            }
        }

         [HttpDelete]
        public void DeleteBook (int id)
        {
             var bookInDb = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);
             
             if (bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

             else
                _dbcontext.Books.Remove(bookInDb);
                _dbcontext.SaveChanges();
        }

    }
}
