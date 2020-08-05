using Microsoft.AspNetCore.Mvc;
using NetCoreRepository.BusinessLogic.BusinessLogic;
using NetCoreRepository.DataAccess.Domain;
using NetCoreRepository.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWrok;

        public CustomerController(IUnitOfWork unitOfWrok)
        {
            this._unitOfWrok = unitOfWrok;
        }


        // GET: api/<Customer>
        [HttpGet]
        public List<Customer> Get()
        {

            //try
            //{
            //    List<Customer> customers = this._unitOfWrok.CustomerRepository.Get().ToList();
            //    return customers;
            //}
            //catch (System.Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return null;
            //}



            using (CustomerBusinessLogic customerBll = new CustomerBusinessLogic(this._unitOfWrok))
            {
                try
                {
                    List<Customer> customers = customerBll.GetAllCustomers().ToList();
                    return customers;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        // GET api/<Customer>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            using (CustomerBusinessLogic customerBll = new CustomerBusinessLogic(this._unitOfWrok))
            {
                try
                {
                    Customer customer = customerBll.getCustomerById(id);
                    return customer;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        // POST api/<Customer>
        [HttpPost]
        public void Post([FromBody] Customer model)
        {
            using (CustomerBusinessLogic customerBll = new CustomerBusinessLogic(this._unitOfWrok))
            {
                try
                {
                    Customer customer = new Customer();
                    customer = model;
                    customerBll.AddCustomer(customer);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // PUT api/<Customer>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer model)
        {
            using (CustomerBusinessLogic customerBll = new CustomerBusinessLogic(this._unitOfWrok))
            {
                try
                {
                    if (id == model.Id)
                    {
                        Customer customer = customerBll.getCustomerById(id);

                        customer.Name = model.Name;
                        customer.Email = model.Email;
                        customerBll.UpdateCustomer(customer);
                    }
                    else
                    {
                        Console.WriteLine("Informações divergentes");
                    }

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (CustomerBusinessLogic customerBll = new CustomerBusinessLogic(this._unitOfWrok))
            {
                try
                {
                    Customer customer = customerBll.getCustomerById(id);
                    customerBll.DeleteCustomer(customer);

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
