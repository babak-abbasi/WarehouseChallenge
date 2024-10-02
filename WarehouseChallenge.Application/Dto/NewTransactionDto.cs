using WarehouseChallenge.Domain;

namespace WarehouseChallenge.Application.Dto
{
    public class NewTransactionDto
    {
        public int TransactionId { get; set; }

        public int? ProductId { get; set; }

        public int? WarehouseId { get; set; }

        public TransactionType TransactionType { get; set; }

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
