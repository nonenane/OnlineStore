USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_tOrders]    Script Date: 11.02.2021 16:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 15-04-2020
-- Description:	Загрузка заказов
-- update:		kav 2020-12-22 поле тип доставки
-- =============================================
ALTER PROCEDURE [OnlineStore].[get_tOrders]	
	@startdate datetime,
	@enddate datetime,
	@id_dep int,
	@type int = 1
AS
BEGIN
	SET NOCOUNT ON;

DECLARE @table table (id_tOrders int ,id_Status int)

insert into @table
select distinct
	s.id_tOrders,
	s.id_Status
from(
select 
	id_tOrders,
	max(DateEdit) as DateEdit
from 
	OnlineStore.j_JournalStatus 
group by id_tOrders) as a inner join OnlineStore.j_JournalStatus s on s.id_tOrders = a.id_tOrders and s.DateEdit = a.DateEdit
order by s.id_tOrders

IF @type<>1 SET @enddate = DATEADD(day,-1,@enddate)

	select 
		tOrd.id,
		ltrim(rtrim(tOrd.OrderNumber)) as OrderNumber,
		tOrd.DateOrder,
		ltrim(rtrim(tOrd.LastnameBuyer)) + ' ' + ltrim(rtrim(tOrd.NameBuyer)) as FIO,
		ltrim(rtrim(tOrd.Email)) as Email,
		ltrim(rtrim(tOrd.Phone)) as Phone,
		ltrim(rtrim(tOrd.Address)) as Address,
		convert(numeric(16,2),sum(Ord.Netto * Ord.Price),0) as sumOrder,
		tOrd.CommentOrder,
		tOrd.SummaDelivery,
		ISNULL(tOrd.Comment,'') as Comment,
		sPay.cName as paymentType,
		case when exists (select id from OnlineStore.j_Orders where id_Departments=6) then '1' else '0' end  dep6,
		case when exists (select id from OnlineStore.j_Orders where (@id_dep is not null and id_Departments=@id_dep) and id_tOrders=tOrd.id) then '1' else '0' end depRuk
		--,case when exists (select jo.id from OnlineStore.j_Orders jo
						 --where jo.Price!=jo.BasicPrice and jo.id_tOrders=tOrd.id) then '1' else '0' end havingBadPrice
		,case when exists (select jo.id from OnlineStore.j_Orders jo
											inner join OnlineStore.s_Goods gg on gg.id_Tovar = jo.id_Tovar
						 where jo.Price!=gg.BasicPrice and jo.id_tOrders=tOrd.id) then '1' else '0' end havingBadPrice
		--,'0' as havingBadPrice				 ---Надо удалить, а что ставить не сказанно.
		,tStatus.id_Status
		,tOrd.DeliveryCost
		,tOrd.DeliveryDate,
		tOrd.DeliveryType,
		tOrd.PlanDeliveryDate
		from OnlineStore.j_tOrders tOrd
		left join OnlineStore.j_Orders Ord on tOrd.id=Ord.id_tOrders
		inner join OnlineStore.s_Payment sPay on tOrd.id_Payment=sPay.id
		left join @table tStatus on tStatus.id_tOrders = tOrd.id
		where 
			(@type = 1 and tOrd.DateOrder>=@startdate and tOrd.DateOrder<=@enddate) 
			or
			(@type = 2 and tOrd.DeliveryDate>=@startdate and tOrd.DeliveryDate<=@enddate) 
			or
			(@type = 3 and tOrd.PlanDeliveryDate>=@startdate and tOrd.PlanDeliveryDate<=@enddate) 
		group by tOrd.id,tOrd.OrderNumber,tOrd.DateOrder,tOrd.Email,tOrd.Phone,tOrd.Address,tOrd.CommentOrder,sPay.cName,
		tOrd.LastnameBuyer,tOrd.NameBuyer,tOrd.Comment, tOrd.SummaDelivery,tStatus.id_Status,tOrd.DeliveryCost,tOrd.DeliveryDate, tOrd.DeliveryType,tOrd.PlanDeliveryDate
		order by DateOrder
END

