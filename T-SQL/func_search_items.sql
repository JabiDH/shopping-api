SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JabiH
-- Create date: 2/9/2024
-- Description:	Search items by name or description
-- =============================================
CREATE OR ALTER FUNCTION func_search_items
(		
	@search nvarchar(100)
)
RETURNS TABLE 
AS
    	
RETURN 
(
	SELECT * FROM Items
	WHERE Items.Name LIKE '%' + @search + '%' OR Items.Description LIKE '%' + @search + '%'
)
GO
