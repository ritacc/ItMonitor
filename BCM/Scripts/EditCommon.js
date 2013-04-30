var timer = null;
function autoSize() {
    var wdiv = $("#wdiv");
    if (!timer) {
        window.clearTimeout(timer);
    }
    timer = window.setTimeout(
                function () {
                    var layout = $.getLayout(window);
                    var height;
                    if (wdiv.height() < layout.innerHeight) {
                        height = layout.innerHeight - 28;
                    }
                    else {
                        height = layout.innerHeight - 28;
                    }
                    wdiv.height(height);
                }, 100);
}

$(document).ready(function () {
    autoSize();
});


