﻿//当自定义页面没有PowerForm.Init，但js用mini.xx方法之前，必须mini.parse();大部分页面引用这个js，可以减少修改的问题
window.onload = function () {
    if (typeof (mini) == "object" && typeof (mini.parse) == "function")
        mini.parse();
};
//判断对象是否为数组
isArray = function (source) {
    return '[object Array]' == Object.prototype.toString.call(source);
};

var __bootReLogin = function () {

    var url = window.location.protocol + "//" + window.location.host;
    top.window.location.href = url;
}
//获取根路径，例如  http://12.3.4.5/powerpip/
function getRootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    return (prePath + postPath);
}
//获取当前日期 2013-01-02
function getdate() {
    var now = new Date();
    y = now.getFullYear();
    m = now.getMonth() + 1;
    d = now.getDate();
    m = m < 10 ? "0" + m : m;
    d = d < 10 ? "0" + d : d;
    return y + "-" + m + "-" + d;
}
//图片查看使用div层实现翻转-还原-关闭
var ImgTransform = {
    i: 1,
    //翻转
    Transform: function () {
        var d = 90 * ImgTransform.i;//每次翻转90°
        ImgTransform.i++;
        if (ImgTransform.i == 5)
            ImgTransform.i = 1;
        //以图片中心点翻转
        $("#bigimg").css({ "-webkit-transform": "rotate(" + d + "deg)", "transform": "rotate(" + d + "deg)", "transform-origin": "center center" });
        $("#bigimg").parent().parent().css({ "overflow-y": "auto" });
        //翻转后，如果图片高度\宽度大于外层div的高度、宽度，则缩小为一样
        //当第一次旋转、第三次旋转时（此时i已经+1了，所以是2、4），应该由宽度对比外层div的高度，图片高度对比外层div的宽度
        if (ImgTransform.i == 2 || ImgTransform.i == 4) {

            if ($("#bigimg").width() > $("#bigimg").parent().parent().height())
                $("#bigimg").css({ "width": "" + $("#bigimg").parent().parent().height() + "px" });
            if ($("#bigimg").height() > $("#bigimg").parent().parent().width())
                $("#bigimg").css({ "height": "" + $("#bigimg").parent().parent().width() + "px" });
        }
        else {
            if ($("#bigimg").width() > $("#bigimg").parent().parent().width())
                $("#bigimg").css({ "width": "" + $("#bigimg").parent().parent().width() + "px" });
            if ($("#bigimg").height() > $("#bigimg").parent().parent().height())
                $("#bigimg").css({ "height": "" + $("#bigimg").parent().parent().height() + "px" });
        }
        //$("#bigimg").css({ "-webkit-transform": "rotate(90deg)", "transform": "rotate(90deg) translate(0," + $("#bigimg").height() + "px)", "transform-origin": "bottom center" });
        //$("#bigimg").parent().css({"overflow": "auto"});
    },
    Close: function () {//关闭：即移除div
        $("#fileimgtopdiv").remove();
        $("#fileimgdiv").remove();
    },
    Restore: function () {
        //重置：即移除样式
        $("#bigimg").removeAttr("style");
        $("#bigimg").parent().css({ "vertical-align": "middle" });
    },
    Original: function (id) {
        //原图：即原有方式打开
        var url = "/PowerPlat/FormXml/FileViewer.aspx?online=1&fileid=" + id;
        window.open(url);
    }
}
// param 为 参数的名称,获取url 参数值，比如 http://12.3.4.5/powerpip/login.html?aa=bb&cc=dd,  aa/cc 为param ,bb/dd 为返回值,win为url打开的窗体(window/parent),默认是window,
function getParameter(param, win) {
    var wind = win && win != "" ? win : window;
    var query = wind.location.search;
    var iLen = param.length;
    var iStart = query.indexOf("&" + param + "=");
    if (iStart == -1) {
        iStart = query.indexOf("?" + param + "=");
        if (iStart == -1) return "";
    }
    iStart += iLen + 1 + 1;
    var iEnd = query.indexOf("&", iStart);
    if (iEnd == -1)
        return query.substring(iStart);

    return query.substring(iStart, iEnd);
}
//是否为空的Guid值 (为空则true,有值为false)
function IsNullGuid(value) {
    if (!value) return true;
    if (value == null || value == "") return true;
    if (value == "00000000-0000-0000-0000-000000000000") return true;
    return false;
}
//补了零的标准的guid格式（当然多了个“guid_”前缀,以及使用“_”代替“-”）。
function CreateGUID() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}
//判断一个值是否为空
function IsEmpty(value) {
    if (value == undefined) return true;
    if (value == null) return true;
    if (value == "") return true;
    if (value == "00000000-0000-0000-0000-000000000000") return true;
    return false;
}
//下面这段代码就是为你的功能而扩充的代码
function setCookie(name, value) {
    var Days = 300; //此 cookie 将被保存 30 天
    var exp = new Date();    //new Date("December 31, 9998");
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}
function getCookie(name) {
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) return unescape(arr[2]); return ""
}
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
}

