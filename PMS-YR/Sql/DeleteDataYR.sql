--施工管理
delete   from XLX_IM_ProAnnouncement --项目公告
delete  from XLX_CST_ProjStartManagement--项目开工报告
delete  from PS_CT_ConstructionFile--总体，标段施工组织设计
delete  from XLX_CST_SpecialOperationApp --施工作业申请许可
delete  from XLX_CST_SpecialOperationRec --施工作业票
delete  from XLX_CST_ElectricityForWater --施工用电用水管理
delete  from XLX_CST_MonomerTestRun --单体试车
delete  from PS_COM_ContactNotes--工程联系单
delete  from PS_CC_ProjectVisa--工程单签证       

--综合管理
delete  from XLX_IM_ProAddressBook --项目通讯录
delete  from XLX_IM_ProAnnouncement--项目公告
delete   from XLX_IM_ProWeeklyReport--项目周报月报
delete  from  XLX_IM_Feedback --沟通交流          

--文档管理
delete  from XLX_FM_DocFolder  --项目文档分类   
delete from XLX_IM_ProjectNews --工程大记事 

--HSE管理
delete  from XLX_HSE_PlanManagement--HSE计划质量管理
delete  from PS_HSE_DailyCheck--日常检查
delete  from PS_HSE_DailyCheck_Dtl--日常检查
delete  from PS_HSE_SpecialCheck--专项检查
delete  from PS_HSE_CorrectNotice--整改通知
delete  from PS_HSE_CorrectNoticeReply--整改回复
delete  from XLX_HSE_StopWorkOrder--停工令
delete  from XLX_HSE_ResumeApplication--复工申请
delete  from PS_HSE_RewardPunish --HSE奖惩
delete  from XLX_HSE_SCCManagement --现场文明施工
delete  from XLX_HSE_Meeting --安全会议
delete  from XLX_HSE_ConInformation--承包商资质
delete  from PS_HSE_HumanInspection--人员信息
delete  from PS_HSE_EquipmentInspection--特种设备信息
delete  from PS_HSE_EquipmentInspection_Dtl--特种人员信息
delete  from PS_HSE_TrainingRec --HSE培训
delete  from PS_HSE_TrainingRec_Dtl----HSE培训
delete  from PS_HSE_SpecialOperationApp --申请许可申请
delete  from PS_HSE_SpecialOperationRec --安全作业票
delete  from XLX_HSE_SafetyAssurance--安全保证金缴纳
delete  from XLX_HSE_SafetyAssurance--安全保证金退还
delete  from XLX_HSE_SafetyAssurance --工伤意外保险记录
delete  from XLX_HSE_SafetyAssurance --安全文明措施费
delete  from XLX_HSE_ConstructionPlan --施工方案
delete  from  XLX_HSE_PersonnelAdmission --HSE人员进场
delete  from  XLX_HSE_PersonnelAdmission --HSE人员退场
delete  from XLX_HSE_EQURetreat --设备进场退场
delete  from XLX_HSE_EQURetreat --设备进场退场   
delete from XLX_HSE_RospDocuments  

--质量管理
delete  from PS_QM_QBS -- 质量计划
delete  from PS_QM_QI--质量计划
delete  from  PS_QM_QL --质量计划
delete  from  PS_QM_QL_ModelLink --质量计划
delete  from PS_QM_QARecord --质量签证记录
delete  from PS_QM_UnqualifiedNotice --不合格通知
delete  from  PS_QM_RectificationRecord --整改记录   

--进度
delete  from PS_MDM_WbsTemplate--wbs模板
delete from PS_MDM_WbsTemplate_Dtl
delete from PS_MDM_MeasureModelDefine  
delete from PS_PLN_ProjPeriod --检测周期定义
delete from  PLN_RSRC --全局资源定义
delete from PS_PLN_TaskCategoryCode --定义作业分类码
delete from Pln_project_plan --PBS定义
delete from Pln_ProjWbs --WBS维护
delete from pln_task --作业表
delete from  PLN_TASKPRED --逻辑关系表
delete from pln_taskproc --步骤表
delete from Pln_taskrsrc--资源表
delete from PS_PlN_TaskCategoryCode--分类码表
delete from ps_pln_taskbcws--计划分解表
delete from PLN_PROJWBS_PARENT_TASK--主子计划关系表
delete from PS_PLN_PlanApprove --WBS维护
delete from PS_PLN_TaskAssign --计划发包
delete from PS_Pln_SubPlanTemp--计划发包
delete from PS_PLN_FeedBackRecord --周期反馈
delete from PS_PLN_FeedBackRecord_task--周期反馈
delete from PS_PLN_IssueTrack --项目问题
delete from PLN_PLAN_TOTAL_CATELOG--作业模板

