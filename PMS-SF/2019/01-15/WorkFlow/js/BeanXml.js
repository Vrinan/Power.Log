var ContextXML = com.xjwgraph.ContextXML = function () {}

ContextXML.prototype = {
	
	setAttribute : function (name, value) {
		this[name] = value;
	},
	
	view : function () {
	
		var self = this,
		
		contextDiv = document.createElement("div");
		
		for (var item in self) {
			
			if (item == "view" || 
					item == "setAttribute" || 
					item == "style" || 
					item == "modeIds") {
				continue;	
			}
			
			contextDiv.setAttribute(item, self[item]);
		
		}
		
		var global = com.xjwgraph.Global,
		tempModeTool = global.modeTool,
		tempBaseTool = global.baseTool,
		
		contextMap = tempBaseTool.contextMap,
		contextModeMap = new Map(),
		
		modeIds = self.modeIds.split(","),
		modeIdsLength = modeIds.length;
		
		for (var i = modeIdsLength; i--;) {
			var modeId = modeIds[i];
			contextModeMap.put(modeId, $id(modeId));
		}
		
		contextMap.put(self.id, contextModeMap);
		contextDiv.style.cssText = self.style;
		
		var tempBaseTool = global.baseTool;
		
		tempBaseTool.pathBody.appendChild(contextDiv);
		tempBaseTool.contextDivDrag(contextDiv, contextModeMap);
		
	}
	
}

var LineXML = com.xjwgraph.LineXML = function () {}

LineXML.prototype = {

    setAttribute: function (name, value) {
        this[name] = value;
    },

    view: function () {

        var self = this,
		global = com.xjwgraph.Global,
		tempLineTool = global.lineTool,

		line = tempLineTool.createBaseLine(self.id, self.d || self.path, self.brokenType),

		lineMode = new BuildLine();
        lineMode.id = line.id;

        line.style.cssText = self.style;
        line.setAttribute("strokeweight", self.strokeweight);
        line.setAttribute("strokecolor", self.strokecolor);
        line.setAttribute("brokenType", self.brokenType);

        var tempModeTool = global.modeTool,
				tempBeanXml = global.beanXml;

        if (self.xBaseMode) {

            var xDelay = function () {

                var xMode = global.modeMap.get(self.xBaseMode);

                lineMode.xBaseMode = xMode;
                lineMode.xIndex = self.xIndex;

                var modeLine = new BuildLine();
                modeLine.id = self.id;
                modeLine.type = true;
                modeLine.index = self.xIndex;

                xMode.lineMap.put(self.id + "-true", modeLine);

            }

            if (global.modeMap.get(self.xBaseMode)) {
                xDelay();
            } else {
                tempBeanXml.delay[tempBeanXml.delayIndex++] = xDelay;
            }

        }

        if (self.wBaseMode) {

            var yDelay = function () {

                var yMode = global.modeMap.get(self.wBaseMode);

                lineMode.wBaseMode = yMode;
                lineMode.wIndex = self.wIndex;
                if (self.title) lineMode.title = self.title;
                if (self.IsSingleLine) lineMode.IsSingleLine = self.IsSingleLine;
                if (self.BookMarkCode) lineMode.BookMarkCode = self.BookMarkCode;
                if (self.BookMarkName) lineMode.BookMarkCode = self.BookMarkName;

                if (self.SelectNodeMode) lineMode.SelectNodeMode = self.SelectNodeMode;

                if (self.ActiveType) {
                    lineMode.ActiveType = self.ActiveType;
                    lineMode.ActivePremise = self.ActivePremise;
                    lineMode.ActiveMero = self.ActiveMero; 
                }

                var modeLine = new BuildLine();
                modeLine.id = self.id;
                modeLine.type = false;
                modeLine.index = self.wIndex;


                yMode.lineMap.put(self.id + "-false", modeLine);

            }

            if (global.modeMap.get(self.wBaseMode)) {
                yDelay();
            } else {
                tempBeanXml.delay[tempBeanXml.delayIndex++] = yDelay;
            }

        }

        global.smallTool.drawLine(line);
        global.lineMap.put(lineMode.id, lineMode);

        tempLineTool.baseLineIdIndex = parseInt(self.id.substring(4)) + 1;

    }

}

var ModeXML = com.xjwgraph.ModeXML = function (iModeIndex) {

    var self = this,
	tempModeTool = com.xjwgraph.Global.modeTool;

    self.modeDiv = tempModeTool.createBaseMode(0, 0, "", "", iModeIndex, "40px", "40px");
   // self.borderDiv = tempModeTool.createBorder(iModeIndex);
    self.backImg = tempModeTool.getSonNode(self.modeDiv, "backImg");
    self.title = tempModeTool.getSonNode(self.modeDiv, "title");

}

