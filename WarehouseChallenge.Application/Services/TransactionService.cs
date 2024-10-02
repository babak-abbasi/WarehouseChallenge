using WarehouseChallenge.Application.Dto;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.Domain.Enum;
using WarehouseChallenge.Domain.Repositories;

namespace WarehouseChallenge.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public TransactionService(ITransactionRepository transactionRepository,
            IProductRepository productRepository,
            IWarehouseRepository warehouseRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
        }

        public string AddNewTransactionByProcedure(NewTransactionDto newTransactionDto)
            => _transactionRepository.AddNewTransactionByProcedure(new()
            {
                TransactionId = newTransactionDto.TransactionId,
                ProductId = newTransactionDto.ProductId,
                WarehouseId = newTransactionDto.WarehouseId,
                Quantity = newTransactionDto.Quantity,
                TransactionDate = newTransactionDto.TransactionDate,
                TransactionType = newTransactionDto.TransactionType.ToString()
            });

        public int GetProductStockInWarehouseByProcedure(GetProductStockInWarehouseDto dto)
            => _transactionRepository.GetProductStockInWarehouseByProcedure(dto.ProductId, dto.WarehouseId);

        public IEnumerable<GetTransactionsByTypeDto> GetTransactionsByTypeByProcedure(TransactionType transactionType)
            => _transactionRepository
            .GetTransactionsByTypeByProcedure(transactionType)
            .Select(trans => new GetTransactionsByTypeDto()
            {
                TransactionId = trans.TransactionId,
                ProductId = trans.ProductId,
                WarehouseId = trans.WarehouseId,
                Quantity = trans.Quantity,
                TransactionType = trans.TransactionType,
                TransactionDate = trans.TransactionDate
            });

        public string AddNewTransaction(NewTransactionDto newTransactionDto)
        {
            if (newTransactionDto.TransactionId < 0)
                return "TransactionId is not valid";
            if(_warehouseRepository.DoesExist(newTransactionDto.TransactionId) is not null)
                return "A record with the same TransactionId exists";
            if (_productRepository.DoesExist(newTransactionDto.ProductId) is null)
                return "A record with this ProductId does not exists";
            if (_warehouseRepository.DoesExist(newTransactionDto.WarehouseId) is null)
                return "A record with this WarehouseId does not exists";
            if(newTransactionDto.Quantity < 0)
                return "Quantity can not be a negative value";
            var productStockInWarehouse = _transactionRepository.GetProductStockInWarehouse(newTransactionDto.ProductId, newTransactionDto.WarehouseId);
            if(newTransactionDto.TransactionType == TransactionType.Sale && productStockInWarehouse < newTransactionDto.Quantity)
                return "You can not sell this product from this warehouse cause the warehouse does not have this quantity available";

            _transactionRepository.AddNewTransaction(new() 
            {
                TransactionId = newTransactionDto.TransactionId,
                ProductId = newTransactionDto.ProductId,
                WarehouseId = newTransactionDto.WarehouseId,
                Quantity = newTransactionDto.Quantity,
                TransactionDate = newTransactionDto.TransactionDate,
                TransactionType = newTransactionDto.TransactionType.ToString()
            });

            return "Transaction added successfully";
        }

        public int GetProductStockInWarehouse(GetProductStockInWarehouseDto dto)
            => _transactionRepository.GetProductStockInWarehouse(dto.ProductId, dto.WarehouseId);

        public IEnumerable<GetTransactionsByTypeDto> GetTransactionsByType(TransactionType transactionType)
            => _transactionRepository
                .GetTransactionsByTypeByProcedure(transactionType)
                .Select(trans => new GetTransactionsByTypeDto()
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
