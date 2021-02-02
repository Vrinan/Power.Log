 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Data;
 using System.Text;   
 using System.Linq;
  
  


 namespace PowerOn.EPC.SFComplex
{  
      /// <summary>
    /// 部门人员签到 消息申明
    /// </summary>
     public partial class SF_HumanCheckOnWorkBO 
    {
	    #region 用户自定义代码，相应外部消息域
		

		#endregion 
    }

    /// <summary>
    /// 部门人员签到
    /// </summary>
     public partial class SF_HumanCheckOnWorkBO<TBusiness> 
    {
        #region 响应内部事件
		

		#endregion 

		#region 用户自定义代码
		public string getHumans(string treeId, string dayTime)
        {
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("select * from v_DeptUser where DeptId='" + treeId + "'");
            DataTable dtTemp = XCode.DataAccessLayer.DAL.QuerySQL(sbSQL.ToString());
            if (dtTemp != null && dtTemp.Rows.Count != 0)
            {
                for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                {
                    Guid MainId = Guid.NewGuid();
                    Power.Business.IBaseBusiness Newbbs = Power.Business.BusinessFactory.CreateBusiness("SF_HumanCheckOnWork");
                    Newbbs.Init();
                    Newbbs.SetItem("Id", MainId);
                    Newbbs.SetItem("HumanId", dtTemp.Rows[i]["HumanId"]);
                    Newbbs.SetItem("MasterId", dtTemp.Rows[i]["DeptId"]);
                    Newbbs.SetItem("DayTime", Convert.ToDateTime(dayTime));
                    Newbbs.SetItem("HumanCode", dtTemp.Rows[i]["Code"]);
                    Newbbs.SetItem("HumanName", dtTemp.Rows[i]["Name"]);
                    Newbbs.Save(System.ComponentModel.DataObjectMethodType.Insert);
                }
            }
            return "已拉取"+Convert.ToString(dtTemp.Rows.Count)+"条数据";
        }


		#endregion 

    }
 
}