ModeXML.prototype = {

    setAttribute: function (name, value) {

        var self = this;
        var pathGlobal = com.xjwgraph.PathGlobal;

        if (name == "backImgSrc") {
            self.backImg.src = pathGlobal.ImageRootPath + value;
        } else if (name == "top") {
            //   self.borderDiv.style.top = value + "px";
            self.modeDiv.style.top = value + "px";
        } else if (name == "left") {
            //   self.borderDiv.style.left = value + "px";
            self.modeDiv.style.left = value + "px";
        } else if (name == "width") {
            //  self.borderDiv.style.width = value + "px";
            self.modeDiv.style.width = value + "px";
            self.backImg.style.width = value + "px";
        } else if (name == "height") {
            //  self.borderDiv.style.height = value + "px";
            self.modeDiv.style.height = value + "px";
            self.backImg.style.height = value + "px";
        } else if (name == "id") {
            com.xjwgraph.Global.modeTool.setIndex(self.modeDiv, value);
        } else if (name == "title") {
            self.title.innerHTML = value;
        } else if (name == "zIndex") {
            // self.borderDiv.style.zIndex = value;
            self.modeDiv.style.zIndex = value;
        } else {
            self.modeDiv.setAttribute(name, value);
        }
    },
    getNodeInfo: function (node, nodeName) {
        var global = com.xjwgraph.Global;
        if (global.baseTool.isIE && global.baseTool.isGecko == false) //ie edge 模式 global.baseTool.isGecko=true
            return node.selectSingleNode(nodeName);
        else {
            if (node.children != undefined) {
                var len = node.children.length;
                for (var iTmp = 0; iTmp < len; iTmp++) {
                    if (node.children[iTmp].nodeName != nodeName) continue;
                    return node.children[iTmp];
                }
                return null;
            }
            else {
                var len = node.childElementCount;
                for (var iTmp = 0; iTmp < len; iTmp++) {
                    if (node.childNodes[iTmp].nodeName != nodeName) continue;
                    return node.childNodes[iTmp];
                }
                return null;
            }
        }
    },
    getNodeList: function (node, nodeName) {
        var global = com.xjwgraph.Global;
        if (global.baseTool.isIE && global.baseTool.isGecko == false) //ie edge 模式 global.baseTool.isGecko=true
            return node.selectNodes(nodeName);
        else {
            var arr = [];
            if (node.children != undefined) {
                var len = node.children.length;
                for (var iTmp = 0; iTmp < len; iTmp++) {
                    if (node.children[iTmp].nodeName != nodeName) continue;
                    arr.push(node.children[iTmp]);
                }
            }
            else {
                var len = node.childElementCount;
                for (var iTmp = 0; iTmp < len; iTmp++) {
                    if (node.childNodes[iTmp].nodeName != nodeName) continue;
                    arr.push(node.childNodes[iTmp]);
                }
            }
            return arr;
        }
    },
    setNodeConfig: function (node, moduleDiv) {
        var self = this;
        var advancedNode = self.getNodeInfo(node, "AdvancedInfo");
        if (advancedNode) {
            var AdvancedInfo = new Object();

            AdvancedInfo.IsSendLeader = advancedNode.getAttribute("IsSendLeader");
            AdvancedInfo.IsSendMail = advancedNode.getAttribute("IsSendMail");
            AdvancedInfo.IsSendMobile = advancedNode.getAttribute("IsSendMobile");
            AdvancedInfo.IsSendRTX = advancedNode.getAttribute("IsSendRTX");
            AdvancedInfo.IsMultiUser = advancedNode.getAttribute("IsMultiUser");
            AdvancedInfo.IsDisabledDelegate = advancedNode.getAttribute("IsDisabledDelegate");
            AdvancedInfo.IsDisabledStop = advancedNode.getAttribute("IsDisabledStop");

            
            AdvancedInfo.SelectNode = advancedNode.getAttribute("SelectNode");
            AdvancedInfo.UserType = advancedNode.getAttribute("UserType");
            moduleDiv.AdvancedInfo = AdvancedInfo;
        }

        var rightNode = self.getNodeInfo(node, "RightInfo");
        if (rightNode) {
            var RightInfo = new Object();
            RightInfo.RightList = [];
            var rightList = self.getNodeList(rightNode, "Item");
            for (var itmp = 0, len = rightList.length; itmp < len; itmp++) {
                var tmp = new Object();
                tmp.formId = rightList[itmp].getAttribute("formId");
                tmp.formName = rightList[itmp].getAttribute("formName");
                tmp.SelectRight = rightList[itmp].getAttribute("SelectRight");
                RightInfo.RightList.push(tmp);
            }
            moduleDiv.RightInfo = RightInfo;
        }

        var mindNode = self.getNodeInfo(node, "MindInfo");
        if (mindNode) {
            var MindInfo = new Object();
            MindInfo.IsMustInput = mindNode.getAttribute("IsMustInput");
            MindInfo.MindGroupCode = mindNode.getAttribute("MindGroupCode");
            moduleDiv.MindInfo = MindInfo;
        }

        // 用户部门
        var deptPositionNode = self.getNodeInfo(node, "DeptPositionInfo");
        if (deptPositionNode) {
            var DeptPositionInfo = new Object();
            DeptPositionInfo.SourceMode = deptPositionNode.getAttribute("SourceMode");
            DeptPositionInfo.SendUserMode = deptPositionNode.getAttribute("SendUserMode"); 
            DeptPositionInfo.DeptPositionMode = deptPositionNode.getAttribute("DeptPositionMode");
            var deptPositionList = self.getNodeList(deptPositionNode, "Item");
            DeptPositionInfo.DeptPositionList = [];
            for (var itmp = 0, len = deptPositionList.length; itmp < len; itmp++) {
                var tmp = new Object();
                tmp.DeptPositionID = deptPositionList[itmp].getAttribute("DeptPositionID");
                tmp.DeptPositionName = deptPositionList[itmp].getAttribute("DeptPositionName");
                tmp.UserList = [];

                DeptPositionInfo.DeptPositionList.push(tmp);

                var UserList = deptPositionList[itmp].getAttribute("UserList");
                var UserNameList = deptPositionList[itmp].getAttribute("UserNameList");
                if (!UserList) continue;
                var userList = UserList.split(",");
                var userNameList = UserNameList.split(",");
                for (var irow = 0; irow < userList.length; irow++) {
                    var tmpUser = new Object();
                    tmpUser.UserID = userList[irow];
                    tmpUser.UserName = userNameList[irow];
                    tmpUser.DeptPositionID = tmp.DeptPositionID;
                    tmpUser.Id = tmpUser.UserID + "_" + tmpUser.DeptPositionID;

                    tmp.UserList.push(tmpUser);
                }
            }
            
            var specialList = self.getNodeList(deptPositionNode, "SpecialItem");
            DeptPositionInfo.SpecialList = [];
            for (var itmp = 0, len = specialList.length; itmp < len; itmp++) {
                var tmp = new Object();
                tmp.BaseID = specialList[itmp].getAttribute("BaseID");
                tmp.BaseName = specialList[itmp].getAttribute("BaseName");
                tmp.ParentType = specialList[itmp].getAttribute("ParentType");
                tmp.ParentTypeName = specialList[itmp].getAttribute("ParentTypeName");
                tmp.UseParent = specialList[itmp].getAttribute("UseParent");
                DeptPositionInfo.SpecialList.push(tmp);
            }

            moduleDiv.DeptPositionInfo = DeptPositionInfo;
        }

        //抄送信息
        var copyDeptPositionNode = self.getNodeInfo(node, "CopyDeptPositionInfo");
        if (copyDeptPositionNode) {
            var copyDeptPositionInfo = new Object();
            copyDeptPositionInfo.SourceMode = copyDeptPositionNode.getAttribute("SourceMode");
            copyDeptPositionInfo.SendUserMode = copyDeptPositionNode.getAttribute("SendUserMode"); 
            copyDeptPositionInfo.DeptPositionMode = copyDeptPositionNode.getAttribute("DeptPositionMode");
            var copyDeptPositionList = self.getNodeList(copyDeptPositionNode, "Item");
            copyDeptPositionInfo.DeptPositionList = [];
            for (var itmp = 0, len = copyDeptPositionList.length; itmp < len; itmp++) {
                var tmp = new Object();
                tmp.DeptPositionID = copyDeptPositionList[itmp].getAttribute("DeptPositionID");
                tmp.DeptPositionName = copyDeptPositionList[itmp].getAttribute("DeptPositionName");
                tmp.UserList = [];

                copyDeptPositionInfo.DeptPositionList.push(tmp);

                var UserList = copyDeptPositionList[itmp].getAttribute("UserList");
                var UserNameList = copyDeptPositionList[itmp].getAttribute("UserNameList");
                if (!UserList) continue;
                var userList = UserList.split(",");
                var userNameList = UserNameList.split(",");
                for (var irow = 0; irow < userList.length; irow++) {
                    var tmpUser = new Object();
                    tmpUser.UserID = userList[irow];
                    tmpUser.UserName = userNameList[irow];
                    tmpUser.DeptPositionID = tmp.DeptPositionID;
                    tmpUser.Id = tmpUser.UserID + "_" + tmpUser.DeptPositionID;

                    tmp.UserList.push(tmpUser);
                }
            }
            
            var copySpecialList = self.getNodeList(copyDeptPositionNode, "SpecialItem");
            copyDeptPositionInfo.SpecialList = [];
            for (var itmp = 0, len = copySpecialList.length; itmp < len; itmp++) {
                var tmp = new Object();
                tmp.BaseID = copySpecialList[itmp].getAttribute("BaseID");
                tmp.BaseName = copySpecialList[itmp].getAttribute("BaseName");
                tmp.ParentType = copySpecialList[itmp].getAttribute("ParentType");
                tmp.ParentTypeName = copySpecialList[itmp].getAttribute("ParentTypeName");
                tmp.UseParent = copySpecialList[itmp].getAttribute("UseParent");
                copyDeptPositionInfo.SpecialList.push(tmp);
            }
            moduleDiv.CopyDeptPositionInfo = copyDeptPositionInfo;
        }

        //投票设置
        var voteNode = self.getNodeInfo(node, "VoteInfo");
        if (voteNode) {
            var VoteInfo = {};
            VoteInfo.IsTurnVote = voteNode.getAttribute("IsTurnVote");
            VoteInfo.VoteType = voteNode.getAttribute("VoteType");
            VoteInfo.DefaultVoteValue = voteNode.getAttribute("DefaultVoteValue");
            VoteInfo.VoteList = [];
            var voteList = self.getNodeList(voteNode, "Item");
            for (var itmp = 0, len = voteList.length; itmp < len; itmp++) {
                var tmp = {};
                tmp.VoteCode = voteList[itmp].getAttribute("VoteCode");
                tmp.VoteName = voteList[itmp].getAttribute("VoteName");
                tmp.Description = voteList[itmp].getAttribute("Description");
                if (!tmp.Description) tmp.Description = "";
                VoteInfo.VoteList.push(tmp);
            }
            moduleDiv.VoteInfo = VoteInfo;
        }

        if (node.getAttribute("NodeType") == "SubNode") {
            var subInfo = self.getNodeInfo(node, "SubInfo");
            if (subInfo) {
                var SubInfo = {};
                SubInfo.IsSingle = subInfo.getAttribute("IsSingle");
                SubInfo.IsAsync = subInfo.getAttribute("IsAsync");
                SubInfo.IsCreateNew = subInfo.getAttribute("IsCreateNew");
                SubInfo.IsMultiUser = subInfo.getAttribute("IsMultiUser");
                
                SubInfo.FormId = subInfo.getAttribute("FormId");
                SubInfo.FormName = subInfo.getAttribute("FormName");
                SubInfo.KeyWord = subInfo.getAttribute("KeyWord");
                SubInfo.Content = "";
                var tmpContent = self.getNodeInfo(subInfo, "Content");
                if (tmpContent != null) SubInfo.Content = tmpContent.innerHTML;
               
                var propertyMapping = self.getNodeList(subInfo, "Item");
                SubInfo.PropertyMapping = [];
                for (var itmp = 0, len = propertyMapping.length; itmp < len; itmp++) {
                    var tmp = new Object();
                    tmp.ParentProperty = propertyMapping[itmp].getAttribute("ParentProperty");
                    tmp.SubProperty = propertyMapping[itmp].getAttribute("SubProperty");
                    SubInfo.PropertyMapping.push(tmp);
                }

                moduleDiv.SubInfo = SubInfo;
            }
        }
        var nodeConfig = self.getNodeInfo(node, "NodeConfig");
        if (nodeConfig) {
            var NodeConfig = {};
            NodeConfig.NodePassMode = nodeConfig.getAttribute("NodePassMode");
            NodeConfig.CustomPassValue = nodeConfig.getAttribute("CustomPassValue");
            NodeConfig.SelectUserMode = nodeConfig.getAttribute("SelectUserMode");
            moduleDiv.NodeConfig = NodeConfig;
        }
    },


    view: function (node) {
        var self = this;
        var mode = new BaseMode(),
		moduleDiv = this.modeDiv;
        //var borderDiv = this.borderDiv;

        global = com.xjwgraph.Global,

		tempModeTool = global.modeTool;
        tempModeTool.pathBody.appendChild(moduleDiv);

        //    tempModeTool.pathBody.appendChild(borderDiv);

        var modeIndex = tempModeTool.getModeIndex(moduleDiv);

        mode.id = moduleDiv.id;
        debugger;
        if (node.getAttribute("Description")) mode.Description = node.getAttribute("Description");
        if (node.getAttribute("ReturnMode")) mode.ReturnMode = node.getAttribute("ReturnMode");
        if (node.getAttribute("LimitDays")) mode.LimitDays = node.getAttribute("LimitDays");
        if (node.getAttribute("SerialNo")) mode.SerialNo = node.getAttribute("SerialNo");
        if (node.getAttribute("BookMarkCode")) mode.BookMarkCode = node.getAttribute("BookMarkCode");
        if (node.getAttribute("BookMarkName")) mode.BookMarkName = node.getAttribute("BookMarkName");

        if (node.getAttribute("SelectNodeMode")) mode.SelectNodeMode = node.getAttribute("SelectNodeMode");

        if (node.getAttribute("IsSign")) mode.IsSign = node.getAttribute("IsSign");

        self.setNodeConfig(node, moduleDiv);




        global.modeMap.put(mode.id, mode);

        tempModeTool.initEvent(modeIndex);
        if (global.WorkFlowMode == "WorkFlowDesign" || global.WorkFlowMode == "WorkingDesign") tempModeTool.showPointerId(modeIndex);

        global.smallTool.drawMode(moduleDiv);

        tempModeTool.baseModeIdIndex = parseInt(modeIndex) + 1;

    }

}

