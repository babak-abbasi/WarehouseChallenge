CREATE PROCEDURE AddNewProduct
(
    @ProductId INT,
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10, 2),
    @StockQuantity INT
)
AS
BEGIN
    BEGIN TRANSACTION;
    
    INSERT INTO Warehouse..Products (ProductId, ProductName, Price, StockQuantity)
    VALUES (@ProductId, @ProductName, @Price, @StockQuantity);

    IF @@ROWCOUNT = 1
    BEGIN
        COMMIT TRANSACTION;
        
        SELECT @ProductId AS InsertedProductId;
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        
        SELECT 'The insert statement is not correct' AS ErrorMessage;
    END
END;
GO
