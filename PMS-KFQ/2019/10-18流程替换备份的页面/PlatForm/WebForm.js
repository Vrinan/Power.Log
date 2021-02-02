//webform 与 singleform 差异：
//webform数据在 DataSets 中缓存子表数据，singleform 每次读取
//webform有新增初始化，singleform没有
document.write('<script src="' + bootPATH + 'PlatForm/FormFuns.js?v=' + __bootGetFileVersion() + '" type="text/javascript" ></script>');

var WebForm = function () {
    var FormData = {};
    var FormConfig = null;
    var KeyFieldName = "";
    var OperatorType = null;
    var KeyWord = null;   //关键词
    var CanShowBox = true;
    var property = null;
    var DataSummary = null;
    var FormActionUrl = bootPATH + "../PowerPlat/Action/FormAction.aspx"; //默认的流程页面
    //富文本编辑初始化
    if (typeof (KindEditor) != "undefined")
        KindEditor.ready(function cc() { });
    //保存成功后，去掉所有修改标记
    var doAcceptChange = function (miniid) {
        //doInitData(); //先使用刷新代替本地处理
        if (miniid.data == undefined) {
            var sender = FormFuns.GetMiniFormGrid(miniid);
            FormFuns.ReLoadData(sender);
        }
        else {
            miniid.accept();
            FormFuns.ReLoadData(mini.get(miniid.id));
            FormFuns.LoadChildData(miniid.id);
        }
    }
    var doSaveGridTree = function (sender) {
        if (!sender) return;
        var pack = {};
        FormFuns.GetSaveDataPack(pack, sender.id, true);

        var jdata = { formId: "", encode: "r4" };
        jdata.jsonData = base64swhere(FormFuns.SaveDataPackToString(pack));
        var params = {};
        if (typeof (workflowdata) != "undefined" && typeof (formconfig) != "undefined" && !FormFuns.WorkflowReadOnly(formconfig.Effected)) {
            params.IsWorkFlowHuman = "1";
        }
        jdata.Params = base64encode(params == undefined ? '' : mini.encode(params));
        var sUrl = "/Form/SaveWebForm";
        //wsl 追加，如果表单参数中有  FromSource ,并且值等于 TransFlow ，说明是从事务流触发的表单新增，则URL重新定向
        if (jdata.Params && jdata.Params.FromSource == "TransFlow") {
            sUrl = "/WorkFlow/SaveWebForm";
        }

        $.ajax({
            url: sUrl,
            type: "POST",
            data: jdata,
            success: function (text) {
                var tmpdata = mini.decode(text);
                if (tmpdata.success == false) {
                    //alert(tmpdata.message);
                    Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 0, position: "center center", closeable: true });
                }
                else {
                    doAcceptChange(sender);
                }
            }
        });
    }

    //删除记录时，如果包含有 _state=added 记录，则同时维护dataset，删除对应的记录
    var delDataSetRow = function (grid, rows) {
        if (!grid || !grid._powerparentrow)
            return;
        var tmpList = grid._powerparentrow[grid._powersourcename];
        for (var i = 0; i < rows.length; i++) {
            if (rows[i]._state != "added")
                continue;
            for (var j = tmpList.length - 1; j > -1; j--) {
                if (rows[i]._uid == tmpList[j]._uid) {
                    //delete (tmpList[j]);
                    tmpList.splice(j, 1);
                    break;
                }
            }
        }
    }

    var getGridList = function (subConfig, gridObject, DataName) {
        var gridData = null;
        switch (subConfig.ControlType) {
            case "DataGrid":
                gridData = gridObject.getChanges();
                break;
            case "ListBox":
            case "ComboBox":
            case "TreeSelect":
                gridData = gridObject.getValue();
                break;
            default:
                Power.ui.alert(app_global_ResouceId["webform_loading_unable"]); return;
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
    var setFormConfig = function (data) {
        FormConfig = data;
    }
    var getFormConfig = function () {
        return FormConfig;
    }
    //将后台返回的记录显示到界面上 
    var SetSaveData = function (formData) {
        var control = null;
        var gridData = null;

        var dataObject = new Object();

        dataObject = formData;   //将主单数据放入容器中
        dataObject[KeyFieldName] = formconfig.KeyValue;

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
        submitData.KeyValue = formconfig.KeyValue;
        return submitData;
    };
    //格式化配置对象
    var FormatConfig = function () {
        if (FormConfig == null) FormConfig = new Object();
        if (FormConfig.MainConfig == null || FormConfig.MainConfig == undefined) FormConfig.MainConfig = [];
        if (FormConfig.BindConfig == null || FormConfig.BindConfig == undefined) FormConfig.BindConfig = [];
    };

    var setOperatorType = function (operatorType) {
        OperatorType = operatorType;
    }
    var setKeyValue = function (data) {
        KeyValue = data;
    }
    //设置权限树
    var setRightTree = function (arr, obj, grid) {
        if (arr.length == 0) return;
        //绑定了权限树类型的字段名
        var fd = arr.pop()
        //绑定的权限树类型的id
        var typeId = obj[fd];
        var url = "/Form/Select?code=RightTreeType"// typeId;
        var par = "&filter=" + ("{\"Id\":\"" + typeId + "\"}");
        var title;
        if (title == undefined) title = app_global_ResouceId["g_select"];
        mini.open({
            url: url + par,
            title: title,
            ondestroy: function (action) {
                if (action != "ok") {
                    setRightTree(arr, obj, grid);
                    return;
                }
                //点击确定返回的数据
                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData();
                data = mini.clone(data);
                if (data == undefined || data.length == 0) return;
                $.ajax({
                    url: "/Form/UpdateRightTree",
                    type: "POST",
                    data: { Data: data[0], SelectId: typeId },
                    cacha: false,
                    success: function (text) {
                        //查出取返回的数据行的哪个字段
                        var tmpdata = mini.decode(text);
                        if (tmpdata && tmpdata.data.ColumnData) {
                            //值
                            var selectValue = data[0][tmpdata.data.ColumnData];
                            //要修改的列
                            var column = fd;
                            //form
                            if (FormFuns.IsMiniForm(grid)) {
                                doUpdateFormData(grid);
                                var row = FormData[grid.el.id];
                                if (row != undefined) {
                                    row[column] = selectValue;
                                    grid.setData(row, true);
                                }
                            }
                                //tree/grid
                            else if (FormFuns.IsMiniGridTree(grid)) {
                                var row = grid.getSelected();
                                if (row != undefined) {
                                    row[column] = selectValue;
                                    if (FormFuns.IsMiniGrid(grid))
                                        grid.updateRow(row);
                                    if (FormFuns.IsMiniTree(grid))
                                        grid.updateNode(row);
                                }
                            }

                        }
                        //递归再次弹出选择树
                        setRightTree(arr, obj, grid);
                    }
                });
            }
        });
    }
    var existsTabId = function (tabid) {
        var tabs = mini.get("maintabs");
        if (!tabs) return false;
        if (tabs.getTab(tabid) == undefined)
            return false;
        return true;
    }

    //初始化tree/grid，绑定事件
    var initGridTree = function (config) {
        if (!config)
            config = formconfig.config.joindata;
        var miniid = config.miniid;
        var sender = mini.get(miniid);
        if (FormFuns.IsMiniGridTree(sender)) {
            sender.setAutoLoad(false);
            if (FormFuns.IsMiniTree(sender))
                sender.setUrl("/Form/TreeLazyLoad")
            else
                sender.setUrl("/Form/GridPageLoad");
            if (FormFuns.IsMiniGrid(sender)) {
                sender.on("select", webself.OnNodeSelect);
                sender.on("headercellclick", FormFuns.onheadercellclick);
                sender.on("beforeselect", webself.OnBeforeNodeSelect);
                if (sender.sortField != undefined && sender.sortField != "") {
                    if (sender.sortOrder != undefined)
                        config.sort = sender.sortField + " " + sender.sortOrder;
                    else
                        config.sort = sender.sortField;
                }
            }
            else {
                sender.on("nodeselect", webself.OnNodeSelect);
                sender.on("beforenodeselect", webself.OnBeforeNodeSelect);
            }
            sender.on("beforeload", webself.OnBeforeLoad);
            sender.on("preload", webself.OnPreLoad);
            sender.on("load", webself.OnAfterLoad);
        }
        //递归设置子表
        if (!config.children || config.children.length == 0)
            return;
        for (var i = 0; i < config.children.length; i++)
            initGridTree(config.children[i]);
    }
    var InitKindEditor = function (fn) {
        if (typeof (KindEditor) == "undefined") {
            fn();
            return;
        }
        var configlist = FormFuns.ConfigToList();
        var kes = [];
        var fnGetKey = function (item) {
            //控制工具栏显示的按钮数量
            var rlt = { id: item.id };
            if (item["data-options"]) {
                var str = item["data-options"];
                try {
                    //var tmp = jQuery.parseJSON(str);
                    var tmp = mini.decode(str);
                    $.each(tmp, function (n, v) {
                        if (typeof (n) != "function") {
                            rlt[n] = v;
                        }
                    })
                }
                catch (err) {
                    console.log("KindEditor.data-options 定义格式不正确,缺少双引号将名称扩起来,id:" + item.id + ",data-options:" + str);
                }
            }
            return rlt;
        }
        for (var i = 0; i < configlist.length; i++) {
            var keyword = configlist[i].miniid;

            var gridfrom = FormFuns.GetMiniFormGrid(keyword);
            if (gridfrom && gridfrom.el && (gridfrom.el.className == "form" || gridfrom.el.className.indexOf("form ") > -1 || gridfrom.el.className.indexOf(" form") > -1)) {
                var fields = gridfrom.getFields();
                for (var j = 0; j < fields.length; j++) {
                    if (fields[j].type == "textarea" && fields[j].kename)
                        kes.push(fnGetKey(fields[j]));
                }

            }
            for (var x = 0; x < 10; x++) {
                var ff = funsself.GetMiniFormGrid(keyword + "-" + x);
                if (ff && ff.el && (ff.el.className == "form" || ff.el.className.indexOf("form ") > -1 || ff.el.className.indexOf(" form") > -1)) {
                    var fields = ff.getFields();
                    for (var j = 0; j < fields.length; j++) {
                        if (fields[j].type == "textarea" && fields[j].kename)
                            kes.push(fnGetKey(fields[j]));
                    }

                }
            }

        }
        if (kes.length == 0) return;
        if (formconfig.kindeditors == undefined) formconfig.kindeditors = [];
        KindEditor.ready(function (K) {
            for (var i = 0; i < kes.length; i++) {
                var item = kes[i];
                //if (item.autheight !=undefined && item.auto)
                var keopt = { //对应文本域id名称
                    themeType: 'simple', //使用和系统更搭配的白色背景
                    //uploadJson: '/Scripts/KindEditor/upload_json.ashx', //加载上传组件
                    getuploadJson: function () {
                        return '/Scripts/KindEditor/upload_json.ashx?keyword=' + formconfig.config.joindata.KeyWord + "&keyvalue=" + formconfig.config.joindata.currow[formconfig.config.joindata.keyfield];
                    },
                    autoHeightMode: false, //随着内容增加，自动增高
                    afterCreate: function () {
                        this.loadPlugin('autoheight');
                    }
                }
                //控制工具栏按钮的数量
                $.each(item, function (n, v) {
                    if (typeof (n) != "function") {
                        keopt[n] = v;
                    }
                })
                formconfig.kindeditors[item.id] = K.create('#' + item.id, keopt);
            }
            fn();
        });
    }
    return webself = {
        //------外部扩展事件-------//
        //执行初始化操作结束后 触发
        EventAterInit: function () { },
        //tree,grid 请求ajax之前 触发
        EventBeforeLoadData: function (e) { },
        //tree,grid ajax请求到数据后setdata之前 触发, 返回true 则系统默认代码不再执行
        EventBeforeSetData: function (e) { return false; },
        //tree,grid加载数据后，渲染前  触发
        EventBeforeRenderData: function (e, data) {
            return data;
        },
        //tree,grid 加载数据之后 触发 
        EventAfterLoadData: function (e) { },
        EventBeforeFormLoad: function (f, params) { },
        //form 加载数据之后 触发 
        EventAfterFormLoad: function (f, data) { },
        //加载权限之前
        EventBeforeLoadRight: function (o) { },
        //加载权限之后
        EventAfterLoadRight: function (o) { },
        //保存完成之后触发
        EventAfterOnBtnSave: function (e) { },
        //向导选中之后，对数据重新处理
        EventWizardData: function (e, data) { return data; },
        //向导第一步查询条件赋值 
        EventWizardWhere: function (e) { },
        //form保存生成保存数据包之前触发
        EventBeforeOnBtnSave: function (e) { },
        //流程按钮同意、送审前触发
        EventBeforeOnBtnFlow: function (e) { },
        //流程按钮驳回前触发
        EventBeforeOnBtnRetrunNode: function (e) { },
        //流程按钮委派前触发
        EventBeforeOnBtnDelegate: function (e) { },
        //流程按钮终止前触发
        EventBeforeOnBtnStop: function (e) { },
        //流程按钮提交前触发
        EventBeforeOnBtnFlowSubmit: function (e) { },
        //选择流程前触发
        EventBeforeSelectWorkFlow: function (e, data) { },
        //form生成数据包，提交到服务器之前出发
        EventBeforeSaveData: function (data, e) { },
        //tree/grid行切换时触发
        EventAfterNodeSeleted: function (e) { },
        //tree/grid行删除前触发
        EventBeforeDelete: function (e, row) { },
        //tree/grid行删除后触发
        EventAfterDelete: function (e, row) { },
        //tree/grid行新增后触发
        EventAfterAddRow: function (e, row) { },
        //tree/grid行新增前触发
        EventBeforeAddRow: function (e, ddata) { },
        //向导选择数据，对grid/treeupdate之后触发
        EventWizardAfterUpdateRow: function (e, row) { },
        //设置附件页签的查询
        EvetnAttachFileWhere: function (e) { },
        //附件页签上传后，重新加载数据，data：附件页面上的数据数组
        EventAttacchFileAfterLoadData: function (data) { },
        //附件页签删除后，data：附件页面上的数据数组
        EventAttacchFileAfterDelete: function (data) { },
        //新增默认值参数
        EventGetNewDefaultValues: function (e) { return e; },
        //按钮生效前事件, action="effect" 生效，="uneffect" 取消生效
        EventBeforeEffect: function (e, action) { return e; },
        //打印按钮加载前e.canNext=true;取消后续加载操作
        EventBeforeLoadPrint: function (e) { },
        //打印按钮加载后
        EventAfterLoadPrint: function (e) { },
        //窗体初始化
        Init: function () {
            // form.init 错误
            mini.parse();
            //wsl 追加   WorkFlowUtils 如果存在，则必定是纳入在工作流体系中  (2016.07.08)
            if (typeof (workflowdata) != "undefined" && workflowdata) {
                //!=workflows = 旧版
                if (workflowdata.WorkFlowFlag != "workflows") {
                    if (typeof (WorkFlowUtils) != "undefined" && !workflowdata.IsSetted) {
                        workflowdata.IsSetted = true;
                        WorkFlowUtils.SetWorkFlowInfo(mini.decode(workflowdata));
                        var isView = false;
                        if (formconfig != undefined && formconfig.FormState == "view") isView = true; //传入参数， 判断当前模式是否只读模式， 只读模式下，流程按钮只显示监控系列
                        WorkFlowUtils.SetFlowButtons(workflowdata, isView);  //如果有工作流体系，则设定工作流按钮 
                    }
                }
                else {
                    if (typeof (controlCenter) != "undefined")   //有控制中心，说明是新版流程
                    {
                        var isView = false;
                        if (formconfig != undefined && formconfig.FormState == "view") isView = true; //传入参数， 判断当前模式是否只读模式， 只读模式下，流程按钮只显示监控系列

                        if (workflowdata.CanFlowOperate)    //正常打开，有SequeID ，能判断当前人和表单关系
                            controlCenter.onSetFlowResult(workflowdata.CanFlowOperate, isView);
                        else if (workflowdata.CurrentResult) {
                            controlCenter.onAskSequ(workflowdata.CurrentResult);   //询问当前序号位置
                        }
                    }
                }
            }

            if (typeof (formconfigerror) != "undefined" && formconfigerror.message) {
                top.Power.ui.error("初始化配置参数错误", { detail: formconfigerror.message, timeout: 0, position: "center center", closeable: true });
                return;
            }

            InitKindEditor(function () {
                //绑定form事件
                FormFuns.EventBeforeFormLoad = webself.EventBeforeFormLoad;
                FormFuns.EventAfterFormLoad = webself.EventAfterFormLoad;
                FormFuns.EventGetNewDefaultValues = webself.EventGetNewDefaultValues;
                FormFuns.EventBeforeLoadRight = webself.EventBeforeLoadRight;
                FormFuns.EventAfterLoadRight = webself.EventAfterLoadRight;

                initGridTree(null);
                FormFuns.InitComboboxData();
                //读取自定义过滤器信息
                FormFuns.LoadCustomFilter();
                //读取自定义列信息
                FormFuns.LoadCustomColumn();
                //初始化，触发配置根节点提取数据
                var miniid = formconfig.config.joindata.miniid;
                var sender = FormFuns.GetMiniFormGrid(miniid);
                //如果是 window.showModalDialog 方式打开，且是新增，则会通过 dialogArguments 方式传递新增默认值
                if (formconfig.FormState == "add" && window.dialogArguments)
                    webself.OnSetNewDefault(window.dialogArguments);

                FormFuns.ReLoadData(sender); //formload数据之后会执行权限计算
                //FormFuns.LoadRight(keyword, true);
                //处理Page分页控件样式
                FormFuns.InitPage();
                //excel复制粘贴
                FormFuns.CopyExcel();

                webself.EventAterInit();
                FormFuns.LoadPrint = webself.OnBtnPrint; //绑定打印按钮需要在页面加载完成之后，需要写到FormFuns中去。
                var configs = FormFuns.ConfigToList();
                for (var i = 0; i < configs.length; i++) {
                    webself.LoadExport(configs[i].miniid + "-Export"); //设置导出按钮
                }
                //设置收藏夹按钮图标颜色
                if (formconfig.IsFavorited != undefined)
                    webself.SetFavoiriteIconColor(null, formconfig.IsFavorited);
                FormFuns.BindImportExcelBtn();
            });

        },
        OnBeforeNodeSelect: function (e) {
            var sender = e.sender;
            var config = FormFuns.GetConfig(sender.id, null);
            if (config && config.children && config.children.length > 0) {
                var treegrid = mini.get(config.children[0].miniid);
                if (treegrid.getChanges().length > 0) {

                    e.cancel = true;
                    if (CanShowBox) {
                        CanShowBox = false;
                        var yes = app_global_ResouceId['webform_save'];
                        var no = app_global_ResouceId['webform_no_save'];
                        var canle = app_global_ResouceId['g_cancel'];
                        var buttonOption = {};
                        buttonOption[yes] = {
                            theme: 'primary',
                            handler: function () {
                                for (var i = 0; i < config.children.length; i++) {
                                    var save = { id: config.children[i].miniid + ".Save" }
                                    webself.OnBtnSave(save);
                                }
                                webself.OnNodeSelect(e);
                            }
                        };
                        buttonOption[no] = function () { webself.OnNodeSelect(e); };
                        buttonOption[canle] = function () { };
                        Power.ui.confirm(app_global_ResouceId['webform_unsave_children_data'], { button: buttonOption });
                    }

                }
                else
                    CanShowBox = true;

            }
            else
                CanShowBox = true;
        },
        //tree/grid切换行的时候
        OnNodeSelect: function (e) {
            FormFuns.NodeSelect(e);
            webself.EventAfterNodeSeleted(e);
        },
        //tree/grid.reload() 的时候触发，填充url参数
        OnBeforeLoad: function (e) {
            var sender = e.sender;    //树控件
            var node = e.node;      //当前节点
            var params = e.params;  //参数对象
            var config = FormFuns.GetConfig(sender.id, null);
            var autocancel = true;
            if (sender.getChanges().length > 0) {
                var buttonOption = {};
                var yes = app_global_ResouceId['docfile_yes'];
                var no = app_global_ResouceId['docfile_no'];
                buttonOption[yes] = {
                    theme: 'primary',
                    handler: function (ret) {
                        autocancel = true;
                    }
                };
                buttonOption[no] = function () {
                    autocancel = false;
                    sender.reload();
                };
                Power.ui.confirm("有修改未保存,是否继续修改", { button: buttonOption });
                if (autocancel)
                    e.cancel = true;
            }
            var pconfig = FormFuns.GetParentConfig(sender.id, null);
            params.KeyWord = config.KeyWord;
            params.KeyWordType = config.KeyWordType || "BO";
            params.select = config.select || "";
            params.swhere = "";
            params.sort = config.sort || config.sequfield || "";
            params.index = 0;
            params.size = 0;
            params.extparams = {};
            //拼与主表关联的where条件
            var swhere = FormFuns.FilterToSWhere(config.filter);
            if (config.fields && pconfig) {
                if (pconfig.currow) {
                    for (var fd in config.fields) {
                        if (typeof (fd) == "function")
                            continue;
                        var pfd = config.fields[fd];
                        if (typeof (pconfig.currow[pfd]) == undefined) //是常量值
                            swhere = swhere + " and " + fd + "='" + pdf + "'";
                        else {
                            if (pconfig.currow[pfd])
                                swhere = swhere + " and " + fd + "='" + pconfig.currow[pfd] + "'";
                            else//与主表关联字段没有值，可能是新增，也可能是null，那就不应该查出数据
                                swhere = swhere + " and 1=0";
                        }
                    }
                }
                else
                    swhere = swhere + " and 1=0";
            }
            if (mini.get("win_search") != undefined && formconfig[config.miniid + ".OnBtnSearch"]) { //查询面板

                var searchinfo = formconfig[config.miniid + ".OnBtnSearch"]["ConditionField"];
                if (searchinfo == undefined) {
                    searchinfo = formconfig[config.miniid + ".OnBtnSearch"];
                }
                var conditionFormula = formconfig[config.miniid + ".OnBtnSearch"]["ConditionFormula"];
                if (conditionFormula == undefined || conditionFormula == "") {
                    for (var item in searchinfo) {
                        //检测是否存在输入框
                        if (searchinfo[item].IfRegion == "1") {
                            if (!mini.get(item + "-1") || !mini.get(item + "-2"))
                                continue;
                        }
                        else {
                            if (!mini.get(item))
                                continue;
                        }

                        switch (searchinfo[item]["ConditionHTMLType"]) {
                            case "CheckBoxList":
                                if (mini.get(item).getValue() != "") {
                                    //判断checkbox是否是数字
                                    if (!isNaN(mini.get(item).getValue()))
                                        swhere = swhere + " and " + item + " in (" + mini.get(item).getValue() + ")";
                                    else

                                        swhere = swhere + " and " + item + " in ('" + mini.get(item).getValue() + "')";
                                }
                                break;
                            case "TextBox":
                                if (mini.get(item).getValue() != "") {
                                    if (searchinfo[item]["IfFuzzy"] == "1") {
                                        swhere = swhere + " and " + item + " like '%" + mini.get(item).getValue() + "%'";
                                    }
                                    else {
                                        swhere = swhere + " and " + item + " ='" + mini.get(item).getValue() + "'";
                                    }
                                }
                                break;
                            case "Date":
                                if (searchinfo[item]["IfRegion"] == "1") {
                                    if (mini.get(item + "-1").getValue() != "" && mini.get(item + "-2").getValue() != "") {
                                        swhere = swhere + " and " + item + " between '" + mini.get(item + "-1").getFormValue() + " 00:00:00" + "' and '" + mini.get(item + "-2").getFormValue() + " 23:59:59" + "'";
                                    }
                                    else {
                                        if (mini.get(item + "-1").getValue() != "") {
                                            swhere = swhere + " and " + item + " >= '" + mini.get(item + "-1").getFormValue() + " 00:00:00" + "'";
                                        }
                                        else if (mini.get(item + "-2").getValue() != "") {
                                            swhere = swhere + " and " + item + " <= '" + mini.get(item + "-2").getFormValue() + " 23:59:59" + "'";
                                        }
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        swhere = swhere + " and " + item + " between '" + mini.get(item).getFormValue() + " 00:00:00" + "' and '" + mini.get(item).getFormValue() + " 23:59:59" + "'";
                                    }
                                }
                                break;
                            case "DateTime":
                                if (searchinfo[item]["IfRegion"] == "1") {
                                    if (mini.get(item + "-1").getValue() != "" && mini.get(item + "-2").getValue() != "") {
                                        swhere = swhere + " and " + item + " between '" + mini.get(item + "-1").getFormValue() + "' and '" + mini.get(item + "-2").getFormValue() + "'";
                                    }
                                    else {
                                        if (mini.get(item + "-1").getValue() != "") {
                                            swhere = swhere + " and " + item + " >= '" + mini.get(item + "-1").getFormValue() + "'";
                                        }
                                        else if (mini.get(item + "-2").getValue() != "") {
                                            swhere = swhere + " and " + item + " <= '" + mini.get(item + "-2").getFormValue() + "'";
                                        }
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        swhere = swhere + " and " + item + " = '" + mini.get(item).getFormValue() + "'";
                                    }
                                }
                                break;
                            case "ButtonEdit":
                                if (mini.get(item).getValue() != "") {
                                    swhere = swhere + " and " + item + " ='" + mini.get(item).getValue() + "'";
                                }
                                break;
                            case "ComboBox":
                                if (mini.get(item).getValue() != "") {
                                    swhere = swhere + " and " + item + " ='" + mini.get(item).getValue() + "'";
                                }
                                break;
                            case "Spinner":
                                if (searchinfo[item]["IfRegion"] == "1") {
                                    if (mini.get(item + "-1").getValue() != "" && mini.get(item + "-2").getValue() != "") {
                                        swhere = swhere + " and " + item + " >= " + mini.get(item + "-1").getValue() + " and " + item + " <= " + mini.get(item + "-2").getValue() + "";
                                    }
                                    else {
                                        if (mini.get(item + "-1").getValue() != "") {
                                            swhere = swhere + " and " + item + " >= " + mini.get(item + "-1").getValue() + "";
                                        }
                                        else if (mini.get(item + "-2").getValue() != "") {
                                            swhere = swhere + " and " + item + " <= " + mini.get(item + "-2").getValue() + "";
                                        }
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        swhere = swhere + " and " + item + " = " + mini.get(item).getValue() + "";
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else {
                    var s1 = new RegExp("&&", "g");
                    var s2 = new RegExp("[|]{2}", "g");
                    var PlusWhere = conditionFormula.replace(s1, " and ");
                    PlusWhere = PlusWhere.replace(s2, " or ");
                    var currentwhere = "";
                    for (var item in searchinfo) {
                        if (searchinfo[item].IfRegion == "1") {
                            if (!mini.get(item + "-1") || !mini.get(item + "-2")) {
                                PlusWhere = PlusWhere.replace(item, "(1=1)");
                                continue;
                            }
                        }
                        else {
                            if (!mini.get(item)) {
                                PlusWhere = PlusWhere.replace(item, "(1=1)");
                                continue;
                            }
                        }
                        switch (searchinfo[item]["ConditionHTMLType"]) {
                            case "CheckBoxList":
                                if (mini.get(item).getValue() != "") {
                                    currentwhere = item + " in (" + mini.get(item).getValue() + ")";
                                }
                                else {
                                    currentwhere = "1=1";
                                }
                                break;
                            case "TextBox":
                                if (mini.get(item).getValue() != "") {
                                    if (searchinfo[item]["IfFuzzy"] == "1") {
                                        currentwhere = item + " like '%" + mini.get(item).getValue() + "%'";
                                    }
                                    else {
                                        currentwhere = item + " ='" + mini.get(item).getValue() + "'";
                                    }
                                }
                                else {
                                    currentwhere = "1=1";
                                }
                                break;
                            case "Date":
                            case "DateTime":
                                if (searchinfo[item]["IfRegion"] == "1") {
                                    if (mini.get(item + "-1").getValue() != "" && mini.get(item + "-2").getValue() != "") {
                                        currentwhere = item + " between '" + mini.get(item + "-1").getFormValue() + "' and '" + mini.get(item + "-2").getFormValue() + "'";
                                    }
                                    else {
                                        if (mini.get(item + "-1").getValue() != "") {
                                            currentwhere = item + " >= '" + mini.get(item + "-1").getFormValue() + "'";
                                        }
                                        else if (mini.get(item + "-2").getValue() != "") {
                                            currentwhere = item + " <= '" + mini.get(item + "-2").getFormValue() + "'";
                                        }
                                        else {
                                            currentwhere = "1=1";
                                        }
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        currentwhere = item + " = '" + mini.get(item).getFormValue() + "'";
                                    }
                                    else {
                                        currentwhere = "1=1";
                                    }
                                }
                                break;
                            case "ButtonEdit":
                                if (mini.get(item).getValue() != "") {
                                    currentwhere = item + " ='" + mini.get(item).getValue() + "'";
                                }
                                else {
                                    currentwhere = "1=1";
                                }
                                break;
                            case "ComboBox":
                                if (mini.get(item).getValue() != "") {
                                    currentwhere = item + " ='" + mini.get(item).getValue() + "'";
                                }
                                else {
                                    currentwhere = "1=1";
                                }
                                break;
                            case "Spinner":
                                if (searchinfo[item]["IfRegion"] == "1") {
                                    if (mini.get(item + "-1").getValue() != "" && mini.get(item + "-2").getValue() != "") {
                                        currentwhere = item + " >= " + mini.get(item + "-1").getValue() + " and " + item + " <= " + mini.get(item + "-2").getValue() + "";
                                    }
                                    else {
                                        if (mini.get(item + "-1").getValue() != "") {
                                            currentwhere = item + " >= " + mini.get(item + "-1").getValue() + "";
                                        }
                                        else if (mini.get(item + "-2").getValue() != "") {
                                            currentwhere = item + " <= " + mini.get(item + "-2").getValue() + "";
                                        }
                                        else {
                                            currentwhere = "1=1";
                                        }
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        currentwhere = item + " = " + mini.get(item).getValue() + "";
                                    }
                                    else {
                                        currentwhere = "1=1";
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        PlusWhere = PlusWhere.replace(item, "(" + currentwhere + ")");
                    }
                    swhere += " and " + PlusWhere;
                }
            }
            if (swhere.length > 0)
                params.swhere = " 1=1 " + swhere;
            if (config.swhere && config.swhere.length > 0) {
                if (params.swhere.length > 0)
                    params.swhere = params.swhere + " and (" + config.swhere + ")";
                else
                    params.swhere = config.swhere;
            }
            //替换[@]类型的参数
            var o = { swhere: params.swhere };
            FormFuns.ReplaceWhere(o, formconfig.config.joindata);
            params.swhere = o.swhere;
            if (FormFuns.IsMiniForm(sender))
            { }
            else if (FormFuns.IsMiniGrid(sender)) {
                var pager = mini.get(sender.id + ".Pager");
                if (pager) {
                    params.index = pager.pageIndex;
                    params.size = pager.pageSize;
                }
                else {
                    if (sender.showPager) {//使用自带的Pager
                        params.index = params.pageIndex;
                        params.size = params.pageSize;
                    }
                }
            }
            else if (FormFuns.IsMiniTree(sender)) {
                if (e.node)
                    params.parentid = e.node[sender.idField] || ""; //当前选中节点
                else
                    params.parentid = "";
                if (sender.lazyload) {
                    var il = parseInt(sender.getExpandOnLoad());
                    if (il && il > 0 && !sender.firstloaded)
                        params.level = il;
                    else
                        params.level = "1";
                }
                else
                    params.level = "0";
            }
            //补充自定义参数
            //if (typeof (FormParams) != "undefined" && FormParams != "") {
            //    params.extparams = base64encode(mini.encode(FormParams));
            //}
            if (typeof (FormParams) != "undefined" && FormParams != "") {
                params.extparams = FormParams;
            }

            if (workflowdata) {
                if (!FormFuns.WorkflowReadOnly(formconfig.Effected)) {
                    if (params.extparams && params.extparams != "")
                        params.extparams.defaultright = false;
                    else {
                        params.extparams = {};
                        params.extparams.defaultright = false;
                    }
                }
                var his = workflowdata.HistoryMind;
                for (var i = 0; i < his.length; i++) {
                    if (sessiondata.HumanId == his[i].UserID) {
                        if (params.extparams && params.extparams != "")
                            params.extparams.defaultright = false;
                        else {
                            params.extparams = {};
                            params.extparams.defaultright = false;
                        }
                    }
                }
                //如果权限中指定没有查看权限，即使审批中,也还是看不到数据
                if (keywordright && keywordright[config.KeyWord] && keywordright[config.KeyWord].bView == "0")
                    delete params.extparams.defaultright;
            }
            if (config.DataSummary) {
                if (params.extparams && params.extparams != "")
                    params.extparams.datasummary = config.DataSummary;
                else {
                    params.extparams = {};
                    params.extparams.datasummary = config.DataSummary;
                }
            }
            //补充自定义查询过滤器,formfuns.ChangeCustomFilter 中赋值
            if (sender._customfilterid) {
                if (params.extparams.length == 0) params.extparams = {};
                var extp = params.extparams;
                if (sender._customfilterid == "default") {
                    extp.customfilterid = "";
                    extp.customfilterobjectid = formconfig.FormId;
                    extp.customfilterobjectcode = sender.id;
                }
                else
                    extp.customfilterid = sender._customfilterid;
            }
            if (params.extparams && params.extparams != "")
                params.extparams = base64encode(mini.encode(params.extparams));
            webself.EventBeforeLoadData(e);
            //编码swhere
            if (params.swhere) {
                var tmp = {};
                if (params.extparams) {
                    var str = base64decode(params.extparams);
                    tmp = mini.decode(str);
                }
                tmp.encodeswhere = "true";
                params.extparams = base64encode(mini.encode(tmp));
                params.swhere = base64encode(params.swhere);
            }
        },
        //tree/grid 提取数据到本地之后，尚未赋值给 tree/grid 时触发
        OnPreLoad: function (e) {
            if (webself.EventBeforeSetData(e))
                return;
            var tmpdata = mini.decode(e.text);
            property = mini.decode(tmpdata.data.meta);
            //设置可编辑的单元格的最大值
            var fieldlength = tmpdata.data.fieldlength;
            if (fieldlength) {
                fieldlength = mini.decode(fieldlength);
                var columns = e.sender.columns;
                for (var i = 0; i < columns.length; i++) {
                    var column = columns[i];
                    if (column.editor && (column.editor.type == "textbox"
                        || column.editor.type == "combobox" || column.editor.type == "textarea")
                        && fieldlength[column.field] && fieldlength[column.field] > 0) {
                        column.editor.maxLength = parseInt(fieldlength[column.field]);
                    }
                }
            }
            if (tmpdata.success == false) {
                Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 0, position: "center center", closeable: true });
                return;
            }
            var data = mini.decode(tmpdata.data.value);
            data = webself.EventBeforeRenderData(e, data);

            if (FormFuns.IsMiniTree(e.sender)) { //树必须使用树结构数据
                e.sender.resultAsTree = true;
                data = mini.arrayToTree(data, e.sender.nodesField, e.sender.idField, e.sender.parentField);
            }
            e.data = data;
            var pager = mini.get(e.sender.id + ".Pager");
            if (pager)
                pager.setTotalCount(tmpdata.data.totalcount);
            else {
                if (e.sender.showPager)//使用自带的pager控件
                    e.sender.setTotalCount(tmpdata.data.totalcount);
            }
            DataSummary = tmpdata.data.DataSummary;
        },
        //数据赋值给 tree/grid 之后发生
        OnAfterLoad: function (e) {
            //如果是tree懒加载，miniui会自动给节点打上新增标记，需要去掉
            if (e.sender.lazyload) {
                for (var i = 0; i < e.data.length; i++)
                    delete e.data[i]._state;
            }
            //数据加载后，自动加载子表数据,前提条件 当前没有选中行，才需要自动加载
            var sender = e.sender;
            var config = FormFuns.GetConfig(sender.id, null);
            if (FormFuns.IsMiniForm(sender)) { }
            else if (FormFuns.IsMiniGrid(sender)) {
                if (sender.getSelected())
                    config.currow = sender.getSelected();
                else
                    config.currow = sender.getRow(0);
            }
            else if (FormFuns.IsMiniTree(sender)) {
                if (!sender.lazyload || !config.currow) {
                    if (sender.getSelectedNode())//树节点，如果本身有选中某个节点，此处currow为对应节点,xuzhimin 20180713
                        config.currow = sender.getSelectedNode();
                    else
                        config.currow = sender.getRootNode().children[0];
                }
            }
            if (sender.lazyload && !sender.firstloaded) {
                var il = parseInt(sender.getExpandOnLoad());
                if (il && il > 0) {
                    sender.firstloaded = true;
                    sender.expandAll();
                }
            }
            FormFuns.LoadChildData(sender.id);
            //触发数据加载后事件
            webself.EventAfterLoadData(e);
            if (FormFuns.IsMiniGrid(sender) && mini.get(sender.id + "-group-fields") != undefined && mini.get(sender.id + "-group-fields") != null) {
                var currentgrid = mini.get(sender.id);
                if (currentgrid) {
                    var searchfields = "[";
                    for (var i = 0; i < currentgrid.columns.length; i++) {

                        if (currentgrid.columns[i].type != "indexcolumn" && currentgrid.columns[i].type != "checkcolumn" && currentgrid.columns[i].visible)
                            if (property != undefined && property[currentgrid.columns[i].field] != undefined && property[currentgrid.columns[i].field] != "Guid")
                                searchfields += "{\"id\":\"" + currentgrid.columns[i].field + "\",\"text\":\"" + currentgrid.columns[i].header + "\"},";
                    }
                    if (searchfields.length > 1) {
                        searchfields = searchfields.substring(0, searchfields.length - 1) + "]";
                        mini.get(sender.id + "-group-fields").setData(searchfields);
                    }
                }
            }
        },
        OnDrawSummaryCell: function (e) {
            if (DataSummary && DataSummary != null) {
                DataSummary = mini.decode(DataSummary);
                var config = FormFuns.GetConfig(e.sender.id);
                if (!config)
                    Power.ui.warning("当前grid的id值：" + e.sender.id + "没有定义配置文件");
                var summaryfield = config.DataSummary;
                for (var i = 0; i < DataSummary.length; i++) {
                    var ds = DataSummary[i];
                    //先判断e.field是否是配置文件的汇总值
                    var isfiled = false;
                    for (var field in summaryfield) {
                        var ms = summaryfield[field].split(',');
                        for (var j = 0; j < ms.length; j++) {
                            if (e.field == ms[j]) {
                                isfiled = true;
                                break;
                            }
                        }
                        if (isfiled)
                            break;
                    }
                    if (!isfiled)
                        continue;
                    for (var name in ds) {
                        var ms = name.split(',');
                        for (var j = 0; j < ms.length; j++) {

                            if (e.field == ms[j]) {
                                var m = ds[ms[j]];
                                if (!(m == null) && !isNaN(m) && typeof (m.toFixed) == "function")
                                    m = m.toFixed(2);//数字保留2位小数
                                e.cellHtml = m;
                            }
                        }
                    }
                }
            }
        },
        getForm: function () {
            return formMain;
        },
        setForm: function (form) {
            formMain = form;
        },
        setKeyFieldName: function (data) {
            KeyFieldName = data;
        },
        getKeyFieldName: function () {
            return KeyFieldName;
        },
        setKeyWord: function (text) {
            KeyWord = text;
        },
        getKeyWord: function () {
            return KeyWord;
        },
        //执行向导操作
        OnBtnWizard: function (e, autoSave) {
            //有只读属性，且=true，不允许操作
            if (e.readOnly) {
                Power.ui.warning(app_global_ResouceId["status_readonly"]);//"当前状态为只读,不允许操作"
                return;
            }
            var btnid = e.id;
            var config = formconfig[btnid];
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + btnid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                return;
            }
            var url = "/Form/Wizard?wizardid=" + config.ComponentID + "&formid=" + FormId + "&btnid=" + btnid;

            webself.EventWizardWhere(e);
            var iwidth = e.iwidth || config.openwidth || parseInt(getInnerWidth("top") * 0.75);
            var iheight = e.iheight || config.openheight || parseInt(getInnerHeight("top") * 0.75);
            if (e.canOpen == false || e.canNext == false)
                return;
            if (formconfig.FormState == "add" && config.multi == "1" && btnid.indexOf("Add") > -1) {
                Power.ui.alert(app_global_ResouceId["webform_save_parent"]);
                return;//如果主表是新增，且向导是多选（认为是子表新增），不允许打开向导
            }
            mini.open({
                url: url,
                width: iwidth,
                height: iheight,
                title: config.title || app_global_ResouceId["g_select"],
                showMaxButton: true,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    var selobj = iframe.contentWindow.Select;
                    if (selobj) {
                        if (selobj.SetSourceData) selobj.SetSourceData(formconfig);
                        if (selobj.SetWhere) selobj.SetWhere(e.where);
                        if (selobj.LoadStepFirst) selobj.LoadStepFirst();
                    }
                },
                ondestroy: function (action) {
                    if (action != "ok")
                        return;
                    var iframe = this.getIFrameEl();
                    var data = null;
                    if (iframe.contentWindow.Select)
                        data = iframe.contentWindow.Select.GetData();
                    else {
                        if (iframe.contentWindow.GetData)
                            data = iframe.contentWindow.GetData();
                    }
                    if (!data || data.length == 0 || !data[0]) {
                        Power.ui.warning(app_global_ResouceId["not_select_data"]);//未选择数据
                        return;
                    }
                    data = mini.clone(data);
                    var tempdata = webself.EventWizardData(e, data);
                    if (tempdata) data = tempdata; //这样写是因为很多EventWizardData重载容易忘记 return data

                    if (e.Next == false)
                        return;
                    var miniid = FormFuns.GetGridTreeName(btnid);
                    var sender = FormFuns.GetMiniFormGrid(miniid);
                    if (!sender) {
                        Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                        return;
                    }
                    var kconfig = FormFuns.GetConfig(miniid);
                    if (!kconfig) {
                        Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                        return;
                    }

                    //Form，一行记录赋值
                    if (FormFuns.IsMiniForm(sender)) {
                        FormFuns.UpdateFormData(kconfig.miniid, false);
                        if (!kconfig.currow) return;
                        FormFuns.CopyFieldValue(kconfig.currow, data[0], config.fields);
                        sender.setData(kconfig.currow, true);
                        //可能存在-1到-10的赋值
                        for (var i = 1; i < 10; i++) {
                            var s = FormFuns.GetMiniFormGrid(miniid + "-" + i);
                            if (s) {
                                s.setData(kconfig.currow, true);
                            }
                        }
                        webself.EventWizardAfterUpdateRow(sender, kconfig.currow, btnid);
                        if (autoSave == true)
                            webself.OnBtnSave(e);
                        return;
                    }
                    //grid/tree 可能存在多行记录赋值
                    if (!FormFuns.IsMiniGridTree(sender))
                        return;

                    var distinctfield = null;
                    if (config.distinct != undefined && config.distinct.length > 0) {
                        distinctfield = new Object();
                        for (var i = 0; i < config.distinct.length; i++) {
                            var tofd = config.distinct[i];
                            var selectfd = config.fields[tofd];
                            distinctfield[tofd] = selectfd;
                        }
                    }

                    //只修改当前行数据
                    if (config.multi == "0") {
                        var data0 = data[0];
                        //检查不允许重复记录出现，场景：一个部门下一个人不能重复多次出现
                        if (FormFuns.IsDataExists(sender.data, data0, distinctfield) == true) {
                            //已经存在唯一值，跳过该条选择的记录
                            return;
                        }

                        var row = sender.getSelected();
                        if (!row) {
                            var a = { id: miniid };
                            //var row0 = FormFuns.OnGridTreeAdd(miniid);
                            row = webself.OnBtnAdd(a);
                        }
                        //FormFuns.CopyFieldValue(row, data0, config.fields);
                        var updvalue = FormFuns.GetUpdateValues(data0, config.fields);

                        if (FormFuns.IsMiniGrid(sender))
                            sender.updateRow(row, updvalue);
                        if (FormFuns.IsMiniTree(sender))
                            sender.updateNode(row, updvalue);
                        //grid/tree中，buttonedit不会自动修改
                        if (e.type != undefined && e.type == "buttonedit" && FormFuns.IsMiniGridTree(sender)) {
                            var fds = mini.decode(config.fields);
                            for (var tofd in fds) {
                                if (typeof (tofd) == "function") continue;
                                if (tofd == e.textName) {
                                    e.setValue(updvalue[tofd]);
                                    break;
                                }
                            }
                            sender.cancelEdit();
                        }
                        webself.EventWizardAfterUpdateRow(e, row);
                        if (autoSave == false)
                            return;
                        doSaveGridTree(sender);
                        return;
                    }
                    //允许多选，则默认选择内容都是新增项
                    for (var i = 0; i < data.length; i++) {
                        var selectrow = data[i];
                        //检查不允许重复记录出现，场景：一个部门下一个人不能重复多次出现
                        if (FormFuns.IsDataExists(sender.data, selectrow, distinctfield) == true) {
                            //已经存在唯一值，跳过该条选择的记录
                            continue;
                        }

                        //触发新增一行记录操作
                        // var row = singleself.OnBtnAdd(mini.get(keyword + "." + "Add"));
                        //var row = FormFuns.OnGridTreeAdd(miniid);
                        var row = webself.OnBtnAdd(sender);
                        if (row == false)
                            return;
                        FormFuns.CopyFieldValue(row, selectrow, config.fields);

                        if (FormFuns.IsMiniGrid(sender))
                            sender.updateRow(row);
                        if (FormFuns.IsMiniTree(sender))
                            sender.updateNode(row);
                        webself.EventWizardAfterUpdateRow(e, row);
                    }
                    if (autoSave == false)
                        return;
                    doSaveGridTree(sender);
                }
            });
        },
        //打开表单界面执行新增操作
        OnBtnAddForm: function (e, formid, params) {
            if (formconfig && formconfig.FormState == "add") {
                Power.ui.alert(app_global_ResouceId["webform_save_parent"]);
                return;
            }
            var senderid = FormFuns.GetGridTreeName(e.id);
            var defaultdata = FormFuns.GetNewDefaulValues(senderid);
            //如果是tree，treegrid，默认为新增选中节点的子节点
            var sender = mini.get(senderid);
            if (sender && FormFuns.IsMiniTree(sender)) {
                var node = sender.getSelectedNode();
                if (node)
                    defaultdata[sender.parentField] = node[sender.idField];
            }

            if (formconfig && formconfig[e.id] && formconfig[e.id].openformid)
                formid = formconfig[e.id].openformid;
            FormFuns.OnAddForm(formid, defaultdata, sender, params);
        },
        //打开查看窗体操作
        OnBtnViewForm: function (e, formid, params) {
            FormFuns.OnEditViewForm(e, formid, "view", params);
            FormFuns.OnEditViewForm = function () { }
        },
        //打开编辑窗口操作
        OnBtnEditForm: function (e, formid, params) {
            FormFuns.OnEditViewForm(e, formid, "edit", params);
        },
        //关闭窗体操作
        OnBtnCloseForm: function () {
            if (window.CloseOwnerWindow) //mini.open 的关闭方法
                window.CloseOwnerWindow();
            else {
                if (window.parent && window.parent.CloseOwnerWindow) //嵌套流程框的时候                
                    window.parent.CloseOwnerWindow();
                else
                    window.close();
            }
        },
        Type: function () {
            return "form";
        },
        //从台账页面新增时，可能会存在参数传递。如eps下增加项目，需要把epsid 传给项目
        OnSetNewDefault: function (data) {
            var config = formconfig.config.joindata;
            config.newdefaultdata = data;
            //由于ajax原因，会导致 setnewdefault 与 formreload 发生的先后顺序 随机,所以2边都需要处理
            if (!config.currow) return;
            for (var fd in data) {
                if (typeof (fd) == "function") continue;
                config.currow[fd] = data[fd];
            }
            var f = FormFuns.GetMiniFormGrid(config.miniid);
            if (f && FormFuns.IsMiniForm(f)) {
                //f.setData(config.currow);
                FormFuns.FormSetData(config.miniid, config.currow);
                //再次出发 afterformload 事件，通常发生在通过向导选择数据后 触发 addform 操作时
                webself.EventAfterFormLoad(f, config.currow);
                FormFuns.LoadCode(config, f);
            }
        },
        //保存并新增，主表快速录入数据时才会存在这样的需求
        OnBtnSaveAdd: function (e, params) {
            webself.OnBtnSave(e, true, params);
        },
        //执行新增操作,在表单上，该操作主要用在子表的新增操作
        OnBtnAdd: function (e, checkParent) {
            var gridid = FormFuns.GetGridTreeName(e.id);
            if (!e.OnBtnAddUnCheckParentAddState && !checkParent) {
                //如果当前按钮不是主表上的保存按钮,且主表状态为add，需先保存主表
                if (gridid != formconfig.config.joindata.miniid && formconfig.FormState == "add")
                { Power.ui.alert(app_global_ResouceId["webform_save_parent"]); return false; }
                //如果当前按钮不是主表上的保存按钮
                if (gridid != formconfig.config.joindata.miniid) {
                    //找到父Config
                    var parentconfig = FormFuns.GetParentConfig(gridid, null);
                    if (!parentconfig.currow) {
                        Power.ui.alert(app_global_ResouceId["webform_select_pre_children"]);//"请先选中父表行"
                        return;
                    }
                    //如果父级不是主表，且父级是新增状态
                    if (parentconfig.miniid != formconfig.config.joindata.miniid && parentconfig.currow._state == "added") {
                        Power.ui.alert(app_global_ResouceId["webform_save_pre_children"]);
                        return;
                    }
                }
            }
            FormFuns.EventBeforeAddRow = webself.EventBeforeAddRow;
            FormFuns.EventAfterAddRow = webself.EventAfterAddRow;
            if (e.canNext == false || e.canOpen == false)
                return;
            return FormFuns.OnGridTreeAdd(gridid);
        },
        //执行删除操作
        OnBtnDel: function (e, fncallback, params) {

            var gridid = FormFuns.GetGridTreeName(e.id);
            var grid = mini.get(gridid);
            if (!grid) {
                Power.ui.warning(app_global_ResouceId["g_through"] + gridid + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                return;
            }

            var rows = null;
            if (FormFuns.IsMiniGrid(grid)) {
                if (grid.multiSelect) {
                    rows = grid.getSelecteds();
                }
                else {
                    var row = grid.getSelected();
                    var rows = new Array();
                    rows.push(row);
                }
            }
            if (FormFuns.IsMiniTree(grid)) {
                if (grid.showCheckBox) {
                    rows = grid.getCheckedNodes(); //不包含没有选中的父节点
                    if (rows.length == 0)
                        return;
                }
                else {
                    var row = grid.getSelectedNode();
                    var rows = new Array();
                    rows.push(row);
                }
            }

            if (!rows || rows.length == 0) {
                Power.ui.warning(app_global_ResouceId["select_delete_row"]);//"请选中要删除的行"
                return;
            }
            webself.EventBeforeDelete(e, rows);
            if (e.cancel == true || e.canNext == false || e.canOpen == false)
                return;
            var buttonOption = {};
            var yes = app_global_ResouceId['docfile_yes'];
            var no = app_global_ResouceId['docfile_no'];
            buttonOption[yes] = {
                theme: 'primary',
                handler: function (ret) {
                    if (ret) {
                        if (FormFuns.IsMiniGrid(grid)) {
                            grid.removeRows(rows, false);
                        }
                        if (FormFuns.IsMiniTree(grid)) {
                            grid.removeNodes(rows);
                        }
                        delDataSetRow(grid, rows);
                        webself.EventAfterDelete(e, rows);
                        if (params && params.autosave != undefined && params.autosave == false) {

                        }
                        else {
                            webself.OnBtnSave(e, null, null, null,
                                function (success) {
                                    if (fncallback)
                                        fncallback();
                                    if (!success)
                                        grid.reload();
                                }
                            );
                        }
                    }
                }
            };
            buttonOption[no] = function () { };
            Power.ui.confirm(app_global_ResouceId["rightpage_alert_delete_select_data"], { button: buttonOption });

        },
        //保存操作
        OnBtnSave: function (e, afteradd, params, validData, fncallback) {

            if (params == undefined || params.length == 0)
                params = {};
            var senderid = FormFuns.GetGridTreeName(e.id);
            var isMainBtnSave = senderid == formconfig.config.joindata.miniid;
            //如果当前按钮不是主表上的保存按钮,且主表状态为add，需先保存主表
            if (isMainBtnSave == false && formconfig.FormState == "add")
            { Power.ui.alert(app_global_ResouceId["webform_save_parent"]); return; }
            //如果当前按钮不是主表上的保存按钮
            if (isMainBtnSave == false) {
                //找到父Config
                var parentconfig = FormFuns.GetParentConfig(senderid, null);
                //如果父级不是主表，且父级是新增状态
                if (parentconfig.miniid != formconfig.config.joindata.miniid && parentconfig.currow && parentconfig.currow._state == "added") {
                    Power.ui.alert(app_global_ResouceId["webform_save_pre_children"]);
                    return;
                }
            }
            webself.EventBeforeOnBtnSave(e);
            if (e.isValid == false || e.canNext == false || e.canOpen == false)
                return;
            //验证主表
            if (validData == undefined || validData == null || validData == true) {
                var oerr = FormFuns.ValidData(senderid, true);
                if (!oerr.success) {
                    if (oerr.errortext && oerr.errortext.length > 0)
                        Power.ui.error(app_global_ResouceId["vilidate_not_pass"] + ": <br/>" + oerr.errortext);//有必填项未填，请检查
                    else
                        Power.ui.error(app_global_ResouceId["vilidate_not_pass"]);//"有必填项未填，请检查"
                    return;
                }
            }

            //如果是主表的保存按钮，禁用
            if (isMainBtnSave && typeof (e.setEnabled) == "function") e.setEnabled(false);
            //更新 form 标签中的数据
            FormFuns.UpdateFormData(senderid, true);
            var pack = {};

            FormFuns.GetSaveDataPack(pack, senderid, true);

            webself.EventBeforeSaveData(pack, e);   //追加  e 参数，以控制行为，wsl 追加

            //检查是否有修改，减少服务器交互
            var jdata = { formId: FormId, encode: "r4" };
            jdata.jsonData = base64swhere(FormFuns.SaveDataPackToString(pack));
            //如果是审批处理，允许没有提交数据, workflowdata 是object时，lengt=undefined
            if (typeof (workflowdata) != "undefined" && workflowdata.UserID && typeof (formconfig) != "undefined" && !FormFuns.WorkflowReadOnly(formconfig.Effected)) {
                if (!params) params = {};
                params.IsWorkFlowHuman = "1";
            }
            //如果是新增状态数据，且是当前录入人
            var joindata = formconfig.config.joindata;
            if (joindata.statusfield && joindata.currow[joindata.statusfield] == "0"
                && FormFuns.IsRegHuman(joindata, joindata.currow)) {
                params.IsRegHuman = "1";
            }
            //如果包含模板附件,新增时需要触发
            if (formconfig.FormState == "add" && existsTabId("attachfiletemplate")) {
                if (!params) params = {};
                params.attachfiletemplate = [];
                params.attachfiletemplate.push(joindata.KeyWord);//用数组以后可以扩展多个
                if (formconfig.config.joindata.TempleteFilter) {
                    params.templetefilter = formconfig.config.joindata.TempleteFilter;
                }
            }
            jdata.Params = base64encode(params == undefined ? '' : mini.encode(params));


            var sUrl = "/Form/SaveWebForm";
            //wsl 追加，如果表单参数中有  FromSource ,并且值等于 TransFlow ，说明是从事务流触发的表单新增，则URL重新定向
            if (params && params.ControlPath != undefined) {
                sUrl = "/" + params.ControlPath + "/SaveWebForm";
            }
            Power.ui.loading("保存中……");
            $.ajax({
                url: sUrl,
                type: "POST",
                data: jdata,
                cache: false,
                success: function (text) {
                    var tmpdata = mini.decode(text);
                    Power.ui.loading.close();
                    if (tmpdata.success == false) {

                        //保存失败之后，也应该再放开保存按钮
                        if (typeof (e.setEnabled) == "function")
                            e.setEnabled(true);
                        //如果是由于自动编号字段重复，则将后台返回的新的编号赋值到页面
                        if (tmpdata.message.indexOf(app_global_ResouceId["autocode_defined_reset_save"]) > -1) {
                            Power.ui.error(app_global_ResouceId["autocode_defined_reset_save"], { detail: tmpdata.detail, timeout: 0, position: "center center", closeable: true });
                            //自动编码数据库已存在，已重新为您生成，请重新保存。
                            var newcode = mini.decode(tmpdata.message.replace(app_global_ResouceId["autocode_defined_reset_save"], ""));
                            //自动编码数据库已存在，已重新为您生成，请重新保存。
                            for (var i = 0; i < newcode.length; i++) {
                                joindata.currow[newcode[i]["Code"]] = newcode[i]["Value"];
                                mini.getbyName(newcode[i]["Code"]).setValue(newcode[i]["Value"]);
                            }
                        }
                        else {
                            Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 0, position: "center center", closeable: true });

                        }
                    }
                    else {
                        //Power.ui.success(app_global_ResouceId["rightpage_alert_save_success"]); //有遮罩不必再提醒
                        if (isMainBtnSave && formconfig.FormState == "add") {
                            //需要考虑修改主键的情况
                            if (pack[senderid] != undefined && pack[senderid].data[0][joindata.keyfield] != undefined)
                                formconfig.KeyValue = pack[senderid].data[0][joindata.keyfield];
                            else
                                formconfig.KeyValue = joindata.currow[joindata.keyfield];
                            formconfig.FormState = "edit";
                            if (typeof (FormState) != "undefined") FormState = "edit";

                            //wsl 追加，新增后，则立即显示 “送审按钮”   //2016.7.6 追加， 如果 IsWorkFlowHuman =1 ，就不修改 workFlowInfo ，以免影响全局变量信息
                            if (typeof (WorkFlowUtils) != "undefined") {
                                $("#btnActive").css("display", "");   //新增保存完毕后，让送审按钮可见 
                                var workFlowInfo = { KeyWord: joindata.KeyWord, KeyValue: formconfig.KeyValue, UserID: '', HtmlPath: formconfig.FormId };
                                WorkFlowUtils.SetWorkFlowInfo(workFlowInfo);
                            }
                        }
                        //保存后新增，只有主表有这样的需求，方便快速录入数据
                        if (isMainBtnSave) {
                            if (formconfig.FormState != "add") {
                                if (typeof (controlCenter) != "undefined")   //有控制中心，说明是新版流程
                                {
                                    onExecute(null, 'ReadFlow');  //加载流程
                                }
                            }
                            if (afteradd) {
                                formconfig.FormState = "add";
                                formconfig.KeyValue = "";
                                //如果是树，编辑打开，再点击 保存并新增，会导致新增的节点 应为没有给父节点赋值而在前端界面看不到数据
                                //因此增加如下判断
                                var cfg = FormFuns.GetConfig(senderid);
                                if (cfg && cfg.parentfield != undefined && cfg.parentfield.length > 0) {
                                    var pid = cfg.currow[cfg.parentfield];
                                    if (cfg.newdefaultdata == undefined)
                                        cfg.newdefaultdata = {};
                                    if (cfg.newdefaultdata[cfg.parentfield] == undefined)
                                        cfg.newdefaultdata[cfg.parentfield] = pid;
                                }
                            }
                            var f = FormFuns.GetMiniFormGrid(senderid);
                            FormFuns.FormReLoad(f, function (tmp) {
                                if (typeof (e.setEnabled) == "function")
                                    e.setEnabled(true);
                            });
                        }
                        else
                            doAcceptChange(senderid);
                        webself.EventAfterOnBtnSave(e);
                        if (existsTabId("attachfile") && top["FileOperate"] && top["FileOperate"].Save)
                            top["FileOperate"].Save();
                        if (existsTabId("attachfiletemplate") && top["FileOperateTemplate"] && top["FileOperateTemplate"].Save)
                            top["FileOperateTemplate"].Save();
                        if (existsTabId("distribute") && top["Distribute"] && top["Distribute"].Save)
                            top["Distribute"].Save();
                        if (existsTabId("distributenowebform") && top["DistributeListNoWebForm"] && top["DistributeListNoWebForm"].Save)
                            top["DistributeListNoWebForm"].Save();
                    }
                    if (fncallback) fncallback(tmpdata.success);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });
        },

        //2016.5.31 小徐为新版流程追加方法，可以直接得到表单数据包
        //Modified by Tao @2017-12-22，终止、作废、驳回时不判断必填项
        FlowSaveValid: function (e, validMustFill) {
            var params = {};
            var senderid = FormFuns.GetGridTreeName(e.id);
            var isMainBtnSave = senderid == formconfig.config.joindata.miniid;
            //如果当前按钮不是主表上的保存按钮,且主表状态为add，需先保存主表
            if (isMainBtnSave == false && formconfig.FormState == "add")
            { Power.ui.alert(app_global_ResouceId["webform_save_parent"]); return; }
            //如果当前按钮不是主表上的保存按钮
            if (isMainBtnSave == false) {
                //找到父Config
                var parentconfig = FormFuns.GetParentConfig(senderid, null);
                //如果父级不是主表，且父级是新增状态
                if (parentconfig.miniid != formconfig.config.joindata.miniid && parentconfig.currow && parentconfig.currow._state == "added") {
                    Power.ui.alert(app_global_ResouceId["webform_save_pre_children"]);
                    return;
                }
            }
            webself.EventBeforeOnBtnSave(e);
            if (e.isValid == false)
                return;
            if (validMustFill == undefined || validMustFill == null || validMustFill == true) {
                //验证主表 
                var oerr = FormFuns.ValidData(senderid, true);
                if (!oerr.success) {
                    if (oerr.errortext && oerr.errortext.length > 0)
                        Power.ui.error(app_global_ResouceId["vilidate_not_pass"] + ": <br/>" + oerr.errortext);//有必填项未填，请检查
                    else
                        Power.ui.error(app_global_ResouceId["vilidate_not_pass"]);//"有必填项未填，请检查"
                    return;
                }
            }
            //如果是主表的保存按钮，禁用
            if (isMainBtnSave && typeof (e.setEnabled) == "function") e.setEnabled(false);
            //更新 form 标签中的数据
            FormFuns.UpdateFormData(senderid, true);
            var pack = {};

            FormFuns.GetSaveDataPack(pack, senderid, true);

            webself.EventBeforeSaveData(pack, e);   //追加  e 参数，以控制行为，wsl 追加

            //检查是否有修改，减少服务器交互
            var jdata = { formId: FormId };
            jdata.jsonData = FormFuns.SaveDataPackToString(pack);
            //如果是审批处理，允许没有提交数据
            if (typeof (workflowdata) != "undefined" && typeof (formconfig) != "undefined" && !FormFuns.WorkflowReadOnly(formconfig.Effected)) {
                if (!params) params = {};
                params.IsWorkFlowHuman = "1";
            }
            //如果是新增状态数据，且是当前录入人
            var joindata = formconfig.config.joindata;
            if (joindata.statusfield && joindata.currow[joindata.statusfield] == "0"
                && FormFuns.IsRegHuman(joindata, joindata.currow)) {
                params.IsRegHuman = "1";
            }
            //如果包含模板附件,新增时需要触发
            if (formconfig.FormState == "add" && existsTabId("attachfiletemplate")) {

                if (!params) params = {};
                params.attachfiletemplate = [];
                params.attachfiletemplate.push(joindata.KeyWord);//用数组以后可以扩展多个
                if (formconfig.config.joindata.TempleteFilter) {
                    params.templetefilter = formconfig.config.joindata.TempleteFilter;
                }
            }
            jdata.Params = mini.encode(params);
            return jdata;

        },
        IsWorkFlowCurrentHuman: function () {
            if (typeof (workflowdata) != "undefined" && workflowdata != "" && workflowdata.WorkInfoID && typeof (formconfig) != "undefined" && !FormFuns.WorkflowReadOnly(formconfig.Effected)) {
                return true;
            }
            else
                return false;
        },
        //权限树操作
        OnBtnTreeList: function (e) {
            var btnid = e.id;
            var gridid = FormFuns.GetGridTreeName(btnid);
            var grid = FormFuns.GetMiniFormGrid(gridid);
            $.ajax({
                url: "/Form/GetRightTreeList",
                type: "POST",
                data: { KeyWord: KeyWord },
                cacha: false,
                success: function (text) {
                    var tmpdata = mini.decode(text);
                    if (tmpdata.data.TreeList) {
                        var obj = mini.decode(tmpdata.data.TreeList);
                        var arry = new Array(); //需要赋值的列名
                        for (var fd in obj) {
                            if (typeof (fd) == "function") continue;
                            arry.push(fd)

                        }
                        setRightTree(arry, obj, grid);
                    }
                }
            });
        },
        //刷新操作
        OnBtnRefresh: function (e) {
            var id = FormFuns.GetGridTreeName(e.id)
            var sender = FormFuns.GetMiniFormGrid(id);
            if (!sender) return;
            FormFuns.ReLoadData(sender);
        },
        //WebFrom中，点击按钮打开div
        //params打开表单的附加参数,字符串 
        OnBtnOpen: function (e, params) {
            var btnid = e.id;
            var config = formconfig[btnid];
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + btnid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                return;
            }
            //配置类型为add时，用此方式打开窗体
            if (config.type == "Add") {
                var gridid = FormFuns.GetGridTreeName(btnid);
                var defaultdata = FormFuns.GetNewDefaulValues(gridid);
                var url = "/Form/AddForm/" + config.openformid + "/" + base64encode(params == undefined ? '' : mini.encode(params));
                mini.open({
                    url: url,
                    title: "",
                    onload: function () {
                        if (defaultdata) {
                            webself.OnBtnSave(e, false, params);
                            //弹出页面加载完成，设置新增默认值
                            var iframe = this.getIFrameEl();
                            //调用弹出页面方法进行初始化
                            iframe.contentWindow.SetNewDefault(defaultdata);
                        }
                    },
                    ondestroy: function (action) {
                        webself.OnBtnRefresh(e);
                    }
                });
            }
                //配置类型为edit时，用此方法打开窗体，将recordId传过去，初始化窗体时，加载数据
            else if (config.type == "Edit") {
                FormFuns.OnEditViewForm(e, config.openformid, "edit", params);
            }
        },
        OnPageChanged: function (e) {
            var sender = FormFuns.GetMiniFormGrid(e.id.split('-')[0]);
            //如果根据按钮的Id找不到，找按钮的el的Id，miniui的源代码中按钮有多层html
            if (sender == null) {
                sender = FormFuns.GetMiniFormGrid(e.el.id.split('-')[0]);
            }
            if (!sender) return;
            if (sender.showPager)
                sender.gotoPage(0);
            else
                FormFuns.ReLoadData(sender);
        },
        OnBtnSearch: function (e) {
            var miniid = FormFuns.GetGridTreeName(e.id);

            var win = mini.get("win_search");

            var atEl = document.getElementById(miniid + ".Search");

            var SearchButtonId = $('a[id$=BtnSearch]')[0].id; //找到查询按钮的ID，不同业务对象的查询按钮 ID会变

            if (SearchButtonId != miniid + "-BtnSearch") {//换业务对象查询，更新查询面板的内容，若还是上一个操作的业务对象的查询按钮，则不更新查询面板的内容
                document.getElementById(SearchButtonId).id = miniid + "-BtnSearch";

                var searchinfo = formconfig[miniid + ".OnBtnSearch"]["ConditionField"];
                if (searchinfo == undefined) {
                    searchinfo = formconfig[miniid + ".OnBtnSearch"];
                }

                var table = document.getElementById("ConditionTable");
                for (var i = table.rows.length - 1; i >= 0; i--) {
                    table.deleteRow(i);
                }

                var evalstr = "";
                for (var item in searchinfo) {
                    var row = table.insertRow(table.rows.length);

                    var ConditionLable = "";
                    if (searchinfo[item]["IfShowLable"] == "1") {
                        ConditionLable = searchinfo[item]["Lable"];
                        var cell = row.insertCell(0);
                        cell.align = "left";
                        cell.style["width"] = "80px";
                        cell.innerHTML = ConditionLable;
                    }


                    var ConditionStr = "";
                    switch (searchinfo[item]["ConditionHTMLType"]) {
                        case "CheckBoxList":
                            ConditionStr = '<div class="mini-checkboxlist" id="' + item + '" repeatItems="3" repeatLayout="table" textField="" valueField="" value="" ></div>';
                            evalstr = 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.setData(mini.encode(comboboxdata[itemname].Data));';
                            break;
                        case "TextBox":
                            ConditionStr = '<input class="mini-textbox" id="' + item + '" emptyText=""/>';
                            break;
                        case "Date":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '-1" style="width:45%;" />&nbsp;到&nbsp;<input class="mini-datepicker" id="' + item + '-2" style="width:45%; float:right;" />';
                            }
                            else {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '"  />';
                            }
                            break;
                        case "DateTime":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '-1" style="width:45%;" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/>&nbsp;到&nbsp;<input class="mini-datepicker" id="' + item + '-2" style="width:45%; float:right;" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/>';
                            }
                            else {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '" onvaluechanged="onValueChanged" nullValue="null" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/>';
                            }
                            break;
                        case "ButtonEdit":
                            ConditionStr = '<input class="mini-buttonedit" id="' + item + '"  onbuttonclick="onButtonEdit" selectOnFocus="true" />';
                            break;
                        case "ComboBox":
                            if (searchinfo[item]["IfAllowInput"] == "1") {
                                ConditionStr = '<input class="mini-combobox" id="' + item + '" textField="text" valueField="id" allowInput="true" showNullItem="true" nullItemText="请选择..."/>   ';
                            }
                            else {
                                ConditionStr = '<input class="mini-combobox" id="' + item + '" textField="text" valueField="id" allowInput="false" showNullItem="true" nullItemText="请选择..."/>   ';
                            }
                            evalstr = 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.setData(mini.encode(comboboxdata[itemname].Data));';
                            break;
                        case "Spinner":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-spinner" id="' + item + '-1"  allowLimitValue="false" value="0" style="width:45%;"/>&nbsp;到&nbsp;<input class="mini-spinner" id="' + item + '-2"   allowLimitValue="false"  value="0" style="width:45%; float:right;"/>';
                            }
                            else {
                                ConditionStr = '<input class="mini-spinner" id="' + item + '"  allowLimitValue="false"  value="0"/>';
                            }
                            break;
                        default:
                            break;
                    }

                    var cell;
                    if (ConditionLable == "") {
                        cell = row.insertCell(0);
                        cell.colSpan = 2;
                    }
                    else {
                        cell = row.insertCell(1);
                    }
                    cell.align = "left";
                    cell.style["height"] = "35px";
                    cell.innerHTML = ConditionStr;
                }
                mini.parse();

                if (evalstr != "") {
                    eval(evalstr);
                }
            }

            win.showAtEl(atEl, {
                xAlign: "left",
                yAlign: "below"
            });
        },
        //打印操作
        OnBtnPrint: function (e, data) {
            var formid = formconfig.FormId;
            webself.EventBeforeLoadPrint(e);
            if (e.isValid == false || e.canNext == false || e.canOpen == false)
                return;
            if ($("#btnPrint") == undefined)
                return;
            $.ajax({
                url: "/Form/GetReport",
                type: "POST",
                data: { FormId: formid },
                cacha: false,
                success: function (text) {
                    var isphone = FormFuns.DeviceIsPhone();
                    var html = "<a href='#' class='btn blue' data-toggle='dropdown'>";
                    html += "<i class='fa fa-print'></i>" + app_global_ResouceId["g_print"] + "</a>";
                    html += "<ul class='dropdown-menu" + (isphone ? "" : " pull-right") + "'>";
                    var tmpdata = mini.decode(text);
                    var data = tmpdata.success ? mini.decode(tmpdata.data.value) : null; //得到所有报表信息
                    if (data != null && data != "") {
                        for (var i = 0; i < data.length; i++) {
                            var id = data[i].Id;
                            var keyvalue = formconfig.config.joindata.currow[formconfig.config.joindata.keyfield];
                            var keyword = formconfig.config.joindata.KeyWord;

                            var url = "/PowerPlat/FormXml/ReportView.aspx?rid=" + id + "&KeyWord=" + keyword;
                            if (data[i].FormKey != null && data[i].FormKey != "") {
                                var formKey = data[i].FormKey.split(',');

                                for (var j = 0; j < formKey.length; j++) {
                                    //[@Id]\[@KeyWord.xx]
                                    var par = formKey[j];
                                    var pars = par.split('.');
                                    if (pars.length == 2)//KeyWord.xxx
                                    {
                                        var config = FormFuns.GetConfig(pars[0], null);
                                        if (config != undefined && config != null && config.currow != undefined && config.currow != null)
                                            url += "&" + par + "=" + config.currow[pars[1]]; //如果能通过KeyWord找到对应的记录，&KeyWord.xxx=值
                                        else
                                            url += "&" + par + "=" + formKey[j]; //如果找不到记录，&KeyWord.xxxx=KeyWord.xxx
                                    }
                                    else {
                                        if (mini.get(pars[0]) != undefined && mini.get(pars[0]) != null)
                                            url += "&" + par + "=" + mini.get(pars[0]).getValue(); //如果能通过mini.get("xx")找到只，&xx=值
                                        else if (pars[0].toLowerCase() == "keyvalue")
                                            url += "&KeyValue=" + keyvalue;
                                        else
                                            url += "&" + par + "=" + formKey[j]; //如果找不到，&xx=xx;
                                    }

                                }
                            }
                            if (isphone)
                                html += "<li><a href='javascript:;' onclick='FormFuns.MiniOpenURL(\"" + url + "\")'>";
                            else
                                html += "<li><a href='" + url + "' target='_blank'>";
                            switch (data[i].ExpType) {
                                case "xlsx":
                                case "xls":
                                    html += "<i class='fa fa-file-excel-o'></i>";
                                    break;
                                case "doc":
                                case "docx":
                                    html += "<i class='fa fa-file-word-o'></i>";
                                    break;
                                case "pdf":
                                    html += "<i class='fa fa-file-pdf-o'></i>";
                                    break;
                                default:
                                    break;
                            }
                            html += data[i].Name + "</a></li>"
                        }
                    }
                    if ($(".de_form").length > 0)
                        html += "<li><a href='javascript:;' onclick='PowerForm.OnBtnOfficePrint(this)'><i class='fa fa-file-code-o'>打印页面</i>";;
                    html += "</ul>";
                    if (isphone && document.getElementById("btnPrint") && !$("#btnPrint").parent().is(".actions"))
                        $(document.getElementById("btnPrint").parentNode).html(html);
                    else
                        $("#btnPrint").html(html);
                    webself.EventAfterLoadPrint(e);
                }
            });
        },
        LoadExport: function (e) {
            if ($("#" + e) == undefined)
                return;
            var filename = "";
            var sort = "";
            if ($("#" + e).attr("title") != undefined && $("#" + e).attr("title").length > 0)
                filename = $("#" + e).attr("title");
            if ($("#" + e).attr("sort") != undefined && $("#" + e).attr("sort").length > 0)
                sort = $("#" + e).attr("sort");
            var html = "<a href=\"#\" class=\"btn blue\" data-toggle=\"dropdown\"><i class=\"fa fa-sign-out\"></i>" + app_global_ResouceId["g_export"] + "</a>";//导出
            html += "<ul class=\"dropdown-menu pull-left\">";
            html += "<li><a href=\"javascript:void(0)\" onclick=\"PowerForm.OnBtnExport('" + e.split('-')[0] + "','thispage','" + filename + "','" + sort + "')\">" + app_global_ResouceId["g_export_this"] + "</a></li>";//导出当前页
            html += "<li><a href=\"javascript:void(0)\" onclick=\"PowerForm.OnBtnExport('" + e.split('-')[0] + "','all','" + filename + "','" + sort + "')\">" + app_global_ResouceId["g_export_all"] + "</a></li>";//导出全部页
            $("#" + e).html(html);
        },
        //数据导出操作
        //xtype=all:导出全部,xtype=thispage:导出当前页
        OnBtnExport: function (e, xtype, filename, sort) {
            var miniid = (e.id != undefined && e.id != null) ? FormFuns.GetGridTreeName(e.id) : e;
            if (filename == undefined || filename == null)
                filename = "";
            FormFuns.ExportToXls(miniid, xtype, filename, webself.OnBeforeLoad, sort);
        },
        //单据直接生效,只有单据录入人可操作
        OnBtnEffect: function (e) {
            //
            Power.ui.confirm(app_global_ResouceId["g_confirm_effect"], function (action) {
                if (!action) return;
                webself.EventBeforeEffect(e, "effect");
                if (e.cancel != undefined && e.cancel == true || e.canNext == false || e.canOpen == false)
                    return;
                webself.OnBtnSave(e, false, null, null, function (success) {
                    if (success)
                        FormFuns.OnFormEffect(e, "effect", formconfig.FormId);
                })
            });

        },
        //单据反生效，只有单据录入人可操作
        OnBtnUnEffect: function (e) {
            webself.EventBeforeEffect(e, "uneffect");
            if (e.cancel != undefined && e.cancel == true || e.canNext == false || e.canOpen == false)
                return;
            FormFuns.OnFormEffect(e, "uneffect", formconfig.FormId);
        },
        //收藏按钮点击操作,e 是收藏按钮
        OnBtnFavorite: function (e, v) {
            if (!formconfig) {
                Power.ui.warning("缺少formconfig参数,收藏操作失败.");
                return;
            }
            var cfg = formconfig.config.joindata;
            var o = { FormId: formconfig.FormId, KeyWord: formconfig.config.joindata.KeyWord, KeyValue: formconfig.KeyValue, FormName: "" };
            if (v) {
                o.FormName = v.FormName;
                o.Name = v.Name
            }
            if (!o.FormName && e && e.el) {
                //按标准表单样式查找标题
                var cp = $(e.el).parent().parent().find(".caption").text();
                cp = $.trim(cp);
                if (cp.length > 0)
                    o.FormName = cp;
            }
            if (!o.Name) {
                if (cfg.namefield) o.Name = cfg.currow[cfg.namefield];
                else if (cfg.codefield) o.Name = cfg.currow[cfg.codefield];
                else o.Name = cfg.currow[cfg.keyfield];
            }
            o.action = formconfig.IsFavorited ? "del" : "add";
            o.showmessage = true;
            o.fncallback = function (rlt) {
                if (rlt.success) {
                    formconfig.IsFavorited = !formconfig.IsFavorited;
                    //修改图标颜色
                    if (e && e.el) {
                        webself.SetFavoiriteIconColor(e.el, formconfig.IsFavorited);
                    }
                }
            }
            FormFuns.PostFavorite(o);
        },
        //设置收藏按钮图标颜色
        SetFavoiriteIconColor: function (btn, favorited) {
            var id = ".Favorite"
            if (!btn) {
                id = formconfig.config.joindata.KeyWord + ".Favorite";
                var temp = mini.get(id);
                if (temp)
                    btn = temp.el;
            }
            if (!btn) {
                return;
            }
            var ii = $(btn).find("i");
            if (ii.length > 0) {
                if (favorited)
                    $(ii[0]).css("color", "yellow");
                else
                    $(ii[0]).removeAttr("style");
            }
        },
        OnComboboxClose: function (e) {
            FormFuns.OnComboboxClose(e);
        },
        OnButtonEditClose: function (e) {
            FormFuns.OnButtonEditClose(e);
        },
        //grid/tree点上移
        OnBtnMoveUp: function (e) {
            var gridid = FormFuns.GetGridTreeName(e.id);
            FormFuns.RowMoveUp(gridid);
        },
        //grid/tree点下移
        OnBtnMoveDown: function (e) {
            var gridid = FormFuns.GetGridTreeName(e.id);
            FormFuns.RowMoveDown(gridid);
        },
        //树节点左移
        OnBtnMoveLeft: function (e) {
            var treeid = FormFuns.GetGridTreeName(e.id);
            FormFuns.RowMoveLeft(treeid);
        },
        //树节点右移
        OnBtnMoveRight: function (e) {
            var treeid = FormFuns.GetGridTreeName(e.id);
            FormFuns.RowMoveRight(treeid);
        }
    ,
        GroupChanged: function (e) {
            var field = mini.get(e.id).getValue();
            var grid = mini.get(e.id.split('-')[0]);
            grid.groupBy(field, "asc");
        },
        ColseCombobox: function (e) {
            var obj = e.sender;
            obj.setText("");
            obj.setValue("");
            var grid = mini.get(e.sender.id.split('-')[0]);
            grid.clearGroup();
        },
        DrawGroup: function (e) {
            var field = mini.get(e.sender.id + "-group-fields").getValue();
            var text = mini.get(e.sender.id + "-group-fields").getText();
            var data = comboboxdata[e.sender.id + "." + field];
            if (data) {
                e.cellHtml = text + ":" + FormFuns.GetGroupText(e, data);
            }
            else
                e.cellHtml = text + ":" + e.value;
        },
        //GetGroupText: function (e, data) {//移动到FormFuns中
        //    var value = data.ValueField;
        //    var text = data.TextField;
        //    for (var i = 0; i < data.Data.length; i++) {
        //        if (data.Data[i][value] == e.value)
        //            return data.Data[i][text];
        //    }
        //},
        //grid或tree的id，导出的文件名，分组字段名，回掉函数，标题列背景色，标题列字体颜色
        OnExportDataToXls: function (gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor, levelcolor, fieldcolor) {
            FormFuns.ExportDataToXls(gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor, "", levelcolor, fieldcolor);
        },
        OnExportDataToPDF: function (gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor, levelcolor, fieldcolor) {
            FormFuns.ExportDataToXls(gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor, 'pdf', levelcolor, fieldcolor);
        },
        //grid或tree的id，导出的文件名，分组字段名，回掉函数，标题列背景色，标题列字体颜色,树的缩进字段
        OnExportTreeDataToXls: function (gridid, filename, treefield, groupfield, fnonbeforeload, headercolor, headerfontcolor) {
            FormFuns.ExportTreeDataToXls(gridid, filename, treefield, groupfield, fnonbeforeload, headercolor, headerfontcolor);
        },
        OnExportTreeDataToPDF: function (gridid, filename, treefield, groupfield, fnonbeforeload, headercolor, headerfontcolor) {
            FormFuns.ExportTreeDataToXls(gridid, filename, treefield, groupfield, fnonbeforeload, headercolor, headerfontcolor, 'pdf');
        },
        //展开/收缩全部节点
        OnBtnExpandAll: function (e) {
            var treeid = FormFuns.GetGridTreeName(e.id);
            var tree = mini.get(treeid);
            var nodes = tree.getList();//获取所有节点
            var b = true;
            for (var i = 0; i < nodes.length; i++) {
                if (!tree.isExpandedNode(nodes[i])) {//获取每个节点是否已经展开，有任意节点未展开，则设置false
                    b = false;
                    break;
                }
            }
            if (b) {
                mini.get(treeid).collapseAll();//如果全部展开，执行收索
            }
            else
                mini.get(treeid).expandAll();//否则执行全部展开
        },
        //展开\收索选中节点
        OnBtnExpandNode: function (e) {
            var treeid = FormFuns.GetGridTreeName(e.id);
            var tree = mini.get(treeid);
            var node = tree.getSelectedNode();
            if (!node) {
                Power.ui.warning(app_global_ResouceId["g_select_expandnode"]);//请选择要展开/收缩的父节点
                return;
            }
            var childs = tree.getAllChildNodes(node);
            var b = true;
            for (var i = 0; i < childs.length; i++) {
                if (!tree.isExpandedNode(childs[i])) {
                    b = false;
                    break;
                }
            }
            if (b) {
                mini.get(treeid).collapseNode(node, true);//如果全部展开，执行收索
            }
            else
                mini.get(treeid).expandNode(node, true);//否则执行全部展开
        },
        OnBtnOfficePrint: function (e) {
            if (formconfig.FormState == "add") {
                Power.ui.alert("新增状态不能打印");
                return;
            }
            window.open('/Form/ViewForm/' + FormId + '/' + formconfig.KeyValue + '?print=1', '_blank')
        },
        OnPictureAction: function (e) {
            var row = e.record;
            var config = FormFuns.GetConfig(e.sender.id, null);
            var FileField = webself.OnGetFileField(config.FileField, e.field);
            if (FileField == undefined || FileField == null)
                return;
            if ((row[FileField.FileIdField] == null || row[FileField.FileIdField] == "") && row._state != "added") {
                if ((mini.get(e.sender.id + ".Add") && mini.get(e.sender.id + ".Add").getEnabled()) ||
                    (mini.get(e.sender.id + ".Add1") && mini.get(e.sender.id + ".Add1").getEnabled()) ||
                    (mini.get(e.sender.id + ".Add2") && mini.get(e.sender.id + ".Add2").getEnabled()))
                    return '<a href="javascript:;" id="imgUpload' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '">' + app_global_ResouceId["docfile_up"] + '</a>';//上传
            }
            else if (row[FileField.FileIdField] != null && row[FileField.FileIdField] != "") {
                var s = '<a href="javascript:;" id="imgDownload' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '"  fileId="' + row[FileField.FileIdField] + '"  class=" btn green btn-xs mt5"><i class="fa fa-download"></i>' + app_global_ResouceId["g_download"] + '</a>';//下载
                s += '<a href="javascript:;" id="imgShow' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '"  fileId="' + row[FileField.FileIdField] + '"  class=" btn blue btn-xs mt5"><i class="fa fa-eye"></i>' + app_global_ResouceId["g_view"] + '</a>';//查看
                if (mini.get(e.sender.id + ".Add") && mini.get(e.sender.id + ".Add").getEnabled() ||
                    (mini.get(e.sender.id + ".Add1") && mini.get(e.sender.id + ".Add1").getEnabled()) ||
                    (mini.get(e.sender.id + ".Add2") && mini.get(e.sender.id + ".Add2").getEnabled()))
                    s += '<a href="javascript:;" id="imgDelete' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '"  fileId="' + row[FileField.FileIdField] + '" rowId="' + row[e.sender.idField] + '" class="btn red btn-xs mt5"><i class="fa fa-trash-o"></i>' + app_global_ResouceId["g_delete"] + '</a>'//删除
                return s;
            }
        },
        OnGetFileField: function (fields, fid) {
            for (var i = 0; i < fields.length; i++) {
                if (fields[i].FileIdField == fid)
                    return fields[i];
            }
        },
        OnSetAttachFileCount: function (count) {
            FormFuns.SetAttachFileCount(count);
        },
        OnUploadList: function (e) {
            var data = e.sender.getList();
            var config = FormFuns.GetConfig(e.sender.id, null);
            for (var iRow = 0, len = data.length; iRow < len; iRow++) {

                var row = data[iRow];
                var fields = config.FileField;
                for (var i = 0; i < fields.length; i++) {
                    webself.bindImgEvent(e, row, e.sender, fields[i].FileIdField);
                }

            }
        }, //绑定其他协议的按钮事件，上传、下载、删除
        bindImgEvent: function (eg, row, sender, fid) {

            var config = FormFuns.GetConfig(sender.id, null);
            var FileField = webself.OnGetFileField(config.FileField, fid);
            if (FileField == undefined || FileField == null)
                return;
            $("#imgUpload" + row[sender.idField] + "_" + row._id + "_" + fid).uploadify({
                height: 30,
                width: "6",
                index: row.Id,
                fileSizeLimit: 0,
                auto: true,
                blocksize: 2048 * 500, //分块大小
                buttonTheme: 'green btn-xs',
                buttonText: '<i class="fa fa-upload"></i>' + app_global_ResouceId["docfile_up"],
                swf: '/Scripts/plugins/uploadify/uploadify.swf',
                uploader: '/PowerPlat/Control/File.ashx?_type=ftp&action=upload',
                formData: {
                    KeyWord: config.KeyWord,
                    KeyValue: row[sender.idField]
                },
                onUploadComplete: function (e) {
                    //上传完毕修改的fileId和FileName
                    var s = "";
                    $.ajax({
                        url: "/Form/UploadComplete",
                        type: "POST",
                        data: { keyword: config.KeyWord, keyvalue: row[sender.idField], fieldid: FileField.FileIdField, fieldname: FileField.FileNameField, Name: e.name, FileSize: e.size },
                        cacha: false,
                        success: function (text) {
                            var tmpdata = mini.decode(text);
                            if (tmpdata.success) {
                                sender.reload();
                            }
                            else
                                Power.ui.alert(tmpdata.message);
                        }
                    });
                },
                onUploadStart: function () {
                    if (!sender.getSelected()) {
                        Power.ui.alert(app_global_ResouceId["workflow_select_node"]);//请先选择一条记录
                        return;
                    }
                    if (sender.getSelected()._state == "added")
                        PowerForm.OnBtnSave({ id: sender.id });
                },
                dragzone: "#FileOperate"
            });

            $("#imgDownload" + row[sender.idField] + "_" + row._id + "_" + fid).click(function () {

                var Id = $(this).attr("fileId");
                var url = "/File/Download/ftp/" + Id;
                window.open(url);
            });

            $("#imgShow" + row[sender.idField] + "_" + row._id + "_" + fid).click(function () {

                var Id = $(this).attr("fileId");
                var url = "/PowerPlat/FormXml/FileViewer.aspx?online=1&fileid=" + Id;
                window.open(url);
            });
            $("#imgDelete" + row[sender.idField] + "_" + row._id + "_" + fid).click(function () {
                var Id = $(this).attr("rowId");
                var yes = app_global_ResouceId["docfile_yes"];
                var no = app_global_ResouceId["docfile_no"];
                if (!Id) return;

                Power.ui.confirm(app_global_ResouceId["docfile_confirmdelete"], function (action) {
                    if (!action) return;
                    if (Id) {
                        $.ajax({
                            url: "/Form/DeleteComplete",
                            type: "POST",
                            data: { keyword: config.KeyWord, keyvalue: Id, fieldid: FileField.FileIdField, fieldname: FileField.FileNameField },
                            cacha: false,
                            success: function (text) {
                                var tmpdata = mini.decode(text);
                                if (tmpdata.success) {
                                    sender.reload();
                                }
                                else
                                    Power.ui.alert(tmpdata.message);
                            }
                        });
                    }
                }
                 );
            });
        }
    }

}

//从台账页面新增时，可能会传递参数到 webform，通过该方法赋值给webform.datasets
//注意：由于js顺序问题，该方法必须放在该文件末尾，否则执行顺序有问题，DataSets=null
window["SetNewDefault"] = function (data) {
    PowerForm.OnSetNewDefault(data);
}

