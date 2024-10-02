using WarehouseChallenge.Domain.Entities;


namespace WarehouseChallenge.Domain.Repositories
{
    public interface IProductRepository
    {
        public string AddNewProduct(Product product);
    }
}
