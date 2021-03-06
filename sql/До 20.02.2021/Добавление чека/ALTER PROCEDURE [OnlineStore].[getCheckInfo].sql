USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getCheckInfo]    Script Date: 14.09.2020 11:34:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-06-01
-- Description:	Проверка чека по кассреализу
-- =============================================
ALTER PROCEDURE [OnlineStore].[getCheckInfo]
	@date datetime,
	@doc_id int,
	@terminal smallint,
	@id_prog int =  435
AS
BEGIN
	
if exists (select id from OnlineStore.Check_vs_Order where DateCheck = @date and KassNumber = @terminal and CheckNumber = @doc_id)
BEGIN
	select -1 as id
	return;
END


 declare 
	@MONTH varchar(2)
 set @MONTH=(case when MONTH(@date)<10 then '0'+cast(MONTH(@date) as varchar(1)) else cast(MONTH(@date) as varchar(2)) end)
 DECLARE 
	@dateStart datetime,@dateEnd datetime
	
 SET @dateStart = DATEADD(hour,8,@date)
 SET @dateEnd = DATEADD(hour,27,@date)

 declare @SQL varchar(MAX)
 declare @journal varchar(255)
 set @journal='[KassRealiz].[dbo].[journal_'+cast(YEAR(@date) as varchar)+'_'+@MONTH+']'   

 set @SQL = 
 'select sum(case when j.op_code = 507 then -1 else 1 end * cast(cash_val as numeric(15,2))/100) AS summa,j.terminal, j.doc_id,a.time from( '
 +'select j.terminal,
					j.doc_id,
					j.time
					from ' + @journal + ' j
					where convert(datetime, j.time) >= convert(datetime, ''' + convert(varchar,@dateStart,120) + ''') and convert(datetime, j.time) <= convert(datetime, ''' + convert(varchar,@dateEnd,120) + ''')'
					+' and j.doc_id = ' + rtrim(ltrim(STR(@doc_id))) 
					+' and j.terminal = ' +  rtrim(ltrim(STR(@terminal))) 
					+' and op_code = 509'
					+' group by terminal, doc_id, time'
					+') as a  inner join ' + @journal + ' j on j.terminal = a.terminal and j.doc_id = a.doc_id'
					+' where convert(datetime, j.time) >= convert(datetime, ''' + convert(varchar,@dateStart,120) + ''') and convert(datetime, j.time) <= convert(datetime, ''' + convert(varchar,@dateEnd,120) + ''')'
					+'and op_code in (505,507) and dpt_no not in (select value from dbo.prog_config where id_prog = '+cast(@id_prog as varchar(10))+' and id_value =''nudo'')'
					+'group by j.terminal, j.doc_id,a.time'

print (@SQL) 
exec (@SQL)

END