	DECLARE @StartDate datetime = '2021-03-01',
	@EndDate datetime = '2021-03-05',
	@id_period int = 1,
	@id_prog int =  435

	DECLARE @resultSum numeric(38,2) = 0
	CREATE TABLE #tableStatus (id_tOrders int ,id_Status int,Comment varchar(max))
	CREATE TABLE #Table (ean varchar(13), cnt numeric(15,3))
	CREATE TABLE #Table_2 (DateCheck Date, CheckNumber int, KassNumber int)
	CREATE TABLE #TableResult (DateCheck Date,KassNumber  int, CheckNumber varchar(max))
	CREATE TABLE #rCena (id_tovar int, rcena numeric(15,3))



	insert into #tableStatus
	select distinct
		s.id_tOrders,
		s.id_Status,
		s.Comment
	from(
	select 
		id_tOrders,
		max(DateEdit) as DateEdit
	from 
		OnlineStore.j_JournalStatus 
	group by id_tOrders) as a inner join OnlineStore.j_JournalStatus s on s.id_tOrders = a.id_tOrders and s.DateEdit = a.DateEdit
	where s.id_Status = 3

	INSERT INTO #Table_2
	select c.DateCheck,c.CheckNumber,c.KassNumber from #tableStatus t inner join OnlineStore.j_tOrders o on o.id = t.id_tOrders inner join OnlineStore.Check_vs_Order c on c.id_tOrder = t.id_tOrders
		where 
		@StartDate<=cast(o.DeliveryDate as date) and cast(o.DeliveryDate as date)<=@EndDate
		and c.isPackage = 0

INSERT INTO #TableResult
select a.DateCheck,a.KassNumber,(select distinct cast(t.CheckNumber as varchar(max)) +',' from  #Table_2 t where t.DateCheck=a.DateCheck and t.KassNumber = a.KassNumber FOR xml path('')) as CheckNumber
from (
select 
	c.DateCheck,c.KassNumber 
from 
	#Table_2 c
group by 
	c.DateCheck,c.KassNumber) as a
	
DROP TABLE #tableStatus,#Table_2

UPDATE #TableResult set CheckNumber =  substring(CheckNumber,1,LEN(CheckNumber)-1)


DECLARE @DateCheck datetime, @CheckNumber varchar(max), @KassNumber   int

	DECLARE notes_cursor CURSOR LOCAL FOR
		select c.DateCheck,c.CheckNumber,c.KassNumber from #TableResult c
	OPEN notes_cursor
	FETCH NEXT FROM notes_cursor INTO @DateCheck, @CheckNumber,@KassNumber
	WHILE @@FETCH_STATUS=0
	BEGIN				
			DELETE FROM #rCena
			insert into #rCena
			select r.id_tovar,r.rcena from(
			select id_tovar,max(tdate_n) as tdate_n from dbo.s_rcena where tdate_n<=@DateCheck group by id_tovar) as a inner join dbo.s_rcena r on r.id_tovar = a.id_tovar and r.tdate_n = a.tdate_n
		
			declare 
				@MONTH varchar(2)
			set @MONTH=(case when MONTH(@DateCheck)<10 then '0'+cast(MONTH(@DateCheck) as varchar(1)) else cast(MONTH(@DateCheck) as varchar(2)) end)
			DECLARE 
				@dateStart datetime,@dateEnd datetime, @tmpDate date 
				set @tmpDate = @DateCheck
	
			SET @dateStart = DATEADD(hour,8,cast(@tmpDate as datetime))
			SET @dateEnd = DATEADD(hour,27,cast(@tmpDate as datetime))

			declare @SQL varchar(MAX)
			declare @journal varchar(255)
			set @journal='[KassRealiz].[dbo].[journal_'+cast(YEAR(@DateCheck) as varchar)+'_'+@MONTH+']'   

			 set @SQL = 
			 'select ltrim(rtrim(j.ean)) as ean,  (case when j.op_code = 507 then -1 else 1 end * j.count)/1000.0 AS count from( '
			 +'select j.terminal,
								j.doc_id,
								j.time					
								from ' + @journal + ' j
								where convert(datetime, j.time) >= convert(datetime, ''' + convert(varchar,@dateStart,120) + ''') and convert(datetime, j.time) <= convert(datetime, ''' + convert(varchar,@dateEnd,120) + ''')'
								+' and j.doc_id in (' + @CheckNumber
								+') and j.terminal = ' +  rtrim(ltrim(STR(@KassNumber))) 
								+' and op_code = 509'
								+' group by terminal, doc_id, time'
								+') as a  inner join ' + @journal + ' j on j.terminal = a.terminal and j.doc_id = a.doc_id'
								+' where convert(datetime, j.time) >= convert(datetime, ''' + convert(varchar,@dateStart,120) + ''') and convert(datetime, j.time) <= convert(datetime, ''' + convert(varchar,@dateEnd,120) + ''')'
								+'and op_code in (505,507) and dpt_no not in (select value from dbo.prog_config where id_prog = '+cast(@id_prog as varchar(10))+' and id_value =''nudo'')'						

			
			delete from #Table

			--print @SQL

			INSERT INTO #Table 
			exec (@SQL)
			
			select @resultSum=@resultSum+sum(k.cnt*isnull(r.rcena,0)) from (select k.ean,sum(k.cnt) as cnt  from #Table k group by k.ean) as k inner join dbo.s_tovar t on ltrim(rtrim(t.ean)) = k.ean inner join #rCena r on r.id_tovar = t.id
			


	FETCH NEXT FROM notes_cursor 
		  INTO @DateCheck, @CheckNumber,@KassNumber
	END
	CLOSE notes_cursor
	DEALLOCATE notes_cursor

	select @resultSum as sumResult,@id_period as id_period



DROP TABLE #TableResult,#Table,#rCena