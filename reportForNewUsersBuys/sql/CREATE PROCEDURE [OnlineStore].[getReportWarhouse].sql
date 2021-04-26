USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getStasticOrder]    Script Date: 05.03.2021 15:20:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 17-03-2021
-- Description:	Получение отчёта для сборщика заказов
-- =============================================
ALTER PROCEDURE [OnlineStore].[getReportWarhouse]	
	@listOrser nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	
select 
	o.id_Departments,
	trim(d.name) as nameDep,
	o.id_Tovar,
	trim(v.ean) as ean,
	trim(v.cname) as nameGood,
	o.Netto,	
	t.OrderNumber,	
	isnull(ag.MinOrder,0.0) as MinOrder
from 
	OnlineStore.j_Orders o
		left join OnlineStore.s_Goods g on g.id_Tovar = o.id_Tovar
		left join OnlineStore.s_AttributeGoods ag on ag.id_Goods = g.id
		left join OnlineStore.j_tOrders t on t.id = o.id_tOrders
		left join dbo.v_tovar v on v.id_tovar = o.id_Tovar
		left join dbo.departments d on d.id = o.id_Departments
where o.id_tOrders in (select value from dbo.StringToTable(@listOrser,','))

END
