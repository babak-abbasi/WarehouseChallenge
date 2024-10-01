using Warehouse.Application.Dto;
using Warehouse.Application.IServices;
using WarehouseChallenge.Domain.Repositories;

namespace Warehouse.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddNewProduct(NewProductDto newProductModel)
        {
            _productRepository.AddNewProductAsync(new() 
            { 
                ProductId = newProductModel.ProductId,
                ProductName = newProductModel.ProductName,
                Price = newProductModel.Price,
                StockQuantity = newProductModel.StockQuantity
            });
        }
    }
}
