 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Data;
 using System.Text;   
 using System.Linq;
  
  


 namespace PowerOn.EPC.SFCG
{  
      /// <summary>
    /// 请购计划 消息申明
    /// </summary>
     public partial class SF_CG_PurchasePlanBO 
    {
	    #region 用户自定义代码，相应外部消息域
		

		#endregion 
    }

    /// <summary>
    /// 请购计划
    /// </summary>
     public partial class SF_CG_PurchasePlanBO<TBusiness,TSF_CG_PurchasePlanListBO> 
    {
        #region 响应内部事件
		public override void EndFlowChange(Power.IWorkFlow.WorkFlow.EFlowOperate flowOperate,Power.IWorkFlow.WorkFlow.ERecordStatus recordStatus,System.Collections.Hashtable hasFlowInfo)
{
            //此处可撰写流程状态改变后代码
            if (recordStatus == Power.IWorkFlow.WorkFlow.ERecordStatus.Finish)
            {
                Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("SF_CG_PurchasePlan").FindByKey(
                    new string[] { "Id" }, new string[] { this.Id.ToString() }, Power.Business.SearchFlag.IgnoreRight);
                string mainCode = "";
                string sequ = "";
                //年份
                string year = DateTime.Now.ToString("yyyy");
                //前缀字母编号
                string type = "";

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.Append(" select TOP 1 CONVERT(int,Right(Code,3)) MaxCode,Code,RegDate ");
                sbSQL.Append(" from SF_CG_PurchasePlan ");
                sbSQL.Append(" where YEAR(RegDate)='" + DateTime.Now.Year.ToString() + "' ");
                //年度计划单独走
                if (this.PlanType.Equals("3"))
                {
                    sbSQL.Append(" and PlanType='" + this.PlanType + "' ");
                }
                else
                {
                    sbSQL.Append(" and PurchaseMajor='" + this.PurchaseMajor + "' ");
                    sbSQL.Append(" and PlanType='" + this.PlanType + "' ");
                    if (this.PurchaseMajor.Equals("3"))
                    {
                        sbSQL.Append(" and ProjId='" + this.ProjId + "' ");
                    }
                }

                sbSQL.Append(" order by MaxCode desc ");
                DataTable dtTemp = XCode.DataAccessLayer.DAL.QuerySQL(sbSQL.ToString());
                if (dtTemp == null || dtTemp.Rows.Count == 0||dtTemp.Rows[0]["MaxCode"].ToString().Length == 0)
                {
                    sequ += "001";
                }
                else
                {
                    int counts = Convert.ToInt32(dtTemp.Rows[0]["MaxCode"]) + 1;
                    if (counts < 10)
                    {
                        sequ += "00" + counts;
                    }
                    else if (counts < 100)
                    {
                        sequ += "0" + counts;
                    }
                    else
                    {
                        sequ += counts + "";
                    }
                }

                //1--工程类  2--膜系统 3--运行站 4--办公用品 5--劳保用品 6--项目部
                //select * from PB_BaseData where DataType='PurchaseMajor'
                //select Code,Name from PB_BaseDataList where BaseDataId='A93B2A46-0626-4F41-B584-30190BD37E85'
                string string_sequ = bbs["PurchaseMajor"].ToString();
                if (this.PlanType.Equals("3"))
                {
                    type += "JQ";
                }
                else
                {
                    if (string_sequ.Equals("2"))
                    {
                        type += "JMS";
                    }
                    else if (string_sequ.Equals("3"))
                    {
                        type += "J";
                        Power.Business.IBaseBusiness projectBO = Power.Business.BusinessFactory.CreateBusinessOperate("Project").FindByKey(
                            new string[] { "project_guid" }, new string[] { this.ProjId.ToString() }, Power.Business.SearchFlag.IgnoreRight);
                        type += projectBO["project_shortname"];

                    }
                    else if (string_sequ.Equals("1"))
                    {
                        //表:PLN_project 业务对象:Project
                        type += "JS";
                        Power.Business.IBaseBusiness projectBO = Power.Business.BusinessFactory.CreateBusinessOperate("Project").FindByKey(
                            new string[] { "project_guid" }, new string[] { this.ProjId.ToString() }, Power.Business.SearchFlag.IgnoreRight);
                        if (projectBO["Abbreviation"] != null)
                        {
                            type += "(" + projectBO["Abbreviation"] + ")";
                        }
                        else
                        {
                            type += "(" + projectBO["project_name"] + ")";
                        }
                    }
                    else
                    {
                        type += "JQ";
                    }
                }

                //年份取后两位
                mainCode = type + year.Substring(2) + sequ;
                bbs.SetItem("Code", mainCode);
                bbs.UpdateSelf();

                //找到本表的所有明细
                Power.Business.IBusinessOperate planDtlOpt = Power.Business.BusinessFactory.CreateBusinessOperate("SF_CG_PurchasePlanList");
                Power.Business.IBusinessList planDtlList = planDtlOpt.FindAll("MasterId", this.Id.ToString(), Power.Business.SearchFlag.IgnoreRight);

                //给所有物资附上计划编号(PlanCode,主表编号+流水号)
                for (int i = 0; i < planDtlList.Count; i++)
                {
                    string Matsequ = "";
                    //明细流水号
                    if (i < 9)
                    {
                        Matsequ = "0" + (i + 1);
                    }
                    else
                    {
                        Matsequ = (i + 1) + "";
                    }
                    planDtlList[i].SetItem("Code", mainCode + "-" + Matsequ);
                    planDtlList[i].SetItem("sequ", Matsequ);
                    //保存
                    planDtlList[i].UpdateSelf();
                }
            }
            return;
}


