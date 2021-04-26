
INSERT INTO dbo.prog_config (id_prog,id_value,type_value,value_name,value,comment) 
values 
(435,'ftps','N','ссылка ftp','ftp:\\',''),
(435,'ftpl','N','логин','admin',''),
(435,'ftpp','N','пароль','admin',''),
(435,'lnln','N','пароль','\\',''),
(435,'lnlg','N','пароль','admin',''),
(435,'lnps','N','пароль','admin',''),
(435,'ntnp','N','','0','новые товары в файл без картинки'),
(435,'dson','N','','1','отделы сотрудников заказов магазина')

ALTER TABLE [OnlineStore].[s_Goods]  ADD [isPicture] bit not null default 0


CREATE TABLE [OnlineStore].[s_Goods_vs_Category](
	[id]			int			IDENTITY(1,1) NOT NULL,
	[id_Goods]		int			not null,
	[id_Category]	int			not null,
	[id_Editor]		int			not null,
	[DateEdit]		datetime	not null,	
 CONSTRAINT [PK_s_Goods_vs_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [OnlineStore].[s_Goods_vs_Category] ADD CONSTRAINT FK_s_Goods_vs_Category_id_Goods FOREIGN KEY (id_Goods)  REFERENCES [OnlineStore].[s_Goods] (id)
GO

ALTER TABLE [OnlineStore].[s_Goods_vs_Category] ADD CONSTRAINT FK_s_Goods_vs_Category_id_Category FOREIGN KEY (id_Category)  REFERENCES [OnlineStore].[s_Category] (id)
GO

ALTER TABLE [OnlineStore].[s_Goods_vs_Category] ADD CONSTRAINT FK_s_Goods_vs_Category_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO


CREATE TABLE [OnlineStore].[j_TypeЕmployesОrder](
	[id]			int			IDENTITY(1,1) NOT NULL,
	[id_tOrders]	int			not null,
	[id_Kadr]		int			not null,
	[Collector]		bit			not null default 0,
	[KassCheck]		bit			not null default 0,
	[Delivery]		bit			not null default 0,
	[id_Editor]		int			not null,
	[DateEdit]		datetime	not null,	
 CONSTRAINT [PK_j_TypeЕmployesОrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [OnlineStore].[j_TypeЕmployesОrder] ADD CONSTRAINT FK_j_TypeЕmployesОrder_id_tOrders FOREIGN KEY (id_tOrders)  REFERENCES [OnlineStore].[j_tOrders] (id)
GO

ALTER TABLE [OnlineStore].[j_TypeЕmployesОrder] ADD CONSTRAINT FK_j_TypeЕmployesОrder_id_Kadr FOREIGN KEY (id_Kadr)  REFERENCES [dbo].[s_kadr] (id)
GO

ALTER TABLE [OnlineStore].[j_TypeЕmployesОrder] ADD CONSTRAINT FK_j_TypeЕmployesОrder_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO
