 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 人员签章
    /// </summary>
    public class HumanSignDO : HumanSignDO<HumanSignDO>
    {

    }

	/// <summary>
    /// 人员签章
    /// </summary>
	  [BindEntity(KeyWord="HumanSign",EntityType = typeof(Power.Systems.StdSystem.HumanSignDO),Description = "人员签章"  )] 

	 [BindTable( "PB_HumanSign", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_HumanSign", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_HumanSign",Description="")]
 [BindIndex(Name = "pt_PB_HumanSign", KeyType = Power.DataAccessLayer.KeyType.ParentKey, Columns = "HumanId,Id", TableName = "PB_HumanSign",Description="")]

    public   class HumanSignDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.HumanSignDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _HumanId;
 /// <summary>
 /// 人员ID
 /// </summary>
 [BindColumn(2,"a", "HumanId", "人员ID","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid HumanId  { get { return _HumanId; } set { _HumanId = value; } }

 private System.Boolean _Actived;
 /// <summary>
 /// 是否启用
 /// </summary>
 [BindColumn(3,"a", "Actived", "是否启用","", "NCHAR", 1,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =1 )]
 public  System.Boolean Actived  { get { return _Actived; } set { _Actived = value; } }

 private System.Byte[] _Picture;
 /// <summary>
 /// 签章图片
 /// </summary>
 [BindColumn(4,"a", "Picture", "签章图片","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.Byte[] Picture  { get { return _Picture; } set { _Picture = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(5,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(6,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _Name;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(7,"a", "Name", "","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String Name  { get { return _Name; } set { _Name = value; } }

 private System.String _PassWord;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(8,"a", "PassWord", "","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String PassWord  { get { return _PassWord; } set { _PassWord = value; } }

 private System.String _FileExt;
 /// <summary>
 /// 图片类型
 /// </summary>
 [BindColumn(9,"a", "FileExt", "图片类型","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String FileExt  { get { return _FileExt; } set { _FileExt = value; } }

 private System.String _Type;
 /// <summary>
 /// 签章类型：印章，手写
 /// </summary>
 [BindColumn(10,"a", "Type", "签章类型：印章，手写","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String Type  { get { return _Type; } set { _Type = value; } }

      
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
if (name == "HUMANID")
{
return _HumanId;
}
if (name == "ACTIVED")
{
return _Actived;
}
if (name == "PICTURE")
{
return _Picture;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "NAME")
{
return _Name;
}
if (name == "PASSWORD")
{
return _PassWord;
}
if (name == "FILEEXT")
{
return _FileExt;
}
if (name == "TYPE")
{
return _Type;
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
if (name == "HUMANID")
{
 _HumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ACTIVED")
{
 _Actived = System.Convert.ToBoolean(value);return;
}
if (name == "PICTURE")
{
 _Picture =  value as System.Byte[];return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "NAME")
{
 _Name = System.Convert.ToString(value);return;
}
if (name == "PASSWORD")
{
 _PassWord = System.Convert.ToString(value);return;
}
if (name == "FILEEXT")
{
 _FileExt = System.Convert.ToString(value);return;
}
if (name == "TYPE")
{
 _Type = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}