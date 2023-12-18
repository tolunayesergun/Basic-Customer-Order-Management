using Bussiness.Services.Abstracts;
using Core.Models.Entities;
using Data.Repositories.Abstracts;

namespace Bussiness.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public Task<bool> AddOrder(Order Order)
        {
            Order.OrderCode = GenerateCode();
            return _OrderRepository.AddOrder(Order);
        }

        public Task<bool> DeleteOrder(Order order)
        {
            return _OrderRepository.DeleteOrder(order);
        }

        public Task<List<Order>> GetAllOrders()
        {
            return _OrderRepository.GetAllOrders();
        }

        public Task<Order> GetOrder(int id)
        {
            return _OrderRepository.GetOrder(id);
        }

        public Task<bool> UpdateOrder(Order Order)
        {
            return _OrderRepository.UpdateOrder(Order);
        }
        private static string GenerateCode()
        {
            var random = new Random();
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int codeLength = 6;

            char[] chars = new char[codeLength];
            for (int i = 0; i < codeLength; i++)
            {
                chars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
    }
}
