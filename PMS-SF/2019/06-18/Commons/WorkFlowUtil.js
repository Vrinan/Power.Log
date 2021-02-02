
var NetWorkData = {};  //渲染后数据

var getEnumsName = function (EnumName, code, dataType) {
    var lst = SelectData[EnumName];
    if (!lst) {
        alert("枚举[" + EnumName + "]无法提取");
        return;
    }

    var len = lst.length;
    for (var irow = 0; irow < len; irow++) {
        switch (dataType) {
            case "Int":
                if (lst[irow].ID != code) continue;
                break;
            case "String":
                if (lst[irow].Code != code) continue;
                break;
        }
        return lst[irow].Text;
    }
    return '';
}
var showSequeInfo = function (record) {
    var result = '';
    if (!record.SubTreePath) {
        result = record.BeforeSequeID + "->" + record.SequeID;
        return result;
    }


    var dataList = gdPastNodeList.getData();
    var subPath = record.SubTreePath.split(",");
    var sOutput = '<table border="0" style="width:100%"  >';
    sOutput += '<tr>';
    sOutput += "<td>";
    var sTmpInfo = '';
    $.each(dataList, function () {
        if (record.BeforeSequeID == this.SequeID)   //得到主发起人
        {
            if (!sTmpInfo)
                sTmpInfo += this.SequeID;
            else
                sTmpInfo += "<br />" + this.SequeID;

        }

        //得到被过滤的发起人
        for (var irow = 0; irow < subPath.length; irow++) {
            if (!subPath[irow]) continue;
            if (this.SequeID == subPath[irow]) {
                sTmpInfo += "<br />" + this.SequeID;
            }
        }
    });
    sOutput += sTmpInfo + "</td>";
    sOutput += "<td style='vertical-align:middle'>->" + record.SequeID + "</td>";
    sOutput += '</table>';

    return sOutput;
}
//显示人员信息
var showUserInfo = function (record) {
    var result = '';
    if (!record.SubTreePath) {
        if (record.BeforeUserName)
            result = record.BeforeUserName + "-->" + record.UserName;
        else
            result = record.UserName;
        return result;
    }
    var dataList = gdPastNodeList.getData();
    var subPath = record.SubTreePath.split(",");
    var sOutput = '<table border="0" style="width:100%"  >';
    sOutput += '<tr>';
    sOutput += "<td>";
    var sTmpInfo = '';

    $.each(dataList, function () {
        if (record.BeforeSequeID == this.SequeID)   //得到主发起人
        {
            if (sTmpInfo == '')
                sTmpInfo += this.UserName;
            else
                sTmpInfo += "<br />" + this.UserName;
        }

        //得到被过滤的发起人
        for (var irow = 0; irow < subPath.length; irow++) {
            if (!subPath[irow]) continue;
            if (this.SequeID == subPath[irow]) {
                sTmpInfo += "<br />" + this.UserName;
            }
        }
    });
    sOutput += sTmpInfo + "</td>";
    sOutput += "<td style='vertical-align:middle'>-->" + record.UserName + "</td>";
    sOutput += '</table>';

    return sOutput;

}

var getMindDate = function (sequeID) {
    var result = '';
    $.each(MindData, function () {
        if (this.BeforeSequeID == sequeID && this.Content) {
            result = this.RecvDate;
            return result;
        }
    });
    return result;
}

Array.prototype.contains = function (obj) {
    var i = this.length;
    while (i--) {
        if (this[i] === obj) {
            return true;
        }
    }
    return false;
}

var getMindContent = function (mindData,sequeID) {
    var result = '';
    $.each(mindData, function () {
        if (this.SequeID == sequeID && this.Content) {
            result = this.Content;
            return result;
        }
    });
    return result;
}
//显示意见信息
var showMindInfo = function (record) {
    var result = '';
    var OutputLst = [];
    var dataList = gdPastNodeList.getData();
    var subPath = record.SubTreePath.split(",");


    $.each(dataList, function () {
        if (this.SequeID == record.BeforeSequeID)   //得到主发起人
        {
            var content = getMindContent(MindData,this.SequeID);
            if (!content) return;
            sOutput = this.UserName + "： " + content;
            if (OutputLst.contains(sOutput) == false) OutputLst.push(sOutput);
        }
        //得到被过滤的发起人
        for (var irow = 0; irow < subPath.length; irow++) {
            if (!subPath[irow]) continue;
            if (this.SequeID == subPath[irow]) {
                var content = getMindContent(MindData, this.SequeID);
                if (!content) return;
                sOutput = this.UserName + "： " + content;
                if (OutputLst.contains(sOutput) == false) OutputLst.push(sOutput);
            }
        }
    });
    return OutputLst.join("<br />");
}
var showRecvDate = function (record) {
    var result = '';

    if (!record.SubTreePath) return mini.formatDate(record.RecvDate, "MM-dd HH:mm");

    var sOutput = '';
    var dataList = gdPastNodeList.getData();
    var subPath = record.SubTreePath.split(",");
    $.each(dataList, function () {
        if (record.BeforeSequeID == this.SequeID)   //得到主发起人
        {
            if (sOutput != '') sOutput += "<br />";
            sOutput += mini.formatDate(getMindDate(this.SequeID), "MM-dd HH:mm");
        }
        //得到被过滤的发起人
        for (var irow = 0; irow < subPath.length; irow++) {
            if (!subPath[irow]) continue;
            if (this.SequeID == subPath[irow]) {
                sOutput += "<br />" + mini.formatDate(getMindDate(this.SequeID), "MM-dd HH:mm");
            }
        }
    });
    return sOutput;
}
//日期如果是 1901，则返回空
var CheckDate = function (value) {
    if (value.getFullYear() <= 1901) return "--";
    return value;
}

