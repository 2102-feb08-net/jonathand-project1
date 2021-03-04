CREATE SCHEMA PizzaApp;
GO
CREATE TABLE PizzaApp.Product
(
    ProductId INT IDENTITY NOT NULL,
    ProductName NVARCHAR(50) NOT NULL,
	ProductPrice NUMERIC(10,2) NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY CLUSTERED (ProductId)
);
GO
CREATE TABLE PizzaApp.Customer
(
    CustomerId INT IDENTITY NOT NULL,
    FirstName NVARCHAR(120),
	LastName NVARCHAR(120),
    CONSTRAINT PK_Customer PRIMARY KEY CLUSTERED (CustomerId)
);
GO
CREATE TABLE PizzaApp.OrderLine
(
    OrderLineID INT IDENTITY NOT NULL,
	OrderID INT NOT NULL,
	ProductID INT NOT NULL,
	Quantity INT NOT NULL,
    CONSTRAINT PK_OrderLine PRIMARY KEY CLUSTERED (OrderLineId)
);
GO
CREATE TABLE PizzaApp.[Order]
(
    OrderID INT IDENTITY NOT NULL,
	CustomerID INT NOT NULL,
	StoreID INT NOT NULL,
	OrderTotal NUMERIC(10,2),
	OrderDate DATETIMEOFFSET NOT NULL,
    CONSTRAINT PK_Order PRIMARY KEY CLUSTERED (OrderId)
);
GO
CREATE TABLE PizzaApp.Store
(
    StoreID INT IDENTITY NOT NULL,
    StoreName NVARCHAR(120),
    CONSTRAINT PK_Store PRIMARY KEY CLUSTERED (StoreId)
);
GO
CREATE TABLE PizzaApp.Inventory
(
    InventoryLineID INT IDENTITY NOT NULL,
	ProductID INT NOT NULL,
	Quantity INT NOT NULL,
	StoreID INT NOT NULL,
    CONSTRAINT PK_Inventory PRIMARY KEY CLUSTERED (InventoryLineID)
);
GO

ALTER TABLE PizzaApp.Orderline ADD
	CONSTRAINT FK_OrderLine_Order
		FOREIGN KEY (OrderID) REFERENCES PizzaApp.[Order](OrderID)
		ON DELETE CASCADE;
GO

ALTER TABLE PizzaApp.Orderline ADD
	CONSTRAINT FK_OrderLine_Product
		FOREIGN KEY (ProductID) REFERENCES PizzaApp.Product(ProductID)
		ON DELETE CASCADE;
GO

ALTER TABLE PizzaApp.[Order] ADD
	CONSTRAINT FK_Order_Customer
		FOREIGN KEY (CustomerID) REFERENCES PizzaApp.Customer(CustomerID)
		ON DELETE CASCADE;
GO

ALTER TABLE PizzaApp.[Order] ADD
	CONSTRAINT FK_Order_Store
		FOREIGN KEY (StoreID) REFERENCES PizzaApp.Store(StoreID)
		ON DELETE CASCADE;
GO

ALTER TABLE PizzaApp.Inventory ADD
	CONSTRAINT FK_Inventory_Store
		FOREIGN KEY (StoreID) REFERENCES PizzaApp.Store(StoreID)
		ON DELETE CASCADE;
GO

ALTER TABLE PizzaApp.Inventory ADD
	CONSTRAINT FK_Inventory_Product
		FOREIGN KEY (ProductID) REFERENCES PizzaApp.Product(ProductID)
		ON DELETE CASCADE;
GO

INSERT INTO PizzaApp.Store VALUES ('Store 1');
INSERT INTO PizzaApp.Store VALUES ('Store 2');
INSERT INTO PizzaApp.Store VALUES ('Store 3');
INSERT INTO PizzaApp.Store VALUES ('Store 4');
INSERT INTO PizzaApp.Store VALUES ('Store 5');

