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

    var len = data.NextNodeList.length;

    var sOutput = '<ul class="yiji">';
    var sUserPut = '';
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
        if (node.IsCancel == true) continue;     //自定义事件中，强制指定此节点无视掉
        var selectuser = "";
        if (node.SendUserMode == ESendUserMode.BySendUser) {
            selectuser += '<div style=\"font-size:1.4rem;color:#4b8df8\"><span onclick="javascript:onDesignUserBySend(\'' + node.NodeCode + '\')">选择人员</span>';
            if (node.CanSelectUsers && node.CanSelectUsers.length > 0) {
             //   selectuser += '&nbsp;&nbsp;|&nbsp;&nbsp;<span onclick="javascript:onDesignUserBySendTwo(\'' + node.NodeCode + '\')">二次筛选</span>';
            }
            selectuser += "</div>";
        }
        sOutput += " <li>" +
                "<a href=\"#\" class=\"inactive\" id=\"check" + node.NodeCode + "\" onclick=\"onInActiveClick('check" + node.NodeCode + "')\">" + node.NodeName + "<span class=\"fa fa-toggle-off\"></span></a>" +
                 
                "<div class=\"slidedivs\">" + selectuser +
                   " <ul id=\"lstNode" + node.NodeCode + "\" name=\"" + node.SelectNodeMode + "\">" +
                   "</ul>" +
                "</div>" +
                "</li>";
        //sOutput += '<tr>';
        //sOutput += '<td style="width:120px">';
        //sOutput += '<div id="chkNode' + node.NodeCode + '" data-options="{\'SelectNodeMode\':\'' + node.SelectNodeMode + '\',\'LineType\':\'' + node.LineType + '\'}"  class="mini-checkbox" text="' + node.NodeName + '" onclick="onResetList(\'' + node.NodeCode + '\')"';
        //sOutput += '></div></td>';

        //var sUserBox = 'mini-radiobuttonlist';
        //if (node.AllowMulitUser == true)     //多选切是发送操作，才能checkboxlist 多选节点，（ 退回操作也是多节点，但只能单选) 
        //    sUserBox = 'mini-checkboxlist';

        //sUserPut = '<td>';
        //if (node.MustNotUserMessage) sUserPut += '<span>' + node.MustNotUserMessage + '</span>';
        //如果是发送者定义
        //sUserPut += '<div id="lstNode' + node.NodeCode + '" data-options="{\'SelectUserMode\':\'' + node.SelectUserMode + '\',\'AllowMulitUser\':' + node.AllowMulitUser + '}"  class="' + sUserBox + '"   repeatItems="0" repeatLayout="flow" repeatDirection="horizontal"  textField="UserName" valueField="UserID" enabled="false"  ></div>';
        //sUserPut += '</td>';

        //sOutput += sUserPut;
        //sOutput += '</tr>';

        if (!node.CanSelectCopyUsers || node.CanSelectCopyUsers.length == 0) continue;
        sOutput += " <li>" +
              "<a href=\"#\" class=\"inactive\" id=\"chkCopyNode" + node.NodeCode + "\" onclick=\"onInActiveClick('chkCopyNode" + node.NodeCode + "')\">抄送<span class=\"fa fa-toggle-off\"></span></a>" +
              "<div class=\"slidedivs\">" +
                 " <ul id=\"lstCopyNode" + node.NodeCode + "\">" +
                 "</ul>" +
              "</div>" +
              "</li>";
        ////绘制抄送
        //sOutput += '<tr>';
        //sOutput += '<td   align="right"><div id="chkCopyNode' + node.NodeCode + '" align="right"  class="mini-checkbox" text="(抄送)" checked="true"  onclick="onResetCopyList(this)" ></div>';
        //sOutput += '<div id="btnCopyNode' + node.NodeCode + '" class="mini-button" style="width:20px;height:20px;display:none"  values="+" text=" "  onclick="onSelectedCopyList(this)">';

        //sOutput += '</td>';
        //sOutput += '<td><div id="lstCopyNode' + node.NodeCode + '"  class="mini-checkboxlist"   repeatItems="0" repeatLayout="flow" repeatDirection="horizontal"  textField="UserName" valueField="UserID"  checked="true" ></div>';
        //sOutput += '</td>';
        //sOutput += '</tr>';
    }
    sOutput += '</ul>';
    sOutput += '  <p style="font-size:14px;margin-top:5px;">审批意见</p>';
    sOutput += '<p style="margin:10px;"><textarea id="txtMindInfo" rows="5"  style="width:100%"></textarea></p>';
    var win_column_obj = $(sOutput);
    win_column_obj.appendTo(mnuNodeList);
    mini.parse();
    for (var iTmp = 0; iTmp < node.CanSelectUsers.length; iTmp++) {
        var user = node.CanSelectUsers[iTmp];
        if (!user.SourceUserID) continue;
        if (user.UserID == user.SourceUserID) continue;
        user.UserName += "  " + "代" + "(" + user.SourceUserName + ")";
    }
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
        var h = "";
        var mulit = node.AllowMulitUser;
        for (var i = 0; i < node.CanSelectUsers.length; i++) {
            var user = node.CanSelectUsers[i];
            var candelete = "";
            if (node.SendUserMode == ESendUserMode.BySendUser)
                candelete = "<span  style=\"font-size:1.4rem;color:#4b8df8\" onclick=\"OnDesignDelete('"+node.NodeCode+"','"+user.UserID+"')\">&nbsp;&nbsp;|&nbsp;&nbsp;删除<span>";
            if (mulit)
                h += '<li onclick="SelectChecked(\'chk' + user.UserID + '\')">' + user.UserName + candelete + '<input id="chk' + user.UserID + '" type="checkbox" value="' + user.UserName + '" DeptPositionID="' + user.DeptPositionID + '" DeptPositionName="' + user.DeptPositionName + '" PlanEndDate="' + mini.formatDate(user.PlanEndDate, "yyyy-MM-dd HH:mm:ss") + '" SourceMode="' + user.SourceMode + '" SourceUserID="' + user.SourceUserID + '" SourceUserName="' + user.SourceUserName + '"/></li>';
            else
                h += '<li onclick="SelectChecked(\'chk' + user.UserID + '\')">' + user.UserName + candelete + '<input id="chk' + user.UserID + '" type="radio" name="' + node.NodeCode + '" value=' + user.UserName + '" DeptPositionID="' + user.DeptPositionID + '" DeptPositionName="' + user.DeptPositionName + '" PlanEndDate="' + mini.formatDate(user.PlanEndDate, "yyyy-MM-dd HH:mm:ss") + '" SourceMode="' + user.SourceMode + '" SourceUserID="' + user.SourceUserID + '" SourceUserName="' + user.SourceUserName + '"/></li>';
        }
        $("#lstNode" + node.NodeCode).html(h);
        //mini.get("lstNode" + node.NodeCode).setData(node.CanSelectUsers);
    }
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
        if (!node.CanSelectCopyUsers || node.CanSelectCopyUsers.length == 0) continue;

        var h = "";
        for (var i = 0; i < node.CanSelectCopyUsers.length; i++) {
            var user = node.CanSelectCopyUsers[i];
            h += '<li onclick="SelectChecked(\'chkcopy' + user.UserID + '\')">' + user.UserName + '<input id="chkcopy' + user.UserID + '" type="checkbox" value="' + user.UserName + '" DeptPositionID="' + user.DeptPositionID + '" DeptPositionName="' + user.DeptPositionName + '" PlanEndDate="' + mini.formatDate(user.PlanEndDate, "yyyy-MM-dd HH:mm:ss") + '" SourceMode="' + user.SourceMode + '" SourceUserID="' + user.SourceUserID + '" SourceUserName="' + user.SourceUserName + '"/></li>';
        }
        $("#lstCopyNode" + node.NodeCode).html(h);

        var allrows = $("#lstCopyNode" + node.NodeCode + " input:checkbox");
        for (var i = 0; i < allrows.length; i++) {
            var row = allrows[i];
            row.checked = true;
        }
        // mini.get("lstCopyNode" + node.NodeCode).setData(node.CanSelectCopyUsers);
        // mini.get("lstCopyNode" + node.NodeCode).selectAll();
    }

    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = data.NextNodeList[iTmp];
        //var chkBox = mini.get("chkNode" + node.NodeCode);
        //var listBox = mini.get("lstNode" + node.NodeCode);
        var listMode = $("#lstNode" + node.NodeCode).name;
        switch (listMode) {
            case "SelectedNode":  //默认选中
                var allrows = $("#lstNode" + node.NodeCode + " input:checkbox");
                for (var i = 0; i < allrows.length; i++) {
                    var row = allrows[i];
                    row.checked = true;
                }
                //chkBox.setValue(true);
                //listBox.setEnabled(true);
                break;
            case "SelectedAndDisabled": //默认选中且不可撤销

                var allrows = $("#lstNode" + node.NodeCode + " input:checkbox");
                for (var i = 0; i < allrows.length; i++) {
                    var row = allrows[i];
                    row.checked = true;
                    row.disabled = true;
                }
                //chkBox.setValue(true);
                //chkBox.setEnabled(false);
                //listBox.setEnabled(true);
                break;
            default:
                break;
        }
    }
    for (var index = 0; index < len; index++) {
        var node = data.NextNodeList[index];
        if (node.DefaultUserID) {

            if ($("#" + node.DefaultUserID).length > 0) {
                $("#" + node.DefaultUserID).prop("checked", true);
            }
        }
        // mini.get("lstNode" + node.NodeCode).setValue(node.DefaultUserID);
    }

    if (len == 1) {
        //mini.get("chkNode" + data.NextNodeList[0].NodeCode).setValue(true);
        onResetList(data.NextNodeList[0].NodeCode);
    }
    onInActiveClick("check" + data.NextNodeList[0].NodeCode);
}
var onInActiveClick = function (id) {
    if ($('#'+id).siblings('.slidedivs').css('display') == 'none') {

        $('#' + id).children('span').addClass('fa-toggle-on');
        $('#' + id).siblings('.slidedivs').slideDown(500);
        //$('#' + id).parent().siblings().find(".slidedivs").slideUp(500);
        //$('#' + id).parent().siblings().find("span").removeClass('fa-toggle-on');
    } else {
        $('#' + id).children('span').removeClass('fa-toggle-on');
        $('#' + id).siblings('.slidedivs').slideUp(500);

    }
}
var SelectChecked = function (id) {
    if ($("#" + id)[0].checked) {
        $("#" + id).prop("checked", false);
    }
    else
        $("#" + id).prop("checked", true);
}
var onResetList = function (nodeCode) {

    //var chkBox = mini.get("chkNode" + nodeCode);
    //var chkCopyBox = mini.get("chkCopyNode" + nodeCode);
    //var listBox = mini.get("lstNode" + nodeCode);
    //var listCopyBox = mini.get("lstCopyNode" + nodeCode);
    //var lineType = chkBox.LineType;
    //if (chkBox.checked == true) {
    //    switch (listBox.SelectUserMode) {
    //        case "DeselectAll":   //默认不选中 
    //            listBox.setEnabled(true);
    //            break;
    //        case "SelectAll":  //默认全选中
    //            listBox.selectAll();
    //            listBox.setEnabled(true);
    //            break;
    //        case "SelectAllAndDisabled":  //默认全选中，且不可去掉钩
    //            listBox.selectAll();
    //            listBox.setEnabled(false);
    //            break;
    //        default:
    //            listBox.setEnabled(true);
    //    }
    //    //如果只有一项内容，直接选中
    //    if (listBox.getData().length == 1) listBox.setValue(listBox.getData()[0].UserID);
    //}
    //else {
    //    listBox.deselectAll();
    //    listBox.setEnabled(false);
    //}
    //if (chkCopyBox) {
    //    chkCopyBox.setEnabled(chkBox.checked);
    //    chkCopyBox.setValue(chkBox.checked);
    //    if (listCopyBox) {
    //        listCopyBox.setEnabled(chkBox.checked);
    //        if (chkBox.checked == true)
    //            listCopyBox.selectAll();
    //        else
    //            listCopyBox.deselectAll();
    //    }
    //}


    ////如果当前是排他线，则取消其他节点的勾
    //if (lineType == EFlowLineType.ExcludeLine && chkBox.checked == true) {
    //    var len = AllData.NextNodeList.length;
    //    for (var iTmp = 0; iTmp < len; iTmp++) {
    //        var tmpNodeCode = AllData.NextNodeList[iTmp].NodeCode;
    //        if (tmpNodeCode == nodeCode) continue;
    //        var chkOtherBox = mini.get("chkNode" + tmpNodeCode);
    //        var listOtherBox = mini.get("lstNode" + tmpNodeCode);
    //        chkOtherBox.setValue(false);
    //        listOtherBox.setEnabled(false);
    //    }
    //}

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

    var IsMindMustInput = false;  //意见是否必填
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = AllData.NextNodeList[iTmp];
        if (mini.get("chkNode" + node.NodeCode).checked != true) continue;
        var listBox = mini.get("lstNode" + node.NodeCode);
        var selectList = listBox.getSelecteds();
        if (selectList.length == 0 && node.IsMustNotUsers == false) {
            top.Power.ui.error("对不起，节点[" + node.NodeName + "]没有选择目标人");
            return false;
        }
        if (node.IsMindMustInput == true && IsMindMustInput == false) IsMindMustInput = true; //说明有选择的目标节点，设置了需要填写意见
        iCount++;
    }
    if (iCount == 0) {
        alert("对不起，请至少选择一个目标节点"); return false;//"对不起，退回操作只能选择一个目标节点"
    }
    //如果当前节点意见必填,或者不是发送操作，则意见必填
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
            top.Power.ui.alert("对不起，请先投票选择");//"对不起，请先投票选择"
            return null;
        }
    }
    form.validate();
    if (form.isValid() == false) {
        var sErrInfo = "";
        for (var itmp = 0; itmp < form.getErrorTexts().length; itmp++)
            sErrInfo += form.getErrorTexts()[itmp] + "<br />";
        top.Power.ui.error(sErrInfo);
        return false;
    }
    return true;
}

