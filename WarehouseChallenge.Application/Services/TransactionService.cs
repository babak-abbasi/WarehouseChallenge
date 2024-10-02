using WarehouseChallenge.Application.Dto;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Enum;
using WarehouseChallenge.Domain.Repositories;

namespace WarehouseChallenge.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public string AddNewTransaction(NewTransactionDto newTransactionDto)
            => _transactionRepository.AddNewTransaction(new()
            {
                TransactionId = newTransactionDto.TransactionId,
                ProductId = newTransactionDto.ProductId,
                WarehouseId = newTransactionDto.WarehouseId,
                Quantity = newTransactionDto.Quantity,
                TransactionDate = newTransactionDto.TransactionDate,
                TransactionType = newTransactionDto.TransactionType.ToString()
            });

        public int GetProductStockInWarehouse(GetProductStockInWarehouseDto dto) 
            => _transactionRepository.GetProductStockInWarehouse(dto.ProductId, dto.WarehouseId);

        public IEnumerable<GetTransactionsByTypeDto> GetTransactionsByType(TransactionType transactionType)
            => _transactionRepository.GetTransactionsByType(transactionType).Select(trans => new GetTransactionsByTypeDto() 
            { 
                TransactionId = trans.TransactionId,
                ProductId = trans.ProductId,
                WarehouseId = trans.WarehouseId,
                Quantity = trans.Quantity,
                TransactionType = trans.TransactionType,
                TransactionDate = trans.TransactionDate
            });
    }
}
