using GraphQL.Types;
using GraphQLMedium.GraphQL.GraphTypes;
using GraphQLMedium.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLMedium.GraphQL.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerQuery(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            Field<ListGraphType<CustomerType>>
            ("customers", 
                resolve: context => _customerRepository.GetAll());
            Field<CustomerType>
            ("customer",
                arguments: new QueryArguments(new  
                    QueryArgument<IntGraphType> {Name = "id"}),
                resolve: 
                context=>_customerRepository.GetCustomerById(
            context.GetArgument<int>("id")));
        }
    }
}
