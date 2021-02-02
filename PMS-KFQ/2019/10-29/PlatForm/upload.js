var policyText = {
    "expiration": "2118-01-01T12:00:00.000Z", //设置该Policy的失效时间，超过这个失效时间之后，就没有办法通过这个policy上传文件了
    "conditions": [
    //["content-length-range", 0, 1048576000] // 设置上传文件的大小限制
    ["content-length-range", 0, 1048576000] // 设置上传文件的大小限制1000G
    ]
};

//官方参数
//accessid= '6MKOqxGiGU4AUk44';
//accesskey= 'ufu7nS8kS59awNihtjSonMETLI0KLy';
//host = 'http://post-test.oss-cn-hangzhou.aliyuncs.com';
var keyvalue = getParameter("KeyValue");
var keyWord = getParameter("KeyWord");
var NewDateTime = '';
var policyBase64 = Base64.encode(JSON.stringify(policyText))
message = policyBase64
var bytes = Crypto.HMAC(Crypto.SHA1, message, accesskey, { asBytes: true }) ;
var signature = Crypto.util.bytesToBase64(bytes);
function getsignature() {
    var g_dirname = host + "/" + epsProjId + "/" + keyvalue + "/" + keyWord + "/AddOssTest.docx";
    $.ajax({
        type: "POST",
        cache: false,
        url: "/OSS/GetSignPolicy",
        data: { dirname: g_dirname },
        success: function (text) {
            var tmp = mini.decode(text);
            tmp.success;
            tmp.data.value;
            alert('signature2=' + tmp.data.value);
            return tmp.data.value;
        }
    });
}

