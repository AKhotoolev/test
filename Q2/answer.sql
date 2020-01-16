/*
В базе данных MS SQL Server есть продукты и категории. Одному продукту может
соответствовать много категорий, в одной категории может быть много продуктов.
Представьте схему такой БД и напишите SQL запрос для выбора всех пар «Имя продукта –
Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
*/

CREATE TABLE [dbo].[Product] (
	[ID]	INT				NOT NULL,
	[Name]	NVARCHAR(50)	NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[Category](
	[ID]	INT				NOT NULL,
	[Name]	NVARCHAR(50)	NOT NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE  [dbo].[ProductToCategory] (
	[ProductID]		INT	NOT NULL,
	[CategoryID]	INT	NOT NULL
)

ALTER TABLE [dbo].[ProductToCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductToCategory_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([Id])

ALTER TABLE [dbo].[ProductToCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductToCategory_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([Id])

INSERT INTO [dbo].[Product] ([ID],[Name]) VALUES (1, 'Apple')
INSERT INTO [dbo].[Product] ([ID],[Name]) VALUES (2, 'Cheese')
INSERT INTO [dbo].[Product] ([ID],[Name]) VALUES (3, 'Phone')
INSERT INTO [dbo].[Product] ([ID],[Name]) VALUES (4, 'StrangeBox')

INSERT INTO [dbo].[Category] ([ID],[Name]) VALUES (1, 'Food')
INSERT INTO [dbo].[Category] ([ID],[Name]) VALUES (2, 'Fruits')
INSERT INTO [dbo].[Category] ([ID],[Name]) VALUES (3, 'Electronics')

INSERT INTO [dbo].[ProductToCategory] ([ProductID],[CategoryID]) VALUES (1,1)
INSERT INTO [dbo].[ProductToCategory] ([ProductID],[CategoryID]) VALUES (1,2)
INSERT INTO [dbo].[ProductToCategory] ([ProductID],[CategoryID]) VALUES (2,1)
INSERT INTO [dbo].[ProductToCategory] ([ProductID],[CategoryID]) VALUES (3,3)


SELECT p.[Name], c.[Name] FROM [dbo].[Product] p
LEFT JOIN [dbo].[ProductToCategory] pc ON p.ID = pc.ProductID
LEFT JOIN [dbo].[Category] c ON c.ID = pc.CategoryID


/*
Name	Name
Apple	Food
Apple	Fruits
Cheese	Food
Phone	Electronics
StrangeBox	NULL
*/