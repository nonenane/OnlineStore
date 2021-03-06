USE [dbase1]
GO
/****** Object:  StoredProcedure [OnlineStore].[setGoodsByGroups]    Script Date: 23.04.2021 16:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		KAV
-- Create date: 2020-06-01
-- Description:	Добавление товара по группам
-- update:		kav 2020-12-16 поле ShortDescription
-- update:		kav 2021-03-01 для неактивных товаров идет update isActive => 1
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
	select  distinct
		st.id as id_Tovar,
		ltrim(rtrim(nt.cname)) as ShortName,
		dbo.f_SprGetFullNameTovar (st.id) as FullName,
		gvs.id_Category as id_Category,
		--cast(round(rc.rcena *(perc.MarkUpPercent+100) / 100,2,1) as decimal(17,2)) as BasicPrice		
		cast(round(rc.rcena *([OnlineStore].[fGetPercentsTovar](st.id,0)+100) / 100,2,1) as decimal(17,2)) as BasicPrice
		,ltrim(rtrim(st.ean)) as ean,
		trim(nt.cname) as ShortDescription
	into #tmpTovar
	from dbo.s_tovar st
		inner join dbo.s_ntovar nt on st.id = nt.id_tovar and nt.tdate_n = (select max (tdate_n) from dbo.s_ntovar where id_tovar = st.id)
	    inner join dbo.s_rcena rc on st.id = rc.id_tovar and rc.tdate_n = (select max(tdate_n) from dbo.s_rcena where id_tovar = st.id)
		inner join dbo.j_realiz jreal on st.id = jreal.id_tovar and jreal.drealiz = (select max(drealiz) from dbo.j_realiz where id_tovar = st.id)
		--left join OnlineStore.s_SettingsPercent perc on perc.id_Department = st.id_otdel
		inner join OnlineStore.grp2_vs_Category gvs on gvs.id_grp2 = st.id_grp2
	
	where st.id_grp2 in (select value from @t)
	--and st.id not in (select id_Tovar from OnlineStore.s_Goods)
	and st.id_otdel = @id_department
	and jreal.drealiz >= Convert(date,@drealiz)

	-- добавляем в s_goods/обновляем

	;with updateTovar(id_tovar, FullName, BasicPrice, ShortName, ShortDescription)
	as (select g.id_Tovar, t.FullName, t.BasicPrice, t.ShortName, t.ShortDescription from OnlineStore.s_Goods g
		inner join #tmpTovar t on g.id_Tovar = t.id_Tovar and g.isActive = 0)
	update OnlineStore.s_Goods
	set 
		isActive = 1,
		DateEdit = getdate(),
		id_Editor = @id_person,
		FullName = ut.FullName,
		BasicPrice = ut.BasicPrice,
		ShortName = ut.ShortName,
		ShortDescription = ut.ShortDescription
	from updateTovar ut
	where ut.id_tovar = id_Tovar

	insert into OnlineStore.s_Goods (id_Tovar,ShortName,FullName,id_Category,BasicPrice,isInsert,isActive,id_Creator,DateCreate,id_Editor,DateEdit, ShortDescription)
    (select id_Tovar, ShortName,FullName, id_Category, BasicPrice, Convert(bit,0,0), CONVERT(bit,1,0),@id_person, GETDATE(), @id_person, getdate(), ShortDescription 
	from #tmpTovar t
	where t.id_Tovar not in (select id_Tovar from OnlineStore.s_Goods))
	

	-- добавляем в s_atributeGoods
	insert into OnlineStore.s_AttributeGoods (id_Goods,MinOrder,MaxOrder,Step,DefaultNetto,PriceSuffix,QuantitySuffix,id_Creator,DateCreate,id_Editor,DateEdit)
	(select sg.id, @minOrder,@maxOrder,@step,@defaultNetto,@priceSuffix,@quantitySuffix,@id_person,getdate(),@id_person,getdate() 
		from OnlineStore.s_Goods sg
		left join OnlineStore.s_AttributeGoods ag on sg.id = ag.id_Goods
		--добавляем только тем, которых нету еще (ag.id is null)
		where ag.id is null and  sg.id_Tovar in (select id_Tovar from #tmpTovar where LEN(ean) = 4))

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

	
	UPDATE cat
	set cat.id_Category = t.id_Category
	from 
		#tmpTovar t 
			inner join OnlineStore.s_Goods g on g.id_Tovar = t.id_Tovar
			left join  OnlineStore.s_Goods_vs_Category cat on cat.id_Goods = g.id
	where cat.id is not null

	insert into OnlineStore.s_Goods_vs_Category (id_Goods,id_Category,id_Editor,DateEdit)
	select 
		g.id,t.id_Category,@id_person,GETDATE() 
	from 
		#tmpTovar t 
			inner join OnlineStore.s_Goods g on g.id_Tovar = t.id_Tovar
			left join OnlineStore.s_Goods_vs_Category cat on cat.id_Goods = g.id
	where cat.id is null

	select t1.id_tovar, trim(t1.ean) as ean, t1.cname from #tmpTovar t left join dbo.v_tovar t1 on t.id_Tovar = t1.id_tovar
drop table #tmpTovar
	
END
