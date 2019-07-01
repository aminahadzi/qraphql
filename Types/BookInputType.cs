using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwsGraph.Types
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("author");
            Field<IntGraphType>("numberOfPages");
        }
    }
}
