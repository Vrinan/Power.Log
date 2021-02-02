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
            if (obj["DeptPositionInfo"] && obj["DeptPositionInfo"]["Item"]) {
                if ($.isArray(obj["DeptPositionInfo"]["Item"]))
                    obj["DeptPositionInfo"]["DeptPositionList"] = obj["DeptPositionInfo"]["Item"];
                else {
                    obj["DeptPositionInfo"]["DeptPositionList"] = [];
                    obj["DeptPositionInfo"]["DeptPositionList"].push(obj["DeptPositionInfo"]["Item"]);
                }
                delete obj["DeptPositionInfo"]["Item"];
            }
            if (obj["CopyDeptPositionInfo"] && obj["CopyDeptPositionInfo"]["Item"]) {
                if ($.isArray(obj["CopyDeptPositionInfo"]["DeptPositionList"])) {
                    obj["CopyDeptPositionInfo"]["DeptPositionList"] = obj["CopyDeptPositionInfo"]["Item"];
                }
                else {
                    obj["CopyDeptPositionInfo"]["DeptPositionList"] = [];
                    obj["CopyDeptPositionInfo"]["DeptPositionList"].push(obj["CopyDeptPositionInfo"]["Item"]);
                }
                delete obj["CopyDeptPositionInfo"]["Item"];
            }
            switch (baseAttr.nodetype) {
                case "StartNode":
                    obj["type"] = "start round";
                    break;
                case "GeneralNode":
                    obj["type"] = "GeneralNode";
                    obj["width"] = 100;
                    break;
                case "EndNode":
                    obj["type"] = "end round";
                    break;
                case "ConcurrentNode":
                    obj["type"] = "ConcurrentNode";
                    obj["width"] = 100;
                    break;
                case "ConvergeNode":
                    obj["type"] = "ConvergeNode";
                    obj["width"] = 100;
                    break;
            }
            return obj;
        },
        XmlToJson: function (xml) {
            xml = xml.replace(/modes/ig, "nodes");
            xml = xml.replace(/<mode/ig, "<node");
            xml = xml.replace(/\<\/mode>/ig, "</node>");
            var xmlObj = $.parseXML(xml);
            var json = $.parseJSON(xml2json(xmlObj, "")); //CoreEntlib.XmlToJson(xmlObj);
            if (!json["nodes"])
                return;
            if (json["nodes"] && json["nodes"]["line"])
                json["line"] = json["nodes"]["line"];
            if (json["nodes"] && json["nodes"]["line"])
                delete json["nodes"]["line"];
            var result = {
                title: "",
                nodes: {},
                lines: {}
            };
            for (var i = 0; i < json.nodes.node.length; i++) {
                var node = json.nodes.node[i];
                var obj = this.PowerNodeToHtmlNode(node);
                if (obj) {
                    result.nodes[obj.id] = obj;
                }
            }
            for (var i = 0; i < json.line.length; i++) {
                var line = json.line[i];
                if (!line)
                    continue;
                var baseAttr = line;
                var attr = line;
                attr["from"] = baseAttr["FromNode"];
                attr["to"] = baseAttr["ToNode"];
                attr["type"] = "sl";
                attr.name = (baseAttr.title || "");
                if (attr)
                    result.lines[baseAttr.id] = attr;
            }
            console.log(result);
            return result;
        },
        LoadWorkFlow: function (workFlowID, version, callback) {
            var result = false;
            $.ajax({
                type: "POST",
                url: "/WorkFlow/ReadConfigXml",
                data: { "workFlowID": workFlowID, "Version": version },
                dataType: "text",
                cache: false,
                success: function (data) {
                    var tmpData = $.parseJSON(data); //mini.decode(data);
                    callback ? callback(tmpData) : "";
                },
                error: function (e, r, h) {
                    if (Version == "10.10.10.10") { result = false; return; }
                    alert("消息", "错误！:" + e.responseText, "info");
                    result = false;
                }
            });
            return result;
        },
        SaveWorkFlow: function (WorkFlowMode, WorkFlowID, Version, textXml, textJSON) {
            var sUrl = "";
            if (!WorkFlowMode || WorkFlowMode == "")
                WorkFlowMode = "WorkFlowDesign";
            if (WorkFlowMode == "WorkFlowDesign")   //常规定义时
                sUrl = "/WorkFlow/SaveConfig";
            else if (WorkFlowMode == "WorkingDesign")   //流转定义时
                sUrl = "/WorkFlow/SaveConfigByWorking";
            $.ajax({
                type: "POST",
                url: sUrl,
                data: {
                    WorkFlowID: WorkFlowID,
                    Version: Version,
                    ConfigMode: "Json",
                    "Xml": Base64.encode(textJSON), // textXml, //escape( textXml),
                    Description: textJSON
                },
                success: function (data) {
                    var tmpData = mini.decode(data);
                    if (tmpData.success == false) {
                        alert(tmpData.message);
                        return;
                    }
                    if (tmpData.Version != Version)  //如果返回的版本号和传入的版本号不一致，说明版本被更新了
                    {
                        Version = tmpData.NewVersion;
                    }
                    alert("保存成功", data, "info");
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
} ());

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
            for (var n = e.firstChild; n; ) {
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