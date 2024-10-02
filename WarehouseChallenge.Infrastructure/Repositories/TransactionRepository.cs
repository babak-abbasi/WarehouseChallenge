using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Enum;
using WarehouseChallenge.Domain.Repositories;
using WarehouseChallenge.Infrastructure.Data;

namespace WarehouseChallenge.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public TransactionRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public string AddNewTransactionByProcedure(Transaction transaction)
        {
            try
            {
                var result = _warehouseDbContext.Database
                    .SqlQueryRaw<string>(
                        "EXEC AddNewTransaction @TransactionId, @ProductID, @WarehouseID, @TransactionType, @Quantity, @TransactionDate",
                        new SqlParameter("@TransactionId", transaction.TransactionId),
                        new SqlParameter("@ProductID", transaction.ProductId),
                        new SqlParameter("@WarehouseID", transaction.WarehouseId),
                        new SqlParameter("@TransactionType", transaction.TransactionType.ToString()),
                        new SqlParameter("@Quantity", transaction.Quantity),
                        new SqlParameter("@TransactionDate", transaction.TransactionDate))
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

        public int GetProductStockInWarehouseByProcedure(int productId, int warehouseId)
        {
            try
            {
                var result = _warehouseDbContext.Database
                    .SqlQueryRaw<int>(
                    "EXEC GetProductStockInWarehouse @ProductId, @WarehouseId",
                    new SqlParameter("@ProductId", productId),
                    new SqlParameter("@WarehouseId", warehouseId))
                    .ToList()
                    .FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Transaction> GetTransactionsByTypeByProcedure(TransactionType transactionType)
        {
            try
            {
                var result = _warehouseDbContext
                    .Set<Transaction>()
                    .FromSqlRaw("EXEC GetTransactionsByType @TransactionType",
                    new SqlParameter("@TransactionType", transactionType.ToString()))
                    .ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Transaction DoesExist(int transactionId)
        {
            try
            {
                return _warehouseDbContext.Transactions.FirstOrDefault(f => f.TransactionId == transactionId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddNewTransaction(Transaction transaction)
        {
            try
            {
                _warehouseDbContext.Transactions.Add(transaction);

                var product = _warehouseDbContext.Products.FirstOrDefault(w => w.ProductId == transaction.ProductId);
                if (transaction.TransactionType == "Purchase")
                    product.StockQuantity += transaction.Quantity;
                else product.StockQuantity -= transaction.Quantity;

                _warehouseDbContext.SaveChanges();

                return "Transaction added successfully";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetProductStockInWarehouse(int productId, int warehouseId)
        {
            try
            {
                var purcahsedProducts = _warehouseDbContext
                    .Transactions
                    .Where(w => w.ProductId == productId
                            && w.WarehouseId == warehouseId
                            && w.TransactionType == "Purchase")
                    .Sum(s => s.Quantity);
                var soldProducts = _warehouseDbContext
                    .Transactions
                    .Where(w => w.ProductId == productId
                            && w.WarehouseId == warehouseId
                            && w.TransactionType == "Sale")
                    .Sum(s => s.Quantity);

                return purcahsedProducts - soldProducts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Transaction> GetTransactionsByType(TransactionType transactionType)
        {
            try
            {
                var result = _warehouseDbContext.Transactions.Where(w => w.TransactionType == transactionType.ToString());

                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
