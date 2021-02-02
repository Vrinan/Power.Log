//绘制到界面上
var bindNode = function (data) {

    if (curWin && data.Current && data.Current.PlanEndDate) {
        var curTitle = curWin.getTitle();

       // if (data.Current.PlanEndDate.getFullYear() > 1970)
       //     curWin.setTitle(curTitle + " 期望在 " + fomateDate(data.Current.PlanEndDate, "YYYY-MM-DD hh:mm") + " 之前完成.");
    }

    var mnuNodeList = document.getElementById("mnuNodeList");
    //先清除里面的内容
    mnuNodeList.innerHTML = "";
    
    var nextNodeList = [];
    for (var iTmp = 0; iTmp < data.NextNodeList.length; iTmp++) {
        var node = data.NextNodeList[iTmp];
        if (node.IsCancel == true) continue;
        nextNodeList.push(node);
    }
    data.NextNodeList = nextNodeList;
    var len = data.NextNodeList.length;

    var sOutput = '<table border="1" style="width:100%" cellpadding="2">';
    var sUserPut = '';
     
    for (var iTmp = 0; iTmp < len; iTmp++) {
        
        var node = data.NextNodeList[iTmp];
        
        if (!node.IsLastReturnNode) node.IsLastReturnNode= "false";
        var sNodeName = node.NodeName;
        if (node.IsLastReturnNode == true) sNodeName += "<br />(上次驳回节点)";
        sOutput += '<tr>';
        sOutput += '<td style="width:260px">';
        sOutput += '<div id="chkNode' + node.NodeCode + '" data-options="{\'SelectNodeMode\':\'' + node.SelectNodeMode + '\',\'LineType\':\'' + node.LineType + '\',\'IsLastReturnNode\':\''+ node.IsLastReturnNode + '\'}"  class="mini-checkbox" text="' + sNodeName + '" onclick="onResetList(\'' + node.NodeCode + '\',\'false\')"';
        sOutput += '></div></td>';

        var sUserBox = 'mini-radiobuttonlist';
        if (node.AllowMulitUser == true)     //多选切是发送操作，才能checkboxlist 多选节点，（ 退回操作也是多节点，但只能单选) 
            sUserBox = 'mini-checkboxlist';

        sUserPut = '<td>';
        if (node.MustNotUserMessage) sUserPut += '<span>' + node.MustNotUserMessage + '</span>';
        //如果是发送者定义
        if (node.SendUserMode == ESendUserMode.BySendUser) {
           
           // if (node.CanSelectUsers && node.CanSelectUsers.length == 0) 
             sUserPut += '&nbsp;<a class="New_Button" href="javascript:onDesignUserBySend(\'' + node.NodeCode + '\')">选择人员</a>';
            if (node.CanSelectUsers && node.CanSelectUsers.length > 0)  
                sUserPut += '&nbsp;&nbsp;<a class="New_Button2" href="javascript:onDesignUserBySendTwo(\'' + node.NodeCode + '\')">二次筛选</a>';
             
        }
        sUserPut += '<div id="lstNode' + node.NodeCode + '" data-options="{\'SelectUserMode\':\'' + node.SelectUserMode + '\',\'AllowMulitUser\':' + node.AllowMulitUser + '}"  class="' + sUserBox + '"   repeatItems="0" repeatLayout="flow" repeatDirection="horizontal"  textField="UserName" valueField="UserID" enabled="false"  ></div>';
        sUserPut += '</td>';

        sOutput += sUserPut;
        sOutput += '</tr>';

        if (!node.CanSelectCopyUsers || node.CanSelectCopyUsers.length == 0) continue;

        //绘制抄送
        sOutput += '<tr>';
        sOutput += '<td   align="right"><div id="chkCopyNode' + node.NodeCode + '" align="right"  class="mini-checkbox" text="(抄送)" checked="true"  onclick="onResetCopyList(this)" ></div>';
        sOutput += '<div id="btnCopyNode' + node.NodeCode + '" class="mini-button" style="width:20px;height:20px;display:none"  values="+" text=" "  onclick="onSelectedCopyList(this)">';

        sOutput += '</td>';
        sOutput += '<td><div id="lstCopyNode' + node.NodeCode + '"  class="mini-checkboxlist"   repeatItems="0" repeatLayout="flow" repeatDirection="horizontal"  textField="UserName" valueField="UserID"  checked="true" ></div>';
        sOutput += '</td>';
        sOutput += '</tr>';
    }
    sOutput += '</table>';

    var win_column_obj = $(sOutput);
    win_column_obj.appendTo(mnuNodeList);
    mini.parse();
  
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp]; 
        var selectUserList = [];
         
        for (var iRow = 0; iRow < node.CanSelectUsers.length; iRow++) {
            var user = node.CanSelectUsers[iRow];
            if (!user) continue; 
            if (user.SourceUserID && user.UserID != user.SourceUserID) {
                user.UserName += "  " + "代" + "(" + user.SourceUserName + ")";
            }
            if (CheckContireUser(selectUserList, user.UserID) == true) continue;
            selectUserList.push(user);
          
        }

        if (!mini.get("lstNode" + node.NodeCode)) continue;
         
        if (data.NodeList && data.NodeList.length > 0) {
            for (var iRow = 0; iRow < data.NodeList.length; iRow++) {
                var tmpNode = data.NodeList[iRow];
                if (tmpNode.NodeCode != node.NodeCode) continue;
                tmpNode.CanSendUsers = mini.decode( mini.decode(tmpNode.CanSendUsers));
                for (var iCol = 0; iCol < tmpNode.CanSendUsers.length; iCol++) {
                    var user = tmpNode.CanSendUsers[iCol];
                    if (!user) continue; 
                    if (CheckContireUser(selectUserList, user.UserID) == true) continue;
                    if (user.SourceUserID && user.UserID != user.SourceUserID)  
                        user.UserName += "  " + "代" + "(" + user.SourceUserName + ")";
                    selectUserList.push(user);
                }
            }
        }
         
        mini.get("lstNode" + node.NodeCode).setData(selectUserList);
    }
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
      
        if (!node.CanSelectCopyUsers || node.CanSelectCopyUsers.length == 0) continue;

        mini.get("lstCopyNode" + node.NodeCode).setData(node.CanSelectCopyUsers);
        mini.get("lstCopyNode" + node.NodeCode).selectAll();
    }
    debugger;
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
       
        var chkBox = mini.get("chkNode" + node.NodeCode);

        var listBox = mini.get("lstNode" + node.NodeCode);
        switch (chkBox.SelectNodeMode) {
            case "SelectedNode":  //默认选中
                if (chkBox.IsLastReturnNode != "true")  chkBox.setValue(true);   //如果当前是上次驳回 节点， 则默认不选中，免得一下子发出去了。。。
                onResetList(node.NodeCode,true);
             //   listBox.setEnabled(true);
                break;
            case "SelectedAndDisabled": //默认选中且不可撤销 
               if (chkBox.IsLastReturnNode != "true")  chkBox.setValue(true);      //如果当前是上次驳回 节点， 则默认不选中，免得一下子发出去了。。。
                onResetList(node.NodeCode,true);
             //   chkBox.setEnabled(false);
            //    listBox.setEnabled(true);
                break;
            default:
                break;
        }
        var tmpUsers = listBox.getData();
        if (tmpUsers.length == 1 && listBox.AllowMulitUser == false) listBox.setValue(tmpUsers[0].UserID);

      
    }
    
    for (var index = 0; index < len; index++) {
        var node = data.NextNodeList[index];
       
        if (node.DefaultUserID)
            mini.get("lstNode" + node.NodeCode).setValue(node.DefaultUserID);
    }

    if (len == 1) {  
        mini.get("chkNode" + data.NextNodeList[0].NodeCode).setValue(true);
        onResetList(data.NextNodeList[0].NodeCode,true);
    }
}
//验证userid 是否在容器中
var CheckContireUser = function (selectUserList, userid) {
    var result = false;
    $(selectUserList).each(function () {
        if (this.UserID == userid) { result = true; return;}
    });
    return result;
}
//触发节点， isInit=true说明是初始加载，此时无须提示
var onResetList = function (nodeCode, isInit) {
    debugger;
    var chkBox = mini.get("chkNode" + nodeCode);
    var chkCopyBox = mini.get("chkCopyNode" + nodeCode);
    var listBox = mini.get("lstNode" + nodeCode);
    var listCopyBox = mini.get("lstCopyNode" + nodeCode);
    var lineType = chkBox.LineType;
    if (chkBox.checked == true) {
        switch (listBox.SelectUserMode) {
            case "DeselectAll":   //默认不选中 
                listBox.setEnabled(true);
                break;
            case "SelectAll":  //默认全选中
                listBox.selectAll();
                listBox.setEnabled(true);
                break;
            case "SelectAllAndDisabled":  //默认全选中，且不可去掉钩
                if (listBox.type == "checkboxlist") {
                    listBox.selectAll();
                    listBox.setEnabled(false);
                }
                break;
            default:
                listBox.setEnabled(true);
        }
        //如果只有一项内容，直接选中
        if (listBox.getData().length == 1) listBox.setValue(listBox.getData()[0].UserID);
    }
    else {
        listBox.deselectAll();
        listBox.setEnabled(false);
    }
    if (chkCopyBox) {
        chkCopyBox.setEnabled(chkBox.checked);
        chkCopyBox.setValue(chkBox.checked);
        if (listCopyBox) {
            listCopyBox.setEnabled(chkBox.checked);
            if (chkBox.checked == true)
                listCopyBox.selectAll();
            else
                listCopyBox.deselectAll();
        }
    }


    //如果当前是排他线，则取消其他节点的勾
    if (lineType == EFlowLineType.ExcludeLine && chkBox.checked == true) {
        var len = AllData.NextNodeList.length;
        for (var iTmp = 0; iTmp < len; iTmp++) {
            var tmpNodeCode = AllData.NextNodeList[iTmp].NodeCode;
            if (tmpNodeCode == nodeCode) continue;
            var chkOtherBox = mini.get("chkNode" + tmpNodeCode);
            var listOtherBox = mini.get("lstNode" + tmpNodeCode);
            chkOtherBox.setValue(false);
            listOtherBox.setEnabled(false);
        }
    }
   
    //如果当前打钩项是上次驳回的节点，则其他节点禁止选中
    if (chkBox.IsLastReturnNode == "true") {
        if (chkBox.checked == true) {
            var len = AllData.NextNodeList.length;
            for (var iTmp = 0; iTmp < len; iTmp++) {
                var tmpNodeCode = AllData.NextNodeList[iTmp].NodeCode;
                if (tmpNodeCode == nodeCode) continue;
                var chkOtherBox = mini.get("chkNode" + tmpNodeCode);
                var listOtherBox = mini.get("lstNode" + tmpNodeCode);
                chkOtherBox.setValue(false);
                listOtherBox.setEnabled(false);
                if (isInit == "false") Power.ui.info("您选中的是[上次驳回节点]，只能排他性选择");
            }
        }
    }
    else {
        var len = AllData.NextNodeList.length;
        for (var iTmp = 0; iTmp < len; iTmp++) {
            var tmpNodeCode = AllData.NextNodeList[iTmp].NodeCode;
            if (tmpNodeCode == nodeCode) continue;
            var chkOtherBox = mini.get("chkNode" + tmpNodeCode);
            var listOtherBox = mini.get("lstNode" + tmpNodeCode);
            if (chkOtherBox.IsLastReturnNode != "true") continue;
            chkOtherBox.setValue(false);
            listOtherBox.setEnabled(false); 
        }
    }
    return;
}
var onResetCopyList = function (e) {
    var id = e.id;

    var lstId = "lstCopyNode" + id.replace("chkCopyNode", "");
    if (e.checked == true) {
        mini.get(lstId).setEnabled(true);
        mini.get(lstId).selectAll();
    }
    else {
        mini.get(lstId).setEnabled(false);
        mini.get(lstId).deselectAll();
    }
}

