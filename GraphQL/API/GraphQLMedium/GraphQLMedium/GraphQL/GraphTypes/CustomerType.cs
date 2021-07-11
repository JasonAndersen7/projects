using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLMedium.Entities;

namespace GraphQLMedium.GraphQL.GraphTypes
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(cust => cust.Id);
            Field(cust => cust.Name);
            Field(cust => cust.City);
            Field(cust => cust.Address);
            Field(cust => cust.State);
            Field(cust => cust.Zipcode);
        }
    }
}
