 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 投标任务分配
    /// </summary>
    public class PS_BidTask_DtlDO : PS_BidTask_DtlDO<PS_BidTask_DtlDO>
    {

    }

	/// <summary>
    /// 投标任务分配
    /// </summary>
	  [BindEntity(KeyWord="PS_BidTask_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_BidTask_DtlDO),Description = "投标任务分配"  )] 

	 [BindTable( "PS_MK_BidTask_Dtl", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_BidTask_Dtl", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_BidTask_Dtl",Description="")]

    public   class PS_BidTask_DtlDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_BidTask_DtlDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(2,"a", "ParentId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _TaskName;
 /// <summary>
 /// 任务名称
 /// </summary>
 [BindColumn(4,"a", "TaskName", "任务名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String TaskName  { get { return _TaskName; } set { _TaskName = value; } }

 private System.String _ResponsibleHuman;
 /// <summary>
 /// 责任人
 /// </summary>
 [BindColumn(5,"a", "ResponsibleHuman", "责任人","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ResponsibleHuman  { get { return _ResponsibleHuman; } set { _ResponsibleHuman = value; } }

 private System.Guid _ResponsibleHumanId;
 /// <summary>
 /// 责任人Id
 /// </summary>
 [BindColumn(6,"a", "ResponsibleHumanId", "责任人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ResponsibleHumanId  { get { return _ResponsibleHumanId; } set { _ResponsibleHumanId = value; } }

 private System.DateTime _PlanEndDate;
 /// <summary>
 /// 要求完成日期
 /// </summary>
 [BindColumn(7,"a", "PlanEndDate", "要求完成日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime PlanEndDate  { get { return _PlanEndDate; } set { _PlanEndDate = value; } }

      
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
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "TASKNAME")
{
return _TaskName;
}
if (name == "RESPONSIBLEHUMAN")
{
return _ResponsibleHuman;
}
if (name == "RESPONSIBLEHUMANID")
{
return _ResponsibleHumanId;
}
if (name == "PLANENDDATE")
{
return _PlanEndDate;
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
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "TASKNAME")
{
 _TaskName = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEHUMAN")
{
 _ResponsibleHuman = System.Convert.ToString(value);return;
}
if (name == "RESPONSIBLEHUMANID")
{
 _ResponsibleHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "PLANENDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _PlanEndDate = System.Convert.ToDateTime(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}