var BeanXML = com.xjwgraph.BeanXML = function () {
	
	var self = this;
	
	self.delay = [];
	self.delayIndex = 0;
	self.doc = null;
	self.create();
	self.root = self.initBeanXML();
	
}

BeanXML.prototype = {

    create: function () {

        var self = this;
        self.doc = null;

        if (document.all) {

            var xmlVersions = ["Msxml2.DOMDocument.6.0",
												 "Msxml2.DOMDocument.5.0",
												 "Msxml2.DOMDocument.4.0",
												 "Msxml2.DOMDocument.3.0",
												 "MSXML2.DOMDocument",
												 "MSXML.DOMDocument",
												 "Microsoft.XMLDOM"];

            var xmlVersionLength = xmlVersions.length;

            for (var i = xmlVersionLength; i--; ) {

                try {
                    self.doc = new ActiveXObject(xmlVersions[i]);
                    break;
                } catch (err) {
                    continue;
                }

            }

        } else {
            self.doc = document.implementation.createDocument('', '', null);
        }

    },

    initBeanXML: function () {

        var self = this,

		headFile = self.doc.createProcessingInstruction("xml", "version='1.0' encoding='utf8'");
        self.doc.appendChild(headFile);

        var root = self.doc.createElement("modes");
        self.doc.appendChild(root);

        return root;

    },

    getNodeAttribute: function (iNode) {

        var nodeText = [],
		k = 0,

		attributes = iNode.attributes,
		attributesLength = attributes.length;

        for (var i = attributesLength; i--; ) {

            var attribute = attributes[i];

            nodeText[k++] = " ";
            nodeText[k++] = attribute.nodeName;
            nodeText[k++] = "=\"";
            nodeText[k++] = attribute.nodeValue;
            nodeText[k++] = "\"";

        }

        return nodeText.join("");

    },

    getText: function (iNode, isTitle) {

        var nodeText = [],
		k = 0,

		self = this;

        if (isTitle) {

            nodeText[k++] = "<";
            nodeText[k++] = iNode.nodeName;

        }

        var childNodes = iNode.childNodes,
		childNodesLength = childNodes.length;

        for (var i = childNodesLength; i--; ) {

            var node = childNodes[i];

            nodeText[k++] = "<";
            nodeText[k++] = node.nodeName;

            if (node.nodeType == 1) {
                nodeText[k++] = self.getNodeAttribute(node);
            }

            nodeText[k++] = ">";

            if (node.hasChildNodes()) {
                nodeText[k++] = self.getText(node, false);
            }

            nodeText[k++] = "</";
            nodeText[k++] = node.nodeName;
            nodeText[k++] = ">";

        }

        if (isTitle) {

            nodeText[k++] = "</";
            nodeText[k++] = iNode.nodeName;
            nodeText[k++] = ">";

        }

        return nodeText.join("");

    },

    createNode: function (type, fNode) {

        var self = this,

		node = self.doc.createElement(type);

        if (fNode) {
            fNode.appendChild(node);
        } else {
            self.root.appendChild(node);
        }
        return node;

    },

    clearNode: function () {

        var self = this;

        if (self.root) {

            var childNodes = self.root.childNodes,
			childNodesLength = childNodes.length;

            for (var i = childNodesLength; i--; ) {

                self.root.removeChild(childNodes[i]);

            }

        }

    },

    getNodeConfig: function (mode, node) {
        var self = this;
        //高级配置
        if (mode.AdvancedInfo) {
            var advancedElement = self.doc.createElement("AdvancedInfo");
            advancedElement.setAttribute("IsSendLeader", mode.AdvancedInfo.IsSendLeader);
            advancedElement.setAttribute("IsSendMail", mode.AdvancedInfo.IsSendMail);
            advancedElement.setAttribute("IsSendMobile", mode.AdvancedInfo.IsSendMobile); 
            advancedElement.setAttribute("IsSendRTX", mode.AdvancedInfo.IsSendRTX);
            advancedElement.setAttribute("IsMultiUser", mode.AdvancedInfo.IsMultiUser);
            advancedElement.setAttribute("IsDisabledDelegate", mode.AdvancedInfo.IsDisabledDelegate);
            advancedElement.setAttribute("IsDisabledStop", mode.AdvancedInfo.IsDisabledStop);
            
            advancedElement.setAttribute("SelectNode", mode.AdvancedInfo.SelectNode);
            advancedElement.setAttribute("UserType", mode.AdvancedInfo.UserType);
            node.appendChild(advancedElement);
        }
        //权限定义域 
        if (mode.RightInfo) {
            var rightElement = self.doc.createElement("RightInfo");
            for (var itmp = 0, len = mode.RightInfo.RightList.length; itmp < len; itmp++) {
                var item = self.doc.createElement("Item");
                item.setAttribute("formId", mode.RightInfo.RightList[itmp].formId);
                item.setAttribute("formName", mode.RightInfo.RightList[itmp].formName);
                item.setAttribute("SelectRight", mode.RightInfo.RightList[itmp].SelectRight);
                rightElement.appendChild(item);
            }
            node.appendChild(rightElement);
        }


        if (mode.MindInfo) {
            var mindElement = self.doc.createElement("MindInfo");
            mindElement.setAttribute("IsMustInput", mode.MindInfo.IsMustInput);
            mindElement.setAttribute("MindGroupCode", mode.MindInfo.MindGroupCode);
            node.appendChild(mindElement);
        }

        //如果有部门定义信息
        if (mode.DeptPositionInfo) {
            var deptPositionElement = self.doc.createElement("DeptPositionInfo");
            deptPositionElement.setAttribute("DeptPositionMode", mode.DeptPositionInfo.DeptPositionMode);
            deptPositionElement.setAttribute("SourceMode", mode.DeptPositionInfo.SourceMode);
            if (!mode.DeptPositionInfo.SendUserMode) mode.DeptPositionInfo.SendUserMode = "Normal";
            deptPositionElement.setAttribute("SendUserMode", mode.DeptPositionInfo.SendUserMode);
          
            for (var itmp = 0, len = mode.DeptPositionInfo.DeptPositionList.length; itmp < len; itmp++) {
                var item = self.doc.createElement("Item");
                item.setAttribute("DeptPositionID", mode.DeptPositionInfo.DeptPositionList[itmp].DeptPositionID);
                item.setAttribute("DeptPositionName", mode.DeptPositionInfo.DeptPositionList[itmp].DeptPositionName);

                if (mode.DeptPositionInfo.DeptPositionMode == "DesignUser") {
                    var userList = "";
                    var userNameList = "";
                    for (var iRow = 0, userlen = mode.DeptPositionInfo.DeptPositionList[itmp].UserList.length; iRow < userlen; iRow++) {
                        userList += mode.DeptPositionInfo.DeptPositionList[itmp].UserList[iRow].UserID + ",";
                        userNameList += mode.DeptPositionInfo.DeptPositionList[itmp].UserList[iRow].UserName + ",";
                    }
                    item.setAttribute("UserList", userList);
                    item.setAttribute("UserNameList", userNameList);
                }
                deptPositionElement.appendChild(item);
            }
            
            for (var itmp = 0, len = mode.DeptPositionInfo.SpecialList.length; itmp < len; itmp++) {
                var item = self.doc.createElement("SpecialItem");
                item.setAttribute("BaseID", mode.DeptPositionInfo.SpecialList[itmp].BaseID);
                item.setAttribute("BaseName", mode.DeptPositionInfo.SpecialList[itmp].BaseName);
                item.setAttribute("ParentType", mode.DeptPositionInfo.SpecialList[itmp].ParentType); 
                item.setAttribute("ParentTypeName", mode.DeptPositionInfo.SpecialList[itmp].ParentTypeName);
                item.setAttribute("UseParent", mode.DeptPositionInfo.SpecialList[itmp].UseParent); 
                deptPositionElement.appendChild(item);
            }

            node.appendChild(deptPositionElement);
        }


        //抄送信息
        if (mode.CopyDeptPositionInfo) {
            var copyDeptPositionElement = self.doc.createElement("CopyDeptPositionInfo");
            copyDeptPositionElement.setAttribute("DeptPositionMode", mode.CopyDeptPositionInfo.DeptPositionMode);
            copyDeptPositionElement.setAttribute("SourceMode", mode.CopyDeptPositionInfo.SourceMode);
            if (!mode.CopyDeptPositionInfo.SendUserMode) mode.CopyDeptPositionInfo.SendUserMode = "Normal";
            copyDeptPositionElement.setAttribute("SendUserMode", mode.CopyDeptPositionInfo.SendUserMode);
            
            for (var itmp = 0, len = mode.CopyDeptPositionInfo.DeptPositionList.length; itmp < len; itmp++) {

                var item = self.doc.createElement("Item");
                item.setAttribute("DeptPositionID", mode.CopyDeptPositionInfo.DeptPositionList[itmp].DeptPositionID);
                item.setAttribute("DeptPositionName", mode.CopyDeptPositionInfo.DeptPositionList[itmp].DeptPositionName);

                if (mode.CopyDeptPositionInfo.DeptPositionMode == "DesignUser") {
                    var userList = "";
                    var userNameList = "";
                    for (var iRow = 0, userlen = mode.CopyDeptPositionInfo.DeptPositionList[itmp].UserList.length; iRow < userlen; iRow++) {
                        userList += mode.CopyDeptPositionInfo.DeptPositionList[itmp].UserList[iRow].UserID + ",";
                        userNameList += mode.CopyDeptPositionInfo.DeptPositionList[itmp].UserList[iRow].UserName + ",";
                    }
                    item.setAttribute("UserList", userList);
                    item.setAttribute("UserNameList", userNameList);
                }
                copyDeptPositionElement.appendChild(item);
            }
             
            for (var itmp = 0, len = mode.CopyDeptPositionInfo.SpecialList.length; itmp < len; itmp++) {
                var item = self.doc.createElement("SpecialItem");
                item.setAttribute("BaseID", mode.CopyDeptPositionInfo.SpecialList[itmp].BaseID);
                item.setAttribute("BaseName", mode.CopyDeptPositionInfo.SpecialList[itmp].BaseName);
                item.setAttribute("ParentType", mode.CopyDeptPositionInfo.SpecialList[itmp].ParentType);
                item.setAttribute("ParentTypeName", mode.CopyDeptPositionInfo.SpecialList[itmp].ParentTypeName);
                item.setAttribute("UseParent", mode.CopyDeptPositionInfo.SpecialList[itmp].UseParent);
                copyDeptPositionElement.appendChild(item);
            }
            node.appendChild(copyDeptPositionElement);
        }

        //投票设置
        if (mode.VoteInfo) {
            var voteElement = self.doc.createElement("VoteInfo");
            voteElement.setAttribute("IsTurnVote", mode.VoteInfo.IsTurnVote);
            voteElement.setAttribute("VoteType", mode.VoteInfo.VoteType);
            voteElement.setAttribute("DefaultVoteValue", mode.VoteInfo.DefaultVoteValue);

            for (var itmp = 0, len = mode.VoteInfo.VoteList.length; itmp < len; itmp++) {

                var item = self.doc.createElement("Item");
                item.setAttribute("VoteCode", mode.VoteInfo.VoteList[itmp].VoteCode);
                item.setAttribute("VoteName", mode.VoteInfo.VoteList[itmp].VoteName);
                var description = mode.VoteInfo.VoteList[itmp].Description;
                if (!description) description = "";
                item.setAttribute("Description", description);
                voteElement.appendChild(item);
            }
            node.appendChild(voteElement);
        }


        if (node.getAttribute("NodeType") == "SubNode") {
            //高级配置
            if (mode.SubInfo) {
                var subInfoElement = self.doc.createElement("SubInfo");
                subInfoElement.setAttribute("IsSingle", mode.SubInfo.IsSingle);
                subInfoElement.setAttribute("IsAsync", mode.SubInfo.IsAsync);
                subInfoElement.setAttribute("IsCreateNew", mode.SubInfo.IsCreateNew);
                subInfoElement.setAttribute("IsMultiUser", mode.SubInfo.IsMultiUser);               
                subInfoElement.setAttribute("FormId", mode.SubInfo.FormId);
                subInfoElement.setAttribute("FormName", mode.SubInfo.FormName);
                subInfoElement.setAttribute("KeyWord", mode.SubInfo.KeyWord);
                
                var tmpContent = self.doc.createElement("Content");
                tmpContent.setAttribute("bbb", "bbbdb");
                tmpContent.value = mode.SubInfo.Content;
                subInfoElement.appendChild(tmpContent);
                for (var itmp = 0, len = mode.SubInfo.PropertyMapping.length; itmp < len; itmp++) {

                    var item = self.doc.createElement("Item");
                    item.setAttribute("ParentProperty", mode.SubInfo.PropertyMapping[itmp].ParentProperty);
                    item.setAttribute("SubProperty", mode.SubInfo.PropertyMapping[itmp].SubProperty);
                    subInfoElement.appendChild(item);
                }
                node.appendChild(subInfoElement);
            }
        }

        if (mode.NodeConfig) {
            var nodeConfigElement = self.doc.createElement("NodeConfig");
            nodeConfigElement.setAttribute("NodePassMode", mode.NodeConfig.NodePassMode);
            nodeConfigElement.setAttribute("CustomPassValue", mode.NodeConfig.CustomPassValue);
            if (mode.NodeConfig.SelectUserMode) nodeConfigElement.setAttribute("SelectUserMode", mode.NodeConfig.SelectUserMode);
            node.appendChild(nodeConfigElement);
        }


    },
    toXML: function () {

        var self = this;
        self.clearNode();

        var global = com.xjwgraph.Global,

		tempBaseTool = global.baseTool,
		contextMap = tempBaseTool.contextMap;

        tempBaseTool.forEach(contextMap, function (contextId) {

            var node = self.createNode("context"),
			context = $id(contextId),

			attributes = context.attributes,
			attributeLength = attributes.length;

            for (var i = attributeLength; i--; ) {

                var attribute = attributes[i];

                if (attribute.nodeValue) {
                    node.setAttribute(attribute.name, attribute.nodeValue);
                }

            }

            node.setAttribute("style", context.style.cssText);

            var contextModeMap = contextMap.get(contextId),
			contextModeMapKeys = contextModeMap.getKeys(),
			contextModeMapKeyLength = contextModeMapKeys.length,
			modeIds = [],
			index = 0;

            for (var i = contextModeMapKeyLength; i--; ) {
                modeIds[index++] = contextModeMapKeys[i];
            }

            node.setAttribute("modeIds", modeIds.join(","));

        });

        tempBaseTool.forEach(global.modeMap, function (modeId) {

            var mode = $id(modeId),
			modeStyle = mode.style,
			attributes = mode.attributes,
			attributeLength = attributes.length,
			node = self.createNode("mode");

            for (var i = attributeLength; i--; ) {

                var attribute = attributes[i];

                if (attribute.name == 'style' ||
							attribute.name == 'id') {
                    continue;
                }

                if (attribute.nodeValue) {
                    node.setAttribute(attribute.name, attribute.nodeValue);
                }
            }



            var modeIndex = global.modeTool.getModeIndex(mode);
            node.setAttribute("id", modeIndex);

            var title = $id("title" + modeIndex).innerHTML;
            node.setAttribute("title", title);

            var backImg = $id("backImg" + modeIndex),
			backImgSrc = Utils.GetFileName(backImg.src);


            node.setAttribute("backImgSrc", backImgSrc);
            node.setAttribute("top", parseInt(modeStyle.top));
            node.setAttribute("left", parseInt(modeStyle.left));
            node.setAttribute("zIndex", parseInt(modeStyle.zIndex));
            node.setAttribute("width", parseInt(backImg.offsetWidth));
            node.setAttribute("height", parseInt(backImg.offsetHeight));
            debugger;
            if (mode.Description) node.setAttribute("Description", mode.Description);
            if (mode.LimitDays) node.setAttribute("LimitDays", mode.LimitDays);
            if (mode.ReturnMode) node.setAttribute("ReturnMode", mode.ReturnMode);
            if (mode.SerialNo) node.setAttribute("SerialNo", mode.SerialNo);
            if (mode.BookMarkCode) node.setAttribute("BookMarkCode", mode.BookMarkCode);
            if (mode.BookMarkName) node.setAttribute("BookMarkName", mode.BookMarkName);

            if (mode.SelectNodeMode) node.setAttribute("SelectNodeMode", mode.SelectNodeMode);
            if (mode.IsSign) node.setAttribute("IsSign", mode.IsSign);

            self.getNodeConfig(mode, node);


        });

        tempBaseTool.forEach(global.lineMap, function (lineId) {

            var line = $id(lineId),

			node = self.createNode("line"),
			attributes = line.attributes,
			attributeLength = attributes.length,
			lineStyle = line.style;

            var strokeweight = line.getAttribute("strokeweight"),
					strokecolor = line.getAttribute("strokecolor");

            node.setAttribute("strokeweight", strokeweight || lineStyle.strokeWidth);
            node.setAttribute("strokecolor", strokecolor || lineStyle.stroke);

            for (var i = attributeLength; i--; ) {

                var attribute = attributes[i];

                if (attribute.name == 'style' ||
						attribute.name == 'marker-end') {
                    continue;
                }

                if (attribute.nodeValue) {
                    node.setAttribute(attribute.name, attribute.nodeValue);
                }

            }

            var cssText = lineStyle.strokeWidth ? '' : ';fill: none; stroke: ' + strokecolor + '; stroke-width: ' + (strokeweight + 0.45);

            node.setAttribute("style", lineStyle.cssText + cssText);
            node.setAttribute("marker-end", "url(#arrow)");

            var buildLine = global.lineMap.get(line.id);
            if (buildLine.xBaseMode) node.setAttribute("FromNode", buildLine.xBaseMode.id.replace("module", ""));
            if (buildLine.wBaseMode) node.setAttribute("ToNode", buildLine.wBaseMode.id.replace("module", ""));

            if (buildLine.title) node.setAttribute("title", buildLine.title);
            if (buildLine.IsSingleLine) node.setAttribute("IsSingleLine", buildLine.IsSingleLine);
            if (buildLine.BookMarkCode) node.setAttribute("BookMarkCode", buildLine.BookMarkCode);
            if (buildLine.BookMarkName) node.setAttribute("BookMarkName", buildLine.BookMarkName);

            if (buildLine.SelectNodeMode) node.setAttribute("SelectNodeMode", buildLine.SelectNodeMode);
            if (buildLine.ActiveType) {
                node.setAttribute("ActiveType", buildLine.ActiveType);
                node.setAttribute("ActivePremise", buildLine.ActivePremise);
                node.setAttribute("ActiveMero", buildLine.ActiveMero);
            }

            for (var item in buildLine) {

                if (typeof (buildLine[item]) == "string" ||
							typeof (buildLine[item]) == "number") {
                    node.setAttribute(item, buildLine[item]);
                } else if (typeof (buildLine[item]) == "object") {
                    node.setAttribute(item, buildLine[item] && buildLine[item].id ? buildLine[item].id : '');
                } else {
                    node.setAttribute(item, buildLine[item] + " is unSupport");
                }

            }

        });

        var textXml = self.getTextXml(self.doc);

        return textXml;
        //  self.viewTextXml(textXml);

    },

    loadXmlText: function () {

        if (document.all && window.ActiveXObject) {

            var self = this;

            return function (xml) {

                var xmlVersions = ["Msxml2.DOMDocument.6.0",
												 	 "Msxml2.DOMDocument.5.0",
												 	 "Msxml2.DOMDocument.4.0",
												 	 "Msxml2.DOMDocument.3.0",
												   "MSXML2.DOMDocument",
												   "MSXML.DOMDocument",
												   "Microsoft.XMLDOM"];

                var xmlVersionLength = xmlVersions.length;
                var result = null;

                for (var i = xmlVersionLength; i--; ) {

                    try {
                        result = new ActiveXObject(xmlVersions[i]);
                        break;
                    } catch (err) {
                        continue;
                    }

                }

                result.async = 'false';
                result.loadXML(xml);

                return result;

            };

        } else {

            return function (xml) {
                return new DOMParser().parseFromString(xml, 'text/xml');
            };

        }

    } (),

    viewTextXml: function (textXml) {

        textXml = textXml.replaceAll("<", "&lt").replaceAll(">", "&gt");

        var viewHTML = window.open('saveXml.html', '', ''),
		i = 0,
		viewHTMLBuffer = [];

        viewHTMLBuffer[i++] = '<html>';
        viewHTMLBuffer[i++] = '<head>';
        viewHTMLBuffer[i++] = '<link href="css/flowPath.css" type="text/css" rel="stylesheet" />';
        viewHTMLBuffer[i++] = '<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />';
        viewHTMLBuffer[i++] = '<title></title>';
        viewHTMLBuffer[i++] = '</head>';
        viewHTMLBuffer[i++] = '<body>';

        viewHTMLBuffer[i++] = textXml;

        viewHTMLBuffer[i++] = '</body></html>';

        viewHTML.document.write(viewHTMLBuffer.join(""));

        viewHTML.document.close();

    },

    getTextXml: function (node) {

        var xml = '';

        if (node) {

            xml = node.xml;

            if (!xml) {

                if (node.innerHTML) {
                    xml = node.innerHTML;
                } else {

                    var xmlSerializer = new XMLSerializer();
                    xml = xmlSerializer.serializeToString(node);

                }

            } else {
                xml = xml.replace(/\r\n\t[\t]*/g, '').replace(/>\r\n/g, '>').replace(/\r\n/g, '\n');
            }

        }

        //xml = xml.replace(/\n/g, '&#xa;');  //2014.12.5 mpqin 替换成'&#xa;'会导致bo保存错误 

        return xml;

    },

    clearHTML: function () {

        var global = com.xjwgraph.Global;

        global.undoRedoEventFactory.clear();
        global.lineTool.removeAll();
        global.modeTool.removeAll()
        global.baseTool.removeAll();

    },

    toHTML: function () {

        var self = this;

        self.clearHTML();

        if (!self.doc) {
            return;
        }

        var docChildNodes = self.doc.childNodes,
		docChildNodesLength = docChildNodes.length;

        for (var i = docChildNodesLength; i--; ) {

            if (docChildNodes[i].nodeName == 'modes') {
                self.root = self.doc.childNodes[i];
                break;
            }

        }

        if (self.root) {

            var childNodes = self.root.childNodes,
			childNodesLength = childNodes.length;

            for (var i = childNodesLength; i--; ) {

                var node = childNodes[i];
                var nodeName = node.nodeName;

                var attributes = node.attributes;
                var attributesLength = attributes.length;
                var xml = null;

                if (nodeName == "mode") {
                    var iModeIndex = attributes[3].value;   //对应"id"
                    xml = new ModeXML(iModeIndex);
                } else if (nodeName == "line") {
                    xml = new LineXML();
                } else if (nodeName == "context") {
                    xml = new ContextXML();
                }

                for (var j = attributesLength; j--; ) {

                    var attribute = attributes[j];
                    xml.setAttribute(attribute.name, attribute.value);
                }

                xml.view(node);
            }

            var delays = self.delay,
			delayLength = delays.length;

            for (var i = delayLength; i--; ) {
                delays[i]();
            }

            delete self.delay;

            self.delay = [];
            self.delayIndex = 0;

        }

    },
    //验证节点XML信息是否合法
    checkXML: function () {
        var self = this;
        self.clearNode();

        var childNodes = self.root.childNodes,
			childNodesLength = childNodes.length;

        for (var i = childNodesLength; i--; ) {

            var node = childNodes[i],
				nodeName = node.nodeName,
				attributes = node.attributes,
				attributesLength = attributes.length;


        }

    }

}


			 