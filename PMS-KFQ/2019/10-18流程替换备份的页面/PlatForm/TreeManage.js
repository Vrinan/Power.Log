var TreeManage = function () {

    var KeyWord = null;   //关键词
    var TreeActionUrl = bootPATH + "../PowerPlat/Action/TreeAction.aspx";
    var TreeControl = null;  //渲染的树对象

    return {

        setKeyWord: function (text) {
            KeyWord = text;
        },
        getKeyWord: function () {
            return KeyWord;
        },
        setControl: function (control) {
            TreeControl = control;
        },
        getControl: function () {
            return TreeControl;
        },
        //读取记录
        LoadTreeList: function (data, callback) {
            Power.App.loading.show();
            var json = mini.encode(data);
            $.ajax({
                url: TreeActionUrl,
                data: { data: json, ServerOperatorType: 'LoadTreeList', KeyWord: KeyWord },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (tmpData.success == false) {
                        Power.ui.alert(tmpData.message);
                        return;
                    }
                 

                    if (TreeControl != null) {
                        if (TreeControl.type == "treeselect")
                            TreeControl.setData(tmpData.NodeData);
                        else
                            TreeControl.loadData(tmpData.NodeData);
                    }
                    if (callback) callback(tmpData);
                    if (parent["MainWindow"]) {
                        parent["MainWindow"].divShowInfo.innerText = tmpData.RunTime;
                    }

                    Power.App.loading.hide();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.App.loading.hide();
                    Power.ui.alert(jqXHR.responseText);

                }
            });
        },

        //读取记录
        SimpleLoadTreeList: function (data, callback, async) {

            var blnAsync = false;
            if (async) blnAsync = async;
            var json = mini.encode(data);
            $.ajax({
                url: TreeActionUrl,
                data: { data: json, ServerOperatorType: 'LoadTreeList', KeyWord: KeyWord },
                cache: false,
                async: blnAsync,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    var tmpData = mini.decode(text);
                    if (tmpData.success == false) {
                        Power.ui.alert(tmpData.message);
                        return;
                    }
                    if (callback) callback(tmpData);

                    if (top["MainWindow"]) {
                        top["MainWindow"].divShowInfo.innerText = tmpData.RunTime;
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.alert(jqXHR.responseText);

                }
            });
        }
    };
};
