 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 引导式菜单分组
    /// </summary>
    public class PS_Guided_MenuGroupDO : PS_Guided_MenuGroupDO<PS_Guided_MenuGroupDO>
    {

    }

	/// <summary>
    /// 引导式菜单分组
    /// </summary>
	  [BindEntity(KeyWord="PS_Guided_MenuGroup",EntityType = typeof(Power.Systems.StdSystem.PS_Guided_MenuGroupDO),Description = "引导式菜单分组"  )] 

	 [BindTable( "PS_Guided_MenuGroup", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_Guided_MenuGroup", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "MenuGroupId", TableName = "PS_Guided_MenuGroup",Description="")]

    public   class PS_Guided_MenuGroupDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PS_Guided_MenuGroupDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _MenuGroupId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "MenuGroupId", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid MenuGroupId  { get { return _MenuGroupId; } set { _MenuGroupId = value; } }

 private System.String _MenuGroupName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "MenuGroupName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String MenuGroupName  { get { return _MenuGroupName; } set { _MenuGroupName = value; } }

 private System.String _Description;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(3,"a", "Description", "","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String Description  { get { return _Description; } set { _Description = value; } }

 private System.String _IconClass;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "IconClass", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String IconClass  { get { return _IconClass; } set { _IconClass = value; } }

 private System.Guid _ModuleId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "ModuleId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ModuleId  { get { return _ModuleId; } set { _ModuleId = value; } }

 private System.Guid _MenuId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "MenuId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MenuId  { get { return _MenuId; } set { _MenuId = value; } }

 private System.Int32 _IsEnable;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "IsEnable", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 IsEnable  { get { return _IsEnable; } set { _IsEnable = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "BizAreaId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "Sequ", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "Status", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "RegHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "RegPosiId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "RegDeptId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "EpsProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "RecycleHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "UpdHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "UpdHuman", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(21,"a", "ApprHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "ApprHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(23,"a", "ApprDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "OwnProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _Memo;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(26,"a", "Memo", "","", "NCHAR", 1000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1000 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.String _MenuName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "MenuName", "","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String MenuName  { get { return _MenuName; } set { _MenuName = value; } }

      
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
			    if (name == "MENUGROUPID")
{
return _MenuGroupId;
}
if (name == "MENUGROUPNAME")
{
return _MenuGroupName;
}
if (name == "DESCRIPTION")
{
return _Description;
}
if (name == "ICONCLASS")
{
return _IconClass;
}
if (name == "MODULEID")
{
return _ModuleId;
}
if (name == "MENUID")
{
return _MenuId;
}
if (name == "ISENABLE")
{
return _IsEnable;
}
if (name == "BIZAREAID")
{
return _BizAreaId;
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
if (name == "UPDHUMAN")
{
return _UpdHuman;
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
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "MEMO")
{
return _Memo;
}
if (name == "MENUNAME")
{
return _MenuName;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "MENUGROUPID")
{
 _MenuGroupId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MENUGROUPNAME")
{
 _MenuGroupName = System.Convert.ToString(value);return;
}
if (name == "DESCRIPTION")
{
 _Description = System.Convert.ToString(value);return;
}
if (name == "ICONCLASS")
{
 _IconClass = System.Convert.ToString(value);return;
}
if (name == "MODULEID")
{
 _ModuleId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MENUID")
{
 _MenuId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ISENABLE")
{
 _IsEnable = System.Convert.ToInt32(value);return;
}
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
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
if (name == "UPDHUMAN")
{
 _UpdHuman = System.Convert.ToString(value);return;
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
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
}
if (name == "MENUNAME")
{
 _MenuName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}