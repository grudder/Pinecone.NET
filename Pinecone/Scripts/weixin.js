var _isIndex = false;
var _member = "";
var _channel = "";
var _isPhase2 = false;

$(function () {
    weixinInit();
});

function weixinInit() {
    var desc = "白送技能Get√-- 客官，试吃“比巴掌还大的野生马尾松塔”单品装，只需付个快递费，无需刷脸，剩下的牛社帮您搞定！";
    if (_member != "") {
        desc = "这一次，说好了，不哭！—— “2014马年年尾，剥松子耍松塔”√时光不老，我们不散。";
    }
    else if (_channel1 != "") {
        desc = "【松塔预售买买买】“即便拯救了世界，松鼠想的只是松塔”…格子间里的野味，比巴掌还大，就在牛社～";
    }

    var link = "http://pinecone.unisw.com";
    if (_isIndex == true && (_member != "" || _channel != "")) {
        link = location.href;
    }
    else if (_channel1 != "") {
        link += "?channel1=" + _channel1;
    }

    if (_isPhase2) {
        desc = "【松塔礼盒装买买买】捣塔吧！像只松鼠一样！";
        link = "http://pinecone.unisw.com/Phase2/";
    }

    // 微信分享
    window.shareData = {
        "imgUrl": "http://pinecone.unisw.com/img/app.jpg",
        "timeLineLink": link,
        "tTitle": "Newbility供销社马尾松塔",
        "tContent": desc
    };

    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
        WeixinJSBridge.on('menu:share:appmessage', function (argv) {
            WeixinJSBridge.invoke('sendAppMessage', {
                "img_url": window.shareData.imgUrl,
                "link": window.shareData.timeLineLink,
                "desc": window.shareData.tContent,
                "title": window.shareData.tTitle
            }, onShareComplete);
        });

        WeixinJSBridge.on("menu:share:timeline", function (argv) {
            WeixinJSBridge.invoke("shareTimeline", {
                "img_url": window.shareData.imgUrl,
                "link": window.shareData.timeLineLink,
                "title": window.shareData.tContent,
                "desc": window.shareData.tTitle
            }, onShareComplete);
        });
    }, false);

    function onShareComplete() {
    }
}
