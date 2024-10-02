using WarehouseChallenge.Application.Dto;
using WarehouseChallenge.Domain.Enum;

namespace WarehouseChallenge.Application.IServices
{
    public interface ITransactionService
    {
        public string AddNewTransaction(NewTransactionDto newTransactionDto);
        public int GetProductStockInWarehouse(GetProductStockInWarehouseDto dto);
        public IEnumerable<GetTransactionsByTypeDto> GetTransactionsByType(TransactionType transactionType);
    }
}
