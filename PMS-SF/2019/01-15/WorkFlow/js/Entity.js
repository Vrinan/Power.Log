var BaseMode = com.xjwgraph.BaseMode = function () {
	
	var self = this;
	
	self.id;
	self.lineMap = new Map();
	
}

var BuildLine = com.xjwgraph.BuildLine = function () {
	
	var self = this;
	
	self.id;
	self.index;
	self.xIndex;
	self.wIndex;
	self.type;
	self.xBaseMode;
	self.wBaseMode;
	
}

var Point = com.xjwgraph.Point = function () {
	
	var self = this;
	
	self.x = 0;
	self.y = 0;
	self.index = 0;

}