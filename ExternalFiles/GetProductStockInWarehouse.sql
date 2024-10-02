CREATE PROCEDURE GetProductStockInWarehouse
(
    @ProductId INT,
	@WarehouseId INT
)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Products WHERE ProductId = @ProductId)
    BEGIN
        Select -1
        RETURN;
    END

	IF NOT EXISTS (SELECT 1 FROM Warehouses WHERE WarehouseId = @WarehouseId)
    BEGIN
        Select -1
        RETURN;
    END

    Select (COALESCE((SELECT SUM(Quantity) FROM Warehouse..Transactions WHERE ProductID = @ProductId AND WarehouseID = @WarehouseId AND TransactionType = 'Purchase'), 0) 
	- COALESCE((SELECT SUM(Quantity) FROM Warehouse..Transactions WHERE ProductID = @ProductId AND WarehouseID = @WarehouseId AND TransactionType = 'Sale'), 0))
END;
GO
