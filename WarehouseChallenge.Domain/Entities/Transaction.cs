using WarehouseChallenge.Domain.Entities;

namespace WarehouseChallenge.Domain.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? ProductId { get; set; }

    public int? WarehouseId { get; set; }

    public TransactionType TransactionType { get; set; }

    public int Quantity { get; set; }

    public DateTime TransactionDate { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
