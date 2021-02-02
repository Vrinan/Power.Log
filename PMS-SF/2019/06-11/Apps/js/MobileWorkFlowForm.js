
var WorkFlowsForm = function () {
    //回调函数
    var CallBackFunction = null;

    return {
        //传入回调函数
        setCallBack: function (callback) {
            CallBackFunction = callback;
        },
        //指令执行
        onExecute: function (data, events, flowOperate) {
            var self = this;
            var result = {};

            switch (flowOperate) {
                case EFlowOperate.Active:   //送审
                    if ((flow_active && flow_active == 1) || (workflowdata && workflowdata.CanFlowOperate && workflowdata.CanFlowOperate.CanPassWordList && workflowdata.CanFlowOperate.CanPassWordList.Active == "Enabled"))
                        self.CheckPass(self.SelectWorkFlow, data, events, flowOperate);
                    else
                        self.SelectWorkFlow(data, events, flowOperate);
                    break;
                case EFlowOperate.Send:  //发送 
                    if ((flow_send && flow_send == 1) || (workflowdata && workflowdata.CanFlowOperate && workflowdata.CanFlowOperate.CanPassWordList && workflowdata.CanFlowOperate.CanPassWordList.Send == "Enabled"))
                        self.CheckPass(self.SelectWorkFlow, data, events, flowOperate);
                    else
                        self.SelectSendNode(data, events, flowOperate);
                    break;
                case EFlowOperate.GetBack:  //回收操作 
                    self.GetBack(data, events, flowOperate);
                    break;
                case EFlowOperate.Stop:  //终止
                    if ((flow_stop && flow_stop == 1) || (workflowdata && workflowdata.CanFlowOperate && workflowdata.CanFlowOperate.CanPassWordList && workflowdata.CanFlowOperate.CanPassWordList.Stop == "Enabled"))
                        self.CheckPass(self.SelectWorkFlow, data, events, flowOperate);
                    else
                        self.StopWorkFlow(data, events, flowOperate);
                    break;
                case EFlowOperate.Return:  //驳回 
                    if ((flow_return && flow_return == 1) || (workflowdata && workflowdata.CanFlowOperate && workflowdata.CanFlowOperate.CanPassWordList && workflowdata.CanFlowOperate.CanPassWordList.Return == "Enabled"))
                        self.CheckPass(self.SelectWorkFlow, data, events, flowOperate);
                    else
                        self.SelectReturnNode(data, events, flowOperate);
                    break;
                case EFlowOperate.Delegate:  //委办操作
                    if ((flow_delegate && flow_delegate == 1) || (workflowdata && workflowdata.CanFlowOperate && workflowdata.CanFlowOperate.CanPassWordList && workflowdata.CanFlowOperate.CanPassWordList.Delegate == "Enabled"))
                        self.CheckPass(self.SelectWorkFlow, data, events, flowOperate);
                    else
                        self.SelectDelegate(data, events, flowOperate);
                    break;
                case EFlowOperate.ShowMonitor:  //监控 
                    self.ShowMonitor(data, events, flowOperate);
                    break;
                default:
                    top.Power.ui.error("无法识别的指令[" + flowOperate + "]");
                    break;
            }
            return result;
        },
        CheckPass: function (fn, data, events, flowOperate) {
            top.Power.ui.dialog({
                title: '验证登陆密码',               //对话框标题
                content: '<input type="password" id="checkpassword" class="form-control" />',          //对话框实体内容
                modal: true,                      //是否创建遮罩
                effect: 'zoom',                   //对话框显示的转场物资
                closeable: false,
                position: 'center center',        //对话框的位置
                button: {                          //设置对话框的按钮组
                    "确定": {
                        theme: 'primary',         //按钮的主题
                        handler: function () {      //点击按钮时的回调
                            var value = $("#checkpassword").val();
                            value = base64swhere(value);
                            top.Power.ui.loading("请稍后……");
                            $.ajax({
                                url: "/WorkFlow/checkuserpass",
                                type: "POST",
                                data: { password: value },
                                success: function (text) {
                                    top.Power.ui.loading.close();
                                    var tmp = mini.decode(text);
                                    if (!tmp.success) {
                                        top.Power.ui.alert(tmp.message);
                                        return;
                                    }
                                    if (fn)
                                        fn(data, events, flowOperate);
                                }
                            });
                        }
                    },
                    "取消": function () {
                    }
                }
            });
            $(".modal-footer").css("padding", "5px 10px");
        },
        //依据keyvalue + 当前登陆人， 获取当前表单和流程的关系
        onReadFlowInfo: function (data, events, flowOperate) {
            var CurrentInfo = {};
            CurrentInfo.Current = data;
            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = CurrentInfo;
            msg.data.FlowOperate = flowOperate;  //执行加载信息操作

            var result = {};
            result.success = true;
            result.data = msg;
            if (CallBackFunction) CallBackFunction(msg.data.FlowOperate, result);

        },

        //选择流程
        SelectWorkFlow: function (data, events, flowOperate) {
            var self = this;
            var result = {};
            result.success = true;

            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnFlow) {
                    PowerForm.EventBeforeOnBtnFlow(data);
                    if (data.isValid == false || data.canNext == false || data.canOpen == false) return;  //验证没通过，则不执行后续操作
                }
            }
            if (events && events.onBeforeSelectFlow) {
                events.onBeforeSelectFlow(data);
                if (data.cancel == true) {
                    result.cancel = true;
                    if (CallBackFunction) CallBackFunction(result);
                    return;
                }
            }

            var url = "/Form/OpenURL?url=/Apps/workflow/WorkNodeSelect.html?KeyWord=" + formconfig.config.joindata.KeyWord + "&KeyValue=" + formconfig.KeyValue + "&FormID=" + FormId + "&flowOperate=" + flowOperate;

            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程审批"}', url);
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appOpenNewWebView', '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程审批"}', function XXX(outparam) {

            //    });
            //}
            //else {
            //    window.open(url, "_self")
            //} 
        },

        //点击发送按钮，选择目标节点
        SelectSendNode: function (data, events, flowOperate) {

            var self = this;
            var result = {};
            result.success = true;

            if (events && events.onBeforeSendNode) {
                events.onBeforeSendNode(data);
                if (data.cancel == true) {
                    result.cancel = true;
                    if (CallBackFunction) CallBackFunction(result);
                    return;
                }
            }


            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnFlow) {
                    data.isValid = true;
                    PowerForm.EventBeforeOnBtnFlow(data);
                    if (data.isValid == false || data.canNext == false || data.canOpen == false) return;  //验证没通过，则不执行后续操作
                }
            }
            var url = "/Form/OpenURL?url=/Apps/workflow/WorkNodeSelect.html?WorkInfoID=" + mini.get("txtCurrentWorkInfoID").getValue() + "&SequeID=" + mini.get("txtCurrentSequeID").getValue() + "&flowOperate=" + flowOperate;
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程审批"}', url);
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appOpenNewWebView', '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程审批"}', function XXX(outparam) {

            //    });
            //}
            //else {
            //    window.open(url, "_self")
            //}

        },

        //点击驳回按钮，选择目标节点
        SelectReturnNode: function (data, events, flowOperate) {

            var self = this;
            var result = {};
            result.success = true;

            if (events && events.onBeforeSendNode) {
                events.onBeforeSendNode(data);
                if (data.cancel == true) {
                    result.cancel = true;
                    if (CallBackFunction) CallBackFunction(result);
                    return;
                }
            }
            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnRetrunNode) {
                    var e = self;
                    e.isValid = true;
                    PowerForm.EventBeforeOnBtnRetrunNode(e);
                    if (data.isValid == false || data.canNext == false || data.canOpen == false) return;  //验证没通过，则不执行后续操作
                }
            }
            var url = "/Form/OpenURL?url=/Apps/workflow/WorkReturnSelect.html?WorkInfoID=" + mini.get("txtCurrentWorkInfoID").getValue() + "&SequeID=" + mini.get("txtCurrentSequeID").getValue() + "&flowOperate=" + flowOperate;
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程审批"}', url);
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appOpenNewWebView', '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程审批"}', function XXX(outparam) {

            //    });
            //}
            //else {
            //    window.open(url, "_self")
            //}


        },
        //------------------------------------------回收-----------------------------
        //询问选择序号
        AskSequ: function (sendData) {
            var self = this;
            var result = {};

            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/Commons/AskInboxList.html",
                showMaxButton: true,
                width: 680, height: 300,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(sendData);
                },
                ondestroy: function (action) {
                    if (action != "ok") {
                        result.cancel = true;
                        if (CallBackFunction) CallBackFunction(null, result);
                        return;
                    }
                    var iframe = this.getIFrameEl();
                    var tmpData = iframe.contentWindow.GetData();

                    tmpData = mini.clone(tmpData);

                    var CurrentInfo = {};
                    CurrentInfo.Current = tmpData;
                    var msg = {};
                    msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
                    msg.data = CurrentInfo;
                    msg.data.FlowOperate = EFlowOperate.ReadFlow;  //加载信息

                    result.data = msg;
                    if (CallBackFunction) CallBackFunction(flowOperate, result);
                }
            });

        },
        //回收操作
        GetBack: function (data, events, flowOperate) {
            var self = this;
            var result = {};
            result.success = true;

            if (events && events.onBeforeGetBack) {
                events.onBeforeGetBack(data);
                if (data.cancel == true) {
                    result.cancel = true;
                    if (CallBackFunction) CallBackFunction(result);
                    return;
                }
            }

            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            var post = {};
            post.Current = data;
            msg.data = post;
            msg.data.FlowOperate = EFlowOperate.GetBack;  //执行回收操作
            result.data = msg;

            if (CallBackFunction) CallBackFunction(flowOperate, result);
        },


        //---------------------------------------终止--------------------------
        //终止
        StopWorkFlow: function (data, events, flowOperate) {
            var self = this;
            var result = {};
            result.success = true;

            if (events && events.onBeforeStop) {
                events.onBeforeStop(data);
                if (data.cancel == true) {
                    result.cancel = true;
                    if (CallBackFunction) CallBackFunction(result);
                    return;
                }
            }

            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkFlowStop.html",
                showMaxButton: true,
                width: 780, height: 580,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(data, flowOperate, win);
                },
                ondestroy: function (action) {
                    if (action != "ok") {
                        result.cancel = true;
                        if (CallBackFunction) CallBackFunction(null, result);
                        return;
                    }
                    var iframe = this.getIFrameEl();
                    var tmpData = iframe.contentWindow.GetData();

                    tmpData = mini.clone(tmpData);

                    var msg = {};
                    msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
                    msg.data = tmpData;
                    msg.data.FlowOperate = EFlowOperate.Stop;  //执行终止操作

                    result.data = msg;
                    if (CallBackFunction) CallBackFunction(flowOperate, result);
                }
            });
        },



        ///----------------------------委办操作------------------------------------ 
        SelectDelegate: function (data, events, flowOperate) {
            var self = this;
            var result = {};
            result.success = true;

            if (events && events.onBeforeDelegate) {
                events.onBeforeDelegate(data);
                if (data.cancel == true) {
                    result.cancel = true;
                    if (CallBackFunction) CallBackFunction(result);
                    return;
                }
            }

            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/DelegateSelect.html",
                showMaxButton: true,
                width: 780, height: 580,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(data, flowOperate, win);   //选择可选工作流
                },
                ondestroy: function (action) {
                    if (action != "ok") {
                        result.cancel = true;
                        if (CallBackFunction) CallBackFunction(null, result);
                        return;
                    }
                    var iframe = this.getIFrameEl();
                    var tmpData = iframe.contentWindow.GetData();

                    tmpData = mini.clone(tmpData);
                    var msg = {};
                    msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
                    msg.data = tmpData;
                    msg.data.FlowOperate = flowOperate;  //执行发送操作

                    result.data = msg;
                    if (CallBackFunction) CallBackFunction(flowOperate, result);

                    if (events && events.onEndDelegate) {
                        events.onEndDelegate(data);
                    }
                }
            });
        },


        ///----------------------流程监控--------------------------------------
        //触发流程监控
        ShowMonitor: function (data, events, flowOperate) {
             
            var url = "/Form/OpenURL?url=/Apps/workflow/ShowMonitor.html?WorkInfoID=" + data.WorkInfoID;// currentResult.CanFlowList["ShowMonitor"].WorkInfoID
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"流程监控"}', url);



        }


    }
}

