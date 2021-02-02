var CoreEntlib = {
    GetInnerHeight: function () {
        var h = (window.innerHeight || (window.document.documentElement.clientHeight || window.document.body.clientHeight));
        return h;
    },
    //获取当前可视区域长度
    GetInnerWidth: function () {
        var de = document.documentElement;
        return window.innerWidth || self.innerWidth || (de && de.clientWidth) || document.body.clientWidth;
    }
}
var WorkflowDesigner = (function () {
    var obj = {
        PowerNodeToHtmlNode: function (node) {

            var baseAttr = node;
            var obj = $.extend({}, node);
            obj["type"] = "task";
            obj["name"] = baseAttr["title"];
            delete obj["title"];
            obj["left"] = parseInt(baseAttr.left);
            obj["top"] = parseInt(baseAttr.top);
            obj["width"] = 32;
            obj["height"] = 32;

            switch (baseAttr.nodetype) {
                case "StartNode":   //起草节点
                    obj["type"] = "start round";
                    break;
                case "GeneralNode":   //普通节点
                    obj["type"] = "GeneralNode";
                    obj["width"] = 100;
                    break;
                case "GeneralMultiNode":   //普通可选多人节点
                    obj["type"] = "GeneralMultiNode";
                    obj["width"] = 100;
                    break;
                case "EndNode":    //办结节点
                    obj["type"] = "end round";
                    break;
                case "ConcurrentNode":   //会签节点
                    obj["type"] = "ConcurrentNode";
                    obj["width"] = 100;
                    break;
                case "ConvergeNode":  //聚合节点
                    obj["type"] = "ConvergeNode";
                    obj["width"] = 100;
                    break;
            }
            return obj;
        },
        LoadWorkFlow: function (workFlowID, version, callback) {

            var data = {};
            data.WorkFlowID = WorkFlowID;
            data.Version = version;
            data.SubOperate = "ReadConfig";   //子指令集,保存选择的人员到指定节点中

            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = data;
            msg.data.FlowOperate = EFlowOperate.SupplyDesign;    //提取流程节点信息


            mini.mask({
                el: document.body,
                cls: 'mini-mask-loading',

                html: '加载中...'
            });
            $.ajax({
                type: "POST",
                url: "/API/APIMessage",
                data: { json: mini.encode(msg) },
                dataType: "json",
                success: function (data) {
                    mini.unmask(document.body);
                     
                    var tmpData = mini.decode(data);
                    if (tmpData.success == false) {
                        alert(tmpData.message);
                        return;
                    }

                    callback ? callback(tmpData.data.ResultInfo) : "";
                },
                error: function (e, r, h) {
                    alert(e.responseText, "错误！", "info");
                }
            });
        },

        //保存流程图
        SaveWorkFlow: function (WorkFlowMode, WorkFlowID, Version, textJSON) {

            var data = {};
            data.WorkFlowID = WorkFlowID;
            data.Version = Version;
            data.JsonInfo = textJSON;
            data.WorkFlowMode = WorkFlowMode;
            data.SubOperate = "SaveConfig";   //子指令集,保存选择的人员到指定节点中

            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = data;
            msg.data.FlowOperate = EFlowOperate.SupplyDesign;    //提取流程节点信息


            mini.mask({
                el: document.body,

                cls: 'mini-mask-loading',
                html: '加载中...'
            });
            $.ajax({
                type: "POST",
                url: "/API/APIMessage",
                data: { json: mini.encode(msg) },
                dataType: "json",
                success: function (data) {
                    mini.unmask(document.body);
                    var tmpData = mini.decode(data);
                    if (tmpData.success == false) {
                        alert(tmpData.message);
                        return;
                    }

                    if (tmpData.data.NewVersion != Version)  //如果返回的版本号和传入的版本号不一致，说明版本被更新了
                    {
                        CurrentVersion = tmpData.data.NewVersion;    //设置当前版本号
                    }
                    if (tmpData.data.Messages) {
                        Power.ui.info("保存成功:   " + tmpData.data.Messages);
                    }
                    else
                        Power.ui.info("保存成功");

                },
                error: function (e, r, h) {
                    alert(e.responseText, "错误！", "info");
                }
            });
        },

        //加载动态流程
        LoadWorkingFlow: function (workInfoID, callback) {

            var CurrentInfo = {};

            CurrentInfo.SubOperate = "ReadInstance";   //子指令集,保存选择的人员到指定节点中
            CurrentInfo.Current = {};
            CurrentInfo.Current.WorkInfoID = workInfoID;
            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = CurrentInfo;
            msg.data.FlowOperate = EFlowOperate.SupplyInstance;    //提取流程节点信息


            mini.mask({
                el: document.body,
                cls: 'mini-mask-loading',

                html: '加载中...'
            });
            $.ajax({
                type: "POST",
                url: "/API/APIMessage",
                data: { json: mini.encode(msg) },
                dataType: "json",
                success: function (data) {

                    mini.unmask(document.body);
                    var tmpData = mini.decode(data);
                    if (tmpData.success == false) {
                        alert(tmpData.message);
                        return;
                    }

                    callback ? callback(tmpData.data.ResultInfo) : "";
                },
                error: function (e, r, h) {
                    alert(e.responseText, "错误！", "info");
                }
            });
        },

        //保存动态流程
        SaveWorkingFlow: function (WorkFlowMode, WorkInfoID, textJSON) {

            var CurrentInfo = {};
            CurrentInfo.Current = {};
            CurrentInfo.Current.WorkInfoID = WorkInfoID;
            CurrentInfo.JsonInfo = textJSON;
            CurrentInfo.WorkFlowMode = WorkFlowMode;
            CurrentInfo.SubOperate = "SaveInstance";   //子指令集,保存选择的人员到指定节点中

            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = CurrentInfo;
            msg.data.FlowOperate = EFlowOperate.SupplyInstance;    //提取流程节点信息


            mini.mask({
                el: document.body,

                cls: 'mini-mask-loading',
                html: '加载中...'
            });
            $.ajax({
                type: "POST",
                url: "/API/APIMessage",
                data: { json: mini.encode(msg) },
                dataType: "json",
                success: function (data) {
                    mini.unmask(document.body);
                    var tmpData = mini.decode(data);
                    if (tmpData.success == false) {
                        alert(tmpData.message);
                        return;
                    }
                    if (tmpData.data.Messages) {
                        Power.ui.info("保存成功:   " + tmpData.data.Messages);
                    }
                    else
                        Power.ui.info("保存成功");
                },
                error: function (e, r, h) {
                    alert(e.responseText, "错误！", "info");
                }
            });
        },
        //保存流程图中绑定的标签,不会触发版本升级
        SaveWorkFlowBookMark: function (WorkFlowMode, WorkFlowID, Version, textJSON) {

            var data = {};
            data.WorkFlowID = WorkFlowID;
            data.Version = Version;
            data.JsonInfo = textJSON;
            data.WorkFlowMode = WorkFlowMode;
            data.SubOperate = "SaveConfigBookMark";   //子指令集,保存选择的人员到指定节点中

            var msg = {};
            msg.MessageCode = "Power.WorkFlows.Actions.RecvFlowOperate";
            msg.data = data;
            msg.data.FlowOperate = EFlowOperate.SupplyDesign;    //提取流程节点信息

            mini.mask({
                el: document.body,

                cls: 'mini-mask-loading',
                html: '加载中...'
            });
            $.ajax({
                type: "POST",
                url: "/API/APIMessage",
                data: { json: mini.encode(msg) },
                dataType: "json",
                success: function (data) {
                    mini.unmask(document.body);
                    var tmpData = mini.decode(data);
                    if (tmpData.success == false) {
                        alert(tmpData.message);
                        return;
                    }
                    if (tmpData.data.Messages) {
                        Power.ui.info("保存成功:   " + tmpData.data.Messages);
                    }
                    else
                        Power.ui.info("保存成功");
                },
                error: function (e, r, h) {
                    alert(e.responseText, "错误！", "info");
                }
            });
        },
        ShowPropertyWindow: function (obj) {

        }
    };
    return obj;
}());

