 
 

 using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Data;
 using System.Text;   
 using System.Linq;
  
  


 namespace PowerOn.EPC.SFZH
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
		protected override int DeleteRecord(Dictionary<string, string> KeyValues)
{
   //此处可撰写删除前代码
  //先把统计的删除
            Power.Business.IBusinessList Check = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork").FindAll("DeptId='" + this.DeptId + "' and Month='" + this.Month + "'  and Year='" + this.Year + "'", "", "", 0, 0);
            //判断是否存在月统计
            if (Check.Count > 0)
            {
                Power.Business.IBaseBusiness Checkbbs = Check[0];
                //只有新增可修改
                if (Checkbbs["Status"].ToString() == "0")
                {
                    Power.Business.IBusinessList All = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + this.HumanId + "' and Month='" + this.Month + "'  and Year='" + this.Year + "'", "", "", 0, 0);
                    //明细是否存在
                    if (All.Count > 0)
                    {
                        Power.Business.IBaseBusiness list = All[0];
                        //判断是哪天的数据删除
                        if (this.Day == "1")
                        {
                            list.SetItem("Day1", 0);
                        }
                        if (this.Day == "2")
                        {
                            list.SetItem("Day2", 0);
                        }
                        if (this.Day == "3")
                        {
                            list.SetItem("Day3", 0);
                        }
                        if (this.Day == "4")
                        {
                            list.SetItem("Day4", 0);
                        }
                        if (this.Day == "5")
                        {
                            list.SetItem("Day5", 0);
                        }
                        if (this.Day == "6")
                        {
                            list.SetItem("Day6", 0);
                        }
                        if (this.Day == "7")
                        {
                            list.SetItem("Day7", 0);
                        }
                        if (this.Day == "8")
                        {
                            list.SetItem("Day8", 0);
                        }
                        if (this.Day == "9")
                        {
                            list.SetItem("Day9", 0);
                        }
                        if (this.Day == "10")
                        {
                            list.SetItem("Day10", 0);
                        }
                        if (this.Day == "11")
                        {
                            list.SetItem("Day11", 0);
                        }
                        if (this.Day == "12")
                        {
                            list.SetItem("Day12", 0);
                        }
                        if (this.Day == "13")
                        {
                            list.SetItem("Day13", 0);
                        }
                        if (this.Day == "14")
                        {
                            list.SetItem("Day14", 0);
                        }
                        if (this.Day == "15")
                        {
                            list.SetItem("Day15", 0);
                        }
                        if (this.Day == "16")
                        {
                            list.SetItem("Day16", 0);
                        }
                        if (this.Day == "17")
                        {
                            list.SetItem("Day17", 0);
                        }
                        if (this.Day == "18")
                        {
                            list.SetItem("Day18", 0);
                        }
                        if (this.Day == "19")
                        {
                            list.SetItem("Day19", 0);
                        }
                        if (this.Day == "20")
                        {
                            list.SetItem("Day20", 0);
                        }
                        if (this.Day == "21")
                        {
                            list.SetItem("Day21", 0);
                        }
                        if (this.Day == "22")
                        {
                            list.SetItem("Day22", 0);
                        }
                        if (this.Day == "23")
                        {
                            list.SetItem("Day23", 0);
                        }
                        if (this.Day == "24")
                        {
                            list.SetItem("Day24", 0);
                        }
                        if (this.Day == "25")
                        {
                            list.SetItem("Day25", 0);
                        }
                        if (this.Day == "26")
                        {
                            list.SetItem("Day26", 0);
                        }
                        if (this.Day == "27")
                        {
                            list.SetItem("Day27", 0);
                        }
                        if (this.Day == "28")
                        {
                            list.SetItem("Day28", 0);
                        }
                        if (this.Day == "29")
                        {
                            list.SetItem("Day29", 0);
                        }
                        if (this.Day == "30")
                        {
                            list.SetItem("Day30", 0);
                        }
                        if (this.Day == "31")
                        {
                            list.SetItem("Day31", 0);
                        }
                        list.UpdateSelf();
                    }
                }
                if (Checkbbs["Status"].ToString() == "20")
                {
                    StringBuilder sql = new StringBuilder();
             sql.AppendFormat("select * from pwf_PastNodes where ActName='开始' and WorkInfoID in (select WorkInfoID from pwf_Infos where keyvalue = '{0}') and SequeID = (select MAX(SequeID) from pwf_PastNodes where WorkInfoID in (select WorkInfoID from pwf_Infos where keyvalue = '{1}'))", Checkbbs["Id"], Checkbbs["Id"]);
                    DataTable Checkk = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
                    if (Checkk.Rows.Count == 0)
                    {
                        throw new Exception("月考勤统计已送审，不可修改！");
                    }
                    else
                    {
                        DataRow dw = Checkk.Rows[0];
                        if (Checkbbs["RegHumId"].ToString() != dw["UserId"].ToString())
                        {
                            throw new Exception("月考勤统计已送审，不可修改！");
                        }
                        else{
                            Power.Business.IBusinessList All = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + this.HumanId + "' and Month='" + this.Month + "'  and Year='" + this.Year + "'", "", "", 0, 0);
                            //明细是否存在
                            if (All.Count > 0)
                            {
                                Power.Business.IBaseBusiness list = All[0];
                                //判断是哪天的数据删除
                                if (this.Day == "1")
                                {
                                    list.SetItem("Day1", 0);
                                }
                                if (this.Day == "2")
                                {
                                    list.SetItem("Day2", 0);
                                }
                                if (this.Day == "3")
                                {
                                    list.SetItem("Day3", 0);
                                }
                                if (this.Day == "4")
                                {
                                    list.SetItem("Day4", 0);
                                }
                                if (this.Day == "5")
                                {
                                    list.SetItem("Day5", 0);
                                }
                                if (this.Day == "6")
                                {
                                    list.SetItem("Day6", 0);
                                }
                                if (this.Day == "7")
                                {
                                    list.SetItem("Day7", 0);
                                }
                                if (this.Day == "8")
                                {
                                    list.SetItem("Day8", 0);
                                }
                                if (this.Day == "9")
                                {
                                    list.SetItem("Day9", 0);
                                }
                                if (this.Day == "10")
                                {
                                    list.SetItem("Day10", 0);
                                }
                                if (this.Day == "11")
                                {
                                    list.SetItem("Day11", 0);
                                }
                                if (this.Day == "12")
                                {
                                    list.SetItem("Day12", 0);
                                }
                                if (this.Day == "13")
                                {
                                    list.SetItem("Day13", 0);
                                }
                                if (this.Day == "14")
                                {
                                    list.SetItem("Day14", 0);
                                }
                                if (this.Day == "15")
                                {
                                    list.SetItem("Day15", 0);
                                }
                                if (this.Day == "16")
                                {
                                    list.SetItem("Day16", 0);
                                }
                                if (this.Day == "17")
                                {
                                    list.SetItem("Day17", 0);
                                }
                                if (this.Day == "18")
                                {
                                    list.SetItem("Day18", 0);
                                }
                                if (this.Day == "19")
                                {
                                    list.SetItem("Day19", 0);
                                }
                                if (this.Day == "20")
                                {
                                    list.SetItem("Day20", 0);
                                }
                                if (this.Day == "21")
                                {
                                    list.SetItem("Day21", 0);
                                }
                                if (this.Day == "22")
                                {
                                    list.SetItem("Day22", 0);
                                }
                                if (this.Day == "23")
                                {
                                    list.SetItem("Day23", 0);
                                }
                                if (this.Day == "24")
                                {
                                    list.SetItem("Day24", 0);
                                }
                                if (this.Day == "25")
                                {
                                    list.SetItem("Day25", 0);
                                }
                                if (this.Day == "26")
                                {
                                    list.SetItem("Day26", 0);
                                }
                                if (this.Day == "27")
                                {
                                    list.SetItem("Day27", 0);
                                }
                                if (this.Day == "28")
                                {
                                    list.SetItem("Day28", 0);
                                }
                                if (this.Day == "29")
                                {
                                    list.SetItem("Day29", 0);
                                }
                                if (this.Day == "30")
                                {
                                    list.SetItem("Day30", 0);
                                }
                                if (this.Day == "31")
                                {
                                    list.SetItem("Day31", 0);
                                }
                                list.UpdateSelf();
                            }
                        }
                    }
                }
                if (Checkbbs["Status"].ToString() == "50")
                {
                    throw new Exception("月考勤统计已批准，不可修改！");
                }
            }
 var result = base.DeleteRecord(KeyValues);  

  //此处可撰写删除后代码   

