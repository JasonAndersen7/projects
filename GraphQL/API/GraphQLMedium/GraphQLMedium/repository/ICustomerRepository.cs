using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLMedium.Entities;

namespace GraphQLMedium.repository
{
   public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int id);
    }
}
