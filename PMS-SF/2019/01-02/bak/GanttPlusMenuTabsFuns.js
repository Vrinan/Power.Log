//code by yc.tao
//默认的操作菜单方法
var ganttPlusMenuFuns = function () {
    //新增菜单
    var addMenuHtml = '';
    return {
        "GetAddMenuHtml": function () {
            return addMenuHtml;
        },
        "SetAddMenuHtml": function (html) {
            addMenuHtml += html;
        },
        "beforeInit": function () { },
        //初始化菜单(新增的菜单默认加到最后)
        "Init": function () {
            ganttPlusMenuFuns.beforeInit();
            $("#mainmenu").append(ganttPlusMenuFuns.GetAddMenuHtml());
        },
        //把菜单放到指定位置
        "InsertAfterToMenu": function (appendToObj, html) {
            appendToObj.after(html);
        },
        //隐藏菜单  默认hide，flag为true时则remove
        "HideMenu": function (obj, flag) {
            if (flag) {
                $(obj).remove();
            } else {
                $(obj).hide();
            }
        },
        //显示菜单
        "ShowMenu": function (obj) {
            $(obj).show();
        },
        //初始化默认菜单事件
        "InitEvent": function (_gantt) {

            //打开计划
            $("#menu").on("click", "#btnOpenPlan", function () {
                OpenPlan(function (planInfo) {
                    if (planInfo != null)
                        LoadPlan(gantt, planInfo.proj_plan_guid);
                    else {
                        Power.ui.alert("请选择打开的计划", "提示");
                    }
                });
            });
            //WBS维护
            $("#menu").on("click", "#btnWbsMaintain", function () {
                if (!current_plan_guid || current_plan_guid.length == 0) {
                    Power.ui.alert("请先选择计划");
                    return;
                }
                var url = "/Form/EditForm/0a8b8c1b-f9e3-4460-9a49-9c2e5788cd48/?plan_guid=" + current_plan_guid;
                mini.open({
                    url: url, title: "WBS编制",
                    width: "80%",
                    height: "80%",
                    showMaxButton: true,
                    ondestroy: function (action) {
                        $("#btnRefresh").trigger("click");
                    }
                });
                return false;
            });
            //编辑(客户端插件)
            $("#menu").on("click", "#btnEditWithClient", function () {
                var planinfo = gantt.planinfo;
                if (planinfo) {
                    var readonly = 0;
                    var gm = 1;
                    if ($.trim($(this).text()) == "查看") {
                        readonly = 1;
                        gm = 0;
                    }
                    var url = ganttHelper.getPowerPlanUrl(planinfo.proj_id, planinfo.proj_plan_id, 1, readonly, gm, 2);
                    console.log("clientUrl", url);
                    $("body").append("<iframe style='display:none;' src=" + url + "></iframe>");
                }
            });
            //增加作业
            var addTask = function (taskTemplate) {
                var record = gantt.getSelected();
                if (!record) {
                    return false;
                }

                //if (record.TaskInfo && record.TaskInfo.rsrc_guid == "00000000-0000-0000-0000-000000000000") {
                //    //Power.ui.error("当前wbs没有分配责任人，不允许新增");
                //    //e.cancel = true;
                //}
                //if (currentSession.IsAdmin || currentSession.IsITAdmin || (gantt.planinfo && currentSession.HumanId == gantt.planinfo.receive_user_guid)) {
                //}
                //else {
                //    var _parentTask = record.IsWBSTask ? record : gantt.getParentTask(record);
                //    while (_parentTask && (!_parentTask.TaskInfo.rsrc_guid || _parentTask.TaskInfo.rsrc_guid == "00000000-0000-0000-0000-000000000000")) {
                //        _parentTask = gantt.getParentTask(_parentTask);
                //    }
                //    if (_parentTask != null) {
                //        if (!(_parentTask.TaskInfo && ((_parentTask.TaskInfo.rsrc_guid || "").toLowerCase() == loginHumanId.toLowerCase() || currentSession.IsAdmin || currentSession.IsITAdmin))) {

                //            //Power.ui.error("当前节点您没权限新增,当前节点的责任人是:" + _parentTask.TaskInfo.rsrc_name);
                //            return false;
                //        }
                //    }
                //}

                //处理权限
                if (!TaskLimitFuns.GetTaskLimit(record)) {
                    Power.ui.error("抱歉，您没有新增权限");
                    return false;
                }
                var newTask = gantt.newTask();
                newTask.UID = newTask.UID.toLowerCase();
                if (taskTemplate) {
                    newTask = $.extend(true, {}, taskTemplate, newTask);
                    if (taskTemplate.task_name != "")
                        newTask.Name = taskTemplate.task_name;    //初始化任务属性
                    //工期属性
                    if (parseFloat(taskTemplate.target_drtn_hr_cnt || 0) > 0) {
                        newTask.Duration = parseFloat(taskTemplate.target_drtn_hr_cnt || 0) / 8;
                    }
                }
                else
                    newTask.Name = '<新增任务>';    //初始化任务属性
                var _taskcode = "";
                var _iswbscode = false;
                var parentRecord = record;
                if (!record.IsWBSTask) {
                    _taskcode = record.task_code || "";
                    parentRecord = gantt.getParentTask(record);
                }
                if (_taskcode == "") {
                    //获取WBS的最大编号
                    var _child = gantt.getChildTasks(parentRecord);
                    if (_child.length > 0)
                        _taskcode = _child[_child.length - 1]["task_code"] || "";
                }
                if (_taskcode == "") {
                    _iswbscode = true;
                    _taskcode = parentRecord.task_code;
                }
                var _taskList = gantt.getTaskList();
                var reg = /^[\D|\0]?/gi;

                var _tmpflag = false;
                while (!_tmpflag) {
                    var _number = 10, _text = _taskcode;
                    if (reg.test(_text)) {
                        _number = _text.split(reg);
                        _number = _number && _number.length > 0 ? _number[_number.length - 1] : 0;
                        var _numlen = _number.length;
                        _number = parseInt(_number) || 0;
                        _number += 10;
                        _numlen = (_number + "").length > _numlen ? (_number + "").length : _numlen;
                        _number = ganttHelper.PrefixInteger(_number, _numlen)
                        _text = _text.match(reg);
                        _text = _text && _text.length > 0 ? _text[0] : "";
                    }
                    else if (!isNaN(_text)) {
                        if (!_iswbscode) {
                            _number = parseInt(_text) + _number;
                            _text = "";
                        }
                    }
                    _taskcode = _text + _number;
                    if (_taskcode && _taskcode != "") {
                        if ($.grep(_taskList, function (item) { return item.task_code == _taskcode }).length == 0) {
                            _tmpflag = true;
                            break;
                        }
                    }
                }
                newTask.task_code = _taskcode;
                newTask.TaskInfo = {
                    task_code: _taskcode,
                    plan_guid: gantt.planinfo.proj_plan_guid,
                    plan_id: gantt.planinfo.proj_plan_id,
                    wbs_id: parentRecord.TaskInfo.wbs_id,
                    wbs_guid: parentRecord.TaskInfo.wbs_guid,
                    proj_guid: gantt.planinfo.proj_guid,
                    proj_id: gantt.planinfo.proj_id,
                    task_type: "TT_Task"
                };
                //Ronnie新增
                newTask.TargetStartDate = checkDateIsNull(getNowFormatDate());
                newTask.TargetEndDate = checkDateIsNull(getNowFormatDate());
                newTask.Finish = checkDateIsNull(getNowFormatDate());
                newTask.Start = checkDateIsNull(getNowFormatDate());
                //if (record.IsWBSTask)
                gantt.addTask(newTask, "add", parentRecord.UID);
                //else
                //    gantt.addTask(newTask, "add", record.UID);
                return newTask;
            }
            $("#btnEditAddTask").unbind("click").click(function () {
                addTask();
                return false;
            });
            //按计划/作业模板增加作业
            //根据计划模板创建计划
            $("#btn_li_addtaskwithplantemplate").unbind("click").click(function () {
                if (current_plan_guid != "") {
                    var taskData = gantt.getTaskList();
                    if (taskData.length <= 1) {
                        var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdPlan/Wizard_pln_projectList.htm";
                        var callback = function (data) {
                            var template_plan_guid = data.length > 0 ? data[0]["proj_plan_guid"] : "";//"08805ffa-e868-4b4e-8da4-29328115dbb6";
                            if (template_plan_guid && template_plan_guid != "") {
                                $.getJSON("/Plan/PlanCopyWithTemplate", {
                                    template_plan_guid: template_plan_guid,
                                    plan_guid: current_plan_guid
                                }, function (result) {
                                    if (result.success) {
                                        Power.ui.success("导入计划模板成功");
                                        $("#btnRefresh").trigger("click");
                                    }
                                    else {
                                        Power.ui.alert("导入计划模板失败(" + result.message + ")");
                                    }
                                });
                            }
                            else {
                                Power.ui.alert("请选择要导入的模板");
                            }
                        }
                        //callback();
                        //return false;
                        mini.open({
                            url: url,
                            title: "选择计划",
                            width: "80%",
                            height: "80%",
                            showMaxButton: true,
                            onload: function () {
                                var iframe = this.getIFrameEl();
                                var selobj = iframe.contentWindow.Select;
                                if (selobj) {
                                    if (selobj.LoadStepFirst) selobj.LoadStepFirst();
                                }
                            },
                            ondestroy: function (action) {
                                if (action != "ok")
                                    return;
                                var iframe = this.getIFrameEl();
                                var data = null;
                                if (iframe.contentWindow.Select)
                                    data = iframe.contentWindow.Select.GetData();
                                else {
                                    if (iframe.contentWindow.GetData)
                                        data = iframe.contentWindow.GetData();
                                }
                                if (!data || data.length == 0) {
                                    Power.ui.alert("未选择数据");
                                    return;
                                }
                                data = mini.clone(data);
                                if (callback) {
                                    callback(data);
                                }
                            }
                        });
                    }
                    else {
                        Power.ui.alert("导入失败<br/>当前计划不允许导入计划模板,请先删除计划的所有作业再导入");
                    }
                }
                else {
                    Power.ui.alert("导入失败<br/>请先打开要打入的计划再导入");
                }
            });
            //根据作业模板创建计划
            $("#btn_li_addtaskwithtasktemplate").unbind("click").click(function () {
                if (current_plan_guid != "") {
                    var taskData = gantt.getTaskList();
                    if (true) {
                        var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdPlan/Wizard_PLN_PLAN_TOTAL_CATELOG.htm";
                        var callback = function (data) {
                            $.each(data, function () {
                                var task = addTask(this);
                                gantt.select(gantt.getTask(task.UID));
                            });
                        }
                        mini.open({
                            url: url, title: "选择计划",
                            width: "80%",
                            height: "80%",
                            showMaxButton: true,
                            onload: function () {
                                var iframe = this.getIFrameEl();
                                var selobj = iframe.contentWindow.Select;
                                if (selobj) {
                                    if (selobj.LoadStepFirst) selobj.LoadStepFirst();
                                }
                            },
                            ondestroy: function (action) {
                                if (action != "ok")
                                    return;
                                var iframe = this.getIFrameEl();
                                var data = null;
                                if (iframe.contentWindow.Select)
                                    data = iframe.contentWindow.Select.GetData();
                                else {
                                    if (iframe.contentWindow.GetData)
                                        data = iframe.contentWindow.GetData();
                                }
                                if (!data || data.length == 0) {
                                    Power.ui.alert("未选择数据");
                                    return;
                                }
                                data = mini.clone(data);
                                if (callback) {
                                    callback(data);
                                }
                            }
                        });
                    }
                    else {
                        Power.ui.alert("导入失败,当前计划不允许导入计划模板,请先删除计划的所有作业再导入");
                    }
                }
                else {
                    Power.ui.alert("导入失败,请先打开要打入的计划再导入");
                }
            });
            //上移
            //下移
            //删除
            $("#btnEditRemoveTask").unbind("click").click(function () {
                var tasks = gantt.getSelecteds();
                var scrollTop = gantt.ganttView.scrollTop;
                if (tasks && tasks.length > 0) {
                    var willDeletes = [];
                    var nolimitTasks = [];//没有删除权限的作业
                    $.each(tasks, function () {
                        if (TaskLimitFuns.GetTaskLimit(this, "delete")) {
                            willDeletes.push(this);
                        } else {
                            nolimitTasks.push(this);
                        }
                    });
                    if (nolimitTasks.length > 0) {
                        Power.ui.error("抱歉，存在没有删除权限的作业，请重新选择");
                        return false;
                    }
                    if (willDeletes.length > 0) {
                        Power.ui.confirm("将删除作业及其关联的页签数据，确定是否需要删除?", function (action) {
                            if (!action) return false;
                            gantt.removeTasks(willDeletes);

                            var deleteTaskDetails = function (task) {
                                var tabs = mini.get("taskDetailTab");
                                var allTabs = tabs.getTabs();
                                $.each(allTabs, function () {
                                    var item = this;
                                    if (item.name == "" || item.name == "subplan" || item.name == "PredOrNextTask") return;
                                    var datagrid = mini.get("datagrid_" + item.name);
                                    if (typeof (datagrid) == "undefined") return;
                                    var detailKeyword = datagrid.name || item.name;
                                    var taskfield = datagrid.taskfield || item.taskfield || "task_guid";
                                    if (detailKeyword == "Comment") {
                                        taskfield = "BOKeyWord='TASK' and FolderId";
                                    }
                                    if (detailKeyword == "DocFile") {
                                        taskfield = "KeyWord='TASK' and KeyValue";
                                    }
                                    $.ajaxSettings.async = false;
                                    $.getJSON("/Plan/DeleteTaskDetails", {
                                        task_guid: task.UID,
                                        detailKeyword: detailKeyword,
                                        taskGuidField: taskfield
                                    }, function (data) {
                                    });
                                });
                            }
                            //批量删除作业及其关联的页签数据
                            $.each(willDeletes, function () {
                                deleteTaskDetails(this);
                            });
                            $.ajaxSettings.async = true;
                            $("#btnEditSave").trigger("click");
                            Power.ui.success("删除成功");
                        });
                    }
                }
                gantt.setScrollTop(scrollTop);
                return false;
            });
            //保存计划
            $("#btnEditSave").unbind("click").click(function (e) {
                saveCurrentTaskWithEditFrom();
                var postData = {};
                var _taskData = getModifyTasks();

                var changeWBSData = getModifyWbsTasks();
                //处理一下wbs  因为此处获取到的wbs有children 防止将未改变的数据 剔除
                //只提交当前wbs 而不提交期子节点
                $.each(changeWBSData, function () {
                    var item = this;
                    item.children = null;
                });

                postData["TASK"] = { KeyWordType: "BO", data: _taskData };
                postData["WBS"] = { KeyWordType: "BO", data: changeWBSData }
                if (_taskData.length > 0) {
                    Power.ui.loading("正在保存...");
                    SaveServer(postData, function (o) {
                        gantt.acceptChanges();
                        Power.ui.loading.close();
                        $.each(_taskData, function () {
                            gantt.updateTask(this, { RemovedPredecessorLink: [] });
                        });
                        Power.ui.success("保存成功!");
                        $("#btnRefresh").trigger("click");//保存完自动刷新
                    }, function (errorMsg) {
                        Power.ui.error("保存失败!" + errorMsg);
                    });
                }
                return false;
            });
            //送审(发起审批)
            $("#menu").on("click", "#btnStartApproval", function () {
                $.ajax({
                    url: "/Plan/StartApprovPlan/" + current_plan_guid,
                    dataType: "JSON",
                    data: {},
                    success: function (data) {
                        gantt.plan_approve_id = data.data.PlanApprove.Id;
                        gantt.clicktype = "btnStartApproval";
                        $("#btnApprovalInfo").trigger("click");
                    }
                });
            });
            //任务下达
            $("#menu").on("click", "#btnCreateTaskAssign", function () {
                var tasks = gantt.getSelecteds();
                var taskIds = [];
                $.each(tasks, function () {
                    taskIds.push(this.UID);
                });
                OpenPlan(function (planInfo) {
                    if (planInfo != null) {
                        $.ajax({
                            url: "/Plan/CreateSubPlan",
                            type: "POST",
                            dataType: "JSON",
                            data: {
                                main_plan_guid: current_plan_guid,
                                subplan_guid: planInfo.proj_plan_guid,
                                task_guids: taskIds.join(",")
                            },
                            success: function (data) {
                                if (data.success) {
                                    var subplaninfo = data.data.subplaninfo;
                                    var url = "/Form/ValidForm/1eef901b-c797-4a3f-96d7-50572e7eed99/edit/" + subplaninfo.Id;
                                    mini.open({
                                        url: url, title: "",
                                        width: "80%",
                                        height: "80%",
                                        showMaxButton: true
                                    });
                                    LoadPlan(gantt, current_plan_guid);
                                }
                                else {
                                    Power.ui.alert(data.message);
                                }
                            }
                        });
                    }
                    else {
                        Power.ui.alert("请选择一个发包后的子计划");
                    }
                }, current_plan_guid);
                return false;
            });
            //计划分摊
            $("#menu").on("click", "#btnCalcTaskPeriod", function () {
                var gantttree = gantt.getTaskTree();
                if (gantttree[0].TaskInfo.est_wt_pct == 0 || gantttree[0].TaskInfo.est_wt_pct == "0") {
                    Power.ui.warning("分摊失败，根节点权重为空");
                    return;
                }

                Power.ui.loading("初始化统计周期中...");
                $.getJSON("/Plan/CalcPlanPeriod/" + current_plan_guid, function (data) {
                    Power.ui.loading.close();
                    if (data.success) {
                        Power.ui.success("初始化完毕" + data.data["timespan"]);
                    }
                    else {
                        Power.ui.alert("初始化失败(" + data.message + ")");
                    }
                });
                return false;
            });
            //审批信息
            $("#menu").on("click", "#btnApprovalInfo", function () {
                if (gantt.plan_approve_id) {
                    var url = "/Form/ValidForm/6a2b7ce7-8706-4ef3-a0aa-2f8b0f5838ff/edit/" + gantt.plan_approve_id + "/";
                    mini.open({
                        url: url,
                        title: "审批信息",
                        width: "80%",
                        height: "80%",
                        showMaxButton: true,
                        ondestroy: function () {

                            if (current_plan_guid && current_plan_guid != "") {
                                LoadPlan(gantt, current_plan_guid);
                            }
                        }
                    });
                }
                else {
                    Power.ui.alert("该计划还没发起审批，请先将计划发起审批");
                }
            });
            //初始化设置
            $("#menu").on("click", "#btnEvmInitSet", function () {
                if (!current_plan_guid || current_plan_guid.length == 0) {
                    Power.ui.alert("请先打开计划.");
                    return;
                }
                var win = mini.get("winEvmInitSet");
                win.showAtPos("center", "middle");
                var ctrls = "cmbwinEvmInitSetEstwt,cmbwinEvmInitSetFeedtype,btnwinEvmInitSetCurve,btnwinEvmInitSetRectype,btnwinEvmInitSetRsrc".split(",");//,chkEvmInitSet
                $.each(ctrls, function (index, ctrlId) {
                    var ctrl = mini.get(ctrlId);
                    ctrl.setValue("");
                    if (ctrl.setText)
                        ctrl.setText("");
                });
            });
            //费用分摊
            $("#menu").on("click", "#btnApportion", function () {
                if (!current_plan_guid || current_plan_guid.length == 0) {
                    Power.ui.alert("请先打开计划.");
                    return;
                }
                var win = mini.get("win_apportion");
                win.showAtPos("center", "middle");
            });
            //汇总(自下而上汇总预算费用)btnSumBcwscost
            $("#menu").on("click", "#btn_li_costbyrsrc", function () {
                if (!current_plan_guid || current_plan_guid.length == 0) {
                    Power.ui.alert("请先打开计划.");
                    return;
                }
                mini.confirm("确定执行费用从资源汇总操作?", "确定?", function (action) {
                    if (action != "ok") return;
                    $.ajax({
                        url: "/Plan/SumExpenses",
                        type: "POST",
                        data: { plan_guid: current_plan_guid },
                        success: function (text) {
                            var o = $.parseJSON(text);
                            if (o.success) {
                                LoadPlan(gantt, current_plan_guid);
                            }
                            else {
                                Power.ui.alert(o.message);
                            }
                        }
                    });
                });
            });
            //费用从作业汇总
            $("#menu").on("click", "#btn_li_costbytask", function () {
                if (!current_plan_guid || current_plan_guid.length == 0) {
                    Power.ui.alert("请先打开计划.");
                    return;
                }
                mini.confirm("确定执行费用从作业汇总操作?", "确定?", function (action) {
                    if (action != "ok") return;

                    var tasktreelist = gantt.getTaskTree();
                    var setFlagFuns = function (d) {
                        d.flag = false;
                        if (!d.IsWBSTask) {
                            d.flag = true;
                        }
                        if (d.children && d.children.length > 0) {
                            $.each(d.children, function () {
                                setFlagFuns(this);
                            });
                        } else {
                            d.flag = true;
                        }
                    }
                    $.each(tasktreelist, function () {
                        setFlagFuns(this);
                    });

                    var GetWbsDataFuns = function (d) {
                        if (d.children && d.children.length > 0) {
                            var getChildren = function (q) {
                                var flag = true;
                                if (q.children && q.children.length > 0) {
                                    $.each(q.children, function () {
                                        if (!this.flag) {
                                            flag = false;
                                        }
                                    });
                                }
                                return flag;
                            }
                            if (getChildren(d) && !d.flag) {
                                var bcws_cost = 0;
                                $.each(d.children, function () {
                                    var curbcws_cost = this.bcws_cost ? this.bcws_cost : this.TaskInfo.bcws_cost;
                                    bcws_cost += curbcws_cost;
                                    if (!d.IsWBSTask) {
                                        delete this;
                                    }
                                });
                                d.bcws_cost = bcws_cost;
                                
                                var record = gantt.getTask(d.UID);
                                //更新权重
                                gantt.updateTask(record, "bcws_cost", parseFloat(d.bcws_cost));
                                if (record.TaskInfo.bcws_cost) {
                                    record.TaskInfo.bcws_cost = parseFloat(d.bcws_cost);
                                }
                                gantt.setTaskModified(record, "bcws_cost");
                                d.flag = true;
                                if (d.ParentTaskUID != -1) {
                                    $.each(tasktreelist, function () {
                                        GetWbsDataFuns(this);
                                    });
                                }
                            } else {
                                $.each(d.children, function () {
                                    GetWbsDataFuns(this);
                                });
                            }
                        }
                    }
                    $.each(tasktreelist, function () {
                        GetWbsDataFuns(this);
                    });

                    //自动保存
                    SaveGantt(gantt, function () {
                        $("#btnRefresh").trigger("click");
                    });
                });
            });
            //权重从作业汇总
            $("#menu").on("click", "#btn_li_wtbytask", function () {
                if (!current_plan_guid || current_plan_guid.length == 0) {
                    Power.ui.alert("请先打开计划.");
                    return;
                }
                mini.confirm("确定执行权重从作业汇总操作?", "确定?", function (action) {
                    if (action != "ok") return;
                    var tasktreelist = gantt.getTaskTree();
                    var setFlagFuns = function (d) {
                        d.flag = false;
                        if (!d.IsWBSTask) {
                            d.flag = true;
                        }
                        if (d.children && d.children.length > 0) {
                            $.each(d.children, function () {
                                setFlagFuns(this);
                            });
                        } else {
                            d.flag = true;
                        }
                    }
                    $.each(tasktreelist, function () {
                        setFlagFuns(this);
                    });

                    var GetWbsDataFuns = function (d) {
                        if (d.children && d.children.length > 0) {
                            var getChildren = function (q) {
                                var flag = true;
                                if (q.children && q.children.length > 0) {
                                    $.each(q.children, function () {
                                        if (!this.flag) {
                                            flag = false;
                                        }
                                    });
                                }
                                return flag;
                            }
                            if (getChildren(d) && !d.flag) {
                                var est_wt = 0;
                                $.each(d.children, function () {
                                    var curest_wt = this.est_wt ? this.est_wt : this.TaskInfo.est_wt || 0;
                                    est_wt += parseFloat(curest_wt);
                                    if (!d.IsWBSTask) {
                                        delete this;
                                    }
                                });
                                d.est_wt = isNaN(est_wt) ? 0 : est_wt;
                                var record = gantt.getTask(d.UID);
                                //更新权重
                                gantt.updateTask(record, "est_wt", parseFloat(d.est_wt));
                                gantt.setTaskModified(record, "est_wt");
                                d.flag = true;
                                if (d.ParentTaskUID != -1) {
                                    $.each(tasktreelist, function () {
                                        GetWbsDataFuns(this);
                                    });
                                }
                            } else {
                                $.each(d.children, function () {
                                    GetWbsDataFuns(this);
                                });
                            }
                        }
                    }
                    $.each(tasktreelist, function () {
                        GetWbsDataFuns(this);
                    });
                    //递归，由下往上计算权重%
                    var gantttasktree = gantt.getTaskTree();
                    var GetEst_WtPctFuns = function (d) {
                        var currest_wt = d.est_wt;
                        if (d.ParentTaskUID == -1) {
                            var value = 100;
                            if (d.est_wt == 0 || isNaN(d.est_wt)) {
                                value = 0;
                            }
                            gantt.updateTask(d, "est_wt_pct", value);
                            gantt.setTaskModified(d, "est_wt_pct");
                        }
                        if (d.children && d.children.length > 0) {
                            var l = d.children.length - 1;
                            var totalpct = 0;
                            $.each(d.children, function (i) {
                                var item = this;
                                if (i != l) {
                                    var value = parseFloat((parseFloat(item.est_wt / currest_wt) * 100).toFixed(2));
                                    if (currest_wt == 0 || isNaN(currest_wt)) {
                                        value = 0;
                                    }
                                    value = isNaN(value) ? 0 : value;
                                    totalpct += value;
                                    gantt.updateTask(item, "est_wt_pct", value);
                                    gantt.setTaskModified(item, "est_wt_pct");
                                } else {
                                    var values = 100 - totalpct;
                                    if (d.est_wt == 0 || isNaN(d.est_wt)) {
                                        values = 0;
                                    }
                                    gantt.updateTask(item, "est_wt_pct", values);
                                    gantt.setTaskModified(item, "est_wt_pct");
                                }
                            });
                            $.each(d.children, function () {
                                GetEst_WtPctFuns(this);
                            })
                        }
                    }
                    $.each(gantttasktree, function () {
                        GetEst_WtPctFuns(this);
                    });
                    //自动保存
                    $("#btnEditSave").trigger("click");
                });
            });
            //目标对比
            $("#menu").on("click", "#btnVersionCompare", function () {
                var win_planversion_list = mini.get("win_planversion_list");
                $.getJSON("/Plan/GetPlanVersionInfo/" + current_plan_guid, function (data) {
                    if (data.success) {
                        var datagrid_planversion = mini.get("datagrid_planversion");
                        var datalist = $.grep(data.list, function (Item) {
                            return Item.planfilter == 'target';
                        })

                        datagrid_planversion.setData(datalist);
                        win_planversion_list.show();
                        $("#btn_planversion_list_ok").unbind("click").click(function () {
                            var row = datagrid_planversion.getSelected();
                            if (row && row.proj_plan_guid != "") {
                                //开始设置横道 
                                LoadTargetComparePlanData(row.proj_plan_guid);
                                //$.getJSON("/Plan/GetTasksPlanDate/" + row.proj_plan_guid, function (data) {
                                //    if (data.success) {
                                //        gantt.setViewModel("track");
                                //        var dict = {};
                                //        $.each(data.list, function (index, item) {
                                //            if (!dict[item.parent_guid])
                                //                dict[item.parent_guid] = item;
                                //        });
                                //        var tasklist = gantt.getTaskList();
                                //        for (var i = 0, l = tasklist.length; i < l; i++) {
                                //            var task = tasklist[i];
                                //            if (!task.Start || !task.Finish) continue;
                                //            var baselineDateObject = dict[task.UID];
                                //            if (baselineDateObject) {
                                //                var baseline0 = {
                                //                    Start: new Date(baselineDateObject.target_start_date),
                                //                    Finish: new Date(baselineDateObject.target_end_date)
                                //                };
                                //                task.Baseline = [];
                                //                task.Baseline.push(baseline0);
                                //                //
                                //                //task.offsetstart = new Date(task.Start).DateDiff("y", new Date(baselineDateObject.target_start_date));
                                //                //task.offsetfinish = new Date(task.Finish).DateDiff("y", new Date(baselineDateObject.target_end_date));
                                //                //目标计划开始
                                //                task.target_plan_start_date = baselineDateObject.target_start_date;
                                //                //
                                //                //var act_start_date = checkDateIsNull(e.record.TaskInfo.act_start_date);
                                //                //var start = checkDateIsNull(task.target_plan_start_date);
                                //                //if (act_start_date && start) {
                                //                //    task.target_offsetstart = start.DateDiff("d", act_start_date);
                                //                //}
                                //                if (checkDateIsNull(task.TaskInfo.act_start_date) && checkDateIsNull(baselineDateObject.target_start_date))
                                //                    //目标偏差(开始)-实际开始时间和期望开始时间差
                                //                    //task.target_offsetstart = StringToDate(task.TaskInfo.act_start_date).DateDiff("d", new Date(baselineDateObject.target_start_date));
                                //                    task.target_offsetstart = StringToDate(task.TaskInfo.act_start_date).DateDiff("d", checkDateIsNull(baselineDateObject.target_start_date));
                                //                //task.target_plan_end_date = baselineDateObject.target_start_date;
                                //                //Ronnie修改后
                                //                //目标计划结束
                                //                task.target_plan_end_date = baselineDateObject.target_end_date;
                                //                if (checkDateIsNull(task.TaskInfo.act_end_date) && checkDateIsNull(baselineDateObject.target_end_date))
                                //                    //目标偏差(结束)-实际完成时间和期望完成时间
                                //                    //task.target_offsetfinish = StringToDate(task.TaskInfo.act_end_date).DateDiff("d", new Date(task.target_plan_end_date));
                                //                    task.target_offsetfinish = StringToDate(task.TaskInfo.act_end_date).DateDiff("d", checkDateIsNull(task.target_plan_end_date));
                                //            }
                                //        }
                                //        gantt.refresh();
                                //        win_planversion_list.hide();

                                //    } else {
                                //        console.log("设置目标横道失败！", data);
                                //    }
                                //});
                                win_planversion_list.hide();
                            }
                            return false;
                        });
                    }
                });

            });

            //版本对比
            $("#menu").on("click", "#btnHistoryVersionCompare", function () {
                var win_planversion_list = mini.get("win_planversion_list");
                $.getJSON("/Plan/GetPlanVersionInfo/" + current_plan_guid, function (data) {
                    if (data.success) {
                        var datagrid_planversion = mini.get("datagrid_planversion");
                        var datalist = $.grep(data.list, function (Item) {
                            return Item.planfilter != 'target';
                        })
                        var j = 0;
                        $.each(datalist, function (i) {
                            var item = this;
                            if (item.versionCode == null || item.versionCode == "") {
                                j++;
                                item.versionCode = "v-初始版";
                                if (j != 1) {
                                    item.versionCode = "v-初始版" + j;
                                }
                            }
                            else {
                                item.versionCode = "v-" + item.versionCode;
                            }
                        });
                        datagrid_planversion.setData(datalist);
                        win_planversion_list.show();
                        $("#btn_planversion_list_ok").unbind("click").click(function () {
                            var row = datagrid_planversion.getSelected();
                            if (row && row.proj_plan_guid != "") {
                                //开始设置横道
                                LoadTargetComparePlanData(row.proj_plan_guid);
                                win_planversion_list.hide();
                            }
                            return false;
                        });
                    }
                });

            });


            //刷新
            $("#menu").on("click", "#btnRefresh", function () {
                if (current_plan_guid && current_plan_guid != "")
                    LoadPlan(gantt, current_plan_guid);
                return false;
            });
            //进度计算
            $("#btnCalcCritical").unbind("click").click(function () {
                debugger;
                var dateId = "txt_data_date";
                var _taskData = getModifyTasks();
                if (_taskData && _taskData.length > 0) {
                    Power.ui.alert("请先保存计划后再计算");
                    return false;
                }
                var miniPrompt = function (successcallback) {
                    var nowdate = (new Date()).Format("yyyy-MM-dd");
                    if (gantt.planinfo.data_date && gantt.planinfo.data_date != "") {
                        nowdate = StringToDate(gantt.planinfo.data_date).Format("yyyy-MM-dd");
                    }
                    mini.MessageBox.show({
                        title: "进度计算",
                        buttons: ["ok", "cancel"],
                        width: 250,
                        html: '<div style="padding:5px;padding-left:10px;">数据日期:<input type="text"  id="' + dateId + '" value="' + nowdate + '"/></div>',
                        callback: function (action) {
                            var input = document.getElementById(dateId);
                            if (action == "ok")
                                successcallback(input.value);
                        }
                    });
                }
                miniPrompt(function (datadate) {
                    var saveToDb = (urlParams.uiview == "EditPlanWithInline" ? 1 : 1);
                    Power.ui.loading("计划数据进度计算中，请稍候...");
                    $.ajax({
                        url: "/Plan/CalcCriticalInterface",
                        dataType: "JSON",
                        data: {
                            plan_guid: current_plan_guid,
                            datadate: datadate,
                            saveToDb: saveToDb
                        },
                        success: function (data) {
                            Power.ui.loading.close();
                            if (!data.success) {
                                Power.ui.alert(data.message);
                                return false;
                            }
                            else {
                                $("#btnRefresh").trigger("click");
                            }
                            /*
                            if (!saveToDb) {
                                $.each(data.list, function (index, clactask) {
                                    var task = gantt.getTask(clactask.UID);
                                    if (task) {
                                        var modifyData = {};
                                        clactask.Start = checkDateIsNull(clactask.Start);
                                        clactask.Finish = checkDateIsNull(clactask.Finish);
                                        var isModify = false;
                                        if (clactask.Start && task.Start.DateDiff("y", clactask.Start) != 0) {
                                            modifyData["Start"] = clactask.Start;
                                            isModify = true;
                                        }
                                        if (clactask.Finish && task.Finish.DateDiff("y", clactask.Finish) != 0) {
                                            modifyData["Finish"] = clactask.Finish;
                                            isModify = true;
                                        }
                                        if (task.Critical != clactask.Critical) {
                                            modifyData["Critical"] = clactask.Critical;
                                            isModify = true;
                                        }
                                        if (isModify) {
                                            gantt.updateTask(task, modifyData);
                                            for (var i in modifyData) {
                                                if (typeof (modifyData[i]) != "function") {
                                                    gantt.setTaskModified(task, i);
                                                }
                                            }
                                        }
                                    }
                                });
                            }
                            else {
                                $("#btnRefresh").trigger("click");
                            }
                            */
                        }
                    });
                });

            });
            //锁定 解锁计划
            //下载PowerPlan客户端
            //版本
            var lstMenu = mini.get("lstVersion");
            $("#menu").on("click", "#lstVersion", function (e) {
                if (!current_plan_guid || current_plan_guid == "")
                    return false;
                var hasLimit = gantt.limit.CanEdit || gantt.limit.AllLimit;
                $.getJSON("/Plan/GetPlanVersionInfo/" + current_plan_guid, function (data) {
                    if (data.success) {
                        var menuItems = [];
                        $("#lstVersion_Upgrade,#lstVersion_Tomainplan").hide();
                        if (data.data.mainplan && data.data.mainplan.primaryVersion_guid && data.data.mainplan.primaryVersion_guid != "" && data.data.mainplan.primaryVersion_guid != "00000000-0000-0000-0000-000000000000") {
                            //说明是子版本
                            $("#lstVersion_Tomainplan").attr("plan_guid", data.data.mainplan.primaryVersion_guid);
                            $("#lstVersion_Tomainplan").show();
                            $("#lstVersion_Tomainplan").unbind("click").bind("click", function () {
                                var _plan_guid = $(this).attr("plan_guid");
                                LoadPlan(gantt, _plan_guid);
                                $("#btnCreateTaskAssign").removeAttr("disabled").removeAttr("title");
                                return false;
                            });
                        }
                        else {
                            if (hasLimit)
                                $("#lstVersion_Upgrade").show();
                            $("#lstVersion_Upgrade").unbind("click").bind("click", function () {
                                if (confirm("请确认是否要升版，升版比较耗时，请谨慎升版!!!")) {
                                    $.getJSON("/Plan/PlanUpgrade/" + current_plan_guid, function (data) {
                                        if (data.success) {
                                            //升版成功后再次打开当前计划（当前计划永远是最新版）
                                            Power.ui.success("升版成功");
                                            LoadPlan(gantt, current_plan_guid, "PlanUpgrade");
                                        }
                                        else {
                                            Power.ui.alert("存储历史版失败");
                                        }
                                    });
                                }
                                return false;
                            });
                        }
                        $("#groupVersion .dropdown-menu li").filter(":not(#lstVersion_Upgrade,#lstVersion_Tomainplan)").remove();
                        $.each(data.list, function () {
                            if (this.planfilter != "target") {
                                var itemHtml = "<li class='plan-version-item' plan_guid='" + this.proj_plan_guid + "'><a>" + "v-" + (this.versionCode || "初始版") + "</a></li>";
                                $("#groupVersion .dropdown-menu").append(itemHtml);
                            }
                        });
                        $("#groupVersion .dropdown-menu .plan-version-item").unbind("click").bind("click", function () {
                            var _plan_guid = $(this).attr("plan_guid");
                            LoadPlan(gantt, _plan_guid);
                            $("#btnCreateTaskAssign").attr("disabled", "disabled").attr("title", "历史版本计划不允许发包");
                        });
                    }
                });
                return true;
            });
            //目标
            $("#menu").on("click", "#lstTarget", function (e) {
                if (!current_plan_guid || current_plan_guid == "")
                    return false;
                var hasLimit = gantt.limit.CanEdit || gantt.limit.AllLimit;
                $.getJSON("/Plan/GetPlanVersionInfo/" + current_plan_guid, function (data) {
                    if (data.success) {
                        var menuItems = [];
                        $("#lstTarget_Upgrade,#lstTarget_Tomainplan").hide();
                        if (data.data.mainplan && data.data.mainplan.primaryVersion_guid && data.data.mainplan.primaryVersion_guid != "" && data.data.mainplan.primaryVersion_guid != "00000000-0000-0000-0000-000000000000") {
                            //说明是子版本
                            $("#lstTarget_Tomainplan").attr("plan_guid", data.data.mainplan.primaryVersion_guid);
                            $("#lstTarget_Tomainplan").show();
                            $("#lstTarget_Tomainplan").unbind("click").bind("click", function () {
                                var _plan_guid = $(this).attr("plan_guid");
                                LoadPlan(gantt, _plan_guid);
                                return false;
                            });
                        }
                        else {
                            if (hasLimit)
                                $("#lstTarget_Upgrade").show();
                            $("#lstTarget_Upgrade").unbind("click").bind("click", function () {
                                var _prompt = null;
                                _prompt = Power.ui.prompt("请输入目标名称", function (value) {
                                    if (!value || value == "") {
                                        Power.ui.error("目标名称必须输入");
                                        return false;
                                    }
                                    $.getJSON("/Plan/PlanUpgrade", {
                                        plan_guid: current_plan_guid,
                                        planfilter: "target",
                                        versioncode: value
                                    }, function (data) {
                                        _prompt.close();
                                        Power.ui.success("保存目标成功");
                                        if (data.success) {
                                            //升版成功后再次打开当前计划（当前计划永远是最新版）
                                            LoadPlan(gantt, current_plan_guid);
                                        }
                                        else {
                                            Power.ui.alert("保存目标失败");
                                        }
                                    });
                                });
                                return false;
                            });
                        }
                        $("#groupTarget .dropdown-menu li").filter(":not(#lstTarget_Upgrade,#lstTarget_Tomainplan)").remove();
                        $.each(data.list, function () {
                            if (this.planfilter == "target") {
                                var itemHtml = "<li class='plan-version-item' plan_guid='" + this.proj_plan_guid + "'><a>" + "v-" + (this.versionCode || "初始版") + "</a></li>";
                                $("#groupTarget .dropdown-menu").append(itemHtml);
                            }
                        });
                        $("#groupTarget .dropdown-menu .plan-version-item").unbind("click").bind("click", function () {
                            var _plan_guid = $(this).attr("plan_guid");
                            LoadPlan(gantt, _plan_guid);
                            $("#btnCreateTaskAssign").attr("disabled", "disabled").attr("title", "历史版本计划不允许发包");
                        });
                    }
                });
                return true;
            });
            //验证数据完整性,权重分配
            window.fun_checkcurve = function (obj) {
                if ($(obj).is(".checkcurve")) {
                    $.getJSON("/Plan/CheckCurve/" + current_plan_guid, function (data) {
                        if (data.success) {
                            if (data.data.count == "0") {
                                gantt.filter(function (task) {
                                    delete task.vfcheckcurve;
                                    return true;
                                });
                                Power.ui.success("数据验证成功！");
                            }
                            else {
                                Power.ui.error("数据验证失败，请到“数据完整性”列看具体信息");
                                var values = data.data.value;
                                gantt.filter(function (task) {
                                    delete task.vfcheckcurve;
                                    var flag = false;
                                    var msg = values[task.UID];
                                    if (msg) {
                                        task.vfcheckcurve = msg;
                                        flag = true;
                                    }
                                    return flag;
                                });
                            }
                        }
                        else {
                            Power.ui.alert(data.message);
                        }
                    });
                }
                else if ($(obj).is(".checkcurve_filter")) {
                    gantt.filter(function (task) {
                        if (task.TaskInfo && typeof (task.TaskInfo.wbs_name) != "undefined")
                            return true;
                        return task.vfcheckcurve != undefined;
                    });
                }
                else if ($(obj).is(".checkcurve_all")) {
                    gantt.clearFilter();
                }
            };

            //显示发包后的子计划
            $("body").on("click", ".subplaninfo", function () {
                var wbs_guid = $(this).attr("ids")
                var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdPlan/EditPlanWithGantt.html&uiview=query&readonly=1&wbs_guid=" + wbs_guid;
                mini.open({
                    url: url,
                    title: "子计划详情",
                    width: "80%",
                    height: "80%",
                    showMaxButton: true
                });
                return false;
            });


            mini.get("btnwinEvmInitSetCurve").on("buttonclick", function (e) {
                OnWiardCurve(function (data) {
                    e.sender.setValue(data[0].Id);
                    e.sender.setText(data[0].ModelName);
                })
            })

            mini.get("btnwinEvmInitSetRsrc").on("buttonclick", function (e) {
                OnWizardHuman(function (data) {
                    e.sender.setValue(data[0].Id);
                    e.sender.setText(data[0].Name);
                })
            })

            //初始化
            $("body").on("click", "#btnwinEvmInitSetOK", function () {
                mini.confirm("确定初始化尚未初始的作业?", "确定?", function (action) {
                    if (action != "ok") return;
                    var v = {};
                    v.est_wt = mini.get("cmbwinEvmInitSetEstwt").getValue();
                    v.feedback_pct_type = mini.get("cmbwinEvmInitSetFeedtype").getValue();
                    v.curve_guid = mini.get("btnwinEvmInitSetCurve").getValue();
                    v.rec_type = mini.get("btnwinEvmInitSetRectype").getValue();
                    var tmp = mini.get("btnwinEvmInitSetRsrc");
                    v.rsrc_name = tmp.getText();
                    v.rsrc_guid = tmp.getValue();
                    v.initselected = mini.get("chkEvmInitSet").checked;
                    var tree = [];
                    if (mini.get("chkEvmInitSet").checked) {
                        delete v.est_wt; //选择作业时,不能初始化权重
                        $.each(gantt.getSelecteds(), function () {
                            if (!this.IsWBSTask)
                                tree.push(this);
                        });
                    }
                    else
                        tree = gantt.getTaskTree();
                    gantt.mask();
                    InitEvmSet(tree, v, function () {
                        gantt.unmask();
                        var win = mini.get("winEvmInitSet");
                        win.hide();
                        LoadPlan(gantt, current_plan_guid);
                    })
                });
            });
            $("body").on("click", "#btnwinEvmInitSetClose", function () {
                var win = mini.get("winEvmInitSet");
                win.hide();
            });
            $("body").on("click", "#btn_apportion_ok", function () {
                ///debugger
                //检查wbs未设置权重，不允许分摊
                var tasks = gantt.getTaskList();
                //for (var i = 0; i < tasks.length; i++) {
                //    var task = tasks[i];
                //    if (task.IsWBSTask == true && task.TaskInfo != undefined
                //        && task.TaskInfo.est_wt_pct != undefined
                //        && (parseFloat(task.TaskInfo.est_wt_pct) == 0)) {
                //        mini.alert("WBS未分配权重,不允许分摊.", "提示");
                //        return;
                //    }
                //}

                mini.confirm("确定分摊吗?", "确定?", function (action) {
                    if (action != "ok") return;
                    var cost = mini.get("txt_apportion").getValue();
                    var url = "/Plan/ApportionExpenses/" + current_plan_guid + "/" + cost;
                    $.getJSON(url, function (o) {
                        if (o.success) {
                            var win = mini.get("win_apportion");
                            win.hide();
                            LoadPlan(gantt, current_plan_guid);
                        }
                        else
                            Power.ui.alert(o.message);
                    });
                });
            });
            //if ($.browser.msie) { $('.queryitem').click(function () { this.blur(); this.focus(); }); }

            $(".queryitem").change(function () {
                if ($(this).is("[name=all]") && this.checked) {
                    $(".queryitem").not("[name=all]").removeAttr("checked");
                }
                if (!$(this).is("[name=all]") && this.checked) {
                    $(".queryitem[name=all]").removeAttr("checked");
                }
                $("#wouldworkDay").css("display", "none");
                $("#wouldworkDayName").css("display", "none");
                if ($(".queryitem[name=wouldwork]:checked").size() > 0) {
                    $("#wouldworkDay").css("display", "");
                    $("#wouldworkDayName").css("display", "");
                }
                $("#delayDay").css("display", "none");
                $("#delayDayName").css("display", "none");
                if ($(".queryitem[name=delaydwork]:checked").size() > 0) {
                    $("#delayDay").css("display", "");
                    $("#delayDayName").css("display", "");
                }
                return false;
            });
            //作业状态查询
            $("body").on("click", "#btn_Query", function () {
                var finished = $(".queryitem[name=finishedwork]:checked").size() > 0;
                var working = $(".queryitem[name=working]:checked").size() > 0;
                var wouldwork = $(".queryitem[name=wouldwork]:checked").size() > 0;
                var wouldworkDays = mini.get("wouldworkDay").getValue();
                var delaydwork = $(".queryitem[name=delaydwork]:checked").size() > 0;
                var delayDays = mini.get("delayDay").getValue();
                var earlywork = $(".queryitem[name=earlywork]:checked").size() > 0;
                var driving_pathwork = $(".queryitem[name=driving_pathwork]:checked").size() > 0;
                var queryOptions = $("#queryOptions").val();
                var notstart = $(".queryitem[name=notstart]:checked").size() > 0;
                var emptyDate = "0001-01-01T00:00:00";
                var todayDate = new Date();
                todayDate = new Date(todayDate.format("yyyy-MM-dd 00:00:00"));


                var clacfun = {
                    //已完成 状态Status_code==TK_Complete
                    finished: function (task) {
                        return (task.PercentComplete == 100 && finished) || task.StatusCode == "TK_Complete";
                    },
                    //进行中 状态是status_code==TK_Active
                    working: function (task) {
                        return task.StatusCode == "TK_Active";
                    },
                    //即将开始状态Status_code==TK_NotStart，计划开始时间-当前日期 小于设置的天数
                    wouldwork: function (task) {
                        //即将开始的任务 默认7天内
                        if (!task.TargetStartDate)
                            task.TargetStartDate = emptyDate;
                        var planStart = StringToDate(todayDate).DateAdd("d", wouldworkDays);
                        var r = (task.StatusCode == "TK_NotStart" || task.status_code == null)
                            && (StringToDate(task.TargetStartDate) >= todayDate && task.TargetStartDate <= planStart);
                        
                        return r;
                    },
                    //滞后
                    /*1. 未开始的作业
                        Status_code TK_NotStart 或是 null，当前日期-计划开始日期 大于等于设置的天数
                        如果是完成里程碑：task_type==TT_FinMile
                         当前日期-计划完成日期 大于等于设置的天数
                      2. 进行中的作业
                        Status_code TK_Active  ,实际开始时间-计划开始时间大于等于设置的天数
                        或者 当前日期-计划完成日期大于等于设置的天数
                      3. 已完成的作业
                        Status_code TK_Complete ，实际完成时间-计划完成时间大于等于设置的天数
                        如果是开始里程碑：task_type==TT_Mile
                        实际开始时间-计划开始时间大于等于设置的天数
                    */
                    delaydwork: function (task) {
                        //滞后情况
                        if (!task.TaskInfo.act_start_date)
                            task.TaskInfo.act_start_date = emptyDate;
                        if (!task.TaskInfo.act_end_date)
                            task.TaskInfo.act_end_date = emptyDate;

                        if (!task.TargetStartDate)
                            task.TargetStartDate = emptyDate;
                        if (!task.TargetEndDate)
                            task.TargetEndDate = emptyDate;
                        //处理时间的时分秒为0点
                        var plan_StartDate = new Date(new Date(task.TargetStartDate).format("yyyy-MM-dd 00:00:00"));
                        var plan_EndDate = new Date(new Date(task.TargetEndDate).format("yyyy-MM-dd 00:00:00"));
                        var act_StartDate = new Date(new Date(task.TaskInfo.act_start_date).format("yyyy-MM-dd 00:00:00"));
                        var act_EndDate = new Date(new Date(task.TaskInfo.act_end_date).format("yyyy-MM-dd 00:00:00"));
                        //实际开始时间-计划开始时间的天数
                        var value1 = parseInt((StringToDate(act_StartDate).getTime() - StringToDate(plan_StartDate || "0001-01-01T00:00:00").getTime()) / (3600 * 24 * 1000));
                        
                        //当前日期-计划开始时间的天数
                        var value2 = parseInt((todayDate.getTime() - StringToDate(plan_StartDate || "0001-01-01T00:00:00").getTime()) / (3600 * 24 * 1000));
                        //实际完成时间-计划完成实际的天数
                        var value3 = parseInt((StringToDate(act_EndDate).getTime() - StringToDate(plan_EndDate || "0001-01-01T00:00:00").getTime()) / (3600 * 24 * 1000));
                        
                        //当前日期-计划完成时间的天数
                        var value4 = parseInt((todayDate.getTime() - StringToDate(plan_EndDate || "0001-01-01T00:00:00").getTime()) / (3600 * 24 * 1000));
                        //未开始的作业
                        var r1 = ((task.StatusCode == "TK_NotStart" || !task.StatusCode)
                            && (task.TaskInfo.task_type == "TT_FinMile" ? value4 >= delayDays : (value2 >= delayDays)));
                        //进行中的作业
                        var r2 = ((task.StatusCode == "TK_Active") && (value1 >= delayDays ||(value4 >= delayDays)));
                        //已完成的作业
                        var r3 = ((task.StatusCode == "TK_Complete")
                            && (task.TaskInfo.task_type == "TT_Mile" ? value1>= delayDays : (value3 >= delayDays)));
                        return r1 || r2 || r3;
                    },
                    //超前
                    //Status_code TK_Complete ，计划完成时间-实际完成时间>=1
                    //如果是开始里程碑：task_type==TT_Mile
                    //计划开始时间-实际开始时间>=1
                    earlywork: function (task) {
                        if (!task.TaskInfo.act_start_date)
                            task.TaskInfo.act_start_date = emptyDate;
                        if (!task.TaskInfo.act_end_date)
                            task.TaskInfo.act_end_date = emptyDate;

                        if (!task.TargetStartDate)
                            task.TargetStartDate = emptyDate;
                        if (!task.TargetEndDate)
                            task.TargetEndDate = emptyDate;
                        //处理时间的时分秒为0点
                        var plan_StartDate = new Date(new Date(task.TargetStartDate).format("yyyy-MM-dd 00:00:00"));
                        var plan_EndDate = new Date(new Date(task.TargetEndDate).format("yyyy-MM-dd 00:00:00"));
                        var act_StartDate = new Date(new Date(task.TaskInfo.act_start_date).format("yyyy-MM-dd 00:00:00"));
                        var act_EndDate = new Date(new Date(task.TaskInfo.act_end_date).format("yyyy-MM-dd 00:00:00"));
                        //计划完成时间-实际完成实际的天数
                        var value1 = parseInt((StringToDate(plan_EndDate || "0001-01-01T00:00:00").getTime()-StringToDate(act_EndDate || "0001-01-01T00:00:00").getTime()) / (3600 * 24 * 1000));
                        //计划开始时间-实际开始时间
                        var value2 = parseInt((StringToDate(plan_StartDate || "0001-01-01T00:00:00").getTime() - StringToDate(act_StartDate || "0001-01-01T00:00:00").getTime()) / (3600 * 24 * 1000));
                        var r = (task.StatusCode == "TK_Complete") && (task.TaskInfo.task_type == "TT_Mile" ? value2 >= 1 : (value1 >= 1))
                        
                        return r;
                    },
                    //关键路径 driving_path_flag = ‘Y’
                    driving_pathwork: function (task) {
                        //return task.driving_path_flag == "Y";//
                        return task.Critical == "1" || task.Critical == 1;
                    },
                    //未开始 状态Status_code TK_NotStart 或是 null
                    notstart: function (task) {
                        return (task.StatusCode == "TK_NotStart");
                    }
                };
                if ($(".queryitem[name=all]:checked").size() > 0)
                    gantt.clearFilter();
                else {

                    gantt.filter(function (task) {

                        if (queryOptions == "or") {
                            return (finished && clacfun.finished(task))
                                || (working && clacfun.working(task))
                                || (wouldwork && clacfun.wouldwork(task))
                                || (delaydwork && clacfun.delaydwork(task))
                                || (earlywork &&clacfun.earlywork(task))
                                || (driving_pathwork && clacfun.driving_pathwork(task))
                                || (notstart && clacfun.notstart(task))
                        }
                        else {
                            return (!finished || (finished && clacfun.finished(task)))
                                && (!working || (working && clacfun.working(task)))
                                && (!wouldwork || (wouldwork && clacfun.wouldwork(task)))
                                && (!delaydwork || (delaydwork && clacfun.delaydwork(task)))
                                && (!earlywork || (earlywork && clacfun.earlywork(task)))
                                && (!driving_pathwork || (driving_pathwork && clacfun.driving_pathwork(task)))
                                && (!notstart || (notstart && clacfun.notstart(task)))
                        }

                    });
                }
            });

            $("body").on("click", ".wizardcurve", function () {
                var uid = $(this).attr("id").replace("wd_", "");
                WizardCurve(uid, gantt);
                return false;
            });
            $("body").on("click", ".wizardhuman", function () {
                var uid = $(this).attr("id").replace("wd_", "");
                WizardHuman(uid, gantt);
                return false;
            });

            //校验费用  bcws_cost
            $("body").on("click", "#btnValidateApportion", function () {

                //递归校验 费用
                var errorInfo = "";
                var validateBCWSCost = function (data) {
                    var flag = true;
                    var currCost = data.TaskInfo.bcws_cost;
                    if (data.children && data.children.length > 0) {
                        var currTotalCost = 0;
                        $.each(data.children, function () {
                            var item = this;
                            currTotalCost += Number(item.TaskInfo.bcws_cost);
                        });
						currCost=Number(currCost.toFixed(6));
						currTotalCost=Number(currTotalCost.toFixed(6));
                        if (currCost != currTotalCost) {
							
                            if (currCost > currTotalCost) {
                                errorInfo = data.Name + "-WBS 尚有" + (currCost - currTotalCost).toFixed(6) + "未分摊";
                            }
                            if (currCost < currTotalCost) {
                                errorInfo = data.Name + "-WBS 超额分摊" + (currTotalCost - currCost).toFixed(6);
                            }
                            flag = false;
                        } else {
                            $.each(data.children, function () {
                                var _item = this;
                                flag = validateBCWSCost(_item);
                                if (!flag) return false;
                            });
                            if (!flag) return false;
                        }
                    }
                    return flag;
                }
                var validate = validateBCWSCost(gantt.data.Tasks[0]);
                if (validate) {
                    Power.ui.success("校验成功!");
                    SaveGantt(gantt);
                } else {
                    Power.ui.error("校验失败，" + errorInfo + "，请检查并重新填写");
                }
            });
            //汇总子计划权重 及其百分比
            $("#mainmenu ").on("click", "#btnSumChildEst_wt", function () {
                Power.ui.confirm("确定汇总子计划权重及百分比吗?", function (action) {
                    if (!action) return;
                    var plan_guid = current_plan_guid;
                    //子计划
                    var SubPlanInfo = gantt.SubPlanInfo || [];
                    var sub_plan_wbs_guids = [];
                    $.each(SubPlanInfo, function () {
                        var item = this;
                        sub_plan_wbs_guids.push(item.sub_plan_wbs_guid);
                    });
                    $.ajax({
                        url: "/Plan/GetPlanChildEst_wt",//获取子计划权重
                        async: false,
                        data: {
                            plan_guid: plan_guid,
                            sub_plan_wbs_guids: sub_plan_wbs_guids.join(",")
                        },
                        type: "POST",
                        dataType: "JSON",
                        success: function (result) {
                            if (result.list && result.list != "") {
                                var datalist = mini.decode(result.list);
                                var tasklist = gantt.getTaskList();
                                //给子计划的权重赋值
                                $.each(datalist, function () {
                                    var item = this;
                                    $.each(SubPlanInfo, function () {
                                        var _item = this;
                                        if (item.sub_plan_wbs_guid == _item.sub_plan_wbs_guid) {
                                            var record = gantt.getTask(_item.task_guid);
                                            //更新权重
                                            gantt.updateTask(record, "est_wt", parseFloat(item.est_wt));
                                            gantt.setTaskModified(record, "est_wt");
                                        }
                                    });
                                });

                                //汇总子计划权重和权重百分比 递归方法
                                var gantttasklist = gantt.data.Tasks;
                                //先给每一个wbs和task加一个标识，是否累加过，初始化给叶子节点的task加标识为true 其他为false
                                var GetEst_WtFun = function (d) {
                                    d.flag = false;
                                    if (!d.IsWBSTask) {
                                        d.flag = true;
                                    }
                                    if (d.children && d.children.length > 0) {
                                        $.each(d.children, function () {
                                            GetEst_WtFun(this);
                                        });
                                    } else {
                                        d.flag = true;
                                    }
                                }
                                $.each(gantttasklist, function () {
                                    GetEst_WtFun(this);
                                });
                                //加完标识 开始循环递归 由下往上汇总权重
                                var GetEst_WtFuns = function (d) {
                                    if (d.children && d.children.length > 0) {
                                        //判断当前节点的孩子节点 是否全部被累加过
                                        var getChildren = function (q) {
                                            var flag = true;
                                            if (q.children && q.children.length > 0) {
                                                $.each(q.children, function () {
                                                    if (!this.flag) {
                                                        flag = false;
                                                    }
                                                });
                                            }
                                            return flag;
                                        }
                                        //如果当前节点未被累加 且其子节点全部被累加
                                        if (getChildren(d) && !d.flag) {
                                            var est_wts = 0;
											
                                            $.each(d.children, function () {
												
                                                est_wts += parseFloat(typeof this.est_wt=="undefined"?0:this.est_wt);
                                                delete this;
                                            });
                                            d.est_wt = isNaN(est_wts) ? 0 : est_wts;
                                            var record = gantt.getTask(d.UID);
											
                                            gantt.updateTask(record, "est_wt", d.est_wt);
                                            gantt.setTaskModified(record, "est_wt");
                                            d.flag = true;
                                            //当前节点非根节点 则重新递归
                                            if (d.ParentTaskUID != -1) {
                                                $.each(gantttasklist, function () {
                                                    GetEst_WtFuns(this);
                                                });
                                            }
                                        } else {
                                            $.each(d.children, function () {
                                                GetEst_WtFuns(this);
                                            });
                                        }
                                    }

                                }
                                $.each(gantttasklist, function () {
                                    GetEst_WtFuns(this);
                                });

                                //递归，由下往上计算权重%
                                var gantttasktree = gantt.getTaskTree();
                                var GetEst_WtPctFuns = function (d) {
                                    var currest_wt = d.est_wt;
                                    if (d.ParentTaskUID == -1) {
                                        var value = 100;
                                        if (d.est_wt == 0 || isNaN(d.est_wt)) {
                                            value = 0;
                                        }
                                        gantt.updateTask(d, "est_wt_pct", value);
                                        gantt.setTaskModified(d, "est_wt_pct");
                                    }
                                    if (d.children && d.children.length > 0) {
                                        var l = d.children.length - 1;
                                        var totalpct = 0;
                                        $.each(d.children, function (i) {
                                            var item = this;
                                            if (i != l) {
												var value = 0;
                                                if (currest_wt == 0 || isNaN(currest_wt)) {
                                                    value = 0;
                                                }else{
													value = parseFloat((parseFloat(item.est_wt / currest_wt) * 100).toFixed(2));
													value=isNaN(value)?0:value;
												}
                                                totalpct += value;
                                                gantt.updateTask(item, "est_wt_pct", value);
                                                gantt.setTaskModified(item, "est_wt_pct");
                                            } else {
                                                var values = 100 - totalpct;
                                                if (d.est_wt == 0 || isNaN(d.est_wt)) {
                                                    values = 0;
                                                }
                                                gantt.updateTask(item, "est_wt_pct", values);
                                                gantt.setTaskModified(item, "est_wt_pct");
                                            }
                                        });
                                        $.each(d.children, function () {
                                            GetEst_WtPctFuns(this);
                                        })
                                    }
                                }
                                $.each(gantttasktree, function () {
                                    GetEst_WtPctFuns(this);
                                });
                            }
                        }
                    });
                    $("#btnEditSave").trigger("click");
                });
            });

            //加载自定义事件
            ganttPlusMenuFuns.PlusEvent(_gantt);
        },
        //自定义事件(包括新增的菜单事件)
        "PlusEvent": function (_gantt) { },
        //当菜单过多时，一排显示不下，将多余的菜单放入下拉框
        "menuToDropDown": function () {
            //code by yc.tao
            //判断元素是否显示
            var objIsShow = function (obj) {
                return new RegExp("block").test(obj.css("display"))
            }
            //获取菜单的长度
            var mainmenuWidth = 0, totalWidth = $("#menu").parent().outerWidth(true), offsetLeft = { left: 0, id: "body" };
            $.each($("#mainmenu").find(".mainmenu"), function () {
                if (!objIsShow($(this))) return;
                mainmenuWidth += $(this).outerWidth(true) + 1;
                //console.log($(this).text()+":"+$(this).offset().left)
            });
            var otherWith = 0;
            var countOtherWith = function (obj) {
                if (!obj) return;
                if (objIsShow(obj)) {
                    otherWith += obj.outerWidth(true);
                }
            }
            countOtherWith($("#div_downloadclient"));
            countOtherWith($("#dropdownmenu"));
            countOtherWith($("#queryContainter"));
            countOtherWith($("#queryMultiLevelContainter"));
            //console.log(totalWidth + "-" + mainmenuWidth + "-" + otherWith + "-" + $(".mainmenu-more").outerWidth(true));
            var maxtotalWidth = totalWidth - otherWith;
            if (otherWith >= totalWidth) {
                //maxtotalWidth = otherWith - totalWidth;
                $("#mainmenu").css("width", mainmenuWidth + "px");
                $(".mainmenu-more").hide();
                return;
            }
            debugger
            if (mainmenuWidth > (maxtotalWidth - $(".mainmenu-more").outerWidth(true))) {
                $(".mainmenu-more").show();
                var width = maxtotalWidth - $(".mainmenu-more").outerWidth(true) - 10;
                $("#mainmenu").css("width", width + "px");
                $.each($("#mainmenu").find(".mainmenu"), function () {
                    if (!objIsShow($(this))) return;
                    if (offsetLeft.left < $(this).offset().left && $(this).offset().left < $(".mainmenu-more").offset().left) {
                        //console.log($(this).text() + ":" + $(this).offset().left)
                        offsetLeft.left = $(this).offset().left;
                        offsetLeft.id = "#" + this.id;
                    }
                });
                width = $("#mainmenu").outerWidth(true) - ($(".mainmenu-more").offset().left - $(offsetLeft.id).offset().left - $(offsetLeft.id).outerWidth(true));
                //var width = $(offsetLeft.id).offset().left + $(offsetLeft.id).outerWidth(true)+70;
                //$("#mainmenu").css("width", width + "px");

                //将未显示的菜单移到下拉菜单
                $(".mainmenu-more").find("ul").html("");
                $.each($(offsetLeft.id).nextAll(), function () {
                    var html = $(this).html();
                    //将原本菜单的属性值添加到下拉框的菜单之中
                    var obj = $(this)[0].attributes;
                    var targetHtml = "<a ";
                    for (var i in obj) {
                        if (!isNaN(parseInt(i))) {
                            if (obj[i].name != "style" && obj[i].name != "type" && obj[i].name != "class") {
                                targetHtml += ' ' + obj[i].name + '="' + obj[i].nodeValue + '"  ';
                            }
                        }
                    }
                    targetHtml += ">" + html;
                    targetHtml += "</a>";
                    $(".mainmenu-more").find("ul").append("<li class='" + this.id + "'>" + targetHtml + "</li>");
                    if (typeof this.id == "undefined"||!this.id) return;
                    $("#mainmenu").find("#" + this.id)
                        .attr("data-id", this.id)
                        .attr("id", this.id + "-menudropdown")
                        //.addClass("menuhide")
                        .css("display", "none");
                    if ($(this).attr("href")) {
                        $("#mainmenu").find("#" + this.id + "-menudropdown").attr("href", $(this).attr("href"));
                    }
                });
            }
        },
        //数据加载完后 页面可能会隐藏或者显示部分菜单 需要重新调整菜单
        "AfterLoadDataMenuToDropDown": function () {
            $(".mainmenu-more").hide();
            $.each($("button[id*='-menudropdown'],a[id*='-menudropdown']"), function () {
                $(this).attr("id", $(this).attr("data-id"))
                       .removeClass("menuhide")
                       .css("display","");
                var item = $(this);
                //把对下拉框按钮加的属性 添加到原来的button上
                $.each($(".mainmenu-more ul li a"), function () {
                    if (item.attr("id") != $(this).attr("id")) return;
                    var obj = $(this)[0].attributes;
                    for (var i in obj) {
                        if (!isNaN(parseInt(i))) {
                            if (obj[i].name != "id" && obj[i].name != "style" && obj[i].name != "class") {
                                item.attr(obj[i].name, obj[i].nodeValue);
                            }
                        }
                    }
                })
            });
            ganttPlusMenuFuns.menuToDropDown();
        }
    }
}();

