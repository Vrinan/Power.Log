using Power.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Power.Standard.Control;

public partial class StandardLogin : System.Web.UI.Page
{
    public string errmsg = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string opt = Request.Params["Opt"];
            if(string.IsNullOrEmpty(opt))
            {
                errmsg = "参数异常，登录失败";
                return;
            }
            string rdtUrl = string.Empty;
            rdtUrl = "/WebCenter/Open/00000000-0000-0000-0000-00000000000a";
            switch (opt)
            {
                //免密登录，参数+UserCode
                case "BackDoor":
                    string userCode = Request.Params["UserCode"];
                    string userName = Request.Params["UserName"];

                    if (String.IsNullOrEmpty(userCode) && String.IsNullOrEmpty(userName))
                    {
                        errmsg = "免密登录失败，参数错误!";
                        return;
                    }
                    if (!String.IsNullOrEmpty(userCode))
                    {
                        Power.Standard.Control.StandardLogin stLogin = new Power.Standard.Control.StandardLogin();
                        ViewResultModel rlt = stLogin.SignleSignOnBackDoorWithUserCode(userCode);
                        if (rlt.success)
                        {
                            //设置打开项目管理
                            Power.Business.Common.Helper.setCookie("firstmenuids", "cccccccc-0000-0000-0000-000000000000", 1);
                            Power.Business.Common.Helper.setCookie("firstmenuname", "个人中心", 1);
                            Power.Business.Common.Helper.setCookie("menuids", "cccccccc-0000-0000-0000-000000000000", 1);
                            HttpContext.Current.Response.Redirect(rdtUrl, false);
                        }
                        else
                        {
                            errmsg = rlt.message;
                            return;
                        }
                    }
                    else
                    {
                        Power.Standard.Control.StandardLogin stLogin = new Power.Standard.Control.StandardLogin();
                        ViewResultModel rlt = stLogin.SignleSignOnBackDoorWithUserName(userName);
                        if (rlt.success)
                        {
                            //设置打开项目管理
                            Power.Business.Common.Helper.setCookie("firstmenuids", "cccccccc-0000-0000-0000-000000000000", 1);
                            Power.Business.Common.Helper.setCookie("firstmenuname", "个人中心", 1);
                            Power.Business.Common.Helper.setCookie("menuids", "cccccccc-0000-0000-0000-000000000000", 1);
                            HttpContext.Current.Response.Redirect(rdtUrl, false);
                        }
                        else
                        {
                            errmsg = rlt.message;
                            return;
                        }
                    }
                    break;
                //流程信息，参数+msgId
                case "WorkFlowStandard":
                    string msgId = Request.Params["MsgId"];
                    if(string.IsNullOrEmpty(msgId))
                    {
                        errmsg = "MsgId不能为空";
                        return;
                    }
                    //Login
                    Power.Standard.Control.StandardLogin stLoginM = new Power.Standard.Control.StandardLogin();
                    ViewResultModel rltm = stLoginM.SignleSignWithMsgId(msgId);
                    if (rltm.success)
                    {
                        if (String.IsNullOrEmpty(msgId))
                        {
                            Power.Business.Common.Helper.setCookie("menuids", "aaaaaaaa-0000-0000-0000-000000000000", 1);
                        }
                        else
                        {
                            Power.Business.Common.Helper.setCookie("loginredirect", "/Message/Show/" + msgId, 1, false);
                            Power.Business.Common.Helper.setCookie("redirecttype", "open", 1, false);
                        }
                        //设置打开项目管理
                        Power.Business.Common.Helper.setCookie("firstmenuids", "aaaaaaaa-0000-0000-0000-000000000000", 1);
                        Power.Business.Common.Helper.setCookie("firstmenuname", "项目管理", 1);
                        HttpContext.Current.Response.Redirect(rdtUrl, false);
                    }
                    else
                    {
                        errmsg = rltm.message;
                    }
                    
                    break;
                default:
                    errmsg = "参数错误，登陆失败";
                    break;
            }
        }
    }
}