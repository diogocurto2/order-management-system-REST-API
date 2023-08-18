CREATE TABLE [dbo].[Stocks]
(
    ProductId INT PRIMARY KEY,
    Quantity INT NOT NULL,
    CONSTRAINT FK_Stock_Product FOREIGN KEY (ProductId) REFERENCES [dbo].[Products](Id)
);