 
 
 using    System;
 using System.Collections.Generic;
 using System.Text; 
 using XCode.Attributes    ;

 namespace  Power.Systems.Systems
{
    /// <summary>
    /// 历史消息
    /// </summary>
    public class PowerMessageHisDO : PowerMessageHisDO<PowerMessageHisDO>
    {

    }

	/// <summary>
    /// 历史消息
    /// </summary>
	  [BindEntity(KeyWord="PowerMessageHis",EntityType = typeof(Power.Systems.Systems.PowerMessageHisDO),Description = "历史消息"  )] 

	 [BindTable( "PB_MessagesHis", Alias = "a",IsAttach=false,Description ="")]

	  [BindIndex(Name = "pk_PB_MessagesHis", KeyType = Power.DataAccessLayer.KeyType.MainKey, Columns = "Id", TableName = "PB_MessagesHis",Description="")]

    public   class PowerMessageHisDO<TEntity> : XCode.Entity<TEntity>, XCode.IEntity where TEntity : Power.Systems.Systems.PowerMessageHisDO<TEntity>, new()
    { 
	    #region 属性

	    
 private System.Guid _Id;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(1,"a", "Id", "","", "NCHAR", 16,0,false, IsPrimaryKey =true ,IsIdentity =true,IsNullable =false,  Length =16 )]
 public virtual System.Guid Id  { get { return _Id; } set { _Id = value; } }