//默认的页签tab方法
var ganttPlusTabsFuns = function () {
    //新增页签tab
    var tabsObj = [];
    return {
        "SetTabs": function (tab, tabHtml) {
            tabsObj.push({ "tab": tab, tabHtml: tabHtml });
        },
        "GetTabs": function () {
            return tabsObj;
        },
        "beforeInit": function () { },
        "Init": function () {
            ganttPlusTabsFuns.beforeInit();
            var tabs = ganttPlusTabsFuns.GetTabs();
            var tabContent = mini.get("taskDetailTab");
            $.each(tabs, function () {
                var item = this;
                tabContent.addTab(item.tab);
                tabContent.getTabBodyEl(item.tab).innerHTML = item.tabHtml;
            });
        },
        "HideTabs": function (tabs) {
            var tabContent = mini.get("taskDetailTab");
            $.each(tabs, function () {
                var itemTab = this;
                if (itemTab) {
                    tabContent.updateTab(itemTab, { visible: false });
                }
            });
        },
        "ShowTabs": function (tabs) {
            var tabContent = mini.get("taskDetailTab");
            $.each(tabs, function () {
                var itemTab = this;
                if (itemTab) {
                    tabContent.updateTab(itemTab, { visible: true });
                }
            });
        },
        //初始化默认页签tab事件
        "InitEvent": function (_gantt) {

            //切换子页签的时候获取子表数据
            mini.get("taskDetailTab").on("activechanged", function (e) {
                gantt.loadTab(e.tab);
            });

            function OpenPL() {
                var task = gantt.getSelected();
                if (!task || !task.TaskInfo) return;
                var title = "作业:" + task.Name;
                var keyword = task.IsWBSTask ? "WBS" : "TASK";
                mini.open({
                    url: "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/Systems/Comment.html&FormId=04666d30-9ea7-4428-a321-6a970785a1f5&KeyWord=" + keyword + "&KeyValue=" + task.UID,
                    title: title,
                    showMaxButton: true,
                    width: "80%", height: "80%",
                    ondestroy: function () {
                        gantt.loadTab({ name: "Comment" });
                    }
                })
            }

            function rendererLag_ht_cnt(e) {
                if (!e.value || e.value == "")
                    return "";
                return (e.value / 8).toFixed(2);
            }

            //****************常用属性页签****************//
            //检测方式改变
            function feedback_pct_typeChange(e) {
                var grid = mini.get("datagrid_DocFile");
                grid.hideColumn("Deliverable_name");
                if (e.value == "Deliverable") {
                    grid.showColumn("Deliverable_name");
                }
            }


            //****************逻辑关系页签****************//
            //紧前任务 紧后任务
            $("#datagrid_TaskPred\\.Del,#datagrid_TaskNext\\.Del").unbind("click").click(function () {
                var gridId = this.id.split(".")[0];
                var grid = mini.get(gridId);
                var rows = grid.getSelecteds();
                if (!rows || rows.length == 0)
                    return false;
                var postData = {};
                var taskList = [];
                $.each(rows, function () {
                    this._state = "removed";
                    var rowLink = this;
                    var task = null;
                    task = gantt.getTask(rowLink.task_guid);
                    if (task && task.PredecessorLink) {
                        if (gridId == "datagrid_TaskPred") {
                            //删除前置关系
                            $.each(task.PredecessorLink, function () {
                                if (this.PredecessorUID == rowLink.pred_guid)
                                    this._state = "removed";
                            });
                        }
                        if (gridId == "datagrid_TaskNext") {
                            //找到后续作业,处理它的前置
                            $.each(task.PredecessorLink, function () {
                                if (this.TaskUID == rowLink.task_guid)
                                    this._state = "removed";
                            });
                        }
                    }
                    taskList.push(task);
                });
                var _taskData = getModifyTasks();
                postData["TaskPred"] = { KeyWordType: "BO", data: rows };
                postData["TASK"] = { KeyWordType: "BO", data: _taskData };

                Power.ui.loading("正在保存...");
                SaveServer(postData, function (o) {
                    Power.ui.loading.close();
                    grid.removeRows(rows, true);
                    $.each(taskList, function () {
                        var newLink = [];
                        var task = this;
                        $.each(this.PredecessorLink || [], function () {
                            if (this._state != "removed") {
                                newLink.push(this);
                            }
                        });
                        gantt.setLinks(task, newLink);
                    });
                    Power.ui.success("删除逻辑关系成功!");
                }, function () {
                    Power.ui.loading.close();
                    Power.ui.error("删除逻辑关系失败!");
                });
                return false;
            });
            var task_pred_cellendedit = function (e) {
                var postData = {};
                var linkerResult = [];
                if (e.field == "pred_type") {

                    var linkType = $.inArray(e.value, predTypeEnum);

                    //当前作业的前置
                    linkerResult.push({
                        PredecessorUID: e.record.pred_guid,
                        PredecessorName: "",
                        Type: linkType,
                        TaskUID: e.record.task_guid
                    });

                    e.record.pred_type = e.value;
                    e.record._state = "modified";
                    postData["TaskPred"] = { KeyWordType: "BO", data: [e.record] };
                }
                if (e.field == "lag_hr_cnt") {
                    var postRecord = $.extend(true, {}, e.record, { lag_hr_cnt: e.value * 8, _state: "modified" });
                    postData["TaskPred"] = { KeyWordType: "BO", data: [postRecord] };
                }

                Power.ui.loading("正在保存...");
                SaveServer(postData, function (o) {
                    $.each(linkerResult, function () {
                        var task = gantt.getTask(this.TaskUID) || [];
                        var link = this;
                        var taskPred = gantt.getTask(this.PredecessorUID) || [];

                        var PredecessorLink = task.PredecessorLink || [];
                        var exists = $.grep(PredecessorLink, function (item) {
                            return item.PredecessorUID == link.PredecessorUID && item.TaskUID == link.TaskUID;
                        }).length > 0;
                        if (exists) {
                            gantt.updateTask(task, { PredecessorLink: linkerResult });
                        }
                    });
                    gantt.acceptChanges();
                    e.sender.accept();
                    Power.ui.loading.close();
                    Power.ui.success("保存成功!");
                }, function (errorMsg) {
                    Power.ui.error("保存失败!" + errorMsg);
                });
            }
            mini.get("datagrid_TaskPred").on("cellendedit", task_pred_cellendedit);
            mini.get("datagrid_TaskNext").on("cellendedit", task_pred_cellendedit);



            //****************步骤页签****************// 
            //按引用模板新增步骤
            $("#TaskProc\\.AddModel").click(function () {
                WizardTaskProcModel(gantt);
                return false;
            });
            //批量增加步骤模板
            $("#TaskProc\\.BatAddModel").click(function () {
                var tasks = gantt.getSelecteds();
                if (tasks.length > 0) {
                    WozardTaskProcWin(function (data) {
                        var postData = {};
                        postData["TaskProc"] = { KeyWordType: "BO", data: [] };
                        $.each(tasks, function (t, task) {
                            $.each(data, function (i, item) {
                                var record = {
                                    task_guid: task.UID,
                                    proc_name: item.Step,
                                    est_wt: item.Weight,
                                    est_wt_pct: item.TotalWeight,
                                    temp_guid: item.MasterId,
                                    KeyWord: item.KeyWord,
                                    _state: "added"
                                };
                                postData["TaskProc"].data.push(record);
                            });
                        });
                        SaveServer(postData, function () {
                            Power.ui.success("批量增加步骤成功");
                        }, function (data) {
                            Power.ui.error("批量增加步骤失败" + data.message);
                        })
                    });
                }
                return false;
            });
            //新增步骤
            $("#TaskProc\\.Add").click(function () {
                OnGridAddRow('datagrid_TaskProc', 'task_guid', true, gantt);
                return false;
            });
            //删除步骤
            $("#TaskProc\\.Del").click(function () {
                OnGridDelete("datagrid_TaskProc", "TaskProc");
                return false;
            });
            //步骤列结束编辑
            mini.get("datagrid_TaskProc").on("cellendedit", function (e) {
                if (e.record._state == undefined) return;
                //修改权重，计算权重百分比
                if (e.field == "est_wt") {
                    var grid = e.sender;
                    var data = grid.data;
                    var total = 0;
                    var updrows = [];
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].est_wt != "0") {
                            data[i].est_wt = data[i].est_wt == null ? 0 : data[i].est_wt;
                            total += parseFloat(data[i].est_wt);
                            updrows.push(data[i]);
                        }
                        else
                            grid.updateRow(data[i], { est_wt_pct: "0" });
                    }
                    if (total != 0) {
                        var noLastRows = [];
                        for (var i = 0; i < updrows.length - 1; i++) {
                            updrows[i].est_wt = updrows[i].est_wt == null ? 0 : updrows[i].est_wt;
                            var vtemp = Math.round(parseFloat(updrows[i].est_wt) / total * 10000) / 100;
                            noLastRows.push(vtemp);
                            grid.updateRow(updrows[i], { "est_wt_pct": vtemp });
                        }
                        var noLastTotal = 0;
                        $.each(noLastRows, function () {
                            noLastTotal += parseFloat(this);
                        })
                        var lastTemp = parseFloat(100 - noLastTotal).toFixed(2);
                        grid.updateRow(updrows[updrows.length - 1], { "est_wt_pct": lastTemp });
                    }
                }
                //Ronnie新增（修改计划完成时间时，编辑target_end_date_lag(计划执行间隔)=target_end_date计划结束时间-act_end_date实际结束时间）
                /*
                if (e.field == "act_end_date") {
                    var tasks = gantt.getSelecteds();
                    if (tasks.length > 0) {
                        var grid = e.sender;
                        var data = grid.data;
                        for (var i = 0; i < data.length; i++) {
                            if (data[i]._uid == e.row._uid) {
                                var target_end_date_lagValue = parseInt((checkDateIsNull(tasks.TargetEndDate) - checkDateIsNull(e.value)) / (3600 * 24 * 1000));
                                target_end_date_lagValue = target_end_date_lagValue / (1 * 24 * 60 * 60 * 1000);
                                //grid.updateRow(data[i], { target_end_date_lag: target_end_date_lagValue });
                            }
                        }

                    }
                }
                */
                SaveGrid("TaskProc");
            })



            //****************资源页签****************//
            //按模板新增资源
            $("#TaskRSRC\\.AddModel").click(function () {
                //获取已使用过的数据；
                var griddata = mini.get("datagrid_TaskRSRC").getData();
                var sfilter = "";
                if (griddata.length > 0) {
                    for (var i = 0; i < griddata.length; i++) {
                        sfilter = sfilter + ",'" + griddata[i]["rsrc_guid"] + "' ";
                    }
                    sfilter = sfilter.substring(1, sfilter.length - 1);
                }
                WizardRSRC(gantt, sfilter);
                return false;
            });
            //增加资源
            $("#TaskRSRC\\.Add").click(function () {
                OnGridAddRow('datagrid_TaskRSRC', 'task_guid', true, gantt);
                return false;
            });
            //删除资源
            $("#TaskRSRC\\.Del").click(function () {
                OnGridDelete("datagrid_TaskRSRC", "TaskRSRC");
                return false;
            });
            //资源结束编辑
            mini.get("datagrid_TaskRSRC").on("cellendedit", function (e) {
                if (e.record._state == undefined) return;
                if (e.field == "cost_per_qty" || e.field == "target_qty" || e.field == "act_reg_qty" || e.field == "remain_qty") {
                    var p = e.record.cost_per_qty || 0;
                    var q = e.record.target_qty || 0
                    var act_reg_qty = e.record.act_reg_qty || 0
                    var remain_qty = e.record.remain_qty || 0
                    e.sender.updateRow(e.row, {
                        target_cost: Math.round(q * p * 100) / 100,
                        act_reg_cost: Math.round(act_reg_qty * p * 100) / 100,
                        remain_cost: Math.round(remain_qty * p * 100) / 100
                    })
                }
                if (e.field == "ismain" && e.value == "1" && e.sender.data.length > 1) {
                    $.each(e.sender.data, function () {
                        if (this.ismain == "1" && this._uid != e.record._uid) {
                            e.sender.updateRow(this, { ismain: 0 });
                        }
                    })
                }
                SaveGrid("TaskRSRC");
            })



            //****************分类码页签
            //新增分类码
            $("#PLN_TASKACTV\\.Add").click(function () {
                WizardCategoryCode(gantt);
                return false;
            });
            //删除分类码
            $("#PLN_TASKACTV\\.Del").click(function () {
                //OnGridDelete("datagrid_TaskCategoryCode", "TaskCategoryCode");
                OnGridDelete("datagrid_PLN_TASKACTV", "PLN_TASKACTV");
                return false;
            });



            //****************评论页签****************//
            //新增评论
            $("#Comment\\.Add").click(function () {
                OpenPL();
                return false;
            });
            //删除评论
            $("#Comment\\.Del").click(function () {
                var grid = mini.get("datagrid_Comment");
                var rows = grid.getSelected();
                grid.removeRow(rows, true);
                SaveGrid("Comment");
                return false;
            });
            
            //评论 列结束编辑
            mini.get("datagrid_Comment").on("cellendedit", function (e) {
                if (e.record._state == undefined) return;
                SaveGrid("Comment");
            });



            //****************附件页签****************//
            // 附件上传
            $("#DocFile\\.Upload").uploadify({
                fileSizeLimit: 0,
                auto: true,
                blocksize: 2048 * 500, //分块大小
                buttonText: '<i class="fa fa-upload"></i>上传',
                swf: '/Scripts/plugins/uploadify/uploadify.swf',
                uploader: '/PowerPlat/Control/File.ashx?_type=ftp&action=upload',
                formData: function () {
                    var rlt = { KeyWord: "TASK" };
                    var task = gantt.getSelected();
                    if (task)
                        rlt.KeyValue = task.UID;
                    return rlt;
                },
                onUploadComplete: function () {
                    gantt.loadTab({ name: "DocFile" });
                },
                onDialogClose: function () {
                },
                dragzone: "#datagrid_DocFile"
            });
            //附件下载
            $("#DocFile\\.Download").click(function () {
                var sel = mini.get("datagrid_DocFile").getSelected();
                if (!sel || sel.length == 0) return;
                window.open("/File/Download/ftp/" + sel["Id"]);
            });
            //附件删除
            $("#DocFile\\.Del").click(function () {
                var grid = mini.get("datagrid_DocFile");
                var sel = grid.getSelecteds();
                if (sel.length == 0) return;
                var yes = "是";
                var no = "否";
                var btnOpt = {};
                btnOpt[yes] = {
                    theme: 'primary',
                    handler: function () {
                        for (var i = 0; i < sel.length; i++) {
                            //if (sel[i].RegHumId != sessiondata.HumanId) {
                            //    Power.ui.warning("不是上传人不允许删除.");
                            //    continue;
                            //}
                            $.getJSON('/PowerPlat/Control/File.ashx?_type=ftp&action=delete&_fileid=' + sel[i].Id, function (data) {

                            });
                            grid.removeRow(sel[i], true);
                        }
                    }
                };
                btnOpt[no] = function () { };
                parent.Power.ui.confirm("确定删除附件?", { button: btnOpt }); //是否删除该文件?
            });



            //****************支付项页签****************//
            //新增支付项
            $("#PS_PIWBS\\.Add").click(function () {
                WizardPSPI(gantt);
                return false;
            });
            //删除支付项
            $("#PS_PIWBS\\.Del").click(function () {
                OnGridDelete("datagrid_PS_PIWBS", "PS_PIWBS");
                return false;
            });



            //****************物料清单页签****************//
            //新增物料清单
            $("#PS_TaskBOM\\.Add").click(function () {
                OnWizardBOM(function (rows) {
                    var grid = mini.get("datagrid_PS_TaskBOM");
                    for (var i = 0; i < rows.length; i++) {
                        row = OnGridAddRow(grid.id, "task_guid", false, gantt);
                        var data = mini.clone(rows[i]);
                        delete data.Id;
                        grid.updateRow(row, data);
                    }
                    SaveGrid("PS_TaskBOM");
                })
            });
            //删除物料清单
            $("#PS_TaskBOM\\.Del").click(function () {
                var grid = mini.get("datagrid_PS_TaskBOM");
                var rows = grid.getSelecteds();
                if (rows.length == 0) return;
                grid.removeRows(rows);
                SaveGrid("PS_TaskBOM", function () {
                    grid.reload();
                });
            });



            //****************模型页签****************//
            //新增模型
            $("#PS_PLN_TaskModelLink\\.Add").click(function () {
                OnWizardModel(function (rows) {
                    //得到datagrid_PS_PLN_TaskModelLink对象
                    var grid = mini.get("datagrid_PS_PLN_TaskModelLink");
                    for (var i = 0; i < rows.length; i++) {
                        row = OnGridAddRow(grid.id, "task_guid", false, gantt);
                        var data = mini.clone(rows[i]);
                        delete data.Id;
                        grid.updateRow(row, data);
                    }
                    SaveGrid("PS_PLN_TaskModelLink");
                })
            });
            //删除模型
            $("#PS_PLN_TaskModelLink\\.Del").click(function () {

                OnGridDelete("datagrid_PS_PLN_TaskModelLink", "PS_PLN_TaskModelLink");
            });



            //****************3D模型页签****************//
            //新增3D模型
            $("#PS_PLN_FuLongModelLink\\.Add").click(function () {
                OnWizardFuLongModel(function (rows) {
                    //得到datagrid_PS_PLN_FuLongModelLink对象
                    var grid = mini.get("datagrid_PS_PLN_FuLongModelLink");
                    for (var i = 0; i < rows.length; i++) {
                        row = OnGridAddRow(grid.id, "Task_guid", false, gantt);
                        var data = mini.clone(rows[i]);
                        delete data.Id;
                        grid.updateRow(row, data);
                    }
                    SaveGrid("PS_PLN_FuLongModelLink");
                })
            });
            //删除3D模型
            $("#PS_PLN_FuLongModelLink\\.Del").click(function () {

                OnGridDelete("datagrid_PS_PLN_FuLongModelLink", "PS_PLN_FuLongModelLink");
            });



            //****************初始化自定义事件****************//
            ganttPlusTabsFuns.PlusEvent(_gantt);
        },
        //自定义事件
        "PlusEvent": function (_gantt) { }
    }
}();

