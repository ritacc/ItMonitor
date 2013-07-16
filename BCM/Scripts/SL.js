function fullScreen() {
    setFullScreen(document.getElementById("objServerRoom"));
    return 0;
}

var originStyle = {};
function setFullScreen(obj) {
    var htmls = document.getElementsByTagName('html');
    if (htmls.length > 0) {
        h = htmls[0];
        var originOverflow = h.style.overflow;
        if (!originStyle.isFullScreenMode) {
            originStyle.position = obj.style.position;
            originStyle.top = obj.style.top;
            originStyle.left = obj.style.left;
            originStyle.height = obj.style.height;
            originStyle.width = obj.style.width;

            var clientSize = $.getLayout(window);
            obj.style.position = "absolute";
            obj.style.top = 0;
            obj.style.left = 0;
            obj.style.height = clientSize.innerHeight + "px";
            obj.style.width = clientSize.innerWidth + "px";
            originStyle.isFullScreenMode = true;
            //h.style.overflow = "hidden";

            //_attachEvent(window, "resize", onSizeChanged);
        } else {
            obj.style.position = originStyle.position;
            obj.style.top = originStyle.top;
            obj.style.left = originStyle.left;
            obj.style.height = originStyle.height;
            obj.style.width = originStyle.width;
            originStyle.isFullScreenMode = false;
            // h.style.overflow = "";
            // _detachEvent(window, "resize", onSizeChanged);
        }
    }
}

function ShowDoubleCurve() {
    var url = "DailyreportContent.aspx";
    $.popup({ title: "多测点历史曲线", url: url, borderStyle: { height: 700, width: 1110} });
}