var onSelectedCopyList = function (e) {
    var id = e.id;
    var lstId = "lstCopyNode" + id.replace("btnCopyNode", "");
    if (e.SelectedTarget == true) {
        mini.get(lstId).selectAll();
        e.SelectedTarget = false;
    }
    else {
        mini.get(lstId).deselectAll();
        e.SelectedTarget = true;
    }
}

var setSelectUserTab = function () {
    var tabNode = tabMain.getTab("tabSelectUser");
    tabNode.enabled = true;
    tabMain.activeTab(tabNode); 
}

//调取选择人员处理
var CheckSelectUser = function () {
     
    var len = AllData.NextNodeList.length;

    var iCount = 0;
     
    var blnIsSelectedReturnNode = false;  //是否选择了上次驳回的节点
    var IsMindMustInput =false;  //意见是否必填
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = AllData.NextNodeList[iTmp];
        var chkBox = mini.get("chkNode" + node.NodeCode);
        if (chkBox.checked != true) continue;
        if (chkBox.IsLastReturnNode == "true") blnIsSelectedReturnNode = true;

        var listBox = mini.get("lstNode" + node.NodeCode);
        
        var selectList = listBox.getSelecteds();
        if (selectList.length == 0 && node.IsMustNotUsers == false) {
            Power.ui.error("对不起，节点[" + node.NodeName + "]没有选择目标人");
            return false;
        }
        if (node.IsMindMustInput ==true && IsMindMustInput == false) IsMindMustInput = true; //说明有选择的目标节点，设置了需要填写意见
        iCount++;
    }
    if (iCount == 0) {
        alert("对不起，请至少选择一个目标节点"); return false;//"对不起，退回操作只能选择一个目标节点"
    }

    if (blnIsSelectedReturnNode == true && iCount > 1) {
        alert("对不起，您选中了[上次驳回节点]，则不能再同时选择其他节点"); return false;
    }
    //如果当前节点意见必填,或者不是发送操作，则意见必填
    //IsMindMustInput = true;   //发送操作，如果要强制输入意见， 这里写死 true
    if (IsMindMustInput == true) {
        mini.get("txtMindInfo").setRequired(true);
        mini.get("txtMindInfo").setRequiredErrorText("请填写办理意见");//"请填写办理意见"
    }
    else {
        mini.get("txtMindInfo").setRequired(false);
        mini.get("txtMindInfo").setRequiredErrorText(""); 
    }

    if (MyVoteInfo && MyVoteInfo.IsTurnVote == true) {
        var voteValue = mini.get("lstVote").getValue();
        if (!voteValue) {
            Power.ui.alert("对不起，请先投票选择");//"对不起，请先投票选择"
            return null;
        }
    }
    form.validate();
    if (form.isValid() == false) {
        var sErrInfo = "";
        for (var itmp = 0; itmp < form.getErrorTexts().length; itmp++)
            sErrInfo += form.getErrorTexts()[itmp] + "<br />";
        Power.ui.error(sErrInfo);
        return false;
    }
    return true;
}