return result;

}
protected override string SaveRecord(System.ComponentModel.DataObjectMethodType methodType)
{
    //此处可撰写保存前代码
  Power.Business.IBusinessList bbs = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork").FindAll("DeptId='"+this.MasterId+ "' and Month='" + this.Month + "'  and Year='" + this.Year + "'", "", "", 0, 0);
            if (bbs.Count > 0)
            {
                Power.Business.IBaseBusiness Checkbbs = bbs[0];
                if (Checkbbs["Status"].ToString() == "20")
                {
                    StringBuilder sql = new StringBuilder();
        sql.AppendFormat("select * from pwf_PastNodes where ActName='开始' and WorkInfoID in (select WorkInfoID from pwf_Infos where keyvalue = '{0}') and SequeID = (select MAX(SequeID) from pwf_PastNodes where WorkInfoID in (select WorkInfoID from pwf_Infos where keyvalue = '{1}'))", Checkbbs["Id"], Checkbbs["Id"]);
                    DataTable Checkk = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
                     if (Checkk.Rows.Count == 0)
                    {
                        throw new Exception("月考勤统计已送审，不可修改！");
                    }
                    else
                    {
                        DataRow dw = Checkk.Rows[0];
                        if (Checkbbs["RegHumId"].ToString() != dw["UserId"].ToString())
                        {
                            throw new Exception("月考勤统计已送审，不可修改！");
                        }
                    }
                }
                if(Checkbbs["Status"].ToString() == "50")
                {
                    throw new Exception("月考勤统计已批准，不可修改！");
                }
            }
 var result = base.SaveRecord(methodType);  

  //此处可撰写保存后代码   

return result;

}


		#endregion 

		#region 用户自定义代码
		    public string getHumans(string treeId, string dayTime, double Year, double Month,double Day)
        {
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("select * from v_DeptUser where DeptId='" + treeId + "' and SecondDeptId ='00000000-0000-0000-0000-000000000000' or SecondDeptId = DeptId");
            DataTable dtTemp = XCode.DataAccessLayer.DAL.QuerySQL(sbSQL.ToString());
            if (dtTemp != null && dtTemp.Rows.Count != 0)
            {
                for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                {
                    Power.Business.IBusinessList list = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("HumanId='" + dtTemp.Rows[i]["HumanId"] + "' and DayTime='"+ dayTime + "'", "", "", 0, 0);
                    if (list.Count == 0)
                    {
                        Guid MainId = Guid.NewGuid();
                        Power.Business.IBaseBusiness Newbbs = Power.Business.BusinessFactory.CreateBusiness("SF_HumanCheckOnWork");
                        Newbbs.Init();
                        Newbbs.SetItem("Id", MainId);
                        Newbbs.SetItem("HumanId", dtTemp.Rows[i]["HumanId"]);
                        Newbbs.SetItem("MasterId", treeId);
                        Newbbs.SetItem("DeptId", dtTemp.Rows[i]["DeptId"]);
                        Newbbs.SetItem("DayTime", Convert.ToDateTime(dayTime));
                        Newbbs.SetItem("HumanCode", dtTemp.Rows[i]["Code"]);
                        Newbbs.SetItem("HumanName", dtTemp.Rows[i]["Name"]);
                        Newbbs.SetItem("Year", Year);
                        Newbbs.SetItem("Month", Month);
                        Newbbs.SetItem("Day", Day);
                        Newbbs.Save(System.ComponentModel.DataObjectMethodType.Insert);
                    }     
                }
            }
            return "已拉取"+Convert.ToString(dtTemp.Rows.Count)+"条数据";
        }
          /// <summary>
         /// 保存时，把考勤填报的数据同步更新到考勤统计表里面
         /// </summary>
         /// <param name="DayTime">填报日期</param>
         /// <param name="month">月</param>
         /// <param name="Day">日</param>
         /// <param name="Year">年</param>
        public void CheckWorkAll(string DayTime,double Month,double Day,double Year,string DeptId)
        {
            //通过年、月查找SF_ZH_CheckWork，如果没有找到就不赋值，如果找到就进行赋值操作
            Power.Business.IBusinessList Check = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork").FindAll("Year='" + Year + "' and Month='" + Month + "' and DeptId='"+ DeptId + "'", "", "", 0, 0);
            if (Check.Count != 0)
            {
                

                //通过时间找到对应的考勤数据
                DateTime DayTime1 = Convert.ToDateTime(DayTime);
                Power.Business.IBaseBusiness Checkbbs = Check[0];
                //判断是有是新增状态，只有新增状态才可以进行赋值
                if (Checkbbs["Status"].ToString() != "50")
                {
                    Power.Business.IBusinessList bbs = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("DayTime='" + DayTime + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
                    //通过循环增加人员
                    foreach (Power.Business.IBaseBusiness item in bbs)
                    {
                        //通过人员Id、月份、年份，在统计表里面进行查询是否能找到对应的人员
                        Power.Business.IBusinessList Humlist = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + item["HumanId"] + "' and Month='" + Month + "' and Year='" + Year + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
                        //如果没有，就加入到考勤统计表里面
                        if (Humlist.Count == 0)
                        {
                            Power.Business.IBaseBusiness Allbbs = Power.Business.BusinessFactory.CreateBusiness("SF_ZH_CheckWork_All");
                            Allbbs.SetItem("HumanId", item["HumanId"]);
                            Allbbs.SetItem("MasterId", Checkbbs["Id"]);
                            Allbbs.SetItem("DeptId", item["DeptId"]);
                            Allbbs.SetItem("DayTime", DayTime);
                            Allbbs.SetItem("HumanCode", item["HumanCode"]);
                            Allbbs.SetItem("HumanName", item["HumanName"]);
                            Allbbs.SetItem("CheckOnWorkType", item["CheckOnWorkType"]);
                            Allbbs.SetItem("Month", Month);
                            Allbbs.SetItem("Year", Year);
                            Allbbs.Save(System.ComponentModel.DataObjectMethodType.Insert);
                        }
                    }
                    //通过Day的值进行判断更新数据
                    foreach (Power.Business.IBaseBusiness item in bbs)
                    {
                        //通过人员Id、月份、年份，在统计表里面进行查询是否能找到对应的人员
                        Power.Business.IBusinessList Humlist = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + item["HumanId"] + "' and Month='" + Month + "' and Year='" + Year + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);

                        if (Humlist.Count > 0)
                        {
                            if (Day == 1)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day1", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 2)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day2", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 3)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day3", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 4)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day4", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 5)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day5", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 6)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day6", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 7)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day7", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 8)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day8", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 9)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day9", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 10)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day10", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 11)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day11", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 12)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day12", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 13)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day13", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 14)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day14", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 15)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day15", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 16)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day16", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 17)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day17", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 18)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day18", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 19)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day19", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 20)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day20", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 21)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day21", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 22)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day22", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 23)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day23", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 24)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day24", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 25)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day25", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 26)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day26", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 27)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day27", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 28)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day28", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 29)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day29", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 30)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day30", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            if (Day == 31)
                            {
                                Power.Business.IBaseBusiness Day1 = Humlist[0];
                                Day1.SetItem("Day31", item["CheckOnWorkType"]);
                                Day1.UpdateSelf();
                            }
                            //取得月份第一天的时间
                            DateTime StartDate = FirstDayOfMonth(DayTime1);
                            //月份最后一天的时间
                            DateTime EndDate = LastDayOfMonth(DayTime1);
                            Power.Business.IBaseBusiness Day2 = Humlist[0];
                            //查询当前月有多少白班
                            Power.Business.IBusinessList DayShift1 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='1' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number = DayShift1.Count;
                            Day2.SetItem("DayShift1", number);
                            //查询当前月有多少中班
                            Power.Business.IBusinessList DayShift2 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='2' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number2 = DayShift2.Count;
                            Day2.SetItem("DayShift2", number2);
                            //查询当前月有多少夜班
                            Power.Business.IBusinessList DayShift3 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='3' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number3 = DayShift3.Count;
                            Day2.SetItem("DayShift3", number3);
                            //查询当前月有多少加班
                            Power.Business.IBusinessList DayShift4 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='4' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number4 = DayShift4.Count;
                            Day2.SetItem("DayShift4", number4);
                            //查询当前月有多少事假
                            Power.Business.IBusinessList DayShift5 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='5' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number5 = DayShift5.Count;
                            Day2.SetItem("DayShift5", number5);
                            //查询当前月有多少病假
                            Power.Business.IBusinessList DayShift6 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='6' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number6 = DayShift6.Count;
                            Day2.SetItem("DayShift6", number6);
                            //查询当前月有多少休假
                            Power.Business.IBusinessList DayShift7 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='7' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number7 = DayShift7.Count;
                            Day2.SetItem("DayShift7", number7);
                            //查询当前月有多少旷工
                            Power.Business.IBusinessList DayShift8 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='8' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                            int number8 = DayShift8.Count;
                            Day2.SetItem("DayShift8", number8);
                            //合计：白班+中班+夜班+加班
                            int number1 = number + number2 + number3 + number4;
                            Day2.SetItem("Total", number1);
                            Day2.UpdateSelf();
                        }
                    }
                }
            }
           
       }
        /// <summary>
        /// 点击按钮，确定生成月考勤统计
        /// 1、先查找是否已存在
        /// 2、不存在，新增，并且把当前月的明细全部更新到统计中
        /// </summary>
        /// <param name="DayTime"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        public string OnCheckWorkAll(string DayTime, double Month, double Day, double Year,string DeptId)
        {
            //查找当前年、月的所有考勤记录
            Guid MainId = Guid.NewGuid();
            Power.Business.IBusinessList Humlist= Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("Year='" + Year + "' and Month='" + Month + "'", "", "", 0, 0);
            //查找当前部门，当前时间的所有考勤记录
            Power.Business.IBusinessList Humlist1 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("DayTime='" + DayTime + "' and DeptId='"+ DeptId + "'", "", "", 0, 0);
            //查找月考勤统计
           Power.Business.IBusinessList Check = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork").FindAll("Year='" + Year + "' and Month='" + Month + "' and DeptId='"+ DeptId + "'", "", "", 0, 0);
            //判断是否存在
            if (Check.Count != 0)
            {
                throw new Exception ("月考勤统计已生成，不可重复生成!");
            }
            else
            {
                //新增月考勤统计
                //Power.Business.IBaseBusiness Hum = Humlist1[0];
                Power.Business.IBaseBusiness bbs = Power.Business.BusinessFactory.CreateBusiness("SF_ZH_CheckWork");
                //查找部门名称
                Power.Business.IBaseBusiness Department = Power.Business.BusinessFactory.CreateBusinessOperate("Department").FindByKey(DeptId);
                
                bbs.SetItem("Id", MainId);
                bbs.SetItem("Code", Year+"-"+Month);
                bbs.SetItem("Title", Year+"年"+Month+"月"+Department["Name"].ToString()+"考勤统计");
                bbs.SetItem("DeptId", DeptId);
                bbs.SetItem("Department", Department["Name"]);
                bbs.SetItem("Year", Year);
                bbs.SetItem("Month", Month);
                bbs.Save(System.ComponentModel.DataObjectMethodType.Insert);
                //给月考勤统计添加明细
                //通过年、月找到对应的考勤数据
                DateTime DayTime1 = Convert.ToDateTime(DayTime);
                Power.Business.IBusinessList Checkbbs = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("Month='" + Month + "' and Year='" + Year + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
                 StringBuilder sql = new StringBuilder();
                sql.AppendFormat("select distinct HumanId,DeptId,HumanCode,HumanName from SF_HumanCheckOnWork where Month={0} and Year={1} and DeptId in (select Id from PB_Department where id='{2}' or ParentId='{3}')", Month,Year,DeptId,DeptId);
                DataTable Checkbbs1 = XCode.DataAccessLayer.DAL.QuerySQL(sql.ToString());
                //通过循环增加人员
                Power.Business.IBusinessList Allbbs1 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("2=1", "", "", 0, 0);
                for (int i = 0; i < Checkbbs1.Rows.Count; i++)
                {
                    DataRow row = Checkbbs1.Rows[i];
                    //通过人员Id、月份、年份，在统计表里面进行查询是否能找到对应的人员
                    Power.Business.IBusinessList HumChecklist = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + row["HumanId"] + "' and MasterId='" + MainId + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
                    //如果没有，就加入到考勤统计表里面
                    if (HumChecklist.Count == 0)
                    {
                        Power.Business.IBaseBusiness Allbbs = Power.Business.BusinessFactory.CreateBusiness("SF_ZH_CheckWork_All");
                        Allbbs.SetItem("HumanId", row["HumanId"]);
                        Allbbs.SetItem("DeptId", row["DeptId"]);
                        Allbbs.SetItem("DayTime", DayTime);
                        Allbbs.SetItem("HumanCode", row["HumanCode"]);
                        Allbbs.SetItem("HumanName", row["HumanName"]);
                        Allbbs.SetItem("CheckOnWorkType", 0);
                        Allbbs.SetItem("Month", Month);
                        Allbbs.SetItem("Year", Year);
                        Allbbs.SetItem("MasterId", MainId);
                        Allbbs1.Add(Allbbs);
                    }
                }
                Allbbs1.Save(true);
                //foreach (Power.Business.IBaseBusiness item in Checkbbs)
                //{
                //    //通过人员Id、月份、年份，在统计表里面进行查询是否能找到对应的人员
                //    Power.Business.IBusinessList HumChecklist = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + item["HumanId"] + "' and MasterId='" + MainId + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);
                //    //如果没有，就加入到考勤统计表里面
                //    if (HumChecklist.Count == 0)
                //    {
                //        Power.Business.IBaseBusiness Allbbs = Power.Business.BusinessFactory.CreateBusiness("SF_ZH_CheckWork_All");
                //        Allbbs.SetItem("HumanId", item["HumanId"]);
                //        Allbbs.SetItem("DeptId", item["MasterId"]);
                //        Allbbs.SetItem("DayTime", DayTime);
                //        Allbbs.SetItem("HumanCode", item["HumanCode"]);
                //        Allbbs.SetItem("HumanName", item["HumanName"]);
                //        Allbbs.SetItem("CheckOnWorkType", item["CheckOnWorkType"]);
                //        Allbbs.SetItem("Month", Month);
                //        Allbbs.SetItem("Year", Year);
                //        Allbbs.SetItem("MasterId", MainId);
                //        Allbbs1.Add(Allbbs);
                //    }
                //}
                //Allbbs1.Save(true);
                //通过Day的值进行判断更新数据
                foreach (Power.Business.IBaseBusiness item in Checkbbs)
                {
                    //通过人员Id、月份、年份，在统计表里面进行查询是否能找到对应的人员
                    Power.Business.IBusinessList HumChecklist = Power.Business.BusinessFactory.CreateBusinessOperate("SF_ZH_CheckWork_All").FindAll("HumanId='" + item["HumanId"] + "'  and MasterId='" + MainId + "'", "", "", 0, 0, Power.Business.SearchFlag.IgnoreRight);

                    if (HumChecklist.Count > 0)
                    {
                         if (Convert.ToDouble(item["Day"].ToString()) == 1)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day1", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 2)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day2", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 3)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day3", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 4)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day4", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 5)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day5", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 6)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day6", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 7)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day7", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 8)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day8", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 9)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day9", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 10)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day10", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 11)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day11", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 12)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day12", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 13)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day13", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 14)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day14", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 15)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day15", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 16)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day16", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 17)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day17", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 18)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day18", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 19)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day19", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 20)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day20", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 21)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day21", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 22)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day22", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 23)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day23", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 24)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day24", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 25)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day25", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 26)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day26", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 27)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day27", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 28)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day28", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 29)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day29", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 30)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day30", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        if (Convert.ToDouble(item["Day"].ToString()) == 31)
                        {
                            Power.Business.IBaseBusiness Day1 = HumChecklist[0];
                            Day1.SetItem("Day31", item["CheckOnWorkType"]);
                            Day1.UpdateSelf();
                        }
                        //取得月份第一天的时间
                        DateTime StartDate = FirstDayOfMonth(DayTime1);
                        //月份最后一天的时间
                        DateTime EndDate = LastDayOfMonth(DayTime1);
                        Power.Business.IBaseBusiness Day2 = HumChecklist[0];
                        //查询当前月有多少白班
                        Power.Business.IBusinessList DayShift1 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='1' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number = DayShift1.Count;
                        Day2.SetItem("DayShift1", number);
                        //查询当前月有多少中班
                        Power.Business.IBusinessList DayShift2 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='2' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number2 = DayShift2.Count;
                        Day2.SetItem("DayShift2", number2);
                        //查询当前月有多少夜班
                        Power.Business.IBusinessList DayShift3 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='3' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number3 = DayShift3.Count;
                        Day2.SetItem("DayShift3", number3);
                        //查询当前月有多少加班
                        Power.Business.IBusinessList DayShift4 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='4' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number4 = DayShift4.Count;
                        Day2.SetItem("DayShift4", number4);
                        //查询当前月有多少事假
                        Power.Business.IBusinessList DayShift5 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='5' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number5 = DayShift5.Count;
                        Day2.SetItem("DayShift5", number5);
                        //查询当前月有多少病假
                        Power.Business.IBusinessList DayShift6 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='6' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number6 = DayShift6.Count;
                        Day2.SetItem("DayShift6", number6);
                        //查询当前月有多少休假
                        Power.Business.IBusinessList DayShift7 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='7' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number7 = DayShift7.Count;
                        Day2.SetItem("DayShift7", number7);
                        //查询当前月有多少旷工
                        Power.Business.IBusinessList DayShift8 = Power.Business.BusinessFactory.CreateBusinessOperate("SF_HumanCheckOnWork").FindAll("(DayTime between '" + StartDate + "' and '" + EndDate + "') and CheckOnWorkType='8' and HumanId='" + item["HumanId"] + "'", "", "", 0, 0);
                        int number8 = DayShift8.Count;
                        Day2.SetItem("DayShift8", number8);
                        //合计：白班+中班+夜班+加班
                        int number1 = number + number2 + number3 + number4;
                        Day2.SetItem("Total", number1);
                        Day2.UpdateSelf();
                    }
                }
            }
            return MainId.ToString();
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