--流程
delete from pwf_InBox --流程记录表
delete from pwf_infos --流程总表
delete from pwf_infoSubs --流程子表
delete from pwf_Opinion -- 历史意见
delete from pwf_PastNodes --历史流程记录表
delete from pwf_PastNodes --历史流程人员     

delete from PB_Messages --我发起的

delete from  PB_MessagesHis --我发起的明细


--预算管理
delete from XLX_PRE_CapitalExpenditureBudgetMonth
delete from XLX_PRE_CapitalExpenditureBudgetMonth_ListE
delete from XLX_PRE_CapitalExpenditureBudgetMonth_ListM
delete from XLX_PRE_CapitalExpenditureBudgetMonth_ListT
delete from XLX_PRE_CapitalExpenditureBudgetE
delete from XLX_PRE_CapitalExpenditureBudgetM
delete from XLX_PRE_CapitalExpenditureBudgetT
delete from XLX_INT_BudgetCategoryNEW
delete from XLX_INT_BudgetCategoryYeah

delete from XLX_PRE_CapitalExpenditureBudgetYeah
delete from  XLX_PRE_CapitalExpenditureBudgetT
delete from XLX_PRE_CapitalExpenditureBudgetM
delete from XLX_PRE_CapitalExpenditureBudgetE

--采购管理
delete from XLX_PUR_Order
delete from XLX_PUR_Order_List
delete from XLX_PUR_Request
delete from XLX_PUR_Request_List
delete from XLX_PUR_NonComformProduct
delete from XLX_PUR_NonComformProduct_List
delete from XLX_PUR_Request_SendRecord
delete from PS_PUR_MatStoreBalance
delete from XLX_PUR_Supplie
delete from XLX_PUR_Supplie_Linkman
delete from XLX_PUR_Inquiry
delete from XLX_PUR_InquirySupplie
delete from XLX_PUR_InquirySupplie_List
delete from XLX_PUR_Inquiry_SupplieList
delete from XLX_PUR_Inquiry_MatList

delete from XLX_MDM_Mat_Texture --材质密度关系表
delete from XLX_MDM_Mat_Equ --换算公式
--delete from XLX_MDM_MatBS --物资
--delete from XLX_MDM_Mat --物资
delete from PS_BID_Inquiry --工程物资招标状态跟踪
delete from XLX_BID_Plan --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Plan_SupplieList --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Doc --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Invitation --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Invitation_SupplieList --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Open --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Open_List --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Confirm --项目部自主招标招标状态跟踪和总览
delete from XLX_BID_Notice --项目部自主招标招标状态跟踪和总览

--BOM
delete from PS_MDM_Storage
--delete from XLX_MDM_Mat
delete from XLX_PUR_BOM
delete from XLX_PUR_BOM_List
delete from PS_PUR_ArrivalCheck
delete from PS_PUR_MatRequisitions
delete from PS_PUR_MatRequisitions_Dtl
delete from PS_PUR_MatTransfer
delete from PS_PUR_MatTransfer_Dtl
delete from PS_PUR_MatInventory
delete from PS_PUR_MatInventory_Dtl
delete from PS_PUR_MatOutStore --出库单
delete from PS_PUR_MatOutStore_Dtl --出库单
delete from XLX_PUR_MatTransfer --物资调拨
delete from PS_PUR_MatReturn --退库
delete from PS_PUR_MatReturn_Dtl --退库
delete from PS_PUR_MatDisposal --物资处理
delete from PS_PUR_MatDisposal --物资处理
delete from XLX_PUR_MatReturn --退库


delete from PS_HSE_SaveActivity --安全活动

--合同管理View_XLX_CM_SubContract_CostAllocation
delete from PS_CM_SubContract 
delete from PS_CC_CostAllocation
delete from PS_CM_SubContractPayment --合同支付

delete  from PS_CM_SubContractApplyMny --合同付款申请

delete  from PS_CM_SubContract --合同审批

delete  from PS_CM_SubContractSettle --合同结算

delete  from PS_CM_SubContractInvoice --合同发票
delete from PS_CM_SubContractInvoice_Dtl

