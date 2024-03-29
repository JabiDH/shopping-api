USE [ShoppingCartDb]
GO
/****** Object:  UserDefinedFunction [dbo].[func_search_items]    Script Date: 2/13/2024 5:43:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JabiH
-- Create date: 2/9/2024
-- Description:	Search items by name or description
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[search_items]
(		
	@filterOn nvarchar(20), 
	@filterQuery nvarchar(100),
	@sortBy nvarchar(20),
	@isAscending bit,
	@pageNo int,
	@pageSize int
)
RETURNS TABLE 
AS
    	
RETURN 
(	
	SELECT i.*, cats.Name 'CategoryName' FROM Items i, Categories cats
	WHERE
		i.CategoryId = cats.Id
	AND
		(UPPER(@filterOn) = 'NAME' AND i.Name LIKE '%' + @filterQuery + '%')
	OR 
		(UPPER(@filterOn) = 'DESCRIPTION' AND i.Description LIKE '%' + @filterQuery + '%')

	ORDER BY 
		CASE WHEN UPPER(@sortBy) = 'NAME' THEN i.Name
		     WHEN UPPER(@sortBy) = 'CATEGORY' THEN cats.Name END 
		+
		CASE WHEN @isAscending = 1 THEN ' ASC' ELSE ' DESC' END

	OFFSET (@pageNo - 1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY
)
