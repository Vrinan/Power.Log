﻿ 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 客户评价
    /// </summary>
    public class PS_ClientEvaluationDO : PS_ClientEvaluationDO<PS_ClientEvaluationDO>
    {

    }

	/// <summary>
    /// 客户评价
    /// </summary>
	  [BindEntity(KeyWord="PS_ClientEvaluation",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ClientEvaluationDO),Description = "客户评价"  )] 

	 [BindTable( "PS_MK_ClientEvaluation", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_ClientEvaluation", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_ClientEvaluation",Description="")]

    public   class PS_ClientEvaluationDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ClientEvaluationDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.DateTime _EvaluationDate;
 /// <summary>
 /// 评价日期
 /// </summary>
 [BindColumn(1,"a", "EvaluationDate", "评价日期","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =0 )]
 public  System.DateTime EvaluationDate  { get { return _EvaluationDate; } set { _EvaluationDate = value; } }

 private System.String _ProjectName;
 /// <summary>
 /// 项目名称
 /// </summary>
 [BindColumn(1,"a", "ProjectName", "项目名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String ProjectName  { get { return _ProjectName; } set { _ProjectName = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _ClientName;
 /// <summary>
 /// 客户名称
 /// </summary>
 [BindColumn(1,"a", "ClientName", "客户名称","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =100 )]
 public  System.String ClientName  { get { return _ClientName; } set { _ClientName = value; } }

 private System.Guid _Client_Guid;
 /// <summary>
 /// 关联客户
 /// </summary>
 [BindColumn(2,"a", "Client_Guid", "关联客户","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Client_Guid  { get { return _Client_Guid; } set { _Client_Guid = value; } }

 private System.Guid _Proj_Guid;
 /// <summary>
 /// 关联项目
 /// </summary>
 [BindColumn(3,"a", "Proj_Guid", "关联项目","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Proj_Guid  { get { return _Proj_Guid; } set { _Proj_Guid = value; } }

 private System.Guid _Contract_Guid;
 /// <summary>
 /// 关联合同
 /// </summary>
 [BindColumn(4,"a", "Contract_Guid", "关联合同","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid Contract_Guid  { get { return _Contract_Guid; } set { _Contract_Guid = value; } }

 private System.String _Code;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(5,"a", "Code", "编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.String _Title;
 /// <summary>
 /// 标题
 /// </summary>
 [BindColumn(6,"a", "Title", "标题","", "NCHAR", 300,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =300 )]
 public  System.String Title  { get { return _Title; } set { _Title = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "UpdHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHuman;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "UpdHuman", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHuman  { get { return _UpdHuman; } set { _UpdHuman = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(9,"a", "UpdDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "RegHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(12,"a", "RegHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(13,"a", "OwnProjName", "","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "OwnProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "EpsProjId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "ApprHumId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(17,"a", "ApprHumName", "","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(18,"a", "ApprDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(19,"a", "Status", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

      
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
			    if (name == "EVALUATIONDATE")
{
return _EvaluationDate;
}
if (name == "PROJECTNAME")
{
return _ProjectName;
}
if (name == "ID")
{
return _Id;
}
if (name == "CLIENTNAME")
{
return _ClientName;
}
if (name == "CLIENT_GUID")
{
return _Client_Guid;
}
if (name == "PROJ_GUID")
{
return _Proj_Guid;
}
if (name == "CONTRACT_GUID")
{
return _Contract_Guid;
}
if (name == "CODE")
{
return _Code;
}
if (name == "TITLE")
{
return _Title;
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

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "EVALUATIONDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _EvaluationDate = System.Convert.ToDateTime(value);return;
}
if (name == "PROJECTNAME")
{
 _ProjectName = System.Convert.ToString(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CLIENTNAME")
{
 _ClientName = System.Convert.ToString(value);return;
}
if (name == "CLIENT_GUID")
{
 _Client_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PROJ_GUID")
{
 _Proj_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CONTRACT_GUID")
{
 _Contract_Guid = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
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

			    base[name] = value;
			}
		}
		#endregion
	}
}