/*	This work is licensed under Creative Commons GNU LGPL License.

License: http://creativecommons.org/licenses/LGPL/2.1/
Version: 0.9
Author:  Stefan Goessner/2006
Web:     http://goessner.net/ 
*/
function json2xml(o, tab) {
    var toXml = function (v, name, ind) {
        var xml = "";
        if (v instanceof Array) {
            for (var i = 0, n = v.length; i < n; i++)
                xml += ind + toXml(v[i], name, ind + "\t") + "\n";
        }
        else if (typeof (v) == "object") {
            var hasChild = false;
            xml += ind + "<" + name;
            for (var m in v) {
                if (m.charAt(0) == "@")
                    xml += " " + m.substr(1) + "=\"" + v[m].toString() + "\"";
                else
                    hasChild = true;
            }
            xml += hasChild ? ">" : "/>";
            if (hasChild) {
                for (var m in v) {
                    if (m == "#text")
                        xml += v[m];
                    else if (m == "#cdata")
                        xml += "<![CDATA[" + v[m] + "]]>";
                    else if (m.charAt(0) != "@")
                        xml += toXml(v[m], m, ind + "\t");
                }
                xml += (xml.charAt(xml.length - 1) == "\n" ? ind : "") + "</" + name + ">";
            }
        }
        else {
            xml += ind + "<" + name + ">" + v.toString() + "</" + name + ">";
        }
        return xml;
    }, xml = "";
    for (var m in o)
        xml += toXml(o[m], m, "");
    return tab ? xml.replace(/\t/g, tab) : xml.replace(/\t|\n/g, "");
}