//Ronnie新增（获取时间yyyymmddhhmmssfff）
function getNowFormatDate() {
    var date = new Date();
    //var seperator1 = "-";
    var seperator1 = "";
    //var seperator2 = ":";
    var seperator2 = "";
    //var seperator3 = " ";
    var seperator3 = "";
    //var seperator4 = ".";
    var seperator4 = "";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    var Milliseconds = date.getMilliseconds();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    if (Milliseconds >= 0 && Milliseconds <= 9) {
        Milliseconds = "00" + Milliseconds;
    }
    if (Milliseconds >= 10 && Milliseconds <= 99) {
        Milliseconds = "0" + Milliseconds;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
            + seperator3 + date.getHours() + seperator2 + date.getMinutes()
            + seperator2 + date.getSeconds() + seperator4 + Milliseconds;
    NewDateTime = currentdate;
    //alert(currentdate);
    return currentdate;
}
var uploader = new plupload.Uploader({
	runtimes : 'html5,flash,silverlight,html4',
	browse_button : 'selectfiles', 
    //runtimes : 'flash',
	container: document.getElementById('container'),
	//flash_swf_url : 'lib/plupload-2.1.2/js/Moxie.swf',
	//silverlight_xap_url : 'lib/plupload-2.1.2/js/Moxie.xap',
	flash_swf_url: 'Moxie.swf',
	silverlight_xap_url: 'Moxie.xap',
	url: host,

	multipart_params: {
	    'Filename': '${filename}',
	    'key': epsProjId + '/' + keyWord + '/' + keyvalue + '/' + '${filename}',
		'policy': policyBase64,
        'OSSAccessKeyId': accessid, 
        'success_action_status' : '200', //让服务端返回200,不然，默认会返回204
        'signature': signature,
	    //'signature': getsignature(),
	},

	init: {
	    PostInit: function () {
	        document.getElementById('ossfile').style.display = "";
			document.getElementById('ossfile').innerHTML = '';
			document.getElementById('postfiles').onclick = function () {
			    //getNowFormatDate();
			    //uploader.start();
			    set_upload_param(uploader);
			    //document.getElementById('ossfile').innerHTML = '';
				return false;
			};
		},

		FilesAdded: function(up, files) {
		    plupload.each(files, function (file) {
		        document.getElementById('ossfile').style.display = "";
				document.getElementById('ossfile').innerHTML += '<div id="' + file.id + '">' + file.name + ' (' + plupload.formatSize(file.size) + ')<b></b>'
				+'<div class="progress"><div class="progress-bar" style="width: 0%"></div></div>'
				+'</div>';
		    });
		    set_upload_param(uploader);
		},
		//BeforeUpload: function (up, files) {
		    //set_upload_param(uploader);
		//},
		UploadProgress: function(up, file) {
			var d = document.getElementById(file.id);
			d.getElementsByTagName('b')[0].innerHTML = '<span>' + file.percent + "%</span>";
            
            var prog = d.getElementsByTagName('div')[0];
			var progBar = prog.getElementsByTagName('div')[0]
			progBar.style.width= 2*file.percent+'px';
			progBar.setAttribute('aria-valuenow', file.percent);
		},

		FileUploaded: function (up, file, info) {
            if (info.status >= 200 || info.status < 200)
            {
                //alert(file.name + "上传成功")
                document.getElementById(file.id).getElementsByTagName('b')[0].innerHTML = '成功';
                var keyvalue = getParameter("KeyValue");
                var keyWord = getParameter("KeyWord");
                //var epsProjId = getParameter("EpsProjId");
                var ServerUrl = host + "/" + epsProjId + "/" + keyWord + "/" + keyvalue + '/' + NewDateTime + "/" + file.name;
                var url = headSign(ServerUrl);
                if (url!="") {
                    ServerUrl = url;
                }
                //成功之后添加数据库记录
                $.ajax({
                    type: "POST",
                    cache: false,
                    url: "/OSS/AddFile",
                    data: { ServerUrl: ServerUrl, Name: file.name, FileSize: file.size, KeyValue: keyvalue, KeyWord: keyWord },
                    success: function (text) {
                        var tmp = mini.decode(text);
                        tmp.success;
                        tmp.data.value;
                        //alert('成功');
                        loadGrid();
                        //document.getElementById('ossfile').style.display = "none";
                        //document.getElementById('ossfile').innerHTML = '';
                        document.getElementById(file.id).innerHTML = '';
                        //alert('成功');
                    }
                });
            }
            else
            {
                document.getElementById(file.id).getElementsByTagName('b')[0].innerHTML = info.response;
            } 
		},

		Error: function(up, err) {
			document.getElementById('console').appendChild(document.createTextNode("\nError xml:" + err.response));
		}
	}
});

uploader.init();

/// <summary>
/// 截取字符串
/// </summary>
/// <param name="OriginalString">原始字符串</param>
/// <param name="BeganToString">开始字符串</param>
/// <param name="EndOfTheString">结束字符串</param>
/// <returns>结果字符串</returns>
function InterceptionOfAString(OriginalString, BeganToString, EndOfTheString) {
    var TheResultingString = ""; //结果字符串
    if (OriginalString != null && $.trim(OriginalString) != '' && OriginalString.length >= BeganToString.length && OriginalString.length >= EndOfTheString.length) {
        if (BeganToString != null && $.trim(BeganToString) != '') {
            OriginalString = OriginalString.substr(OriginalString.indexOf(BeganToString, 0) + BeganToString.length);
        }
        else { //从头截取到指定字符串
            TheResultingString = OriginalString.substr(0, OriginalString.indexOf(EndOfTheString, 0));
        }
        if (EndOfTheString != null && $.trim(EndOfTheString) != '') {
            TheResultingString = OriginalString.substr(0, OriginalString.indexOf(EndOfTheString));
        }
        else { //从开始字符串截取到字符串最后
            TheResultingString = OriginalString;
        }
    }
    return TheResultingString;
}


//签名
function headSign(ServerUrl) {
    //if (!validate()) return;
    var metas = new Array();
    var headerString = "";
    var showHeaderString = "";
    var showSignString = "";
    showHeaderString = '\n'
    var toSignString = "";
    toSignString = toSignString.concat("GET", "\n");
    showSignString = "GET" + "<br/>";
    var md5 = ''
    toSignString = toSignString + md5.concat("\n");
    showSignString = showSignString + md5 + "<br>";

    var contentType = ''
    toSignString = toSignString + contentType.concat("\n");
    showSignString = showSignString + contentType + "<br>";
    //设置签名时间
    var signDateTime = generateUTCTime();
    //设置超时时间(秒)
    var expire = 60 * parseInt(SignatureTime);
    expireTime = parseInt(signDateTime) + parseInt(expire)
    toSignString = toSignString + expireTime + '\n'
    showSignString = showSignString + expireTime + "<br>";

    var resource = "/" + InterceptionOfAString(host, "http://", ".oss") + InterceptionOfAString(ServerUrl, ".aliyuncs.com", "");

    toSignString = toSignString + resource;
    showSignString = showSignString + resource;
    var hash = CryptoJS.HmacSHA1(toSignString, accesskey);
    var sign = hash.toString(CryptoJS.enc.Base64);
    var url = ''
    bucket = ''
    object_name = ''
    var splited = resource.split('/');
    if (splited.length == 3) {
        bucket = splited[1]
        object_name = splited[2]
    }
    else if (splited.length > 3) {
        bucket = splited[1]
        for (var i = 2; i < splited.length; ++i) {
            if (i != 2) {
                object_name += '/'
            }
            object_name += splited[i]
        }
    }
    var myResource = resource
    var url = ""
    url = "http://" + bucket + ".oss" +InterceptionOfAString(host, ".oss", "") + "/" + object_name + '?OSSAccessKeyId=' + accessid + '&Expires=' + expireTime + '&Signature=' + encodeURIComponent(sign)
    return url;
}

function generateUTCTime() {
    //var dateTime = document.getElementById("signTime");
    var signDate = new Date();
    return parseInt(signDate.getTime() / 1000);
}


//重新赋值
function set_upload_param(up) {
    multipart_params = {
        'Filename': '${filename}',
        'key': epsProjId + '/' + keyWord + '/' + keyvalue + '/'+getNowFormatDate() + '/' + '${filename}',
        'policy': policyBase64,
        'OSSAccessKeyId': accessid,
        'success_action_status': '200', //让服务端返回200,不然，默认会返回204
        'signature': signature,
    };
    up.setOption({
        'multipart_params': multipart_params
    });
    up.start();
}



