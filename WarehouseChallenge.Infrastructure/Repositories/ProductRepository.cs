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

        public Product DoesExist(int productId)
        {
            try
            {
                return _warehouseDbContext.Products.FirstOrDefault(f => f.ProductId == productId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product DoesExist(string productName)
        {
            try
            {
                return _warehouseDbContext.Products.FirstOrDefault(f => f.ProductName == productName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddNewProductByProcedure(Product product)
        {
            try
            {
                var result = _warehouseDbContext.Database.SqlQueryRaw<string>(
                    "EXEC AddNewProduct @ProductId, @ProductName, @Price",
                        new SqlParameter("@ProductId", product.ProductId),
                        new SqlParameter("@ProductName", product.ProductName),
                        new SqlParameter("@Price", product.Price))
                    .ToList()
                    .FirstOrDefault();

                if (result is not null)
                    return result;
                else return "There has been an issue in Database please check with administrator";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddNewProduct(Product product)
        {
            try
            {
                _warehouseDbContext.Products.Add(product);
                _warehouseDbContext.SaveChanges();

                return "Product added successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
