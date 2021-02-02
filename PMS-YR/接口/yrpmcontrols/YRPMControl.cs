using Power.Business;
using Power.Controls.PMS;
using Power.Global;
using Power.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YRPMControls
{
    public class YRPMControl : Power.Controls.PMS.BaseControl
    {
        /// <summary>
        /// type:0是全部同步，1是增量同步，2是按条件同步，3是查询NC中的数量
        /// </summary> 
        /// <returns></returns>
        [ActionAttribute]
        public string Sync(string id, string type)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            //根据id，查到接口表中的数据
            Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("YR_NC_Interface").FindByKey(id, SearchFlag.IgnoreRight);
            //点击增量同步时，没有同步时间，则默认改为全部同步
            if (bbs["NCType"] == null || bbs["NCType"].ToString() == "")
            { throw new Exception("【NC同步类型】必须填写"); }
            else if (bbs["NCType"].ToString() == "付款协议")
                Sync1(id, type);
            else if (bbs["NCType"].ToString() == "付款类别")
                Sync2(id, type);
            else if (bbs["NCType"].ToString() == "收支项目")
                Sync3(id, type);
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
                    string Condition = "''%"+ bbs["Condition"].ToString() + "%''";
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
                    int pmNumber = Power.Business.BusinessFactory.CreateBusinessOperate("XLX_PUR_Supplie").FindCount("EpsProjId='" + session.EpsProjId + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                    bbs.SetItem("PMNumber", pmNumber);
                }
                bbs.UpdateSelf();
            }
            return result.ToJson();
        }
        public string Sync1(string id, string type)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("YR_NC_Interface").FindByKey(id, SearchFlag.IgnoreRight);
            if (type == "1" && (bbs["SyncTime"] == null || Convert.ToDateTime(bbs["SyncTime"].ToString()) == DateTime.MinValue))
                type = "0";
            //string sql = " select * from openquery(NCDB,  'SELECT * from V_pm_supplier where pk_corp=''1081'' and ts>=''2017-01-01'' ' )";
            //nc的sql
            string sql = "select * from v_pm_bd_payterm ";
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
                sql += " where ts>=''" + time + "''";

                string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                bbs.SetItem("SyncTime", DateTime.Now);
            }
            else if (type == "2")//按条件同步，不能回写时间戳
            {
                if (bbs["Condition"] == null || bbs["Condition"].ToString() == "")
                    throw new Exception("【同步条件】不能为空");

                sql += " where  " + bbs["Condition"].ToString().Replace("'", "''");

                string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
            }
            else if (type == "3")//查询NC中的数量
            {
                sql = "SELECT count(*) as SupCount from v_pm_bd_payterm ";
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
                    if (dr["PK_PAYTERM"] == null || dr["PK_PAYTERM"].ToString() == "")
                        continue;
                    Power.Business.IBusinessList list = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindAll("NC_Id='" + dr["PK_PAYTERM"] + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                    if (list.Count > 0)//修改
                    {
                        Power.Business.IBaseBusiness sup = list[0];
                        if (dr["TERMID"] != null && dr["TERMID"].ToString() != "")
                            sup.SetItem("Code", dr["TERMID"]);
                        if (dr["TERMNAME"] != null && dr["TERMNAME"].ToString() != "")
                            sup.SetItem("Name", dr["TERMNAME"]);
                        //if (dr["BANKDOCNAME"] != null && dr["BANKDOCNAME"].ToString() != "")
                        //    sup.SetItem("BankName", dr["BANKDOCNAME"]);
                        //if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                        //    sup.SetItem("BankAccount", dr["ACCOUNT"]);
                        sup.UpdateSelf();
                    }
                    else
                    {//新增
                        Power.Business.IBaseBusiness sup = Power.Business.BusinessFactory.CreateBusiness("BaseDataList");
                        if (dr["TERMID"] != null && dr["TERMID"].ToString() != "")
                            sup.SetItem("Code", dr["TERMID"]);
                        if (dr["TERMNAME"] != null && dr["TERMNAME"].ToString() != "")
                            sup.SetItem("Name", dr["TERMNAME"]);
                        //if (dr["TS"] != null && dr["TS"].ToString() != "")
                        //    sup.SetItem("UpdDate", dr["TS"]);
                        //if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                        //    sup.SetItem("BankAccount", dr["ACCOUNT"]);
                        sup.SetItem("UpdDate", DateTime.Now);
                        sup.SetItem("NC_Id", dr["PK_PAYTERM"]);
                        sup.SetItem("Actived", "1");
                        sup.SetItem("bSysDefault", "N");
                        sup.SetItem("BaseDataId", "DFC8B116-1A4C-47C2-B028-D1499064AD37");
                        sup.Save(System.ComponentModel.DataObjectMethodType.Insert);

                    }
                }
                //回写PM的数量
                int pmNumber = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindCount("BaseDataId='" + "DFC8B116-1A4C-47C2-B028-D1499064AD37" + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                bbs.SetItem("PMNumber", pmNumber);
            }
            bbs.UpdateSelf();
            return result.ToJson();
        }
        public string Sync2(string id, string type)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("YR_NC_Interface").FindByKey(id, SearchFlag.IgnoreRight);
            if (type == "1" && (bbs["SyncTime"] == null || Convert.ToDateTime(bbs["SyncTime"].ToString()) == DateTime.MinValue))
                type = "0";
            //string sql = " select * from openquery(NCDB,  'SELECT * from V_pm_supplier where pk_corp=''1081'' and ts>=''2017-01-01'' ' )";
            //nc的sql
            string sql = "select * from v_pm_bd_paytype";
            DataTable nctable = new DataTable();
            if (type == "0")//全部同步，查询完，就将当前时间，设置到上次同步时间中
            {
                string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                bbs.SetItem("SyncTime", DateTime.Now);
            }
            else if (type == "1")//增量同步，需要增加时间戳判断
            {
                return "当前接口不支持增量同步";
                //string time = Convert.ToDateTime(bbs["SyncTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                //sql += " where ts>=''" + time + "''";

                //string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                //nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                //bbs.SetItem("SyncTime", DateTime.Now);
            }
            else if (type == "2")//按条件同步，不能回写时间戳
            {
                if (bbs["Condition"] == null || bbs["Condition"].ToString() == "")
                    throw new Exception("【同步条件】不能为空");

                sql += " where  " + bbs["Condition"].ToString().Replace("'", "''");

                string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
            }
            else if (type == "3")//查询NC中的数量
            {
                sql = "SELECT count(*) as SupCount from v_pm_bd_paytype";
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
                    if (dr["VALUE"] == null || dr["VALUE"].ToString() == "")
                        continue;
                    Power.Business.IBusinessList list = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindAll("NC_Id='" + dr["VALUE"] + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                    if (list.Count > 0)//修改
                    {
                        Power.Business.IBaseBusiness sup = list[0];
                        if (dr["VALUE"] != null && dr["VALUE"].ToString() != "")
                            sup.SetItem("Code", dr["VALUE"]);
                        if (dr["NAME"] != null && dr["NAME"].ToString() != "")
                            sup.SetItem("Name", dr["NAME"]);
                        //if (dr["BANKDOCNAME"] != null && dr["BANKDOCNAME"].ToString() != "")
                        //    sup.SetItem("BankName", dr["BANKDOCNAME"]);
                        //if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                        //    sup.SetItem("BankAccount", dr["ACCOUNT"]);
                        sup.UpdateSelf();
                    }
                    else
                    {//新增
                        Power.Business.IBaseBusiness sup = Power.Business.BusinessFactory.CreateBusiness("BaseDataList");
                        if (dr["VALUE"] != null && dr["VALUE"].ToString() != "")
                            sup.SetItem("Code", dr["VALUE"]);
                        if (dr["NAME"] != null && dr["NAME"].ToString() != "")
                            sup.SetItem("Name", dr["NAME"]);
                        //if (dr["TS"] != null && dr["TS"].ToString() != "")
                        //    sup.SetItem("UpdDate", dr["TS"]);
                        //if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                        //    sup.SetItem("BankAccount", dr["ACCOUNT"]);
                        sup.SetItem("UpdDate", DateTime.Now);
                        sup.SetItem("NC_Id", dr["VALUE"]);
                        sup.SetItem("Actived", "1");
                        sup.SetItem("bSysDefault", "N");
                        sup.SetItem("BaseDataId", "663474EC-5BED-4F7B-94EC-4E2827B02235");
                        sup.Save(System.ComponentModel.DataObjectMethodType.Insert);

                    }
                }
                //回写PM的数量
                int pmNumber = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindCount("BaseDataId='" + "663474EC-5BED-4F7B-94EC-4E2827B02235" + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                bbs.SetItem("PMNumber", pmNumber);
            }
            bbs.UpdateSelf();
            return result.ToJson();
        }
        public string Sync3(string id, string type)
        {
            ViewResultModel result = ViewResultModel.Create(true, "");
            Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("YR_NC_Interface").FindByKey(id, SearchFlag.IgnoreRight);
            if (type == "1" && (bbs["SyncTime"] == null || Convert.ToDateTime(bbs["SyncTime"].ToString()) == DateTime.MinValue))
                type = "0";
            //string sql = " select * from openquery(NCDB,  'SELECT * from V_pm_supplier where pk_corp=''1081'' and ts>=''2017-01-01'' ' )";
            //nc的sql
            string sql = "select * from v_pm_bd_costsubj  where pk_corp=1082 ";
            DataTable nctable = new DataTable();
            if (type == "0")//全部同步，查询完，就将当前时间，设置到上次同步时间中
            {
                string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                bbs.SetItem("SyncTime", DateTime.Now);
            }
            else if (type == "1")//增量同步，需要增加时间戳判断
            {
                return "当前接口不支持增量同步";
                //string time = Convert.ToDateTime(bbs["SyncTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                //sql += " where ts>=''" + time + "''";

                //string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                //nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
                //bbs.SetItem("SyncTime", DateTime.Now);
            }
            else if (type == "2")//按条件同步，不能回写时间戳
            {
                if (bbs["Condition"] == null || bbs["Condition"].ToString() == "")
                    throw new Exception("【同步条件】不能为空");

                sql += " where  " + bbs["Condition"].ToString().Replace("'", "''");

                string ncsql = " select * from openquery(NCDB,  '" + sql + "' )";
                nctable = XCode.DataAccessLayer.DAL.QuerySQL(ncsql);
            }
            else if (type == "3")//查询NC中的数量
            {
                sql = "SELECT count(*) as SupCount from v_pm_bd_costsubj where pk_corp=1082";
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
                    if (dr["PK_COSTSUBJ"] == null || dr["PK_COSTSUBJ"].ToString() == "")
                        continue;
                    Power.Business.IBusinessList list = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindAll("NC_Id='" + dr["PK_COSTSUBJ"] + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                    if (list.Count > 0)//修改
                    {
                        Power.Business.IBaseBusiness sup = list[0];
                        if (dr["costcode"] != null && dr["costcode"].ToString() != "")
                            sup.SetItem("Code", dr["costcode"]);
                        if (dr["COSTNAME"] != null && dr["COSTNAME"].ToString() != "")
                            sup.SetItem("Name", dr["COSTNAME"]);
                        //if (dr["BANKDOCNAME"] != null && dr["BANKDOCNAME"].ToString() != "")
                        //    sup.SetItem("BankName", dr["BANKDOCNAME"]);
                        //if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                        //    sup.SetItem("BankAccount", dr["ACCOUNT"]);
                        sup.UpdateSelf();
                    }
                    else
                    {//新增
                        Power.Business.IBaseBusiness sup = Power.Business.BusinessFactory.CreateBusiness("BaseDataList");
                        if (dr["costcode"] != null && dr["costcode"].ToString() != "")
                            sup.SetItem("Code", dr["costcode"]);
                        if (dr["COSTNAME"] != null && dr["COSTNAME"].ToString() != "")
                            sup.SetItem("Name", dr["COSTNAME"]);
                        if (dr["PK_PARENT"] != null && dr["PK_PARENT"].ToString() != "")
                            sup.SetItem("LongCode", dr["PK_PARENT"]);
                        else
                            sup.SetItem("LongCode", "00000000-0000-0000-0000-000000000000");
                        //if (dr["TS"] != null && dr["TS"].ToString() != "")
                        //    sup.SetItem("UpdDate", dr["TS"]);
                        //if (dr["ACCOUNT"] != null && dr["ACCOUNT"].ToString() != "")
                        //    sup.SetItem("BankAccount", dr["ACCOUNT"]);
                        sup.SetItem("UpdDate", DateTime.Now);
                        sup.SetItem("NC_Id", dr["PK_COSTSUBJ"]);
                        sup.SetItem("Actived", "1");
                        sup.SetItem("bSysDefault", "N");
                        sup.SetItem("BaseDataId", "B92084E1-9963-44FB-ACB5-E5E90597EB5E");
                        sup.Save(System.ComponentModel.DataObjectMethodType.Insert);          

                    }
                }
                //更新父节点Id
                //1、获取子表数据
                Power.Business.IBusinessList BaseDataListBO = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindAll("BaseDataId='B92084E1-9963-44FB-ACB5-E5E90597EB5E''" + "'", "", "", 0, 0,SearchFlag.IgnoreRight);
                foreach (var tmp1 in BaseDataListBO)
                {
                    //2、根据评价子表中个LongCode 和 NC_Id 的值更新Parent_Id的值    
                    if ((Convert.ToString(tmp1["LongCode"]) != "") && (Convert.ToString(tmp1["LongCode"]) != "00000000-0000-0000-0000-000000000000"))
                    {
                        //子节点需要更新父节点ID
                        //查找对应的父节点Id
                        string strsql_Pid = "select Id from pb_BaseDataList where NC_Id='" + tmp1["LongCode"].ToString() + "' ";
                        DataTable Piddata = XCode.DataAccessLayer.DAL.QuerySQL(strsql_Pid); //执行
                        tmp1.SetItem("ParentId", Piddata.Rows[0]["Id"].ToString());
                        tmp1.Save(System.ComponentModel.DataObjectMethodType.Update);
                    }
                }
                //回写PM的数量
                int pmNumber = Power.Business.BusinessFactory.CreateBusinessOperate("BaseDataList").FindCount("BaseDataId='" + "B92084E1-9963-44FB-ACB5-E5E90597EB5E" + "'", "", "", 0, 0, SearchFlag.IgnoreRight);
                bbs.SetItem("PMNumber", pmNumber);
            }
            bbs.UpdateSelf();
            return result.ToJson();
        }
        //人员同步
        [Action(Authorize = true)]
        public string NC_Synchro_Human()
        {   //Guid plan_guid 
            ViewResultModel re = ViewResultModel.Create(true, "");
            XCode.DataAccessLayer.DAL dal = XCode.DataAccessLayer.DAL.Create();
            try
            {
                //调用存储过程 

                System.Data.Common.DbCommand cmd = dal.Session.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "p_yr_nc_Human_get";
                dal.Session.Execute(cmd);
                return re.ToJson();
            }
            catch (System.Exception e)
            {
                re.success = false;
                re.message = e.Message;
                return re.ToJson();

            }
            finally
            {
                dal.Session.AutoClose();
            }
        }
        /// <summary>
        /// 无密码登录
        /// </summary>
        /// <param name="UserCode">帐号</param>
        /// <param name="Language">语种</param>
        /// <returns></returns>
        [ActionAttribute(Authorize = false)]
        public string Login(string UserCode, string Language)
        {
            Power.Controls.PMS.APIControl api = new APIControl();
            Power.Global.ViewResultModel result = api.Login(UserCode, Language);
            return result.ToJson();
        }
    }
}
