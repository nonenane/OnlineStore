DECLARE @id_tOrders int = 1118

--Формирование переменной текущей даты
DECLARE @dateEnd date = getdate();

CREATE TABLE #tableTovar (id_tovar int)

insert #tableTovar (id_tovar)
select id_Tovar from OnlineStore.j_Orders where id_tOrders = @id_tOrders

--Расчёт заказанных товаров за дату доставки
DECLARE @PlanDeliveryDate date
select @PlanDeliveryDate = PlanDeliveryDate from OnlineStore.j_tOrders where id = @id_tOrders

CREATE table #tableStatus (id_tOrders int)

INSERT INTO #tableStatus
select j.id_tOrders from OnlineStore.j_JournalStatus j
inner join (select id_tOrders, max(DateEdit) as DateEdit from OnlineStore.j_JournalStatus group by id_tOrders) as a on a.id_tOrders = j.id_tOrders and a.DateEdit = j.DateEdit
where j.id_Status in (1,2)

CREATE table #tableOrderTovarDate (id_Tovar int,netto numeric(16,3))

INSERT INTO #tableOrderTovarDate
select 
	t.id_Tovar, sum(t.Netto)  as netto
from 
	OnlineStore.j_tOrders o
	inner join OnlineStore.j_Orders t on t.id_tOrders =o.id
	inner join #tableStatus j on j.id_tOrders = o.id
	inner join #tableTovar tt on tt.id_tovar = t.id_Tovar
where 
	o.PlanDeliveryDate = @PlanDeliveryDate
group by t.id_Tovar

DROP TABLE #tableStatus

--Расчёт цены на товары в магазине
CREATE TABLE #tablePrice (id_tovar int, price numeric(13,2))

INSERT INTO #tablePrice
select r.id_tovar,r.rcena from(
select t.id_tovar,max(r.tdate_n)  as tdate_n
from #tableTovar t
		left join dbo.s_rcena r on r.id_tovar  = t.id_tovar
where r.tdate_n<=@dateEnd group by t.id_tovar) as a inner join dbo.s_rcena r on r.id_tovar = a.id_tovar and r.tdate_n = a.tdate_n

--Получение даты инвентаризации
DECLARE @dttost date
select TOP(1) @dttost = dttost from dbo.j_ttost where dttost<=@dateEnd and promeg = 0 order by dttost desc

CREATE table #tableDvigTovar (id_Tovar int,netto numeric(16,3))

INSERT INTO #tableDvigTovar
select a.id_tovar, sum(a.netto) as netto from(

--Расчёт остатков по инвенты на дату
select 
	o.id_tovar,
	ISNULL(ost.netto,0.0) AS netto 
from #tableTovar o 
inner join (select 
	id_tovar,trim(ean) as ean,sum(netto) as netto
from	
	dbo.j_ost 
where 
		id_tost in ( select id from dbo.j_tost where id_ttost in(select TOP(1) id from dbo.j_ttost where dttost<=@dateEnd and promeg = 0 order by dttost desc))	
group by id_tovar,trim(ean)) as ost on ost.id_tovar = o.id_tovar

union all

--Расчёт реализации
select 
	r.id_tovar ,-1*sum(r.netto) as netto 
from 
	dbo.j_realiz r
where 
	@dttost<= r.drealiz and r.drealiz<=@dateEnd and
	r.id_tovar in (select t.id_tovar from #tableTovar t)
group by 
	r.id_tovar

union all
select a.id_tovar,a.netto from(
select 	
	case 
		when p.id_tovar is not null  then p.id_tovar 
		when s.id_tovar is not null  then s.id_tovar 
		when v.id_tovar is not null  then v.id_tovar 
		when o.id_tovar is not null  then o.id_tovar 
		when vk.id_tovar is not null  then vk.id_tovar 
	end as id_tovar,
	case 
		when p.netto is not null  then p.netto 
		when s.netto is not null  then -1* s.netto 
		when v.netto is not null  then -1* v.netto 
		when o.netto is not null  then -1* o.netto 
		when vk.netto is not null  then abs(vk.netto)
	end as netto
		
from 
	dbo.j_allprihod a
		left join dbo.j_prihod p on p.id_allprihod = a.id and a.id_operand in (1,3) and p.id_tovar in (select t2.id_tovar from #tableTovar t2)
		left join dbo.j_spis s on s.id_allprihod = a.id and s.id_tovar in (select t2.id_tovar from #tableTovar t2)
		left join dbo.j_vozvr v on v.id_allprihod = a.id and v.id_tovar in (select t2.id_tovar from #tableTovar t2)
		left join dbo.j_otgruz o on o.id_allprihod = a.id and o.id_tovar in (select t2.id_tovar from #tableTovar t2)
		left join dbo.j_vozvkass vk on vk.id_allprihod = a.id and vk.id_tovar in (select t2.id_tovar from #tableTovar t2)
where 
	@dttost<= a.dprihod and a.dprihod<=@dateEnd and a.id_operand in (1,2,3,5,7,8) ) as a where a.id_tovar is not null

union all

--Расчёт накладных у оформителя
select a.id_tovar,a.netto from(
select 
	--trim(t.EAN) as ean,
	nt.id as id_tovar,
	sum(case when n.id_Operand in (2) then -1.0 else 1.0 end * t.Netto) as netto
from 
	dbo.j_NaklOform n 
		inner join dbo.j_NaklTovars t on t.id_Nakl = n.id and t.isActiv = 1
		inner join dbo.s_tovar nt on trim(nt.ean)  = trim(t.EAN)
where 
	@dttost<= n.DateNakl and n.DateNakl<=@dateEnd and 
	n.isActive = 1 and n.id_Status in (0,1,2)
group by nt.id --trim(t.EAN)
) as a where a.id_tovar in (select t2.id_tovar from #tableTovar t2)
) as a
group by a.id_tovar
--order by a.id_tovar asc


select 
	t.id_tovar,
	trim(tt.ean) as ean,
	isnull(ord.netto,0.000) as nettoOrder,
	isnull(dvig.netto,0.000) as nettiDvig,
	p.price,
	[OnlineStore].[fGetPercentsTovar](t.id_tovar,0)+100 as upperPrice,
	cast(case when c.id is not null then 1 else 0 end as bit) as isPromo
from 
	#tableTovar t
		left join #tableOrderTovarDate ord on ord.id_Tovar = t.id_tovar
		left join #tableDvigTovar dvig on dvig.id_Tovar = t.id_tovar
		left join dbo.s_tovar tt on tt.id = t.id_tovar
		left join #tablePrice p on p.id_tovar = t.id_tovar
		left join requests.s_CatalogPromotionalTovars c on c.id_tovar = t.id_tovar

--Удаление временных таблиц
DROP TABLE #tableTovar
DROP TABLE #tableOrderTovarDate
DROP TABLE #tableDvigTovar
DROP TABLE #tablePrice