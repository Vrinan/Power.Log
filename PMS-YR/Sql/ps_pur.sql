
Create Table PS_PUR_QuarterlyPurchasingPlan(
	Id uniqueidentifier Primary Key,
	Code varchar(50) NOT NULL,
	Title varchar(100) NULL,
	[Year] int NULL,
	Quarter int NULL,
	TotalPrice float NULL,
	BizAreaId uniqueidentifier NULL,
	Sequ int NULL Default 0,
	Status tinyint NULL Default 0,
	RegHumId uniqueidentifier NULL,
	RegHumName varchar(80) NULL,
	RegDate datetime NULL,
	RegPosiId uniqueidentifier NULL,
	RegDeptId uniqueidentifier NULL,
	EpsProjId uniqueidentifier NULL,
	RecycleHumId uniqueidentifier NULL,
	UpdHumId uniqueidentifier NULL,
	UpdHumName varchar(80) NULL,
	UpdDate datetime NULL,
	ApprHumId uniqueidentifier NULL,
	ApprHumName varchar(80) NULL,
	ApprDate datetime NULL,
	Memo varchar(255) NULL,
	OwnProjId uniqueidentifier NULL,
	OwnProjName varchar(255) NULL
);
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Code';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Title';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Year';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'季度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Quarter';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'总价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'TotalPrice';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'业务域' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'BizAreaId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Sequ';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Status';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'录入人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'RegHumId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'录入人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'RegHumName';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'录入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'RegDate';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'录入人主岗位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'RegPosiId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'录入人主部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'RegDeptId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'项目id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'EpsProjId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'删除人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'RecycleHumId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'UpdHumId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'UpdHumName';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'最后修改日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'UpdDate';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'批准人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'ApprHumId';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'批准人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'ApprHumName';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'批准日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'ApprDate';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlan', @level2type=N'COLUMN',@level2name=N'Memo';




Create Table PS_PUR_QuarterlyPurchasingPlanlist(
	Id uniqueidentifier Primary Key,
	MainId uniqueidentifier NOT NULL,
	OrderType varchar(50) NULL,
	PurWay varchar(50) NULL,
	PlanRequisitionDate datetime NULL,
	ProjName varchar(50) NULL,
	ProjArea varchar(50) NULL,
	PurAddress varchar(50) NULL,
	Remark varchar(50) NULL,
	OrganizeName varchar(50) NULL,
	OrganizeCode varchar(50) NULL,
	Amount int NULL,
	MatUnit varchar(50) NULL,
	MatModel varchar(50) NULL,
	MatName varchar(500) NULL,
	MatType varchar(500) NULL,
	Currency varchar(50) NULL,
	ExchangeRate float NULL,
	UnitPrice float NULL,
	TotalPrice float NULL,
	TechnicalParameters varchar(50) NULL,
	SupplyTime datetime NULL,
	Purpose varchar(50) NULL,
	Texture varchar(50) NULL,
	CapitalSource varchar(50) NULL,
	Nationality varchar(50) NULL,
	Squ int NULL,
	[Update] datetime NULL,
	Mat_Guid uniqueidentifier NULL,
	MatCode varchar(50) NULL
);
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'采购类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'OrderType';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'采购方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'PurWay';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'采购时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'PlanRequisitionDate';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'拟使用项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'ProjName';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'项目所在区域' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'ProjArea';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'采购地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'PurAddress';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Remark';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'OrganizeName';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'OrganizeCode';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Amount';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'MatUnit';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'规格型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'MatModel';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'物资名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'MatName';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'物资类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'MatType';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'货币种类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Currency';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'ExchangeRate';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'UnitPrice';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'总价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'TotalPrice';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'技术参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'TechnicalParameters';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'供货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'SupplyTime';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'用途' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Purpose';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'材质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Texture';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'资金来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'CapitalSource';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'国别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Nationality';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'物资编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'Mat_Guid';
EXEC dbo.sp_addextendedproperty @name=N'MS_Description', @value=N'物资编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PS_PUR_QuarterlyPurchasingPlanlist', @level2type=N'COLUMN',@level2name=N'MatCode';


