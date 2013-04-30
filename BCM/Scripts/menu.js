$(document).ready(function () {
    //************改变webMain高度***********/
    var wdiv = $("#webmain");
    var layout = $.getLayout(window);
    var height = layout.innerHeight - 143;
    if (wdiv.height() < height) {
        wdiv.height(height);
    }
    $(window).resize(function () {
        var layout = $.getLayout(window);
        var height = layout.innerHeight - 143;
        if (wdiv.height() < height) {
            wdiv.height(height);
        }
    });
    $("#divHtml").click(function () {
        alert($("#my_menu").html());
    });

    //**************** 下理菜单选择项  ***********/
    //处理所点击的

    var currentId = $.cookie("menu");
    if (currentId != "") {
        var oMenu2 = $("#" + currentId);
        if (oMenu2.length > 0) {
            oMenu2.addClass("current2");
            var oMenu1 = oMenu2.parent();
            oMenu1.show(); //slideDown("slow");
            oMenu1.prev().addClass("current1");
        }
    }

    //处理显示下一级

    $("#my_menu span").each(function (i) {
        $(this).click(function () {
            var p = $(this);
            if (!p.hasClass("current1")) {
                $(".current1").removeClass("current1").next().slideUp("fast");
                p.addClass("current1");
                p.next().slideDown("fast");
            }
            else {
                $(".current1").removeClass("current1").next().slideUp("fast");
            }
           
        }).next().children().each(function (j) {
            $(this).click(function () {
                var p = $(this);
                $.cookie("menu", p.attr("id"), { path: '/' });
                $(".current2").removeClass("current2");
                p.addClass("current2");
            });
        });
    });

    startTime();

    //menu hide,show

    $(".vhr > img").click(function () {
        var obj = $(".webleft");
        //obj.toggle();
        if (obj.css("display") == "none") {
            obj.css("display", "");

            $(".vhr > img").attr("src", "../images/web_21.gif")
        }
        else {
            obj.css("display", "none");
            $(".vhr > img").attr("src", "../images/web_24.gif")
        }
    });
});