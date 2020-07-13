IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Warehouse')
CREATE DATABASE Warehouse
GO

USE Warehouse
GO

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'Product')
drop table Product

create table Product
(
ProductID int primary key identity(1,1) not null,
ProductName nvarchar(500) not null,
ProductCode nvarchar(100) not null,
ProductAmmount int DEFAULT 0 Check (ProductAmmount>=0 and ProductAmmount <101),
Price decimal (6,2) not null,
InStock nvarchar(3) DEFAULT 'NO' Check (UPPER(InStock) = 'YES' or UPPER(InStock) = 'NO') not null
)