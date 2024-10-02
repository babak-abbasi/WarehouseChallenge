CREATE PROCEDURE GetTransactionsByType
(
    @TransactionType nvarchar(50)
)
AS
BEGIN

	IF(@TransactionType = 'Purchase' OR @TransactionType = 'Sale')
		Select trans.TransactionID TransactionId, trans.ProductID ProductId, trans.WarehouseID WarehouseId, trans.TransactionType, trans.Quantity, trans.TransactionDate 
		FROM Warehouse..Transactions trans 
		WHERE TransactionType = @TransactionType
	ELSE IF(@TransactionType is null)
		Select trans.TransactionID TransactionId, trans.ProductID ProductId, trans.WarehouseID WarehouseId, trans.TransactionType, trans.Quantity, trans.TransactionDate 
		FROM Warehouse..Transactions trans 
END;
GO
