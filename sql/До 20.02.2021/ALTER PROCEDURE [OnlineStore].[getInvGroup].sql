USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[getInvGroup]    Script Date: 27.10.2020 15:27:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-06-01
-- Description:	Получение инвентаризационных групп по отделу
-- =============================================
ALTER PROCEDURE [OnlineStore].[getInvGroup]	
	@id_Dep int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @dateUpdate datetime,@dateRealiz date;

	select @dateUpdate = DateUpdate, @dateRealiz = DateRealiz from OnlineStore.UpdateTime where id in(
	select TOP(1) id from OnlineStore.UpdateTime where id_Department =@id_Dep order by DateUpdate desc)

	select 
			grp2.id,
			cname,
			Convert(bit,'1',0) as selected,
			case when exists (select * from OnlineStore.grp2_vs_Category g where g.id_grp2 = grp2.id) then Convert(bit,'1',0) 
			else Convert(bit,'0',0) end as isAdded,
			isnull(@dateUpdate,'') as dateUpdate,
			isnull(@dateRealiz,'') as dateRealiz,
			--isnull(max(updt.DateUpdate),'') as dateUpdate,
			--isnull(max(updt.DateRealiz),'') as dateRealiz,
			isnull(gvc.id_Category,0) as idCat,
			Convert(bit,'0',0) as selectedAtt,
			grp2.id_unit
	from dbo.s_grp2 grp2
	--left join OnlineStore.UpdateTime updt on updt.id_Department = grp2.id_otdel
	-- 1 группа - 1 категория, потому можем лефтджоин
	left join OnlineStore.grp2_vs_Category gvc on grp2.id = gvc.id_grp2
	where id_otdel = @id_Dep and grp2.ldeystv = 1
	group by grp2.id, cname, gvc.id_Category, id_unit
	order by cname
	
END