using Microsoft.EntityFrameworkCore;
using System.Net;

namespace onlinestore
{
        public class StoreDbContext : DbContext
        {
            readonly string _connectrionString =
                "Server = (localdb)\\MyDataBase; Database=OnlineStore;Trusted_Connection=True";

            public DbSet<Order> Orders { get; set; }
            public DbSet<Item> Items { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_connectrionString);
            }

        }
    
}

