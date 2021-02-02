
function Win_AppForm() {
    return {
        data: {
            canPullUp: true, // 可以执行上拉
            gridData: [], // 数据列表
            optionDiv: null, // 获取页面的配置
            index: "0",
            size: "0",
            hasOpenDeleteBlock: false
        },
        getData: function (key) {
            return this.data[key];
        },
        setData: function (key, value) {
            var obj = {};

            obj[key] = value;
            this.data = $.extend(this.data, obj);
        },
        //GridPageLoad加载数据
        gridPageLoad: function (params, callback) {
            var p = $.extend({}, params);

            var url = p.url || "/Form/GridPageLoad";
            p.KeyWordType = p.KeyWordType || "BO";
            p.select = p.select || "";
            p.sort = p.sort || "";
            p.index = p.index || "0";
            p.size = p.size || "0";
            p.swhere = p.swhere || "";
            var _async = typeof (p.async) == "undefined" ? true : p.async;
            delete p.async;

            if (p.swhere) {
                var tmp = {};
                if (p.extparams) {
                    var str = Util.Base64Decode(p.extparams);
                    tmp = JSON.parse(str);
                }
                tmp.encodeswhere = "r4";
                p.extparams = Util.Base64Encode(JSON.stringify(tmp));
                p.swhere = Util.Base64Swhere(p.swhere);
            }

            Util._ajax(url, p, "post", false, function(data) {
                var getData = JSON.parse(data);
                if (callback) {
                    callback(getData);
                }
            });
        },
        UIEvents: function () {
            var that = this;
            var SearchDOM = $("#searchKey");
            var optionDiv = that.getData("optionDiv");
            var listWrap = $("#" + optionDiv["htmlParams"]["gridid"]);

            // 处理搜索框失焦
            $(".list-wrap, .footer-wrap").on("touchstart", function () {
                if (SearchDOM.size() > 0) {
                    SearchDOM.blur();
                }
            });

            // 搜索框输入数据改变
            SearchDOM.on("change", function () {
                that.searchFun(function (data) {
                    that.renderList(data, "search");
                });
            });

            // 新增表单
            $("#win_add_from").on("tap", function() {
                var hasRight = keywordright[optionDiv["dataParams"]["KeyWord"]];
                if ((hasRight.bAdd + "") == "0") {
                    mui.alert("你没有添加权限");
                    return false;
                }

                that.addWebForm(OpenFormId);
            });

            // 删除事件
            $("#win_show_action_block").on("tap", function () {
                var $this = $(this);
                $this.parent().addClass("hide").next().removeClass("hide");
    
                listWrap.find(".mui-checkbox").removeClass("hide");
                that.setData("hasOpenDeleteBlock", true);
            });

            // 返回事件
            $("#win_hide_action_block").on("tap", function () {
                var $this = $(this);
                $this.parent().addClass("hide").prev().removeClass("hide");
                listWrap.find(".mui-checkbox").addClass("hide");
                listWrap.find("input[type=checkbox]").prop("checked", false);
                that.setData("hasOpenDeleteBlock", false);
            });

            // 确定删除事件
            $("#win_delete_form").on("tap", function () {
                that.deleteHandle();
            });

            // checkbox的toggle切换
            listWrap.on("tap", ".mui-media-body" ,function (e) {
                e.preventDefault();
                e.stopPropagation();

                var $this = $(this);
                var checked = $this.prev().find("input[type=checkbox]").prop("checked");
                var hasOpenDeleteBlock = that.getData("hasOpenDeleteBlock");
                var line = $this.closest("li.mui-table-view-cell");
                var KeyValue = line.attr("data-id");
                var title = line.attr("data-title");

                if (!hasOpenDeleteBlock) {
                    that.openWebForm(KeyValue, title);
                    return false;
                }

                if (checked) {
                    $this.prev().find("input[type=checkbox]").prop("checked", false);
                } else {
                    $this.prev().find("input[type=checkbox]").prop("checked", true);
                }
            });
        },
        init: function (options, callback) {
            var that = this;

            // mui.js 初始化
            mui.init({
				pullRefresh: {
					container: '#pullrefresh',
					down: {
						callback: function () {
                            that.pullDown(function (data) {
                                $("#pullLast").addClass("hide");
                                that.renderList(data, "pullDown");
                                mui('#pullrefresh').pullRefresh().endPulldownToRefresh();
                            });
                        }
					},
					up: {
						contentrefresh: '',
						callback: function () {
                            var canPullUp = that.getData("canPullUp");
                            if (!canPullUp) {
                                $("#pullLast").removeClass("hide");
                                mui('#pullrefresh').pullRefresh().endPullupToRefresh();
                            } else {
                                that.pullUp(function (data) {
                                    $("#pullLast").addClass("hide");
                                    that.renderList(data, "pullUp");
                                    mui('#pullrefresh').pullRefresh().endPullupToRefresh();
                                });
                            }
                        }
					}
				}
            });
            
            that.setData("optionDiv", options);
            that.setData("index", options["dataParams"]["index"] || "0");
            that.setData("size", options["dataParams"]["size"] || "0");

            that.UIEvents();

            that.load(null, function (data) {
                that.renderList(data);
                callback && callback(that.data);
            });
        },
        //获取子表上，行的标题数据
        getTypeResult: function (htmlparams, row, type) {
            var result = "";
            var num = "";

            if (htmlparams[type].value != "") {
                var format = htmlparams[type].format;
                //普通文本
                if (!format){
                    result = row[htmlparams[type].value];
                } else if (format == "combobox") {
                    var comb = comboboxdata[htmlparams.gridid + "." + htmlparams[type].value];
                    if (comb) {
                        var ds = comb.Data;
                        var v = row[htmlparams[type].value];
                        for (var i = 0; i < ds.length; i++) {
                            var d = ds[i];
                            if (d[comb.ValueField] == v) {
                                result = d[comb.TextField];
                                num = d[comb.ValueField];
                                break;
                            }
                        }
                    }
                } else if (format.indexOf("nember") > -1 || format.indexOf("c") > -1 || format.indexOf("p") > -1) {
                    //数字
                    result = new Number( row[htmlparams[type].value]);
                } else if (format.indexOf("y") > -1) {
                    //日期
                    result =  Util._formatDate(row[htmlparams[type].value], format);
                } else if (format.indexOf("n2") > -1) {
                    // 千分位
                    result =  Util.toThousand(row[htmlparams[type].value] + '');
                }
            }

            if (!result) {
                result = "暂无";
            }

            if (type == "tag" && !!result) {
                switch (num) {
                    case "0": 
                        return {
                            tagColor: "power-project-menu-bg7",
                            result: result
                        }
                    case "20": 
                        return {
                            tagColor: "power-project-menu-bg2",
                            result: result
                        }
                    case "35": 
                        return {
                            tagColor: "power-project-menu-bg3",
                            result: result
                        }
                    case "40": 
                        return {
                            tagColor: "power-project-menu-bg4",
                            result: result
                        }
                    case "50": 
                        return {
                            tagColor: "power-project-menu-bg0",
                            result: result
                        }
                }
            }
            
            return result.replace("null", "");
        },
        // 再一次组织渲染数据
        getRenderUnit: function (htmlParams, item ,type) {
            var that = this;
            if (!htmlParams) { return false }

            if (!htmlParams[type]) {
                return '';
            }

            switch (type) {
                case "title": 
                    var value = that.getTypeResult(htmlParams, item, "title");
                    var name = htmlParams["title"]["name"];

                    if (name) {
                        return '<span>'+ name + ':' + value +'</span>'
                    } else {
                        return '<span>'+ value +'</span>';
                    }
                case "left":
                    var value = that.getTypeResult(htmlParams, item, "left");
                    var name = htmlParams["left"]["name"];

                    if (name) {
                        return '<div class="list-unit">'+ name + ':' + value +'</div>'
                    } else {
                        return '<div class="list-unit">'+ value +'</div>';
                    }
                case "right":
                    var value = that.getTypeResult(htmlParams, item, "right");
                    var name = htmlParams["right"]["name"];

                    if (name) {
                        return '<div class="list-unit">'+ name + ':' + value +'</div>'
                    } else {
                        return '<div class="list-unit">'+ value +'</div>';
                    }
                case "center":
                    var value = that.getTypeResult(htmlParams, item, "center");
                    var name = htmlParams["center"]["name"];

                    if (name) {
                        return '<div class="list-unit">'+ name + ':' + value +'</div>'
                    } else {
                        return '<div class="list-unit">'+ value +'</div>';
                    }
                case "tag":
                    var value = that.getTypeResult(htmlParams, item, "tag");
                    return '<div class="mui-tag '+ value.tagColor +'"><span>'+ value.result +'</span></div>'
                
            }
        },
        // 渲染方法
        renderList: function (data, type) {
            var that = this, html = '';
            var htmlParams = this.getData("optionDiv")["htmlParams"];

            data.forEach(function (item) {
                var title = that.getRenderUnit(htmlParams, item, "title");
                var left =  that.getRenderUnit(htmlParams, item, "left");
                var right =  that.getRenderUnit(htmlParams, item, "right");
                var center =  that.getRenderUnit(htmlParams, item, "center");
                var tag =  that.getRenderUnit(htmlParams, item, "tag");

                html += '<li data-title="'+ $(title).text() +'" data-id="'+ item[htmlParams["idfield"]] +'" class="mui-table-view-cell">' +
                    '<div class="mui-slider-handle">' +
                    '<div class="mui-win-form text-row">' +
                    '<div class="hide mui-media-object mui-pull-left mui-checkbox">' +
                    '<input data-id="'+ item[htmlParams["idfield"]] +'" class="" name="checkbox"type="checkbox">' +
                    '</div>' +
                    '<div class="mui-media-body">' +
                    '<p class="mui-ellipsis list-title">' +
                    '<span>'+ title +'</span>' +
                    '</p>' +
                    '<div class="list-units">' +
                    '<div class="list-unit">'+ left +'</div>' +
                    '<div class="list-unit">'+ center +'</div>' +
                    '<div class="list-unit">'+ right +'</div>' +
                    '</div>' +
                    '</div>' +
                    tag
                    '</div>' +
                    '</div>' +
                    '</li>';
            });

            switch (type) {
                case "normal":
                    $("#" + htmlParams["gridid"]).append(html);
                    break;
                case "pullDown":
                    $("#" + htmlParams["gridid"]).html(html);
                    break;
                case "pullUp":
                    $("#" + htmlParams["gridid"]).append(html);
                    break;
                case "search":
                    $("#" + htmlParams["gridid"]).html(html);
                    break;
                default:
                    $("#" + htmlParams["gridid"]).html(html);
            }
        },
        // 组织请求参数
        buildParams: function () {
            var that = this;
            var optionDiv = that.getData("optionDiv");
            var dataParams = optionDiv["dataParams"];
            var params = JSON.parse(JSON.stringify(dataParams));
            var config = formconfig.config.joindata;
            var searchKey = $.trim($("#searchKey").val());
            var searchField = optionDiv["searchField"];

            params.select = params.select || config.select;
            params.KeyWord = params.KeyWord || config.KeyWord;
            params.KeyWordType = params.KeyWordType || config.KeyWordType;
            params.swhere = params.swhere || config.swhere;
            params.size = params.size || "0";
            params.index = params.index || "0";

            if (searchField && searchKey) {
                if (Util.isArray(searchField)) {
                    params.swhere += " and ("
                    searchField.forEach(function (field, index) {
                        if (index === 0) {
                            params.swhere += " "+ field +" like '%" + searchKey + "%'";
                        } else {
                            params.swhere += " or "+ field +" like '%" + searchKey + "%'";
                        }
                    });
                    params.swhere += ") ";
                } else {
                    params.swhere += " and "+ optionDiv.searchField +" like '%" + searchKey + "%'";
                }
            }

            return params;
        },
        //打开表单
        openWebForm: function(keyvalue, title) {
            var url = "", that = this;
            var optionDiv = that.getData("optionDiv");
            var hasRight = keywordright[optionDiv["dataParams"]["KeyWord"]];
            //直接由按钮是否是灰色的，来判断是查看还是编辑
            hasRight.bEdit += "";
            if (hasRight.bEdit !== "1") {
                url = "/Form/ValidForm/" + OpenFormId  + "/view/" + keyvalue + "/";
            } else {
                url = "/Form/ValidForm/" + OpenFormId  + "/edit/" + keyvalue + "/";
            }
            
            appPhysical.OpenWebView(url, title);
        },
        // 删除操作
        deleteHandle: function () {
            var that = this;
            var optionDiv = that.getData("optionDiv");
            var listWrap = $("#" + optionDiv["htmlParams"]["gridid"]);
            var checkboxs = listWrap.find("input[type=checkbox]:checked");
            var rows = [];

            checkboxs.each(function () {
                var $this = $(this), id = $this.attr("data-id");
                var obj = {
                    "_state": "removed"
                };

                obj[optionDiv.htmlParams.idfield] = id;
                rows.push(obj);
            });

            if (rows.length == 0) {
                mui.alert("请选中数据!");
                return false;
            }

            var pack = {};
            var KeyWord = optionDiv["dataParams"]["KeyWord"];
            var KeyWordType = optionDiv["dataParams"]["KeyWordType"];
            pack[KeyWord] = {
                "KeyWordType": KeyWordType || "BO"
            };

            pack[KeyWord].data = rows;
            var jdata = {
                formId: "",
                encode: "r4",
            };

            jdata.jsonData = JSON.stringify(pack);
            jdata.Params = Util.Base64Encode("");
            jdata.jsonData = Util.Base64Swhere(jdata.jsonData);

            Util._ajax("/Form/SaveWebForm", jdata, "POST", false, function(data) {
                var getData = JSON.parse(data);
                if (getData.success) {
                    checkboxs.each(function () {
                        $(this).closest("li.mui-table-view-cell").remove();
                    });

                    mui.toast("删除成功");
                } else {
                    mui.alert("删除失败：" +getData.message);
                    return false;
                }
            });
        },
        //新增一条记录
        addWebForm: function(formid) {
            var url = "/Form/AddForm/" + formid + "/";
            appPhysical.OpenWebView(url, "新增表单");
        },
        // 执行搜索
        searchFun: function (callback) {
            var that = this;
            var params = that.buildParams();
            var size = Number(that.getData("size"));

            that.setData("index", "0");
            params["index"] = "0";

            that.load(params, function (data) {
                $("#win_hide_action_block").trigger("tap");
                if (data.length < size) {
                    that.setData("canPullUp", false);
                } else {
                    that.setData("canPullUp", true);
                }
                callback && callback(data);
            });
        },
        // 下拉
        pullDown: function (callback) {
            var that = this;
            var params = that.buildParams();
            var size = Number(that.getData("size"));

            that.setData("index", "0");
            params["index"] = "0";
            that.load(params, function (data) {
                $("#win_hide_action_block").trigger("tap");
                if (data.length < size) {
                    that.setData("canPullUp", false);
                } else {
                    that.setData("canPullUp", true);
                }
                callback && callback(data);
            });
        },
        // 上拉
        pullUp: function (callback) {
            var that = this;
            var params = that.buildParams();
            var index = that.getData("index");
            var size  = that.getData("size") + "";

            params["index"] = Number(index) + 1 + "";
            that.load(params, function (data) {
                $("#win_hide_action_block").trigger("tap");
                if (data.length < Number(size)) {
                    that.setData("canPullUp", false);
                    that.setData("index", index);
                } else {
                    that.setData("canPullUp", true);
                    that.setData("index", params["index"]);
                }
                callback && callback(data);
            });
        },
        // 加载方法
        load: function (p, callback) {
            var that = this;
            var params = p ? p : that.buildParams();
            var optionDiv = that.getData("optionDiv");

            if (params.KeyWord == "") {
                mui.alert("第一个参数中KeyWord不能为空");
                return false;
            }

            if (optionDiv.loadBefore) {
                params = optionDiv.loadBefore(params);
            }

            that.gridPageLoad(params, function (data) {
                var getData = [];
                if (!data.success) {
                    mui.alert(data.message);
                    return false;
                }

                if (!!data.data.value) {
                    getData = JSON.parse(data.data.value);
                }

                if (optionDiv.loadAfter) {
                    getData = optionDiv.loadAfter(getData);
                }

                callback && callback(getData);
            });
        }
    }
}
