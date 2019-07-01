using dwsGraph.Mutations;
using dwsGraph.Queries;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwsGraph.Schema
{
    public class BookSchema : GraphQL.Types.Schema
    {
        public BookSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BookQuery>();
            Mutation = resolver.Resolve<BookMutation>();
        }
    }
}
