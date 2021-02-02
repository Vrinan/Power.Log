using Power.Controls.PMS;
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
    public class ProjectControl : BaseControl
    {
        /// <summary>
        /// 查询付款主表
        /// </summary>
        /// <param name="swhere">查询条件 </param>
        /// <param name="order">排序方式</param>
        /// <returns></returns>
        [ActionAttribute(Authorize = false)]
        public string ContractPay(string swhere, string order)
        {
            Power.Global.ViewResultModel result = Power.Global.ViewResultModel.Create(true, "");
            //解码HttpUtility
            swhere = HttpUtility.UrlDecode(swhere);
            order = HttpUtility.UrlDecode(order);
            //删除特殊字符
            swhere = swhere.Replace("drop", "").Replace("delete", "").Replace("sysdatabases", "").Replace("sysobjects", "");

            //调用的数据的视图需要虚拟登录
            //虚拟登录
            DataTable dtTemp = Power.Systems.StdSystem.UserDO.FindAllByTable("Code='admin'", "Code", "Code,PassWord", 0, 1);
            string pass = dtTemp.Rows[0]["PassWord"] == DBNull.Value ? "" : dtTemp.Rows[0]["PassWord"].ToString();
            Power.Controls.Action.ILoginAction loginAct = new Power.Controls.Action.LoginAction();
            loginAct.Login("admin", pass, "zh-CN");

            Power.Business.ViewEntity.IViewEntity viewOperate =
                Power.Business.ViewEntity.ViewEntityFactory.CreateViewEntity("view_PS_CM_SubContractApplyMny");

            viewOperate._SetSession(this.session);

            result.list = viewOperate.LoadDataList(swhere, order, 0, 0);

            return result.ToJson();
        }
        /// <summary>
        /// 查询付款子表
        /// </summary>
        /// <param name="swhere">查询条件 </param>
        /// <param name="order">排序方式</param>
        /// <returns></returns>
        [ActionAttribute(Authorize = false)]
        public string ContractPayDtl(string swhere, string order)
        {
            Power.Global.ViewResultModel result = Power.Global.ViewResultModel.Create(true, "");
            swhere = swhere.Replace("drop", "").Replace("delete", "").Replace("sysdatabases", "").Replace("sysobjects", "");
            List<Power.Systems.StdContract.PS_SubContractApplyMoney_MatDO> list =
                Power.Systems.StdContract.PS_SubContractApplyMoney_MatDO.FindAll(swhere, order, "", 0, 0);
            result.list = list;
            //DataTable dtTemp = Power.Systems.StdSystem.UserDO.FindAllByTable("Code='admin'", "Code", "Code,PassWord", 0, 1);
            //string pass = dtTemp.Rows[0]["PassWord"] == DBNull.Value ? "" : dtTemp.Rows[0]["PassWord"].ToString();
            //Power.Controls.Action.ILoginAction loginAct = new Power.Controls.Action.LoginAction();
            //loginAct.Login("admin", pass, "zh-CN");

            //Power.Business.ViewEntity.IViewEntity viewOperate =
            //    Power.Business.ViewEntity.ViewEntityFactory.CreateViewEntity("view_PS_CM_SubContractApplyMny");

            //viewOperate._SetSession(this.session);

            //result.list = viewOperate.LoadDataList(swhere, order, 0, 0);

            return result.ToJson();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SubContract_Guid">合同主键</param>
        /// <param name="SubContractType">合同类型</param>
        /// <param name="Code">合同支付编号</param>
        /// <param name="Title">合同支付名称</param>
        /// <param name="NC_ID">NC支付主键</param>
        /// <param name="OwnProjName">项目名称</param>
        /// <param name="EpsProjId">项目主键</param>
        /// <param name="PaymentWay">付款方式</param>
        /// <param name="PaymentAmount">付款金额</param>
        /// <param name="PaymentDate">付款日期</param>
        /// <param name="Memo">付款说明</param>
        /// <param name="TotalPaymentAmount">累计付款金额</param>
        /// <returns></returns>
        [ActionAttribute(Authorize = false)]
        public string ContractPayment(string SubContract_Guid, string SubContractType, string Code, string Title,
            string OwnProjName, string PaymentWay, string PaymentAmount, string PaymentDate, string Memo, string TotalPaymentAmount, string NC_ID, string EpsProjId)
        {
            Power.Global.ViewResultModel result = Power.Global.ViewResultModel.Create(true, "");
            //解码HttpUtility
            //swhere = HttpUtility.UrlDecode(swhere);
            //order = HttpUtility.UrlDecode(order);
            //删除特殊字符
            //swhere = swhere.Replace("drop", "").Replace("delete", "").Replace("sysdatabases", "").Replace("sysobjects", "");

            //调用的数据的视图需要虚拟登录
            //虚拟登录
            DataTable dtTemp = Power.Systems.StdSystem.UserDO.FindAllByTable("Code='admin'", "Code", "Code,PassWord", 0, 1);
            string pass = dtTemp.Rows[0]["PassWord"] == DBNull.Value ? "" : dtTemp.Rows[0]["PassWord"].ToString();
            Power.Controls.Action.ILoginAction loginAct = new Power.Controls.Action.LoginAction();
            loginAct.Login("admin", pass, "zh-CN");

            if (PaymentAmount.ToString().Length == 0)
            {
                PaymentAmount = "0";
            }
            if (TotalPaymentAmount.ToString().Length == 0)
            {
                TotalPaymentAmount = "0";
            }
                Guid MainId = Guid.NewGuid();
                Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusiness("PS_SubContractPayment");
                bbs.Init();
                bbs.SetItem("Id", MainId);
                bbs.SetItem("Status", "50");
                bbs.SetItem("SubContract_Guid", SubContract_Guid);
                bbs.SetItem("SubContractType", SubContractType);
                bbs.SetItem("Code", Code);
                bbs.SetItem("Title", Title);
                bbs.SetItem("PaymentWay", PaymentWay);
                bbs.SetItem("PaymentAmount", PaymentAmount);
                bbs.SetItem("PaymentDate", PaymentDate);
                bbs.SetItem("OwnProjName", OwnProjName);
                bbs.SetItem("EpsProjId", EpsProjId);
                bbs.SetItem("NC_ID", NC_ID);
                bbs.SetItem("TotalPaymentAmount", TotalPaymentAmount);
                bbs.SetItem("Memo", Memo);
                bbs.SetItem("RegHumId", "3636654E-65B6-49AF-8E8D-50A8AEEA9FA7");
                bbs.SetItem("RegHumName", "NC");
                bbs.SetItem("RegDate", DateTime.Now);
                bbs.Save(System.ComponentModel.DataObjectMethodType.Insert);

            //Power.Business.ViewEntity.IViewEntity viewOperate =
            //    Power.Business.ViewEntity.ViewEntityFactory.CreateViewEntity("view_PS_CM_SubContractPayment");

            //viewOperate._SetSession(this.session);

            //result.list = viewOperate.LoadDataList(swhere, order, 0, 0);
            Power.ISystems.AutoLoginConfig config = new ISystems.AutoLoginConfig();
            config.epsprojid = "22499EBC-401C-44E1-A036-6134DD424D8D";//自动打开的项目ID
            config.url = "http://172.30.30.216:8080/Form/ValidForm/0bc7d119-6a0d-418e-8bb4-273642584ba8/edit/"+ MainId;//打开的地址
            config.type = ISystems.EConfigType.MiniOpen;//通过mini.open的方式打开
            config.title = "打开";
            config.target = "_blank";
            string id = Power.Global.PowerGlobal.autologinPool.AddAutoLogin("130005", DateTime.Now, "zh-cn", config, DateTime.Now.AddYears(999), 999, ISystems.EActionType.GoPath);
            //string adress = "http://172.30.30.216:8080/API/AutoLogin/" + id ;
            //System.Diagnostics.Process.Start(adress);
            Power.Business.IBaseBusiness Login = Power.Business.BusinessFactory.CreateBusinessOperate("AutoLogin").FindByKey(id);
            Login.SetItem("OpenId", MainId);
            Login.UpdateSelf();
            return result.ToJson();
        }
    }
}
