 
 
 using System;
 using System.Collections.Generic;
 using System.Collections;
 using System.Text; 
 using System.Linq;
 using XCode.Attributes;
 using Power.Business.ViewEntity;
 using Power.Business.Attributes;
 using XCode.DataAccessLayer;

  namespace Power.Systems.StdKM.StdKM
{ 

    /// <summary>
    /// 企业知识库左侧树
    /// </summary>
  
    public partial class V_PS_KM_DocFolderView : V_PS_KM_DocFolderView<V_PS_KM_DocFolderView>
    {

    }

    /// <summary>
    /// 企业知识库左侧树
    /// </summary> 
	
	 [BindViewEntityConfig(KeyWord = "V_PS_KM_DocFolder",BusinessKeyWord = "",ViewEntityType = Power.Business.Attributes.EViewEntityType.SQLView, Description = "企业知识库左侧树")]
 [BindIndex(Name = "pk_View", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id" ,Description="")]
 [BindIndex(Name = "pt_View", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "ParentId" ,Description="")]

    public partial class V_PS_KM_DocFolderView<TViewEntity> : ViewEntity<TViewEntity> where TViewEntity : IViewEntity, new()
    {
	
	  #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// Id
 /// </summary>
 [BindColumn(0, "VKDFR", "Id","Id",null,IsPrimaryKey =true ,IsIdentity =true  ) ]
 public System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _BizAreaId;
 /// <summary>
 /// BizAreaId
 /// </summary>
 [BindColumn(0, "VKDFR", "BizAreaId","BizAreaId",null ) ]
 public System.Guid BizAreaId  { get { return _BizAreaId; } set { _BizAreaId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// Sequ
 /// </summary>
 [BindColumn(0, "VKDFR", "Sequ","Sequ",null ) ]
 public System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _LongCode;
 /// <summary>
 /// LongCode
 /// </summary>
 [BindColumn(0, "VKDFR", "LongCode","LongCode",null ) ]
 public System.String LongCode  { get { return _LongCode; } set { _LongCode = value; } }

 private System.String _Name2;
 /// <summary>
 /// Name2
 /// </summary>
 [BindColumn(0, "VKDFR", "Name2","Name2",null ) ]
 public System.String Name2  { get { return _Name2; } set { _Name2 = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// EpsProjId
 /// </summary>
 [BindColumn(0, "VKDFR", "EpsProjId","EpsProjId",null ) ]
 public System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.String _Name;
 /// <summary>
 /// Name
 /// </summary>
 [BindColumn(0, "VKDFR", "Name","Name",null ) ]
 public System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _Code;
 /// <summary>
 /// Code
 /// </summary>
 [BindColumn(0, "VKDFR", "Code","Code",null ) ]
 public System.String Code  { get { return _Code; } set { _Code = value; } }

 private System.Guid _ParentId;
 /// <summary>
 /// ParentId
 /// </summary>
 [BindColumn(0, "VKDFR", "ParentId","ParentId",null ) ]
 public System.Guid ParentId  { get { return _ParentId; } set { _ParentId = value; } }

      
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
if (name == "BIZAREAID")
{
return _BizAreaId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "LONGCODE")
{
return _LongCode;
}
if (name == "NAME2")
{
return _Name2;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "NAME")
{
return _Name;
}
if (name == "CODE")
{
return _Code;
}
if (name == "PARENTID")
{
return _ParentId;
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
if (name == "BIZAREAID")
{
 _BizAreaId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "LONGCODE")
{
 _LongCode = System.Convert.ToString(value);return;
}
if (name == "NAME2")
{
 _Name2 = System.Convert.ToString(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "CODE")
{
 _Code = System.Convert.ToString(value);return;
}
if (name == "PARENTID")
{
 _ParentId = XCode.Common.Helper.ConvertToGuid(value);return;
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
sSql.Table = @"V_PS_KM_DocFolder VKDFR";
sSql.OrderBy = "Sequ";
 _ViewSQL = sSql; return _ViewSQL;   
			 }
	     }
		#endregion
	}
}