INSERT INTO PizzaApp.Product VALUES ('Pepperoni Pizza', 9.99);
INSERT INTO PizzaApp.Product VALUES ('Cheese Pizza', 9.99);
INSERT INTO PizzaApp.Product VALUES ('Ham Pizza',9.99);
INSERT INTO PizzaApp.Product VALUES ('Hawaiian Pizza',9.99);
INSERT INTO PizzaApp.Product VALUES ('BBQ Chicken Pizza',9.99);
INSERT INTO PizzaApp.Product VALUES ('Buffalo Chicken Pizza',9.99);
INSERT INTO PizzaApp.Product VALUES ('Sausage Pizza',9.99);
INSERT INTO PizzaApp.Product VALUES ('Meatastic Pizza',9.99);
INSERT INTO PizzaApp.Product VALUES ('Bread Sticks',4.99);
INSERT INTO PizzaApp.Product VALUES ('Cheese Sticks',4.99);
INSERT INTO PizzaApp.Product VALUES ('Buffalo Wings',6.99);
INSERT INTO PizzaApp.Product VALUES ('BBQ Wings',6.99);
INSERT INTO PizzaApp.Product VALUES ('Coke',2.99);
INSERT INTO PizzaApp.Product VALUES ('Sprite',2.99);
INSERT INTO PizzaApp.Product VALUES ('Diet Coke',2.99);
INSERT INTO PizzaApp.Product VALUES ('Water',2.99);
INSERT INTO PizzaApp.Product VALUES ('Gatorade',2.99);

