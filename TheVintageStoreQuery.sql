-- CREATE DATABASE TheVintageStore
use TheVintageStore;

-- AUTHOR: SHARJEEL SOHAIL
-- DATE: 04/06/2021
-- PROJECT: INFT3050 ASSIGNMENT PART 2

-- DROP TABLES 

--DROP TABLE tblOrderItem;
--DROP TABLE tblOrders;
--DROP TABLE tblShipping;
--DROP TABLE tblPaymentDetails;
--DROP TABLE tblProduct;
--DROP TABLE tblCategory;
--DROP TABLE tblAdminStaff;
--DROP TABLE tblAddress;
--DROP TABLE tblCustomer;
--DROP TABLE tblSettings;

-- CREATE TABLES 


CREATE TABLE [tblCustomer] (
  [CustomerID] int IDENTITY(566000, 1) PRIMARY KEY,
  [Email] varchar(100) NOT NULL UNIQUE, 
  [Password] varchar(100) NOT NULL,
  [FirstName] varchar(100) NOT NULL,
  [LastName] varchar(100) NOT NULL,
  [PhoneNumber] varchar(20) NOT NULL,
  [Status] bit DEFAULT(1),
);

CREATE TABLE [tblAddress] (
  [AddressID] int IDENTITY(1, 1) PRIMARY KEY,
  [CustomerID] int REFERENCES tblCustomer(CustomerID) ON UPDATE CASCADE ON DELETE CASCADE,
  [Address1] varchar(200) NOT NULL,
  [Address2] varchar(200),
  [Suburb] varchar(50) NOT NULL,
  [State] varchar(50) NOT NULL,
  [PostCode] int NOT NULL
);

CREATE TABLE [tblAdminStaff] (
  [AdminID] int PRIMARY KEY,
  [Email] varchar(100) NOT NULL,
  [Password] varchar(100) NOT NULL,
  [FirstName] varchar(100) NOT NULL,
  [LastName] varchar(100) NOT NULL
);

CREATE TABLE [tblCategory] (
  [CategoryID] int IDENTITY(1, 1) PRIMARY KEY,
  [Title] varchar(100) NOT NULL,
  [ImageURL] varchar(200) NOT NULL
);

CREATE TABLE [tblProduct] (
  [ProductCode] int IDENTITY(5000, 1) PRIMARY KEY,
  [CategoryID] int REFERENCES tblCategory(CategoryID) ON UPDATE CASCADE ON DELETE CASCADE,
  [Title] varchar(150) NOT NULL,
  [Description] varchar(300) NOT NULL,
  [Color] varchar(50) NOT NULL,
  [Size] varchar(50) NOT NULL,
  [TotalQuantity] int NOT NULL,
  [Price] float NOT NULL,
  [Status] BIT DEFAULT(1),
  [ImageURL] varchar(200) NOT NULL
);

CREATE TABLE [tblPaymentDetails] (
  [PayID] int IDENTITY(1, 1) PRIMARY KEY,
  [CustomerID] int REFERENCES tblCustomer(CustomerID) ON UPDATE CASCADE ON DELETE CASCADE,
  [CardNumber] bigint NOT NULL,
  [CardholderName] varchar(100) NOT NULL,
  [ExpiryDate] dateTime2 NOT NULL,
  [SecurityCode] int NOT NULL
);

CREATE TABLE [tblShipping] (
  [ShippingID] int IDENTITY(1, 1) PRIMARY KEY,
  [CustomerID] int REFERENCES tblCustomer(CustomerID) ON UPDATE CASCADE ON DELETE NO ACTION,
  [ShippingType] varchar(50) NOT NULL, 
  [Fee] float,
  [ExpectedDeliveryDate] dateTime2
);

CREATE TABLE [tblOrders] (
  [OrderNo] int IDENTITY(1000, 1) PRIMARY KEY,
  [CustomerID] int REFERENCES tblCustomer(CustomerID) ON UPDATE NO ACTION ON DELETE NO ACTION,
  [ShippingID] int REFERENCES tblShipping(ShippingID) ON UPDATE NO ACTION ON DELETE NO ACTION,
  [TotalPrice] float NOT NULL,
  [OrderDate] dateTime2 NOT NULL
);

CREATE TABLE [tblOrderItem] (
  [OrderItemID] int IDENTITY(1000, 1) PRIMARY KEY,
  [ProductCode] int REFERENCES tblProduct(ProductCode) ON UPDATE CASCADE ON DELETE CASCADE,
  [OrderNo] int REFERENCES tblOrders(OrderNo) ON UPDATE CASCADE ON DELETE CASCADE,
  [Quantity] int NOT NULL
);

CREATE TABLE [tblSettings] (
  [ExchangeSettings] varchar(1000),
  [ReturnSettings] varchar(1000),
  [PaymentSettings] varchar(1000),
  [ShippingSettings] varchar(1000)
);

-- SAMPLE DATA FOR TESTING 

INSERT INTO tblSettings VALUES
('You have 30 days from the shipping date to exchange your purchase from The Vintage Store free of charge.' + CHAR(13) +
'You can change the size or colour of your items.' + CHAR(13) + 
'If you prefer to exchange it for another item, you must ask for a return and make a new purchase', -- Exchange

'You have 30 days from the shipping date of your order to return your purchase from The Vintage Store free of charge' + CHAR(13) +  
'The items must have all their labels and be in perfect condition.', -- Return

'We offer the following payment methods: ' + CHAR(13) + 
'Visa ' + CHAR(13) +  
'Master Card' + CHAR(13) + 
'Paypal', -- Payment 

'The shipping options may vary depending on the delivery address, what time you make your purchase and item availability. ' + CHAR(13) +
'At the time of processing your purchase, we will show you the available shipping methods, the cost and the delivery date of your order.' + CHAR(13) +
'Bear in mind that deliveries are only made on working days.' -- Shipping
)

