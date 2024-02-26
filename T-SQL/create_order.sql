-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JabiH
-- Create date: 2/22/2024
-- Description:	Create an order and associated order items
-- =============================================
CREATE OR ALTER PROCEDURE create_order
	@OrderId BIGINT OUTPUT,
	@Email NVARCHAR(255),	
	@Status NVARCHAR(255),
	@TaxRate DECIMAL(18, 2),
	@OrderItems AS dbo.OrderItemsType READONLY
AS
DECLARE
	@SubTotal DECIMAL(18, 2),
	@SalesTax DECIMAL(18, 2),
	@Total DECIMAL(18, 2),
	@CreatedOn Datetime2(7)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT @SubTotal = SUM(Price * Quantity) FROM @OrderItems;

	SET @SalesTax = @SubTotal * @TaxRate;
	SET @Total = @SubTotal + @SalesTax;

	SET @CreatedOn = GETDATE();

	INSERT INTO Orders (Email, CreatedOn, Status, TaxRate, SubTotal, SalesTax, Total)
    VALUES (@Email, @CreatedOn, @Status, @TaxRate, @SubTotal, @SalesTax, @Total)
  
	SET @OrderId = SCOPE_IDENTITY();

	INSERT INTO OrderItems(ItemId, OrderId, TaxRate, Price, SalesTax, Quantity)
	SELECT ItemId, @OrderId, TaxRate, Price, (Quantity * Price * TaxRate), Quantity
	FROM @OrderItems;

END
GO