 private System.Guid _OId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(2,"a", "OId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =16 )]
 public  System.Guid OId  { get { return _OId; } set { _OId = value; } }

 private System.String _Title;
 /// <summary>
 /// 标题
 /// </summary>
 [BindColumn(3,"a", "Title", "标题","", "NCHAR", 254,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =254 )]
 public  System.String Title  { get { return _Title; } set { _Title = value; } }

 private System.DateTime _ComeDate;
 /// <summary>
 /// 到达日期
 /// </summary>
 [BindColumn(4,"a", "ComeDate", "到达日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime ComeDate  { get { return _ComeDate; } set { _ComeDate = value; } }

 private System.DateTime _FromDate;
 /// <summary>
 /// 发送日期
 /// </summary>
 [BindColumn(5,"a", "FromDate", "发送日期","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime FromDate  { get { return _FromDate; } set { _FromDate = value; } }

 private System.String _Icon;
 /// <summary>
 /// 消息图标
 /// </summary>
 [BindColumn(6,"a", "Icon", "消息图标","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String Icon  { get { return _Icon; } set { _Icon = value; } }

 private System.Guid _ToHumanId;
 /// <summary>
 /// 接收人编号
 /// </summary>
 [BindColumn(7,"a", "ToHumanId", "接收人编号","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid ToHumanId  { get { return _ToHumanId; } set { _ToHumanId = value; } }

 private System.String _ToHumanName;
 /// <summary>
 /// 接收人
 /// </summary>
 [BindColumn(8,"a", "ToHumanName", "接收人","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String ToHumanName  { get { return _ToHumanName; } set { _ToHumanName = value; } }

 private System.Guid _FromHumanId;
 /// <summary>
 /// 发送人编号
 /// </summary>
 [BindColumn(9,"a", "FromHumanId", "发送人编号","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FromHumanId  { get { return _FromHumanId; } set { _FromHumanId = value; } }

 private System.String _FromHumanName;
 /// <summary>
 /// 发送人
 /// </summary>
 [BindColumn(10,"a", "FromHumanName", "发送人","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String FromHumanName  { get { return _FromHumanName; } set { _FromHumanName = value; } }

 private System.String _MessageType;
 /// <summary>
 /// 消息类型（通知 notify、消息message、任务事项 task、警告(预警)warn、工作流 workflow、其他other）
 /// </summary>
 [BindColumn(11,"a", "MessageType", "消息类型（通知 notify、消息message、任务事项 task、警告(预警)warn、工作流 workflow、其他other）","", "NCHAR", 20,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =20 )]
 public  System.String MessageType  { get { return _MessageType; } set { _MessageType = value; } }

 private System.String _GroupId;
 /// <summary>
 /// 消息分组（建议输入GUID，当同一个消息需要发送发送一批消息的时候必填，流程中建议填写节点GUID）
 /// </summary>
 [BindColumn(12,"a", "GroupId", "消息分组（建议输入GUID，当同一个消息需要发送发送一批消息的时候必填，流程中建议填写节点GUID）","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String GroupId  { get { return _GroupId; } set { _GroupId = value; } }

 private System.String _KeyWord;
 /// <summary>
 /// 工作流消息，记录对应的KeyWord
 /// </summary>
 [BindColumn(13,"a", "KeyWord", "工作流消息，记录对应的KeyWord","", "NCHAR", 80,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =80 )]
 public  System.String KeyWord  { get { return _KeyWord; } set { _KeyWord = value; } }

 private System.Guid _KeyValue;
 /// <summary>
 /// 工作流消息，记录对应的KeyValue
 /// </summary>
 [BindColumn(14,"a", "KeyValue", "工作流消息，记录对应的KeyValue","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid KeyValue  { get { return _KeyValue; } set { _KeyValue = value; } }

 private System.SByte _IsMail;
 /// <summary>
 /// 是否发送邮件（0 否；1 表示是；2表示已发送；3用户已处理）
 /// </summary>
 [BindColumn(15,"a", "IsMail", "是否发送邮件（0 否；1 表示是；2表示已发送；3用户已处理）","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte IsMail  { get { return _IsMail; } set { _IsMail = value; } }

 private System.SByte _IsTextMessage;
 /// <summary>
 /// 是否发送短信（0 否；1 表示是；2表示已发送；3用户已处理）
 /// </summary>
 [BindColumn(16,"a", "IsTextMessage", "是否发送短信（0 否；1 表示是；2表示已发送；3用户已处理）","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte IsTextMessage  { get { return _IsTextMessage; } set { _IsTextMessage = value; } }

 private System.SByte _IsPowerMessage;
 /// <summary>
 /// 是否发送系统消息（0 否；1 表示是；2表示已发送；3用户已处理）
 /// </summary>
 [BindColumn(17,"a", "IsPowerMessage", "是否发送系统消息（0 否；1 表示是；2表示已发送；3用户已处理）","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte IsPowerMessage  { get { return _IsPowerMessage; } set { _IsPowerMessage = value; } }

 private System.SByte _IsDeviceMessage;
 /// <summary>
 /// 是否根据设备特性推送消息（0 否；1 表示是；2表示已发送；3用户已处理）
 /// </summary>
 [BindColumn(18,"a", "IsDeviceMessage", "是否根据设备特性推送消息（0 否；1 表示是；2表示已发送；3用户已处理）","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =false,  Length =3 )]
 public  System.SByte IsDeviceMessage  { get { return _IsDeviceMessage; } set { _IsDeviceMessage = value; } }

 private System.String _ContentText;
 /// <summary>
 /// 消息内容
 /// </summary>
 [BindColumn(19,"a", "ContentText", "消息内容","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String ContentText  { get { return _ContentText; } set { _ContentText = value; } }

 private System.String _CronExpress;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(20,"a", "CronExpress", "","", "NCHAR", 100,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =100 )]
 public  System.String CronExpress  { get { return _CronExpress; } set { _CronExpress = value; } }

 private System.SByte _IsSend;
 /// <summary>
 /// 是否发送完毕(0否,1是)，其他几个状态的与结果
 /// </summary>
 [BindColumn(21,"a", "IsSend", "是否发送完毕(0否,1是)，其他几个状态的与结果","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte IsSend  { get { return _IsSend; } set { _IsSend = value; } }

 private System.Guid _FormId;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(22,"a", "FormId", "","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid FormId  { get { return _FormId; } set { _FormId = value; } }

 private System.Guid _EpsProjId;
 /// <summary>
 /// 项目ID
 /// </summary>
 [BindColumn(23,"a", "EpsProjId", "项目ID","", "NCHAR", 16,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =16 )]
 public  System.Guid EpsProjId  { get { return _EpsProjId; } set { _EpsProjId = value; } }

 private System.String _EpsProjCode;
 /// <summary>
 /// 项目编码
 /// </summary>
 [BindColumn(24,"a", "EpsProjCode", "项目编码","", "NCHAR", 50,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =50 )]
 public  System.String EpsProjCode  { get { return _EpsProjCode; } set { _EpsProjCode = value; } }

 private System.String _EpsProjName;
 /// <summary>
 /// 项目名称
 /// </summary>
 [BindColumn(25,"a", "EpsProjName", "项目名称","", "NCHAR", 200,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =200 )]
 public  System.String EpsProjName  { get { return _EpsProjName; } set { _EpsProjName = value; } }

 private System.DateTime _UpdDate;
 /// <summary>
 /// 最后更新时间
 /// </summary>
 [BindColumn(26,"a", "UpdDate", "最后更新时间","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.DateTime UpdDate  { get { return _UpdDate; } set { _UpdDate = value; } }

 private System.SByte _IsRTX;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(27,"a", "IsRTX", "","", "NCHAR", 3,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =3 )]
 public  System.SByte IsRTX  { get { return _IsRTX; } set { _IsRTX = value; } }

 private System.String _LinkUrl;
 /// <summary>
 /// 
 /// </summary>
 [BindColumn(28,"a", "LinkUrl", "","", "NCHAR", 500,0,false, IsPrimaryKey =false ,IsIdentity =false,IsNullable =true,  Length =500 )]
 public  System.String LinkUrl  { get { return _LinkUrl; } set { _LinkUrl = value; } }

      
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
if (name == "OID")
{
return _OId;
}
if (name == "TITLE")
{
return _Title;
}
if (name == "COMEDATE")
{
return _ComeDate;
}
if (name == "FROMDATE")
{
return _FromDate;
}
if (name == "ICON")
{
return _Icon;
}
if (name == "TOHUMANID")
{
return _ToHumanId;
}
if (name == "TOHUMANNAME")
{
return _ToHumanName;
}
if (name == "FROMHUMANID")
{
return _FromHumanId;
}
if (name == "FROMHUMANNAME")
{
return _FromHumanName;
}
if (name == "MESSAGETYPE")
{
return _MessageType;
}
if (name == "GROUPID")
{
return _GroupId;
}
if (name == "KEYWORD")
{
return _KeyWord;
}
if (name == "KEYVALUE")
{
return _KeyValue;
}
if (name == "ISMAIL")
{
return _IsMail;
}
if (name == "ISTEXTMESSAGE")
{
return _IsTextMessage;
}
if (name == "ISPOWERMESSAGE")
{
return _IsPowerMessage;
}
if (name == "ISDEVICEMESSAGE")
{
return _IsDeviceMessage;
}
if (name == "CONTENTTEXT")
{
return _ContentText;
}
if (name == "CRONEXPRESS")
{
return _CronExpress;
}
if (name == "ISSEND")
{
return _IsSend;
}
if (name == "FORMID")
{
return _FormId;
}
if (name == "EPSPROJID")
{
return _EpsProjId;
}
if (name == "EPSPROJCODE")
{
return _EpsProjCode;
}
if (name == "EPSPROJNAME")
{
return _EpsProjName;
}
if (name == "UPDDATE")
{
return _UpdDate;
}
if (name == "ISRTX")
{
return _IsRTX;
}
if (name == "LINKURL")
{
return _LinkUrl;
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
if (name == "OID")
{
 _OId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TITLE")
{
 _Title = System.Convert.ToString(value);return;
}
if (name == "COMEDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _ComeDate = System.Convert.ToDateTime(value);return;
}
if (name == "FROMDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _FromDate = System.Convert.ToDateTime(value);return;
}
if (name == "ICON")
{
 _Icon = System.Convert.ToString(value);return;
}
if (name == "TOHUMANID")
{
 _ToHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "TOHUMANNAME")
{
 _ToHumanName = System.Convert.ToString(value);return;
}
if (name == "FROMHUMANID")
{
 _FromHumanId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "FROMHUMANNAME")
{
 _FromHumanName = System.Convert.ToString(value);return;
}
if (name == "MESSAGETYPE")
{
 _MessageType = System.Convert.ToString(value);return;
}
if (name == "GROUPID")
{
 _GroupId = System.Convert.ToString(value);return;
}
if (name == "KEYWORD")
{
 _KeyWord = System.Convert.ToString(value);return;
}
if (name == "KEYVALUE")
{
 _KeyValue = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "ISMAIL")
{
 _IsMail = System.Convert.ToSByte(value);return;
}
if (name == "ISTEXTMESSAGE")
{
 _IsTextMessage = System.Convert.ToSByte(value);return;
}
if (name == "ISPOWERMESSAGE")
{
 _IsPowerMessage = System.Convert.ToSByte(value);return;
}
if (name == "ISDEVICEMESSAGE")
{
 _IsDeviceMessage = System.Convert.ToSByte(value);return;
}
if (name == "CONTENTTEXT")
{
 _ContentText = System.Convert.ToString(value);return;
}
if (name == "CRONEXPRESS")
{
 _CronExpress = System.Convert.ToString(value);return;
}
if (name == "ISSEND")
{
 _IsSend = System.Convert.ToSByte(value);return;
}
if (name == "FORMID")
{
 _FormId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJID")
{
 _EpsProjId = XCode.Common.Helper.ConvertToGuid(value);return;
}
if (name == "EPSPROJCODE")
{
 _EpsProjCode = System.Convert.ToString(value);return;
}
if (name == "EPSPROJNAME")
{
 _EpsProjName = System.Convert.ToString(value);return;
}
if (name == "UPDDATE")
{
 if (value == null || value.ToString().IsNullOrEmpty() == true) value = DateTime.MinValue;
 _UpdDate = System.Convert.ToDateTime(value);return;
}
if (name == "ISRTX")
{
 _IsRTX = System.Convert.ToSByte(value);return;
}
if (name == "LINKURL")
{
 _LinkUrl = System.Convert.ToString(value);return;
}

			    base[name] = value;
			}
		}
		#endregion
	}
}