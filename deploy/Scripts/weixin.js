var _isIndex = false;
var _member = "";
var _channel = "";
var _channel1 = "";

$(function () {
    weixinInit();
});

// 初始化微信分享
function weixinInit() {
    var weixinParam = buildWeixinParam();

    document.addEventListener("WeixinJSBridgeReady", function onBridgeReady() {
        WeixinJSBridge.call("hideToolbar");
        WeixinJSBridge.on("menu:share:appmessage", function (argv) {
            WeixinJSBridge.invoke("sendAppMessage", weixinParam, onShareComplete);
        });

        WeixinJSBridge.on("menu:share:timeline", function (argv) {
            WeixinJSBridge.invoke("shareTimeline", weixinParam, onShareComplete);
        });
    }, false);

    function onShareComplete() {
    }
}

function buildWeixinParam() {
    var desc = "白送技能Get√-- 客官，试吃“比巴掌还大的野生马尾松塔”单品装，只需付个快递费，无需刷脸，剩下的牛社帮您搞定！";
    if (_member != "") {
        desc = "这一次，说好了，不哭！—— “2014马年年尾，剥松子耍松塔”√时光不老，我们不散。";
    }
    else if (_channel1 != "") {
        desc = "【松塔预售买买买】“即便拯救了世界，松鼠想的只是松塔”…格子间里的野味，比巴掌还大，就在牛社～";
    }

    var weixinParam = new Object();
    weixinParam.img_url = "http://pinecone.unisw.com/img/app.jpg";
    weixinParam.link = (_isIndex == true) ? location.href : "http://pinecone.unisw.com";
    weixinParam.desc = desc;
    weixinParam.title = "Newbility供销社马尾松塔";

    return weixinParam;
}
