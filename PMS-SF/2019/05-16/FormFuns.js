﻿
var fileImportKeyWord = "";
function _copyexcelstringtorows(text) {
    var lines = text.split('\n');
    var header = lines[0].split('\t');
    var idx = 0, row = {}, rows = [], heap = [];
    for (var i = 1; i < lines.length; i++) {
        var cols = lines[i].split('\t');
        for (var j = 0; j < cols.length; j++) {
            var s = cols[j];
            var flag = '';
            if (s == '"') {
                flag = (heap.length == 0) ? 'start' : 'end';
            }
            else {
                if (s.substr(0, 1) == '"')
                    flag = 'start';
                else if (s.substr(s.length - 1, 1) == '"')
                    flag = 'end';
            }
            if (flag == 'start') {
                if (heap.length > 0) { //栈中有数据,需要出栈
                    for (var k = 0; k < heap.length; k++) {
                        row[header[idx]] = heap[k];
                        idx = parseInt(idx) + 1;
                        if (idx == header.length) { //新的一行数据
                            idx = 0;
                            rows.push(row);
                            row = {};
                        }
                    }
                    heap = []; //清空
                }
                heap.push(s);//头节点,始终压栈
                continue;
            }
            else if (flag == 'end') {
                if (heap.length > 0) {//拼接折行数据
                    var rs = "";
                    for (var k = 0; k < heap.length; k++) {
                        rs += heap[k] + "\n";
                    }
                    heap = [];//清空
                    s = rs.substr(1, rs.length - 1) + s.substr(0, s.length - 1);//去掉"                            
                }
            }
            else {
                if (heap.length > 0) {//栈不为空,压栈
                    heap.push(s);
                    continue;
                }
            }
            row[header[idx]] = s;
            idx = parseInt(idx) + 1;
            if (idx == header.length) { //新的一行数据
                idx = 0;
                rows.push(row);
                row = {};
            }
        }
    }
    if (heap.length > 0) {//栈中还有数据,出栈
        for (var k = 0; k < heap.length; k++) {
            row[header[idx]] = heap[k];
            idx = parseInt(idx) + 1;
            if (idx == header.length) { //新的一行数据
                idx = 0;
                rows.push(row);
                row = {};
            }
        }
    }
    return { header: header, rows: rows };
}

