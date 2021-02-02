sp_helptext View_KFQ_FilesWorkFlow
CREATE view View_KFQ_FilesWorkFlow
as
select q1.KeyValue,q1.KeyWord ,q1.WorkInfoID,q1.RecordStatus,q1.Title,q1.UserId as RegHumId,q1.UserName as RegHumName,
q1.EpsProjectName ,q1.EpsProjectId,q1.CreateDate,q2.NodeCode,q2.SequeID,q2.BeforeUserName,
case when q1.RecordStatus = 50 then '-' else q2.UserName end as UserName,q2.UserID,q2.ActName,
case when q1.RecordStatus = '40' then '终止'
	 when q1.RecordStatus = '50' then '已处理完成'
	 when q2.ActName = '文秘' or q2.ActName = '开始'  then '文秘未处理'
	 when q2.ActName = '办公室主任' and q1.RecordStatus != '40' then '办公室主任未处理'
	 when q2.ActName = '董事长/党委书记' or q2.ActName = '总经理' or q2.ActName = '分管副总' then '领导未处理'
	 when q2.ActName = '交办' then '部门未处理'
	 when q2.ActName = '传阅' then '传阅'
	 when q2.ActName = '归档' then '归档'
	 else '' end  TypeName,
	 1 as Num,
q2.RecvDate,q2.ReadDate,q2.SendDate,
case when q1.RecordStatus = 50 then '-' else CONVERT(nvarchar(100),DATEDIFF(day,q2.RecvDate,getdate())) end as delayDays ,
q3.Content,
CONVERT(nvarchar(4000),q1.Title+CONVERT(nvarchar(4000),q1.KeyValue) 
+CONVERT(nvarchar(4000),q1.WorkInfoID)
+q2.NodeCode
+CONVERT(nvarchar(4000),q2.SequeID)
+CONVERT(nvarchar(4000),q2.UserId)) as Memo
 from pwf_Infos q1
left join
(select * from pwf_PastNodes al
where al.sequeid = (select max(alr.sequeid) from pwf_PastNodes as alr where alr.WorkInfoID = al.WorkInfoID)) q2
on q1.WorkInfoID = q2.WorkInfoID
left join
pwf_Opinion q3 on q2.SequeID-1 = q3.SequeID and q2.WorkInfoID = q3.WorkInfoID where q1.KeyWord='PS_FileContact'
and q1.WorkFlowID='d3559a38-37a4-b8aa-0dab-62acd132fbd5'