//公共静态方法
var WorkFlowUtil = {

    //关闭窗体
    CloseWindow: function (action) {
        if (window.CloseOwnerWindow) return window.CloseOwnerWindow(action);
        else window.close();
    },
    //创建guid
    CreateGUID: function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    },
    GetOperate: function (flowOperate) {
        var flowString = "";
        switch (flowOperate) {
            case EFlowOperate.Send:
                flowString = ""; break;
            case EFlowOperate.Return:
                flowString = "退回"; break;//"退回"
            case EFlowOperate.Stop:
                flowString = "终止"; break;//"终止"
            case EFlowOperate.CheckOut:
                flowString = "签收"; break;//"签收"
            case EFlowOperate.Delegate:
                flowString = "委派给他人"; break;//"委派给他人" 
            case EFlowOperate.EndFlow:
                flowString = "办结"; break;//"办结"
            default:
                flowString = ""; break;

        }
        return flowString;
    },
    //绘制意见栏目
    DrawMindList: function (div, mindList) {

        var tb = "<table style=\"width:100%\" >";
        for (var iTmp = 0, len = mindList.length; iTmp < len; iTmp++) {

            var node = mindList[iTmp];
            if (node.Alias != "MindRecord") continue;
            if (node.InboxStatus != EFlowInboxStatus.WorkEnd) continue;

            var flowString = WorkFlowUtil.GetOperate(node.FlowOperate);
            if (flowString)
                tb += "<tr><td colspan='3' style=\"width:100%\">" + node.ActName + " (" + flowString + ")</td></tr>";
            else
                tb += "<tr><td colspan='3' style=\"width:100%\">" + node.ActName + "</td></tr>";

            var c = "同意"; //"同意";

            if (mindList[(iTmp - 1)] != null && mindList[(iTmp - 1)].FlowOperate == 32)
                c = "不同意"; //"不同意";
            if (node.Content && node.Content != "")
                c = node.Content;
            switch (node.InboxStatus) {
                case EFlowInboxStatus.WaitingSign:  //等候签收
                    tb += "<tr><td style=\"width:40%\" ></td><td colspan='2'  style=\"width:60%\"> 等候签收</td></tr>"; //等候签收
                    break;
                case EFlowInboxStatus.WorkEnd:   //线路结束 
                    tb += "<tr><td  style=\"width:40%\" ></td><td colspan='2' style=\"width:60%\" > " + c + "</td></tr>";
                    break;
                default:
                    tb += "<tr><td  style=\"width:40%\"></td><td colspan='2'  style=\"width:60%\"> 正在办理</td></tr>";//正在办理
                    break;
            }
            tb += "<tr style=\"border-bottom:1px dashed  black\"><td colspan='2' style=\"width:60%\"></td><td  style=\"width:40%;font-size:12px\">" + node.UserName + "&nbsp;&nbsp;" + node.MindDate + "</td> </tr>";

        }
        tb += "</table>";
        div.append(tb);

    }
}