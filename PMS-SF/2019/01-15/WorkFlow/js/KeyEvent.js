var KeyDownFactory = com.xjwgraph.KeyDownFactory = function () {}

KeyDownFactory.prototype = {

    removeNode: function () {

        var global = com.xjwgraph.Global,

		tempLineTool = global.lineTool,
		pathBody = tempLineTool.pathBody,
		svgBody = tempLineTool.svgBody,

		tempSmallTool = global.smallTool,
		tempModeTool = global.modeTool,

		activeModeArray = [],
		activeModeMap = [],
		i = 0,

        removeNodeId = "",
		isRemoveMode = false;

        tempModeTool.forEach(function (modeId) {

            var mode = $id(modeId);

            if (tempModeTool.isActiveMode(mode)) {

                activeModeMap[i] = global.modeMap.get(mode.id);
                activeModeArray[i++] = mode;

                global.modeTool.removeNode(modeId);
                removeNodeId = modeId;
                isRemoveMode = true;

            }

        });

        if (isRemoveMode) {

            var undoRedoModeEvent = new com.xjwgraph.UndoRedoEvent(function () {

                var activeModeLength = activeModeArray.length;

                for (var i = activeModeLength; i--; ) {

                    var activeMode = activeModeArray[i];

                    global.modeMap.put(activeMode.id, activeModeMap[i]);

                    pathBody.appendChild(activeMode);
                    tempModeTool.showPointer(activeMode);

                    tempSmallTool.drawMode(activeMode);

                }

            }, PathGlobal.removeMode);

            undoRedoModeEvent.setRedo(function () {

                var activeModeLength = activeModeArray.length;

                for (var i = activeModeLength; i--; ) {

                    var activeMode = activeModeArray[i];
                    global.modeTool.removeNode(activeMode.id);

                }

            });

        }

        var activeLineArray = [],
		activeLineMap = [],
		j = 0,
		isRemoveLine = false;

        tempLineTool.forEach(function (lineId) {

            var line = $id(lineId);

            if (tempLineTool.isActiveLine(line)) {

                activeLineMap[j] = com.xjwgraph.Global.lineMap.get(line.id);
                activeLineArray[j++] = line;

                tempLineTool.removeLine(line.id);
                isRemoveLine = true;

            }

        });

        if (isRemoveLine) {

            var undoRedoLineEvent = new com.xjwgraph.UndoRedoEvent(function () {

                var activeLineLength = activeLineArray.length;

                for (var j = activeLineLength; j--; ) {

                    var activeLine = activeLineArray[j];

                    if (tempLineTool.isVML) {

                        activeLine.setAttribute("coordsize", "100,100");
                        activeLine.setAttribute("filled", "f");
                        activeLine.setAttribute("strokeweight", PathGlobal.strokeweight + "px");
                        activeLine.setAttribute("strokecolor", PathGlobal.lineColor);

                        pathBody.appendChild(activeLine);

                    } else if (tempLineTool.isSVG) {
                        svgBody.appendChild(activeLine);
                    }

                    global.lineMap.put(activeLine.id, activeLineMap[j]);
                    tempSmallTool.drawLine(activeLine);

                }

            }, PathGlobal.remodeLine);

            undoRedoLineEvent.setRedo(function () {

                var activeLineLength = activeLineArray.length;

                for (var i = activeLineLength; i--; ) {

                    var activeLine = activeLineArray[i];
                    tempLineTool.removeNode(activeLine.id);

                }

            });

        }

        return removeNodeId;
    },

    copyNode: function () {

        var global = com.xjwgraph.Global,
		tempModeTool = global.modeTool,

		activeModeArray = [],
		i = 0,

		tempSmallTool = global.smallTool;

        tempModeTool.forEach(function (modeId) {

            var mode = $id(modeId);

            if (tempModeTool.isActiveMode(mode)) {

                var copyObj = global.modeTool.copy(mode);

                activeModeArray[i++] = copyObj;
                tempModeTool.hiddPointer(mode);
                tempSmallTool.drawMode(copyObj);

            }

        });

        var tempLineTool = global.lineTool;

        if (activeModeArray.length > 0) {

            var undoRedoEvent = new com.xjwgraph.UndoRedoEvent(function () {

                var activeModeLength = activeModeArray.length;

                for (var i = activeModeLength; i--; ) {

                    var activeMode = activeModeArray[i];

                    if (activeMode && activeMode.id && $id(activeMode.id)) {

                        global.modeMap.remove(activeMode.id);

                        tempLineTool.pathBody.removeChild(activeMode);
                        tempSmallTool.removeMode(activeMode.id);

                    }

                }

            }, PathGlobal.copyMode);

            undoRedoEvent.setRedo(function () {

                var activeModeLength = activeModeArray.length;

                for (var i = activeModeLength; i--; ) {

                    var activeMode = activeModeArray[i];

                    var baseMode = new BaseMode();
                    baseMode.id = activeMode.id;
                    global.modeMap.put(activeMode.id, baseMode);

                    tempLineTool.pathBody.appendChild(activeMode);

                    tempModeTool.showPointer(activeMode);
                    tempSmallTool.drawMode(activeMode);

                }

            });

        }

    }

}


var keyDownFactory = new KeyDownFactory();

function KeyDown(event) {
	
	event = event || window.event;
	
	if (event.keyCode == 46) {
		 keyDownFactory.removeNode();
	}
	
	if (event.ctrlKey) {
	
		switch(event.keyCode) { 
			
			case 77: keyDownFactory.removeNode(); break;
			case 86: keyDownFactory.copyNode(); break;
			
  	}
   
	}
	
}