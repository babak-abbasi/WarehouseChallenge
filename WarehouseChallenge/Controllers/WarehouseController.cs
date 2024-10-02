using Microsoft.AspNetCore.Mvc;
using WarehouseChallenge.Application.IServices;
using WarehouseChallenge.Domain.Enum;
using WarehouseChallenge.WebAPI.RequestModels;

namespace WarehouseChallenge.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;

        public WarehouseController(ILogger<WarehouseController> logger,
            IProductService productService,
            ITransactionService transactionService)
        {
            _logger = logger;
            _productService = productService;
            _transactionService = transactionService;
        }

        [HttpPost(Name = "AddNewProductByProcedure")]
        public IActionResult AddNewProductByProcedure([FromBody] NewProductModel request)
            => Ok(_productService.AddNewProductByProcedure(new()
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Price = request.Price
            }));

        [HttpPost(Name = "AddNewTransactionByProcedure")]
        public IActionResult AddNewTransactionByProcedure([FromBody] NewTransactionModel request)
            => Ok(_transactionService.AddNewTransactionByProcedure(new()
            {
                TransactionId = request.TransactionId,
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                Quantity = request.Quantity,
                TransactionDate = request.TransactionDate,
                TransactionType = request.TransactionType
            }));

        [HttpGet(Name = "ProductStockInWarehouseByProcedure")]
        public IActionResult ProductStockInWarehouseByProcedure([FromQuery] GetProductStockInWarehouseModel request)
            => Ok(_transactionService.GetProductStockInWarehouseByProcedure(new()
            {
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId
            }));

        [HttpGet(Name = "TransactionsByTypeByProcedure")]
        public IActionResult TransactionsByTypeByProcedure([FromQuery] TransactionType request)
            => Ok(_transactionService.GetTransactionsByTypeByProcedure(request));

        [HttpPost(Name = "AddNewProduct")]
        public IActionResult AddNewProduct([FromBody] NewProductModel request)
            => Ok(_productService.AddNewProduct(new()
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Price = request.Price
            }));

        [HttpPost(Name = "AddNewTransaction")]
        public IActionResult AddNewTransaction([FromBody] NewTransactionModel request)
            => Ok(_transactionService.AddNewTransaction(new()
            {
                TransactionId = request.TransactionId,
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                Quantity = request.Quantity,
                TransactionDate = request.TransactionDate,
                TransactionType = request.TransactionType
            }));

        [HttpGet(Name = "ProductStockInWarehouse")]
        public IActionResult ProductStockInWarehouse([FromQuery] GetProductStockInWarehouseModel request)
            => Ok(_transactionService.GetProductStockInWarehouse(new()
            {
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId
            }));

        [HttpGet(Name = "TransactionsByType")]
        public IActionResult TransactionsByType([FromQuery] TransactionType request)
            => Ok(_transactionService.GetTransactionsByType(request));
    }
}
