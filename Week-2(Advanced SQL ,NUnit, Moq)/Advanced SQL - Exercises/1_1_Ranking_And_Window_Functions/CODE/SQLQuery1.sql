USE RetailStoreDB;
GO

-- DROP IF EXISTS (OPTIONAL)
IF OBJECT_ID('Products', 'U') IS NOT NULL
    DROP TABLE Products;
GO

-- CREATE TABLE
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Category NVARCHAR(50),
    Price DECIMAL(10,2)
);

-- INSERT DATA
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200),
(2, 'Smartphone', 'Electronics', 800),
(3, 'Headphones', 'Electronics', 200),
(4, 'Camera', 'Electronics', 800),
(5, 'T-shirt', 'Apparel', 25),
(6, 'Jeans', 'Apparel', 50),
(7, 'Jacket', 'Apparel', 100),
(8, 'Dress', 'Apparel', 75),
(9, 'Coffee Table', 'Furniture', 150),
(10, 'Sofa', 'Furniture', 600),
(11, 'Dining Table', 'Furniture', 600),
(12, 'Bookshelf', 'Furniture', 300);
