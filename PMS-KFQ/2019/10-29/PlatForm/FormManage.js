var FormManage = function () {
    var KeyWord = null;   //关键词
    var formMain = null;
    var formDataObject = null;   //表单数据
    var selectDataObject = null;  //辅助的下拉框等数据
    var OperatorType = null;
    var KeyValue = null;  //主键值
    var KeyFieldName = null;

    var WorkInfoData = null;  //和工作流相关数据包

    var FormActionUrl = bootPATH + "../PowerPlat/Action/FormAction.aspx";

    var FormConfig = null;

    var SetJsonData = function (subConfig, control, data) {

        switch (subConfig.ControlType) {
            case "DataGrid":
                control.setData(data);
                break;
            case "TreeGrid":
                if (subConfig.resultAsTree == true)
                    control.loadData(data);
                else
                    control.loadList(data, control.idField, control.parentField);
                break;
            case "ComboBox":
            case "ListBox":
                control.loadData(data);
                break;
            case "TreeSelect":
                control.loadData(data, control.idField, control.parentField);
                break;
            default:

                Power.ui.error("无法识别的加载方式", { timeout: 0, position: "center center", closeable: true });
                return;
        }
    };

    var getGridList = function (subConfig, gridObject, DataName) {
        var gridData = null;
        switch (subConfig.ControlType) {
            case "DataGrid":
                gridData = gridObject.getChanges();
                break;
            case "TreeGrid":
                gridData = gridObject.getChanges();
                break;
            case "ListBox":
            case "ComboBox":
            case "TreeSelect":
                gridData = gridObject.getValue();
                break;
            default:

                Power.ui.error("无法识别的加载方式", { timeout: 0, position: "center center", closeable: true });
                return;
        }

        var control = null;
        var tmpSub = [];
        for (var iTmp = 0; iTmp < gridData.length; iTmp++) {
            var objSub = gridData[iTmp];
            if (objSub._IsParent == "1") continue;

            tmpSub.push(objSub);

            //加载孙项
            if (!subConfig.SubRequestList) continue;
            for (var iSub = 0; iSub < subConfig.SubRequestList.length; iSub++) {
                var sunConfig = subConfig.SubRequestList[iSub];
                if (sunConfig.DataName in objSub == false) objSub[sunConfig.DataName] = [];
                if (iSub == 0) objSub[sunConfig.DataName] = [];
                //过滤不属于自己的信息
                if (sunConfig.ParentField != null) {
                    if (objSub[sunConfig.ParentField] != sunConfig.KeyValue) continue;
                }

                if (sunConfig.ControlName != null && sunConfig.ControlName.indexOf(".") < 0)     //如果是当前页面的grid，则直接处理
                {
                    control = mini.get(sunConfig.ControlName);
                }
                else {
                    var tabName = sunConfig.ControlName.substring(0, sunConfig.ControlName.indexOf("."));
                    var controlName = sunConfig.ControlName.substring(sunConfig.ControlName.indexOf(".") + 1);
                    if (top[tabName] == null || top[tabName] == undefined) continue;  //tab页如果未激活  
                    control = top[tabName].mini.get(controlName);
                }
                var tmpSun = getGridList(sunConfig, control, sunConfig.DataName);   //递归
                if (tmpSun.length > 0)
                    objSub[sunConfig.DataName] = tmpSun;
                else
                    delete objSub[subConfig.DataName];

            }
        }
        return tmpSub;
    };
    //绑定下拉框数据
    var BindSelectData = function () {

        FormatConfig();  //格式化配置信息
        var bindLen = FormConfig.BindConfig.length;
        for (var iTmp = 0; iTmp < bindLen; iTmp++) {
            var config = FormConfig.BindConfig[iTmp];
            var bindList = selectDataObject[config.SourceName];

            if (!bindList) {
                Power.ui.error(config.SourceName + "不存在，无法继续执行数据绑定", { timeout: 0, position: "center center", closeable: true });
                return;
            }
            var control = mini.get(config.ControlName);
            if (config.ControlType != "TreeSelect") {
                if (isArray(bindList) == false) continue;  //如果不是数组，则返回                 
                control.setData(bindList);
            }
            else {
                if (control.resultAsTree == false) {

                    control.loadList(bindList, control.valueField, control.parentField);
                }
                else {
                    if (!bindList.children) continue;
                    control.setData(bindList.children);
                }
            }
        }
    };

    //重置明细记录
    var ResetDataState = function (subConfig, control, data) {
        switch (subConfig.ControlType) {
            case "DataGrid":
                for (var iRow = 0, len = data.length; iRow < len; iRow++)
                    if (data[iRow]._state == "added") data[iRow]._state = "modified";
                break;
            case "TreeGrid":
                for (var iRow = 0, len = data.length; iRow < len; iRow++)
                    if (data[iRow]._state == "added") data[iRow]._state = "auto";
                break;
            case "ComboBox":
            case "ListBox":
            case "TreeSelect":
                break;
            default:
                Power.ui.error("无法识别的加载方式", { timeout: 0, position: "center center", closeable: true });
                return;
        }
    };

    //保存完毕后，重置明细记录状态
    var ResetState = function () {
        FormatConfig();  //格式化配置信息

        var mainLen1 = FormConfig.MainConfig.length;
        for (var iTmp = 0; iTmp < mainLen1; iTmp++) {
            var subConfig = FormConfig.MainConfig[iTmp];
            var subList = formDataObject[subConfig.DataName];
            if (isArray(subList) == false) return;  //如果不是数组，则返回


            if (subConfig.ControlName != null && subConfig.ControlName.indexOf(".") < 0) {   //如果是当前页面的grid，则直接处理 
                control = mini.get(subConfig.ControlName);
            }
            else {   //如果是嵌套页面，则要判断嵌套页面是否已激活
                var tabName = subConfig.ControlName.substring(0, subConfig.ControlName.indexOf("."));
                var controlName = subConfig.ControlName.substring(subConfig.ControlName.indexOf(".") + 1);
                if (top[tabName] == null || top[tabName] == undefined) continue;  //tab页如果未激活 
                control = top[tabName].mini.get(controlName);
            }
            ResetDataState(subConfig, control, subList);
        }
    };
    //将后台返回的记录显示到界面上 
    var SetReadData = function () {
        var control = null;

        FormatConfig();  //格式化配置信息
        var mainLen1 = FormConfig.MainConfig.length;
        for (var iTmp = 0; iTmp < mainLen1; iTmp++) {
            var subConfig = FormConfig.MainConfig[iTmp];
            var subList = formDataObject[subConfig.DataName];
            if (isArray(subList) == false) return;  //如果不是数组，则返回


            if (subConfig.ControlName != null && subConfig.ControlName.indexOf(".") < 0) {   //如果是当前页面的grid，则直接处理

                control = mini.get(subConfig.ControlName);
            }
            else {   //如果是嵌套页面，则要判断嵌套页面是否已激活
                var tabName = subConfig.ControlName.substring(0, subConfig.ControlName.indexOf("."));
                var controlName = subConfig.ControlName.substring(subConfig.ControlName.indexOf(".") + 1);
                if (top[tabName] == null || top[tabName] == undefined) continue;  //tab页如果未激活 
                control = top[tabName].mini.get(controlName);
            }

            SetJsonData(subConfig, control, subList);

        }
    };

    //将后台返回的记录显示到界面上 
    var SetSaveData = function (formData) {
        var control = null;
        var gridData = null;

        var dataObject = new Object();

        dataObject = formData;   //将主单数据放入容器中
        dataObject[KeyFieldName] = KeyValue;

        FormatConfig();  //格式化配置信息
        //加载子项
        var mainLen3 = FormConfig.MainConfig.length;
        for (var iTmp = 0; iTmp < mainLen3; iTmp++) {
            var subConfig = FormConfig.MainConfig[iTmp];
            if (subConfig.DataName in dataObject == false) dataObject[subConfig.DataName] = [];  //容器内如果有东西，则先清空，容器如果不存在，则先创建
            if (iTmp == 0) dataObject[subConfig.DataName] = [];

            if (subConfig.ControlName != null && subConfig.ControlName.indexOf(".") < 0)     //如果是当前页面的grid，则直接处理
            {
                control = mini.get(subConfig.ControlName);
            }
            else {
                var tabName = subConfig.ControlName.substring(0, subConfig.ControlName.indexOf("."));
                var controlName = subConfig.ControlName.substring(subConfig.ControlName.indexOf(".") + 1);
                if (top[tabName] == null || top[tabName] == undefined) continue;  //tab页如果未激活  
                control = top[tabName].mini.get(controlName);
            }
            var tmpSub = getGridList(subConfig, control, subConfig.DataName);

            if (tmpSub.length > 0)
                dataObject[subConfig.DataName] = tmpSub;
            else
                delete dataObject[subConfig.DataName];

        }

        var submitData = new Object();   // 和 Power.Business.IRequestInitData 相对应
        submitData.ResultFormData = dataObject;
        submitData.KeyFieldName = KeyFieldName;
        submitData.KeyValue = KeyValue;
        return submitData;
    };
    //格式化配置对象
    var FormatConfig = function () {
        if (FormConfig == null) FormConfig = new Object();
        if (FormConfig.MainConfig == null || FormConfig.MainConfig == undefined) FormConfig.MainConfig = [];
        if (FormConfig.BindConfig == null || FormConfig.BindConfig == undefined) FormConfig.BindConfig = [];
    };


    return {

        getForm: function () {
            return formMain;
        },
        setForm: function (form) {
            formMain = form;
        },

        setKeyWord: function (text) {
            KeyWord = text;
        },
        getKeyWord: function () {
            return KeyWord;
        },


        setKeyFieldName: function (data) {
            KeyFieldName = data;
        },
        getKeyFieldName: function () {
            return KeyFieldName;
        },
        setKeyValue: function (data) {
            KeyValue = data;
        },
        getKeyValue: function () {
            return KeyValue;
        },
        setFormDataObject: function (data) {
            formDataObject = data;
        },
        getFormDataObject: function () {
            return formDataObject;
        },
        setOperatorType: function (operatorType) {
            OperatorType = operatorType;
        },
        getOperatorType: function () {
            return OperatorType;
        },
        setSelectDataObject: function (data) {
            selectDataObject = data;
        },
        getSelectDataObject: function () {
            return selectDataObject;
        },
        setFormConfig: function (data) {
            FormConfig = data;
        },
        getFormConfig: function () {
            return FormConfig;
        },


        getWorkInfo: function () {
            return WorkInfoData;
        },
        setWorkInfo: function (value) {
            WorkInfoData = value;
            FormActionUrl = bootPATH + "../PowerPlat/WorkFlow/WorkFlowAction.aspx";   //绑定了工作流，则重定向Action 指向工作流网址
        },



        //将后台返回的记录显示到界面上 ，只处理嵌套页，此函数通常在 tab.tabLoad 事件中执行
        SetFrameReadData: function () {

            FormatConfig();  //格式化配置信息
            //只关注嵌套了tab页的子表显示，比如附件列表显示
            var mainLen2 = FormConfig.MainConfig.length;
            for (var iTmp = 0; iTmp < mainLen2; iTmp++) {
                var subConfig = FormConfig.MainConfig[iTmp];
                if (subConfig.ControlName != null && subConfig.ControlName.indexOf(".") < 0) continue;

                var subList = formDataObject[subConfig.DataName];
                if (isArray(subList) == false) return;  //如果不是数组，则返回

                var tabName = subConfig.ControlName.substring(0, subConfig.ControlName.indexOf("."));
                var controlName = subConfig.ControlName.substring(subConfig.ControlName.indexOf(".") + 1);
                if (top[tabName] == null || top[tabName] == undefined) continue;  //tab页如果未激活

                SetJsonData(subConfig, top[tabName].mini.get(controlName), subList);
            }
        },

        //读取孙表记录，放入容器中 subName子表名，  sonName:孙表名
        getSubData: function (subName, sonName, iIndex) {

            var subData = formDataObject[subName];
            if (isArray(subData) == false) return;  //如果不是数组，则返回
            var len = subData.length;
            if (len < iIndex) {
                Power.ui.error("传入的索引号溢出", { timeout: 0, position: "center center", closeable: true });
                return;
            }

            //检索孙表 
            var sonData = subData[iIndex][sonName];
            if (sonData == undefined) return null;

            if (isArray(sonData) == false) return;  //如果不是数组，则返回

            if (sonName == null) {
                Power.ui.error("Error,通过" + sonName + "未检索到列表", { timeout: 0, position: "center center", closeable: true });
                return;
            }
            return sonData;
        },


        //-------------------------------------------------------界面操控域----------------------------
        // e, 按钮自身    control:被上下排序的对象，  SerialField:排序字段名
        onMoveUpDown: function (e, controlName, SerialField, UpOrDown) {
            var control = mini.get(controlName);
            var row = control.getSelected();
            if (!row) return;

            var index = control.indexOf(row);
            if (index == 0 && UpOrDown == "Up") return null;
            if (index >= control.getData().length - 1 && UpOrDown == "Down") return null;
            var newIndex = -1;
            if (UpOrDown == "Up") newIndex = index - 1;
            if (UpOrDown == "Down") newIndex = index + 2;

            var obj = new Object();

            control.moveRow(row, newIndex);
            control.getData()[index].SerialNo = row[SerialField];   //回写原行号
            obj.OldSerialNo = row[SerialField];

            if (control.getData()[index]._state == undefined) control.getData()[index]._state = "modified";
            if (row._state == undefined) row._state = "modified";

            row[SerialField] = control.indexOf(row) + 1;  //序号从1开始，所以要加一
            obj.NewSerialNo = row[SerialField];


            if (UpOrDown == "Up") obj.OldSerialNo = parseInt(obj.OldSerialNo) - 1;
            if (UpOrDown == "Down") obj.NewSerialNo = parseInt(obj.NewSerialNo) - 1;

            obj.OldSerialNo = parseInt(obj.OldSerialNo);
            obj.NewSerialNo = parseInt(obj.NewSerialNo);
            return obj;
        },
        //----------------------保存按钮----------------------------------
        //新增或修改操作
        SaveData: function (BeforeCallBack, EndCallback) {

            formMain.validate();
            if (formMain.isValid() == false) return;
            var o = formMain.getData();

            var ServerType = "";

            //如果是新增操作，触发了保存，则创建个GUID
            if (OperatorType == "AddRecord") {
                KeyValue = CreateGUID();// Guid.NewGuid().ToString();
                ServerType = "InsertRecord";   //设置为保存模式
            }
            else
                ServerType = "UpdateRecord";   //设置为保存模式

            var submitData = SetSaveData(o);  //将后台返回的记录显示到界面上 


            if (BeforeCallBack) {
                var result = false;
                result = BeforeCallBack(submitData);   //保存前回调函数
                if (result == false) return;
            }


            var json = mini.encode(submitData);

            var workInfoData = "";
            if (WorkInfoData != null) workInfoData = mini.encode(WorkInfoData);
            $.ajax({
                url: FormActionUrl,
                type: 'post',
                data: { data: json, ServerOperatorType: ServerType, KeyWord: KeyWord, WorkInfoData: workInfoData },
                cache: false,
                success: function (text) {

                    var tmpData = mini.decode(text);
                    if (tmpData.success == false) {
                        Power.ui.error(tmpData.message, { timeout: 0, position: "center center", closeable: true });
                        return;
                    }
                    if (OperatorType == "AddRecord") {
                        formDataObject = tmpData.ResultFormData;   //表单数据先存起来 
                        formMain.setData(tmpData.ResultFormData);   //触发界面赋值，看到数据 
                        SetReadData();  //将后台返回的记录显示到界面上  ,看到明细数据 
                        formMain.setChanged(false);
                    }
                    if (tmpData.WorkInfoData) WorkInfoData = tmpData.WorkInfoData;   //将服务端返回的工作流相关信息存放在脚本对象中

                    ResetState();  //重置记录状态

                    submitData.ResultFormData.OperatorType = OperatorType;

                    if (OperatorType == "AddRecord")  //如果之前为新增模式，则填入主键，改为修改模式
                    {
                        OperatorType = "OpenRecord";
                    }

                    if (EndCallback) EndCallback(tmpData);  //执行回调函数

                    if (top["MainWindow"]) {
                        top["MainWindow"].divShowInfo.innerText = tmpData.RunTime;
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                    if (EndCallback) EndCallback(null);  //执行回调函数
                }
            });

        },
        //批量保存，走ResultFormDataList 路线，增删改受 _state 控制
        SimpleSaveList: function (submitData, callback) {

            var json = mini.encode(submitData);
            $.ajax({
                url: FormActionUrl,
                type: 'post',
                data: { data: json, ServerOperatorType: 'SaveRecordList', KeyWord: KeyWord },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });
        },
        //简化保存
        SimpleSaveData: function (submitData, callback) {

            var ServerType = "";
            //如果是新增操作，触发了保存，则创建个GUID
            if (OperatorType == "AddRecord") {
                KeyValue = CreateGUID();//Guid.NewGuid().ToString();
                ServerType = "InsertRecord";   //设置为保存模式
            }
            else
                ServerType = "UpdateRecord";   //设置为保存模式 

            var json = mini.encode(submitData);


            var workInfoData = "";
            if (WorkInfoData != null) workInfoData = mini.encode(WorkInfoData);

            $.ajax({
                url: FormActionUrl,
                type: 'post',
                data: { data: json, ServerOperatorType: ServerType, KeyWord: KeyWord, WorkInfoData: workInfoData },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (OperatorType == "AddRecord")  //如果之前为新增模式，则填入主键，改为修改模式
                    {
                        OperatorType = "OpenRecord";
                    }

                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });

        },

        //简化读取
        SimpleReadBindList: function (callback, bindList) {


            //if (!IsAsync) IsAsync = true;  //如果未指定同步一步，默认异步。
            var tmpUrl = "/PowerForm/ReadBindList";
            $.ajax({
                url: tmpUrl,
                data: { "BindList": mini.encode(bindList) },
                type: 'post',
                cache: false,
                async: true,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (tmpData.success == false) {
                        Power.ui.error(tmpData.message); return;
                    }

                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });

        },
        //-----------------------------------------------------------
        //删除记录
        DeleteData: function (callback) {
            if (OperatorType == "AddRecord") {
                Power.ui.warning("新增状态下不可删除", { timeout: 0, position: "center center", closeable: true });
                return;
            }


            var ServerType = "DeleteRecord";   //设置为删除模式


            var workInfoData = "";
            if (WorkInfoData != null) workInfoData = mini.encode(WorkInfoData);
            $.ajax({
                url: FormActionUrl,
                type: 'post',
                data: { KeyValue: KeyValue, ServerOperatorType: ServerType, KeyWord: KeyWord, WorkInfoData: workInfoData },
                cache: false,
                success: function (tmpData) {
                    if (formMain) formMain.setChanged(false);
                    if (callback) callback();

                    if (top["MainWindow"]) {
                        top["MainWindow"].divShowInfo.innerText = tmpData.RunTime;
                    }

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });
        },
        //-------------------------------读取-------------------------------
        //读取记录
        ReadBindData: function (callback, BindList) {
            var bindList = "";
            if (BindList != null) bindList = mini.encode(BindList);

            $.ajax({
                url: FormActionUrl,
                type: 'post',
                data: { ServerOperatorType: 'ReadBind', BindList: bindList },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);

                    selectDataObject = tmpData.SelectData;   //将下拉所需数据塞入对象

                    BindSelectData();   //绑定下拉框等信息
                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });
        },
        //读取记录
        ReadData: function (callback, BindList) {
            var ServerType = "";
            if (OperatorType == "AddRecord")
                ServerType = "InitRecord";
            else
                ServerType = "OpenRecord";

            var workInfoData = "";
            if (WorkInfoData != null) workInfoData = mini.encode(WorkInfoData);

            var bindList = "";
            if (BindList != null) bindList = mini.encode(BindList);

            $.ajax({
                url: FormActionUrl,
                type: 'post',
                data: { KeyValue: KeyValue, ServerOperatorType: ServerType, KeyWord: KeyWord, BindList: bindList, WorkInfoData: workInfoData },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (tmpData.success == false) {
                        Power.ui.error(tmpData.message, { timeout: 0, position: "center center", closeable: true });
                        return;
                    }
                    KeyFieldName = tmpData.KeyFieldName;

                    selectDataObject = tmpData.SelectData;   //将下拉所需数据塞入对象

                    BindSelectData();   //绑定下拉框等信息

                    formDataObject = tmpData.ResultFormData;   //表单数据先存起来

                    formMain.setData(tmpData.ResultFormData);   //触发界面赋值，看到数据

                    SetReadData();  //将后台返回的记录显示到界面上  ,看到明细数据

                    formMain.setChanged(false);


                    if (callback) callback(tmpData);

                    if (top["MainWindow"]) {
                        top["MainWindow"].divShowInfo.innerText = tmpData.RunTime;
                    }

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });
        },
        //简化读取
        SimpleReadData: function (IsAsync, callback) {

            var ServerType = "";
            if (OperatorType == "AddRecord")
                ServerType = "InitRecord";
            else
                ServerType = "OpenRecord";

            //if (!IsAsync) IsAsync = true;  //如果未指定同步一步，默认异步。

            $.ajax({
                url: FormActionUrl,
                data: { KeyValue: KeyValue, ServerOperatorType: ServerType, KeyWord: KeyWord },
                type: 'post',
                cache: false,
                async: IsAsync,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });

        },
        //简化读取
        SimpleReadList: function (IsAsync,KeyWord,config, callback) {

            
            var ServerConfig = mini.encode(config);
            //if (!IsAsync) IsAsync = true;  //如果未指定同步一步，默认异步。
            var tmpUrl = "/PowerForm/LoadRecord";
            $.ajax({
                url: tmpUrl,
                data: { "KeyWord": KeyWord, "ServerConfig": ServerConfig },
                type: 'post',
                cache: false,
                async: IsAsync,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });

        },
        
        //---------------------------初始打开界面
        init: function () {
            var _KeyWord = getParameter("KeyWord");
            var _KeyValue = getParameter("KeyValue");

            var _OperatorType = getParameter("OperatorType");

            if (_OperatorType == "OpenRecord") {
                if (_KeyValue == null || _KeyValue == "" || _KeyValue == "undefined" || _KeyValue == undefined) {
                    Power.ui.error("严重警告，传入的操作指令不含主键值", { timeout: 0, position: "center center", closeable: true });
                }
                else {
                    KeyValue = _KeyValue;
                }
            }
            OperatorType = _OperatorType;
            KeyWord = _KeyWord;
        },

        //-------------------------------工作流相关操作----------------------------
        //选择目标节点
        SelectSendNode: function (FlowOperate, callback) {
            if (OperatorType == "AddRecord") {
                Power.ui.warning("请您先保存表单，再执行发送操作", { timeout: 0, position: "center center", closeable: true });
                return;
            }
            if (!WorkInfoData) {
                Power.ui.error("流程信息无法捕获，请重新打开表单", { timeout: 0, position: "center center", closeable: true });
                return;
            }

            formMain.validate();
            if (formMain.isValid() == false) return;
            var o = formMain.getData();

            WorkInfoData.FlowOperate = FlowOperate;  //执行发送指令

            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/WorkNodeSelect.html",
                title: "流程流转", width: 800, height: 600,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(WorkInfoData);
                },
                ondestroy: function (action) {
                    if (action != "ok") {
                        WorkInfoData.FlowOperate = "Update";  //如果取消了，状态置回修改
                        return;
                    }
                    var iframe = this.getIFrameEl();
                    var data = iframe.contentWindow.GetData();
                    if (!data) {
                        WorkInfoData.FlowOperate = "Update";  //如果取消了，状态置回修改
                        return;
                    }
                    data = mini.clone(data);
                    if (callback) callback(data);
                }
            });
        },
        //流程发送
        SendNode: function (data, BeforeCallBack, AfterCallback) {
            formMain.validate();
            if (formMain.isValid() == false) return;
            var o = formMain.getData();

            var ServerType = "";

            //如果是新增操作，触发了保存，则创建个GUID
            if (OperatorType == "AddRecord") {
                Power.ui.warning("请先执行单据保存", { timeout: 0, position: "center center", closeable: true });
                return;
            }
            var submitData = SetSaveData(o);  //将后台返回的记录显示到界面上  
            if (BeforeCallBack) {
                var result = false;
                result = BeforeCallBack(submitData);   //保存前回调函数
                if (result == false) return;
            }

            var json = mini.encode(submitData);

            var workInfoData = "";
            if (WorkInfoData != null) workInfoData = mini.encode(WorkInfoData);
            $.ajax({
                url: FormActionUrl,
                data: { data: json, KeyValue: KeyValue, ServerOperatorType: 'SendNode', KeyWord: KeyWord, WorkInfoData: workInfoData },
                cache: false,
                type: 'post',
                async: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (AfterCallback) AfterCallback(tmpData);
                    WorkInfoData.FlowOperate = "Update";  //指令复位
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    WorkInfoData.FlowOperate = "Update";  //指令复位
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });
        },
        //回收操作
        GetBackRecord: function (workInfoID, sequeID, callback) {
            $.ajax({
                url: FormActionUrl,
                data: { ServerOperatorType: 'GetBack', WorkInfoID: workInfoID, SequeID: sequeID },
                type: 'post',
                cache: false,
                async: false,
                success: function (text) {
                    if (callback) callback();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                }
            });
        }


    };



};
