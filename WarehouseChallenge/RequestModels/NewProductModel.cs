﻿namespace WarehouseChallenge.WebAPI.RequestModels
{
    public class NewProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
