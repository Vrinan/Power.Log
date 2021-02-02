var PowerMobile = PowerMobile || {};
//手机原生方法执行后的回掉函数
PowerMobile.EventAfterExecAPI = function (o) {

}
//手机下拉执行刷新时,默认刷新当前页面
PowerMobile.EventPullDownRefresh = function () {
    window.location.reload();
}
//拍照,结果触发
PowerMobile.OpenCarema = function () {
    window.location.href = "powerpms://opencarema";
}
//选取照片
PowerMobile.OpenPhoto = function () {
    window.location.href = "powerpms://openphoto";
}
//设置pms服务器地址
PowerMobile.SetPmsServer = function () {
    window.location.href = "powerpms://setserver";
}
PowerMobile.RefreshFinished = function () {
    window.location.href = "powerpms://refreshfinished";
}

//拦截session丢失,跳转到重新登陆页面
$.ajaxSetup({
    complete: function (xhr, text) {
        var sTemp = xhr.responseText;
        if (sTemp && sTemp.indexOf('{"success":false') > -1 && sTemp.indexOf('"detail":"gotorelogin"') > -1) {
            var url = window.location.protocol + "//" + window.location.host + "/sessionlost.html";
            window.location.href = url;
        }
    }
});