delete from PS_CM_BOQConfirm --工程量申报
delete from PS_CM_BOQConfirm_Dtl  --工程量申报
delete from PS_CM_SubContractClaim --合同索赔
delete from PS_CM_SubContractClaim_Dtl --合同索赔
delete from PS_CM_ContractCharged --合同扣款
delete from PS_BID_BidWinNotice --中标通知书
delete from PS_BID_PerformanceBondRec --退缴保证金
delete from PS_CM_SubContractChange --采购合同变更
delete from PS_CM_SubContractChange_Dtl --采购合同变更


--设计管理(附件上传文档管理关联pb_defaultfiled
delete from XLX_DM_SeminarDesignClarification
delete from XLX_DM_DesignDisclosurePlan
delete from XLX_DM_DesignSendRegistration
delete from XLX_DM_DesignConstructionPlanReview
delete from XLX_DM_DesignConstructionPlanReviewCompany
delete from XLX_DM_DesignConstructionPlanReviewDetailed
delete from XLX_DM_DesignConstructionPlanReviewDetailedLT
delete from XLX_DM_DesignManagement
delete from XLX_DM_DesignReview
delete from XLX_DM_DesignReviewList
delete from XLX_DM_DesignReceiveRegistration
delete from XLX_DM_DesignDisclosureOutline
delete from XLX_DM_DesignChange
delete from XLX_DM_DesignChangeList
delete from XLX_DM_DesignPlan


delete from PB_Human
delete from PB_Department where id <>'00000000-0000-0000-0000-0000000000A2'
delete from PB_Position where id <>'00000000-0000-0000-0000-0000000000A2'
delete from PB_Right 
delete from PB_RightGroup where id <>'AD000000-0000-0000-0000-000000000000'
delete from PB_RightGroupPosiMap
delete from PB_User where  id <>'AD000000-0000-0000-0000-000000000000'
delete from USER_list
delete from PB_HumanRelation
delete from PB_HumanSign
delete from PB_HumanOwnProjMap
delete from PB_Organize

--工程量清单
delete from PS_CC_PI_Class
delete from PS_CC_PI
delete from PS_CC_PI_PriceAnalysis
delete from PS_CC_PIWBS
delete from PS_CC_PICBS
delete from XLX_INT_PI
delete from PS_CC_QuoteImport --投标报价导入
delete from  PS_CC_QuoteImport_Dtl --投标报价导入

delete from XLX_HSE_CorrectNotice --整改通知

delete from PLN_ACTVCODE --作业分类码定义
delete from  PLN_ACTVTYPE --作业分类码定义
--费用工作表定义
--delete from PS_CC_CbsSheetConfig
delete from PS_CC_ContractBudget --项目预算表
delete from PS_CC_ContractBudget_CBS --项目预算表
delete from PS_CC_ContractBudget_WBS --项目预算表
delete from PS_CC_CapitalPlan --支付计划
delete from PS_CC_CapitalPlan_Dtl
--前期评审
delete from XLX_PM_PreProjectEvaluation
--费用科目定义
delete from PS_CC_CBS_Class
delete from PS_CC_CBS
delete from PS_CC_CBSWBS
delete from XLX_PRE_CapitalExpenditureBudgetYeah
delete from XLX_PRE_CapitalExpenditureBudgetT
delete from XLX_PRE_CapitalExpenditureBudgetM
delete from XLX_PRE_CapitalExpenditureBudgetE

--前期管理
delete from XLX_PM_FeasibilityStudy
delete from PS_MK_ProjectHandover
delete from PS_CH_ProjManagerAppointment
delete from PS_MK_ProjTeamEstablish
delete from PS_MK_ProjTeamEstablish_Posi
delete from PS_MK_ProjTeamEstablish_Human
delete from PS_CH_PlanningTask
delete from PS_CH_PlanningTask_Dtl
delete from PS_CH_ManagementPlan
delete from PLN_project_plan
delete from pln_project_plan_type
delete from PS_PLN_PlanLimit
delete from PS_MK_CommencementReport
--采购订单
delete from PS_PUR_PurchaseOrder
delete from PS_PUR_PurchaseOrder_MatList
delete from PS_PUR_PurchaseOrderTrack
--招标计划
delete from PS_BID_TenderPlan
delete from PS_BID_TenderPlan_Dtl
delete from PS_BID_BidOpen
--到货检查、明细
delete from PS_PUR_MatInStore
delete from PS_PUR_MatInStore_Dtl 

--评标记录
delete from PS_BID_BidReview