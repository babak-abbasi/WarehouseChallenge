using WarehouseChallenge.Domain.Entities;


namespace WarehouseChallenge.Domain.Repositories
{
    public interface IProductRepository
    {
        public void AddNewProduct(Product product);
        public void AddNewTransaction(Transaction transaction);
    }
}
