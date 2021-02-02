

//公共静态方法
var WorkFlowUtil = {
    OtherMindList:[], 
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
    onShowOtherMind : function () {
        var td = "";

        $.each(WorkFlowUtil.OtherMindList, function () {
            td += this.BeforeUserName + " -> " + this.UserName + " : " + this.Content + "    [" + fomateDate(this.RecvDate, "YYYY-MM-DD hh:mm") + "]  \r\n";
        });

        alert(td);
    },
   
    DrawItem: function (mindList, node, Agreelable, DisagreeLabel ) {
        var tb = '';
        var tbtwo = '';
     
        var tmpTb = '';
        if ((node.NodeType == "StartNode" || node.NodeType == "SubNode") && WorkFlowUtil.OtherMindList && WorkFlowUtil.OtherMindList.length > 0) {
            tmpTb += "&nbsp;&nbsp;<a href='#' onclick='javascript:WorkFlowUtil.onShowOtherMind()'>更多</a>";
        }

        if (node.InboxStatus)
            tb += "<tr><td  style=\"width:50%\">" + node.UserName + ":   " + node.NodeName + "(" + node.InboxStatus + ")   " + tmpTb + "</td > <td align='right'>" + mini.formatDate(node.MindDate, "MM-dd HH:mm") + "</tr>";
        else
            tb += "<tr><td  style=\"width:50%\">" + node.UserName + ":   " + node.NodeName + tmpTb + "</td > <td align='right'>" + mini.formatDate(node.MindDate, "MM-dd HH:mm") + "</tr>";

        tbtwo += "<tr><td></td>";
        var c = Agreelable;  //同意意见
        if (node.FlowOperate == EFlowOperate.Return)
            c = DisagreeLabel; //不同意意见
        if (node.Content )
            c = node.Content;
        if (node.SequeID <= -2)   //<=-2说明是系统消息
            c = "<font color='red'>" + node.Content + "<font>";

        if (node.IsCancel == 1)  //说明是作废的意见，所谓作废， 就是记录跑一半，又回到起草节点重新跑。
        {
            c = "<s>" + c + "</s>";
        }
        tbtwo += "<td><p>" + c + "</p></td></tr>";
        if (node.InboxStatus) tbtwo = '';
        return tb + tbtwo;
    },
   
     
    //绘制意见栏目
    DrawMindList: function (div, mindList, otherMindList, Agreelable, DisagreeLabel) {
       
        WorkFlowUtil.OtherMindList = otherMindList;
        var tb = "<table style=\"width:100%\"  border='1' >";
        for (var iTmp = 0, len = mindList.length; iTmp < len; iTmp++) {

            var node = mindList[iTmp]; 
       
             
            tb += WorkFlowUtil.DrawItem(mindList, node, Agreelable, DisagreeLabel);

        }
        tb += "</table>";
        div.empty();
        div.append(tb);

    },
    //绘制意见栏目
    DrawOtherMindList: function (div, mindList, Agreelable, DisagreeLabel) {

        var tb = "<table style=\"width:100%\"  border='1' >";
        for (var iTmp = 0, len = mindList.length; iTmp < len; iTmp++) {

            var node = mindList[iTmp];
            // if (node.InboxStatus == EFlowInboxStatus.Hidden) continue;  //隐藏的记录暂时不显示 

            if (typeof (node["FlowOperate"]) != "undefined" && node.FlowOperate == EFlowOperate.EndFlow) continue;  //如果是办结操作，则无视掉 
            //记录如果是隐藏，则不显示
            //  if (node.InboxStatus == EFlowInboxStatus.Hidden) return;
            tb += "<tr><td style=\"width:100px\">" + node.BeforeUserName + " -> " + node.UserName + "</td> ";
            tb += "<td> " + node.MindDate + " </td>";
            tb += "<tr><td></td> <td align='left'>" + node.Content + "</td></tr>";
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
                    result.data.ResultInfo = mini.decode(result.data.ResultInfo);
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