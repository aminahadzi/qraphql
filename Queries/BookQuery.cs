using dwsGraph.Repositories;
using dwsGraph.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwsGraph.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IBookRepository bookRepository)
        {
            Field<ListGraphType<BookType>>(
                "Books",
                resolve: ctx => bookRepository.GetBooks());
            Field<BookType>(
                "getBookById",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return bookRepository.GetBookById(id);
                });
        }
    }
}
