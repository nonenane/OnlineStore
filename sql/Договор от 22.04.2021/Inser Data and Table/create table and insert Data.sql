
INSERT INTO dbo.prog_config (id_prog,id_value,type_value,value_name,value,comment) 
values 
(435,'ftps','N','������ ftp','ftp:\\',''),
(435,'ftpl','N','�����','admin',''),
(435,'ftpp','N','������','admin',''),
(435,'lnln','N','������','\\',''),
(435,'lnlg','N','������','admin',''),
(435,'lnps','N','������','admin',''),
(435,'ntnp','N','','0','����� ������ � ���� ��� ��������'),
(435,'dson','N','','1','������ ����������� ������� ��������')

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


CREATE TABLE [OnlineStore].[j_Type�mployes�rder](
	[id]			int			IDENTITY(1,1) NOT NULL,
	[id_tOrders]	int			not null,
	[id_Kadr]		int			not null,
	[Collector]		bit			not null default 0,
	[KassCheck]		bit			not null default 0,
	[Delivery]		bit			not null default 0,
	[id_Editor]		int			not null,
	[DateEdit]		datetime	not null,	
 CONSTRAINT [PK_j_Type�mployes�rder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [OnlineStore].[j_Type�mployes�rder] ADD CONSTRAINT FK_j_Type�mployes�rder_id_tOrders FOREIGN KEY (id_tOrders)  REFERENCES [OnlineStore].[j_tOrders] (id)
GO

ALTER TABLE [OnlineStore].[j_Type�mployes�rder] ADD CONSTRAINT FK_j_Type�mployes�rder_id_Kadr FOREIGN KEY (id_Kadr)  REFERENCES [dbo].[s_kadr] (id)
GO

ALTER TABLE [OnlineStore].[j_Type�mployes�rder] ADD CONSTRAINT FK_j_Type�mployes�rder_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO
