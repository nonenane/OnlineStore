USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[setGoodsByGroups]    Script Date: 06.10.2020 12:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-06-01
-- Description:	Добавление товара по группам
-- =============================================
ALTER PROCEDURE [OnlineStore].[setGoodsByGroups]	
	@id_groups varchar(max),
	@drealiz datetime,
	@id_person int,
	@minOrder numeric(16,3),
	@maxOrder numeric(16,3),
	@step numeric(16,3),
	@defaultNetto numeric(16,3),
	@priceSuffix varchar(50),
	@quantitySuffix varchar(50),
	@id_department int
AS
BEGIN
	SET NOCOUNT ON;
	--парсим айдишники
	select @id_groups='select ''' + replace(@id_groups,',',''' as value union all select ''') + ''''
	declare @t table (id int identity, value int)
		insert into @t 
		exec (@id_groups)
	-- выбираем товары которые нннадо нам по всем условиям
	select  
		st.id as id_Tovar,
		ltrim(rtrim(nt.cname)) as ShortName,
		dbo.f_SprGetFullNameTovar (st.id) as FullName,
		gvs.id_Category as id_Category,
		--cast(round(rc.rcena *(perc.MarkUpPercent+100) / 100,2,1) as decimal(17,2)) as BasicPrice		
		cast(round(rc.rcena *([OnlineStore].[fGetPercentsTovar](st.id,0)+100) / 100,2,1) as decimal(17,2)) as BasicPrice
		,ltrim(rtrim(st.ean)) as ean
	into #tmpTovar
	from dbo.s_tovar st
		left join dbo.s_ntovar nt on st.id = nt.id_tovar and nt.tdate_n = (select max (tdate_n) from dbo.s_ntovar where id_tovar = st.id)
	    inner join dbo.s_rcena rc on st.id = rc.id_tovar and rc.tdate_n = (select max(tdate_n) from dbo.s_rcena where id_tovar = st.id)
		left join dbo.j_realiz jreal on st.id = jreal.id_tovar and jreal.drealiz = (select max(drealiz) from dbo.j_realiz where id_tovar = st.id)
		left join OnlineStore.s_SettingsPercent perc on perc.id_Department = st.id_otdel
		inner join OnlineStore.grp2_vs_Category gvs on gvs.id_grp2 = st.id_grp2
	
	where st.id_grp2 in (select value from @t)
	and st.id not in (select id_Tovar from OnlineStore.s_Goods)
	and st.id_otdel = @id_department
	and jreal.drealiz >= Convert(date,@drealiz)

	-- добавляем в s_goods
	insert into OnlineStore.s_Goods (id_Tovar,ShortName,FullName,id_Category,BasicPrice,isInsert,isActive,id_Creator,DateCreate,id_Editor,DateEdit)
    (select id_Tovar, ShortName,FullName, id_Category, BasicPrice, Convert(bit,0,0), CONVERT(bit,1,0),@id_person, GETDATE(), @id_person, getdate() from #tmpTovar)
	

	-- добавляем в s_atributeGoods
	insert into OnlineStore.s_AttributeGoods (id_Goods,MinOrder,MaxOrder,Step,DefaultNetto,PriceSuffix,QuantitySuffix,id_Creator,DateCreate,id_Editor,DateEdit)
	(select id, @minOrder,@maxOrder,@step,@defaultNetto,@priceSuffix,@quantitySuffix,@id_person,getdate(),@id_person,getdate() from OnlineStore.s_Goods sg where sg.id_Tovar in (select id_Tovar from #tmpTovar where LEN(ean) = 4))

	-- добавляем запись в update
	if exists (select top(1) * from OnlineStore.UpdateTime where id_Department = @id_department)
		BEGIN
			UPDATE  OnlineStore.UpdateTime
			SET DateUpdate = getdate(), 
			DateRealiz = CONVERT(date, @drealiz),
			id_Creator = @id_person
		where 
			id_Department = @id_department
		END
	ELSE
		BEGIN
			insert into OnlineStore.UpdateTime (DateUpdate, DateRealiz, id_Department, id_Creator)
			values (getdate(),CONVERT(date, @drealiz), @id_department, @id_person)
		END


drop table #tmpTovar
	
END