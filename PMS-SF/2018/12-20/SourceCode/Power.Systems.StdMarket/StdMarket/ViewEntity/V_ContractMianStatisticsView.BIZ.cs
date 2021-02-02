 
 
 using System;
 using System.Collections.Generic;
 using System.Collections;
 using System.Text; 
 using System.Linq;
 using XCode.Attributes;
 using Power.Business.ViewEntity;
 using Power.Business.Attributes;
 using XCode.DataAccessLayer;

  namespace Power.Systems.StdMarket.StdMarket
{ 

    /// <summary>
    /// V_ContractMianStatistics
    /// </summary>
  
    public partial class V_ContractMianStatisticsView : V_ContractMianStatisticsView<V_ContractMianStatisticsView>
    {

    }

    /// <summary>
    /// V_ContractMianStatistics
    /// </summary> 
	
	 [BindViewEntityConfig(KeyWord = "V_ContractMianStatistics",BusinessKeyWord = "",ViewEntityType = Power.Business.Attributes.EViewEntityType.SQLView, Description = "V_ContractMianStatistics")]
 [BindIndex(Name = "pk_View", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "project_guid" ,Description="")]

    public partial class V_ContractMianStatisticsView<TViewEntity> : ViewEntity<TViewEntity> where TViewEntity : IViewEntity, new()
    {
	
	  #region 属性

	    
 private System.Double _PaymentAmount;
 /// <summary>
 /// PaymentAmount
 /// </summary>
 [BindColumn(0, "", "PaymentAmount","PaymentAmount",null ) ]
 public System.Double PaymentAmount  { get { return _PaymentAmount; } set { _PaymentAmount = value; } }

 private System.Double _OutvoiceAmount;
 /// <summary>
 /// OutvoiceAmount
 /// </summary>
 [BindColumn(0, "", "OutvoiceAmount","OutvoiceAmount",null ) ]
 public System.Double OutvoiceAmount  { get { return _OutvoiceAmount; } set { _OutvoiceAmount = value; } }

 private System.Double _S_OutvoiceAmount;
 /// <summary>
 /// S_OutvoiceAmount
 /// </summary>
 [BindColumn(0, "", "S_OutvoiceAmount","S_OutvoiceAmount",null ) ]
 public System.Double S_OutvoiceAmount  { get { return _S_OutvoiceAmount; } set { _S_OutvoiceAmount = value; } }

 private System.Double _E_Sum;
 /// <summary>
 /// E_Sum
 /// </summary>
 [BindColumn(0, "", "E_Sum","E_Sum",null ) ]
 public System.Double E_Sum  { get { return _E_Sum; } set { _E_Sum = value; } }

 private System.Double _C_PaymentAmount;
 /// <summary>
 /// C_PaymentAmount
 /// </summary>
 [BindColumn(0, "", "C_PaymentAmount","C_PaymentAmount",null ) ]
 public System.Double C_PaymentAmount  { get { return _C_PaymentAmount; } set { _C_PaymentAmount = value; } }

 private System.Double _ReceiveAmount;
 /// <summary>
 /// ReceiveAmount
 /// </summary>
 [BindColumn(0, "", "ReceiveAmount","ReceiveAmount",null ) ]
 public System.Double ReceiveAmount  { get { return _ReceiveAmount; } set { _ReceiveAmount = value; } }

 private System.Double _InSum;
 /// <summary>
 /// InSum
 /// </summary>
 [BindColumn(0, "", "InSum","InSum",null ) ]
 public System.Double InSum  { get { return _InSum; } set { _InSum = value; } }

 private System.Double _E_PaymentAmount;
 /// <summary>
 /// E_PaymentAmount
 /// </summary>
 [BindColumn(0, "", "E_PaymentAmount","E_PaymentAmount",null ) ]
 public System.Double E_PaymentAmount  { get { return _E_PaymentAmount; } set { _E_PaymentAmount = value; } }

 private System.Double _Outdifference;
 /// <summary>
 /// Outdifference
 /// </summary>
 [BindColumn(0, "", "Outdifference","Outdifference",null ) ]
 public System.Double Outdifference  { get { return _Outdifference; } set { _Outdifference = value; } }

