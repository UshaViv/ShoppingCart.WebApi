using ShoppingCart.Domain.Models;

namespace ShoppingCart.Application.Services
{
    public class OrderQueue
    {
        private readonly Queue<Order> orders = new Queue<Order>();

        public void Enqueue(Order order)
        {
            orders.Enqueue(order);
            Console.WriteLine($"Order {order.OrderId} for {order.ProductName} added to the queue.");
        }

        public Order? Dequeue()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("Queue is empty.");
                return null;
            }

            Order order = orders.Dequeue();
            Console.WriteLine($"Order {order.OrderId} for {order.ProductName} dequeued.");
            return order;
        }

        public int Count
        {
            get { return orders.Count; }
        }
    }
}
