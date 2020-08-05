using NetCoreRepository.DataAccess.Domain;
using NetCoreRepository.DataAccess.Repository;
using System.Collections.Generic;

namespace NetCoreRepository.BusinessLogic.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetCustomersByName();
    }
}
