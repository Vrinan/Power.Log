var drawMindControl = (function () {

    var workMindInfo = document.getElementById("workMindInfo");
    if (!workMindInfo) {
        //alert("");
        Power.ui.error("无法找到定位标签 workMindInfo", { timeout: 0, position: "center center", closeable: true });
        return;
    }
    workMindInfo.innerHTML = "<fieldset style='border:solid 1px #aaa;padding:3px;'><legend >办理意见</legend><textarea class='mini-textarea' id='txtMindInfo' name='MindInfo' style='width:90%;height;80px' emptyText='请输入办理意见'  ></textarea><div id='treeMindList' class='mini-tree' showTreeLines='false' showExpandButtons='false' style='padding:5px;' expandOnNodeClick='true'></div> </fieldset>";
    mini.parse();

    var txtMindInfo = mini.get("txtMindInfo");
    txtMindInfo.setHeight("80px");
    txtMindInfo.setWidth("90%");

    mini.get("treeMindList").on("drawnode", function (e) { var node = e.node; if (node.Alias == "MindGroup") e.iconCls = "mindIcon"; return "mindIcon" });

})();

var WorkFlowManage = function () {
    return {



    }
}
