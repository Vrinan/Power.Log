 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 委托与委托明细中间表
    /// </summary>
    public class PB_FlowProxyListDO : PB_FlowProxyListDO<PB_FlowProxyListDO>
    {

    }

	/// <summary>
    /// 委托与委托明细中间表
    /// </summary>
	  [BindEntity(KeyWord="PB_FlowProxyList",EntityType = typeof(Power.Systems.Systems.PB_FlowProxyListDO),Description = "委托与委托明细中间表"  )] 

	 [BindTable( "PB_FlowProxyList", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_FlowProxyList", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_FlowProxyList",Description="")]

    public   class PB_FlowProxyListDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.PB_FlowProxyListDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键唯一标识
 /// </summary>
 [BindColumn(1,"a", "Id", "主键唯一标识","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ProxyId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(2,"a", "ProxyId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProxyId  { get { return _ProxyId; } set { _ProxyId = value; } }

 private System.Guid _ProjectId;
 /// <summary>
 /// 项目id
 /// </summary>
 [BindColumn(3,"a", "ProjectId", "项目id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProjectId  { get { return _ProjectId; } set { _ProjectId = value; } }

 private System.String _ProjectName;
 /// <summary>
 /// 项目名称
 /// </summary>
 [BindColumn(4,"a", "ProjectName", "项目名称","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String ProjectName  { get { return _ProjectName; } set { _ProjectName = value; } }

 private System.Guid _MenuId;
 /// <summary>
 /// 菜单id
 /// </summary>
 [BindColumn(5,"a", "MenuId", "菜单id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MenuId  { get { return _MenuId; } set { _MenuId = value; } }

 private System.String _MenuName;
 /// <summary>
 /// 菜单名称
 /// </summary>
 [BindColumn(6,"a", "MenuName", "菜单名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String MenuName  { get { return _MenuName; } set { _MenuName = value; } }

 private System.DateTime _StartDate;
 /// <summary>
 /// 开始时间
 /// </summary>
 [BindColumn(7,"a", "StartDate", "开始时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime StartDate  { get { return _StartDate; } set { _StartDate = value; } }

 private System.DateTime _EndDate;
 /// <summary>
 /// 结束时间
 /// </summary>
 [BindColumn(8,"a", "EndDate", "结束时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime EndDate  { get { return _EndDate; } set { _EndDate = value; } }

 private System.Guid _PropxyHumanId;
 /// <summary>
 /// 受托人id
 /// </summary>
 [BindColumn(9,"a", "PropxyHumanId", "受托人id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PropxyHumanId  { get { return _PropxyHumanId; } set { _PropxyHumanId = value; } }

 private System.String _PropxyHumanName;
 /// <summary>
 /// 受托人名称
 /// </summary>
 [BindColumn(10,"a", "PropxyHumanName", "受托人名称","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String PropxyHumanName  { get { return _PropxyHumanName; } set { _PropxyHumanName = value; } }

 private System.Int16 _IsEnabled;
 /// <summary>
 /// 是否有效
 /// </summary>
 [BindColumn(11,"a", "IsEnabled", "是否有效","", "NCHAR", 5,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =5 )]
 public  System.Int16 IsEnabled  { get { return _IsEnabled; } set { _IsEnabled = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后修改日期
 /// </summary>
 [BindColumn(12,"a", "UpdDate", "最后修改日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(13,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

      
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
if (name == "PROXYID")
{
return _ProxyId;
}
if (name == "PROJECTID")
{
return _ProjectId;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "MENUID")
{
return _MenuId;
}
if (name == "MENUNAME")
{
return _MenuName;
}
if (name == "STARTDATE")
{
return _StartDate;
}
if (name == "ENDDATE")
{
return _EndDate;
}
if (name == "PROPXYHUMANID")
{
return _PropxyHumanId;
}
if (name == "PROPXYHUMANNAME")
{
return _PropxyHumanName;
}
if (name == "ISENABLED")
{
return _IsEnabled;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "SEQU")
{
return _Sequ;
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
if (name == "PROXYID")
{
 _ProxyId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTID")
{
 _ProjectId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "MENUID")
{
 _MenuId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MENUNAME")
{
 _MenuName = System.Convert.ToString(value);return;
}
if (name == "STARTDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _StartDate = System.Convert.ToDateTime(value);return;
}
if (name == "ENDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _EndDate = System.Convert.ToDateTime(value);return;
}
if (name == "PROPXYHUMANID")
{
 _PropxyHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROPXYHUMANNAME")
{
 _PropxyHumanName = System.Convert.ToString(value);return;
}
if (name == "ISENABLED")
{
 _IsEnabled = System.Convert.ToInt16(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}