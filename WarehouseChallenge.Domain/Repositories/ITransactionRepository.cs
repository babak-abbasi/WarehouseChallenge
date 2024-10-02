using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Enum;

namespace WarehouseChallenge.Domain.Repositories
{
    public interface ITransactionRepository
    {
        public string AddNewTransactionByProcedure(Transaction transaction);
        public int GetProductStockInWarehouseByProcedure(int productId, int warehouseId);
        public IEnumerable<Transaction> GetTransactionsByTypeByProcedure(TransactionType transactionType);

        public Transaction DoesExist(int transactionId);
        public string AddNewTransaction(Transaction transaction);
        public int GetProductStockInWarehouse(int productId, int warehouseId);
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType transactionType);
    }
}