function moveMessage() {
    $('#messageDIV').animate({ top: '0' }, 500, function () {
        //  $(this).css({ display: 'none', top: '-200px' });
        $(this).remove();
    });
}
function ShowMessage(msg) {
    var messageDiv = "<div id='messageDIV' class='MessageCss' style='position: absolute;'></div>";
    $(document.body).append(messageDiv);
    $('#messageDIV')[0].innerHTML = "<font color='red'>" + msg + "</font>";

    $('#messageDIV').css({ display: 'block', top: '200px' }).animate({ top: '+50' }, 2000, function () {
        setTimeout(moveMessage, 1000);
    });
}
//打开弹出窗体
function OpenWindow(url, openType, iWidth, iHeight) {
    if (!iWidth || parseInt(iWidth) < 1)
        iWidth = this.innerWidth * 0.75;
    if (!iHeight || parseInt(iHeight) < 1)
        iHeight = this.innerHeight * 0.75;

    var arg = "dialogWidth=" + iWidth + "px;dialogHeight=" + iHeight + "px;";

    switch (openType.toLowerCase()) {
        case "modal":
            if ((!iWidth || parseInt(iWidth) < 1) && (!iHeight || parseInt(iHeight) < 1)) {
                window.showModalDialog(url, ""); //, arg
            }
            else {
                window.showModalDialog(url, "", "dialogWidth=" + iWidth + "px;dialogHeight=" + iHeight + "px");
            }
            break;
        case "div":
            if ((!iWidth || parseInt(iWidth) < 1) && (!iHeight || parseInt(iHeight) < 1)) {
                mini.open({
                    url: url,
                    showMaxButton: true
                });
            }
            else {
                mini.open({
                    url: url,
                    width: iWidth,
                    height: iHeight,
                    showMaxButton: true
                });
            }
            break;
        case "tabs":
            window.open(url);
            break;
    }
}
//关闭弹出窗体,参数： 关闭前执行的方法
function ComToolsCloseWindow(action, preclose) {
    if (preclose != undefined) {
        if (!preclose())
            return;
    }
    if (window.CloseOwnerWindow) { //mini.open 的关闭方法    
        window.CloseOwnerWindow(action);
    }
    else {
        if (window.parent && window.parent.CloseOwnerWindow) //嵌套流程框的时候                
            window.parent.CloseOwnerWindow(action);
        else
            window.close();
    }
}

//获取url中的参数
function request(strParame, url) {
    var args = new Object();
    var query = "";
    if (!url)
        query = unescape(location.search.substring(1)); // Get query string
    else {
        var index = url.indexOf("?");
        query = url.substring(index + 1);
    }
    var pairs = query.split("&"); // Break at ampersand
    for (var i = 0; i < pairs.length; i++) {
        var pos = pairs[i].indexOf('='); // Look for "name=value"
        if (pos == -1) continue; // If not found, skip
        var argname = pairs[i].substring(0, pos); // Extract the name
        var value = pairs[i].substring(pos + 1); // Extract the value
        try {
            value = decodeURIComponent(value); // Decode it, if needed
        }
        catch (e) { }
        args[argname] = value; // Store as a property
    }
    return args[strParame]; // Return the object
}

