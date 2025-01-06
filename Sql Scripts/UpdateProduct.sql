USE Inventory; 
GO 
CREATE PROCEDURE UpdateProduct 
@ProductID INT, 
@ProductName NVARCHAR(500),
@ProductDescription NVARCHAR(500),
@Quantity INT, 
@Price INT,
@ProductType NVARCHAR(100), 
@ShipmentStatus NVARCHAR(100)
AS 
BEGIN 
UPDATE Product_Inventory 
SET [Product Name] = @ProductName, 
ProductDescription= @ProductDescription,
Quantity = @Quantity, 
Price = @Price ,
ProductType = @ProductType ,
ShipmentStatus= @ShipmentStatus
WHERE ProductID = @ProductID; 
END; 
GO