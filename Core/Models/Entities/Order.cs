using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities
{
    [Index(nameof(OrderCode), IsUnique = true)]
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OrderCode { get; set; }

    }
}