var Base64 = {

    // private property
    _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",
    // public method for encoding
    encode: function (input) {
        var output = "";
        var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
        var i = 0;

        input = Base64._utf8_encode(input);

        while (i < input.length) {

            chr1 = input.charCodeAt(i++);
            chr2 = input.charCodeAt(i++);
            chr3 = input.charCodeAt(i++);

            enc1 = chr1 >> 2;
            enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
            enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
            enc4 = chr3 & 63;

            if (isNaN(chr2)) {
                enc3 = enc4 = 64;
            } else if (isNaN(chr3)) {
                enc4 = 64;
            }

            output = output +
			this._keyStr.charAt(enc1) + this._keyStr.charAt(enc2) +
			this._keyStr.charAt(enc3) + this._keyStr.charAt(enc4);

        }

        return output;
    },

    // public method for decoding
    decode: function (input) {
        var output = "";
        var chr1, chr2, chr3;
        var enc1, enc2, enc3, enc4;
        var i = 0;

        input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

        while (i < input.length) {

            enc1 = this._keyStr.indexOf(input.charAt(i++));
            enc2 = this._keyStr.indexOf(input.charAt(i++));
            enc3 = this._keyStr.indexOf(input.charAt(i++));
            enc4 = this._keyStr.indexOf(input.charAt(i++));

            chr1 = (enc1 << 2) | (enc2 >> 4);
            chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
            chr3 = ((enc3 & 3) << 6) | enc4;

            output = output + String.fromCharCode(chr1);

            if (enc3 != 64) {
                output = output + String.fromCharCode(chr2);
            }
            if (enc4 != 64) {
                output = output + String.fromCharCode(chr3);
            }

        }

        output = Base64._utf8_decode(output);

        return output;

    },

    // private method for UTF-8 encoding
    _utf8_encode: function (string) {
        string = string.replace(/\r\n/g, "\n");
        var utftext = "";

        for (var n = 0; n < string.length; n++) {

            var c = string.charCodeAt(n);

            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }

        }

        return utftext;
    },

    // private method for UTF-8 decoding
    _utf8_decode: function (utftext) {
        var string = "";
        var i = 0;
        var c = c1 = c2 = 0;

        while (i < utftext.length) {

            c = utftext.charCodeAt(i);

            if (c < 128) {
                string += String.fromCharCode(c);
                i++;
            }
            else if ((c > 191) && (c < 224)) {
                c2 = utftext.charCodeAt(i + 1);
                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                i += 2;
            }
            else {
                c2 = utftext.charCodeAt(i + 1);
                c3 = utftext.charCodeAt(i + 2);
                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                i += 3;
            }

        }

        return string;
    },

    rc4: function (data) {
        var key = "PowerM3";
        var seq = Array(256);//int
        var das = Array(data.length);//code of data
        for (var i = 0; i < 256; i++)
            seq[i] = i;
        var j = 0;
        for (var i = 0; i < 256; i++) {
            var j = (j + seq[i] + key.charCodeAt(i % key.length)) % 256;
            var temp = seq[i];
            seq[i] = seq[j];
            seq[j] = temp;
        }
        for (var i = 0; i < data.length; i++)
            das[i] = data.charCodeAt(i);
        for (var x = 0; x < das.length; x++) {
            var i = (i + 1) % 256;
            var j = (j + seq[i]) % 256;
            var temp = seq[i];
            seq[i] = seq[j];
            seq[j] = temp;
            var k = (seq[i] + seq[j]) % 256;
            das[x] = String.fromCharCode(das[x] ^ seq[k]);
        }
        return das.join('');
    }
}
//客户端Base64编码
function base64encode(str) {
    if (str == undefined || str.length == 0)
        return "";
    return Base64.encode(str);
}
//客户端Base64解码
function base64decode(str) {
    if (str == undefined || str.length == 0)
        return "";
    return Base64.decode(str);
}

function base64swhere(str) {
    if (str == undefined || str.length == 0)
        return "";
    return encodeURIComponent(Base64.rc4(str));
}

function strencrypt(str) {
    if (str == undefined || str.length == 0)
        return "";
    return Base64.encode(base64swhere(str));
}

//用Post方式向服务器提交数据
function postDataToServer(postUrl, data, type) {
    //$("#frmpostdata").remove();
    //$("#frmpopwin").remove();
    $("#postdatapanel").remove();
    var posthtml = [];
    posthtml.push("<div id='postdatapanel' style='display:none;'>");
    posthtml.push("<iframe name='frmpopwin' id='frmpopwin' style='display:none;width:0px;height:0px;'></iframe>");
    posthtml.push("<form id='frmpostdata' method='post' target='frmpopwin' action='" + postUrl + "'>");
    for (var k in data) {
        if (typeof (data[k]) != "function")
            posthtml.push("<textarea name='" + k + "'>" + data[k] + "</textarea>");
    }
    posthtml.push("</form>");
    posthtml.push("</div>");
    $("body").append(posthtml.join(""));
    if (type == "_blank")
        $("#frmpostdata")[0].target = "_blank";
    $("#frmpostdata")[0].submit();
}

