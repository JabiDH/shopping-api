-- ================================
-- Create User-defined Table Type
-- ================================
USE ShoppingCartDb

-- Drop all type references
DECLARE @ObjectName NVARCHAR(128)
DECLARE @DropStatement NVARCHAR(MAX)

DECLARE ref_objects_cursor CURSOR FOR
SELECT OBJECT_NAME(object_id) AS ReferenceObject
FROM sys.sql_modules
WHERE definition LIKE '%OrderItemsType%';

OPEN ref_objects_cursor;

FETCH NEXT FROM ref_objects_cursor INTO @ObjectName;

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @DropStatement = 'DROP PROCEDURE ' + @ObjectName;
	EXEC sp_executesql @DropStatement;
	FETCH NEXT FROM ref_objects_cursor INTO @ObjectName;
END;

CLOSE ref_objects_cursor;
DEALLOCATE ref_objects_cursor;

IF EXISTS (SELECT * FROM sys.types WHERE name = 'OrderItemsType' AND is_table_type = 1)
BEGIN
    DROP TYPE dbo.OrderItemsType;
END;

CREATE TYPE OrderItemsType AS TABLE 
(
	ItemId BIGINT,
	TaxRate DECIMAL(18, 2),
	Price DECIMAL(18, 2),
	Quantity INT
);


