namespace WarehouseChallenge.Domain.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public string TransactionType { get; set; }

    public int Quantity { get; set; }

    public DateTime TransactionDate { get; set; }
}
