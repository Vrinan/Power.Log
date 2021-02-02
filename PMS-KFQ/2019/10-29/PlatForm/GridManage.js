var GridManage = function () {

    var KeyWord = null;   //关键词
    var GridActionUrl = bootPATH + "../PowerPlat/Action/GridAction.aspx";
    var GridControl = null;  //渲染的树对象

    return {

        setKeyWord: function (text) {
            KeyWord = text;
        },
        getKeyWord: function () {
            return KeyWord;
        },
        setControl: function (control) {
            GridControl = control;
        },
        getControl: function () {
            return GridControl;
        },
        //读取记录
        LoadGridList: function (data, callback) {
            Power.App.loading.show();
            var json = mini.encode(data);
            $.ajax({
                url: GridActionUrl,
                data: { "json": json, ServerOperatorType: 'LoadRecord', KeyWord: KeyWord },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (tmpData.success == false) {
                        Power.App.loading.hide();
                        Power.ui.alert(tmpData.message);
                        return;
                    }
                 
                    if (callback) callback(tmpData);
                    if (GridControl != null) 
                            GridControl.setData(tmpData.NodeData); 
                   
                    if (top["MainWindow"]) {
                        top["MainWindow"].divShowInfo.innerText = tmpData.RunTime;
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
        SimpleLoadGridList: function (data, callback, async) {
            mini.mask({
                el: document.body,
                cls: 'mini-mask-loading',
                html: '加载中...'
            });
           
            var blnAsync = false;
            if (async) blnAsync = async;
            var json = mini.encode(data);
            $.ajax({
                url: GridActionUrl,
                data: { json: json, ServerOperatorType: 'LoadRecord', KeyWord: KeyWord },
                cache: false,
                async: blnAsync,
                success: function (text) {

                    mini.unmask(document.body);
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
                    mini.unmask(document.body);
                    Power.ui.alert(jqXHR.responseText);

                }
            });
        }
    };
};
