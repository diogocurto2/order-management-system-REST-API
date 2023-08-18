CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100),
    [Price] DECIMAL(10, 2),
    [Description] NVARCHAR(500)
)
