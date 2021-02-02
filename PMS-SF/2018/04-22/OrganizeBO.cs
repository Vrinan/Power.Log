 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Data;
 using System.Text;   
 using System.Linq;
  
  


 namespace PowerOn.EPC.StdSystem
{  
      /// <summary>
    /// 组织单位 消息申明
    /// </summary>
     public partial class OrganizeBO 
    {
	    #region 用户自定义代码，相应外部消息域
		

		#endregion 
    }

    /// <summary>
    /// 组织单位
    /// </summary>
     public partial class OrganizeBO<TBusiness> 
    {
        #region 响应内部事件
		

		#endregion 

		#region 用户自定义代码
		public string DocFilesFindAll(string MainIds)
        {
            ////fun1
            //string ReIds = "";
            //string[] ids = MainIds.Split(",");
            //foreach (string item in ids)
            //{
            //    //Power.Business.IBaseBusiness file = Power.Business.BusinessFactory.CreateBusinessOperate("FileOperate").FindByKey(item);
            //    Power.Business.IBusinessList files = Power.Business.BusinessFactory.CreateBusinessOperate("FileOperate").FindAll("FolderId = '" + item + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
            //    foreach (Power.Business.IBaseBusiness itemDtl in files)
            //    {
            //        Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusinessOperate("FileOperate").FindByKey(itemDtl["Id"], Power.Business.SearchFlag.IgnoreRight);
            //        ReIds += bbs["Id"] + ",";
            //    }
            //}
            //return "";


            //fun2
            string ids = "";
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("select t.* from (select stuff((select ','+ CONVERT(varchar(8000),Id) from PB_DocFiles where FolderId in (" + MainIds + ") for xml path('')),1,1,'') as idColumns) t");
            DataTable dtTemp = XCode.DataAccessLayer.DAL.QuerySQL(sbSQL.ToString());
            if (dtTemp != null || dtTemp.Rows.Count != 0)
            {
                //DataRow[] ids = dtTemp.Select("");
                ids = Convert.ToString(dtTemp.Rows[0].ItemArray[0]);
            }
            return ids;
        }


		#endregion 

    }
 
}