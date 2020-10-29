USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[get_tOrders]    Script Date: 14.09.2020 19:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sporykhin G Y
-- Create date: 16-09-2020
-- Description:	��������� ����� �� ������ � ������ rcena
-- =============================================
ALTER PROCEDURE [OnlineStore].[getSumNotesOrderWithRCena]	
	@StartDate datetime,
	@EndDate datetime,
	@id_period int,
	@id_prog int =  435
AS
BEGIN
	SET NOCOUNT ON;


	DECLARE @resultSum numeric(38,2) = 0
	DECLARE @tableStatus table (id_tOrders int ,id_Status int,Comment varchar(max))
	DECLARE @tableResult table (id_tOrders int ,resultSum numeric(38,2))
	DECLARE @Table table (ean varchar(13), cnt numeric(15,3))

	insert into @tableStatus
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

	DECLARE @DateCheck datetime, @CheckNumber int, @KassNumber int, @id_tOrders int

	DECLARE notes_cursor CURSOR LOCAL FOR
		select c.DateCheck,c.CheckNumber,c.KassNumber,t.id_tOrders from @tableStatus t inner join OnlineStore.j_tOrders o on o.id = t.id_tOrders inner join OnlineStore.Check_vs_Order c on c.id_tOrder = t.id_tOrders
		--where @StartDate<=cast(o.DateOrder as date) and cast(o.DateOrder as date)<=@EndDate and c.isPackage = 0
		where @StartDate<=cast(o.DeliveryDate as date) and cast(o.DeliveryDate as date)<=@EndDate and c.isPackage = 0
	OPEN notes_cursor
	FETCH NEXT FROM notes_cursor INTO @DateCheck, @CheckNumber,@KassNumber,@id_tOrders
	WHILE @@FETCH_STATUS=0
	BEGIN	
			print @KassNumber
			DECLARE @rCena table (id_tovar int, rcena numeric(15,3))
			insert into @rCena
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
								+' and j.doc_id = ' + rtrim(ltrim(STR(@CheckNumber))) 
								+' and j.terminal = ' +  rtrim(ltrim(STR(@KassNumber))) 
								+' and op_code = 509'
								+' group by terminal, doc_id, time'
								+') as a  inner join ' + @journal + ' j on j.terminal = a.terminal and j.doc_id = a.doc_id'
								+' where convert(datetime, j.time) >= convert(datetime, ''' + convert(varchar,@dateStart,120) + ''') and convert(datetime, j.time) <= convert(datetime, ''' + convert(varchar,@dateEnd,120) + ''')'
								+'and op_code in (505,507) and dpt_no not in (select value from dbo.prog_config where id_prog = '+cast(@id_prog as varchar(10))+' and id_value =''nudo'')'					

			delete from @Table

			--print @SQL

			INSERT INTO @Table 
			exec (@SQL)
			
			insert into @tableResult
			select @id_tOrders,sum(k.cnt*isnull(r.rcena,0)) from @Table k inner join dbo.s_tovar t on ltrim(rtrim(t.ean)) = k.ean inner join @rCena r on r.id_tovar = t.id


	FETCH NEXT FROM notes_cursor 
		  INTO @DateCheck, @CheckNumber,@KassNumber,@id_tOrders
	END
	CLOSE notes_cursor
	DEALLOCATE notes_cursor

	select id_tOrders,sum(resultSum) as resultSum from @tableResult group by id_tOrders

END