 private System.Double _P_PaymentAmount;
 /// <summary>
 /// P_PaymentAmount
 /// </summary>
 [BindColumn(0, "", "P_PaymentAmount","P_PaymentAmount",null ) ]
 public System.Double P_PaymentAmount  { get { return _P_PaymentAmount; } set { _P_PaymentAmount = value; } }

 private System.Double _C_Sum;
 /// <summary>
 /// C_Sum
 /// </summary>
 [BindColumn(0, "", "C_Sum","C_Sum",null ) ]
 public System.Double C_Sum  { get { return _C_Sum; } set { _C_Sum = value; } }

 private System.Double _GrossProfit;
 /// <summary>
 /// GrossProfit
 /// </summary>
 [BindColumn(0, "", "GrossProfit","GrossProfit",null ) ]
 public System.Double GrossProfit  { get { return _GrossProfit; } set { _GrossProfit = value; } }

 private System.String _LongCode;
 /// <summary>
 /// LongCode
 /// </summary>
 [BindColumn(0, "", "LongCode","LongCode",null ) ]
 public System.String LongCode  { get { return _LongCode; } set { _LongCode = value; } }

 private System.String _project_name;
 /// <summary>
 /// project_name
 /// </summary>
 [BindColumn(0, "", "project_name","project_name",null ) ]
 public System.String project_name  { get { return _project_name; } set { _project_name = value; } }

 private System.String _project_shortname;
 /// <summary>
 /// project_shortname
 /// </summary>
 [BindColumn(0, "", "project_shortname","project_shortname",null ) ]
 public System.String project_shortname  { get { return _project_shortname; } set { _project_shortname = value; } }

 private System.Double _Indifference;
 /// <summary>
 /// Indifference
 /// </summary>
 [BindColumn(0, "", "Indifference","Indifference",null ) ]
 public System.Double Indifference  { get { return _Indifference; } set { _Indifference = value; } }

 private System.Double _ReplyAmount;
 /// <summary>
 /// ReplyAmount
 /// </summary>
 [BindColumn(0, "", "ReplyAmount","ReplyAmount",null ) ]
 public System.Double ReplyAmount  { get { return _ReplyAmount; } set { _ReplyAmount = value; } }

 private System.Double _P_Sum;
 /// <summary>
 /// P_Sum
 /// </summary>
 [BindColumn(0, "", "P_Sum","P_Sum",null ) ]
 public System.Double P_Sum  { get { return _P_Sum; } set { _P_Sum = value; } }

 private System.Double _S_PaymentAmount;
 /// <summary>
 /// S_PaymentAmount
 /// </summary>
 [BindColumn(0, "", "S_PaymentAmount","S_PaymentAmount",null ) ]
 public System.Double S_PaymentAmount  { get { return _S_PaymentAmount; } set { _S_PaymentAmount = value; } }

 private System.Double _P_OutvoiceAmount;
 /// <summary>
 /// P_OutvoiceAmount
 /// </summary>
 [BindColumn(0, "", "P_OutvoiceAmount","P_OutvoiceAmount",null ) ]
 public System.Double P_OutvoiceAmount  { get { return _P_OutvoiceAmount; } set { _P_OutvoiceAmount = value; } }

 private System.Double _OutChange;
 /// <summary>
 /// OutChange
 /// </summary>
 [BindColumn(0, "", "OutChange","OutChange",null ) ]
 public System.Double OutChange  { get { return _OutChange; } set { _OutChange = value; } }

 private System.Double _S_Sum;
 /// <summary>
 /// S_Sum
 /// </summary>
 [BindColumn(0, "", "S_Sum","S_Sum",null ) ]
 public System.Double S_Sum  { get { return _S_Sum; } set { _S_Sum = value; } }

 private System.Double _PmCost;
 /// <summary>
 /// PmCost
 /// </summary>
 [BindColumn(0, "", "PmCost","PmCost",null ) ]
 public System.Double PmCost  { get { return _PmCost; } set { _PmCost = value; } }

