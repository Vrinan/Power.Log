var LineTool = com.xjwgraph.LineTool = function (pathBody) {

    var self = this;

    self.stepIndex = PathGlobal.lineDefStep;
    self.pathBody = pathBody;

    var global = com.xjwgraph.Global;

    self.tool = global.baseTool;
    self.moveable = false;
    self.isSVG = self.tool.isSVG();
    self.isVML = self.tool.isVML();

    self.pathBody.oncontextmenu = function (event) {
        if (PathGlobal.WorkFlowMode != "WorkFlowDesign"  ) return;    //如果不是设计模式，不允许拖曳

        if (!PathGlobal.rightLineMenu && !PathGlobal.rightMenu) {

            PathGlobal.rightMenu = true;
            PathGlobal.rightLineMenu = true;
            global.baseTool.showMenu(event);
        }
        return false;
    }

    self.baseLineIdIndex = PathGlobal.lineDefIndex;

    if (self.isSVG) {

        var doc = document;

        self.svgBody = doc.createElementNS('http://www.w3.org/2000/svg', 'svg');
        self.svgBody.setAttribute("id", "svgContext");
        self.svgBody.setAttribute("style", "position:absolute;z-index:0;");
        self.svgBody.setAttribute("height", this.pathBody.scrollHeight + "px");
        self.svgBody.setAttribute("width", this.pathBody.scrollWidth + "px");

        var marker = doc.createElementNS('http://www.w3.org/2000/svg', 'marker');
        marker.setAttribute("id", "arrow");
        marker.setAttribute("viewBox", "0 0 18 20");
        marker.setAttribute("refX", "0");
        marker.setAttribute("refY", "10");
        marker.setAttribute("markerUnits", "strokeWidth");
        marker.setAttribute("markerWidth", "4");
        marker.setAttribute("markerHeight", "10");
        marker.setAttribute("orient", "auto");

        var linePath = doc.createElementNS('http://www.w3.org/2000/svg', 'path');
        linePath.setAttribute("d", "M 0 0 L 20 10 L 0 20 z");
        linePath.setAttribute("fill", PathGlobal.lineColor);
        linePath.setAttribute("stroke", PathGlobal.lineColor);
    
        marker.appendChild(linePath); 
        self.svgBody.appendChild(marker);
        self.pathBody.appendChild(self.svgBody);

        self.pathBody.addEventListener("scroll", function () {
            global.smallTool.initSmallBody();
        }, false);

    } else if (self.isVML) {

        self.pathBody.attachEvent("onscroll", function () {
            global.smallTool.initSmallBody();
        });

    }

}

