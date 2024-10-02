using WarehouseChallenge.Application.Dto;

namespace WarehouseChallenge.Application.IServices
{
    public interface IProductService
    {
        public string AddNewProductByProcedure(NewProductDto newProductDto);
        public string AddNewProduct(NewProductDto newProductModel);
    }
}