//****************模态框的点击右上角关闭按钮后激发****************//
function panel_LinkSelectEditorbeforeClick(e) {
    var name = e.name;
    var panel_LinkSelectEditor = mini.get("panel_LinkSelectEditor");
    if (name == "close") {
        panel_LinkSelectEditor.hide();
    }
}


// ****************逻辑关系页签 紧前任务 紧后任务****************//
function AddTaskPred(type) {
    if (!linkTaskForm) {
        Power.ui.error("非B/S在线编辑模式不能分配逻辑关系!");
        return false;
    }
    var winTitle = "";
    switch (type) {
        case "Predecessor":
            winTitle = "选择紧前作业";
            break;
        case "Successor":
            winTitle = "选择紧后作业";
            break;
    }
    var panel_LinkSelectEditor = mini.get("panel_LinkSelectEditor");
    panel_LinkSelectEditor.setTitle(winTitle);
    var treeData = gantt.getTaskTree();
    var treeCtrl = mini.get("linkSelectditorTree");
    mini.get("linkeditor_linktype_container").setValue("1");
    treeCtrl.setData(treeData);
    treeCtrl.uncheckAllNodes();
    panel_LinkSelectEditor.show();
    var formTaskData = gantt.editForm.getData();
    var formTask = gantt.getTask(formTaskData.UID);
    linkTaskForm.setData(formTask, true, true);
    //取消
    $("#btnClosePredecessorWin").unbind("click").click(function () {
        panel_LinkSelectEditor.hide();
        return false;
    });
    //保存
    $("#btnSavePredecessorWin").unbind("click").click(function () {
        var linkType = mini.get("linkeditor_linktype_container").getValue();
        if (linkType == "")
            linkType = "1";
        var linker = mini.get("linkSelectditorTree").getCheckedNodes(false);
        var thisTask = gantt.getSelected();
        if (!thisTask || !linker || linker.length == 0)
            return false;
        var _taskDict = {};
        var _taskList = gantt.getTaskList();
        $.each(_taskList, function () {
            if (!_taskDict[this.UID])
                _taskDict[this.UID] = this;
        });
        //var _addTaskList = $.grep(_taskList, function (item) {
        //    return !item.TaskInfo.task_id||item.TaskInfo.task_id==0
        //});
        var data = {};
        var PredecessorResult = [];
        var linkerResult = [];
        if (type == "Predecessor") {
            //获取最终记录
            $.each(linker, function () {
                //当前作业的前置
                linkerResult.push({
                    PredecessorUID: this.UID,
                    PredecessorName: this.Name,
                    Type: linkType,
                    TaskUID: thisTask.UID
                });
            });
        }
        if (type == "Successor") {
            var _data = [];
            $.each(linker, function () {
                //把当前作业作为相关的作业 的前序
                linkerResult.push({
                    PredecessorUID: thisTask.UID,
                    PredecessorName: thisTask.Name,
                    Type: linkType,
                    TaskUID: this.UID
                });
            });
        }
        //声明是否选择自己参数（true:自己）Ronnie新增
        var Isoneself = false;
        var postData = {};
        postData["TaskPred"] = { KeyWordType: "BO", data: [] };
        $.each(linkerResult, function () {
            var _task_pred = {
                task_pred_guid: newGuid(),
                _state: "added",
                task_id: _taskDict[this.TaskUID].TaskInfo.task_id,
                task_guid: this.TaskUID,
                pred_task_id: _taskDict[this.PredecessorUID].TaskInfo.task_id,
                pred_guid: this.PredecessorUID,
                proj_id: gantt.planinfo.proj_id,
                proj_guid: gantt.planinfo.proj_guid,
                pred_proj_id: gantt.planinfo.proj_id,
                pred_proj_guid: gantt.planinfo.proj_guid,
                pred_plan_guid: gantt.planinfo.proj_plan_guid,
                //pred_plan_id: _taskDict[this.PredecessorUID].TaskInfo.pred_plan_id,
                pred_plan_id: _taskDict[this.PredecessorUID].plan_id,
                pred_type: predTypeEnum[(parseInt(this.Type) || 1)],
                plan_id: gantt.planinfo.proj_plan_id,
                plan_guid: gantt.planinfo.proj_plan_guid,

                wbs_guid: _taskDict[this.TaskUID].TaskInfo.wbs_guid,
                wbs_id: _taskDict[this.TaskUID].TaskInfo.wbs_id,
                pred_wbs_guid: _taskDict[this.PredecessorUID].TaskInfo.wbs_guid,
                pred_wbs_id: _taskDict[this.PredecessorUID].TaskInfo.wbs_id
            };
            //Ronnie新增
            //if (_taskDict[this.TaskUID].TaskInfo.task_id == _taskDict[this.PredecessorUID].TaskInfo.task_id) {
            //Isoneself = true;//选择了自己
            //}
            if (this.TaskUID == this.PredecessorUID) {
                Isoneself = true;//选择了自己
            }

            postData["TaskPred"].data.push(_task_pred);
        });
        //逻辑关系选择了作业本身
        if (Isoneself) {
            Power.ui.error("逻辑关系不能为作业本身!");
            return false;
        }

        var _taskData = getModifyTasks();
        postData["TASK"] = { KeyWordType: "BO", data: _taskData };

        Power.ui.loading("正在保存...");
        SaveServer(postData, function (o) {
            $.each(linkerResult, function () {
                var task = gantt.getTask(this.TaskUID) || [];
                var link = this;
                var PredecessorLink = this.PredecessorLink || [];
                var exists = $.grep(PredecessorLink, function (item) {
                    return item.PredecessorUID == link.PredecessorUID && item.TaskUID == link.TaskUID;
                }).length > 0;
                if (!exists) {
                    PredecessorLink.push(this);
                    gantt.updateTask(task, { PredecessorLink: PredecessorLink });
                }
            });
            gantt.acceptChanges();
            Power.ui.loading.close();
            //Power.ui.success("保存成功!");

            panel_LinkSelectEditor.hide();
            var tabs = mini.get("taskDetailTab").getTabs();
            var taskDetailTab = mini.get("taskDetailTab").getActiveTab();
            gantt.loadTab(taskDetailTab);

        }, function (errorMsg) {
            Power.ui.error("保存失败!" + errorMsg);
            panel_LinkSelectEditor.hide();
        });
    });
}



