 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.StdSystem
{
    /// <summary>
    /// 同步p6操作日志
    /// </summary>
    public class PB_SyncP6LogDO : PB_SyncP6LogDO<PB_SyncP6LogDO>
    {

    }

	/// <summary>
    /// 同步p6操作日志
    /// </summary>
	  [BindEntity(KeyWord="PB_SyncP6Log",EntityType = typeof(Power.Systems.StdSystem.PB_SyncP6LogDO),Description = "同步p6操作日志"  )] 

	 [BindTable( "PB_SyncP6Log", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_SyncP6Log", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_SyncP6Log",Description="")]

    public   class PB_SyncP6LogDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.StdSystem.PB_SyncP6LogDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 主键
 /// </summary>
 [BindColumn(1,"a", "Id", "主键","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _MainId;
 /// <summary>
 /// PB_SyncP6的Id
 /// </summary>
 [BindColumn(2,"a", "MainId", "PB_SyncP6的Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid MainId  { get { return _MainId; } set { _MainId = value; } }

 private System.Int32 _Sequ;
 /// <summary>
 /// 序号
 /// </summary>
 [BindColumn(3,"a", "Sequ", "序号","", "NCHAR", 10,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =10 )]
 public  System.Int32 Sequ  { get { return _Sequ; } set { _Sequ = value; } }

 private System.String _Remark;
 /// <summary>
 /// 备注
 /// </summary>
 [BindColumn(3,"a", "Remark", "备注","", "NCHAR", 2147483647,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =2147483647 )]
 public  System.String Remark  { get { return _Remark; } set { _Remark = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新日期
 /// </summary>
 [BindColumn(4,"a", "UpdDate", "最后更新日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.Guid _UpdHumId;
 /// <summary>
 /// 最后修改人Id
 /// </summary>
 [BindColumn(5,"a", "UpdHumId", "最后修改人Id","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid UpdHumId  { get { return _UpdHumId; } set { _UpdHumId = value; } }

 private System.String _UpdHumName;
 /// <summary>
 /// 最后修改人名称
 /// </summary>
 [BindColumn(6,"a", "UpdHumName", "最后修改人名称","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String UpdHumName  { get { return _UpdHumName; } set { _UpdHumName = value; } }

      
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
if (name == "MAINID")
{
return _MainId;
}
if (name == "SEQU")
{
return _Sequ;
}
if (name == "REMARK")
{
return _Remark;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "UPDHUMID")
{
return _UpdHumId;
}
if (name == "UPDHUMNAME")
{
return _UpdHumName;
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
if (name == "MAINID")
{
 _MainId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "SEQU")
{
 _Sequ = System.Convert.ToInt32(value);return;
}
if (name == "REMARK")
{
 _Remark = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "UPDHUMID")
{
 _UpdHumId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "UPDHUMNAME")
{
 _UpdHumName = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}