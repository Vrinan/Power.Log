


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;




namespace PowerOn.EPC.StdPurchase
{
    /// <summary>
    /// 请购单 消息申明
    /// </summary>
    public partial class PS_PurchaseRequisitionBO
    {
        #region 用户自定义代码，相应外部消息域


        #endregion
    }

    /// <summary>
    /// 请购单
    /// </summary>
    public partial class PS_PurchaseRequisitionBO<TBusiness, TPS_PurchaseRequisition_DtlBO>
    {
        #region 响应内部事件
        protected override string SaveRecord(System.ComponentModel.DataObjectMethodType methodType)
        {
            //此处可撰写保存前代码
            if (methodType == System.ComponentModel.DataObjectMethodType.Update)
            {
                if (this.NeedPersistenceList.Contains("Status"))
                {
                    PS_PurchaseRequisitionBO ent = PS_PurchaseRequisitionBO.FindByKey(this.Id);
                    if (ent != null)
                    {
                        this.OnStatusChange(ent.Status, this.Status);
                    }
                }
            }
            var result = base.SaveRecord(methodType);
            //此处可撰写保存后代码   
            return result;
        }


        #endregion

        #region 用户自定义代码
        public void OnStatusChange(int oldStatus, int newStatus)
        {
            double flag = 0;
            //生效或批准
            if ((oldStatus == 0 && newStatus == (int)Power.IWorkFlow.WorkFlow.ERecordStatus.IsSign)
                 || (oldStatus != newStatus && newStatus == (int)Power.IWorkFlow.WorkFlow.ERecordStatus.Finish))
                flag = 1;
            //取消生效或批准
            if ((oldStatus == (int)Power.IWorkFlow.WorkFlow.ERecordStatus.IsSign && newStatus == 0)
                || ((oldStatus != newStatus && oldStatus == (int)Power.IWorkFlow.WorkFlow.ERecordStatus.Finish)))
                flag = -1;
            if (flag == 1)
            {
                #region 动力站
                if (this.RequestSource == "1")
                {
                    //固定字段
                    String a = "YXZ-";
                    //年份，后两位
                    int dt = DateTime.Now.Year;
                    string year = Convert.ToString(dt);
                    year = year.Substring(2, 2) + "-";
                    //拼接前两块
                    string RequestCode = a + year;
                    //返还当前格式的最大流水号+1
                    string serialNumber = ReturnMaxAdd(RequestCode);
                    if (serialNumber != "0")
                    {
                        //全部拼接起来
                        RequestCode += serialNumber;
                        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("PS_PurchaseRequisition").FindByKey(this.Id);
                        bbs.SetItem("Code", RequestCode);
                        bbs.UpdateSelf();
                    }
                    else
                    {
                        RequestCode += "0001";
                        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("PS_PurchaseRequisition").FindByKey(this.Id);
                        bbs.SetItem("Code", RequestCode);
                        bbs.UpdateSelf();
                    }
                }
                #endregion

                #region 膜系统
                if (this.RequestSource == "2")
                {
                    //固定字段
                    String a = "MXT-";
                    //年份，后两位
                    int dt = DateTime.Now.Year;
                    string year = Convert.ToString(dt) + "-";
                    //拼接前两块
                    string RequestCode = a + year;
                    //返还当前格式的最大流水号+1
                    string serialNumber = ReturnMaxAdd(RequestCode);
                    if (serialNumber != "0")
                    {
                        //全部拼接起来
                        RequestCode += serialNumber;
                        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("PS_PurchaseRequisition").FindByKey(this.Id);
                        bbs.SetItem("Code", RequestCode);
                        bbs.UpdateSelf();
                    }
                    else
                    {
                        RequestCode += "0001";
                        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("PS_PurchaseRequisition").FindByKey(this.Id);
                        bbs.SetItem("Code", RequestCode);
                        bbs.UpdateSelf();
                    }
                }

                #endregion

                #region 项目部
                if (this.RequestSource == "3")
                {
                    //固定字段
                    String a = "XMB-";
                    string projName = this.OwnProjName;
                    string RequestCode = a + projName + "-";
                    string serialNumber = ReturnMaxAdd(RequestCode);
                    if (serialNumber != "0")
                    {
                        //全部拼接起来
                        RequestCode += serialNumber;
                        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("PS_PurchaseRequisition").FindByKey(this.Id);
                        bbs.SetItem("Code", RequestCode);
                        bbs.UpdateSelf();
                    }
                    else
                    {
                        RequestCode += "0001";
                        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("PS_PurchaseRequisition").FindByKey(this.Id);
                        bbs.SetItem("Code", RequestCode);
                        bbs.UpdateSelf();
                    }
                }
                #endregion
            }
        }

        public string ReturnMaxAdd(string RequestCode)
        {
            string serialNumber = "";
            string maxCode = "";
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("select MAX(Code) as maxCode from PS_PUR_PurchaseRequisition where Code like '%" + RequestCode + "%' ");
            DataTable dtTemp = XCode.DataAccessLayer.DAL.QuerySQL(sbSQL.ToString());
            if (dtTemp != null || dtTemp.Rows.Count != 0)
            {
                maxCode = Convert.ToString(dtTemp.Rows[0].ItemArray[0]);
                //去掉固定值，转换为int
                int num = Convert.ToInt32(maxCode.Replace(RequestCode, ""));
                //流水号+1
                num += 1;
                //判断流水号有几位
                int numLength = 0;
                numLength = Convert.ToString(num).Length;
                string serialNumber1 = "";
                switch (numLength)
                {
                    case 1:
                        serialNumber1 = "000" + num;
                        break;
                    case 2:
                        serialNumber1 = "00" + num;
                        break;
                    case 3:
                        serialNumber1 = "0" + num;
                        break;
                    case 4:
                        serialNumber1 = Convert.ToString(num);
                        break;
                }
                serialNumber = serialNumber1;
            }
            else
            {
                serialNumber = "0";
            }
            return serialNumber;
        }


        #endregion

    }

}