//传入字符串依据指定长度换行
// len分隔长度, count 分隔次数
var changeStrTT = function (str, len ) {
    if (str == null || str == "") {
        return "";
    }
   
    if (len == null) {
        len = 10;
    }
    var result = "";
    var curlen = 0;
    var patten = /.*[\u4e00-\u9fa5]+.*$/;
    var iTmpRow = 1;  //换行次数
    for (var i = 0; i < str.length; i++) {
        if (patten.test(str[i])) {
            curlen += 2;
        } else {
            curlen++;
        }
        if (curlen >= len) {
            curlen = 0; 
            result += "<br />";
            iTmpRow++;
        }
        result += str[i];
    }
    return result;
}



//显示阴影
var changeChosenNodeShadowSize = function (values, id, selected, hovering) {
    values.shadowSize = 30;
}
//显示鼠标移入阴影
var changeChosenNodeShadowColor = function (values, id, selected, hovering) {
    values.shadowColor = "#ffff00";
}
//连线绘制箭头 
var changeChosenEdgeToArrowScale = function (values, id, selected, hovering) {
    // values.toArrowScale = 0;
}
var changeChosenEdgeShadow =
    function (values, id, selected, hovering) {
        values.shadow = true;
        values.shadowColor = "#00ffff";
    }
 
var changeChosenEdgeShadowColor =
  function (values, id, selected, hovering) {
      values.shadowColor = "#00ffff";
  }

var changeChosenEdgeShadowSize =
  function (values, id, selected, hovering) {
      values.shadowSize = 20;
  }

var changeChosenEdgeShadowX =
  function (values, id, selected, hovering) {
      values.shadowX = -5;
  }

var changeChosenEdgeShadowY =
  function (values, id, selected, hovering) {
      values.shadowY = -5;
  }
 
//------------------------------------------------------------------------------------------------




//数据格式转化为流程图编辑模式
var FormatDataToWorkFlow = function (workFlowJson) {

    var nodeList = [];
    $.each(workFlowJson.NodeList, function () {
        var node = {};
        node.x = this.left;
        node.y = this.top;
        node.size = this.width;
        node.label = this.NodeName;
        node.id = this.NodeCode;

        node.shadow = true;  //显示阴影
        node.chosen = { label: false, node: changeChosenNodeShadowColor };
        node.group = 'Node';
        node.connections = [];

        nodeList.push(node);
    });
    NetWorkData.NodeList = new vis.DataSet(nodeList);

    var lineList = [];
    $.each(workFlowJson.LineList, function () {
        var line = {};
        line.from = this.FromNode;
        line.to = this.ToNode;
        line.label = this.title;
        line.chosen = { label: false, edge: changeChosenEdgeToArrowScale };
        line.group = 'Line';
        lineList.push(line);
    });

    NetWorkData.LineList = new vis.DataSet(lineList);


    var data = {
        nodes: NetWorkData.NodeList,
        edges: NetWorkData.LineList
    }

    return data;
}
var changeChosenEdgeDashes =
  function (values, id, selected, hovering) {
      values.dashes = [10, 10];
  }