//提取目标节点可选人员
var GetNodesUser = function (data, flag) {

    //if (flag == true) setSelectUserTab();

    if (data == null || data == "") {
        alert("用户信息提取失败"); return;//"提取失败"
    }
    // mini.get("btnOK").setEnabled(true);

    curFlowOperate = data.FlowOperate;

    bindNode(data);

    //判断是否有期望完成时间要手工定义的，如果有，放开选择日期框
    //var len = data.NextNodeList.length;
    //for (var iTmp = 0; iTmp < len; iTmp++) {
    //    var node = data.NextNodeList[iTmp];
    //    if (node.IsCancel == true) continue;     //自定义事件中，强制指定此节点无视掉
    //    if (node.InputLimitDaysByRun != true) continue;

    //    document.getElementById("spnPlanEndDate").style.display = "";
    //    mini.get("dtPlanEndDate").setVisible(true);
    //    mini.get("dtPlanEndDate").setRequired(true);
    //    mini.get("dtPlanEndDate").setRequiredErrorText("请填写期望完成时间");//"请填写办理意见"
    //    break;
    //}

    //var div = $("#mindList");
    //WorkFlowUtil.DrawMindList(div, data.HistoryMind);
    //mini.get("txtMindInfo").setValue(data.MindInfo);


    //渲染投票
    MyVoteInfo = data.VoteInfo;

    //if (MyVoteInfo && MyVoteInfo.IsTurnVote == true) {
    //    var voteType = MyVoteInfo.VoteType;
    //    var defaultVoteValue = MyVoteInfo.DefaultVoteValue;

    //    var listHTML = '<div id="lstVote"  ';
    //    if (voteType == "RadioBox")
    //        listHTML += 'class="mini-radiobuttonlist" ';
    //    else
    //        listHTML += 'class="mini-checkboxlist" ';

    //    listHTML += '  repeatItems="0" repeatLayout="flow" repeatDirection="horizontal"  textField="VoteName" valueField="VoteCode"  ></div>';

    //    var divVoteInfo = document.getElementById("divVoteInfo");
    //    var win_column_obj = $(listHTML);
    //    win_column_obj.appendTo(divVoteInfo);
    //    mini.parse();
    //    mini.get("lstVote").setData(MyVoteInfo.VoteList);

    //    if (defaultVoteValue) mini.get("lstVote").setValue(defaultVoteValue);
    //}
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
    var mindInfo = $("#txtMindInfo").val();
    var selectNode = [];
    var user = null; 
    var planEndDate = new Date();
    var len = AllData.NextNodeList.length;
    var icount = 0;//标记如果下一步是多个节点，则选中了几个
    for (var iTmp = 0; iTmp < len; iTmp++) {
        var node = AllData.NextNodeList[iTmp];
        var nodeCode = node.NodeCode;
        //var chkBox = mini.get("chkNode" + nodeCode);
        //var chkCopyBox = mini.get("chkCopyNode" + nodeCode);
        //var listBox = mini.get("lstNode" + nodeCode);
        //var listCopyBox = mini.get("lstCopyNode" + nodeCode);

        //循环check或者radio，没有任何一个选中的，就continue
        var check = $("#lstNode" + nodeCode + " input:checkbox");
        var checklist = [];
        for (var i = 0; i < check.length; i++) {
            if (check[i].checked) {
                var a = {};
                var c = $("#" + check[i].id);
                a.UserID = check[i].id.replace("chk","");
                a.UserName = check[i].value;
                a.DeptPositionID = c.attr("deptpositionid");
                a.DeptPositionName = c.attr("deptpositionname");
                a.PlanEndDate = mini.parseDate(c.attr("planenddate"));
                if (a.PlanEndDate == null)
                    a.PlanEndDate = new Date();
                a.SourceMode = c.attr("sourcemode");
                a.SourceUserID = c.attr("sourceuserid");
                a.SourceUserName = c.attr("sourceusername");
                checklist.push(a);
            }
        }
        var radio = $("#lstNode" + nodeCode + " input:radio");
        var radiolist = [];
        for (var i = 0; i < radio.length; i++) {
            if (radio[i].checked) {
                var a = {};
                var c = $("#" + radio[i].id);
                a.UserID = radio[i].id.replace("chk", "");;
                a.UserName = radio[i].value;
                a.DeptPositionID = c.attr("deptpositionid");
                a.DeptPositionName = c.attr("deptpositionname");
                a.PlanEndDate = mini.parseDate(c.attr("planenddate"));
                if (a.PlanEndDate == null)
                    a.PlanEndDate = new Date();
                a.SourceMode = c.attr("sourcemode");
                a.SourceUserID = c.attr("sourceuserid");
                a.SourceUserName = c.attr("sourceusername");
                radiolist.push(a);
            }
        } 
        if (checklist.length == 0 && radiolist.length == 0 && len > 1) continue;



        var selectList = checklist.length == 0 ? radiolist : checklist;
        var selectCopyList = [];
        var checkCopy = $("#lstCopyNode" + nodeCode + " input:checkbox");
        for (var i = 0; i < checkCopy.length; i++) {
            if (checkCopy[i].checked) {
                var c = $("#" + checkCopy[i].id);
                var a = {};
                a.UserID = checkCopy[i].id.replace("chkcopy", "");;
                a.UserName = checkCopy[i].value;
                a.DeptPositionID = c.attr("deptpositionid");
                a.DeptPositionName = c.attr("deptpositionname");
                a.PlanEndDate = mini.parseDate(c.attr("planenddate"));
                if (a.PlanEndDate == null)
                    a.PlanEndDate = new Date();
                a.SourceMode = c.attr("sourcemode");
                a.SourceUserID = c.attr("sourceuserid");
                a.SourceUserName = c.attr("sourceusername");
                selectCopyList.push(a);
            }
        }
        // if (chkCopyBox && chkCopyBox.checked == true && listCopyBox) selectCopyList = listCopyBox.getSelecteds();

        if (selectList.length == 0 && node.IsMustNotUsers == false) {
            top.Power.ui.alert("对不起，节点" + node.NodeName + "没有选择人");
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
        icount++;
    }
    if (icount == 0) {
        top.Power.ui.alert("请至少选中一个下一步流程节点");
        return null;
    }
    var voteValue = "";
    var voteText = "";
    //提取投票信息
    if (MyVoteInfo && MyVoteInfo.IsTurnVote == true) {
        //var voteSelected = mini.get("lstVote").getSelecteds();
        //if (!voteSelected) {
        //    alert("异常，未捕获到投票信息"); return;
        //}
        //voteValue = voteSelected[0].VoteCode;
        //voteText = voteSelected[0].VoteName;
    }

    return { "Current": currentInfo, "SelectedNode": selectNode, "MindInfo": mindInfo, "VoteValue": voteValue, "VoteText": voteText };
}
