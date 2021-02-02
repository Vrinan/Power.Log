
var WorkFlowsForm = function () {
    //回调函数
    var CallBackFunction = null;

    //监控界面的 “配置保存按钮"
    var onbuttonclick = function (e) {
        var iframe = this.getIFrameEl();

        if (e.name == "edit") {
            iframe.contentWindow.onSaveConfig();
        }

    };

 //转发人员
    var    onForwardUserList = function (data,userList) {
             
            var CurrentInfo = {};  
            CurrentInfo.SendUserList = userList;
             CurrentInfo.Current = data;
            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = CurrentInfo;
            msg.data.FlowOperate = EFlowOperate.Forward;    //转发指令

            mini.mask({
                el: document.body,
                cls: 'mini-mask-loading',
                html: '加载中...'
            });
            //先获取到所有可用流程
            $.ajax({
                url: "/API/APIMessage",
                type: "POST",
                data: { json: mini.encode(msg) },
                cacha: false,
                success: function (text) { 
                    var result = mini.decode(text);
                    if (result.success == false) {
                        mini.unmask(document.body);
                        Power.ui.error(result.message, { detail: result.detail, timeout: 0, position: "center center", closeable: true });
                        return;
                    }
                    Power.ui.info("转发成功");
                    var data = result.data;
                    
                    mini.unmask(document.body);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    mini.unmask(document.body);
                    alert(jqXHR.responseText);
                }
            });
        };  

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
                    self.SelectWorkFlow(data, events, flowOperate);
                    break;
                case EFlowOperate.Send:  //发送 
                    self.SelectSendNode(data, events, flowOperate);
                    break;
                case EFlowOperate.BatchSends:  //批量发送 
                    self.BatchSendNodes(data, events, flowOperate);
                    break;
                case EFlowOperate.GetBack:  //回收操作 
                    self.GetBack(data, events, flowOperate);
                    break;
                case EFlowOperate.Stop:  //终止
                    self.StopWorkFlow(data, events, flowOperate);
                    break;
                case EFlowOperate.Scrap:  //作废
                    self.ScrapWorkFlow(data, events, flowOperate);
                    break;
                case EFlowOperate.Return:  //驳回 
                    self.SelectReturnNode(data, events, flowOperate);
                    break;
                case EFlowOperate.Delegate:  //委办操作
                    self.SelectDelegate(data, events, flowOperate);
                    break;
                case EFlowOperate.ShowMonitor:  //监控 
                    self.ShowMonitor(data, events, flowOperate);
                    break;
                case EFlowOperate.Forward://转发操作
                     self.Forward(data, events, flowOperate);
                    break;
                default:
                    Power.ui.error("无法识别的指令[" + flowOperate + "]");
                    break;
            }
            return result;
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
                    if (data.isValid == false) return;  //验证没通过，则不执行后续操作
                }
            }

            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkNodeSelect.html",
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

                    if (PowerForm) {
                        var e = self;
                        PowerForm.EventBeforeSelectWorkFlow(e, tmpData);
                        if (e.isValid == false)
                            return;
                    }

                    tmpData = mini.clone(tmpData);
                    var msg = {};
                    msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
                    msg.data = tmpData;
                    msg.data.FlowOperate = EFlowOperate.Send;  //执行发送操作

                    result.data = msg;

                    if (CallBackFunction) CallBackFunction(flowOperate, result);  //返回时，一定返回入口指令： 比如，入口指令是Active, 内部触发了Send指令，但回调函数仍然得返回Active. 因为外部会对指令做统一提交

                }
            });
        },

        IsPhoneDevice: function () {
            return (typeof (sessiondata) != "undefined" && sessiondata.DeviceInfo && sessiondata.DeviceInfo.IsPhone);
        },
        GetPhoneWidth: function (defwidth) {
            if (this.IsPhoneDevice())
                return window.innerWidth || self.innerWidth || (de && de.clientWidth) || document.body.clientWidth;
            else
                return defwidth;
        },
        GetPhoneHeight: function (defheight) {
            if (this.IsPhoneDevice())
                return (window.innerHeight || (window.document.documentElement.clientHeight || window.document.body.clientHeight));
            else
                return defheight;
        },
        //点击发送按钮，选择目标节点
        SelectSendNode: function (data, events, flowOperate) {

            var self = this;
            var result = {};
            result.success = true;

            if (document && document.getElementById("myframe")) {
                var myFrame = document.getElementById("myframe").contentWindow;
                if (myFrame && myFrame.PowerForm)
                    PowerForm = myFrame.PowerForm;
            }
            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnFlow) {
                    data.isValid = true;
                    PowerForm.EventBeforeOnBtnFlow(data);
                    if (data.isValid == false) return;  //验证没通过，则不执行后续操作
                }
            }

            var width = self.GetPhoneWidth(780);
            var height = self.GetPhoneHeight(580);
            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkNodeSelect.html",
                showMaxButton: true,
                width: width, height: height,
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

                }
            });
        },
        //批量发送
        BatchSendNodes: function (data, events, flowOperate) {

            var self = this;
            var result = {};
            result.success = true;


            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkNodeBatchSelect.html",
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
                    msg.data.FlowOperate = flowOperate;  //执行批量发送操作

                    result.data = msg;
                    if (CallBackFunction) CallBackFunction(flowOperate, result);

                }
            });
        },
        //点击驳回按钮，选择目标节点
        SelectReturnNode: function (data, events, flowOperate) {

            var self = this;
            var result = {};
            result.success = true;

            if (document && document.getElementById("myframe")) {
                var myFrame = document.getElementById("myframe").contentWindow;
                if (myFrame && myFrame.PowerForm)
                    PowerForm = myFrame.PowerForm;
            }
            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnRetrunNode) {
                    var e = self;
                    e.isValid = true;
                    PowerForm.EventBeforeOnBtnRetrunNode(e);
                    if (e.isValid == false) return;  //验证没通过，则不执行后续操作
                }
            }

            var width = self.GetPhoneWidth(780);
            var height = self.GetPhoneHeight(580);
            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkReturnSelect.html",
                showMaxButton: true,
                width: width, height: height,
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
                    msg.data.FlowOperate = flowOperate;  //执行驳回操作

                    result.data = msg;
                    if (CallBackFunction) CallBackFunction(flowOperate, result);

                    if (events && events.onEndSendNode) {
                        events.onEndSendNode(data);
                    }
                }
            });
        },
        //------------------------------------------回收-----------------------------
        //询问选择序号
        AskSequ: function (sendData) {
            var self = this;
            var result = {};

            if (document && document.getElementById("myframe")) {
                var myFrame = document.getElementById("myframe").contentWindow;
                if (myFrame && myFrame.PowerForm)
                    PowerForm = myFrame.PowerForm;
            }
            var width = self.GetPhoneWidth(680);
            var height = self.GetPhoneHeight(300);
            mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/Commons/AskInboxList.html",
                showMaxButton: true,
                width: width, height: height,
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

                    window.location.href = "/Form/EditForm/" + formconfig.FormId + "/" + formconfig.KeyValue + "?WorkInfoID=" + tmpData.WorkInfoID + "&WorkSequeID=" + tmpData.SequeID;
                    return;
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

            if (document && document.getElementById("myframe")) {
                var myFrame = document.getElementById("myframe").contentWindow;
                if (myFrame && myFrame.PowerForm)
                    PowerForm = myFrame.PowerForm;
            }
            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnStop) {
                    var e = self;
                    e.isValid = true;
                    PowerForm.EventBeforeOnBtnStop(e);
                    if (e.isValid == false) return;  //验证没通过，则不执行后续操作
                }
            }

            var width = self.GetPhoneWidth(780);
            var height = self.GetPhoneHeight(580);
            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkFlowStop.html",
                showMaxButton: true,
                width: width, height: height,
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

        //---------------------------------------作废--------------------------
        //作废
        ScrapWorkFlow: function (data, events, flowOperate) {
            var self = this;
            var result = {};
            result.success = true;

            if (document && document.getElementById("myframe")) {
                var myFrame = document.getElementById("myframe").contentWindow;
                if (myFrame && myFrame.PowerForm)
                    PowerForm = myFrame.PowerForm;
            }
            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnStop) {
                    var e = self;
                    e.isValid = true;
                    PowerForm.EventBeforeOnBtnStop(e);
                    if (e.isValid == false) return;  //验证没通过，则不执行后续操作
                }
            }

            var width = self.GetPhoneWidth(780);
            var height = self.GetPhoneHeight(580);
            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/WorkFlowScrap.html",
                showMaxButton: true,
                width: width, height: height,
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
                    msg.data.FlowOperate = EFlowOperate.Scrap;  //执行终止操作

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

            if (document && document.getElementById("myframe")) {
                var myFrame = document.getElementById("myframe").contentWindow;
                if (myFrame && myFrame.PowerForm)
                    PowerForm = myFrame.PowerForm;
            }
            if (PowerForm) {
                if (PowerForm.EventBeforeOnBtnDelegate) {
                    var e = self;
                    e.isValid = true;
                    PowerForm.EventBeforeOnBtnDelegate(e);
                    if (e.isValid == false) return;  //验证没通过，则不执行后续操作
                }
            }

            var width = self.GetPhoneWidth(780);
            var height = self.GetPhoneHeight(580);
            var win = mini.open({
                url: "/Form/OpenURL?url=/PowerPlat/WorkFlows/DelegateSelect.html",
                showMaxButton: true,
                width: width, height: height,
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


            var url = "/Form/OpenURL?url=/PowerPlat/WorkFlows/ShowMonitorVIS.html";

            var width = this.GetPhoneWidth(780);
            var height = this.GetPhoneHeight(580);
            var win = mini.open({
                url: url,
                width: width, height: height,
                title: "流程监控",
                buttons: "max close",
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(data, win);
                },
                ondestroy: function (action) {
                }
            });
 
        },

        //转发操作
        Forward:function(data,events,flowOperate){

        debugger;
             mini.open({
                url: "/PowerPlat/WorkFlows/Commons/SelectUser.html",
                title: '人员选择', width: "800px", height: "600px",
                allowDrag: true, allowResize: true, showCloseButton: true, showMaxButton: true, showModal: true, showInBody: true,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    var tmpNode = {};
                    tmpNode.SourceMode = "DeptAndUser";   //默认是选择部门 
                    tmpNode.AllowRestore =  false;    //是否最后要返还给本人
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
                    onForwardUserList(data,userList);
                }
            });
        }, 

       
    }
}