//绘制一根线
var DrawLine = function (line, record, Agreelable, DisagreeLabel) {
    line.title =   record.SequeID + ".  ";
    line.arrows = { from: { type: "circle" }, to: { type: "arrow" } };   //默认是箭头 
    line.chosen = { label: false, edge: changeChosenEdgeShadow };
   
    var content = getMindContent(MindData, record.BeforeSequeID); 

    if (content && content.length>2) //有实际意见
    {
        line.color = { "color": "rgba(33,32,132,1)", "inherit": false };
        line.width = 3; //有实际意见，设粗
    }
    else {
        line.width = 1; 
        content = Agreelable;
    }
   
    switch (record.InboxStatus) {
        case EFlowInboxStatus.WaitingSign:  //等候签收
            line.title += "(等候签收)<br />";
            line.dashes = [2, 2, 10, 10];   //断续线
          //  line.color = { "color": "rgba(133,32,132,1)", "inherit": false };
            break;
        case EFlowInboxStatus.Normal:  //已签收在处理中
            line.title += "(阅读处理中...)<br />";
          //  line.color = { "color": "rgba(133,32,132,1)", "inherit": false };
            break;
        case EFlowInboxStatus.Hidden:  //隐藏中   
            line.title += "(隐藏等待中...)<br />";
        //    line.color = { "color": "rgba(147,144,144,0.49)", "inherit": false };
            line.dashes = true;  //设为虚线
            break; 
        default:
            line.title += "(已处理...)<br />";
            line.color = { "color": "rgba(0,144,0,0.49)", "inherit": false };
            break;
    }

    switch (record.FlowOperate) {
        case ECanFlowOperate.Return:    // //驳回  枚举  
            line.title = "[驳回操作]" + line.title; 
            line.color = { color: 'red' };
            break;
        case ECanFlowOperate.Stop:   //终止操作
            line.title = "[终止操作]" + line.title;
            line.arrows.to.type = "circle";  //终止操作，目标不是箭头，是原点
          //  line.chosen = { label: false, edge: changeChosenEdgeDashes };
            line.color = { color: 'red' }; 
            break;
    }
 
    //30个 字换一行
    line.title += "<b>" + record.UserName + " 同志</b> :<br /> 您好! <br />" + changeStrTT(content,30) + "<br /><br />" + record.BeforeUserName + "  " + mini.formatDate(record.RecvDate, "yyyy-MM-dd HH:mm") + " 致";

    return line;
   
}
//获取某个节点的所有状态 ,Waiting/Noraml/Hidden/WorkStop/WorkEnd 等
var GetNodeInboxStatus = function (pastNodeList,nodeCode) {
    var result ="";
    $.each(pastNodeList, function () {
        if (this.NodeCode != nodeCode) return;

        if (result.indexOf(this.InboxStatus) >= 0) return;

        result += this.InboxStatus + ",";
    });
    if (result != "") result = result.substring(0, result.length - 1);
    return result;
}


//判断某个连线对应的节点上，是否已经有同类连线(非虚线,非隐藏)
var checkLine = function (lineList, tmpFrom,tmpTo,groupCode) {

    var flag = false;
    $.each(lineList, function () {
        if(this.group  != groupCode) return;
        if (this.from == tmpFrom && this.to == tmpTo && this.hidden==false) {
            flag = true;
            return;
        }
    });
    if (flag == true) return flag;
    return flag;
}
//数据格式转化为监控格式
//修改步骤范围
var ChangeFlowWorkSequeRange = function (  MaxSequeID) {
   
    $.each(NetWorkData.LineList._data, function () {
         
        this.hidden = (parseInt(this.label) > MaxSequeID);
       
        NetWorkData.LineList.update([this]);
    });

    //流程图对应连线 
    $.each(workFlowJson.LineList, function () {
        
        var blnIsHidden = checkLine(NetWorkData.LineList._data, this.FromNode, this.ToNode, "PastNodes.Line");   //已经手节点对应 流程图级连线就不显示了，否则虚线显示
        
        var line = NetWorkData.LineList._data[this.LineCode];
        if (!line) return;
        line.hidden = blnIsHidden;
        NetWorkData.LineList.update([line]);
    }); 
}

//数据格式转化为监控格式
//修改步骤范围
var ChangePastWorkSequeRange = function ( MaxSequeID) {
    
    $.each(PastListData.LineList._data, function () { 
        this.hidden = (parseInt(this.id) > MaxSequeID);
       
        PastListData.LineList.update([this]);
    });
    $.each(PastListData.NodeList._data, function () {

        this.hidden = (parseInt(this.id) > MaxSequeID);
         PastListData.NodeList.update([this]);
        
    });
    
}
var DrawNodeStyle = function (node, nodeInboxStatus) {

    //有隐藏状态
    if (nodeInboxStatus.indexOf(EFlowInboxStatus.Hidden) >= 0) {
        node.shapeProperties = { borderDashes: [5, 5] };
    }

    if (nodeInboxStatus.indexOf(EFlowInboxStatus.Normal) >= 0) {
        node.borderWidth = 2;    //设置边框加粗 
        node.color = { border: 'red' };
    }

    if (nodeInboxStatus.indexOf(EFlowInboxStatus.WaitingSign) >= 0) {
        node.borderWidth = 2;    //设置边框加粗
        node.shapeProperties = { borderDashes: [5, 5] };  //虚线？
        node.color = { border: 'red' };
    }
    if (nodeInboxStatus.indexOf(EFlowInboxStatus.WorkEnd) >= 0) {
        node.borderWidth = 1;    //设置边框加粗  
    }
    if (nodeInboxStatus == "")  //如果某节点没有任何状态，说明此节点尚未走到
    {
        node.borderWidth = 0;    //设置边框为0 说明此节点尚未经手
    }
}

