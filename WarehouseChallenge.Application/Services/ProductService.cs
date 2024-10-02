using WarehouseChallenge.Application.Dto;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.Domain.Entities;
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

        public string AddNewProductByProcedure(NewProductDto newProductDto)
            => _productRepository.AddNewProductByProcedure(new() 
            { 
                ProductId = newProductDto.ProductId,
                ProductName = newProductDto.ProductName,
                Price = newProductDto.Price
            });

        public string AddNewProduct(NewProductDto newProductDto)
        {
            if (newProductDto.ProductId < 0)
                return "ProductId is not valid";
            if (_productRepository.DoesExist(newProductDto.ProductId) is not null)
                return "A record with the same ProductID exists";
            if(string.IsNullOrEmpty(newProductDto.ProductName))
                return "ProductName is not valid";
            if (_productRepository.DoesExist(newProductDto.ProductName) is not null)
                return "A record with the same ProductName exists";
            if (newProductDto.Price < 0)
                return "Price can not be a negative value";

            var result = _productRepository.AddNewProduct(new()
            {
                ProductId = newProductDto.ProductId,
                ProductName = newProductDto.ProductName,
                Price = newProductDto.Price
            });

            return result;
        }
    }
}