		#endregion 

		#region 用户自定义代码
		        //已选择的方案
        public String setChosenPlan(string SchemeId,string KeyValue,string KeyWord,string Type,bool IsReloadSchemeList)
        {
            Power.Global.ViewResultModel result = Power.Global.ViewResultModel.Create(true, "");
            //保存前,如果选过采购计划，那就把方案的IsChosen置为未选择(0)
            if (Type.Equals("Before"))
            {
                Power.Business.IBaseBusiness busi = Power.Business.BusinessFactory.CreateBusinessOperate(KeyWord)
                    .FindByKey(KeyValue);
                if ( busi!=null && busi["SchemeId"] != null )
                {
                    Power.Business.IBaseBusiness PurchasePlan = Power.Business.BusinessFactory.CreateBusinessOperate("SF_CG_PurchasePlan").FindByKey(busi["SchemeId"].ToString()); ;
                    PurchasePlan.SetItem("IsChosen",0);
                    PurchasePlan.UpdateSelf();
                    result.data.Add("values", "FindScheme-Set0");
                }
            }
            else
            {
                result.data.Add("values", "NoScheme");
            }
            //保存后,置为1,并且把明细读进来
            if (Type.Equals("After"))
            {
                Power.Business.IBaseBusiness PurchasePlan = Power.Business.BusinessFactory.CreateBusinessOperate("SF_CG_PurchasePlan").FindByKey(SchemeId);
                PurchasePlan.SetItem("IsChosen", 1);
                PurchasePlan.UpdateSelf();

                //如果重选了向导,就清除重载下明细
                if(IsReloadSchemeList)
                {
                    //如果原本有明细,那就全删除
                    if (Power.Business.BusinessFactory.CreateBusinessOperate(KeyWord + "List").FindAll("MasterId", KeyValue, Power.Business.SearchFlag.IgnoreRight).Count > 0)
                    {
                        Power.Business.BusinessFactory.CreateBusinessOperate(KeyWord + "List").FindAll("MasterId", KeyValue, Power.Business.SearchFlag.IgnoreRight).Delete();
                    }
                    //找到采购计划的所有明细
                    Power.Business.IBusinessList planList = Power.Business.BusinessFactory
                        .CreateBusinessOperate("SF_CG_PurchasePlanList").FindAll(new string[] {"MasterId"},
                            new string[] { SchemeId }, Power.Business.SearchFlag.IgnoreRight);
                    for (int i = 0; i < planList.Count; i++)
                    {
                        //根据关键词,创建对应子表的对象,赋值后保存
                        Power.Business.IBaseBusiness busi = Power.Business.BusinessFactory.CreateBusiness(KeyWord+"List");
    
                        busi.SetItem("Id", new Guid().ToString());
                        busi.SetItem("MasterId", KeyValue);
                        busi.SetItem("PlanId", planList[i]["Id"]);
                        busi.SetItem("PlanCode", planList[i]["Code"]);
                        busi.SetItem("Code", planList[i]["MatCode"]);
                        busi.SetItem("MatId", planList[i]["MatId"]);
                        busi.SetItem("MatName", planList[i]["MatName"]);
                        busi.SetItem("Specification", planList[i]["Specification"]);
                        busi.SetItem("PID", planList[i]["PID"]);
                        busi.SetItem("MatUnit", planList[i]["MatUnit"]);
                        busi.SetItem("Amount", planList[i]["Amount"]);
                        busi.SetItem("BidPrice", planList[i]["Price"]);
                        busi.SetItem("BidTotalPrice", planList[i]["TotalPrice"]);
                        busi.SetItem("Remark", planList[i]["Remark"]);
                        busi.SetItem("sequ", i);
                        busi.SetItem("Update", planList[i]["Update"]);
                        busi.SetItem("Model", planList[i]["Model"]);
                        //保存
                        busi.Save(System.ComponentModel.DataObjectMethodType.Insert);
                    }
                    result.data.Add("valuess", "ReLoadListData");
                }
                else
                {
                    result.data.Add("valuess", "Do nothing!+"+IsReloadSchemeList);
                }
            }

            return result.ToJson();
        }
            
