using System;
using System.Collections.Generic;
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

            return _dbcontext.Books.ToList();
        }

        public Book GetBook(int id)
        {
            var book = _dbcontext.Books.SingleOrDefault(b => b.ISBN == id);
            //var book = _dbcontext.Books.GroupBy(x => x.Genre).Select(z => new
            //{
            //    Genre = z.Key,
            //    Count = z.Count()
            //});

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
                bookInDb.Genre = book.Genre;
                bookInDb.Genre = book.Genre;
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
