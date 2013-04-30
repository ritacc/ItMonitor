<!--
    $(document).ready(function () {
    var tabs = $(".tab");
    $.each(tabs, function(){
	    var navs = $("#tab_nav").children();
	    var bodys = $("#tab_body").children();
	    navs.hover(
		    function () {
			    $(this).addClass("hover");
		    },
		    function () {
			    $(this).removeClass("hover");
		    }
	    ).click(function () {
		    var p = $(this);
		    if(!p.hasClass("selected")) {
			    navs.removeClass("selected");
			    bodys.removeClass("selected");
			    p.addClass("selected");
			    bodys.eq(navs.index(p)).addClass("selected");
		    }
	    });
    });
});
-->