using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public void AddNewProduct(Product product)
        {
            try
            {
                _warehouseDbContext.Database.ExecuteSqlRaw(
                    "EXEC AddNewProduct @ProductId, @ProductName, @Price, @StockQuantity",
                    new SqlParameter("@ProductId", product.ProductId),
                    new SqlParameter("@ProductName", product.ProductName),
                    new SqlParameter("@Price", product.Price),
                    new SqlParameter("@StockQuantity", product.StockQuantity));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddNewTransaction(Transaction transaction)
        {
            try
            {
                _warehouseDbContext.Database.ExecuteSqlRaw(
                    "EXEC AddNewTransaction @TransactionId, @ProductID, @WarehouseID, @TransactionType, @Quantity, @TransactionDate",
                    new SqlParameter("@TransactionId", transaction.TransactionId),
                    new SqlParameter("@ProductID", transaction.ProductId),
                    new SqlParameter("@WarehouseID", transaction.WarehouseId),
                    new SqlParameter("@TransactionType", transaction.TransactionType),
                    new SqlParameter("@Quantity", transaction.Quantity),
                    new SqlParameter("@TransactionDate", transaction.TransactionDate));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
