using dwsGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwsGraph.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book AddBook(Book todo);
        Book DeleteBook(int id);
        Book GetBookById(int id);
    }
}
