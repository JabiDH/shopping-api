SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JabiH
-- Create date: 2/25/2024
-- Description:	Get Orders and its associated items
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[get_orders]
(	
	@OrderId int = null
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT
		o.Id,
		o.Email,
		o.CreatedOn,
		o.ClosedOn,
		o.Status,
		o.SubTotal,
		o.SalesTax,
		o.TaxRate,
		o.Total,
		JSON_QUERY('[' + ISNULL(STUFF((
					SELECT
						CONCAT(', { "Id": ', CAST(oi.Id AS VARCHAR),
							   ', "ItemId": ', CAST(oi.ItemId AS VARCHAR),
							   ', "Quantity": ', CAST(oi.Quantity AS VARCHAR),
							   ', "Price": ', CAST(oi.Price AS VARCHAR),
							   ', "SalesTax": ', CAST(oi.SalesTax AS VARCHAR),
							   ', "TaxRate": ', CAST(oi.TaxRate AS VARCHAR), ' }')
					FROM
						OrderItems oi
					WHERE
						oi.OrderId = o.Id
					FOR XML PATH('')), 1, 1, ''), '') + ']') AS OrderItems
	FROM
		Orders o
	WHERE 
		(@OrderId IS NULL OR @OrderId = 0 OR o.Id = @OrderId)
)
GO
