
/*
Release:
    2011-01-25: 
        1.添加 targetElement 参数: targetElement 为目标验证控件,如A为TextBox, 但是A是隐藏的, B为A的替身, 那么设置B.yz({ targetElement:[A的ID] });就可以通过B来验证A的目的
        2.修改select 控件 列表为空时,val()方法返回值为null的bug.
*/
;(function($){
	// RequiredFieldValidator
	var oBody = $(document.body);
	
	// Validator Container
	var valContainer = [];
	var skipContainer = [];
	// 验证yz
	$.fn.yz = function(args) {
	    args = args || {};
	    args = $.extend({}, defaults, args);
	    var round = $.yz.getRound(args.type);
        
		if(!args.max) {
			args.max = round.max;
		}
		if(!args.min) {
			args.min = round.min;
		}
        //alert( args.max);
		var title = $.trim(args.title);
		if(title == "") {
			title = this.attr("title");
		}
		title = $.trim(title);
		if(title != ""){
			args.onError = "[" + title + "] " + args.onError;
			args.onOutOfRange =  "[" + title + "] " + args.onOutOfRange;
			args.onEmpty =  "[" + title + "] " + args.onEmpty;
			args.onOuOfDigits =  "[" + title + "] " + args.onOuOfDigits;
            args.onSave = "[" + title + "] " + args.onSave;
            args.onLen  = "[" + title + "] " + args.onSave;
		}
		args.onOutOfRange += "(" + args.min + "~" + args.max + ")";
        args.onLen += args.len;
		this.args = args;
		requiredFieldValidator(this);
		
		if(args.targetElement != undefined) {
		    skipContainer.push(args.targetElement);
		}
		
		valContainer[this.attr("id")] = this;
		var ptr = $(this);
		return ptr;
	}

	var defaults = {
		group: "group1",
		title : "",						// 提示信息的自段名称 其他提示信息 自动在开头累加上此属性 如 alert([title] + [onError])
		onError: "输入格式错误",		// 格式错误提示
		onOutOfRange : "输入超出范围",	// 超出范围提示
		onEmpty: "输入不能为空",		// 为空的时候的提示
		onOuOfDigits : "小数位数太长",	// 小数点位数太长的提示
        onLen: "长度必须为",  //固定长度
        onSave : "禁止录入的字符  '",	// 小数点位数太长的提示
		canEmpty: false,				// 是否允许为空
		type : "string",				// 要验证的数据类型 : string int float date(yyyy-MM-dd),datetime(yyyy-MM-dd 24h:mi)
		digits : 3,						// 小数位数只对浮点型有效
		isByte : false,					// 字符长度的计算方式 true:字节长度, false : 字符个数
		isShow : true,					// 是否显示除了错误以外的提示图标 true : 始终提示 false: 不显示
        isSave : false,                   // 是否检查为安全字符!=['"<>/]
		min : null,						// 字符串为最大长度 其他类型为最大范围
        len : null,                     //数据长度
		max : null,						// 字符串为最小长度 其他类型为最小范围
		delay : null,					// 漂浮提示显示的时间长，null : 不显示
		cssClass : null				// 格式错误后输入框的css样式,默认样式是背景色变红，字体变粗

	};
	
	function requiredFieldValidator(obj) {
		obj.blur(function(){	
			var val;
			if(obj.args.targetElement != undefined){
			    val = $.trim($("#" + obj.args.targetElement).val());
			} else {
			    val = obj.val();
			}
			var result;
			if(val == undefined || val == "") {
				if(obj.args.canEmpty == false) {
					$.yz.addStyle(obj);
				}
				else {
					$.yz.removeStyle(obj);
				}
			} else if((result = ($.yz.validData(obj.args, val))) != true){
				$.yz.addStyle(obj);
			} else {
				$.yz.removeStyle(obj);
			}			
		});

	}

	$.yz = {
		getErrorList : function (groupName) {
			groupName = groupName || "group1";
			var errorList = [];
			errorList.push("信息提示：\n");
			for(id in valContainer) {
			    if(!skipContainer.contains(id)) {
				    if(valContainer[id]
					    && valContainer[id].args
					    && groupName == valContainer[id].args.group) {
    					
					    var obj = valContainer[id];
					    var val;
					    if(obj.args.targetElement != undefined){
					        var targetElement = $("#" + obj.args.targetElement);
			                val = $.trim(targetElement.val());
			            } else {
			                val = obj.val();
			            }
			            					    
					    var result;
					    if(val == "") {
						    if(obj.args.canEmpty == false) {
							    $.yz.addStyle(obj);
							    errorList.push(obj.args.onEmpty);
						    }
						    else {
							    $.yz.removeStyle(obj);
						    }
					    } else if((result = ($.yz.validData(obj.args, val))) != true){
						    $.yz.addStyle(obj);
						    errorList.push(result);
					    } else {
						    $.yz.removeStyle(obj);
					    }
				    }
				}
			}
			if(errorList.length > 1) {
				alert(errorList.join("\n  * "));
				return false;
			}
			return true;
		},
		validData : function (args, value) {
			switch(args.type) {
				case "string" :
					var n = args.isByte ? value.replace(/[.]/g,'a').replace(/[^x00-xff]/g,"aa").length : value.length;
					if(n <= args.max && n >= args.min) {
                        if(args.isSave && new RegExp(/\'/g).test(value)) {
                            return args.onSave;
                        }
						return true;
					}
					return args.onOutOfRange + "(" + (args.isByte ? "字节个数" : "字符个数") + ")";
				case "int" :
					if($.yz.isInteger(value)) {
						var n = Number(value);
                        if(args.len)
                        {
                            if(value.length == args.len)
                            {
                                return true
                            }
                            else
                            {
                                return args.onLen;
                            }
                            if(n <= args.max && n >= args.min) {
							    return true;
						    }
                        }
                        if(n <= args.max && n >= args.min) {
							return true;
						}
						return args.onOutOfRange;
					}
					return args.onError;
				case "float" :
					if($.yz.isFloat(value)) {
						var n = Number(value);
						if(n <= args.max && n >= args.min) {
							if(value.replace(/^[0-9]+\.?/g, "").length <= args.digits) {
								return true;
							}
							return args.onOuOfDigits;
						}
						return args.onOutOfRange;
					}
					return args.onError;
				case "date":
					if($.yz.isDate(value)) {
						var now = Date.parse(value.replace(/-/g,"/"));
						var max = Date.parse(args.max.replace(/-/g,"/"));
						var min = Date.parse(args.min.replace(/-/g,"/"));
						if(max - now >= 0 && now - min >= 0) {
							return true;
						}
						return args.onOutOfRange;
					}
					return args.onError + "正确时间格式:yyyy-MM-dd (如:2010-01-29).";
				case "datetime" :
					if($.yz.isDateTime(value)) {
						try
						{
							var now = Date.parse((value+":00").replace(/-/g,"/"));
							var max = Date.parse(args.max.replace(/-/g,"/"));
							var min = Date.parse(args.min.replace(/-/g,"/"));
							if(max - now >= 0 && now - min >= 0) {
								return true;
							}
							return args.onOutOfRange;
						}
						catch(w){
							return args.onOutOfRange;
						}
					}
					return args.onError + "正确时间格式:yyyy-MM-dd hh:mi(如:2010-01-29 05:50).";
               case"ip":
                   if($.yz.isIp(value)) 
                         return true;
                   
                  return  args.onError;
			}
		},
		isInteger : function (value) {
			return new RegExp('^[0-9]+$').test(value);
		},
		isFloat : function (value) {
			return new RegExp("(^\\d+$)|(^\\d+\.\\d+$)","g").test(value);
		},
		isDate : function(value) {
			var ls_regex = "^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
			return new RegExp(ls_regex, "i").test(value);
		},
		isDateTime : function(value) {
			var arr = value.split(' ', 2);
			if(arr.length == 2 && $.yz.isDate(arr[0])) {
				var ls_regex = "^([0-1]?[0-9]|2[0-3]):([0-5][0-9])$";
				return new RegExp(ls_regex, "i").test(arr[1]);
			}
			return false;
		},
        isIp : function(value){
           var pattern = /^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$/;

            return pattern.test(value);


        },
		getRound : function (type) {
			switch(type) {
				case "string" :
					return { max:2000,min:0 };
				case "int" :
					return  { max:2147483647,min:0 };
				case "float" :
					return  { max:2147483647,min:0 };
				case "date":
					return  { max:"9999-12-31",min:"1900-01-01" };
				case "datetime" : {
					return  { max:"9999-12-31",min:"1900-01-01" };
               
                 }
                 case "ip" : {
					return  { max:"255.255.255.255",min:"0.0.0.0" };
               
                 }
                  
			}
		},
		addStyle : function(obj) {
			if(obj.args) {
				if(obj.args.cssClass) {
					obj.addClass(obj.args.cssClass);
					return;
				}
			}
			obj.css("background-color", "#FFCBCB");
			//obj.css("font-weight", "bold");
			return;
		},
		removeStyle : function(obj) {
			if(obj.args) {
				if(obj.args.cssClass) {
					obj.removeClass(obj.args.cssClass);
					return;
				}
			}
			obj.css("background-color", "");
			//obj.css("font-weight", "");
			return;
		}
	};
	
	Array.prototype.contains = function(e)  {  
        for(i=0;i<this.length;i++) {
            if(this[i] == e) {
                return true;
            }
        }
        return false;
    } 
})(jQuery);