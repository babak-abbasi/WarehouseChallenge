using WarehouseChallenge.Application.Dto;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.Domain.Repositories;

namespace WarehouseChallenge.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddNewProduct(NewProductDto newProductDto)
        {
            if (newProductDto.ProductId < 1)
                throw new ArgumentException("ProductId is invalid");
            if (string.IsNullOrEmpty(newProductDto.ProductName))
                throw new ArgumentException("ProductName is invalid");
            if (newProductDto.Price < 1)
                throw new ArgumentException("Price is invalid");
            if (newProductDto.StockQuantity < 0)
                throw new ArgumentException("StockQuantity is invalid");

            _productRepository.AddNewProduct(new() 
            { 
                ProductId = newProductDto.ProductId,
                ProductName = newProductDto.ProductName,
                Price = newProductDto.Price,
                StockQuantity = newProductDto.StockQuantity
            });
        }

        public void AddNewTransaction(NewTransactionDto newTransactionDto)
        {
            if (newTransactionDto.TransactionId < 1)
                throw new ArgumentException("TransactionId is invalid");
            if (newTransactionDto.ProductId < 1)
                throw new ArgumentException("ProductId is invalid");
            if (newTransactionDto.WarehouseId < 1)
                throw new ArgumentException("WarehouseId is invalid");
            if (newTransactionDto.Quantity < 1)
                throw new ArgumentException("Quantity is invalid");
            if (newTransactionDto.TransactionDate == default)
                throw new ArgumentException("TransactionDate is invalid");


            _productRepository.AddNewTransaction(new()
            {
                TransactionId = newTransactionDto.TransactionId,
                ProductId = newTransactionDto.ProductId,
                WarehouseId = newTransactionDto.WarehouseId,
                Quantity = newTransactionDto.Quantity,
                TransactionDate = newTransactionDto.TransactionDate,
                TransactionType = newTransactionDto.TransactionType
            });
        }
    }
}
