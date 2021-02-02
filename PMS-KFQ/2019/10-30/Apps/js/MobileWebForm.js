﻿
document.write('<script src="' + bootPATH + 'PlatForm/FormFuns.js?v=' + __bootGetFileVersion() + '" type="text/javascript" ></script>');

function MobileWebFormLoadFile() {
    var sort = "";
    var a = {};
    var swhere = "";
    $.ajax({
        url: "/Form/GetDocFiles",
        data: {
            BOKeyWord: formconfig.config.joindata.KeyWord,
            BOKeyValue: formconfig.KeyValue,
            select: "",
            swhere: swhere,
            sort: sort,
            index: 0,
            size: 0
        },
        cache: false,
        success: function (text) {
            var tmp = mini.decode(text);
            if (tmp.success) {
                var data = mini.decode(tmp.data.value);
                var count = data.length;
                var html = "";
                for (var i = 0; i < data.length; i++) {
                    var d = data[i];
                    var time = "";

                    time = mini.formatDate(d.RegDate, "yyyy-MM-dd")
                    html += "<li  onclick=\"PowerForm.OpenView('" + d.Id + "','" + d.Name + d.FileExt + "','" + d.FileExt + "')\"> <a href=\"javascrpit:;\"></a><span class=\"fileleft\">" + d.Name + d.FileExt + "</span><span class=\"fileright\">" + time + "</span></li>";
                }
                $("#FileAttach").html(html);
                $("#filecount").html("附件(" + count + ")");
            }
            else
                $("#FileAttach").html("");



        }
    });
}

