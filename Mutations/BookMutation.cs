using dwsGraph.Models;
using dwsGraph.Repositories;
using dwsGraph.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwsGraph.Mutations
{
    public class BookMutation : ObjectGraphType
    {
        public BookMutation(IBookRepository bookRepository)
        {
            Field<BookType>(
            "addBook",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
            resolve: ctx =>
            {
                var todo = ctx.GetArgument<Book>("book");
                return bookRepository.AddBook(todo);
            });
            Field<BookType>(
                "removeBook",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return bookRepository.DeleteBook(id);
                });
        }
    }
}
