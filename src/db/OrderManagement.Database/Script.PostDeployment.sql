/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Insert initial data into the Customers table
INSERT INTO [Customers] (FirstName, LastName, Email)
VALUES
    ('John', 'Doe', 'john@example.com'),
    ('Jane', 'Smith', 'jane@example.com');


-- Insert initial data into the Products table
INSERT INTO [Products](Name, Price, Description)
VALUES
    ('Product A', 19.99, 'Description for Product A'),
    ('Product B', 29.99, 'Description for Product B');


-- Insert initial data into the Orders table
INSERT INTO [Orders] (CustomerID, OrderDate, TotalCost)
VALUES
    (1, '2023-08-10', 49.98),
    (2, '2023-08-11', 59.98);

-- Insert initial data into the OrderItems table
INSERT INTO [OrderItems] (OrderID, ProductID, Quantity, ItemCost)
VALUES
    (1, 1, 2, 39.98),
    (1, 2, 1, 29.99),
    (2, 2, 2, 59.98);

-- Insert initial data into the Stocks table
INSERT INTO [dbo].[Stocks] (ProductId, Quantity)
VALUES
    (1, 100), 
    (2, 150),