//处理台账页面，取数、数据处理与webform有差异
var MobileWebForm = function () {
    var DataP = {};
    var HtmlP = {};
    var athumanlist = {};
    var $lastPopover = null;
    var commentlist = null;
    var loginhumanid = "";

    return mobilewebself = {
        //执行初始化操作结束后 触发
        EventAterInit: function () { },
        //tree,grid 请求ajax之前 触发
        EventBeforeLoadData: function (e) { },
        //tree,grid ajax请求到数据后setdata之前 触发, 返回true 则系统默认代码不再执行
        EventBeforeSetData: function (e) { return false; },
        //tree,grid加载数据后，渲染前  触发
        EventBeforeRenderData: function (e, data) {
            return data;
        },
        //tree,grid 加载数据之后 触发 
        EventAfterLoadData: function (e) { },
        //向导选中之后，对数据重新处理
        EventWizardData: function (e, data) { return data; },
        //向导第一步查询条件赋值 
        EventWizardWhere: function (e) { },
        //form保存生成保存数据包之前触发
        EventBeforeOnBtnSave: function (e) { },
        //流程按钮同意、送审前触发
        EventBeforeOnBtnFlow: function (e) { },
        //流程按钮驳回前触发
        EventBeforeOnBtnRetrunNode: function (e) { },
        //form生成数据包，提交到服务器之前出发
        EventBeforeSaveData: function (data, e) { },
        //tree/grid行删除前触发
        EventBeforeDelete: function (e, row) { },
        //tree/grid行删除后触发
        EventAfterDelete: function (e, row) { },
        //form 加载数据之后 触发 
        EventAfterFormLoad: function (data) { },
        //子表加载数据之后 触发
        EventAfterEditlistLoad: function (data) { },
        //子表保存之前 
        EventBeforeOnBtnOK: function (data) { },
        //设置评论参数  对应特殊情况设置 data.formid,data.keyword,data.keyvalue
        EventSetCommentParams: function (data) { },
        Init: function () {
            //绑定初始化事件 
            var configs = FormFuns.ConfigToList();
            for (var i = 0; i < configs.length; i++) {
                var config = configs[i];

                var swhere = "";

                var dataparams = {};
                dataparams.KeyWord = config.KeyWord;//关键词
                dataparams.select = "";//需要查询哪些字段,默认空
                dataparams.KeyWordType = config.KeyWordType;//BO/ViewEntity;默认BO
                dataparams.swhere = swhere;//where条件，默认空
                dataparams.size = "10";//每页条数，默认0
                dataparams.index = "0";//当前多少页，默认0
                dataparams.order = "";//排序，默认空
                config.dataparams = dataparams;
            }


            if ($("#nav").length > 0) {
                $("#nav").click(function () {
                    $("#listdiv").show();
                });
            }
            if ($("#listdiv").length > 0) {
                $("#listdiv").click(function () {
                    $("#listdiv").hide();
                });
            }

            if ($("#print").length > 0) {
                $("#print").click(function () {
                    $("#listprint").show();
                });
            }
            if ($("#listprint").length > 0) {
                $("#listprint").click(function () {
                    $("#listprint").hide();
                });
            }

            if ($("#media").length > 0) {
                $("#media").click(function () {
                    $("#listmedia").show();
                });
            }
            if ($("#listmedia").length > 0) {
                $("#listmedia").click(function () {
                    $("#listmedia").hide();
                });
            }

            if ($("#audio").length > 0) {
                $("#audio").click(function () {
                    $("#listaudio").show();
                });
            }
            if ($("#listaudio").length > 0) {
                $("#listaudio").click(function () {
                    $("#listaudio").hide();
                });
            }
            if (typeof (workflowdata) != "undefined" && workflowdata) {
                //!=workflows = 旧版
                if (workflowdata.WorkFlowFlag != "workflows") {
                    if (typeof (WorkFlowUtils) != "undefined" && !workflowdata.IsSetted) {
                        workflowdata.IsSetted = true;
                        WorkFlowUtils.SetWorkFlowInfo(mini.decode(workflowdata));
                        WorkFlowUtils.SetFlowButtons(workflowdata);  //如果有工作流体系，则设定工作流按钮 
                    }
                }
                else {
                    if (typeof (controlCenter) != "undefined")   //有控制中心，说明是新版流程
                    {
                        if (workflowdata.CanFlowOperate)    //正常打开，有SequeID ，能判断当前人和表单关系
                            controlCenter.onSetFlowResult(workflowdata.CanFlowOperate);
                        else if (workflowdata.CurrentResult) {
                            controlCenter.onAskSequ(workflowdata.CurrentResult);   //询问当前序号位置
                        }
                    }
                }
            }
            var oul = document.getElementById("ul1");
            var oli = null;
            if (oul)
                oli = oul.getElementsByTagName("li");
            var otab = document.getElementById("tablist");
            var odiv = null;
            if (otab)
                odiv = otab.getElementsByTagName("section");
            var obutton = document.getElementsByClassName("buttonlist");
            if (!oli)
                oli = [];
            for (var i = 0; i < oli.length; i++) {
                oli[i].index = i;
                oli[i].onclick = function () {
                    for (var i = 0; i < oli.length; i++) {
                        oli[i].className = "";
                    }
                    this.className = "active";
                    for (var j = 0; j < odiv.length; j++) {
                        odiv[j].className = odiv[j].className.replace("hide", "").replace("show", "").trim() + " hide";
                    }

                    odiv[this.index].className = odiv[this.index].className.replace("hide", "").replace("show", "").trim() + " show";
                    var id = odiv[this.index].id;
                    for (var j = 0; j < obutton.length; j++) {
                        if (obutton[j].id == id + "_buttonlist")
                            obutton[j].className = "show buttonlist";
                        else
                            obutton[j].className = "hide buttonlist";
                    }

                    if (id == "file") {
                        mobilewebself.loadGrid();
                    }
                    else if (id == "comment") {
                        mobilewebself.loadComment();
                    }
                    else if (id !== formconfig.config.joindata.KeyWord) {
                        var c = FormFuns.GetConfig(id);
                        if (c.dataparams.index == "0")
                            mobilewebself.loadlist(id);//加载子表数据
                    }
                }
            }
            //初始化下拉框数据
            FormFuns.InitComboboxData();
            //加载主表数据
            mobilewebself.LoadMain();
            //加载打印按钮
            mobilewebself.OnBtnPrint();
            mobilewebself.EventAterInit();
        },
        //打印按钮
        OnBtnPrint: function () {
            var formid = formconfig.FormId;
            if ($("#btnPrint") == undefined || $("#listprint") == undefined)
                return;
            $.ajax({
                url: "/Form/GetReport",
                type: "POST",
                data: { FormId: formid },
                cacha: false,
                success: function (text) {

                    var html = '<div class="navbg"></div>';
                    html += '<div class="navlist">';
                    html += '<div class="triangle-up"></div>';
                    html += '<ul>';
                    // html += "<ul class='dropdown-menu" + (isphone ? "" : " pull-right") + "'>";
                    var tmpdata = mini.decode(text);
                    var data = tmpdata.success ? mini.decode(tmpdata.data.value) : null; //得到所有报表信息
                    if (data != null && data != "") {
                        if ($("#reportname"))
                            $("#reportname").html("报表(" + data.length + ")")
                        for (var i = 0; i < data.length; i++) {
                            var id = data[i].Id;
                            var keyvalue = formconfig.config.joindata.currow[formconfig.config.joindata.keyfield];
                            var keyword = formconfig.config.joindata.KeyWord;

                            var url = "/PowerPlat/FormXml/ReportView.aspx?rid=" + id + "&KeyWord=" + keyword;
                            if (data[i].FormKey != null && data[i].FormKey != "") {
                                var formKey = data[i].FormKey.split(',');

                                for (var j = 0; j < formKey.length; j++) {
                                    //[@Id]\[@KeyWord.xx]
                                    var par = formKey[j];
                                    var pars = par.split('.');
                                    if (pars.length == 2)//KeyWord.xxx
                                    {
                                        var config = FormFuns.GetConfig(pars[0], null);
                                        if (config != undefined && config != null && config.currow != undefined && config.currow != null)
                                            url += "&" + par + "=" + config.currow[pars[1]]; //如果能通过KeyWord找到对应的记录，&KeyWord.xxx=值
                                        else
                                            url += "&" + par + "=" + formKey[j]; //如果找不到记录，&KeyWord.xxxx=KeyWord.xxx
                                    }
                                    else {
                                        if (mini.get(pars[0]) != undefined && mini.get(pars[0]) != null)
                                            url += "&" + par + "=" + mini.get(pars[0]).getValue(); //如果能通过mini.get("xx")找到只，&xx=值
                                        else if (pars[0].toLowerCase() == "keyvalue")
                                            url += "&KeyValue=" + keyvalue;
                                        else
                                            url += "&" + par + "=" + formKey[j]; //如果找不到，&xx=xx;
                                    }

                                }
                            }
                            html += ' <li><a href="javascript:void(0)" onclick=\'PowerForm.OpenReportView(\"' + url + '\")\'>' + data[i].Name + '</a></li>';


                        }
                    }

                    html += "</ul>";
                    html += '</div>';
                    $("#listprint").html(html);

                    mobilewebself.SetFloatWidth();
                }
            });
        },
        //子表点击删除按钮时，显示复选框，隐藏原来的保存按钮条，显示删除的确认按钮条
        ShowDel: function (e) {
            var miniid = e.id.split(".")[0];
            $("#" + miniid + " .left input").show();
            $("#" + miniid + "_buttonlist").hide();
            $("#" + miniid + "_buttonlist1").show();
        },
        //子表删除按钮条上的【取消】按钮
        CancelDel: function (miniid) {
            $("#" + miniid + " .left input").hide();
            $("#" + miniid + "_buttonlist").show();
            $("#" + miniid + "_buttonlist1").hide();
            $("#" + miniid + " :checkbox").attr("checked", false);
        },
        //附件【打开相机】拍照并上传
        OpenCamera: function () {
            CallAppFunction("appTakePhotos", '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","scale": 0.75,"upload":"true" }, "translateBase64": "false","filePath": "true"}', "", "MobileWebFormLoadFile");
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appTakePhotos', '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","scale": 0.75,"upload":"true" }, "translateBase64": "false","filePath": "true"}', function XXX(outparam) {
            //        mobilewebself.loadGrid();
            //    });
            //}
        },
        //附件【打开图库】选择照片并上传
        OpenGallery: function () {
            CallAppFunction("appOpenImagesLibrary", '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","scale": 0.75,"upload":"true" }, "translateBase64": "false","filePath": "true"}', "", "MobileWebFormLoadFile");
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appOpenImagesLibrary', '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","scale": 0.75,"upload":"true" }, "translateBase64": "false","filePath": "true"}', function XXX(outparam) {
            //        mobilewebself.loadGrid();
            //    });
            //}
        },
        //打开扫描二维码，fn是回调函数名称，二维码信息会在回调函数的参数中
        OpenQRCode: function (fn) {
            CallAppFunction("appOpenQRCode", '', '', fn);
        },
        //附件-【录像】并上传
        RecordVideos: function () {
            CallAppFunction("appRecordVideos", '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","width": 0,"height":0,"upload":"true" }, "translateBase64": "false","filePath": "true"}', "", "MobileWebFormLoadFile");
        },
        //附件-【选择视频文件】并上传
        OpenVideos: function () {
            CallAppFunction("appOpenVideosLibrary", '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","width": 0,"height":0,"upload":"true" }, "translateBase64": "false","filePath": "true"}', "", "MobileWebFormLoadFile");
        },
        //附件-【选择音频文件】并上传
        OpenAudio: function () {
            CallAppFunction("appRecordAudio", '{"uploadServer": {"keyword": "' + formconfig.config.joindata.KeyWord + '", "keyvalue": "' + formconfig.KeyValue + '","scale": 0.75,"upload":"true" }, "translateBase64": "false","filePath": "true"}', "", "MobileWebFormLoadFile");
        },
        //子表的新增按钮
        OnBtnAdd: function (e) {
            if (formconfig.FormState == "add") {
                top.Power.ui.alert("请先保存主表");
                return;
            }
            $("#" + e.id.split(".")[0] + "_AddTable").show();
            formconfig.state = "added";
            formconfig.listid = "";
        },
        //点击子表的行的时候，判断是删除时，则选中行；如果是正常状态，且有表单html，则显示表单html
        EditList: function (keyword, idfield, id) {
            if ($("#" + id).css("display") != "none") {
                //删除状态，为选中复选框
                if ($("#" + id)[0].checked) {
                    $("#" + id).prop("checked", false);
                }
                else
                    $("#" + id).prop("checked", true);
                return;
            }
            //否则打开表单
            var config = FormFuns.GetConfig(keyword);
            var data = config.data;
            if (data == undefined || data == null) {
                Power.uii.error("没有加载数据！");
                return;
            }
            for (var i = 0; i < data.length; i++) {
                var d = data[i];
                if (d[idfield] == id) {
                    var forms = new mini.Form("#" + keyword + "_Form");
                    forms.setData(data[i]);
                    mobilewebself.EventAfterEditlistLoad(data[i]);
                    break;
                }
            }
            $("#" + keyword + "_AddTable").show();
            formconfig.state = "modified";
            formconfig.listid = id;
            formconfig.listidfield = idfield;
        },
        //表单子表的编辑html上，点击取消
        OnBtnCancel: function (e) {
            var forms = new mini.Form("#" + e.id.split(".")[0] + "_Form");
            forms.setData({});
            $("#" + e.id.split(".")[0] + "_AddTable").hide();
        },
        //表单子表的编辑html上，点击确定
        OnBtnOk: function (e) {
            var keyword = e.id.split(".")[0];
            var config = FormFuns.GetConfig(keyword);
            var sender = FormFuns.GetMiniFormGrid(keyword + "_Form");
            var fields = sender.getFields();
            var data = {};
            if (formconfig.listid != "") {
                for (var i = 0; i < config.data.length; i++) {
                    if (config.data[i][formconfig.listidfield] == formconfig.listid)
                        data = config.data[i];
                }
            }
            for (var i = 0; i < fields.length; i++) {
                var c = fields[i];
                data[c.name] = c.getValue();
            }
            //将向导中，选择的值，存入data中
            if (formconfig[keyword]) {
                for (var tofd in formconfig[keyword]) {
                    data[tofd] = formconfig[keyword][tofd];
                }
            }
            data["_state"] = formconfig.state;
            if (formconfig.state == "added")
                data[config.keyfield] = CreateGUID();

            var pconfig = FormFuns.GetParentConfig(keyword);
            if (pconfig && pconfig.currow) {
                for (var fd in config.fields) {
                    if (typeof (fd) == "function") continue;
                    data[fd] = pconfig.currow[config.fields[fd]];
                }
            }
            mobilewebself.EventBeforeOnBtnOK(data);
            var pack = {};
            pack[keyword] = { KeyWordType: config.KeyWordType, data: [data] };
            var jdata = { formId: FormId, encode: "r4" };
            jdata.jsonData = base64swhere(FormFuns.SaveDataPackToString(pack));
            var sUrl = "/Form/SaveWebForm";

            top.Power.ui.loading("保存中……");
            $.ajax({
                url: sUrl,
                type: "POST",
                data: jdata,
                cache: false,
                success: function (text) {
                    var tmpdata = mini.decode(text);
                    top.Power.ui.loading.close();
                    if (tmpdata.success == false) {

                        top.Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 2000, position: "center center", closeable: true });


                    }
                    else {
                        var forms = new mini.Form("#" + keyword + "_Form");
                        forms.setData({});
                        formconfig[keyword] = {};
                        $("#" + keyword + "_AddTable").hide();
                        var html = "";
                        var row = data;
                        html += " <li id=\"" + row[HtmlP.idfield] + "_li\">" +
                       "<a href=\"javascript:;\" " + mobilewebself.GetOnClick(HtmlP, row) + ">" +
                           "<span class=\"left\"><input id=\"" + row[HtmlP.idfield] + "\" name=\"" + HtmlP.idfield + "\" class=\"check\" type=\"checkbox\" value=\"\" style=\"display:none\"/></span>" +
                           "<div>" +
                               mobilewebself.GetTitle(HtmlP, row) +
                               "<p class=\"group\">" +
                                  mobilewebself.GetLeft(HtmlP, row) +
                                  mobilewebself.GetCenter(HtmlP, row) +
                                 mobilewebself.GetRight(HtmlP, row) +
                              " </p>" +
                          " </div>" +
                          " <span class=\"right\"><i class=\"fa fa-angle-right\"></i></span>" +
                       "</a>" +
                   "</li>";
                        if (data["_state"] == "added") {
                            $("#" + HtmlP.gridid + " ul").append(html);
                            config.data.push(row);
                        }
                        else {
                            $('#' + row[HtmlP.idfield] + '_li').replaceWith(html);
                        }

                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });
        },
        //加载表单主表数据
        LoadMain: function () {
            var params = new Object();
            params.KeyWord = formconfig.config.joindata.KeyWord;
            params.KeyWordType = formconfig.config.joindata.KeyWordType || "BO";
            params.keyvalue = formconfig.KeyValue;
            params.select = "";
            params.formstate = formconfig.FormState;

            var config = FormFuns.GetConfig(formconfig.config.joindata.KeyWord);
            jQuery.ajax({
                url: "/Form/FormLoad",
                data: params,
                success: function (text) {

                    var tmpdata = mini.decode(text);
                    if (!tmpdata.success) {

                        top.Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 2000, position: "center center", closeable: true });
                    }
                    else {
                        var data = mini.decode(tmpdata.data.value);
                        config.currow = mini.decode(tmpdata.data.value);
                        config.oldcurrow = mini.decode(tmpdata.data.value);
                        //如果是表单的主表form，且有台账页面传递过来的新增默认值，且是新增状态，则需要赋值进去
                        if (config.miniid == formconfig.config.joindata.miniid && formconfig.FormState == "add") {
                            formconfig.KeyValue = config.currow[config.keyfield];
                            if (KeyValue != undefined && KeyValue == "")
                                KeyValue = config.currow[config.keyfield];
                            var sysfilter = getParameter("sysfilter");
                            if (sysfilter) {
                                sysfilter = mini.decode(Base64.decode(sysfilter));
                                for (var fd in sysfilter) {
                                    if (typeof (fd) == "function") continue;
                                    config.currow[fd] = sysfilter[fd];
                                }
                            }
                        }
                        var forms = new mini.Form("#" + formconfig.config.joindata.KeyWord);
                        forms.setData(config.currow);
                        $("#" + formconfig.config.joindata.KeyWord + " .NativeControl[name]").each(function () {
                            var _name = $(this).attr("name");
                            var _value = config.currow[_name];
                            var _type = $(this).attr("type");
                            if (_type == "date") {
                                _value = mini.formatDate(_value, "yyyy-MM-dd");
                            }
                            if (_type == "datetime") {
                                _value = mini.formatDate(_value, "yyyy-MM-dd");
                            }
                            $(this).val(_value);
                        });
                        mobilewebself.EventAfterFormLoad(config.currow);
                        //加载权限
                        var effected = formconfig.Effected;
                        if ((formconfig.FormState == "view") || (!workflowdata && !keywordright[config.KeyWord]) || FormFuns.WorkflowReadOnly(effected) || effected == true || FormFuns.WorkFlowUpdateForm() == true) {
                            //没权限，禁用所有按钮和控件
                            var fields = forms.getFields();
                            for (var j = 0; j < fields.length; j++) {
                                var c = fields[j];
                                if (c.setReadOnly) c.setReadOnly(true);     //只读
                                if (c.setIsValid) c.setIsValid(true);      //去除错误提示
                            }
                            //找到是否有子表form
                            var configs = FormFuns.ConfigToList();
                            for (var i = 0; i < configs.length; i++) {
                                var mid = configs[i].miniid + "_Form";
                                var m = document.getElementById(mid);
                                if (m == undefined) continue;

                                if (m && (m.className == "form" || m.className.indexOf("form ") > -1 || m.className.indexOf(" form") > -1)) {
                                    var f = new mini.Form("#" + mid);
                                    var fd = f.getFields();
                                    for (var j = 0; j < fd.length; j++) {
                                        var c = fd[j];
                                        if (c.setReadOnly) c.setReadOnly(true);     //只读
                                        if (c.setIsValid) c.setIsValid(true);      //去除错误提示
                                    }
                                }
                            }
                            $('.buttonlist a').removeAttr('onclick');
                            $('.listdiv a').removeAttr('onclick');
                            $('.selectbutton .ok').removeAttr('onclick');
                            $('.selectbutton .ok').css('background-color', "#f4f4f4");
                            $('.buttonlist .button').css('background-color', "#f4f4f4");
                        }
                        if (formconfig.KeyValue != "") {
                            $.ajax({
                                url: "/Form/GetFileCount",
                                data: { KeyWord: formconfig.config.joindata.KeyWord, KeyValue: formconfig.KeyValue },
                                success: function (text) {
                                    var t = mini.decode(text);
                                    var c = t.data.value;
                                    $("#filecount").html("附件(" + c + ")");
                                }
                            })
                        }
                    }
                }
            });
        },
        //加载表单子表数据
        loadlist: function (keyword) {
            var config = FormFuns.GetConfig(keyword);
            var swhere = "";
            if (formconfig.KeyValue == "")
                swhere = " 1=0 ";
            else {

                var pconfig = FormFuns.GetParentConfig(keyword, null);
                swhere = " 1=1 " + FormFuns.FilterToSWhere(config.filter);
                if (config.fields && pconfig) {
                    if (pconfig.currow) {
                        for (var fd in config.fields) {
                            if (typeof (fd) == "function")
                                continue;
                            var pfd = config.fields[fd];
                            if (typeof (pconfig.currow[pfd]) == undefined) //是常量值
                                swhere = swhere + " and " + fd + "='" + pdf + "'";
                            else {
                                if (pconfig.currow[pfd])
                                    swhere = swhere + " and " + fd + "='" + pconfig.currow[pfd] + "'";
                                else//与主表关联字段没有值，可能是新增，也可能是null，那就不应该查出数据
                                    swhere = swhere + " and 1=0";
                            }
                        }
                    }
                    else
                        swhere = swhere + " and 1=0";
                }
                swhere = "1=1 and " + swhere;
            }
            config.dataparams.swhere = swhere;
            var e = {};
            e.params = {};
            e.params.swhere = "";
            e.id = keyword;
            mobilewebself.EventBeforeLoadData(e);//增加对原有加载前事件的支持

            if (e.params.swhere != "") {
                if (config.dataparams.swhere != "")
                    config.dataparams.swhere += " and " + e.params.swhere;
                else
                    config.dataparams.swhere = e.params.swhere;
            }
            //var dataparams = {};
            //dataparams.KeyWord = config.KeyWord;//关键词
            //dataparams.select = "";//需要查询哪些字段,默认空
            //dataparams.KeyWordType = config.KeyWordType;//BO/ViewEntity;默认BO
            //dataparams.swhere = swhere;//where条件，默认空
            //dataparams.size = "10";//每页条数，默认0
            //dataparams.index = "0";//当前多少页，默认0
            //dataparams.order = "";//排序，默认空
            var htmlparams = {};
            htmlparams.gridid = keyword;//ul的id
            htmlparams.icon = "";//左侧图标，默认fa-plus-square-o
            htmlparams.formid = "";//如果需要打开表单，表单的formid
            var opation = $("#" + keyword).attr("data-potions");
            if (opation == "") {
                top.Power.ui.alert("没有" + keyword + "的查询必要配置");
            }
            opation = mini.decode(opation);
            htmlparams.idfield = opation.idfield;//主键字段是什么
            htmlparams.title = opation.title;
            htmlparams.left = opation.left;
            htmlparams.center = opation.center;
            htmlparams.right = opation.right;
            mobilewebself.LoadData(config.dataparams, htmlparams);

            //var one = {};
            //one.KeyWord = keyword; //数据集的名字
            //if (formconfig.KeyValue == "")
            //    one.swhere = " 1=0 ";
            //else {
            //    var config = FormFuns.GetConfig(keyword, null);
            //    var pconfig = FormFuns.GetParentConfig(keyword, null);
            //    var swhere = " 1=1 " + FormFuns.FilterToSWhere(config.filter);
            //    if (config.fields && pconfig) {
            //        if (pconfig.currow) {
            //            for (var fd in config.fields) {
            //                if (typeof (fd) == "function")
            //                    continue;
            //                var pfd = config.fields[fd];
            //                if (typeof (pconfig.currow[pfd]) == undefined) //是常量值
            //                    swhere = swhere + " and " + fd + "='" + pdf + "'";
            //                else {
            //                    if (pconfig.currow[pfd])
            //                        swhere = swhere + " and " + fd + "='" + pconfig.currow[pfd] + "'";
            //                    else//与主表关联字段没有值，可能是新增，也可能是null，那就不应该查出数据
            //                        swhere = swhere + " and 1=0";
            //                }
            //            }
            //        }
            //        else
            //            swhere = swhere + " and 1=0";
            //    }
            //    one.swhere = "1=1 and " + swhere;
            //}
            //one.size = "10";
            //FormFuns.GridPageLoad(one, function (o) {
            //    var data = mini.decode(o.data.value);
            //    var html = "<ul>";
            //    for (var j = 0; j < data.length; j++) {
            //        var row = data[j];
            //        html += " <li>" + row["PayNodes"] + "</li>";
            //    }
            //    html += "</ul>"
            //    $("#" + keyword).html(html);

            //})
        },
        //执行向导操作
        OnBtnWizard: function (e) {
            //有只读属性，且=true，不允许操作
            if (e.readOnly) {
                top.Power.ui.warning("当前状态为只读,不允许操作");//"当前状态为只读,不允许操作"
                return;
            }
            var btnid = e.id;
            var config = formconfig[btnid];
            if (!config) {
                top.Power.ui.warning(app_global_ResouceId["g_through"] + btnid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
                return;
            }
            var url = "/Form/Wizard?wizardid=" + config.ComponentID + "&formid=" + FormId + "&btnid=" + btnid;

            mobilewebself.EventWizardWhere(e);
            var where = "";
            if (e.where)
                where = e.where;
            var title = "选择";
            if (config.ComponentName)
                title = config.ComponentName;

            if (e.canOpen == false)
                return;
            CallAppFunction("appOpenWizard", '{"url":"' + url + '","where":"' + where + '","btnid":"' + btnid + '","pullUp":"true","pullDown":"true","showTabbar":"false","title":"' + title + '"}', url);
            //var t=mini.open({
            //    url: url,             
            //    showHeader: false,
            //    onload: function () {
            //        var iframe = this.getIFrameEl();
            //        var selobj = iframe.contentWindow.Select;
            //        if (selobj) {
            //            if (selobj.SetSourceData) selobj.SetSourceData(formconfig);
            //            if (selobj.SetWhere) selobj.SetWhere(e.where);
            //            if (selobj.LoadStepFirst) selobj.LoadStepFirst();
            //        }
            //    },
            //    ondestroy: function (action) {
            //        if (action != "ok")
            //            return;
            //        var iframe = this.getIFrameEl();
            //        var data = null;
            //        if (iframe.contentWindow.Select)
            //            data = iframe.contentWindow.Select.GetData();
            //        else {
            //            if (iframe.contentWindow.GetData)
            //                data = iframe.contentWindow.GetData();
            //        }
            //        if (!data || data.length == 0) {
            //            top.Power.ui.warning(app_global_ResouceId["not_select_data"]);//未选择数据
            //            return;
            //        }
            //        data = mini.clone(data);
            //        var tempdata = mobilewebself.EventWizardData(e, data);
            //        if (tempdata) data = tempdata; //这样写是因为很多EventWizardData重载容易忘记 return data

            //        if (e.Next == false)
            //            return;
            //        var miniid = FormFuns.GetGridTreeName(btnid);
            //        var sender = FormFuns.GetMiniFormGrid(miniid);
            //        if (!sender) {
            //            top.Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_grid"]);//通过xx找不到到Form/Grid/Tree
            //            return;
            //        }
            //        var kconfig = FormFuns.GetConfig(miniid);
            //        if (!kconfig) {
            //            top.Power.ui.warning(app_global_ResouceId["g_through"] + miniid + app_global_ResouceId["not_fined_config"]);//通过xx找不到配置文件
            //            return;
            //        }

            //        //主表赋值
            //        if (FormFuns.IsMiniForm(sender) && kconfig.miniid == formconfig.config.joindata.miniid) {
            //            FormFuns.UpdateFormData(kconfig.miniid, false);
            //            if (!kconfig.currow) return;
            //            FormFuns.CopyFieldValue(kconfig.currow, data[0], config.fields);
            //            sender.setData(kconfig.currow, true);
            //            //可能存在-1到-10的赋值
            //            for (var i = 1; i < 10; i++) {
            //                var s = FormFuns.GetMiniFormGrid(miniid + "-" + i);
            //                if (s) {
            //                    s.setData(kconfig.currow, true);
            //                }
            //            } 
            //        }
            //        else if (FormFuns.IsMiniForm(sender) ) {
            //            if (formconfig[kconfig.miniid] == undefined)
            //                formconfig[kconfig.miniid] = {}; 
            //            FormFuns.CopyFieldValue(formconfig[kconfig.miniid], data[0], config.fields);
            //            sender.setData(formconfig[kconfig.miniid], true);
            //        }
            //    }
            //});
            //t.max();
        },
        //打开查看附件
        OpenView: function (id, title, fileext) {
            if (title.toLowerCase().indexOf(".avi") > -1 || title.toLowerCase().indexOf(".mp4") > -1 || title.toLowerCase().indexOf(".mov") > -1) {
                CallAppFunction("appPlayVideos", '{"fileid":"' + id + '","filename":"' + title + '"}', "", "");
            }
            else {
                var url = "/PowerPlat/FormXml/FileViewer.aspx?online=1&fileid=" + id;

                CallAppFunction("appOpenNewWebView", '{"action":"openfile","fileext":"' + fileext + '","url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"' + title + '"}', url);
            }
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appOpenNewWebView', '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"'+title+'"}', function XXX(outparam) {

            //    });
            //}
            //else {
            //    window.open(url, "_self")
            //} 
        },
        //加载附件
        loadGrid: function () {
            MobileWebFormLoadFile();
        },
        //加载【评论】页签
        loadComment: function () {
            var html = '  <div class="portlet-body" id="chats" style="height:100%; margin-top: -40px;">' +
                            '<div class="mini-fit"> ' +
                                '<ul class="chats" id="commentlist"></ul>' +
                            '</div>' +
                            '<div class="chat-form" style="    bottom: 55px;position: absolute; padding:5px;">' +
                                '<div class="input-group">' +
                                    '<span class="input-group-addon">' +
                                        '<label class="checkbox-inline">' +
                                            '<input type="checkbox" id="chksubscribe" onclick="PowerForm.OnSubScribe()" />订阅' +
                                        '</label>' +
                                    '</span>' +
                                    '<span class="input-group-btn">' +
                                        '<a class="btn btn-small yellow" onclick="PowerForm.OnSelectAtHuman()">@用户</a>' +
                                    '</span>' +
                                    '<input id="txtAthuman" class="form-control tags small" type="text" value="" />' +
                                    '<span class="input-group-btn">' +
                                      '<a class="btn btn-small green" href="javascript:;" onclick="PowerForm.OnPostComment()"><i class="fa fa-comments"></i>发送</a>' +
                                    '</span>' +
                                '</div>' +
                                '<textarea class="form-control" id="txtSend" rows="4" placeholder="请输入发送信息" style="resize: none; display: block;"></textarea>' +
                            '</div>' +
                        '</div>';
            $("#tagcomment").html(html);
            $('#txtAthuman').tagsInput({
                width: 'auto',
                height: '34px',
                interactive: false,
                onRemoveTag: function (e) {
                    for (var i in athumanlist) {
                        if (e == '@' + athumanlist[i]) {
                            delete athumanlist[i];
                            return;
                        }
                    }
                }
            });

            commentlist = document.getElementById('commentlist');
            var Commentparams = {};
            Commentparams.keyword = formconfig.config.joindata.KeyWord;
            Commentparams.keyvalue = formconfig.KeyValue;
            Commentparams.formid = formconfig.FormId;
            //评论参数
            mobilewebself.EventSetCommentParams(Commentparams);
            if (Commentparams.keyvalue == undefined || Commentparams.keyvalue == undefined || Commentparams.keyvalue.length == 0)
                return;
            $.ajax({
                url: "/Form/GetComment",
                data: { KeyWord: Commentparams.keyword, KeyValue: Commentparams.keyvalue },
                type: "POST",
                success: function (text) {
                    var o = mini.decode(text);
                    if (o.success) {
                        loginhumanid = o.data.HumanId;
                        $('#chksubscribe').attr('checked', o.data.Subscribe == 'Y');
                        var shtml = "";
                        for (var i = 0; i < o.data.value.length; i++) {
                            var r = o.data.value[i];
                            shtml = shtml + mobilewebself.ToHtml(r.RegHumId, r.RegHumName, r.RegDate, r.RegHeader, r.AtHumanList, r.CommentText);
                        }
                        commentlist.innerHTML = shtml;
                    }
                    else
                        top.Power.ui.error(o.message);
                }
            });

            $(document).on("click", function () {
                $lastPopover && ($lastPopover.popbox("destroy"), $lastPopover = null);
            });

        },
        //评论页签，对话记录html
        ToHtml: function (reghumid, reghumname, regdate, regheader, atlist, commenttext) {
            var hums = "";
            if (atlist && atlist.length > 0) {
                for (var i = 0; i < atlist.length; i++) {
                    var h = atlist[i];
                    hums = hums + '<a href="javascript:;" onclick="PowerForm.OnHumNamePopover(\'' + h.HumanId + '\',\'' + h.HumanName + '\',this)">@' + h.HumanName + "</a> ";
                }
            }
            var s = loginhumanid == reghumid ? 'out' : 'in';
            s = '<li class="' + s + '"><img class="avatar img-responsive" alt="" src="' + regheader + '">'
              + '<div class="message">'
              + '<span class="arrow"></span>'
              + '<a class="name" href="javascript:;" onclick="PowerForm.OnHumNamePopover(\'' + reghumid + '\',\'' + reghumname + '\',this)">' + reghumname + '</a> '
              + '<span class="datetime"> ' + mini.formatDate(regdate, 'yyyy-MM-dd HH:mm') + '</span>'
              + '<span class="body">'
              + hums + commenttext
              + '</span>'
              + '</div>'
              + '</li>';
            return s;
        },
        //评论页签，发送评论
        OnPostComment: function () {
            var commenttext = $("#txtSend").val();
            if (commenttext == undefined || commenttext.length == 0) {
                top.Power.ui.warning("发送内容不能为空");
                return;
            }
            var humanlist = [];
            for (var i in athumanlist) {
                if (typeof (i) == "function") continue;
                humanlist.push({ HumanId: i, HumanName: athumanlist[i] });
            }
            var Commentparams = {};
            Commentparams.keyword = formconfig.config.joindata.KeyWord;
            Commentparams.keyvalue = formconfig.KeyValue;
            Commentparams.formid = formconfig.FormId;
            //评论参数
            mobilewebself.EventSetCommentParams(Commentparams);

            var p = { FormId: Commentparams.formid, KeyWord: Commentparams.keyword, KeyValue: Commentparams.keyvalue, CommentText: commenttext, AtHumanList: humanlist };
            $.ajax({
                url: "/Form/PostComment",
                data: { jsonData: mini.encode(p) },
                type: "post",
                success: function (text) {
                    var o = mini.decode(text);
                    if (o.success) {
                        var shtml = mobilewebself.ToHtml(loginhumanid, o.data.RegHumName, o.data.RegDate, o.data.RegHeader, humanlist, commenttext);
                        commentlist.innerHTML = shtml + commentlist.innerHTML;
                        //清空发送内容,@用户
                        athumanlist = {};
                        $("#txtSend").val("");
                        mobilewebself.AtHumanListToText();
                    }
                    else
                        top.Power.ui.error(o.message);
                }
            });
        },
        //【评论】页签，【订阅】按钮
        OnSubScribe: function () {
            var Commentparams = {};
            Commentparams.keyword = formconfig.config.joindata.KeyWord;
            Commentparams.keyvalue = formconfig.KeyValue;
            Commentparams.formid = formconfig.FormId;
            //评论参数
            mobilewebself.EventSetCommentParams(Commentparams);
            var sub = document.getElementById('chksubscribe').checked ? "Y" : "N";
            $.ajax({
                url: "/Form/SubscribeComment",
                data: { KeyWord: Commentparams.keyword, KeyValue: Commentparams.keyvalue, Subscribe: sub },
                type: "get",
                success: function (text) {
                    var o = mini.decode(text);
                    if (!o.success) {
                        var b = sub == "Y" ? false : true; //撤销修改
                        $('#chksubscribe').attr('checked', b);
                        top.Power.ui.error(o.message);
                    }
                    else {
                        var msg = sub == "Y" ? "订阅成功" : "订阅已取消";
                        Power.form.success(msg);
                    }
                }
            });
        },
        //点击【评论】上的@XXX显示【回复】和人员基本信息
        OnHumNamePopover: function (humid, humname, target) {
            $.getJSON("/Form/HumanInfo/" + humid, function (text) {
                var o = mini.decode(text);
                if (!o.success) {
                    top.Power.ui.warning(o.message);
                    return;
                }
                var html = "<div style='height:150px;'>"
                         + "<div class='portlet box' style='heigh:100%'>"
                         + "<div class='portlet-title'>"
                         + "<div class='caption'>" + o.data.Name + "</div>"
                         + "<div class='actions'><a class='btn btn-xs green' onclick='PowerForm.OnReply(\"" + humid + "\",\"" + humname + "\")'>回复</a></div></div>"
                         + "<div class='portlet-body'>"
                         + "<table style='width:100%'>"
                         + "<tr><td style='width:15%'>编号:</td><td>" + o.data.Code + "</td><td style='width:15%'>类型:</td><td>" + o.data.Utype + "</td></tr>"
                         + "<tr><td>部门:</td><td colspan='3'>" + o.data.DeptName + "</td></tr>"
                         + "<tr><td>岗位:</td><td colspan='3'>" + o.data.PosiName + "</td></tr>"
                         + "<tr><td>单位:</td><td colspan='3'>" + o.data.EpsProjName + "</td></tr>"
                         + "</table>"
                         + "</div>" //portlet-body
                         + "</div>"
                         + "</div>";
                $lastPopover = $(target).popbox({
                    width: 310,
                    position: 'bottom',
                    content: $(html)
                });
            })
        },
        //【评论】上的【回复】按钮事件
        OnReply: function (humid, humname) {
            if (humid == loginhumanid) {
                top.Power.ui.warning('不能给自己发消息');
                return;
            }
            document.getElementById('txtSend').focus();
            if (athumanlist[humid] == undefined)
                athumanlist[humid] = humname;
            mobilewebself.AtHumanListToText();
        },
        //通过@选择用户后，将用户名加到人员框中
        AtHumanListToText: function () {
            var names = "";
            for (var i in athumanlist) {
                if (typeof (i) == "function") continue;
                names = names + athumanlist[i] + ",";
            }
            $("#txtAthuman").importTags(names);
        },
        //【评论】选择用户
        OnSelectAtHuman: function () {

            var url = "/Apps/selectuser.html";

            var title = "选择";
            CallAppFunction("appOpenWizard", '{"url":"' + url + '","where":"","btnid":"wizardcomment","pullUp":"true","pullDown":"true","showTabbar":"false","title":"' + title + '"}', url);
            mobilewebself.EventWizardData = function (e, data) {
                if (e.id == "wizardcomment") {
                    e.Next = false;
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].Id == loginhumanid) continue; //不能给自己发消息
                        if (athumanlist[data[i].Id] == undefined)
                            athumanlist[data[i].Id] = data[i].Name;
                    }
                    mobilewebself.AtHumanListToText();
                }
            }
        },
        //主表保存
        OnBtnSave: function (e, afteradd, params, validData, fncallback) {

            $("#" + formconfig.config.joindata.KeyWord + " .NativeControl[name]").each(function () {
                var _name = $(this).attr("name");
                var _value = $(this).val();//config.currow[_name];
                if (!$(this).attr("readonly") || !$(this).attr("disabled"))
                    formconfig.config.joindata.currow[_name] = _value;
            });

            if (params == undefined)
                params = {};
            var senderid = FormFuns.GetGridTreeName(e.id);
            senderid = senderid;
            var isMainBtnSave = senderid == formconfig.config.joindata.miniid;
            //如果当前按钮不是主表上的保存按钮,且主表状态为add，需先保存主表
            if (isMainBtnSave == false && formconfig.FormState == "add")
            { top.Power.ui.warning("请先保存主表"); return; }
            //如果当前按钮不是主表上的保存按钮
            if (isMainBtnSave == false) {
                //找到父Config
                var parentconfig = FormFuns.GetParentConfig(senderid, null);
                //如果父级不是主表，且父级是新增状态
                if (parentconfig.miniid != formconfig.config.joindata.miniid && parentconfig.currow && parentconfig.currow._state == "added") {
                    top.Power.ui.alert("请先保存上级子表");
                    return;
                }
            }
            mobilewebself.EventBeforeOnBtnSave(e);
            if (e.isValid == false)
                return;
            //验证主表
            if (validData == undefined || validData == null || validData == true) {
                var oerr = FormFuns.ValidData(senderid, true);
                if (!oerr.success) {
                    if (oerr.errortext && oerr.errortext.length > 0)
                        top.Power.ui.error("有必填项未填，请检查" + ": <br/>" + oerr.errortext);//有必填项未填，请检查
                    else
                        top.Power.ui.error("有必填项未填，请检查");//"有必填项未填，请检查"
                    return;
                }
            }

            //如果是主表的保存按钮，禁用
            if (isMainBtnSave && typeof (e.setEnabled) == "function") e.setEnabled(false);
            //更新 form 标签中的数据
            FormFuns.UpdateFormData(senderid, false);
            var pack = {};

            FormFuns.GetSaveDataPack(pack, senderid, false);

            mobilewebself.EventBeforeSaveData(pack, e);   //追加  e 参数，以控制行为，wsl 追加

            //检查是否有修改，减少服务器交互
            var jdata = { formId: FormId, encode: "r4" };
            jdata.jsonData = base64swhere(mini.encode(pack));
            //如果是审批处理，允许没有提交数据
            if (typeof (workflowdata) != "undefined" && typeof (formconfig) != "undefined" && !FormFuns.WorkflowReadOnly(formconfig.Effected)) {
                if (!params) params = {};
                params.IsWorkFlowHuman = "1";
            }
            //如果是新增状态数据，且是当前录入人
            var joindata = formconfig.config.joindata;
            if (joindata.statusfield && joindata.currow[joindata.statusfield] == "0"
                && FormFuns.IsRegHuman(joindata, joindata.currow)) {
                params.IsRegHuman = "1";
            }
            ////如果包含模板附件,新增时需要触发
            //if (formconfig.FormState == "add" && existsTabId("attachfiletemplate")) {
            //    if (!params) params = {};
            //    params.attachfiletemplate = [];
            //    params.attachfiletemplate.push(joindata.KeyWord);//用数组以后可以扩展多个
            //    if (formconfig.config.joindata.TempleteFilter) {
            //        params.templetefilter = formconfig.config.joindata.TempleteFilter;
            //    }
            //}
            jdata.Params = base64encode(params == undefined ? '' : mini.encode(params));


            var sUrl = "/Form/SaveWebForm";
            //wsl 追加，如果表单参数中有  FromSource ,并且值等于 TransFlow ，说明是从事务流触发的表单新增，则URL重新定向
            if (params && params.ControlPath != undefined) {
                sUrl = "/" + params.ControlPath + "/SaveWebForm";
            }
            top.Power.ui.loading("保存中……");
            $.ajax({
                url: sUrl,
                type: "POST",
                data: jdata,
                cache: false,
                success: function (text) {
                    var tmpdata = mini.decode(text);
                    top.Power.ui.loading.close();
                    if (tmpdata.success == false) {

                        //保存失败之后，也应该再放开保存按钮
                        if (typeof (e.setEnabled) == "function")
                            e.setEnabled(true);
                        //如果是由于自动编号字段重复，则将后台返回的新的编号赋值到页面
                        if (tmpdata.message.indexOf(app_global_ResouceId["autocode_defined_reset_save"]) > -1) {
                            top.Power.ui.error(app_global_ResouceId["autocode_defined_reset_save"], { detail: tmpdata.detail, timeout: 2000, position: "center center", closeable: true });
                            //自动编码数据库已存在，已重新为您生成，请重新保存。
                            var newcode = mini.decode(tmpdata.message.replace(app_global_ResouceId["autocode_defined_reset_save"], ""));
                            //自动编码数据库已存在，已重新为您生成，请重新保存。
                            for (var i = 0; i < newcode.length; i++) {
                                joindata.currow[newcode[i]["Code"]] = newcode[i]["Value"];
                                mini.getbyName(newcode[i]["Code"]).setValue(newcode[i]["Value"]);
                            }
                        }
                        else {
                            top.Power.ui.error(tmpdata.message, { detail: tmpdata.detail, timeout: 2000, position: "center center", closeable: true });

                        }
                    }
                    else {
                        //top.Power.ui.success(app_global_ResouceId["rightpage_alert_save_success"]); //有遮罩不必再提醒
                        if (isMainBtnSave && formconfig.FormState == "add") {
                            ////需要考虑修改主键的情况
                            if (pack[senderid] != undefined && pack[senderid].data[0][joindata.keyfield] != undefined)
                                formconfig.KeyValue = pack[senderid].data[0][joindata.keyfield];
                            else
                                formconfig.KeyValue = joindata.currow[joindata.keyfield];
                            window.location.href = "/Form/ValidForm/" + FormId + "/edit/" + formconfig.KeyValue + "/";;
                            //formconfig.FormState = "edit";
                            //if (typeof (FormState) != "undefined") FormState = "edit";

                            ////wsl 追加，新增后，则立即显示 “送审按钮”   //2016.7.6 追加， 如果 IsWorkFlowHuman =1 ，就不修改 workFlowInfo ，以免影响全局变量信息
                            //if (typeof (WorkFlowUtils) != "undefined") {
                            //    $("#btnActive").css("display", "");   //新增保存完毕后，让送审按钮可见 
                            //    var workFlowInfo = { KeyWord: joindata.KeyWord, KeyValue: formconfig.KeyValue, UserID: '', HtmlPath: formconfig.FormId };
                            //    WorkFlowUtils.SetWorkFlowInfo(workFlowInfo);
                            //}
                        }
                        //保存后新增，只有主表有这样的需求，方便快速录入数据
                        if (isMainBtnSave) {
                            if (formconfig.FormState != "add") {
                                if (typeof (controlCenter) != "undefined")   //有控制中心，说明是新版流程
                                {
                                    onExecute(null, 'ReadFlow');  //加载流程
                                }
                            }
                            if (afteradd) {
                                formconfig.FormState = "add";
                                formconfig.KeyValue = "";
                                //如果是树，编辑打开，再点击 保存并新增，会导致新增的节点 应为没有给父节点赋值而在前端界面看不到数据
                                //因此增加如下判断
                                var cfg = FormFuns.GetConfig(senderid);
                                if (cfg && cfg.parentfield != undefined && cfg.parentfield.length > 0) {
                                    var pid = cfg.currow[cfg.parentfield];
                                    if (cfg.newdefaultdata == undefined)
                                        cfg.newdefaultdata = {};
                                    if (cfg.newdefaultdata[cfg.parentfield] == undefined)
                                        cfg.newdefaultdata[cfg.parentfield] = pid;
                                }
                            }
                            mobilewebself.LoadMain();
                        }
                        //else
                        //    doAcceptChange(senderid);
                    }
                    if (fncallback) fncallback(tmpdata.success);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });
        },
        //计算打印按钮的位置
        SetFloatWidth: function () {
            var btns = $(".show.buttonlist div");
            var width = 0;
            for (var i = 0; i < btns.length; i++) {
                var btn = btns[i];
                if (btn.style.display != "none" && btn.id != "btnPrint")
                    width += btn.offsetWidth;
            }
            if (width > 0 && $("#listprint.navlist")) {
                if ($("#listprint .navlist").length > 0) {
                    $("#listprint .navlist")[0].style.left = width + "px";
                }
            }
        },
        FlowSaveValid: function (e) {
            var params = {};
            var senderid = FormFuns.GetGridTreeName(e.id);
            var isMainBtnSave = senderid == formconfig.config.joindata.miniid;
            //如果当前按钮不是主表上的保存按钮,且主表状态为add，需先保存主表
            if (isMainBtnSave == false && formconfig.FormState == "add")
            { top.Power.ui.alert(app_global_ResouceId["webform_save_parent"]); return; }
            //如果当前按钮不是主表上的保存按钮
            if (isMainBtnSave == false) {
                //找到父Config
                var parentconfig = FormFuns.GetParentConfig(senderid, null);
                //如果父级不是主表，且父级是新增状态
                if (parentconfig.miniid != formconfig.config.joindata.miniid && parentconfig.currow && parentconfig.currow._state == "added") {
                    top.Power.ui.alert(app_global_ResouceId["webform_save_pre_children"]);
                    return;
                }
            }
            mobilewebself.EventBeforeOnBtnSave(e);
            if (e.isValid == false)
                return;
            //验证主表 
            var oerr = FormFuns.ValidData(senderid, true);
            if (!oerr.success) {
                if (oerr.errortext && oerr.errortext.length > 0)
                    top.Power.ui.error(app_global_ResouceId["vilidate_not_pass"] + ": <br/>" + oerr.errortext);//有必填项未填，请检查
                else
                    top.Power.ui.error(app_global_ResouceId["vilidate_not_pass"]);//"有必填项未填，请检查"
                return;
            }
            //如果是主表的保存按钮，禁用
            if (isMainBtnSave && typeof (e.setEnabled) == "function") e.setEnabled(false);
            //更新 form 标签中的数据
            FormFuns.UpdateFormData(senderid, false);
            var pack = {};

            FormFuns.GetSaveDataPack(pack, senderid, false);

            mobilewebself.EventBeforeSaveData(pack, e);   //追加  e 参数，以控制行为，wsl 追加

            //检查是否有修改，减少服务器交互
            var jdata = { formId: FormId };
            jdata.jsonData = mini.encode(pack);
            //如果是审批处理，允许没有提交数据
            if (typeof (workflowdata) != "undefined" && typeof (formconfig) != "undefined" && !FormFuns.WorkflowReadOnly(formconfig.Effected)) {
                if (!params) params = {};
                params.IsWorkFlowHuman = "1";
            }
            //如果是新增状态数据，且是当前录入人
            var joindata = formconfig.config.joindata;
            if (joindata.statusfield && joindata.currow[joindata.statusfield] == "0"
                && FormFuns.IsRegHuman(joindata, joindata.currow)) {
                params.IsRegHuman = "1";
            }
            //如果包含模板附件,新增时需要触发
            //if (formconfig.FormState == "add" && existsTabId("attachfiletemplate")) {

            //    if (!params) params = {};
            //    params.attachfiletemplate = [];
            //    params.attachfiletemplate.push(joindata.KeyWord);//用数组以后可以扩展多个
            //    if (formconfig.config.joindata.TempleteFilter) {
            //        params.templetefilter = formconfig.config.joindata.TempleteFilter;
            //    }
            //}
            jdata.Params = mini.encode(params);
            return jdata;

        },
        //子表删除事件
        OnBtnDel: function (keyword, keywordtype) {
            var rows = [];
            var allrows = $("input:checkbox");
            for (var i = 0; i < allrows.length; i++) {
                var row = allrows[i];
                var idfield = row.name;
                if (row.checked) {
                    var obj = { "_state": "removed" };
                    obj[idfield] = row.id;
                    rows.push(obj);
                }
            }
            if (rows.length == 0) {
                top.Power.ui.alert("请选择数据"); return;
            }
            var e = { id: keyword };
            mobilewebself.EventBeforeDelete(e, rows);
            if (e.canNext == false || e.canOpen == false)
                return;
            var buttonOption = {};
            var yes = "是";
            var no = "否";
            buttonOption[yes] = {
                theme: 'primary',
                handler: function (ret) {
                    if (ret) {

                        var pack = {};
                        pack[keyword] = { "KeyWordType": keywordtype || "BO" };

                        pack[keyword].data = rows;
                        var jdata = { formId: "", encode: "r4" };
                        jdata.jsonData = mini.encode(pack);
                        jdata.Params = base64encode("");


                        jdata.jsonData = base64swhere(jdata.jsonData);

                        top.Power.ui.loading("保存中……");
                        $.ajax({
                            url: "/Form/SaveWebForm",
                            type: "POST",
                            data: jdata,
                            success: function (text) {
                                var o = mini.decode(text);
                                top.Power.ui.loading.close();
                                var e = {};
                                mobilewebself.EventAfterDelete(e, rows);
                                if (e.canNext == false || e.canOpen == false)
                                    return;
                                if (o.success == false) {
                                    top.Power.ui.error(o.message, { timeout: 2000, position: "center center", closeable: true });
                                    //sender.reload();
                                }
                                else {
                                    var allrows = $("input:checkbox");
                                    for (var i = 0; i < allrows.length; i++) {
                                        var row = allrows[i];
                                        if (row.checked) {
                                            $("#" + row.id + "_li").remove();
                                        }
                                    }
                                    $("#" + keyword + " .left input").hide();
                                    $("#" + keyword + "_buttonlist").show();
                                    $("#" + keyword + "_buttonlist1").hide();
                                    $("#" + keyword + " :checkbox").attr("checked", false);

                                }


                            }
                        });
                    }
                }
            };
            buttonOption[no] = function () { };
            top.Power.ui.confirm("是否确认删除", { button: buttonOption });
        },
        //子表加载数据
        LoadData: function (dataparams, htmlparams) {
            dataparams.size = dataparams.size || "10";
            dataparams.index = dataparams.index || "0";
            DataP = dataparams;
            HtmlP = htmlparams;
            PowerM3AppCallBack.loadpage = mobilewebself.doLoadData;//IOS下拉时触发
            AndroidLoadPage = mobilewebself.doLoadData;//android下拉时触发
            if (dataparams.KeyWord == "") {
                top.Power.ui.alert("第一个参数中KeyWord不能为空");
                return;
            }
            mobilewebself.doLoadData(dataparams, htmlparams);
        },
        //子表加载数据
        doLoadData: function (dataparams, htmlparams) {
            dataparams = dataparams || DataP;
            htmlparams = htmlparams || HtmlP;
            var otab = document.getElementById("tablist");
            var odiv = otab.getElementsByTagName("section");
            for (var i = 0; i < odiv.length; i++) {
                if (odiv[i].className == "show") {
                    if (dataparams.KeyWord != odiv[i].id)
                        return;
                }
            }
            var one = {};
            one.url = dataparams.url || "/Form/GridPageLoad";
            one.select = dataparams.select || ""
            one.KeyWord = dataparams.KeyWord; //数据集的名字
            one.KeyWordType = dataparams.KeyWordType || "BO";
            one.swhere = dataparams.swhere;
            one.size = dataparams.size;
            one.index = dataparams.index;
            one.sort = dataparams.order;
            FormFuns.GridPageLoad(one, function (o) {
                var data = mini.decode(o.data.value);
                if (mobilewebself.EventBeforeSetData({ id: dataparams.KeyWord }))
                    return;
                data = mobilewebself.EventBeforeRenderData({ id: dataparams.KeyWord }, data);
                var config = FormFuns.GetConfig(dataparams.KeyWord);
                if (config.data == undefined || config.data == "")
                    config.data = data;
                else {
                    for (var i = 0; i < data.length; i++) {
                        config.data.push(data[i]);
                    }
                }
                mobilewebself.BuildHTML(data, htmlparams);
                mobilewebself.EventAfterLoadData({ id: dataparams.KeyWord });
            })
        },
        //加载子表数据到html
        BuildHTML: function (data, htmlparams) {
            var html = "";

            for (var j = 0; j < data.length; j++) {
                var row = data[j];
                html += " <li id=\"" + row[htmlparams.idfield] + "_li\">" +
               "<a href=\"javascript:;\" " + mobilewebself.GetOnClick(htmlparams, row) + ">" +
                   "<span class=\"left\"><input id=\"" + row[htmlparams.idfield] + "\" name=\"" + htmlparams.idfield + "\" class=\"check\" type=\"checkbox\" value=\"\" style=\"display:none\"/></span>" +
                   "<div>" +
                       mobilewebself.GetTitle(htmlparams, row) +
                       "<p class=\"group\">" +
                          mobilewebself.GetLeft(htmlparams, row) +
                          mobilewebself.GetCenter(htmlparams, row) +
                         mobilewebself.GetRight(htmlparams, row) +
                      " </p>" +
                  " </div>" +
                  " <span class=\"right\"><i class=\"fa fa-angle-right\"></i></span>" +
               "</a>" +
           "</li>";
            }
            $("#" + htmlparams.gridid + " ul").append(html);
            if (data.length > 0)
                DataP.index = parseInt(DataP.index) + 1;
            if ($(".buttonlist1").css("display") != "none") {
                $(".left input").show();
            }
        },
        //获取子表点击事件
        GetOnClick: function (htmlparams, row) {
            var onclick = "";//单击html 
            onclick = "onclick=\"PowerForm.EditList('" + htmlparams.gridid + "','" + htmlparams.idfield + "','" + row[htmlparams.idfield] + "')\"";

            return onclick;
        },
        //获取子表上，行的标题数据
        GetTitle: function (htmlparams, row) {

            var title = "";//title

            if (htmlparams.title.value != "") {
                var format = htmlparams.title.format;
                if (format == "" || format == null)//普通文本
                    title = "<p class=\"title\">" + row[htmlparams.title.value] + "</p>";
                else if (format == "combobox") {
                    var comb = comboboxdata[htmlparams.gridid + "." + htmlparams.title.value];
                    if (comb) {
                        var ds = comb.Data;
                        var v = row[htmlparams.title.value];
                        for (var i = 0; i < ds.length; i++) {
                            var d = ds[i];
                            if (d[comb.ValueField] == v) {
                                title = "<p class=\"title\">" + d[comb.TextField] + "</p>";
                                break;
                            }
                        }
                    }
                }
                else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) {//数字
                    title = "<p class=\"title\">" + mini.formatNumber(parseFloat(row[htmlparams.title.value]), format) + "</p>";
                }
                else if (format.indexOf("y") > -1) {//日期
                    title = "<p class=\"title\">" + mini.formatDate(row[htmlparams.title.value], format) + "</p>";
                }
            }
            return title.replace("null", "");
        },
        //获取子表上，行的左侧数据
        GetLeft: function (htmlparams, row) {

            var left = "";//左下角

            if (htmlparams.left.value != "") {
                var format = htmlparams.left.format;
                if (format == "" || format == null)//普通文本
                    left = "<span>" + row[htmlparams.left.value] + "</span>";
                else if (format == "combobox") {
                    var comb = comboboxdata[htmlparams.gridid + "." + htmlparams.left.value];
                    if (comb) {
                        var ds = comb.Data;
                        var v = row[htmlparams.left.value];
                        for (var i = 0; i < ds.length; i++) {
                            var d = ds[i];
                            if (d[comb.ValueField] == v) {
                                left = "<span>" + d[comb.TextField] + "</span>";
                                break;
                            }
                        }
                    }
                }
                else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) {//数字
                    left = "<span>" + mini.formatNumber(parseFloat(row[htmlparams.left.value]), format) + "</span>";
                }
                else if (format.indexOf("y") > -1) {//日期
                    left = "<span>" + mini.formatDate(row[htmlparams.left.value], format) + "</span>";
                }
            }
            return left.replace("null", "");
        },
        //获取子表上，行的中部数据
        GetCenter: function (htmlparams, row) {
            var center = "";//中间
            if (htmlparams.center.value != "") {
                var format = htmlparams.center.format;
                if (format == "" || format == null)//普通文本
                    center = "<span>" + row[htmlparams.center.value] + "</span>";
                else if (format == "combobox") {
                    var comb = comboboxdata[htmlparams.gridid + "." + htmlparams.center.value];
                    if (comb) {
                        var ds = comb.Data;
                        var v = row[htmlparams.center.value];
                        for (var i = 0; i < ds.length; i++) {
                            var d = ds[i];
                            if (d[comb.ValueField] == v) {
                                center = "<span>" + d[comb.TextField] + "</span>";
                                break;
                            }
                        }
                    }
                }
                else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) {//数字
                    center = "<span>" + mini.formatNumber(parseFloat(row[htmlparams.center.value]), format) + "</span>";
                }
                else if (format.indexOf("y") > -1) {//日期
                    center = "<span>" + mini.formatDate(row[htmlparams.center.value], format) + "</span>";
                }
            }
            return center.replace("null", "");;
        },
        //获取子表上，行的右侧数据
        GetRight: function (htmlparams, row) {

            var right = "";//右下角
            if (htmlparams.right.value != "") {
                var format = htmlparams.right.format;
                if (format == "" || format == null)//普通文本
                    right = "<span>" + row[htmlparams.right.value] + "</span>";
                else if (format == "combobox") {
                    var comb = comboboxdata[htmlparams.gridid + "." + htmlparams.right.value];
                    if (comb) {
                        var ds = comb.Data;
                        var v = row[htmlparams.right.value];
                        for (var i = 0; i < ds.length; i++) {
                            var d = ds[i];
                            if (d[comb.ValueField] == v) {
                                right = "<span>" + d[comb.TextField] + "</span>";
                                break;
                            }
                        }
                    }
                }
                else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) {//数字
                    right = "<span>" + mini.formatNumber(row[htmlparams.right.value], format) + "</span>";
                }
                else if (format.indexOf("y") > -1) {//日期
                    right = "<span>" + mini.formatDate(row[htmlparams.right.value], format) + "</span>";
                }
            }
            return right.replace("null", "");;
        },
        //打开另一个表单
        OpenWebForm: function (formid, keyvalue) {
            if ($(".buttonlist1").css("display") != "none") {
                if ($("#" + keyvalue)[0].checked) {
                    $("#" + keyvalue).prop("checked", false);
                }
                else
                    $("#" + keyvalue).prop("checked", true);
                return;
            }
            var url = "/Form/ValidForm/" + formid + "/edit/" + keyvalue + "/";
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":""}', url);

        },
        //打开新增表单
        AddWebForm: function (formid) {
            var url = "/Form/AddForm/" + formid + "/";
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":""}', url);
        },
        //打开报表
        OpenReportView: function (url) {

            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":""}', url);

        }
    }
}

