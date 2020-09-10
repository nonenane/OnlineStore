CREATE TABLE [OnlineStore].[s_PercentSettingsGroups](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[id_grp2]		int				not null,
	[MarkUpPercent]	numeric(5,2)	null,
	[salePercent]	numeric(5,2)	null,
	[id_Creator]	int				not	null,
	[DateCreate]	datetime		not	null,
	[id_Editor]		int				not	null,
	[DateEdit]		datetime		not	null,
 CONSTRAINT [PK_s_PercentSettingsGroups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [OnlineStore].[s_PercentSettingsGroups] ADD CONSTRAINT FK_s_PercentSettingsGroups_id_grp2 FOREIGN KEY (id_grp2)  REFERENCES [dbo].[s_grp2] (id)
GO

ALTER TABLE [OnlineStore].[s_PercentSettingsGroups] ADD CONSTRAINT FK_s_PercentSettingsGroups_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [OnlineStore].[s_PercentSettingsGroups] ADD CONSTRAINT FK_s_PercentSettingsGroups_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO



CREATE TABLE [OnlineStore].[s_PercentSettingsGoods](
	[id]			int				IDENTITY(1,1) NOT NULL,
	[id_Tovar]		int				not null,
	[MarkUpPercent]	numeric(5,2)	null,
	[salePercent]	numeric(5,2)	null,
	[id_Creator]	int				not	null,
	[DateCreate]	datetime		not	null,
	[id_Editor]		int				not	null,
	[DateEdit]		datetime		not	null,
 CONSTRAINT [PK_s_PercentSettingsGoods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [OnlineStore].[s_PercentSettingsGoods] ADD CONSTRAINT FK_s_PercentSettingsGoods_id_Tovar FOREIGN KEY (id_Tovar)  REFERENCES [dbo].[s_tovar] (id)
GO

ALTER TABLE [OnlineStore].[s_PercentSettingsGoods] ADD CONSTRAINT FK_s_PercentSettingsGoods_id_Creator FOREIGN KEY (id_Creator)  REFERENCES [dbo].[ListUsers] (id)
GO

ALTER TABLE [OnlineStore].[s_PercentSettingsGoods] ADD CONSTRAINT FK_s_PercentSettingsGoods_id_Editor FOREIGN KEY (id_Editor)  REFERENCES [dbo].[ListUsers] (id)
GO



ALTER TABLE [OnlineStore].[j_JournalStatus]  DROP COLUMN id_Departments
ALTER TABLE [OnlineStore].[j_JournalStatus]  ADD Comment varchar(1024)	null

ALTER TABLE [OnlineStore].[j_tOrders]  ADD DeliveryDate Date  null
ALTER TABLE [OnlineStore].[j_tOrders]  ADD DeliveryCost numeric(10,2) null


ALTER TABLE [OnlineStore].[Check_vs_Order]  ADD Summa numeric(10,2) null