function AppForm() {
    return {
        data: {
            mainFormData: {}, // 主表数据
            optionDiy: {}, // 获取自定义参数
            configLists: [], // 主子表所有的配置
            configListMap: {},// 主子表所有的配置字典
            FileAttachRight: {}, // 附件的权限
            AtHuman: [], // @向导中 所有人员列表
            selectedAtHuman: [], // 获取的@人员
            HumanId: "",
            currentTableItem: {
                KeyWord: "",
                item: {}
            },
            table_state: "modified", // 默认：modified 新增：added
            Actions: [
                { id: "Active", text: "送审", type: "default", code: 1 },
                { id: "Send", text: "同意", type: "default", code: 2 },
                { id: "Return", text: "驳回", type: "default", code: 3 },
                { id: "GetBack", text: "回收", type: "default", code: 4 },
                { id: "Stop", text: "终止", type: "default", code: 5},
                { id: "ShowMonitor", text: "监控", type: "default", code: 6 },
                { id: "ShowHistoryMonitor", text: "历史", type: "default", code: 7 },
                { id: "Delegate", text: "委派", type: "default", code: 8 },
                { id: "Delegateing", text: "委派反馈", type: "default", code: 9 },
                // 这个不是审批流中的操作 但是要加进去
                { id: "saveMainTable", text: "保存", type: "default", code: 10 }
            ]
        },
        getData: function (key) {
            return this.data[key];
        },
        setData: function (key, value) {
            var obj = {}; obj[key] = value;
            this.data = $.extend(this.data, obj);
        },
        // 判断当前表单的创建人和当前登录人是不是同一个人
        sameMan: function(config, row) {
            var that = this;
            var mainFormData = that.getData("mainFormData");

            if (!formconfig) {
                return false;
            }

            if (!config) {
                config = formconfig.config.joindata;
            }

            if (!row) {
                row = mainFormData;
            }

            if (formconfig.FormState == "add") {
                return true;
            }

            if (sessiondata) {
                if (
                    config.reghumidfield &&
                    row &&
                    row[config.reghumidfield] == sessiondata.HumanId
                ) {
                    return true;
                }
            }

            return false;
        },
        // 获取config方法
        getConfig: function (miniid, config) {
            var that = this;
            if (!config) {
                config = formconfig.config.joindata;
            }

            if (config.miniid == miniid) {
                return config;
            }

            var result = null;
            if (!config.children || config.children.length == 0) {
                return result;
            }

            for (var i = 0; i < config.children.length; i++) {
                result = that.getConfig(miniid, config.children[i]);
                if (result) {
                    return result;
                }
            }
            return result;
        },
        //从formconfig中获取所有Config形成List返回
        ConfigToList: function (config) {
            var that = this;
            var optionDiy = that.getData("optionDiy");
            var childConfigDiy = optionDiy.childrenTables;
            var defaultOption = {
                dataparams: {
                    KeyWord: "", //子表的KeyWord
                    select: "", // //需要查询哪些字段,默认空
                    KeyWordType: "BO",  //BO/ViewEntity;默认BO
                    swhere: "",//where条件，默认空
                    size: "0", //每页条数，默认0
                    index: "0", //当前多少页，默认0
                    order: "" //排序，默认空    
                },
                htmlparams: {
                    // 指定容器的id，把对应的html塞进指定的元素中
                    // 一般和子表的KeyWord相同
                    gridid: "",
                    idfield: "Id", //主键,
                    formid: "", //如果需要打开表单，表单的formid
                    title: {
                        value: "", // title显示的字段
                        format: ""
                    },
                    left: {
                        value: "", // 左侧显示的字段
                        format: "" // 如果是下拉框，就设置combobox
                    },
                    center: {
                        value: "",// 中间显示的字段
                        format: ""
                    },
                    right: {
                        value: "", // 右边显示的字段
                        format: ""
                    }
                }
            };

            if (!config) {
                config = Util.deepClone(formconfig.config.joindata);
            }

            var rlt = [];
            var map = {};
            rlt.push(config);
            map[config.KeyWord] = config;

            //子表
            function getChildConfig (config) {
                if (config.children && config.children.length > 0) {
                    config.children.forEach(function (item) {
                        if (childConfigDiy[item.KeyWord]) {
                            item = $.extend(item, Util.deepClone(childConfigDiy[item.KeyWord]));
                        } else {
                            item = $.extend(item, Util.deepClone(defaultOption));
                        }

                        rlt.push(item);
                        map[item.KeyWord] = item;

                        if (item.children && item.children.length > 0) {
                            getChildConfig(item);
                        }
                    });
                }
            }
            getChildConfig(config);

            that.setData("configLists", rlt.concat());
            that.setData("configListMap", map);
        },
        //从formconfig中获取 父级节点的config
        getParentConfig: function (miniid, config) {
            var that = this;
            if (!config) {
                config = formconfig.config.joindata;
            }

            var result = null;
            if (!config.children || config.children.length == 0) {
                return result;
            }

            for (var i = 0; i < config.children.length; i++) {
                var c = config.children[i];
                if (c.miniid == miniid) {
                    return config;
                }
                result = that.getParentConfig(miniid, c);
                if (result) {
                    return result;
                }
            }
            return result;
        },
        //form config 中 filter 转换成 where 条件
        filterToSWhere: function (filter) {
            var result = "";
            if (!filter) {
                return result
            };
            for (var fd in filter) {
                if (typeof (fd) == "function") {
                    continue;
                }
                result = result + " and " + fd + "='" + filter[fd] + "'";
            }
            return result;
        },
        // 主表相关
        // 获取主表数据
        getMainTable: function (callback) {
            var mainConfig = Util.deepClone(formconfig);
            var url = "/Form/FormLoad";
            var params = {
                KeyWord: mainConfig.config.joindata.KeyWord,
                KeyWordType: mainConfig.config.joindata.KeyWordType || "BO",
                keyvalue: mainConfig.KeyValue,
                select: "",
                formstate: mainConfig.FormState
            };

            Util._ajax(url, params, "get", false, function (data) {
                if (callback) {
                    if (typeof data == "string") {
                        data = JSON.parse(data);
                    }
                    if (data.success) {
                        if (data.data.value != "") {
                            callback && callback(JSON.parse(data.data.value));
                        }
                    } else {
                        mui.alert(data.message, 'message');
                    }
                }
            });
        },
        // 对主表赋值
        setMainTable: function (config) {
            var that = this;
            var obj = Util.deepClone(that.getData("mainFormData"));
            var KeyWord = config.KeyWord;
            var form = $("#" + KeyWord);

            if (form.size() == 0) {
                //在主表的form元素上，给定form元素的id 为config中的KeyWord
                //否则，抛出错误，不能正确赋值
                throw new Error("Can not find the form's KeyWord, please set it");
            }

            for (var key in obj) {
                //在主表中input或者textarea元素上的id设置规则是 KeyWord + "_" + key的形式
                //原来的KeyWord + "." + key形式的，废弃
                var mainDom = form.find("#" + KeyWord + "_" + key);
                obj[key] = Util.fieldToView(mainDom, KeyWord, key, obj[key])
                mainDom.val(obj[key]);
            }
        },
        //判断是否当前录入人
        IsRegHuman: function (joindata, row) {
            if (!formconfig || !joindata || !row) {
                return false;
            }

            if (formconfig.FormState == "add") {
                return true;
            }

            if (sessiondata) {
                if (row[joindata.reghumidfield] == sessiondata.HumanId) {
                    return true;
                }
            }

            return false;
        },
        //判断业务流程状态已经批准
        WorkflowApproved: function () {
            var that = this;
            var mainFormData = that.getData("mainFormData");
            //业务不需要走流程
            if (
                typeof (workflowdata) == "undefined" || 
                workflowdata === "" ||
                workflowdata === null
            ) {
                return false;
            }

            //流程结束
            // FlowRecordStatus.Finish 50 = 办结
            if (workflowdata.RecordStatus == 50) {
                return true;
            }

            //状态=50,可能是手工批准的
            if ( formconfig && formconfig.config && formconfig.config.joindata) {
                var joindata = formconfig.config.joindata;

                if (
                    joindata.statusfield && 
                    mainFormData && mainFormData[joindata.statusfield] && 
                    mainFormData[joindata.statusfield] == "50") {
                    return true;
                }
            }

            return false;
        },
        // 过滤操作表
        fliterActions: function (actions) {
            var that = this;
            var result = [];
            // var effected = formconfig.Effected;

            var isView = formconfig.FormState == "view";
            var Approved = that.WorkflowApproved();
            var sameMan = that.sameMan();

            for (var i = 0; i < actions.length; i++) {
                var item = actions[i];
                if (item.id == "saveMainTable") {
                    if (!isView && !Approved && sameMan) {
                        result.push(item);
                    }
                } else {
                    if (workflowdata && workflowdata.CanFlowOperate) {
                        var currentResult = workflowdata.CanFlowOperate;
                        var canFlowOperate = currentResult.CanFlowOperate;

                        if ((canFlowOperate & appFlowsEnums.ECanFlowOperate[item.id]) > 0) {
                            result.push(item);
                        }
                    }
                }
            }

            result = result.sort(function (a, b) {
                return a.code - b.code;
            });

            return result;
        },
        //判断业务走流程的状态下控制只读，true只读
        WorkflowReadOnly: function () {
            var that = this;

            //业务不需要走流程
            if (!workflowdata) {
                return false;
            }

            if (that.WorkflowApproved()) {
                return true;
            }
            //FlowOperate.Active 参阅 FlowStatusSerials.js
            var flowActive = 4096;
            //新流程通过当前审批人和当前登录人来判断
            if (workflowdata.WorkFlowFlag && workflowdata.WorkFlowFlag == "workflows") {
                //如果没有  CanFlowOperate 说明当下此人无SequeID
                if (!workflowdata.CanFlowOperate) {
                    return false;
                }

                if (workflowdata.CanFlowOperate.UserType != 1 && (workflowdata.CanFlowOperate.UserType & 4) == 0) {
                    return true;
                } else {
                    return false;
                }
            }
            if ((workflowdata.CanFlowOperate & flowActive) != 0) {
                //处理当前业务上的送审按钮权限
                //只有编辑状态下显示，且只有录入人=当前用户才显示
                //如果已经执行生效操作，则 送审 按钮也不应该显示
                return false;
            }
            //走流程过程中，不是当前节点用户
            var flowUpdate = 4;   //FlowOperate.Update 参阅 PC FlowStatusSerials.js
            if ((workflowdata.CanFlowOperate & flowUpdate) == 0) {
                return true;
            } else {
                return false;
            }
        },
        flowSaveValid: function (params) {
            var that = this;
            var joindata = formconfig.config.joindata
            var keyword = joindata.KeyWord;
            var mainFormData = that.getData("mainFormData");
            
            // 获取form里面的数据
            // 给主表赋值
            $("#" + keyword).find("input,select,textarea").each(function () {
                var $this = $(this);
                var key = $this.attr("name");
                var value = $this.val();

                value = Util.fieldToSave($this, keyword, key, value);
                if (!$this.attr("readonly") || !$this.attr("disabled")) {
                    if (mainFormData[key] != value) {
                        mainFormData[key] = value;
                    }
                }
            });

            // 如果没有 params参数
            if (!params) {
                params = {};
            }

            if (formconfig.FormState == "add") {
                mainFormData["_state"] = "added";
            } else if (formconfig.FormState == "edit") {
                mainFormData["_state"] = "modified";
            } else {
                mainFormData["_state"] = "view";
            }

            var pack = {};
            pack[keyword] = {
                KeyWordType: joindata.KeyWordType || "BO",
                data: []
            };

            pack[keyword].data.push(mainFormData);

            //检查是否有修改，减少服务器交互
            var jdata = {
                formId: FormId,
                jsonData: JSON.stringify(pack)
            };

            //如果是审批处理，允许没有提交数据
            if (
                workflowdata &&
                formconfig &&
                !that.WorkflowReadOnly()) {

                if (!params) {
                    params = {};
                }

                params.IsWorkFlowHuman = "1";
            }

            //如果是新增状态数据，且是当前录入人
            if (joindata.statusfield &&
                mainFormData[joindata.statusfield] == "0" &&
                that.IsRegHuman(joindata, mainFormData)
            ) {
                params.IsRegHuman = "1";
            }

            if (!params) {
                jdata.Params = "";
            } else {
                jdata.Params = JSON.stringify(params);
            }

            return jdata;
        },
        // 保存主表信息
        saveMainTable: function (params, callback) {
            var that = this;
            var keyword = formconfig.config.joindata.KeyWord;
            var hasError = false;
            var optionDiy = that.getData("optionDiy");
            
            // 校验form里面的数据
            $("#" + keyword).find("input,select,textarea").each(function () {
                var $this = $(this);
                var required = $this.prop("required");
                var value = $this.val();
                $this.parent().removeClass("mui-required");
                if (required) {
                    if (!value || value == "") {
                        $this.parent().addClass("mui-required");
                        hasError = true;
                    }
                }
            });

            if (hasError) {
                mui.alert("请完善主表必填信息");
                return false;
            }

            var jdata = that.flowSaveValid(params);
            var url = "/Form/SaveWebForm";

            if (optionDiy.mainFormSaveBefore) {
                jdata = optionDiy.mainFormSaveBefore(jdata);
            }

            jdata.Params = Util.Base64Encode(jdata.Params);
            // wsl 追加，如果表单参数中有  FromSource ,并且值等于 TransFlow ，
            // 说明是从事务流触发的表单新增，则URL重新定向
            if (params && params.ControlPath != undefined) {
                url = "/" + params.ControlPath + "/SaveWebForm";
            }

            Util._ajax(url, jdata, "POST", false, function (data) {
                var getData = JSON.parse(data);
                if (getData.success) {
                    mui.toast("保存成功");
                    callback && callback();
                    if (optionDiy.mainFormSaveAfter) {
                        optionDiy.mainFormSaveAfter(getData);
                    }
                } else {
                    mui.alert("保存失败 " + getData.message);
                }
            });
        },
        //如果绑定了工作流体系，则设定工作流按钮 在操作表中 
        setFlowResult: function () {
            var that = this;
            var Actions = that.getData("Actions").concat();
            var fliterAction = that.fliterActions(Actions);
            var optionDiy = that.getData("optionDiy");

            if (optionDiy.btnExtend && optionDiy.btnExtend.length > 0) {
                fliterAction = optionDiy.btnExtend.concat(fliterAction)
            }

            var html = '';
            fliterAction.forEach(function (item, index) {
                var id = item.id;
                if (id != "saveMainTable") {
                    id = "workFlow_action_" + item.id;
                }
                
                html += '<li class="mui-table-view-cell">' +
                    '<a id="' + id + '" href="javascript:void(0)">' + item.text + '</a>' +
                    '</li>';
            });
            $("#ActionSheetList").html(html);
        
            // 保存主表信息
            $("#saveMainTable").on("tap", function (e) {
                e.preventDefault();

                that.saveMainTable(null, function () {
                    var actionLink = "";
                    var joindata = formconfig.config.joindata;
                    var mainFormData = that.getData("mainFormData");
                    var keyValue = mainFormData[joindata.keyfield];
                    
                    if (formconfig.FormState == "add") {
                        actionLink = "edit";
                        window.location.href = "/Form/ValidForm/"
                        + FormId + "/" + actionLink + "/" + keyValue + "/";
                    } else {
                        formconfig.KeyValue = mainFormData[joindata.keyfield];
                        that.load();
                    }
                });
                that.toggleActionSheet();
            });

            //自定义按钮事件
            optionDiy.btnExtend.forEach(function (item, index) {
                $("#workFlow_action_" + item.id).on("tap", function (e) {
                    that.toggleActionSheet();
                    item.callback && item.callback(e);
                });
            });

            // 绑定流程按钮事件
            that.workflowEvents();
        },
        // 获取送审的参数
        getFlowParameter: function () {
            var that = this;
            var mainFormData = that.getData("mainFormData");
            var joindata = formconfig.config.joindata;
            var data = {
                FormId: formconfig.FormId,
                KeyValue: formconfig.KeyValue,
                KeyWord: formconfig.config.joindata.KeyWord,
                WorkInfoID: workflowdata.CanFlowOperate.WorkInfoID,
                SequeID: workflowdata.CanFlowOperate.SequeID,
                FormState: FormState
            };

            if (workflowdata) {
                data.WorkInfoID = workflowdata.CanFlowOperate ? workflowdata.CanFlowOperate.WorkInfoID : "";
            }

            if (!data.KeyValue) {
                data.KeyValue = mainFormData[joindata.keyfield];
            }

            if (!data.WorkInfoID) {
                data.WorkInfoID = "";
                if (
                    workflowdata &&
                    workflowdata.CanFlowOperate &&
                    workflowdata.CanFlowOperate.CanFlowList && 
                    workflowdata.CanFlowOperate.CanFlowList.ShowMonitor
                ) {
                    data.WorkInfoID = workflowdata.CanFlowOperate.CanFlowList.ShowMonitor.WorkInfoID;
                }
            }
            return data;
        },
        // 检验参数
        checkFlowParams: function (params, flowOperate, callback) {
            var that = this;
            var data = that.flowSaveValid(params);
            var result = JSON.parse(data.jsonData);

            if (!data.params) {
                data.params = {};
            }

            //设置以流程参与人模式触发保存,外部规定
            data.params.IsWorkFlowHuman = 1;

            var formData = {};
            formData.formId = formconfig.FormId;
            formData.json = result;
            formData.params = Util.Base64Encode(JSON.stringify(data.params));

            var msg = {};
            msg.MessageCode = "Power.Controls.PMS.SaveWebForm";
            msg.data = formData;
            msg.data.FlowOperate = flowOperate;

            var postInfo = {};
            //开启事务
            postInfo.OpenTrans = "true";
            //要保存的数据包 
            postInfo[flowOperate] = msg;

            callback && callback(postInfo);
        },
        // 走流程 更新数据
        saveFormWorkFlow: function (postInfo, callback) {
            var params = {
                json: JSON.stringify(postInfo)
            };

            Util._APIAjax(params, function (data) {
                callback && callback(data);
            });
        },
        // 流程按钮事件
        workflowEvents: function () {
            var that = this;
            var flowAction = new WorkFlowAction();

            // 送审
            $("#workFlow_action_Active").on("tap", function () {
                var data = that.getFlowParameter();
                that.checkFlowParams(null, "Update", function (postInfo) {
                    that.saveFormWorkFlow(postInfo, function (res) {
                        var getData = JSON.parse(res);
                        if (getData.success) {
                            mui.toast("保存成功");
                            flowAction.Active({
                                FormId: data.FormId,
                                KeyWord: data.KeyWord,
                                KeyValue: data.KeyValue,
                                flowOperate: 'Active'
                            });
                        } else {
                            mui.alert(getData.message);
                        }
                    });
                });

                that.toggleActionSheet();
            });

            // 同意
            $("#workFlow_action_Send").on("tap", function (e) {
                e.preventDefault();
                // 收集跨页面传递的参数
                var data = that.getFlowParameter();
                that.checkFlowParams(null, "Update", function (postInfo) {
                    that.saveFormWorkFlow(postInfo, function (res) {
                        var getData = JSON.parse(res);
                        if (getData.success) {
                            mui.toast("保存成功");
                            flowAction.Agree({
                                WorkInfoID: data.WorkInfoID,
                                FormId: data.FormId,
                                KeyWord: data.KeyWord,
                                KeyValue: data.KeyValue,
                                SequeID: data.SequeID
                            });
                        } else {
                            mui.alert(getData.message);
                        }
                    });
                });
                that.toggleActionSheet();
            });

            // 驳回
            $("#workFlow_action_Return").on("tap", function () {
                var data = that.getFlowParameter();
                that.checkFlowParams(null, "Update", function (postInfo) {
                    that.saveFormWorkFlow(postInfo, function (res) {
                        var getData = JSON.parse(res);
                        if (getData.success) {
                            mui.toast("保存成功");
                            flowAction.Return({
                                FormId: data.FormId,
                                KeyValue: data.KeyValue,
                                KeyWord: data.KeyWord,
                                SequeID: data.SequeID
                            });
                        } else {
                            mui.alert(getData.message);
                        }
                    });
                });

                that.toggleActionSheet();
            });

            // 委派
            $("#workFlow_action_Delegate").on("tap", function () {
                var data = that.getFlowParameter();
                that.checkFlowParams(null, "Update", function (postInfo) {
                    that.saveFormWorkFlow(postInfo, function (res) {
                        var getData = JSON.parse(res);
                        if (getData.success) {
                            mui.toast("保存成功");
                            flowAction.Delegate({
                                FormId: data.FormId,
                                KeyWord: data.KeyWord,
                                KeyValue: data.KeyValue,
                                SequeID: data.SequeID,
                                FormState: data.FormState
                            });
                        } else {
                            mui.alert(getData.message);
                        }
                    });
                });
                that.toggleActionSheet();
            });
            // 委派处理
            $("#workFlow_action_Delegateing").on("tap", function () {
                var data = that.getFlowParameter();
                that.checkFlowParams(null, "Update", function (postInfo) {
                    that.saveFormWorkFlow(postInfo, function (res) {
                        var getData = JSON.parse(res);
                        if (getData.success) {
                            mui.toast("保存成功");
                            flowAction.Delegating({
                                FormId: data.FormId,
                                KeyWord: data.KeyWord,
                                KeyValue: data.KeyValue,
                                SequeID: data.SequeID,
                                FormState: data.FormState
                            });
                        } else {
                            mui.alert(getData.message);
                        }
                    });
                });

                that.toggleActionSheet();
            });

            // 查看流程监控
            $("#workFlow_action_ShowMonitor").on("tap", function () {
                var data = that.getFlowParameter();
                that.toggleActionSheet();
                flowAction.Monitor({
                    WorkInfoID: data.WorkInfoID,
                    flowOperate: "ShowMonitor"
                });
            });

            // 监控历史
            $("#workFlow_action_ShowHistoryMonitor").on("tap", function() {
                that.toggleActionSheet();
                flowAction.MonitorHistory({});
            });

            // 回收
            $("#workFlow_action_GetBack").on("tap", function () {
                var data = that.getFlowParameter();
                flowAction.GetBack({
                    FormId: data.FormId,
                    FormState: data.FormState,
                    KeyValue: data.KeyValue,
                    KeyWord: data.KeyWord,
                    SequeID: data.SequeID
                });
                that.toggleActionSheet();
            });

            // 终止
            $("#workFlow_action_Stop").on("tap", function () {
                var data = that.getFlowParameter();
                that.checkFlowParams(null, "Update", function (postInfo) {
                    that.saveFormWorkFlow(postInfo, function (res) {
                        var getData = JSON.parse(res);
                        if (getData.success) {
                            mui.toast("保存成功");
                            flowAction.Stop({
                                FormId: data.FormId,
                                KeyWord: data.KeyWord,
                                KeyValue: data.KeyValue,
                                SequeID: data.SequeID
                            });
                        } else {
                            mui.alert(getData.message);
                        }
                    });
                });

                that.toggleActionSheet();
            });
        },
        // 子表相关
        // 循环加载指定的所有子表
        loadChildrenTable: function (optionDiy, type, callback) {
            if (typeof optionDiy == "object") {
                if (optionDiy.childrenTables && type == "all") {
                    for (var key in optionDiy.childrenTables) {
                        if (callback) {
                            callback(key);
                        }
                    }
                }
            } else if (typeof optionDiy == "string") {
                if (type == "single") {
                    callback(optionDiy);
                }
            }
        },
        //GridPageLoad加载数据
        gridPageLoad: function (params, callback) {
            if (params) {
                var p = $.extend({}, params);
            }

            var url = p.url || "/Form/GridPageLoad";
            p.KeyWordType = p.KeyWordType || "BO";
            p.select = p.select || "";
            p.sort = p.sort || "";
            p.index = p.index || "0";
            p.size = p.size || "0";
            p.swhere = p.swhere || "";
            var _async = typeof (p.async) == "undefined" ? true : p.async;
            delete p.async;

            if (p.swhere) {
                var tmp = {};
                if (p.extparams) {
                    var str = Util.Base64Decode(p.extparams);
                    tmp = JSON.parse(str);
                }
                tmp.encodeswhere = "r4";
                p.extparams = Util.Base64Encode(JSON.stringify(tmp));
                p.swhere = Util.Base64Swhere(p.swhere);
            }

            Util._ajax(url, p, "post", false, function (data) {
                var getData = JSON.parse(data);
                if (callback) {
                    callback(getData);
                }
            });
        },
        // 获取当前子表的当前信息数据
        getCurrentTableList: function (Id, thisTableConfig) {
            var data = thisTableConfig.tableData;
            var idfield = thisTableConfig.htmlparams.idfield || "Id";
            var arr = data.filter(function (item) {
                if (Id == item[idfield]) {
                    return item;
                }
            });

            return arr[0];
        },
        // 打开子表的一条数据
        openChildForm: function () {
            var that = this;
            var currentItem = that.getData("currentTableItem");
            var Row = currentItem["item"];
            var KeyWord = currentItem["KeyWord"];
            var Form = $("#" + KeyWord + "_Form");
            var htmlparams = that.getData("configListMap")[KeyWord][htmlparams];

            for (var key in Row) {
                var childDom = $("#" + KeyWord + "_" + key);
                childDom.parent().removeClass("mui-required")
                var value = Util.fieldToView(childDom, KeyWord, key, Row[key]);

                childDom.val(value);
            }

            Form.addClass("move-animation-back").removeClass("move-animation-start");
        },
        // 渲染子表列表数据
        tableCellTemp: function (data, htmlparams) {
            var that = this;
            var html = '';

            data.forEach(function (item) {
                var title = Util.getTableTypeResult(htmlparams, item, "title");
                var left = Util.getTableTypeResult(htmlparams, item, "left");
                var right = Util.getTableTypeResult(htmlparams, item, "right");
                var center = Util.getTableTypeResult(htmlparams, item, "center");

                html += '<li data-title="'+ $(title).text() +'" data-id="'+ item[htmlparams.idfield] +'" class="mui-table-view-cell">' +
                    '<div class="mui-slider-handle">' +
                    '<div class="mui-win-form text-row">' +
                    '<div class="hide mui-media-object mui-pull-left mui-checkbox">' +
                    '<input data-id="'+ item[htmlparams.idfield] +'" class="" name="checkbox" type="checkbox">' +
                    '</div>' +
                    '<div class="mui-media-body">' +
                    '<p class="mui-ellipsis list-title">'+ title +'</p>' +
                    '<div class="list-units">'+ left + center + right +'</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</li>';
            });

            var tableGrid = $("#" + htmlparams.gridid);
            tableGrid.html(html);

            // 子表列表信息的tap事件
            tableGrid.find(".mui-table-view-cell").on("tap", function (e) {
                e.preventDefault();
                e.stopPropagation();

                var $this = $(this);
                var Id = $this.attr("data-id");
                var thisTableConfig = that.getData("configListMap")[htmlparams.gridid];
                var currentItem = that.getCurrentTableList(Id, thisTableConfig);

                if (($this.find(".mui-checkbox").hasClass("hide"))) {
                    that.setData("currentTableItem", {
                        KeyWord: thisTableConfig.dataparams.KeyWord,
                        item: currentItem || {}
                    });
                    that.setData("table_state", "modified");
                    that.openChildForm();
                } else {
                    var checkedBox = $this.find("input[type=checkbox]");
                    var checked = checkedBox.prop("checked");

                    checkedBox.prop("checked", !checked);
                }
            });

            // 点击子表列表中的checkbox的时候 触发的事件
            tableGrid.find(".mui-table-view-cell input[type=checkbox]").on("tap", function (e) {
                e.preventDefault();
                e.stopPropagation();
                
                var $this = $(this);
                var row = $this.closest(".mui-table-view-cell");

                row.trigger("tap");
            });
        },
        // 获取子表数据
        getChildrenTable: function (keyword) {
            var that = this;
            var configListMap = Util.deepClone(that.getData("configListMap"));
            var thisTableConfig = configListMap[keyword];
            var mainFormData = that.getData("mainFormData");

            if (!thisTableConfig) {
                mui.alert("不能获取子表" + keyword + "的配置信息，请检查配置信息...");
                return false;
            }

            var dataparams = Util.deepClone(thisTableConfig.dataparams);
            var htmlparams = Util.deepClone(thisTableConfig.htmlparams);
            if (!dataparams) {
                mui.alert("页面中没有配置子表" + keyword + "dataparams的信息");
                return false;
            }

            if (!htmlparams) {
                mui.alert("页面中没有配置子表" + keyword + "htmlparams的信息");
                return false;
            }

            var swhere = "";
            if (formconfig.KeyValue == "") {
                swhere = " 1=0 ";
            } else {
                var pconfig = that.getParentConfig(keyword, null);
                swhere = " 1=1 " + that.filterToSWhere(thisTableConfig.filter);

                if (thisTableConfig.fields && pconfig) {
                    for (var fd in thisTableConfig.fields) {
                        var pfd = thisTableConfig.fields[fd];
                        //是常量值
                        if (typeof (mainFormData[pfd]) == undefined) {
                            swhere = swhere + " and " + fd + "='" + pdf + "'";
                        } else {
                            if (mainFormData[pfd]) {
                                swhere = swhere + " and " + fd + "='" + mainFormData[pfd] + "'";
                            } else {
                                swhere = swhere + " and 1=0";
                            }
                        }
                    }
                }
            }

            if (dataparams && dataparams.swhere) {
                swhere += dataparams.swhere
            }

            dataparams.swhere = swhere;
            if (thisTableConfig.loadBefore) {
                dataparams = thisTableConfig.loadBefore(dataparams);
            }

            that.gridPageLoad(dataparams, function (data) {
                var getData = [];
                if (data.success) {
                    if (data.data.value) {
                        getData = JSON.parse(data.data.value);
                    }

                    if (thisTableConfig.render && typeof thisTableConfig.render == "function") {
                        thisTableConfig.render(getData, htmlparams);
                    } else {
                        if (thisTableConfig.loadAfter) {
                            getData = thisTableConfig.loadAfter(getData);
                        }

                        thisTableConfig["tableData"] = getData;
						var configListMapList = Util.deepClone(that.getData("configListMap"));
                        configListMapList[keyword] = Util.deepClone(thisTableConfig);
                        that.setData("configListMap", configListMapList);

                        that.tableCellTemp(getData, htmlparams);
                    }
                } else {
                    mui.alert(data.message);
                    return false;
                }
            });
        },
        // 保存子表数据
        SaveChildrenTable: function (KeyWord, callback) {
            var that = this;
            var can_next = true;
            var currentTableConfig = that.getData("configListMap")[KeyWord];
            var currentTableItemData = that.getData("currentTableItem");
            var currentForm = $("#" + KeyWord + "_Form");
            var joindata = formconfig.config.joindata;
            var mainFormData = that.getData("mainFormData");
            var table_state = that.getData("table_state");
            var data = {};

            if (currentTableItemData.KeyWord == KeyWord) {
                data = $.extend({}, currentTableItemData.item);
            }

            if (!KeyWord) {
                mui.alert("KeyWord 参数为" + KeyWord);
                return false;
            }

            if (!currentTableConfig) {
                mui.alert("当前子表配置获取失败！");
                return false;
            }

            if (currentForm.length == 0) {
                mui.alert("当前子表列表容器没有找到，请检查子表页面DOM配置");
                return false;
            }

            // 获取dom输入的数据 并 校验
            currentForm.find("input,textarea").each(function () {
                var $this = $(this);
                var key = $this.attr("name");
                var value = $this.val();
                var required = $this.prop("required");

                if (required && value == "") {
                    $this.parent().addClass("mui-required");
                    can_next = false;
                } else {
                    data[key] = Util.fieldToSave($this, KeyWord, key, value);
                    $this.parent().removeClass("mui-required");
                }
            });

            if (!can_next) {
                mui.alert("必填信息不完整，请完善信息");
                return false;
            }

            // 判断数据状态是修改还是新增
            data["_state"] = table_state;
            if (table_state == "added") {
                data[currentTableConfig.keyfield] = Util.newGuid();

                var parent_config = that.getParentConfig(KeyWord);
                if (parent_config) {
                    if (parent_config.KeyWord == joindata.KeyWord) {
                        for (var fd in currentTableConfig.fields) {
                            if (typeof fd == "function") {
                                continue;
                            }
        
                            data[fd] = mainFormData[currentTableConfig.fields[fd]];
                        }
                    }
                }
            }

            var pack = {};
            pack[KeyWord] = {
                KeyWordType: currentTableConfig.KeyWordType || "BO",
                data: [data]
            };

            Util._loading();
            $.ajax({
                url: "/Form/SaveWebForm",
                type: "POST",
                data: {
                    formId: FormId || formconfig.FormId,
                    encode: "r4",
                    jsonData: Util.Base64Swhere(JSON.stringify(pack))
                },
                dataType: "json",
                success: function (res) {
                    Util._closeLoading();

                    if (!res.success) {
                        mui.alert(res.message);
                        return false;
                    }

                    that.loadChildrenTable(KeyWord, "single", function (table) {
                        that.getChildrenTable(table);

                        currentForm.addClass("move-animation-start").removeClass("move-animation-back");
                        currentForm.find("input,textarea").val("");

                        callback && callback();
                    });
                },
                error: function (a) {
                    Util._closeLoading();
                    mui.alert(a + " 网络连接失败，请检查网络！");
                    return false;
                }
            });
        },
        // 删除子表数据
        deleteTableLists: function (KeyWord, callback) {
            var that = this;

            if (!KeyWord) {
                mui.alert("KeyWord传参失败");
                return false;
            }
            var currentTableConfig = that.getData("configListMap")[KeyWord];
            var rows = [];
            var lis = $("#" + KeyWord).find("input:checked").closest("li");

            if (lis.size() == 0) {
                mui.alert("请选择数据!");
                return false;
            }

            lis.each(function () {
                var $this = $(this);
                var id = $this.attr("data-id");

                var obj = {
                    _state: "removed"
                };

                obj[currentTableConfig.keyfield] = id;
                rows.push(obj);
            });

            var pack = {};
            pack[KeyWord] = {
                "KeyWordType": currentTableConfig.KeyWordType || "BO",
                data: rows
            };

            Util._loading("正在删除");
            $.ajax({
                url: "/Form/SaveWebForm",
                type: "POST",
                data: {
                    formId: "",
                    encode: "r4",
                    jsonData: Util.Base64Swhere(JSON.stringify(pack)),
                    Params: Util.Base64Encode("")
                },
                dataType: "json",
                success: function (res) {
                    Util._closeLoading();
                    if (res.success) {
                        lis.remove();
                        callback && callback();
                    } else {
                        mui.alert(res.message);
                    }
                },
                error: function (e) {
                    Util._closeLoading();
                    mui.alert(e);
                }
            });
        },

        // 附件相关
        // 渲染附件数据
        renderAttachFile: function (data) {
            var that = this;
            var dataMap = {
                picFiles: [],
                mediaFiles: [],
                docFiles: [],
                otherFiles: []
            };
            var attachNum = 0;
            var sameMan = that.sameMan();

            data.map(function (item, index) {
                var fileAvatar = Util._getAvatar(item.FileExt, item.Id);

                dataMap[fileAvatar.type].push(item);
                item.avatar = fileAvatar.url;
                item.fileType = fileAvatar.type;
                return item;
            });

            for (var key in dataMap) {
                var attachList = dataMap[key];
                var fileItem, html = '';

                //附件个数
                attachNum += attachList.length;

                if (attachList.length == 0) {
                    $("#" + key).prev().addClass("hide");
                } else {
                    $("#" + key).prev().removeClass("hide");
                }

                for (var i = 0; i < attachList.length; i++) {
                    fileItem = attachList[i];
                    if (!fileItem.FileExt) {
                        fileItem.FileExt = "";
                    }
                    var delete_html = '<span class="delete mui-icon mui-icon-closeempty"></span>';
                    if (formconfig.FormState == "view" && !sameMan) {
                        delete_html = ''
                    }

                    html += '<li data-id="' + fileItem.Id + '" data-fileext="' + fileItem.FileExt + '" data-name="' + fileItem.Name + '" data-type="' + fileItem.fileType + '" class="mui-table-view-cell mui-media bottom-line">' +
                        '<a href="javascript:;">' +
                        '<img class="mui-media-object mui-pull-left" src="' + fileItem.avatar + '">' +
                        '<div class="mui-media-body">' +
                        '<span>' + Util._formatDate(fileItem.UpdDate, "yyyy-MM-dd") + '</span>' +
                        '<p class="mui-ellipsis">'+ fileItem.Name + fileItem.FileExt +'</p>' +
                        '</div>' +
                        delete_html +
                        '</a>' +
                        '</li>';
                }

                $("#" + key).html(html);

                // 附件的删除事件
                $("#" + key).find(".delete").on("tap", function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    var $this = $(this);
                    var row = $this.closest(".mui-table-view-cell.mui-media");
                    var content = $this.closest(".mui-table-view");
                    var id = row.attr("data-id");
                    var FileAttachRight = that.getData("FileAttachRight");

                    mui.confirm('确认删除此文件？', '注意', ["否", "是"], function (e) {
                        if (e.index == 1) {
                            if ((FileAttachRight.bDocDel + "") == "1") {
                                that.deleteAttach(id, function (data) {
                                    if (data.success) {
                                        row.remove();
                                        mui.toast('删除成功');

                                        var lastAttachNum = content.find(".mui-table-view-cell.mui-media").size();
                                        if (lastAttachNum == 0) {
                                            content.prev().hide();
                                        }
                                    } else {
                                        mui.alert('删除失败');
                                    }
                                });
                            } else {
                                mui.alert("你没有删除权限");
                            }
                        }
                    });
                });

                // 点击查看附件
                $("#" + key).find(".mui-table-view-cell").on("tap", function (e) {
                    e.preventDefault();
                    e.stopPropagation();

                    var $this = $(this),
                        id = $this.attr("data-id"),
                        fileType = $this.attr("data-type"),
                        title = $this.attr("data-name"),
                        fileext = $this.attr("data-fileext");
                    var FileAttachRight = that.getData("FileAttachRight");

                    if ((FileAttachRight.bDocView + "") != "1") {
                        if (fileType == "picFiles") {
                            mui.alert("你没有权限查看");
                        } else {
                            mui.alert("你没有权限下载");
                        }
                        return false;
                    }

                    if (fileType == "otherFiles") {
                        var drawings = [".dwg", ".dxf"];
                        if (drawings.indexOf(fileext) >= 0) {
                            appPhysical.OpenDrawingView(id, title + fileext, fileext);
                        } else {
                            mui.alert("文件不能在移动端查看，请移步PC端");
                        }
                    } else {
                        appPhysical.OpenView(id, title + fileext, fileext);
                    }
                });
            }
        },
        // 获取附件数据
        getDocFiles: function (callback) {
            var that = this;
            var url = "/Form/GetDocFiles";
            var params = {
                BOKeyWord: formconfig.config.joindata.KeyWord,
                BOKeyValue: formconfig.KeyValue,
                select: "",
                swhere: "",
                sort: "",
                index: 0,
                size: 0
            };
            
            var optionDiy = that.getData("optionDiy");
            var AttachFileConfigDiy = optionDiy.AttachFile;
            if (AttachFileConfigDiy && AttachFileConfigDiy.loadBefore) {
                params = AttachFileConfigDiy.loadBefore(params);
            }
            
            Util._ajax(url, params, "get", true, function (data) {
                var getFileData = JSON.parse(data);
                var getData = [];
                if (getFileData.success) {
                    var value = getFileData.data.value;
                    if (value) {
                        getData = JSON.parse(value);
                    }

                    var right = Util.deepClone(getFileData.data.right);
                    that.setData("FileAttachRight", right);

                    if (AttachFileConfigDiy && AttachFileConfigDiy.loadAfter) {
                        getData = AttachFileConfigDiy.loadAfter(getData);
                    }

                    callback && callback(getData);
                } else {
                    mui.alert(getFileData.message);
                    return false;
                }
            });
        },
        // 删除附件
        deleteAttach: function (id, callback) {
            var url = '/PowerPlat/Control/File.ashx?_type=default&action=delete&_fileid=' + id;
            $.getJSON(url, function (data) {
                if (callback) {
                    callback(data);
                }
            });
        },
        // 附件上传事件
        upLoadAttachEvents: function (conf) {
            var that = this;
            //获取经纬度2
            window.getLocation = function (data) {
                mui.alert(data);
            };

            $("#getLocation").on("tab",function(){
                appPhysical.getCurrentLocation();
            });


            window.getQRCodeMessage = function (data) {
                mui.alert(data);
            };

            $("#openQRCode").on("tap", function () {
                appPhysical.openQRCode();
            });

            // 打开图库/相册
            $("#Gallery").on("tap", function (e) {
                e.preventDefault();
                var FileAttachRight = that.getData("FileAttachRight");
                if ((FileAttachRight.bDocUp + "") == "1") {
                    appPhysical.OpenGallery(conf);
                } else {
                    mui.alert("你没有权限上传附件");
                }
            });
            // 打开相机
            $("#Camera").on("tap", function (e) {
                e.preventDefault();
                var FileAttachRight = that.getData("FileAttachRight");
                if ((FileAttachRight.bDocUp + "") == "1") {
                    appPhysical.OpenCamera(conf);
                } else {
                    mui.alert("你没有权限上传附件");
                }
            });

            // 打开录像
            $("#RecordVideos").on("tap", function (e) {
                e.preventDefault();
                var FileAttachRight = that.getData("FileAttachRight");
                if ((FileAttachRight.bDocUp + "") == "1") {
                    appPhysical.RecordVideos(conf);
                } else {
                    mui.alert("你没有权限上传附件");
                }
            });
            // 上传视频
            $("#Videos").on("tap", function (e) {
                e.preventDefault();
                var FileAttachRight = that.getData("FileAttachRight");
                if ((FileAttachRight.bDocUp + "") == "1") {
                    appPhysical.OpenVideos(conf);
                } else {
                    mui.alert("你没有权限上传附件");
                }
            });

            // 打开音频
            $("#Audio").on("tap", function (e) {
                e.preventDefault();
                var FileAttachRight = that.getData("FileAttachRight");
                if ((FileAttachRight.bDocUp + "") == "1") {
                    appPhysical.OpenAudio(conf);
                } else {
                    mui.alert("你没有权限上传附件");
                }
            });
            // 打开上传文件
            $("#UploadFileAll").on("tap", function (e) {
                e.preventDefault();
                var FileAttachRight = that.getData("FileAttachRight");
                if ((FileAttachRight.bDocUp + "") == "1") {
                    appPhysical.UploadFile(conf);
                } else {
                    mui.alert("你没有权限上传附件");
                }
            });
        },

        // 报表相关
        // 获取报表数据
        getReport: function (callback) {
            var formid = formconfig.FormId;
            var params = {
                FormId: formid
            };
            Util._APIAjax(params, function (data) {
                var getData = JSON.parse(data);
                if (!!getData.data.value) {
                    if (callback) {
                        callback(JSON.parse(getData.data.value));
                    }
                }
            }, "/Form/GetReport");
        },
        // 报表数据处理
        checkReportData: function (data) {
            var that = this;
            var arr = [];
            var mainFormData = that.getData("mainFormData");
            var keyvalue = mainFormData[formconfig.config.joindata.keyfield];
            var keyword = formconfig.config.joindata.KeyWord;

            data.forEach(function (item, index) {
                var id = item.Id;
                var url = "/PowerPlat/FormXml/ReportView.aspx?rid=" + id +
                    "&KeyWord=" + keyword;
                var formKeys;

                if (item.FormKey) {
                    formKeys = item.FormKey.split(',');
                    formKeys.forEach(function (keyItem, keyIndex) {
                        //[@Id]\[@KeyWord.xx]
                        var pars = keyItem.split(".");
                        if (pars.length == 2) {
                            var this_config = configsMap[pars[0]];
                            if (this_config.currow) {
                                url += "&" + keyItem + "=" + this_config.currow[pars[1]];
                            } else {
                                url += "&" + keyItem + "=" + keyItem;
                            }
                        } else {
                            //如果能通过$("#xx")找到值，&xx=值
                            if ($("#" + pars[0]).size() > 0) {
                                url += "&" + keyItem + "=" + $("#" + pars[0]).val();
                            } else if (pars[0].toLowerCase() == "keyvalue") {
                                url += "&KeyValue=" + keyvalue;
                            } else {//如果找不到，&xx=xx;
                                url += "&" + keyItem + "=" + keyItem;
                            }
                        }
                    });
                    item.url = url;
                    arr.push(item);
                }
            });
            return arr;
        },
        // 渲染报表数据
        renderReport: function (data) {
            var that = this;
            data = that.checkReportData(data);

            var html = '';
            data.forEach(function (item, index) {
                html += '<li data-title = "' + item.Name + "." + item.ExpType + '" data-link="' + item.url + '" class="mui-table-view-cell">' +
                    '<a class="mui-navigate-right report">' +
                    '<p class="mui-ellipsis"><span>' + item.Name + "." + item.ExpType + '</span></p>' +
                    '</a>' +
                    '</li>';
            });

            $("#ReportList").html(html);

            // 打开报表
            $("#ReportList .mui-table-view-cell").on("tap", function () {
                var $this = $(this);
                var link = $this.attr("data-link");
                var title = $this.attr("data-title");

                appPhysical.OpenWebView(link, title);
            });
        },


        // 评论相关
        // 获取评论数据
        // 获取评论数据
        getComment: function (callback) {
            var formid = formconfig.FormId;
            var params = {
                FormId: formid,
                KeyWord: formconfig.config.joindata.KeyWord,
                KeyValue: formconfig.KeyValue
            };
            Util._APIAjax(params, function (data) {
                var getData = JSON.parse(data);
                if (getData.success) {
                    callback(getData);
                } else {
                    mui.alert(getData.message);
                }
            }, "/Form/GetComment");
        },
        // 评论列表渲染模板
        commentList: function (data) {
            var html = '';
            var that = this;
            var lists = data.data.value;
            var Subscribe = data.data.Subscribe;
            var HumanId = data.data.HumanId;
            that.setData("HumanId", HumanId);
            function atList(AtHumanList) {
                var atHtml = '';
                if (!AtHumanList || AtHumanList.length == 0) {
                    return atHtml;
                }

                AtHumanList.forEach(function (item, index) {
                    atHtml += '<span class="at-list" data-atid="' + item.HumanId + '">@' + item.HumanName + '</span>'
                });
                return atHtml;
            }
            // 订阅checkbox
            $("#subscribe").prop("checked", Subscribe == "Y");

            lists = lists.sort(function (a, b) {
                return new Date(a.RegDate).getTime() - new Date(b.RegDate).getTime();
            });

            lists.forEach(function (item, index) {
                var RegHumId = item.RegHumId;
                var AtHumanList = item.AtHumanList;

                if (!item.RegHeader) {
                    item.RegHeader = "/App_Themes/Default/assets/img/avatar1_small.jpg";
                }
                if (HumanId == RegHumId) {
                    html += '<div class="comment-history-list right">' +
                        '<p class="time-send">' +
                        '<span> ' + Util._formatDate(item.RegDate) + '</span>' +
                        '<span>' + item.RegHumName + ' </span>' +
                        '</p>' +
                        '<div class="list-wrap">' +
                        '<div class="list-text">' +
                        '<span class="text right">' + atList(AtHumanList) + item.CommentText + ' </span>' +
                        '</div>' +
                        '<div class="avatar-wrap">' +
                        '<img src="' + item.RegHeader + '" alt="">' +
                        '</div>' +
                        '</div>' +
                        '</div>';
                } else {
                    html += '<div class="comment-history-list left">' +
                        '<p class="time-send">' +
                        '<span>' + item.RegHumName + ' </span>' +
                        '<span >' + Util._formatDate(item.RegDate) + '</span>' +
                        '</p>' +
                        '<div class="list-wrap">' +
                        '<div class="avatar-wrap">' +
                        '<img src="' + item.RegHeader + '" alt="">' +
                        '</div>' +
                        '<div class="list-text">' +
                        '<span class="text left">' + atList(AtHumanList) + item.CommentText + '</span>' +
                        '</div>' +
                        '</div>' +
                        '</div>';
                }
            });

            $("#comment_history").html(html);
            $("#comment_lists_wrap").scrollTop($("#comment_lists_wrap")[0].scrollHeight);
        },
        // 发送评论
        onPostComment: function (callback) {
            var that = this;
            var Send_comment = $("#Send_comment_text");
            var send_comment_text = $.trim(Send_comment.val());
            var selectedAtHuman = that.getData("selectedAtHuman");

            if (!send_comment_text) {
                mui.alert("发送内容不能为空");
                return false;
            }

            Send_comment.blur();

            var json = {
                FormId: formconfig.FormId,
                KeyWord: formconfig.config.joindata.KeyWord,
                KeyValue: formconfig.KeyValue,
                CommentText: send_comment_text,
                AtHumanList: []
            };
            selectedAtHuman.forEach(function (item) {
                json.AtHumanList.push({
                    HumanId: item.Id,
                    HumanName: item.Name
                });
            });
            var params = {
                jsonData: JSON.stringify(json)
            }

            Util._APIAjax(params, function (data) {
                var getData = Util.stringify(data);
                if (getData.success) {
                    if (callback) {
                        callback(getData);
                    }
                } else {
                    mui.alert(getData.message);
                }
            }, "/Form/PostComment");
        },
        // 获取@人员的全部数据 人员向导
        getAtHumans: function (where, callback) {
            var params = {
                KeyWord: "Human",
                KeyWordType: "BO",
                index: "0",
                order: "",
                select: "",
                size: "0",
                swhere: " 1=1 ",
                sort: "",
                url: "/Form/GridPageLoad"
            };

            if (where) {
                params.swhere += " and " + where;
            }

            //此处修改上方查询字段
            var searchKey = $.trim($("#search_wizard").val());
            if (searchKey) {
                params.swhere += " and (Name like '%" + searchKey + "%' or Code like '%" + searchKey + "%')";
            }

            if (params.swhere) {
                var tmp = {};
                tmp.encodeswhere = "r4";
                params.extparams = Util.Base64Encode(JSON.stringify(tmp));
                params.swhere = Util.Base64Swhere(params.swhere);
            }

            Util._loading("加载中");
            $.ajax({
                url: params.url,
                data: params,
                type: 'POST',
                success: function (data) {
                    var getData = JSON.parse(data);
                    Util._closeLoading();

                    if (getData.success) {
                        $("#search_wizard").val("");
                        if (getData.data.value != "") {
                            callback(JSON.parse(getData.data.value));
                        }
                    }
                },
                error: function (e) {
                    Util._closeLoading();
                    mui.alert(e);
                }
            });
        },
        // 删除At缓存中的人员
        deleteAtHuman: function (id) {
            var arr = [], that = this;
            var selectedAtHuman = that.getData("selectedAtHuman");
            selectedAtHuman.forEach(function (item) {
                if (id != item.Id) {
                    arr.push(item);
                }
            });

            that.setData("selectedAtHuman", arr);
        },
        //At 人员选择后的渲染模板
        atSelectedLists: function (data, targetId) {
            var html = "", that = this;
            data.forEach(function (item, index) {
                html += '<span data-id="' + item.Id + '" data-code="' + item.Code + '" class="list-human">' +
                    '<label>' + item.Name + '</label>' +
                    '<i class="mui-icon mui-icon-closeempty"></i>' +
                    '</span>';
            });

            $("#" + targetId).html(html);
            $("#" + targetId).find(".mui-icon-closeempty").on("tap", function (e) {
                e.preventDefault();
                e.stopPropagation();

                var row = $(this).closest(".list-human");
                var id = row.attr("data-id");
                that.deleteAtHuman(id);
                that.atSelectedLists(that.getData("selectedAtHuman"), targetId);
            });
        },
        //At 人员向导模板
        renderAtHuman: function (data, targetId) {
            var html = '', that = this;
            var HumanId = that.getData("HumanId"); 
            var selectedAtHuman = that.getData("selectedAtHuman");
            that.setData("AtHuman", data);
            data.forEach(function (item) {
                var isExist = selectedAtHuman.filter(function (select) { if ( item.Id == select.Id) { return item } });
                var selected = isExist.length == 0 ? "" : "selected";
                var checked = isExist.length == 0 ? "" : "checked";
                html += '<li data-code="' + item.Code + '" data-name="' + item.Name + '" data-id = "' + item.Id + 
                    '" class="mui-table-view-cell mui-media '+ selected +'">' +
                    '<div>' +
                    '<div class="mui-media-object mui-checkbox mui-pull-left">' +
                    '<input name="checkbox" type="checkbox" '+ checked +' >' +
                    '</div>' +
                    '<div class="mui-media-body">' +
                    '<span>' + item.Name + '</span>' +
                    '<p class="mui-ellipsis">' + item.Code + '</p>' +
                    '</div>' +
                    '</div>' +
                    '</li>';
            });

            var targetDom = $("#" + targetId);
            targetDom.html(html);

            targetDom.find(".mui-media-body, .mui-checkbox").on("tap", function () {
                var $this = $(this);
                var row = $this.closest(".mui-table-view-cell");
                var id = row.attr("data-id");

                if (id == HumanId) {
                    mui.alert("不能选择自己");
                    return false;
                }

                var obj = that.filerSelectedAtHuman(id);
                if (!obj.can) {
                    return false;
                }

                that.setData("selectedAtHuman", obj.arr);
                row.toggleClass("selected");
                if (row.hasClass("selected")) {
                    row.find("input").prop("checked", true);
                } else {
                    row.find("input").prop("checked", false);
                }
                that.atSelectedLists(obj.arr, "selected_lists");
            });

            targetDom.find("input").on("tap", function (e) {
                e.preventDefault();
                e.stopPropagation();
                $(this).parent().next().trigger("tap");
            });
        },
        // @人员 选择人的时候 进行人员判定
        filerSelectedAtHuman: function (id) {
            var that = this;
            var selectedAtHuman = that.getData("selectedAtHuman");
            var selected = selectedAtHuman.concat();
            var AtHuman = that.getData("AtHuman");
            var thisHuman = AtHuman.filter(function(item) {
                if (item.Id == id) {
                    return item;
                }
            });

            if (selectedAtHuman.length >= 4) {
                mui.alert("@人数上限4人~~");
                return {
                    arr: selectedAtHuman,
                    can: false
                };
            }

            var isExitHuman = selected.filter(function (item) {
                if (item.Id == id) {
                    return item;
                }
            });

            if (isExitHuman.length == 0) {
                selectedAtHuman = selectedAtHuman.concat(thisHuman);
            } else {
                selectedAtHuman = selectedAtHuman.filter(function (item) {
                    if (item.Id != id) {
                        return item;
                    }
                });
            }

            return {
                arr: selectedAtHuman,
                can: true
            };
        },
        // 子表相关操作事件
        childTableEvent: function () {
            var that = this;

            // 点击子表新增按钮 新增子表 
            $(".add-table-list").on("tap", function () {
                var $this = $(this);
                var currentForm = $this.closest(".mui-control-content").find(".children-table-form");
                var keyword = currentForm.attr("id").replace("_Form", "");
                var right = keywordright[keyword];

                if (currentForm.length == 0) {
                    mui.alert("没有找到当前表单列表，请检查DOM结构");
                    return false;
                }

                if (right.bEdit != 1) {
                    mui.alert("您没有修改权限");
                    return false;
                }

                if (formconfig.FormState == "view") {
                    mui.alert("您没有新增权限");
                    return false;
                } else {
                    currentForm.find("input,textarea").prop("readonly", false);
                    currentForm.find("input,textarea").parent().removeClass("mui-required")
                    that.setData("table_state", "added");

                    currentForm.addClass("move-animation-back").removeClass("move-animation-start");
                }
            });

            // 点击子表删除按钮
            $(".delete-table-list").on("tap", function () {
                var $this = $(this);
                var actionBlock = $this.closest(".action-table");
                var currentForm = $this.closest(".mui-control-content").find(".children-table-form");
                var keyword = currentForm.attr("id").replace("_Form", "");
                var right = keywordright[keyword];
                var listsContent = $this.closest(".mui-control-content").find(".mui-table-view");
                
                if (right && (right.bDel == 1)) {
                    listsContent.find("div.mui-checkbox").removeClass("hide");
                    actionBlock.addClass("hide").next().removeClass("hide");
                } else {
                    mui.alert("您没有删除权限！");
                    return false;
                }
            });

            // 点击子表返回按钮 隐藏checkbox 和确认删除面板
            $(".delete-table-back").on("tap", function () {
                var $this = $(this);
                var actionBlock = $this.closest(".action-table");
                var listsContent = $this.closest(".mui-control-content").find(".mui-table-view");

                listsContent.find("input[type=checkbox]").prop("checked", false);
                listsContent.find("div.mui-checkbox").addClass("hide");
                actionBlock.addClass("hide").prev().removeClass("hide");
            });

            // 点击确认删除按钮 执行删除子表数据
            $(".delete-table-lists").on("tap", function () {
                var $this = $(this);
                var actionBlock = $this.closest(".action-table");
                var listsContent = $this.closest(".mui-control-content").find(".mui-table-view");
                var KeyWord = listsContent.attr("id");
                var right = keywordright[KeyWord];

                if (right.bDel != 1) {
                    mui.alert("您没有操作权限");
                    return false;
                }

                mui.confirm("确认删除?", "", ["否", "是"], function (e) {
                    if (e.index == 1) {
                        that.deleteTableLists(KeyWord, function () {
                            actionBlock.addClass("hide").prev().removeClass("hide");
                        });
                    } else {
                        return false;
                    }
                });
            });

            // 子表当前信息的保存事件
            $(".action-table .save-child-table").on("tap", function () {
                var $this = $(this);
                var form = $this.closest(".children-table-form");
                var id = form.attr("id");
                var keyword = id.replace("_Form", "");
                var right = keywordright[keyword];

                if (right.bEdit != 1) {
                    mui.alert("您没有修改权限");
                    return false;
                }

                that.SaveChildrenTable(keyword, function () {
                    mui.toast("保存成功");
                });
            });

            // 关闭当前信息面板
            $(".action-table .close-child-table").on("tap", function () {
                var $this = $(this);
                var Form = $this.closest("form");

                // 关闭面板
                Form.addClass("move-animation-start").removeClass("move-animation-back");
                // 清除数据
                Form.find("input, textarea").each(function () {
                    if ($(this).attr("type") == "checkbox") {
                        $(this).prop("checked", false);
                    } else if ($(this).attr("type") == "radio") {
                        $(this).prop("checked", false);
                    } else {
                        $(this).val("");
                    }
                });
            });
        },
        // 操作版的显示与隐藏
        toggleActionSheet: function () {
            mui('#ActionSheet').popover('toggle');
        },
        // 整个表单功能点的静态事件
        FormEvent: function () {
            var that = this;

            // 点击主表下的操作按钮
            // 操作表显示和隐藏
            $("#Action_btn").on("tap", function () {
                that.toggleActionSheet();
            });

            // 检测当前App处于什么系统
            Util._checkPlat(function (tag) {
                if (tag == "iPhone") {
                    //$("#UploadFileAll").addClass("hide");
                }
            });

            // 附件相关
            // 留给原生App上传附件成功之后调用
            window.MobileWebFormLoadFile = function () {
                that.getDocFiles(function (data) {
                    that.renderAttachFile(data);
                });
            };
            // 点击附件 只加载一次数据
            $("#attach_action").one("tap", function () {
                that.getDocFiles(function (data) {
                    that.renderAttachFile(data);
                });
            });

            // 添加上传事件
            that.upLoadAttachEvents(formconfig);

            // 点击报表 加载数据
            $("#report_action").one("tap", function () {
                that.getReport(function (data) {
                    that.renderReport(data);
                });
            });

            // 点击评论 加载评论数据
            $("#comment_action").one("tap", function () {
                that.getComment(function (data) {
                    that.commentList(data);
                });
            });

            // 点击发送评论
            $("#send_btn").on("tap", function () {
                that.onPostComment(function () {
                    that.getComment(function (data) {
                        that.commentList(data);

                        that.setData("selectedAtHuman", []);
                        that.atSelectedLists(that.getData("selectedAtHuman"), "selected_lists");
                        $("#Send_comment_text").val("");
                    });
                });
            });

            // 打开@人员向导
            $("#at_wizard").on("tap", function () {
                that.getAtHumans(null, function (data) {
                    $("#AtHumanWrap").addClass("move-animation-back").removeClass("move-animation-start");
                    that.renderAtHuman(data, "wizard_lists");
                });
            });

            // 关闭@人员面板
            $(".At-Human-header .at-btn").on("tap", function () {
                var action = $(this).attr("data-action");

                if (action == "cancel") {
                    that.setData("selectedAtHuman", []);
                    that.atSelectedLists(that.getData("selectedAtHuman"), "selected_lists");
                }

                that.setData("AtHuman", []);
                $("#AtHumanWrap").addClass("move-animation-start").removeClass("move-animation-back");
            });
        },
        // 打开向导面板
        openWizardWrap: function () {
            $("#WizardIframeWrap").addClass("move-animation-back").removeClass("move-animation-start");
        },
        // 关闭向导面板
        closeWizardWrap: function (data) {
            var that = this;

            $("#WizardIframeWrap").removeClass("move-animation-back").addClass("move-animation-start");

            if (!data) { return false; }

            var jsonData = formconfig.config.joindata;
            var mainFormData = that.getData("mainFormData");
            var currentTableItem = that.getData("currentTableItem");

            var option = data.option;
            var res = data.res;
            var query = data.query;
            
            if ( (option.multi + "") == "0") { // 说明数据是单选
                if (query.KeyWord == jsonData.KeyWord) { // 说明是主表
                    mainFormData = $.extend(mainFormData, res[0]);
                    that.setData("mainFormData", mainFormData);

                    for (var key in res[0]) {
                        $("#" + query.KeyWord + "_" + key).val(res[0][key]);
                    }
                } else { // 是打开的当前子表
                    currentTableItem.item = $.extend(currentTableItem.item, res[0]);
                    that.setData("currentTableItem", currentTableItem);

                    for (var key in res[0]) {
                        $("#" + query.KeyWord + "_" + key).val(res[0][key]);
                    }
                }
            } else { // 多选的 根据需求待定

            }
        },
        // 组件的静态事件
        compotentEvents: function () {
            var that = this;

            window.closeWizardWrap = function (data) {
                that.closeWizardWrap(data);
            }

            // 日期组件事件
            $(".mui-input.btn-picker").on("tap", function (e) {
                e.preventDefault();
                e.stopPropagation();

                var $this = $(this);
                var format = $this.attr("data-format");
                $("input").blur();

                if ($this.prop("readonly")) {
                    return false;
                }

                Util._openDtPicker({}, function (data) {
                    var value = Util._formatDate(data.text, format);
                    $this.attr("data-value", data.text);
                    $this.val(value).blur();
                });
            });

            // input框 textarea输入框的change事件
            $("input.mui-input, textarea.mui-textarea").on("change", function (e) {
                var $this = $(this);
                var required = $this.prop("required");
                var val = $this.val();

                $("input").blur();

                if (required && val == "") {
                    $this.parent().addClass("mui-required");
                } else {
                    $this.parent().removeClass("mui-required");
                }
            });

            //打开通用下拉框选择器
            $("input.mui-select").on("tap", function () {
                var $this = $(this);
                var readonly = $this.prop("readonly");
                var keyword = $this.attr("data-keyword");
                var key = $this.attr("name");
                var selectData = [];

                $("input").blur();

                if (readonly) {
                    return false;
                }

                if (!keyword || !key) {
                    mui.alert("此选择器没有配置对应的data-keyword属性或name属性");
                    return false;
                }

                if (comboboxdata[keyword + "." + key]) {
                    selectData = comboboxdata[keyword + "." + key].Data;
                } else {
                    mui.alert("comboboxdata中没有对应的选项");
                    return false;
                }

                $("input").blur();

                Util._openPicker(selectData, function (data) {
                    $this.val(data.text).blur();
                });
            });

            //  主子表向导
            $("input.mui-wizard").on("tap", function () {
                var $this = $(this);
                var url = $this.attr("data-url");
                var field = $this.attr("name");
                var keyword = $this.attr("data-keyword");
                var WizardIframe = $("#WizardIframe");

                $("input").blur();

                if (url) {
                    url += "?KeyWord=" + keyword + "&Name=" + field + "&EpsProjId=" + strEpsProjId;
                } else {
                    mui.alert("请设置向导的url");
                }

                WizardIframe.attr("src", url);
                that.openWizardWrap();
                Util._loading("加载中");
                WizardIframe.on("load", function () {
                    Util._closeLoading();
                });
            });
        },
        // 审批相关的权限
        workFlowRight: function () {
            var that = this;
            var mainFormData = that.getData("mainFormData");
            var joindata = formconfig.config.joindata;
            var status = mainFormData[joindata.statusfield];
            var sameMan = that.sameMan();
            var formstate = FormState || formconfig.FormState;

            // 如果审批流是终止 起草人还可以操作
            if (status == "40") {
                if (sameMan) {
                    return true;
                } else {
                    return false;
                }
            }

            // 如果审批流是已批准
            if (status == "50") {
                return false;
            }

            // 如果已经走了审批流程
            if (status == "20") {
                if (sameMan) {
                    return true;
                } else {
                    return false;
                }
            }

            // 如果已经生效
            if (status == "35") {
                return false;
            }

            // 如果是查看
            if (formstate == "view") {
                if (sameMan) {
                    return true;
                } else {
                    return false;
                }
            }

            return true;
        },
        // 审批相关的权限事件
        workFlowRightEvent: function () {
            var that = this;
            var hasRight = that.workFlowRight();

            if (hasRight) {
                return false;
            }

            // 没有权限的话 输入操作禁止
            $("input").each(function () {
                var $this = $(this);
                
                if ($this.hasClass("exclude")) {
                    $this.prop("disabled", false);
                } else {
                    $this.prop("disabled", true);
                }
            });

            // 子表列表
            var footer_bars = $(".mui-control-content>.mui-footer");
            if (footer_bars.hasClass("exclude")) {
                footer_bars.removeClass("hide");
            } else {
                footer_bars.addClass("hide");
            }

            // 子表表单
            if ($(".save-child-table").hasClass("exclude")) {
                $(".save-child-table").removeClass("hide");
            } else {
                $(".save-child-table").addClass("hide");
            }
        },
        // UI事件相关
        UIEvents: function () {
            var that = this;

            // 添加子表详情事件
            that.childTableEvent();

            // 整个表单功能点的静态事件
            that.FormEvent();

            // 组件的静态事件
            that.compotentEvents();
        },
        // 初始化程序
        init: function (option, callback) {
            var that = this;

            that.setData("optionDiy", option);
            that.UIEvents();

            that.load(callback);
        },
        // 加载数据
        load: function (callback) {
            var that = this;
            var config = that.getConfig(formconfig.config.joindata.KeyWord);

            localStorage.setItem("current_workflowdata", JSON.stringify(workflowdata));
            that.ConfigToList();
            that.getMainTable(function (data) {
                that.setData("mainFormData", data);
                that.setMainTable(config);

                // 主表的流程操作权限
                that.setFlowResult();

                var optionDiy = Util.deepClone(that.getData("optionDiy"));
                that.loadChildrenTable(optionDiy, "all", function (table) {
                    that.getChildrenTable(table);
                });

                // 执行权限事件
                that.workFlowRightEvent();
            });
        }
    }
}
