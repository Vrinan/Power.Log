/**
 * Created by DELL on 2017-5-2.
 */

function CallAppFunction(name, params, url, callback) {
    if (window.m3app != undefined &&
        typeof(window.m3app.AppCall) == "function") {

        window.m3app.AppCall(name, params, callback);
    } else if (typeof(window.PowerM3AppCall) == "function") {

        window.PowerM3AppCall(name, params, callback);
    } else if (url != undefined && url != "") {

        window.open(url, "_self")
    }
}


Date.prototype.Format = function(fmt) {
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),
        "S": this.getMilliseconds()
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    }

    return fmt;
};



$(function() {

    //处理合同详情页面的js  --开始
    var tapMain = $("#receivingNode");
    //实现长时间触摸显示选中框
    tapMain.on("taphold", function() {
        $(this).attr("data-btns", "no");
        $(this).find("ul.receive-node-content").addClass("tapHoldEvent");

        $(".receiving-node-checkAll-delete").show();
        $(".receivingNode-control").hide();
    });

    //实现选中的样式添加（对号）
    tapMain.on("click", ".receive-node-checkbox-check", function() {
        $(this).find("i").toggleClass("icon-tongyi");
        $(this).closest("li").toggleClass("checkTrue");

        var checkLis = tapMain.find("li.checkTrue");
        var tapLis = tapMain.find("li");

        if (checkLis.length == tapLis.length) {
            $(".delete-all").addClass("checkCancel").text("取消全选");
        } else {
            $(".delete-all").removeClass("checkCancel").text("全部选中")
        }
    });

    //实现删除功能
    //目前只是操作Dom,想要完整的实现删除，
    // 还需要使用ajax,具体的根据项目需求来
    //删除所有

    $(".delete-all").on("click", function() {
        $(this).toggleClass("checkCancel");
        if ($(this).hasClass("checkCancel")) {
            $(this).text("取消全选");

            tapMain.find("i.checkContent").addClass("icon-tongyi")
                .closest("li").addClass("checkTrue");
        } else {
            $(this).text("全部选中");
            tapMain.find("i.checkContent").removeClass("icon-tongyi")
                .closest("li").removeClass("checkTrue");
        }
    });


    //删除选中
    $(".delete-check").on("click", function() {
        $("#receivingNode").find("li.checkTrue").remove();
        tapMain.find("ul.receive-node-content").removeClass("tapHoldEvent");
        $(this).closest("div.receiving-node-checkAll-delete").hide();
    });



    //用于处理  合同详情的按钮显示或者隐藏
    $('.contractMenu a[data-toggle="tab"]').on('shown.bs.tab', function(e) {
        var index = $(this).parent().index();
        var dataBtns = tapMain.attr("data-btns");


        $(".btn-bottom-groups .btn-control-content").eq(index).show().siblings().hide();

        if (dataBtns == "no") {
            $(".receivingNode-control").hide();
        }
    });

    //用于点击按钮后  显示出现loading  出现loading的时间为1000ms
    $(".btn-box-content").on("click", function(e) {
        var target = $(this).attr("data-target");
        $("." + target).parent().show().end()
            .addClass("power-project-box").show()
            .siblings().hide();

        setTimeout(function() {
            $("." + target)
                .addClass("power-project-box")
                .hide().parent().hide();
        }, 1000);

    });

    //处理合同详情页面的js  --结束




    //指派给   --开始
    //实现菜单的隐藏于显示
    $(".task-assigned-person").on("click", ".task-assigned-open-btn", function() {
        var show = $(this).attr("data-show");

        if (show == "true") {
            $(this).find(".floatRight").addClass("icon-more").removeClass("icon-moreunfold");
            $(this).next().removeClass("active");
            $(this).attr("data-show", "false");
        } else if (show == "false") {
            $(this).find(".floatRight").addClass("icon-moreunfold").removeClass("icon-more");
            $(this).next().addClass("active");
            $(this).attr("data-show", "true");
        }
    });



    $(" .task-appoint-content .task-appoint-title-btn ").on("click", function() {
        var show = $(this).attr("data-show"),
            toggleLeft = $(this).find(".toggle-left");
        if (show == "true") {
            $(this).next().addClass("active");

            toggleLeft.addClass("icon-moreunfold").removeClass("icon-more");

            $(this).attr("data-show", "false");
        } else if (show === "false") {
            $(this).next().removeClass("active");

            toggleLeft.removeClass("icon-moreunfold").addClass("icon-more");

            $(this).attr("data-show", "true");
        }
    });


    //指派给  -- 结束


    //实现搜索项目板块的显示与隐藏 --对应的页面   projectCenter.html
    $(".project-search-show-content-dialog-bg").on("click", function() {
        var that = $(this);
        that.next().animate({ "left": "-100%" }, 500, function() {
            that.animate({ "left": "-100%" }, 500);
        });
    });

    $(".project-search-show-content-dialog-showBtn").on("click", function() {
        var dialogBg = $(".project-search-show-content-dialog-bg");
        dialogBg.animate({ "left": "0" }, 500, function() {
            dialogBg.next().animate({ "left": "0" }, 500);
        });
    });

    //对应页面   addNode.html控制输入框的显示与隐藏
    $(".contract-unit-list li p.unit-list").on("click", function() {
        var dataEdit = $(this).attr("data-edit");
        if (dataEdit == "edit-close") {
            $(this).attr({ "data-edit": "edit-active" }).next().slideDown()
                .end().parent().siblings().find("p.unit-list")
                .attr("data-edit", "edit-close").next().slideUp();
        } else if (dataEdit == "edit-active") {
            $(this).attr({ "data-edit": "edit-close" }).next().slideUp();
        }
    });






});