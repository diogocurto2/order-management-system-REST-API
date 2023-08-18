CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	CustomerID INT,
    OrderDate DATETIME,
    TotalCost DECIMAL(10, 2),
    CONSTRAINT FK_Customers FOREIGN KEY (CustomerID) REFERENCES [dbo].[Customers](Id)
)
