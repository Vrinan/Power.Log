 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Data;
 using System.Text;   
 using System.Linq;
  
  


 namespace PowerOn.EPC.SFZH
{  
      /// <summary>
    /// 加班申请 消息申明
    /// </summary>
     public partial class SF_ZH_OverTimeBO 
    {
	    #region 用户自定义代码，相应外部消息域
		

		#endregion 
    }

    /// <summary>
    /// 加班申请
    /// </summary>
     public partial class SF_ZH_OverTimeBO<TBusiness,TSF_ZH_OverTime_listBO> 
    {
        #region 响应内部事件
		public override void EndFlowChange(Power.IWorkFlow.WorkFlow.EFlowOperate flowOperate,Power.IWorkFlow.WorkFlow.ERecordStatus recordStatus,System.Collections.Hashtable hasFlowInfo)
{
    //此处可撰写流程状态改变后代码
//流程审批完成自动给备案人赋值
            if (recordStatus == Power.IWorkFlow.WorkFlow.ERecordStatus.Finish)
            {
                UpdareMonthTime(this.Id.ToString(), this.RegDate.ToString());
            }
   

return  ;

}


		#endregion 

		#region 用户自定义代码
		 /// <summary>
        /// 更新本月加班累计时长
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="RegDate"></param>
        /// <returns></returns>
        public string UpdareMonthTime(string Id,string RegDate)
        {
            DateTime DayTime = Convert.ToDateTime(RegDate);
            Power.Business.IBusinessOperate piOpt = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_OverTime");
            Power.Business.IBaseBusiness pi = piOpt.FindByKey(Id); 
            double sum = 0.0;
            DateTime StartDate = FirstDayOfMonth(DayTime);
            DateTime EndDate = LastDayOfMonth(DayTime);
            //Power.Business.IBusinessList piList = piOpt.FindAll(" Mouth='" + pi["Mouth"] + "' and HumId='"+pi["HumId"] +"' and OverType='"+pi["OverType"]+"'", "RegDate", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);          
            //foreach (Power.Business.IBaseBusiness piItem in piList)
            //{
            //    sum += Convert.ToDouble(piItem["OverTime"].ToString());
            //}
            //foreach (Power.Business.IBaseBusiness piItem in piList)
            //{
            //    piItem.SetItem("MouthTime", sum);
            //    piItem.Save(System.ComponentModel.DataObjectMethodType.Update, false);
            //}
              StringBuilder sql = new StringBuilder();
            sql.Append("select a.Id ,a.HumId,a.OverType,b.Id as ListId,b.OverDate,b.OverDate1,b.OverTime ");
            sql.Append("from SF_ZH_Overtime a inner join sf_zh_overtime_list b on a.id=b.masterid");
            sql.AppendFormat(" where a.Status=50 and HumId='{0}' and (b.OverDate between '{1}' and '{2}') and OverType='{3}' and a.Status=50 ", pi["HumId"], StartDate, EndDate, pi["OverType"]);
            DataTable OverTime = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
            for(int i=0; i <= OverTime.Rows.Count-1; i++)
            {
                DataRow dw = OverTime.Rows[i];
                sum = sum + Convert.ToDouble(dw["OverTime"].ToString());
            }
            Power.Business.IBusinessList piList = piOpt.FindAll(" Mouth='" + pi["Mouth"] + "' and HumId='" + pi["HumId"] + "' and OverType='" + pi["OverType"] + "'", "RegDate", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
            foreach (Power.Business.IBaseBusiness piItem in piList)
            {
                piItem.SetItem("MouthTime", sum);
                piItem.Save(System.ComponentModel.DataObjectMethodType.Update, false);
            }
            return sum.ToString();
        }
        /// <summary>
        /// 取得某月的第一天
        /// </summary>
        /// <param name="datetime">要取得月份第一天的时间</param>
        /// <returns></returns>
        private DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }
        /// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        private DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }


		#endregion 

    }
 
}