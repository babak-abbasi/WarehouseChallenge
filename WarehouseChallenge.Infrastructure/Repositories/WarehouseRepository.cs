using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Repositories;
using WarehouseChallenge.Infrastructure.Data;

namespace WarehouseChallenge.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public WarehouseRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public Warehouse DoesExist(int warehouseId)
        {
            try
            {
                return _warehouseDbContext.Warehouses.FirstOrDefault(f => f.WarehouseID == warehouseId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
