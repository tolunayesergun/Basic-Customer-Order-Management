using Bussiness.Services.Abstracts;
using Core.Models.Entities;
using Data.Repositories.Abstracts;

namespace Bussiness.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<bool> AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public Task<bool> DeleteCustomer(Customer Customer)
        {
            return _customerRepository.DeleteCustomer(Customer); 
        }

        public Task<List<Customer>> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Task<Customer> GetCustomer(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }
    }
}
