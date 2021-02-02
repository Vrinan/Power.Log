


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;




namespace PowerOn.EPC.SFFK
{
    /// <summary>
    /// 收入确认表 消息申明
    /// </summary>
    public partial class SF_FK_RevenueRecognitionBO
    {
        #region 用户自定义代码，相应外部消息域


        #endregion
    }

    /// <summary>
    /// 收入确认表
    /// </summary>
    public partial class SF_FK_RevenueRecognitionBO<TBusiness, TSF_FK_RevenueRecognition_dtlBO>
    {
        #region 响应内部事件
        protected override string SaveRecord(System.ComponentModel.DataObjectMethodType methodType)
        {
            //此处可撰写保存前代码
            if (methodType == System.ComponentModel.DataObjectMethodType.Insert)
            {
                AddDetil(this.Id, this.YearMonth, this.EpsProjectId);
            }
            var result = base.SaveRecord(methodType);

            //此处可撰写保存后代码   

            return result;

        }


        #endregion

        #region 用户自定义代码
        public void AddDetil(Guid MainId, DateTime YearMonth, Guid EpsProjectId)
        {
            Power.Business.IBusinessList bbsM = Power.Business.BusinessFactory.CreateBusinessOperate("SF_FK_RevenueRecognition").FindAll("EpsProjectId='" + EpsProjectId + "' and IsNew ='1'", "YearMonth desc,UpdDate desc", "", 0, 0);
            if (bbsM.Count != 0)
            {
                Power.Business.IBusinessList bbsMList = Power.Business.BusinessFactory.CreateBusinessOperate("SF_FK_RevenueRecognition_dtl").FindAll("MasterId='" + bbsM[0]["Id"] + "'", "", "", 0, 0);
                foreach (Power.Business.IBaseBusiness item in bbsMList)
                {
                    Power.Business.IBaseBusiness Newbbs = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition_dtl");
                    Newbbs.Init();
                    Newbbs.SetItem("MasterId", MainId);
                    Newbbs.SetItem("YearMonth", item["YearMonth"]);
                    Newbbs.SetItem("AmountType", item["AmountType"]);
                    Newbbs.SetItem("ContractMoney", item["ContractMoney"]);
                    Newbbs.SetItem("ContractChangeMoney", item["ContractChangeMoney"]);
                    Newbbs.SetItem("FinalContractMoney", item["FinalContractMoney"]);
                    Newbbs.SetItem("ContractGetAmount", item["ContractGetAmount"]);
                    Newbbs.SetItem("BudgetCost", item["BudgetCost"]);
                    Newbbs.SetItem("BudgetRate", item["BudgetRate"]);
                    Newbbs.SetItem("WorkCost", item["WorkCost"]);
                    Newbbs.SetItem("ProduceCost", item["ProduceCost"]);
                    Newbbs.SetItem("Rate", item["Rate"]);
                    Newbbs.SetItem("MonthSchedule", item["MonthSchedule"]);
                    Newbbs.SetItem("MonthGetAmount", item["MonthGetAmount"]);
                    Newbbs.SetItem("MonthRate", item["MonthRate"]);
                    Newbbs.SetItem("Memo", item["Memo"]);
                    Newbbs.Save(System.ComponentModel.DataObjectMethodType.Insert);
                }
            }
            else
            {
                #region 新增四个空明细
                Power.Business.IBaseBusiness Newbbs = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition_dtl");
                Newbbs.Init();
                Newbbs.SetItem("MasterId", MainId);
                Newbbs.SetItem("YearMonth", YearMonth);
                Newbbs.SetItem("AmountType", "01");
                Newbbs.SetItem("ContractMoney", 0);
                string point1 = "1.1";
                Newbbs.SetItem("ContractGetAmount", 0);
                Newbbs.SetItem("ContractChangeMoney", 0);
                Newbbs.SetItem("FinalContractMoney", 0);
                Newbbs.Save(System.ComponentModel.DataObjectMethodType.Insert);

                Power.Business.IBaseBusiness Newbbs1 = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition_dtl");
                Newbbs1.Init();
                Newbbs1.SetItem("MasterId", MainId);
                Newbbs1.SetItem("YearMonth", YearMonth);
                Newbbs1.SetItem("AmountType", "02");
                Newbbs1.SetItem("ContractMoney", 0);
                string point2 = "1.06";
                Newbbs1.SetItem("ContractGetAmount", 0);
                Newbbs1.SetItem("ContractChangeMoney", 0);
                Newbbs1.SetItem("FinalContractMoney", 0);
                Newbbs1.Save(System.ComponentModel.DataObjectMethodType.Insert);

                Power.Business.IBaseBusiness Newbbs2 = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition_dtl");
                Newbbs2.Init();
                Newbbs2.SetItem("MasterId", MainId);
                Newbbs2.SetItem("YearMonth", YearMonth);
                Newbbs2.SetItem("AmountType", "03");
                Newbbs2.SetItem("ContractMoney", 0);
                string point3 = "1.16";
                Newbbs2.SetItem("ContractGetAmount", 0);
                Newbbs2.SetItem("ContractChangeMoney", 0);
                Newbbs2.SetItem("FinalContractMoney", 0);
                Newbbs2.Save(System.ComponentModel.DataObjectMethodType.Insert);

                Power.Business.IBaseBusiness Newbbs3 = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition_dtl");
                Newbbs3.Init();
                Newbbs3.SetItem("MasterId", MainId);
                Newbbs3.SetItem("YearMonth", YearMonth);
                Newbbs3.SetItem("AmountType", "04");
                Newbbs3.SetItem("ContractMoney", 0);
                Newbbs3.SetItem("ContractGetAmount", 0);
                Newbbs3.SetItem("ContractChangeMoney", 0);
                Newbbs3.SetItem("FinalContractMoney", 0);
                Newbbs3.Save(System.ComponentModel.DataObjectMethodType.Insert);
                #endregion
            }
        }

