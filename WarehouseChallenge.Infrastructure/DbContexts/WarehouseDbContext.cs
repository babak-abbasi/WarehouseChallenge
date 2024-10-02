using Microsoft.EntityFrameworkCore;
using WarehouseChallenge.Domain.Entities;

namespace WarehouseChallenge.Infrastructure.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
