using WarehouseChallenge.Application.Dto;

namespace WarehouseChallenge.Application.IServices
{
    public interface IProductService
    {
        public void AddNewProduct(NewProductDto newProductModel);
        public void AddNewTransaction(NewTransactionDto newTransactionDto);
    }
}
