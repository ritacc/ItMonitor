/* Author       : Jitlee.Wan
 * Create Date  : Mar 19th,2011
 * Description  : provided device or supply dropdown list
 */
 
; (function($) {
    $.fn.device = initDeviceConfigtion;                 // 设备（3层）
   

    // 方法
    $.deviceAndSupply = {
        add: deviceAndSupplyAdd,                        //  添加节点
        ajax: deviceAndSupplyAjax,                      //  扩展Ajax
        autoLayout: deviceAndSupplyAutoLayout, 	        //  设置popup对象的位置
        collapse: deviceAndSupplyCollapse, 		        //  隐藏下拉面板
        del: deviceAndSupplyDelete,                     //  删除节点
        empty: deviceAndSupplyEmpty,                    //  置空
        edit: deviceAndSupplyEdit,                      //  修改节点
        extend: deviceAndSupplyExtend,                  //   扩展参数
        filter: deviceAndSupplyFilter,                  //   JS过滤
        getCurrent: deviceAndSupplyGetCurrent,          //   获取当前节点对象
        getOptions: deviceAndSupplyGetOptions, 	        //   通过popup对象获取参数
        getParent: deviceAndSupplyGetParent,            //   获取父结点对象
        init: deviceAndSupplyInit,                      //   初始化
        initLevel1: deviceAndSupplyInitLevel1,          //   初始化一级节点
        initLevel2: deviceAndSupplyInitLevel2,          //   初始化二级节点
        initLevel3: deviceAndSupplyInitLevel3,          //   初始化三级节点
        initLevel4: deviceAndSupplyInitLevel4,          //   初始化四级节点
        initMenu: deviceAndSupplyInitMenu,              //   初始化菜单选项
        initNew: deviceAndSupplyInitNew,                //   初始化新加的节点
        loadCollection: deviceAndLoadCollection,        //   加载子集
        loadData: deviceAndSupplyLoadData,              //   加载数据
        select: deviceAndSupplySelect,                  //   选中事件
        setSelectItem: deviceAndSupplySetSelectedItem,  //   设置对象被选中
        setText: deviceAndSupplySetText,                //   设置按钮文本
        single: deviceAndSupplySingle,                  //   页面回传时将guid变成displayName
        togeter: deviceAndSupplyToggler, 	            //   切换下拉面板展开与隐藏状态
        updateTitle: deviceAndSupplyUpdateTitle         //   编辑后更新当前项的title属性
    };

    // 属性
    $.deviceAndSupply.defaults = {
        guid: undefined, 	                            //   根节点Guid
        input: false, 		                            //	 是否为可输入模式
        canEmpty: false, 		                        // * 是否验证为空,input设置为false时，默认为false,input设置为true时默认值为true
        title: undefined,                               // * 验证的字段名称,empty为true时有效
        depth: undefined,                               //   显示层的深度
        any: undefined                                   //   表示可以选择任意节点
    };


    $.deviceAndSupply.menuOptions = new Array(5);

    // 初始化设备类型
    function initDeviceConfigtion(options) {
        var opts = $.deviceAndSupply.extend(options);
        if (opts != undefined) {
            if (opts.title == undefined) {
                opts.title = "设备类型";
            }
            if (opts.depth == undefined) {
                opts.depth = 3;
            }
            opts.viewClass = "device";
            opts.isDevice = true;
            opts.isSupply = false;
            opts.identity = "infoAdmin"; // 管理员身份 infoAdmin:设备参数管理权限
            opts.titles = [{ title: "设备名称", canDuplicate: false }, { title: "品牌", canDuplicate: false }, { title: "型号", canDuplicate: false}];
            $.deviceAndSupply.init(opts, $(this));
        }
        return $(this);
    }
     

    //  添加节点
    function deviceAndSupplyAdd(element, opts, level) {
        var fields = [{ id: "Displayname", value: "", title: opts.titles[level].title, yz: { max: 64, isSave: true}}];
        if ((opts.isDevice && level == 2)
                || (opts.isSupply && level == 3)) {
            fields.push({ id: "SubName", value: "", title: "规格", yz: { max: 64, canEmpty: true, isSave: true} });
            if (opts.isSupply) { // 如果是耗材 添加是否为耗材字段
                fields.push({ id: "Flag", checked: false, type: "checkbox", title: " 0o", caption: "是否为耗材" });
            }
            fields.push({ id: "Remark", value: "", type: "textarea", title: "备注", yz: { max: 128, canEmpty: true, isSave: true} });
        }
        $.tip.close("delete_" + opts.id); // 清除之前的错误提示

        var el = $(element);
        var oParentElement = $.deviceAndSupply.getParent(opts, el, level);
        if (oParentElement.length != 1) {
            $.alertError({ message: "对象得不到任何值", object: "oParentElement", method: "deviceAndSupplyAdd", file: "~/script/jquery.device-supply.js", line: 483, desc: "参数level = " + level });
            return;
        }

        $.prompt({
            title: "新增" + opts.titles[level].title,
            fields: fields,
            submit: function(result) {
                //自定义验证   验证是否有重复名称（注意编辑不包含自己）
                var bReuslt = true;
                if (opts.titles[level].canDuplicate == false) { // 不能同名
                    var titles = $("span.level" + (level + 1), oParentElement);
                    titles.each(function(iTitle, nTitle) {
                        if (bReuslt) {
                            var ths = $(nTitle);
                            if ($.trim(ths.find("span.level-title:first").text().toUpperCase()) == result.Displayname.toUpperCase()) {
                                var buff = [];
                                buff.push("信息提示：\n");
                                if ((opts.isDevice && level == 2)
                                    || (opts.isSupply && level == 3)) { // 型号和规格 不能同时重复
                                    if ($.trim(ths.find("span.level-sub:first").text().toUpperCase()) == result.SubName.toUpperCase()) {
                                        bReuslt = false;
                                        buff.push("[" + opts.titles[level].title + "和规格" + "]\t不能重复");
                                    }
                                } else {
                                    bReuslt = false;
                                    buff.push("[" + opts.titles[level].title + "]\t不能重复");
                                }
                                if (bReuslt == false) {
                                    alert(buff.join("\n  * "));
                                }
                                buff.length = 0;
                                buff = null;
                            }
                        }
                        ths = null;
                    });
                    titles = null;
                }
                return bReuslt;
            },
            ok: function(result) {
                var oNewCategory = {};
                oNewCategory.Displayname = result.Displayname;
                oNewCategory.ParentGuid = oParentElement.attr("guid");
                oNewCategory.RootGuid = opts.guid;
                oNewCategory.Level = level + 1;
                if ((opts.isDevice && level == 2)
                        || (opts.isSupply && level == 3)) {
                    oNewCategory.SubName = result.SubName;
                    if (opts.isSupply) {// 如果是耗材 添加是否为耗材字段
                        oNewCategory.Flag = result.Flag === true ? 1 : 0;
                    }
                    oNewCategory.Remark = result.Remark;
                }
                $.deviceAndSupply.ajax("type=add&obj=" + escape($.jsonToString(oNewCategory)) + "&depth=" + opts.depth, function(ajaxContent) {
                    oNewCategory.Guid = ajaxContent.UserState;
                    oNewCategory.obj = ajaxContent.Html;
                    $.deviceAndSupply.initNew(oNewCategory, opts, oParentElement);
                    oParentElement = null;
                    oNewCategory = null;
                    fields.length = null;
                    el = null;
                });
            }
        });
    }

    //  编辑节点
    function deviceAndSupplyEdit(element, opts, level) {
        var el = $(element);
        var oCurrent = $.deviceAndSupply.getCurrent(el, level);
        if (oCurrent == undefined) { return; }        
        var fields = [{ id: "Displayname", value: oCurrent.object.Displayname, title: opts.titles[level].title, yz: { max: 64, isSave: true}}];
        if ((opts.isDevice && level == 2)
                || (opts.isSupply && level == 3)) {
            fields.push({ id: "SubName", value: oCurrent.object.SubName, title: "规格", yz: { max: 64, canEmpty: true, isSave: true} });
            if (opts.isSupply) {// 如果是耗材 添加是否为耗材字段
                fields.push({ id: "Flag", checked: oCurrent.object.Flag === 1, type: "checkbox", title: " ", caption: "是否为耗材" });
            }
            fields.push({ id: "Remark", value: oCurrent.object.Remark, type: "textarea", title: "备注", yz: { max: 128, canEmpty: true, isSave: true} });
        }

        $.tip.close("delete_" + opts.id); // 清除之前的错误提示
        $.prompt({
            title: "编辑" + opts.titles[level].title,
            fields: fields,
            submit: function(result) {
                //自定义验证   验证是否有重复名称（注意编辑不包含自己）
                var bReuslt = true;
                if (opts.titles[level].canDuplicate == false) { // 不能同名        
                    var oParentElement = $.deviceAndSupply.getParent(opts, el, level);
                    if (oParentElement.length != 1) {
                        $.alertError({ message: "对象得不到任何值", object: "oParentElement", method: "deviceAndSupplyAdd", file: "~/script/jquery.device-supply.js", line: 483, desc: "参数level = " + level });
                        oParentElement = null;
                        return;
                    }
                    var titles = $("span.level" + (level + 1), oParentElement);

                    titles.each(function(iTitle, nTitle) {
                        if (bReuslt) {
                            var ths = $(nTitle);
                            if ($.trim(ths.find("span.level-title:first").text().toUpperCase()) == result.Displayname.toUpperCase()
                                    && ths.attr("guid") != oCurrent.object.Guid) {
                                var buff = [];
                                buff.push("信息提示：\n");
                                if ((opts.isDevice && level == 2)
                                    || (opts.isSupply && level == 3)) { // 型号和规格 不能同时重复
                                    if ($.trim(ths.find("span.level-sub:first").text().toUpperCase()) == result.SubName.toUpperCase()) {
                                        bReuslt = false;
                                        buff.push("[" + opts.titles[level].title + "和规格" + "]\t不能重复");
                                    }
                                } else {
                                    bReuslt = false;
                                    buff.push("[" + opts.titles[level].title + "]\t不能重复");
                                }
                                if (bReuslt == false) {
                                    //alert(buff.join("\n  * "));
                                }
                                buff.length = 0;
                                buff = null;
                            }
                        }
                        ths = null;
                    });
                    titles = null;
                    oParentElement = null;
                }
                return bReuslt;
            },
            ok: function(result) {
                oCurrent.object.Displayname = result.Displayname;
                if ((opts.isDevice && level == 2)
                        || (opts.isSupply && level == 3)) {
                    oCurrent.object.SubName = result.SubName;
                    if (opts.isSupply) {// 如果是耗材 添加是否为耗材字段
                        oCurrent.object.Flag = result.Flag === true ? 1 : 0;
                    }
                    oCurrent.object.Remark = result.Remark;
                }
                $.deviceAndSupply.ajax("type=edit&obj=" + escape($.jsonToString(oCurrent.object)) + "&depth=" + opts.depth, function(ajaxContent) {
                    oCurrent.element.attr("obj", ajaxContent.Html);
                    $("span.level-title:first", oCurrent.element).text(result.Displayname);
                    if ((opts.isDevice && level == 2)
                            || (opts.isSupply && level == 3)) {
                        $("span.level-sub:first", oCurrent.element).text(result.SubName);
                    }
                    // 管理已选择项的视图状态,如果修项正好为当前项或为当前项的父亲，则更新视图
                    var val = $.trim(opts.oSourceElement.val());
                    if (opts.input == false
                                && val.length > 0) {
                        var guidOrObject = $.tryUnescape(val);
                        if (guidOrObject != undefined) {
                            if (oCurrent.object.Guid == guidOrObject.Guid) { // 本身
                                $.deviceAndSupply.setSelectItem(opts, oCurrent.element);
                            } else { // 子项
                                var selectedItem = $("#level_" + guidOrObject.Guid, oCurrent.element);
                                if (selectedItem.length > 0) {
                                    $.deviceAndSupply.setSelectItem(opts, selectedItem);
                                }
                                selectedItem = null;
                            }
                        }
                        guidOrObject = null;
                    }

                    // 更新当前项的title
                    $.deviceAndSupply.updateTitle(opts, oCurrent.object, level, el);

                    el = null;
                    oCurrent = null;
                    fields.length = 0;
                });
            }
        });
    }

    //  删除节点
    function deviceAndSupplyDelete(element, opts, level) {
        var el = $(element);
        var oCurrent = $.deviceAndSupply.getCurrent(el, level);
        if (oCurrent == undefined) { return; }
        $.tip.close("delete_" + opts.id); // 清除之前的错误提示
        $.confirm(
            {
                title: "询问",
                caption: "是否确定删除[" + opts.titles[level].title + ">>" + oCurrent.object.Displayname + "]吗？",
                ok: function() {
                    $.deviceAndSupply.ajax("type=delete&guid=" + escape(oCurrent.object.Guid) + "&root=" + opts.guid + "&depth=" + opts.depth + "&flag=" + (opts.isSupply ? 0 : 1), function(ajaxContent) {
                        var count = parseInt(ajaxContent.UserState);
                        if (count == 0) {// 删除成功
                            // 管理已选择项的视图状态,如果已选择的被删除（包含其中）则清空选择项
                            var val = $.trim(opts.oSourceElement.val());
                            if (opts.input == false
                                && val.length > 0) {
                                var guidOrObject = $.tryUnescape(val);
                                if (guidOrObject != undefined
                                    && (oCurrent.object.Guid == guidOrObject.Guid
                                    || $("#level_" + guidOrObject.Guid, oCurrent.element).length > 0)) {
                                    $.deviceAndSupply.empty(opts, true);
                                }
                            }
                            oCurrent.element.remove();
                        } else { // 有关联数据，删除失败
                            opts.oPopup.error({ id: "delete_" + opts.id, caption: "[<span style=\"color:blue;text-decoration:underline;\">" + opts.titles[level].title + "</span>&gt;&gt;<span style=\"color:blue;text-decoration:underline;\">" + oCurrent.object.Displayname + "</span>]不能被删除，其他表有<span style=\"color:red;\">" + count + "</span>条关联数据.", fix: true });
                        }
                        el = null;
                        oCurrent = null;
                    });
                }
            });
    }

    function deviceAndSupplyEmpty(opts, valid) {
        opts.oSourceElement.val("");
        if (opts.input == false) {
            opts.oCaption.text("请选择");
            if (valid != undefined && opts.canEmpty == false) {
                opts.oButton.addClass("valid");
            }
            opts.oButton.removeAttr("title");
        }
    }

    // 扩展参数
    function deviceAndSupplyExtend(options) {
        var opts = {};
        if (typeof options == "string") {
            opts = $.extend({}, $.deviceAndSupply.defaults, { guid: options, title: options });
        } else if (typeof options == "object") {
            if (options.input == true
				&& typeof options.canEmpty == "undefined") {
                // input设置为false时，默认为false,input设置为true时默认值为true
                options.canEmpty = true;
            }
            opts = $.extend({}, $.deviceAndSupply.defaults, options || {});
            if (typeof opts.guid == "undefined") {
                $.alertError({ message: "参数配置错误,没有设置参数guid！", object: "options", method: "deviceAndSupplyExtend", file: "~/script/jquery.device-supply.js", line: 289 });
                return undefined;
            }
            if (opts.any == undefined) {
                opts.any = opts.input;
            }
        } else {
            $.alertError({ message: "参数配置错误，参数类型不满足！", object: "options", method: "deviceAndSupplyExtend", file: "~/script/jquery.device-supply.js", line: 296 });
            return undefined;
        }
        return opts;
    }

    $(document).click($.deviceAndSupply.collapse);

    function deviceAndSupplyAjax(data, success, error, complete) {
        $.extentAjax("../DropdownDeviceList.aspx", data, success, error, complete);
    }

    function deviceAndSupplyAutoLayout(opts) {
        var offset, layout, width, height, left, top, oFix;
        offset = opts.oButton.offset();
        layout = $.getLayout();
        width = opts.oPopup.width();
        height = opts.oPopup.height();

        // oButton没有大小，不知道为什么
        if (opts.oInput != undefined && opts.oInput.length) {
            oFix = opts.oInput;
        } else {
            oFix = opts.oButton.children("div:first");
        }
        var fixWidth = oFix.outerWidth() - 2;
        if (width < fixWidth) {
            opts.oPopup.width(fixWidth);
        }
        if (height < 20) {
            opts.oPopup.width(50);
        }

        top = offset.top + oFix.outerHeight();

        left = offset.left;
        if (left + width > layout.innerWidth) {
            left = layout.innerWidth - width - 18;
        }
        opts.oPopup.animate({
            top: top,
            left: left
        }, 200);
    }

    function deviceAndSupplyCollapse(event) {
        var oPopup = $("div.device-dropdown-expended");
        if (oPopup.length > 0) {
            var opts = $.deviceAndSupply.getOptions(oPopup);
            if (opts.autoCollaspe) {
                if (opts.canEmpty == false) {
                    if (opts.oButton.length > 0
						&& $.trim(opts.oSourceElement.val()) == "") {
                        opts.oButton.addClass("valid");
                    } else {
                        opts.oButton.removeClass("valid");
                    }
                }
                oPopup.removeClass("device-dropdown-expended").hide();
                opts.oButton.removeClass("device-dropdown-expended");
            }
            opts = null;
        }
        oPopup = null;
    }

    function deviceAndSupplyFilter(opts) {
        var keywords = $.trim(opts.oSearchInput.val().toUpperCase());
        opts.oSearchInput.endFocus();
        $("span.hit", opts.oPopup).removeClass("hit");
        $("span.hide", opts.oPopup).removeClass("hide");
        $("b.hide", opts.oPopup).removeClass("hide");
        $("a.hide", opts.oPopup).removeClass("hide");
        if (keywords.length > 0) {
            $("span.level1-selected", opts.oPopup).removeClass("level1-selected").removeClass("level1-expand");
            $("span.level1", opts.oPopup).each(function(i1, oLevel1) {
                var level1 = $(oLevel1);
                if (level1.text().toUpperCase().indexOf(keywords) > -1) {
                    level1.addClass("hit");
                    if ($("span.level1-content", level1).text().toUpperCase().indexOf(keywords) > -1) {
                        $("span.level2", level1).each(function(i2, oLevel2) {
                            var level2 = $(oLevel2);
                            if (level2.text().toUpperCase().indexOf(keywords) > -1) {
                                if ($("span.level2-content", level2).text().toUpperCase().indexOf(keywords) > -1) {
                                    $("span.level3", level2).each(function(i3, oLevel3) {
                                        var level3 = $(oLevel3);
                                        if (level3.text().toUpperCase().indexOf(keywords) > -1) {
                                            if ($("span.level3-content", level3).text().toUpperCase().indexOf(keywords) > -1) {
                                                $("span.level4", level3).each(function(i4, oLevel4) {
                                                    var level4 = $(oLevel4);
                                                    if (level4.text().toUpperCase().indexOf(keywords) == -1) {
                                                        level4.addClass("hide");
                                                        return;
                                                    }
                                                });
                                            }
                                        } else {
                                            level3.addClass("hide");
                                        }
                                    });
                                }
                            } else {
                                level2.addClass("hide");
                            }
                        });
                    }
                } else {
                    level1.addClass("hide");
                }
            });
        }
    }

    function deviceAndSupplyGetOptions(oPopup) {
        var opts = eval("(" + oPopup.attr("options") + ")");
        opts.oSourceElement = $("#" + opts.id);
        opts.oButton = $("#button_" + opts.id);
        opts.oCaption = $("#caption_" + opts.id);
        opts.oInput = $("#input_" + opts.id);
        opts.oPopup = $("#popup_" + opts.id);
        opts.oContent = $("#content_" + opts.id);
        //        opts.oSearchInput = $("#search_input_" + opts.id);
        opts.oSearchButton = $("#search_button_" + opts.id);
        opts.autoCollaspe = oPopup.attr("autoCollaspe") != false;
        return opts;
    }

    function deviceAndSupplyGetParent(opts, el, level) {
        var parent = undefined;
        switch (level) {
            case 0:
                parent = el.is("span.level1-title") ? el.closest("div.content") : el.find("div.content:first");
                break;
            case 1:
                parent = el.closest("span.level1");
                break;
            case 2:
                parent = el.closest("span.level2");
                break;
            case 3:
                parent = el.closest("span.level3");
                break;
        }
        return parent;
    }

    function deviceAndSupplyGetCurrent(el, level) {
        var element = undefined;
        switch (level) {
            case 0:
                element = el.closest("span.level1");
                break;
            case 1:
                element = el.closest("span.level2");
                break;
            case 2:
                element = el.closest("span.level3");
                break;
            case 3:
                element = el;
                break;
        }
        if (element.length != 1) {
            $.alertError({ message: "获取当前节点失败", object: "element", method: "deviceAndSupplyGetCurrent", "file": "~/script/jquery.device-supply.js", line: 744 });
            return undefined;
        }
        var object = $.tryUnescape($.trim(element.attr("obj").replace(/&quot;/g, "\"")));
        if (object == undefined) {
            $.alertError({ message: "序列化对象失败", object: "object", method: "deviceAndSupplyGetCurrent", "file": "~/script/jquery.device-supply.js", line: 749 });
            return undefined;
        }
        return { "element": element, "object": object };
    }

    function deviceAndSupplyInit(opts, obj) {
        // 定义变量
        var oSourceElement; 			            // 当前源控件对象
        var id; 						            // 当前源控件的ID
        var oBody; 					                // 当前body对象
        var oButton; 				                // 当控件为不可输入的情况下的按纽对象
        var sButtonId; 				                // 当控件为不可输入的情况下的按纽对象ID
        var oCaption; 				                // 当控件为不可输入状态下的文本对象
        var sCaptionId; 				            // 当控件为不可输入状态下的文本对象ID
        var oDropdownButton; 		                // 当控件为可输入状态下的下拉按纽对象
        var sDropdownButtonId; 		                // 当控件为可输入状态下的下拉按纽对象ID
        var oPopup; 				                // 下拉框
        var oContent;                               // 列表容器
        var sContentId;                             // 列表容器Id
        var sPopupId; 				                // 下拉框ID
        var oInput;                                 // 输入框
        var sInputId;                               // 输入框Id
        var oEmptyButton;                           // 清空按钮对象
        var sEmptyButtonId;                         // 清空按钮对象ID
        //        var oSearchInput;                           // 搜索框对象
        var sSearchInputId;                         // 搜索框对象Id
        var oSearchButton;                          // 搜索框对象
        var sSearchButtonId;                        // 搜索按钮对象Id
        var bCanDrop; 				                // 临时保存是否可以下拉的变量
        var optsJsonString; 		                // 临时保存optsJson格式的字符串
        oBody = $(window.document.body);
        oSourceElement = obj; 	                // 初始化当前源控件对象

        // 分配ID
        id = oSourceElement.attr("id");
        sButtonId = "button_" + id;
        sCaptionId = "caption_" + id;
        sDropdownButtonId = "dropdown_" + id;
        sPopupId = "popup_" + id;
        sInputId = "input_" + id;
        sContentId = "content_" + id;
        sSearchInputId = "search_input_" + id;
        sSearchButtonId = "search_button_" + id;
        sEmptyButtonId = "empty_button_" + id;
        opts.id = id;


        oButton = $("#" + sButtonId);
        if (oButton.length) { // 重新设置depth时需要，很痛苦，当初没考虑到这一点
            oSourceElement.insertBefore(oButton);
            oButton.remove();
            $("#" + sPopupId).remove();
            oSourceElement.val("");
        }

        //如果源控件对象的Enabled属性为'false'时，设置为不弹出下拉框
        opts.candrop = bCanDrop = oSourceElement.attr("disabled") == false;
        optsJsonString = $.jsonToString(opts);
        opts.oSourceElement = oSourceElement;

        if (opts.input == true) {		// 输入模式
            oButton = $("<span id=\"" + "button_" + id + "\" class=\"device-dropdown\"></span>").insertAfter(oSourceElement).append(oSourceElement.hide());
            opts.oButton = oButton;

            oInput = $("<input type=\"text\" id=\"" + sInputId + "\" />").appendTo(oButton).keyup(function() {
                var ths = $(this);
                ths.css("fontWeight", "normal");
                ths.removeAttr("title");
                ths = null;
            }).change(function() {
                var ths = $(this);
                opts.oSourceElement.val(ths.val());
                ths = null;
            });
            opts.oInput = oInput;
        } else {						// 不可输入模式
            var buff = [];
            // 生成的按钮
            buff.push("<span tabindex=\"0\" onselectstart=\"return false;\" class=\"device-dropdown\"><span id=\"");
            buff.push(sButtonId);
            buff.push("\">");
            // 按钮的外框
            buff.push("<div class=\"outer-box\">");
            // 按钮的内框
            buff.push("<div class=\"inner-box\">");
            // 按钮的文本
            buff.push("<div id=\"");
            buff.push(sCaptionId);
            buff.push("\" class=\"\"></div>");
            // 是否显示下拉三角符号
            if (bCanDrop) {
                buff.push("<div class=\"drop\">▼</div>");
            }
            buff.push("</div></div></span></span>");
            oButton = $(buff.join("")).insertAfter(oSourceElement.hide()).children(":first-child");
            if (bCanDrop) {
                oButton.hover(function() { // 设置鼠标Hover样式
                    $(this).addClass("hover");
                }, function() {
                    $(this).removeClass("hover");
                });
            }
            opts.oButton = oButton;
            opts.oCaption = $("#" + sCaptionId, oButton);
            buff = null;
        }

        $.deviceAndSupply.single(opts);

        // 设置验证
        if (opts.canEmpty == false) {
            if (opts.input == false) {
                oButton.yz({
                    title: opts.title,
                    targetElement: id,
                    cssClass: "valid"
                });
            } else {
                opts.oSourceElement.yz({ title: opts.title });
            }
        }

        // 创建下拉面板
        if (bCanDrop) {
            var buff = [];
            buff.push("<div id=\"");
            buff.push(sPopupId);
            buff.push("\" class=\"device-dropdown device-dropdown-popup\" onselectstart=\"return false;\"><div class=\"");
            buff.push(opts.viewClass);
            buff.push("\"><div class=\"title\"><span>");
            buff.push(opts.title);
            buff.push("</span><span id=\"");
            buff.push(sEmptyButtonId);
            buff.push("\" class=\"empty-button\" title=\"置空\"></span></div>\<div id=\"");
            buff.push(sContentId);
            buff.push("\" guid=\"");
            buff.push(opts.guid);
            buff.push("\" class=\"content\"></div></div></div>");
            oPopup = $(buff.join("")).appendTo(oBody).attr("options", optsJsonString).click(function(event) {
                event.stopPropagation();
            });
             oPopup.bgiframe();
            opts.oPopup = oPopup;
            oContent = $("#" + sContentId);
            opts.oContent = oContent;
            oEmptyButton = $("#" + sEmptyButtonId).click(function() { $.deviceAndSupply.empty(opts, true); $.deviceAndSupply.collapse(); });
          
            oButton.click(function(event) {
                $.deviceAndSupply.togeter(event, opts);
            }).attr("tabindex", 0);
            optsJsonString = null;
            buff = null;

            if (opts.any && opts.depth > 1) {
                if ($.cookie("anyChoise") == undefined) {
                    $("#any_" + opts.id, opts.oPopup).remove();
                    opts.oPopup.tip({ id: "any_" + opts.id, caption: "用鼠标可以选择<span style=\"color:blue\">任意</span>节点.", fix: true, close: function() {
                        $.cookie("anyChoise", true, { expires: 30, path: "/" })
                    }
                    });
                }

            }

            // 初始化Popup面板的位置
            $.deviceAndSupply.autoLayout(opts);
        }

        // 释放资源
        oSourceElement = null; 			                // 当前源控件对象
        id = null; 						                // 当前源控件的ID
        oBody = null; 					                // 当前body对象
        oButton = null; 				                // 当控件为不可输入的情况下的按纽对象
        sButtonId = null; 				                // 当控件为不可输入的情况下的按纽对象ID
        oCaption = null; 				                // 当控件为不可输入状态下的文本对象
        sCaptionId = null; 				                // 当控件为不可输入状态下的文本对象ID
        oDropdownButton = null; 		                // 当控件为可输入状态下的下拉按纽对象
        sDropdownButtonId = null; 		                // 当控件为可输入状态下的下拉按纽对象ID
        oPopup = null; 				                    // 下拉框
        oContent = null;                                // 列表容器
        sContentId = null;                              // 列表容器Id
        sPopupId = null; 				                // 下拉框ID
        oEmptyButton = null;                            // 清空按钮对象
        sEmptyButtonId = null;                          // 清空按钮对象Id
        //        oSearchInput = null;                            // 搜索框对象
        sSearchInputId = null;                          // 搜索框对象Id
        oSearchButton = null;                           // 搜索框对象
        sSearchButtonId = null;                         // 搜索按钮对象Id
        bCanDrop = null; 				                // 临时保存是否可以下拉的变量
        optsJsonString = null; 		                    // 临时保存optsJson格式的字符串

        return false;
    }

    function deviceAndSupplyInitNew(category, opts, parent) {
        var buff = [];
        buff.push("<span class=\"level");
        buff.push(category.Level);
        buff.push("  level\" id=\"level_");
        buff.push(category.Guid);
        buff.push("\" guid=\"");
        buff.push(category.Guid);
        buff.push("\" obj=\"");
        buff.push(category.obj);
        buff.push("\"><span class=\"level");
        buff.push(category.Level);
        buff.push("-title\">");
        if (category.Level == 1) {
            buff.push("<b></b>");
        }
        buff.push("<span class=\"level-title\">");
        buff.push(category.Displayname);
        buff.push("</span>");
        if (((opts.isDevice && category.Level == 3)       // 设备第三层
                            || (opts.isSupply && category.Level == 4))   // 耗材第四层
                            && category.SubName.length > 0) {     // SubName不为空
            buff.push("<span class=\"level-sub\">");
            buff.push(" ");
            buff.push(category.SubName);
            buff.push("</span>");
        }
        buff.push("</span><span class=\"level");
        buff.push(category.Level);
        buff.push("-content\"></span>");
        buff.push("</span>");
        var oLevel = undefined;
        switch (category.Level) {
            case 1:
                oLevel = $(buff.join("")).appendTo(parent);
                $.deviceAndSupply.initLevel1(opts, oLevel);
                break;
            case 2:
                oLevel = $(buff.join("")).appendTo($(".level1-content", parent));
                $.deviceAndSupply.initLevel2(opts, oLevel);
                break;
            case 3:
                oLevel = $(buff.join("")).appendTo($(".level2-content", parent));
                $.deviceAndSupply.initLevel3(opts, oLevel);
                break;
            case 4:
                oLevel = $(buff.join("")).appendTo($(".level3-content", parent));
                $.deviceAndSupply.initLevel4(opts, oLevel);
                break;
        }
        oLevel = null;
        buff.length = 0;
    }

    function deviceAndSupplyInitLevel1(opts, obj) {
       
        var level1Title = $("span.level1-title", obj);
        //        if (obj.length > 0) {
        //            obj.eq(0).addClass("level1-selected").addClass("level1-expand");
        //        }
       
        if (opts.isAdmin) {
         
            if (opts.depth > 0) {
           
                $.deviceAndSupply.initMenu(opts, 0);
            }
            level1Title.contextmenu($.deviceAndSupply.menuOptions[0]).attr("tabindex", 0);
        }
        level1Title.hover(
			    function() {
			        var prt = $(this).parent("span.level1");
			        prt.addClass("level1-hover");
			    },
			    function() {
			        var prt = $(this).parent(".level1");
			        prt.removeClass("level1-hover");
			    }
		    );
        setTimeout(function() {
            level1Title.each(function(i, n) {
                var ths = $(this);
                $.deviceAndSupply.updateTitle(opts, { Displayname: ths.text() }, 0, ths);
                ths = null;
            });
        }, 500);
        if (opts.depth == 1 || opts.any) {
            level1Title.click(function() { $.deviceAndSupply.select(opts, $(this)); }).hover(
			        function() {
			            $(this).addClass("any-hover");
			        },
			        function() {
			            $(this).removeClass("any-hover");
			        }
		        );
            level1Title.find("b").click(function(event) {
                var prt = $(this).closest("span.level1");
                if (opts.depth > 1) {
                    if (prt.hasClass("level1-selected")) {
                        prt.toggleClass("level1-expand");
                    } else {
                        $("span.level1-selected").removeClass("level1-selected").removeClass("level1-expand");
                        prt.addClass("level1-selected").addClass("level1-expand");
                        $.deviceAndSupply.loadCollection(opts, prt.attr("guid"), 2, prt);
                    }
                    $("span.hit").removeClass("hit");
                } else {
                    $("span.level1-selected").removeClass("level1-selected");
                    prt.addClass("level1-selected");
                }
                event.stopPropagation();
            });
        } else {
            level1Title.click(function() {
                var prt = $(this).parent("span.level1");
                if (opts.depth > 1) {
                    if (prt.hasClass("level1-selected")) {
                        prt.toggleClass("level1-expand");
                    } else {
                        $("span.level1-selected").removeClass("level1-selected").removeClass("level1-expand");
                        prt.addClass("level1-selected").addClass("level1-expand");
                        $.deviceAndSupply.loadCollection(opts, prt.attr("guid"), 2, prt);
                    }
                    $("span.hit").removeClass("hit");
                } else {
                    $("span.level1-selected").removeClass("level1-selected");
                    prt.addClass("level1-selected");
                }
            });
        }
    }

    function deviceAndSupplyInitLevel2(opts, obj) {
        obj.hover(
			    function() {
			        $(this).addClass("level2-hover");
			    },
			    function() {
			        $(this).removeClass("level2-hover");
			    }
		    );
        var level2Title = $("span.level2-title", obj);
        setTimeout(function() {
            level2Title.each(function(i, n) {
                var ths = $(this);
                $.deviceAndSupply.updateTitle(opts, { Displayname: ths.text() }, 1, ths);
                ths = null;
            });
        }, 1500);
        if (opts.isAdmin) {
            if (opts.depth > 1) {
                $.deviceAndSupply.initMenu(opts, 1);
            }
            level2Title.contextmenu($.deviceAndSupply.menuOptions[1]).attr("tabindex", 0);
        }
        if (opts.depth == 2 || opts.any) {
            level2Title.click(function() { $.deviceAndSupply.select(opts, $(this)); }).hover(
			        function() {
			            $(this).addClass("any-hover");
			        },
			        function() {
			            $(this).removeClass("any-hover");
			        }
		        );
        }
    }

    function deviceAndSupplyInitLevel3(opts, obj) {
        obj.hover(
			    function() {
			        $(this).addClass("level3-hover");
			    },
			    function() {
			        $(this).removeClass("level3-hover");
			    }
		    );
        var level3Title = $("span.level3-title", obj);
        setTimeout(function() {
            if (opts.isDevice) {
                level3Title.each(function(i, n) {
                    var ths = $(this);
                    var object = $.tryUnescape($.trim(ths.closest("span.level3").attr("obj").replace(/&quot;/g, "\"")));
                    $.deviceAndSupply.updateTitle(opts, object, 2, ths);
                    ths = null;
                    object = null;
                });
            } else {
                level3Title.each(function(i, n) {
                    var ths = $(this);
                    ths.attr("title", opts.titles[2].title + ":" + ths.text())
                    ths = null;
                });
            }
        }, 3000);
        if (opts.isAdmin) {
            if (opts.depth > 2) {
                $.deviceAndSupply.initMenu(opts, 2);
            }
            level3Title.contextmenu($.deviceAndSupply.menuOptions[2]).attr("tabindex", 0);
        }
        if (opts.depth == 3 || opts.any) {
            level3Title.click(function() { $.deviceAndSupply.select(opts, $(this)); }).hover(
			        function() {
			            $(this).addClass("any-hover");
			        },
			        function() {
			            $(this).removeClass("any-hover");
			        }
		        );
        }
    }

    function deviceAndSupplyInitLevel4(opts, obj) {
        obj.hover(
			    function() {
			        $(this).addClass("any-hover");
			    },
			    function() {
			        $(this).removeClass("any-hover");
			    }
		    ).click(function() { $.deviceAndSupply.select(opts, $(this)); });
        setTimeout(function() {
            obj.each(function(i, n) {
                var ths = $(this);
                var object = $.tryUnescape($.trim(ths.closest("span.level4").attr("obj").replace(/&quot;/g, "\"")));
                $.deviceAndSupply.updateTitle(opts, object, 3, ths);
                ths = null;
                object = null;
            })
        }, 5000);
        if (opts.isAdmin) {
            if (opts.depth > 3) {
                $.deviceAndSupply.initMenu(opts, 3);
            }
            obj.contextmenu($.deviceAndSupply.menuOptions[3]).attr("tabindex", 0);
        }
    }

    function deviceAndSupplyInitMenu(opts, level) {     
        if ($.deviceAndSupply.menuOptions[level != undefined]) {       
            return;
        }
        var index = level % 4;      
        $.deviceAndSupply.menuOptions[level] = { alias: "alias_level" + level + opts.id, items: [{ text: "新增" + opts.titles[index].title, icon: "../images/icon/add.png", alias: "1-1", action: function(element) { $.deviceAndSupply.add(element, opts, index); } }] }
        if (opts.isDevice && level < 3) {
            $.deviceAndSupply.menuOptions[level].items.push({ text: "修改" + opts.titles[index].title, icon: "../images/icon/building_edit.png", alias: "1-2", action: function(element) { $.deviceAndSupply.edit(element, opts, index); } });
            $.deviceAndSupply.menuOptions[level].items.push({ text: "删除" + opts.titles[index].title, icon: "../images/icon/delete.gif", alias: "1-3", action: function(element) { $.deviceAndSupply.del(element, opts, index); } });
            if (opts.depth > index + 1 && ((opts.isSupply && level < 3) || opts.isDevice && level < 2)) {
                $.deviceAndSupply.menuOptions[level].items.push({ type: "splitLine" });
                $.deviceAndSupply.menuOptions[level].items.push({ text: "新增" + opts.titles[index + 1].title, icon: "../images/icon/add.png", alias: "1-4", action: function(element) { $.deviceAndSupply.add(element, opts, index + 1); } });
            }
        }
        $.deviceAndSupply.menuOptions[level].items.push({ type: "splitLine" });
        $.deviceAndSupply.menuOptions[level].items.push({ text: "刷新", icon: "../images/Common/refresh.gif", alias: "1-5", action: function(element) {}});
         
    }



    function deviceAndLoadCollection(opts, guid, level, context) {
        if (context.find("span.level" + level).length == 0) {
            $.deviceAndSupply.loadData(opts, guid, level, context);
        }
    }

    function deviceAndSupplyLoadData(opts, guid, level, context) {
        var data = "type=list&guid=" + escape(guid) + "&level=" + level + "&identity=" + opts.identity + "&depth=" + opts.depth;
        $.deviceAndSupply.ajax(data, function(ajaxContent) {
            var content = $(ajaxContent.Html);
            switch (level) {
                case 1:
                    opts.isAdmin = ajaxContent.UserState;
                    if (opts.isAdmin) { // 如果是管理员
                        $.deviceAndSupply.initMenu(opts, 4);
                        opts.oPopup.contextmenu($.deviceAndSupply.menuOptions[4]).attr("tabindex", 0);                       
                        if ($.cookie(opts.viewClass) == undefined) {
                            $("#admin_" + opts.id, opts.oPopup).remove();
                            opts.oPopup.tip({ id: "admin_" + opts.id, caption: "您拥有管理[" + opts.title + "]参数的权限,点击鼠标<span style=\"color:blue;\">右键</span>可以进操作.", fix: true, close: function() {
                                $.cookie(opts.viewClass, true, { expires: 30, path: "/" })
                            }
                            });
                        }
                    }
                    var level1s = $("span.level1", content).appendTo(opts.oContent);
                    $.deviceAndSupply.initLevel1(opts, level1s);
                    level1s = null;
                    break;
                case 2:
                    var level2s = $("span.level2", content).appendTo($("span.level1-content", context));
                    $.deviceAndSupply.initLevel2(opts, level2s);
                    if (opts.depth > 2) {
                        var level3s = $("span.level3", level2s);
                        $.deviceAndSupply.initLevel3(opts, level3s);
                        if (opts.isSupply == true && opts.depth > 3) {
                            var level4s = $("span.level4", level3s);
                            $.deviceAndSupply.initLevel4(opts, level4s);
                            level4s = null;
                        }
                        level3s = null;
                    }
                    level2s = null;
                    break;               
            }
        }, null, function() {
            opts.oPopup.removeClass("isloading");
            $.tip.hide("isloading_" + opts.id);
        });
    }

    function deviceAndSupplySelect(opts, obj) {
        //        if (opts.input) {
        //            opts.oSourceElement.val($.trim(obj.text()));
        //        } else {
        //            $.deviceAndSupply.setSelectItem(opts, obj);
        //        }
        $.deviceAndSupply.setSelectItem(opts, obj);
        $.deviceAndSupply.collapse();
        if (opts.input) {
            opts.oSourceElement.endFocus();
        }
    }

    function deviceAndSupplySetSelectedItem(opts, obj) {
        var buff = [];
        var buffTitle = [];
        var attrObj;
        if (opts.depth > 3 && obj.hasClass("level4")) {
            buff.push($.trim(obj.closest("span.level1").find("span:first").text()));
            buffTitle.push(opts.titles[0].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            buff.push($.trim(obj.closest("span.level2").find("span:first").text()));
            buffTitle.push("\n");
            buffTitle.push(opts.titles[1].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            buff.push($.trim(obj.closest("span.level3").find("span:first").text()));
            buffTitle.push("\n");
            buffTitle.push(opts.titles[2].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            buff.push($.trim(obj.text()));
            attrObj = $.tryUnescape(obj.attr("obj").replace(/&quot;/g, "\""));
            buffTitle.push("\n");
            buffTitle.push(opts.titles[3].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            if (attrObj != undefined) {
                buffTitle.push("\n规格：");
                buffTitle.push(attrObj.SubName);
                buffTitle.push("\n备注：");
                buffTitle.push(attrObj.Remark);
            }
        } else if (opts.depth > 2 && obj.hasClass("level3-title")) {
            buff.push($.trim(obj.closest("span.level1").find("span:first").text()));
            buffTitle.push(opts.titles[0].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            buff.push($.trim(obj.closest("span.level2").find("span:first").text()));
            buffTitle.push("\n");
            buffTitle.push(opts.titles[1].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            buff.push($.trim(obj.text()));
            attrObj = $.tryUnescape(obj.closest("span.level3").attr("obj").replace(/&quot;/g, "\""));
            buffTitle.push("\n");
            buffTitle.push(opts.titles[2].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            if (opts.isDevice && attrObj) {
                buffTitle.push("\n规格：");
                buffTitle.push(attrObj.SubName);
                buffTitle.push("\n备注：");
                buffTitle.push(attrObj.SubName);
            }
        } else if (opts.depth > 1 && obj.hasClass("level2-title")) {
            buff.push($.trim(obj.closest("span.level1").find("span:first").text()));
            buffTitle.push(opts.titles[0].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            buff.push($.trim(obj.text()));
            buffTitle.push("\n");
            buffTitle.push(opts.titles[1].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            attrObj = $.tryUnescape(obj.closest("span.level2").attr("obj").replace(/&quot;/g, "\""));
        } else if (obj.hasClass("level1-title")) {
            buff.push($.trim(obj.text()));
            buffTitle.push(opts.titles[0].title);
            buffTitle.push("：");
            buffTitle.push(buff[buff.length - 1]);
            attrObj = $.tryUnescape(obj.closest("span.level1").attr("obj").replace(/&quot;/g, "\""));
        }
        if (buff.length > 0 && attrObj != undefined) {
            attrObj.FullName = $.trim(buff.join(" "));
            if (opts.oCaption != undefined && opts.oCaption.length) {
                opts.oCaption.text(attrObj.FullName);
                opts.oButton.attr("title", buffTitle.join(""));
            }
            else if (opts.oInput != undefined && opts.oInput.length) {
                opts.oInput.val(attrObj.Displayname);
                opts.oInput.attr("title", buffTitle.join(""));
                opts.oInput.css("fontWeight", "bold");
            }
            opts.oSourceElement.val($.jsonToString(attrObj));

        }
        attrObj = null;
        buff.length = 0;
        buff = null;
        buffTitle.length = 0;
        buffTitle = null;
    }

    function deviceAndSupplySetText(buff, objDeviceOrSupply, opts) {
        var titleBuff = [];
        $.each(buff, function(iTitle, nTitle) {
            if (opts.titles.length > iTitle) {
                titleBuff.push(opts.titles[iTitle].title);
                titleBuff.push("：");
                titleBuff.push(nTitle);
                titleBuff.push("\n");
            }
        });
        if ((objDeviceOrSupply.Level == 3
                && opts.isDevice)
                || (objDeviceOrSupply.Level == 4
                && opts.isSupply)) {
            titleBuff.push("规格：");
            titleBuff.push(objDeviceOrSupply.SubName);
            titleBuff.push("\n备注：");
            titleBuff.push(objDeviceOrSupply.Remark);
        }

        if (opts.oCaption != undefined && opts.oCaption.length) {
            opts.oCaption.text($.trim(buff.join(" ")));
            opts.oButton.attr("title", titleBuff.join(""));
        }
        else if (opts.oInput != undefined && opts.oInput.length) {
            opts.oInput.val(objDeviceOrSupply.Displayname);
            opts.oInput.attr("title", titleBuff.join(""));
            opts.oInput.css("fontWeight", "bold");
        }

        objDeviceOrSupply = null;
        buff.length = 0;
        buff = null;
        titleBuff.length = 0;
        titleBuff = null;
    }

    function deviceAndSupplySingle(opts) {
        var val = $.trim(opts.oSourceElement.val());
        if (val.length > 0) {
            var guidOrObject = $.tryUnescape(val);
            if (guidOrObject == undefined) {
                if (opts.oInput != undefined && opts.oInput.length) {
                    opts.oInput.val(val);
                }
                else {
                    $.deviceAndSupply.ajax("type=single&guid=" + escape(opts.oSourceElement.val()), function(ajaxContent) {
                        if (ajaxContent.Html != "") {
                        
                            var objDeviceOrSupply = $.tryUnescape(ajaxContent.Html);
                            if (objDeviceOrSupply != undefined && objDeviceOrSupply.FullName != undefined) {
                                opts.oSourceElement.val(ajaxContent.Html);
                                var buff = objDeviceOrSupply.FullName.split("￥");
                                $.deviceAndSupply.setText(buff, objDeviceOrSupply, opts);
                            } else {
                                $.deviceAndSupply.empty(opts);
                            }
                        } else {
                            $.deviceAndSupply.empty(opts);
                        }
                    }, function() {
                        $.deviceAndSupply.empty(opts);
                    });
                }
            } else if (guidOrObject.FullName != undefined) {
                var buff = guidOrObject.FullName.split(" ");
                $.deviceAndSupply.setText(buff, guidOrObject, opts);
            } else {
                $.deviceAndSupply.empty(opts);
            }
        } else {
            $.deviceAndSupply.empty(opts);
        }
        return false;
    }

    function deviceAndSupplyToggler(event, opts) {
        // $.tip.close("delete_" + opts.id); // 清除之前的错误提示
        if (opts.oPopup.hasClass("device-dropdown-expended")) {
            opts.oPopup.removeClass("device-dropdown-expended").hide();
            opts.oButton.removeClass("device-dropdown-expended");
        } else {
            $.deviceAndSupply.collapse();
            opts.oPopup.addClass("device-dropdown-expended").show();
            opts.oButton.addClass("device-dropdown-expended");
            var isLoading = opts.oPopup.hasClass("isloading");
            if (!isLoading && opts.oPopup.find("span.level1").length == 0) {
                opts.oPopup.addClass("isloading");
                $.deviceAndSupply.loadData(opts, opts.guid, 1);
            } else if (isLoading) {
                opts.oPopup.tip({ id: "isloading_" + opts.id, caption: "系统已经在加载数据，请稍等...", fix: true });
            }
            $.deviceAndSupply.autoLayout(opts);
            //            if (!opts.input) {
            //                opts.oSearchInput.endFocus();
            //            }
        }
        event.stopPropagation(opts);
    }

    function deviceAndSupplyUpdateTitle(opts, obj, level, el) {
        var buff = [];
        buff.push(opts.titles[level].title);
        buff.push("：");
        buff.push(obj.Displayname);
        if ((opts.isDevice && level == 2)
                || (opts.isSupply && level == 3)) {
            buff.push("\n规格：");
            buff.push(obj.SubName);
            if (obj.Flag === 1 && opts.isSupply) {
                buff.push("\n此设备为耗材");
            }
            buff.push("\n备注：");
            buff.push(obj.Remark);
        }
        el.attr("title", buff.join(""));
        obj = null;
        buff.length = 0;
        buff = null;
    }
})(jQuery);