 private System.String _project_guid;
 /// <summary>
 /// project_guid
 /// </summary>
 [BindColumn(0, "", "project_guid","project_guid",null,IsPrimaryKey =true ,IsIdentity =true  ) ]
 public System.String project_guid  { get { return _project_guid; } set { _project_guid = value; } }

 private System.Double _E_OutvoiceAmount;
 /// <summary>
 /// E_OutvoiceAmount
 /// </summary>
 [BindColumn(0, "", "E_OutvoiceAmount","E_OutvoiceAmount",null ) ]
 public System.Double E_OutvoiceAmount  { get { return _E_OutvoiceAmount; } set { _E_OutvoiceAmount = value; } }

 private System.Double _InvoiceAmount;
 /// <summary>
 /// InvoiceAmount
 /// </summary>
 [BindColumn(0, "", "InvoiceAmount","InvoiceAmount",null ) ]
 public System.Double InvoiceAmount  { get { return _InvoiceAmount; } set { _InvoiceAmount = value; } }

 private System.Double _OutSum;
 /// <summary>
 /// OutSum
 /// </summary>
 [BindColumn(0, "", "OutSum","OutSum",null ) ]
 public System.Double OutSum  { get { return _OutSum; } set { _OutSum = value; } }

 private System.Double _C_OutvoiceAmount;
 /// <summary>
 /// C_OutvoiceAmount
 /// </summary>
 [BindColumn(0, "", "C_OutvoiceAmount","C_OutvoiceAmount",null ) ]
 public System.Double C_OutvoiceAmount  { get { return _C_OutvoiceAmount; } set { _C_OutvoiceAmount = value; } }

 private System.Double _InChange;
 /// <summary>
 /// InChange
 /// </summary>
 [BindColumn(0, "", "InChange","InChange",null ) ]
 public System.Double InChange  { get { return _InChange; } set { _InChange = value; } }

      
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
			    if (name == "PAYMENTAMOUNT")
{
return _PaymentAmount;
}
if (name == "OUTVOICEAMOUNT")
{
return _OutvoiceAmount;
}
if (name == "S_OUTVOICEAMOUNT")
{
return _S_OutvoiceAmount;
}
if (name == "E_SUM")
{
return _E_Sum;
}
if (name == "C_PAYMENTAMOUNT")
{
return _C_PaymentAmount;
}
if (name == "RECEIVEAMOUNT")
{
return _ReceiveAmount;
}
if (name == "INSUM")
{
return _InSum;
}
if (name == "E_PAYMENTAMOUNT")
{
return _E_PaymentAmount;
}
if (name == "OUTDIFFERENCE")
{
return _Outdifference;
}
if (name == "P_PAYMENTAMOUNT")
{
return _P_PaymentAmount;
}
if (name == "C_SUM")
{
return _C_Sum;
}
if (name == "GROSSPROFIT")
{
return _GrossProfit;
}
if (name == "LONGCODE")
{
return _LongCode;
}
if (name == "PROJECT_NAME")
{
return _project_name;
}
if (name == "PROJECT_SHORTNAME")
{
return _project_shortname;
}
if (name == "INDIFFERENCE")
{
return _Indifference;
}
if (name == "REPLYAMOUNT")
{
return _ReplyAmount;
}
if (name == "P_SUM")
{
return _P_Sum;
}
if (name == "S_PAYMENTAMOUNT")
{
return _S_PaymentAmount;
}
if (name == "P_OUTVOICEAMOUNT")
{
return _P_OutvoiceAmount;
}
if (name == "OUTCHANGE")
{
return _OutChange;
}
if (name == "S_SUM")
{
return _S_Sum;
}
if (name == "PMCOST")
{
return _PmCost;
}
if (name == "PROJECT_GUID")
{
return _project_guid;
}
if (name == "E_OUTVOICEAMOUNT")
{
return _E_OutvoiceAmount;
}
if (name == "INVOICEAMOUNT")
{
return _InvoiceAmount;
}
if (name == "OUTSUM")
{
return _OutSum;
}
if (name == "C_OUTVOICEAMOUNT")
{
return _C_OutvoiceAmount;
}
if (name == "INCHANGE")
{
return _InChange;
}

