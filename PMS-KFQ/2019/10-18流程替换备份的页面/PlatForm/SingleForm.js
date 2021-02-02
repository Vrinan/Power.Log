
document.write('<script src="' + bootPATH + 'PlatForm/FormFuns.js?v=' + __bootGetFileVersion() + '" type="text/javascript" ></script>');

//处理台账页面，取数、数据处理与webform有差异
var SingleForm = function () {
    /* 
    /Form/Init/$Model.data.FormId  中获取到如下参数，引用sigleform.js 的html页面中需执行该请求
    formconfig:
    keywordright:
    */
    var CanShowBox = true;
    var property = null;
    var DataSummary = null;
    //var app_global_ResouceId = null;
    //保存成功后，去掉所有修改标记
    var doAcceptChange = function (grid) {
        //只有 removed 标记需要手动删除，grid.accept 已经对 add/modifield 做处理
        if (!grid) return;
        grid.accept();
        FormFuns.LoadChildData(grid.id);
    }


    //台账页面，操作后立即保存,且操作的都是 grid / tree
    var doSaveGridTree = function (sender, params, fncallback) {
        if (!sender) {
            Power.ui.warning(app_global_ResouceId['save_not_fined_grid']);//保存时未找到grid/tree
            return;
        }
        var pack = {};
        FormFuns.GetSaveDataPack(pack, sender.id, true);

        var jdata = { formId: "", encode: "r4" };
        jdata.jsonData = FormFuns.SaveDataPackToString(pack);
        jdata.Params = base64encode(params == undefined ? '' : mini.encode(params));

        singleself.EventBeforeSaveData(jdata);
        jdata.jsonData = base64swhere(jdata.jsonData);

        Power.ui.loading("保存中……");
        $.ajax({
            url: "/Form/SaveWebForm",
            type: "POST",
            data: jdata,
            success: function (text) {
                var o = mini.decode(text);
                Power.ui.loading.close();
                singleself.EventAfterSave(o);
                singleself.EventAfterOnBtnSave(o);
                if (o.success == false) {
                    Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                    sender.reload();
                }
                else {
                    //Power.ui.success(app_global_ResouceId["rightpage_alert_save_success"]); //有遮罩不必再提醒
                    doAcceptChange(sender);
                }

                if (fncallback) fncallback(o.success);
            }
        });
    }

    //初始化tree/grid，绑定事件
    var initGridTree = function (config) {

        if (!config)
            config = formconfig.config.joindata;
        var sender = mini.get(config.miniid);
        if (FormFuns.IsMiniGridTree(sender)) {
            sender.setAutoLoad(false);
            if (FormFuns.IsMiniTree(sender))
                sender.setUrl("/Form/TreeLazyLoad")
            else
                sender.setUrl("/Form/GridPageLoad");
            //grid
            if (FormFuns.IsMiniGrid(sender)) {
                sender.on("select", singleself.OnNodeSelect);
                sender.on("rowdblclick", singleself.OnRowDBLClick);
                sender.on("headercellclick", FormFuns.onheadercellclick);
                sender.on("beforeselect", singleself.OnBeforeNodeSelect);
                if (sender.sortField != undefined && sender.sortField != "") {
                    if (sender.sortOrder != undefined)
                        config.sort = sender.sortField + " " + sender.sortOrder;
                    else
                        config.sort = sender.sortField;
                }
            }
            else { //tree
                sender.on("nodeselect", singleself.OnNodeSelect);
                sender.on("nodedblclick", singleself.OnRowDBLClick);
                sender.on("beforenodeselect", singleself.OnBeforeNodeSelect);
            }
            sender.on("beforeload", singleself.OnBeforeLoad);
            sender.on("preload", singleself.OnPreLoad);
            sender.on("load", singleself.OnAfterLoad);

        }
        //递归设置子表
        if (!config.children || config.children.length == 0)
            return;
        for (var i = 0; i < config.children.length; i++)
            initGridTree(config.children[i]);
    }

    var getBodyDom = function (obj) {
        if (obj.className == 'mini-panel-body') return obj;
        else return getBodyDom(obj.parentNode);
    }

    return singleself = {
        //------外部扩展事件-------//
        //执行初始化操作结束后 触发
        EventAterInit: function () { },
        //tree,grid 请求ajax之前 触发
        EventBeforeLoadData: function (e) { },
        //tree,grid ajax请求到数据后setdata之前 触发, 返回true 则系统默认代码不再执行
        EventBeforeSetData: function (e, data) { return false; },
        //tree,grid 加载数据之后 触发
        EventAfterLoadData: function (e) { },
        //form 加载数据之后 触发 
        EventAfterFormLoad: function (f, data) { },
        //加载权限之前
        EventBeforeLoadRight: function (o) { },
        //加载权限之后
        EventAfterLoadRight: function (o) { },
        //tree,grid点击新增前触发
        EventBeforeAddForm: function (e) { },
        //新增表单前，设置默认值
        EventBeforeAddFormSetDefaultData: function (e, defaultdata) { },
        //tree点击左移前触发
        EventBeforeMoveLeft: function (e) { },
        //tree点击右移前触发
        EventBeforeMoveRight: function (e) { },
        //treenode选择前触发
        EventBeforeNodeSelect: function (e) { },
        //treenode选择后触发
        EventAfterNodeSeleted: function (e) { },
        //tree\grid保存前
        EventBeforeSave: function (e) { },
        //由于大部分人都在表单页面用了这个方法，所以此处也可使用本方法，方便记忆，效果和EventBeforeSave一样
        EventBeforeOnBtnSave: function (e) { },
        //tree/grid保存后
        EventAfterSave: function (e) { },
        //由于大部分人都在表单页面用了这个方法，所以此处也可使用本方法，方便记忆，效果和EventAfterSave一样
        EventAfterOnBtnSave: function (e) { },
        //form生成数据包，提交到服务器之前出发
        EventBeforeSaveData: function (data) { },
        //tree/grid行删除前触发
        EventBeforeDelete: function (e, row) { },
        //tree/grid行删除后触发
        EventAfterDelete: function (e, row) { },

        //向导选择数据，对grid/treeupdate之后触发
        EventWizardAfterUpdateRow: function (e, row) { },
        //tree/grid行新增后触发
        EventAfterAddRow: function (e, row) { },
        //tree/grid行新增前触发
        EventBeforeAddRow: function (e, ddata) { },
        //向导选中之后，对数据重新处理
        EventWizardData: function (e, data) { },
        //向导第一步查询条件赋值 
        EventWizardWhere: function (e) { },
        //通过新增打开表单，关闭后事件
        EventCloseAddForm: function (e) { },
        //通过编辑查看打开表单，关闭后事件
        EventCLoseEditViewForm: function (e) { },
        //窗体初始化
        Init: function () {
            mini.parse();
            // form.init 错误
            if (typeof (formconfigerror) != "undefined" && formconfigerror.message) {
                top.Power.ui.error("初始化配置参数错误", { detail: formconfigerror.message, timeout: 0, position: "center center", closeable: true });
                return;
            }
            //绑定form事件
            FormFuns.EventAfterFormLoad = singleself.EventAfterFormLoad;
            FormFuns.EventBeforeLoadRight = singleself.EventBeforeLoadRight;
            FormFuns.EventAfterLoadRight = singleself.EventAfterLoadRight;

            initGridTree(null);
            FormFuns.InitComboboxData();
            //读取自定义过滤器信息
            FormFuns.LoadCustomFilter();
            //读取自定义列信息
            FormFuns.LoadCustomColumn();
            //初始化，触发第一个节点提取数据
            var miniid = formconfig.config.joindata.miniid;
            var sender = FormFuns.GetMiniFormGrid(miniid);
            FormFuns.ReLoadData(sender);
            //计算权限
            FormFuns.LoadRight(miniid, true);
            //处理Page分页控件样式
            FormFuns.InitPage();
            //excel复制粘贴
            FormFuns.CopyExcel();


            var configs = FormFuns.ConfigToList();
            for (var i = 0; i < configs.length; i++) {
                singleself.LoadExport(configs[i].miniid + "-Export"); //设置导出按钮
            }
            for (var i = 0; i < configs.length; i++) {
                singleself.LoadHelp(configs[i].miniid + "-Help"); //设置帮助按钮
            }
            FormFuns.BindImportExcelBtn();
            singleself.EventAterInit();
        },
        OnBeforeNodeSelect: function (e) {
            singleself.EventBeforeNodeSelect(e);
            var sender = e.sender;
            var config = FormFuns.GetConfig(sender.id, null);
            if (config.children.length > 0) {
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
                                var save = { id: config.children[0].miniid + ".Save" }
                                var r = singleself.OnBtnSave(save);
                                if (r != false)
                                    singleself.OnNodeSelect(e);
                            }
                        };
                        buttonOption[no] = function () { singleself.OnNodeSelect(e); };
                        buttonOption[canle] = function () { CanShowBox = true };
                        top.Power.ui.confirm(app_global_ResouceId['webform_unsave_children_data'], { button: buttonOption });

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
            singleself.EventAfterNodeSeleted(e);
        },

        //tree/grid.reload() 的时候触发，填充url参数
        OnBeforeLoad: function (e) {
            var sender = e.sender;    //树控件
            var params = e.params;  //参数对象
            var config = FormFuns.GetConfig(sender.id, null);
            var autocancel = true;
            if (typeof (closecancel) != "undefined" && closecancel == 1 && sender.getChanges().length > 0) {
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
            params.sort = config.sort || "";
            params.index = 0;
            params.size = 0;
            params.extparams = "";
            //默认 排序字段 倒序
            if (params.sort.length == 0 && config.sequfield && config.sequfield.length > 0)
                params.sort = config.sequfield + " desc";
            //拼与主表关联的where条件
            var swhere = FormFuns.FilterToSWhere(config.filter);
            if (config.fields && pconfig) {
                if (pconfig.currow) {
                    for (var fd in config.fields) {
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
            if (FormFuns.IsMiniForm(sender))
            { }
            else if (FormFuns.IsMiniGrid(sender)) {
                var pager = mini.get(sender.id + ".Pager");
                if (pager) {//使用手动的Pager
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
            //获取右上角查询条件
            swhere += FormFuns.GetSearchFieldsWhere(sender.id);

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
                                        swhere = swhere + " and " + item + " in ('" + mini.get(item).getValue().replace(/,/g, "','") + "')";
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
                            case "TreeSelect":
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
                        currentwhere = "";
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
                        //去掉currentwhere="1=1"否则会出现 and(A='' or 1=1 )导致查询无效，xuzhimin
                        //增加替换，过滤掉and() ( and()) 之类的 错误
                        switch (searchinfo[item]["ConditionHTMLType"]) {
                            case "CheckBoxList":
                                if (mini.get(item).getValue() != "") {
                                    currentwhere = item + " in (" + mini.get(item).getValue() + ")";
                                }
                                //else {
                                //    currentwhere = "1=1";
                                //}
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
                                //else {
                                //    currentwhere = "1=1";
                                //}
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
                                        //else {
                                        //    currentwhere = "1=1";
                                        //}
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        currentwhere = item + " = '" + mini.get(item).getFormValue() + "'";
                                    }
                                    //else {
                                    //    currentwhere = "1=1";
                                    //}
                                }
                                break;
                            case "ButtonEdit":
                                if (mini.get(item).getValue() != "") {
                                    currentwhere = item + " ='" + mini.get(item).getValue() + "'";
                                }
                                //else {
                                //    currentwhere = "1=1";
                                //}
                                break;
                            case "ComboBox":
                                if (mini.get(item).getValue() != "") {
                                    currentwhere = item + " ='" + mini.get(item).getValue() + "'";
                                }
                                //else {
                                //    currentwhere = "1=1";
                                //}
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
                                        //else {
                                        //    currentwhere = "1=1";
                                        //}
                                    }
                                }
                                else {
                                    if (mini.get(item).getValue() != "") {
                                        currentwhere = item + " = " + mini.get(item).getValue() + "";
                                    }
                                    //else {
                                    //    currentwhere = "1=1";
                                    //}
                                }
                                break;
                            default:
                                break;
                        }

                        if (currentwhere != "")
                            PlusWhere = PlusWhere.replace(item, "(" + currentwhere + ")");
                        else {
                            PlusWhere = PlusWhere.replace("and " + item, "").replace("or " + item, "").replace(item, "");
                        }
                    }
                    PlusWhere = PlusWhere.replace("( )", "(1=1)").replace("( or", "(").replace("( and", "(").trim();
                    if (PlusWhere.indexOf("and") == 0)
                        PlusWhere = PlusWhere.replace("and", "");
                    if (PlusWhere.indexOf("or") == 0)
                        PlusWhere = PlusWhere.replace("or", "");
                    if (PlusWhere.trim() != "")
                        swhere += " and (" + PlusWhere + ")";
                }
            }
            if (swhere.length > 0)
                params.swhere = " 1=1  " + swhere;
            //config中指定的附加where条件
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
            //补充自定义参数
            var extp = null;
            if (typeof (FormParams) != "undefined") {
                extp = FormParams;
            }
            if (config.defaultright && config.defaultright == "false") {
                extp = extp || {};
                //如果FormParams中存在 权限控制的参数,以 FormParams中的为准
                if (!extp.defaultright)
                    extp.defaultright = "false";
            }
            //补充自定义查询过滤器,formfuns.ChangeCustomFilter 中赋值
            if (sender._customfilterid) {
                extp = extp || {};
                if (sender._customfilterid == "default") {
                    extp.customfilterid = "";
                    extp.customfilterobjectid = formconfig.FormId;
                    extp.customfilterobjectcode = sender.id;
                }
                else
                    extp.customfilterid = sender._customfilterid;
            }

            if (config.DataSummary) {
                if (extp && params.extp != "")
                    extp.datasummary = mini.encode(config.DataSummary);
                else {
                    extp = {};
                    extp.datasummary = mini.encode(config.DataSummary);
                }
            }
            if (extp)
                params.extparams = base64encode(mini.encode(extp));
            singleself.EventBeforeLoadData(e);
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

            var tmpdata = mini.decode(e.text);
            property = mini.decode(tmpdata.data.meta);
            if (tmpdata.success == false) {
                Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 0, position: "center center", closeable: true });
                return;
            }

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
            var data = mini.decode(tmpdata.data.value);
            if (singleself.EventBeforeSetData(e, data))
                return;
            if (FormFuns.IsMiniTree(e.sender)) { //树必须使用树结构数据
                e.sender.resultAsTree = true;
                data = mini.arrayToTree(data, e.sender.nodesField, e.sender.idField, e.sender.parentField);
            }
            e.data = data;
            var pager = mini.get(e.sender.id + ".Pager");
            if (pager)
                pager.setTotalCount(tmpdata.data.totalcount)
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
                    config.currow = sender.getRootNode().children[0];
                }
            }
            //FormFuns.LoadChildData(sender.id);  //nodeselect的时候会导致重复加载子表数据，影响性能            
            if (sender.lazyload && !sender.firstloaded && typeof (sender.getExpandOnLoad) == "function") {
                var il = parseInt(sender.getExpandOnLoad());
                if (il && il > 0) {
                    sender.firstloaded = true;
                    sender.expandAll();
                }
            }
            //设置右上角查询框 
            FormFuns.SetSearchFieldsData(sender.id, property);

            //触发数据加载后事件
            singleself.EventAfterLoadData(e);

            if (FormFuns.IsMiniGrid(sender) && mini.get(sender.id + "-group-fields") != undefined && mini.get(sender.id + "-group-fields") != null) {
                var rcurrentgrid = FormFuns.ParseGridAllHeader(sender.id);
                if (rcurrentgrid && rcurrentgrid.length > 0) {
                    var searchfields = "[";
                    for (var i = 0; i < rcurrentgrid.length; i++) {

                        if (rcurrentgrid[i].type != "indexcolumn" && rcurrentgrid[i].type != "checkcolumn" && rcurrentgrid[i].visible)
                            if (property != undefined && property[rcurrentgrid[i].field] != undefined && property[rcurrentgrid[i].field] != "Guid")
                                searchfields += "{\"id\":\"" + rcurrentgrid[i].field + "\",\"text\":\"" + rcurrentgrid[i].header + "\"},";
                    }
                    if (searchfields.length > 1) {
                        searchfields = searchfields.substring(0, searchfields.length - 1) + "]";
                        mini.get(sender.id + "-group-fields").setData(searchfields);
                        if (mini.get(sender.id + "-group-fields").getValue() != "")
                            mini.get(sender.id + "-group-fields").doValueChanged();
                    }
                }
            }
            FormFuns.LoadChildData(sender.id);
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
        //双击行的时候触发
        OnRowDBLClick: function (e) {

            //如果有编辑权限，默认以编辑方式打开，否则以查看方式打开
            var senderid = e.sender.id;
            var right = keywordright[senderid];
            if (!right) return; //无权限
            var btn = null;
            var config = FormFuns.GetConfig(formconfig.config.joindata.KeyWord);;
            if (FormFuns.IsRegHuman(config, e.record) || right.bEdit)//录入人双击自己录入的数据，已编辑的形式打开
                btn = mini.get(senderid + ".EditForm");
            if ((btn == undefined || btn.length == 0) && right.bView == "1")
                btn = mini.get(senderid + ".ViewForm");
            if (formconfig.FormState == "view")//查看状态，只查看
                btn = mini.get(senderid + ".ViewForm");

            if (btn) {
                btn.doClick();
            }
            else {//没有miniui控件时，判断是否有jquery控件 
                if (FormFuns.IsRegHuman(config, e.record) || right.bEdit)//录入人双击自己录入的数据，已编辑的形式打开
                    btn = $("#" + senderid + "\\.EditForm");
                if ((btn == undefined || btn.length == 0) && right.bView == "1")
                    btn = $("#" + senderid + "\\.ViewForm");
                if (formconfig.FormState == "view")//查看状态，只查看
                    btn = $("#" + senderid + "\\.ViewForm");

                if (btn) {
                    btn.click();
                }
            }
            e.htmlEvent.stopPropagation();
            return false;
        },
        //打开表单界面执行新增操作
        OnBtnAddForm: function (e, formid, params) {
            FormFuns.EventCloseAddForm = singleself.EventCloseAddForm;
            singleself.EventBeforeAddForm(e);
            if (e.canNext == false || e.canOpen == false)
                return;
            var btnid = FormFuns.GetGridTreeName(e.id);
            var defaultdata = FormFuns.GetNewDefaulValues(btnid);
            //如果是tree，treegrid，默认为新增选中节点的子节点
            var sender = mini.get(btnid);
            if (sender && FormFuns.IsMiniTree(sender)) {
                var node = sender.getSelectedNode();
                if (node)
                    defaultdata[sender.parentField] = node[sender.idField];
            }
            singleself.EventBeforeAddFormSetDefaultData(e, defaultdata);//给新增默认值增加额外参数
            //按钮设置独立的openformid
            if (formconfig[e.id] && formconfig[e.id].openformid)
                formid = formconfig[e.id].openformid;
            FormFuns.OnAddForm(formid, defaultdata, sender, params);
        },
        //打开查看窗体操作
        OnBtnViewForm: function (e, formid, params) {
            FormFuns.EventCLoseEditViewForm = singleself.EventCLoseEditViewForm;
            FormFuns.OnEditViewForm(e, formid, "view", params);
        },
        //打开编辑窗口操作
        OnBtnEditForm: function (e, formid, params) {
            FormFuns.EventCLoseEditViewForm = singleself.EventCLoseEditViewForm;
            var btnid = FormFuns.GetGridTreeName(e.id);
            var defaultdata = FormFuns.GetNewDefaulValues(btnid);
            //如果是tree，treegrid，默认为新增选中节点的子节点
            var sender = mini.get(btnid);
            if (sender && FormFuns.IsMiniTree(sender)) {
                var node = sender.getSelectedNode();
                if (node)
                    defaultdata[sender.parentField] = node[sender.idField];
            }
            //按钮设置独立的openformid
            if (formconfig[e.id] && formconfig[e.id].openformid)
                formid = formconfig[e.id].openformid;
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

        //执行新增操作
        OnBtnAdd: function (e) {
            var gridid = FormFuns.GetGridTreeName(e.id);

            FormFuns.EventBeforeAddRow = singleself.EventBeforeAddRow;
            FormFuns.EventAfterAddRow = singleself.EventAfterAddRow;
            if (e.canNext == false || e.canOpen == false)
                return;
            return FormFuns.OnGridTreeAdd(gridid);
        },
        //执行删除操作
        OnBtnDel: function (e, params, fncallback) {
            var id = FormFuns.GetGridTreeName(e.id);
            var sender = FormFuns.GetMiniFormGrid(id);
            if (!sender) {
                Power.ui.warning(app_global_ResouceId["g_through"] + id + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                return;
            }

            var rows = null;
            if (FormFuns.IsMiniGrid(sender)) {
                var grid = sender;
                if (grid.multiSelect) {
                    rows = grid.getSelecteds();
                }
                else {
                    rows = new Array();
                    rows.push(grid.getSelected());
                }
            }
            if (FormFuns.IsMiniTree(sender)) {
                var tree = sender;
                if (tree.showCheckBox) {
                    rows = tree.getCheckedNodes(); //不包含没有选中的父节点,为false是不包含父节点
                }
                else if (tree.multiSelect) {
                    rows = tree.getSelectedNodes();//如果是多选treegrid，则使用此方法
                }
                else if (tree.getSelectedNode()) {
                    rows = new Array();
                    rows.push(tree.getSelectedNode());
                }
            }

            if (!rows || rows.length == 0) return;

            singleself.EventBeforeDelete(e, rows);
            if (e.canNext == false || e.canOpen == false)
                return;
            var buttonOption = {};
            var yes = app_global_ResouceId['docfile_yes'];
            var no = app_global_ResouceId['docfile_no'];
            buttonOption[yes] = {
                theme: 'primary',
                handler: function (ret) {
                    if (ret) {
                        if (FormFuns.IsMiniGrid(sender)) {
                            sender.removeRows(rows, false);
                        }
                        if (FormFuns.IsMiniTree(sender)) {
                            sender.removeNodes(rows);
                        }
                        //立即保存数据
                        singleself.EventAfterDelete(e, rows);
                        doSaveGridTree(sender, params, fncallback);
                    }
                }
            };
            buttonOption[no] = function () { };
            top.Power.ui.confirm(app_global_ResouceId["rightpage_alert_delete_select_data"], { button: buttonOption });

        },
        //保存操作
        OnBtnSave: function (e, afteradd, params, fncallback) {
            singleself.EventBeforeSave(e);
            singleself.EventBeforeOnBtnSave(e);
            if (e.isValid == false || e.canNext == false || e.canOpen == false)
                return false;
            var id = FormFuns.GetGridTreeName(e.id);
            var sender = FormFuns.GetMiniFormGrid(id);
            if (!sender) {
                Power.ui.warning(app_global_ResouceId["g_through"] + id + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                return;
            }
            doSaveGridTree(sender, params, fncallback);
        },
        //刷新操作
        OnBtnRefresh: function (e) {
            var id = FormFuns.GetGridTreeName(e.id)
            var sender = FormFuns.GetMiniFormGrid(id);
            if (!sender) {
                Power.ui.warning(app_global_ResouceId["g_through"] + id + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                return;
            }
            FormFuns.ReLoadData(sender);
        },
        //执行向导操作
        OnBtnWizard: function (e, autoSave) {
            //有只读属性，且=true，不允许操作
            if (e.readOnly) return;
            var btnid = e.id;
            var config = formconfig[btnid];
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + btnid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件                
                return;
            }
            var iw = e.iwidth || config.openwidth || parseInt(getInnerWidth("top") * 0.75);
            var ih = e.iheight || config.openheight || parseInt(getInnerHeight("top") * 0.75);
            singleself.EventWizardWhere(e);
            if (e.canOpen == false || e.canNext == false)
                return;
            var url = "/Form/Wizard?wizardid=" + config.ComponentID + "&formid=" + FormId + "&btnid=" + btnid;
            mini.open({
                url: url, width: iw, height: ih, showMaxButton: true,
                title: config.title || app_global_ResouceId["g_select"],
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.Select.SetSourceData(formconfig);
                    iframe.contentWindow.Select.SetWhere(e.where);
                    iframe.contentWindow.Select.LoadStepFirst();
                },
                ondestroy: function (action) {
                    if (action != "ok")
                        return;
                    var iframe = this.getIFrameEl();
                    var data = iframe.contentWindow.Select.GetData();
                    if (!data || data.length == 0) {
                        Power.ui.warning(app_global_ResouceId["not_select_data"]);//未选择数据
                        return;
                    }
                    data = mini.clone(data);
                    singleself.EventWizardData(e, data);

                    if (e.Next == false)//此处特殊，由于上面已经有判断canOpen和canNext了，此处只能用另外一种
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
                        FormFuns.UpdateFormData(miniid, false);
                        if (!kconfig.currow) return;
                        FormFuns.CopyFieldValue(kconfig.currow, data[0], config.fields);
                        sender.setData(kconfig.currow, true);
                        singleself.EventWizardAfterUpdateRow(sender, kconfig.currow, btnid);
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
                            row = FormFuns.OnGridTreeAdd(miniid);
                        }
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
                        singleself.EventWizardAfterUpdateRow(e, row);
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
                        var row = FormFuns.OnGridTreeAdd(miniid);
                        FormFuns.CopyFieldValue(row, selectrow, config.fields);

                        if (FormFuns.IsMiniGrid(sender))
                            sender.updateRow(row);
                        if (FormFuns.IsMiniTree(sender))
                            sender.updateNode(row);
                        singleself.EventWizardAfterUpdateRow(e, row);
                    }
                    if (autoSave == false)
                        return;
                    doSaveGridTree(sender);
                }
            });
        },
        OnClearSeach: function (e) {
            var form = new mini.Form("#ConditionTable");
            if (form)
                form.clear();
        },
        Type: function () {
            return "win";
        },
        //查询面板中执行向导操作
        OnBtnWizardForSearch: function (e, autoSave) {
            //有只读属性，且=true，不允许操作
            if (e.readOnly) return;
            var btnid = e.id;
            var config = formconfig[btnid];
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + btnid + app_global_ResouceId["not_fined_config"]); //通过xx找不到配置文件                
                return;
            }
            singleself.EventWizardWhere(e);
            if (e.canOpen == false || e.canNext == false)
                return;
            var url = "/Form/Wizard?wizardid=" + config.ComponentID + "&formid=" + FormId + "&btnid=" + btnid;
            mini.open({
                url: url,
                title: config.title || app_global_ResouceId["g_select"],
                width: 720,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.Select.SetSourceData(formconfig);
                    iframe.contentWindow.Select.SetWhere(e.where);
                    iframe.contentWindow.Select.LoadStepFirst();
                },
                ondestroy: function (action) {
                    if (action != "ok")
                        return;
                    var iframe = this.getIFrameEl();
                    var data = iframe.contentWindow.Select.GetData();
                    if (!data || data.length == 0) {
                        Power.ui.warning(app_global_ResouceId["not_select_data"]); //未选择数据
                        return;
                    }
                    data = mini.clone(data);
                    singleself.EventWizardData(e, data);
                    var sender = mini.get(btnid);
                    var miniid = FormFuns.GetGridTreeName(btnid);
                    if (!sender) {
                        Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_grid"]); //通过xx找不到到Form/Grid/Tree
                        return;
                    }
                    var currentrow = {};
                    FormFuns.CopyFieldValue(currentrow, data[0], config.fields);
                    for (x in currentrow) {
                        if (mini.get(miniid + "." + x) != undefined) {
                            mini.get(miniid + "." + x).setValue(currentrow[x]);
                            switch (mini.get(miniid + "." + x).type) {
                                case "buttonedit":
                                    var textname = mini.get(miniid + "." + x).textName;
                                    mini.get(miniid + "." + x).setText(currentrow[textname]);

                                    break;
                            }
                        }
                    }

                }
            });
        },
        //执行向导新增操作
        OnBtnAddWizard: function (e, formid) {
            //有只读属性，且=true，不允许操作
            if (e.readOnly) return;
            var btnid = e.id;
            var config = formconfig[e.id];
            if (!config) return;
            singleself.EventWizardWhere(e);
            if (e.canOpen == false || e.canNext == false)
                return;
            var url = "/Form/Wizard?wizardid=" + config.ComponentID + "&formid=" + FormId + "&btnid=" + btnid;
            mini.open({
                url: url,
                width: 720,
                title: config.title || app_global_ResouceId["g_select"],
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.Select.SetSourceData(formconfig);
                    iframe.contentWindow.Select.SetWhere(e.where);
                    iframe.contentWindow.Select.LoadStepFirst();
                },
                ondestroy: function (action) {
                    if (action != "ok")
                        return;
                    var iframe = this.getIFrameEl();
                    var data = iframe.contentWindow.Select.GetData();
                    if (!data || data.length == 0) {
                        Power.ui.warning(app_global_ResouceId["not_select_data"]);//未选择数据
                        return;
                    }
                    data = mini.clone(data);
                    singleself.EventWizardData(e, data);
                    if (e.Next == false) return;
                    //按钮设置独立的openformid
                    var config = formconfig[btnid];
                    if (config.openformid) formid = config.openformid;
                    var defaultdata = mini.clone(config.fields);
                    var data0 = data[0];
                    for (var fd in defaultdata) {
                        if (typeof (fd) == "function") continue;
                        var wfd = defaultdata[fd];
                        if (data0[wfd] != undefined) defaultdata[fd] = data0[wfd];
                        else {
                            if (data0[wfd] == null) {
                                delete defaultdata[fd];
                            }
                        }
                    }
                    var gridid = FormFuns.GetGridTreeName(e.id);
                    //如果是tree，treegrid，默认为新增选中节点的子节点
                    var sender = mini.get(gridid);
                    FormFuns.OnAddForm(formid, defaultdata, sender);
                }
            });
        },
        //打开查询面板
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
                            evalstr += 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.setData(mini.encode(comboboxdata[itemname].Data));';
                            break;
                        case "TextBox":
                            ConditionStr = '<input class="mini-textbox" id="' + item + '" onenter="PowerForm.OnSearchEnter" emptyText=""/>';
                            break;
                        case "Date":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '-1" style="width:44%; float:left;" /><span style="width:12%; display:block; float:left; text-align:center; line-height:30px;">到</span><input class="mini-datepicker" id="' + item + '-2" style="width:44%; float:right;" />';
                            }
                            else {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '"  />';
                            }
                            break;
                        case "DateTime":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '-1" style="width:44%; float:left" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/><span style="width:12%; display:block; float:left; text-align:center; line-height:30px;">到</span><input class="mini-datepicker" id="' + item + '-2" style="width:44%; float:right;" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/>';
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
                            evalstr += 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.setData(mini.encode(comboboxdata[itemname].Data));';
                            break;
                        case "TreeSelect":
                            if (searchinfo[item]["IfAllowInput"] == "1") {
                                ConditionStr = '<input class="mini-treeselect" id="' + item + '" textField="text" valueField="id" allowInput="true" showNullItem="true" nullItemText="请选择..." expandOnLoad="true"/>   ';
                            }
                            else {
                                ConditionStr = '<input class="mini-treeselect" id="' + item + '" textField="text" valueField="id" allowInput="false" showNullItem="true" nullItemText="请选择..." expandOnLoad="true"/>   ';
                            }
                            evalstr += 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setParentField(comboboxdata[itemname].ParentField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.loadList(comboboxdata[itemname].Data,comboboxdata[itemname].ValueField,comboboxdata[itemname].ParentField);';
                            break;
                        case "Spinner":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-spinner" id="' + item + '-1"  allowLimitValue="false" value="0" style="width:44%; float:left;"/><span style="width:12%; display:block; float:left; text-align:center; line-height:30px;">到</span><input class="mini-spinner" id="' + item + '-2"   allowLimitValue="false"  value="0" style="width:44%; float:right;"/>';
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
        OnBtnSearch1: function (e) {
            var miniid = e;

            var win = $("#SearchBar");
            var SearchBarHtml = "";

            if (formconfig[miniid + ".OnBtnSearch"] != undefined) {
                var searchinfo = formconfig[miniid + ".OnBtnSearch"]["ConditionField"];
                if (searchinfo == undefined) {
                    searchinfo = formconfig[miniid + ".OnBtnSearch"];
                }

                var evalstr = "";
                var Width = 0; //查询条件共占宽度（12分）
                for (var item in searchinfo) {
                    var ConditionLable = "";
                    if (searchinfo[item]["IfShowLable"] == "1") {
                        SearchBarHtml += "<div class=\"col-md-1 col-hd-12\"  style=\"line-height:30px;\">";
                        SearchBarHtml += searchinfo[item]["Lable"];
                        SearchBarHtml += "</div>";

                        Width++;
                    }

                    var ConditionStr = "";
                    switch (searchinfo[item]["ConditionHTMLType"]) {
                        case "CheckBoxList":
                            ConditionStr = '<div class="mini-checkboxlist" id="' + item + '" repeatItems="3" repeatLayout="table" textField="" valueField="" value="" ></div>';
                            evalstr += 'var cmb = mini.get("' + item + '");';
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
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '-1" style="width:44%; float:left;" /><span style="width:12%; display:block; float:left; text-align:center; line-height:30px;">到</span><input class="mini-datepicker" id="' + item + '-2" style="width:44%; float:right;" />';
                            }
                            else {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '"  />';
                            }
                            break;
                        case "DateTime":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-datepicker" id="' + item + '-1" style="width:44%; float:left;" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/><span style="width:12%; display:block; float:left; text-align:center; line-height:30px;">到</span><input class="mini-datepicker" id="' + item + '-2" style="width:44%; float:right;" format="yyyy-MM-dd H:mm:ss" timeFormat="H:mm:ss" showTime="true" showOkButton="true" showClearButton="false"/>';
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
                            evalstr += 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.setData(mini.encode(comboboxdata[itemname].Data));';
                            break;
                        case "TreeSelect":
                            if (searchinfo[item]["IfAllowInput"] == "1") {
                                ConditionStr = '<input class="mini-treeselect" id="' + item + '" textField="text" valueField="id" allowInput="true" showNullItem="true" nullItemText="请选择..." expandOnLoad="true"/>   ';
                            }
                            else {
                                ConditionStr = '<input class="mini-treeselect" id="' + item + '" textField="text" valueField="id" allowInput="false" showNullItem="true" nullItemText="请选择..." expandOnLoad="true"/>   ';
                            }
                            evalstr += 'var cmb = mini.get("' + item + '");';
                            evalstr += 'var itemname = miniid+".Search.' + item + '";';
                            evalstr += 'cmb.setValueField(comboboxdata[itemname].ValueField);';
                            evalstr += 'cmb.setParentField(comboboxdata[itemname].ParentField);';
                            evalstr += 'cmb.setTextField(comboboxdata[itemname].TextField);';
                            evalstr += 'cmb.loadList(comboboxdata[itemname].Data,comboboxdata[itemname].ValueField,comboboxdata[itemname].ParentField);';
                            break;
                        case "Spinner":
                            if (searchinfo[item]["IfRegion"] == "1") {
                                ConditionStr = '<input class="mini-spinner" id="' + item + '-1"  allowLimitValue="false" value="0" style="width:44%; float:left;"/><span style="width:12%; display:block; float:left; text-align:center; line-height:30px;">到</span><input class="mini-spinner" id="' + item + '-2"   allowLimitValue="false"  value="0" style="width:44%; float:right;"/>';
                            }
                            else {
                                ConditionStr = '<input class="mini-spinner" id="' + item + '"  allowLimitValue="false"  value="0"/>';
                            }
                            break;
                        default:
                            break;
                    }
                    SearchBarHtml += "<div class=\"col-md-2 col-hd-12\" >";
                    SearchBarHtml += ConditionStr;
                    SearchBarHtml += "</div>";

                    Width += 2;

                }
                var EmptyWidth = 12 - Width % 12;
                Width += EmptyWidth;

                var EmptyHtml = "";
                if (EmptyWidth < 2) {
                    EmptyHtml = "<div class=\"col-md-" + EmptyWidth + " col-hd-12\"></div>";

                    EmptyWidth = 12;
                    Width += 12;
                }

                SearchBarHtml += EmptyHtml + "<div class=\"col-md-" + EmptyWidth + " col-hd-12\" style=\"line-height:30px;\"><a class=\"mini-button blue\"  id=\"Clear\" onclick=\"PowerForm.OnClearSeach(this)\" style=\"float:right; margin-left:20px;\"><i class=\"fa fa-search\"></i>清空</a><a class=\"mini-button blue\"  id=\"" + miniid + "-BtnSearch1\" onclick=\"PowerForm.OnPageChanged(this)\" style=\"float:right\"><i class=\"fa fa-search\"></i>搜索</a></div>";

                win.html(SearchBarHtml);
                mini.parse();

                var body = $(".portlet-body");
                for (var i = 0; i < body.length; i++) {
                    if (body[i].children.length > 0 && body[i].children[0].id == e) {
                        $(".portlet-body")[i].style["padding-top"] = (Math.ceil(Width / 12) * 40 + 42) + "px";
                    }
                }


                if (evalstr != "") {
                    eval(evalstr);
                }
            }
            else {
                win.height(0);
            }
        },
        //打印操作
        OnBtnPrint: function (e) {
            var menuid = "472E1993-A661-EA80-5352-C4726FCB5573";
            if ($("#" + e) == undefined)
                return;
            $.ajax({
                url: "/Form/GetReport",
                type: "POST",
                data: { FormId: menuid },
                cacha: false,
                success: function (text) {
                    var tmpdata = mini.decode(text);
                    var data = mini.decode(tmpdata.data.value); //得到所有报表信息
                    var html = "<a href=\"#\" class=\"btn blue\" data-toggle=\"dropdown\"><i class=\"fa fa-print\"></i>" + app_global_ResouceId["g_print"] + "</a>";//打印
                    html += "<ul class=\"dropdown-menu pull-right\">";
                    if (data != null && data != "") {
                        for (var i = 0; i < data.length; i++) {
                            var id = data[i].Id;
                            html += "<li><a href=\"/PowerPlat/FormXml/ReportView.aspx?rid=" + id;
                            if (data[i].FormKey != null && data[i].FormKey != "") {
                                var formKey = data[i].FormKey.split(',');

                                for (var j = 0; j < formKey.length; j++) {
                                    //[@Id]\[@KeyWord.xx]
                                    var par = formKey[j];

                                    var pars = par.split('.');
                                    if (pars.length == 2)//KeyWord.xxx
                                    {
                                        var k = e.split('-')[0];
                                        var cu = null;
                                        if (FormFuns.IsMiniGridTree(k)) {
                                            if (FormFuns.IsMiniGrid(k))
                                                cu = mini.get(k).getSelected();
                                            else
                                                cu = mini.get(k).getSelectedNode();
                                        }
                                        if (cu != undefined && cu != null)
                                            html += "&" + par + "=" + cu[pars[1]]; //如果能通过KeyWord找到对应的记录，&KeyWord.xxx=值
                                        else
                                            html += "&" + par + "=" + formKey[j]; //如果找不到记录，&KeyWord.xxxx=KeyWord.xxx
                                    }
                                    else {
                                        if (mini.get(pars[0]) != undefined && mini.get(pars[0]) != null)
                                            html += "&" + par + "=" + mini.get(pars[0]).getValue(); //如果能通过mini.get("xx")找到只，&xx=值

                                        else
                                            html += "&" + par + "=" + formKey[j]; //如果找不到，&xx=xx;
                                    }

                                }
                            }
                            switch (data[i].ExpType) {
                                case "xlsx":
                                case "xls":
                                    html += "\" target=\"_blank\"> <i class=\"fa fa-file-excel-o \"></i>" + data[i].Name + "</a></li>";
                                    break;
                                case "doc":
                                case "docx":
                                    html += "\" target=\"_blank\"> <i class=\"fa fa-file-word-o \"></i>" + data[i].Name + "</a></li>";
                                    break;
                                case "pdf":
                                    html += " \" target=\"_blank\"> <i class=\"fa fa-file-pdf-o \"></i>" + data[i].Name + "</a></li>";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    html += "</ul>";
                    $("#" + e).html(html);
                }
            });
        },
        LoadHelp: function (e) {
            if ($("#" + e).length == 0)
                return;

            if (Power.cookie.get("menuids") == "")
                return;
            var f = "帮助";
            if ($("#" + e).html())
                f = $("#" + e).html();
            //通过menuid找到数据库中的帮助表的列
            //认为menuid是存在与cookies中的，所以可以直接取

            $.ajax({
                url: "/Form/GetHelp",
                type: "POST",
                data: { MenuId: Power.cookie.get("menuids") },
                cacha: false,
                success: function (text) {
                    var tmpdata = mini.decode(text);
                    var data = mini.decode(tmpdata.data.value); //得到所有报表信息
                    var html = "<a href=\"#\" class=\"btn blue\" data-toggle=\"dropdown\"><i class=\"fa fa-question-circle\"></i>" + f + "</a>";//打印
                    html += "<ul class=\"dropdown-menu pull-right\">";
                    if (data != null && data != "") {
                        for (var i = 0; i < data.length; i++) {
                            var d = data[i];
                            switch (d.HelpType) {
                                case "富文本":
                                    html += "<li><a href=\"javascript:;\" onclick=\"PowerForm.HelpCreateWin('" + "a_" + d.Id + "','" + d.Name + "','" + d.Html + "')\"> <i class=\"fa fa-file-text-o \"></i>" + d.Name + "</a></li>";
                                    break;
                                case "url链接":
                                    html += "<li><a href=\"" + d.Url + "\" target=\"_blank\" > <i class=\"fa fa-globe \"></i>" + d.Name + "</a></li>";
                                    break;
                                case "附件":
                                    html += "<li><a href=\"/PowerPlat/FormXml/FileViewer.aspx?online=1&fileid=" + d.FileId + "\" target=\"_blank\" > <i class=\"fa fa-file-o \"></i>" + d.Name + "</a></li>";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    html += "</ul>";
                    $("#" + e).html(html);
                }
            });
        },
        HelpCreateWin: function (id, name, html) {
            if (mini.get(id)) {
                mini.get(id).showAtPos("center", "middle");//如果html已经存在，这直接打开
                mini.get(id).max();
            }
            else {
                var fullhtml =
                  "<div id=\"" + id + "\" class=\"mini-window\" style=\"width:700px;height:350px;\"" +
                        "showmaxbutton=\"true\" showcollapsebutton=\"false\" showshadow=\"false\"" +
                         " allowresize=\"true\" allowdrag=\"true\" title=\"" + name + "\">" +
                       "<div class=\"portlet box blue\" style=\"height: 100%; \">" +
                               "<div class=\"portlet-body\" style=\"height: 100%; \">" +
                               Base64.decode(html) +
                               "</div>" +
                       "</div>" +
                   "</div>";
                $("body").append(fullhtml);
                mini.parse();
                mini.get(id).showAtPos("center", "middle");
                mini.get(id).max();
            }
        },
        LoadExport: function (e) {
            if ($("#" + e).length == 0)
                return;
            var filename = "";
            var sort = "";
            if ($("#" + e).attr("title") != undefined && $("#" + e).attr("title").length > 0)
                filename = $("#" + e).attr("title");
            if ($("#" + e).attr("sort") != undefined && $("#" + e).attr("sort").length > 0)
                sort = $("#" + e).attr("sort");
            var html = "<a href=\"#\" class=\"btn blue\" data-toggle=\"dropdown\"><i class=\"fa fa-sign-out\"></i>" + app_global_ResouceId["g_export"] + "</a>";//导出
            html += "<ul class=\"dropdown-menu pull-right\">";
            html += "<li><a href=\"javascript:;\" onclick=\"PowerForm.OnBtnExport('" + e.split('-')[0] + "','thispage','" + filename + "','" + sort + "')\">" + app_global_ResouceId["g_export_this"] + "</a></li>";//导出当前页
            html += "<li><a href=\"javascript:;\" onclick=\"PowerForm.OnBtnExport('" + e.split('-')[0] + "','all','" + filename + "','" + sort + "')\">" + app_global_ResouceId["g_export_all"] + "</a></li>";//导出全部页
            $("#" + e).html(html);
        },
        //数据导出操作
        //xtype=all:导出全部,xtype=thispage:导出当前页
        OnBtnExport: function (e, xtype, filename, sort) {
            var miniid = (e.id != undefined && e.id != null) ? FormFuns.GetGridTreeName(e.id) : e;
            if (filename == undefined || filename == null)
                filename = "";
            FormFuns.ExportToXls(miniid, xtype, filename, singleself.OnBeforeLoad, sort);
        },
        //审核操作
        OnBtnValid: function (e) {
            var workInfoData = new Object();

            if (formconfig.FormState == "Add") {
                workInfoData.SequeID = 1;  //起草时流水号从1开始
            }
            else {
                formManage.setOperatorType("OpenRecord");
                formManage.setKeyValue(getParameter("KeyValue"));

                workInfoData.WorkInfoID = getParameter("WorkInfoID");   //当前流程号
                workInfoData.SequeID = getParameter("SequeID");      //当前流转流水号
                workInfoData.CurNodeCode = getParameter("NodeCode");  //当前节点编号
                workInfoData.CheckOutRecord = "false";    //如果从收件箱中打开，则触发签收指令
            }

            var tmpData = null;

            //如果非起草节点，则直接弹出选择节点框（此时流程已经绑定）
            if (formManage.getWorkInfo().RecordStatus != FlowRecordStatus.Create) {
                formManage.SelectSendNode("Send", EndSendSelect);
                return;
            }

            //起草节点，且只有一个候选流程，则直接绑定
            if (tmpData.WorkInfoData.CanActiveFlowList.length == 1) {
                var tmp = tmpData.WorkInfoData.CanActiveFlowList[0];
                formManage.getWorkInfo().WorkFlowID = tmp.WorkFlowID;
                formManage.getWorkInfo().Version = tmp.Version;
                formManage.getWorkInfo().CurNodeCode = tmp.CurNodeCode
                formManage.SelectSendNode("Send", EndSendSelect);
                return;
            }

            if (tmpData.WorkInfoData.CanActiveFlowList.length < 1) {
                Power.ui.error(app_global_ResouceId["singleform_unfind_workflow"], { timeout: 0, position: "center center", closeable: true });
                return;
            }


            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/WorkFlowSelect.html",
                title: app_global_ResouceId["singform_workflow"], //width: 580, height: 250,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(tmpData.WorkInfoData);   //选择可选工作流
                },
                ondestroy: function (action) {

                    if (action != "ok") return;
                    var iframe = this.getIFrameEl();
                    var data = iframe.contentWindow.GetData();
                    data = mini.clone(data);

                    formManage.getWorkInfo().WorkFlowID = data.WorkFlowID;
                    formManage.getWorkInfo().Version = data.Version;
                    formManage.getWorkInfo().CurNodeCode = data.CurNodeCode
                    formManage.SelectSendNode("Send", EndSendSelect);
                }
            });
        },
        OnComboboxClose: function (e) {
            FormFuns.OnComboboxClose(e);
        },
        OnButtonEditClose: function (e) {
            FormFuns.OnButtonEditClose(e);
        },
        //grid/tree点上移
        OnBtnMoveUp: function (e, params) {
            singleself.EventBeforeSave(e);
            singleself.EventBeforeOnBtnSave(e);
            if (e.isValid == false || e.canNext == false || e.canOpen == false)
                return false;
            var gridid = FormFuns.GetGridTreeName(e.id);
            if (FormFuns.RowMoveUp(gridid)) {
                var grid = mini.get(gridid);
                doSaveGridTree(grid, params);
            }
        },
        //grid/tree点下移
        OnBtnMoveDown: function (e, params) {
            singleself.EventBeforeSave(e);
            singleself.EventBeforeOnBtnSave(e);
            if (e.isValid == false || e.canNext == false || e.canOpen == false)
                return false;
            var gridid = FormFuns.GetGridTreeName(e.id);
            if (FormFuns.RowMoveDown(gridid)) {
                var grid = mini.get(gridid);
                doSaveGridTree(grid, params);
            }
        },
        //树节点左移
        OnBtnMoveLeft: function (e, params) {
            singleself.EventBeforeMoveLeft(e);
            if (e.canNext == false || e.canOpen == false) {
                return;
            }
            singleself.EventBeforeSave(e);
            singleself.EventBeforeOnBtnSave(e);
            if (e.isValid == false || e.canOpen == false || e.canNext == false)
                return false;
            var treeid = FormFuns.GetGridTreeName(e.id);
            if (FormFuns.RowMoveLeft(treeid)) {
                var tree = mini.get(treeid);
                doSaveGridTree(tree, params);
            }
        },
        //树节点右移
        OnBtnMoveRight: function (e, params) {
            singleself.EventBeforeMoveRight(e);
            if (e.canNext == false || e.canOpen == false) {
                return;
            }
            singleself.EventBeforeSave(e);
            singleself.EventBeforeOnBtnSave(e);
            if (e.isValid == false || e.canNext == false || e.canOpen == false)
                return false;
            var treeid = FormFuns.GetGridTreeName(e.id);
            if (FormFuns.RowMoveRight(treeid)) {
                var tree = mini.get(treeid);
                doSaveGridTree(tree, params);
            }
        },

        FieldChanged: function (e) {
            var props = e._boproperty;
            var field = mini.get(e.id).getValue();
            var search = e.id.split('-')[0] + "-search";
            if (props != null) {
                var miniid = e.id.replace("-search-fields", "");
                var rcurrentgrid = FormFuns.ParseGridAllHeader(miniid);
                var column = null;
                for (var i = 0; i < rcurrentgrid.length; i++) {
                    if (rcurrentgrid[i].field == field) {
                        column = rcurrentgrid[i];
                        break;
                    }
                }
                var data = comboboxdata[e.id.replace("-search-fields", "") + "." + field];
                //如果combobox列上直接绑定data属性，也可以选择到
                if (column && column.type == "comboboxcolumn" && !data && column.editor && column.editor.data
                    && typeof (column.editor.data) == "string") {
                    data = {};
                    data.Data = eval(column.editor.data);
                }
                if (column != null & column.type == "comboboxcolumn" && data && data != null) {
                    $("#" + search).html(" <input id=\"" + e.id.split('-')[0] + "-search-value\" class=\"mini-combobox\" multiSelect=\"true\" style=\"width: 150px;\" />");
                    mini.parse();
                    if (data.ValueField)
                        mini.get(e.id.split('-')[0] + "-search-value").setValueField(data.ValueField);
                    if (data.TextField)
                        mini.get(e.id.split('-')[0] + "-search-value").setTextField(data.TextField);
                    mini.get(e.id.split('-')[0] + "-search-value").setData(data.Data);

                }
                else if (props[field] != undefined && props[field] == "DateTime") {
                    $("#" + search).html(" <input id=\"" + e.id.split('-')[0] + "-search-value\" class=\"mini-datepicker\" format=\"yyyy-MM-dd\" style=\"width: 150px;\" />-<input id=\"" + e.id.split('-')[0] + "-search-value-d\" class=\"mini-datepicker\" format=\"yyyy-MM-dd\" style=\"width: 150px;\" />");
                    mini.parse();
                }
                else if (props[field] != undefined && props[field].toLowerCase() != "string") {
                    $("#" + search).html(" <input id=\"" + e.id.split('-')[0] + "-search-value\" class=\"mini-spinner\"  style=\"width: 100px;\" allowLimitValue=\"false\" />-<input id=\"" + e.id.split('-')[0] + "-search-value-d\" class=\"mini-spinner\"  style=\"width: 100px;\" allowLimitValue=\"false\"/>");
                    mini.parse();
                }
                else {
                    $("#" + search).html(" <input id=\"" + e.id.split('-')[0] + "-search-value\" class=\"mini-textbox\" style=\"width: 150px;\"  onenter=\"PowerForm.OnPageChanged\" />");
                    mini.parse();
                }

            }
        },
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
            else if (mini.formatDate(e.value, "yyyy-MM-dd") != "") {
                e.cellHtml = text + ":" + mini.formatDate(e.value, "yyyy-MM-dd");
            }
            else
                e.cellHtml = text + ":" + e.value;
        },
        //grid或tree的id，导出的文件名，分组字段名，回掉函数，标题列背景色，标题列字体颜色
        OnExportDataToXls: function (gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor, levelcolor, fieldcolor) {
            FormFuns.ExportDataToXls(gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor,"", levelcolor, fieldcolor);
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
        //GetGroupText: function (e, data) {//移动到FormFuns中
        //    var value = data.ValueField;
        //    var text = data.TextField;
        //    for (var i = 0; i < data.Data.length; i++) {
        //        if (data.Data[i][value] == e.value)
        //            return data.Data[i][text];
        //    }
        //},
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
            //如果子层级只有1层，且当前层级是收缩的，也展开
            if (b) {
                if (!tree.isExpandedNode(node)) {
                    b = false;
                }
            }
            if (b) {
                mini.get(treeid).collapseNode(node, true);//如果全部展开，执行收索
            }
            else
                mini.get(treeid).expandNode(node, true);//否则执行全部展开
        },
        OnPageChanged: function (e) {
            var sender = e.sender ? FormFuns.GetMiniFormGrid(e.sender.id.split('-')[0]) : FormFuns.GetMiniFormGrid(e.id.split('-')[0]);
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
        OnSearchEnter: function (e) {
            var sender = null;
            var btnArray = getBodyDom(this.el.parentNode).getElementsByClassName('mini-button');
            for (var i = 0; i < btnArray.length; i++) {
                if (btnArray[i].id.indexOf('BtnSearch') < 0) continue;
                sender = FormFuns.GetMiniFormGrid(btnArray[i].id.split('-')[0]);
                break;
            }
            if (!sender) return;
            if (sender.showPager)
                sender.gotoPage(0);
            else
                FormFuns.ReLoadData(sender);
        },
        OnPictureAction: function (e) {
            var row = e.record;
            var config = FormFuns.GetConfig(e.sender.id, null);
            var FileField = singleself.OnGetFileField(config.FileField, e.field);
            if (FileField == undefined || FileField == null)
                return;
            if ((row[FileField.FileIdField] == null || row[FileField.FileIdField] == "") && row._state != "added") {
                if (mini.get(e.sender.id + ".Add") && mini.get(e.sender.id + ".Add").getEnabled())
                    return '<a href="javascript:;" id="imgUpload' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '">' + app_global_ResouceId["docfile_up"] + '</a>';//上传
            }
            else if (row[FileField.FileIdField] != null && row[FileField.FileIdField] != "") {
                var s = '<a href="javascript:;" id="imgDownload' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '"  fileId="' + row[FileField.FileIdField] + '"  class=" btn green btn-xs mt5"><i class="fa fa-download"></i>' + app_global_ResouceId["g_download"] + '</a>';//下载
                s += '<a href="javascript:;" id="imgShow' + row[e.sender.idField] + "_" + row._id + "_" + e.field + '"  fileId="' + row[FileField.FileIdField] + '"  class=" btn blue btn-xs mt5"><i class="fa fa-eye"></i>' + app_global_ResouceId["g_view"] + '</a>';//查看
                if (mini.get(e.sender.id + ".Add") && mini.get(e.sender.id + ".Add").getEnabled())
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
        OnUploadList: function (e) {
            var data = e.sender.getList();
            var config = FormFuns.GetConfig(e.sender.id, null);
            for (var iRow = 0, len = data.length; iRow < len; iRow++) {

                var row = data[iRow];
                var fields = config.FileField;
                for (var i = 0; i < fields.length; i++) {
                    singleself.bindImgEvent(e, row, e.sender, fields[i].FileIdField);
                }

            }
        }, //绑定其他协议的按钮事件，上传、下载、删除
        bindImgEvent: function (eg, row, sender, fid) {

            var config = FormFuns.GetConfig(sender.id, null);
            var FileField = singleself.OnGetFileField(config.FileField, fid);
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
        },
        QmenuLibrary: function (miniid) {
            var QmenuMap = {
                'add': {
                    name: 'add',
                    title: app_global_ResouceId["g_add"],
                    iconCls: 'plus',
                    handler: function () {
                        singleself.OnBtnAddForm({ id: miniid + ".AddForm" }, OpenFormId);
                    }
                },
                'edit': {
                    name: 'edit',
                    title: app_global_ResouceId["g_edit"],
                    iconCls: 'edit',
                    handler: function () {
                        singleself.OnBtnEditForm({ id: miniid + ".EditForm" }, OpenFormId);
                    }
                },
                'view': {
                    name: 'view',
                    title: app_global_ResouceId["g_view"],
                    iconCls: 'book',
                    handler: function () {
                        singleself.OnBtnViewForm({ id: miniid + ".ViewForm" }, OpenFormId);
                    }
                },
                'refresh': {
                    name: 'refresh',
                    title: app_global_ResouceId["g_refresh"],
                    iconCls: 'refresh',
                    handler: function () {
                        singleself.OnBtnRefresh({ id: miniid + ".Refresh" });
                    }
                },
                'delete': {
                    name: 'delete',
                    title: app_global_ResouceId["g_delete"],
                    iconCls: 'trash-o',
                    handler: function () {
                        singleself.OnBtnDel({ id: miniid + ".Delete" });
                    }
                },
                'moveup': {
                    name: 'moveup',
                    title: app_global_ResouceId["g_up"],
                    iconCls: 'arrow-up',
                    handler: function () {
                        singleself.OnBtnMoveUp({ id: miniid + ".moverow" });
                    }
                },
                'movedown': {
                    name: 'movedown',
                    title: app_global_ResouceId["g_down"],
                    iconCls: 'arrow-down',
                    handler: function () {
                        singleself.OnBtnMoveDown({ id: miniid + ".moverow" });
                    }
                },
                'moveleft': {
                    name: 'moveleft',
                    title: app_global_ResouceId["g_left"],
                    iconCls: 'arrow-left',
                    handler: function () {
                        singleself.OnBtnMoveLeft({ id: miniid + ".moverow" });
                    }
                },
                'moveright': {
                    name: 'moveright',
                    title: app_global_ResouceId["g_right"],
                    iconCls: 'arrow-right',
                    handler: function () {
                        singleself.OnBtnMoveRight({ id: miniid + ".moverow" });
                    }
                },
                'copy': {
                    name: 'copy',
                    title: app_global_ResouceId["g_copy"],
                    iconCls: 'copy',
                    handler: $.noop
                },
                'cut': {
                    name: 'cut',
                    title: app_global_ResouceId["g_cut"],
                    iconCls: 'cut',
                    handler: $.noop
                },
                'paste': {
                    name: 'paste',
                    title: app_global_ResouceId["g_paste"],
                    iconCls: 'paste',
                    handler: $.noop
                },
                'search': {
                    name: 'search',
                    title: app_global_ResouceId["g_search"],
                    iconCls: 'search',
                    handler: function () {
                        singleself.OnBtnSearch({ id: miniid + ".Search" });
                    }
                }
            };

            return QmenuMap;
        },
        setQmenu: function (miniid, names) {

            if (!miniid) return;

            names = names || 'view,refresh,delete,edit,moveup,movedown';

            var QmenuMap = singleself.QmenuLibrary(miniid);

            names.split(",").forEach(function (name) {
                name = $.trim(name);
                if (QmenuMap.hasOwnProperty(name)) {
                    //添加菜单项
                    Power.quickMenu.addItem(QmenuMap[name]);
                }
            });

            //快速菜单初始化
            var Qmenu = Power.quickMenu();

            //单击grid显示菜单
            var gridEl = typeof miniid == 'string' ? mini.get(miniid) : miniid;
            gridEl.on("rowclick", function (event) {
                event.htmlEvent.stopPropagation();
                Qmenu.show({
                    left: event.htmlEvent.pageX,
                    top: event.htmlEvent.pageY
                });
            });

        }
    }
}

