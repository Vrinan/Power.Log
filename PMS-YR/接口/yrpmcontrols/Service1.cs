using System;
using Power.Business;
using Power.Controls.PMS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Power.Global;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace YRPMControls
{
    partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            EventLog.WriteEntry("我的服务启动（定时触发事件）");//在系统事件查看器里的应用程序事件里来源的描述
            WriteLog("服务启动"); //自定义文本日志
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 1000*60*10; //1秒
            t.Elapsed += new System.Timers.ElapsedEventHandler(ChkSrv);//到达时间的时候执行事件
            t.AutoReset = true;//设置是执行一次（false），还是一直执行（true）
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件

        }
        public void ChkSrv (object source,System.Timers.ElapsedEventArgs e)
        {
            int intHour = e.SignalTime.Hour; //时
            int intMinute = e.SignalTime.Minute;//分
            int intsecond = e.SignalTime.Second;//秒

            if(intHour == 10 && intMinute == 30 && intsecond == 00)  //定时设置，判断分时秒 12点发送消息
            {
                try
                {
                    System.Timers.Timer tt = (System.Timers.Timer)source;
                    tt.Enabled = false;

                    SendMessage();

                    tt.Enabled = true;
                }
                catch (Exception err)
                {
                    WriteLog(err.Message);
                }
            }
        }
        public void SendMessage()
        {
            try
            {
                WriteLog(Sync("BDB38047-3EE8-C964-062B-B738F77D34B3", "1"));
            }
            catch(Exception ex)
            {
                WriteLog(ex.Message);
            }
        }
        public string Sync(string id, string type)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            //根据id，查到接口表中的数据
            Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("YR_NC_Interface").FindByKey(id, SearchFlag.IgnoreRight);
            //点击增量同步时，没有同步时间，则默认改为全部同步
            if (bbs["NCType"] == null || bbs["NCType"].ToString() == "")
            { throw new Exception("【NC同步类型】必须填写"); }
            
            else
            {
                if (bbs["NCCode"] == null || bbs["NCCode"].ToString() == "")
                    throw new Exception("【当前项目编号】必须填写");
                if (type == "1" && (bbs["SyncTime"] == null || Convert.ToDateTime(bbs["SyncTime"].ToString()) == DateTime.MinValue))
                    type = "0";
                //string sql = " select * from openquery(NCDB,  'SELECT * from V_pm_supplier where pk_corp=''1081'' and ts>=''2017-01-01'' ' )";
                //nc的sql
                string sql = "SELECT * from V_pm_supplier where pk_corp=''" + bbs["NCCode"] + "''";
                DataTable nctable = new DataTable();
                if (type == "0")//全部同步，查询完，就将当前时间，设置到上次同步时间中
                {
                    string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                    nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                    bbs.SetItem("SyncTime", DateTime.Now);
                }
                else if (type == "1")//增量同步，需要增加时间戳判断
                {
                    string time = Convert.ToDateTime(bbs["SyncTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    sql += " and ts>=''" + time + "''";

                    string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                    nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                    bbs.SetItem("SyncTime", DateTime.Now);
                }
                else if (type == "2")//按条件同步，不能回写时间戳
                {
                    if (bbs["Condition"] == null || bbs["Condition"].ToString() == "")
                        throw new Exception("【同步条件】不能为空");
                    string Condition = "''%" + bbs["Condition"].ToString() + "%''";
                    sql += " and CUSTNAME like " + Condition;

                    string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                    nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                }
                else if (type == "3")//查询NC中的数量
                {
                    sql = "SELECT count(*) as SupCount from V_pm_supplier where pk_corp=''" + bbs["NCCode"] + "''";
                    string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                    nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                    bbs.SetItem("NCNumber", nctable.Rows[0]["SupCount"]);
                }
                if (type != "3")
                {
                    for (int i = 0; i < nctable.Rows.Count; i++)
                    {
                        DataRow dr = nctable.Rows[i];
                        //NC中必须有主键
                        if (dr["PK_CUBASDOC"] == null || dr["PK_CUBASDOC"].ToString() == "")
                            continue;
                        Power.Business.IBusinessList list = Power.Business.BusinessFactory.CreateBusinessOperate("XLX_PUR_Supplie").FindAll("NC_ID='" + dr["PK_CUBASDOC"] + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                        if (list.Count > 0)//修改
                        {
                            Power.Business.IBaseBusiness sup = list[0];
                            if (dr["CUSTCODE"] != null && dr["CUSTCODE"].ToString() != "")
                                sup.SetItem("Code", dr["CUSTCODE"]);
                            if (dr["CUSTNAME"] != null && dr["CUSTNAME"].ToString() != "")
                                sup.SetItem("Name", dr["CUSTNAME"]);
                            if (dr["BANKDOCNAME"] != null && dr["BANKDOCNAME"].ToString() != "")
                                sup.SetItem("BankName", dr["BANKDOCNAME"]);
                            if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                                sup.SetItem("BankAccount", dr["ACCOUNT"]);
                            sup.UpdateSelf();
                        }
                        else
                        {//新增
                            Power.Business.IBaseBusiness sup = Power.Business.BusinessFactory.CreateBusiness("XLX_PUR_Supplie");
                            if (dr["CUSTCODE"] != null && dr["CUSTCODE"].ToString() != "")
                                sup.SetItem("Code", dr["CUSTCODE"]);
                            if (dr["CUSTNAME"] != null && dr["CUSTNAME"].ToString() != "")
                                sup.SetItem("Name", dr["CUSTNAME"]);
                            if (dr["BANKDOCNAME"] != null && dr["BANKDOCNAME"].ToString() != "")
                                sup.SetItem("BankName", dr["BANKDOCNAME"]);
                            if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                                sup.SetItem("BankAccount", dr["ACCOUNT"]);
                            sup.SetItem("NC_ID", dr["PK_CUBASDOC"]);
                            sup.SetItem("QuaStatus", "准入");
                            sup.Save(System.ComponentModel.DataObjectMethodType.Insert);

                        }
                    }
                    //回写PM的数量
                    int pmNumber = Power.Business.BusinessFactory.CreateBusinessOperate("XLX_PUR_Supplie").FindCount("EpsProjId='345ED76D-18FA-42A4-B666-4842A12310A0'" + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                    bbs.SetItem("PMNumber", pmNumber);
                }
                bbs.UpdateSelf();
            }
            return result.ToJson();
        }
        public void WriteLog(string readme)
        {
            System.IO.StreamWriter dout = new System.IO.StreamWriter(@"c:/" + "WServ_InnPointLog.txt", true);
            dout.Write("/r/n事件：" + readme + "/r/n操作时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dout.Close();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            WriteLog("服务停止");
            EventLog.WriteEntry("我的服务停止");

        }
    }
}
