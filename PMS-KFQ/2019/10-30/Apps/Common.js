
Function.prototype.getName = function () {
    return this.name || this.toString().match(/function\s*([^(]*)\(/)[1]
}

var CallAppFunction = function (name, params, url, callback, closeback) {
    //var fun_name = callback == undefined ? "" : callback.getName();
    closeback = closeback || "";
    if (window.m3app != undefined && typeof (window.m3app.AppCall) == "function") {
        //var fun_name = callback == undefined ? "" : callback.getName();
        if (closeback == "") {
            window.m3app.AppCall(name, params, callback);
        } else {
            window.m3app.AppCall(name, params, callback, closeback);
        }
    } else if (typeof (window.PowerM3AppCall) == "function") {
        window.PowerM3AppCall(name, params, callback, closeback);
    } else if (url != undefined && url != "") {
        window.open(url, "_self")
    }
}

var PowerM3AppCallBack = PowerM3AppCallBack || {};
PowerM3AppCallBack.pagepullup = function () {
    //Power.ui.success("上拉触发成功");
    //alert(typeof (loadpage));
    PowerM3AppCallBack.loadpage(null, null);
}

PowerM3AppCallBack.loadpage = function () {
}

//android下拉
var AndroidLoadPage = function () {
    PowerM3AppCallBack.loadpage(null, null);
}

//向导选完后固定回调
function WizardResultData(d) {
    if (d == null || d == "")
        return;
    var x = jQuery.parseJSON(d);
    var action = x.action;
    var data = x.data;
    var btnid = x.btnid;
    if (action != "ok")
        return;
    
    if (!data || data.length == 0) {
        Power.ui.warning("未选择数据");//未选择数据
        return;
    }

    data = mini.clone(data);
    var e = {};
    e.id = btnid;
    var tempdata = mobilewebself.EventWizardData(e, data);
    if (tempdata) data = tempdata; //这样写是因为很多EventWizardData重载容易忘记 return data

    if (e.Next == false)
        return;
    var miniid = FormFuns.GetGridTreeName(btnid);
    var sender = FormFuns.GetMiniFormGrid(miniid);

    if (!sender) {
        sender = FormFuns.GetMiniFormGrid(miniid + "_Form");
        if (!sender) {
            Power.ui.warning("通过" + miniid + "_Form" + "找不到到Form/Grid/Tree");//通过xx找不到到Form/Grid/Tree
            return;
        }
    }

    var kconfig = FormFuns.GetConfig(miniid);
    if (!kconfig) {
        Power.ui.warning("通过" + miniid + "找不到配置文件");//通过xx找不到配置文件
        return;
    }
    var config = formconfig[btnid];
    //主表赋值
    if (FormFuns.IsMiniForm(sender) && kconfig.miniid == formconfig.config.joindata.miniid) {
        FormFuns.UpdateFormData(kconfig.miniid, false);
        if (!kconfig.currow) return;
        FormFuns.CopyFieldValue(kconfig.currow, data[0], config.fields);
        sender.setData(kconfig.currow, true);
        //可能存在-1到-10的赋值
        for (var i = 1; i < 10; i++) {
            var s = FormFuns.GetMiniFormGrid(miniid + "-" + i);
            if (s) {
                s.setData(kconfig.currow, true);
            }
        }
    }
    else if (FormFuns.IsMiniForm(sender)) {
        if (formconfig[kconfig.miniid] == undefined)
            formconfig[kconfig.miniid] = {};
        FormFuns.CopyFieldValue(formconfig[kconfig.miniid], data[0], config.fields);
        sender.setData(formconfig[kconfig.miniid], false);
    }

}
