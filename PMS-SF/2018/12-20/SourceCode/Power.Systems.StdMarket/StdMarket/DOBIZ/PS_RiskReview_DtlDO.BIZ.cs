 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 项目风险评估详情
    /// </summary>
    public class PS_RiskReview_DtlDO : PS_RiskReview_DtlDO<PS_RiskReview_DtlDO>
    {

    }

	/// <summary>
    /// 项目风险评估详情
    /// </summary>
	  [BindEntity(KeyWord="PS_RiskReview_Dtl",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_RiskReview_DtlDO),Description = "项目风险评估详情"  )] 

	 [BindTable( "PS_MK_RiskReview_Dtl", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_RiskReview_Dtl", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_RiskReview_Dtl",Description="")]

    public   class PS_RiskReview_DtlDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_RiskReview_DtlDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _MasterId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "MasterId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MasterId  { get { return _MasterId; } set { _MasterId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _RiskClass;
 /// <summary>
 /// 风险类别
 /// </summary>
 [BindColumn(4,"a", "RiskClass", "风险类别","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String RiskClass  { get { return _RiskClass; } set { _RiskClass = value; } }

 private System.String _RiskName;
 /// <summary>
 /// 风险名称
 /// </summary>
 [BindColumn(5,"a", "RiskName", "风险名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String RiskName  { get { return _RiskName; } set { _RiskName = value; } }

 private System.String _RiskLevel;
 /// <summary>
 /// 风险等级
 /// </summary>
 [BindColumn(6,"a", "RiskLevel", "风险等级","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String RiskLevel  { get { return _RiskLevel; } set { _RiskLevel = value; } }

 private System.Double _probability;
 /// <summary>
 /// 发生概率
 /// </summary>
 [BindColumn(7,"a", "probability", "发生概率","", "NCHAR", 53,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =53 )]
 public  System.Double probability  { get { return _probability; } set { _probability = value; } }

 private System.String _PossibleAffection;
 /// <summary>
 /// 可能影响
 /// </summary>
 [BindColumn(8,"a", "PossibleAffection", "可能影响","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String PossibleAffection  { get { return _PossibleAffection; } set { _PossibleAffection = value; } }

 private System.String _PossiblePhase;
 /// <summary>
 /// 发生阶段
 /// </summary>
 [BindColumn(9,"a", "PossiblePhase", "发生阶段","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String PossiblePhase  { get { return _PossiblePhase; } set { _PossiblePhase = value; } }

 private System.String _HandingMethod;
 /// <summary>
 /// 控制措施
 /// </summary>
 [BindColumn(10,"a", "HandingMethod", "控制措施","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String HandingMethod  { get { return _HandingMethod; } set { _HandingMethod = value; } }

      
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
if (name == "MASTERID")
{
return _MasterId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "RISKCLASS")
{
return _RiskClass;
}
if (name == "RISKNAME")
{
return _RiskName;
}
if (name == "RISKLEVEL")
{
return _RiskLevel;
}
if (name == "PROBABILITY")
{
return _probability;
}
if (name == "POSSIBLEAFFECTION")
{
return _PossibleAffection;
}
if (name == "POSSIBLEPHASE")
{
return _PossiblePhase;
}
if (name == "HANDINGMETHOD")
{
return _HandingMethod;
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
if (name == "MASTERID")
{
 _MasterId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "RISKCLASS")
{
 _RiskClass = System.Convert.ToString(value);return;
}
if (name == "RISKNAME")
{
 _RiskName = System.Convert.ToString(value);return;
}
if (name == "RISKLEVEL")
{
 _RiskLevel = System.Convert.ToString(value);return;
}
if (name == "PROBABILITY")
{
 _probability = System.Convert.ToDouble(value);return;
}
if (name == "POSSIBLEAFFECTION")
{
 _PossibleAffection = System.Convert.ToString(value);return;
}
if (name == "POSSIBLEPHASE")
{
 _PossiblePhase = System.Convert.ToString(value);return;
}
if (name == "HANDINGMETHOD")
{
 _HandingMethod = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}