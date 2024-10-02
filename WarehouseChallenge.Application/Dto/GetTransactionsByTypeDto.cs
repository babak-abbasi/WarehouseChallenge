using WarehouseChallenge.Domain.Enum;

namespace WarehouseChallenge.Application.Dto
{
    public class GetTransactionsByTypeDto
    {
        public int TransactionId { get; set; }

        public int? ProductId { get; set; }

        public int? WarehouseId { get; set; }

        public string TransactionType { get; set; }

        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
