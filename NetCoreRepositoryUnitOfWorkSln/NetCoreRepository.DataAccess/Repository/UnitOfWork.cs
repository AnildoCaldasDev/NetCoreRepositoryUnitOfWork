using NetCoreRepository.DataAccess.Context;
using NetCoreRepository.DataAccess.Domain;
using System;


namespace NetCoreRepository.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public AppDbContext _context;
        private Repository<Customer> _customerRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public UnitOfWork()
        {
            _context = new AppDbContext();
        }


        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return _customerRepository = _customerRepository ?? new Repository<Customer>(_context);
            }
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public void RollBack()
        {
            this._context.Dispose();
        }
    }
}
