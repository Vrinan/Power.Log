document.write('<script src="' + bootPATH + 'PlatForm/FormFuns.js" type="text/javascript" ></script>');

var Select = function () {
    var currentgrid = null;
    var currentgrid_plus = null;
    var wizardpars = { stepindex: 0 }; //初始第一步index是0
    var textfieldList = new Object();
    var parentfieldList = new Object();
    var defaultWhere = "";
    var property = null;
    var sourcedata = null; //记录调用表单的 formconfig，方便访问调用表单上的数据
    function search() {
        var key = mini.get("key").getValue();
    }
    function onKeyEnter(e) {
        search();
    }

    var SetStepVisible = function (idx, visible) {
        var id = "StepDiv" + idx;
        var o = document.getElementById(id);
        if (!o) {
            id = "Step" + idx;
            o = mini.get(id);
            if (o) o.setVisible(visible);
        }
        else {
            if (visible == true) {
                o.style.display = "";
            }
            else {
                o.style.display = "none";
            }
        }
    }
    //////////////////////////////////
    var CloseWindow = function (action) {
        if (window.CloseOwnerWindow)
            return window.CloseOwnerWindow(action);
        else
            window.close();
    }
    var OnOK = function () {
        //树、单选、必须选叶子节点
        var selgrid = currentgrid_plus == undefined ? currentgrid : currentgrid_plus;
        if (GridIsTree(selgrid) == true && selgrid.showCheckBox == false && wizardpars.isleaf != undefined && wizardpars.isleaf == "1") {
            var node = selgrid.getSelectedNode();
            if (selgrid.isLeaf(node) == false) {
                Power.ui.info("请选择叶子节点.");
                return;
            }
        }
        CloseWindow("ok");
    }
    var OnCancel = function () {
        CloseWindow("cancel");
    }
    var OnNext = function () {
        var prestepnode = Select.GetData();
        if (!prestepnode || prestepnode.length == 0) {
            Power.form.warning("请选择一条记录");
            return;
        }
        SetStepVisible(wizardpars.stepindex, false);
        wizardpars.stepindex++;
        SetStepVisible(wizardpars.stepindex, true);
        currentgrid = mini.get("Step" + wizardpars.stepindex);
        //下一步不一定使用上一步的id作为条件，也可能是其他字段或多个字段
        currentgrid.prestepnode = prestepnode;
        currentgrid.reload();

        if (wizardpars.stepindex < maxNo) {
            mini.get("btn-prev").setVisible(true);
            mini.get("btn-next").setVisible(true);
            mini.get("btn-cancel").setVisible(true);
            mini.get("btn-ok").setVisible(false);
        }
        else {
            mini.get("btn-prev").setVisible(true);
            mini.get("btn-next").setVisible(false);
            mini.get("btn-cancel").setVisible(true);
            mini.get("btn-ok").setVisible(true);
            //设置是否允许多选,是否允许多选，指最后一步 是否允许多选
            setLastMulti();
        }

        document.title = "";
        SetSearchFiledsData();
        mini.get("search-fields").setValue("");
        mini.get("search-value").setValue("");
    }
    var OnPrev = function () {

        currentgrid.setData({});
        SetStepVisible(wizardpars.stepindex, false);
        wizardpars.stepindex--;
        currentgrid = mini.get("Step" + wizardpars.stepindex);
        SetStepVisible(wizardpars.stepindex, true);

        if (wizardpars.stepindex > minNo) {
            mini.get("btn-prev").setVisible(true);
            mini.get("btn-next").setVisible(true);
            mini.get("btn-cancel").setVisible(true);
            mini.get("btn-ok").setVisible(false);
        }
        else {
            mini.get("btn-prev").setVisible(false);
            mini.get("btn-next").setVisible(true);
            mini.get("btn-cancel").setVisible(true);
            mini.get("btn-ok").setVisible(false);
        }
        SetSearchFiledsData();
        mini.get("search-fields").setValue(currentgrid._search_fields);
        mini.get("search-value").setValue(currentgrid._search_value);
    }
    var OnPageChanged = function () {
        var selgrid = currentgrid_plus == undefined ? currentgrid : currentgrid_plus;
        selgrid._search_btn = true;
        selgrid._search_fields = mini.get("search-fields").getValue();
        var field = mini.get("search-fields").getValue();
        var value = mini.get("search-value").getValue();
        if (mini.get("search-value").uiCls == "mini-datepicker")
            value = mini.get("search-value").getFormValue();
        if (property != null) {
            if (property[field] != undefined && property[field] == "DateTime") {
                value = mini.get("search-value").getFormValue()

            }
        }
        selgrid._search_value = value;
        selgrid.reload();
    }
    //判断是 grid or tree
    var GridIsTree = function (o) {
        return o._dataSource.type == "datatree";
    }

    var setLastMulti = function () {
        if (currentgrid == undefined) return;
        //设置是否允许多选,是否允许多选，指最后一步 是否允许多选
        if ((wizardpars) && (wizardpars.multi)) {
            var bmulti = wizardpars.multi == "1";

            if (GridIsTree(currentgrid))
                currentgrid.showCheckBox = bmulti;
            else {
                currentgrid.setMultiSelect(bmulti);
                if (bmulti)
                    currentgrid.showColumn("checkcolumn");
                else
                    currentgrid.hideColumn("checkcolumn");
            }
        }
    }
    //tree 懒加载切换行的时候加载子节点数据
    var OnTreeNodeSelect = function (e) {
        var sender = e.sender;
        var node = e.node;
        if (sender.lazyload && (node.isLeaf == undefined || node.isLeaf == false)
                    && (node.children == undefined || node.children.length == 0)) {
            sender.loadNode(node);
        }
        if (currentgrid_plus != undefined)
            currentgrid_plus.reload();
    }



    //tree/grid 提取数据到本地之后，尚未赋值给 tree/grid 时触发
    var OnPreLoad = function (e) {
        var tmpdata = mini.decode(e.text);
        property = mini.decode(tmpdata.data.meta);
        if (tmpdata.success == false) {
            Power.ui.error(tmpdata.message, { timeout: 0, position: "center center", closeable: true });
            return;
        }
        var data = mini.decode(tmpdata.data.value);
        if (GridIsTree(e.sender)) { //树必须使用树结构数据
            //如果是懒加载，标记节点不展开，否则出现 - 号图标，实际应该是 + 号图标
            if (e.sender.lazyload) {
                for (var i = 0; i < data.length; i++)
                    data[i].expanded = false;
            }
            e.sender.resultAsTree = true;
            data = mini.arrayToTree(data, e.sender.nodesField, e.sender.idField, e.sender.parentField);
        }
        e.data = data;
        e.sender.setTotalCount(tmpdata.data.totalcount);
        //如果是查询按钮，不需要重置
        if (!e.sender._search_btn)
            SetSearchFiledsData();
    }
    var SetSearchFiledsData = function (sender) {
        var search = mini.get("search-fields");
        var selgrid = currentgrid_plus == undefined ? currentgrid : currentgrid_plus;
        if (search) {
            var fields = [];
            for (var i = 0; i < selgrid.columns.length; i++) {
                var col = selgrid.columns[i];
                if (col.type == "indexcolumn" || col.type == "checkcolumn" && !col.visible
                    || property[col.field] == undefined || property[col.field] == "Guid" || col.visible == false)
                    continue;
                fields.push({ id: col.field, text: col.header });
            }
            search.setData(fields);
            if (fields.length > 0) {
                search.setValue(fields[0].id);
                wizardself.FieldChanged()
            }
        }
    }
    var InitComboboxData = function () {
        //form/initwizarddata中获取 comboboxdata
        if (columncomboboxStep == undefined || !columncomboboxStep) return;
        for (var item in columncomboboxStep) {
            if (typeof (item) == "function") continue;
            var cmb = mini.get(item);
            if (cmb) {
                cmb.setValueField(columncomboboxStep[item].ValueField);
                cmb.setTextField(columncomboboxStep[item].TextField);
                cmb.setData(mini.encode(columncomboboxStep[item].Data));
            }
            else { //不能通过id直接找到对应的列
                var senderid = funsself.GetGridTreeName(item);
                if (!senderid) continue;
                var sender = funsself.GetMiniFormGrid(senderid);
                if (!sender || !funsself.IsMiniGridTree(sender)) continue;
                //遍历找到对应的列
                var fdname = funsself.GetControlName(item);
                if (!fdname) continue;
                for (var i = 0; i < sender.columns.length; i++) {
                    var col = sender.columns[i];
                    if (col.type == "comboboxcolumn" && col.editor && col.field == fdname) {
                        col.editor.data = columncomboboxStep[item].Data;
                        continue;
                    }
                }
            }
        }
    }

    return wizardself = {

        //初始化操作
        //Init:function(p){

        //},
        Init: function (params) {
            mini.parse();
            //绑定按钮事件
            mini.get("btn-ok").on("click", OnOK);
            mini.get("btn-next").on("click", OnNext);
            mini.get("btn-prev").on("click", OnPrev);
            mini.get("btn-cancel").on("click", OnCancel);
            if (mini.get("btn-search")) mini.get("btn-search").on("click", OnPageChanged);
            if (mini.get("search-value")) mini.get("search-value").on("enter", OnPageChanged);
            mini.get("btn-prev").setVisible(false);
            if (minNo == maxNo)
                mini.get("btn-next").setVisible(false);
            else
                mini.get("btn-ok").setVisible(false);

            if (params && params.wizardid) wizardpars.wizardid = params.wizardid;
            if (params && params.filter) wizardpars.filter = params.filter;
            if (params && params.multi) wizardpars.multi = params.multi;
            if (params && params.isleaf) wizardpars.isleaf = params.isleaf;

            //是否允许多选，指最后一步 是否允许多选            
            //绑定tree，grid的响应事件
            for (var i = minNo; i <= maxNo; i++) {
                var n = "Step" + i;
                var g = mini.get(n);
                if (!g) continue;
                g.setAutoLoad(false);
                g.setUrl("/Form/GetWizardData")
                if (GridIsTree(g) && g.lazyload)
                    g.on("nodeselect", OnTreeNodeSelect); //tree，懒加载 绑定选中行事件
                g.on("beforeload", wizardself.OnBeforeLoad);
                g.on("preload", OnPreLoad);
                g.on("load", wizardself.OnAfterLoad)
                if (i == maxNo) {
                    if (wizardpars.multi != "1") {
                        if (GridIsTree(g))
                            g.on("nodedblclick", OnOK);
                        else
                            g.on("rowdblclick", OnOK);
                    }
                }
                else {
                    if (GridIsTree(g))
                        g.on("nodedblclick", OnNext);
                    else
                        g.on("rowdblclick", OnNext);
                }
                var frame = document.getElementById("StepDiv" + i);
                if (!frame) {
                    id = "Step" + i;
                    frame = mini.get(id);
                    if (frame) frame.setVisible(false);
                }
                else {
                    frame.style.display = "none";
                }
            }
            for (var i = minNo; i <= maxNo; i++) {
                var n = "Step" + i + "_Plus";
                var g_plus = mini.get(n);
                if (!g_plus) continue;
                g_plus.setAutoLoad(false);
                g_plus.setUrl("/Form/GetWizardDataPlus")
                if (GridIsTree(g_plus) && g_plus.lazyload)
                    g_plus.on("nodeselect", OnTreeNodeSelect); //tree，懒加载 绑定选中行事件
                g_plus.on("beforeload", wizardself.OnBeforeLoad);
                g_plus.on("preload", OnPreLoad);
                g_plus.on("load", wizardself.OnAfterLoad)

                if (i == maxNo) {
                    if (GridIsTree(g))
                        g.on("nodedblclick", OnOK);
                    else
                        g.on("rowdblclick", OnOK);
                }
                else {
                    if (GridIsTree(g))
                        g.on("nodedblclick", OnNext);
                    else
                        g.on("rowdblclick", OnNext);
                }
                //g_plus.setVisible(false); //这句导致配置的左右结构向导，右边被隐藏不显示

            }
            InitComboboxData();
            SetStepVisible(wizardpars.stepindex, true);
        },
        LoadStepFirst: function () {
            currentgrid = mini.get("Step0");
            currentgrid_plus = mini.get("Step0_Plus");

            if (currentgrid != undefined)
                currentgrid.reload();
            if (currentgrid_plus != undefined)
                currentgrid_plus.reload();
            if (typeof (minNo) != "undefined") {
                if (minNo == maxNo)
                    setLastMulti();
            }
        },
        FieldChanged: function () {
            var field = mini.get("search-fields").getValue();
            if (property != null) {
                var miniid = "Step" + wizardpars.stepindex;
                var rcurrentgrid = FormFuns.ParseGridAllHeader(miniid);
                var column = null;
                for (var i = 0; i < rcurrentgrid.length; i++) {
                    if (rcurrentgrid[i].field == field) {
                        column = rcurrentgrid[i];
                        break;
                    }
                }
                var data = null;
                if (column && column.type == "comboboxcolumn" && column.editor && column.editor.data) {
                    data = {};
                    data.Data = eval(column.editor.data);
                }
                if (column && column.type == "comboboxcolumn" && data && data != null) {
                    $("#search").html(" <input id=\"search-value\" class=\"mini-combobox\" style=\"width: 150px;\" onenter=\"Select.WizardReload\" />");
                    mini.parse();
                    if (data.ValueField)
                        mini.get("search-value").setValueField(data.ValueField);
                    if (data.TextField)
                        mini.get("search-value").setTextField(data.TextField);
                    mini.get("search-value").setData(data.Data);

                }
                else if (property[field] != undefined && property[field] == "DateTime") {
                    $("#search").html(" <input id=\"search-value\" class=\"mini-datepicker\" format=\"yyyy-MM-dd\"  style=\"width: 150px;\"onenter=\"Select.WizardReload\"  />");
                    mini.parse();
                }
                else {
                    $("#search").html(" <input id=\"search-value\" class=\"mini-textbox\" style=\"width: 150px;\" onenter=\"Select.WizardReload\" />");
                    mini.parse();
                }

            }
        },
        WizardReload: function () {
            OnPageChanged();
        },
        //tree/grid.reload() 的时候触发，填充url参数
        OnBeforeLoad: function (e) {
            var sender = e.sender;    //树控件
            var node = e.node;      //当前节点
            var params = e.params;  //参数对象
            var sprestepnode = "";

            params.wizardid = wizardpars.wizardid || "";
            params.wizardfilter = wizardpars.filter || "";

            params.stepindex = wizardpars.stepindex;
            params.prestep = "";
            params.loadtype = "";
            params.sort = "";
            if (!params.pageIndex) params.pageIndex = 0;
            if (!params.pageSize) params.pageSize = 0;

            if (WizardParams.sort != undefined && WizardParams.sort != "")//配置文件中传进来的排序设置
            {
                params.sort = WizardParams.sort;
            }
            else {
            }
            //排序
            if (params.sortField)
                params.sort = params.sortField + " " + params.sortOrder;
            //只有第一步使用外部传递给向导过滤条件
            if (wizardpars.stepindex != 0) params.wizardfilter = "";
            var swhere = "";
            if (sender._search_btn && sender._search_fields != "" && sender._search_value && sender._search_value != "") {
                var field = mini.get("search-fields").getValue();
                if (property != null) {
                    if (property[field] != undefined && property[field] == "DateTime") {
                        swhere = sender._search_fields + " >='" + sender._search_value + "' and "
                        + sender._search_fields + " <='" + sender._search_value + " 23:59:59.999'";
                    }
                    else if (property[field] != undefined && property[field] != "String")
                        swhere = sender._search_fields + " = '" + sender._search_value + "'";
                    else
                        swhere = sender._search_fields + " like '%" + sender._search_value + "%'";
                }

            }
            if (params.wizardfilter != "") {
                if (swhere != "")
                    swhere = base64decode(params.wizardfilter) + " and " + swhere;
                else
                    swhere = base64decode(params.wizardfilter)
            }
            var o = { swhere: swhere };
            if (sourcedata != null && sourcedata != undefined)
                FormFuns.ReplaceWhere(o, sourcedata.config.joindata);
            params.wizardfilter = o.swhere;
            //上一步选中的节点
            if (sender.prestepnode)
                params.prestep = mini.encode(sender.prestepnode);

            if (GridIsTree(sender)) {
                if (sender.lazyload) {
                    params.parentid = node[sender.idField] == undefined ? "" : node[sender.idField];
                    params.loadtype = "lazy";
                }
                else {
                    //treegrid，不是懒加载，也不是分页
                    if (sender.type == "treegrid") {
                        if (sender.showPager) {
                            if (!sender.data || sender.data.length == 0)
                                params.pageIndex = 0;
                        }
                        else
                            params.pageSize = 0;
                    }
                }
            }
            else {
                if (sender.showPager) {
                    if (!sender.data || sender.data.length == 0)
                        params.pageIndex = 0;
                }
                else
                    params.pageSize = 0;
            }
            //第一步时，加上EventWizardWhere传入的条件
            if (wizardpars.stepindex == 0 && defaultWhere != undefined && defaultWhere != "") {
                if (params.wizardfilter == "")
                    params.wizardfilter = defaultWhere;
                else
                    params.wizardfilter += " and " + defaultWhere;
            }
            wizardself.EventBeforeLoadData(e, sourcedata);
            if (!params.parentid) params.parentid = "";
            if (params.wizardfilter && params.wizardfilter != "")
                params.wizardfilter = base64encode(params.wizardfilter);
        },
        //tree,grid 请求ajax之前 触发
        EventBeforeLoadData: function (e) { },
        //数据赋值给 tree/grid 之后发生
        OnAfterLoad: function (e) { wizardself.EventAfterSetData(e) },
        //数据赋值给 tree/grid 之后发生
        EventAfterSetData: function (e) { },
        //返回选中的数据
        GetData: function () {
            var selgrid = currentgrid_plus == undefined ? currentgrid : currentgrid_plus;
            if (selgrid.type == "tree" || selgrid.type == "treegrid") {
                //tree
                if (selgrid.showCheckBox) {
                    var tlist = selgrid.getCheckedNodes();
                    //treegrid 的时候，如果有 checkcolumn列，需要使用grid的方式获取选中的内容
                    if (tlist.length == 0) {
                        var chkcol = selgrid.getColumn("checkcolumn");
                        if (chkcol && chkcol.type == "checkcolumn")
                            tlist = selgrid.getSelecteds();
                    }
                    if (wizardpars != undefined && wizardpars.isleaf == "1") {
                        var result = new Array();
                        for (var i = 0; i < tlist.length; i++) {
                            var item = tlist[i];
                            if (selgrid.isLeaf(item) == true)
                                result.push(item);
                        }
                        return result;
                    }
                    return tlist;
                }
                else {
                    var result = null;
                    var node = selgrid.getSelectedNode();
                    if (node) {
                        result = new Array();
                        result.push(node);
                    }
                    return result;
                }
            }
            else {
                //grid
                if (selgrid.multiSelect) {
                    return selgrid.getSelecteds();
                }
                else if (selgrid.checkRecursive || (typeof (selgrid.getShowCheckBox) != "undefined" && selgrid.getShowCheckBox())) {
                    return selgrid.getCheckedNodes();
                }
                else {
                    var result = null;
                    var node = selgrid.getSelected();
                    if (node) {
                        result = new Array();
                        result.push(node);
                    }
                    return result;
                }
            }
        },
        //接收调用表单的formconfig
        SetSourceData: function (d) {
            sourcedata = d;
        },
        //EventWizardWhere传入的参数
        SetWhere: function (where) {
            defaultWhere = where;
        },
        GetSourceData: function (data) {

            return sourcedata;
        },
        GetWhere: function () {

            return defaultWhere;
        }
    }
}();

