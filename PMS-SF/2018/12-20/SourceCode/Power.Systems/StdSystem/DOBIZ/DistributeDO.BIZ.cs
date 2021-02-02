 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 表单分发
    /// </summary>
    public class DistributeDO : DistributeDO<DistributeDO>
    {

    }

	/// <summary>
    /// 表单分发
    /// </summary>
	  [BindEntity(KeyWord="Distribute",EntityType = typeof(Power.Systems.StdSystem.DistributeDO),Description = "表单分发"  )] 

	 [BindTable( "PB_DistributeList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_DistributeList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_DistributeList",Description="")]

    public   class DistributeDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.DistributeDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =true,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 对应主表关键词
 /// </summary>
 [BindColumn(2,"a", "KeyWord", "对应主表关键词","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.Guid _KeyValue;
 /// <summary>
 /// 对应主表主键
 /// </summary>
 [BindColumn(3,"a", "KeyValue", "对应主表主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid KeyValue  { get { return _KeyValue; } set { _KeyValue = value; } }

 private System.String _HtmlPath;
 /// <summary>
 /// 一般存主表的FormId
 /// </summary>
 [BindColumn(4,"a", "HtmlPath", "一般存主表的FormId","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String HtmlPath  { get { return _HtmlPath; } set { _HtmlPath = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 分发人Id
 /// </summary>
 [BindColumn(4,"a", "HumanId", "分发人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.String _HumanCode;
 /// <summary>
 /// 分发人编号
 /// </summary>
 [BindColumn(5,"a", "HumanCode", "分发人编号","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanCode  { get { return _HumanCode; } set { _HumanCode = value; } }

 private System.String _HumanName;
 /// <summary>
 /// 分发人名称
 /// </summary>
 [BindColumn(6,"a", "HumanName", "分发人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HumanName  { get { return _HumanName; } set { _HumanName = value; } }

 private System.Guid _FormId;
 /// <summary>
 /// 需要打开的表单Id
 /// </summary>
 [BindColumn(7,"a", "FormId", "需要打开的表单Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FormId  { get { return _FormId; } set { _FormId = value; } }

 private System.Guid _FormValue;
 /// <summary>
 /// 需要打开的表单的主键
 /// </summary>
 [BindColumn(8,"a", "FormValue", "需要打开的表单的主键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FormValue  { get { return _FormValue; } set { _FormValue = value; } }

 private System.String _FormWidth;
 /// <summary>
 /// 打开表单的宽度
 /// </summary>
 [BindColumn(9,"a", "FormWidth", "打开表单的宽度","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FormWidth  { get { return _FormWidth; } set { _FormWidth = value; } }

 private System.String _FormName;
 /// <summary>
 /// 需要打开的表单的名称
 /// </summary>
 [BindColumn(9,"a", "FormName", "需要打开的表单的名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String FormName  { get { return _FormName; } set { _FormName = value; } }

 private System.String _Remark;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(10,"a", "Remark", "备注","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Remark  { get { return _Remark; } set { _Remark = value; } }

 private System.String _FormHeight;
 /// <summary>
 /// 打开表单的高度
 /// </summary>
 [BindColumn(10,"a", "FormHeight", "打开表单的高度","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FormHeight  { get { return _FormHeight; } set { _FormHeight = value; } }

 private System.String _FormModule;
 /// <summary>
 /// 打开表单的模式
 /// </summary>
 [BindColumn(11,"a", "FormModule", "打开表单的模式","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String FormModule  { get { return _FormModule; } set { _FormModule = value; } }

 private System.Guid _RegHumanId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(12,"a", "RegHumanId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumanId  { get { return _RegHumanId; } set { _RegHumanId = value; } }

 private System.String _RegHumanName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(13,"a", "RegHumanName", "录入人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RegHumanName  { get { return _RegHumanName; } set { _RegHumanName = value; } }

 private System.String _FormTitle;
 /// <summary>
 /// 标题字段
 /// </summary>
 [BindColumn(13,"a", "FormTitle", "标题字段","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String FormTitle  { get { return _FormTitle; } set { _FormTitle = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入时间
 /// </summary>
 [BindColumn(14,"a", "RegDate", "录入时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Int32 _IsDistribute;
 /// <summary>
 /// 是否已分发:0否，1是
 /// </summary>
 [BindColumn(19,"a", "IsDistribute", "是否已分发:0否，1是","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsDistribute  { get { return _IsDistribute; } set { _IsDistribute = value; } }

 private System.DateTime _FirstOpenTime;
 /// <summary>
 /// 第一次打开时间
 /// </summary>
 [BindColumn(20,"a", "FirstOpenTime", "第一次打开时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime FirstOpenTime  { get { return _FirstOpenTime; } set { _FirstOpenTime = value; } }

 private System.DateTime _LastOpenTime;
 /// <summary>
 /// 最后一次打开事件
 /// </summary>
 [BindColumn(21,"a", "LastOpenTime", "最后一次打开事件","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime LastOpenTime  { get { return _LastOpenTime; } set { _LastOpenTime = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新时间
 /// </summary>
 [BindColumn(22,"a", "UpdDate", "最后更新时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _DistributeHumanId;
 /// <summary>
 /// 分发人id
 /// </summary>
 [BindColumn(23,"a", "DistributeHumanId", "分发人id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid DistributeHumanId  { get { return _DistributeHumanId; } set { _DistributeHumanId = value; } }

 private System.String _DistributeHumanName;
 /// <summary>
 /// 分发人名称
 /// </summary>
 [BindColumn(24,"a", "DistributeHumanName", "分发人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String DistributeHumanName  { get { return _DistributeHumanName; } set { _DistributeHumanName = value; } }

      
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
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "KEYVALUE")
{
return _KeyValue;
}
if (name == "HTMLPATH")
{
return _HtmlPath;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "HUMANCODE")
{
return _HumanCode;
}
if (name == "HUMANNAME")
{
return _HumanName;
}
if (name == "FORMID")
{
return _FormId;
}
if (name == "FORMVALUE")
{
return _FormValue;
}
if (name == "FORMWIDTH")
{
return _FormWidth;
}
if (name == "FORMNAME")
{
return _FormName;
}
if (name == "REMARK")
{
return _Remark;
}
if (name == "FORMHEIGHT")
{
return _FormHeight;
}
if (name == "FORMMODULE")
{
return _FormModule;
}
if (name == "REGHUMANID")
{
return _RegHumanId;
}
if (name == "REGHUMANNAME")
{
return _RegHumanName;
}
if (name == "FORMTITLE")
{
return _FormTitle;
}
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "ISDISTRIBUTE")
{
return _IsDistribute;
}
if (name == "FIRSTOPENTIME")
{
return _FirstOpenTime;
}
if (name == "LASTOPENTIME")
{
return _LastOpenTime;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "DISTRIBUTEHUMANID")
{
return _DistributeHumanId;
}
if (name == "DISTRIBUTEHUMANNAME")
{
return _DistributeHumanName;
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
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "KEYVALUE")
{
 _KeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HTMLPATH")
{
 _HtmlPath = System.Convert.ToString(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANCODE")
{
 _HumanCode = System.Convert.ToString(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}
if (name == "FORMID")
{
 _FormId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FORMVALUE")
{
 _FormValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FORMWIDTH")
{
 _FormWidth = System.Convert.ToString(value);return;
}
if (name == "FORMNAME")
{
 _FormName = System.Convert.ToString(value);return;
}
if (name == "REMARK")
{
 _Remark = System.Convert.ToString(value);return;
}
if (name == "FORMHEIGHT")
{
 _FormHeight = System.Convert.ToString(value);return;
}
if (name == "FORMMODULE")
{
 _FormModule = System.Convert.ToString(value);return;
}
if (name == "REGHUMANID")
{
 _RegHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "REGHUMANNAME")
{
 _RegHumanName = System.Convert.ToString(value);return;
}
if (name == "FORMTITLE")
{
 _FormTitle = System.Convert.ToString(value);return;
}
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "ISDISTRIBUTE")
{
 _IsDistribute = System.Convert.ToInt32(value);return;
}
if (name == "FIRSTOPENTIME")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _FirstOpenTime = System.Convert.ToDateTime(value);return;
}
if (name == "LASTOPENTIME")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _LastOpenTime = System.Convert.ToDateTime(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "DISTRIBUTEHUMANID")
{
 _DistributeHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DISTRIBUTEHUMANNAME")
{
 _DistributeHumanName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}