        public String IsRepeat(string yyMM, string EpsProjectId)
        {
            yyMM += "-01 00:00:00.000";
            Power.Business.IBusinessList bbs = Power.Business.BusinessFactory.CreateBusinessOperate("SF_FK_RevenueRecognition").FindAll("YearMonth='" + yyMM + "' and EpsProjectId='" + EpsProjectId + "' and IsNew ='1'", "", "", 0, 0);
            if (bbs.Count > 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string Up(string id)
        {
            Power.Business.IBaseBusiness oldbbs = Power.Business.BusinessFactory.CreateBusinessOperate("SF_FK_RevenueRecognition").FindByKey(id);
            //版本号+1
            string ver = Convert.ToString(oldbbs["Version"]);
            int nver = Convert.ToInt32(ver.Replace(".0", "")) + 1;
            string newVer = Convert.ToString(nver) + ".0";
            //取消 最新版
            oldbbs.SetItem("IsNew", 0);
            oldbbs.UpdateSelf();
            //新建主表
            Guid MainId = Guid.NewGuid();
            Power.Business.IBaseBusiness newbbs = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition");
            newbbs.Init();
            newbbs.SetItem("Id", MainId);
            newbbs.SetItem("Code", oldbbs["Code"]);
            newbbs.SetItem("Titile", oldbbs["Titile"]);
            newbbs.SetItem("EpsProjectId", oldbbs["EpsProjectId"]);
            newbbs.SetItem("EpsProjectName", oldbbs["EpsProjectName"]);
            newbbs.SetItem("YearMonth", oldbbs["YearMonth"]);
            newbbs.SetItem("Version", newVer);
            newbbs.SetItem("IsNew", 1);
            newbbs.SetItem("Memo", oldbbs["Memo"]);
            newbbs.Save(System.ComponentModel.DataObjectMethodType.Insert);


            //删除保存事件四条明细
            Power.Business.IBusinessList bbs_dtlnew1 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_FK_RevenueRecognition_dtl").FindAll("MasterId='" + MainId + "'", "", "", 0, 0);
            bbs_dtlnew1.Delete();
            //找到所有明细
            Power.Business.IBusinessList oldbbs_dtl = Power.Business.BusinessFactory.CreateBusinessOperate("SF_FK_RevenueRecognition_dtl").FindAll("MasterId='" + oldbbs["Id"] + "'", "", "", 0, 0);
            foreach (Power.Business.IBaseBusiness item in oldbbs_dtl)
            {
                Guid DtlId = Guid.NewGuid();
                Power.Business.IBaseBusiness newbbs_dtl = Power.Business.BusinessFactory.CreateBusiness("SF_FK_RevenueRecognition_dtl");
                newbbs_dtl.Init();
                newbbs_dtl.SetItem("Id", DtlId);
                newbbs_dtl.SetItem("MasterId", MainId);
                newbbs_dtl.SetItem("YearMonth", item["YearMonth"]);
                newbbs_dtl.SetItem("AmountType", item["AmountType"]);
                newbbs_dtl.SetItem("ContractMoney", item["ContractMoney"]);
                newbbs_dtl.SetItem("ContractChangeMoney", item["ContractChangeMoney"]);
                newbbs_dtl.SetItem("FinalContractMoney", item["FinalContractMoney"]);
                newbbs_dtl.SetItem("ContractGetAmount", item["ContractGetAmount"]);
                newbbs_dtl.SetItem("BudgetCost", item["BudgetCost"]);
                newbbs_dtl.SetItem("BudgetRate", item["BudgetRate"]);
                newbbs_dtl.SetItem("WorkCost", item["WorkCost"]);
                newbbs_dtl.SetItem("ProduceCost", item["ProduceCost"]);
                newbbs_dtl.SetItem("Rate", item["Rate"]);
                newbbs_dtl.SetItem("MonthSchedule", item["MonthSchedule"]);
                newbbs_dtl.SetItem("MonthGetAmount", item["MonthGetAmount"]);
                newbbs_dtl.SetItem("MonthRate", item["MonthRate"]);
                newbbs_dtl.SetItem("Memo", item["Memo"]);
                newbbs_dtl.Save(System.ComponentModel.DataObjectMethodType.Insert);
            }
            return Convert.ToString(MainId);
        }


        #endregion

    }

}