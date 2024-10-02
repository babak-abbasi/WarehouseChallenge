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

        public string AddNewTransaction(Transaction transaction)
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

        public int GetProductStockInWarehouse(int productId, int warehouseId)
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

        public IEnumerable<Transaction> GetTransactionsByType(TransactionType transactionType)
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
    }
}
