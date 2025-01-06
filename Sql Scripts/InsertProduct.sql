USE Inventory; 
GO
CREATE PROCEDURE InsertProduct 
@ProductName NVARCHAR(500),
@ProductDescription NVARCHAR(500),
@Quantity INT, 
@Price INT,
@ProductType NVARCHAR(100), 
@ShipmentStatus NVARCHAR(100)
AS 
BEGIN 
INSERT INTO Product_Inventory ([Product Name], ProductDescription, Quantity,Price, ProductType,ShipmentStatus) VALUES (@ProductName, @ProductDescription, @Quantity, @Price,@ProductType,@ShipmentStatus); 
END; 
GO