LineTool.prototype = {
    showMenu: function (event, line) {

        PathGlobal.rightLineMenu = true;

        var self = this;


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

        var rightLineMenu = $id("rightLineMenu"),
		rightLineMenuStyle = rightLineMenu.style;
        rightLineMenuStyle.top = ty + "px";
        rightLineMenuStyle.left = tx + "px";
        rightLineMenuStyle.visibility = "visible";
        rightLineMenuStyle.zIndex = self.getNextIndex();


        rightLineMenu.lineTag = line.id;
    },
    removeAll: function () {

        var self = this;

        self.forEach(function (lineId) {
            self.removeLine(lineId);
        });

    },

    removeLine: function (lineId) {

        var self = this,
		line = $id(lineId);

        if (self.isVML && line) {
            self.pathBody.removeChild(line);
        } else if (self.isSVG && line) {
            self.svgBody.removeChild(line);
        }

        var global = com.xjwgraph.Global;
        global.lineMap.remove(lineId);

        if (line) {
            global.smallTool.removeLine(lineId);
        }

    },

    formatPath: function (path) {

        if (this.isVML) {
            path = path.replaceAll(",", " ");
            path = path.replaceAll("e", "z");
            path = path.replaceAll("l", "L ");
        }

        return path;

    },

    getNextIndex: function () {

        var self = this;
        self.baseLineIdIndex += self.stepIndex;

        return self.baseLineIdIndex;

    },

    getActiveLine: function () {

        var activeLine;

        this.forEach(function (lineId) {

            var line = $id(lineId);

            if (com.xjwgraph.Global.lineTool.isActiveLine(line)) {
                activeMode = line;
            }

        });

        return activeLine;

    },

    isActiveLine: function (line) {

        var isActive,
		global = com.xjwgraph.Global;

        if (global.lineTool.isVML) {
            isActive = (line.getAttribute("strokecolor") == PathGlobal.lineCheckColor);
        } else if (global.lineTool.isSVG) {
            isActive = (line.getAttribute("style").indexOf(PathGlobal.lineCheckColor) > 0);
        }

        return isActive;

    },

    forEach: function (fn) {

        var lineKeys = com.xjwgraph.Global.lineMap.getKeys(),
  	lineKeysLength = lineKeys.length;

        for (var i = lineKeysLength; i--; ) {

            if (fn) {
                fn(lineKeys[i]);
            }

        }

    },

    createBaseLine: function (lineId, path, brokenType) {
        var tempLineTool = com.xjwgraph.Global.baseTool;
        var self = this,
		line = null,

		doc = document;

        if (self.isSVG) {

            line = doc.createElementNS('http://www.w3.org/2000/svg', "path");
            line.setAttribute("id", lineId);
            line.setAttribute("style", "cursor:pointer; fill:none; stroke:" + PathGlobal.lineColor + "; stroke-width:" + PathGlobal.strokeweight);
            line.setAttribute("stroke", "purple");
            line.setAttribute("marker-end", 'url(#arrow)');
            line.setAttribute("brokenType", brokenType);

            self.setPath(line, path);
            self.drag(line);
            self.svgBody.appendChild(line);

        } else if (self.isVML) {

            line = doc.createElement('<v:shape style="cursor:pointer;WIDTH:100;POSITION:absolute;HEIGHT:100" coordsize="100,100" filled="f" strokeweight="' + PathGlobal.strokeweight + 'px" strokecolor="' + PathGlobal.lineColor + '"></v:shape>');

            var stroke = doc.createElement("<v:stroke EndArrow='classic'/>");
            line.appendChild(stroke);

            line.setAttribute("id", lineId);
            line.setAttribute("brokenType", brokenType);

            self.setPath(line, path);

            self.drag(line);
            self.pathBody.appendChild(line);

        }
        return line;

    },

    setPath: function (line, path) {

        var self = this;

        if (self.isSVG) {
            path = path.replace("z", "");
        }

        line.setAttribute("d", path);
        line.setAttribute("path", path);

    },

    getLineHead: function (path) {

        path = path.replace("M", "");
        path = path.replace("m", "");
        path = path.replace("z", "");

        var paths = path.split("L"),

		head = this.strTrim(paths[0]).split(" "),

		left = parseInt(head[0]),
		top = parseInt(head[1]);

        return [left, top];

    },

    getLineEnd: function (path) {

        path = path.replace("M", "");
        path = path.replace("m", "");
        path = path.replace("z", "");

        var paths = path.split("L"),

		self = this,
		endStr = self.strTrim(paths[1]),

		end;

        if (endStr.indexOf(",") > 0) {
            end = endStr.split(",");
            end = self.strTrim(end[end.length - 1]).split(" ");
        } else {
            end = endStr.split(" ");
            end = [end[end.length - 2], end[end.length - 1]];
        }

        return [parseInt(end[0]), parseInt(end[1])];

    },

    brokenPath: function (path, brokenType) {

        var self = this,

		head = self.getLineHead(path),
		left = head[0],
		top = head[1],

		end = self.getLineEnd(path),
		endLeft = end[0],
		endTop = end[1];

        if (brokenType == 2) {
            path = self.brokenVertical(left, top, endLeft, endTop);
        } else if (brokenType == 3) {
            path = self.brokenCross(left, top, endLeft, endTop);
        }

        return path;

    },

    broken: function (left, top, endLeft, endTop, brokenType) {

        if (brokenType == 2) {
            path = this.brokenVertical(left, top, endLeft, endTop > top ? (endTop - 7) : (endTop + 7));
        } else if (brokenType == 3) {
            path = this.brokenCross(left, top, endLeft > left ? (endLeft - 7) : (endLeft + 7), endTop);
        }

        return path;

    },

    brokenVertical: function (left, top, endLeft, endTop) {

        var descTop = endTop - top;
        var path = null;

        if (left != endLeft) {
            path = "M " + left + " " + top + " L " +
		(left) + " " + (top + parseInt(descTop / 2)) +
		"," + (endLeft) + " " + (endTop - parseInt(descTop / 2)) +
		"," + endLeft + " " + endTop + " z";
        }
        else {
            path = "M " + left + " " + top + " L " +
		    endLeft + " " + endTop + " z";
        }

        return path;

    },

    brokenCross: function (left, top, endLeft, endTop) {

        var descLeft = endLeft - left,

		path = "M " + left + " " + top + " L " +
		(left + parseInt(descLeft / 2)) + " " + (top) +
		"," + (left + parseInt(descLeft / 2)) + " " + (endTop) +
		"," + endLeft + " " + endTop + " z";

        return path;

    },

    create: function (left, top, brokenType) {

        var self = this,
		idIndex = self.getNextIndex(),

		path = "M " + left + " " + top + " L " + (left + 100) + " " + top + " z";

        if (brokenType != 1) {
            path = "M " + left + " " + top + " L " + (left + 100) + " " + (top + 60) + " z";
            path = self.brokenPath(path, brokenType);
        }

        var lineId = "line" + idIndex;
        var line = self.createBaseLine(lineId, path, brokenType);


        var lineMode = new BuildLine();
        lineMode.id = "line" + idIndex;

        var global = com.xjwgraph.Global;

        global.lineMap.put(lineMode.id, lineMode);

        var tempSmallTool = global.smallTool,

		undoRedoLineEvent = new com.xjwgraph.UndoRedoEvent(function () {

		    var isExist = line && line.id && $id(line.id);

		    if (self.isVML && isExist) {
		        self.pathBody.removeChild(line);
		    } else if (self.isSVG && isExist) {
		        self.svgBody.removeChild(line);
		    }

		    global.lineMap.remove(lineMode.id);

		    if (isExist) {
		        tempSmallTool.removeLine(lineMode.id);
		    }

		}, PathGlobal.lineCreate);

        undoRedoLineEvent.setRedo(function () {

            if (self.isVML) {

                line.setAttribute("filled", "f");
                line.setAttribute("strokeweight", PathGlobal.strokeweight + "px");
                line.setAttribute("strokecolor", PathGlobal.lineColor);

                self.pathBody.appendChild(line);

            } else if (self.isSVG) {
                self.svgBody.appendChild(line);
            }

            global.lineMap.put(line.id, lineMode);
            tempSmallTool.drawLine(line);

        });
        return lineId;
    },

    getPath: function (line) {

        var self = this,
		pathStr = "";

        if (self.isSVG) {
            pathStr = line.getAttribute("d");
        } else {
            pathStr = line.path + "";
            pathStr = self.formatPath(pathStr);
        }

        return pathStr;

    },

    distancePoint: function (x, y, line) {

        var self = this,

		pathStr = this.getPath(line),

		head = self.getLineHead(pathStr),
		end = self.getLineEnd(pathStr),

		x1 = parseInt(head[0]),
		y1 = parseInt(head[1]),

		x2 = parseInt(end[0]),
		y2 = parseInt(end[1]),

		disPoint1 = Math.abs(Math.sqrt(Math.pow(x1 - x, 2) + Math.pow(y1 - y, 2))),
		disPoint2 = Math.abs(Math.sqrt(Math.pow(x2 - x, 2) + Math.pow(y2 - y, 2)));

        return disPoint1 <= disPoint2;

    },

    strTrim: function (text) {

        text = text.replace(/^\s+/, "");

        for (var i = text.length - 1; i >= 0; i--) {

            if (/\S/.test(text.charAt(i))) {
                text = text.substring(0, i + 1);
                break;
            }

        }

        return text;

    },

    initScaling: function (multiple) {

        var self = this,
		tempSmalTool = com.xjwgraph.Global.smallTool;

        self.forEach(function (lineId) {

            var line = $id(lineId),
			path = self.formatPath(self.getPath(line)),

			headPoint = self.getLineHead(path),
			endPoint = self.getLineEnd(path),

			brokenType = line.getAttribute("brokenType");

            path = self.headPoint(parseInt(headPoint[0] / multiple), parseInt(headPoint[1] / multiple), path, brokenType);
            path = self.endPoint(parseInt(endPoint[0] / multiple), parseInt(endPoint[1] / multiple), path, brokenType);

            self.setPath(line, path);

            tempSmalTool.drawLine(line);

        });

    },

    getEndPoint: function (path) {

        var paths = path.split("L");
        paths[1] = this.strTrim(paths[1]);

        return paths[1].split(" ");

    },

    getHeadPoint: function (path) {

        var paths = path.split("L");
        paths[0] = this.strTrim(paths[0]);

        return paths[0].split(" ");

    },

    endPoint: function (x, y, path, brokenType) {

        var self = this,
		newPath;

        if (brokenType != 1) {

            var head = self.getLineHead(path);
            newPath = self.broken(parseInt(head[0]), parseInt(head[1]), x, y, brokenType);

        } else {

            var paths = path.split("L");
            paths[0] = this.strTrim(paths[0]);

            newPath = paths[0] + " L " + x + " " + y + " z";

        }

        return newPath;

    },

    headPoint: function (x, y, path, brokenType) {

        var self = this,
		newPath;

        if (brokenType != 1) {

            var end = self.getLineEnd(path);
            newPath = self.broken(x, y, parseInt(end[0]), parseInt(end[1]), brokenType);

        } else {

            var paths = path.split("L");
            paths[1] = this.strTrim(paths[1]);
            newPath = "M " + x + " " + y + " L " + paths[1];

        }

        return newPath;

    },

    vecMultiply: function (p1, p2, p3) {
        return ((p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y));
    },

    poInTrigon: function (p1, p2, p3, p) {

        var self = this,

		re1 = self.vecMultiply(p1, p, p2),
		re2 = self.vecMultiply(p2, p, p3),
		re3 = self.vecMultiply(p3, p, p1);

        if (re1 * re2 * re3 == 0) {
            return false;
        }

        if ((re1 > 0 && re2 > 0 && re3 > 0) || (re1 < 0 && re2 < 0 && re3 < 0)) {
            return true;
        }

        return false;

    },

    buildModeAndPoint: function (line, mode, x, y) {

        var w = mode.offsetWidth,
		h = mode.offsetHeight,

		point = new Point(),
		pointA = new Point();

        pointA.x = parseInt(mode.offsetLeft);
        pointA.y = parseInt(mode.offsetTop);

        var pointB = new Point();
        pointB.x = parseInt(mode.offsetLeft) + parseInt(w);
        pointB.y = parseInt(mode.offsetTop);

        var pointC = new Point();
        pointC.x = parseInt(mode.offsetLeft) + parseInt(w) / 2;
        pointC.y = parseInt(mode.offsetTop) + parseInt(h) / 2;

        var pointD = new Point();
        pointD.x = x;
        pointD.y = y;

        var self = this;

        if (self.poInTrigon(pointA, pointB, pointC, pointD)) {

            point.x = "0px";
            point.y = w / 2 + "px";
            point.index = PathGlobal.pointTypeUp;

        }

        pointB.x = parseInt(mode.offsetLeft);
        pointB.y = parseInt(mode.offsetTop) + parseInt(h);

        if (self.poInTrigon(pointA, pointB, pointC, pointD)) {

            point.x = h / 2 + "px";
            point.y = "0px";
            point.index = PathGlobal.pointTypeLeft;

        }

        pointA.x = parseInt(mode.offsetLeft) + parseInt(w);
        pointA.y = parseInt(mode.offsetTop) + parseInt(h);

        if (self.poInTrigon(pointA, pointB, pointC, pointD)) {

            point.x = h + "px";
            point.y = w / 2 + "px";
            point.index = PathGlobal.pointTypeDown;

        }

        pointB.x = parseInt(mode.offsetLeft) + parseInt(w);
        pointB.y = parseInt(mode.offsetTop);

        if (self.poInTrigon(pointA, pointB, pointC, pointD)) {

            point.x = h / 2 + "px";
            point.y = w + "px";
            point.index = PathGlobal.pointTypeRight;

        }

        point.x = parseInt(mode.offsetTop) + parseInt(point.x);
        point.y = parseInt(mode.offsetLeft) + parseInt(point.y);

        return point;

    },
    //从一个节点绘制一根线到另外个节点
    buildLineAndByModes: function (line, fromMode, toMode) {

        var self = this;
        var fromBuildLine = new BuildLine();
        var toBuildLine = new BuildLine();


        var tempModeTool = com.xjwgraph.Global.modeTool;
        line.setAttribute("brokenType", tempModeTool.calculateLineType(fromMode, toMode));   //判断线路类型，上下型还是左右型
        fromBuildLine.angle = tempModeTool.calcuateAngle(fromMode, toMode);  //计算夹角
        fromBuildLine.index = tempModeTool.calculateDirection(fromBuildLine.angle);  //求取连线方向  
        fromBuildLine.id = line.id;

        var global = com.xjwgraph.Global,
		fromBaseMode = global.modeMap.get(fromMode.id),
        toBaseMode = global.modeMap.get(toMode.id);
        fromBuildLine.type = true;
        fromBaseMode.lineMap.put(fromBuildLine.id + "-" + "true", fromBuildLine);


        toBuildLine.type = false;
        toBuildLine.angle = tempModeTool.calcuateAngle(toMode, fromMode);  //计算夹角
        toBuildLine.index = tempModeTool.calculateDirection(toBuildLine.angle);  //求取连线方向  
        toBuildLine.id = line.id;
        toBaseMode.lineMap.put(toBuildLine.id + "-" + "false", toBuildLine);

        var lineMode = global.lineMap.get(line.id);

        lineMode.xBaseMode = fromBaseMode;
        lineMode.xIndex = fromBuildLine.index;

        lineMode.wBaseMode = toBaseMode;
        lineMode.wIndex = toBuildLine.index;
        global.lineMap.put(line.id, lineMode);

        self.pathSimpleLine(line, fromMode, toMode);   //从一个节点绘制一根线到目标节点

        var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {
            lineMode.xBaseMode = null;
            lineMode.wBaseMode = null;
            fromBaseMode.lineMap.remove(fromBuildLine.id + "-" + "true");
            toBaseMode.lineMap.remove(toBuildLine.id + "-" + "false");

        }, PathGlobal.buildLineAndByModes);

        undoRedoEvent.setRedo(function () {

            lineMode.xBaseMode = fromMode;
            lineMode.wBaseMode = toMode;
            fromBaseMode.lineMap.put(fromBuildLine.id + "-" + "true", fromBuildLine);
            toBaseMode.lineMap.put(toBuildLine.id + "-" + "false", toBuildLine);

        });

    },


    buildLineAndMode: function (line, mode, x, y, isPoint1) {

        var self = this,
      	point = self.buildModeAndPoint(line, mode, x, y),

		buildLine = new BuildLine();
        buildLine.index = point.index;

        buildLine.id = line.id;

        self.pathLine(point.y, point.x, line, isPoint1);

        var global = com.xjwgraph.Global,

		baseMode = global.modeMap.get(mode.id);
        buildLine.type = isPoint1;
        baseMode.lineMap.put(buildLine.id + "-" + buildLine.type, buildLine);

        var lineMode = global.lineMap.get(line.id);

        if (isPoint1) {
            lineMode.xBaseMode = baseMode;
            lineMode.xIndex = point.index;
        } else {
            lineMode.wBaseMode = baseMode;
            lineMode.wIndex = point.index;
        }

        global.lineMap.put(line.id, lineMode);

        var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

            if (isPoint1) {
                lineMode.xBaseMode = null;
            } else {
                lineMode.wBaseMode = null;
            }

            baseMode.lineMap.remove(buildLine.id + "-" + buildLine.type);

        }, PathGlobal.buildLineAndMode);

        undoRedoEvent.setRedo(function () {

            if (isPoint1) {
                lineMode.xBaseMode = baseMode;
            } else {
                lineMode.wBaseMode = baseMode;
            }

            baseMode.lineMap.put(buildLine.id + "-" + buildLine.type, buildLine);

        });

    },
    //判断两个节点之间是否已经有连线,true 说明已经有
    checkModeLine: function (fromMode, toMode) {
        var global = com.xjwgraph.Global,
		baseMode = global.modeMap.get(fromMode.id),
		baseLineModeMap = baseMode.lineMap,
		baseLineKey = baseLineModeMap.getKeys(),
		baseLineKeyLength = baseLineKey.length;

        var self = this;
        for (var i = baseLineKeyLength; i--; ) {
            var buildLine = baseLineModeMap.get(baseLineKey[i]),
			line = $id(buildLine.id);
            if (!line) continue;

            var lineMode = global.lineMap.get(line.id);
            var fromBaseMode = lineMode.xBaseMode;
            var toBaseMode = lineMode.wBaseMode;

            if (fromBaseMode.id == fromMode.id && toBaseMode.id == toMode.id) return true;  //
        }
        return false;
    },
     //获取两个节点之间的连线，和checkModeLine 配套使用
    getModeLine: function (fromMode, toMode) {
        var global = com.xjwgraph.Global,
		baseMode = global.modeMap.get(fromMode.id),
		baseLineModeMap = baseMode.lineMap,
		baseLineKey = baseLineModeMap.getKeys(),
		baseLineKeyLength = baseLineKey.length;

        var self = this;
        for (var i = baseLineKeyLength; i--; ) {
            var buildLine = baseLineModeMap.get(baseLineKey[i]),
			line = $id(buildLine.id);
            if (!line) continue;

            var lineMode = global.lineMap.get(line.id);
            var fromBaseMode = lineMode.xBaseMode;
            var toBaseMode = lineMode.wBaseMode;

            if (fromBaseMode.id == fromMode.id && toBaseMode.id == toMode.id) return line.id;  //
        }
        return null;
    },
    //从fromNode 绘制一根线到 toNode
    buildLineAndTwoMode: function (line, fromMode, toMode, isPoint1) {
        //在两个节点之间绘制一条线

        this.buildLineAndByModes(line, fromMode, toMode);


    },
    removeBuildLineAndMode: function (line, mode, isPoint1) {

        var global = com.xjwgraph.Global,

		baseMode = global.modeMap.get(mode.id),
  	    baseLineModeMap = baseMode.lineMap,
		key = line.id + "-" + isPoint1;

        if (baseLineModeMap.containsKey(key)) {

            baseMode.lineMap.remove(key);
            var lineMode = global.lineMap.get(line.id);

            if (lineMode && lineMode.xBaseMode && lineMode.xBaseMode.id == mode.id) {
                lineMode.xBaseMode = null;
            } else if (lineMode && lineMode.wBaseMode && lineMode.wBaseMode.id == mode.id) {
                lineMode.wBaseMode = null;
            }
        }
    },


    isCoverBaseMode: function (x, y, line, isPoint1) {

        var global = com.xjwgraph.Global,

		modeKeys = global.modeMap.getKeys(),
		modeKeysLength = modeKeys.length,
		tempModeTool = global.modeTool,

		self = this,

		activeMode = global.modeTool.getActiveMode();

        if (activeMode) {

            tempModeTool.hiddPointer(activeMode);
            tempModeTool.flip(global.modeTool.getModeIndex(activeMode));

            self.buildLineAndMode(line, activeMode, x, y, isPoint1);
        }

        for (var i = modeKeysLength; i--; ) {

            var mode = $id(modeKeys[i]),
			modeStyle = mode.style,

			left = parseInt(modeStyle.left),
			xWidth = mode.offsetWidth + left,

  		    top = parseInt(modeStyle.top),
  		    yHeight = mode.offsetHeight + top;

            if (activeMode && activeMode.id == mode.id) {
                continue;
            } else {
                tempModeTool.hiddPointer(mode);
                self.removeBuildLineAndMode(line, mode, isPoint1);
            }
        }
    },
    //简单绘制线
    pathSimpleLine: function (line, fromMode, toMode) {
        var self = this,
		oldPath = self.getPath(line),
		newPath,
		brokenType = line.getAttribute("brokenType");

        var tempModeTool = com.xjwgraph.Global.modeTool;
        var fromPointer = tempModeTool.calculateLinePointer(line, fromMode);  //求取连线方向   
        var toPointer = tempModeTool.calculateLinePointer(line, toMode);  //求取连线方向  

        //如果是IE10，则需要删除线对象，再添加线对象，否则箭头不会联动
        if (com.xjwgraph.Global.baseTool.isIE10 == true || com.xjwgraph.Global.baseTool.isIE11 == true) {
           self.svgBody.removeChild(line);
        }
        self.pathLine(fromPointer.x, fromPointer.y, line, true);
        self.pathLine(toPointer.x, toPointer.y, line, false);

        //如果是IE10，则需要删除线对象，再添加线对象，否则箭头不会联动
        if (com.xjwgraph.Global.baseTool.isIE10 == true || com.xjwgraph.Global.baseTool.isIE11 == true) {
            self.svgBody.appendChild(line);
        }

        com.xjwgraph.Global.smallTool.drawLine(line);
    },
    pathLine: function (x1, y1, line, isPoint1) {

        var self = this,
		oldPath = self.getPath(line),
		newPath,
		brokenType = line.getAttribute("brokenType");

        if (isPoint1) {
            newPath = self.headPoint(parseInt(x1), parseInt(y1), oldPath, brokenType);
        } else {
            newPath = self.endPoint(parseInt(x1), parseInt(y1), oldPath, brokenType);
        }

        self.setPath(line, newPath);

        com.xjwgraph.Global.smallTool.drawLine(line);

    },

    drag: function (line) {

        var global = com.xjwgraph.Global;
        global.smallTool.drawLine(line);
        var tempLineTool = global.lineTool;
        line.ondragstart = function () {
            return false;
        };
        line.oncontextmenu = function (event) {
            if (PathGlobal.WorkFlowMode != "WorkFlowDesign"  ) return;    //如果不是设计模式，不允许拖曳

            global.lineTool.showMenu(event, line);
            return false;

        }
        line.onmouseup = function (event) {
            if (PathGlobal.WorkFlowMode != "WorkFlowDesign"  ) return;    //如果不是设计模式，不允许拖曳

            if (event.button != 2) return;  //必须是右键
            event.cancelBubble = true;
            event.returnvalue = false;
            global.lineTool.showMenu(event, line);
            return false;

        }
        line.onmousedown = function (event) {

            return;
            event = event || window.event;

            var tempLineTool = global.lineTool;

            global.modeTool.clear();

            tempLineTool.moveable = true;

            if (tempLineTool.isVML) {
                line.setAttribute("strokecolor", PathGlobal.lineCheckColor);
            } else if (global.lineTool.isSVG) {
                line.setAttribute("style", "cursor:pointer;fill:none; stroke:" + PathGlobal.lineCheckColor + "; stroke-width:" + PathGlobal.strokeweight);
            }

            var tempSmallTool = global.smallTool,
			oldPath = tempLineTool.getPath(line),

			x = event.clientX ? event.clientX : event.offsetX,
			y = event.clientY ? event.clientY : event.offsetY,

			tempPathBody = tempLineTool.pathBody,
			leftTops = global.baseTool.sumLeftTop(tempPathBody);

            x = x - parseInt(leftTops[0]) + parseInt(tempPathBody.scrollLeft);
            y = y - parseInt(leftTops[1]) + parseInt(tempPathBody.scrollTop);

            if (!event.pageX) {
                event.pageX = event.clientX;
            }

            if (!event.pageY) {
                event.pageY = event.clientY;
            }

            var tx = event.clientX - x,
   				ty = event.clientY - y,

			isPoint1 = tempLineTool.distancePoint(x, y, line),
			doc = document;

            doc.onmousemove = function (event) {
                return;
                event = event || window.event;

                if (tempLineTool.moveable) {

                    var x1 = event.clientX ? event.clientX : event.offsetX;
                    var y1 = event.clientY ? event.clientY : event.offsetY;

                    var leftTops = global.baseTool.sumLeftTop(tempPathBody);

                    x1 = x1 - parseInt(leftTops[0]) + parseInt(tempPathBody.scrollLeft);
                    y1 = y1 - parseInt(leftTops[1]) + parseInt(tempPathBody.scrollTop);

                    tempLineTool.pathLine(x1, y1, line, isPoint1);

                }

            }

            doc.onmouseup = function (event) {
                PathGlobal.rightLineMenu = false;

                return;
                event = event || window.event;

                var x2 = event.clientX ? event.clientX : event.offsetX,
						y2 = event.clientY ? event.clientY : event.offsetY;

                var leftTops = global.baseTool.sumLeftTop(tempPathBody);
                x2 = x2 - parseInt(leftTops[0]) + parseInt(tempPathBody.scrollLeft);
                y2 = y2 - parseInt(leftTops[1]) + parseInt(tempPathBody.scrollTop);


                tempLineTool.moveable = false;

                doc.onmousemove = null;
                doc.onmouseup = null;

                if (tempLineTool.isVML) {
                    line.setAttribute("strokecolor", PathGlobal.lineColor);
                } else if (global.lineTool.isSVG) {
                    line.setAttribute("style", "cursor:pointer; fill:none; stroke:" + PathGlobal.lineColor + "; stroke-width:" + PathGlobal.strokeweight);
                }

                tempLineTool.isCoverBaseMode(x2, y2, line, isPoint1);

                var newPath = tempLineTool.getPath(line);

                if (oldPath != newPath) {

                    var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

                        global.lineTool.setPath(line, oldPath);
                        tempSmallTool.drawLine(line);

                    }, PathGlobal.lineMove);

                    undoRedoEvent.setRedo(function () {

                        global.lineTool.setPath(line, newPath);
                        tempSmallTool.drawLine(line);

                    });

                }

            }

        }

    }

}