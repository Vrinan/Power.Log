//标准模块功能中的通用业务功能JS

//获取CBSBizCfgCode
function getCBSBizCfgCode() {
    var CBSBizCfgCode = "";
    $.ajax({
        url: "/Form/GridPageLoad",
        data: {
            KeyWord: "PS_CBSBizCfg", KeyWordType: "BO",
            select: "Code",
            swhere: " TargetType='1'",
            sort: "",
            index: "0",
            size: "1"
        },
        type: "POST",
        cache: false,
        async: false,
        success: function (text) {
            //返回json字符串，需要先格式化成json包，再取数据

            var tmpdata = mini.decode(text);
            if (tmpdata.success == false) {//success为false时，查询报错
                Power.ui.error("查询失败：" + tmpdata.message);//message为错误详细信息
                return;
            }
            var data = mini.decode(tmpdata.data.value);//查询出来的数据列表，如果index是1，size是10的话，会查出第11-20条记录
            var totalCount = tmpdata.data.totalcount;//当前条件的数据库记录总数
            if (totalCount > 0) {
                CBSBizCfgCode = data[0].Code;
            }
        }
    });
    return CBSBizCfgCode;
}
//获取可用概算金额
function getRestMoney(Cbs_Guid, CostTypeId, CBSBizCfgCode) {
    var RestMoney = 0;
    $.ajax({
        url: "/Form/GridPageLoad",
        data: {
            KeyWord: "PS_CbsSheet", KeyWordType: "BO",
            select: "RestMoney",
            swhere: "Cbs_Guid='" + Cbs_Guid + "'and CostTypeId='" + CostTypeId + "' and CBSBizCfgCode='" + CBSBizCfgCode + "'",
            sort: "",
            index: "0",
            size: "1"
        },
        type: "POST",
        cache: false,
        async: false,
        success: function (text) {
            //返回json字符串，需要先格式化成json包，再取数据

            var tmpdata = mini.decode(text);
            if (tmpdata.success == false) {//success为false时，查询报错
                Power.ui.error("查询失败：" + tmpdata.message);//message为错误详细信息
                return;
            }
            var data = mini.decode(tmpdata.data.value);//查询出来的数据列表，如果index是1，size是10的话，会查出第11-20条记录
            var totalCount = tmpdata.data.totalcount;//当前条件的数据库记录总数
            if (totalCount > 0) {
                RestMoney = data[0].RestMoney;
            }
        }
    });
    return RestMoney;
}


//PIP分摊按钮功能
var StdCost = {
    ShareForPIP: function (KeyValue, Code) {
        $.ajax({
            url: "/Cost/CheckShareIdForPIP",
            data: { KeyValue: KeyValue, Code: Code },
            type: "POST",
            dataType: "JSON",
            success: function (text) {
                var o = mini.decode(text);
                if (o.success) {
                    if (o.detail != "") {
                        var url = "/Form/ValidForm/4aeda03f-b8a8-4e3c-95e3-4295c0bfcca0/edit/" + o.detail
                        //mini.open只有url必填，其他可不写，width和 height不写的话，会自动根据当前浏览器大小计算
                        mini.open({
                            url: url,
                            width: 900,
                            height: 600,
                            showMaxButton: true,
                            onload: function () {
                            },
                            ondestroy: function () {
                            }
                        });
                    } else {
                        Power.ui.confirm("确定分摊？", function (ret) {
                            if (ret) {
                                Power.ui.loading("分摊中...")
                                var guid = formconfig.KeyValue;
                                $.ajax({
                                    url: "/Cost/AutoShareForPIP",
                                    data: {
                                        KeyValue: guid,
                                        Code: Code
                                    },
                                    type: "POST",
                                    dataType: "JSON",
                                    success: function (text) {
                                        Power.ui.loading.close();
                                        var o = mini.decode(text);
                                        if (o.success) {
                                            var url = "/Form/ValidForm/4aeda03f-b8a8-4e3c-95e3-4295c0bfcca0/edit/" + o.detail
                                            //mini.open只有url必填，其他可不写，width和 height不写的话，会自动根据当前浏览器大小计算
                                            mini.open({
                                                url: url,
                                                width: 900,
                                                height: 600,
                                                showMaxButton: true,
                                                onload: function () {
                                                },
                                                ondestroy: function () {
                                                }
                                            });
                                        }
                                        else {
                                            Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                                        }
                                    }
                                });

                            }
                        });
                    }
                }
                else {
                    Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                }
            }
        });
    },
    //直接分摊,Flag：1增加，非1减少
    DirectlyShareForPIP: function (KeyValue, Code, Flag) {
        Power.ui.confirm("确定分摊？", function (ret) {
            if (ret) {
                Power.ui.loading("分摊中...")
                var guid = formconfig.KeyValue;
                $.ajax({
                    url: "/Cost/DirectlyShareForPIP",
                    data: {
                        KeyValue: guid,
                        Code: Code,
                        flag: Flag + ""
                    },
                    type: "POST",
                    dataType: "JSON",
                    success: function (text) {
                        Power.ui.loading.close();
                        var o = mini.decode(text);
                        if (o.success) {
                            Power.ui.success("分摊成功");
                        }
                        else {
                            Power.ui.error(o.message, { detail: o.detail, timeout: 0, position: "center center", closeable: true });
                        }
                    }
                });

            }
        });
    }
}