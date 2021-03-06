USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getCheck]    Script Date: 14.09.2020 13:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-07-06
-- Description:	Загрузка чека
-- =============================================
ALTER PROCEDURE [OnlineStore].[getCheck]	
	@doc_id int,
	@date datetime,
	@terminal int,
	@id_prog int =  435
AS
BEGIN
	
		declare @MONTH varchar(2)
 set @MONTH=(case when MONTH(@date)<10 then '0'+cast(MONTH(@date) as varchar(1)) else cast(MONTH(@date) as varchar(2)) end)
 declare @SQL varchar(MAX)
 declare @journal varchar(255)
 set @journal='[KassRealiz].[dbo].[journal_'+cast(YEAR(@date) as varchar)+'_'+@MONTH+']'   


  set @SQL = 'select 
					ltrim(rtrim(j.ean)) as ean,
					ltrim(rtrim(snt.cname)) as nametovar,
					case when j.op_code = 505 then Convert(numeric(16,3),(j.count)/1000.0) 
						else Convert(numeric(16,3),-(j.count)/1000.0) end as count,
					case when j.op_code = 505 then Convert(numeric(16,2),(j.price)/100.0) 
						else Convert(numeric(16,2),-(j.price)/100.0) end as price,
					case when j.op_code = 505 then Convert(numeric(16,2),(j.cash_val)/100.0) 
						else Convert(numeric(16,2),-(j.cash_val)/100.0) end as sumtovar 
				
					
					from ' + @journal + ' j 
					left join [ISI_SERVER].dbase1.dbo.s_tovar st on ltrim(rtrim(j.ean)) = ltrim(rtrim(st.ean)) collate Cyrillic_General_CS_AI
					left join [ISI_SERVER].dbase1.dbo.s_ntovar snt on snt.id_tovar = st.id and snt.id = 
					(select top(1) id from [ISI_SERVER].dbase1.dbo.s_ntovar q where q.id_tovar = st.id and tdate_n<= ''' + convert(varchar,@date,23) + ''' order by tdate_n desc) 
					where
					j.doc_id = ' + rtrim(ltrim(STR(@doc_id))) + ' 
					and j.terminal = ' +  rtrim(ltrim(STR(@terminal))) +
					' and j.op_code in (505,507)  and dpt_no not in (select value from dbo.prog_config where id_prog = '+cast(@id_prog as varchar(10))+' and id_value =''nudo'')
					--group by st.ean, snt.cname, op_code
					'

print(@SQL)
exec (@SQL)

END