USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_Orders]    Script Date: 11.03.2021 13:16:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 15-04-2020
-- Description:	Загрузка товаров в заказе
-- UPD:			Базовая цена товара и вес товара (2020-05-06 KAV)
-- UPDATE:		подгружаем id заказа
-- =============================================
ALTER PROCEDURE [OnlineStore].[get_Orders]	
	@id_tOrder int
AS
BEGIN
	SET NOCOUNT ON;

	select 
		ord.id,
		ord.Position,
		ord.id_Tovar,
		ord.id_Departments,
		dep.name,
		tov.ean,
		ttov.cName +' ' + ntov.cname as nameTovar,
		ord.Netto as Netto,
		ord.Price,
		Convert(numeric(16,2),ord.Netto*ord.Price,0) as sumTovar-- А ТАК МОЖНО?)))))
		,isnull(gg.BasicPrice,0.00) as BasicPrice--,isnull(ord.BasicPrice,0.00) as BasicPrice --- ЧТО с этой хренью делать на что менять в ТЗ не сказано! сделаю тупо 0.00
		,tov.brutto
		,id_tOrders
	from OnlineStore.j_Orders ord
	left join dbo.s_tovar tov on ord.id_Tovar = tov.id
	left join dbo.s_ntovar ntov on tov.id= ntov.id_tovar
	left join dbo.s_TypeTovar ttov on ntov.ntypetovar=ttov.id
	left join dbo.departments dep on ord.id_Departments=dep.id
	left join OnlineStore.s_Goods gg on gg.id_Tovar = ord.id_Tovar
	where ord.id_tOrders= @id_tOrder
	and ntov.tdate_n = (select max(tdate_n) from s_ntovar nt where nt.id_tovar=tov.id)
	order by ord.Position

END
