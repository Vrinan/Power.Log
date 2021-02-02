var Utils = com.xjwgraph.Utils = {

    create: function (options) {

        this.global = com.xjwgraph.Global;

        this.global.modeMap = new com.xjwgraph.Map();
        this.global.lineMap = new com.xjwgraph.Map();
        this.global.beanXml = new com.xjwgraph.BeanXML();

        // var contextBody = options.contextBody;
        //  var contextBodyDiv = $id(contextBody);

        //   var LayoutMain = mini.get("LayoutMain");  //��ȡ�������ּܹ�
        //    var contextBodyDiv = LayoutMain.getRegion("center")._body; //��ȡ�м��ͼ��

        var contextBodyDiv = options.contextBody; // $id("contextBody");
        var contextWidth = options.width;
        var contextHeight = options.height;

        this.global.baseTool = new com.xjwgraph.BaseTool(contextBodyDiv, contextWidth, contextHeight);
        this.global.modeTool = new com.xjwgraph.ModeTool(contextBodyDiv);
        this.global.lineTool = new com.xjwgraph.LineTool(contextBodyDiv);

        var smallMap = options.smallMap;
        if (smallMap) this.global.smallTool = new com.xjwgraph.SmallMapTool(smallMap, contextBodyDiv);

        var mainControl = $id(options.mainControl);
        if (mainControl) this.global.controlTool = new com.xjwgraph.ControlTool(mainControl);

        var historyMessage = options.historyMessage;
        if (historyMessage) {
            this.global.undoRedoEventFactory = new com.xjwgraph.UndoRedoEventFactory(historyMessage);
            this.global.undoRedoEventFactory.init();
        }

        var baseLineDiv = $id(options.LineDiv);
        if (baseLineDiv) this.global.baseTool.setBaseLineDiv(baseLineDiv);  //��·�����������ȥ 


        this.global.baseTool.setWorkFlowMode(options.WorkFlowMode);  //���嵱ǰ�������Ĵ���ģʽ ��ǰ���ģʽ ������ģʽ����תģʽ�����̼��ģʽ)
        this.global.baseTool.setImageRootPath(options.ImageRootPath);   //����ͼƬ��·��
        return this;

    },

    init: function () {
        this.global = com.xjwgraph.Global;
        this.global.beanXml = new com.xjwgraph.BeanXML();
    },
    toMerge: function () {
        this.global.baseTool.toMerge();
    },

    toSplit: function () {
        this.global.baseTool.toSeparate()
    },

    toTop: function () {
        this.global.modeTool.toTop();
    },

    toBottom: function () {
        this.global.modeTool.toBottom();
    },

    printView: function () {
        this.global.baseTool.printView();
    },

    undo: function () {
        this.global.undoRedoEventFactory.undo();
    },

    redo: function () {
        this.global.undoRedoEventFactory.redo();
    },

    saveXml: function () {

        return this.global.beanXml.toXML();

    },
    exportXml: function () {
        var textXml = this.global.beanXml.toXML();
        this.global.beanXml.viewTextXml(textXml);
    },
    importXml: function () {
        var self = this;
        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/ImportXML.html",
            title: "�ڵ�����", width: 980, height: 600,
            onload: function () {
            },
            ondestroy: function (action) {
                if (action != "ok") return;
                var iframe = this.getIFrameEl();
                var text = iframe.contentWindow.GetData();

                self.global.beanXml.clearHTML();
                self.loadTextXml(text);
            }
        });
    },
    //����������ʾ��Ŀ�ڵ�
    ShowActiveMode: function (lstMode) {
        var global = com.xjwgraph.Global;
        var tempModeTool = global.modeTool;

        //�б�����  �ڵ��ţ����      NodeCode:SequeID
        for (var iTmp = 0; iTmp < lstMode.length; iTmp++) {
            var tmp = lstMode[iTmp];
            var nodeCode = tmp.substr(0, tmp.indexOf(":"));
            tempModeTool.createBorder(nodeCode);
        }
    },

    loadXml: function () {
        this.global.beanXml.toHTML();
    },

    loadTextXml: function (textXml) {

        this.global.beanXml.doc = null;
        this.global.beanXml.doc = this.global.beanXml.loadXmlText(textXml);

        this.loadXml();

    },

    clearHtml: function () {
        this.global.beanXml.clearHTML();
    },

    copyNode: function () {
        keyDownFactory.copyNode();
    },

    removeNode: function () {

        var removeNodeId = keyDownFactory.removeNode();
        
        if (WorkFlowMode && WorkFlowMode == "WorkingDesign") {
            //�׽���ĩ�ڵ�����
            var len = CustomObj.WorkingNodeList.length;
            for (var irow = 0; irow < len; irow++) {
                if (CustomObj.WorkingNodeList[irow] != removeNodeId) continue;
                CustomObj.WorkingNodeList.splice(irow, 1);  //�޳���ɾ����Ԫ��
                if (irow == len - 1) break;   //���һ��Ԫ����ֱ������

                DrawAllLine(CustomObj.WorkingNodeList[irow]);  //���»�������
                break;
            }

        }
    },

    removeLine: function () {
        var global = com.xjwgraph.Global;
        var rightLineMenu = $id("rightLineMenu");

        var curLine = $id(rightLineMenu.lineTag);   //��ǰѡ�е�����
        if (!curLine) return;
        var rightLineMenu = $id("rightLineMenu");
        rightLineMenu.style.visibility = "hidden";
        rightLineMenu.lineTag = null;
        var tempLineTool = com.xjwgraph.Global.lineTool;
        tempLineTool.removeLine(curLine.id);

    },
    //�趨�ؼ��ڵ�
    SetNodeSign: function (curNode) {
        var self = this;
        var global = com.xjwgraph.Global;
        var tempModeTool = global.modeTool;
        var curMode = tempModeTool.getActiveMode();
        if (!curMode) return;
        var modeIndex = global.modeTool.getModeIndex(curMode);

        if (curMode.getAttribute("NodeType") != "GeneralNode" && curMode.getAttribute("NodeType") != "ConvergeNode") return;  //ֻ����ͨ�ڵ�������ùؼ��ڵ�

        //�ؼ��ڵ�ֻ����һ��������ֻ������ͨ�ڵ�
        var nodeList = [];
        tempModeTool.forEach(function (modeId) {
            var mode = $id(modeId);
            var modeIndex = global.modeTool.getModeIndex(mode);
            if (mode.getAttribute("IsSign") == "true" && (mode.getAttribute("NodeType") == "GeneralNode" || mode.getAttribute("NodeType") == "ConvergeNode")) {
                document.getElementById("backImg" + modeIndex).src = "/PowerPlat/WorkFlow/Images/GeneralNode.png";
                mode.setAttribute("IsSign", "");
            }
        }
        );
        document.getElementById("backImg" + modeIndex).src = "/PowerPlat/WorkFlow/Images/SignGeneralNode.png";
        curMode.setAttribute("IsSign", "true");
    },
    //һ��ڵ����Զ���
    OpenNodeProperty: function (curMode) {

        var global = com.xjwgraph.Global;
        var tempModeTool = global.modeTool;
        var modeIndex = global.modeTool.getModeIndex(curMode);
        var title = $id("title" + modeIndex).innerHTML;

        //��ȡ��ǰ��Ļ�����нڵ���Ϣ
        var nodeList = [];
        tempModeTool.forEach(function (modeId) {

            var mode = $id(modeId);
            var modeIndex = global.modeTool.getModeIndex(mode);
            var title = $id("title" + modeIndex).innerHTML;

            var tmpNode = new Object();
            tmpNode.NodeCode = modeIndex;
            tmpNode.NodeName = title;
            nodeList.push(tmpNode);
        }
        );
        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/NodeProperty.html",
            width: 1050, height: 600, //title: "�ڵ�����",
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetData(WorkFlowAdvanced, nodeList, curMode, title);
            },
            ondestroy: function (action) {
                if (action != "ok") return;
                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData(curMode);
                data = mini.clone(data);

                $id("title" + modeIndex).innerHTML = data.title;
                curMode.setAttribute("NodeType", data.NodeType);
                curMode.setAttribute("Description", data.Description);
                curMode.setAttribute("LimitDays", data.LimitDays);
                curMode.setAttribute("BookMarkCode", data.BookMarkCode);
                curMode.setAttribute("BookMarkName", data.BookMarkName);
                curMode.setAttribute("ReturnMode", data.ReturnMode);

                if (data.NodeType != "StartNode") {
                    curMode.DeptPositionInfo = data.DeptPositionInfo;
                    if (data.CopyDeptPositionInfo) curMode.CopyDeptPositionInfo = data.CopyDeptPositionInfo;
                    curMode.AdvancedInfo = data.AdvancedInfo;
                    curMode.RightInfo = data.RightInfo;
                    curMode.SubInfo = data.SubInfo;
                }
                if (data.VoteInfo) curMode.VoteInfo = data.VoteInfo;
                curMode.MindInfo = data.MindInfo;

                if (data.NodeType == "SubNode") curMode.SubNodeConfig = data.SubNodeConfig;
                if (data.NodeConfig) curMode.NodeConfig = data.NodeConfig;

            }
        });
    },

    //���ýڵ�����
    SetNodeProperty: function () {
        var self = this;
        var global = com.xjwgraph.Global;
        var tempModeTool = global.modeTool;

        var curMode = tempModeTool.getActiveMode();
        if (!curMode) return;

        Utils.OpenNodeProperty(curMode);
    },
    //������ʾ
    highLightNode: function (nodeList) {
        if (!nodeList) return;

        var tempModeTool = com.xjwgraph.Global.modeTool;

        for (var itmp = 0; itmp < nodeList.length; itmp++) {
            var mode = $id("module" + nodeList[itmp].NodeCode);
            mode.style.border = "5px solid #00f000";
        }

    },
    ///ϵͳ����
    SystemConfig: function () {
        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/SystemConfig.html",
            title: "�ڵ�����", width: 980, height: 600,
            onload: function () {
            },
            ondestroy: function (action) {

            }
        });
    },

    //���ýڵ�����
    SetLineProperty: function () {
        var self = this;
        var global = com.xjwgraph.Global;
        var rightLineMenu = $id("rightLineMenu");

        var curLine = $id(rightLineMenu.lineTag);   //��ǰѡ�е�����
        if (!curLine) return;
        var buildLine = global.lineMap.get(curLine.id);

        var rightLineMenu = $id("rightLineMenu");
        rightLineMenu.style.visibility = "hidden";
        rightLineMenu.lineTag = null;

        mini.open({
            url: "/Form/OpenURL?url=/PowerPlat/WorkFlow/LineProperty.html",
            width: 680, height: 400,
            onload: function () {
                var iframe = this.getIFrameEl();
                iframe.contentWindow.SetData(WorkFlowAdvanced, buildLine);
            },
            ondestroy: function (action) {
                if (action != "ok") return;
                var iframe = this.getIFrameEl();
                var data = iframe.contentWindow.GetData();
                data = mini.clone(data);
                buildLine.title = data.title;
                buildLine.IsSingleLine = data.IsSingleLine;
                buildLine.BookMarkCode = data.BookMarkCode;
                buildLine.BookMarkName = data.BookMarkName;
                buildLine.ActiveType = data.ActiveType;
                buildLine.ActivePremise = data.ActivePremise;
                buildLine.ActiveMero = data.ActiveMero;

            }
        });
    },
    //�ж������ڵ�֮������ߣ��Ƿ񱻴�����
    CheckNodeLine: function (CurrentNodeList, fromModeIndex, toModeIndex) {
        var result = false;
         
        for (var iTmp = 0, len = CurrentNodeList.length; iTmp < len; iTmp++) {
            var toNode = CurrentNodeList[iTmp].substr(0, CurrentNodeList[iTmp].indexOf(":"));
            var fromNode = CurrentNodeList[iTmp].substr(  CurrentNodeList[iTmp].indexOf(":") + 1);
            if (fromNode != fromModeIndex) continue;
            if (toNode != toModeIndex) continue;
            result = true;
            break;
        }
        return result;
    },

    SetNodeMindTag: function (mindData, CurrentNodeList,lineStyle) {
        var self = this;
        var global = com.xjwgraph.Global;
        var tempModeTool = global.modeTool;
        var tempLineTool = global.lineTool;
       
        //��������Ľڵ㣬����  title ,��
        var nodeList = [];
         
        tempModeTool.forEach(function (modeId) {
            
            var mode = $id(modeId);
            var modeIndex = global.modeTool.getModeIndex(mode);

            var mindInfo = "";
            for (var iTmp = 0, len = mindData.length; iTmp < len; iTmp++) {
                if (mindData[iTmp].Alias == "MindGroup") continue;
                if (mindData[iTmp].NodeCode != modeIndex) continue;
                // mindInfo += mindData[iTmp].text+"/r/n";//���ڷ��ص�����Դ�Ѿ�û��text���������ֱ��ƴ��xuzhimin 2014-12-19
                mindInfo += mindData[iTmp].MindDate + mindData[iTmp].DeptPositionName + mindData[iTmp].UserName + "[" + mindData[iTmp].ActName + "]" + "\r\n";

            }
            if (mindInfo != "") mode.title = mindInfo;

            var blnFlag = false; //���Ϊture ˵�����ڵ�ǰ�ڵ�
            for (var iTmp = 0, len = CurrentNodeList.length; iTmp < len; iTmp++) {
                var curNode = CurrentNodeList[iTmp].substr(0, CurrentNodeList[iTmp].indexOf(":"));
                if (curNode != modeIndex) continue;
                blnFlag = true;
                break;
            }

            if (blnFlag == true)
               mode.children["content" + modeIndex].children["backImg" + modeIndex].style.border = lineStyle;


        }
      );
         
    },
    //��������
    SetLineDashed: function (CurrentNodeList) {
        var self = this;
        var global = com.xjwgraph.Global;
        var tempModeTool = global.modeTool;
        var tempLineTool = global.lineTool;
         
        //����δ����������Ϊ����
        tempLineTool.forEach(function (lineId) {
            
            var flag = false;
            for (var iTmp = 0; iTmp < CurrentNodeList.length; iTmp++) {
                var str = CurrentNodeList[iTmp];
                var lineCode = (str + "").split(":")[2];
                if (!lineCode) continue;
                if (lineId == lineCode) { flag = true; break; }               
            }
            if (flag == true) return;

            var curLine = $id(lineId);
            var style = curLine.getAttribute("style");
            curLine.setAttribute("style", style + ";stroke-width:1;stroke-dasharray:9,5;");
        }
        );

    },
    test: function () {
        var global = com.xjwgraph.PathGlobal;
        alert(global.FromSelectNode);
    },
    alignLeft: function () {

        this.global.baseTool.toLeft();
        this.global.baseTool.clearContext();

    },

    alignRight: function () {

        this.global.baseTool.toRight();
        this.global.baseTool.clearContext();

    },

    verticalCenter: function () {

        this.global.baseTool.toMiddleWidth();
        this.global.baseTool.clearContext();

    },

    alignTop: function () {

        this.global.baseTool.toTop();
        this.global.baseTool.clearContext();

    },

    horizontalCenter: function () {

        this.global.baseTool.toMiddleHeight();
        this.global.baseTool.clearContext();

    },

    bottomAlignment: function () {

        this.global.baseTool.toBottom();
        this.global.baseTool.clearContext();

    },

    baseLineClick: function (line) {
        this.global.baseTool.baseLineClick(line);
    },

    nodeDrag: function (node, isLine, lineType) {
        this.global.baseTool.drag(node, isLine, lineType);
    },
    //����ȫ·���������ļ�����wsl ׷��
    GetFileName: function (src) {

        if (!src) return src;
        var iIndex = src.lastIndexOf("/");
        if (iIndex > 0) return src.substring(iIndex + 1);
        return src;
    }
}

 