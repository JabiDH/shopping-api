CREATE OR ALTER PROCEDURE update_order
	@OrderId BIGINT,
	@Status NVARCHAR(255),
	@TaxRate DECIMAL(18, 2) NULL,
	@OrderItems AS dbo.OrderItemsType NULL READONLY 
AS
DECLARE
	@OrderExists INT,
	@HasItems INT,
	@SubTotal DECIMAL(18, 2),
	@SalesTax DECIMAL(18, 2),
	@Total DECIMAL(18, 2)
BEGIN
	SET NOCOUNT ON;

	SELECT @OrderExists = COUNT(*) FROM Orders WHERE Id = @OrderId;
	SELECT @HasItems = COUNT(*) FROM @OrderItems;

	IF @OrderExists = 1
	BEGIN
		
		-- Get tax rate
		IF @TaxRate IS NULL OR @TaxRate <= 0
		BEGIN
			SELECT @TaxRate = TaxRate FROM Orders WHERE Id = @OrderId;
		END

		-- Update order items
		IF @HasItems > 0
		BEGIN
			DELETE FROM OrderItems WHERE OrderId = @OrderId;

			INSERT INTO OrderItems(ItemId, OrderId, TaxRate, Price, SalesTax, Quantity)
			SELECT ItemId, @OrderId, TaxRate, Price, (Quantity * Price * TaxRate), Quantity
			FROM @OrderItems;
		END

		-- Set new total(s)
		SELECT @SubTotal = SUM(oi.Price * oi.Quantity) 
						   FROM OrderItems oi
     					   WHERE oi.OrderId = @OrderId;
		SET @SalesTax = @SubTotal * @TaxRate;
		SET @Total = @SubTotal + @SalesTax;

		-- Update order
		UPDATE o
		SET
			o.Status = @Status,
			o.SubTotal = @SubTotal,
			o.TaxRate = @TaxRate,
			o.Total = @Total,
			o.SalesTax = @SalesTax,
			o.ClosedOn = CASE WHEN LOWER(@Status) = 'closed' THEN GETDATE() ELSE NULL END
		FROM Orders o
		WHERE o.Id = @OrderId;

	END
END
GO
