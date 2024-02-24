USE [ShoppingCartDb]
GO

DECLARE @OrderId BIGINT
DECLARE @SaleTax DECIMAL(18, 2) 
DECLARE @Quantity INT

SET @SaleTax = 0.06
SET @Quantity = 2

DECLARE @OrderItems AS dbo.OrderItemsType;
INSERT INTO @OrderItems (ItemId, Price, SaleTax, Quantity)
SELECT TOP(3) Id, Price, @SaleTax AS 'SaleTax', @Quantity AS Quantity FROM Items


EXEC [dbo].[create_order]
	@OrderId = @OrderId OUTPUT,
	@Email = 'user@gmail.com',
	@Status = 'created',
	@SaleTax = @SaleTax,	
	@OrderItems = @OrderItems

SELECT	@OrderId as 'OrderId'

GO
