using Microsoft.EntityFrameworkCore;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.Application.Services;
using WarehouseChallenge.Domain.Repositories;
using WarehouseChallenge.Infrastructure.Data;
using WarehouseChallenge.Infrastructure.Repositories;

namespace WarehouseChallenge.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static void ExtendedServices(this IServiceCollection services)
        {
            services.AddDbContext<WarehouseDbContext>(options =>
                options.UseSqlServer("Data Source=.;Initial Catalog=Warehouse;User ID=sa;Password=1qaz!QAZ;TrustServerCertificate=Yes;"));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
