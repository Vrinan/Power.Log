 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdAPP
{
    /// <summary>
    /// APP质量
    /// </summary>
    public class PS_APP_QualityDO : PS_APP_QualityDO<PS_APP_QualityDO>
    {

    }

	/// <summary>
    /// APP质量
    /// </summary>
	  [BindEntity(KeyWord="PS_APP_Quality",EntityType = typeof(Power.Systems.StdAPP.PS_APP_QualityDO),Description = "APP质量"  )] 

	 [BindTable( "PS_APP_Quality", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_APP_Quality", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_APP_Quality",Description="")]

    public   class PS_APP_QualityDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdAPP.PS_APP_QualityDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _Title;
 /// <summary>
 /// 标题
 /// </summary>
 [BindColumn(2,"a", "Title", "标题","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Title  { get { return _Title; } set { _Title = value; } }

 private System.String _Tab;
 /// <summary>
 /// 标签
 /// </summary>
 [BindColumn(3,"a", "Tab", "标签","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Tab  { get { return _Tab; } set { _Tab = value; } }

 private System.DateTime _CheckDate;
 /// <summary>
 /// 检查日期
 /// </summary>
 [BindColumn(4,"a", "CheckDate", "检查日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime CheckDate  { get { return _CheckDate; } set { _CheckDate = value; } }

 private System.String _CheckHuman;
 /// <summary>
 /// 检查人
 /// </summary>
 [BindColumn(5,"a", "CheckHuman", "检查人","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String CheckHuman  { get { return _CheckHuman; } set { _CheckHuman = value; } }

 private System.String _CheckHumanId;
 /// <summary>
 /// 检查人Id
 /// </summary>
 [BindColumn(6,"a", "CheckHumanId", "检查人Id","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String CheckHumanId  { get { return _CheckHumanId; } set { _CheckHumanId = value; } }

 private System.String _CheckContent;
 /// <summary>
 /// 检查内容
 /// </summary>
 [BindColumn(7,"a", "CheckContent", "检查内容","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String CheckContent  { get { return _CheckContent; } set { _CheckContent = value; } }

 private System.String _CheckResult;
 /// <summary>
 /// 检查结果
 /// </summary>
 [BindColumn(8,"a", "CheckResult", "检查结果","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String CheckResult  { get { return _CheckResult; } set { _CheckResult = value; } }

 private System.Int32 _CheckStatus;
 /// <summary>
 /// 检查状态  0:不合格;1:合格;2:让步接受
 /// </summary>
 [BindColumn(9,"a", "CheckStatus", "检查状态  0:不合格;1:合格;2:让步接受","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 CheckStatus  { get { return _CheckStatus; } set { _CheckStatus = value; } }

 private System.String _ChangeContent;
 /// <summary>
 /// 整改内容
 /// </summary>
 [BindColumn(10,"a", "ChangeContent", "整改内容","", "NCHAR", 2000,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2000 )]
 public  System.String ChangeContent  { get { return _ChangeContent; } set { _ChangeContent = value; } }

 private System.DateTime _ChangedDate;
 /// <summary>
 /// 整改完成日期
 /// </summary>
 [BindColumn(11,"a", "ChangedDate", "整改完成日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ChangedDate  { get { return _ChangedDate; } set { _ChangedDate = value; } }

 private System.String _NotifyHuman;
 /// <summary>
 /// 通知人
 /// </summary>
 [BindColumn(12,"a", "NotifyHuman", "通知人","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String NotifyHuman  { get { return _NotifyHuman; } set { _NotifyHuman = value; } }

 private System.String _NotifyHumanId;
 /// <summary>
 /// 通知人Id
 /// </summary>
 [BindColumn(13,"a", "NotifyHumanId", "通知人Id","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String NotifyHumanId  { get { return _NotifyHumanId; } set { _NotifyHumanId = value; } }

 private System.String _RecordHuman;
 /// <summary>
 /// 记录人
 /// </summary>
 [BindColumn(14,"a", "RecordHuman", "记录人","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RecordHuman  { get { return _RecordHuman; } set { _RecordHuman = value; } }

 private System.String _RecordHumanId;
 /// <summary>
 /// 记录人Id
 /// </summary>
 [BindColumn(15,"a", "RecordHumanId", "记录人Id","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RecordHumanId  { get { return _RecordHumanId; } set { _RecordHumanId = value; } }

 private System.String _ChangeHuman;
 /// <summary>
 /// 整改人
 /// </summary>
 [BindColumn(16,"a", "ChangeHuman", "整改人","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ChangeHuman  { get { return _ChangeHuman; } set { _ChangeHuman = value; } }

 private System.String _ChangeHumanId;
 /// <summary>
 /// 整改人Id
 /// </summary>
 [BindColumn(17,"a", "ChangeHumanId", "整改人Id","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String ChangeHumanId  { get { return _ChangeHumanId; } set { _ChangeHumanId = value; } }

 private System.String _CCHuman;
 /// <summary>
 /// 抄送人
 /// </summary>
 [BindColumn(18,"a", "CCHuman", "抄送人","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String CCHuman  { get { return _CCHuman; } set { _CCHuman = value; } }

 private System.String _CCHumanId;
 /// <summary>
 /// 抄送人Id
 /// </summary>
 [BindColumn(19,"a", "CCHumanId", "抄送人Id","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String CCHumanId  { get { return _CCHumanId; } set { _CCHumanId = value; } }

 private System.String _RecheckHuman;
 /// <summary>
 /// 复检人
 /// </summary>
 [BindColumn(20,"a", "RecheckHuman", "复检人","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RecheckHuman  { get { return _RecheckHuman; } set { _RecheckHuman = value; } }

 private System.String _RecheckHunmanId;
 /// <summary>
 /// 复检人Id
 /// </summary>
 [BindColumn(21,"a", "RecheckHunmanId", "复检人Id","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RecheckHunmanId  { get { return _RecheckHunmanId; } set { _RecheckHunmanId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(22,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.Int32 _Status;
 /// <summary>
 /// 表单状态；0新增，20审批中，35生效，40终止，50批准
 /// </summary>
 [BindColumn(23,"a", "Status", "表单状态；0新增，20审批中，35生效，40终止，50批准","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(24,"a", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(25,"a", "RegHumName", "录入人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(26,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 录入人岗位Id
 /// </summary>
 [BindColumn(27,"a", "RegPosiId", "录入人岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 录入人部门Id
 /// </summary>
 [BindColumn(28,"a", "RegDeptId", "录入人部门Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 记录所属EPS节点Id
 /// </summary>
 [BindColumn(29,"a", "EpsProjId", "记录所属EPS节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 删除人Id
 /// </summary>
 [BindColumn(30,"a", "RecycleHumId", "删除人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(31,"a", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(32,"a", "UpdHumName", "最后更新人名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(33,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 批准人Id
 /// </summary>
 [BindColumn(34,"a", "ApprHumId", "批准人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 批准人名称
 /// </summary>
 [BindColumn(35,"a", "ApprHumName", "批准人名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 批准日期
 /// </summary>
 [BindColumn(36,"a", "ApprDate", "批准日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(37,"a", "Memo", "备注","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 所属项目Id
 /// </summary>
 [BindColumn(38,"a", "OwnProjId", "所属项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 所属项目名称
 /// </summary>
 [BindColumn(39,"a", "OwnProjName", "所属项目名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String OwnProjName  { get { return _OwnProjName; } set { _OwnProjName = value; } }

 private System.Int32 _ReplyType;
 /// <summary>
 /// 回复类型  0:整改回复;1:复检回复;
 /// </summary>
 [BindColumn(40,"a", "ReplyType", "回复类型  0:整改回复;1:复检回复;","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 ReplyType  { get { return _ReplyType; } set { _ReplyType = value; } }

      
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
if (name == "TITLE")
{
return _Title;
}
if (name == "TAB")
{
return _Tab;
}
if (name == "CHECKDATE")
{
return _CheckDate;
}
if (name == "CHECKHUMAN")
{
return _CheckHuman;
}
if (name == "CHECKHUMANID")
{
return _CheckHumanId;
}
if (name == "CHECKCONTENT")
{
return _CheckContent;
}
if (name == "CHECKRESULT")
{
return _CheckResult;
}
if (name == "CHECKSTATUS")
{
return _CheckStatus;
}
if (name == "CHANGECONTENT")
{
return _ChangeContent;
}
if (name == "CHANGEDDATE")
{
return _ChangedDate;
}
if (name == "NOTIFYHUMAN")
{
return _NotifyHuman;
}
if (name == "NOTIFYHUMANID")
{
return _NotifyHumanId;
}
if (name == "RECORDHUMAN")
{
return _RecordHuman;
}
if (name == "RECORDHUMANID")
{
return _RecordHumanId;
}
if (name == "CHANGEHUMAN")
{
return _ChangeHuman;
}
if (name == "CHANGEHUMANID")
{
return _ChangeHumanId;
}
if (name == "CCHUMAN")
{
return _CCHuman;
}
if (name == "CCHUMANID")
{
return _CCHumanId;
}
if (name == "RECHECKHUMAN")
{
return _RecheckHuman;
}
if (name == "RECHECKHUNMANID")
{
return _RecheckHunmanId;
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
if (name == "REPLYTYPE")
{
return _ReplyType;
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
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
}
if (name == "TAB")
{
 _Tab = System.Convert.ToString(value);return;
}
if (name == "CHECKDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _CheckDate = System.Convert.ToDateTime(value);return;
}
if (name == "CHECKHUMAN")
{
 _CheckHuman = System.Convert.ToString(value);return;
}
if (name == "CHECKHUMANID")
{
 _CheckHumanId = System.Convert.ToString(value);return;
}
if (name == "CHECKCONTENT")
{
 _CheckContent = System.Convert.ToString(value);return;
}
if (name == "CHECKRESULT")
{
 _CheckResult = System.Convert.ToString(value);return;
}
if (name == "CHECKSTATUS")
{
 _CheckStatus = System.Convert.ToInt32(value);return;
}
if (name == "CHANGECONTENT")
{
 _ChangeContent = System.Convert.ToString(value);return;
}
if (name == "CHANGEDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ChangedDate = System.Convert.ToDateTime(value);return;
}
if (name == "NOTIFYHUMAN")
{
 _NotifyHuman = System.Convert.ToString(value);return;
}
if (name == "NOTIFYHUMANID")
{
 _NotifyHumanId = System.Convert.ToString(value);return;
}
if (name == "RECORDHUMAN")
{
 _RecordHuman = System.Convert.ToString(value);return;
}
if (name == "RECORDHUMANID")
{
 _RecordHumanId = System.Convert.ToString(value);return;
}
if (name == "CHANGEHUMAN")
{
 _ChangeHuman = System.Convert.ToString(value);return;
}
if (name == "CHANGEHUMANID")
{
 _ChangeHumanId = System.Convert.ToString(value);return;
}
if (name == "CCHUMAN")
{
 _CCHuman = System.Convert.ToString(value);return;
}
if (name == "CCHUMANID")
{
 _CCHumanId = System.Convert.ToString(value);return;
}
if (name == "RECHECKHUMAN")
{
 _RecheckHuman = System.Convert.ToString(value);return;
}
if (name == "RECHECKHUNMANID")
{
 _RecheckHunmanId = System.Convert.ToString(value);return;
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
if (name == "REPLYTYPE")
{
 _ReplyType = System.Convert.ToInt32(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}