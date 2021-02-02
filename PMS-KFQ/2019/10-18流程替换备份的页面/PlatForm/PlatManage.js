var PlatManage = function () {
       var PlatActionUrl = bootPATH + "../PowerPlat/Action/PlatAction.aspx";

    return {
     
        //读取记录
        LoadDataSourceConfig: function (DataSourceID,DataSourceType, callback) {

            //加载JSON数据
            $.ajax({
                url: PlatActionUrl,
                data: { ServerOperatorType: 'DataSourceConfig', DataSourceID: DataSourceID, DataSourceType: DataSourceType },
                cache: false,
                success: function (text) {
                    var tmpData = mini.decode(text);
                    if (callback) callback(tmpData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    Power.ui.alert(jqXHR.responseText);
                }
            });
        }
    };
};