//替换所有页面的标签，大小写统一,按照标签与格式相匹配直接替换
var replaceTempate = function (obj, jsonDatas) {
    var obj = $("#" + obj);
    //通用替换模版
    var template = obj.html();
    var content = "";
    for (var i = 0; i <= jsonDatas.length - 1; i++) {
        var a = template;

        for (var m in jsonDatas[i]) {
            var reg = new RegExp("\\$" + m + "\\$", "gim");
            var v = eval("jsonDatas[i]." + m);
            a = a.replace(reg, v);
        }
        content += a.replace("$loop$", (i + 1));
    }

    obj.html(content);
}

//将二维结构转为树成结构
function convert(source) {
    var tmp = {}, parent, parentList = [], n;
    for (n in source) {
        var item = source[n];
        if (item.ParentID == -1) {
            parentList.push(item.ID);
        }
        if (!tmp[item.ID]) {
            tmp[item.ID] = {};
        }
        tmp[item.ID].Name = item.Name;
        //tmp[item.ID].ID = item.ID;
        if (!("children" in tmp[item.ID])) tmp[item.ID].children = [];

        if (item.ID != item.ParentID) {
            if (tmp[item.ParentID]) {
                tmp[item.ParentID].children.push(tmp[item.ID]);
            }
            else {
                tmp[item.ParentID] = { children: [tmp[item.ID]] };
            }
        }
    }

    var result = [];
    for (var i = 0; i < parentList.length; i++) {
        result.push(tmp[parentList[i]]);
    }
    return result;
}
//获取当前可视区域高度
function getInnerHeight(t) {
    var win = (t == "top") ? top.window : window;
    return (win.innerHeight || (win.document.documentElement.clientHeight || win.document.body.clientHeight));
}
//获取当前可视区域长度
function getInnerWidth(t) {
    var win = (t == "top") ? top.window : window;
    var de = win.document.documentElement;
    return win.innerWidth || self.innerWidth || (de && de.clientWidth) || win.document.body.clientWidth;
}


//Ajax 访问数据集和业务对象，返回json
var getDataJson = function (jsonData, CallBackFun) {
    //jsonData  数组 
    //CallBackFun 回调函数名 将json对象返回		
    $.ajax({
        type: 'POST',
        url: '/Data/GetDataJson',
        data: { json: mini.encode(jsonData) },
        dataType: 'json',
        async: false,
        success: function (result) {
            var tmpData = mini.decode(result);
            if (tmpData.success == false) {
                alert(tmpData.message); return;
            }
            if (CallBackFun) CallBackFun(tmpData);
        },
        error: function (result, status) {
            alert(status);
            return;
        }
    })
};

