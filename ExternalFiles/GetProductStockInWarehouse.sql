CREATE PROCEDURE GetProductStockInWarehouse
(
    @ProductId INT
)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Products WHERE ProductId = @ProductId)
    BEGIN
        RAISERROR('Product with ProductId %d does not exist', 16, 1, @ProductId);
        RETURN;
    END

    SELECT StockQuantity
    FROM Products
    WHERE ProductId = @ProductId;
END;
GO
