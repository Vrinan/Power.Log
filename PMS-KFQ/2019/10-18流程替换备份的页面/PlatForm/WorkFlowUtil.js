 

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
    GetOperate: function (flowOperate, userName) {
        var flowString = "";
        if (!userName) return flowString;
        switch (flowOperate) {
            case EFlowOperate.Send:
                flowString = ""; break;
            case EFlowOperate.Return:
                flowString = "退回"; break;//"退回"
            case EFlowOperate.Stop:
                flowString = "终止"; break;//"终止"
            case EFlowOperate.Scrap:
                flowString = "作废"; break;//"作废"
            case EFlowOperate.CheckOut:
                flowString = "签收"; break;//"签收"
            case EFlowOperate.Delegate:
                flowString = "委派给 [" + userName + "]"; break;//"委派给他人" 
            case EFlowOperate.EndFlow:
                flowString = "办结"; break;//"办结"
            default:
                flowString = ""; break;

        }
        return flowString;
    },
    //wsl算法做了调整，依据参数，提取上个节点的操作信息
    GetOperate: function (node, toUserName) {
        var flowString = "";
        if (!toUserName) return flowString;

        switch (node.FlowOperate) {
            case EFlowOperate.Active:
                flowString = "送审"; break;
            case EFlowOperate.Send:
                flowString = "发送 [" + toUserName + "]"; break;
            case EFlowOperate.Return:
                flowString = "驳回" + "[" + toUserName + "]"; break; //"退回"
            case EFlowOperate.Stop:
                flowString = "终止"; break; //终止
            case EFlowOperate.Scrap:
                flowString = "作废"; break; //作废
            case EFlowOperate.CheckOut:
                flowString = "签收"; break; //签收
            case EFlowOperate.Delegate:
                if (node.IsReturnDelegateRoot == false)
                    flowString = "委派给他人" + "[" + toUserName + "]";
                else
                    flowString = "委派返还发起人" + "[" + toUserName + "]";
                break; //委派给他人
            case EFlowOperate.DelegateAndReturn:
                flowString = "委派返还发起人" + "[" + toUserName + "]"; break; //委派并须返还
            case EFlowOperate.EndFlow:
                flowString = "办结"; break; //办结
            default:
                flowString = ""; break;

        }
        return flowString;
    },
    DrawItem: function (node, Agreelable, DisagreeLabel) {
        var tb = '';
        var flowString = "";
        
		if (node.InboxStatus ==EFlowInboxStatus.WorkStop) return '';  //应老江意见， workstop的记录不显示了。。。

        flowString = WorkFlowUtil.GetOperate(node, node.ToUserName);
        var firstUser = node.BeforeUserName; //node.UserName.substring(0, 1);
        if (!firstUser) return '';
        if (flowString)
            tb += "<tr><td  style=\"width:50%\">" + firstUser + ":   " + node.ActName + " (" + flowString + ")</td><td align='right'>" + mini.formatDate(node.RecvDate, "MM-dd HH:mm") + "</tr>";
        else
            tb += "<tr><td  style=\"width:50%\">" + firstUser + ":   " + node.ActName + "</td><td align='right'>" + mini.formatDate(node.RecvDate, "MM-dd HH:mm") + "</tr>";

        var c = Agreelable;  //同意意见
        if (node.FlowOperate == EFlowOperate.Return)
            c = DisagreeLabel; //不同意意见
        if (node.BeforeContent && node.BeforeContent != "")
            c = node.BeforeContent;
        if (node.SequeID <= -2)   //<=-2说明是系统消息
            c = "<font color='red'>" + c + "<font>";

        switch (node.InboxStatus) {
            case EFlowInboxStatus.WaitingSign:
                tb += "<tr><td  ></td><td   >等候签收</td></tr>";
                break;
            case EFlowInboxStatus.Hidden:
                tb += "<tr><td  ></td><td   >" + c + "   (隐藏等待中)</td></tr>";
                break;
            case EFlowInboxStatus.WaitingUnlock:
                tb += "<tr><td  ></td><td   >等候解锁</td></tr>";
                break;
            case EFlowInboxStatus.Delegated:
                if (c)
                    tb += "<tr><td  ></td><td   >" + c + "</td></tr>";
                else
                    tb += "<tr><td  ></td><td   >委派</p>";
                break;
            case EFlowInboxStatus.WorkEnd:
                tb += "<tr><td  ></td><td   >" + c + "</td></tr>";
                break;
            case EFlowInboxStatus.WorkStop:
                if (c)
                    tb += "<tr><td  ></td><td   >" + c + "</td></tr>";
                else
                    tb += "<tr><td  ></td><td   >已终止</p>";
                break;
            default:
                if (c)
                    tb += "<tr><td  ></td><td   >" + c + "</td></tr>";
                else
                    tb += "<tr><td  ></td><td   >正在办理</p>"; //正在办理
                break;
        }


        return tb;
    },

    
    ///田国斌 需求
    DrawTIANGUOBINGItem: function (node, Agreelable, DisagreeLabel) {
        var tb = '';
        var flowString = "";

        if (node.FlowOperate == EFlowOperate.Active) return '';  //第一条送审记录不显示


        flowString = WorkFlowUtil.GetOperate(node, node.ToUserName);
        var firstUser = node.BeforeUserName ; //node.UserName.substring(0, 1);


        tb += "<tr><td style=\"width:100px\">" + firstUser + ":</td> ";
        if (!node.BeforeContent) node.BeforeContent = "";
        tb += " <td align='left'>" + node.BeforeContent +"</td></tr>";


        var c =  Agreelable;  //同意意见
        if (node.FlowOperate == EFlowOperate.Return)
            c =  DisagreeLabel; //不同意意见

        //  if (node.BeforeContent && node.BeforeContent != "")
        //      c = node.BeforeContent;
        if (node.SequeID <= -2)   //<=-2说明是系统消息
            c = "<font color='red'>" + c + "<font>";

        
        switch (node.InboxStatus) {
            case EFlowInboxStatus.WaitingSign:   //等候签收
                alert("waiting");
                break;
            default:
               
                tb += "<tr><td  ></td><td     >" + c + " </td></tr>";
                break;
        }
        tb += "<tr><td ></td><td align='right'>审批日期：" + mini.formatDate(node.RecvDate, "yyyy-MM-dd HH:mm") + "</td></tr>";

        return tb;
    },
    //绘制意见栏目
    DrawMindList: function (div, mindList, Agreelable, DisagreeLabel) {
        
        var tb = "<table style=\"width:100%\"  border='1' >";
        for (var iTmp = 0, len = mindList.length; iTmp < len; iTmp++) {

            var node = mindList[iTmp];
           // if (node.InboxStatus == EFlowInboxStatus.Hidden) continue;  //隐藏的记录暂时不显示 

            if (typeof (node["FlowOperate"]) != "undefined" && node.FlowOperate == EFlowOperate.EndFlow) continue;  //如果是办结操作，则无视掉
            if (node.Alias != "MindRecord") continue;

           

            //记录如果是隐藏，则不显示
            //  if (node.InboxStatus == EFlowInboxStatus.Hidden) return;
           tb += WorkFlowUtil.DrawItem(node, Agreelable, DisagreeLabel);
           
        }
        tb += "</table>";
        div.empty();
        div.append(tb);

    }
}

