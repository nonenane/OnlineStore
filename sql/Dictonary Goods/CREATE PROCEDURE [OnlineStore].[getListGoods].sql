
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SPG
-- Create date: 2020-04-07
-- Description:	Получение продаваемых товаров онлайн
-- =============================================
ALTER PROCEDURE [OnlineStore].[getListGoods]	
	@id_deps int 
AS
BEGIN
	SET NOCOUNT ON;

DECLARE @nowDate date = '2019-12-03';--getdate()


/*Движение товара за текущий день*/
BEGIN
declare @year int, @month int,@strYear nvarchar(4), @strMonth nvarchar(2), @startDate varchar(50),@endDate varchar(50), @SQL nvarchar(max)

set @year = YEAR(@nowDate);
set @month = MONTH(@nowDate);
set @strYear = @year;
set @strMonth = case when LEN(@month)=1 then '0' else '' end+cast(@month as varchar(2))

set @startDate = convert(varchar(50), dateadd(hour,6,cast(@nowDate as datetime)),120)
set @endDate   = convert(varchar(50), dateadd(hour,27,cast(@nowDate as datetime)),120)
set @SQL = '';

--DECLARE @table table (terminal int,op_code int, doc_id bigint,ean varchar(13),[count] int )
--DECLARE @table_tovar table (ean varchar(13),count numeric(17,3))


IF OBJECT_ID('tempdb.dbo.#table', 'U') IS NOT NULL
	DROP TABLE #table
IF OBJECT_ID('tempdb.dbo.#table_tovar', 'U') IS NOT NULL
	DROP TABLE #table_tovar
IF OBJECT_ID('tempdb.dbo.#table_fin', 'U') IS NOT NULL
	DROP TABLE #table_fin
IF OBJECT_ID('tempdb.dbo.#table_dvig_today', 'U') IS NOT NULL
	DROP TABLE #table_dvig_today

CREATE table #table (terminal int,op_code int, doc_id bigint,ean varchar(13),[count] int )
CREATE table #table_tovar (ean varchar(13),count numeric(17,3))
CREATE table #table_fin (ean varchar(13),count numeric(17,3))
CREATE table #table_dvig_today (id_tovar int,dvig_tovar_today numeric(17,3))

SET @SQL = 'select terminal,op_code,doc_id,ean,[count]
			from KassRealiz.dbo.journal_'+@strYear+'_'+@strMonth+' 
			where op_code in (505,507,509) and '''+@startDate+'''<= time and time <='''+@endDate+''''

INSERT INTO #table
EXEC (@SQL)

INSERT INTO #table_tovar
select 
	ltrim(rtrim(t2.ean)) as ean,
	case when t2.op_code = 507 then -1 else 1 end * cast(t2.count as numeric(17,3))/1000 as [count]	
from 
	#table t 
		inner join #table t2 on t2.terminal = t.terminal and t2.doc_id = t.doc_id and t2.op_code in (505,507)
where 
	t.op_code = 509

DROP TABLE #table

INSERT INTO #table_fin
select 
	ean,
	sum(count) as cnt	
from 
	#table_tovar
group by ean

DROP TABLE #table_tovar

INSERT INTO #table_dvig_today
select 
	t.id_Tovar,
	( prihod - vozvr - otgruz  - spis - vkass - isnull(f.[count],0) ) as dvig_tovar_today		
