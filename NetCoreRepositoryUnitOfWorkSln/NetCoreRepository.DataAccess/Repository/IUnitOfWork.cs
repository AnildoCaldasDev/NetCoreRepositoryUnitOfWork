using NetCoreRepository.DataAccess.Domain;

namespace NetCoreRepository.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        void Commit();

        void RollBack();
    }
}