INSERT INTO tblCategory VALUES 
('Shirts', '../Img/Shirt.png'),
('T-Shirts', '../Img/TShirt.png'),
('Jeans', '../Img/Jeans.png'),
('Pants', '../Img/Pants.png'),
('Outerwear', '../Img/Outerwear.png'),
('Blazer', '../Img/Blazer.png'),
('Suits', '../Img/Suit.png'),
('Knitwear', '../Img/Knitwear.png')

INSERT INTO tblProduct VALUES 
(1, 'Striped Shirt', 'Blue Colored Striped Shirt with Patchwork', 'Blue', 'Medium', 9, 29.95, 1, '../Img/Shirt.png'),
(1, 'Checkered Shirt', 'Grey Striped Shirt with mix threads', 'Grey', 'Large', 11, 35.95, 1, '../Img/Shirt2.png'),
(1, 'Summer overshirt', 'Lemon Colored Casual Striped Shirt', 'Lemon', 'Small', 6, 25.95, 1, '../Img/Shirt3.png'),
(2, 'Grey T-Shirt', 'Black Colored Checkered Shirt Viscose Material', 'Black', 'Large', 5, 19.95, 1, '../Img/Tshirt.png'),
(2, 'Black band T-Shirt', 'Blue Colored Striped Shirt with Patchwork', 'Blue', 'Medium', 9, 22.95, 1, '../Img/Tshirt2.png'),
(2, 'Casual White T-Shirt', 'Blue Colored Striped Shirt with Patchwork', 'Blue', 'Medium', 8, 20.95, 1, '../Img/Tshirt3.png'),
(3, 'Wide leg Jeans', 'Wide legged blue Jeans Vintage Style', 'Blue', 'Medium', 10, 49.95, 1, '../Img/Jeans.png'),
(3, 'Fit Black Jeans', 'Black slim-fit jeans with Cuffs', 'Black', 'Large', 11, 45.95, 1, '../Img/Jeans2.png'),
(3, 'White Beach Jeans', 'White Beach type jeans Casual wear', 'White', 'Small', 5, 39.95, 1, '../Img/Jeans3.png'),
(4, 'Wide blue pants', 'Blue Wide pants for a perfect netflix day', 'Blue', 'Medium', 15, 29.95, 1, '../Img/Pants.png'),
(4, 'Checkered pants', 'Checkered mix pants made with pure cotton and silk', 'Grey', 'Large', 12, 25.95, 1, '../Img/Pants2.png'),
(4, 'Funky light pants', 'Funky white pants tye-dye perfect for summers', 'White', 'Large', 7, 22.95, 1, '../Img/Pants3.png'),
(5, 'Black Leather Jacket', 'Heavy leather Black Jacket made for snow', 'Black', 'Large', 9, 69.95, 1, '../Img/Outerwear.png'),
(5, 'Blue Puffer Jacket', 'Blue light-weight Puffer Jacket with Pockets and throw', 'Blue', 'Medium', 9, 79.95, 1, '../Img/Outerwear2.png'),
(5, 'Vintage Sleeveless Upper', 'Handmade Knit Upper Varsity style', 'White', 'Medium', 8, 49.95, 1, '../Img/Outerwear3.png'),
(6, 'Black Wide Blazer', 'Black oversized type Blazer for casual or weddings', 'Black', 'Small', 3, 49.95, 1, '../Img/Blazer.png'),
(6, 'Grey Blazer', 'Grey blazer made with Pashmina and Cotton', 'Grey', 'Small', 3, 49.95, 1, '../Img/Blazer2.png'),
(6, 'Oversized Blazer', 'Oversized Black blazer perfect for University or meetings', 'Black', 'Large', 6, 45.95, 1, '../Img/Blazer3.png'),
(7, 'Black Suit', 'Black suit with pockets and tousers made in Italy', 'Black', 'Medium', 8, 109.95, 1, '../Img/Suit.png'),
(7, 'Blue Suit', 'Blue suit in details made with love in Pakistan', 'Blue', 'Medium', 8, 115.95, 1, '../Img/Suit2.png'),
(7, 'James bond suit', 'Oversized yet fitted James bond Suit for action', 'Black', 'Large', 4, 149.95, 1, '../Img/Suit3.png'),
(8, 'Light Green Knitwear', 'Handmade Knitwear with printed style dots', 'Green', 'Medium', 8, 39.95, 1, '../Img/Knitwear.png'),
(8, 'Grey thick Upper', 'High-next upper made with Knit and cotton', 'Grey', 'Large', 8, 35.95, 1, '../Img/Knitwear2.png'),
(8, 'Cashmore cardigan', 'Light Cardigan for chilled winter days', 'Black', 'X-Large', 8, 45.95, 1, '../Img/Knitwear3.png')

INSERT INTO tblCustomer VALUES 
('customer@login.com', 'password', 'Sharjeel', 'Sohail', '0451645687', 1)

INSERT INTO tblAddress VALUES 
(566000, 'Unit 5 49 Mawson Street', 'Basement', 'Shortland', 'NSW', 2307)

INSERT INTO tblAdminStaff VALUES 
(01, 'admin@login.com', 'password', 'Josh', 'Matt')

INSERT INTO tblPaymentDetails VALUES 
(566000, '5217225624248787', 'Mr Sharjeel Sohail', SYSDATETIME(), 388)

INSERT INTO tblShipping VALUES 
(566000, 'Express', 14.95, SYSDATETIME())

INSERT INTO tblOrders VALUES 
(566000, 1, 81.99, SYSDATETIME())

INSERT INTO tblOrderItem VALUES 
(5000, 1000, 1)