 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 投标任务书
    /// </summary>
    public class PS_BidTaskDO : PS_BidTaskDO<PS_BidTaskDO>
    {

    }

	/// <summary>
    /// 投标任务书
    /// </summary>
	  [BindEntity(KeyWord="PS_BidTask",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTaskDO),Description = "投标任务书"  )] 

	 [BindTable( "PS_MK_BidTask", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_BidTask", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_BidTask",Description="")]

    public   class PS_BidTaskDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_BidTaskDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ProjectInfo_Guid;
 /// <summary>
 /// 项目信息外键
 /// </summary>
 [BindColumn(2,"a", "ProjectInfo_Guid", "项目信息外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ProjectInfo_Guid  { get { return _ProjectInfo_Guid; } set { _ProjectInfo_Guid = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// 客户外键
 /// </summary>
 [BindColumn(3,"a", "Client_Guid", "客户外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.String _BussinessManager;
 /// <summary>
 /// 商务经理
 /// </summary>
 [BindColumn(4,"a", "BussinessManager", "商务经理","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String BussinessManager  { get { return _BussinessManager; } set { _BussinessManager = value; } }

 private System.String _TechManager;
 /// <summary>
 /// 技术经理
 /// </summary>
 [BindColumn(5,"a", "TechManager", "技术经理","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String TechManager  { get { return _TechManager; } set { _TechManager = value; } }

 private System.Guid _BussinessManagerId;
 /// <summary>
 /// 商务经理Id
 /// </summary>
 [BindColumn(6,"a", "BussinessManagerId", "商务经理Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid BussinessManagerId  { get { return _BussinessManagerId; } set { _BussinessManagerId = value; } }

 private System.Guid _TechManagerId;
 /// <summary>
 /// 技术经理Id
 /// </summary>
 [BindColumn(7,"a", "TechManagerId", "技术经理Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid TechManagerId  { get { return _TechManagerId; } set { _TechManagerId = value; } }

 private System.DateTime _DeadLine;
 /// <summary>
 /// 投标截止日期
 /// </summary>
 [BindColumn(8,"a", "DeadLine", "投标截止日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime DeadLine  { get { return _DeadLine; } set { _DeadLine = value; } }

 private System.String _ResponsibleHuman;
 /// <summary>
 /// 责任人
 /// </summary>
 [BindColumn(9,"a", "ResponsibleHuman", "责任人","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ResponsibleHuman  { get { return _ResponsibleHuman; } set { _ResponsibleHuman = value; } }

 private System.Guid _ResponsibleHumanId;
 /// <summary>
 /// 责任人Id
 /// </summary>
 [BindColumn(10,"a", "ResponsibleHumanId", "责任人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ResponsibleHumanId  { get { return _ResponsibleHumanId; } set { _ResponsibleHumanId = value; } }

 private System.String _Memo;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "Memo", "","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "UpdHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "UpdHuman", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "RegHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "OwnProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "EpsProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

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

 private System.SByte _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(24,"a", "Status", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.String _Title;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(25,"a", "Title", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String Title  { get { return _Title; } set { _Title = value; } }

      
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
if (name == "PROJECTINFO_GUID")
{
return _ProjectInfo_Guid;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "BUSSINESSMANAGER")
{
return _BussinessManager;
}
if (name == "TECHMANAGER")
{
return _TechManager;
}
if (name == "BUSSINESSMANAGERID")
{
return _BussinessManagerId;
}
if (name == "TECHMANAGERID")
{
return _TechManagerId;
}
if (name == "DEADLINE")
{
return _DeadLine;
}
if (name == "RESPONSIBLEHUMAN")
{
return _ResponsibleHuman;
}
if (name == "RESPONSIBLEHUMANID")
{
return _ResponsibleHumanId;
}
if (name == "MEMO")
{
return _Memo;
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
if (name == "REGDATE")
{
return _RegDate;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGHUMID")
{
return _RegHumId;
}
if (name == "OWNPROJNAME")
{
return _OwnProjName;
}
if (name == "OWNPROJID")
{
return _OwnProjId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
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
if (name == "STATUS")
{
return _Status;
}
if (name == "TITLE")
{
return _Title;
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
if (name == "PROJECTINFO_GUID")
{
 _ProjectInfo_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "BUSSINESSMANAGER")
{
 _BussinessManager = System.Convert.ToString(value);return;
}
if (name == "TECHMANAGER")
{
 _TechManager = System.Convert.ToString(value);return;
}
if (name == "BUSSINESSMANAGERID")
{
 _BussinessManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TECHMANAGERID")
{
 _TechManagerId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "DEADLINE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _DeadLine = System.Convert.ToDateTime(value);return;
}
if (name == "RESPONSIBLEHUMAN")
{
 _ResponsibleHuman = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEHUMANID")
{
 _ResponsibleHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "MEMO")
{
 _Memo = System.Convert.ToString(value);return;
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
if (name == "REGDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _RegDate = System.Convert.ToDateTime(value);return;
}
if (name == "REGHUMNAME")
{
 _RegHumName = System.Convert.ToString(value);return;
}
if (name == "REGHUMID")
{
 _RegHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "OWNPROJNAME")
{
 _OwnProjName = System.Convert.ToString(value);return;
}
if (name == "OWNPROJID")
{
 _OwnProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
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
if (name == "STATUS")
{
 _Status = System.Convert.ToSByte(value);return;
}
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}