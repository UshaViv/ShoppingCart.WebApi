using ShoppingCart.Domain.Models;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderService : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersPageAsync(int page, int pageSize);
        bool PlaceOrdersInQueue(Order order);
    }
}
