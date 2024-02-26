USE [ShoppingCartDb]
GO

DECLARE @OrderId BIGINT
DECLARE @TaxRate DECIMAL(18, 2) 
DECLARE @Quantity INT

SET @TaxRate = 0.06
SET @Quantity = 2

DECLARE @OrderItems AS dbo.OrderItemsType;
INSERT INTO @OrderItems (ItemId, TaxRate, Price, Quantity)
SELECT TOP(3) Id, @TaxRate AS 'TaxRate', Price, @Quantity AS Quantity FROM Items


EXEC [dbo].[create_order]
	@OrderId = @OrderId OUTPUT,
	@Email = 'user@gmail.com',
	@Status = 'created',
	@TaxRate = @TaxRate,	
	@OrderItems = @OrderItems

SELECT	@OrderId as 'OrderId'

GO
