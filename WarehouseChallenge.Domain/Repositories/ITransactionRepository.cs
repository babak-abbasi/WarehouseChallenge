using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Enum;

namespace WarehouseChallenge.Domain.Repositories
{
    public interface ITransactionRepository
    {
        public string AddNewTransaction(Transaction transaction);
        public int GetProductStockInWarehouse(int productId, int warehouseId);
        public IEnumerable<Transaction> GetTransactionsByType(TransactionType transactionType);
    }
}