var FormatDataToShowMonitor = function (workFlowJson, pastNodeList, Agreelable, DisagreeLabel) {
     
    var nodeList = [];
    var level = 0;
    $.each(workFlowJson.NodeList, function () {
         
        var node = {};
        node.x = this.left;
        node.y = this.top;
          
        node.label = this.NodeName  ;
        node.id = this.NodeCode; 
        node.shadow = true;  //显示阴影
        node.chosen = { label: false, node: changeChosenNodeShadowColor };
        node.group = 'Node';
        node.connections = [];
        node.level = level;
        node.shape = "image";
        node.image = "/PowerPlat/WorkFlows/Images/"+ this.NodeType +".png";
         
        var nodeInboxStatus = GetNodeInboxStatus(pastNodeList,this.NodeCode);
        DrawNodeStyle(node, nodeInboxStatus);
      
        nodeList.push(node);
    });
    NetWorkData.NodeList = new vis.DataSet(nodeList);

    var lineList = [];
    //流转记录对应 连线
    $.each(pastNodeList, function () {
        var line = {};
        line.id = this.SequeID;
        line.from = this.FromNodeCode;
        line.to = this.NodeCode;
        line.hidden = false;
        if (this.BeforeSequeID == 0) return;  //起草第一条记录忽略
        //   line.chosen = { label: false, edge: changeChosenEdgeToArrowScale };       

        line.group = 'PastNodes.Line';
       
        line = DrawLine(line, this, Agreelable, DisagreeLabel);

        line.label = this.SequeID;
         
        lineList.push(line);
    });
    //流程图对应连线 
    $.each(workFlowJson.LineList, function () {
        var line = {};
        line.id = this.LineCode;
        line.from = this.FromNode;
        line.to = this.ToNode; 
        // line.chosen = { label: false, edge: changeChosenEdgeToArrowScale };
        line.dashes = true;  //设为虚线
        line.color = { "color": "rgba(132,128,123,1)", "inherit": false };  //淡灰色
        line.group = 'WorkFlow.Line';

        line.hidden = checkLine(lineList, line.from, line.to, "PastNodes.Line");   //已经手节点对应 流程图级连线就不显示了，否则虚线显示
        lineList.push(line);
    });

    NetWorkData.LineList = new vis.DataSet(lineList);
     
    var data = {
        nodes: NetWorkData.NodeList,
        edges: NetWorkData.LineList
    }

    return data;
}

//pwf_pastnodes数据数据格式转化
var FormatPastDataToVis = function (pastNodeList, mindData, Agreelable, DisagreeLabel) {

    var nodeList = [];
    var lineList = [];

    $.each(pastNodeList, function () {
        var node = {};
 
        node.label = this.UserName + "\r\n" + this.ActName;

        node.id = this.SequeID;
        node.shadow = true;  //显示阴影
        node.chosen = { label: false, node: changeChosenNodeShadowColor };
        node.group = 'usergroups';
        node.NodeCode = this.NodeCode;
        node.NodeName = this.ActName;

        switch (this.InboxStatus) {
            case EFlowInboxStatus.WaitingSign:  //等候签收
                node.borderWidth = 2;    //设置边框加粗
                node.shapeProperties = { borderDashes: [5, 5] };
                node.color = { border: 'red' };        
                break;
            case EFlowInboxStatus.Normal:
                node.borderWidth = 2;    //设置边框加粗 
                node.color = { border: 'red' };
                break;
            case EFlowInboxStatus.Hidden:   //隐藏状态
                node.shapeProperties = { borderDashes: [5, 5] };
                break;
        } 

        nodeList.push(node);

        if (this.BeforeSequeID == 0) return;

        var line = {};
        line.id = this.SequeID;
        line.label = line.id;
        line.font = { align: 'bottom' };
        line.from = this.BeforeSequeID;
        line.to = this.SequeID;
      
        line = DrawLine(line, this, Agreelable, DisagreeLabel);

        lineList.push(line);
    });
    PastListData.NodeList = new vis.DataSet(nodeList);
    PastListData.LineList = new vis.DataSet(lineList);


    var data = {
        nodes: PastListData.NodeList,
        edges: PastListData.LineList
    }

    return data;
}