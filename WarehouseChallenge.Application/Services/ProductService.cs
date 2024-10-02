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

        public string AddNewProduct(NewProductDto newProductDto)
            => _productRepository.AddNewProduct(new() 
            { 
                ProductId = newProductDto.ProductId,
                ProductName = newProductDto.ProductName,
                Price = newProductDto.Price
            });
    }
}
