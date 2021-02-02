﻿var ControlCenter = function () {
    var CurrentSender = null;   //当前触发的对象
    var dataStatus = {};  //信息状态，由该包判断是否所有的信息都准备完毕
    var postInfo = {};   //提交数据包

    var reloadForm = function () {
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

    //如果绑定了工作流体系，则设定工作流按钮
    var SetFlowResult = function (currentResult) {



        var canFlowOperate = currentResult.CanFlowOperate;
        if (!mini.get("txtCurrentWorkInfoID")) {
            alert("没有找到对象[txtCurrentWorkInfoID]，请绘制");
            return;
        }

        if (currentResult.WorkInfoID) mini.get("txtCurrentWorkInfoID").setValue(currentResult.WorkInfoID);
        if (currentResult.SequeID) mini.get("txtCurrentSequeID").setValue(currentResult.SequeID);

        var buttons = ["Active", "Send", "BatchSends", "Return", "GetBack", "Stop", "ShowMonitor"];   //, "HangUp", "UnHangUp", "DelayDate", "UnEndFlow"

        for (var irow = 0; irow < buttons.length; irow++) {
            var name = buttons[irow];
            if ($("#btn" + name).length==0) continue;
            $("#btn" + name).css("display", (canFlowOperate & ECanFlowOperate[name]) > 0 ? "" : "none");
            //mini.get("btn" + name).setEnabled((canFlowOperate & ECanFlowOperate[name]) > 0);
            //mini.get("btn" + name).setVisible((canFlowOperate & ECanFlowOperate[name]) > 0);
        }

        //if (mini.get("btnDelegate")) {
        //    mini.get("btnDelegate").setEnabled((canFlowOperate & ECanFlowOperate.Delegate) > 0 || (canFlowOperate & ECanFlowOperate.Delegateing) > 0);
        //    mini.get("btnDelegate").setVisible((canFlowOperate & ECanFlowOperate.Delegate) > 0 || (canFlowOperate & ECanFlowOperate.Delegateing) > 0);
        //}

        if ($('#btnShowMonitor')) {
            if ((canFlowOperate & ECanFlowOperate.ShowMonitor) > 0)
                $('#btnShowMonitor').show();
            else
                $('#btnShowMonitor').hide(); 
            if (currentResult.CanFlowList["ShowMonitor"]) {
                var fnShowMonitor = function () {
                    var data = {};
                    data.WorkInfoID = currentResult.CanFlowList["ShowMonitor"].WorkInfoID;
                    onExecuteMonitor(this, 'ShowMonitor', data);   //显示监控
                    return false;
                }
                $("#btnShowMonitor").unbind("click").bind("click", fnShowMonitor);
            }
        }


        //if (currentResult.CanFlowList["ShowHistoryMonitor"] && mini.get("btnShowHistoryMonitor")) {

        //    var tmpLst = currentResult.CanFlowList["ShowHistoryMonitor"]["List"];

        //    mini.get("btnShowHistoryMonitor").setEnabled((canFlowOperate & ECanFlowOperate.ShowHistoryMonitor) > 0 && tmpLst.length > 0);
        //    mini.get("btnShowHistoryMonitor").setVisible((canFlowOperate & ECanFlowOperate.ShowHistoryMonitor) > 0 && tmpLst.length > 0);

        //    $("#popupHistoryMonitor .mini-menu-inner .mini-menu-float").empty();  //清理下拉框            
        //    for (var irow = 0; irow < tmpLst.length; irow++) {
        //        var result = tmpLst[irow];
        //        var Status = "";
        //        switch (result.RecordStatus) {
        //            case "Stop":
        //                Status = "已终止"; break;
        //            case "Finish":
        //                Status = "已办结"; break;
        //            default:
        //                Status = "流转中"; break;
        //        }
        //        var finishDate = new Date(result.FinishDate);
        //        var title = Status + " [" + result.FinishUserName + ":" + finishDate.getFullYear() + "-" + (finishDate.getMonth() + 1) + "-" + finishDate.getDate() + " " + finishDate.getHours() + ":" + finishDate.getMinutes() + "]";
        //        var html = '<div class="mini-menuitem ' + result.WorkinfoID + '" onmouseover=\'menuitemOver(this)\' onmouseout=\'menuitemOut(this)\'><div onclick=\"onShowMonitor(this,\'' + result.WorkInfoID + '\')\" class="mini-menuitem-inner"><div class="mini-menuitem-icon icon-open" style="display: block;"></div><div class="mini-menuitem-text">' + title + '</div><div class="mini-menuitem-allow"></div></div></div>';
        //        $("#popupHistoryMonitor .mini-menu-inner .mini-menu-float").append(html);

        //    }
        //}
         
    }
    //提取流程列表
    var onSubmitDatas = function () {
        var self = this;
        //只要有任何一项， Complete不是 true ,说明有数据未到位，不允许和服务端交互
        for (var item in dataStatus) {
            if (!dataStatus[item]) continue;
            if (dataStatus[item].Complete != true) return;
        }

        mini.mask({
            el: document.body,
            cls: 'mini-mask-loading',
            html: '加载中...'
        });

        //先获取到所有可用流程
        $.ajax({
            url: "/API/APIMessages",
            type: "POST",
            data: { json: mini.encode(postInfo) },
            cacha: false,
            success: function (text) {

                //if (CurrentSender) CurrentSender.setEnabled(true);
                mini.unmask(document.body);
                var result = mini.decode(text);
                if (result.success == false) {
                    top.Power.ui.error(result.message);
                    postInfo = {};
                    return;
                }

                for (flowOperate in postInfo) {
                    if (flowOperate == "OpenTrans") continue;
                    var tmpResult = result.data[flowOperate];
                    if (!tmpResult) {
                        alert("严重异常，返回对象不可访问"); postInfo = {}; return;
                    }
                    if (tmpResult.success == false) {
                        alert(tmpResult.message); postInfo = {}; return;
                    }

                    switch (flowOperate) {
                        case EFlowOperate.Update:
                            formconfig.FormState = "edit";
                            top.Power.ui.success("保存表单成功");

                            //formconfig.KeyValue = formconfig.config.joindata.currow[formconfig.config.joindata.keyfield];

                           // var f = FormFuns.GetMiniFormGrid(formconfig.config.joindata.KeyWord);
                            PowerForm.LoadMain();
                            break;
                        case EFlowOperate.ReadFlow:  //加载流程信息 
                        case EFlowOperate.Send:  //发送操作        
                        case EFlowOperate.BatchSends:  //发送操作        
                        case EFlowOperate.Return:  //发送操作     
                        case EFlowOperate.Active:  //发送操作       
                        case EFlowOperate.GetBack:  //回收操作        
                        case EFlowOperate.Delegate:  //委派操作    
                        case EFlowOperate.Stop:  //终止指令

                            tmpResult = mini.decode(tmpResult.data.CurrentResult);
                            //如果触发询问模式，则弹出询问框
                            if (tmpResult.EachCommand && tmpResult.EachCommand == EEachCommand.AskSequ) {
                                var flow = new WorkFlowsForm();
                                postInfo = {};
                                dataStatus = {};
                                flow.setCallBack(onEndExecute);  //绑定回调函数
                                flow.AskSequ(tmpResult);
                                return;
                            }
                            else
                                if (tmpResult) SetFlowResult(tmpResult);
                            break;
                        default:
                            alert("无法识别的指令[" + flowOperate + "]");
                    }
                    //非加载和修改模式，比如送审、终止等操作，要刷新页面。
                    if (flowOperate != EFlowOperate.ReadFlow && flowOperate != EFlowOperate.Update)
                        reloadForm();
                }
                postInfo = {};
                dataStatus = {};
                mini.unmask(document.body);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (CurrentSender) CurrentSender.setEnabled(true);
                mini.unmask(document.body);
                top.Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
            }
        });
    }

    //保存表单信息
    var onSaveForm = function (data, flowOperate) {

        var e = {};
        e.id = data.KeyWord + ".Save";

        var data = PowerForm.FlowSaveValid(e);
        if (!data) return;
        var result = mini.decode(data.jsonData);

        if (!data.params) data.params = {};
        data.params.IsWorkFlowHuman = 1;  //设置以流程参与人模式触发保存。外部规定

        var formData = {};
        formData.formId = formconfig.FormId;
        formData.json = result;
        formData.params = Base64.encode(mini.encode(data.params));

        var msg = {};
        msg.MessageCode = "Power.Controls.PMS.SaveWebForm";
        msg.data = formData;
        msg.data.FlowOperate = flowOperate;  //执行加载信息操作

        if (!postInfo) postInfo = {};
        postInfo.OpenTrans = "true";  //开启事务
        postInfo[flowOperate] = msg;   //要保存的数据包 

        dataStatus[flowOperate] = {};
        dataStatus[flowOperate].Complete = true;  //数据已经准备完毕
        onSubmitDatas();
    }
    //脚本级命令执行完毕后的回调函数
    var onEndExecute = function (flowOperate, result) {
        var self = this;
        if (result.success == false) {
            top.Power.ui.error(result.message);
            dataStatus = {};  //数据状态复位，说明取消操作了
            if (CurrentSender) CurrentSender.setEnabled(true);
            return;
        }
        if (result.cancel == true) {
            dataStatus = {};  //数据状态复位，说明取消操作了
            if (CurrentSender) CurrentSender.setEnabled(true);
            return;
        }   //收到取消指令，则忽略所有行为

        if (!postInfo) postInfo = {};
        postInfo.OpenTrans = "true";  //开启事务
        postInfo[flowOperate] = result.data;
        if (!dataStatus[flowOperate]) dataStatus[flowOperate] = {};
        dataStatus[flowOperate].Complete = true;  //标记某个域的数据已经提交

        onSubmitDatas();  //执行
    }
    //----------------------------------------------------------------------------------------
    return {


        //命令执行入口
        onExecute: function (sender, data, events, flowOperates) {
            CurrentSender = sender;
            var self = this;
            if (!flowOperates) {
                top.Power.ui.error("参数错误[" + flowOperates + "]");
                return;
            }

            var flow = new WorkFlowsForm();
            flow.setCallBack(onEndExecute);  //绑定回调函数

            var FlowOperates = flowOperates.split(',');


            for (var irow = 0; irow < FlowOperates.length; irow++) {
                var curFlowOperate = FlowOperates[irow];
                switch (curFlowOperate) {
                    case EFlowOperate.Update:
                        onSaveForm(data, curFlowOperate);
                        break;
                    case EFlowOperate.ReadFlow:  //加载流程信息  
                        flow.onReadFlowInfo(data, events, curFlowOperate);
                        break;
                    case EFlowOperate.Active:  //送审
                    case EFlowOperate.Send:  //发送 
                    case EFlowOperate.BatchSends:  //批量发送 
                    case EFlowOperate.Stop:  //终止 
                    case EFlowOperate.Delegate: //委派
                    case EFlowOperate.Return:  //驳回
                    case EFlowOperate.ShowMonitor:  //监控
                    case EFlowOperate.ShowHistoryMonitor:  //监控历史                         
                        flow.onExecute(data, events, curFlowOperate);
                        break;
                    case EFlowOperate.GetBack:  //回收
                        top.Power.ui.confirm("您是否要回收这份表单?", function (confirm) {
                            if (!confirm) {
                                if (CurrentSender) CurrentSender.setEnabled(true); return;
                            }
                            flow.onExecute(data, events, curFlowOperate);
                        });
                        break;

                }
            }
        },
        ///设置按钮状态
        onSetFlowResult: function (currentResult) {

            SetFlowResult(currentResult);

        },
        //询问当前SequeID位置
        onAskSequ: function (currentReseult) {
            var tmpResult = mini.decode(currentReseult);
            //如果触发询问模式，则弹出询问框
            if (tmpResult.EachCommand && tmpResult.EachCommand == EEachCommand.AskSequ) {
                var flow = new WorkFlowsForm();

                flow.setCallBack(onEndExecute);  //绑定回调函数
                flow.AskSequ(tmpResult);
                return;
            }

        }
    }

}


mini.parse();

var groupID = "";
groupID = getParameter("GroupID");    //子流程创建时，会有此数值
var workInfoID = "";
workInfoID = getParameter("WorkInfoID");   //子流程创建时，会有此数值
if (workInfoID && mini.get("txtCurrentWorkInfoID")) mini.get("txtCurrentWorkInfoID").setValue(workInfoID);  //如果外部url 传入了SequeID序号，则引用此序号

var controlCenter = new ControlCenter();   //控制中心，管辖 WebForm/WorkFlowsForm,既表单和流程

if (getParameter("SequeID") && mini.get("txtCurrentSequeID")) mini.get("txtCurrentSequeID").setValue(getParameter("SequeID"));  //如果外部url 传入了SequeID序号，则引用此序号
var onExecute = function (sender, flowOperates) {

   // if (sender) sender.setEnabled(false);
    var data = {};
    if (!formconfig.FormId) {
        alert("FormId不可为空");
        return;
    }
    data.FormId = formconfig.FormId;
    data.KeyValue = formconfig.KeyValue;

    if (!data.KeyValue) {
        data.KeyValue = formconfig.config.joindata.currow[formconfig.config.joindata.keyfield];
    }
    data.KeyWord = formconfig.config.joindata.KeyWord;
    var sequeID = mini.get("txtCurrentSequeID").getValue();
    if (sequeID) data.SequeID = sequeID;

    if (workInfoID) data.WorkInfoID = workInfoID;
    if (groupID) data.GroupID = groupID;


    var events = {};
    controlCenter.onExecute(sender, data, events, flowOperates);
}
var onExecuteMonitor = function (sender, flowOperates, data) {

    var events = {};
    controlCenter.onExecute(sender, data, events, flowOperates);
}

var onShowMonitor = function (sender, workInfoID) {
    var data = {};
    data.WorkInfoID = workInfoID;
    var events = {};
    controlCenter.onExecute(sender, data, events, 'ShowMonitor');
}
var menuitemOver = function (elem) {
    $(elem).addClass("mini-menuitem-hover");
    return false;
}
var menuitemOut = function (elem) {
    $(elem).removeClass("mini-menuitem-hover");
    return false;
}