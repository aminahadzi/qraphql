using dwsGraph.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwsGraph.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Book id");
            Field(x => x.Name).Description("Book title");
            Field(x => x.Author).Description("Book author");
            Field(x => x.NumberOfPages).Description("Number of pages");
        }
    }
}