//提取目标节点可选人员
var GetNodesUser = function (data,flag) {
     
    if (flag == true) setSelectUserTab();
   
    if (data == null || data == "") {
        alert("用户信息提取失败"); return;//"提取失败"
    }
    mini.get("btnOK").setEnabled(true);
     
    curFlowOperate = data.FlowOperate;

    bindNode(data);
     
    //判断是否有期望完成时间要手工定义的，如果有，放开选择日期框
    var len = data.NextNodeList.length; 
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
        
        if (node.InputLimitDaysByRun != true) continue;

        document.getElementById("spnPlanEndDate").style.display = "";
        mini.get("dtPlanEndDate").setVisible(true);
        mini.get("dtPlanEndDate").setRequired(true);
        mini.get("dtPlanEndDate").setRequiredErrorText("请填写期望完成时间");//"请填写办理意见"
        break; 
    }
    
    var div = $("#mindList");
    WorkFlowUtil.DrawMindList(div, data.HistoryMind, data.Agreelable, data.DisagreeLabel);
    if (data.MindInfo)
        mini.get("txtMindInfo").setValue(data.MindInfo);
 

    //渲染投票
    MyVoteInfo = data.VoteInfo;

    if (MyVoteInfo && MyVoteInfo.IsTurnVote == true) {
        var voteType = MyVoteInfo.VoteType;
        var defaultVoteValue = MyVoteInfo.DefaultVoteValue;

        var listHTML = '<div id="lstVote"  ';
        if (voteType == "RadioBox")
            listHTML += 'class="mini-radiobuttonlist" ';
        else
            listHTML += 'class="mini-checkboxlist" ';

        listHTML += '  repeatItems="0" repeatLayout="flow" repeatDirection="horizontal"  textField="VoteName" valueField="VoteCode"  ></div>';

        var divVoteInfo = document.getElementById("divVoteInfo");
        var win_column_obj = $(listHTML);
        win_column_obj.appendTo(divVoteInfo);
        mini.parse();
        mini.get("lstVote").setData(MyVoteInfo.VoteList);

        if (defaultVoteValue) mini.get("lstVote").setValue(defaultVoteValue);
    }
}
//--------------------------意见编辑
var onEditMind = function (e) {
    mini.open({
        url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/CommonMind.html",
        width: 600, height: 400, //title: "流程流转",
        onload: function () {

        },
        ondestroy: function (action) {
            if (action != "ok") return;

            var iframe = this.getIFrameEl();
            var tmpData = iframe.contentWindow.GetData();
            mini.get("txtMindInfo").setValue(tmpData);
        }
    });
}
//获取选择的信息
var getSelectedInfo = function (currentInfo) {
    var mindInfo = mini.get("txtMindInfo").getValue();
    var selectNode = [];
    var user = null;

    var planEndDate = mini.get("dtPlanEndDate").getValue();
    var len = AllData.NextNodeList.length;
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = AllData.NextNodeList[iTmp];
        var nodeCode = node.NodeCode;
        var chkBox = mini.get("chkNode" + nodeCode);
        var chkCopyBox = mini.get("chkCopyNode" + nodeCode);
        var listBox = mini.get("lstNode" + nodeCode);
        var listCopyBox = mini.get("lstCopyNode" + nodeCode);

        if (chkBox.checked != true) continue;

      

        var selectList = listBox.getSelecteds();
        var selectCopyList = [];
        if (chkCopyBox && chkCopyBox.checked == true && listCopyBox) selectCopyList = listCopyBox.getSelecteds();

        if (selectList.length == 0 && node.IsMustNotUsers == false) {
            Power.ui.alert("对不起，节点" + node.NodeName + "没有选择人");
            return null;
        }

        if (node.InputLimitDaysByRun == true) {
            for (var irow = 0; irow < selectList.length; irow++)
                selectList[irow].PlanEndDate = planEndDate;
        }

        var sendNode = new Object();
        sendNode.SendUserList = selectList;
        sendNode.CopyUserList = selectCopyList;
        sendNode.NodeCode = node.NodeCode;
        selectNode.push(sendNode);
    }
    var voteValue = "";
    var voteText = "";
    //提取投票信息
    if (MyVoteInfo && MyVoteInfo.IsTurnVote == true) {
        var voteSelected = mini.get("lstVote").getSelecteds();
        if (!voteSelected) {
            alert("异常，未捕获到投票信息"); return;
        }
        voteValue = voteSelected[0].VoteCode;
        voteText = voteSelected[0].VoteName;
    }

    return { "Current": currentInfo, "SelectedNode": selectNode, "MindInfo": mindInfo, "VoteValue": voteValue, "VoteText": voteText };
}
