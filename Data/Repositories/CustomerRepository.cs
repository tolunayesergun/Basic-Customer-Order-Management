using Core.Helpers;
using Core.Models.Entities;
using Data.Contexts;
using Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        Task<bool> ICustomerRepository.AddCustomer(Customer customer)
        {
            try
            {
                _context.Add(customer);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult(false);
            }
        }

        Task<bool> ICustomerRepository.DeleteCustomer(Customer customer)
        {
            try
            {
                _context.Remove(customer);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult(false);
            }
        }

        Task<List<Customer>> ICustomerRepository.GetAllCustomers()
        {
            return _context.Customers.ToListAsync();
        }

        Task<Customer> ICustomerRepository.GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
        }

        Task<bool> ICustomerRepository.UpdateCustomer(Customer customer)
        {
            try
            {
                _context.Update(customer);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
