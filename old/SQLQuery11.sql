
CREATE table #tableStatus (id_tOrders int)
INSERT INTO #tableStatus
select j.id_tOrders from OnlineStore.j_JournalStatus j
inner join (select id_tOrders, max(DateEdit) as DateEdit from OnlineStore.j_JournalStatus group by id_tOrders) as a on a.id_tOrders = j.id_tOrders and a.DateEdit = j.DateEdit
where j.id_Status in (1,2)


select 
	t.id_Tovar, sum(t.Netto)  as netto
from 
	OnlineStore.j_tOrders o
	inner join OnlineStore.j_Orders t on t.id_tOrders =o.id
	inner join #tableStatus j on j.id_tOrders = o.id
where 
	o.PlanDeliveryDate = '2021-02-17'
group by t.id_Tovar

DROP TABLE #tableStatus

