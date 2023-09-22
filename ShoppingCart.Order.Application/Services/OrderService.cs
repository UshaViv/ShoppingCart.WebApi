using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain.Models;
using ShoppingCart.Infrastructure;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.Application.Services
{
    public class OrderService : Repository<Order>, IOrderService
    {
        private readonly ILogger<OrderService> _logger;

        public OrderService(OrderDbContext orderDbContext, ILogger<OrderService> logger)
            : base(orderDbContext)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetOrdersPageAsync(int page, int pageSize)
        {
            _logger.LogInformation("GetOrdersPage Service started");
            _logger.LogInformation($"Page : {page} PageSize : {pageSize}");

            IQueryable<Order> ordersQuery = GetAllQuerybleAsync();

            int skipCount = (page - 1) * pageSize;

            var ordersPage = await ordersQuery
                .OrderBy(p => p.OrderId)
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();

            _logger.LogInformation($"orders Count: {ordersPage.Count}");

            return ordersPage;
        }

        public bool PlaceOrdersInQueue(Order order)
        {
            var orderQueue = new OrderQueue();

            orderQueue.Enqueue(
                new Order
                {
                    OrderId = order.OrderId,
                    ProductName = order.ProductName,
                    TotalAmount = order.TotalAmount
                }
            );

            return orderQueue.Count > 0;
        }
    }
}
