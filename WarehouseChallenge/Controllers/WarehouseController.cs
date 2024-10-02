using Microsoft.AspNetCore.Mvc;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.WebAPI.RequestModels;

namespace WarehouseChallenge.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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

            return Ok();
        }

        [HttpPost(Name = "AddNewTransaction")]
        public IActionResult AddNewTransaction([FromBody] NewTransactionModel request)
        {
            _productService.AddNewTransaction(new()
            {
                TransactionId = request.TransactionId,
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                Quantity = request.Quantity,
                TransactionDate = request.TransactionDate,
                TransactionType = request.TransactionType
            });

            return Ok();
        }
    }
}
