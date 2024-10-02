CREATE PROCEDURE AddNewProduct
(
    @ProductId INT,
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10, 2)
)
AS
BEGIN
	--It could be auto increment
	IF(@ProductId <= 0)
	BEGIN
		SELECT 'ProductId is not valid' AS ErrorMessage;
		RETURN
	END

	IF EXISTS (SELECT 1 FROM Products WHERE ProductID = @ProductId)
	BEGIN
		SELECT 'A record with the same ProductID exists';
		RETURN
	END

	IF(@ProductName = '')
	BEGIN
		SELECT 'ProductName is not valid' AS ErrorMessage;
		RETURN
	END

	IF EXISTS (SELECT 1 FROM Products WHERE ProductName = @ProductName) 
	BEGIN
		SELECT 'A record with the same ProductName exists';
		RETURN
	END

	IF(@Price < 0)
	BEGIN
		SELECT 'Price can not be a negative value' AS ErrorMessage;
		RETURN
	END

    BEGIN TRANSACTION;

    INSERT INTO Warehouse..Products (ProductId, ProductName, Price, StockQuantity)
    VALUES (@ProductId, @ProductName, @Price, 0);

    IF @@ROWCOUNT = 1
    BEGIN
        COMMIT TRANSACTION;
        
        SELECT 'Product added successfully' AS Message;
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        
        SELECT 'The insert statement is not correct' AS ErrorMessage;
    END
END
