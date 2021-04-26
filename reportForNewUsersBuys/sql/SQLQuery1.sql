DECLARE 
	@dateStart date = '2021-02-21',
	@dateEnd date = '2021-06-01'


	exec [OnlineStore].[getReportNewUserBuy] @dateStart,@dateEnd

CREATE TABLE #userPhone (Email varchar(max),NameBuyer  varchar(max),LastnameBuyer   varchar(max), Phone varchar(10))
CREATE TABLE #userDate (id int,Email varchar(max),NameBuyer  varchar(max),LastnameBuyer   varchar(max), Phone varchar(10))

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


INSERT INTO #userDate
select	
	a.id,
	a.Email,
	a.NameBuyer,
	a.LastnameBuyer,	
	CASE WHEN LEN(a.replacePhone) = 10 THEN a.replacePhone ELSE SUBSTRING(a.replacePhone,2,10) END as endPhone
from (
select 
	o.id,
	o.Email,
	o.LastnameBuyer,
	o.NameBuyer,
	o.Phone, 	
	replace(replace(replace(replace(replace(replace(o.Phone,'+7','8'),' ',''),'(',''),')',''),'-',''),'+8','') as replacePhone
from 
	OnlineStore.j_tOrders o
where o.PlanDeliveryDate>=@dateStart AND o.PlanDeliveryDate<=@dateEnd) as a

select 	
	u.Email,
	u.LastnameBuyer,
	u.NameBuyer,
	u.Phone,	
	u.countRow+count(p.Phone) as mainCount,
	case when count(p.Phone) <> 0 then 0 else 1 end as isNewUser
from 
	(select uu.Email,uu.LastnameBuyer,uu.NameBuyer,uu.Phone, count(uu.id) as countRow from  #userDate uu group by  uu.Email,uu.LastnameBuyer,uu.NameBuyer,uu.Phone) as  u
		left join #userPhone p on p.Email = u.Email or u.Phone = p.Phone or (p.LastnameBuyer= u.LastnameBuyer and p.NameBuyer = u.NameBuyer)
		where u.LastnameBuyer = 'Иванова'
group by u.Email,u.LastnameBuyer,u.NameBuyer,u.Phone,u.countRow





DROP TABLE #userPhone,#userDate