//****************附件页签****************//
//附件查看
function TaskDocView(action) {
    var row = mini.get("datagrid_DocFile").getSelected();
    if (!row) return;
    if (action == "pdf") {
        var url = "/PowerPlat/FormXml/FileViewer.aspx?online=1&fileid=" + row["Id"];
        window.open(url);
    }
    else if (action == "office") {
        var url = "/PowerPlat/FormXml/DocFile/DocumentEdit.aspx?id=" + row["Id"] + "&readonly=1";
        window.open(url);
    }
}

//评论时间
var timeRenderer = function (e) {
    var rlt = e.value.replace("T", " ");
    return rlt;
}

//选择3D模型
function OnWizardFuLongModel(callback) {
    var url = "/Form/Wizard?wizardid=ccd7b0d2-0ea5-4719-8f2c-641e9813aee0&formid=&btnid=";
    mini.open({
        url: url, title: "选择3D模型",
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var cwin = this.getIFrameEl().contentWindow;
            if (cwin.Select) {
                //cwin.HideMajorFilter();
                //cwin.SetDefaultMajor(wbsprop);
                if (cwin.WizardParams) cwin.WizardParams.multi = 1;
                if (cwin.Select.LoadStepFirst) cwin.Select.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            for (var i = 0; i < data.length; i++) {
                data[i].Model_guid = data[i].id;
                data[i].Model_Name = data[i].categoryName;
            }
            if (callback) {
                callback(data);
            }
        }
    });
}

