using NetCoreRepository.DataAccess.Context;
using NetCoreRepository.DataAccess.Domain;
using NetCoreRepository.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCoreRepository.BusinessLogic.Repository
{
    public class CustomerRepository : IRepository<Customer>, ICustomerRepository
    {
        AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Customer> Get(Expression<Func<Customer, bool>> predicate)
        {
            return _context.Customers.Where(predicate);
        }

        public Customer GetById(Expression<Func<Customer, bool>> predicate)
        {
            return _context.Customers.FirstOrDefault(predicate);
        }

        public IEnumerable<Customer> GetCustomersByName()
        {
            return Get().OrderBy(c => c.Name).ToList();
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
        }
    }
}
