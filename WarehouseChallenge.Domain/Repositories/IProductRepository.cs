using WarehouseChallenge.Domain.Entities;


namespace WarehouseChallenge.Domain.Repositories
{
    public interface IProductRepository
    {
        public Product DoesExist(int productId);
        public Product DoesExist(string productName);
        public string AddNewProductByProcedure(Product product);
        public string AddNewProduct(Product product);
    }
}
