USE [ShoppingCartDb]
GO

DECLARE	@return_value int

DECLARE @orderItems AS dbo.OrderItemsType;
INSERT INTO @orderItems (ItemId, TaxRate, Price, Quantity)
SELECT ItemId, TaxRate, Price, Quantity From OrderItems WHERE OrderId = 10012;

--INSERT INTO @orderItems (ItemId, TaxRate, Price, Quantity)
--SELECT Id, 0.07, Price, 2 From Items WHERE Id = 2;

--INSERT INTO @orderItems (ItemId, TaxRate, Price, Quantity)
--SELECT Id, 0.07, Price, 1 From Items WHERE Id = 128;



EXEC	@return_value = [dbo].[update_order]
		@OrderId = 10012,
		@Status = N'Closed',
		@TaxRate = 0,
		@OrderItems = @orderItems

SELECT	'Return Value' = @return_value

GO

select * from orders where Id = 10012;

--SELECT * 
--FROM  Orders o, OrderItems oi
--WHERE o.Id = oi.OrderId AND oi.OrderId = 10012

--SELECT SUM(oi.Price * oi.Quantity) 
--FROM OrderItems oi
--WHERE oi.OrderId = 10012;

--select * from Items;