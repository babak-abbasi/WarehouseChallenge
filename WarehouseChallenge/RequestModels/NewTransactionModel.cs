using WarehouseChallenge.Domain;

namespace WarehouseChallenge.WebAPI.RequestModels
{
    public class NewTransactionModel
    {
        public int TransactionId { get; set; }

        public int? ProductId { get; set; }

        public int? WarehouseId { get; set; }

        public TransactionType TransactionType { get; set; }

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