			    return base[name];
			}
			set 
			{
			   name = name.ToUpper();
			       if (name == "PAYMENTAMOUNT")
{
 _PaymentAmount = System.Convert.ToDouble(value);return;
}
if (name == "OUTVOICEAMOUNT")
{
 _OutvoiceAmount = System.Convert.ToDouble(value);return;
}
if (name == "S_OUTVOICEAMOUNT")
{
 _S_OutvoiceAmount = System.Convert.ToDouble(value);return;
}
if (name == "E_SUM")
{
 _E_Sum = System.Convert.ToDouble(value);return;
}
if (name == "C_PAYMENTAMOUNT")
{
 _C_PaymentAmount = System.Convert.ToDouble(value);return;
}
if (name == "RECEIVEAMOUNT")
{
 _ReceiveAmount = System.Convert.ToDouble(value);return;
}
if (name == "INSUM")
{
 _InSum = System.Convert.ToDouble(value);return;
}
if (name == "E_PAYMENTAMOUNT")
{
 _E_PaymentAmount = System.Convert.ToDouble(value);return;
}
if (name == "OUTDIFFERENCE")
{
 _Outdifference = System.Convert.ToDouble(value);return;
}
if (name == "P_PAYMENTAMOUNT")
{
 _P_PaymentAmount = System.Convert.ToDouble(value);return;
}
if (name == "C_SUM")
{
 _C_Sum = System.Convert.ToDouble(value);return;
}
if (name == "GROSSPROFIT")
{
 _GrossProfit = System.Convert.ToDouble(value);return;
}
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
}
if (name == "PROJECT_NAME")
{
 _project_name = System.Convert.ToString(value);return;
}
if (name == "PROJECT_SHORTNAME")
{
 _project_shortname = System.Convert.ToString(value);return;
}
if (name == "INDIFFERENCE")
{
 _Indifference = System.Convert.ToDouble(value);return;
}
if (name == "REPLYAMOUNT")
{
 _ReplyAmount = System.Convert.ToDouble(value);return;
}
if (name == "P_SUM")
{
 _P_Sum = System.Convert.ToDouble(value);return;
}
if (name == "S_PAYMENTAMOUNT")
{
 _S_PaymentAmount = System.Convert.ToDouble(value);return;
}
if (name == "P_OUTVOICEAMOUNT")
{
 _P_OutvoiceAmount = System.Convert.ToDouble(value);return;
}
if (name == "OUTCHANGE")
{
 _OutChange = System.Convert.ToDouble(value);return;
}
if (name == "S_SUM")
{
 _S_Sum = System.Convert.ToDouble(value);return;
}
if (name == "PMCOST")
{
 _PmCost = System.Convert.ToDouble(value);return;
}
if (name == "PROJECT_GUID")
{
 _project_guid = System.Convert.ToString(value);return;
}
if (name == "E_OUTVOICEAMOUNT")
{
 _E_OutvoiceAmount = System.Convert.ToDouble(value);return;
}
if (name == "INVOICEAMOUNT")
{
 _InvoiceAmount = System.Convert.ToDouble(value);return;
}
if (name == "OUTSUM")
{
 _OutSum = System.Convert.ToDouble(value);return;
}
if (name == "C_OUTVOICEAMOUNT")
{
 _C_OutvoiceAmount = System.Convert.ToDouble(value);return;
}
if (name == "INCHANGE")
{
 _InChange = System.Convert.ToDouble(value);return;
}

			    base[name] = value;
			}
		}
		#endregion

		#region 辅助
		  public override  SelectBuilder ViewSQL { 
			 get 
			 {
				 if (_ViewSQL != null) return _ViewSQL;
SelectBuilder sSql = new SelectBuilder();
sSql.Column = @"*";
sSql.Table = @"V_ContractMianStatistics";
sSql.Where = @"LongCode like '%.%'";
sSql.OrderBy = "LongCode";
 _ViewSQL = sSql; return _ViewSQL;   
			 }
	     }
		#endregion
	}
}