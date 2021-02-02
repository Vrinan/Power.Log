var power = power || {};
power.workflow = power.workflow || {};

var FlowNodeType = power.workflow.FlowNodeType = {
    StartNode: 10,   //起草节点
    EndNode: 20,      //结束节点
    GeneralNode: 30,   //普通节点
    ConcurrentNode: 50,   //并发节点
    ConvergeNode: 40,      //汇合节点
    BranchNode: 60,              //分支节点
    SubNode: 100         //子流程
}

var FlowRecordStatus = power.workflow.FlowRecordStatus = {
    Finish: 50,   //完成状态
    Flowing: 20,      //流转状态
    Create: 10,   //初始起草状态(此时尚未选择工作流, 没有WorkFlowID/Version)
    Initial: 15,   // 初始起草状态(创建),已经绑定了工作流，但未执行过发送
    Waiting: 30,      //挂起等候状态
    Stop: 40,    //终止状态
    Hidden: 60,         //隐藏状态，并发时用到
    None: 100         //默认空状态
}

var FlowInboxStatus = power.workflow.FlowInboxStatus = {
    None: 10,   // 空状态，默认
    Hidden: 30,      //隐藏状态
    Normal: 20,   //正常状态
    WaitingUnlock: 50,   // 等候解锁
    WaitingSign: 40,      //等候签收
    WorkEnd: 60     //本线支路结束 
}

var FlowTargetType = power.workflow.FlowTargetType = {
    DesignUser: 20,   //定义时指定了用户
    WorkUser: 30,      //WorkUser 流转时指定了用户
    Only: 40    //Only 没有指定人员，只指定了部门或岗位
}

var FlowSourceMode = power.workflow.FlowSourceMode = {
    DeptAndUser: 30,   // 部门用户
    PositionAndUser: 40,  //岗位用户
    Dept: 10,      //部门
    Position: 20    //岗位
}

var FlowOperate = power.workflow.FlowOperate = {
    None: 1,     /// 无操作 
    Insert: 2,    ///  保存操作 
    Update: 4,     ///  修改操作 
    Delete: 8,     ///  删除操作 
    Send: 16,     ///  发送操作 
    Return: 32,      ///  回退操作 
    EndFlow: 64,    ///  签批操作       
    GetBack: 128,  ///  回收操作
    CheckOut: 256,      ///  签收操作 
    Delegate: 512,    /// 直接委派操作
    DelegateAndReturn: 1024,    /// 委派返还操作
    Stop: 2048,      /// 终止流程 
    Active: 4096,      /// 激活流程 
    ShowFlowMonitor: 8192,  ///  流程监控,
    ShowStopedFlowMonitor: 16384  ///  被终止流程监控,
}

//渲染意见信息显示
var DrawMindList = function (mindList) {
    for (var iTmp = 0, len = mindList.length; iTmp < len; iTmp++) {
        var node = mindList[iTmp];
        if (node.Alias != "MindRecord") continue;
        var contect = "";
        var deptname = node.DeptName;
        if (!deptname) deptname = node.DeptPositionName;

        switch (node.InboxStatus) {
            case FlowInboxStatus.WaitingSign:
                contect = node.MindDate + " " + deptname + node.UserName + " [" + node.ActName + "] 等候签收";
                break;
            case FlowInboxStatus.WorkEnd:
                contect = node.MindDate + " " + deptname + node.UserName + " [" + node.ActName + "] 经手";
                break;
            default:
                contect = node.MindDate + " " + deptname + node.UserName + " [" + node.ActName + "] 正在办理";
                break;
        }
        if (node.Content) contect += ",意见信息:" + node.Content;
        node.text = contect;
    }
}