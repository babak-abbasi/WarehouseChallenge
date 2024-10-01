using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Dto;
using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Repositories;
using WarehouseChallenge.Infrastructure.Data;

namespace WarehouseChallenge.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ProductRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public void AddNewProductAsync(Product product)
        {
            try
            {
                _warehouseDbContext.Database.ExecuteSqlRaw(
                        "EXEC AddNewProduct @ProductId, @ProductName, @Price, @StockQuantity",
                        new SqlParameter("@ProductId", product.ProductId),
                        new SqlParameter("@ProductName", product.ProductName),
                        new SqlParameter("@Price", product.Price),
                        new SqlParameter("@StockQuantity", product.StockQuantity)
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
