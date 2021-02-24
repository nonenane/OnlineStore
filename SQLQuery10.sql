
DECLARE @listEAN nvarchar(max) = '6940360116598,4607176680959,4607065732820,4607015775969,4660085510663,4956'

--Формирование переменной текущей даты
DECLARE @date date = getdate();

DECLARE @year nvarchar(4) =  cast(YEAR(@date) as varchar(4))
DECLARE @month nvarchar(2) =  RIGHT('0'+cast(Month(@date) as varchar(2)),2)
DECLARE @nSQL nvarchar(max) = ''
DECLARE @startDate varchar(100) = convert(varchar(100),dateadd(hour,6,cast(@date as datetime)),120)
DECLARE @endDate varchar(100) = convert(varchar(100),dateadd(hour,27,cast(@date as datetime)),120)

--Создание временной таблицы для товаров
CREATE table #tableJournal (terminal int,op_code int,doc_id int,ean varchar(13),count numeric(16,3))

SET @nSQL = 'select terminal,op_code,doc_id,trim(ean) as ean ,count/1000.00 from dbo.journal_'+@year+'_'+@month+' where op_code in (509,505,507) and  '''+@startDate+''' <=time and time<='''+@endDate+'''';

insert into #tableJournal
exec (@nSQL)

select a.ean,sum(a.netto) as netto,a.price from(
select 
	b.ean,
	case when b.op_code = 507 then -1.0 else 1.0 end * b.count as netto,
	g.price/100.00 as price
from 
	#tableJournal t 
		inner join #tableJournal b on b.doc_id  = t.doc_id and b.terminal =  t.terminal and b.op_code in (505,507)
		inner join dbo.StringToTable(@listEAN,',') e on e.value = b.ean collate Cyrillic_General_CS_AS
		inner join dbo.goods_updates g on trim(g.ean) = b.ean collate Cyrillic_General_CS_AS and g.ActualRow = 1 
where 
	t.op_code = 509) as a
group by a.ean,a.price


DROP TABLE #tableJournal