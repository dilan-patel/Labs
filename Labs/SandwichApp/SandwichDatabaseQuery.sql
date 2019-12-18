
DROP DATABASE IF EXISTS Sandwich
GO

CREATE DATABASE Sandwich
GO

DROP TABLE IF EXISTS Bread
DROP TABLE IF EXISTS Cheese
DROP TABLE IF EXISTS Filling
DROP TABLE IF EXISTS Topping
DROP TABLE IF EXISTS Extras
DROP TABLE IF EXISTS Category
GO

--Stores categories for ingredient types
CREATE TABLE Category(
	CategoryID INT IDENTITY NOT NULL PRIMARY KEY,
	CategoryName VARCHAR(50) NULL
)

CREATE TABLE Bread(
	BreadID INT IDENTITY NOT NULL PRIMARY KEY,
	BreadName VARCHAR(50) NULL,
	Price DECIMAL(6,2) NULL,
	CategoryID INT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
)

CREATE TABLE Cheese(
	CheeseID INT IDENTITY NOT NULL PRIMARY KEY,
	CheeseName VARCHAR(50) NULL,
	Price DECIMAL(6,2) NOT NULL,
	CategoryID INT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
)

CREATE TABLE Filling(
	FillingID INT IDENTITY NOT NULL PRIMARY KEY,
	FillingName VARCHAR(50) NULL,
	Price DECIMAL(6,2) NOT NULL,
	CategoryID INT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
)

CREATE TABLE Topping(
	ToppingID INT IDENTITY NOT NULL PRIMARY KEY,
	ToppingName VARCHAR(50) NULL,
	Price DECIMAL(6,2) NOT NULL,
	CategoryID INT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
)

CREATE TABLE Extras(
	ExtrasID INT IDENTITY NOT NULL PRIMARY KEY,
	ExtrasName VARCHAR(50) NULL,
	Price DECIMAL(6,2) NOT NULL,
	CategoryID INT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
)

INSERT INTO Category VALUES ('Bread'), ('Cheese'), ('Filling'), ('Toppings'), ('Extras')

INSERT INTO Bread VALUES ('White', 0.10, 1), ('Brown', 0.12, 1)

INSERT INTO Cheese VALUES ('Cheddar', 0.15, 2), ('Swiss', 0.13, 2), ('American', 0.10, 2)

INSERT INTO Filling VALUES ('Ham', 1.00, 3), ('Chicken', 0.70, 3), ('Steak', 1.50, 3), ('Tuna', 0.75, 3), ('Turkey', 0.85, 3)

INSERT INTO Topping VALUES ('Lettuce', 0.20, 4), ('Sweetcorn', 0.20, 4), ('Onions', 0.15, 4), ('Cucumbers', 0.15, 4), ('Tomatoes', 0.25, 4)

INSERT INTO Extras VALUES ('Mayo', 0.20, 5), ('Garlic Mayo', 0.25, 5), ('Ketchup', 0.20, 5), ('Chilli', 0.30, 5), ('Bbq', 0.30, 5)

SELECT * FROM Category
SELECT * FROM Bread
SELECT * FROM Cheese
SELECT * FROM Filling
SELECT * FROM Topping
SELECT * FROM Extras

