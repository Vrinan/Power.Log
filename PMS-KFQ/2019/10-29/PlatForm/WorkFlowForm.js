var power = {};
power.workflow = {};
var WorkFlowGlobal = power.workflow.Global = {
    WorkFlowInfo: {}
}

var existsTabId = function (tabid) {
    var tabs = mini.get("maintabs");
    if (!tabs) return false;
    if (tabs.getTab(tabid) == undefined)
        return false;
    return true;
}
var WorkFlowUtil = power.workflow.Util = {
    create: function (options) {
        this.global = power.workflow.Global;
        this.global.WorkFlowInfo = {};
        return this;
    },

    //设置主键值
    SetWorkFlowInfo: function (workFlowInfo) {

        var global = power.workflow.Global;
        global.WorkFlowInfo = workFlowInfo;
    },
    //wsl 添加，如果绑定了工作流体系，则设定工作流按钮
    SetFlowButtons: function (workflowString) {
        var data = mini.decode(workflowString);
        var canFlowOperate = data.CanFlowOperate;  //获取可操作的方式（枚举集合）

        var isAnyShow;
        var pwframe = window.parent; //获取流程外框，一下按钮都是流程外框上的, mpqin 2014.7.17
        try{ //判断一下，如果是域外iframe的，就不要执行了，会报错 hw2017.6.29
            if (pwframe.location.href.indexOf("WorkFlowFrame.htm") == -1
                && pwframe.location.href.indexOf("Message/Show") == -1
                && pwframe.location.href.indexOf("Form/ValidForm") == -1
                ) {
                pwframe = window;
            }
            if (pwframe) {

                pwframe.jQuery("#btnSend").css("display", (canFlowOperate & FlowOperate.Send) == 0 ? "none" : isAnyShow = "inline");
                pwframe.jQuery("#btnReturn").css("display", (canFlowOperate & FlowOperate.Return) == 0 ? "none" : isAnyShow = "inline");
                pwframe.jQuery("#btnCheckOut").css("display", (canFlowOperate & FlowOperate.CheckOut) == 0 ? "none" : isAnyShow = "inline");
                pwframe.jQuery("#btnDelegate").css("display", (canFlowOperate & FlowOperate.Delegate) == 0 ? "none" : isAnyShow = "inline");
                pwframe.jQuery("#btnGetBack").css("display", (canFlowOperate & FlowOperate.GetBack) == 0 ? "none" : isAnyShow = "inline");
                pwframe.jQuery("#btnStop").css("display", (canFlowOperate & FlowOperate.Stop) == 0 ? "none" : isAnyShow = "inline");

                if (data.StopedWorkInfoList && data.StopedWorkInfoList.length > 0) {
                    //pwframe.jQuery("#btnShowMonitor").css("display", "");
                    var html = "<a href=\"#\" class=\"btn blue\" data-toggle=\"dropdown\"><i class=\"fa fa-video-camera\"></i>历史监控</a>";
                    html += "<ul class=\"dropdown-menu pull-right\">";
                    for (var irow = 0; irow < data.StopedWorkInfoList.length; irow++) {
                        html += '<li><a href="javascript:;" onclick="document.getElementById(\'frmMain\').contentWindow.WorkFlowUtils.ShowStopedMonitor(\'' + data.StopedWorkInfoList[irow].WorkInfoID + '\',\'' + data.StopedWorkInfoList[irow].ConfigMode + '\' )">';
                        html += '<i class=\"fa fa-history \"></i>已终止流程[' + data.StopedWorkInfoList[irow].UserName + ':'
                            + data.StopedWorkInfoList[irow].StopDate.getFullYear() + "-" + (data.StopedWorkInfoList[irow].StopDate.getMonth() + 1) + "-" + data.StopedWorkInfoList[irow].StopDate.getDate() + " " + data.StopedWorkInfoList[irow].StopDate.getHours() + ":" + data.StopedWorkInfoList[irow].StopDate.getMinutes() + ":" + data.StopedWorkInfoList[irow].StopDate.getSeconds(); +']</a></li>';
                    }
                    html += '</ul>';
                    pwframe.jQuery("#btnHisMonitor").html(html);
                }

                pwframe.jQuery("#btnShowMonitor").css("display", (canFlowOperate & FlowOperate.ShowFlowMonitor) == 0 ? "none" : isAnyShow = "inline");



                if (isAnyShow != undefined || (data.StopedWorkInfoList && data.StopedWorkInfoList.length > 0)) {
                    pwframe.jQuery("#WorkFlowToolbar").css("display", "");
                    //pwframe.jQuery(window).trigger("resize");
                    if (typeof (pwframe.ResizeOwnerWindow) == "function")
                        pwframe.ResizeOwnerWindow();
                }
            }
        }
        catch (err) {

        }
        //新增数据，保存，还没有选择流程，再次打开，显示激活流程按钮
        //if ($("#btnActive") != "undefined" && (canFlowOperate & FlowOperate.Active) != 0)
        //    $("#btnActive").css("display", "");
        // 应孔晶所提，保存按钮永远可见
        //xuzhimin 2015-10-13 09:18:15 注释
        //var global = power.workflow.Global;
        //if (document.getElementById(global.WorkFlowInfo.KeyWord + ".Save") != "undefined") {
        //    var showSave = (canFlowOperate & FlowOperate.Update) != 0;
        //    showSave = showSave || (canFlowOperate & FlowOperate.Insert) != 0;
        //    //保存按钮显示隐藏设置前，判断是否存在保存按钮 xuzhimin 2015年8月24日 09:24:35
        //    if (typeof(document.getElementById(global.WorkFlowInfo.KeyWord + ".Save"))!="undefined"&&document.getElementById(global.WorkFlowInfo.KeyWord + ".Save")!=null)
        //    document.getElementById(global.WorkFlowInfo.KeyWord + ".Save").style.display = showSave == false ? "none" : "";
        //}

    },

    //----------------------------------激活区域---------------------------------------
    //选择流程
    SelectWorkFlow: function (tmpData, AfterCallback) {

        var self = this;
        var global = power.workflow.Global;
        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/WorkNodeSelect.html",
            showMaxButton: true,
            width: 680, height: 480,
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetDataWorkFlow(global.WorkFlowInfo, tmpData);   //选择可选工作流
            },
            ondestroy: function (action) {
                if (action != "ok") {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }
                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData();

                if (!data) {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }
                data = mini.clone(data);

                global.WorkFlowInfo = data.workInfoData;
                global.WorkFlowInfo.SendNodeList = data.SelectedNode;   //将选中的 节点、人员信息放入对象中，以备ajax 提交服务器
                global.WorkFlowInfo.MindInfo = data.MindInfo;
                global.WorkFlowInfo.VoteValue = data.VoteValue;
                delete global.WorkFlowInfo.HistoryMind;   //历史意见无须提交服务器（不用持久化的)
                var re = self.SendNode(data, AfterCallback);
                if (re == false)
                    return;
                if (window.CloseOwnerWindow)
                    window.CloseOwnerWindow("ok");
                else if (window.parent) {
                    if (window.parent.CloseOwnerWindow)
                        window.parent.CloseOwnerWindow("ok");
                    else
                        window.parent.close();
                }
                else
                    window.close();
            }
        });
    },
    //激活一个流程，由btn.Active 按钮触发
    ActiveWorkFlow: function (e, validData) {

        var self = this;
        var global = power.workflow.Global;

        if (PowerForm) {
            if (PowerForm.EventBeforeOnBtnFlow) {
                PowerForm.EventBeforeOnBtnFlow(e);
                if (e.isValid == false) return;  //验证没通过，则不执行后续操作
            }

            if (validData == true) {
                var oerr = FormFuns.ValidData(formconfig.config.joindata.KeyWord, true);
                if (!oerr.success) {
                    if (oerr.errortext.length > 0)
                        Power.ui.error(oerr.errortext);
                    else
                        Power.ui.alert("有必填项未填，请检查");
                    return;
                }
            }
            var a = {};
            a.id = formconfig.config.joindata.KeyWord + ".Save";
            PowerForm.OnBtnSave(a, null, null, null, function (succ) {
                 
                var workFlowString = mini.encode(global.WorkFlowInfo);
                //先获取到所有可用流程
                $.ajax({
                    url: "/WorkFlow/GetWorkFlowList",
                    type: "POST",
                    data: { workFlowString: workFlowString },
                    cacha: false,
                    success: function (text) {
                        var tmpData = mini.decode(text);
                        if (tmpData.success == false) {
                            Power.ui.error(tmpData.message, { detail: tmpData.detail, timeout: 0, position: "center center", closeable: true });
                            return;
                        }
                        if (tmpData instanceof Array == false)   //返回的是对象，说明工作流只有一个候选，无须选择已经绑好了。
                        {
                            self.SetFlowButtons(tmpData);   //只有一个流程，则已经被写入数据库，设置下按钮样式即可了事
                            global.WorkFlowInfo = tmpData;   //服务端信息反写客户端
                            return;
                        }

                        if (tmpData.length == 0) {
                            Power.ui.error("未找到可用的工作流程", { timeout: 0, position: "center center", closeable: true });
                            //alert("未找到可用的工作流程");
                            return;
                        }
                        if (PowerForm) {
                            PowerForm.EventBeforeSelectWorkFlow(e, tmpData);
                            if (e.isValid == false)
                                return;
                        }
                        self.SelectWorkFlow(tmpData, null);   //弹出选择界面，选择一个工作流
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        //alert(jqXHR.responseText);
                        Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
                    }

                });
            });
        }



    },
    ReLoadRight: function () {
        if (FormFuns) {
            var a = {};
            a.KeyWord = formconfig.config.joindata.KeyWord;
            a.KeyValue = formconfig.KeyValue;
            a.FormId = workflowdata.HtmlPath;
            a.fncallback = function (back) {
                workflowdata = back;
                FormFuns.LoadRight(formconfig.config.joindata.KeyWord, true);
            }
            FormFuns.GetNewWorkFlowdData(a);
        }
    },
    //------------------------------回收区域-----------------------------------------------
    //触发回收操作
    GetBack: function () {
        var self = this;
        var global = power.workflow.Global;

        var workFlowString = mini.encode(global.WorkFlowInfo);
        //先获取到所有可用流程
        $.ajax({
            url: "/WorkFlow/GetBack",
            type: "POST",
            data: { workFlowString: workFlowString },
            cacha: false,
            success: function (text) {
                var tmpData = mini.decode(text);
                if (tmpData.success == false) {
                    Power.ui.error(tmpData.message, { detail: tmpData.detail, timeout: 0, position: "center center", closeable: true });
                    return;
                    return;
                }
                self.SetFlowButtons(tmpData);   //只有一个流程，则已经被写入数据库，设置下按钮样式即可了事
                global.WorkFlowInfo = tmpData;   //服务端信息反写客户端
                self.ReLoadRight();//重新加载权限
                return;
            },
            error: function (jqXHR, textStatus, errorThrown) {
                //alert(jqXHR.responseText);
                Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });
            }

        });
    },

    //-----------------------发送及退回区域-------------------------------------------
    BeforeSave: function (e, evt) {

        if (PowerForm) {
            //mpqin 2016.5.5 调用表单标准保存操作
            var btn = { id: formconfig.config.joindata.KeyWord + ".Save" };
            PowerForm.OnBtnSave(btn, false, null, true, function (succ) {
                if (!succ) return;
                if (evt == "SelectSendNode")
                    WorkFlowUtil.SelectSendNode(e, true);
                else if (evt == "SelectReturnNode")
                    WorkFlowUtil.SelectReturnNode(e);
                else if (evt == "SelectDelegate")
                    WorkFlowUtil.SelectDelegate(e);
                else if (evt == "SelectStop")
                    WorkFlowUtil.SelectStop(e);
            });
        }
        else {
            if (evt == "SelectSendNode")
                WorkFlowUtil.SelectSendNode(e, true);
            else if (evt == "SelectReturnNode")
                WorkFlowUtil.SelectReturnNode(e);
            else if (evt == "SelectDelegate")
                WorkFlowUtil.SelectDelegate(e);
            else if (evt == "SelectStop")
                WorkFlowUtil.SelectStop(e);
        }
    },
    //点击发送按钮，选择目标节点
    SelectSendNode: function (e, validData, beforeCallback, endCallback) {

        var self = this;
        var global = power.workflow.Global;
        if (PowerForm) {
            if (PowerForm.EventBeforeOnBtnFlow) {
                e.isValid = true;
                PowerForm.EventBeforeOnBtnFlow(e);
                if (e.isValid == false) return;  //验证没通过，则不执行后续操作
            }

            if (validData == true) {
                var oerr = FormFuns.ValidData(formconfig.config.joindata.KeyWord, true);
                if (!oerr.success) {
                    if (oerr.errortext.length > 0)
                        Power.ui.error(oerr.errortext);
                    else
                        Power.ui.alert("有必填项未填，请检查");
                    return;
                }
            }

        }
        if (beforeCallback) {
            var result = beforeCallback();
            if (result == false) return;
        }
        global.WorkFlowInfo.FlowOperate = FlowOperate.Send;  //执行发送指令
        self.ShowSendDialog();
    },
    //点击退回按钮，选择目标节点
    SelectReturnNode: function () {
        var self = this;
        var global = power.workflow.Global;
        if (PowerForm) {
            if (PowerForm.EventBeforeOnBtnRetrunNode) {
                var e = self;
                e.isValid = true;
                PowerForm.EventBeforeOnBtnRetrunNode(e);
                if (e.isValid == false) return;  //验证没通过，则不执行后续操作
            }
        } 
        global.WorkFlowInfo.FlowOperate = FlowOperate.Return;  //执行退回指令
        self.ShowSendDialog();
    },
    //弹出发送或者退回选择框
    ShowSendDialog: function (AfterCallback) {
        var self = this;
        var global = power.workflow.Global; 
      //  var curFlowOperate = global.WorkFlowInfo.FlowOperate;   //2016.3.22 注，不知为什么，弹出前如果触发 ajax 保存，再提取WorkFlowInfo。当触发mini.open 时，FlowOpearte 的值会变为1，原因不详。
        mini.open({
            url: "/PowerPlat/WorkFlow/WorkNodeSelect.html",
            showMaxButton: true,
            width: 800, height: 600,
            onload: function () {
                var iframe = this.getIFrameEl();  
                iframe.contentWindow.SetDataWorkNode(global.WorkFlowInfo);
            },
            ondestroy: function (action) {
                if (action != "ok") {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }
                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData();

                if (!data) {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }
                data = mini.clone(data);

                global.WorkFlowInfo.SendNodeList = data.SelectedNode;   //将选中的 节点、人员信息放入对象中，以备ajax 提交服务器
                global.WorkFlowInfo.MindInfo = data.MindInfo;
                global.WorkFlowInfo.VoteValue = data.VoteValue;
                delete global.WorkFlowInfo.HistoryMind;   //历史意见无须提交服务器（不用持久化的)
                self.SendNode(data, AfterCallback);
            }
        });
    },
    //执行发送操作
    SendNode: function (data, AfterCallback) {
        var self = this;
        var global = power.workflow.Global;

        var workFlowString = mini.encode(global.WorkFlowInfo);
       
        if (PowerForm) {
            if (PowerForm.EventBeforeOnBtnFlowSubmit) {

                var e = self;
                e.isValid = true;
                PowerForm.EventBeforeOnBtnFlowSubmit(e);
                if (e.isValid == false) return false;  //验证没通过，则不执行后续操作
            }
        }

        $.ajax({
            url: "/WorkFlow/SaveRecord",
            type: "POST",
            data: { workFlowString: workFlowString },
            cache: false,
            type: 'post',
            async: false,
            success: function (text) {

                var tmpData = mini.decode(text);
                if (tmpData.success == false) {
                    Power.ui.error(tmpData.message, { detail: tmpData.detail, timeout: 0, position: "center center", closeable: true });
                    return;
                    return;
                }
                global.WorkFlowInfo = tmpData;
                global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //指令复位

                self.SetFlowButtons(tmpData);   // 设置下按钮样式 

                self.ReLoadRight();//重新加载权限
                if (AfterCallback) AfterCallback(tmpData);

                if (PowerForm) {
                    if (PowerForm.EndSend) { 
                        PowerForm.EndSend(tmpData);
                    }
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {

                global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //指令复位
                ShowMessage(jqXHR.responseText);
            }
        });
    },
    //------------------------委派操作区域
    //点击委派按钮，选择目标节点
    SelectDelegate: function () {
        var self = this;
        var global = power.workflow.Global;
        if (PowerForm) {
            if (PowerForm.EventBeforeOnBtnDelegate) {
                var e = self;
                e.isValid = true;
                PowerForm.EventBeforeOnBtnDelegate(e);
                if (e.isValid == false) return;  //验证没通过，则不执行后续操作
            }
        }
        global.WorkFlowInfo.FlowOperate = FlowOperate.DelegateAndReturn;  //执行退回指令
        self.DelegateDialog();
    },
    //委派操作
    DelegateDialog: function (AfterCallback) {
        var self = this;
        var global = power.workflow.Global;

        var workFlowString = mini.encode(global.WorkFlowInfo);

        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/DelegateSelect.html",
            showMaxButton: true,
            width: 800, height: 600,
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetData(global.WorkFlowInfo);
            },
            ondestroy: function (action) {
                if (action != "ok") {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }

                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData();
                if (!data) {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }

                data = mini.clone(data);
                global.WorkFlowInfo.FlowOperate = data.FlowOperate;   //可能是直接委派，也可能是委派返还\
                global.WorkFlowInfo.SourceMode = data.SourceMode;
                global.WorkFlowInfo.SendNodeList = data.SelectedNode;   //将选中的 节点、人员信息放入对象中，以备ajax 提交服务器
                global.WorkFlowInfo.MindInfo = data.MindInfo;
                global.WorkFlowInfo.VoteValue = data.VoteValue;
                delete global.WorkFlowInfo.HistoryMind;   //历史意见无须提交服务器（不用持久化的)
                self.DelegateNode(data, AfterCallback);
            }
        });
    },
    //执行委派操作
    DelegateNode: function (data, AfterCallback) {
        var self = this;
        var global = power.workflow.Global;

        var workFlowString = mini.encode(global.WorkFlowInfo);

        $.ajax({
            url: "/WorkFlow/SaveRecord",
            type: "POST",
            data: { workFlowString: workFlowString },
            cache: false,
            type: 'post',
            async: false,
            success: function (text) {
                var tmpData = mini.decode(text);
                if (tmpData.success == false) {
                    Power.ui.error(tmpData.message, { detail: tmpData.detail, timeout: 0, position: "center center", closeable: true });
                    return;
                    return;
                }
                global.WorkFlowInfo = tmpData;
                global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //指令复位

                self.SetFlowButtons(tmpData);   // 设置下按钮样式 
                self.ReLoadRight();//重新加载权限
                if (AfterCallback) AfterCallback(tmpData);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //指令复位
                ShowMessage(jqXHR.responseText);
            }
        });
    },

    //---------------------终止操作区域
    //点击退回按钮，选择目标节点
    SelectStop: function () {
        var self = this;
        var global = power.workflow.Global;
        if (PowerForm) {
            if (PowerForm.EventBeforeOnBtnStop) {
                var e = self;
                e.isValid = true;
                PowerForm.EventBeforeOnBtnStop(e);
                if (e.isValid == false) return;  //验证没通过，则不执行后续操作
            }
        }
        global.WorkFlowInfo.FlowOperate = FlowOperate.Stop;  //执行退回指令
        self.StopWorkFlowDialog();
    },
    //终止操作
    StopWorkFlowDialog: function (AfterCallback) {
        var self = this;
        var global = power.workflow.Global;

        var workFlowString = mini.encode(global.WorkFlowInfo);

        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/WorkFlowStop.html",
            showMaxButton: true,
            width: 800, height: 600,
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetData(global.WorkFlowInfo);
            },
            ondestroy: function (action) {
                if (action != "ok") {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }
                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData();
                if (!data) {
                    global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //如果取消了，状态置回修改
                    return;
                }
                data = mini.clone(data);
                global.WorkFlowInfo.MindInfo = data;
                delete global.WorkFlowInfo.HistoryMind;   //历史意见无须提交服务器（不用持久化的)
                self.StopWorkFlow(data, AfterCallback);
            }
        });
    },
    //执行终止操作
    StopWorkFlow: function (data, AfterCallback) {
        var self = this;
        var global = power.workflow.Global;

        var workFlowString = mini.encode(global.WorkFlowInfo);

        $.ajax({
            url: "/WorkFlow/StopWorkFlow",
            type: "POST",
            data: { workFlowString: workFlowString },
            cache: false,
            type: 'post',
            async: false,
            success: function (text) {
                var tmpData = mini.decode(text);
                if (tmpData.success == false) {
                    Power.ui.error(tmpData.message, { detail: tmpData.detail, timeout: 0, position: "center center", closeable: true });
                    return;
                    return;
                }
                global.WorkFlowInfo = tmpData;
                global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //指令复位

                self.SetFlowButtons(tmpData);   // 设置下按钮样式  
                self.ReLoadRight();//重新加载权限
                if (AfterCallback) AfterCallback(tmpData);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                global.WorkFlowInfo.FlowOperate = FlowOperate.Update;  //指令复位
                ShowMessage(jqXHR.responseText);
            }
        });
    },

    //------------------------流程监控区域
    //显示被终止的流程
    ShowStopedMonitor: function (stopedWorkInfoID, configMode) {
       
        var self = this;
        var global = power.workflow.Global;
        self.ShowMonitor(stopedWorkInfoID, configMode); //显示当前流程
    },
    //显示当前流程
    ShowCurrentMonitor: function () {

        var self = this;
        var global = power.workflow.Global;
        self.ShowMonitor(global.WorkFlowInfo.WorkInfoID, workflowdata.ConfigMode); //显示当前流程
    },
    //触发流程监控
    ShowMonitor: function (workInfoID, configMode) {

        var self = this;
        var global = power.workflow.Global;

        if (!workInfoID || workInfoID == '00000000-0000-0000-0000-000000000000' || workflowdata.WorkInfoID == '00000000-0000-0000-0000-000000000000' || workflowdata.HtmlPath == 'HisDataNodes') {
            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/ShowHistory.html&keyvalue=" + workflowdata.KeyValue,
                title: "", width: 800, height: 600
            });
            return;
        }

        //zhouke
        //新流程设计器设计出来的流程图用新的监控页面


        //2015.11 吴石磊做了改动，服务端追加了  workflowdata.ConfigMode  判断当前流程走json 还是走xml
        var url = "/Form/OpenURL?url=/PowerPlat/WorkFlow/ShowMonitor.html";

        if (configMode == "Json")//JSON 格式就跳转到JSON 页面
            url = "/Form/OpenURL?url=/PowerPlat/WorkFlow/ShowMonitorForJson.htm";

        mini.open({
            url: url,
            width: 800, height: 600,
            showMaxButton: true,
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetData(workInfoID);
            },
            ondestroy: function (action) {
            }
        });


    }
}

var WorkFlowUtils = power.workflow.Util.create();   //默认创建一个全局对象，负责处理工作流


