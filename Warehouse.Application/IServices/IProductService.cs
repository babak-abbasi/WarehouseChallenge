using Warehouse.Application.Dto;

namespace Warehouse.Application.IServices
{
    public interface IProductService
    {
        public void AddNewProduct(NewProductDto newProductModel);
    }
}
