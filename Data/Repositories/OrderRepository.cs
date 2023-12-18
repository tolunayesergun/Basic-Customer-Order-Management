using Core.Helpers;
using Core.Models.Entities;
using Data.Contexts;
using Data.Repositories.Abstracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        Task<bool> IOrderRepository.AddOrder(Order Order)
        {
            try
            {
                _context.Add(Order);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult(false);
            }
        }

        Task<bool> IOrderRepository.DeleteOrder(Order Order)
        {
            try
            {
                _context.Remove(Order);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Task.FromResult(false);
            }
        }

        Task<List<Order>> IOrderRepository.GetAllOrders()
        {
            return _context.Orders.Include(x => x.Customer).ToListAsync();

        }

        Task<Order> IOrderRepository.GetOrder(int id)
        {
            return _context.Orders.Include(x => x.Customer).FirstOrDefaultAsync(m => m.Id == id);
        }

        Task<bool> IOrderRepository.UpdateOrder(Order Order)
        {
            try
            {
                _context.Update(Order);
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
