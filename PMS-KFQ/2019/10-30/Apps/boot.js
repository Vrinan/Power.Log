﻿var mini_debugger = false;
var bootPATH = "/Scripts/";
var __bootCSSPATH = "/App_Themes/Default/";
var __bootGetCookie = function (Name) {
    var cookies = document.cookie.split("; "),
    	lastMatch = null,
		cookie;
    for (var i = 0; i < cookies.length; i++) {
        cookie = cookies[i].split("=");
        if (Name == cookie[0]) {
            lastMatch = cookie;
        }
    }
    if (lastMatch) {
        var v = lastMatch[1];
        if (v === undefined) return v;
        return unescape(v);
    }
    return null;
};

var __bootGetFileVersion = function () {
    var fileName = "?";
    var scripts = document.getElementsByTagName("script");
    var version = "_v=" + Math.random();
    for (var i = 0; i <= scripts.length; i++) {
        var script = document.getElementsByTagName("script")[i];
        if (script && script.src && script.src != "") {
            var index = script.src.indexOf(fileName);
            if (index > -1) {
                version = script.src.substring(index + fileName.length);
                var _vers = version.split('=');
                if (_vers != null)
                    version = _vers[_vers.length - 1];
                break;
            }
        }
    }
    return version;
}
document.write('<link href="' + __bootCSSPATH + 'assets/plugins/bootstrap/css/bootstrap.min.css?v=$AppVersion" rel="stylesheet" type="text/css" role="responsive" />');
document.write('<link href="' + __bootCSSPATH + 'assets/css/style.min.css?v=$AppVersion" rel="stylesheet" type="text/css" role="responsive" />');
document.write('<link href="' + __bootCSSPATH + 'assets/css/style-metronic.min.css?v=$AppVersion" rel="stylesheet" type="text/css" role="responsive" />');
document.write('<link href="' + __bootCSSPATH + 'assets/css/style-responsive.min.css?v=$AppVersion" rel="stylesheet" type="text/css" role="responsive" />');

var __bootTheme = __bootGetCookie("Power.theme") || 'default';
document.write('<link href="' + __bootCSSPATH + 'assets/css/themes/' + __bootTheme + '.min.css?v=$AppVersion" rel="stylesheet" type="text/css" id="global_theme" role="responsive" />');


document.write('<link href="' + __bootCSSPATH + 'assets/plugins/font-awesome/css/font-awesome.min.css?v=$AppVersion" rel="stylesheet" type="text/css" />');
document.write('<link href="' + __bootCSSPATH + 'assets/plugins/simple-icons/css/simple-line-icons.min.css?v=$AppVersion" rel="stylesheet" type="text/css" />');

//respond
document.write('<!--[if lt IE 9]><script src="' + bootPATH + 'plugins/respond.min.js?v=$AppVersion"></script><![endif]-->');

//framework
document.write('<script src="' + bootPATH + 'plugins/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>');
document.write('<script src="' + bootPATH + 'plugins/bootstrap/bootstrap.min.js?v=$AppVersion" type="text/javascript" ></script>');

//power
document.write('<script src="' + bootPATH + 'assets/scripts/app.min.js?v=$AppVersion" type="text/javascript" ></script>');

//miniui
document.write('<link href="' + __bootCSSPATH + 'miniui/default/miniui.min.css?v=$AppVersion" rel="stylesheet" type="text/css" />');
document.write('<link href="' + __bootCSSPATH + 'miniui/default/miniui_power.min.css?v=$AppVersion" rel="stylesheet" type="text/css" />');
document.write('<script src="' + bootPATH + 'miniui/miniui.js?v=$AppVersion" type="text/javascript" ></script>');

document.write('<script src="' + bootPATH + 'PlatForm/PowerMobile.js?v=$AppVersion" type="text/javascript" ></script>');
document.write('<script src="/Apps/js/TouchSlide.1.1.js?v=$AppVersion" type="text/javascript" ></script>');
document.write('<script src="/Apps/Common.js?v=$AppVersion" type="text/javascript" ></script>');
 
document.write('<link href="/Apps/style/font-awesome.min.css?v=$AppVersion" rel="stylesheet" type="text/css" />');
//document.write('<link href="/Apps/style/?v=$AppVersion" rel="stylesheet" type="text/css" />');
document.write('<link href="/Scripts/plugins/jQuery/jquery-tags-input/jquery.tagsinput.css?v=$AppVersion" rel="stylesheet" type="text/css" />');
document.write('<link href="/Scripts/plugins/popbox/css/popbox.css?v=$AppVersion" rel="stylesheet" type="text/css" />');
document.write('<script src="/Scripts/plugins/jQuery/jquery-tags-input/jquery.tagsinput.min.js?v=$AppVersion" type="text/javascript" ></script>');
document.write('<script src="/Scripts/plugins/jQuery/jquery-ui/jquery-ui-1.10.3.custom.min.js?v=$AppVersion" type="text/javascript" ></script>');
document.write('<script src="/Scripts/plugins/popbox/jquery.popbox.js?v=$AppVersion" type="text/javascript" ></script>');

//下面这句注释请不要删除，在PMS站点启动时如果项目自定义 boot.js，将会自动将其注入到下面这个位置
//***<projects.boot.js>***//

//主页切换主题iframe内页同步更新
(function () {
    var changeFrameTheme = function (data) {
        var iframes = document.getElementsByTagName("iframe");
        for (var i = 0; i < iframes.length; i++) {
            try {
                iframes[i].contentWindow.postMessage(data, '*');
            } catch (ex) {
                console.log("the browser does not support postMessage!");
            }
        }
    };

    var messageHandler = function (event) {
        try {
            var data = event.data;
            if (data && data.action == "changeTheme" && data.theme) {
                var themeStyle = document.getElementById("global_theme");
                var themePath = themeStyle.getAttribute("href");
                themeStyle.setAttribute("href", themePath.replace(/\/\w+(\.\w+)?\.(.+)$/, "/" + data.theme + "$1.css"));
                changeFrameTheme({ action: "changeTheme", theme: data.theme });
            }
        } catch (ex) { }
    };

    if (window.addEventListener) {
        window.addEventListener("message", messageHandler, false);
    } else if (window.attachEvent) {
        window.attachEvent('onmessage', messageHandler);
    }
})();