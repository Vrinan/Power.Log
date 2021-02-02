var Select = function () {
    var gridleft = null;
    var gridright = null;
    var selectcode = "";
    var leafflag = "0"; //=1必须选择叶子节点
    var filters = null; //调用选择窗体传递过来的参数
    var textfieldList = new Object();
    var parentfieldList = new Object();
    //将数据包赋值给grid
    var SetGridData = function (grid, datatype, data) {
        if (GridIsTree(grid)) {
            if (datatype == "tree") {
                if (textfieldList[grid.id] == undefined)
                    textfieldList[grid.id] = grid.textField;
                if (parentfieldList[grid.id] == undefined)
                    parentfieldList[grid.id] = grid.parentField;
                grid.setParentField("pId");
                grid.setTextField("text");
                //grid.setData(data);
            }
            else {
                if (textfieldList[grid.id] == undefined)
                    textfieldList[grid.id] = grid.textField;
                else
                    grid.setTextField(textfieldList[grid.id]);
                if (parentfieldList[grid.id] == undefined)
                    parentfieldList[grid.id] = grid.parentField;
                else
                    grid.setParentField(parentfieldList[grid.id]);

                //grid.loadList(data, grid.idField, grid.parentField);
            }
            grid.loadList(data, grid.idField, grid.parentField);
        }
        else
            grid.setData(data);
    }
    //选择左边grid/tree节点时，提取右边grid/tree的数据
    var OnGridLeftSelect = function (e) {
        //if (e.node._powerdata)
        //    SetGridData(gridright, e.node._powerdata);
        //else
        LoadGridRight(e.node);
    }

    function search() {
        var key = mini.get("key").getValue();
        //grid.load({ key: key });
    }
    function onKeyEnter(e) {
        search();
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
        if (GridIsTree(gridright) == true && gridright.showCheckBox == false && leafflag != undefined && leafflag == "1") {
            var node = gridright.getSelectedNode();
            if (gridright.isLeaf(node) == false) {
                alert("请选择叶子节点.");
                return;
            }
        }
        CloseWindow("ok");
    }
    var OnCancel = function () {
        CloseWindow("cancel");
    }
    //判断是 grid or tree
    var GridIsTree = function (o) {
        return o._dataSource.type == "datatree";
    }
    //加载右边 grid/tree 数据
    var LoadGridRight = function (pnode) {
        var text = "";
        if (pnode) {
            var data = mini.clone(pnode);
            delete (data._powerdata);
            text = mini.encode(data);
        }
        $.ajax({
            url: "/Form/GetSelectData",
            data: { selectCode: selectcode, leftRight: "Right", parentNode: text, filter: filters },
            cache: false,
            success: function (text) {
                var tmpData = mini.decode(text);
                if (tmpData.success == false) {
                    Power.ui.alert(tmpData.message);
                    return;
                }
                var d = mini.decode(tmpData.data.data);
                SetGridData(gridright, tmpData.data.datatype, d);
            }
        });
    }
    //加载左边 grid/tree 数据
    var LoadGridLeft = function () {
        $.ajax({
            url: "/Form/GetSelectData",
            data: { selectCode: selectcode, leftRight: "Left", parentNode: "", filter: filters },
            cache: false,
            success: function (text) {
                var tmpData = mini.decode(text);
                if (tmpData.success == false) {
                    Power.ui.alert(tmpData.message);
                    return;
                }
                var d = mini.decode(tmpData.data.data);
                SetGridData(gridleft, tmpData.data.datatype, d);
                //加载根节点对应的右边数据
                if (GridIsTree(gridleft)) {
                    var pnode = gridleft.getRootNode();
                    if (pnode && pnode.children.length > 0)
                        LoadGridRight(pnode.children[0]);
                }
            }
        });
    }

    return {
        //初始化操作
        Init: function (code, params) {
            mini.parse();
            gridleft = mini.get("gridleft");
            gridright = mini.get("gridright");
            //params = { "multi": "1", "child": "1" };
            selectcode = code;
            //绑定按钮事件
            var btnok = mini.get("btn-ok");
            btnok.on("click", OnOK);
            var btncancel = mini.get("btn-cancel");
            btncancel.on("click", OnCancel);

            var objPara = mini.decode(params);
            if (objPara.filter != undefined)
                filters = objPara.filter;
            leafflag = objPara.leaf;
            //设置允许多选
            if ((objPara) && (objPara.multi)) {
                var bmulti = objPara.multi == "1";

                if (GridIsTree(gridright))
                    gridright.showCheckBox = bmulti;
                else {
                    gridright.multiSelect = bmulti;
                    if (bmulti)
                        gridright.showColumn("checkcolumn");
                    else
                        gridright.hideColumn("checkcolumn");
                }
            }
            //加载数据
            if (gridleft != undefined) {
                gridleft.on("nodeselect", OnGridLeftSelect);
                LoadGridLeft();
            }
            else {
                LoadGridRight(null);
            }
        },
        //返回选中的数据
        GetData: function () {
            if (GridIsTree(gridright)) {
                //tree
                if (gridright.showCheckBox) {
                    var tlist = gridright.getCheckedNodes(true);
                    if (leafflag != undefined && leafflag == "1") {
                        var result = new Array();
                        for (var i = 0; i < tlist.length; i++) {
                            var item = tlist[i];
                            if (gridright.isLeaf(item) == true)
                                result.push(item);
                        }
                        return result;
                    }
                    return tlist;
                }
                else {
                    var result = new Array();
                    var node = gridright.getSelectedNode();
                    result.push(node);
                    return result;
                }
            }
            else {
                //grid
                if (gridright.multiSelect) {
                    return gridright.getSelecteds();
                }
                else {
                    var result = new Array();
                    var node = gridright.getSelected();
                    result.push(node);
                    return result;
                }
            }
        }
    }
}();