//页签 物料清单
function OnBeforeLoadTaskBOM(e) {
    e.cancel = true;
    var task = gantt.getSelected();
    if (!task)
        return false;
    if (task.IsWBSTask) {
        e.sender.setData("");
        return;
    }
    var p = { KeyWord: "PS_TaskBOM", KeyWordType: "BO", select: "", sort: "Sequ", index: e.params.pageIndex, size: e.params.pageSize, extparams: "" };
    p.swhere = "task_guid='" + task.UID + "'";
    $.ajax({
        url: "/Form/GridPageLoad", data: p, type: "POST",
        success: function (text) {
            var o = mini.decode(text);
            if (o.success) {
                e.sender.setData(mini.decode(o.data.value));
                e.sender.setTotalCount(o.data.totalcount);
            }
        }
    })
}
//选择BOM物资
function OnBeforeLoadBOM(e) {
    e.cancel = true;
    e.sender.setData("");
    var task = gantt.getSelected();
    if (!task)
        return false;
    if (task.IsWBSTask) {
        return;
    }
    //找到专业、装置
    var wbsprop = GetWBSProperty(task);
    var p = { index: e.params.pageIndex, size: e.params.pageSize };
    if (mini.get("PsBomDescription").value) wbsprop.description = mini.get("PsBomDescription").value;
    p.strdata = mini.encode(wbsprop);
    $.ajax({
        url: "/Purchase/BOMAutoMatchData",
        data: p,
        type: "POST",
        success: function (text) {
            var o = mini.decode(text);
            if (o.success) {
                e.sender.setData(o.list);
                e.sender.setTotalCount(o.data.totalcount);
            }
            else
                Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
        }
    });
}
//获取wbs属性
function GetWBSProperty(task) {
    var rlt = { unit: "", major: "", device: "", system: "" };
    if (task) {
        var getmu = function (tk) {
            if (tk) {
                if (tk.TaskInfo.phase_id == "1" && rlt.device.length == 0) //装置
                    rlt.device = tk.Name;
                if (tk.TaskInfo.phase_id == "2" && rlt.unit.length == 0) //单元
                    rlt.unit = tk.Name;
                if (tk.TaskInfo.phase_id == "3" && rlt.major.length == 0) //专业
                    rlt.major = tk.Name;
                if (tk.TaskInfo.phase_id == "4" && rlt.system.length == 0) //系统
                    rlt.system = tk.Name;
                if (rlt.major.length > 0 && rlt.unit.length > 0 && rlt.device.length > 0 && rlt.system.length > 0)
                    return;
                tk = gantt.getParentTask(tk);
                getmu(tk);
            }
        }
        getmu(task);
    }
    return rlt;
}
//选择BOM物资
function OnWizardBOM(callback) {
    var task = gantt.getSelected();
    if (!task)
        return;
    if (task.IsWBSTask) {
        return;
    }
    var wbsprop = GetWBSProperty(task);
    var swhere = "1=1";
    if (wbsprop.unit.length > 0) swhere = " and "
    var url = "/Form/Wizard?wizardid=9de4148e-e69b-4d2d-8346-7a05e62f70ec&formid=&btnid=";
    mini.open({
        url: url, title: "选择BOM物资",
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var cwin = this.getIFrameEl().contentWindow;
            if (cwin.Select) {
                cwin.HideMajorFilter();
                cwin.SetDefaultMajor(wbsprop);
                if (cwin.WizardParams) cwin.WizardParams.multi = 1;
                if (cwin.Select.LoadStepFirst) cwin.Select.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                Power.ui.alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            if (callback) {
                callback(data);
            }
        }
    });
}
//选择模型
function OnWizardModel(callback) {
    var url = "/Form/Wizard?wizardid=5210eae0-1b09-4fe7-811a-85f638d176bb&formid=&btnid=";
    mini.open({
        url: url, title: "选择模型",
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var cwin = this.getIFrameEl().contentWindow;
            if (cwin.Select) {
                //cwin.HideMajorFilter();
                //cwin.SetDefaultMajor(wbsprop);
                if (cwin.WizardParams) cwin.WizardParams.multi = 1;
                if (cwin.Select.LoadStepFirst) cwin.Select.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            for (var i = 0; i < data.length; i++) {
                data[i].NodeName = data[i].bimpath;
                data[i].BIMTargetId = data[i].userid;
                data[i].BIMTargetName = data[i].name;
            }
            if (callback) {
                callback(data);
            }
        }
    });
}
//选择模型
function WozardTaskProcWin(callback) {
    var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdPlan/WizardSelectMeasureModel.htm";
    mini.open({
        url: url, title: "选择模型",
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var iframe = this.getIFrameEl();
            var selobj = iframe.contentWindow.Select;
            if (selobj) {
                if (selobj.LoadStepFirst) selobj.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                Power.ui.alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            callback(data);
        }
    });
}
//选择模型
function WizardTaskProcModel(gantt) {
    WozardTaskProcWin(function (data) {
        var task = gantt.getSelected();
        if (task) {
            var grid = mini.get("datagrid_TaskProc");
            for (var i = 0; i < data.length; i++) {
                var row = OnGridAddRow("datagrid_TaskProc", "task_guid", false, gantt);
                grid.updateRow(row, {
                    proc_name: data[i].Step, est_wt: data[i].Weight,
                    est_wt_pct: data[i].TotalWeight, temp_guid: data[i].MasterId, KeyWord: data[i].KeyWord
                });
            }
            SaveGrid("TaskProc");
        }
    });
}
//选择资源
function WizardRSRC(gantt, filter, beforeinsert, afterinsert) {
    var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdPlan/WizardSelectRSRC.htm";
    mini.open({
        url: url, title: "选择资源",
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var iframe = this.getIFrameEl();
            var selobj = iframe.contentWindow.Select;
            if (selobj) {
                selobj.defaultwhere = filter;
                if (selobj.LoadStepFirst) selobj.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                Power.ui.alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            var task = gantt.getSelected();
            if (task) {
                var grid = mini.get("datagrid_TaskRSRC");
                var isfirstadd = grid.data.length == 0;
                if (beforeinsert) {
                    data = beforeinsert(grid, data);
                }
                for (var i = 0; i < data.length; i++) {
                    var row = OnGridAddRow("datagrid_TaskRSRC", "task_guid", false, gantt);
                    var d = data[i].cost_per_qty;
                    var upddata = { rsrc_name: data[i].rsrc_name, rsrc_type: data[i].rsrc_type, rsrc_guid: data[i].guid, cost_per_qty: parseFloat(data[i].cost_per_qty), unit_name: data[i].unit_name };
                    upddata.ismain = (isfirstadd && i == 0) ? "1" : "0";
                    if (upddata.ismain == "0")
                        upddata.ismain = (data[i].ismain && data[i].ismain == 1) ? "1" : "0";
                    grid.updateRow(row, upddata);
                }
                SaveGrid("TaskRSRC", afterinsert);
            }
        }
    });
}
//弹出选择分类码
function winWizardCategoryCode(title, callback) {
    var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdPlan/WizardSelectCategoryCode.htm";
    mini.open({
        url: url, title: (title || "选择分类码"),
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var iframe = this.getIFrameEl();
            var selobj = iframe.contentWindow.Select;
            if (selobj) {
                if (selobj.LoadStepFirst) selobj.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                Power.ui.alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            if (callback)
                callback(data);
        }
    });
}
//选择分类码
function WizardCategoryCode(gantt) {
    winWizardCategoryCode("选择分类码", function (data) {
        var task = gantt.getSelected();
        if (task) {
            var grid = mini.get("datagrid_PLN_TASKACTV");
            var findtype = function (typename) {
                for (var i = 0; i < grid.data.length; i++) {
                    if (grid.data[i].ActvType_guid == typename)
                        return true;
                }
                return false;
            }
            $.each(data, function () {
                //相同分类只能有一个
                if (!findtype(this.actv_code_type_guid)) {
                    var grid = mini.get("datagrid_PLN_TASKACTV");
                    var row = OnGridAddRow("datagrid_PLN_TASKACTV", "task_guid", false, gantt);
                    var upddata = {
                        ActvCode_guid: this.guid, actv_code_id: this.actv_code_id,
                        actv_code_type_id: this.actv_code_type_id, ActvType_guid: this.actv_code_type_guid,
                        task_guid: gantt.getSelected().UID
                    };
                    grid.updateRow(row, upddata);
                }
                else {//如果存在，直接替换掉；
                    var grid = mini.get("datagrid_PLN_TASKACTV");
                    var self = this;
                    var row = grid.findRow(function (row) {
                        if (row.ActvType_guid == self.actv_code_type_guid) {
                            return true;
                        }
                    });
                    var upddata = {
                        ActvCode_guid: this.guid, actv_code_id: this.actv_code_id,
                        actv_code_type_id: this.actv_code_type_id, ActvType_guid: this.actv_code_type_guid,
                        task_guid: gantt.getSelected().UID
                    };
                    grid.updateRow(row, upddata);
                }
            })
            SaveGrid("PLN_TASKACTV", function (o) {
                var taskDetailTab = mini.get("taskDetailTab").getActiveTab();
                if (taskDetailTab.name) {
                    gantt.loadTab(taskDetailTab);
                }
            });
        }
    });
}
//计划预警 选择分类码
function SelectTaskCategoryCode(e) {
    var ctrlself = this;
    winWizardCategoryCode("选择分类码", function (data) {
        ctrlself.setValue(data[0].guid);
        ctrlself.setText(data[0].category_name);

    });
}
//选择支付项
function WizardPSPI(gantt) {
    var url = "/Form/OpenURL?url=/PowerPlat/FormXml/zh-CN/StdCost/WizardWin_PS_CBS_Class.htm";
    mini.open({
        url: url, title: "选择支付项",
        width: "80%",
        height: "80%",
        showMaxButton: true,
        onload: function () {
            var iframe = this.getIFrameEl();
            var selobj = iframe.contentWindow.Select;
            var wiardpar = iframe.contentWindow.WizardParams;
            if (selobj) {
                if (wiardpar) wiardpar.multi = "1";
                if (selobj.LoadStepFirst) selobj.LoadStepFirst();
            }
        },
        ondestroy: function (action) {
            if (action != "ok")
                return;
            var iframe = this.getIFrameEl();
            var data = null;
            if (iframe.contentWindow.Select)
                data = iframe.contentWindow.Select.GetData();
            else {
                if (iframe.contentWindow.GetData)
                    data = iframe.contentWindow.GetData();
            }
            if (!data || data.length == 0) {
                Power.ui.alert("未选择数据");
                return;
            }
            data = mini.clone(data);
            var task = gantt.getSelected();
            if (task) {
                var grid = mini.get("datagrid_PS_PIWBS");
                $.each(data, function () {
                    var row = OnGridAddRow("datagrid_PS_PIWBS", "Task_Guid", false, gantt);
                    var upddata = {
                        PiCode: this.PiCode, PiName: this.PiName, Pi_Guid: this.Id, PiUnit: this.PiUnit,
                        PiMoney: this.PiMoney, PiAmount: this.PiAmount, UnitPrice: this.UnitPrice
                    };
                    grid.updateRow(row, upddata);
                })
                SaveGrid("PS_PIWBS");
            }
        }
    });
}
//初始化作业
function InitEvmSet(tree, p, callback) {
    var taskrows = [];
    var wbsrows = [];
    //计算节点下所有子节点的合计值
    var CalTasksum = function (items) {
        var rlt = { count: 0, duration: 0, pct: 0, bcws_cost: 0 };
        $.each(items, function () {
            //if (!this.IsWBSTask) {
            rlt.count++;
            rlt.duration += (this.Duration || 0);//工期
            rlt.bcws_cost += (this.TaskInfo.bcws_cost || 0);//费用
            //}
        })
        return rlt;
    }
    var fnloop = function (item, suminfo) {
        //权值处理，部分wbs/task 统一处理
        var node = {};
        if (p.est_wt) {
            if (p.est_wt == "等比" && suminfo.count > 0) {
                if (suminfo.lastnode)
                    node.est_wt = 100 - suminfo.pct;
                else {
                    node.est_wt = Math.round(1 / suminfo.count * 10000) / 100;
                    suminfo.pct += node.est_wt;
                }
                node.est_wt_pct = node.est_wt;
            }
            if (p.est_wt == "DUR" && suminfo.duration > 0) {
                if (suminfo.lastnode)
                    node.est_wt = 100 - suminfo.pct;
                else {
                    node.est_wt = Math.round(item.Duration / suminfo.duration * 10000) / 100;
                    suminfo.pct += node.est_wt;
                }
                node.est_wt_pct = node.est_wt;
            }
            if (p.est_wt == "费用" && suminfo.bcws_cost > 0) {
                node.est_wt = item.TaskInfo.bcws_cost;
                if (suminfo.lastnode) {
                    node.est_wt_pct = 100 - suminfo.pct;
                }
                else {
                    node.est_wt_pct = Math.round(node.est_wt / suminfo.bcws_cost * 10000) / 100;
                    suminfo.pct += node.est_wt_pct;
                }
            }
        }
        //task 专有处理
        if (!item.IsWBSTask) {
            if (p.curve_guid && p.curve_guid.length > 0)
                node.curve_guid = p.curve_guid;
            if (p.rsrc_guid && p.rsrc_guid.length > 0) {
                node.rsrc_guid = p.rsrc_guid;
                node.rsrc_name = p.rsrc_name;
            }
            if (p.rec_type && p.rec_type.length > 0)
                node.rec_type = p.rec_type;
            if (p.feedback_pct_type && p.feedback_pct_type.length > 0)
                node.feedback_pct_type = p.feedback_pct_type;
            node._state = "modified";
            node.task_guid = item.UID;
            taskrows.push(node);
        }
        //wbs 专有处理
        if (item.IsWBSTask && p.est_wt && p.est_wt.length > 0) {
            node.wbs_guid = item.UID;
            node._state = "modified";
            wbsrows.push(node);
        }
        //处理子节点
        if (item.children && item.children.length > 0) {
            var sinfo = CalTasksum(item.children);
            $.each(item.children, function (idx) {
                sinfo.lastnode = (idx == sinfo.count - 1);
                fnloop(this, sinfo);
            })
        }
    }
    var suminfo = CalTasksum(tree);

    $.each(tree, function (idx) {
        suminfo.lastnode = (idx == suminfo.count - 1);
        fnloop(this, suminfo);
    })

    if (taskrows.length > 0 || wbsrows.length > 0) {
        var pack = {};
        if (taskrows.length > 0) pack.TASK = { KeyWordType: "BO", data: taskrows };
        if (wbsrows.length > 0) pack.WBS = { KeyWordType: "BO", data: wbsrows };
        SaveServer(pack, function (o) {
            if (callback) callback();
        });
    }
    else {
        if (callback) callback();
    }
}
//页签gird增加一行
function OnGridAddRow(gridid, taskguidfield, autosave, gantt) {
    //var gantt = uiViewConfig.gantt;
    var task = gantt.getSelected();
    if (!task || !task.TaskInfo) return;
    var grid = mini.get(gridid);
    if (!grid) return;
    var row = {};
    row[grid.idField] = CreateGUID();
    row[taskguidfield] = task.UID;
    grid.addRow(row, grid.data.length);
    grid.clearSelect();//先清除再选择新增行
    grid.select(row, false);
    grid.scrollIntoView(row);
    if (autosave) {
        var KeyWord = gridid.replace("datagrid_", "");
        SaveGrid(KeyWord);
    }
    return row;
}
//页签gird删除一行
function OnGridDelete(gridid, keyword) {
    var grid = mini.get(gridid);
    if (!grid) return;
    var rows = grid.getSelected();
    if (rows.length == 0) return;
    Power.ui.confirm("确定是否需要删除?", function (action) {
        if (!action) return;
        grid.removeRow(rows, true);
        SaveGrid(keyword, function () {
            Power.ui.success("删除成功");
        });
    });
}
//保存grid到服务端
function SaveServer(data, successcallback, failsuccess) {
    var jdata = { formId: "", Params: "" };
    jdata.jsonData = mini.encode(data);
    $.ajax({
        url: "/Form/SaveWebForm",
        type: "POST",
        data: jdata,
        success: function (text) {
            var o = mini.decode(text);
            if (o.success == false) {
                if (!failsuccess)
                    Power.ui.alert(o.message);
                else
                    failsuccess(o.message);
                //Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
            }
            else {
                //Power.ui.success(app_global_ResouceId["rightpage_alert_save_success"]);
                if (successcallback) successcallback(o);
            }
        }
    });
}
//保存grid
function SaveGrid(KeyWord, callback) {
    var gridid = "datagrid_" + KeyWord;
    var grid = mini.get(gridid);
    if (grid == null) return;
    var rows = grid.getChanges(null, false); //获取所有修改行及其字段
    if (rows && rows.length > 0) {
        var data = rows.clone();
        var pack = {};
        pack[KeyWord] = { KeyWordType: "BO", data: data };
        SaveServer(pack, function (o) {
            grid.accept();
            if (callback) callback(o, grid);
        });
    }
}
//调用BO 自定义API封装方法
function APIExecFuns(keyword, keywordtype, methodname, params, fncallback) {
    var exec = {};  //对象
    exec.KeyWord = keyword;   //bo的KeyWord
    exec.MethodName = methodname; //方法名称
    if (keywordtype != undefined)
        exec.KeyWordType = keywordtype;
    //如果是数据集的话，要加上 exec.KeyWordType="ViewEntity";
    exec.MethodParams = params;
    var txt = mini.encode(exec); //对象转换成字符串
    $.ajax({
        url: "/API/Exec",
        type: "POST",
        data: { jsonData: txt }, //对象字符串传递给 jsonData变量
        cache: false,
        success: function (text) {
            if (fncallback != undefined)
                fncallback(text);
        }
    });
}
// 使用方法
//var grid=mini.get("");
//var row = gantt.getSelected();
//var par = { proj_guid: gantt.planinfo.proj_guid, plan_guid: gantt.planinfo.proj_plan_guid, task_guid: row.UID };
//APIExecFuns("TaskPred", "BO", "GetPreOrNextTask", par, function (text) {
//    var data = mini.decode(text);
//    data = mini.decode(data.data.value);
//    if (data.list.length > 0) {
//        grid.setData(data.list);
//    }
//});


