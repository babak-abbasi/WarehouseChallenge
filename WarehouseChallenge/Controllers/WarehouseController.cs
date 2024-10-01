using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.IServices;
using Warehouse.Application.Services;
using WarehouseChallenge.Domain.Entities;
using WarehouseChallenge.Domain.Repositories;
using WarehouseChallenge.Infrastructure.Data;
using WarehouseChallenge.WebAPI.RequestModels;

namespace WarehouseChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly IProductService _productService;
        //private readonly WarehouseDbContext _warehouseDbContext;

        public WarehouseController(ILogger<WarehouseController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost(Name = "AddNewProduct")]
        public IActionResult AddNewProduct([FromBody] NewProductModel request)
        {
            _productService.AddNewProduct(new()
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            });

            //_warehouseDbContext.Database.ExecuteSqlRaw(
            //            "EXEC AddNewProduct @ProductId, @ProductName, @Price, @StockQuantity",
            //            new SqlParameter("@ProductId", request.ProductId),
            //            new SqlParameter("@ProductName", request.ProductName),
            //            new SqlParameter("@Price", request.Price),
            //            new SqlParameter("@StockQuantity", request.StockQuantity)
            //        );

            return Ok();
        }
    }
}
