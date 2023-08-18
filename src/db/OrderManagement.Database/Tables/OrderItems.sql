CREATE TABLE [dbo].[OrderItems]
(
	OrderID INT,
    OrderItemID INT IDENTITY,
    ProductID INT,
    Quantity INT,
    ItemCost DECIMAL(10, 2),
    PRIMARY KEY (OrderID, OrderItemID),
    CONSTRAINT FK_Orders FOREIGN KEY (OrderID) REFERENCES [dbo].[Orders](Id),
    CONSTRAINT FK_Products FOREIGN KEY (ProductID) REFERENCES [dbo].[Products](Id)
);
