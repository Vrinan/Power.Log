﻿document.write('<script src="' + bootPATH + 'PlatForm/FormFuns.js?v=' + __bootGetFileVersion() + '" type="text/javascript" ></script>');
///新增关闭时刷新 勿动方法名Closeback
function Closeback() {
    //可重写
    mobilesingleself.OpenWebFormcloseback();
}
//处理台账页面，取数、数据处理与webform有差异
var MobileSingleForm = function() {
    var DataP = {};
    var HtmlP = {};
    return mobilesingleself = { //执行初始化操作结束后 触发
        EventAterInit: function() {},
        //tree,grid 请求ajax之前 触发
        EventBeforeLoadData: function(e) {},
        //tree,grid ajax请求到数据后setdata之前 触发, 返回true 则系统默认代码不再执行
        EventBeforeSetData: function(e, data) { return false; },
        //tree,grid 加载数据之后 触发
        EventAfterLoadData: function(e) {},
        //tree,grid点击新增前触发
        EventBeforeAddForm: function(e) {},
        //新增表单前，设置默认值
        EventBeforeAddFormSetDefaultData: function(e, defaultdata) {},
        //tree\grid保存前
        EventBeforeSave: function(e) {},
        //tree/grid保存后
        EventAfterSave: function(e) {},
        //form生成数据包，提交到服务器之前出发
        EventBeforeSaveData: function(data) {},
        //tree/grid行删除前触发
        EventBeforeDelete: function(e, row) {},
        //tree/grid行删除后触发
        EventAfterDelete: function(e, row) {},
        Init: function() {
            //绑定初始化事件
            if ($("#del").length > 0) {
                $("#del").click(function() {
                    $(".left i").hide();
                    $(".left input").show();
                    $(".buttonlist").hide();
                    $(".buttonlist1").show();
                });
            }

            if ($(".buttonlist1 .cancel").length > 0) {
                $(".buttonlist1 .cancel").click(function() {
                    $(".left i").show();
                    $(".left input").hide();
                    $(".buttonlist").show();
                    $(".buttonlist1").hide();
                    $(":checkbox").attr("checked", false);
                });
            }

            if ($("#nav").length > 0) {
                $("#nav").click(function() {
                    $("#listdiv").show();
                });
            }

            if ($("#listdiv").length > 0) {
                $("#listdiv").click(function() {
                    $("#listdiv").hide();
                });
            }

            mobilesingleself.EventAterInit();
        },
        //删除
        OnBtnDel: function(keyword, keywordtype) {
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
                top.Power.ui.alert("请选择数据");
                return;
            }
            var e = {};
            mobilesingleself.EventBeforeDelete(e, rows);
            if (e.canNext == false || e.canOpen == false)
                return;
            var buttonOption = {};
            var yes = "是";
            var no = "否";
            buttonOption[yes] = {
                theme: 'primary',
                handler: function(ret) {
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
                            success: function(text) {
                                var o = mini.decode(text);
                                top.Power.ui.loading.close();
                                var e = {};
                                mobilesingleself.EventAfterDelete(e, rows);
                                if (e.canNext == false || e.canOpen == false)
                                    return;
                                if (o.success == false) {
                                    top.Power.ui.error(o.message, { timeout: 2000, position: "center center", closeable: true });
                                    sender.reload();
                                } else {
                                    window.location.reload();
                                }


                            }
                        });
                    }
                }
            };
            buttonOption[no] = function() {};
            top.Power.ui.confirm("是否确认删除", { button: buttonOption });
        },
        //加载数据入口
        LoadData: function(dataparams, htmlparams) {
            var config = formconfig.config.joindata;
            dataparams.select = dataparams.select || config.select;
            dataparams.KeyWord = dataparams.KeyWord || config.KeyWord;
            dataparams.KeyWordType = dataparams.KeyWordType || config.KeyWordType;
            dataparams.swhere = dataparams.swhere || config.swhere;
            var e = {};
            e.params = {};
            e.params.swhere = "";
            e.id = dataparams.KeyWord;
            mobilesingleself.EventBeforeLoadData(e); //增加对原有加载前事件的支持
            if (e.params.swhere != "") {
                if (dataparams.swhere != "")
                    dataparams.swhere += " and " + e.params.swhere;
                else
                    dataparams.swhere = e.params.swhere;
            }
            dataparams.size = dataparams.size || "10";
            dataparams.index = dataparams.index || "0";
            DataP = dataparams; //数据查询参数
            HtmlP = htmlparams; //HTML参数
            PowerM3AppCallBack.loadpage = mobilesingleself.doLoadData; //IOS下拉时触发
            AndroidLoadPage = mobilesingleself.doLoadData; //android下拉时触发
            if (dataparams.KeyWord == "") {
                top.Power.ui.alert("第一个参数中KeyWord不能为空");
                return;
            }
            mobilesingleself.doLoadData(dataparams, htmlparams);
        },
        //通过LoadData传递的参数查询数据
        doLoadData: function(dataparams, htmlparams) {
            dataparams = dataparams || DataP;
            htmlparams = htmlparams || HtmlP;
            var one = {};
            one.url = dataparams.url || "/Form/GridPageLoad";
            one.select = dataparams.select || ""
            one.KeyWord = dataparams.KeyWord; //数据集的名字
            one.KeyWordType = dataparams.KeyWordType || "BO";
            one.swhere = dataparams.swhere;
            one.size = dataparams.size;
            one.index = dataparams.index;
            one.sort = dataparams.order;
            var sw = FormFuns.FilterToSWhere(formconfig.config.joindata.filter);
            if (sw != "")
                one.swhere += sw;
            FormFuns.GridPageLoad(one, function(o) {
                var data = mini.decode(o.data.value);
                var e = {};
                e.sender = {};
                e.sender.id = dataparams.KewyWord;
                if (mobilesingleself.EventBeforeSetData(e, data))
                    return;
                //创建HTML
                mobilesingleself.BuildHTML(data, htmlparams);
                //加载权限
                var kright = keywordright[dataparams.KeyWord];
                if (kright) {
                    if (kright.bAdd == 0) {
                        $('.buttonlist .button').css('background-color', "#f4f4f4");
                        $('.buttonlist a').removeAttr('onclick');
                        $('.buttonlist1 .button').css('background-color', "#f4f4f4");
                        $('.buttonlist1 a').removeAttr('onclick');
                    }
                    if (kright.bDel == 0) {
                        $('.buttonlist1 .button').css('background-color', "#f4f4f4");
                        $('.buttonlist1 a').removeAttr('onclick');
                    }
                } else {
                    $('.buttonlist .button').css('background-color', "#f4f4f4");
                    $('.buttonlist a').removeAttr('onclick');
                    $('.buttonlist1 .button').css('background-color', "#f4f4f4");
                    $('.buttonlist1 a').removeAttr('onclick');
                }

                //触发数据加载后事件
                mobilesingleself.EventAfterLoadData(e);

            })
        },
        //通过查询到的数据创建HTML
        BuildHTML: function(data, htmlparams) {
            var html = "";
            //点击事件、标题文字、左中右文字，都单独提取出方法获取
            // for (var j = 0; j < data.length; j++) {
            //     var row = data[j];
            //     html += " <li>" +
            //    "<a class=\"clearfix\" href=\"javascript:;\" " + mobilesingleself.GetOnClick(htmlparams, row) + ">" +
            //        "<span class=\"left\"><input id=\"" + row[htmlparams.idfield] + "\" name=\"" + htmlparams.idfield + "\" class=\"check\" type=\"checkbox\" value=\"\" style=\"display:none\"/><i class=\"fa " + (htmlparams.icon || "fa-plus-square-o") + " a\"></i></span>" +
            //        "<div>" +
            //            mobilesingleself.GetTitle(htmlparams, row) +
            //            "<p class=\"group clearfix\">" +
            //               mobilesingleself.GetLeft(htmlparams, row) +
            //               mobilesingleself.GetCenter(htmlparams, row) +
            //              mobilesingleself.GetRight(htmlparams, row) +
            //           " </p>" +
            //       " </div>" +
            //       " <span class=\"right\"><i class=\"fa fa-angle-right\"></i></span>" +
            //    "</a>" +
            //"</li>";
            // }
            for (var j = 0; j < data.length; j++) {
                var row = data[j];
                html += ' <li>' +
                    '<a class="clearfix" href="javascript:;"' + mobilesingleself.GetOnClick(htmlparams, row) + '>' +
                    '<span class="left"><input id="' + row[htmlparams.idfield] + '" name="' + htmlparams.idfield + '" class="check" type="checkbox" value="" style="display:none"/><i class="fa ' + (htmlparams.icon || "fa-plus-square-o") + ' a"></i></span>' +
                    '<div>' +
                    mobilesingleself.GetTitle(htmlparams, row) +
                    '<p class="group clearfix">' +
                    mobilesingleself.GetLeft(htmlparams, row) +
                    mobilesingleself.GetCenter(htmlparams, row) +
                    mobilesingleself.GetRight(htmlparams, row) +
                    '</p>' +
                    '</div>' +
                    '<span class="right"><i class="fa fa-angle-right"></i></span>' +
                    '</a>' +
                    '</li>';
            }
            $("#" + htmlparams.gridid).append(html);
            //如果查询的数据存在，则index+1，下次执行的时候，即可查询到下一页
            if (data.length > 0)
                DataP.index = parseInt(DataP.index) + 1;
            //如果当前是点击的删除的状态，将图标隐藏，显示复选框
            if ($(".buttonlist1").css("display") != "none") {
                $(".left i").hide();
                $(".left input").show();
            }
        },
        //获取行单击的html
        GetOnClick: function(htmlparams, row) {
            var onclick = ""; //单击html
            if (htmlparams.formid != "") {
                onclick = "onclick=\"PowerForm.OpenWebForm('" + htmlparams.formid + "','" + row[htmlparams.idfield] + "','"+ row["OwnProjName"] +"')\"";
            }
            return onclick;
        },
        //获取行的【标题】html
        GetTitle: function(htmlparams, row) {

            var title = ""; //title

            if (htmlparams.title.value != "") {
                var format = htmlparams.title.format;
                if (format == "" || format == null) //普通文本
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
                } else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) { //数字 
                    title = "<p class=\"title\">" + mini.formatNumber(parseFloat(row[htmlparams.title.value]), format) + "</p>";
                } else if (format.indexOf("y") > -1) { //日期
                    title = "<p class=\"title\">" + mini.formatDate(row[htmlparams.title.value], format) + "</p>";
                }
            }
            return title.replace("null", "");
        },
        //获取行的【左侧】html
        GetLeft: function(htmlparams, row) {

            var left = ""; //左下角

            if (htmlparams.left.value != "") {
                var format = htmlparams.left.format;
                if (format == "" || format == null) //普通文本
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
                } else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) { //数字 
                    left = "<span>" + mini.formatNumber(parseFloat(row[htmlparams.left.value]), format) + "</span>";
                } else if (format.indexOf("y") > -1) { //日期
                    left = "<span>" + mini.formatDate(row[htmlparams.left.value], format) + "</span>";
                }
            }
            return left.replace("null", "");
        },
        //获取行的【中间】html
        GetCenter: function(htmlparams, row) {
            var center = ""; //中间
            if (htmlparams.center.value != "") {
                var format = htmlparams.center.format;
                if (format == "" || format == null) //普通文本
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
                } else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) { //数字 
                    center = "<span>" + mini.formatNumber(parseFloat(row[htmlparams.center.value]), format) + "</span>";
                } else if (format.indexOf("y") > -1) { //日期
                    center = "<span>" + mini.formatDate(row[htmlparams.center.value], format) + "</span>";
                }
            }
            return center.replace("null", "");;
        },
        //获取行的【右侧】HTML
        GetRight: function(htmlparams, row) {

            var right = ""; //右下角
            if (htmlparams.right.value != "") {
                var format = htmlparams.right.format;
                if (format == "" || format == null) //普通文本
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
                } else if (format.indexOf("n") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) { //数字 
                    right = "<span>" + mini.formatNumber(parseFloat(row[htmlparams.right.value]), format) + "</span>";
                } else if (format.indexOf("y") > -1) { //日期
                    right = "<span>" + mini.formatDate(row[htmlparams.right.value], format) + "</span>";
                }
            }
            return right.replace("null", "");;
        },
        //打开表单
        OpenWebForm: function(formid, keyvalue, title) {            
            if ($(".buttonlist1").css("display") != "none") {
                if ($("#" + keyvalue)[0].checked) {
                    $("#" + keyvalue).prop("checked", false);
                } else
                    $("#" + keyvalue).prop("checked", true);
                return;
            }
            var url = "/Form/ValidForm/" + formid + "/edit/" + keyvalue + "/";
            //直接由按钮是否是灰色的，来判断是查看还是编辑
            if ($('.buttonlist1 .button').css('background-color') == "#f4f4f4")
                url = "/Form/ValidForm/" + formid + "/view/" + keyvalue + "/";
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"false","pullDown":"false","showTabbar":"false","title":"'+ title +'"}', url);
        },
        //新增一条记录
        AddWebForm: function(formid) {
            var e = {};
            mobilesingleself.EventBeforeAddForm(e)
            if (e.canNext == false || e.canOpen == false)
                return;
            var url = "/Form/AddForm/" + formid + "/";
            //传递默认值
            var result = {};
            var config = formconfig.config.joindata;
            //常量过滤值
            mobilesingleself.EventBeforeAddFormSetDefaultData(e, result);
            if (result == undefined)
                result = e; //原来没有加上参数e，会和pc端不一样，加上e后，可能导致原来的result没值
            if (config.filter) {
                for (var fd in config.filter) {
                    if (typeof(fd) == "function") continue;
                    //result += "&" + result[fd] + "=" + config.filter[fd];
                    result[fd] = config.filter[fd];
                }
            }
            if (JSON.stringify(result) != '{}')
                url += "?sysfilter=" + Base64.encode(mini.encode(result));
            CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"true","pullDown":"true","showTabbar":"false","title":""}', url);
            // CallAppFunction("appOpenNewWebView", '{"url":"' + url + '","pullUp":"true","pullDown":"true","showTabbar":"false","title":""}', url,"",'Closeback');
            //if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
            //    window.m3app.AppCall('appOpenNewWebView', '{"url":"' + url + '","pullUp":"true","pullDown":"true","showTabbar":"false","title":""}', function XXX(outparam) {

            //    });
            //}
            //else {
            //    window.open(url, "_self")
            //}
        },
        //打开二维码扫描方法，二维码内容，会返回fn中，fn是回调函数的名称
        OpenQRCode: function(fn) {
            CallAppFunction("appOpenQRCode", '', '', fn);
        },
        ///关闭窗体后刷新操作
        OpenWebFormcloseback: function() {
            var dataparams = DataP;
            var htmlparams = HtmlP;
            var list = $("#" + htmlparams.gridid);
            if (list != undefined) {
                $("#" + htmlparams.gridid).html("");
                dataparams.index = 0;
                mobilesingleself.LoadData(dataparams, htmlparams);
            }
        }
    }
}