from(
select 
		g.id_Tovar,
		ltrim(rtrim(t.ean)) as ean,
			--Приход
		(SELECT ISNULL(SUM(netto),0)
			FROM dbo.j_allprihod a with (nolock)
					INNER JOIN dbo.j_prihod p with (nolock) on a.id = p.id_allprihod
			WHERE p.id_tovar = g.id_Tovar AND a.dprihod = cast(GETDATE() as date) and a.InventSpis = 0
		)  as prihod, 
		-- возврат
		(SELECT ISNULL(SUM(v.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					LEFT JOIN dbo.j_vozvr v with (nolock) ON a.id = v.id_allprihod
			WHERE v.id_tovar = g.id_Tovar AND a.dprihod = cast(GETDATE() as date) AND a.InventSpis = 0
		) as vozvr,
		-- отгрузка
		(SELECT ISNULL(SUM(o.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					INNER JOIN dbo.j_otgruz o with (nolock) ON a.id = o.id_allprihod
			WHERE o.id_tovar = g.id_Tovar AND a.dprihod = cast(GETDATE() as date) AND a.InventSpis = 0
		) as otgruz,		
		-- списание
		(SELECT ISNULL(SUM(s.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					LEFT JOIN dbo.j_spis s with (nolock) ON a.id = s.id_allprihod AND a.InventSpis = 0
			WHERE s.id_tovar = g.id_Tovar AND a.dprihod = cast(GETDATE() as date)			
		) AS  spis,			
		-- возврат с касс
		(SELECT ISNULL(SUM(vk.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					INNER JOIN dbo.j_vozvkass vk with (nolock) ON a.id = vk.id_allprihod
			WHERE vk.id_tovar = g.id_Tovar AND a.dprihod = cast(GETDATE() as date) AND a.InventSpis = 0
		) as vkass 
from 
	OnlineStore.s_Goods g
		left join dbo.s_tovar t on t.id = g.id_Tovar			
where 
	t.id_otdel = @id_deps or @id_deps = 0) as t
		left join #table_fin f on ltrim(rtrim(f.ean)) = ltrim(rtrim(t.ean))

DROP TABLE #table_fin
END

/*Остаток товара на утро*/
BEGIN

IF OBJECT_ID('tempdb.dbo.#table_ost_tovar', 'U') IS NOT NULL
	DROP TABLE #table_ost_tovar

CREATE table #table_ost_tovar (id_tovar int,ostOnDate numeric(17,3))

DECLARE @dateInv date	
set @dateInv =  [Requests].[GetDateInv](0)

INSERT INTO #table_ost_tovar
select 
	t.id_Tovar,
	( nachOst + postup/*-vkass*/ -otgruz - vozvr - spis - realiz - vkass) as ostOnDate
from(
select 
		g.id_Tovar,
		--Начальный остаток
		(
		SELECT ISNULL(SUM(jo.netto),0)
			FROM dbo.j_ost jo with (nolock)
					LEFT JOIN dbo.j_tost jt with (nolock) on jo.id_tost = jt.id
					LEFT JOIN dbo.j_ttost jtt with (nolock) on jt.id_ttost = jtt.id
			WHERE jt.dtost = @dateInv 
					AND jo.id_tovar = g.id_Tovar
		) as nachOst,
			--поступления
		(SELECT ISNULL(SUM(netto),0)
			FROM dbo.j_allprihod a with (nolock)
					INNER JOIN dbo.j_prihod p with (nolock) on a.id = p.id_allprihod
			WHERE p.id_tovar = g.id_Tovar
					AND a.dprihod < cast(GETDATE() as date)
					AND a.dprihod > @dateInv  AND a.InventSpis = 0
		)  as postup, 
		-- отгрузка
		(SELECT ISNULL(SUM(o.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					INNER JOIN dbo.j_otgruz o with (nolock) ON a.id = o.id_allprihod
			WHERE o.id_tovar = g.id_Tovar
					AND a.dprihod < cast(GETDATE() as date)
					AND a.dprihod > @dateInv AND a.InventSpis = 0
		) as otgruz,
		-- возврат поставщику
		(SELECT ISNULL(SUM(v.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					LEFT JOIN dbo.j_vozvr v with (nolock) ON a.id = v.id_allprihod
			WHERE v.id_tovar = g.id_Tovar
					AND a.dprihod < cast(GETDATE() as date)
					AND a.dprihod > @dateInv AND a.InventSpis = 0
		) as vozvr,
		-- списание
		(SELECT ISNULL(SUM(s.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					LEFT JOIN dbo.j_spis s with (nolock) ON a.id = s.id_allprihod AND a.InventSpis = 0
			WHERE s.id_tovar = g.id_Tovar
					AND a.dprihod < cast(GETDATE() as date)
					AND a.dprihod > @dateInv				
		) AS  spis,
		-- Реализация	
		(SELECT ISNULL(SUM(netto),0)
			FROM dbo.j_realiz with (nolock)
			WHERE id_tovar = g.id_Tovar
					AND drealiz < cast(GETDATE() as date)
					AND drealiz > @dateInv
		) as realiz,
		-- возврат с касс
		(SELECT ISNULL(SUM(vk.netto),0)
			FROM dbo.j_allprihod a with (nolock)
					INNER JOIN dbo.j_vozvkass vk with (nolock) ON a.id = vk.id_allprihod
			WHERE vk.id_tovar = g.id_Tovar
					AND a.dprihod < cast(GETDATE() as date)
					AND a.dprihod > @dateInv AND a.InventSpis = 0
		) as vkass 
from 
	OnlineStore.s_Goods g
		left join dbo.s_tovar t on t.id = g.id_Tovar
where 
	t.id_otdel = @id_deps or @id_deps = 0) as t
END


--select * from #table_dvig_today

select 
	g.id, 
	g.id_Tovar,
	ltrim(rtrim(t.ean)) as ean,
	g.ShortName,
	ltrim(rtrim(c.NameCategory)) as nameCategory,
	cast(0 as numeric(17,3)) as countOnlineSell,
	tdt.dvig_tovar_today as moveNow,
	tot.ostOnDate+tdt.dvig_tovar_today as ostNow,
	(select TOP(1) rcena from dbo.s_rcena r where r.id_tovar = g.id_Tovar and tdate_n<GETDATE() order by tdate_n desc) as rcena,
	g.BasicPrice as rcenaOnline,
	isnull(g.StockPrice,0) as rcenaPromo,
	t.id_grp1,
	t.id_grp2,
	g.id_Category,
	g.isActive,
	g.FullName,
	t.id_otdel,
	cast(0 as bit) as isSelect,
	case when c.id_ParentCategory is not null then cp.NameCategory + ' > ' else '' end +c.NameCategory as nameCategoryToCsv,
	g.isInsert,
	g.DateEdit
from 
	OnlineStore.s_Goods g
		left join dbo.s_tovar t on t.id = g.id_Tovar
		left join OnlineStore.s_Category c on c.id = g.id_Category	
		left join OnlineStore.s_Category cp on cp.id = c.id_ParentCategory
		left join #table_dvig_today tdt on tdt.id_tovar = g.id_Tovar
		left join #table_ost_tovar tot on tot.id_tovar = g.id_Tovar
where 
	@id_deps = 0 or t.id_otdel  = @id_deps


DROP TABLE #table_dvig_today,#table_ost_tovar

END
