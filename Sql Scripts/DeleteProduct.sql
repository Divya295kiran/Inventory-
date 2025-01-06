USE Inventory; 
GO 
CREATE PROCEDURE DeleteProduct
@ProductID INT 
AS 
BEGIN
DELETE FROM Product_Inventory WHERE ProductID = @ProductID;
END; 
GO