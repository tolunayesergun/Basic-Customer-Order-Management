using Core.Models.Entities;

namespace Bussiness.Services.Abstracts
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<bool> AddOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(Order order);
    }
}