INSERT INTO PizzaApp.Inventory VALUES (1,200,1);
INSERT INTO PizzaApp.Inventory VALUES (2,200,1);
INSERT INTO PizzaApp.Inventory VALUES (3,200,1);
INSERT INTO PizzaApp.Inventory VALUES (4,200,1);
INSERT INTO PizzaApp.Inventory VALUES (5,200,1);
INSERT INTO PizzaApp.Inventory VALUES (6,200,1);
INSERT INTO PizzaApp.Inventory VALUES (7,200,1);
INSERT INTO PizzaApp.Inventory VALUES (8,200,1);
INSERT INTO PizzaApp.Inventory VALUES (9,200,1);
INSERT INTO PizzaApp.Inventory VALUES (10,200,1);
INSERT INTO PizzaApp.Inventory VALUES (11,200,1);
INSERT INTO PizzaApp.Inventory VALUES (12,200,1);
INSERT INTO PizzaApp.Inventory VALUES (13,200,1);
INSERT INTO PizzaApp.Inventory VALUES (14,200,1);
INSERT INTO PizzaApp.Inventory VALUES (15,200,1);
INSERT INTO PizzaApp.Inventory VALUES (16,200,1);
INSERT INTO PizzaApp.Inventory VALUES (17,200,1);
INSERT INTO PizzaApp.Inventory VALUES (1,200,2);
INSERT INTO PizzaApp.Inventory VALUES (2,200,2);
INSERT INTO PizzaApp.Inventory VALUES (3,200,2);
INSERT INTO PizzaApp.Inventory VALUES (4,200,2);
INSERT INTO PizzaApp.Inventory VALUES (5,200,2);
INSERT INTO PizzaApp.Inventory VALUES (6,200,2);
INSERT INTO PizzaApp.Inventory VALUES (7,200,2);
INSERT INTO PizzaApp.Inventory VALUES (8,200,2);
INSERT INTO PizzaApp.Inventory VALUES (9,200,2);
INSERT INTO PizzaApp.Inventory VALUES (10,200,2);
INSERT INTO PizzaApp.Inventory VALUES (11,200,2);
INSERT INTO PizzaApp.Inventory VALUES (12,200,2);
INSERT INTO PizzaApp.Inventory VALUES (13,200,2);
INSERT INTO PizzaApp.Inventory VALUES (14,200,2);
INSERT INTO PizzaApp.Inventory VALUES (15,200,2);
INSERT INTO PizzaApp.Inventory VALUES (16,200,2);
INSERT INTO PizzaApp.Inventory VALUES (17,200,2);
INSERT INTO PizzaApp.Inventory VALUES (1,200,3);
INSERT INTO PizzaApp.Inventory VALUES (2,200,3);
INSERT INTO PizzaApp.Inventory VALUES (3,200,3);
INSERT INTO PizzaApp.Inventory VALUES (4,200,3);
INSERT INTO PizzaApp.Inventory VALUES (5,200,3);
INSERT INTO PizzaApp.Inventory VALUES (6,200,3);
INSERT INTO PizzaApp.Inventory VALUES (7,200,3);
INSERT INTO PizzaApp.Inventory VALUES (8,200,3);
INSERT INTO PizzaApp.Inventory VALUES (9,200,3);
INSERT INTO PizzaApp.Inventory VALUES (10,200,3);
INSERT INTO PizzaApp.Inventory VALUES (11,200,3);
INSERT INTO PizzaApp.Inventory VALUES (12,200,3);
INSERT INTO PizzaApp.Inventory VALUES (13,200,3);
INSERT INTO PizzaApp.Inventory VALUES (14,200,3);
INSERT INTO PizzaApp.Inventory VALUES (15,200,3);
INSERT INTO PizzaApp.Inventory VALUES (16,200,3);
INSERT INTO PizzaApp.Inventory VALUES (17,200,3);
INSERT INTO PizzaApp.Inventory VALUES (1,200,4);
INSERT INTO PizzaApp.Inventory VALUES (2,200,4);
INSERT INTO PizzaApp.Inventory VALUES (3,200,4);
INSERT INTO PizzaApp.Inventory VALUES (4,200,4);
INSERT INTO PizzaApp.Inventory VALUES (5,200,4);
INSERT INTO PizzaApp.Inventory VALUES (6,200,4);
INSERT INTO PizzaApp.Inventory VALUES (7,200,4);
INSERT INTO PizzaApp.Inventory VALUES (8,200,4);
INSERT INTO PizzaApp.Inventory VALUES (9,200,4);
INSERT INTO PizzaApp.Inventory VALUES (10,200,4);
INSERT INTO PizzaApp.Inventory VALUES (11,200,4);
INSERT INTO PizzaApp.Inventory VALUES (12,200,4);
INSERT INTO PizzaApp.Inventory VALUES (13,200,4);
INSERT INTO PizzaApp.Inventory VALUES (14,200,4);
INSERT INTO PizzaApp.Inventory VALUES (15,200,4);
INSERT INTO PizzaApp.Inventory VALUES (16,200,4);
INSERT INTO PizzaApp.Inventory VALUES (17,200,4);
INSERT INTO PizzaApp.Inventory VALUES (1,200,5);
INSERT INTO PizzaApp.Inventory VALUES (2,200,5);
INSERT INTO PizzaApp.Inventory VALUES (3,200,5);
INSERT INTO PizzaApp.Inventory VALUES (4,200,5);
INSERT INTO PizzaApp.Inventory VALUES (5,200,5);
INSERT INTO PizzaApp.Inventory VALUES (6,200,5);
INSERT INTO PizzaApp.Inventory VALUES (7,200,5);
INSERT INTO PizzaApp.Inventory VALUES (8,200,5);
INSERT INTO PizzaApp.Inventory VALUES (9,200,5);
INSERT INTO PizzaApp.Inventory VALUES (10,200,5);
INSERT INTO PizzaApp.Inventory VALUES (11,200,5);
INSERT INTO PizzaApp.Inventory VALUES (12,200,5);
INSERT INTO PizzaApp.Inventory VALUES (13,200,5);
INSERT INTO PizzaApp.Inventory VALUES (14,200,5);
INSERT INTO PizzaApp.Inventory VALUES (15,200,5);
INSERT INTO PizzaApp.Inventory VALUES (16,200,5);
INSERT INTO PizzaApp.Inventory VALUES (17,200,5);
