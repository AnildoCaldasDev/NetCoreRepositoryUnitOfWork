using NetCoreRepository.DataAccess.Domain;
using NetCoreRepository.DataAccess.Repository;
using System;
using System.Collections.Generic;

namespace NetCoreRepository.BusinessLogic.BusinessLogic
{
    public class CustomerBusinessLogic : IDisposable
    {
        IUnitOfWork _uow;
        public CustomerBusinessLogic(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public CustomerBusinessLogic()
        {
            this._uow = new UnitOfWork();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _uow.CustomerRepository.Get();
        }

        public void AddCustomer(Customer entity)
        {
            try
            {
                _uow.CustomerRepository.Add(entity);
                _uow.Commit();
            }
            catch (System.Exception ex)
            {
                _uow.RollBack();
            }
        }
        public void DeleteCustomer(Customer entity)
        {
            _uow.CustomerRepository.Delete(entity);
        }

        public void UpdateCustomer(Customer entity)
        {
            _uow.CustomerRepository.Update(entity);
        }

        public Customer getCustomerById(int id)
        {
            return _uow.CustomerRepository.GetById(c => c.Id == id);
        }

        public void Dispose()
        {
            _uow.RollBack();
        }
    }
}

