using WarehouseChallenge.Domain.Entities;

namespace WarehouseChallenge.Domain.Repositories
{
    public interface IWarehouseRepository
    {
        public Warehouse DoesExist(int warehouseId);
    }
}
