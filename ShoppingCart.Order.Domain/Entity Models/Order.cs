
namespace ShoppingCart.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