//关联作业页签
//双击关联作业行
//格式化关联作业类型
var renderTaskPredType = function (e) {
    var value = e.value;

    $.each(comboboxList.pred_type, function () {
        var item = this;
        if (item["id"] == value) {
            value = item["text"];
        }
    });
    return value;
}

function OpenPredOrNextTaskDetail(e) {
    //return false;
    var task_guid = e.record.pred_guid;
    var task = gantt.getSelected();
    var url = '/Form/ValidForm/a5a4fe22-e1db-4da5-a652-b20872402114/edit/' + task_guid + '/';
    mini.open({
        url: url,
        showMaxButton: true,
        width: 900,
        height: 600,
        ondestroy: function (action) {
            if (action != "close")
                return;
            var task = gantt.getSelected();
            if (task) {
                var taskDetailTab = mini.get("taskDetailTab").getActiveTab();
                if (taskDetailTab.name) {
                    gantt.loadTab(taskDetailTab);
                }
            }
        }
    })

}
//加载目标计划对比数据 
function LoadTargetComparePlanData(planguid) {
    //开始设置横道
    $.getJSON("/Plan/GetTasksPlanDate/" + planguid, function (data) {
        if (data.success) {
            gantt.setViewModel("track");
            var dict = {};
            $.each(data.list, function (index, item) {
                if (!dict[item.parent_guid])
                    dict[item.parent_guid] = item;
            });
            var tasklist = gantt.getTaskList();
            for (var i = 0, l = tasklist.length; i < l; i++) {
                var task = tasklist[i];
                if (!task.Start || !task.Finish) continue;
                var baselineDateObject = dict[task.UID];
                if (baselineDateObject) {
                    var baseline0 = {
                        Start: new Date(baselineDateObject.target_start_date),
                        Finish: new Date(baselineDateObject.target_end_date)
                    };
                    task.Baseline = [];
                    task.Baseline.push(baseline0);
                    //
                    //task.offsetstart = new Date(task.Start).DateDiff("y", new Date(baselineDateObject.target_start_date));
                    //task.offsetfinish = new Date(task.Finish).DateDiff("y", new Date(baselineDateObject.target_end_date));
                    //目标计划开始
                    task.target_plan_start_date = baselineDateObject.target_start_date;
                    //
                    //var act_start_date = checkDateIsNull(e.record.TaskInfo.act_start_date);
                    //var start = checkDateIsNull(task.target_plan_start_date);
                    //if (act_start_date && start) {
                    //    task.target_offsetstart = start.DateDiff("d", act_start_date);
                    //}
                    if (checkDateIsNull(task.TaskInfo.act_start_date) && checkDateIsNull(baselineDateObject.target_start_date))
                        //目标偏差(开始)-实际开始时间和期望开始时间差
                        //task.target_offsetstart = StringToDate(task.TaskInfo.act_start_date).DateDiff("d", new Date(baselineDateObject.target_start_date));
                        task.target_offsetstart = StringToDate(task.TaskInfo.act_start_date).DateDiff("d", checkDateIsNull(baselineDateObject.target_start_date));
                    //task.target_plan_end_date = baselineDateObject.target_start_date;
                    //Ronnie修改后
                    //目标计划结束
                    task.target_plan_end_date = baselineDateObject.target_end_date;
                    if (checkDateIsNull(task.TaskInfo.act_end_date) && checkDateIsNull(baselineDateObject.target_end_date))
                        //目标偏差(结束)-实际完成时间和期望完成时间
                        //task.target_offsetfinish = StringToDate(task.TaskInfo.act_end_date).DateDiff("d", new Date(task.target_plan_end_date));
                        task.target_offsetfinish = StringToDate(task.TaskInfo.act_end_date).DateDiff("d", checkDateIsNull(task.target_plan_end_date));
                }
            }
            gantt.refresh();
            //win_planversion_list.hide();

        } else {
            console.log("设置目标横道失败！", data);
        }
    });
}

