using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dwsGraph.Models;

namespace dwsGraph.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public Book AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();

            return book;
        }

        public Book DeleteBook(int id)
        {
            var book = _db.Books.Find(id);

            _db.Books.Remove(book);
            _db.SaveChanges();

            return book;
        }

        public Book GetBookById(int id)
        {
            return _db.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _db.Books;
        }
    }
}
