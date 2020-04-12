CREATE TABLE [OnlineStore].[s_Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NameCategory]			varchar(max)	not null,
	[id_Departments]		int				not null,
	[id_ParentCategory]		int				null,
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--ALTER TABLE [OnlineStore].[s_Category] ADD CONSTRAINT FK_s_Category_id_Departments FOREIGN KEY (id_Departments)  REFERENCES [dbo].[departments] (id)
--GO

ALTER TABLE [OnlineStore].[s_Category] ADD CONSTRAINT FK_s_Category_id_ParentCategory FOREIGN KEY (id_ParentCategory)  REFERENCES [OnlineStore].[s_Category] (id)
GO

ALTER TABLE [OnlineStore].[s_Category] ADD CONSTRAINT FK_s_Category_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [OnlineStore].[s_Category] ADD CONSTRAINT FK_s_Category_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO


CREATE TABLE [OnlineStore].[s_Goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Tovar]				int				not null,
	[ShortName]				varchar(50)		not null,
	[FullName]				varchar(max)	not null,	
	[id_Category]			int				not null,
	[BasicPrice]			numeric(16,2)	not null,
	[StockPrice]			numeric(16,2)	null,
	[isInsert]				int				not null	DEFAULT 0,
	[isActive]				bit				not null	DEFAULT 1,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_Goods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [OnlineStore].[s_Goods] ADD CONSTRAINT FK_s_Goods_id_Tovar FOREIGN KEY (id_Tovar)  REFERENCES [dbo].[s_tovar] (id)
GO

ALTER TABLE [OnlineStore].[s_Goods] ADD CONSTRAINT FK_s_Goods_id_Category FOREIGN KEY (id_Category)  REFERENCES [OnlineStore].[s_Category] (id)
GO

ALTER TABLE [OnlineStore].[s_Goods] ADD CONSTRAINT FK_s_Goods_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [OnlineStore].[s_Goods] ADD CONSTRAINT FK_s_Goods_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO



CREATE TABLE [OnlineStore].[s_AttributeGoods](
	[id] [int] IDENTITY(1,1) NOT NULL,	
	[id_Goods]				int				not null,
	[MinOrder]				numeric(16,2)	not null,
	[MaxOrder]				numeric(16,2)	not null,
	[Step]					numeric(16,2)	not null,
	[DefaultNetto]			numeric(16,2)	not null,
	[PriceSuffix]			varchar(50)		not null,
	[QuantitySuffix]		varchar(50)		not null,
	[id_Creator]			int				not null,
	[DateCreate]			datetime		not null,
	[id_Editor]				int				null,
	[DateEdit]				datetime		null,
 CONSTRAINT [PK_s_AttributeGoods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [OnlineStore].[s_AttributeGoods] ADD CONSTRAINT FK_s_AttributeGoods_id_Goods FOREIGN KEY (id_Goods)  REFERENCES [OnlineStore].[s_Goods] (id)
GO

ALTER TABLE [OnlineStore].[s_AttributeGoods] ADD CONSTRAINT FK_s_AttributeGoods_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [OnlineStore].[s_AttributeGoods] ADD CONSTRAINT FK_s_AttributeGoods_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO