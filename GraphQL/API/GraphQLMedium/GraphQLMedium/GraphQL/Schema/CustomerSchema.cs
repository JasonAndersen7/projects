using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLMedium.GraphQL.Queries;

namespace GraphQLMedium.GraphQL.Schema
{
    public class CustomerSchema : global::GraphQL.Types.Schema
    {   
        public CustomerSchema(IDependencyResolver resolver):   
            base(resolver)
        {      
            Query = resolver.Resolve<CustomerQuery>(); 
        }
    }
}
