;(function($) {
    $.Layers = new Array();
    $.loadingObj = [];

    //得到主窗口，即最顶端的窗口
    var topWin = window.top;

    $.fn.extendCss = function(style) {
        var ptr = $(this);
        for (css in style) {
            ptr.css(css, style[style]);
        }
        return ptr;
    }

    $.popup = function(opts) {
        return installForm(opts);
    }

    $.fn.popup = function(opts) {
        return installBlock($(this), opts);
    }

    $.prompt = function(opts) {
        return installPrompt(opts);
    }

    $.confirm = function(opts) {
        return installConfirm(opts);
    }

    $.loading = function(opts) {
        return installLoading(opts);
    }

  

    $.tip = { hide: tipOrErrorRemove, close: tipOrErrorClose }; // 渐变小时和，立即消除
    $.error = { hide: tipOrErrorRemove };
    $.fn.tip = function(options) {
        var ths = $(this);
        var opts = $.extend({}, $.tip.defaults, ((typeof options == "string") ? { caption: options} : options) || {});
        opts.viewClass = "info-tip";
        installTipOrError(opts, ths);
        return ths;
    }

    $.fn.error = function(options) {
        var ths = $(this);
        var opts = $.extend({}, $.error.defaults, ((typeof options == "string") ? { caption: options} : options) || {});
        opts.viewClass = "error-tip";
        installTipOrError(opts, ths);
        return ths;
    }

    $.loading.defaults = {
        id: undefined,
        caption: "数据加载中,请稍候...",
        css:    "popup-window-loading"
    };

    $.tip.defaults = {
        id: undefined,
        title: "提示",
        caption: "提示信息",
        fix: false,
        close: undefined // 关闭事件
    };

    $.error.defaults = {
        id: undefined,
        title: "警告",
        caption: "警告信息",
        fix: false,
        close: undefined // 关闭事件
    };

    $.popup.defaults = {
        id: undefined,
        title: "弹出框口",
        caption: "你确定要继续吗？",
        url: "javascript:void(0);",
        cancel: undefined,
        ok: undefined,        
        close: undefined,
        submit: undefined, // 客户自己验证事件
        checked: false,
        opobj: undefined,//用于弹出Div
        checkCaption: undefined,
        init: undefined,
        style: undefined,
        /*{
        border:				"solid 1px #DDDDDD",
        height:				"300px",
        width:				"400px"
        },*/
        topStyle: undefined,
        /*{
        backgroundColor:		"#C1B38E",
        height:				"30px",
        cursor:				"move"
        },*/
        titleStyle: undefined,
        /*{
        fontSize:			"10pt",
        color:				"white",
        "float":			"left",
        marginTop:			"5px",
        marginLeft:			"5px"
        },*/
        closeButtonStyle: undefined,
        /*{
        marginTop:			"7px",
        marginRight:		"7px",
        height:				16,
        width:				16,
        "float":			"right",
        backgroundRepeat:	"no-repeat",
        cursor:				"pointer"
        },*/
        closeButtonNormalStyle: undefined,
        /*{
        backgroundImage:	"url(red_close_normal.png)"
        },*/
        closeButtonMouseoverStyle: undefined,
        /*{
        backgroundImage:	"url(red_close_hover.png)"
        },*/
        borderStyle: undefined,
        /*{
        position:				"absolute",
        width:          		400,
        height:         		300,
        zIndex:				5000,
        border:				"solid 2px #DDDDDD",
        backgroundColor:		"white"
        },*/
        loadingStyle: undefined
        /*{
        width:				120,
        textAlign:			"center",
        paddingTop:			60,
        backgroundColor:	"#FFFFFF",
        position:			"absolute",
        top:				0,
        left:				0,
        fontSize:			"14pt",
        fontFamily:			"黑体",
        fontWeight:			"bold",
        color:				"#000000",
        backgroundImage:	"url(loading.gif)",
        backgroundRepeat:	"no-repeat",
        backgroundPosition:	"center"
        }*/
    };
    function installBlock(obj, options) {
        options = $.extend({}, $.popup.defaults, options || {});
        if (undefined != document.forms[0]) {
            options.form = document.forms[0];
        }
        if (options.id == undefined) {
            options.id = "popup" + Math.round(Math.random() * 10000);
        }
        var opts = installBase(options);
        opts.opobj=obj;
        opts.oBorder.append("<div id=\"body_"
			+ opts.id
			+ "\" class=\"bluecolor popup-window "
			+ opts.id
			+ "\"></div>");
        var oBody = $("#body_" + opts.id, opts.oBorder);
        if (opts.borderStyle != undefined) {
            oBody.css(opts.borderStyle);
        }

        obj.appendTo(oBody);
        obj.show();
        obj.bgiframe();

        opts.oBody = oBody;
        var optsLayout = setLayout(opts);
        window.top.$.Layers.push(optsLayout);
        var divTitle=$("#top_"+opts.id);
         /******************************拖动处理*******************************/
        
         divTitle.bind("mousedown", function(event){
					topWin.$.popup.dragEle = opts.oBorder;
					topWin.$.popup.pointer = getPointer(event);//当前鼠标位置
					topWin.$.popup.dialogPointer = {x:opts.oBorder.css('left').substring(0,opts.oBorder.css('left').length-2),y:opts.oBorder.css('top').substring(0,opts.oBorder.css('top').length-2)};//记录窗体当前位置
		    	opts.oBorder.bind("mousemove", dragMove);
		    	opts.oBorder.bind("mouseup", dragUp);
		    	//在背景层上绑定，修正拖动不平滑的bug
		    	$(topWin.document).bind("mousemove", dragMove);
		    	$(topWin.document).bind("mouseup",dragUp);
         });
         /******************************End拖动处理*******************************/

        return obj;
    }
    function installForm(options) {
        var opts = installBase(options);
        
        opts.oBorder.append("<div id=\"loading_"
			+ opts.id
			+ "\" class=\"popup-window-iframe-loading "
			+ opts.id
			+ "\">Loading...</div>");
        var oLoading = $("#loading_" + opts.id, opts.oBorder);
        if (opts.loadingStyle != undefined) {
            oLoading.css(opts.loadingStyle);
        }

        opts.oLoading = oLoading;

        opts.oBorder.append("<iframe id=\"body_"
			+ opts.id
			+ "\" class=\"popup-window " + opts.id + "\" frameborder=\"0\" src=\""
			+ opts.url
			+ "\"></iframe>");
        var oBody = $("#body_" + opts.id, opts.oBorder);
        if (opts.borderStyle != undefined) {
            oBody.css(opts.borderStyle);
        }

        //oBody.height(opts.oBorder.height() - opts.oTop.height());
        oBody.bind("load", function() {
            oLoading.hide(); ;
        });
        opts.oBody = oBody;
        var opts1 = setLayout(opts);
        window.top.$.Layers.push(opts1);

        /******************************拖动处理*******************************/
        var ifrm=opts.oBorder.find("#body_" +opts.id);
         opts.oBorder.bind("mousedown", function(event){
					topWin.$.popup.dragEle = opts.oBorder;
                    topWin.$.popup.iframeObj = ifrm;
					topWin.$.popup.pointer = getPointer(event);//当前鼠标位置
					topWin.$.popup.dialogPointer = {x:opts.oBorder.css('left').substring(0,opts.oBorder.css('left').length-2),y:opts.oBorder.css('top').substring(0,opts.oBorder.css('top').length-2)};//记录窗体当前位置
		    	opts.oBorder.bind("mousemove", dragMove);
		    	opts.oBorder.bind("mouseup", dragUp);
		    	//在背景层上绑定，修正拖动不平滑的bug
		    	$(topWin.document).bind("mousemove", dragMove);
		    	$(topWin.document).bind("mouseup",dragUp);
                
		    	//鼠标滑动可能在iframe中发生,将弹出窗口的坐标作为入参，作为判断鼠标进入iframe的依据
               
		    	if(ifrm && ifrm.attr('contentWindow')){
		    	    $(ifrm.attr('contentWindow').document).bind("mousemove",{x: topWin.$.popup.dragEle.css('left'),y:topWin.$.popup.dragEle.css('top')}, dragMove);
		    	    $(ifrm.attr('contentWindow').document).bind("mouseup", dragUp);
		    	}
         });
         /******************************End拖动处理*******************************/

        return opts1;
    }


function dragMove(event){	
    if (topWin.$.popup.dragEle == null ) {
		return;
	}
    
    if(window.top.event && event.button !=1)
        dragUp();
    
    event = event ? event : ((window.event) ? window.event : "");
    var dx =0;
	var dy =  0;
    if(event.data)
    {
     var evx=event.data.x;
     var evy=event.data.y;
     dx=parseInt(evx.substring(0,(evx.length-2)));
     dy=parseInt(evy.substring(0,(evy.length-2)));
    }
  
	//鼠标的现在位置
	var x = dx  + getPointer(event).x - parseInt(topWin.$.popup.pointer.x);//还需要加上iframe与div之间的表格宽度13
	var y = dy  + getPointer(event).y - parseInt(topWin.$.popup.pointer.y);//还需要加上iframe与div之间的表格宽度33
   
	topWin.$.popup.dragEle.css('left',parseInt(topWin.$.popup.dialogPointer.x) + x);
	topWin.$.popup.dragEle.css('top',parseInt(topWin.$.popup.dialogPointer.y) + y);
}


function dragUp()
{
    topWin.$.popup.dragEle.unbind("mousemove", dragMove).unbind("mouseup", dragUp);
    $(topWin.document).unbind("mousemove", dragMove).unbind("mouseup", dragUp);
    if(topWin.$.popup.iframeObj && topWin.$.popup.iframeObj.attr('contentWindow'))
    {
        
        $(topWin.$.popup.iframeObj.attr('contentWindow').document).unbind("mousemove", dragMove);
        $(topWin.$.popup.iframeObj.attr('contentWindow').document).unbind("mouseup", dragUp);
    }
}
//获得当前鼠标的坐标
function getPointer(event){
		var x = event.pageX || (event.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft)) || 0;
		var y = event.pageY || (event.clientY + (document.documentElement.scrollTop || document.body.scrollTop)) || 0;
		return {x:x, y:y};
}


   function installBase(options) {
        var opts = $.extend({}, $.popup.defaults, options || {});
        if (opts.id == undefined) {
            opts.id = "popup" + Math.round(Math.random() * 10000);
        }
        var topBody = $(window.top.document.body);
       
        setHtmlBodyScroll(false);
        
        var layout = $.getLayout();

        var popWindowBackground = $("#popup_window_background", topBody);
        
        if (popWindowBackground.length == 0) {
            var bgHtml="<div id='popup_window_background' style=\"-moz-user-focus:ignore;-moz-user-select:   none;\" onselectstart=\"return false;\"></div>";
            topBody.append(bgHtml);
            popWindowBackground = $("#popup_window_background", topBody);//查询
            if (opts.form && opts.form != undefined) 
                popWindowBackground.appendTo(opts.form);          
            popWindowBackground.height(layout.outerHeight).width(layout.outerWidth).bgiframe().click(function(event) { event.stopPropagation(); });    
        } else {
            popWindowBackground.show();
        }
        
        topBody.append("<div id=\""
		    + opts.id
		    + "\" class=\"popup-window-border "
		    + opts.id
		    + "\"></div>");
        var oBorder = $("#" + opts.id, topBody).click(function(event) { event.stopPropagation(); });
        if (opts.form != undefined) {
            oBorder.appendTo(opts.form);
        }
        var zIndex = oBorder.css("zIndex");
        var formCount = window.top.$.Layers.length;
        popWindowBackground.css("zIndex", zIndex + formCount);
        oBorder.css("zIndex", zIndex + formCount);

        oBorder.append("<div id=\"top_"
			+ opts.id
			+ "\" class=\"popup-window-top "
			+ opts.id
			+ "\" style=\"-moz-user-focus:ignore;-moz-user-select:   none;\"  onselectstart=\"return false;\"></div>");
        var oTop = $("#top_" + opts.id, oBorder);

        if (opts.topStyle != undefined) {
            oTop.css(opts.topStyle != undefined);
        }

        oTop.append("<div id=\"title_"
			+ opts.id
			+ "\" class=\"popup-window-title\">"
			+ opts.title
			+ "</div>");
        var oTitle = $("#title_" + opts.id, oTop);
        if (opts.titleStyle != undefined) {
            oTitle.css(opts.titleStyle);
        }

        oTop.append("<div id=\"close_"
			+ opts.id
			+ "\" class=\"popup-widow-close-button "
			+ opts.id
			+ "\"></div>");
        var oCloseButton = $("#close_" + opts.id, oTop);
        if (opts.closeButtonStyle != undefined) {
            oCloseButton.css(opts.closeButtonStyle);
        }
        if (opts.closeButtonNormalStyle != undefined) {
            oCloseButton.css(opts.closeButtonNormalStyle);
        }
        oCloseButton.hover(
			function() {
			    oCloseButton.addClass("popup-widow-close-button-hover");
			    if (opts.closeButtonMouseoverStyle != undefined) {
			        oCloseButton.css(opts.closeButtonMouseoverStyle);
			    }
			},
			function() {
			    oCloseButton.removeClass("popup-widow-close-button-hover");
			    if (opts.closeButtonNormalStyle != undefined) {
			        oCloseButton.css(opts.closeButtonNormalStyle);
			    }
			}
		);

        oCloseButton.click(function() {
            if(opts.closeOk)
            {
                $.popup.close("Close");
            }
            else
            {
                remove(opts);
                if (typeof opts.cancel == "function") {
                    opts.cancel();
                }
            }
        });
        
        oTop.append("<div class=\"" + opts.id + "\" style=\"clear:both\"></div>");
       
        opts.oTop = oTop;
        opts.layout = layout;
        opts.oBorder = oBorder;
        
        return opts;
    }

     function installPrompt(options) {
        var opts = installBase(options);
        opts.oBorder.append("<div id=\"body_"
			+ opts.id
			+ "\" class=\"popup-window "
			+ opts.id
			+ "\"></div>");
        var oBody = $("#body_" + opts.id, opts.oBorder);
        if (opts.borderStyle != undefined) {
            oBody.css(opts.borderStyle);
        }

        oBody.append("<table id=\"table_"
			+ opts.id
			+ "\" cellspacing=\"0\" cellpadding=\"0\" class=\"popup-window-table "
			+ opts.id
			+ "\"><tbody  id=\"tbody_"
			+ opts.id
			+ "\"></tbody></table>");

        var oTable = $("#tbody_" + opts.id, oBody);

        /*window.top.document.onselectstart = null;*/
        var inputs = [];
        if (opts.fields) {
            $.each(opts.fields, function(i, o) {
                var arr = new Array();
                arr.push("<tr id=\"field_input_td_");
                arr.push(o.id);
                arr.push("_");
                arr.push(opts.id);
                arr.push("\"><td class=\"");
                arr.push(opts.id);
                arr.push(" ");
                if (o.single == true) {
                    arr.push(" td-single\" colspan=\"2\">");

                } else {
                    arr.push("td-left\"><span>");
                    arr.push(o.title || "字段" + i);
                    arr.push("</span></td><td class=\"td-right ");
                    arr.push(opts.id);
                    arr.push("\">");
                }
                if (o.type == "checkbox") {
                    arr.push("<span title=\"");
                    arr.push(o.caption);
                    arr.push("\"><input type=\"checkbox\" id=\"field_input_");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\" name=\"");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\"");
                    if (o.checked == true) {
                        arr.push(" checked=\"checked\" ");
                    }
                    arr.push("/><label  for=\"field_input_");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\">");
                    arr.push(o.caption);
                    arr.push("</label></span>");
                } else if (o.type == "textarea") {
                    arr.push("<textarea id=\"field_textarea_");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\" rows=\"4\" title=\"");
                    arr.push(o.title);
                    arr.push("\"></textarea>");
                } else if (o.type == "select") {
                    arr.push("<select id=\"field_select_");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\" rows=\"4\" title=\"");
                    arr.push(o.title);
                    arr.push("\"></select>");
                } else if (o.type == "select") {
                    arr.push("<select id=\"field_select_");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\" title=\"");
                    arr.push(o.title);
                    arr.push("\"></select>");
                } else {
                    arr.push("<input id=\"field_input_");
                    arr.push(o.id);
                    arr.push("_");
                    arr.push(opts.id);
                    arr.push("\" type=\"text\" title=\"");
                    arr.push(o.title);
                    arr.push("\"/>");
                }
                arr.push("</td></tr>");
                oTable.append(arr.join(""));

                if (o.type == "checkbox") {
                    var checkbox = $("#field_input_"
				        + o.id
				        + "_"
				        + opts.id, oTable);
                    inputs.push(checkbox);
                    if (typeof o.change == "function") {
                        var id = opts.id;
                        checkbox.change(function() { o.change(id); });
                    }
                } else if (o.type == "textarea") {
                    var textarea = $("#field_textarea_"
				        + o.id
				        + "_"
				        + opts.id, oTable);
                    if (o.value) {
                        textarea.val(o.value);
                    }
                    if (o.yz) {
                        if (o.yz.group == undefined) {
                            o.yz.group = opts.id;
                        }
                        textarea.yz(o.yz);
                    }
                    inputs.push(textarea);
                } else if (o.type == "select") {
                    var select = $("#field_select_"
				        + o.id
				        + "_"
				        + opts.id, oTable);
                    if (o.options) {
                        $.each(o.options, function(i, opt) {
                            if (opt.value != undefined) {
                                $("<option value=\"" + opt.value + "\">" + opt.text + "</option>").appendTo(select);
                            } else {
                                $("<option>" + opt.text + "</option>").appendTo(select);
                            }
                        });
                    }
                    if (o.value != undefined) {
                        select.val(o.value);
                    }
                    if (o.yz) {
                        if (o.yz.group == undefined) {
                            o.yz.group = opts.id;
                        }
                        select.yz(o.yz);
                    }
                    inputs.push(select);
                } else {
                    var input = $("#field_input_"
				        + o.id
				        + "_"
				        + opts.id, oTable);
                    if (o.value) {
                        input.val(o.value);
                    }
                    if (o.yz) {
                        if (o.yz.group == undefined) {
                            o.yz.group = opts.id;
                        }
                        input.yz(o.yz);
                    }
                    inputs.push(input);
                }
            });
        }

        oBody.append("<div id=\"footer_"
			+ opts.id
			+ "\" class=\"popup-window-footer "
			+ opts.id
			+ "\"></div>");
        var oFooter = $("#footer_" + opts.id, oBody);

        oFooter.append("<input id=\"ok_"
			+ opts.id
			+ "\" type=\"button\" class=\"popup-window-ok "
			+ opts.id
			+ "\" value=\"确定\" />");
        var oOK = $("#ok_" + opts.id, oBody);

        oFooter.append("<input id=\"cancel_"
			+ opts.id
			+ "\" type=\"button\" class=\"popup-window-cancel "
			+ opts.id
			+ "\" value=\"取消\" />");
        var oCancel = $("#cancel_" + opts.id, oBody);

        var option = opts;

        oOK.click(function() {
            if (option.fields) {
                var result = {};
                $.each(option.fields, function(i, o) {
                    if (o.type == "checkbox") {
                        result[o.id] = $(inputs[i]).attr("checked");
                    } else {
                        result[o.id] = inputs[i].val();
                    }
                });
                var formCount = window.top.$.Layers.length;
                if (formCount > 0) {
                    if (!$.yz.getErrorList(option.id)) {
                        return false;
                    }
                    if (typeof option.submit == "function" && option.submit(result) == false) {
                        return false;
                    }
                    remove(option);
                    if (typeof option.ok == "function") {
                        option.ok(result);
                    }
                    if (typeof option.close == "function") {
                        option.close();
                    }
                } else {
                    window.close();
                }
            }
        });

        oCancel.click(function() {
            remove(option);
            if (typeof option.cancel == "function") {
                option.cancel();
            }
        });
        if (typeof opts.init == "function") {
            opts.init(opts.id);
        }

        oBody.width(oTable.outerWidth() + 5);
        oBody.height(oTable.outerHeight() + 5 + oFooter.height());
        opts.oBody = oBody;
        var optionsLayouted = setLayout(opts);
        window.top.$.Layers.push(optionsLayouted);
        return optionsLayouted;
    }


    function installConfirm(options) {
        var opts = installBase(options);
        opts.oBorder.append("<div id=\"body_"
			+ opts.id
			+ "\" class=\"popup-window "
			+ opts.id
			+ "\"></div>");
        var oBody = $("#body_" + opts.id, opts.oBorder);
        if (opts.borderStyle != undefined) {
            oBody.css(opts.borderStyle);
        }

        oBody.append("<div id=\"confirm_"
			+ opts.id
			+ "\" class=\"popup-window-confirm "
			+ opts.id
			+ "\"><div class=\"popup-window-cofirm-ico\"></div><div class=\"popup-window-confirm-context\">"
			+ opts.caption
			+ "</div></div>");

        var oConfirm = $("#confirm_" + opts.id, oBody);


        oBody.append("<div id=\"footer_"
			+ opts.id
			+ "\" class=\"popup-window-footer "
			+ opts.id
			+ "\"></div>");
        var oFooter = $("#footer_" + opts.id, oBody);

        oFooter.append("<input id=\"ok_"
			+ opts.id
			+ "\" type=\"button\" class=\"popup-window-ok "
			+ opts.id
			+ "\" value=\"确定\" />");
        var oOK = $("#ok_" + opts.id, oBody);

        oFooter.append("<input id=\"cancel_"
			+ opts.id
			+ "\" type=\"button\" class=\"popup-window-cancel "
			+ opts.id
			+ "\" value=\"取消\" />");
        var oCancel = $("#cancel_" + opts.id, oBody);

        if (opts.checkCaption != undefined) {
            oFooter.append("<div class=\"popup-window-conform-check\"><input id=\"check_"
		        + opts.id
		        + "\" type=\"checkbox\" name=\"check_"
		        + opts.id
		        + "\" "
		        + (opts.checked ? "checked=\"checked\"" : "")
		        + " /><label for=\"check_"
		        + opts.id
		        + "\">"
		        + opts.checkCaption
		        + "</label></div>");
        }

        var option = opts;

        oOK.click(function() {
            var formCount = window.top.$.Layers.length;
            if (formCount > 0) {
                if (!$.yz.getErrorList(option.id)) {
                    return;
                }
                remove(option);
                if (typeof option.ok == "function") {
                    var check = $("#check_" + option.id, oFooter);
                    option.ok(check.attr("checked"));
                }
            } else {
                window.close();
            }
        });

        oCancel.click(function() {
            remove(option);
            if (typeof option.cancel == "function") {
                option.cancel();
            }
        });

        oBody.width(oConfirm.outerWidth() + 5);
        oBody.height(oConfirm.outerHeight() + 5 + oFooter.height());
        opts.oBody = oBody;
        opts = setLayout(opts);
        window.top.$.Layers.push(opts);
        return opts;
    }

    
    function setLayout(opts) {
        var bodyHeight = opts.oBody.height();
        var bodyWidth = opts.oBody.width();
        var topHeight = opts.oTop.height();
        var borderheight = bodyHeight + topHeight;
        opts.oBorder.height(borderheight);
        opts.oBorder.width(bodyWidth);
        
        if (opts.oLoading) {
            opts.oLoading.css("top", 0.5 * bodyHeight - 40);
            opts.oLoading.css("left", 0.5 * bodyHeight - 60);
        }

        var top = opts.layout.scrollTop + 0.5 * (opts.layout.innerHeight - borderheight);
        var left = opts.layout.scrollLeft + 0.5 * (opts.layout.innerWidth - bodyWidth);
        //alert(opts.layout.scrollTop);
        opts.oBorder.css("top", top - 50);
        opts.oBorder.css("left", left);
        opts.oBorder.hide();
        opts.oBorder.animate({
            top: top,
            opacity: 'toggle'
        }, 300);

        return opts;
    }

    function installLoading(options) {
        var opts = $.extend({}, $.loading.defaults, options || {});
        if (opts.id == undefined) {
            opts.id = "popup" + Math.round(Math.random() * 10000);
        }
        var topBody = $(window.top.document.body);
        var layout = $.getLayout();
        //popup-window-iframe-loading
        topBody.append("<div id=\"" + opts.id + "\" class=\""+ opts.css +"\">" + opts.caption + "</div>");
        var loading = $("#" + opts.id);
        if (opts.borderStyle != undefined) {
            loading.css(opts.borderStyle);
        }
        var width = loading.width();
        var left = layout.scrollLeft + 0.5 * (layout.innerWidth - width);
        loading.css("left", left + width);
        loading.css("top", layout.scrollTop);
        loading.animate({
            left: left
        }, 200, "swing");
        loading.fadeIn(200);
        $.loadingObj.push(loading);
        if(opts.IsToCenter){
            $.toCenter(loading);
        }
        return opts;
    }

  

    $.loading.close = function(opts) {
        var topBody = $(window.top.document.body);
        var layout = $.getLayout();
        var loading = $("#" + opts.id);
        var width = loading.width();
        var left = layout.scrollLeft + 0.5 * (layout.innerWidth - width);
        loading.fadeOut(200, function() { loading.remove(); });
        return opts;
    }
    

    $.popup.close = function(obj) { 
        var formCount = window.top.$.Layers.length;
         if (formCount > 0) {
            var opts = window.top.$.Layers[formCount - 1];
            remove(opts);
            if(!obj){ 
                if (typeof opts.close == "function") {
                    opts.close();
                }
                return;
            }
            if (typeof opts.ok == "function") {
                opts.ok(obj);
            }
        }
//         else {
//            window.close();
//        }
    }
    $.popup.Refrsh=function()
    {
        document.location = document.location.href;
    }

    $.popup.cancel = function() {
        var formCount = window.top.$.Layers.length;
        if (formCount > 0) {
            var opts = window.top.$.Layers[formCount - 1];
            remove(opts);            
            if (typeof opts.cancel == "function") {
                opts.cancel();
            }
        } else {
            window.close();
        }
    }
     
    function remove(opts) {
        var topBody = $(window.top.document.body);
        if (opts.opobj !=undefined)
        {
            opts.opobj.appendTo(topBody);
            opts.opobj.hide();
        }
        var popWindowBackground = $("#popup_window_background", topBody);
        if (popWindowBackground.length > 0) {
            var zIndex = popWindowBackground.css("zIndex");
            popWindowBackground.css("zIndex", zIndex - 1);
        }

        window.top.$.Layers.pop();
        if (window.top.$.Layers.length == 0) {
            popWindowBackground.remove();
            setHtmlBodyScroll(true);
            window.top.document.onselectstart = null;
        }
        var els = $("." + opts.id, topBody);
        reset(els);
        
    }

    function reset(els) {
        els.each(function(i, o) {
            $(this).remove();
        });
    }

    /*获取鼠标的坐标 */
    function mouseCoords(ev) {
        if (ev.pageX || ev.pageY) {
            return { x: ev.pageX, y: ev.pageY };
        }
        return {
            x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
            y: ev.clientY + document.body.scrollTop - document.body.clientTop
        };
    }

    $.jsonToString = jsonToString;
    /* 将Json对象序列化 */
    function jsonToString(obj) {
        switch (typeof (obj)) {
            case 'string':
                return '"' + obj.replace(/(["\\])/g, '\\$1') + '"';
            case 'array':
                return '[' + obj.map(jsonToString).join(',') + ']';
            case 'object':
                if (obj instanceof Array) {
                    var strArr = [];
                    var len = obj.length;
                    for (var i = 0; i < len; i++) {
                        strArr.push(jsonToString(obj[i]));
                    }
                    return '[' + strArr.join(',') + ']';
                } else if (obj == null) {
                    return 'null';
                } else {
                    var string = [];
                    for (var property in obj)
                        string.push(jsonToString(property) + ':' + jsonToString(obj[property]));
                    return '{' + string.join(',') + '}';
                }
            case 'number':
                return obj;
            case "boolean":
                return obj;
        }
    }

    $.tryUnescape = function(text) {
        var oResult;
        if (typeof text == "string"
            && (/^\[.*\]$/.test(text)
            || /^\{.*\}$/.test(text))) {
            try {
                oResult = eval("(" + text + ")");
            } catch (escapeErr) {
                try {
                    oResult = eval("(" + escape(text) + ")");
                } catch (escapeErr) {
                    oResult = undefined;
                }
            }
        }
        return oResult || undefined;
    }

    $.fn.endFocus = function() {
        var ths = $(this);
        if (!ths.is("input[type='text']")
            && !ths.is("textarea")) {
            // 非标单元素退出
            return;
        }
        var elem = document.getElementById(ths.attr("id"));
        var caretPos = elem.value.length;
        if (elem != null) {
            if (elem.createTextRange) {
                var range = elem.createTextRange();
                range.move('character', caretPos);
                range.select();
            }
            else {
                elem.setSelectionRange(caretPos, caretPos);
                elem.focus();

                //空格键
                var evt = document.createEvent("KeyboardEvent");
                evt.initKeyEvent("keypress", true, true, null, false, false, false, false, 0, 32);
                elem.dispatchEvent(evt);
                // 退格键
                evt = document.createEvent("KeyboardEvent");
                evt.initKeyEvent("keypress", true, true, null, false, false, false, false, 8, 0);
                elem.dispatchEvent(evt);
            }
        }
    }

    function installTipOrError(opts, obj) {
        var buff = [];
        var oTip;
        var oCloseButton;

        if (document.getElementById(opts.id) == null) {
            if (opts.id == undefined) {
                opts.id = opts.viewClass + Math.round(Math.random() * 10000);
            }
            buff.push("<div class=\"tip\" id=\"");
            buff.push(opts.id);
            buff.push("\"><div class=\"");
            buff.push(opts.viewClass);
            buff.push("\"><b class=\"tip-ico\"></b><span class=\"tip-title\">");
            buff.push(opts.title);
            buff.push("</span><span class=\"tip-colon\">:</span><span>");
            buff.push(opts.caption);
            buff.push("</span><b class=\"tip-btn\"></b></div>");
            if (opts.fix) {
                oTip = $(buff.join("")).width(obj.innerWidth()).appendTo(obj);
            } else {
                oTip = $(buff.join("")).appendTo(obj);
            }
            oCloseButton = $("b.tip-btn", oTip).hover(function() {
                $(this).addClass("hover");
            },
            function() {
                $(this).removeClass("hover");
            }).click(function() {
                if (typeof opts.close == "function") {
                    opts.close();
                }
                oTip.fadeOut("normal", function() {
                    oTip.remove();
                    oTip = null;
                    oCloseButton = null;
                });
            });
        }
    }

    function tipOrErrorRemove(id) {
        var oTip = $("#" + id);
        if (oTip.length) {
            oTip.fadeOut("normal", function() {
                oTip.remove();
                oTip = null;
            });
        }
    }

    function tipOrErrorClose(id) {
        $("#" + id).remove();
    }

   
    function setHtmlBodyScroll(flag) {
        /*var tempH1 = window.top.document.body.clientHeight;
        var tempH2 = window.top.document.documentElement.clientHeight;
        var isXhtml = (tempH2<=tempH1&&tempH2!=0)?true:false; 
        var htmlbody = isXhtml?window.top.document.documentElement:window.top.document.body;*/
        var htmlbody = window.top.document.documentElement;
        htmlbody.style.overflow = flag ? "auto" : "hidden";
    }

    $.extentAjax = function(url, data, success, error, complete) {
        var opts = $.loading();
        $.ajax({
            url: url,
            data: data,
            success: function(ajaxContext) {
                if (ajaxContext != undefined
                        && ajaxContext.IsSuccess != undefined
                        && ajaxContext.Html != undefined) {
                    if (ajaxContext.IsSuccess == true) {
                        success(ajaxContext);
                        return;
                    } else if (ajaxContext.Source
                                && ajaxContext.Message
                                && ajaxContext.TargetSite
                                && ajaxContext.StackTrace) {
                        if (typeof error == "function") {
                            error();
                            return;
                        } else {
                            $.alertError({ message: ajaxContext.Message, object: ajaxContext.Source, method: ajaxContext.SoTargetSiterce, inner: ajaxContext.InnerException, desc: ajaxContext.StackTrace });
                        }
                    } else {
                        if (typeof error == "function") {
                            error();
                            return;
                        } else {
                            $.alertError({ message: "ajax 出现异常，但异常信息未能捕获.", object: "ajaxContext", method: "$.extentAjax", "file": "~/script/jquery.popup.js", line: 910 });
                        }
                    }

                } else {
                    if (typeof error == "function") {
                        error();
                        return;
                    } else {
                        $.alertError({ message: "ajax 请求成功，但是参数[ajaxContext]为null.", object: "ajaxContext", method: "$.extentAjax", "file": "~/script/jquery.popup.js", line: 975 });
                    }
                }
            },
            dataType: "json",
            cache: false,
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                if (typeof error == "function") {
                    error();
                } else {
                    $.alertError({ message: textStatus, object: "error", method: "$.extentAjax", "file": "~/script/jquery.popup.js", line: 1000 });
                }
            },
            complete: function() {
                if (typeof complete == "function") {
                    complete();
                }
                $.loading.close(opts);
            }
        });
    }
    $.alertError = function(options) {
        var opts;
        if (typeof options == "string") {
            opts = { message: options };
        } else if (typeof options == "object") {
            opts = options;
        } else {
            return;
        }
        var errorArray = [];
        errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
        errorArray.push(opts.message);
        if (opts.object != undefined) {
            errorArray.push("\r\n\t对象名称：\t");
            errorArray.push(opts.object);
        }
        if (opts.method != undefined) {
            errorArray.push("\r\n\t方法名称：\t");
            errorArray.push(opts.method);
        }
        if (opts.file != undefined) {
            errorArray.push("\r\n\t代码文件：\t");
            errorArray.push(opts.file);
        }
        if (opts.line != undefined) {
            errorArray.push("\r\n\t出 错 行：\t");
            errorArray.push(opts.line);
            errorArray.push(" 行");
        }
        if (opts.inner != undefined) {
            errorArray.push("\r\n\t内联异常：\t");
            errorArray.push(opts.inner);
        }
        if (opts.desc != undefined) {
            errorArray.push("\r\n\t详细信息：\t");
            errorArray.push(opts.desc);
        }
        errorArray.push("\r\n\r\n请与系统管理员联系.\r\n\r\nCopyright © ");
        errorArray.push(new Date().getFullYear());
        errorArray.push(" Shenzhen Custom, All Rights Reserved");

        alert(errorArray.join(""));
    }

    $.toCenter=function(obj)
    {    
         var layout = $.getLayout(window);
         var width =(layout.innerWidth -  obj.width())/2;
         var mHigth=(layout.innerHeight - obj.height())/2;
         obj.css("left", width);
         obj.css("top", mHigth);
    }

})(jQuery);
