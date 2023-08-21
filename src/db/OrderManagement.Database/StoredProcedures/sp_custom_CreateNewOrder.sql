
CREATE PROCEDURE [dbo].[sp_custom_CreateNewOrder]
    @CustomerID INT,
    @OrderItems ProductOrderItem READONLY,
    @OrderID INT OUTPUT
AS
	    -- Declare variables
    DECLARE @OrderDate DATETIME, @TotalCost DECIMAL(10, 2);

        -- Validate CustomerID
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Customers] WHERE @CustomerID = @CustomerID)
    BEGIN
        RAISERROR ('Invalid CustomerID.', 18, 0);
        RETURN;
    END;

    -- Validate ProductOrders
    IF (SELECT COUNT(*) FROM @OrderItems) = 0
    BEGIN
        RAISERROR('No product orders provided.', 18, 0);
        RETURN;
    END;

    -- Validate ProductIDs in ProductOrders
    IF EXISTS (
        SELECT oi.ProductID
	        FROM @OrderItems oi
		        LEFT OUTER JOIN Products p ON oi.ProductID = p.Id
	        WHERE p.Id IS NULL
    )
    BEGIN
        RAISERROR('Invalid ProductID in ProductOrders.', 18, 0);
        RETURN;
    END;

    -- Check if there's enough stock for each ordered product
    IF EXISTS (
        SELECT 1
        FROM @OrderItems oi
        WHERE NOT EXISTS (
            SELECT 1
            FROM [dbo].[Stocks] s
            WHERE s.ProductId = oi.ProductID
            AND s.Quantity >= oi.Quantity
        )
    )
    BEGIN
        RAISERROR ('Insufficient stock for some products.', 18, 0);
        RETURN;
    END;

    -- Calculate total cost
    SELECT @TotalCost = SUM(p.Price * oi.Quantity)
        FROM @OrderItems oi
        INNER JOIN [dbo].[Products] p ON oi.ProductID = p.Id;

    -- Get current date and time
    SET @OrderDate = GETDATE();

    -- Insert new order into Order table
    INSERT INTO [dbo].[Orders] (CustomerID, OrderDate, TotalCost)
        VALUES (@CustomerID, @OrderDate, @TotalCost);

    -- Get the newly inserted OrderID
    SET @OrderID = SCOPE_IDENTITY();

    -- Insert order items into OrderItem table
    INSERT INTO [dbo].[OrderItems] (OrderID, ProductID, Quantity, ItemCost)
        SELECT @OrderID, oi.ProductID, oi.Quantity, p.Price * oi.Quantity
            FROM @OrderItems oi
            INNER JOIN [dbo].[Products] p ON oi.ProductID = p.Id;

    -- Update stock quantities
    UPDATE s
        SET s.Quantity = s.Quantity - oi.Quantity
        FROM [dbo].[Stocks] s
            JOIN @OrderItems oi ON s.ProductId = oi.ProductID;

RETURN 0
