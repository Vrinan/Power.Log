﻿ 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 用户(PB_User)
    /// </summary>
    public class UserDO : UserDO<UserDO>
    {

    }

	/// <summary>
    /// 用户(PB_User)
    /// </summary>
	  [BindEntity(KeyWord="User",EntityType = typeof(Power.Systems.StdSystem.UserDO),Description = "用户(PB_User)"  )] 

	 [BindTable( "PB_User", Alias = "a",IsAttach=false,Description ="用户")]
[BindTable( "PB_DefaultField", Alias = "b",IsAttach=true,Description ="常用字段")]

	  [BindIndex(Name = "pk_PB_User", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_User",Description="用户")]
 [BindIndex(Name = "pk_PB_DefaultField", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "DefaultFieldId", TableName = "PB_DefaultField",Description="常用字段")]

    public   class UserDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.UserDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 [BindColumn(1,"b", "DefaultFieldId", "对应业务记录Id","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _ITAdminFlag;
 /// <summary>
 /// Y是IT管理员
 /// </summary>
 [BindColumn(1,"a", "ITAdminFlag", "Y是IT管理员","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =1 )]
 public  System.String ITAdminFlag  { get { return _ITAdminFlag; } set { _ITAdminFlag = value; } }

 private System.Guid _LastEpsProjId;
 /// <summary>
 /// 最后打开项目
 /// </summary>
 [BindColumn(1,"a", "LastEpsProjId", "最后打开项目","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid LastEpsProjId  { get { return _LastEpsProjId; } set { _LastEpsProjId = value; } }

 private System.String _Code;
 /// <summary>
 /// 账号
 /// </summary>
 [BindColumn(2,"a", "Code", "账号","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Name;
 /// <summary>
 /// 名称
 /// </summary>
 [BindColumn(3,"a", "Name", "名称","", "NCHAR", 30,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =30 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(4,"a", "HumanId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.String _HumanName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(5,"a", "HumanName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String HumanName  { get { return _HumanName; } set { _HumanName = value; } }

 private System.String _PassWord;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(6,"a", "PassWord", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String PassWord  { get { return _PassWord; } set { _PassWord = value; } }

 private System.DateTime _ValidDate;
 /// <summary>
 /// 账号有效期
 /// </summary>
 [BindColumn(7,"a", "ValidDate", "账号有效期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ValidDate  { get { return _ValidDate; } set { _ValidDate = value; } }

 private System.SByte _Actived;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "Actived", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte Actived  { get { return _Actived; } set { _Actived = value; } }

 private System.String _IsWinAccount;
 /// <summary>
 /// Y,windows域验证密码
 /// </summary>
 [BindColumn(10,"a", "IsWinAccount", "Y,windows域验证密码","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.String IsWinAccount  { get { return _IsWinAccount; } set { _IsWinAccount = value; } }

 private System.Int32 _ErrorCount;
 /// <summary>
 /// 出错次数
 /// </summary>
 [BindColumn(12,"a", "ErrorCount", "出错次数","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 ErrorCount  { get { return _ErrorCount; } set { _ErrorCount = value; } }

 private System.DateTime _LockTime;
 /// <summary>
 /// 锁定时间
 /// </summary>
 [BindColumn(13,"a", "LockTime", "锁定时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime LockTime  { get { return _LockTime; } set { _LockTime = value; } }

 private System.String _TableName;
 /// <summary>
 /// 数据所属表名
 /// </summary>
 [BindColumn(2,"b", "TableName", "数据所属表名","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String TableName  { get { return _TableName; } set { _TableName = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// 数据录入业务域Id
 /// </summary>
 [BindColumn(3,"b", "BizAreaId", "数据录入业务域Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(4,"b", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 平台状态；0编制中，1送审中，2生效，3废止
 /// </summary>
 [BindColumn(5,"b", "Status", "平台状态；0编制中，1送审中，2生效，3废止","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(6,"b", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(7,"b", "RegHumName", "录入人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(8,"b", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 录入人岗位Id
 /// </summary>
 [BindColumn(9,"b", "RegPosiId", "录入人岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 录入人部门Id
 /// </summary>
 [BindColumn(10,"b", "RegDeptId", "录入人部门Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 记录所属EPS/Project节点Id
 /// </summary>
 [BindColumn(11,"b", "EpsProjId", "记录所属EPS/Project节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 删除人Id
 /// </summary>
 [BindColumn(12,"b", "RecycleHumId", "删除人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(13,"b", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(14,"b", "UpdHumName", "最后更新人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(15,"b", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 批准人Id
 /// </summary>
 [BindColumn(16,"b", "ApprHumId", "批准人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 批准人名称
 /// </summary>
 [BindColumn(17,"b", "ApprHumName", "批准人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 批准日期
 /// </summary>
 [BindColumn(18,"b", "ApprDate", "批准日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(19,"b", "Memo", "备注","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 所属项目Id
 /// </summary>
 [BindColumn(20,"b", "OwnProjId", "所属项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 所属项目名称
 /// </summary>
 [BindColumn(21,"b", "OwnProjName", "所属项目名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
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
if (name == "ITADMINFLAG")
{
return _ITAdminFlag;
}
if (name == "LASTEPSPROJID")
{
return _LastEpsProjId;
}
if (name == "CODE")
{
return _Code;
}
if (name == "NAME")
{
return _Name;
}
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "HUMANNAME")
{
return _HumanName;
}
if (name == "PASSWORD")
{
return _PassWord;
}
if (name == "VALIDDATE")
{
return _ValidDate;
}
if (name == "ACTIVED")
{
return _Actived;
}
if (name == "ISWINACCOUNT")
{
return _IsWinAccount;
}
if (name == "ERRORCOUNT")
{
return _ErrorCount;
}
if (name == "LOCKTIME")
{
return _LockTime;
}
if (name == "TABLENAME")
{
return _TableName;
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
if (name == "ITADMINFLAG")
{
 _ITAdminFlag = System.Convert.ToString(value);return;
}
if (name == "LASTEPSPROJID")
{
 _LastEpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "HUMANNAME")
{
 _HumanName = System.Convert.ToString(value);return;
}
if (name == "PASSWORD")
{
 _PassWord = System.Convert.ToString(value);return;
}
if (name == "VALIDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ValidDate = System.Convert.ToDateTime(value);return;
}
if (name == "ACTIVED")
{
 _Actived = System.Convert.ToSByte(value);return;
}
if (name == "ISWINACCOUNT")
{
 _IsWinAccount = System.Convert.ToString(value);return;
}
if (name == "ERRORCOUNT")
{
 _ErrorCount = System.Convert.ToInt32(value);return;
}
if (name == "LOCKTIME")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _LockTime = System.Convert.ToDateTime(value);return;
}
if (name == "TABLENAME")
{
 _TableName = System.Convert.ToString(value);return;
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