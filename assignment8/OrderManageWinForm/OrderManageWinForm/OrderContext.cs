using System;
using System.Data.Entity;
using System.Linq;

namespace OrderManageWinForm
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderContext")
        {
            Database.SetInitializer(
              new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}