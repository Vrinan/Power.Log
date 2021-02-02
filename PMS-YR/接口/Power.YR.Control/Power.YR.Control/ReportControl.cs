using Power.Controls.PMS;
using Power.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Power.YR.Control
{
    public class ReportControl : BaseControl
    {
        /// <summary>
        /// 获取项目成本报告表（按装置）
        /// 单项目，不穿透统计
        /// 已签合同，点击时，要跳转到包含这个统计的已签合同列表
        /// 合同已支付，点击时，同理
        /// 装置名称，费用科目定义的代码名称
        /// 费用类别，费用工作表定义中的预算控制的名称
        /// 概算金额，项目预算-CBS中，版本号最大的，5中费用
        /// 已签合同成本：
        /// 合同已支付：付款申请的分摊
        /// 拆概算金额：
        /// </summary>
        /// <returns></returns>
        [ActionAttribute]
        public string GetProjectCostReport()
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            //1.获取所有装置
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select * from PS_CC_CBS_Class where XLX_Type='单项工程' and EpsProjId='{0}' order by CbsClassCode asc", session.EpsProjId);
            DataTable dtMain = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            //2.获取概算金额
            //2.1先获取当前主板本
            sql.Length = 0;
            sql.AppendFormat("select Id from PS_CC_ContractBudget where isLastVersion=0 and EpsProjId='{0}'", session.EpsProjId);
            DataTable dtbudget = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            //2.2 如果有主板本，获取概算
            if (dtbudget == null || dtbudget.Rows.Count == 0)
                throw new Exception("当前项目没有定义[项目预算-CBS]");
            sql.Length = 0;
            sql.AppendFormat(@"select * from PS_CC_ContractBudget_CBS where MasterId='{0}'and cbsclass_guid 
in(select Id from PS_CC_CBS_Class where XLX_Type='单项工程' and EpsProjId='{1}')", dtbudget.Rows[0]["Id"], session.EpsProjId);
            DataTable dtCBSClass = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            //3获取付款申请的分摊做为合同已支付金额
            sql.Length = 0;
            sql.AppendFormat(" select * from PS_CC_CostAllocation_CBS where MasterId in(select Id From PS_CC_CostAllocation where KeyWord='PS_SubContractApplyMoney' and EpsProjId='{0}')", session.EpsProjId);
            DataTable dtCBSCost = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            //3.1获取已签合同成本--李建市修改增加
            sql.Length = 0;
            sql.AppendFormat(" select * from PS_CC_CostAllocation_CBS where MasterId in(select Id From PS_CC_CostAllocation where KeyWord='PS_SubContract' and EpsProjId='{0}')", session.EpsProjId);
            DataTable dtConCBSCost = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());

            sql.Length = 0;
            sql.AppendFormat(" select * from PS_CC_CbsSheetConfig where  EpsProjId='{0}' and KeyWord in('PS_SubContract','PS_SubContractApplyMoney','PS_ContractBudget') order by Sequ asc", session.EpsProjId);
            DataTable dtConfig = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            DataRow[] ContConfig = dtConfig.Select("KeyWord='PS_SubContract'");//合同的
            DataRow[] ApplyConfig = dtConfig.Select("KeyWord='PS_SubContractApplyMoney'");//付款的
            DataRow[] BudgetConfig = dtConfig.Select("KeyWord='PS_ContractBudget'");//概算的
            //待返回的数据
            List<Hashtable> resultHash = new List<Hashtable>();
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                DataRow drMain = dtMain.Rows[i];
                //每一种费用类别
                foreach (DataRow drBudgetConfig in BudgetConfig)
                {
                    //一条要返回的数据
                    Hashtable hash = new Hashtable();
                    hash.Add("Id", Guid.NewGuid());
                    hash.Add("CbsClassName", drMain["CbsClassName"]);
                    hash.Add("CbsClass_Guid", drMain["Id"]);
                    hash.Add("CbsTitle", drBudgetConfig["CbsTitle"]);
                    //获取概算金额汇总：按装置、类别汇总
                    //1.先找到当前cbs的
                    DataRow[] CBSClass = dtCBSClass.Select("CbsClass_Guid='" + drMain["Id"].ToString() + "'");
                    double BudgetMoney = 0;
                    //2.循环这个cbs，去累加一个类别
                    foreach (DataRow drCBSClass in CBSClass)
                    {
                        string value = drCBSClass["CbsValue"] == null ? "" : drCBSClass["CbsValue"].ToString();
                        if (value == "")
                            continue;
                        Hashtable htValue = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(value);
                        if (htValue[drBudgetConfig["Id"].ToString()] == null || htValue[drBudgetConfig["Id"].ToString()].ToString() == "")
                            continue;
                        BudgetMoney += double.Parse(htValue[drBudgetConfig["Id"].ToString()].ToString());
                    }
                    hash.Add("BudgetMoney", BudgetMoney);
                    //3.计算合同已支付金额
                    //合同已支付的分摊对应的id和drBudgetConfig不一致，所以需要转化以下，现在暂时用名字做匹配
                    //先找到付款的
                    string ApplyId = getApplyId(drBudgetConfig, ApplyConfig);
                    hash.Add("ApplyCbs_Guid", ApplyId);
                    DataRow[] CBSCost = dtCBSCost.Select("CbsClass_Guid='" + drMain["Id"].ToString() + "'");
                    double CostMoney = 00;
                    foreach (DataRow drCBSCost in CBSCost)
                    {
                        string value = drCBSCost["AllocatedAmount"] == null ? "" : drCBSCost["AllocatedAmount"].ToString();
                        if (value == "")
                            continue;
                        Hashtable htValue = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(value);
                        if (htValue[ApplyId] == null || htValue[ApplyId].ToString() == "")
                            continue;
                        CostMoney += double.Parse(htValue[ApplyId].ToString());
                    }
                    hash.Add("CostMoney", CostMoney);

                    // ContractMoney一直为0，可能是徐老师忘记了，现在2018-2-26 10:44 由李建市进行修改
                    // hash.Add("ContractMoney", 0);
                    //在找已签合同成本
                    string ConApplyId = getConApplyId(drBudgetConfig, ContConfig);
                    //hash.Add("ApplyCbs_Guid", ApplyId);
                    DataRow[] ConCBSCost = dtConCBSCost.Select("CbsClass_Guid='" + drMain["Id"].ToString() + "'");
                    double ContractMoney = 00;
                    foreach (DataRow drConCBSCost in ConCBSCost)
                    {
                        string value = drConCBSCost["AllocatedAmount"] == null ? "" : drConCBSCost["AllocatedAmount"].ToString();
                        if (value == "")
                            continue;
                        Hashtable htValue = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(value);
                        if (htValue[ConApplyId] == null || htValue[ConApplyId].ToString() == "")
                            continue;
                        ContractMoney += double.Parse(htValue[ConApplyId].ToString());
                    }
                    hash.Add("ContractMoney", ContractMoney);
                    resultHash.Add(hash);
                }
            }
            result.data.Add("value", resultHash);
            return result.ToJson();
        }
        /// <summary>
        /// 点击合同已支付金额时，查询出有哪些合同付款
        /// </summary>
        /// <param name="CbsClass_Guid"></param>
        /// <param name="Cbs_Guid"></param>
        /// <returns></returns>
        [ActionAttribute]
        public string GetApplyIds(string CbsClass_Guid, string Cbs_Guid)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            //1.先通过CbsClass_Guid和当前EPS找到满足装置的数据
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select * from PS_CC_CostAllocation_CBS where MasterId in(select Id From PS_CC_CostAllocation where KeyWord='PS_SubContractApplyMoney' and EpsProjId='{0}')  and CbsClass_Guid='{1}'", session.EpsProjId, CbsClass_Guid);
            DataTable dtCost = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            //2.将当前Cbs_Guid=0的过滤掉，留下不为0的masterid
            List<string> masterids = new List<string>();
            for (int i = 0; i < dtCost.Rows.Count; i++)
            {
                DataRow drCost = dtCost.Rows[i];
                string value = drCost["AllocatedAmount"] == null ? "" : drCost["AllocatedAmount"].ToString();
                if (value == "")
                    continue;
                Hashtable htValue = Newtonsoft.Json.JsonConvert.DeserializeObject<Hashtable>(value);
                if (Cbs_Guid == "")
                {
                    if (!masterids.Contains(drCost["MasterId"].ToString()))
                        masterids.Add(drCost["MasterId"].ToString());
                }
                else
                {
                    if (htValue[Cbs_Guid] == null || htValue[Cbs_Guid].ToString() == "" || htValue[Cbs_Guid].ToString() == "0")
                        continue;
                    if (!masterids.Contains(drCost["MasterId"].ToString()))
                        masterids.Add(drCost["MasterId"].ToString());
                }
            }
            //找到分摊主表
            //将列表转为'xxx','xxx'
            string ids = "";
            foreach (string msterid in masterids)
            {
                ids += "'" + msterid + "',";
            }
            if (ids == "")
                throw new Exception("当前没有合同付款申请的费用分摊至此");
            ids = ids.Substring(0, ids.Length - 1);
            sql.Length = 0;
            sql.AppendFormat("select KeyValue from PS_CC_CostAllocation where Id in ({0})", ids);
            DataTable dtC = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            string keyvalues = "";
            for (int i = 0; i < dtC.Rows.Count; i++)
            {
                DataRow dr = dtC.Rows[i];
                keyvalues += "'" + dr["KeyValue"].ToString() + "',";
            }
            if (keyvalues == "")
                throw new Exception("通过" + sql.ToString() + "不能找到数据！");
            keyvalues = keyvalues.Substring(0, keyvalues.Length - 1);
            result.data.Add("value", keyvalues);
            return result.ToJson();
        }

        [ActionAttribute]
        public string ExecProc(string procname,string paramsname,string paramsvalue)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            XCode.DataAccessLayer.DAL dal = XCode.DataAccessLayer.DAL.Create();
            try
            {
                // 调用存储过程 
                System.Data.Common.DbCommand cmd = dal.Session.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procname;
                string[] paramsnames = paramsname.Split(',');
                string[] paramsvalues = paramsvalue.Split(',');
                for (int i = 0; i < paramsnames.Length; i++)
                {

                    System.Data.Common.DbParameter pms_proj_id = cmd.CreateParameter();
                    pms_proj_id.ParameterName = "@" + paramsnames[i];
                    pms_proj_id.Value = NewLife.Security.DataHelper.base64Decode(paramsvalues[i]);
                    cmd.Parameters.Add(pms_proj_id);
                }
                DataTableCollection dc = dal.Session.Query(cmd).Tables;
                //TitleRight
                if (dc.Count > 0)
                {
                    DataTable dt = dc[0];
                    result.data.Add("value", dt);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                dal.Session.AutoClose();
            }
            return result.ToJson();
        }
        /// <summary>
        /// 获取付款的费用工作表Id，由于付款的和预算的不是用一个，但报表需要是放在一起，所以要比对
        /// </summary>
        /// <param name="drBudgetConfig"></param>
        /// <param name="ApplyConfig"></param>
        /// <returns></returns>
        private string getApplyId(DataRow drBudgetConfig, DataRow[] ApplyConfig)
        {
            string ApplyId = "";
            //如果预算的名字中包含建，而付款的也包含建，那么Id就是这个，下面的一样
            if (drBudgetConfig["CbsTitle"].ToString().IndexOf("建") > -1)
            {

                DataRow dr = ApplyConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("建") > -1);
                if (dr != null)
                {
                    ApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("安装") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ApplyConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("安装") > -1);
                if (dr != null)
                {
                    ApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("设备") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ApplyConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("设备") > -1);
                if (dr != null)
                {
                    ApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("材料") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ApplyConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("材料") > -1);
                if (dr != null)
                {
                    ApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("其他") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ApplyConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("其他") > -1);
                if (dr != null)
                {
                    ApplyId = dr["Id"].ToString();
                }
            }
            return ApplyId;
        }
        /// <summary>
        /// 获取合同的费用工作表Id，由于合同的和预算的不是用一个，但报表需要是放在一起，所以要比对
        /// </summary>
        /// <param name="drBudgetConfig"></param>
        /// <param name="ContConfig"></param>
        /// <returns></returns>
        private string getConApplyId(DataRow drBudgetConfig, DataRow[] ContConfig)
        {
            string ConApplyId = "";
            //如果预算的名字中包含建，而付款的也包含建，那么Id就是这个，下面的一样
            if (drBudgetConfig["CbsTitle"].ToString().IndexOf("建") > -1)
            {

                DataRow dr = ContConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("建") > -1);
                if (dr != null)
                {
                    ConApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("安装") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ContConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("安装") > -1);
                if (dr != null)
                {
                    ConApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("设备") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ContConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("设备") > -1);
                if (dr != null)
                {
                    ConApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("材料") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ContConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("材料") > -1);
                if (dr != null)
                {
                    ConApplyId = dr["Id"].ToString();
                }
            }
            else if (drBudgetConfig["CbsTitle"].ToString().IndexOf("其他") > -1)
            {
                //如果当前是建筑工程的
                DataRow dr = ContConfig.FirstOrDefault(t => t["CbsTitle"].ToString().IndexOf("其他") > -1);
                if (dr != null)
                {
                    ConApplyId = dr["Id"].ToString();
                }
            }
            return ConApplyId;
        }
    }
}