/*	This work is licensed under Creative Commons GNU LGPL License.

License: http://creativecommons.org/licenses/LGPL/2.1/
Version: 0.9
Author:  Stefan Goessner/2006
Web:     http://goessner.net/ 
*/
function xml2json(xml, tab) {
    var X = {
        toObj: function (xml) {
            var o = {};
            if (xml.nodeType == 1) {   // element node ..
                if (xml.attributes.length)   // element with attributes  ..
                    for (var i = 0; i < xml.attributes.length; i++)
                        o["" + xml.attributes[i].nodeName] = (xml.attributes[i].nodeValue || "").toString();
                if (xml.firstChild) { // element has child nodes ..
                    var textChild = 0, cdataChild = 0, hasElementChild = false;
                    for (var n = xml.firstChild; n; n = n.nextSibling) {
                        if (n.nodeType == 1) hasElementChild = true;
                        else if (n.nodeType == 3 && n.nodeValue.match(/[^ \f\n\r\t\v]/)) textChild++; // non-whitespace text
                        else if (n.nodeType == 4) cdataChild++; // cdata section node
                    }
                    if (hasElementChild) {
                        if (textChild < 2 && cdataChild < 2) { // structured element with evtl. a single text or/and cdata node ..
                            X.removeWhite(xml);
                            for (var n = xml.firstChild; n; n = n.nextSibling) {
                                if (n.nodeType == 3)  // text node
                                    o["#text"] = X.escape(n.nodeValue);
                                else if (n.nodeType == 4)  // cdata node
                                    o["#cdata"] = X.escape(n.nodeValue);
                                else if (o[n.nodeName]) {  // multiple occurence of element ..
                                    if (o[n.nodeName] instanceof Array)
                                        o[n.nodeName][o[n.nodeName].length] = X.toObj(n);
                                    else
                                        o[n.nodeName] = [o[n.nodeName], X.toObj(n)];
                                }
                                else  // first occurence of element..
                                    o[n.nodeName] = X.toObj(n);
                            }
                        }
                        else { // mixed content
                            if (!xml.attributes.length)
                                o = X.escape(X.innerXml(xml));
                            else
                                o["#text"] = X.escape(X.innerXml(xml));
                        }
                    }
                    else if (textChild) { // pure text
                        if (!xml.attributes.length)
                            o = X.escape(X.innerXml(xml));
                        else
                            o["#text"] = X.escape(X.innerXml(xml));
                    }
                    else if (cdataChild) { // cdata
                        if (cdataChild > 1)
                            o = X.escape(X.innerXml(xml));
                        else
                            for (var n = xml.firstChild; n; n = n.nextSibling)
                                o["#cdata"] = X.escape(n.nodeValue);
                    }
                }
                if (!xml.attributes.length && !xml.firstChild) o = null;
            }
            else if (xml.nodeType == 9) { // document.node
                o = X.toObj(xml.documentElement);
            }
            else
                alert("unhandled node type: " + xml.nodeType);
            return o;
        },
        toJson: function (o, name, ind) {
            var json = name ? ("\"" + name + "\"") : "";
            if (o instanceof Array) {
                for (var i = 0, n = o.length; i < n; i++)
                    o[i] = X.toJson(o[i], "", ind + "\t");
                json += (name ? ":[" : "[") + (o.length > 1 ? ("\n" + ind + "\t" + o.join(",\n" + ind + "\t") + "\n" + ind) : o.join("")) + "]";
            }
            else if (o == null)
                json += (name && ":") + "null";
            else if (typeof (o) == "object") {
                var arr = [];
                for (var m in o)
                    arr[arr.length] = X.toJson(o[m], m, ind + "\t");
                json += (name ? ":{" : "{") + (arr.length > 1 ? ("\n" + ind + "\t" + arr.join(",\n" + ind + "\t") + "\n" + ind) : arr.join("")) + "}";
            }
            else if (typeof (o) == "string")
                json += (name && ":") + "\"" + o.toString() + "\"";
            else
                json += (name && ":") + o.toString();
            return json;
        },
        innerXml: function (node) {
            var s = ""
            if ("innerHTML" in node)
                s = node.innerHTML;
            else {
                var asXml = function (n) {
                    var s = "";
                    if (n.nodeType == 1) {
                        s += "<" + n.nodeName;
                        for (var i = 0; i < n.attributes.length; i++)
                            s += " " + n.attributes[i].nodeName + "=\"" + (n.attributes[i].nodeValue || "").toString() + "\"";
                        if (n.firstChild) {
                            s += ">";
                            for (var c = n.firstChild; c; c = c.nextSibling)
                                s += asXml(c);
                            s += "</" + n.nodeName + ">";
                        }
                        else
                            s += "/>";
                    }
                    else if (n.nodeType == 3)
                        s += n.nodeValue;
                    else if (n.nodeType == 4)
                        s += "<![CDATA[" + n.nodeValue + "]]>";
                    return s;
                };
                for (var c = node.firstChild; c; c = c.nextSibling)
                    s += asXml(c);
            }
            return s;
        },
        escape: function (txt) {
            return txt.replace(/[\\]/g, "\\\\")
                   .replace(/[\"]/g, '\\"')
                   .replace(/[\n]/g, '\\n')
                   .replace(/[\r]/g, '\\r');
        },
        removeWhite: function (e) {
            e.normalize();
            for (var n = e.firstChild; n;) {
                if (n.nodeType == 3) {  // text node
                    if (!n.nodeValue.match(/[^ \f\n\r\t\v]/)) { // pure whitespace text node
                        var nxt = n.nextSibling;
                        e.removeChild(n);
                        n = nxt;
                    }
                    else
                        n = n.nextSibling;
                }
                else if (n.nodeType == 1) {  // element node
                    X.removeWhite(n);
                    n = n.nextSibling;
                }
                else                      // any other node
                    n = n.nextSibling;
            }
            return e;
        }
    };
    if (xml.nodeType == 9) // document node
        xml = xml.documentElement;
    var json = X.toJson(X.toObj(X.removeWhite(xml)), xml.nodeName, "\t");
    return "{\n" + tab + (tab ? json.replace(/\t/g, tab) : json.replace(/\t|\n/g, "")) + "\n}";
}