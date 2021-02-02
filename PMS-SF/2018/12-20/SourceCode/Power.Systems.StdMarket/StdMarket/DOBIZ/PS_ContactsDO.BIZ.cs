 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdMarket.StdMarket
{
    /// <summary>
    /// 客户联系人
    /// </summary>
    public class PS_ContactsDO : PS_ContactsDO<PS_ContactsDO>
    {

    }

	/// <summary>
    /// 客户联系人
    /// </summary>
	  [BindEntity(KeyWord="PS_Contacts",EntityType = typeof(Power.Systems.StdMarket.StdMarket.PS_ContactsDO),Description = "客户联系人"  )] 

	 [BindTable( "PS_MK_Contacts", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PS_MK_Contacts", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PS_MK_Contacts",Description="")]

    public   class PS_ContactsDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdMarket.StdMarket.PS_ContactsDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _PrentId;
 /// <summary>
 /// 外键
 /// </summary>
 [BindColumn(2,"a", "PrentId", "外键","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid PrentId  { get { return _PrentId; } set { _PrentId = value; } }

 private System.String _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _Name;
 /// <summary>
 /// 姓名
 /// </summary>
 [BindColumn(4,"a", "Name", "姓名","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _Position;
 /// <summary>
 /// 职务
 /// </summary>
 [BindColumn(5,"a", "Position", "职务","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Position  { get { return _Position; } set { _Position = value; } }

 private System.String _Tel;
 /// <summary>
 /// 电话
 /// </summary>
 [BindColumn(6,"a", "Tel", "电话","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Tel  { get { return _Tel; } set { _Tel = value; } }

 private System.String _Fax;
 /// <summary>
 /// 传真
 /// </summary>
 [BindColumn(7,"a", "Fax", "传真","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Fax  { get { return _Fax; } set { _Fax = value; } }

 private System.String _Email;
 /// <summary>
 /// 邮箱
 /// </summary>
 [BindColumn(8,"a", "Email", "邮箱","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Email  { get { return _Email; } set { _Email = value; } }

 private System.SByte _isAgent;
 /// <summary>
 /// 是否代理人
 /// </summary>
 [BindColumn(9,"a", "isAgent", "是否代理人","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte isAgent  { get { return _isAgent; } set { _isAgent = value; } }

 private System.Int32 _sex;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(10,"a", "sex", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 sex  { get { return _sex; } set { _sex = value; } }

 private System.DateTime _Birthday;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(11,"a", "Birthday", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime Birthday  { get { return _Birthday; } set { _Birthday = value; } }

 private System.String _ParentName;
 /// <summary>
 /// 客户名称
 /// </summary>
 [BindColumn(12,"a", "ParentName", "客户名称","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String ParentName  { get { return _ParentName; } set { _ParentName = value; } }

 private System.String _PlaceOfOrigin;
 /// <summary>
 /// 籍贯
 /// </summary>
 [BindColumn(13,"a", "PlaceOfOrigin", "籍贯","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String PlaceOfOrigin  { get { return _PlaceOfOrigin; } set { _PlaceOfOrigin = value; } }

 private System.Int32 _Status;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(14,"a", "Status", "","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Status  { get { return _Status; } set { _Status = value; } }

 private System.String _RegHumName;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(15,"a", "RegHumName", "","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String RegHumName  { get { return _RegHumName; } set { _RegHumName = value; } }

 private System.DateTime _RegDate;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(16,"a", "RegDate", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime RegDate  { get { return _RegDate; } set { _RegDate = value; } }

      
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
if (name == "PRENTID")
{
return _PrentId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "NAME")
{
return _Name;
}
if (name == "POSITION")
{
return _Position;
}
if (name == "TEL")
{
return _Tel;
}
if (name == "FAX")
{
return _Fax;
}
if (name == "EMAIL")
{
return _Email;
}
if (name == "ISAGENT")
{
return _isAgent;
}
if (name == "SEX")
{
return _sex;
}
if (name == "BIRTHDAY")
{
return _Birthday;
}
if (name == "PARENTNAME")
{
return _ParentName;
}
if (name == "PLACEOFORIGIN")
{
return _PlaceOfOrigin;
}
if (name == "STATUS")
{
return _Status;
}
if (name == "REGHUMNAME")
{
return _RegHumName;
}
if (name == "REGDATE")
{
return _RegDate;
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
if (name == "PRENTID")
{
 _PrentId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToString(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "POSITION")
{
 _Position = System.Convert.ToString(value);return;
}
if (name == "TEL")
{
 _Tel = System.Convert.ToString(value);return;
}
if (name == "FAX")
{
 _Fax = System.Convert.ToString(value);return;
}
if (name == "EMAIL")
{
 _Email = System.Convert.ToString(value);return;
}
if (name == "ISAGENT")
{
 _isAgent = System.Convert.ToSByte(value);return;
}
if (name == "SEX")
{
 _sex = System.Convert.ToInt32(value);return;
}
if (name == "BIRTHDAY")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _Birthday = System.Convert.ToDateTime(value);return;
}
if (name == "PARENTNAME")
{
 _ParentName = System.Convert.ToString(value);return;
}
if (name == "PLACEOFORIGIN")
{
 _PlaceOfOrigin = System.Convert.ToString(value);return;
}
if (name == "STATUS")
{
 _Status = System.Convert.ToInt32(value);return;
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

			    base[name] = value;
			}
		}
		#endregion
	}
}