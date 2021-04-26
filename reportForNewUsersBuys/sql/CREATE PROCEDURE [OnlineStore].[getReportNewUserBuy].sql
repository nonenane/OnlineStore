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
-- Description:	Получение отчёта по новым покупателям за период
-- =============================================
ALTER PROCEDURE [OnlineStore].[getReportNewUserBuy]	
	@dateStart date,
	@dateEnd date
AS
BEGIN
	SET NOCOUNT ON;


CREATE TABLE #userPhone (Email varchar(max),NameBuyer  varchar(max),LastnameBuyer   varchar(max), Phone varchar(10))
CREATE TABLE #userPhoneFinal (Email varchar(max),NameBuyer  varchar(max),LastnameBuyer   varchar(max), Phone varchar(max),countOrder int)
CREATE TABLE #userDate (id int,Email varchar(max),NameBuyer  varchar(max),LastnameBuyer   varchar(max), Phone varchar(10),maxDate date)
CREATE TABLE #userDateFinal (Email varchar(max),NameBuyer  varchar(max),LastnameBuyer   varchar(max), Phone varchar(max),countOrder int,maxDate date)

INSERT INTO #userPhone
select --distinct
	a.Email,
	a.NameBuyer,
	a.LastnameBuyer,	
	CASE WHEN LEN(a.replacePhone) = 10 THEN a.replacePhone ELSE SUBSTRING(a.replacePhone,2,10) END as endPhone
from (
select 
	o.Email,
	o.LastnameBuyer,
	o.NameBuyer,
	o.Phone, 	
	replace(replace(replace(replace(replace(replace(o.Phone,'+7','8'),' ',''),'(',''),')',''),'-',''),'+8','') as replacePhone
from 
	OnlineStore.j_tOrders o
where o.PlanDeliveryDate<@dateStart) as a


insert into #userPhoneFinal
select  
	STUFF((
    SELECT distinct ' | ' + p2.Email 
    FROM #userPhone p2
    WHERE (p2.Phone = p1.Phone) 
    FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
	,1,2,'') as Email,

	STUFF((
    SELECT distinct ' | ' + p2.LastnameBuyer+' '+p2.NameBuyer 
    FROM #userPhone p2
    WHERE (p2.Phone = p1.Phone) 
    FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
	,1,2,'') as NameBuyer,
	'' as LastnameBuyer,
	p1.Phone,
	count(*)
from #userPhone p1 
group by p1.Phone



INSERT INTO #userDate
select	
	a.id,
	a.Email,
	a.NameBuyer,
	a.LastnameBuyer,	
	CASE WHEN LEN(a.replacePhone) = 10 THEN a.replacePhone ELSE SUBSTRING(a.replacePhone,2,10) END as endPhone,
	a.DateOrder
from (
select 
	o.id,
	o.Email,
	o.LastnameBuyer,
	o.NameBuyer,
	o.Phone, 	
	replace(replace(replace(replace(replace(replace(o.Phone,'+7','8'),' ',''),'(',''),')',''),'-',''),'+8','') as replacePhone,
	o.DateOrder
from 
	OnlineStore.j_tOrders o
where o.PlanDeliveryDate>=@dateStart AND o.PlanDeliveryDate<=@dateEnd) as a

INSERT INTO #userDateFinal
select 
	STUFF((
    SELECT distinct ' | ' + p2.Email 
    FROM #userDate p2
    WHERE (p2.Phone = p1.Phone) 
    FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
	,1,2,'') as Email,
	STUFF((
    SELECT distinct ' | ' + upper(p2.LastnameBuyer)+' '+upper(p2.NameBuyer)
    FROM #userDate p2
    WHERE (p2.Phone = p1.Phone) 
    FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
	,1,2,'') as NameBuyer,
	'' as LastnameBuyer,
	p1.Phone,
	count(*),
	max(p1.maxDate)
from #userDate p1
group by p1.Phone


select 	
	u.Email,
	u.LastnameBuyer,
	u.NameBuyer,--+isnull(' | '+p.NameBuyer,'') as NameBuyer,
	u.Phone,	
	isnull(u.countOrder,0)+isnull(p.countOrder,0) as mainCount,
	cast(case when p.countOrder is not null then 0 else 1 end as bit) as isNewUser,
	u.maxDate
from 
	#userDateFinal as  u
		left join #userPhoneFinal p on u.Phone = p.Phone


DROP TABLE #userPhone,#userDate,#userPhoneFinal,#userDateFinal

END
