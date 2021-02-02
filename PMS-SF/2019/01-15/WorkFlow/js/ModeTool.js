var ModeTool = com.xjwgraph.ModeTool = function (body) {
	
	var self = this;
	
	self.moveable = false;
	self.optionMode;
	self.baseModeIdIndex = PathGlobal.modeDefIndex;
	self.stepIndex = PathGlobal.modeDefStep;
	self.pathBody = body;
	self.tempMode;
	
}

ModeTool.prototype = {

    initScaling: function (multiple) {

        var self = this,
		tempSmallTool = com.xjwgraph.Global.smallTool;

        self.forEach(function (modeId) {

            var mode = $id(modeId),
			modeStyle = mode.style,
			index = self.getModeIndex(mode),
			content = $id("content" + index),
			backImg = $id("backImg" + index),

			contentStyle = content.style,
			backImgStyle = backImg.style,

			newModeWidth = parseInt(parseInt(mode.offsetWidth) / multiple) + "px",
			newModeHeight = parseInt(parseInt(mode.offsetHeight) / multiple) + "px";

            modeStyle.top = parseInt(parseInt(modeStyle.top) / multiple) + "px";
            modeStyle.left = parseInt(parseInt(modeStyle.left) / multiple) + "px";

            contentStyle.width = newModeWidth;
            contentStyle.height = newModeHeight;

            backImgStyle.width = newModeWidth;
            backImgStyle.height = newModeHeight;

            modeStyle.width = newModeWidth;
            modeStyle.height = newModeHeight;

            self.showPointer(mode);

            tempSmallTool.drawMode(mode);

        });

    },

    showMenu: function (event, mode) {

        PathGlobal.rightMenu = true;

        var self = this;

        self.tempMode = mode.parentNode;

        event = event || window.event;

        if (!event.pageX) {
            event.pageX = event.clientX;
        }

        if (!event.pageY) {
            event.pageY = event.clientY;
        }

        var tx = event.pageX,
				ty = event.pageY,

		global = com.xjwgraph.Global,

		tempPathBody = global.lineTool.pathBody,
  	leftTops = global.baseTool.sumLeftTop(tempPathBody);

        tx = tx - parseInt(leftTops[0]) + parseInt(tempPathBody.scrollLeft);
        ty = ty - parseInt(leftTops[1]) + parseInt(tempPathBody.scrollTop);

        var rightMenu = $id("rightMenu"),
		rightMenuStyle = rightMenu.style;

        rightMenuStyle.top = ty + "px";
        rightMenuStyle.left = tx + "px";
        rightMenuStyle.visibility = "visible";
        rightMenuStyle.zIndex = self.getNextIndex();

    },

    removeAll: function () {

        var self = this;

        self.forEach(function (modeId) {
            self.removeNode(modeId);
        });

    },

    removeNode: function (modeId) {

        var mode = $id(modeId);

        if (mode) {

            var global = com.xjwgraph.Global,
			pathBody = global.lineTool.pathBody,
		    baseMode = global.modeMap.get(modeId),
		    baseLineModeMap = baseMode.lineMap,
		    baseLineKey = baseLineModeMap.getKeys(),
		    baseLineKeyLength = baseLineKey.length;


            for (var i = baseLineKeyLength; i--; ) {
                var buildLine = baseLineModeMap.get(baseLineKey[i]),
		     	line = $id(buildLine.id);

                if (!line) continue;

                var lineMode = global.lineMap.get(line.id);
                var fromBaseMode = lineMode.xBaseMode;
                var toBaseMode = lineMode.wBaseMode;

                var fromMode = $id(fromBaseMode.id);
                var toMode = $id(toBaseMode.id);

                var fromBuilderLine = fromBaseMode.lineMap.get(buildLine.id + "-" + true);
                fromBuilderLine.index = fromBaseMode.index;

                fromBaseMode.lineMap.remove(buildLine.id + "-" + "true");

                toBaseMode.lineMap.remove(buildLine.id + "-" + "true");

                global.lineMap.remove(line.id);

                global.lineTool.removeLine(line.id);
            }



            this.hiddPointer(mode);



            global.modeMap.remove(mode.id);
            global.smallTool.removeMode(mode.id);

            pathBody.removeChild(mode);

        }

    },

    cutter: function () {

        var self = this,
		tempModeId = self.tempMode.id,

		global = com.xjwgraph.Global,

		mode = global.modeMap.get(tempModeId),
		modeDiv = $id(tempModeId),
		pathBody = global.lineTool.pathBody;

        self.removeNode(tempModeId);

        var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

            global.modeMap.put(tempModeId, mode);

            pathBody.appendChild(modeDiv);
            self.showPointer(modeDiv);

            global.smallTool.drawMode(modeDiv);

        }, PathGlobal.modeCutter);

        undoRedoEvent.setRedo(function () {
            self.removeNode(tempModeId);
        });

    },
    //复制对象
    duplicate: function () {

        var global = com.xjwgraph.Global,

		pathBody = global.lineTool.pathBody,
		self = this,

		copyObj = global.modeTool.copy(self.tempMode),
		mode = global.modeMap.get(copyObj.id);

        global.modeTool.hiddPointer(self.tempMode);
        global.smallTool.drawMode(copyObj);

        var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {
            self.removeNode(copyObj.id);
        }, PathGlobal.modeDuplicate);

        undoRedoEvent.setRedo(function () {

            global.modeMap.put(copyObj.id, mode);

            pathBody.appendChild(copyObj);
            self.showPointer(copyObj);

            global.smallTool.drawMode(copyObj);

        });

    },

    del: function () {

        var self = this;
        self.cutter();
        self.tempMode = null;

    },

    getNextIndex: function () {

        var self = this;
        self.baseModeIdIndex += self.stepIndex;

        return self.baseModeIdIndex;

    },

    setClass: function (mode, className) {

        if (mode) {
            mode.setAttribute("class", className);
            mode.setAttribute("className", className);
        }

    },


    /*
    //滚动连线算法用函数
    getStyleValue: function (ele, attr) {

    var doc = document;
    var style = ele.currentStyle || doc.defaultView.getComputedStyle(ele, null);
    return parseInt(style[attr].replace(/px/g, ""));
    },
    //触发滚动
    RollBorder: function (modeIndex) {
    debugger;
    var self = this;
    var borTop = $id("topBorder" + modeIndex),
    borBottom = $id("bottomBorder" + modeIndex),
    borLeft = $id("leftBorder" + modeIndex),
    borRight = $id("rightBorder" + modeIndex),

    left = self.getStyleValue(borTop, 'left'),
    top = self.getStyleValue(borLeft, 'top');

    setInterval(function () {
    if (left < 0) {
    left += 2;
    borRight.style.top = left + "px";
    borTop.style.left = left + "px";
    } else left = -1500;

    if (top > -3000) {
    top -= 2;
    borBottom.style.left = top + "px";
    borLeft.style.top = top + "px";
    } else top = -1500;
    }, 60);
    },
   
    createBorder: function (modeIndex) {
    var self = this,
    doc = document;

    //绘制边框
    var borderDiv = doc.createElement("div");
    borderDiv.id = "Border" + modeIndex;
    self.setClass(borderDiv, "NodeBorder");
    var top_border = doc.createElement("div");
    var left_border = doc.createElement("div");
    var right_border = doc.createElement("div");
    var bottom_border = doc.createElement("div");
    var contDiv = doc.createElement("div");
    contDiv.innerHTML = " ";
    top_border.id = "topBorder" + modeIndex;
    left_border.id = "leftBorder" + modeIndex;
    right_border.id = "rightBorder" + modeIndex;
    bottom_border.id = "bottomBorder" + modeIndex;
    self.setClass(top_border, "topBorder_move");
    self.setClass(left_border, "leftBorder_move");
    self.setClass(right_border, "rightBorder_move");
    self.setClass(bottom_border, "bottomBorder_move");
    borderDiv.zIndex = 1000;
    borderDiv.appendChild(top_border);
    borderDiv.appendChild(left_border);
    borderDiv.appendChild(contDiv);
    borderDiv.appendChild(right_border);
    borderDiv.appendChild(bottom_border);

    return borderDiv;
    //  mini.get("LayoutMain").getRegion("center")._body.appendChild(borderDiv);
    //   moduleDiv.appendChild(borderDiv);
    },
    */
    //创建一个节点
    createBaseMode: function (top, left, title, imgSrc, modeIndex, backWidth, backHeight, NodeType) {

        var self = this,
		doc = document,

		moduleDiv = doc.createElement("div"),
		titleDiv = doc.createElement("div"),
		contentDiv = doc.createElement("div"),
		backImg = doc.createElement("img");

        moduleDiv.setAttribute("NodeType", NodeType);

        moduleDiv.appendChild(titleDiv);
        moduleDiv.appendChild(contentDiv);
        contentDiv.appendChild(backImg);

        var moduleDivStyle = moduleDiv.style;
        moduleDivStyle.top = top + "px";
        moduleDivStyle.left = left + "px";

        self.setClass(moduleDiv, "module");
        self.setClass(titleDiv, "title");
        self.setClass(contentDiv, "content");

        moduleDiv.id = "module" + modeIndex;
        titleDiv.id = "title" + modeIndex;
        titleDiv.innerHTML = title;
        contentDiv.id = "content" + modeIndex;
        backImg.id = "backImg" + modeIndex;

        backImg.style.width = backWidth;
        backImg.style.height = backHeight;
        backImg.src = imgSrc;


        //------------绘制焦点
        var top_left = doc.createElement("div"),
		top_middle = doc.createElement("div"),
		top_right = doc.createElement("div"),
		middle_left = doc.createElement("div"),
		middle_right = doc.createElement("div"),
		bottom_left = doc.createElement("div"),
		bottom_middle = doc.createElement("div"),
		bottom_right = doc.createElement("div");

        self.setClass(top_left, "top_left");
        self.setClass(top_middle, "top_middle");
        self.setClass(top_right, "top_right");
        self.setClass(middle_left, "middle_left");
        self.setClass(middle_right, "middle_right");
        self.setClass(bottom_left, "bottom_left");
        self.setClass(bottom_middle, "bottom_middle");
        self.setClass(bottom_right, "bottom_right");

        top_left.id = "top_left" + modeIndex;
        top_middle.id = "top_middle" + modeIndex;
        top_right.id = "top_right" + modeIndex;
        middle_left.id = "middle_left" + modeIndex;
        middle_right.id = "middle_right" + modeIndex;
        bottom_left.id = "bottom_left" + modeIndex;
        bottom_middle.id = "bottom_middle" + modeIndex;
        bottom_right.id = "bottom_right" + modeIndex;

        moduleDiv.appendChild(top_left);
        moduleDiv.appendChild(top_middle);
        moduleDiv.appendChild(top_right);
        moduleDiv.appendChild(middle_left);
        moduleDiv.appendChild(middle_right);
        moduleDiv.appendChild(bottom_left);
        moduleDiv.appendChild(bottom_middle);
        moduleDiv.appendChild(bottom_right);

        return moduleDiv;

    },

    create: function (top, left, title, imgSrc, nodeType) {

        var self = this;

        var global = com.xjwgraph.Global;

        var modeIndex = self.getNextIndex();
        var doc = document;

        var moduleDiv = self.createBaseMode(top, left, title, imgSrc, modeIndex, "40px", "40px", nodeType);
        self.pathBody.appendChild(moduleDiv);

        var mode = new BaseMode();
        mode.id = moduleDiv.id;



        global.modeMap.put(mode.id, mode);

        this.initEvent(modeIndex);
        global.smallTool.drawMode(moduleDiv);

        var tempModeTool = global.modeTool;
        tempModeTool.flip(modeIndex);

        drawLine(modeIndex);   //新建节点后，尝试和上次选中的节点间绘制连线
        com.xjwgraph.Global.baseTool.setLineEnabled(moduleDiv);    //设置当前选中的节点，以备绘线
        // com.xjwgraph.Global.baseTool.setLineDisabled();



        var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

            if ($id(moduleDiv.id)) {

                global.smallTool.removeMode(moduleDiv.id);
                tempModeTool.pathBody.removeChild(moduleDiv);
                global.modeMap.remove(moduleDiv.id);

            }

        }, PathGlobal.modeCreate);

        undoRedoEvent.setRedo(function () {

            global.modeMap.put(mode.id, mode);

            tempModeTool.pathBody.appendChild(moduleDiv);
            tempModeTool.showPointer(moduleDiv);
            tempModeTool.changeBaseModeAndLine(moduleDiv, true);

            global.smallTool.drawMode(moduleDiv);

        });

    },

    initEvent: function (modeIndex) {

        var tempModeTool = com.xjwgraph.Global.modeTool;

        if (PathGlobal.WorkFlowMode == "WorkFlowDesign" || PathGlobal.WorkFlowMode == "WorkingDesign")    //如果不是设计模式，不允许拖曳
        {
            tempModeTool.drag($id("content" + modeIndex));
            tempModeTool.dragPoint($id("top_left" + modeIndex));
            tempModeTool.dragPoint($id("top_middle" + modeIndex));
            tempModeTool.dragPoint($id("top_right" + modeIndex));
            tempModeTool.dragPoint($id("middle_left" + modeIndex));
            tempModeTool.dragPoint($id("middle_right" + modeIndex));
            tempModeTool.dragPoint($id("bottom_left" + modeIndex));
            tempModeTool.dragPoint($id("bottom_middle" + modeIndex));
            tempModeTool.dragPoint($id("bottom_right" + modeIndex));
        }

        $id("content" + modeIndex).onclick = function () {

            if (PathGlobal.WorkFlowMode == "WorkFlowDesign" || PathGlobal.WorkFlowMode == "WorkingDesign")    //如果不是设计模式，不允许拖曳
            {
                tempModeTool.showPointer($id("module" + modeIndex));
                drawLine(modeIndex);
            } 
        }

        drawLine = function (modeIndex) {
            var pathGlobal = com.xjwgraph.PathGlobal;

            //如果没有线路原版，则无视后续操作
            if (pathGlobal.BaseLineDiv == null) return;

            if (pathGlobal.StartDrawLine == false) {
                com.xjwgraph.Global.baseTool.setLineEnabled($id("module" + modeIndex));  //设置线路状态 
            }
            else {
                var fromNode = pathGlobal.FromSelectNode;
                if (fromNode == null) {
                    alert("error");
                    return;
                }
                var toNode = $id("module" + modeIndex);

                var tempLineTool = com.xjwgraph.Global.lineTool;
                if (tempLineTool.checkModeLine(fromNode, toNode) == true) {
                    alert("对不起，该两节点之间已经有连线了");
                    return;
                }
                var lineId = com.xjwgraph.Global.lineTool.create(1, 1, 3);  //创建一根线    (x,y ,线类型(1,2,3)  1: 直线，2/3均折线 

                var line = $id(lineId);

                tempLineTool.buildLineAndTwoMode(line, fromNode, toNode, 1);
                pathGlobal.FromSelectNode = toNode;
                pathGlobal.StartDrawLine = false;
                //com.xjwgraph.Global.baseTool.setLineDisabled();
            }
        }

    },

    clear: function () {

        var global = com.xjwgraph.Global,

		tempModeTool = global.modeTool;

        this.forEach(function (modeId) {
            tempModeTool.hiddPointer($id(modeId));
        });

        global.smallTool.clear();

    },

    toTop: function () {

        var tempModeTool = com.xjwgraph.Global.modeTool;

        this.forEach(function (modeId) {

            var mode = $id(modeId),
			modeStyle = mode.style;

            if (modeStyle.visibility == "visible") {
                modeStyle.zIndex = tempModeTool.getNextIndex();
            } else {

                if (modeStyle.zIndex < 1) {
                    modeStyle.zIndex = 0;
                } else {
                    modeStyle.zIndex = modeStyle.zIndex - 1;
                }

            }

        });

    },

    toBottom: function () {

        this.forEach(function (modeId) {

            var mode = $id(modeId),
			modeStyle = mode.style;

            if (modeStyle.visibility == "visible") {
                modeStyle.zIndex = 0;
            } else if (modeStyle.zIndex == 0) {
                modeStyle.zIndex = 1;
            }

        });

        stopEvent = true;

    },

    forEach: function (fn) {

        var modeKeys = com.xjwgraph.Global.modeMap.getKeys(),
		modeKeysLength = modeKeys.length;

        for (var i = modeKeysLength; i--; ) {

            if (fn) {
                fn(modeKeys[i]);
            }

        }

        stopEvent = true;

    },

    hiddPointer: function (mode) {

        var idIndex = this.getModeIndex(mode);

        $id("module" + idIndex).style.visibility = "hidden";
        $id("top_left" + idIndex).style.visibility = "hidden";
        $id("top_middle" + idIndex).style.visibility = "hidden";
        $id("top_right" + idIndex).style.visibility = "hidden";
        $id("middle_left" + idIndex).style.visibility = "hidden";
        $id("middle_right" + idIndex).style.visibility = "hidden";
        $id("bottom_left" + idIndex).style.visibility = "hidden";
        $id("bottom_middle" + idIndex).style.visibility = "hidden";
        $id("bottom_right" + idIndex).style.visibility = "hidden";

        var rightMenu = $id("rightMenu");
        if (rightMenu) {
            rightMenu.style.visibility = "hidden";
            PathGlobal.rightMenu = false;
            PathGlobal.rightLineMenu = false;
        }
        var topCross = $id("topCross"),
		leftCross = $id("leftCross");

        topCross.style.visibility = "hidden";
        leftCross.style.visibility = "hidden";

        com.xjwgraph.Global.smallTool.clearMode($id("small" + mode.id));

    },

    getModeIndex: function (mode) {

        var subIndex;

        if (mode.className == "module") {
            subIndex = 6;
        } else if (mode.className == "content") {
            subIndex = 7;
        }

        return mode.id.substr(subIndex);

    },

    showPointer: function (mode) {
        this.showPointerId(this.getModeIndex(mode));
    },

    //高亮显示某个对象，上下左右出现绿色小点
    showPointerId: function (idIndex) {

        var smallObj = $id("small" + "module" + idIndex),
		global = com.xjwgraph.Global;

        if (smallObj) {

            var smallObjStyle = smallObj.style;

            smallObjStyle.borderWidth = "1px";
            smallObjStyle.borderColor = global.smallTool.checkColor;
            smallObjStyle.borderStyle = "solid";

        }

        var moduleDiv = $id("module" + idIndex);
        moduleDiv.style.visibility = "visible";

        var topLeftDiv = $id("top_left" + idIndex),
		topLeftDivStyle = topLeftDiv.style,

		sH = topLeftDiv.offsetHeight,
		sW = topLeftDiv.offsetWidth,

		mH = moduleDiv.offsetHeight,
		mW = moduleDiv.offsetWidth;

        $id("title" + idIndex).style.width = mW + "px";

        topLeftDivStyle.top = -sH / 2 + "px";
        topLeftDivStyle.left = -sW / 2 + "px";
        topLeftDivStyle.visibility = "visible";

        var topMiddleDivStyle = $id("top_middle" + idIndex).style;

        topMiddleDivStyle.top = -sH / 2 + "px";
        topMiddleDivStyle.left = mW / 2 - sW / 2 + "px";
        topMiddleDivStyle.visibility = "visible";

        var topRightDivStyle = $id("top_right" + idIndex).style;

        topRightDivStyle.top = -sH / 2 + "px";
        topRightDivStyle.left = mW - sW / 2 + "px";
        topRightDivStyle.visibility = "visible";

        var middleLeftDivStyle = $id("middle_left" + idIndex).style;

        middleLeftDivStyle.top = mH / 2 - sH / 2 + "px";
        middleLeftDivStyle.left = -sW / 2 + "px";
        middleLeftDivStyle.visibility = "visible";

        var middleRightDivStyle = $id("middle_right" + idIndex).style;

        middleRightDivStyle.top = mH / 2 - sH / 2 + "px";
        middleRightDivStyle.left = mW - sW / 2 + "px";
        middleRightDivStyle.visibility = "visible";

        var bottomLeftDivStyle = $id("bottom_left" + idIndex).style;

        bottomLeftDivStyle.top = mH - sH / 2 + "px";
        bottomLeftDivStyle.left = -sW / 2 + "px";
        bottomLeftDivStyle.visibility = "visible";

        var bottomMiddleDivStyle = $id("bottom_middle" + idIndex).style;

        bottomMiddleDivStyle.top = mH - sH / 2 + "px";
        bottomMiddleDivStyle.left = mW / 2 - sW / 2 + "px";
        bottomMiddleDivStyle.visibility = "visible";

        var bottomRightDivStyle = $id("bottom_right" + idIndex).style;

        bottomRightDivStyle.top = mH - sH / 2 + "px";
        bottomRightDivStyle.left = mW - sW / 2 + "px";
        bottomRightDivStyle.visibility = "visible";

        var imageStyle = $id("backImg" + idIndex).style;

        imageStyle.width = (mW - 2) + "px";
        imageStyle.height = (mH - 2) + "px";
        imageStyle.top = "0px";
        imageStyle.left = "0px";

        if (global.controlTool) global.controlTool.print(idIndex);

    },

    drag: function (mode) {

        var parentMode = mode.parentNode,
		parentModeStyle = parentMode.style,

		global = com.xjwgraph.Global,

		tempModeTool = global.modeTool,
		tempLineTool = global.lineTool;

        mode.ondragstart = function (e) {
            return false;
        };

        mode.onclick = function () {
            tempModeTool.clear();
            tempModeTool.showPointer(parentMode);
        }

        mode.ondblclick = function () {
            tempModeTool.hiddPointer(parentMode);
            tempModeTool.flip(global.modeTool.getModeIndex(parentMode));
        }

        mode.onmousemove = function () {

            if (tempLineTool.moveable) {
                tempModeTool.showPointerId(global.modeTool.getModeIndex(parentMode));
            }

        }

        mode.onmouseout = function () {

            if (tempLineTool.moveable) {
                tempModeTool.hiddPointer(parentMode);
            }

        }

        mode.oncontextmenu = function (event) {
            if (PathGlobal.WorkFlowMode != "WorkFlowDesign" && PathGlobal.WorkFlowMode != "WorkingDesign") return;    //如果不是设计模式，不允许拖曳

            tempModeTool.showMenu(event, mode);

            return false;

        }

        mode.onmousedown = function (event) {

            tempModeTool.clear();

            tempModeTool.isModeCross(parentMode);
            tempModeTool.moveable = true;

            event = event || window.event;

            tempModeTool.showPointer(parentMode);

            if (parentMode.setCapture) {
                parentMode.setCapture();
            } else if (window.captureEvents) {
                window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
            }

            //wsl修改,否则在IE10下拖曳会有问题
            var x = 0;
            var y = 0;
            if (global.baseTool.isIE == true) {
                x = event.offsetX;
                y = event.offsetY;
            }
            else {
                x = event.layerX ? event.layerX : event.offsetX,
				y = event.layerY ? event.layerY : event.offsetY;
            }


            stopEvent = true;

            var doc = document,

			orgLeft = parseInt(parentMode.offsetLeft),
			orgTop = parseInt(parentMode.offsetTop);

            doc.onmousemove = function (event) {

                event = event || window.event;

                if (tempModeTool.moveable) {

                    if (!event.pageX) {
                        event.pageX = event.clientX;
                    }

                    if (!event.pageY) {
                        event.pageY = event.clientY;
                    }

                    var tx = event.pageX - x,
   						ty = event.pageY - y,

					tempPathBody = global.lineTool.pathBody,

   				leftTops = global.baseTool.sumLeftTop(tempPathBody);

                    tx = tx - parseInt(leftTops[0]) + parseInt(tempPathBody.scrollLeft);
                    ty = ty - parseInt(leftTops[1]) + parseInt(tempPathBody.scrollTop);

                    parentModeStyle.left = tx + "px";
                    parentModeStyle.top = ty + "px";

                    tempModeTool.isModeCross(parentMode);
                    tempModeTool.changeBaseModeAndLine(parentMode, true);
                    tempModeTool.showPointer(parentMode);

                    global.smallTool.drawMode(parentMode);

                }

            };

            doc.onmouseup = function (event) {

                event = event || window.event;

                tempModeTool.moveable = false;
                if (parentMode.releaseCapture) {
                    parentMode.releaseCapture();
                } else if (window.releaseEvents) {
                    window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP);
                }

                doc.onmousemove = null;
                doc.onmouseup = null;

                var orgAfterLeft = parseInt(parentMode.offsetLeft),
				orgAfterTop = parseInt(parentMode.offsetTop);

                if (orgLeft != orgAfterLeft || orgTop != orgAfterTop) {

                    var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

                        parentMode.style.left = orgLeft + "px";
                        parentMode.style.top = orgTop + "px";

                        tempModeTool.showPointer(parentMode);
                        tempModeTool.changeBaseModeAndLine(parentMode, true);

                        global.smallTool.drawMode(parentMode);

                    }, PathGlobal.modeMove);

                    undoRedoEvent.setRedo(function () {

                        parentModeStyle.left = orgAfterLeft + "px";
                        parentModeStyle.top = orgAfterTop + "px";

                        tempModeTool.showPointer(parentMode);
                        tempModeTool.changeBaseModeAndLine(parentMode, true);

                        global.smallTool.drawMode(parentMode);

                    });

                }

            };

        }

    },

    findModeLine: function (mode, line) {

        var baseMode = com.xjwgraph.Global.modeMap.get(mode.id),
		baseLineModeMap = baseMode.lineMap,

		baseLineKey = baseLineModeMap.getKeys(),
		baseLineKeyLength = baseLineKey.length;

        for (var i = baseLineKeyLength; i--; ) {

            var buildLine = baseLineModeMap.get(baseLineKey[i]);

            if (line.id == buildLine.id) {
                return buildLine;
            }

        }

        return null;

    },

    changeLineType: function (line, mode, buildLine) {

        var self = this,

		lineBase = com.xjwgraph.Global.lineMap.get(line.id),

		xBaseMode = lineBase.xBaseMode,
		wBaseMode = lineBase.wBaseMode,

		xMode,
		wMode;

        if (xBaseMode) {
            xMode = $id(xBaseMode.id);
        }

        if (wBaseMode) {
            wMode = $id(wBaseMode.id);
        }

        if (xBaseMode && xBaseMode.id == mode.id) {

            if (wMode && xMode) {

                var wBuildLine = self.findModeLine(wMode, line);

                if (wMode.offsetTop - (xMode.offsetTop + xMode.offsetHeight) > 0) {

                    buildLine.index = PathGlobal.pointTypeDown;
                    wBuildLine.index = PathGlobal.pointTypeUp;

                } else if (xMode.offsetTop - (wMode.offsetTop + wMode.offsetHeight) > 0) {

                    buildLine.index = PathGlobal.pointTypeUp;
                    wBuildLine.index = PathGlobal.pointTypeDown;

                } else if (xMode.offsetLeft - (wMode.offsetLeft + wMode.offsetWidth + lineNumber) > 0) {

                    buildLine.index = PathGlobal.pointTypeLeft;
                    wBuildLine.index = PathGlobal.pointTypeRight;

                } else if (wMode.offsetLeft - (xMode.offsetLeft + xMode.offsetWidth + lineNumber) > 0) {

                    buildLine.index = PathGlobal.pointTypeRight;
                    wBuildLine.index = PathGlobal.pointTypeLeft;

                }

                this.changeBaseModeAndLine(wMode, false);

            }
        }

        if (wBaseMode && wBaseMode.id == mode.id) {

            if (wMode && xMode) {

                var xBuildLine = self.findModeLine(xMode, line);

                if (xMode.offsetTop - (wMode.offsetTop + wMode.offsetHeight) > 0) {

                    buildLine.index = PathGlobal.pointTypeDown;
                    xBuildLine.index = PathGlobal.pointTypeUp;

                } else if (wMode.offsetTop - (xMode.offsetTop + xMode.offsetHeight) > 0) {

                    buildLine.index = PathGlobal.pointTypeUp;
                    xBuildLine.index = PathGlobal.pointTypeDown;

                } else if (wMode.offsetLeft - (xMode.offsetLeft + xMode.offsetWidth + lineNumber) > 0) {

                    buildLine.index = PathGlobal.pointTypeLeft;
                    xBuildLine.index = PathGlobal.pointTypeRight;

                } else if (xMode.offsetLeft - (wMode.offsetLeft + wMode.offsetWidth + lineNumber) > 0) {

                    buildLine.index = PathGlobal.pointTypeRight;
                    xBuildLine.index = PathGlobal.pointTypeLeft;

                }

                self.changeBaseModeAndLine(xMode, false);

            }
        }

        return buildLine;

    },

    changeBaseModeAndLine: function (mode, isChangeEnd) {


        var self = this,
		global = com.xjwgraph.Global,
		baseMode = global.modeMap.get(mode.id),
		baseLineModeMap = baseMode.lineMap,
		baseLineKey = baseLineModeMap.getKeys(),
		baseLineKeyLength = baseLineKey.length;


        for (var i = baseLineKeyLength; i--; ) {
            var buildLine = baseLineModeMap.get(baseLineKey[i]),
			line = $id(buildLine.id);

            if (!line) continue;

            var lineMode = global.lineMap.get(line.id);
            var fromBaseMode = lineMode.xBaseMode;
            var toBaseMode = lineMode.wBaseMode;

            var fromMode = $id(fromBaseMode.id);
            var toMode = $id(toBaseMode.id);

            line.setAttribute("brokenType", self.calculateLineType(fromMode, toMode));   //判断线路类型，上下型还是左右型

            fromBaseMode.angle = self.calcuateAngle(fromMode, toMode);  //计算夹角
            fromBaseMode.index = self.calculateDirection(fromBaseMode.angle);  //求取连线方向  (返回的是发送端方向) 

            toBaseMode.angle = self.calcuateAngle(toMode, fromMode);  //计算夹角
            toBaseMode.index = self.calculateDirection(toBaseMode.angle);

            lineMode.xIndex = fromBaseMode.index;
            lineMode.wIndex = toBaseMode.index;


            var fromBuilderLine = fromBaseMode.lineMap.get(buildLine.id + "-" + true);
            fromBuilderLine.index = fromBaseMode.index;
            fromBuilderLine.angle = fromBaseMode.angle;
            fromBaseMode.lineMap.put(buildLine.id + "-" + "true", fromBuilderLine);

            var toBuilderLine = toBaseMode.lineMap.get(buildLine.id + "-" + false);
            toBuilderLine.index = toBaseMode.index;
            toBuilderLine.angle = toBaseMode.angle;
            toBaseMode.lineMap.put(buildLine.id + "-" + "true", toBuilderLine);


            global.lineMap.put(line.id, lineMode);   //修改过的信息放回列表
            // self.changeLineType(line, mode, buildLine);


            //  global.lineTool.pathSimpleLine(line, fromMode, toMode);

        }

        for (var i = baseLineKeyLength; i--; ) {
            var buildLine = baseLineModeMap.get(baseLineKey[i]),
			line = $id(buildLine.id);

            if (!line) continue;

            var lineMode = global.lineMap.get(line.id);
            var fromBaseMode = lineMode.xBaseMode;
            var toBaseMode = lineMode.wBaseMode;

            var fromMode = $id(fromBaseMode.id);
            var toMode = $id(toBaseMode.id);


            self.aa(fromMode, lineMode.xIndex);
            self.aa(toMode, lineMode.wIndex);

            global.lineTool.pathSimpleLine(line, fromMode, toMode);
        }

    },
    bb: function (lst, id) {
        for (var i = 0; i < lst.length; i++) {
            if (lst[i].id == id) return i;
        }
        return -1;
    },
    //计算某个节点上的连线数量，如果有重叠则增加偏移量，让连线不重叠
    aa: function (mode, index) {

        var self = this,
		global = com.xjwgraph.Global,
		baseMode = global.modeMap.get(mode.id),
		baseLineModeMap = baseMode.lineMap,
		baseLineKey = baseLineModeMap.getKeys(),
		baseLineKeyLength = baseLineKey.length;

        var ids = [];
        var lst = [];
        for (var i = baseLineKeyLength; i--; ) {
            var buildLine = baseLineModeMap.get(baseLineKey[i]),
			line = $id(buildLine.id);
            if (!line) continue;
            if (buildLine.index != index) continue;

            lst.push(buildLine);
            ids.push(baseLineKey[i]);
        }
        var lst2 = lst.slice(0);
        //按角度对数组排序，以免连线覆盖
        lst2.sort(function (A, B) {
            return A.angle - B.angle;
        });
        var tmpIndex = 0;
        tmpIndex = -lst.length / 2 * 6;
        for (var i = 0; i < lst.length; i++) {
            var tmpRow = self.bb(lst2, lst[i].id);
            lst[i].OffsetValue = tmpRow * 6 + tmpIndex;
            baseLineModeMap.put(ids[i], lst[i]);
        }

    },
    dragPoint: function (point) {

        var global = com.xjwgraph.Global;

        point.onmousedown = function (event) {

            var parentMode = point.parentNode,
			parentModeStyle = parentMode.style,

			tempModeTool = global.modeTool;

            tempModeTool.isModeCross(parentMode);

            var idIndex = global.modeTool.getModeIndex(parentMode),

			contentImage = $id("backImg" + idIndex),
			contentImageStyle = contentImage.style,
			content = $id("content" + idIndex),
			contentStyle = content.style,

			dragType = point.className,

			oldTopBaseMode = parentMode.offsetTop,
			oldLeftBaseMode = parentMode.offsetLeft,
			oldWidthBaseMode = parentMode.offsetWidth,
			oldHeightBaseMode = parentMode.offsetHeight,

			undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

			    parentModeStyle.left = oldLeftBaseMode + "px";
			    parentModeStyle.top = oldTopBaseMode + "px";
			    parentModeStyle.width = oldWidthBaseMode + "px";
			    parentModeStyle.height = oldHeightBaseMode + "px";

			    contentStyle.left = "0px";
			    contentStyle.top = "0px";
			    contentStyle.width = oldWidthBaseMode + "px";
			    contentStyle.height = oldHeightBaseMode + "px";

			    contentImageStyle.left = "0px";
			    contentImageStyle.top = "0px";
			    contentImageStyle.width = oldWidthBaseMode + "px";
			    contentImageStyle.height = oldHeightBaseMode + "px";

			    tempModeTool.showPointer(parentMode);
			    tempModeTool.changeBaseModeAndLine(parentMode, true);

			    global.smallTool.drawMode(parentMode);

			}, PathGlobal.modeDragPoint);

            global.modeTool.moveable = true;

            event = event || window.event;

            if (parentMode.setCapture) {
                parentMode.setCapture();
            } else if (window.captureEvents) {
                window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
            }

            //wsl修改
            var x = 0;
            var y = 0;
            if (global.baseTool.isIE == true) {
                x = event.offsetX;
                y = event.offsetY;
            }
            else {
                x = event.layerX ? event.layerX : event.offsetX,
				y = event.layerY ? event.layerY : event.offsetY;
            }


            stopEvent = true;

            var doc = document;

            doc.onmousemove = function (event) {

                event = event || window.event;

                if (global.modeTool.moveable) {

                    if (!event.pageX) {
                        event.pageX = event.clientX;
                    }

                    if (!event.pageY) {
                        event.pageY = event.clientY;
                    }

                    var tx = event.pageX - x,
   						ty = event.pageY - y,

   				tempPathBody = global.lineTool.pathBody,
   				leftTops = global.baseTool.sumLeftTop(tempPathBody);

                    tx = tx - parseInt(leftTops[0]) + parseInt(tempPathBody.scrollLeft);
                    ty = ty - parseInt(leftTops[1]) + parseInt(tempPathBody.scrollTop);

                    var minWidth = PathGlobal.minWidth,
   						minHeight = PathGlobal.minHeight;

                    if ("bottom_right" == dragType) {

                        if ((parseInt(tx) - parseInt(parentMode.offsetLeft)) < minWidth) {

                            contentImageStyle.width = minWidth + "px";
                            parentModeStyle.width = minWidth + "px";
                            contentStyle.width = minWidth + "px";

                        } else {

                            contentImageStyle.width = parseInt(tx) - parseInt(parentMode.offsetLeft) + "px";
                            parentModeStyle.width = parseInt(tx) - parseInt(parentMode.offsetLeft) + "px";
                            contentStyle.width = parseInt(tx) - parseInt(parentMode.offsetLeft) + "px";
                        }

                        if ((parseInt(ty) - parseInt(parentMode.offsetTop)) < minHeight) {

                            contentImageStyle.height = minHeight + "px";
                            parentModeStyle.height = minHeight + "px";
                            contentStyle.height = minHeight + "px";

                        } else {

                            contentImageStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";
                            parentModeStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";
                            contentStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";

                        }

                    } else if ("bottom_middle" == dragType) {

                        if ((parseInt(ty) - parseInt(parentMode.offsetTop)) < minHeight) {

                            contentImageStyle.height = minHeight + "px";
                            parentModeStyle.height = minHeight + "px";
                            contentStyle.height = minHeight + "px";

                        } else {

                            contentImageStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";
                            parentModeStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";
                            contentStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";

                        }

                    } else if ("bottom_left" == dragType) {

                        if (parseInt(ty) - parseInt(parentMode.offsetTop) < minHeight) {

                            contentImageStyle.height = minHeight + "px";
                            parentModeStyle.height = minHeight + "px";
                            contentStyle.height = minHeight + "px";

                        } else {

                            contentImageStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";
                            parentModeStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";
                            contentStyle.height = parseInt(ty) - parseInt(parentMode.offsetTop) + "px";

                        }

                        var newWidth = 0;

                        if (parseInt(tx) > parseInt(oldLeftBaseMode)) {

                            newWidth = parseInt(tx) - parseInt(oldLeftBaseMode);
                            newWidth = parseInt(oldWidthBaseMode) - newWidth;

                            if (newWidth <= minWidth) {

                                newWidth = minWidth;
                                tx = parseInt(oldWidthBaseMode) - minWidth + parseInt(oldLeftBaseMode);

                            }

                        } else {

                            newWidth = parseInt(oldLeftBaseMode) - parseInt(tx);
                            newWidth = parseInt(oldWidthBaseMode) + newWidth;

                            if (newWidth <= minWidth) {

                                newWidth = minWidth;
                                tx = minWidth - parseInt(oldWidthBaseMode) + parseInt(oldLeftBaseMode);

                            }
                        }

                        contentImageStyle.width = newWidth + "px";
                        parentModeStyle.width = newWidth + "px";
                        contentStyle.width = newWidth + "px";

                        parentModeStyle.left = parseInt(tx) + "px";

                    } else if ("middle_right" == dragType) {

                        if (parseInt(tx) - parseInt(parentMode.offsetLeft) < minWidth) {

                            contentImageStyle.width = minWidth + "px";
                            parentModeStyle.width = minWidth + "px";
                            contentStyle.width = minWidth + "px";

                        } else {

                            contentImageStyle.width = parseInt(tx) - parseInt(parentMode.offsetLeft) + "px";
                            parentModeStyle.width = parseInt(tx) - parseInt(parentMode.offsetLeft) + "px";
                            contentStyle.width = parseInt(tx) - parseInt(parentMode.offsetLeft) + "px";

                        }

                    } else if ("middle_left" == dragType) {

                        var newWidth = 0;

                        if (parseInt(tx) > parseInt(oldLeftBaseMode)) {

                            newWidth = parseInt(tx) - parseInt(oldLeftBaseMode);
                            newWidth = parseInt(oldWidthBaseMode) - newWidth;

                            if (newWidth <= minWidth) {

                                newWidth = minWidth;
                                tx = parseInt(oldWidthBaseMode) - minWidth + parseInt(oldLeftBaseMode);

                            }

                        } else {

                            newWidth = parseInt(oldLeftBaseMode) - parseInt(tx);
                            newWidth = parseInt(oldWidthBaseMode) + newWidth;

                            if (newWidth <= minWidth) {

                                newWidth = minWidth;
                                tx = minWidth - parseInt(oldWidthBaseMode) + parseInt(oldLeftBaseMode);

                            }
                        }

                        contentImageStyle.width = newWidth + "px";
                        parentModeStyle.width = newWidth + "px";
                        contentStyle.width = newWidth + "px";
                        parentModeStyle.left = parseInt(tx) + "px";

                    } else if ("top_right" == dragType) {

                        var newWidth = 0;

                        if (parseInt(tx) > (parseInt(oldLeftBaseMode) + parseInt(oldWidthBaseMode))) {

                            newWidth = parseInt(tx) - (parseInt(oldLeftBaseMode) + parseInt(oldWidthBaseMode));
                            newWidth = parseInt(oldWidthBaseMode) + newWidth;

                            if (newWidth <= minWidth) {
                                newWidth = minWidth;
                            }

                        } else {

                            newWidth = (parseInt(oldLeftBaseMode) + parseInt(oldWidthBaseMode)) - parseInt(tx);
                            newWidth = parseInt(oldWidthBaseMode) - newWidth;

                            if (newWidth <= minWidth) {
                                newWidth = minWidth;
                            }

                        }

                        contentImageStyle.width = newWidth + "px";
                        parentModeStyle.width = newWidth + "px";
                        contentStyle.width = newWidth + "px";

                        var newHeight = 0;

                        if (parseInt(ty) > parseInt(oldTopBaseMode)) {

                            newHeight = parseInt(ty) - parseInt(oldTopBaseMode);
                            newHeight = parseInt(oldHeightBaseMode) - parseInt(newHeight);

                            if (newHeight <= minHeight) {

                                newHeight = minHeight;
                                ty = parseInt(oldHeightBaseMode) - minHeight + parseInt(oldTopBaseMode);

                            }

                        } else {

                            newHeight = parseInt(oldTopBaseMode) - parseInt(ty);
                            newHeight = parseInt(oldHeightBaseMode) + parseInt(newHeight);

                            if (newHeight <= minHeight) {

                                newHeight = minHeight;
                                ty = minHeight - parseInt(oldHeightBaseMode) + parseInt(oldTopBaseMode);

                            }

                        }

                        contentImageStyle.height = newHeight + "px";
                        parentModeStyle.height = newHeight + "px";
                        contentStyle.height = newHeight + "px";
                        parentModeStyle.top = parseInt(ty) + "px";

                    } else if ("top_middle" == dragType) {

                        var newHeight = 0;

                        if (parseInt(ty) > parseInt(oldTopBaseMode)) {

                            newHeight = parseInt(ty) - parseInt(oldTopBaseMode);
                            newHeight = parseInt(oldHeightBaseMode) - parseInt(newHeight);

                            if (newHeight <= minHeight) {
                                newHeight = minHeight;
                                ty = parseInt(oldHeightBaseMode) + parseInt(oldTopBaseMode) - minHeight;
                            }

                        } else {

                            newHeight = parseInt(oldTopBaseMode) - parseInt(ty);
                            newHeight = parseInt(oldHeightBaseMode) + parseInt(newHeight);

                            if (newHeight <= minHeight) {

                                newHeight = minHeight;
                                ty = minHeight - parseInt(oldHeightBaseMode) + parseInt(oldTopBaseMode);

                            }

                        }

                        contentImageStyle.height = newHeight + "px";
                        contentStyle.height = newHeight + "px";
                        parentModeStyle.height = newHeight + "px";
                        parentModeStyle.top = parseInt(ty) + "px";

                    } else if ("top_left" == dragType) {

                        var newWidth = 0;

                        if (parseInt(tx) > parseInt(oldLeftBaseMode)) {

                            newWidth = parseInt(tx) - parseInt(oldLeftBaseMode);
                            newWidth = parseInt(oldWidthBaseMode) - newWidth;

                            if (newWidth <= minWidth) {

                                newWidth = minWidth;
                                tx = parseInt(oldWidthBaseMode) - minWidth + parseInt(oldLeftBaseMode);

                            }

                        } else {

                            newWidth = parseInt(oldLeftBaseMode) - parseInt(tx);
                            newWidth = parseInt(oldWidthBaseMode) + newWidth;

                            if (newWidth <= minWidth) {

                                newWidth = minWidth;
                                tx = minWidth - parseInt(oldWidthBaseMode) + parseInt(oldLeftBaseMode);

                            }
                        }

                        contentImageStyle.width = newWidth + "px";
                        parentModeStyle.width = newWidth + "px";
                        contentStyle.width = newWidth + "px";

                        var newHeight = 0;

                        if (parseInt(ty) > parseInt(oldTopBaseMode)) {

                            newHeight = parseInt(ty) - parseInt(oldTopBaseMode);
                            newHeight = parseInt(oldHeightBaseMode) - parseInt(newHeight);

                            if (newHeight <= minHeight) {
                                newHeight = minHeight;
                                ty = parseInt(oldHeightBaseMode) + parseInt(oldTopBaseMode) - minHeight;
                            }

                        } else {

                            newHeight = parseInt(oldTopBaseMode) - parseInt(ty);
                            newHeight = parseInt(oldHeightBaseMode) + parseInt(newHeight);

                            if (newHeight <= minHeight) {

                                newHeight = minHeight;
                                ty = minHeight - parseInt(oldHeightBaseMode) + parseInt(oldTopBaseMode);

                            }

                        }

                        contentImageStyle.height = newHeight + "px";
                        parentModeStyle.height = newHeight + "px";
                        contentStyle.height = newHeight + "px";

                        parentModeStyle.top = parseInt(ty) + "px";
                        parentModeStyle.left = parseInt(tx) + "px";

                    }

                    var tempModeTool = global.modeTool;

                    tempModeTool.isModeCross(parentMode);
                    tempModeTool.showPointer(parentMode);
                    tempModeTool.changeBaseModeAndLine(parentMode, true);

                    global.smallTool.drawMode(parentMode);

                }

            };

            doc.onmouseup = function (event) {

                event = event || window.event;

                global.modeTool.moveable = false;
                if (parentMode.releaseCapture) {
                    parentMode.releaseCapture();
                } else if (window.releaseEvents) {
                    window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP);
                }

                var afterTopBaseMode = parentMode.offsetTop,
				afterLeftBaseMode = parentMode.offsetLeft,
				afterWidthBaseMode = parentMode.offsetWidth,
				afterHeightBaseMode = parentMode.offsetHeight;

                undoRedoEvent.setRedo(function () {

                    parentModeStyle.left = afterLeftBaseMode + "px";
                    parentModeStyle.top = afterTopBaseMode + "px";
                    parentModeStyle.width = afterWidthBaseMode + "px";
                    parentModeStyle.height = afterHeightBaseMode + "px";

                    contentImageStyle.left = "0px";
                    contentImageStyle.top = "0px";
                    contentImageStyle.width = afterWidthBaseMode + "px";
                    contentImageStyle.height = afterHeightBaseMode + "px";

                    contentStyle.top = "0px";
                    contentStyle.left = "0px";
                    contentStyle.width = afterWidthBaseMode + "px";
                    contentStyle.height = afterHeightBaseMode + "px";

                    tempModeTool.showPointer(parentMode);
                    tempModeTool.changeBaseModeAndLine(parentMode, true);

                    global.smallTool.drawMode(parentMode);

                });

                doc.onmousemove = null;
                doc.onmouseup = null;

            };

        }

    },

    isActiveMode: function (mode) {
        return mode.style.visibility == "visible";
    },

    getActiveMode: function () {

        var activeMode,
		tempModeTool = com.xjwgraph.Global.modeTool;

        this.forEach(function (modeId) {

            var mode = $id(modeId);

            if (tempModeTool.isActiveMode(mode)) {
                activeMode = mode;
            }

        });

        return activeMode;

    },

    getSonNode: function (mode, nodeClassName) {

        for (var copyNode = mode.firstChild; copyNode != null; copyNode = copyNode.nextSibling) {

            if (copyNode.nodeType == 1) {
                var className = copyNode.className;

                if (className == nodeClassName) {
                    return copyNode;
                }

                if (className == "content" && nodeClassName == "backImg") {

                    for (var sonNode = copyNode.firstChild; sonNode != null; sonNode = sonNode.nextSibling) {

                        if (sonNode.nodeType == 1) {
                            return sonNode;
                        }

                    }

                }

            }

        }

    },

    setIndex: function (mode, idIndex) {

        mode.id = "module" + idIndex;

        for (var copyNode = mode.firstChild; copyNode != null; copyNode = copyNode.nextSibling) {

            if (copyNode.nodeType == 1) {

                var className = copyNode.className;
                copyNode.id = className + idIndex;

                if (className == "content") {

                    for (var sonNode = copyNode.firstChild; sonNode != null; sonNode = sonNode.nextSibling) {

                        if (sonNode.nodeType == 1) {
                            sonNode.id = "backImg" + idIndex;
                            break;
                        }

                    }

                }

            }

        }

        return mode;

    },

    copy: function (mode) {

        var self = this,
		copyObj = mode.cloneNode(true),
		idIndex = self.getNextIndex();

        self.setIndex(copyObj, idIndex);

        var copyObjStyle = copyObj.style;

        copyObjStyle.left = parseInt(copyObjStyle.left) + PathGlobal.copyModeDec + "px";
        copyObjStyle.top = parseInt(copyObjStyle.top) + PathGlobal.copyModeDec + "px";

        var baseMode = new BaseMode();
        baseMode.id = copyObj.id;

        var global = com.xjwgraph.Global;

        global.modeMap.put(baseMode.id, baseMode);

        var tempLineTool = global.lineTool;
        tempLineTool.pathBody.appendChild(copyObj);
        this.initEvent(idIndex);

        return copyObj;

    },

    //让对象翻滚
    flip: function (idIndex, titleHTML) {

        var mode = com.xjwgraph.Global.modeMap.get("module" + idIndex);

        if (mode.isFilp) {
            return;
        }

        mode.isFilp = true;

        var backImg = $id("backImg" + idIndex),
		tempHeight = backImg.height,
		content = $id("content" + idIndex),
		contentStyle = content.style;

        mode.modeHeigh = tempHeight;

        contentStyle.width = backImg.width + "px";
        contentStyle.fontSize = (tempHeight - parseInt(tempHeight * 0.15)) + "px";
        contentStyle.lineHeight = tempHeight + "px";
        contentStyle.height = tempHeight + "px";

        var modeDiv = $id(mode.id),
		modeDivStyle = modeDiv.style;

        modeDivStyle.width = backImg.width + "px";
        modeDivStyle.height = tempHeight + "px";

        mode.inc = mode.modeHeigh / 10;

        this.doFlip(idIndex, titleHTML);

    },

    doFlip: function (idIndex, titleHTML) {

        var backImg = $id("backImg" + idIndex);

        if (!backImg) {
            return;
        }

        var global = com.xjwgraph.Global,

		ht = backImg.height,
		mode = global.modeMap.get("module" + idIndex);

        ht = ht - mode.inc;

        if (ht < 1) {
            ht = 1;
        }

        if (ht <= 1) {

            mode.inc = -mode.inc;

        } else if (ht >= mode.modeHeigh) {

            $id("backImg" + idIndex).style.height = mode.modeHeigh + "px";
            mode.modeHeigh = 0;
            mode.isFilp = false;
            mode.inc = -mode.inc;

            var contentStyle = $id("content" + idIndex).style;

            contentStyle.width = 0 + "px";
            contentStyle.height = 0 + "px";
            contentStyle.lineHeight = 0 + "px";
            contentStyle.fontSize = 0 + "px";

            var titleDiv = $id("title" + idIndex);

            if (titleHTML == 'undefined' || !titleHTML) {
            } else {
                titleDiv.innerHTML = titleHTML;
            }

            this.showPointerId(idIndex);

            return;

        } else {
            $id("backImg" + idIndex).style.height = ht + "px";
        }

        setTimeout(function () {
            global.modeTool.doFlip(idIndex, titleHTML);
        }, PathGlobal.pauseTime);

    },

    //是否交叉
    isModeCross: function (moveMode) {

        var moveModeLeft = parseInt(moveMode.offsetLeft),
  	moveModeWidth = moveMode.offsetWidth + moveModeLeft,
  	moveModeWidthHlef = parseInt(moveMode.offsetWidth / 2) + moveModeLeft,

		moveModeTop = parseInt(moveMode.offsetTop),
		moveModeHeight = moveMode.offsetHeight + moveModeTop,
		moveModeHeightHlef = parseInt(moveMode.offsetHeight / 2) + moveModeTop,

		leftCross = $id("leftCross"),
		topCross = $id("topCross"),

		leftCrossStyle = leftCross.style,
		topCrossStyle = topCross.style,

	  modeKeys = com.xjwgraph.Global.modeMap.getKeys(),

	  isTopCross = false,
	  isLeftCross = false,
	  modeKeysLength = modeKeys.length;

        for (var i = modeKeysLength; i--; ) {

            var mode = $id(modeKeys[i]);

            if (moveMode.id == mode.id) {
                continue;
            }

            var left = parseInt(mode.offsetLeft),
			xWidth = mode.offsetWidth + left,
			xWidthHlef = parseInt(mode.offsetWidth / 2) + left,

			top = parseInt(mode.offsetTop),
			yHeight = mode.offsetHeight + top,
			yHeightHlef = parseInt(mode.offsetHeight / 2) + top;

            if (moveModeLeft == left || moveModeLeft == xWidth) {

                leftCross.style.left = moveModeLeft;
                isLeftCross = true;
                leftCross.style.visibility = "visible";

            }

            if (moveModeWidth == left || moveModeWidth == xWidth) {

                leftCrossStyle.left = moveModeWidth;
                isLeftCross = true;
                leftCrossStyle.visibility = "visible";

            }

            if (moveModeWidthHlef == left || moveModeWidthHlef == xWidthHlef) {

                leftCrossStyle.left = moveModeWidthHlef;
                isLeftCross = true;
                leftCrossStyle.visibility = "visible";

            }

            if (moveModeWidthHlef == xWidth) {

                leftCrossStyle.left = moveModeWidthHlef;
                isLeftCross = true;
                leftCrossStyle.visibility = "visible";

            }

            if (moveModeLeft == xWidthHlef || moveModeWidth == xWidthHlef) {

                leftCrossStyle.left = xWidthHlef;
                isLeftCross = true;
                leftCrossStyle.visibility = "visible";

            }

            if (moveModeTop == top || moveModeTop == yHeight) {

                topCrossStyle.top = moveModeTop;
                isTopCross = true;
                topCrossStyle.visibility = "visible";

            }

            if (moveModeTop == yHeightHlef || yHeightHlef == moveModeHeightHlef || yHeightHlef == moveModeHeight) {

                topCrossStyle.top = yHeightHlef;
                isTopCross = true;
                topCrossStyle.visibility = "visible";

            }

            if (moveModeHeightHlef == top || moveModeHeightHlef == yHeight) {

                topCrossStyle.top = moveModeHeightHlef;
                isTopCross = true;
                topCrossStyle.visibility = "visible";

            }

            if (yHeightHlef == moveModeHeightHlef) {

                topCrossStyle.top = yHeightHlef;
                isTopCross = true;
                topCrossStyle.visibility = "visible";

            }

            if (moveModeHeight == top || moveModeHeight == yHeight) {

                topCrossStyle.top = moveModeHeight;
                isTopCross = true;
                topCrossStyle.visibility = "visible";

            }

        }

        if (!isTopCross) {
            topCrossStyle.visibility = "hidden";
        }

        if (!isLeftCross) {
            leftCrossStyle.visibility = "hidden";
        }
    },
    //计算某条线路，附着于某个点的那个位置，具体坐标
    calculateLinePointer: function (line, mode) {
        var global = com.xjwgraph.Global;
        var baseMode = global.modeMap.get(mode.id),
		baseLineModeMap = baseMode.lineMap,
		baseLineKey = baseLineModeMap.getKeys(),
		baseLineKeyLength = baseLineKey.length;


        var buildLine = null;
        for (var i = baseLineKeyLength; i--; ) {

            buildLine = baseLineModeMap.get(baseLineKey[i]);
            if (buildLine.id != line.id) continue;
            break;
        }
        if (buildLine == null) {

            alert("线路和节点没有关系");
            return;
        }

        var offsetValue = 0;// buildLine.OffsetValue;   //偏移值，如果没有则为0
        if (!offsetValue) offsetValue = 0;

        var modeCenterX = mode.offsetLeft + mode.offsetWidth / 2;
        var modeCenterY = mode.offsetTop + mode.offsetHeight / 2;

        var pointer = new Point();
        switch (buildLine.index) {
            case PathGlobal.pointTypeLeftUp:   //左上
                pointer.x = modeCenterX - mode.offsetWidth / 2;
                pointer.y = modeCenterY - mode.offsetHeight / 2;
                break;
            case PathGlobal.pointTypeUp:   //上 
                pointer.x = modeCenterX + offsetValue + 6;
                pointer.y = modeCenterY - mode.offsetHeight / 2;
                break;
            case PathGlobal.pointTypeUpRight:   //右上
                pointer.x = modeCenterX + mode.offsetWidth / 2;
                pointer.y = modeCenterY - mode.offsetHeight / 2;
                break;
            case PathGlobal.pointTypeLeft:   //左                 
                pointer.x = modeCenterX - mode.offsetWidth / 2;
                pointer.y = modeCenterY + offsetValue + 6;
                break;
            case PathGlobal.pointTypeRight:   //右 
                pointer.x = modeCenterX + mode.offsetWidth / 2;
                pointer.y = modeCenterY + offsetValue + 6;
                break;
            case PathGlobal.pointTypeLeftDown:   //左下
                pointer.x = modeCenterX - mode.offsetWidth / 2;
                pointer.y = modeCenterY + mode.offsetHeight / 2;
                break;
            case PathGlobal.pointTypeDown:   //下 
                pointer.x = modeCenterX + offsetValue + 5;
                pointer.y = modeCenterY + mode.offsetHeight / 2;
                break;
            case PathGlobal.pointTypeDownRight:   //右下
                pointer.x = modeCenterX + mode.offsetWidth / 2;
                pointer.y = modeCenterY + mode.offsetHeight / 2;
                break;
            default:

                alert("无法识别的连线类型");
        }
        return pointer;
    },
    //计算两个节点之间夹角
    calcuateAngle: function (fromMode, toMode) {
        var self = this;


        var fromCenterX = fromMode.offsetLeft + fromMode.offsetWidth / 2;
        var fromCenterY = fromMode.offsetTop + fromMode.offsetHeight / 2;

        var toCenterX = toMode.offsetLeft + toMode.offsetWidth / 2;
        var toCenterY = toMode.offsetTop + toMode.offsetHeight / 2;

        var width = toCenterX - fromCenterX;
        var height = -(toCenterY - fromCenterY);

        if (width == 0) {

        }
        if (width == 0) {
            if (height > 0)
                return 270;    //返回270度
            else
                return 90;     //返回90度
        }

        var angle = Math.atan(Math.abs(height) / Math.abs(width)) * 180 / 3.1415926;  //计算角度
        if (width < 0 && height >= 0)
            angle = 180 - angle;
        else if (width < 0 && height < 0)
            angle = 180 + angle;
        else if (width > 0 && height < 0)
            angle = 360 - angle;

        return angle;
    },
    //计算方向 (返回的是发送端方向)
    calculateDirection: function (angle) {
        var self = this;
        //  var angle = self.calcuateAngle(fromMode, toMode);

        // 正上下左右，夹角是60度， 斜向夹角是30度

        if (angle <= 30 || angle >= 330) return PathGlobal.pointTypeRight;
        if (angle > 30 && angle <= 60) return PathGlobal.pointTypeUpRight;
        if (angle > 60 && angle <= 120) return PathGlobal.pointTypeUp;
        if (angle > 120 && angle <= 150) return PathGlobal.pointTypeLeftUp;
        if (angle > 150 && angle <= 210) return PathGlobal.pointTypeLeft;
        if (angle > 210 && angle <= 240) return PathGlobal.pointTypeLeftDown;
        if (angle > 240 && angle <= 300) return PathGlobal.pointTypeDown;
        if (angle > 300 && angle <= 330) return PathGlobal.pointTypeDownRight;

        return;
    },
    //计算连线类型，左右型和上下型
    calculateLineType: function (fromMode, toMode) {
        var self = this;
        var angle = self.calcuateAngle(fromMode, toMode);

        if (angle < 45 || angle >= 315) return 3;
        if (angle >= 135 && angle < 225) return 3;

        if (angle >= 45 && angle < 135) return 2;
        if (angle >= 225 && angle < 315) return 2;
        return 1;
    }

}