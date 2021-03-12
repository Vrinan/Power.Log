select * from XLX_QM_InspectionNotice_Dtl

create table XLX_PUR_InquiryOnlineDoc(
Id uniqueidentifier null,
MasterId uniqueidentifier null,
SupplyId uniqueidentifier null,
SupplyName nvarchar(max) null,
DocName nvarchar(max) null,
RegDate datetime null,
UpdDate datetime null,
Remark nvarchar(max) null
)

alter table XLX_PUR_InquiryOnlineDoc add Sequ nvarchar(max) null