//发送邮件通知
function SendEmail() {
    var startDate = mini.get("txt_startdate").getValue()||new Date();
    var endDate = mini.get("txt_enddate").getValue() || new Date();
    var rec_type = mini.get("query_rec_type").getValue()|"";
    var _TaskCategoryCode = mini.get("query_TaskCategoryCode").getText()||"";
    var _task_human = mini.get("query_task_human").getValue()||"";
    var url = window.location.href + "&plan_guid=" + gantt.planinfo.proj_plan_guid;
    var tasklist = gantt.getSelecteds();
    var wbshumanList = [];
    var taskhumanList = [];
    $.each(tasklist, function () {
        var item = this;
        if (item.TaskInfo && item.TaskInfo.rsrc_guid && item.TaskInfo.rsrc_guid != "" && item.TaskInfo.rsrc_guid != "00000000-0000-0000-0000-000000000000"
            && $.inArray(item.TaskInfo.rsrc_guid, taskhumanList) == -1) {
            if (!item.IsWBSTask) {
                taskhumanList.push(item.TaskInfo.rsrc_guid);
            }
            //获取当前task的所有父级wbs
            var wbsitem = gantt.getAncestorTasks(item);
            $.each(wbsitem, function () {
                var _item = this;
                if (_item.TaskInfo && item.TaskInfo.rsrc_guid && _item.TaskInfo.rsrc_guid != "" && _item.TaskInfo.rsrc_guid != "00000000-0000-0000-0000-000000000000"
            && $.inArray(_item.TaskInfo.rsrc_guid, wbshumanList) == -1) {
                    wbshumanList.push(_item.TaskInfo.rsrc_guid);
                }
            });

        }
    });
    if ($("#btn_QueryMultiLevel").attr("filter") == "true") {
        var args = [];
        args.push("query=1");
        args.push("startDate=" + startDate);
        args.push("endDate=" + endDate);
        args.push("rec_type=" + rec_type);
        args.push("taskcategorycode=" + rec_type);
        url += "&" + args.join("&");
    }
    //window.location.href = url;
    $.post("/Plan/SendEmailToMonitorNotify", {
        planGuid: current_plan_guid,
        postedArgs: JSON.stringify({
            startDate: mini.formatDate(StringToDate(startDate), "yyyy-MM-dd"),
            endDate: mini.formatDate(StringToDate(endDate), "yyyy-MM-dd"),
            rec_type: rec_type,
            linkUrl: url
        }),
        wbshumanList: wbshumanList.join(","),
        taskhumanList: taskhumanList.join(",")
    }, function (data) {
        data = $.parseJSON(data);
        if (data.success) {
            Power.ui.success("预警邮件发送成功!");
        }
        else {
            var errorInfo = "发送预警邮件失败!";
            if (data.message != "") {
                errorInfo += "<p>(" + data.message + ")</p>";
            }
            Power.ui.alert(errorInfo);
        }
    });
}

//打开附件
function loadWinDocFiles(taskId, title) {
    if (!title)
        title = "附件";
    var url = "/Form/EditForm/ca909b6a-3a75-4931-ab5d-d4b6c82b1d0c/?task_guid=" + taskId + "&proj_guid=" + gantt.planinfo.proj_guid;
    mini.open({
        url: url,
        title: title,
        showMaxButton: true,
        width: "60%", height: "50%"
    })
}