//私有域
var PowerWorkFlowUtil = {
    //关闭窗体
    TransRecord: function (subOperate) {

        if (!mini.get("txtCurrentWorkInfoID")) {
            alert("没有找到对象[txtCurrentWorkInfoID]，请绘制");
            return;
        }
        var CurrentInfo = {};
        CurrentInfo.SubOperate = subOperate;   //子指令集.导出实例
        var sWorkInfoID = mini.get("txtCurrentWorkInfoID").getValue();
        if (!sWorkInfoID) {
            alert("没有找到workInfoID ，请先流转");
            return;
        }
        CurrentInfo.WorkInfoID = sWorkInfoID;
        mini.mask({
            el: document.body,
            cls: 'mini-mask-loading',
            html: '加载中...'
        });
        var msg = {};
        msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
        msg.data = CurrentInfo;
        msg.data.FlowOperate = EFlowOperate.SupplyDesign;    //提取流程节点信息
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
                mini.unmask(document.body);
               
                if (result.data.ResultInfo) {
                    result.data.ResultInfo =  mini.decode(result.data.ResultInfo);
                     return;
                }
                 
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (CurrentSender) CurrentSender.setEnabled(true);

                mini.unmask(document.body);
                Power.ui.error(jqXHR.responseText, { timeout: 0, position: "center center", closeable: true });

            }
        });
    },

}