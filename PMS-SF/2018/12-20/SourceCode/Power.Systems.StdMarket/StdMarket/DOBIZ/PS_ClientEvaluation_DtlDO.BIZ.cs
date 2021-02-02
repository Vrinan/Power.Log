 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 客户评价子表
    /// </summary>
    public class PS_ClientEvaluation_DtlDO : PS_ClientEvaluation_DtlDO<PS_ClientEvaluation_DtlDO>
    {

    }

	/// <summary>
    /// 客户评价子表
    /// </summary>
	  [BindEntity(KeyWord="PS_ClientEvaluation_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ClientEvaluation_DtlDO),Description = "客户评价子表"  )] 

	 [BindTable( "PS_MK_ClientEvaluation_Dtl", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_ClientEvaluation_Dtl", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_ClientEvaluation_Dtl",Description="")]

    public   class PS_ClientEvaluation_DtlDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ClientEvaluation_DtlDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.String _EvaluationStandard;
 /// <summary>
 /// 评价标准
 /// </summary>
 [BindColumn(1,"a", "EvaluationStandard", "评价标准","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =200 )]
 public  System.String EvaluationStandard  { get { return _EvaluationStandard; } set { _EvaluationStandard = value; } }

 private System.Guid _MasterId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "MasterId", "","", "NCHAR", 0,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =0 )]
 public  System.Guid MasterId  { get { return _MasterId; } set { _MasterId = value; } }

 private System.Decimal _FullScore;
 /// <summary>
 /// 总分
 /// </summary>
 [BindColumn(1,"a", "FullScore", "总分","", "NCHAR", 6,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =6 )]
 public  System.Decimal FullScore  { get { return _FullScore; } set { _FullScore = value; } }

 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.String _EvaluationCode;
 /// <summary>
 /// 编号
 /// </summary>
 [BindColumn(1,"a", "EvaluationCode", "编号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =50 )]
 public  System.String EvaluationCode  { get { return _EvaluationCode; } set { _EvaluationCode = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(2,"a", "ParentId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

 private System.String _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _EvaluationItem;
 /// <summary>
 /// 评价项目
 /// </summary>
 [BindColumn(4,"a", "EvaluationItem", "评价项目","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String EvaluationItem  { get { return _EvaluationItem; } set { _EvaluationItem = value; } }

 private System.Double _EvaluationScore;
 /// <summary>
 /// 得分
 /// </summary>
 [BindColumn(5,"a", "EvaluationScore", "得分","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double EvaluationScore  { get { return _EvaluationScore; } set { _EvaluationScore = value; } }

 private System.String _EvaluationLevel;
 /// <summary>
 /// 评价等级
 /// </summary>
 [BindColumn(6,"a", "EvaluationLevel", "评价等级","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String EvaluationLevel  { get { return _EvaluationLevel; } set { _EvaluationLevel = value; } }

      
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
			    if (name == "EVALUATIONSTANDARD")
{
return _EvaluationStandard;
}
if (name == "MASTERID")
{
return _MasterId;
}
if (name == "FULLSCORE")
{
return _FullScore;
}
if (name == "ID")
{
return _Id;
}
if (name == "EVALUATIONCODE")
{
return _EvaluationCode;
}
if (name == "PARENTID")
{
return _ParentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "EVALUATIONITEM")
{
return _EvaluationItem;
}
if (name == "EVALUATIONSCORE")
{
return _EvaluationScore;
}
if (name == "EVALUATIONLEVEL")
{
return _EvaluationLevel;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "EVALUATIONSTANDARD")
{
 _EvaluationStandard = System.Convert.ToString(value);return;
}
if (name == "MASTERID")
{
 _MasterId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FULLSCORE")
{
 _FullScore = System.Convert.ToDecimal(value);return;
}
if (name == "ID")
{
 _Id = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EVALUATIONCODE")
{
 _EvaluationCode = System.Convert.ToString(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToString(value);return;
}
if (name == "EVALUATIONITEM")
{
 _EvaluationItem = System.Convert.ToString(value);return;
}
if (name == "EVALUATIONSCORE")
{
 _EvaluationScore = System.Convert.ToDouble(value);return;
}
if (name == "EVALUATIONLEVEL")
{
 _EvaluationLevel = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}