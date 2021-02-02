 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdAPP
{
    /// <summary>
    /// APP施工日志
    /// </summary>
    public class PS_APP_ConstructionLogDO : PS_APP_ConstructionLogDO<PS_APP_ConstructionLogDO>
    {

    }

	/// <summary>
    /// APP施工日志
    /// </summary>
	  [BindEntity(KeyWord="PS_APP_ConstructionLog",EntityType = typeof(Power.Systems.StdAPP.PS_APP_ConstructionLogDO),Description = "APP施工日志"  )] 

	 [BindTable( "PS_APP_ConstructionLog", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_APP_ConstructionLog", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_APP_ConstructionLog",Description="")]

    public   class PS_APP_ConstructionLogDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdAPP.PS_APP_ConstructionLogDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.DateTime _WorkDate;
 /// <summary>
 /// 日期
 /// </summary>
 [BindColumn(2,"a", "WorkDate", "日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime WorkDate  { get { return _WorkDate; } set { _WorkDate = value; } }

 private System.String _Weather;
 /// <summary>
 /// 天气
 /// </summary>
 [BindColumn(3,"a", "Weather", "天气","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Weather  { get { return _Weather; } set { _Weather = value; } }

 private System.Double _MinTemperature;
 /// <summary>
 /// 最低温度
 /// </summary>
 [BindColumn(4,"a", "MinTemperature", "最低温度","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double MinTemperature  { get { return _MinTemperature; } set { _MinTemperature = value; } }

 private System.Double _MaxTemperature;
 /// <summary>
 /// 最高温度
 /// </summary>
 [BindColumn(5,"a", "MaxTemperature", "最高温度","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double MaxTemperature  { get { return _MaxTemperature; } set { _MaxTemperature = value; } }

 private System.String _ConstructionTeam;
 /// <summary>
 /// 施工班组
 /// </summary>
 [BindColumn(6,"a", "ConstructionTeam", "施工班组","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ConstructionTeam  { get { return _ConstructionTeam; } set { _ConstructionTeam = value; } }

 private System.Int32 _ConstructionNumber;
 /// <summary>
 /// 施工人数
 /// </summary>
 [BindColumn(7,"a", "ConstructionNumber", "施工人数","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 ConstructionNumber  { get { return _ConstructionNumber; } set { _ConstructionNumber = value; } }

 private System.String _ConstructionSite;
 /// <summary>
 /// 施工部位
 /// </summary>
 [BindColumn(8,"a", "ConstructionSite", "施工部位","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String ConstructionSite  { get { return _ConstructionSite; } set { _ConstructionSite = value; } }

 private System.String _ConstructionContent;
 /// <summary>
 /// 工作内容
 /// </summary>
 [BindColumn(9,"a", "ConstructionContent", "工作内容","", "NCHAR", 4000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =4000 )]
 public  System.String ConstructionContent  { get { return _ConstructionContent; } set { _ConstructionContent = value; } }

 private System.String _Question;
 /// <summary>
 /// 存在问题
 /// </summary>
 [BindColumn(10,"a", "Question", "存在问题","", "NCHAR", 4000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =4000 )]
 public  System.String Question  { get { return _Question; } set { _Question = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(11,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Int32 _Status;
 /// <summary>
 /// 表单状态；0新增，20审批中，35生效，40终止，50批准
 /// </summary>
 [BindColumn(12,"a", "Status", "表单状态；0新增，20审批中，35生效，40终止，50批准","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(13,"a", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(14,"a", "RegHumName", "录入人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(15,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 录入人岗位Id
 /// </summary>
 [BindColumn(16,"a", "RegPosiId", "录入人岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 录入人部门Id
 /// </summary>
 [BindColumn(17,"a", "RegDeptId", "录入人部门Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 记录所属EPS节点Id
 /// </summary>
 [BindColumn(18,"a", "EpsProjId", "记录所属EPS节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 删除人Id
 /// </summary>
 [BindColumn(19,"a", "RecycleHumId", "删除人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(20,"a", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(21,"a", "UpdHumName", "最后更新人名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(22,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 批准人Id
 /// </summary>
 [BindColumn(23,"a", "ApprHumId", "批准人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 批准人名称
 /// </summary>
 [BindColumn(24,"a", "ApprHumName", "批准人名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 批准日期
 /// </summary>
 [BindColumn(25,"a", "ApprDate", "批准日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(26,"a", "Memo", "备注","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 所属项目Id
 /// </summary>
 [BindColumn(27,"a", "OwnProjId", "所属项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 所属项目名称
 /// </summary>
 [BindColumn(28,"a", "OwnProjName", "所属项目名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

      
		#endregion 

		#region 获取/设置 字段值
		 /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">属性名</param>
        /// <return>属性值</return>
        public override object this[string name]
        {
            get
            {
			  name = name.ToUpper();
			    if (name == "ID")
{
return _Id;
}
if (name == "WORKDATE")
{
return _WorkDate;
}
if (name == "WEATHER")
{
return _Weather;
}
if (name == "MINTEMPERATURE")
{
return _MinTemperature;
}
if (name == "MAXTEMPERATURE")
{
return _MaxTemperature;
}
if (name == "CONSTRUCTIONTEAM")
{
return _ConstructionTeam;
}
if (name == "CONSTRUCTIONNUMBER")
{
return _ConstructionNumber;
}
if (name == "CONSTRUCTIONSITE")
{
return _ConstructionSite;
}
if (name == "CONSTRUCTIONCONTENT")
{
return _ConstructionContent;
}
if (name == "QUESTION")
{
return _Question;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGPOSIID")
{
return _RegPosiId;
}
if (name == "REGDEPTID")
{
return _RegDeptId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "RECYCLEHUMID")
{
return _RecycleHumId;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "APPRHUMID")
{
return _ApprHumId;
}
if (name == "APPRHUMNAME")
{
return _ApprHumName;
}
if (name == "APPRDATE")
{
return _ApprDate;
}
if (name == "MEMO")
{
return _Memo;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "WORKDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _WorkDate = System.Convert.ToDateTime(value);return;
}
if (name == "WEATHER")
{
 _Weather = System.Convert.ToString(value);return;
}
if (name == "MINTEMPERATURE")
{
 _MinTemperature = System.Convert.ToDouble(value);return;
}
if (name == "MAXTEMPERATURE")
{
 _MaxTemperature = System.Convert.ToDouble(value);return;
}
if (name == "CONSTRUCTIONTEAM")
{
 _ConstructionTeam = System.Convert.ToString(value);return;
}
if (name == "CONSTRUCTIONNUMBER")
{
 _ConstructionNumber = System.Convert.ToInt32(value);return;
}
if (name == "CONSTRUCTIONSITE")
{
 _ConstructionSite = System.Convert.ToString(value);return;
}
if (name == "CONSTRUCTIONCONTENT")
{
 _ConstructionContent = System.Convert.ToString(value);return;
}
if (name == "QUESTION")
{
 _Question = System.Convert.ToString(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToInt32(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGPOSIID")
{
 _RegPosiId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGDEPTID")
{
 _RegDeptId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "RECYCLEHUMID")
{
 _RecycleHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "APPRHUMID")
{
 _ApprHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "APPRHUMNAME")
{
 _ApprHumName = System.Convert.ToString(value);return;
}
if (name == "APPRDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ApprDate = System.Convert.ToDateTime(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}