function dealwithData(event) {
    var ss = $("#textArea");
    var data = _copyexcelstringtorows(ss.val());
    var grid = mini.get(fileImportKeyWord);
    var isgrid = funsself.IsMiniGrid(grid);
    var istree = funsself.IsMiniTree(grid);
    var fields = [];
    //循环excel中的第一行，在循环页面中的所有表头匹配
    for (var i = 0; i < data.header.length; i++) {
        var header = data.header[i];
        allheaderdata(grid.columns, header, fields);
    }
    //循环内容行,Excel复制3行，length会等于4，所以此处减去一行
    for (var i = 0; i < data.rows.length; i++) {
        var row = data.rows[i];
        var newRow = funsself.OnGridTreeAdd(fileImportKeyWord, i);
        //循环行中的每一列，并对应写成名称：值
        for (var j = 0; j < fields.length; j++) {
            var field = fields[j];
            if (row[field.header] == null || row[field.header] == "")
                continue;
            newRow[field.field] = row[field.header];
        }
        if (isgrid)
            grid.updateRow(newRow);
        if (istree)
            grid.updateNode(newRow);
    }
    ss.blur();
    $("#textArea").remove();
}
function allheaderdata(columns, header, fields) {
    for (var i = 0; i < columns.length; i++) {
        var col = columns[i];
        if (col.columns && col.columns.length > 0)
            allheaderdata(col.columns, header, fields);
        if ($.trim(col.header) == $.trim(header)) {
            fields.push({ header: header, field: col.field });
            break;
        }
    }
}
function cellkeydown(event, miniid) {

    var cell = mini.get(miniid).getCurrentCell()
    fileImportKeyWord = miniid;

    if (mini.get(miniid).isEditingCell(cell) == null && event.ctrlKey && event.keyCode == 86) {
        //权限，如果AddForm或者Add或者向导按钮被禁用，则无复制权限
        var addForm = mini.get(miniid + ".AddForm");
        if (addForm && !addForm.enabled)
            return;
        var add = mini.get(miniid + ".Add");
        if (add && !add.enabled)
            return;
        var wizard = null;
        for (var i = 0; i < 10; i++) {
            wizard = mini.get(miniid + ".Add" + i);
            if (wizard) {
                if (!wizard.enabled)
                    return;
                break;
            }
        }
        if (!add && !addForm && !wizard)
            return;
        $("body").append(" <textarea id=\"textArea\" style=\"width: 0px; height: 0px; top: -50px; position: absolute;\"> </textarea>");
        var ss = $("#textArea");
        ss.focus();
        ss.select();
        // 等50毫秒，keyPress事件发生了再去处理数据 
        setTimeout("dealwithData()", 500);
    }
}
var FormFuns = function () {
    //树新增节点后，刷新树当前选中节点的子节点
    var doAfterAddReLoadTreeNode = function (o) {
        if (!o) return;
        //新增操作结束后，刷新grid 或 tree 中的数据
        if (funsself.IsMiniTree(o)) {
            var n = o.getSelectedNode();
            if (n) {
                if (n.children) delete n.children;
                o.loadNode(n);
                //重新取当前记录的数据
                var config = funsself.GetConfig(o.id);
                if (config) {
                    var p = { KeyWord: config.KeyWord, KeyWordType: config.KeyWordType, index: "0", size: "1" };
                    p.swhere = o.idField + "='" + n[o.idField] + "'";
                    funsself.GridPageLoad(p, function (rlt) {
                        if (!rlt.success) return;
                        var rs = mini.decode(rlt.data.value);
                        if (rs && rs.length > 0) {
                            o.updateNode(n, rs[0]);
                            o.acceptRecord(n);
                        }
                    });
                }
            }
            else
                o.reload();
        }
        if (funsself.IsMiniGrid(o)) {
            o.reload();
        }
    }

    //必填错误信息转换字符串
    var RequestTextToString = function (ar) {
        if (!ar || ar.length == 0) return "";
        var s = "";
        for (var i = 0; i < ar.length; i++) {
            if (ar[i].length == 0 || ar[i] == "不能为空")
                continue;
            s += ar[i] + ";  ";
        }
        return s;
    }
    return funsself = {
        onPageChanged: function (e) {
            var id = funsself.GetGridTreeName(e.sender.id);
            var o = mini.get(id);
            if (o) o.reload();
        },
        onheadercellclick: function (e) {
            if (e.column.type != "indexcolumn" && e.column.type != "checkcolumn") {
                if (!e.column.allowSort) {
                    Power.ui.warning(app_global_ResouceId["column_not_sort"]);//本列不允许排序
                    return;
                }
                var config = funsself.GetConfig(e.source.id, null);
                if (!config) {
                    Power.ui.warning(app_global_ResouceId["g_through"] + e.source.id + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                    return;
                }
                if (e.source.sortField) {
                    //如果点击2个列中间的线的时候，e.source.sortField可能会是  field asc，所以此处要先去掉asc 和desc
                    e.source.sortField = e.source.sortField.replace(' asc', '').replace(' desc', '');
                    config.sort = e.source.sortField + " " + (e.source.sortOrder == "asc" ? "asc" : "desc");
                }
                else
                    config.sort = e.column.field + " asc"; //第一次点击时是升序，但是miniui没有记录
                var sender = mini.get(e.source.id);
                sender.reload();
            }
        },
        //解析按钮名称，返回对应的 form/grid/tree名称 eg: BizArea.Add 返回 BizArea
        GetGridTreeName: function (name) {
            var arr = name.split(".");
            var rlt = arr[0];
            for (var i = 1; i < arr.length - 1; i++)
                rlt = rlt + "." + arr[i];
            return rlt;
        },
        //解析按钮名称，返回除 keyword 外的 控件名称 eg: BizArea.Add 返回 Add
        GetControlName: function (name) {
            var arr = name.split(".");
            if (arr.length == 0)
                return name;
            return arr[arr.length - 1];
        },
        //根据id返回 mini-form 或 mini控件
        GetMiniFormGrid: function (miniid) {
            if (!miniid || miniid.length == 0)
                return null;

            var m = document.getElementById(miniid);
            if (m == undefined) return null;

            if (m && (m.className == "form" || m.className.indexOf("form ") > -1 || m.className.indexOf(" form") > -1))
                return new mini.Form("#" + miniid);
            else
                return mini.get(miniid);
        },
        OnGridTreeAdd: function (gridid, index) {
            var grid = mini.get(gridid);
            if (!grid) {
                Power.ui.warning(app_global_ResouceId["g_through"] + gridid + app_global_ResouceId["not_fined_control"]);//通过xx找不到控件
                return;
            }
            if (funsself.IsMiniGrid(grid)) {
                //grid默认添加到最后一行
                index = index || grid.data.length;
            }
            if (funsself.IsMiniTree(grid)) {
                //tree默认添加到本层最后一行
                var length = 0;
                if (grid.getSelected() != undefined && grid.getSelected().children != undefined) {
                    length = grid.getSelected().children.length;
                }
                index = index || length;
            }
            var fncopyfd = function (dest, source) {
                for (var fd in source) {
                    if (typeof (fd) == "function") continue;
                    dest[fd] = source[fd];
                }
            }
            //1.创建新对象
            var newRow = {};
            newRow[grid.idField] = CreateGUID();
            //2.新增默认值处理
            var ddata = funsself.GetNewDefaulValues(gridid);
            if (ddata)
                fncopyfd(newRow, ddata);

            //3.处理新增前外部扩展事件，也可能有默认值
            ddata = {};
            funsself.EventBeforeAddRow(grid, ddata);
            if (grid && grid.canNext == false)
                return;
            if (ddata)
                fncopyfd(newRow, ddata);

            var config = funsself.GetConfig(gridid);
            config.currow = newRow;
            if (funsself.IsMiniGrid(grid)) {
                grid.addRow(newRow, index);
                grid.clearSelect();//先清除再选择新增行
                grid.select(newRow, false);
                grid.scrollIntoView(newRow);
                funsself.EventAfterAddRow(grid, newRow);
                return newRow;
            }
            //如果是树，则给parentid赋值为当前选中行，未选中则不管
            if (funsself.IsMiniTree(grid)) {
                //处理自动编号字段
                if (funsself.GetConfig(gridid).codefield != null && funsself.GetConfig(gridid).codefield != "") {
                    var codefield = funsself.GetConfig(gridid).codefield;
                    //如果有编号字段
                    var childs = [];//所有同级节点
                    if (grid.getSelected())
                        childs = grid.getChildNodes(grid.getSelected());//如果有选中行，即为新增选中行的子节点，要获取子节点的编号值
                    else
                        childs = grid.getChildNodes(grid.getRootNode());//如果没有选中行，即为新增根节点，要获取根节点的最大值
                    //循环获取最大值
                    var max = 0;
                    var length = 0;
                    var oldc = "";
                    for (var i = 0; i < childs.length; i++) {
                        var child = childs[i];//获取一行
                        var code = child[codefield];//获取编号列的值
                        if (code == undefined)
                            continue;
                        var reg = /\d+$/;
                        var num = code.match(reg);//正则获取最后一个数字字符串，如A001.B002.C003则此处获取的是["003"]

                        if (num != null && num.length == 1 && parseFloat(num[0]) > max) {
                            max = parseFloat(num[0]);//如果当前字符串转为float大于最大值的话，则最大值置为次float
                            length = num[0].length;//记录当前编号的长度，后面还需要再把数字转为对应长度的字符
                            oldc = code;//将最大值对应的整个编号值赋值出去，后面需要截取转变成新的编号
                        }
                    }
                    if (max > 0) {
                        //大于0才认为是有为数字的编号，否则不处理
                        max++;
                        var c = (Array(length).join('0') + max).slice(-length);//将数字转为对应的字符，如将4转为004;
                        if (max.toString().length > length)
                            c = max.toString();//如果max的长度大于前一个字符的长度，就直接用max，即99-100而不是99-00
                        var newc = oldc.substring(0, oldc.length - length) + c;//将旧的编号去掉最后的数字，在加上新的数字
                        //将新编号复制到默认值中
                        newRow[codefield] = newc;
                    }
                }
                if (grid.getSelected()) {
                    newRow[grid.parentField] = grid.getSelected()[grid.idField];
                    grid.addNode(newRow, index, grid.getSelected());
                    // grid.clearSelect();//先清除再选择新增行
                    // grid.selectNode(newRow);
                }
                else {
                    grid.addNode(newRow, index, null);
                    grid.clearSelect();//先清除再选择新增行
                    grid.select(newRow);
                }
                grid.scrollIntoView(newRow);
                funsself.EventAfterAddRow(grid, newRow);
                return newRow;
            }
        },
        EventAfterAddRow: function (e, row) { },
        EventBeforeAddRow: function (e, defaultdata) { },
        EventGetNewDefaultValues: function (e) { return e; },
        //判断对象是 mini-form
        IsMiniForm: function (e) {
            return e != undefined && (e.el.className == "form" || e.el.className.indexOf("form ") > -1 || e.el.className.indexOf(" form") > -1);
        },
        //判断对象是 mini-datagrid
        IsMiniGrid: function (e) {
            return e != undefined && e.type == "datagrid";
        },
        //判断对象是 mini-tree 或 mini-treegrid, tree/treegrid的操作方式一致
        IsMiniTree: function (e) {
            return e != undefined && (e.type == "tree" || e.type == "treegrid");
        },
        //判断对象是 mini-datagrid 或 mini-tree 或 mini-treegrid,
        IsMiniGridTree: function (e) {
            return e != undefined && (e.type == "tree" || e.type == "treegrid" || e.type == "datagrid");
        },
        IsRowCanMove: function (grid, row, cfg) {
            if (row == undefined) {
                Power.ui.warning(app_global_ResouceId["select_move_row"]);//请选中需要移动的行
                return false;
            }
            if (cfg.sequfield == undefined || cfg.sequfield.length == 0) //没有序号字段，上下移动没有意义
            {
                Power.ui.warning(app_global_ResouceId["not_defined_sort"]);//"没有定义序号字段"
                return false;
            }
            if (!funsself.IsRowSequOK(row, cfg.sequfield, grid))
                return false;
            return true;
        },
        IsRowSequOK: function (row, sequfield, grid) {
            if (!row[sequfield]) {
                if (row._state == "added") {
                    Power.ui.warning("新增数据不允许移动,请先保存数据再移动.");
                    return false;
                }
                else {
                    var cfg = funsself.GetConfig(grid.id);
                    var keywprd = cfg.KeyWord;
                    jQuery.ajax({
                        url: "/Form/FindSequ",
                        data: { KeyWord: keywprd, KeyValue: row[grid.idField], SequField: sequfield },
                        async: false,
                        success: function (text) {

                            var tmpdata = mini.decode(text);
                            if (tmpdata.data.value) {
                                if (funsself.IsMiniGrid(grid)) {
                                    var x = {};
                                    x[sequfield] = tmpdata.data.value
                                    grid.updateRow(row, x);
                                    return true;
                                }
                                else if (funsself.IsMiniTree(grid)) {
                                    var x = {};
                                    x[sequfield] = tmpdata.data.value
                                    grid.updateNode(row, x);
                                    return true;
                                }
                                return false;
                            }
                            else {
                                Power.ui.warning("序号字段值为空,请先保存数据再移动.");
                                return false;
                            }
                        }
                    });

                }
            }
            return true;
        },
        //grid/tree点上移
        RowMoveUp: function (miniid) {
            var tree = mini.get(miniid);
            var row = tree.getSelected();
            var cfg = funsself.GetConfig(miniid);
            if (!funsself.IsRowCanMove(tree, row, cfg)) return false;
            if (funsself.IsMiniGrid(tree)) {
                var index = tree.data.indexOf(row);
                if (index == 0) {
                    Power.ui.warning(app_global_ResouceId["not_up_first_row"]);//"第一行不能再上移"
                    return false;
                }
                var cnode = tree.data[index - 1];
                if (!funsself.IsRowSequOK(cnode, cfg.sequfield, tree)) return false;
                var upd1 = {}; upd2 = {};
                upd1[cfg.sequfield] = row[cfg.sequfield];
                upd2[cfg.sequfield] = cnode[cfg.sequfield];
                tree.updateRow(cnode, upd1);
                tree.updateRow(row, upd2);
                var arr = [];
                arr.push(row);
                tree.moveUp(arr);
            }
            if (funsself.IsMiniTree(tree)) {
                var pnode = tree.getParentNode(row);
                if (!pnode) {
                    Power.ui.warning(app_global_ResouceId["tree_excaption"]);//"树形结构异常"
                    return false;
                }
                var brother = tree.getChildNodes(pnode);
                var index = brother.indexOf(row);
                if (index == 0) {
                    Power.ui.warning(app_global_ResouceId["not_up_first_row"]);//"第一行不能再上移"
                    return false;
                }
                //交换序号、长代码
                var cnode = brother[index - 1];
                if (!funsself.IsRowSequOK(cnode, cfg.sequfield, tree)) return false;
                var upd1 = {}, upd2 = {};
                upd1[cfg.sequfield] = row[cfg.sequfield];
                upd2[cfg.sequfield] = cnode[cfg.sequfield];
                if (cfg.longcodefield != undefined) {
                    upd1[cfg.longcodefield] = row[cfg.longcodefield];
                    upd2[cfg.longcodefield] = cnode[cfg.longcodefield];
                }
                tree.updateNode(cnode, upd1);
                tree.updateNode(row, upd2);
                tree.moveNode(row, cnode, "before");
            }
            return true;
        },
        //grid/tree点下移
        RowMoveDown: function (miniid) {
            var tree = mini.get(miniid);
            var row = tree.getSelected();
            var cfg = funsself.GetConfig(miniid);
            if (!funsself.IsRowCanMove(tree, row, cfg)) return false;
            if (funsself.IsMiniGrid(tree)) { //grid处理
                var index = tree.data.indexOf(row);
                if (index == tree.data.length - 1) {
                    Power.ui.warning(app_global_ResouceId["not_down_last_row"]);//最后一行不能再下移
                    return false;
                }
                var cnode = tree.data[index + 1];
                if (!funsself.IsRowSequOK(cnode, cfg.sequfield, tree)) return false;
                var upd1 = {}; upd2 = {};
                upd1[cfg.sequfield] = row[cfg.sequfield];
                upd2[cfg.sequfield] = cnode[cfg.sequfield];
                tree.updateRow(cnode, upd1);
                tree.updateRow(row, upd2);
                var arr = [];
                arr.push(row);
                tree.moveDown(arr);
            }
            if (funsself.IsMiniTree(tree)) { //tree处理
                var pnode = tree.getParentNode(row);
                if (!pnode) //没有父节点
                {
                    Power.ui.warning(app_global_ResouceId["tree_excaption"]);//"树形结构异常"
                    return false;
                }
                var brother = tree.getChildNodes(pnode);
                var index = brother.indexOf(row);
                if (index == brother.length - 1) //已经是最后一个节点
                {
                    Power.ui.warning(app_global_ResouceId["not_down_last_row"]);//最后一行不能再下移
                    return false;
                }
                //交换序号、长代码
                var cnode = brother[index + 1];
                if (!funsself.IsRowSequOK(cnode, cfg.sequfield, tree)) return false;
                var upd1 = {}; upd2 = {};
                upd1[cfg.sequfield] = row[cfg.sequfield];
                upd2[cfg.sequfield] = cnode[cfg.sequfield];
                if (cfg.longcodefield) {
                    upd1[cfg.longcodefield] = row[cfg.longcodefield];
                    upd2[cfg.longcodefield] = cnode[cfg.longcodefield];
                }
                tree.updateRow(cnode, upd1);
                tree.updateRow(row, upd2);
                tree.moveNode(row, cnode, "after");
            }
            return true;
        },
        //树节点左移
        RowMoveLeft: function (miniid) {
            var tree = mini.get(miniid);
            if (funsself.IsMiniTree(tree) == false) {
                Power.ui.warning(miniid + app_global_ResouceId["not_tree_left"]);//"不是一棵树,不能左移"
                return false;
            }
            var row = tree.getSelected();
            if (row == undefined) {
                Power.ui.warning(app_global_ResouceId["select_move_row"]);//请选中需要移动的行
                return false;
            }
            if (tree.getLevel(row) == 0) {
                Power.ui.warning(app_global_ResouceId["root_not_left"]);//"根节点不能再左移"
                return false;
            }
            var pnode = tree.getParentNode(row);
            if (!pnode) {
                Power.ui.warning(app_global_ResouceId["not_find_parent_node_not_left"]);//"未找到父节点,不能左移"
                return false;
            }
            var ppnode = tree.getParentNode(pnode);
            if (!ppnode) {
                Power.ui.warning(app_global_ResouceId["not_find_moved_parent_node_not_left"]);//"未找到移动后的父节点,不能左移 "
                return false;
            }
            //有长代码字段，且长代码字段值为空，是新增不允许左右移动, 维护长代码
            var cfg = funsself.GetConfig(miniid);
            if (cfg && cfg.longcodefield && cfg.sequfield) {
                var lfd = cfg.longcodefield;
                var sfd = cfg.sequfield;
                if (!funsself.IsRowSequOK(row, sfd, tree)) return false;
                var upd = {};
                upd[lfd] = (ppnode._level == -1) ? row[sfd] : (ppnode[lfd] + "." + row[sfd]);
                tree.updateNode(row, upd);
            }
            tree.moveNode(row, ppnode, "add");
            return true;
        },
        //树节点右移
        RowMoveRight: function (miniid) {
            var tree = mini.get(miniid);
            if (funsself.IsMiniTree(tree) == false) {
                Power.ui.warning(miniid + app_global_ResouceId["not_tree_right"]);//"不是一棵树,不能右移"
                return false;
            }
            var row = tree.getSelected();
            if (row == undefined) {
                Power.ui.warning(app_global_ResouceId["select_move_row"]);//请选中需要移动的行
                return false;
            }
            var pnode = tree.getParentNode(row);
            if (!pnode) {
                Power.ui.warning(app_global_ResouceId["tree_excaption"]);//"树形结构异常"
                return false;
            }
            var brother = tree.getChildNodes(pnode);
            var idfd = tree.idField;
            for (var i = 0; i < brother.length; i++) {
                if (brother[i][idfd] == row[idfd] && i > 0) {
                    var pnode = brother[i - 1];
                    //有长代码字段，且长代码字段值为空，是新增不允许左右移动, 维护长代码
                    var cfg = funsself.GetConfig(miniid);
                    if (cfg && cfg.longcodefield && cfg.sequfield) {
                        var lfd = cfg.longcodefield;
                        var sfd = cfg.sequfield;
                        if (!funsself.IsRowSequOK(pnode, lfd, tree)) return false;
                        if (!funsself.IsRowSequOK(row, sfd, tree)) return false;
                        var upd = {};
                        upd[lfd] = pnode[cfg.longcodefield] + "." + row[cfg.sequfield];
                        tree.updateNode(row, upd);
                    }

                    tree.moveNode(row, pnode, "add");
                    return true;
                }
            }
            Power.ui.warning(app_global_ResouceId["not_rigth_last_node"]);//"末级节点或当前层级第一个节点不能右移"
            return false;
        },
        //设置form可编辑属性
        SetFormEnabled: function (formid, bedit) {
            var frm = funsself.GetMiniFormGrid(formid);
            //grid
            if (FormFuns.IsMiniGrid(frm)) {
                var columns = [];
                funsself.GetTreeGridAllHeaders(frm.columns, columns);
                for (var i = 0; i < columns.length; i++) {
                    var col = columns[i];
                    col.readOnly = (bedit == false);
                }
                return;
            }
            //tree
            if (FormFuns.IsMiniTree(frm)) {
                frm.setReadOnly(bedit == false);
                return;
            }
            //form
            if (FormFuns.IsMiniForm(frm)) {
                var fields = frm.getFields();
                for (var j = 0; j < fields.length; j++) {
                    var c = fields[j];
                    if (c.setReadOnly) c.setReadOnly(bedit == false);     //只读
                    if (c.setIsValid) c.setIsValid(bedit == false);      //去除错误提示
                }
            }
        },
        //查找grid/tree中是否已经存在重复值，弹出选择窗体新增行时判断使用 fields={"ToField":"SelectFromField"}
        IsDataExists: function (datalist, data, fields) {
            if (datalist == undefined || datalist.length == 0 || data == undefined || fields == undefined)
                return false;
            var bExistFlag = false;

            //遍历本地记录，查找distinct字段
            for (var j = 0; j < datalist.length; j++) {
                bExistFlag = true;
                var currow = datalist[j];

                for (var tofd in fields) {
                    if (typeof (tofd) == "function") continue;
                    if (currow[tofd] != data[fields[tofd]]) {
                        //mpqin ！= 表示不存在，不需要该提示
                        bExistFlag = false;
                        break;
                    }
                }
                if (bExistFlag == true) break;
                if (currow.children && currow.children.length > 0) {
                    bExistFlag = funsself.IsDataExists(currow.children, data, fields);
                    if (bExistFlag == true) break;
                }

            }
            //已经存在唯一值，跳过该条选择的记录
            return bExistFlag;
        },
        //从一行记录复制指定字段到另一行数据，弹出选择窗体选择内容回填时使用 fields={"ToField":"SelectFromField"}
        CopyFieldValue: function (rowto, rowfrom, fields) {
            if (rowto == undefined || rowfrom == undefined || fields == undefined)
                return;
            fields = mini.decode(fields);
            for (var tofd in fields) {
                if (typeof (fields[tofd]) == "function") continue;
                rowto[tofd] = rowfrom[fields[tofd]];
            }
        },
        GetUpdateValues: function (data, fields) {
            var result = {};
            for (var tofd in fields) {
                if (typeof (fields[tofd]) == "function") continue;
                result[tofd] = data[fields[tofd]];
            }
            return result;
        },
        //form config 中 filter 转换成 where 条件
        FilterToSWhere: function (filter) {
            var result = "";
            if (!filter) return result;
            for (var fd in filter) {
                if (typeof (fd) == "function")
                    continue;
                result = result + " and " + fd + "='" + filter[fd] + "'";
            }
            return result;
        },
        //从formconfig中获取config节点
        GetConfig: function (miniid, config) {
            if (!config)
                config = formconfig.config.joindata;
            if (config.miniid == miniid)
                return config;

            var result = null;
            if (!config.children || config.children.length == 0)
                return result;

            for (var i = 0; i < config.children.length; i++) {
                result = funsself.GetConfig(miniid, config.children[i]);
                if (result)
                    return result;
            }
            return result;
        },
        //从formconfig中获取所有Config形成List返回
        ConfigToList: function (config) {
            if (!config)
                config = formconfig.config.joindata;
            var rlt = new Array();
            rlt.push(config);

            //子表
            if (config.children && config.children.length > 0) {
                for (var i = 0; i < config.children.length; i++) {
                    var c = funsself.ConfigToList(config.children[i]);
                    if (c != undefined && c.length > 0) {
                        for (var j = 0; j < c.length; j++)
                            rlt.push(c[j]);
                    }
                }
            }
            return rlt;
        },

        //从formconfig中获取 父级节点的config
        GetParentConfig: function (miniid, config) {
            if (!config)
                config = formconfig.config.joindata;

            var result = null;
            if (!config.children || config.children.length == 0)
                return result;

            for (var i = 0; i < config.children.length; i++) {
                var c = config.children[i];
                if (c.miniid == miniid)
                    return config;
                result = funsself.GetParentConfig(miniid, c);
                if (result)
                    return result;
            }
            return result;
        },
        //html初始化时，设置combobox的下拉内容
        InitComboboxData: function () {
            //form/init中获取 comboboxdata
            if (typeof (comboboxdata) == "undefined" || comboboxdata == undefined) return;
            for (var item in comboboxdata) {
                if (typeof (item) == "function") continue;
                var cmbdata = comboboxdata[item];
                var cmb = mini.get(item);
                if (cmb) {
                    switch (cmb.type) {
                        case "combobox":
                        case "checkboxlist":
                        case "radiobuttonlist":
                            cmb.setValueField(cmbdata.ValueField);
                            cmb.setTextField(cmbdata.TextField);
                            if (cmbdata.SourceType != "url")
                                cmb.setData(mini.encode(cmbdata.Data));
                            else
                                cmb.load(cmbdata.Data);
                            break;
                        case "treeselect":
                            cmb.setValueField(cmbdata.ValueField);
                            cmb.setParentField(cmbdata.ParentField);
                            cmb.setTextField(cmbdata.TextField);
                            if (cmbdata.SourceType != "url")
                                cmb.loadList(cmbdata.Data, cmbdata.ValueField, cmbdata.ParentField);
                            else
                                cmb.load(cmbdata.Data);
                            break
                        default:
                            //不能通过id直接找到对应的列
                            var senderid = funsself.GetGridTreeName(item);
                            if (!senderid) continue;
                            var sender = funsself.GetMiniFormGrid(senderid);
                            if (!sender || !funsself.IsMiniGridTree(sender)) continue;
                            //遍历找到对应的列
                            var fdname = funsself.GetControlName(item);
                            if (!fdname) continue;
                            for (var i = 0; i < sender.columns.length; i++) {
                                var col = sender.columns[i];
                                if ((col.type == "comboboxcolumn" || col.type == "displayfield") && col.editor && col.field == fdname) {
                                    col.editor.valueField = cmbdata.ValueField;
                                    col.editor.textField = cmbdata.TextField;
                                    if (cmbdata.SourceType != "url")
                                        col.editor.data = cmbdata.Data;
                                    else
                                        col.editor.load(cmbdata.Data);
                                    continue;
                                }
                            }
                            break;
                    }
                }
                else { //不能通过id直接找到对应的列
                    var senderid = funsself.GetGridTreeName(item);
                    if (!senderid) continue;
                    var sender = funsself.GetMiniFormGrid(senderid);
                    if (!sender || !funsself.IsMiniGridTree(sender)) continue;
                    //遍历找到对应的列
                    var fdname = funsself.GetControlName(item);
                    if (!fdname) continue;
                    funsself.GridTreeBindCombobox(sender.columns, fdname, cmbdata);
                }
            }
        },
        GridTreeBindCombobox: function (columns, fdname, cmbdata) {
            for (var i = 0; i < columns.length; i++) {
                var col = columns[i];
                if (col.columns && col.columns.length > 0)
                    funsself.GridTreeBindCombobox(col.columns, fdname, cmbdata);
                if ((col.type == "comboboxcolumn" || col.type == "displayfield") && col.editor && col.field == fdname) {
                    col.editor.valueField = cmbdata.ValueField;
                    col.editor.textField = cmbdata.TextField;
                    //debugger;
                    //if (col.editor.id&&col.editor.id.indexOf('.')>-1) {
                    //    var treegrid = mini.get(col.editor.id.split('.')[0]);
                    //    var ed = treegrid.getCellEditor(col);
                    //    if(typeof(ed.on)=="function")
                    //        ed.on("valuechanged", funsself.ComboboxValueChanged);
                    //} 
                    if (cmbdata.SourceType != "url")
                        col.editor.data = cmbdata.Data;
                    else
                        col.editor.load(cmbdata.Data);
                    continue;
                }
                if ((col.type == "treeselectcolumn" || col.type == "displayfield") && col.editor && col.field == fdname) {
                    col.editor.valueField = cmbdata.ValueField;
                    col.editor.parentField = cmbdata.ParentField;
                    col.editor.textField = cmbdata.TextField;
                    if (cmbdata.SourceType != "url")
                        col.editor.data = mini.arrayToTree(cmbdata.Data, "children", cmbdata.ValueField, cmbdata.ParentField);
                    else
                        col.editor.load(cmbdata.Data);
                    continue;
                }
            }
        },
        ComboboxValueChanged: function (e) {//批量修改treegrid、grid中的行的值
            if (e && e.sender && e.sender.getSelecteds()) {
                var c = e.sender.getSelecteds();
                for (var i = 0; i < c.length; i++) {
                    var x = e.sender.getRow(c[i]);

                    if (e.editor && e.editor.type == "buttonedit") {//如果是向导的话，可能有多个字段要修改
                        if (formconfig) {
                            var config = formconfig[e.editor.id];
                            if (config) {
                                var fields = config.fields;
                                if (fields) {
                                    var upd = {};
                                    var row = e.sender.getSelected();
                                    for (var field in fields) {
                                        upd[field] = row[field];
                                    }
                                    e.sender.updateRow(x, upd);
                                }
                            }
                        }
                    }
                    else {//否则只修改当前字段
                        var f = e.field;
                        var upd = {};
                        upd[f] = e.value;
                        e.sender.updateRow(x, upd);
                    }
                }
            }
        },
        EventAfterFormLoad: function (f, data) { },
        LoadPrint: function (f, data) { },
        FormSetData: function (miniid, data) {
            var f = funsself.GetMiniFormGrid(miniid);
            if (f != null)
                f.setData(data);
            for (var i = 1; i < 10; i++) {
                var ff = funsself.GetMiniFormGrid(miniid + "-" + i);
                if (ff != null)
                    ff.setData(data);
            }
        },
        FormSetMaxLength: function (d) {
            if (!d)
                return;
            var tmp = mini.decode(d);
            for (var t in tmp) {
                if (tmp[t] == "0" || tmp[t] == "-1")
                    continue;
                var ctl = mini.getbyName(t);
                if (!ctl)
                    continue;
                if ((ctl.getStyle() && ctl.getStyle().replace(/\s/g, "").indexOf("display:none") > -1) || ctl.getVisible() == false)
                    continue;
                if ((ctl.type == "combobox" || ctl.type == "textbox" || ctl.type == "textarea") && !ctl.readOnly)
                    ctl.setMaxLength(parseInt(tmp[t]));
            }
        },
        //form加载单条数据
        FormReLoad: function (f, fncallback) {

            var config = FormFuns.GetConfig(f.el.id);
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + f.el.id + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                return;
            }
            var params = new Object();
            params.KeyWord = config.KeyWord;
            params.KeyWordType = config.KeyWordType;
            params.keyvalue = formconfig.KeyValue;
            params.select = "";
            params.formstate = formconfig.FormState;

            jQuery.ajax({
                url: "/Form/FormLoad",
                data: params,
                success: function (text) {

                    var tmpdata = mini.decode(text);
                    if (!tmpdata.success) {
                        //f.setData("");
                        funsself.FormSetData(f.el.id, "");
                        config.currow = null;
                        config.oldcurrow = null;
                        Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 0, position: "center center", closeable: true });
                    }
                    else {
                        config.currow = mini.decode(tmpdata.data.value);
                        config.oldcurrow = mini.decode(tmpdata.data.value);
                        //如果是表单的主表form，且有台账页面传递过来的新增默认值，且是新增状态，则需要赋值进去
                        if (config.miniid == formconfig.config.joindata.miniid && formconfig.FormState == "add") {
                            formconfig.KeyValue = config.currow[config.keyfield];
                            if (KeyValue != undefined && KeyValue == "")
                                KeyValue = config.currow[config.keyfield];
                            if (config.filter) {
                                for (var fd in config.filter) {
                                    if (typeof (fd) == "function") continue;
                                    config.currow[fd] = config.filter[fd];
                                }
                            }
                            if (config.newdefaultdata) {
                                for (var fd in config.newdefaultdata) {
                                    if (typeof (fd) == "function") continue;
                                    config.currow[fd] = config.newdefaultdata[fd];
                                }
                            }
                        }
                        //f.setData(config.currow);
                        funsself.FormSetData(f.el.id, config.currow);
                        //设置miniui控件的最大长度
                        funsself.FormSetMaxLength(tmpdata.data.fieldlength);
                        //加载子表数据
                        funsself.LoadChildData(config.miniid);


                        //重新加载权限
                        funsself.LoadRight(config.miniid, true);
                        funsself.LoadAttach(config);
                        //只有主业务对象，新增时，才进行关键词判断
                        if (formconfig.FormState == "add" && formconfig.config.joindata.KeyWord == config.KeyWord) {
                            //新增的时候，在到后台方法获取一下编号，否则有启用条件的编号规则，不会显示
                            funsself.LoadCode(config, f);
                        }
                        else
                            //触发form数据加载后事件
                            funsself.EventAfterFormLoad(f, config.currow);
                        if (formconfig.FormState != "add" && workflowdata) {
                            var fw = false;
                            var divs = $("#" + config.KeyWord + " div");
                            for (var i = 0; i < divs.length; i++) {
                                var div = divs[i];
                                if (div.id.indexOf("flow.") == 0) {
                                    fw = true;
                                    break;
                                }
                            }
                            if (fw) {
                                if (typeof (getParameter) == "function") {
                                    if (getParameter("print") && getParameter("print") == "1") {
                                        $(".portlet-title,.mini-buttonedit-icon").css("display", "none");
                                        $(".portlet-body").css("margin-top", "0px");
                                        $(".row").css("overflow-y", "initial");
                                        $(".portlet-body").css("overflow-y", "initial");
                                    }
                                }
                                $.ajax({
                                    url: "/Form/FlowDataTable",
                                    type: "POST",
                                    data: { formKeyValue: formconfig.KeyValue, fromKeyWord: config.KeyWord },
                                    cache: false,
                                    success: function (text) {
                                        var tmpdata = mini.decode(text);
                                        if (tmpdata.success == false) {
                                            Power.ui.alert(tmpdata.messages);
                                        }

                                        if (tmpdata.data.value) {
                                            var ds = mini.decode(tmpdata.data.value);
                                            if (ds && ds[0]) {
                                                var d = ds[0];
                                                var divs = $("#" + config.KeyWord + " div");
                                                for (var i = 0; i < divs.length; i++) {
                                                    var div = divs[i];
                                                    if (div.id.indexOf("flow.") == 0) {
                                                        var id = div.id.replace("flow.", "");
                                                        if (d[id]) {
                                                            div.innerHTML = d[id];
                                                        }
                                                    }
                                                }
                                                var imgs = $("#" + config.KeyWord + " img");
                                                for (var i = 0; i < imgs.length; i++) {
                                                    var img = imgs[i];
                                                    if (img.id.indexOf("flow.") == 0) {
                                                        var id = img.id.replace("flow.", "");
                                                        if (d[id]) {
                                                            img.src = "data:image/png; base64," + d[id];
                                                            img.style.display = "inline"
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                });
                            }
                        }
                        //查找是否有富文本编辑框属性KindEditor
                        var kinds = config.KindEditor;
                        if (kinds) {
                            for (var i = 0; i < kinds.length; i++) {
                                if (formconfig.FormState == "view") {
                                    var div = $("#" + config.KeyWord + "_" + kinds[i].Content);
                                    if (div && div.is("div") && typeof (div.html) == "function") {
                                        div.html(Base64.decode(config.currow[kinds[i].Content]));
                                        if ($(".ke-container") && typeof ($(".ke-container").hide) == "function")
                                            $(".ke-container").hide();
                                    }
                                }
                                if (formconfig.kindeditors[kinds[i].ViewControl]) {
                                    if (config.currow[kinds[i].Content] == null || config.currow[kinds[i].Content] == "")
                                        formconfig.kindeditors[kinds[i].ViewControl].html("");
                                    else
                                        formconfig.kindeditors[kinds[i].ViewControl].html(Base64.decode(config.currow[kinds[i].Content]));
                                }

                            }
                        }
                        funsself.LoadPrint(f, config.currow); //触发打印按钮绑定事件

                    }

                    if (fncallback != undefined && typeof (fncallback) == "function") {
                        fncallback(tmpdata);
                    }
                }
            })
        },
        LoadAttach: function (config) {
            var mtabs = mini.get("maintabs");
            if (mtabs != undefined) {
                var mkeyword = config.BusinessKeyWord || config.KeyWord;
                var tmptab = mtabs.getTab("attachfile");
                if (tmptab) {
                    var effected = formconfig.Effected;
                    var upddata = { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/FileOperate.htm&KeyWord=" + mkeyword + "&KeyValue=" + config.currow[config.keyfield] };
                    if ((formconfig.FormState == "view") || (!workflowdata && !keywordright[config.KeyWord]) || funsself.WorkflowReadOnly(effected) || effected == true || funsself.WorkFlowUpdateForm() == true)
                        upddata.url += "&canEdit=false";
                    else
                        upddata.url += "&canEdit=true";
                    mtabs.updateTab(tmptab, upddata);
                    mtabs.reloadTab(tmptab);
                    if (formconfig.KeyValue != "") {
                        $.ajax({
                            url: "/Form/GetFileCount",
                            data: { KeyWord: mkeyword, KeyValue: formconfig.KeyValue },
                            success: function (text) {
                                var t = mini.decode(text);
                                var c = t.data.value;
                                FormFuns.SetAttachFileCount(c);
                            }
                        })
                    }
                }
                tmptab = mtabs.getTab("attachfiletemplate");
                if (tmptab) {
                    var effected = formconfig.Effected;
                    var upddata = { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/FileOperateTemplate.htm&KeyWord=" + mkeyword + "&KeyValue=" + config.currow[config.keyfield] };
                    if ((formconfig.FormState == "view") || (!workflowdata && !keywordright[config.KeyWord]) || funsself.WorkflowReadOnly(effected) || effected == true || funsself.WorkFlowUpdateForm() == true)
                        upddata.url += "&canEdit=false";
                    else
                        upddata.url += "&canEdit=true";
                    mtabs.updateTab(tmptab, upddata);
                    mtabs.reloadTab(tmptab);
                }

                tmptab = mtabs.getTab("reclink");
                if (tmptab) {
                    var effected = formconfig.Effected;
                    var upddata = { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/Systems/PB_RecLink.htm&KeyWord=" + mkeyword + "&KeyValue=" + config.currow[config.keyfield] };
                    if ((formconfig.FormState == "view") || (!workflowdata && !keywordright[config.KeyWord]) || funsself.WorkflowReadOnly(effected) || effected == true || funsself.WorkFlowUpdateForm() == true)
                        upddata.url += "&canEdit=false";
                    else
                        upddata.url += "&canEdit=true";
                    mtabs.updateTab(tmptab, upddata);
                    mtabs.reloadTab(tmptab);
                    if (formconfig.KeyValue != "") {
                        $.ajax({
                            url: "/Form/GetRecLinkCount",
                            data: { KeyWord: mkeyword, KeyValue: formconfig.KeyValue },
                            success: function (text) {
                                var t = mini.decode(text);
                                var c = t.data.value;
                                FormFuns.SetRecLinkCount(c);
                            }
                        })
                    }
                }
                tmptab = mtabs.getTab("tagcomment");
                if (tmptab) {
                    mtabs.updateTab(tmptab, { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/Systems/Comment.html&FormId=" + formconfig.FormId + "&KeyWord=" + mkeyword + "&KeyValue=" + config.currow[config.keyfield] });

                    mtabs.reloadTab(tmptab);
                }
                tmptab = mtabs.getTab("flowpastnodes");
                if (tmptab) {
                    if (typeof (WorkFlowUtils) != "undefined" && workflowdata) {
                        mtabs.updateTab(tmptab, { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/Systems/FlowPastNodes.htm&workflowid=" + workflowdata.WorkInfoID + "&configmodel=" + workflowdata.ConfigMode });
                        mtabs.reloadTab(tmptab);
                    }
                }
                tmptab = mtabs.getTab("distribute");
                if (tmptab) {
                    //修改为，只有查看，才不能操作分发，其他情况都能操作分发
                    if ((formconfig.FormState == "view"))
                        mtabs.updateTab(tmptab, { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdSystem/DistributeList.htm&KeyWord=" + mkeyword + "&canEdit=false&KeyValue=" + config.currow[config.keyfield] + "&HtmlPath=" + formconfig.FormId });
                    else
                        mtabs.updateTab(tmptab, { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdSystem/DistributeList.htm&KeyWord=" + mkeyword + "&canEdit=true&KeyValue=" + config.currow[config.keyfield] + "&HtmlPath=" + formconfig.FormId });

                    mtabs.reloadTab(tmptab);
                }
                tmptab = mtabs.getTab("distributenowebform");
                if (tmptab) {
                    //修改为，只有查看，才不能操作分发，其他情况都能操作分发
                    if ((formconfig.FormState == "view"))
                        mtabs.updateTab(tmptab, { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdSystem/DistributeListNoWebForm.htm&KeyWord=" + mkeyword + "&canEdit=false&KeyValue=" + config.currow[config.keyfield] + "&HtmlPath=" + formconfig.FormId });
                    else
                        mtabs.updateTab(tmptab, { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdSystem/DistributeListNoWebForm.htm&KeyWord=" + mkeyword + "&canEdit=true&KeyValue=" + config.currow[config.keyfield] + "&HtmlPath=" + formconfig.FormId });
                    mtabs.reloadTab(tmptab);
                }
            }
        },
        LoadCode: function (config, f) {
            var p = {};
            funsself.GetSaveDataPack(p, config.miniid, false);
            var tmpkw = (config.KeyWordType && config.KeyWordType.toLowerCase() == "viewentity") ? config.BusinessKeyWord : config.KeyWord;
            $.ajax({
                url: "/Form/GetCode",
                type: "POST",
                data: { KeyWord: tmpkw, Row: mini.encode(p[config.KeyWord].data[0]) },
                cache: false,
                success: function (text) {
                    var t = mini.decode(text);
                    var v = mini.decode(t.data.value);
                    funsself.UpdateFormData(config.miniid, false)
                    for (var i = 0; i < v.length; i++) {
                        var d = v[i];
                        config.currow[d.code] = d.value;
                    }
                    funsself.FormSetData(f.el.id, config.currow);
                    //触发form数据加载后事件
                    funsself.EventAfterFormLoad(f, config.currow);
                }
            })
        },
        //form/tree/grid 重新加载数据
        ReLoadData: function (o) {
            if (!o) return;
            if (funsself.IsMiniForm(o))
                funsself.FormReLoad(o)
            else if (funsself.IsMiniGridTree(o))
                o.reload();
        },
        //加载某个keyword的子表数据
        LoadChildData: function (miniid) {
            //数据加载后，自动加载子表数据
            var config = FormFuns.GetConfig(miniid, null);
            if (!config || !config.children || config.children.length == 0)
                return;
            for (var i = 0; i < config.children.length; i++) {
                var cc = config.children[i];
                var sender = funsself.GetMiniFormGrid(cc.miniid);
                if (!sender) continue;
                //如果当前节点是grid，父控件切换行后加载子表数据，应该从第0页开始，index=0
                if (funsself.IsMiniGrid(sender))
                    sender.setPageIndex(0);
                cc.currow = null; //清除子表当前选中记录
                //父节点没有数据，清除子表数据
                funsself.ReLoadData(sender);
            }
        },
        //验证数据有效性，bchild=true，包含子表
        ValidData: function (miniid, bchild) {
            var rlt = { success: true, errortext: "" };
            var sender = funsself.GetMiniFormGrid(miniid);
            if (!sender) return rlt;
            sender.validate()
            if (sender.isValid() == false) {
                if (sender.getErrorTexts != undefined)
                    rlt.errortext += RequestTextToString(sender.getErrorTexts());
                else {
                    if (sender.title) {
                        rlt.errortext += ("[" + sender.title + "]验证未通过");
                    } else
                        rlt.errortext += (sender.id + "验证未通过");
                }
                rlt.success = false;
                return rlt;
            }
            //验证KeyWord-1....KeyWord-9
            for (var i = 0; i < 10; i++) {
                var _sender = funsself.GetMiniFormGrid(miniid + "-" + i);
                if (!_sender) continue;
                _sender.validate()
                if (_sender.isValid() == false) {
                    if (sender.getErrorTexts != undefined)
                        rlt.errortext += RequestTextToString(sender.getErrorTexts());
                    else {
                        if (sender.title) {
                            rlt.errortext += ("[" + sender.title + "]验证未通过");
                        } else
                            rlt.errortext += (sender.id + "验证未通过");
                    }
                    rlt.success = false;
                    return rlt;
                }
            }
            if (!bchild)
                return true;
            var config = funsself.GetConfig(miniid);
            if (config && config.children && config.children.length > 0) {
                for (var i = 0; i < config.children.length; i++) {
                    var cc = config.children[i];
                    if (cc.cancelCheck == true) continue;  //如果有属性标记，该对象不做验证，则忽略掉（wsl2015.5.12 因协鑫项目上业务需求追加)
                    var r = funsself.ValidData(cc.miniid, bchild);
                    if (!r.success) {//任意一个子表验证失败，则整个验证失败
                        rlt.errortext += r.errortext;
                        rlt.success = false;
                        return rlt;
                    }
                }
            }
            return rlt;
        },
        //将form中是数据写入到config.currow中, bchild=true 包含子表
        UpdateFormData: function (miniid, bchild) {
            var sender = funsself.GetMiniFormGrid(miniid);
            if (!sender) {
                Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                return;
            }
            var config = funsself.GetConfig(miniid);
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                return;
            }
            if (funsself.IsMiniForm(sender)) {
                if (!config.currow) config.currow = new Object();
                var fields = sender.getFields();
                for (var i = 0; i < fields.length; i++) {
                    var c = fields[i];
                    config.currow[c.name] = c.getValue();
                }
                for (var j = 1; j < 10; j++) {
                    sender = funsself.GetMiniFormGrid(miniid + "-" + j);
                    if (!sender) continue;
                    if (funsself.IsMiniForm(sender)) {
                        var fields = sender.getFields();
                        for (var i = 0; i < fields.length; i++) {
                            var c = fields[i];
                            config.currow[c.name] = c.getValue();
                        }
                    }
                }
            }
            //处理富文本编辑框
            var kinds = config.KindEditor;
            if (kinds) {
                for (var i = 0; i < kinds.length; i++) {
                    if (formconfig.kindeditors && formconfig.kindeditors[kinds[i].ViewControl]) {
                        var editorData = formconfig.kindeditors[kinds[i].ViewControl].html();//全部内容
                        var editorText = formconfig.kindeditors[kinds[i].ViewControl].text();//去掉HTML格式的内容(默认含有img,embed标签)
                        editorText = editorText.replace(/<img.*>.*<\/img>/ig, "");   //过滤如<img></img>形式的图片元素
                        editorText = editorText.replace(/<img.*\/>/ig, "");   //过滤如<img />形式的元素
                        editorText = editorText.replace(/<embed.*\/>/ig, "");   //过滤embed标签
                        editorData = Base64.encode(editorData);
                        config.currow[kinds[i].Content] = editorData;
                        config.currow[kinds[i].Text] = editorText;
                    }
                }
            }
            if (!bchild)
                return true;

            if (config.children && config.children.length > 0) {
                for (var i = 0; i < config.children.length; i++) {
                    funsself.UpdateFormData(config.children[i].miniid);
                }
            }
        },
        //获取新增默认值，包括关联主表的字段，常量字段
        GetNewDefaulValues: function (miniid) {
            var r = { cancel: false, miniid: miniid };
            r.data = {};
            FormFuns.EventGetNewDefaultValues(r);
            if (r.cancel == true)
                return r.data;

            var sender = FormFuns.GetMiniFormGrid(miniid);
            if (!sender) {
                Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
                return null;
            }
            var config = FormFuns.GetConfig(miniid);
            if (!config) {
                Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                return null;
            }

            var result = {};

            var pconfig = FormFuns.GetParentConfig(miniid);
            if (pconfig && pconfig.currow) {
                for (var fd in config.fields) {
                    if (typeof (fd) == "function") continue;
                    result[fd] = pconfig.currow[config.fields[fd]];
                }
            }
            //常量过滤值
            if (config.filter) {
                for (var fd in config.filter) {
                    if (typeof (fd) == "function") continue;
                    result[fd] = config.filter[fd];
                }
            }
            return result;
        },
        //获取保存数据包，keyword->rows, result 是返回的结果集, bchild=true 包含子表
        GetSaveDataPack: function (result, miniid, bchild) {
            var sender = FormFuns.GetMiniFormGrid(miniid);
            var config = FormFuns.GetConfig(miniid);
            var keyword = config.KeyWord;
            if (sender) {
                if (FormFuns.IsMiniForm(sender) && config.currow) {
                    if (!result[keyword]) result[keyword] = { KeyWordType: config.KeyWordType, data: [] };
                    var row = mini.clone(config.currow);
                    if (!row._state) {
                        if (formconfig.FormState == "add") row._state = "added";
                        else if (formconfig.FormState == "edit") row._state = "modified";
                        else row._state = "view";
                    }
                    result[keyword].data.push(row);
                }
                else if (FormFuns.IsMiniGridTree(sender)) {
                    var rows = sender.getChanges(null, false); //获取所有修改行及其字段
                    if (rows && rows.length > 0) {
                        if (!result[keyword]) result[keyword] = { KeyWordType: config.KeyWordType, data: [] };
                        for (var i = 0; i < rows.length; i++) {
                            rows[i]._sys_check_update = "1";
                            result[keyword].data.push(rows[i]);
                        }
                    }
                }
            }
            //处理子表            
            if (!bchild || !config || !config.children || config.children.length == 0) return result;
            for (var i = 0; i < config.children.length; i++) {
                funsself.GetSaveDataPack(result, config.children[i].miniid, bchild);
            }
        },
        //由于GetSaveDataPack中使用属性方式存储数据，属性在序列化过程中因浏览器不同，其顺序可能发生变化
        //为确保是按配置文件中的主-子表顺序提交数据，需要对保存数据进行二次处理
        SaveDataPackToString: function (pack) {
            var temp = {};
            var rlt = "{";
            var list = funsself.ConfigToList();
            for (var i = 0; i < list.length; i++) {
                var kw = list[i].KeyWord;
                if (!pack[kw]) continue;
                if (rlt.length > 1) rlt += ",";
                rlt += "\"" + kw + "\":" + mini.encode(pack[kw]);
                temp[kw] = "1";
            }
            //还有一部分keyword不在config中出现，手动添加进去的，添加在最后
            for (var kw in pack) {
                if (typeof (kw) == "function") continue;
                if (temp[kw] != undefined) continue;
                if (rlt.length > 1) rlt += ",";
                rlt += "\"" + kw + "\":" + mini.encode(pack[kw]);
            }
            rlt += "}";
            return rlt;
        },
        //保存keyword数据
        SaveKeyWordData: function (keyword, data, extparams, callback) {
            var pack = {};
            var datas = ($.isArray(data)) ? data : [data];
            pack[keyword] = { KeyWordType: "BO", data: datas };
            var s_data = base64swhere(funsself.SaveDataPackToString(pack))
            var s_param = base64encode(extparams == undefined ? '' : mini.encode(params));
            $.ajax({
                url: "/Form/SaveWebForm",
                type: "POST",
                data: { formId: "", encode: "r4", jsonData: s_data, Params: s_param },
                success: function (text) {
                    var o = mini.decode(text);
                    if (callback)
                        callback(o);
                }
            });
        },
        //生效，反生效操作
        OnFormEffect: function (e, actoin) {
            //只有主表可以执行生效操作
            var senderid = funsself.GetGridTreeName(e.id);
            if (senderid != formconfig.config.joindata.miniid) {
                Power.ui.warning(app_global_ResouceId["main_table_effect"] + senderid + app_global_ResouceId["not_main_table"]);//"只有主表才能执行生效操作"+senderid+"不是主表"
                return;
            }
            var url = "/Form/FormEffect";
            if (actoin == "uneffect") url = "/Form/FormUnEffect";

            $.ajax({
                url: url,
                type: "POST",
                data: { KeyWord: formconfig.config.joindata.KeyWord, KeyValue: formconfig.KeyValue },
                cache: false,
                success: function (text) {
                    var o = mini.decode(text);
                    if (o.success == false) {
                        Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                    }
                    else {
                        //重新刷新整个页面，尤其撤销生效操作，本地没有记录哪些字段可以修改。撤销之后不能设置控件的编辑属性
                        //如果是新增保存后,刷新应当变成编辑方式
                        if (typeof (formconfig) != "undefined") {
                            var uadd = "/Form/AddForm/" + formconfig.FormId + "/";
                            if (window.location.pathname && window.location.pathname.indexOf(uadd) >= 0) {
                                var uedit = window.location.protocol + "//" + window.location.host + "/Form/EditForm/" + formconfig.FormId + "/" + formconfig.KeyValue;
                                window.location.href = uedit;
                            }
                            else
                                window.location.reload();
                        }
                        else
                            window.location.reload();
                    }
                }
            });
        },
        //判断是否当前录入人
        IsRegHuman: function (config, row) {
            if (!formconfig || !config || !row) return false;
            if (formconfig.FormState == "add") return true;
            if (sessiondata) {
                if (config.reghumidfield && row && row[config.reghumidfield] == sessiondata.HumanId)
                    return true;
            }
            return false;
        },
        //判断业务流程状态已经批准
        WorkflowApproved: function () {
            //业务不需要走流程
            if (typeof (workflowdata) == "undefined" || !workflowdata)   // == undefined)
                return false;
            //流程结束
            if (workflowdata.RecordStatus == 50)   // FlowRecordStatus.Finish 50 = 办结
                return true;
            //状态=50,可能是手工批准的
            if (typeof (formconfig) != "undefined" && formconfig && formconfig.config && formconfig.config.joindata) {
                var config = formconfig.config.joindata;
                if (config.statusfield && config.currow && config.currow[config.statusfield] && config.currow[config.statusfield] == "50")
                    return true;
            }
            return false;
        },
        //判断业务走流程的状态下控制只读，true只读
        WorkflowReadOnly: function (effected) {
            //业务不需要走流程
            if (typeof (workflowdata) == "undefined" || !workflowdata)
                return false;
            if (funsself.WorkflowApproved())
                return true;
            var flowActive = 4096;  //FlowOperate.Active 参阅 FlowStatusSerials.js 
            //新流程通过当前审批人和当前登录人来判断
            if (workflowdata.WorkFlowFlag && workflowdata.WorkFlowFlag == "workflows") {
                if (!workflowdata.CanFlowOperate) return false;  //如果没有  CanFlowOperate 说明当下此人无SequeID
                if (workflowdata.CanFlowOperate.UserType != 1 && (workflowdata.CanFlowOperate.UserType & 4) == 0)
                    return true;
                else
                    return false;
            }
            if ((workflowdata.CanFlowOperate & flowActive) != 0) {
                //处理当前业务上的送审按钮权限
                //只有编辑状态下显示，且只有录入人=当前用户才显示
                //如果已经执行生效操作，则 送审 按钮也不应该显示
                var act = mini.get("btnActive"); //$("#btnActive")[0];
                if (act) {
                    if (effected == false) {
                        if (formconfig.FormState == "edit" && workflowdata.RecordRegHumId == workflowdata.UserID)
                            act.setVisible(true);
                    }
                    else
                        act.setVisible(false);
                }
                return false;
            }
            //走流程过程中，不是当前节点用户
            var flowUpdate = 4;   //FlowOperate.Update 参阅 FlowStatusSerials.js
            if ((workflowdata.CanFlowOperate & flowUpdate) == 0)
                return true;
            else
                return false;
        },

        WorkFlowUpdateForm: function () {
            //全局参数设置审批人不允许修改表单,起草者可修改
            var config = funsself.GetConfig(formconfig.config.joindata.KeyWord);
            if (enableform != undefined && enableform == 0 && config && config.currow && config.statusfield
               && config.currow[config.statusfield] != "0" && (workflowdata.CurNodeType != 10 || !funsself.IsRegHuman(config, config.currow)) && sessiondata.IsITAdmin == false)
                return true;
            else
                return false;
        },
        SetEffectButton: function (miniid, effect) {//提取对生效的权限控制 
            if (typeof (formconfig) == "undefined" || !formconfig.config || !formconfig.config.joindata) return;
            if (miniid != formconfig.config.joindata.miniid) return;
            var btneffect = mini.get(miniid + ".Effect");
            var btnuneffect = mini.get(miniid + ".UnEffect");
            if (btneffect) btneffect.setVisible(false);
            if (btnuneffect) btnuneffect.setVisible(false);

            if (funsself.WorkflowApproved())//状态是 完成状态,推出
                return;
            var config = funsself.GetConfig(miniid);
            if (formconfig.FormState == "edit" && config && config.currow && config.statusfield && config.reghumidfield
                && typeof (sessiondata) != "undefined") {
                var vstatus = config.currow[config.statusfield];
                if (vstatus != "0" && vstatus != "35")  //不是新增、生效状态
                    return false;
                var vreghumid = config.currow[config.reghumidfield];
                if (vreghumid && vreghumid.toUpperCase() == sessiondata.HumanId.toUpperCase()) {
                    if (effect == false && btneffect) btneffect.setVisible(true);
                    //已经生效
                    if (effect && btnuneffect) btnuneffect.setVisible(true);
                }
            }
        },
        EventBeforeLoadRight: function (e) { },
        EventAfterLoadRight: function (e) { },
        //加载权限
        LoadRight: function (miniid, bchild) {
            if (!miniid || miniid.length < 1) return;
            var config = funsself.GetConfig(miniid);
            
            //debugger;
            //按用户需求添加的:任何状态(除新增单据)都能转发
            if( mini.get("btnForward") && formstate!="add" ){
                mini.get("btnForward").setEnabled(true);
                mini.get("btnForward").show();
            }
            //Al add at 18-02-14
            if($("#SendTo").length==0 && formstate!="add"){
                //debugger;
                $("#btnForward").parent().append("<a class='mini-button flowbuttoncolor' id='SendTo' onclick='SendToPay("+config.KeyWord+")'><i class='fa fa-arrow-down'></i>支付提醒</a>"); 
                //按需求开放权限("关键词"+人员Id(注意转为小写) )
                // if((sessiondata.HumanId.toLowerCase()=="ad000000-0000-0000-0000-000000000000" || sessiondata.HumanName=="周兴卫") && config.KeyWord=="PS_SubContractInvoice")
                if((sessiondata.HumanId.toLowerCase()=="ad000000-0000-0000-0000-000000000000" || (sessiondata.DeptId.toLowerCase()=="c08b71bb-83d8-4e27-bbf5-55f487a93669" && sessiondata.PosiId.toLowerCase()=="3965084a-9c22-4b1b-a870-b6e2342c4bcd")) && config.KeyWord=="PS_SubContractInvoice")
                {
                    $("#SendTo").show();
                }
                else
                {
                    $("#SendTo").hide();
                }
            }
            //zyx
            if($("#zyxReturnBtn").length==0 && formstate!="add"){
                //debugger;
                $("#btnForward").parent().append("<a class='mini-button flowbuttoncolor' id='zyxReturnBtn' onclick='zyxReturnBtn("+config.KeyWord+")'>删除流程</a>"); 
                //按需求开放权限("关键词"+人员Id(注意转为小写) )
                if(sessiondata.HumanId.toLowerCase()=="ad000000-0000-0000-0000-000000000000"
                   ||( (config.KeyWord=="PS_SubContract"||config.KeyWord=="PS_SubContract_PiClass") && sessiondata.HumanId=="F7E6496A-7C23-47BB-81BE-B8B99341C4D5".toLowerCase()) 
                   ||(config.KeyWord=="PS_IncomeContract" && sessiondata.HumanId=="7F464B4A-D096-4A87-BFCE-BF1A3ACE4285".toLowerCase()) ){
                    $("#zyxReturnBtn").show();
                }else{
                    $("#zyxReturnBtn").hide();
                }
            }

            if($("#delPrintRecord").length==0){
                $("#btnForward").parent().append(" <a class='mini-button red' id='delPrintRecord' onclick='delPrintRecord(\""+config.KeyWord+"\")'>删除打印记录</a>"); 
                if(sessiondata.HumanId.toLowerCase()=="ad000000-0000-0000-0000-000000000000"){
                    // debugger;
                    if( config.KeyWord && config.KeyWord=="PS_SubContractApplyMoney"){
                        $("#delPrintRecord").show();
                    }
                    else{
                        $("#delPrintRecord").hide();
                    }
                }else{
                    $("#delPrintRecord").hide();
                }
            }

            if($("#EditAll").length==0){
                $("#btnForward").parent().append(" <a class='mini-button green' id='EditAll' onclick='EditAll()'>编辑</a>"); 
                if(sessiondata.HumanId.toLowerCase()=="ad000000-0000-0000-0000-000000000000"){
                    $("#EditAll").show();
                }else{
                    $("#EditAll").hide();
                }
            }
            
            var oEvent = { id: miniid, cancel: false }
            funsself.EventBeforeLoadRight(oEvent);
            var formstate = formconfig.FormState;
            if (!oEvent.cancel && config && formstate && typeof (keywordright) != "undefined") {
                //新增、修改、删除设置按钮权限
                var fdRight = {
                    "bAdd": ["Add", "Add0", "Add1", "Add2", "AddForm", "AddFormChild", "AddFormBrother", "SaveAdd"],
                    "bEdit": ["Save", "Edit", "EditForm", "Tree", "MoveUp", "MoveDown", "MoveLeft", "MoveRight"],
                    "bView": ["View", "ViewForm"],
                    "bDel": ["Delete", "Del"],
                    "bValid": ["Valid"],
                    //"bPrint": ["Print"],
                    //"bExport": ["Export"]
                }
                //导出和打印按钮，只要有权限，则任何时候都可用，即，判断keywordright中，如果为0，则隐藏，否则不管
                var kwright = keywordright[config.KeyWord];
                var mk = keywordright[formconfig.config.joindata.KeyWord];//打印按钮只需要主表
                if (mk && mk.bPrint == "0" && $("#btnPrint").length > 0) {
                    $("#btnPrint").css("display", "none");
                }
                if (kwright && kwright.bExport == "0" && $("#" + config.KeyWord + "-Export").length > 0) {//每个子表判断是否有导出权限
                    $("#" + config.KeyWord + "-Export").css("display", "none");
                }

                //根据配置设置控件权限,根据配置的权限类型,将控件 id 添加到权限数组中
                for (var i in formconfig) {
                    if (typeof (i) == "function" || !formconfig[i] || !formconfig[i].m3right) continue;
                    var kwid = funsself.GetGridTreeName(i);
                    if (kwid != config.KeyWord) continue;
                    var tmpid = i.replace(kwid + ".", "");
                    var bindright = "b" + formconfig[i].m3right.bind;
                    if (!fdRight[bindright]) continue;
                    fdRight[bindright].push(tmpid);
                }
                var _setBtnRight = function (_btn, _yes) {
                    if (!_btn) return;
                    var _rt = "enabled";
                    var _cfg = formconfig[_btn.id];
                    if (_cfg && _cfg.m3right && _cfg.m3right.action)
                        _rt = _cfg.m3right.action;
                    if (_rt == "enabled") {
                        if (_btn.type == "button") _btn.setEnabled(_yes);
                        else _btn.setReadOnly(!_yes);
                    }
                    if (_rt == "visible") _btn.setVisible(_yes);
                }

                var _findBtnAndSetRight = function (_btns, _yes) {
                    if (!_btns || _btns.length == 0) return;
                    for (var j = 0; j < _btns.length; j++) {
                        var tmpid = miniid + "." + _btns[j];
                        var m = mini.get(tmpid);
                        _setBtnRight(m, _yes);
                    }
                }

                var effected = formconfig.Effected;
                var wfreadonly = funsself.WorkflowReadOnly(effected);

                var wfupdateform = funsself.WorkFlowUpdateForm();
                if (PowerForm && PowerForm.Type() == "win")
                    wfupdateform = false;
                //主表编辑状态下，控制生效，取消生效按钮显示
                funsself.SetEffectButton(miniid, effected);
                //查看，或者权限中不存在keyword则表示无权限，或者审批中或 审批结束
                if ((formstate == "view" && wfreadonly == true) || effected == true || wfupdateform == true || wfreadonly == true || (!workflowdata && !kwright)) {
                    funsself.SetFormEnabled(miniid, false);
                    //再次循环防止有keyword-x的没有被禁用
                    for (var x = 0; x < 10; x++) {
                        funsself.SetFormEnabled(miniid + "-" + x, false);
                    }
                    //查看，禁用所有 miniid 相关的操作
                    for (var r in fdRight) {
                        if (typeof (r) == "function") continue;
                        if (r == "bExport") continue; //此条件下，导出不禁用
                        if (formstate == "view" && kwright && r == "bView") continue;
                        _findBtnAndSetRight(fdRight[r], false);
                    }
                    //已批准或已生效,设置可编辑字段
                    if (effected || funsself.WorkflowApproved()) {
                        if (kwright && kwright.propright) {
                            //如果是 grid 或 gridtree，隐藏对应列
                            //如果有，任意可编辑控件，则启用保存按钮
                            if (mini.get(config.KeyWord + ".Save"))
                                mini.get(config.KeyWord + ".Save").setEnabled(true);
                            var g = mini.get(miniid);
                            if (g && g.type != "datagrid" && g.type != "treegrid") {
                                g = null;
                            }
                            for (var r in kwright.propright) {
                                if (typeof (r) == "function") continue;
                                var tmp = kwright.propright[r];
                                if (tmp.valid != "1") continue;
                                //grid 隐藏不可见列处理, 查看或编辑无权限
                                var m = mini.get(miniid + "." + r);
                                if (m)
                                    _setBtnRight(m, true);
                                else {
                                    if (g && g.columns.length > 0) {
                                        var columns = [];
                                        funsself.GetTreeGridAllHeaders(g.columns, columns);
                                        for (var i = 0; i < columns.length; i++) {
                                            if (columns[i].field != r) continue;
                                            columns[i].readOnly = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                    //新增编辑状态下的权限控制                
                else if ((formstate == "add" || formstate == "edit") && (effected == false) && (wfreadonly == false) || (wfreadonly == false && formstate=="view")) {
                    var rkeyword = mini.clone(kwright);
                    if (rkeyword) {
                        //录入人允许编辑、删除自己录入的数据
                        if (rkeyword.bAdd == "1" && funsself.IsRegHuman(config, config.currow)) {
                            rkeyword.bEdit = "1";
                            rkeyword.bDel = "1";
                        }
                        for (var r in rkeyword) {
                            if (typeof (r) == "function") continue;
                            if (rkeyword[r] == "9" || !fdRight[r]) continue;
                            _findBtnAndSetRight(fdRight[r], rkeyword[r] == "1");
                        }
                        //字段权限
                        if (rkeyword.propright) {
                            //如果是 grid 或 gridtree，隐藏对应列
                            var g = mini.get(miniid);
                            if (g && g.type != "datagrid" && g.type != "treegrid") {
                                g = null;
                            }
                            for (var r in rkeyword.propright) {
                                if (typeof (r) == "function") continue;
                                var tmp = rkeyword.propright[r];
                                //grid 隐藏不可见列处理, 查看或编辑无权限
                                if (tmp.view == "0" && g && g.columns.length > 0) {
                                    for (var i = g.columns.length - 1; i > -1; i--) {
                                        if (g.columns[i].field != r) continue;
                                        g.hideColumn(g.columns[i]);
                                    }
                                }
                                //字段控件处理S
                                if (tmp.edit == "0") {
                                    var m = mini.get(miniid + "." + r);
                                    _setBtnRight(m, false);
                                }
                            }
                        }
                    }
                }
            }
            oEvent.data = config ? config.currow : null;
            oEvent.cancel = false;
            funsself.EventAfterLoadRight(oEvent);
            if (oEvent.cancel) return;
            //如果包含子表，处理子表
            if (!bchild || !config || !config.children || config.children.length == 0) return;
            for (var i = 0; i < config.children.length; i++)
                funsself.LoadRight(config.children[i].miniid, bchild);

        },
        //加载栏位配置
        LoadCustomColumn: function (title, formid, humanid) {
            if (!formid && typeof (formconfig) != "undefined")
                formid = formconfig.FormId;
            if (!formid) return;
            if (!humanid && typeof (sessiondata) != "undefined")
                humanid = sessiondata.HumanId;
            if (!humanid) return;
            if (!title) title = "栏位";

            var btns = $(".customcolumn");
            if (btns.length == 0) return;

            var builderhtml = function (btn, grdid) {
                var p = { KeyWord: "HumanCustom", select: "Id,Name,IsDefault", sort: "Sequ" };
                p.swhere = "CustomType='WidgetColumn' and ObjectId='" + formid + "' and ObjectCode='" + grdid + "' and HumanId='" + humanid + "'";
                funsself.GridPageLoad(p, function (o) {
                    if (!o.success) return;
                    var defaultid = null;
                    var html = "<a href='#' class='btn blue' data-toggle='dropdown'><i class='fa fa-columns'></i>" + title + "</a>"
                             + "<ul class='dropdown-menu'>";
                    var dt = mini.decode(o.data.value);
                    for (var j = 0; j < dt.length; j++) {
                        html += "<li><a class='btn' onclick=\"FormFuns.ChangeCustomColumn(this,'" + grdid + "','" + dt[j].Id + "')\">";
                        if (dt[j].IsDefault == "1") {
                            html += "<i class='fa fa-check'></i>";
                            defaultid = dt[j].Id;
                        }
                        html += (dt[j].Name + "</a></li>");
                    }
                    html += "<li class='divider'></li>";
                    html += "<li class='Actived'><a class='btn' onclick=\"FormFuns.SetCustomColumn('" + formid + "','" + humanid + "','" + grdid + "')\"'>栏位定义</a></li></ul>";
                    $(btn).html(html);
                    if (defaultid) {
                        funsself.ChangeCustomColumn(null, grdid, defaultid);
                    }
                })
            }

            for (var i = 0; i < btns.length; i++) {
                var btn = btns[i];
                var gridid = $(btn).attr("gridid");
                if (!gridid || gridid.length == 0) continue;
                var grid = mini.get(gridid);
                if (!grid || grid.type == "tree") continue;

                builderhtml(btn, gridid);
            }
        },
        //切换自定义栏位
        ChangeCustomColumn: function (sender, gridid, customid) {
            if (sender) {
                var ul = $(sender).parent().parent();
                if (ul.length > 0) {
                    $(ul[0]).find("i").each(function () {
                        this.remove();
                    })
                }
                $(sender).prepend("<i class='fa fa-check'></i>")
            }
            var grid = mini.get(gridid);
            if (!grid) return;
            funsself.GridPageLoad({ KeyWord: "HumanCustom", select: "ExtJson", swhere: "Id='" + customid + "'" }, function (o) {
                if (!o.success) return;
                var data = mini.decode(o.data.value);
                if (data.length == 0) return;
                var ext = mini.decode(data[0].ExtJson);
                if (ext.length == 0) return;
                //var cols = grid.columns;
                //var cols = [];
                //funsself.GetTreeGridAllHeaders(grid.columns, cols);
                //var newcols = [];
                //for (var i = 0; i < grid.columns.length; i++) {
                //    if (grid.columns[i].type == "indexcolumn" || grid.columns[i].type == "checkcolumn")
                //        if (!grid.field)
                //            newcols.push(grid.columns[i]);
                //}
                //debugger;
                //for (var i = 0; i < ext.length; i++) {
                //    for (var j = 0; j < cols.length; j++) {
                //        var col = cols[j];

                //        if (col.field == ext[i].field) {
                //            if (ext[i].bvisible != undefined)
                //                col.visible = ext[i].bvisible;
                //            if (ext[i].iwidth)
                //                col.width = ext[i].iwidth;
                //            newcols.push(col);
                //            break;
                //        }
                //    }
                //}
                //通过显示、隐藏来控制列，使之兼容多表头
                var cols = grid.columns;
                for (var i = 0; i < ext.length; i++) {
                    //通过递归寻找cols的col
                    funsself.GetCustomColumnVisiable(ext[i], cols);
                }
                grid.setColumns(cols);
                //如果页面修改导致列增多，通过栏位显示时，是隐藏，但不是消失
                //for (var i = 0; i < cols.length; i++) {
                //    for (var j = 0; j < newcols.length; j++) {
                //        if (cols[i].field == newcols[j].field)
                //            break;
                //        if (j == (newcols.length - 1)) {
                //            cols[i].visible = false;
                //            newcols.push(cols[i]);
                //        }
                //    }
                //}
                //if (newcols.length > 0)
                //    grid.setColumns(newcols);
                //$.each(ext, function () {
                //    for (var j = 0; j < cols.length; j++) {
                //        var col = cols[j];
                //        if (!col.field || col.field != this.field)
                //            continue;
                //        var set = {};
                //        if (this.bvisible != undefined && col.visible != this.bvisible) set.visible = this.bvisible;
                //        if (this.iwidth && col.width != this.iwidth) set.width = this.iwidth;
                //        grid.updateColumn(col, set);
                //    }
                //})
            })
        },
        GetCustomColumnVisiable: function (ext, cols) {
            for (var j = 0; j < cols.length; j++) {
                var col = cols[j];
                if (col.columns && col.columns.length > 0)
                    funsself.GetCustomColumnVisiable(ext, col.columns);
                else {
                    if (col.field == ext.field) {
                        if (ext.bvisible != undefined)
                            col.visible = ext.bvisible;
                        if (ext.iwidth)
                            col.width = ext.iwidth;
                        break;
                    }
                }
            }
        },
        //定义栏位
        SetCustomColumn: function (formid, humanid, gridid) {
            var grid = mini.get(gridid)
            if (!grid) return;
            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/FormXML/zh-CN/StdSystem/WizardCustomColumn.htm",
                height: 600, width: 900,
                showMaxButton: true,
                onload: function () {
                    var data = { formid: formid, humanid: humanid, gridid: gridid, column: [] };
                    var rcurrentgrid = [];
                    funsself.GetTreeGridAllHeaders(grid.columns, rcurrentgrid);
                    for (var i = 0; i < rcurrentgrid.length; i++) {
                        var col = rcurrentgrid[i];
                        if (!col.field) continue;
                        data.column.push({ field: col.field, header: col.header, bvisible: col.visible, iwidth: col.width.replace('px', '') });
                    }
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.LoadData(data);
                },
                ondestroy: function (action) { }
            })
        },

        GetTreeGridAllHeaders: function (columns, returncolumns) {
            for (var i = 0; i < columns.length; i++) {
                if (columns[i].field == undefined || columns[i].field == "") {
                    if (columns[i].columns && columns[i].columns.length > 0)
                        funsself.GetTreeGridAllHeaders(columns[i].columns, returncolumns);
                }
                else
                    returncolumns.push(columns[i]);
            }
        },
        //自定义过滤条件
        LoadCustomFilter: function (title, formid, humanid) {
            if (!formid && typeof (formconfig) != "undefined")
                formid = formconfig.FormId;
            if (!formid) return;
            if (!humanid && typeof (sessiondata) != "undefined")
                humanid = sessiondata.HumanId;
            if (!humanid) return;
            if (!title) title = "高级搜索";

            var btns = $(".customfilter");
            if (btns.length == 0) return;

            var builderhtml = function (btn, grdid) {
                //$(btn).bind("click", function () {
                //    funsself.SetCustomFilter(formid, humanid, grdid);
                //});
                var html = "<a href='#' onclick='FormFuns.SetCustomFilter(\"" + formid + "\", \"" + humanid + "\", \"" + grdid + "\")' class='btn blue' data-toggle='dropdown'><i class='fa fa-filter'></i>" + title + "</a>";
                $(btn).html(html);

                //var p = { KeyWord: "HumanCustom", select: "Id,Name,IsDefault", sort: "Sequ" };
                //p.swhere = "CustomType='WidgetFilter' and ObjectId='" + formid + "' and ObjectCode='" + grdid + "' and HumanId='" + humanid + "'";
                //funsself.GridPageLoad(p, function (o) {
                //    if (!o.success) return;
                //    var html = "<a href='#' class='btn blue' data-toggle='dropdown'><i class='fa fa-filter'></i>" + title + "</a>"
                //             + "<ul class='dropdown-menu'>";
                //    var dt = mini.decode(o.data.value);
                //    for (var j = 0; j < dt.length; j++) {
                //        html += "<li><a class='btn' onclick=\"FormFuns.ChangeCustomFilter(this,'" + grdid + "','" + dt[j].Id + "')\">";
                //        if (dt[j].IsDefault == "1") {
                //            html += "<i class='fa fa-check'></i>";
                //        }
                //        html += (dt[j].Name + "</a></li>");
                //    }
                //    html += "<li class='divider'></li>";
                //    html += "<li class='Actived'><a class='btn' onclick=\"FormFuns.SetCustomFilter('" + formid + "','" + humanid + "','" + grdid + "')\"'>过滤器定义</a></li></ul>";
                //    $(btn).html(html);
                //})
            }

            for (var i = 0; i < btns.length; i++) {
                var btn = btns[i];
                var gridid = $(btn).attr("gridid");
                if (!gridid || gridid.length == 0) continue;
                var grid = mini.get(gridid);
                if (!grid || grid.type == "tree") continue;
                if (!grid._customfilterid) grid._customfilterid = "default"; //标记第一次使用缺省过滤器
                builderhtml(btn, gridid);
            }
        },
        //切换自定义过滤条件
        ChangeCustomFilter: function (sender, gridid, customid) {
            if (sender) {
                var baddcheck = ($(sender).find("i").length == 0) //再次勾选表示取消
                var ul = $(sender).parent().parent();
                if (ul.length > 0) {
                    $(ul[0]).find("i").each(function () {
                        this.remove();
                    })
                }
                if (baddcheck)
                    $(sender).prepend("<i class='fa fa-check'></i>")
                else
                    customid = "";
            }
            var grid = mini.get(gridid);
            if (!grid) return;
            grid._customfilterid = customid;
            grid.reload();
        },
        //定义过滤条件
        SetCustomFilter: function (formid, humanid, gridid) {
            if (!formid && typeof (formconfig) != "undefined")
                formid = formconfig.FormId;
            if (!formid) return;
            if (!humanid && typeof (sessiondata) != "undefined")
                humanid = sessiondata.HumanId;
            if (!humanid) return;
            var grid = mini.get(gridid)
            if (!grid) return;
            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/FormXML/zh-CN/StdSystem/WizardCustomFilter.htm",
                height: 600, width: 900,
                showMaxButton: true,
                onload: function () {
                    var data = { formid: formid, humanid: humanid, gridid: gridid, fields: {} };
                    var cols = [];
                    funsself.GetTreeGridAllHeaders(grid.columns, cols);
                    for (var i = 0; i < cols.length; i++) {
                        var col = cols[i];
                        if (!col.field) continue;
                        var p = { header: col.header, editorcls: "mini-textbox" };
                        if (col.editor && col.editor.cls)
                            p.editorcls = col.editor.cls;
                        if (col.editor && col.editor.data)
                            p.editordata = col.editor.data;
                        p.isdate = p.editorcls == "mini-datepicker";
                        p.iscombox = p.editorcls == "mini-combobox";
                        data.fields[col.field] = p;
                    }
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.LoadData(data);
                },
                ondestroy: function (action) {
                    if (action != null && action != "" && action != "close") {
                        if (action == "clear") {
                            grid._customfilterid = "";
                        }
                        else
                            grid._customfilterid = action;
                        grid.reload();
                    }
                }
            })
        },
        EncodeGridPageLoadswhere: function (p) {
            if (p.swhere) {
                var tmp = {};
                if (p.extparams) {
                    var str = base64decode(p.extparams);
                    tmp = mini.decode(str);
                }
                tmp.encodeswhere = "r4";
                p.extparams = base64encode(mini.encode(tmp));
                p.swhere = base64swhere(p.swhere);
            }
        },
        //GridPageLoad加载数据
        GridPageLoad: function (p, fncallback) {
            var url = p.url || "/Form/GridPageLoad";
            p.KeyWordType = p.KeyWordType || "BO";
            p.select = p.select || "";
            p.sort = p.sort || "";
            p.index = p.index || "0";
            p.size = p.size || "0";
            p.swhere = p.swhere || "";
            var _async = typeof (p.async) == "undefined" ? true : p.async;
            delete p.async;
            if (p.swhere) {
                var tmp = {};
                if (p.extparams) {
                    var str = base64decode(p.extparams);
                    tmp = mini.decode(str);
                }
                tmp.encodeswhere = "r4";
                p.extparams = base64encode(mini.encode(tmp));
                p.swhere = base64swhere(p.swhere);
            }
            $.ajax({
                url: url,
                data: p,
                async: _async,
                type: 'post',
                success: function (text) {
                    var o = mini.decode(text);
                    if (fncallback) {
                        fncallback(o);
                        return;
                    }
                    if (!o.success)
                        Power.ui.error(o.message, { detail: o.detail });
                }
            })
        },
        //打开页面执行新增数据操作
        OnAddForm: function (formid, defaultdata, grid, params) {
            var url = "/Form/AddForm/" + formid + "/" + base64encode(params == undefined ? '' : mini.encode(params));
            //打开表单的宽、高,优先考虑按钮的参数，再考虑表单的参数
            var iw = formconfig.config.openwidth || 900;
            var ih = formconfig.config.openheight || 550;
            var opentype = formconfig.config.opentype || "div";
            var btnid = null;
            if (grid)
                btnid = grid.id + ".AddForm";
            if (formconfig[btnid]) {
                if (formconfig[btnid].formtype) opentype = formconfig[btnid].formtype;
                if (formconfig[btnid].formwidth && formconfig[btnid].formwidth != 0) iw = formconfig[btnid].formwidth;
                if (formconfig[btnid].formheight && formconfig[btnid].formheight != 0) ih = formconfig[btnid].formheight;
                if (formconfig[btnid].openformid) formid = formconfig[btnid].openformid;
            }
            var max = false;
            if (iw == "-1" && ih == "-1") {
                max = true;
                iw = 900;
                ih = 550;
            }
            if (opentype.toLowerCase() == "div") {
                var t = mini.open({
                    url: url,
                    width: iw,
                    height: ih,
                    showMaxButton: true,
                    onload: function () {
                        if (defaultdata) {
                            //弹出页面加载完成，设置新增默认值
                            var iframe = this.getIFrameEl();
                            //调用弹出页面方法进行初始化
                            iframe.contentWindow.SetNewDefault(defaultdata);
                        }
                    },
                    ondestroy: function () {
                        //判断是否有数据修改但未保存
                        var iframe = this.getIFrameEl();
                        if (!iframe.contentWindow.formconfig)
                            iframe = this.getIFrameEl().contentWindow.document.getElementById("frmMain");
                        if (!iframe.contentWindow.formconfig)
                            return;
                        var ifwin = iframe.contentWindow;
                        var b = funsself.OnCloseCancel(ifwin);
                        if (b) {
                            var buttonOption = {};
                            var yes = app_global_ResouceId['docfile_yes'];
                            var no = app_global_ResouceId['docfile_no'];
                            buttonOption[yes] = {
                                theme: 'primary',
                                handler: function (ret) {

                                    ifwin.autocancel = false;
                                }
                            };
                            buttonOption[no] = function () {
                                ifwin.autocancel = true;
                                if (ifwin.CloseOwnerWindow) //mini.open 的关闭方法
                                    ifwin.CloseOwnerWindow();
                                else {
                                    if (ifwin.parent && ifwin.parent.CloseOwnerWindow) //嵌套流程框的时候                
                                        ifwin.parent.CloseOwnerWindow();
                                    else
                                        ifwin.close();
                                }
                            };
                            ifwin.Power.ui.confirm("有修改未保存,是否继续修改", { button: buttonOption });
                            if (!ifwin.autocancel) {
                                return false;
                            }
                        }
                        var e = { formid: formid };
                        funsself.EventCloseAddForm(e);
                        if (e.canNext == false)
                            return;
                        //新增操作结束后，刷新grid 或 tree 中的数据
                        doAfterAddReLoadTreeNode(grid);
                    }
                });
                if (max && t && typeof (t.max) == "function")
                    t.max();
            }
            else if (opentype.toLowerCase() == "modal") {
                window.showModalDialog(url, defaultdata, "dialogWidth=" + iw + "px;dialogHeight=" + ih + "px");
                //新增操作结束后，刷新grid 或 tree 中的数据
                var e = { formid: formid };
                funsself.EventCloseAddForm(e);
                if (e.canNext == false)
                    return;
                doAfterAddReLoadTreeNode(grid);
            }
            else if (opentype.toLowerCase() == "tabs")
            { }
        },
        EventCloseAddForm: function (e) { },
        OnCloseCancel: function (form) {
            //对比主表
            //全局参数控制不判断
            if (closecancel != 1)
                return false;
            if (form.formconfig && form.formconfig.FormState == "view")
                return false;
            var pack = {};
            var m = form.document.getElementById(form.formconfig.config.joindata.miniid);
            if (m == undefined) return false;
            var keyword = form.formconfig.config.joindata.KeyWord;
            if (m && m.className == "form") {
                var sender = new form.mini.Form("#" + form.formconfig.config.joindata.miniid);
                if (sender) {
                    var fields = sender.getFields();
                    for (var i = 0; i < fields.length; i++) {
                        var c = fields[i];
                        pack[c.name] = c.getValue();
                    }
                    for (var j = 1; j < 10; j++) {
                        if (!form.document.getElementById(form.formconfig.config.joindata.miniid + "-" + j))
                            continue;
                        sender == new form.mini.Form("#" + form.formconfig.config.joindata.miniid + "-" + j);
                        if (!sender) continue;
                        var fields = sender.getFields();
                        for (var i = 0; i < fields.length; i++) {
                            var c = fields[i];
                            pack[c.name] = c.getValue();
                        }
                    }
                }
            }
            for (var field in pack) {
                if ((pack[field] == null || pack[field] == "") && (form.formconfig.config.joindata.oldcurrow[field] == null || form.formconfig.config.joindata.oldcurrow[field] == ""))
                    continue;
                if (mini.formatDate(pack[field], "yyyy-MM-dd") != "") {
                    if (mini.formatDate(pack[field], "yyyy-MM-dd") != mini.formatDate(form.formconfig.config.joindata.oldcurrow[field], "yyyy-MM-dd"))
                        return true;
                    continue;
                }
                //防止页面存在控件值，业务对象没有该控件的值
                if (form.formconfig.config.joindata.oldcurrow[field] == undefined)
                    continue;
                var oldf = form.formconfig.config.joindata.oldcurrow[field] == null ? "" : form.formconfig.config.joindata.oldcurrow[field];
                if (pack[field].toString().toLowerCase() == "false" && oldf.toString().toLowerCase() == "")
                    continue;//如果数据库为空，页面复选框不会选中，对比时，页面复选框值为false，导致判断出错
                //先判断是否可以转为float类型，如果能，则用float判断，否则转为string判断，因为可能有1和1.000000的问题
                if (parseFloat(pack[field].toString()) && parseFloat(oldf.toString())) {
                    if (parseFloat(pack[field].toString()) != parseFloat(oldf.toString()))
                        return true;
                }
                else if (pack[field].toString().toLowerCase() != oldf.toString().toLowerCase())
                    return true;
            }
            //查子表
            return funsself.ChildIsChange(form, form.formconfig.config.joindata);
        },
        ChildIsChange: function (form, config) {
            var sender = form.mini.get(config.miniid);
            if (sender && funsself.IsMiniGridTree(sender) && sender.getChanges().length > 0)
                return true;
            if (!config || !config.children || config.children.length == 0) return false;
            for (var i = 0; i < config.children.length; i++) {
                if (form.mini.get(config.children[i].miniid) && form.mini.get(config.children[i].miniid).getChanges().length > 0)
                    return true;
            }
            for (var i = 0; i < config.children.length; i++) {
                var result = funsself.ChildIsChange(form, config.children[i]);
                if (result)
                    return true;
            }
            return false;
        },
        EventCLoseEditViewForm: function (e) { },
        OnEditViewForm: function (btn, formid, action, params) {
            var btnid = btn.id;
            var gridid = funsself.GetGridTreeName(btnid);
            var grid = funsself.GetMiniFormGrid(gridid);
            var row = null;
            var recordId = null;
            if (funsself.IsMiniForm(grid)) {
                config = funsself.GetConfig(gridid);
                row = config.currow;
                recordId = row[config.keyfield];
            }
            else {
                row = grid.getSelected();
                recordId = row[grid.idField];
            }
            if (!row) {
                Power.ui.warning(app_global_ResouceId["select_open_row"]);//请选中要打开的行
                return;
            }
            //按钮设置独立的openformid
            //打开表单的方式,优先考虑按钮的参数，再考虑表单的参数
            //打开表单的宽、高,优先考虑按钮的参数，再考虑表单的参数
            var iw = formconfig.config.openwidth || 900;
            var ih = formconfig.config.openheight || 550;
            var opentype = formconfig.config.opentype || "div";
            if (formconfig[btnid]) {
                if (formconfig[btnid].formtype) opentype = formconfig[btnid].formtype;
                if (formconfig[btnid].formwidth && formconfig[btnid].formwidth != 0) iw = formconfig[btnid].formwidth;
                if (formconfig[btnid].formheight && formconfig[btnid].formheight != 0) ih = formconfig[btnid].formheight;
                if (formconfig[btnid].openformid) formid = formconfig[btnid].openformid;
            }
            if (!iw || (parseInt(iw) < 1 && parseInt(iw) != -1))
                iw = this.innerWidth * 0.75;
            if (!ih || (parseInt(ih) < 1 && parseInt(ih) != -1))
                ih = this.innerHeight * 0.75;

            var p = { formid: formid, keyvalue: recordId, action: action, params: params, opentype: opentype, width: iw, height: ih };
            funsself.OnOpenForm(p, function () {

                var e = { formid: formid };
                funsself.EventCLoseEditViewForm(e);
                if (e.canNext == false)
                    return;
                if (grid)
                    doAfterAddReLoadTreeNode(grid);
            });
        },
        //参数:{formid, keyvalue, opentype, width, height, action, params}
        OnOpenForm: function (e, fncallbak) {
            e.params = e.params || "";
            e.width = e.width || 900;
            e.height = e.height || 550;
            e.opentype = e.opentype || "div";

            var url = "/Form/ValidForm/" + e.formid + "/" + e.action + "/" + e.keyvalue + "/" + base64encode(mini.encode(e.params));

            var arg = "dialogWidth=" + e.width + "px;dialogHeight=" + e.height + "px;";

            switch (e.opentype.toLowerCase()) {
                case "modal":
                    if ((parseInt(e.width) < 1) && (parseInt(e.height) < 1)) {
                        window.showModalDialog(url, ""); //, arg
                    }
                    else {
                        window.showModalDialog(url, "", "dialogWidth=" + e.width + "px;dialogHeight=" + e.height + "px");
                    }
                    if (fncallbak) fncallbak();
                    break;
                case "div":
                    var win = null;
                    if ((parseInt(e.width) < 1 && parseInt(e.width) != -1) && (parseInt(e.height) < 1 && parseInt(e.height) != -1)) {
                        win = mini.open({
                            url: url,
                            showMaxButton: true,
                            ondestroy: function () {
                                //判断是否有数据修改但未保存
                                var iframe = this.getIFrameEl();
                                if (!iframe.contentWindow.formconfig)
                                    iframe = this.getIFrameEl().contentWindow.document.getElementById("frmMain");
                                if (!iframe.contentWindow.formconfig)
                                    return;
                                var b = funsself.OnCloseCancel(iframe.contentWindow);
                                if (b) {
                                    var buttonOption = {};
                                    var yes = app_global_ResouceId['docfile_yes'];
                                    var no = app_global_ResouceId['docfile_no'];
                                    buttonOption[yes] = {
                                        theme: 'primary',
                                        handler: function (ret) {

                                            iframe.contentWindow.autocancel = false;
                                        }
                                    };
                                    buttonOption[no] = function () {
                                        iframe.contentWindow.autocancel = true;
                                        if (iframe.contentWindow.CloseOwnerWindow) //mini.open 的关闭方法
                                            iframe.contentWindow.CloseOwnerWindow();
                                        else {
                                            if (iframe.contentWindow.parent && iframe.contentWindow.parent.CloseOwnerWindow) //嵌套流程框的时候                
                                                iframe.contentWindow.parent.CloseOwnerWindow();
                                            else
                                                iframe.contentWindow.close();
                                        }
                                    };
                                    iframe.contentWindow.Power.ui.confirm("有修改未保存,是否继续修改", { button: buttonOption });

                                    if (!iframe.contentWindow.autocancel)
                                        return false;
                                }
                                if (fncallbak) fncallbak();
                            }
                        });
                    }
                    else {
                        var max = false;
                        if (e.width == "-1" && e.height == "-1") {
                            max = true;
                            e.width = 900;
                            e.height = 550;
                        }
                        win = mini.open({
                            url: url,
                            width: e.width,
                            height: e.height,
                            showMaxButton: true,
                            ondestroy: function () {
                                //判断是否有数据修改但未保存
                                var iframe = this.getIFrameEl();
                                if (!iframe.contentWindow.formconfig)
                                    iframe = this.getIFrameEl().contentWindow.document.getElementById("frmMain");
                                if (!iframe.contentWindow.formconfig)
                                    return;
                                var b = funsself.OnCloseCancel(iframe.contentWindow);
                                if (b) {
                                    var buttonOption = {};
                                    var yes = app_global_ResouceId['docfile_yes'];
                                    var no = app_global_ResouceId['docfile_no'];
                                    buttonOption[yes] = {
                                        theme: 'primary',
                                        handler: function (ret) {

                                            iframe.contentWindow.autocancel = false;
                                        }
                                    };
                                    buttonOption[no] = function () {
                                        iframe.contentWindow.autocancel = true;
                                        if (iframe.contentWindow.CloseOwnerWindow) //mini.open 的关闭方法
                                            iframe.contentWindow.CloseOwnerWindow();
                                        else {
                                            if (iframe.contentWindow.parent && iframe.contentWindow.parent.CloseOwnerWindow) //嵌套流程框的时候                
                                                iframe.contentWindow.parent.CloseOwnerWindow();
                                            else
                                                iframe.contentWindow.close();
                                        }
                                    };
                                    iframe.contentWindow.Power.ui.confirm("有修改未保存,是否继续修改", { button: buttonOption });

                                    if (!iframe.contentWindow.autocancel)
                                        return false;
                                }
                                if (fncallbak) fncallbak();
                            }
                        });
                        if (max && win && typeof (win.max) == "function")
                            win.max();
                    }
                    //手机打开表单,最大化
                    if (funsself.DeviceIsPhone() && win && typeof (win.max) == "function")
                        win.max();
                    break;
                case "tabs":
                    window.open(url);
                    break;
            }
        },
        //mini.open url, 主要用在手机查看报表、附件的时候
        MiniOpenURL: function (url, p) {
            if (!p) p = {};
            p.width = p.width || document.documentElement.clientWidth;
            p.height = p.height || document.documentElement.clientHeight;
            var win = mini.open({
                url: url,
                width: p.width,
                height: p.height,
                showMaxButton: p.showmaxbutton
            });
            if (!p.buttons)
                p.buttons = [{ html: '<a class="btn btn-xs blue btnclose" style="position:relative;top:-4px;" onclick="$(this).parents(\'.mini-panel\').remove();$(\'.mini-modal\').remove()">' + app_global_ResouceId["g_off"] + '</a>' }];//关闭
            win.setButtons(p.buttons);
            if (p.max)
                win.max();
        },
        //发送通知消息{tohumanid:"",title:"",contenttext:"",showconfirm:true,confirmtitle:"",fncallback:null}
        //base64encode 在 ComTools.js
        SendNotify: function (e) {
            var p = { base64: "true" };
            p.tohumanid = e.tohumanid || "";
            p.title = e.title || "";
            p.contenttext = base64encode(e.contenttext);
            if (e.showconfirm == undefined)
                e.showconfirm = true;
            e.confirmtitle = e.confirmtitle || "确定发送通知消息?";
            var dosend = function () {
                $.ajax({
                    url: "/Message/SendNotify",
                    data: p,
                    type: "post",
                    success: function (text) {
                        var o = mini.decode(text);
                        if (e.fncallback) { e.fncallback(o); }
                        else {
                            if (o.success)
                                Power.form.success("消息已发送");
                            else
                                Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                        }
                    }
                })
            }
            if (e.showconfirm) {
                var buttonOption = {};
                buttonOption["发送"] = {
                    theme: 'primary',
                    handler: function () { dosend(); }
                };
                buttonOption["否"] = function () { };
                Power.ui.confirm(e.confirmtitle, { button: buttonOption });
            }
            else {
                dosend();
            }
        },
        //发送通知消息{to:"",cc:"",title:"",content:"",showconfirm:true,confirmtitle:"",fncallback:null}
        //base64encode 在 ComTools.js
        SendMail: function (e) {
            var p = { fromId: "", base64: "true", attachList: "" };
            p.ccList = e.cc || "";
            p.subject = e.title || "";
            p.toList = e.to || "";
            p.securitysend = e.security || "0";
            p.content = base64encode(e.content);
            if (e.showconfirm == undefined)
                e.showconfirm = true;
            e.confirmtitle = e.confirmtitle || "确定发送通知消息?";
            var dosend = function () {
                $.ajax({
                    url: "/Message/SendMail",
                    data: p,
                    type: "post",
                    success: function (text) {
                        var o = mini.decode(text);
                        if (e.fncallback) { e.fncallback(o); }
                        else {
                            if (o.success)
                                Power.form.success("邮件已发送");
                            else
                                Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                        }
                    }
                })
            }
            if (e.showconfirm) {
                var buttonOption = {};
                buttonOption["发送"] = {
                    theme: 'primary',
                    handler: function () { dosend(); }
                };
                buttonOption["否"] = function () { };
                Power.ui.confirm(e.confirmtitle, { button: buttonOption });
            }
            else {
                dosend();
            }
        },
        //获取自动登录 url 链接 e={type:"miniopen/tabs/newwindow", to:"", url:"", title:"", count:"",goto:"login/indexpage/open" fncallback:null}
        GetAutoLogUrl: function (e) {
            var p = { type: e.type, url: e.url, title: e.title, to: e.to };
            if (e.count) p.count = e.count;
            if (e.goto) p.goto = e.goto;
            $.ajax({
                url: "/API/GetAutoLogin",
                data: { config: mini.encode(p) },
                type: "post",
                success: function (text) {
                    var o = mini.decode(text);
                    if (e.fncallback) { e.fncallback(o); }
                }
            })
        },
        //获取workflowdata
        GetNewWorkFlowdData: function (e) {
            var WKeyWord = e.KeyWord;
            var WKeyValue = e.KeyValue;
            var WFormId = e.FormId;
            if (!WFormId) WFormId = "";
            $.ajax({
                url: "/WorkFlow/GetWorkFlowStatus",
                data: { "KeyWord": WKeyWord, "KeyValue": WKeyValue, "HtmlPath": WFormId },
                type: "post",
                success: function (text) {
                    var o = mini.decode(text);
                    if (e.fncallback) { e.fncallback(o); }
                }
            })
        },
        //将传进来的列转换成导出Excel需要的列信息
        GetExportXlsCol: function (cols) {
            var xlscols = [];
            //防止后面的操作会修改到columns,将columns拷贝一份
            var temp = [];
            for (var i = 0; i < cols.length; i++) temp.push(cols[i]);
            for (var i = 0; i < temp.length; i++) {
                var item = temp[i];
                if (!item.visible || item.type == "indexcolumn" || item.type == "checkcolumn")//没有绑定字段的列也不能导出excel
                    continue;
                if (item.columns != undefined) {
                    for (var j = 0; j < item.columns.length; j++)
                        temp.push(item.columns[j]);
                }
                var header = item.header;
                if (header != undefined && typeof (header) != "function")
                    header = header.replace("\\n", "").replace(/ /g, "").replace(/<br>/g, "");
                var node = { ID: item._id + "", ParentID: item._pid + "", Name: $.trim(header), Width: item.width };
                if (item.field) node.field = item.field;
                if (item.type == "comboboxcolumn" && item.editor) {
                    var idfd = item.editor.valueField || "id";
                    var txtfd = item.editor.textField || "text";
                    node.comboboxdata = [];
                    for (var j = 0; j < item._data.length; j++)
                        node.comboboxdata.push({ id: item._data[j][idfd], text: item._data[j][txtfd] });
                }
                if (item.dateFormat != null)
                    node.dateformat = item.dateFormat;
                if (item.numberFormat != null)
                    node.numberformat = item.numberFormat;
                if (item.currencyUnit != null)
                    node.currencyunit = item.currencyUnit;
                if (item.dataType != null)
                    node.datatype = item.dataType;
                xlscols.push(node);
            }
            return mini.arrayToTree(xlscols, "children", "ID", "ParentID"); //二维转为树型 comtools.convert 方法仅保留Name字段，方法有问题 
        },
        //导出到excel, xtype=all:导出全部,xtype=thispage:导出当前页
        ExportToXls: function (gridid, xtype, filename, fnonbeforeload, sort) {
            var tab = mini.get(gridid);
            var pg = mini.get(gridid + ".Pager");
            if (!pg) pg = tab;
            var config = funsself.GetConfig(gridid, null);
            var keywordtype = config.KeyWordType || "BO";
            var p = { sender: tab, params: { pageIndex: 0, sizeIndex: 0 } };
            //因为执行 OnBeforeLoad 方法获取where条件，不需要再这里额外处理，否则where条件可能与grid中查询结果不一致
            if (fnonbeforeload) fnonbeforeload(p);
            if (p.params.extparams) {
                p.params.extparams = base64decode(p.params.extparams);
                var tmp = mini.decode(p.params.extparams);
                if (tmp && tmp.encodeswhere && tmp.encodeswhere == "true") {
                    p.params.swhere = base64decode(p.params.swhere);
                    delete tmp.encodeswhere;
                    p.params.extparams = mini.encode(tmp);
                }
            }

            //获取表头信息（兼容多表头）
            //var columns = grid.getColumns();
            //columns已经被使用，此处更换成 columnsinfo;前面没有定义过grid，只有p.sender xuzhimin 2015-07-03 09:17:03
            //将列头信息转换成导出excel需要的格式，统一到 formfuns 中，webform.js也用到
            var excelColumns = funsself.GetExportXlsCol(p.sender.getColumns());

            var columns = "";
            var cols = tab.getBottomColumns();
            for (var i = 0; i < cols.length; i++) {
                if (cols[i].field != undefined) {
                    if (cols[i].header != undefined) {
                        var header = cols[i].header.replace("\\n", "").replace(/ /g, "").replace(/<br>/g, "");
                        columns += cols[i].field + " as '" + $.trim(header) + "',";
                    }
                    else
                        columns += cols[i].field + ",";
                }
            }
            if (columns.length > 0)
                columns = columns.substring(0, columns.length - 1);

            var json = { KeyWord: config.KeyWord, Columns: columns };
            json.FileName = (filename && filename.length > 0) ? filename : config.KeyWord;
            json.Where = p.params.swhere;
            json.extparams = p.params.extparams;
            json.StartIndex = (xtype == "thispage") ? pg.pageIndex * pg.pageSize : 0;
            json.MaxIndex = (xtype == "thispage") ? pg.pageSize : 0;
            if (sort != null && sort != "")
                json.Order = sort;
            else
                json.Order = (tab.sortField != "") ? tab.sortField + " " + tab.sortOrder : config.sort;
            json.Tree = funsself.IsMiniTree(tab);
            //默认 排序字段 倒序
            if ((json.Order == null || json.Order.length == 0) && config.sequfield && config.sequfield.length > 0)
                json.Order = config.sequfield + " desc";
            json.excelColumns = JSON.stringify(excelColumns);
            json.MenuId = Power.cookie.get("menuids") == null ? "" : Power.cookie.get("menuids");
            var encodejson = encodeURIComponent(mini.encode(json));
            postDataToServer("/Form/ExportFile", { json: encodejson, KeyWordType: keywordtype });
        },
        //AlEdit 2018年11月12日 14:19:28
        //导出到excel, grid固定data的数据
        AlExportDataToXls: function (gridid, filename, MergeColumns, groupfield, fnonbeforeload, headercolor, headerfontcolor, exporttype) {
            var tab = mini.get(gridid);
            if (tab == undefined) {
                Power.ui.warning("通过" + gridid + "没有找到Grid");
                return;
            }
            var p = { sender: tab };
            if (fnonbeforeload) fnonbeforeload(p);

            //获取表头信息（兼容多表头）
            //var columns = grid.getColumns();
            //columns已经被使用，此处更换成 columnsinfo;前面没有定义过grid，只有p.sender xuzhimin 2015-07-03 09:17:03
            //将列头信息转换成导出excel需要的格式，统一到 formfuns 中，webform.js也用到
            var excelColumns = funsself.GetExportXlsCol(p.sender.getColumns());
            var columns = "";
            var cols = tab.getBottomColumns();
            for (var i = 0; i < cols.length; i++) {
                if (cols[i].field != undefined) {
                    if (cols[i].header != undefined) {
                        var header = cols[i].header.replace("\\n", "").replace(/ /g, "").replace(/<br>/g, "");
                        columns += cols[i].field + " as '" + $.trim(header) + "',";
                    }
                    else
                        columns += cols[i].field + ",";
                }
            }
            if (columns.length > 0)
                columns = columns.substring(0, columns.length - 1);

            var data = tab.data;//默认获取grid的data

            if (funsself.IsMiniTree(tab)) {

                //如果是treegrid，按顺序获取treegrid中的全部子节点
                data = tab.getAllChildNodes();
                var newd = [];
                for (var i = 0; i < data.length; i++) {

                    var d = data[i];
                    var nd = {};
                    for (var item in d) {
                        if (item !== "children")
                            nd[item] = d[item];
                    }
                    newd.push(nd);

                }
                data = newd;
            }
            //如果有分组
            if (tab.getGroupingView() && tab.getGroupingView().length > 0) {
                var gd = tab.getGroupingView();
                var ds = [];
                var groupColumns = {};
                groupColumns.ID = "0";
                groupColumns.Name = "分组";
                groupColumns.ParentID = "-1";
                groupColumns.field = "SystemGroupField";
                excelColumns.unshift(groupColumns);//将分组列加到标题中
                //循环分组的数据
                for (var i = 0; i < gd.length; i++) {
                    var g = gd[i];
                    //得到分组的文字比如： 状态：新增
                    var d = comboboxdata[gridid + "." + g.field];
                    var fzl = "";
                    if (mini.get(gridid + "-group-fields"))
                        groupfield = mini.get(gridid + "-group-fields").getText();
                    var text = groupfield;
                    if (d) {
                        fzl = text + ":" + funsself.GetGroupText(g, d);
                    }
                    else if (mini.formatDate(g.value, "yyyy-MM-dd") != "") {
                        fzl = text + ":" + mini.formatDate(g.value, "yyyy-MM-dd");
                    }
                    else
                        fzl = text + ":" + g.value;

                    //将当前分组文字，插入第一行的分组列
                    var fz = g.rows[0];
                    fz["SystemGroupField"] = fzl;
                    ds.push(fz);
                    for (var j = 1; j < g.rows.length; j++) {

                        var gr = g.rows[j];
                        gr["SystemGroupField"] = "";//去掉原来的分组
                        ds.push(gr);
                    }
                }
                data = ds;
            }
            //检查每一列，看是否有汇总
            var SummaryColumns = null;
            for (var i = 0; i < cols.length; i++) {
                var c = cols[i];
                if (c.summaryType && c.summaryType != "") {
                    var s = tab.getSummaryCellEl(c.field);
                    var txt = $(s).text();
                    if (SummaryColumns == null) SummaryColumns = {};
                    SummaryColumns[c["name"]] = txt;
                }
            }
            if (SummaryColumns != null)
                data.push(SummaryColumns);
            //由于返回的值有Dirtys:{}导致导出失败，这里去掉
            for (var i = 0; i < data.length; i++) {
                data[i]["Dirtys"] = "";
            }
            var json = { datatable: data, Columns: columns };
            json.fileName = (filename && filename.length > 0) ? filename : "ExportPageData";
            json.headcolor = (headercolor && headercolor.length > 0) ? headercolor : "";
            json.headfontcolor = (headerfontcolor && headerfontcolor.length > 0) ? headerfontcolor : "";
            //传入类型为string[]
            var mergeColumns = (MergeColumns && MergeColumns.length > 0) ? MergeColumns : "";
            json.mergeColumns = mergeColumns.split(',');
            //json.GroupField = p.params.swhere;
            //json.SummaryColumns = p.params.extparams;  
            if (exporttype == "pdf")
                json.PDF = "1";
            json.excelColumns = JSON.stringify(excelColumns);

            json.menuid = Power.cookie.get("menuids") == null ? "" : Power.cookie.get("menuids");
            json.ispdf = false;
            var jsonPar = JSON.stringify(json);
            //调用Controller
            postDataToServer("/AlExport/DataTableToExcel", { json: jsonPar }, "_blank");
        },
        _ExportDataToXls: function (gridid, filename, MergeColumns, groupfield, fnonbeforeload, headercolor, headerfontcolor, exporttype) {
            var tab = mini.get(gridid);
            if (tab == undefined) {
                Power.ui.warning("通过" + gridid + "没有找到Grid");
                return;
            }
            var p = { sender: tab };
            if (fnonbeforeload) fnonbeforeload(p);

            //获取表头信息（兼容多表头）
            //var columns = grid.getColumns();
            //columns已经被使用，此处更换成 columnsinfo;前面没有定义过grid，只有p.sender xuzhimin 2015-07-03 09:17:03
            //将列头信息转换成导出excel需要的格式，统一到 formfuns 中，webform.js也用到
            var excelColumns = funsself.GetExportXlsCol(p.sender.getColumns());
            var columns = "";
            var cols = tab.getBottomColumns();
            for (var i = 0; i < cols.length; i++) {
                if (cols[i].field != undefined) {
                    if (cols[i].header != undefined) {
                        var header = cols[i].header.replace("\\n", "").replace(/ /g, "").replace(/<br>/g, "");
                        columns += cols[i].field + " as '" + $.trim(header) + "',";
                    }
                    else
                        columns += cols[i].field + ",";
                }
            }
            if (columns.length > 0)
                columns = columns.substring(0, columns.length - 1);

            var data = tab.data;//默认获取grid的data

            if (funsself.IsMiniTree(tab)) {

                //如果是treegrid，按顺序获取treegrid中的全部子节点
                data = tab.getAllChildNodes();
                var newd = [];
                for (var i = 0; i < data.length; i++) {

                    var d = data[i];
                    var nd = {};
                    for (var item in d) {
                        if (item !== "children")
                            nd[item] = d[item];
                    }
                    newd.push(nd);

                }
                data = newd;
            }
            //如果有分组
            if (tab.getGroupingView() && tab.getGroupingView().length > 0) {
                var gd = tab.getGroupingView();
                var ds = [];
                var groupColumns = {};
                groupColumns.ID = "0";
                groupColumns.Name = "分组";
                groupColumns.ParentID = "-1";
                groupColumns.field = "SystemGroupField";
                excelColumns.unshift(groupColumns);//将分组列加到标题中
                //循环分组的数据
                for (var i = 0; i < gd.length; i++) {
                    var g = gd[i];
                    //得到分组的文字比如： 状态：新增
                    var d = comboboxdata[gridid + "." + g.field];
                    var fzl = "";
                    if (mini.get(gridid + "-group-fields"))
                        groupfield = mini.get(gridid + "-group-fields").getText();
                    var text = groupfield;
                    if (d) {
                        fzl = text + ":" + funsself.GetGroupText(g, d);
                    }
                    else if (mini.formatDate(g.value, "yyyy-MM-dd") != "") {
                        fzl = text + ":" + mini.formatDate(g.value, "yyyy-MM-dd");
                    }
                    else
                        fzl = text + ":" + g.value;

                    //将当前分组文字，插入第一行的分组列
                    var fz = g.rows[0];
                    fz["SystemGroupField"] = fzl;
                    ds.push(fz);
                    for (var j = 1; j < g.rows.length; j++) {

                        var gr = g.rows[j];
                        gr["SystemGroupField"] = "";//去掉原来的分组
                        ds.push(gr);
                    }
                }
                data = ds;
            }
            //检查每一列，看是否有汇总
            var SummaryColumns = null;
            for (var i = 0; i < cols.length; i++) {
                var c = cols[i];
                if (c.summaryType && c.summaryType != "") {
                    var s = tab.getSummaryCellEl(c.field);
                    var txt = $(s).text();
                    if (SummaryColumns == null) SummaryColumns = {};
                    SummaryColumns[c["name"]] = txt;
                }
            }
            if (SummaryColumns != null)
                data.push(SummaryColumns);
            //由于返回的值有Dirtys:{}导致导出失败，这里去掉
            for (var i = 0; i < data.length; i++) {
                data[i]["Dirtys"] = "";
            }
            var json = { datatable: data, Columns: columns };
            json.fileName = (filename && filename.length > 0) ? filename : "ExportPageData";
            json.headcolor = (headercolor && headercolor.length > 0) ? headercolor : "";
            json.headfontcolor = (headerfontcolor && headerfontcolor.length > 0) ? headerfontcolor : "";
            //传入类型为string[]
            var mergeColumns = (MergeColumns && MergeColumns.length > 0) ? MergeColumns : "";
            json.mergeColumns = mergeColumns.split(',');
            //mini.get(gridid)._mergedCells -> MergeCells
            json.mergeCells=mini.get(gridid)._mergedCells;
            if(JSON.stringify(json.mergeCells)=="{}"){json.mergeCells=[{ rowIndex: mini.get(gridid).data.length, columnIndex: 0, rowSpan: 1, colSpan: 1 }]}
            //json.GroupField = p.params.swhere;
            //json.SummaryColumns = p.params.extparams;  
            if (exporttype == "pdf")
                json.PDF = "1";
            json.excelColumns = JSON.stringify(excelColumns);

            json.menuid = Power.cookie.get("menuids") == null ? "" : Power.cookie.get("menuids");
            json.ispdf = false;
            var jsonPar = JSON.stringify(json);
            //调用Controller
            // debugger;
            postDataToServer("/zyxExport/DataTableToExcel", { json: jsonPar }, "_blank");
        },
        //导出到excel, grid固定data的数据
        ExportDataToXls: function (gridid, filename, groupfield, fnonbeforeload, headercolor, headerfontcolor, exporttype) {
            // debugger;
            var tab = mini.get(gridid);
            if (tab == undefined) {
                Power.ui.warning("通过" + gridid + "没有找到Grid");
                return;
            }
            var p = { sender: tab };
            if (fnonbeforeload) fnonbeforeload(p);

            //获取表头信息（兼容多表头）
            //var columns = grid.getColumns();
            //columns已经被使用，此处更换成 columnsinfo;前面没有定义过grid，只有p.sender xuzhimin 2015-07-03 09:17:03
            //将列头信息转换成导出excel需要的格式，统一到 formfuns 中，webform.js也用到
            var excelColumns = funsself.GetExportXlsCol(p.sender.getColumns());
            var columns = "";
            var cols = tab.getBottomColumns();
            for (var i = 0; i < cols.length; i++) {
                if (cols[i].field != undefined) {
                    if (cols[i].header != undefined) {
                        var header = cols[i].header.replace("\\n", "").replace(/ /g, "").replace(/<br>/g, "");
                        columns += cols[i].field + " as '" + $.trim(header) + "',";
                    }
                    else
                        columns += cols[i].field + ",";
                }
            }
            if (columns.length > 0)
                columns = columns.substring(0, columns.length - 1);

            var data = tab.data;//默认获取grid的data

            if (funsself.IsMiniTree(tab)) {

                //如果是treegrid，按顺序获取treegrid中的全部子节点
                data = tab.getAllChildNodes();
                var newd = [];
                for (var i = 0; i < data.length; i++) {

                    var d = data[i];
                    var nd = {};
                    for (var item in d) {
                        if (item !== "children")
                            nd[item] = d[item];
                    }
                    newd.push(nd);

                }
                data = newd;
            }
            //如果有分组
            if (tab.getGroupingView() && tab.getGroupingView().length > 0) {
                var gd = tab.getGroupingView();
                var ds = [];
                var groupColumns = {};
                groupColumns.ID = "0";
                groupColumns.Name = "分组";
                groupColumns.ParentID = "-1";
                groupColumns.field = "SystemGroupField";
                excelColumns.unshift(groupColumns);//将分组列加到标题中
                //循环分组的数据
                for (var i = 0; i < gd.length; i++) {
                    var g = gd[i];
                    //得到分组的文字比如： 状态：新增
                    var d = comboboxdata[gridid + "." + g.field];
                    var fzl = "";
                    if (mini.get(gridid + "-group-fields"))
                        groupfield = mini.get(gridid + "-group-fields").getText();
                    var text = groupfield;
                    if (d) {
                        fzl = text + ":" + funsself.GetGroupText(g, d);
                    }
                    else if (mini.formatDate(g.value, "yyyy-MM-dd") != "") {
                        fzl = text + ":" + mini.formatDate(g.value, "yyyy-MM-dd");
                    }
                    else
                        fzl = text + ":" + g.value;

                    //将当前分组文字，插入第一行的分组列
                    var fz = g.rows[0];
                    fz["SystemGroupField"] = fzl;
                    ds.push(fz);
                    for (var j = 1; j < g.rows.length; j++) {

                        var gr = g.rows[j];
                        gr["SystemGroupField"] = "";//去掉原来的分组
                        ds.push(gr);
                    }
                }
                data = ds;
            }
            //检查每一列，看是否有汇总
            var SummaryColumns = null;
            for (var i = 0; i < cols.length; i++) {
                var c = cols[i];
                if (c.summaryType && c.summaryType != "") {
                    var s = tab.getSummaryCellEl(c.field);
                    var txt = $(s).text();
                    if (SummaryColumns == null) SummaryColumns = {};
                    SummaryColumns[c["name"]] = txt;
                }
            }
            if (SummaryColumns != null)
                data.push(SummaryColumns);
            //由于返回的值有Dirtys:{}导致导出失败，这里去掉
            for (var i = 0; i < data.length; i++) {
                data[i]["Dirtys"] = "";
            }
            var json = { Data: data, Columns: columns };
            json.FileName = (filename && filename.length > 0) ? filename : "ExportPageData";
            json.headColor = (headercolor && headercolor.length > 0) ? headercolor : "";
            json.headFontColor = (headerfontcolor && headerfontcolor.length > 0) ? headerfontcolor : "";
            //json.GroupField = p.params.swhere;
            //json.MergeColumns = p.params.extparams;  
            //json.SummaryColumns = p.params.extparams;  
            if (exporttype == "pdf")
                json.PDF = "1";
            json.excelColumns = JSON.stringify(excelColumns);

            json.MenuId = Power.cookie.get("menuids") == null ? "" : Power.cookie.get("menuids");
            var encodejson = encodeURIComponent(mini.encode(json));
            if (exporttype == "pdf") {
                postDataToServer("/Form/ExportPageData", { json: encodejson }, "_blank");
            }
            else
                postDataToServer("/Form/ExportPageData", { json: encodejson });
        },
        GetGroupText: function (e, data) {
            var value = data.ValueField;
            var text = data.TextField;
            for (var i = 0; i < data.Data.length; i++) {
                if (data.Data[i][value] == e.value)
                    return data.Data[i][text];
            }
        },
        //添加删除收藏{action:add/del, FormId:"", KeyWord:"", KeyValue:"", FormName:"", Name:"", fncallback:null}
        PostFavorite: function (e) {
            var p = { FormId: "", KeyWord: "", KeyValue: "", FormName: "" };
            if (e.FormId) p.FormId = e.FormId;
            if (e.KeyWord) p.KeyWord = e.KeyWord;
            if (e.KeyValue) p.KeyValue = e.KeyValue;
            if (e.FormName) p.FormName = e.FormName;
            if (e.Name) p.Name = e.Name;
            if (e.Url) p.Url = e.Url;
            var json = base64encode(mini.encode(p));
            var action = e.action || "add";
            $.ajax({
                url: "/Form/PostFavorite",
                data: { action: action, jsonData: json },
                type: "post",
                success: function (text) {
                    var o = mini.decode(text);
                    if (e.showmessage) {
                        if (!o.success)
                            Power.ui.error(o.message);
                        else {
                            if (action == "add") Power.ui.success("收藏成功");
                            if (action == "del") Power.ui.success("已删除收藏");
                        }
                    }
                    if (e.fncallback) e.fncallback(o)
                }
            });
        },
        //判断运行设备是手机
        DeviceIsPhone: function () {
            return (typeof (sessiondata) != "undefined" && sessiondata.DeviceInfo && sessiondata.DeviceInfo.IsPhone);
        },
        //初始化Pager控件样式
        InitPage: function (config, gridform) {
            if (!config)
                config = formconfig.config.joindata;
            if (!gridform)
                gridform = new FormFuns.layout();
            var pg = mini.get(config.miniid + ".Pager");
            if (pg) gridform.init(config.miniid);
            //递归设置子表
            if (!config.children || config.children.length == 0)
                return;
            for (var i = 0; i < config.children.length; i++)
                funsself.InitPage(config.children[i], gridform);
        },
        //判断是否可进行excel复制粘贴
        CopyExcel: function (config) {
            if (!config)
                config = formconfig.config.joindata;
            var miniid = config.miniid;
            var grid = funsself.GetMiniFormGrid(miniid);
            if (grid != undefined && funsself.IsMiniGrid(grid)) {
                if (grid.canImport != undefined && (grid.canImport == true || grid.canImport == "true"))
                    $("#" + miniid).keydown(function (event) { return cellkeydown(event, miniid) });
            }
            //递归设置子表
            if (!config.children || config.children.length == 0)
                return;
            for (var i = 0; i < config.children.length; i++)
                funsself.CopyExcel(config.children[i]);
        },
        //grid，tree选中行的时候执行
        NodeSelect: function (e) {
            var sender = e.sender;
            //读取子表数据
            //先把所有子表数据清空，再读取子表
            funsself.ClearChildData(sender.id);
            var cfg = funsself.GetConfig(sender.id, null);
            cfg.currow = e.node == undefined ? e.record : e.node;

            if (funsself.IsMiniTree(sender)) {
                //miniui如果有子节点已经加载会有children属性且children.count>0，如果节点 isLeaf=true，表示这个节点是叶子节点，不需要再加载子节点
                //导致子节点需要重新获取数据，如果tree是编辑状态下，miniui会将这些子节点标记为 removed，再在添加节点
                if ((sender.lazyload || sender.lazyload == "true") && (cfg.currow.isLeaf == undefined || cfg.currow.isLeaf == false)
                    && (cfg.currow.children == undefined || cfg.currow.children.length == 0)) {
                    sender.loadNode(cfg.currow);
                }
                funsself.LoadRight(sender.id, false);
                //懒加载时，先load子节点，在load当前选中的节点所对应子表的数据
                funsself.LoadChildData(sender.id);
                if (e.node != sender.getSelectedNode())
                    sender.selectNode(e.node, false);
            }
            if (funsself.IsMiniGrid(sender)) {
                //计算切换行后的权限
                funsself.LoadRight(sender.id, false);
                funsself.LoadChildData(sender.id);
                if (e.node != sender.getSelected())
                    sender.select(e.node, false);

            }
        },
        BindImportExcelBtn: function () {
            if (formconfig) {
                for (var f in formconfig) {
                    var config = formconfig[f];
                    if (config && config.type && config.type.toLowerCase() == "excel") {
                        var btntext = "<i class=\"fa fa-upload\"></i>导入Excel";
                        var ob = $("#" + f.replace(".", "\\."));
                        if (ob && typeof (ob.html) == "function" && ob.html() != "")
                            btntext = ob.html();
                        $("#" + f.replace(".", "\\.")).uploadify({
                            "height": 30,
                            fileSizeLimit: 0,
                            auto: true,
                            config: config,
                            button: f,
                            //fileTypeExts: "image/gif;application/msword",
                            blocksize: 2048 * 500, //分块大小
                            batfiles: 5,//批量上传最大文件数
                            "buttonText": btntext,
                            "swf": '/Scripts/plugins/uploadify/swfupload.swf',
                            "uploader": "/PowerPlat/Control/File.ashx?action=upload&uploadtype=ExcelImportService_System",
                            dragzone: ".container",
                            formData: function () {
                                var rec = {};
                                var config = this.config;
                                rec.KeyWord = formconfig.config.joindata.KeyWord;
                                rec.KeyValue = formconfig.KeyValue;
                                var p = funsself.GetParentConfig(this.button.split('.')[0]);
                                var c = funsself.GetConfig(this.button.split('.')[0]);
                                //有外键
                                if (p && c) {
                                    var sender = funsself.GetMiniFormGrid(p.miniid);
                                    for (var x in c.fields) {
                                        config.mainkey = x;
                                    }
                                    if (sender && funsself.IsMiniForm(sender)) {
                                        config.mainkeyvalue = formconfig.KeyValue;
                                    }
                                    if (sender && funsself.IsMiniGridTree(sender)) {
                                        if (sender.getSelected())
                                            config.mainkeyvalue = sender.getSelected()[sender.idField];
                                    }
                                }
                                rec.config = base64encode(mini.encode(config));
                                //找到所有的下拉框数据源，进行传递
                                if (comboboxdata && comboboxdata != "")
                                    rec.comboboxdata = base64encode(mini.encode(comboboxdata));
                                else
                                    rec.comboboxdata = "";
                                return rec;
                            },
                            onUploadStart: function () {
                                Power.ui.loading("Loading...");
                            },
                            onDialogClose: function () {
                                if (formconfig.FormState == "add") {
                                    Power.ui.alert("请先保存主表");
                                    return false;
                                }
                                var p = funsself.GetParentConfig(this.button.split('.')[0]);
                                if (p) {
                                    var sender = mini.get(p.miniid);
                                    if (sender && funsself.IsMiniGridTree(sender)) {
                                        if (!sender.getSelected()) {
                                            Power.ui.alert("请选择父表行");
                                            return false;
                                        }
                                    }
                                }
                            },
                            onUploadComplete: function (file, responseText, fileId) {
                                Power.ui.loading.close();
                                mini.get(this.config.miniid).reload();
                            },
                            onUploadError: function (file, responseText) {
                                Power.ui.loading.close();
                                mini.get(this.config.miniid).reload();
                            }
                        });
                        $(".uploadify-button").addClass("btn").addClass("btn-primary");
                    }
                }
            }

        },
        //清除所有子表的数据
        ClearChildData: function (miniid) {
            var config = FormFuns.GetConfig(miniid, null);
            if (!config || !config.children || config.children.length == 0)
                return;
            for (var i = 0; i < config.children.length; i++) {
                var cc = config.children[i];
                var sender = funsself.GetMiniFormGrid(cc.miniid);
                if (!sender) continue;
                //如果当前节点是grid，清除子表数据
                if (funsself.IsMiniGrid(sender)) {
                    sender.setPageIndex(0);
                    sender.setData([]);
                    sender.setTotalCount(0);
                    funsself.ClearChildData(sender.id);
                }
                else if (funsself.IsMiniTree(sender)) {
                    sender.loadList([]);
                    funsself.ClearChildData(sender.id);
                }
            }
        },
        SetAttachFileCount: function (count) {
            if (mini.get("maintabs") != undefined && mini.get("maintabs").getTab("attachfile") != null) {
                if (count != "" || count == 0) {
                    var at = mini.get("maintabs").getTab("attachfile").title;
                    if (at.indexOf('(') > 0)
                        at = at.substring(0, at.indexOf('('));
                    var title = at + "(" + count + ")"
                    mini.get("maintabs").updateTab(mini.get("maintabs").getTab("attachfile"), { title: title });
                }
            }
            if (mini.get("maintabs") != undefined && mini.get("maintabs").getTab("attachfiletemplate") != null) {
                if (count != "" || count == 0) {
                    var at = mini.get("maintabs").getTab("attachfiletemplate").title;
                    if (at.indexOf('(') > 0)
                        at = at.substring(0, at.indexOf('('));
                    var title = at + "(" + count + ")"
                    mini.get("maintabs").updateTab(mini.get("maintabs").getTab("attachfiletemplate"), { title: title });
                }
            }
        },
        SetRecLinkCount: function (count) {
            if (mini.get("maintabs") != undefined && mini.get("maintabs").getTab("reclink") != null) {
                if (count != "" || count == 0) {
                    var at = mini.get("maintabs").getTab("reclink").title;
                    if (at.indexOf('(') > 0)
                        at = at.substring(0, at.indexOf('('));
                    var title = at + "(" + count + ")"
                    mini.get("maintabs").updateTab(mini.get("maintabs").getTab("reclink"), { title: title });
                }
            }
        },
        ReplaceWhere: function (o, data) {
            if (typeof (data) == "object") {
                for (var key in data.currow) {
                    if (typeof (key) != "function") {
                        var bl = "[@" + data.KeyWord + "." + key + "]";
                        o.swhere = o.swhere.replace(bl, data.currow[key]);
                    }
                }
                for (var i = 0; i < data.children.length; i++) {
                    funsself.ReplaceWhere(o, data.children[i]);
                }
            }
        },
        //API封装方法
        APIExec: function (keyword, keywordtype, methodname, params, fncallback) {
            var exec = {};  //对象
            exec.KeyWord = keyword;   //bo的KeyWord
            exec.MethodName = methodname; //方法名称
            if (keywordtype != undefined)
                exec.KeyWordType = keywordtype;
            //如果是数据集的话，要加上 exec.KeyWordType="ViewEntity";
            exec.MethodParams = params;
            var txt = mini.encode(exec); //对象转换成字符串
            $.ajax({
                url: "/API/Exec",
                type: "POST",
                data: { jsonData: txt }, //对象字符串传递给 jsonData变量
                cache: false,
                success: function (text) {
                    if (fncallback != undefined)
                        fncallback(text);
                }
            });
        },
        //由于手机浏览器解析mini-fit错误，表单上调用该方法，重置table上form的高度，使table可以上下滑动
        //singleform中多个 portlet box导致高度计算不正确，需要重算，如左右结构等
        //NVeolcityHelper.HtmlConverToMobile 中补充 FormFuns.SetTableFormHight();
        SetTableFormHight: function () {
            //if (window.innerHeight < window.parent.innerHeight) return;
            var tbs = $("table.phone");
            if (tbs && tbs.length > 0) {
                var getNodeHight = function (node) {
                    var pnode = node.parentNode;
                    var h = 0;
                    if (pnode == document.body) {
                        var ifs = window.parent.$.find("iframe");
                        for (var i = 0; i < ifs.length; i++) {
                            if (ifs[i].contentWindow == window) {
                                h = $(ifs[i]).parent().height();
                                break;
                            }
                        }
                    }
                    else
                        h = getNodeHight(pnode);
                    var pchild = mini.getChildNodes(pnode);
                    if (pchild.length > 1) {
                        for (var i = 0; i < pchild.length; i++) {
                            if (pchild[i] == node) continue;
                            h = h - mini.getHeight(pchild[i]);
                        }
                    }
                    return h;
                }

                for (var i = 0; i < tbs.length; i++) {
                    var tb = tbs[i];
                    if (!tb.parentNode || tb.parentNode.className.toLowerCase() != "form")
                        continue;
                    var h = getNodeHight(tb.parentNode) + "px";
                    $(tb.parentNode).css("height", h);
                }
            }
            var box = $("div.portlet-body.phone");
            if (box && box.length == 2) //默认是200高度,=2时重算，50%高度
            {
                var ih = parseInt(window.innerHeight / 2) - 40 + "px";
                $(box[0]).css("height", ih);
                $(box[1]).css("height", ih);
            }
        },
        //返回右上角查询框组成的where条件
        //miniid=grid.id, property = grid绑定bo的bo信息, gridpageload加载时获取到
        GetSearchFieldsWhere: function (miniid) {
            var swhere = "";
            var fdsearch = mini.get(miniid + "-search-fields");
            var fdsearch_d = mini.get(miniid + "-search-fields-d");
            if ((!fdsearch && !fdsearch_d) || !fdsearch._boproperty)
                return swhere;

            var edtvalue = mini.get(miniid + "-search-value");
            var edtvalue_d = mini.get(miniid + "-search-value-d")

            var property = fdsearch._boproperty;
            var field = fdsearch.getValue();
            var value = edtvalue.getValue();
            if (value == "")
                return swhere;
            if (property[field] != undefined && property[field] == "DateTime" && (value != "" || edtvalue_d.getFormValue())) {
                value = edtvalue.getFormValue();
                var value2 = edtvalue_d.getFormValue();
                if (value)
                    swhere = swhere + " and " + field + " >='" + value + "'";
                if (value2)
                    swhere = swhere + " and " + field + " <='" + value2 + " 23:59:59.999'";
            }
            else if (edtvalue.type == "combobox" && value != "") {
                var re = new RegExp(",", "g"); //定义正则表达式
                swhere = swhere + " and " + field + " in ('" + value.replace(re, "','") + "')";
            }
            else if (property[field] != undefined && property[field] != "String" && value != "") {
                value = edtvalue.getFormValue();
                var value2 = edtvalue_d.getFormValue();
                if (value)
                    swhere = swhere + " and " + field + " >=" + value;
                if (value2)
                    swhere = swhere + " and " + field + " <=" + value2;

            }
            else if (property[field] != undefined)
                swhere = swhere + " and " + field + " like '%" + value + "%'";


            return swhere;

        },
        //将属性绑定到右上角查询框中
        //miniid=grid.id, property = grid绑定bo的bo信息, gridpageload加载时获取到
        SetSearchFieldsData: function (miniid, property) {
            if (!property) return;
            var fdsearch = mini.get(miniid + "-search-fields");
            if (fdsearch == undefined || fdsearch == null)
                return;
            fdsearch._boproperty = property;
            var rcurrentgrid = funsself.ParseGridAllHeader(miniid);
            if (!rcurrentgrid || rcurrentgrid.length == 0)
                return;
            var searchfields = "[";
            for (var i = 0; i < rcurrentgrid.length; i++) {
                if (rcurrentgrid[i].type != "indexcolumn" && rcurrentgrid[i].type != "checkcolumn" && rcurrentgrid[i].visible)
                    if (property[rcurrentgrid[i].field] != undefined && property[rcurrentgrid[i].field] != "Guid")
                        searchfields += "{\"id\":\"" + rcurrentgrid[i].field + "\",\"text\":\"" + rcurrentgrid[i].header + "\"},";
            }
            if (searchfields.length > 1) {
                searchfields = searchfields.substring(0, searchfields.length - 1) + "]";
                fdsearch.setData(searchfields);
            }
        },
        //返回指定grid的所有列头信息,miniid=grid.id
        ParseGridAllHeader: function (miniid) {
            var rlt = [];
            var fnloop = function (cols) {
                for (var i = 0, j = cols.length; i < j; i++) {
                    if (cols[i].field == undefined || cols[i].field == "") {
                        if (cols[i].columns && cols[i].columns.length > 0)
                            fnloop(cols[i].columns);
                    }
                    else
                        rlt.push(cols[i]);
                }
            }
            var grid = mini.get(miniid);
            if (grid)
                fnloop(grid.columns);
            return rlt;
        },
        SearchComboboxClose: function (e) {
            var obj = e.sender;
            obj.setText("");
            obj.setValue("");
            var id = e.sender.id.replace("fields", "value");
            if (mini.get(id)) {
                //debugger;
                //mini.get(id).setText("");
                mini.get(id).setValue("");
            }
        }
    }
}();

//重置datagrid自定义分页显示高度 add by 舒鲜阳
FormFuns.layout = function () {

    function doLayout(gridId) {
        var
			custGrid = mini.get(gridId),
			$custGrid = $(custGrid.el),
			$custPager = $custGrid.next(".mini-pager").addClass("mini-grid-pager"),
			gridTop = $custGrid.offset().top,
			pagerHeight = $custPager.length ? $custPager.outerHeight() : 0,
			clientHeight = (window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight) - parseInt(gridTop);

        var c = mini.findControls(function (e) {
            if (e.type == "tabs") return true;
        })
        if (c.length > 0)
            return custGrid.setHeight(clientHeight - pagerHeight - 5 - 20);
        else
            return custGrid.setHeight(clientHeight - pagerHeight - 5);

    }

    var resize_timer;
    var gridId = null;

    function resizeHandler() {
        if (resize_timer) {
            clearTimeout(resize_timer);
        }
        resize_timer = setTimeout(function () {
            doLayout(gridId);
        }, 80);
    }

    function init(id) {
        doLayout(gridId = id);
        $(window).on("resize", resizeHandler);
    }

    function destroy() {
        $(window).off("resize", resizeHandler);
    }

    return {
        init: init,
        destroy: destroy
    }

};
//提醒付款
function SendToPay(key){
    // Power.ui.success("(●'◡'●)");
    mini.open({
        url: "/PowerPlat/WorkFlows/Commons/SelectUser.html",
        title: '人员选择', width: "800px", height: "600px",
        allowDrag: true, allowResize: true, showCloseButton: true, showMaxButton: true, showModal: true, showInBody: true,
        onload: function () {
            var iframe = this.getIFrameEl();
            var tmpNode = {};
            tmpNode.SourceMode = "DeptAndUser";   //默认是选择部门 
            tmpNode.AllowRestore = false;    //是否最后要返还给本人
            tmpNode.AllowMulitUser = true;   //是否允许选择多人
            tmpNode.WorkInfoID = workInfoID;
            iframe.contentWindow.SetData(tmpNode, []);
        },
        ondestroy: function (action) {
            if (action != "ok") return;
            var iframe = this.getIFrameEl();

            var userList = iframe.contentWindow.GetData();
            userList = mini.clone(userList);
            if (userList.length == 0) {
                Power.ui.error("未捕获到任何用户");
                return;
            }
            //转成json传入控制器
            if(formconfig && formconfig.KeyValue)
            {
                //执行contorl方法
                $.ajax({
                    url: "/Al/SendToPay",
                    data: {
                        userlist: JSON.stringify(userList),
                        formid: FormId,
                        keyvalue:formconfig.KeyValue,
                        InvoiceId:formconfig.config.joindata.currow.Id,
                        InvoiceCode:formconfig.config.joindata.currow.Code,
                        InvoiceTitle:formconfig.config.joindata.currow.Title,
                        SubContractId:formconfig.config.joindata.currow.SubContract_Guid,
                        SubContractCode:formconfig.config.joindata.currow.SubContractCode,
                        SubContractTitle:formconfig.config.joindata.currow.SubContractName,
                        SubContractType:formconfig.config.joindata.currow.SubContractType,
                    },
                    type: "POST",
                    success: function (text) {
                        var o = mini.decode(text);
                        if (o=="") {
                            Power.ui.success("已提醒接收人");
                        }
                        else
                        {
                            Power.ui.error("异常信息，请联系管理员");
                        }
                    }
                });    
            }
        }
    });
}
//删除流程 按钮事件
function zyxReturnBtn(KeyWord){
    if(formconfig.FormId&&formconfig.KeyValue){
        // debugger;
        //信息存进数据库表 DeleteWorkFlow
        var data = { "FormId": formconfig.FormId, 
                     "KeyWord": KeyWord.id,
                     "KeyValue": formconfig.KeyValue,
                     "HumanId": sessiondata.HumanId,
                     "HumanName": sessiondata.HumanName}
        Power.ui.confirm("系统将<a style='color:red;font-weight:bold;'>记录</a>您的信息，</br>确定执行吗?", function (action) {
            if (action){
                $.ajax({
                    url: "/zyx/DeleteWorkFlow",
                    data: data,
                    type: "POST",
                    success: function (text) {
                        if(text==""){Power.ui.alert("删除成功，请关闭单据重新打开!");}
                    }
                });
            }
        });
    }
}
//删除打印记录
function delPrintRecord(_KeyWord){
    //合同付款申请
    if( _KeyWord && _KeyWord=="PS_SubContractApplyMoney"){
        // debugger;
        if(formconfig && formconfig.KeyValue){
            var data = { "KeyWord": _KeyWord,"KeyValue": formconfig.KeyValue}
            Power.ui.confirm("系统将<a style='color:red;font-weight:bold;'>删除</a>打印记录!</br>确定执行吗?", function (action) {
                if (action){
                    $.ajax({
                        url: "/zyx/DeletePrintRecord",
                        data: data,
                        type: "POST",
                        success: function (text) {
                            if(text==""){Power.ui.success("删除成功!");}
                        }
                    });
                }
            });
        }
    }
}
//渲染 附件tab(附件数、url链接)
function LoadContractAttachfile(_KeyWord,_KeyValue,_tabName){
    // debugger;
    var mtabs = mini.get("maintabs");
    if (mtabs != undefined) {
        var tmptab = mtabs.getTab(_tabName);
        if (tmptab) {
            var effected = formconfig.Effected;
            var upddata = { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/getFileOperate.htm&KeyWord=" + _KeyWord 
                            + "&KeyValue=" + _KeyValue
                            + "&canEdit=false" };
            mtabs.updateTab(tmptab, upddata);
            mtabs.reloadTab(tmptab);
            if (_KeyValue != "") {
                $.ajax({
                    url: "/Form/GetFileCount",
                    data: { KeyWord: _KeyWord, KeyValue: _KeyValue },
                    success: function (text) {
                        var t = mini.decode(text);
                        var at = mini.get("maintabs").getTab(_tabName).title;
                        if (at.indexOf('(') > 0)
                            at = at.substring(0, at.indexOf('('));
                        var title = at + "(" + t.data.value + ")";
                        // debugger;
                        mini.get("maintabs").updateTab(mini.get("maintabs").getTab(_tabName), { title: title });
                    }
                })
            }
        }
    }
}

function EditAll(){
    //主表
    Power.ui.info("当前登录人为:"+sessiondata.HumanName+"，最高编辑权限");
    var propertys = formconfig.config.joindata.currow;
    var propertyslength = Object.keys(propertys);
    var mainKeyWord = formconfig.config.joindata.miniid;
    //保存按钮
    mini.get(mainKeyWord+".Save").enable();
    // mini.get("SF_ProjectMessage_List.Delete").enable();
    //主表字段
    for(var i =0;i<propertyslength.length;i++)
    {
        if(mini.get(mainKeyWord+"."+propertyslength[i]))
        {
            mini.get(mainKeyWord+"."+propertyslength[i]).setReadOnly(false);
        }
    }
    //子表
    var childrenid = formconfig.config.joindata.children;
    for(var t=0;t<childrenid.length;t++)
    {
        var childname = childrenid[t].miniid;
        if(mini.get(childname+".Add"))
        {
            mini.get(childname+".Add").enable();
        }
        if(mini.get(childname+".Delete"))
        {
            mini.get(childname+".Delete").enable();
        }
        var g = mini.get(childname);
        if (g && g.columns.length > 0) {
            var columns = [];
            funsself.GetTreeGridAllHeaders(g.columns, columns);
                for (var i = 0; i < columns.length; i++) {
                    columns[i].readOnly = false;
            }
        }
    }
    //附件
    var mtabs = mini.get("maintabs");
    if (mtabs != undefined) {
        var mkeyword = mainKeyWord;
        var mkeyvalue = KeyValue;
        var tmptab = mtabs.getTab("attachfile");
        if (tmptab) {
            var effected = formconfig.Effected;
            var upddata = { url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/FileOperate.htm&KeyWord=" + mkeyword + "&KeyValue=" + mkeyvalue };
            upddata.url += "&canEdit=true";//允许编辑附件页面
            mtabs.updateTab(tmptab, upddata);
            mtabs.reloadTab(tmptab);
        }
    }
    // formconfig.FormState = "add";
}