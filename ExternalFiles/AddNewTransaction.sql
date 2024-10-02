CREATE PROCEDURE AddNewTransaction
(
    @TransactionId INT,
    @ProductId INT,
    @WarehouseId INT,
    @TransactionType INT,
	@Quantity INT,
	@TransactionDate DATETIME
)
AS
BEGIN
    BEGIN TRANSACTION;
    
    INSERT INTO Warehouse..TraTransactions(TransactionID, ProductID, WarehouseID, TransactionType, Quantity, TransactionDate)
    VALUES (@TransactionId, @ProductId, @WarehouseId, @TransactionType, @Quantity, @TransactionDate);

    IF @@ROWCOUNT = 1
    BEGIN
        COMMIT TRANSACTION;
        
        SELECT @TransactionId AS InsertedTransactionId;
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        
        SELECT 'The insert statement is not correct' AS ErrorMessage;
    END
END;
GO
