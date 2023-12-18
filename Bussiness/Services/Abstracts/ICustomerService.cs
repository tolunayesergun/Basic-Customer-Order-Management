using Core.Models.Entities;

namespace Bussiness.Services.Abstracts
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(int id);
        Task<bool> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(Customer customer);
    }
}
