using WarehouseChallenge.Domain.Entities;

namespace WarehouseChallenge.Domain.Repositories
{
    public interface IProductRepository
    {
        public void AddNewProductAsync(Product product);
    }
}
