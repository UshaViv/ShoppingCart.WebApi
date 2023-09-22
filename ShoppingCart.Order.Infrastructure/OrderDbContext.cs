using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, constraints, and defaults here.
        }
    }
}