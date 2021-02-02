//部分js 因在 NodeProperty.html /WorkFlowConfig.html 等中有重复，故提取放入当前文件中

//公共静态方法
var WorkFlowConfigureUtil = function() {
    var ConfigMode = "";  //加载模式， Golbal: 全局定义，此时不能选择“默认行为"\
  
    var NotifySelected = {};
    var NotifyDefaultList = [];

    function isArray(obj) { 
        return Object.prototype.toString.call(obj) === '[object Array]'; 
    }

    var getSelectedValue = function (gridid, code, name) {
        var rdoList = document.getElementsByName(code + '_' + name + '_' + gridid);
        if (!rdoList) {
            alert("严重异常，通过[" + code + '_' + name + '_' + gridid + "]无法获取到radio对象");
            return;
        }
        for (var i = 0; i < rdoList.length; i++) {
            if (rdoList[i].checked) { 
                return rdoList[i].value
            }
        } 
        return null;
    }

    //isDefault = true ,说明任何项都得设置值
    var getItem = function (gridid, dataList,isDefault) {
 
        var result = [];
        var len = dataList.length;
        if (!isDefault) isDefault = false;
        
        for (var irow = 0; irow < len; irow++) {
            var data = dataList[irow];
           
            var columnList = data.ColumnList;
            for (var icol = 0; icol < columnList.length; icol++) {
                var column = columnList[icol];
                column.Code = data.Code;
                if (isDefault == false && column.SelectedValue == "DefaultOperate") continue; //如果是听从上级配置安排，则无须保存
                column.SelectedValue = getSelectedValue(gridid,column.Code,column.Name);
                if (!column.SelectedValue) {
                    alert("取值[" + gridid + "." + column.Code + "]失败");
                    return;
                }
                result.push(column);
            }  
        }
        return result;
    }
    //isDefault = true ,说明任何项都得设置值
    var setItem = function (dataList, selectedList ) {
        var result = [];
        var len = dataList.length;
        var selLen = selectedList.length;
      
        
        for (var irow = 0; irow < len; irow++) {
            var data = dataList[irow];
            var sSelectedValue = "";
            var sSelectedName = "";
            for (var icol = 0; icol < selLen; icol++) {
                if (selectedList[icol].Code != data.Code) continue;
                if (!selectedList[icol].SelectedValue) continue;
                sSelectedName = selectedList[icol].Name;
                sSelectedValue = selectedList[icol].SelectedValue;
                break;
            }
            if (!sSelectedName) continue;

            for (var icol = 0; icol < data.ColumnList.length; icol++) {
                var column = data.ColumnList[icol];
                if (column.Name != sSelectedName) continue;
                column.SelectedValue = sSelectedValue;
                break;
            } 
        }
        return result;
    }
    return { 

        //加载配置
        LoadConfigure: function (configMode,msg,saveData,callback) {
            ConfigMode = configMode;   //加载模式， Golbal: 全局定义，此时不能选择“默认行为"
             
            mini.mask({
                el: document.body,
                cls: 'mini-mask-loading',

                html: '加载中...'
            });
            $.ajax({
                type: "POST",
                url: "/API/APIMessage",
                data: { json: mini.encode(msg) },
                dataType: "json",
                success: function (data) {
                    
                    mini.unmask(document.body);
                    var result = mini.decode(data);
                    if (result.success == false) {
                        alert(result.message);
                        return;
                    }
                    if (ConfigMode !="Node" && !gdWorkFlowList) {
                        alert("列表【gdWorkFlowList】不存在"); return;
                    }
                    if (!gdWorkNodeList) {
                        alert("列表【gdWorkNodeList】不存在"); return;
                    }
                    if (!gdNotifyList) {
                        alert("列表【gdNotifyList】不存在"); return;
                    } 
                    var tmpData = mini.decode(result.data.ResultInfo);
                    var tmpSaveData = {};
                    if (ConfigMode == "Node")
                        tmpSaveData = saveData;
                    else
                        tmpSaveData = mini.decode(result.data.SaveInfo);
                    if (!tmpSaveData)  tmpSaveData = {}; 
                    if (!tmpSaveData.WorkFlowSelected) tmpSaveData.WorkFlowSelected = [];
                    if (!tmpSaveData.WorkNodeSelected) tmpSaveData.WorkNodeSelected = [];
                    if (!tmpSaveData.NotifySelected) tmpSaveData.NotifySelected = {};
                     
                    if (isArray(tmpSaveData.NotifySelected)==true) tmpSaveData.NotifySelected = {};  //如果是数组，切换成对象
                     
                    if (ConfigMode !="Node") setItem(tmpData.CanWorkFlowList, tmpSaveData.WorkFlowSelected);
                    setItem(tmpData.CanWorkNodeList, tmpSaveData.WorkNodeSelected);
                     
                    if (ConfigMode != "Node") {
                        gdWorkFlowList.setData(tmpData.CanWorkFlowList);
                    }

                    if (tmpSaveData.NotifySelected) {
                        NotifySelected = mini.decode(tmpSaveData.NotifySelected);
                    }
                    
                    //过滤掉  属性为IsAllowNotify 的记录，这些行不可定义通知信息
                    var tmpLst = [];
                    var OperateLst = mini.decode(result.data.FlowOperateList);
                    for (var irow = 0; irow < OperateLst.length; irow++) {
                        if (OperateLst[irow].IsAllowNotify == false) continue;
                        if (NotifySelected[OperateLst[irow].Code]) OperateLst[irow].IsReset = true;
                        tmpLst.push(OperateLst[irow]);
                    }
                    
                    gdFlowOperate.setData(tmpLst);
                    gdWorkNodeList.setData(tmpData.CanWorkNodeList);
                     
                    NotifyDefaultList = mini.clone( tmpData.NotifyList);  //保存默认值信息
                    gdNotifyList.setData(tmpData.NotifyList);
                    gdNotifyList.setEnabled(false);
                 
                   
                    if (callback) callback(tmpData);
                  
                },
                error: function (e, r, h) {
                    alert(e.responseText, "错误！", "info");
                }
            }); 
        },
        
        ondrawcell :function(e) {
            var grid = e.sender,
                record = e.record,
                column = e.column,
                field = e.field, 
                ColumnList = record.ColumnList;
            var self = this;
            var gridid = grid.id;

            var createRedioList = function (record, ItemList, column,gridid) {
                if (!ItemList) return "";
                var html = "";
                if (column.Label)
                    html += '<label  >' + column.Label +':&nbsp;&nbsp; </label>';
                
           
                for (var i = 0, l = ItemList.length; i < l; i++) {
                    var fn = ItemList[i];

                    var checked = null;
                    var clickRadio = 'configureUtil.radioFunc(\'' + grid.id + '\', \'' + record.Code + '\',\'' + column.Name + '\',\'' + fn.Code + '\', this.checked)';


                    if (column.SelectedValue)
                        checked = fn.Code == column.SelectedValue ? 'checked' : '';
                    else
                        checked = fn.Code == column.DefaultOperate ? 'checked' : '';


                    html += '<label class="function-item"><input onclick="' + clickRadio + '" value="' + fn.Code + '"  type="radio" name="' + record.Code + '_' + column.Name + '_' + gridid + '" ' + checked + ' />' + fn.Text + '</label>&nbsp;&nbsp;';
                }
                return html;
            }
             
            if (field == 'ColumnList') {
                var result = '';
                if (!ColumnList) return;
               
                for (irow =0;irow < ColumnList.length;irow ++)
                {
                    if (irow > 0) result += '<div style="width:100%; height:2px; border-top:1px solid #999; clear:both;"></div>';
                    var column = ColumnList[irow];
                    var ItemList = record[column.Name]; 
                    result += createRedioList(record, ItemList, column, gridid);
                }
                e.cellHtml = result;
            }
        },
        getItemList: function () {
            var workFlowSelected = null;
            if (ConfigMode != "Node") {
                var workFlowData = gdWorkFlowList.getData();
                workFlowSelected = getItem(gdWorkFlowList.id,workFlowData);
            }
            var workNodeData = gdWorkNodeList.getData();
            var workNodeSelected = getItem(gdWorkNodeList.id,workNodeData);
            
            ////过滤筛选掉 默认选项，让返回的对象尽量小一点
            //var tmpNotifySelected = {};
            //for (var p in NotifySelected) {
            //    if (!NotifySelected[p]) continue;

            //    var tmpLst = NotifySelected[p];
            //    var tmpObj =[];
            //    for (var irow = 0; irow < tmpLst.length; irow++) {
            //        if (tmpLst[irow].SelectedValue == "DefaultOperate") continue;
            //        tmpObj.push(tmpLst[irow]);
            //    }
            //    if (tmpObj.length == 0) continue;
            //    tmpNotifySelected[p] = tmpObj;
            //}
            
            return { "WorkFlowSelected": workFlowSelected, "WorkNodeSelected": workNodeSelected, "NotifySelected": NotifySelected };
        },
        radioFunc: function (gridId, code, columnName, operate, checked) {
             
            var grid = mini.get(gridId);
            if (grid.getEnabled() == false) return;  //禁用的grid直接返回

            var record = grid.getRecord(code);
            if (!record) return;
            var ColumnList = record.ColumnList;
            var column = null;
            for (var irow = 0; irow < ColumnList.length; irow++) {
                if (ColumnList[irow].Name != columnName) continue;
                column = ColumnList[irow];
                break;
            }
            if (!column ) return;

            var ItemList = record[columnName];

            if (!ItemList) return;
            

            function getAction(Code) {
                for (var i = 0, l = ItemList.length; i < l; i++) {
                    var o = ItemList[i];
                    if (o.Code == Code) return o;
                }
            }
            var obj = getAction(operate);
            if (!obj) return;
            obj.checked = checked;
            column.SelectedValue = obj.Code;
            column.SelectedText = obj.Text;
             
            if (gridId == "gdNotifyList") {
                var flowOpearteRow = gdFlowOperate.getSelected();
                if (!flowOpearteRow) {
                    alert("当前没有选中操作场景，无法设置"); return;
                }
                
                var notifyData = gdNotifyList.getData(); 
                NotifySelected[flowOpearteRow.Code] = mini.clone(getItem(gdNotifyList.id, notifyData, true));
                gdFlowOperate.updateRow(flowOpearteRow, {"IsReset":true});
               // mini.get("txtMero").setValue(mini.encode(NotifySelected));
            }
        },

        //加载通知域信息
        LoadNotifyList: function (flowOperate) {
            gdNotifyList.setEnabled(true);
            
            if (NotifySelected[flowOperate]) {
                gdNotifyList.setData(mini.clone(NotifyDefaultList));  //先设置回默认项
                var notifyData = gdNotifyList.getData();
                setItem(notifyData, NotifySelected[flowOperate] );
                gdNotifyList.setData(notifyData);
            }
            else { 
                gdNotifyList.setData(mini.clone(NotifyDefaultList)); 
            }
           
          //  mini.get("txtMero").setValue(mini.encode(NotifySelected));
        },

        ResetFlowOperate: function (flowOperate) {
            if (!NotifySelected[flowOperate]) return;

            var flowOpearteRow = gdFlowOperate.getSelected();
            if (!flowOpearteRow) {
                alert("当前没有选中操作场景，无法设置"); return;
            }
            delete NotifySelected[flowOperate];
            gdNotifyList.setData(mini.clone(NotifyDefaultList));
            gdFlowOperate.updateRow(flowOpearteRow, { "IsReset": false });             
        }
    }

}