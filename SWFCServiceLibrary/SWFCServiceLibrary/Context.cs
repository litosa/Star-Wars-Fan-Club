using SWFCServiceLibrary.Models;
using System.Data.Entity;

namespace SWFCServiceLibrary
{
    class Context : DbContext
    {
        public Context() : base("SWFC")
        {

        }

        public DbSet<WallData> Wall { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Chat> Chat { get; set; }

    }
}