         //导入物资
         public string ImportExcel(string KeyWord, string KeyValue, string Id)
        {

            DataTable ImportData = ReslutData(KeyWord, KeyValue);
            if (ImportData.Rows.Count > 0)
            {
                //先删除原来的全部
                Power.Business.BusinessFactory.CreateBusinessOperate("SF_CG_PurchasePlanList").FindAll("MasterId", Id, Power.Business.SearchFlag.IgnoreRight).Delete();//此处修改外键
            }
            //获取session
            Power.IBaseCore.ISession session = Power.Global.PowerGlobal.CurrentSession;

            //把物资库（PS_MDM_Mat） 读进来
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("select Id,MatCode,MatShortName from PS_MDM_Mat");
            DataTable dtTemp = XCode.DataAccessLayer.DAL.QuerySQL(sbSQL.ToString());
            DataRow[] unitRows = null;
            if (dtTemp != null || dtTemp.Rows.Count != 0)
            {
                unitRows = dtTemp.Rows.Cast<DataRow>().ToArray();
            }
            //PS_MDM_MatBS里的未分类物资项
            StringBuilder matSQL = new StringBuilder();
            matSQL.Append("select Id,MatBSName,MatBSCode from PS_MDM_MatBS where MatBSName like '%未分类%'");
            DataTable matTemp = XCode.DataAccessLayer.DAL.QuerySQL(matSQL.ToString());
            DataRow[] matRows = null;
            if (matTemp != null || matTemp.Rows.Count != 0)
            {
                matRows = matTemp.Rows.Cast<DataRow>().ToArray();
            }


            for (int i = 0; i < ImportData.Rows.Count; i++)
            {
                DataRow item = ImportData.Rows[i];
                //非空判断，从0开始，去掉表头一行，
                if (item["物资编码"] == null || item["物资编码"].ToString().Trim() == "")
                    throw new Exception("第" + (i + 2) + "行,物资编码不能为空");

                Power.Business.IBusinessOperate busiOpt = Power.Business.BusinessFactory.CreateBusinessOperate("SF_CG_PurchasePlanList");
                Power.Business.IBaseBusiness busi = Power.Business.BusinessFactory.CreateBusiness("SF_CG_PurchasePlanList");
                //生成新的编号
                String newId = new Guid().ToString();

                //这行明细的Id
                busi.SetItem("Id", newId);
                busi.SetItem("MasterId", Id);
                busi.SetItem("MatCode", item["物资编码"]);
                busi.SetItem("MatName", item["物资名称"]);
                busi.SetItem("Specification", item["规格型号"]);
                busi.SetItem("PID", item["PID"]);
                busi.SetItem("Model", item["技术参数"]);
                busi.SetItem("MatUnit", item["单位"]);

                //根据物资编码 找到在物资库（PS_MDM_Mat）的Id
                if (unitRows != null)
                {
                    for (int j = 0; j < unitRows.Length; j++)
                    {
                        bool hasFindMat = false;
                        if (unitRows[j][1].Equals(item["物资编码"]))
                        {
                            busi.SetItem("MatId", unitRows[j][0]);
                            busi.SetItem("MatName", unitRows[j][2]);
                            hasFindMat = true;
                            break;
                        }
                        //如果没找到,那就把这条物资新增进物资库,并且挂到未分类下
                        if ((!hasFindMat)&& j== unitRows.Length-1)
                        {
                            Power.Business.IBaseBusiness newMat = Power.Business.BusinessFactory.CreateBusiness("PS_MDM_Mat");
                            string newMatId = Guid.NewGuid().ToString();
                            string MatBS_Guid = matRows == null ? "00000000-0000-0000-0000-000000000000" : matRows[0][0].ToString();
                            string MatBS_Name = matRows == null ? "" : matRows[0][1].ToString();
                            string MatBS_Code = matRows == null ? "" : matRows[0][2].ToString();
                            
                            newMat.SetItem("Id", newMatId);
                            newMat.SetItem("MatBS_Guid", MatBS_Guid);
                            newMat.SetItem("MatBS_Code", MatBS_Code);
                            newMat.SetItem("MatBS_Name", MatBS_Name);

                            //生成一个流水号
                            int codes = Power.Business.BusinessFactory.CreateBusinessOperate("PS_MDM_Mat")
                                .FindAll("MatBS_Guid", matRows[0][0].ToString(), Power.Business.SearchFlag.IgnoreRight).Count;
                            newMat.SetItem("MatCode", MatBS_Code+"."+ codes);
                            
                            newMat.SetItem("MatShortName", item["物资名称"]);
                            newMat.SetItem("MatLongName", item["规格型号"]);
                            newMat.SetItem("MatUnit", item["单位"]);

                            newMat.SetItem("UpdHumId", this.RegHumId);
                            newMat.SetItem("UpdHuman", this.RegHumName);
                            newMat.SetItem("UpdDate",DateTime.Now);
                            newMat.SetItem("RegDate", DateTime.Now);
                            newMat.SetItem("RegHumName", this.RegHumName);
                            newMat.SetItem("RegHumId", this.RegHumId);
                            newMat.SetItem("OwnProjName", this.OwnProjName);
                            newMat.SetItem("OwnProjId", this.OwnProjId);
                            newMat.SetItem("EpsProjId", this.EpsProjId);
                            newMat.SetItem("Stauts", 0);
                            newMat.SetItem("Memo", "新增未分类物资");
                            //保存,如果物资名称为空，就不插入了
                            if(!(item["物资名称"].ToString().Trim() == "")){
                                newMat.Save(System.ComponentModel.DataObjectMethodType.Insert);
                                busi.SetItem("MatCode", MatBS_Code + "." + codes);
                                //把新增物资的Id赋给导入物资
                                busi.SetItem("MatId", newMatId);
                            }
                        }
                    }
                }
                busi.SetItem("Amount", item["请购数量"]);
                if (item["预估单价"] == null || item["预估单价"].ToString().Trim() == "")
                {
                    busi.SetItem("Price", 0);
                }
                else
                {
                    busi.SetItem("Price", item["预估单价"]);
                }
                busi.SetItem("ArrivalDate", item["到货日期"]);
                busi.SetItem("ArrivalDate", item["到货日期"]);
                busi.SetItem("ArrivalAddress", item["到货地点"]);
                busi.SetItem("Supplier", item["厂家/品牌/供应商"]);
                busi.SetItem("Remark", item["备注"]);
                //总价计算下
                double price = item["预估单价"].ToString().Trim() == "" ? 0 : Double.Parse(item["预估单价"].ToString());
                double totalPrice = Double.Parse(item["请购数量"].ToString()) * price;
                busi.SetItem("TotalPrice", totalPrice);
                busi.SetItem("Sequ", i);
                busi.SetItem("PurchaseMajor", this.PurchaseMajor);
                busi.SetItem("UpdDate", DateTime.Now);

                //保存到数据库
                busi.Save(System.ComponentModel.DataObjectMethodType.Insert);

            }
            return "";
        }
        //本方法不用改
        public DataTable ReslutData(string KeyWord, string KeyValue)
        {

            // 上传的数据
            DataTable tempFile = new DataTable();

            //找到目标文件对象
            //System.Web.HttpPostedFile uploadFile = this.Context.Request.Files["PCPath"];

            // 如果有文件, 则读取文件信息
            // if (uploadFile.ContentLength > 0)
            //{
            //System.IO.Stream fileDataStream = uploadFile.InputStream;
            //int fileLength = uploadFile.ContentLength;
            // byte[] fileData = new byte[fileLength];
            //通过KeyWord、Keyword找到PB_DocFiles对应的数据
            string[] keys = { "BOKeyWord", "FolderId" };
            string[] values = { KeyWord, KeyValue };
            Power.Systems.Systems.DocFileBO docfile = Power.Business.BusinessFactory.CreateBusinessOperate("DocFile").FindByKey(keys, values) as Power.Systems.Systems.DocFileBO;

            string Ip = Power.Global.PowerGlobal.FTPIp;
            string Port = Power.Global.PowerGlobal.FTPPort;
            string UserId = Power.Global.PowerGlobal.FTPUserId;
            string UserPwd = Power.Global.PowerGlobal.FTPUserPwd;
            string filePath = "ftp://" + Ip + ":" + Port + docfile.ServerUrl;

            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            byte[] bt = Power.Global.FtpHelper.FtpfileDownLoad(filePath, UserId, UserPwd).GetBuffer();
            foreach (byte item in bt)
            {
                memory.WriteByte(item);
            }

            //System.IO.StreamWriter writer = new System.IO.StreamWriter(memory);
            string fileurl = AppDomain.CurrentDomain.BaseDirectory + "\\" + docfile.Name + docfile.FileExt;
            System.IO.FileStream file = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "\\" + docfile.Name + docfile.FileExt, System.IO.FileMode.OpenOrCreate);
            memory.WriteTo(file);

            file.Dispose();
            //writer.Dispose();
            memory.Dispose();
            //把文件流填充到数组   
            //fileDataStream.Read(fileData, 0, fileLength);
            //解码二进制数组

            DataSet ds = Power.Global.PowerGlobal.Office.ExcelToDataSet(AppDomain.CurrentDomain.BaseDirectory + "\\" + docfile.Name + docfile.FileExt);
            //tempFile = GetExcelDatatable(AppDomain.CurrentDomain.BaseDirectory + "\\" + docfile.Name + docfile.FileExt, "dt1");
            tempFile = ds.Tables[0];
            if (System.IO.File.Exists(fileurl))
                System.IO.File.Delete(fileurl);
            docfile.Delete();
            // uploadFile.SaveAs(string.Format("{0}{1}{2}", tempFile, "Images/", uploadFile.FileName));
            // }
            //tempFile = System.IO.File.ReadAllText(@"C:\Data.txt");

            //从ftp下载文件到本地服务器

            //读取服务器上的文件
            return tempFile;
        }


		#endregion 

    }
 
}