CREATE PROCEDURE AddNewTransaction
(
    @TransactionId INT,
    @ProductId INT,
    @WarehouseId INT,
    @TransactionType nvarchar(50),
	@Quantity INT,
	@TransactionDate DATETIME
)
AS
BEGIN
	--It could be auto increment
	IF(@TransactionId <= 0)
	BEGIN
		SELECT 'ProductId is not valid' AS ErrorMessage;
		RETURN
	END

	IF EXISTS (SELECT 1 FROM Transactions WHERE TransactionId = @TransactionId)
	BEGIN
		SELECT 'A record with the same TransactionId exists';
		RETURN
	END

	IF NOT EXISTS (SELECT 1 FROM Products WHERE ProductId = @ProductId)
	BEGIN
		SELECT 'A record with this ProductId does not exists';
		RETURN
	END

	IF NOT EXISTS (SELECT 1 FROM Warehouses WHERE WarehouseId = @WarehouseId)
	BEGIN
		SELECT 'A record with this WarehouseId does not exists';
		RETURN
	END

	IF(@Quantity < 0)
	BEGIN
		SELECT 'Quantity can not be a negative value' AS ErrorMessage;
		RETURN
	END

    BEGIN TRANSACTION;
    
    INSERT INTO Warehouse..Transactions(TransactionID, ProductID, WarehouseID, TransactionType, Quantity, TransactionDate)
    VALUES (@TransactionId, @ProductId, @WarehouseId, @TransactionType, @Quantity, @TransactionDate);

	IF(@TransactionType = 'Purchase')
		Update Warehouse..Products SET StockQuantity = StockQuantity + @Quantity WHERE ProductID = @ProductId
	ELSE IF(@TransactionType = 'Sale')
	BEGIN
		IF(COALESCE((SELECT SUM(Quantity) FROM Warehouse..Transactions WHERE ProductID = @ProductId AND WarehouseID = @WarehouseID AND TransactionType = 'Purchase'), 0) - COALESCE((SELECT SUM(Quantity) FROM Warehouse..Transactions WHERE ProductID = @ProductId AND WarehouseID = @WarehouseID AND TransactionType = 'Sale'), 0) >= 0)
			Update Warehouse..Products SET StockQuantity = StockQuantity - @Quantity WHERE ProductID = @ProductId
		ELSE 
			BEGIN
				ROLLBACK TRANSACTION;
				SELECT 'You can not this product from this warehouse cause the warehouse does not have this quantity available' AS Message;
				RETURN
			END
	END

    IF @@ROWCOUNT = 1
    BEGIN
        COMMIT TRANSACTION;
        
        SELECT 'Transaction added successfully' AS Message;
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        
        SELECT 'The insert statement is not correct' AS ErrorMessage;
    END
END;
GO
