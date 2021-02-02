 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 同步P6
    /// </summary>
    public class PB_SyncP6DO : PB_SyncP6DO<PB_SyncP6DO>
    {

    }

	/// <summary>
    /// 同步P6
    /// </summary>
	  [BindEntity(KeyWord="PB_SyncP6",EntityType = typeof(Power.Systems.StdSystem.PB_SyncP6DO),Description = "同步P6"  )] 

	 [BindTable( "PB_SyncP6", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_SyncP6", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_SyncP6",Description="")]

    public   class PB_SyncP6DO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PB_SyncP6DO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Int32 _GroupId;
 /// <summary>
 /// 分组
 /// </summary>
 [BindColumn(2,"a", "GroupId", "分组","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 GroupId  { get { return _GroupId; } set { _GroupId = value; } }

 private System.Int32 _FromProjectId;
 /// <summary>
 /// 来源项目ID
 /// </summary>
 [BindColumn(3,"a", "FromProjectId", "来源项目ID","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 FromProjectId  { get { return _FromProjectId; } set { _FromProjectId = value; } }

 private System.String _FromProjectShortName;
 /// <summary>
 /// 来源项目编码
 /// </summary>
 [BindColumn(4,"a", "FromProjectShortName", "来源项目编码","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String FromProjectShortName  { get { return _FromProjectShortName; } set { _FromProjectShortName = value; } }

 private System.String _FromProjectName;
 /// <summary>
 /// 来源项目名称
 /// </summary>
 [BindColumn(5,"a", "FromProjectName", "来源项目名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String FromProjectName  { get { return _FromProjectName; } set { _FromProjectName = value; } }

 private System.String _FromProjectType;
 /// <summary>
 /// 来源项目类型（是一个真实项目还是EPS）
 /// </summary>
 [BindColumn(6,"a", "FromProjectType", "来源项目类型（是一个真实项目还是EPS）","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String FromProjectType  { get { return _FromProjectType; } set { _FromProjectType = value; } }

 private System.Int32 _ToProjectId;
 /// <summary>
 /// 目标项目ID
 /// </summary>
 [BindColumn(7,"a", "ToProjectId", "目标项目ID","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 ToProjectId  { get { return _ToProjectId; } set { _ToProjectId = value; } }

 private System.String _ToProjectShortName;
 /// <summary>
 /// 目标项目编码
 /// </summary>
 [BindColumn(8,"a", "ToProjectShortName", "目标项目编码","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ToProjectShortName  { get { return _ToProjectShortName; } set { _ToProjectShortName = value; } }

 private System.String _ToProjectName;
 /// <summary>
 /// 目标项目名称
 /// </summary>
 [BindColumn(9,"a", "ToProjectName", "目标项目名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ToProjectName  { get { return _ToProjectName; } set { _ToProjectName = value; } }

 private System.String _ToProjectType;
 /// <summary>
 /// 目标项目类型（是真实项目还是EPS）
 /// </summary>
 [BindColumn(10,"a", "ToProjectType", "目标项目类型（是真实项目还是EPS）","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String ToProjectType  { get { return _ToProjectType; } set { _ToProjectType = value; } }

 private System.Guid _ToProjectGuid;
 /// <summary>
 /// 目标项目GUID
 /// </summary>
 [BindColumn(11,"a", "ToProjectGuid", "目标项目GUID","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ToProjectGuid  { get { return _ToProjectGuid; } set { _ToProjectGuid = value; } }

 private System.Int32 _ToProjectPlanId;
 /// <summary>
 /// 目标项目的主计划Id(同步操作时用到)
 /// </summary>
 [BindColumn(12,"a", "ToProjectPlanId", "目标项目的主计划Id(同步操作时用到)","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 ToProjectPlanId  { get { return _ToProjectPlanId; } set { _ToProjectPlanId = value; } }

 private System.Guid _ToProjectPlanGuid;
 /// <summary>
 /// 目标项目对应的主计划GUID
 /// </summary>
 [BindColumn(13,"a", "ToProjectPlanGuid", "目标项目对应的主计划GUID","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid ToProjectPlanGuid  { get { return _ToProjectPlanGuid; } set { _ToProjectPlanGuid = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(14,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _ToProjectPlanName;
 /// <summary>
 /// 目标项目对应的主计划名称
 /// </summary>
 [BindColumn(14,"a", "ToProjectPlanName", "目标项目对应的主计划名称","", "NCHAR", 400,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =400 )]
 public  System.String ToProjectPlanName  { get { return _ToProjectPlanName; } set { _ToProjectPlanName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(15,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后修改人Id
 /// </summary>
 [BindColumn(16,"a", "UpdHumId", "最后修改人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后修改人名称
 /// </summary>
 [BindColumn(17,"a", "UpdHumName", "最后修改人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _data_date;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "data_date", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime data_date  { get { return _data_date; } set { _data_date = value; } }

 private System.Int32 _DataDirection;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "DataDirection", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 DataDirection  { get { return _DataDirection; } set { _DataDirection = value; } }

      
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
if (name == "GROUPID")
{
return _GroupId;
}
if (name == "FROMPROJECTID")
{
return _FromProjectId;
}
if (name == "FROMPROJECTSHORTNAME")
{
return _FromProjectShortName;
}
if (name == "FROMPROJECTNAME")
{
return _FromProjectName;
}
if (name == "FROMPROJECTTYPE")
{
return _FromProjectType;
}
if (name == "TOPROJECTID")
{
return _ToProjectId;
}
if (name == "TOPROJECTSHORTNAME")
{
return _ToProjectShortName;
}
if (name == "TOPROJECTNAME")
{
return _ToProjectName;
}
if (name == "TOPROJECTTYPE")
{
return _ToProjectType;
}
if (name == "TOPROJECTGUID")
{
return _ToProjectGuid;
}
if (name == "TOPROJECTPLANID")
{
return _ToProjectPlanId;
}
if (name == "TOPROJECTPLANGUID")
{
return _ToProjectPlanGuid;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "TOPROJECTPLANNAME")
{
return _ToProjectPlanName;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
}
if (name == "DATA_DATE")
{
return _data_date;
}
if (name == "DATADIRECTION")
{
return _DataDirection;
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
if (name == "GROUPID")
{
 _GroupId = System.Convert.ToInt32(value);return;
}
if (name == "FROMPROJECTID")
{
 _FromProjectId = System.Convert.ToInt32(value);return;
}
if (name == "FROMPROJECTSHORTNAME")
{
 _FromProjectShortName = System.Convert.ToString(value);return;
}
if (name == "FROMPROJECTNAME")
{
 _FromProjectName = System.Convert.ToString(value);return;
}
if (name == "FROMPROJECTTYPE")
{
 _FromProjectType = System.Convert.ToString(value);return;
}
if (name == "TOPROJECTID")
{
 _ToProjectId = System.Convert.ToInt32(value);return;
}
if (name == "TOPROJECTSHORTNAME")
{
 _ToProjectShortName = System.Convert.ToString(value);return;
}
if (name == "TOPROJECTNAME")
{
 _ToProjectName = System.Convert.ToString(value);return;
}
if (name == "TOPROJECTTYPE")
{
 _ToProjectType = System.Convert.ToString(value);return;
}
if (name == "TOPROJECTGUID")
{
 _ToProjectGuid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TOPROJECTPLANID")
{
 _ToProjectPlanId = System.Convert.ToInt32(value);return;
}
if (name == "TOPROJECTPLANGUID")
{
 _ToProjectPlanGuid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "TOPROJECTPLANNAME")
{
 _ToProjectPlanName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}
if (name == "DATA_DATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _data_date = System.Convert.ToDateTime(value);return;
}
if (name == "DATADIRECTION")
{
 _DataDirection = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}