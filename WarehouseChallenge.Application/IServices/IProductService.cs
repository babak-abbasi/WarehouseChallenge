using WarehouseChallenge.Application.Dto;

namespace WarehouseChallenge.Application.IServices
{
    public interface IProductService
    {
        public string AddNewProduct(NewProductDto newProductModel);
    }
}
