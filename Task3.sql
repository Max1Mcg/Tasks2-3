/* 
Перед использованием нужно создать БД ProdCat
Отсутствие категории у продукта подразумевает то, что она ещё не была присвоена, поэтому у всех полей, которые не являются первичными ключами, стоит ограничение на NOT NULL
 */

use ProdCat;

CREATE TABLE Products (
	Id INT PRIMARY KEY,
	"Name" TEXT NOT NULL
);

CREATE TABLE Categories (
	Id INT PRIMARY KEY,
	"Name" TEXT NOT NULL
);

CREATE TABLE ProductsCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO Products
VALUES
	(1, 'Unreal engine'),
	(2, 'CS:GO'),
	(3, 'Lord of the rings'),
	(4, 'sql');

INSERT INTO Categories
VALUES
	(1, 'Game engine'),
	(2, 'Computer game'),
	(3, 'Movie trilogy');

INSERT INTO ProductsCategories
VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(1, 2);

SELECT P."Name", C."Name"
FROM Products P
LEFT JOIN ProductsCategories PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON PC.CategoryId = C.Id;