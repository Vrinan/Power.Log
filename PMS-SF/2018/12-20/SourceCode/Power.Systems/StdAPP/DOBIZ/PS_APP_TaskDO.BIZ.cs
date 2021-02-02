 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdAPP
{
    /// <summary>
    /// 任务
    /// </summary>
    public class PS_APP_TaskDO : PS_APP_TaskDO<PS_APP_TaskDO>
    {

    }

	/// <summary>
    /// 任务
    /// </summary>
	  [BindEntity(KeyWord="PS_APP_Task",EntityType = typeof(Power.Systems.StdAPP.PS_APP_TaskDO),Description = "任务"  )] 

	 [BindTable( "PS_APP_Task", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_APP_Task", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_APP_Task",Description="")]

    public   class PS_APP_TaskDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdAPP.PS_APP_TaskDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _Name;
 /// <summary>
 /// 任务名称
 /// </summary>
 [BindColumn(2,"a", "Name", "任务名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.Int32 _TaskStatus;
 /// <summary>
 /// 任务状态：0执行中，1已完成，2未完成
 /// </summary>
 [BindColumn(3,"a", "TaskStatus", "任务状态：0执行中，1已完成，2未完成","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 TaskStatus  { get { return _TaskStatus; } set { _TaskStatus = value; } }

 private System.DateTime _DueDate;
 /// <summary>
 /// 截止日期
 /// </summary>
 [BindColumn(4,"a", "DueDate", "截止日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime DueDate  { get { return _DueDate; } set { _DueDate = value; } }

 private System.DateTime _BeginDate;
 /// <summary>
 /// 开始时间
 /// </summary>
 [BindColumn(5,"a", "BeginDate", "开始时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime BeginDate  { get { return _BeginDate; } set { _BeginDate = value; } }

 private System.DateTime _FinishDate;
 /// <summary>
 /// 实际完成时间
 /// </summary>
 [BindColumn(6,"a", "FinishDate", "实际完成时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime FinishDate  { get { return _FinishDate; } set { _FinishDate = value; } }

 private System.Int32 _Priority;
 /// <summary>
 /// 优先级，0一般，1低，2中，3高
 /// </summary>
 [BindColumn(7,"a", "Priority", "优先级，0一般，1低，2中，3高","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Priority  { get { return _Priority; } set { _Priority = value; } }

 private System.String _Describe;
 /// <summary>
 /// 描述
 /// </summary>
 [BindColumn(8,"a", "Describe", "描述","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Describe  { get { return _Describe; } set { _Describe = value; } }

 private System.Guid _PublishId;
 /// <summary>
 /// 发布人id
 /// </summary>
 [BindColumn(9,"a", "PublishId", "发布人id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PublishId  { get { return _PublishId; } set { _PublishId = value; } }

 private System.String _PublishName;
 /// <summary>
 /// 发布人名称
 /// </summary>
 [BindColumn(10,"a", "PublishName", "发布人名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String PublishName  { get { return _PublishName; } set { _PublishName = value; } }

 private System.String _ResponsibleId;
 /// <summary>
 /// 负责人id
 /// </summary>
 [BindColumn(11,"a", "ResponsibleId", "负责人id","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String ResponsibleId  { get { return _ResponsibleId; } set { _ResponsibleId = value; } }

 private System.String _ResponsibleName;
 /// <summary>
 /// 负责人名称
 /// </summary>
 [BindColumn(12,"a", "ResponsibleName", "负责人名称","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String ResponsibleName  { get { return _ResponsibleName; } set { _ResponsibleName = value; } }

 private System.String _ExecutorId;
 /// <summary>
 /// 执行人id，多个逗号隔开
 /// </summary>
 [BindColumn(13,"a", "ExecutorId", "执行人id，多个逗号隔开","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String ExecutorId  { get { return _ExecutorId; } set { _ExecutorId = value; } }

 private System.String _ExecutorName;
 /// <summary>
 /// 执行人名称，多个逗号隔开，与id对应
 /// </summary>
 [BindColumn(14,"a", "ExecutorName", "执行人名称，多个逗号隔开，与id对应","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String ExecutorName  { get { return _ExecutorName; } set { _ExecutorName = value; } }

 private System.Int32 _EvaluationLevel;
 /// <summary>
 /// 评价登记，0：较差，1中等，2良好，3优秀
 /// </summary>
 [BindColumn(15,"a", "EvaluationLevel", "评价登记，0：较差，1中等，2良好，3优秀","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 EvaluationLevel  { get { return _EvaluationLevel; } set { _EvaluationLevel = value; } }

 private System.String _Evaluation;
 /// <summary>
 /// 评价描述
 /// </summary>
 [BindColumn(16,"a", "Evaluation", "评价描述","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Evaluation  { get { return _Evaluation; } set { _Evaluation = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(17,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.SByte _Status;
 /// <summary>
 /// 表单状态；0新增，20审批中，35生效，40终止，50批准
 /// </summary>
 [BindColumn(18,"a", "Status", "表单状态；0新增，20审批中，35生效，40终止，50批准","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte Status  { get { return _Status; } set { _Status = value; } }

 private System.Guid _RegHumId;
 /// <summary>
 /// 录入人Id
 /// </summary>
 [BindColumn(19,"a", "RegHumId", "录入人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegHumId  { get { return _RegHumId; } set { _RegHumId = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 录入人名称
 /// </summary>
 [BindColumn(20,"a", "RegHumName", "录入人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 录入日期
 /// </summary>
 [BindColumn(21,"a", "RegDate", "录入日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

 private System.Guid _RegPosiId;
 /// <summary>
 /// 录入人岗位Id
 /// </summary>
 [BindColumn(22,"a", "RegPosiId", "录入人岗位Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegPosiId  { get { return _RegPosiId; } set { _RegPosiId = value; } }

 private System.Guid _RegDeptId;
 /// <summary>
 /// 录入人部门Id
 /// </summary>
 [BindColumn(23,"a", "RegDeptId", "录入人部门Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RegDeptId  { get { return _RegDeptId; } set { _RegDeptId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 记录所属EPS节点Id
 /// </summary>
 [BindColumn(24,"a", "EpsProjId", "记录所属EPS节点Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.Guid _RecycleHumId;
 /// <summary>
 /// 删除人Id
 /// </summary>
 [BindColumn(25,"a", "RecycleHumId", "删除人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid RecycleHumId  { get { return _RecycleHumId; } set { _RecycleHumId = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后更新人Id
 /// </summary>
 [BindColumn(26,"a", "UpdHumId", "最后更新人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后更新人名称
 /// </summary>
 [BindColumn(27,"a", "UpdHumName", "最后更新人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(28,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _ApprHumId;
 /// <summary>
 /// 批准人Id
 /// </summary>
 [BindColumn(29,"a", "ApprHumId", "批准人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ApprHumId  { get { return _ApprHumId; } set { _ApprHumId = value; } }

 private System.String _ApprHumName;
 /// <summary>
 /// 批准人名称
 /// </summary>
 [BindColumn(30,"a", "ApprHumName", "批准人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ApprHumName  { get { return _ApprHumName; } set { _ApprHumName = value; } }

 private System.DateTime _ApprDate;
 /// <summary>
 /// 批准日期
 /// </summary>
 [BindColumn(31,"a", "ApprDate", "批准日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ApprDate  { get { return _ApprDate; } set { _ApprDate = value; } }

 private System.String _Memo;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(32,"a", "Memo", "备注","", "NCHAR", -1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =-1 )]
 public  System.String Memo  { get { return _Memo; } set { _Memo = value; } }

 private System.Guid _OwnProjId;
 /// <summary>
 /// 所属项目Id
 /// </summary>
 [BindColumn(33,"a", "OwnProjId", "所属项目Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid OwnProjId  { get { return _OwnProjId; } set { _OwnProjId = value; } }

 private System.String _OwnProjName;
 /// <summary>
 /// 管理层级名称
 /// </summary>
 [BindColumn(34,"a", "OwnProjName", "管理层级名称","", "NCHAR", 255,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =255 )]
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
if (name == "NAME")
{
return _Name;
}
if (name == "TASKSTATUS")
{
return _TaskStatus;
}
if (name == "DUEDATE")
{
return _DueDate;
}
if (name == "BEGINDATE")
{
return _BeginDate;
}
if (name == "FINISHDATE")
{
return _FinishDate;
}
if (name == "PRIORITY")
{
return _Priority;
}
if (name == "DESCRIBE")
{
return _Describe;
}
if (name == "PUBLISHID")
{
return _PublishId;
}
if (name == "PUBLISHNAME")
{
return _PublishName;
}
if (name == "RESPONSIBLEID")
{
return _ResponsibleId;
}
if (name == "RESPONSIBLENAME")
{
return _ResponsibleName;
}
if (name == "EXECUTORID")
{
return _ExecutorId;
}
if (name == "EXECUTORNAME")
{
return _ExecutorName;
}
if (name == "EVALUATIONLEVEL")
{
return _EvaluationLevel;
}
if (name == "EVALUATION")
{
return _Evaluation;
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
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "TASKSTATUS")
{
 _TaskStatus = System.Convert.ToInt32(value);return;
}
if (name == "DUEDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _DueDate = System.Convert.ToDateTime(value);return;
}
if (name == "BEGINDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _BeginDate = System.Convert.ToDateTime(value);return;
}
if (name == "FINISHDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _FinishDate = System.Convert.ToDateTime(value);return;
}
if (name == "PRIORITY")
{
 _Priority = System.Convert.ToInt32(value);return;
}
if (name == "DESCRIBE")
{
 _Describe = System.Convert.ToString(value);return;
}
if (name == "PUBLISHID")
{
 _PublishId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PUBLISHNAME")
{
 _PublishName = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEID")
{
 _ResponsibleId = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLENAME")
{
 _ResponsibleName = System.Convert.ToString(value);return;
}
if (name == "EXECUTORID")
{
 _ExecutorId = System.Convert.ToString(value);return;
}
if (name == "EXECUTORNAME")
{
 _ExecutorName = System.Convert.ToString(value);return;
}
if (name == "EVALUATIONLEVEL")
{
 _EvaluationLevel = System.Convert.ToInt32(value);return;
}
if (name == "EVALUATION")
{
 _Evaluation = System.Convert.ToString(value);return;
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