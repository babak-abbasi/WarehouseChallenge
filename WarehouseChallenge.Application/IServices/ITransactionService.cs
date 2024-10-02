using WarehouseChallenge.Application.Dto;
using WarehouseChallenge.Domain.Enum;

namespace WarehouseChallenge.Application.IServices
{
    public interface ITransactionService
    {
        public string AddNewTransactionByProcedure(NewTransactionDto newTransactionDto);
        public int GetProductStockInWarehouseByProcedure(GetProductStockInWarehouseDto dto);
        public IEnumerable<GetTransactionsByTypeDto> GetTransactionsByTypeByProcedure(TransactionType transactionType);

        public string AddNewTransaction(NewTransactionDto newTransactionDto);
        public int GetProductStockInWarehouse(GetProductStockInWarehouseDto dto);
        public IEnumerable<GetTransactionsByTypeDto> GetTransactionsByType(TransactionType transactionType);
    }
}