var fomateDate = function (oDate, sFomate, bZone) {

    sFomate = sFomate.replace("YYYY", oDate.getFullYear());
    sFomate = sFomate.replace("YY", String(oDate.getFullYear()).substr(2))
    sFomate = sFomate.replace("MM", oDate.getMonth() + 1)
    sFomate = sFomate.replace("DD", oDate.getDate());
    sFomate = sFomate.replace("hh", oDate.getHours());
    sFomate = sFomate.replace("mm", oDate.getMinutes());
    sFomate = sFomate.replace("ss", oDate.getSeconds());
    if (bZone) sFomate = sFomate.replace(/\b(\d)\b/g, '0$1');
    return sFomate;
}
//string.Format()  http://www.cnblogs.com/loogn/archive/2011/06/20/2085165.html
String.prototype.format = function (args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
                    //var reg = new RegExp("({[" + i + "]})", "g");//这个在索引大于9时会有问题，谢谢何以笙箫的指出

                    var reg = new RegExp("({)" + i + "(})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
}


/** * 对Date的扩展，将 Date 转化为指定格式的String * 月(M)、日(d)、12小时(h)、24小时(H)、分(m)、秒(s)、周(E)、季度(q)
   可以用 1-2 个占位符 * 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) * eg: * (new
   Date()).pattern("yyyy-MM-dd hh:mm:ss.S")==> 2006-07-02 08:09:04.423      
* (new Date()).pattern("yyyy-MM-dd E HH:mm:ss") ==> 2009-03-10 二 20:09:04      
* (new Date()).pattern("yyyy-MM-dd EE hh:mm:ss") ==> 2009-03-10 周二 08:09:04      
* (new Date()).pattern("yyyy-MM-dd EEE hh:mm:ss") ==> 2009-03-10 星期二 08:09:04      
* (new Date()).pattern("yyyy-M-d h:m:s.S") ==> 2006-7-2 8:9:4.18      
*/

Date.prototype.format = function (fmt) {

    var o = {
        "M+": this.getMonth() + 1, //月份         
        "d+": this.getDate(), //日         
        "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //小时         
        "H+": this.getHours(), //小时         
        "m+": this.getMinutes(), //分         
        "s+": this.getSeconds(), //秒         
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度         
        "S": this.getMilliseconds() //毫秒         
    };
    var week = {
        "0": "/u65e5",
        "1": "/u4e00",
        "2": "/u4e8c",
        "3": "/u4e09",
        "4": "/u56db",
        "5": "/u4e94",
        "6": "/u516d"
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    if (/(E+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "/u5468") : "") + week[this.getDay() + ""]);
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}
//将普通的JSON 转为Echart 需要的格式
//[{q:1,act:50},{q:2,act:40}]
//ChartHelper.Convert(data,"q","act")

var ChartHelper = {
    //将标准的JSON 转换为 name,value 
    ConvertData: function (data, namefield, valuefield) {
        //data的格式如上的Result1，这种格式的数据，多用于饼图、单一的柱形图的数据源
        var categories = [];
        var datas = [];
        for (var i = 0; i < data.length; i++) {
            categories.push(data[i][namefield] || "");
            datas.push({ name: data[i][namefield], value: data[i][valuefield] || 0 });
        }
        return { category: categories, data: datas };
    },
    //待分组
    //多个柱子需要
    ConvertGroupData: function (data, type, is_stack, field) {
        field = $.extend(true, {
            namefield: "name",
            valuefield: "value",
            groupfield: "group"
        }, field);
        //data的格式如上的Result2，type为要渲染的图表类型：可以为line，bar，is_stack表示为是否是堆积图，这种格式的数据多用于展示多条折线图、分组的柱图
        var chart_type = 'line';
        if (type)
            chart_type = type || 'line';

        var xAxis = [];
        var group = [];
        var series = [];
        if (!data)
            data = [];
        for (var i = 0; i < data.length; i++) {
            for (var j = 0; j < xAxis.length && xAxis[j] != data[i][field.namefield]; j++);
            if (j == xAxis.length)
                xAxis.push(data[i][field.namefield]);

            for (var k = 0; k < group.length && group[k] != data[i][field.groupfield]; k++);
            if (k == group.length) {
                var _group = data[i][field.groupfield];
                group.push(_group);
            }
        }


        for (var i = 0; i < group.length; i++) {
            var temp = [];
            for (var j = 0; j < data.length; j++) {
                if (group[i] == data[j][field.groupfield]) {
                    if (type == "map") {
                        temp.push({ name: data[j][field.namefield], value: data[i][field.valuefield] });
                    } else {
                        temp.push(data[j][field.valuefield]);
                    }
                }

            }



            switch (type) {
                case 'bar':
                    var series_temp = { name: group[i], data: temp, type: chart_type };
                    if (is_stack)
                        series_temp = $.extend({}, { stack: 'stack' }, series_temp);
                    break;

                case 'map':
                    var series_temp = {
                        name: group[i], type: chart_type, mapType: 'china', selectedMode: 'single',
                        itemStyle: {
                            normal: { label: { show: true } },
                            emphasis: { label: { show: true } }
                        },
                        data: temp
                    };
                    break;

                case 'line':
                    var series_temp = { name: group[i], data: temp, type: chart_type };
                    if (is_stack)
                        series_temp = $.extend({}, { stack: 'stack' }, series_temp);
                    break;

                default:
                    var series_temp = { name: group[i], data: temp, type: chart_type };
            }
            series.push(series_temp);
        }
        if (group.length == 1 && !group[0])
            group[0] = "数量";
        return { category: group, xAxis: xAxis, series: series };
    }
}