<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="GDK.BCM.Map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>通过Map生成系统模块和权限</title>
    <style type="text/css">
        a
        {
        	display:block;
        	background-image:url(images/build.png);
        	background-repeat:no-repeat;
        	width:171px;
        	height:91px;
        	margin:auto;
        }
        span
        {
        	display:block;
        	background-image:url(images/loading.gif);
        	background-repeat:no-repeat;
        	background-position:center top;
        	width:100px;
        	height:60px;
        	margin:auto;
        	padding-top:44px;
        	display:none;
        }
    </style>
    <script type="text/javascript" src="Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            var span = $("span");
            var a = $("a");
            a.click(function() {
                a.hide();
                span.show();
                $.ajax({
                    url: "Map.aspx",
                    data: "type=build",
                    success: function(ajaxContext) {
                        var errorArray = [];
                        errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
                        if (ajaxContext != undefined
                            && ajaxContext.IsSuccess != undefined) {
                            if (ajaxContext.IsSuccess == true) {
                                alert("恭喜，生成成功了！");
                                return;
                            } else if (ajaxContext.Source
                                && ajaxContext.Message
                                && ajaxContext.TargetSite
                                && ajaxContext.StackTrace) {
                                errorArray.push(ajaxContext.Message);
                                errorArray.push("\r\n\t对象名称：\t")
                                errorArray.push(ajaxContext.Source);
                                errorArray.push("\r\n\t异常方法：\t");
                                errorArray.push(ajaxContext.SoTargetSiterce);
                                if (ajaxContext.InnerException) {
                                    errorArray.push("\r\n\t内联异常");
                                    errorArray.push(ajaxContext.InnerException);
                                }
                                errorArray.push("\r\n\t详细信息：\r\n")
                                errorArray.push(ajaxContext.StackTrace);
                            } else {
                                errorArray.push("服务器内部发生了错误，但是服务器未能给出异常信息.");
                                errorArray.push("\r\n\t代码文件：\t~/Map.js");
                                errorArray.push("\r\n\t出 错 行：\t53 行");
                            }
                        } else {
                                errorArray.push("ajax 请求成功，但是参数[ajaxContext]为null.");
                                errorArray.push("\r\n\t代码文件：\t~/script/Map.aspx");
                                errorArray.push("\r\n\t出 错 行：\t62 行");
                        }
                        errorArray.push("\r\n\r\n请与系统管理员联系.\r\n\r\nCopyright © [深圳海关技术处]");
                        alert(errorArray.join(""));
                    },
                    dataType: "json",
                    cache: false,
                    error: function(XMLHttpRequest, textStatus, errorThrown) {
                        if (typeof error == "function") {
                            error();
                        } else {
                            var errorArray = [];
                            errorArray.push("出错了!\r\n\r\n\t错误信息：\t");
                            errorArray.push(textStatus);
                            errorArray.push("\r\n\t代码文件：\t~/Map.aspx");
                            errorArray.push("\r\n\t出 错 行：\t78 行");
                            errorArray.push("\r\n\r\n请与系统管理员联系.\r\n\r\nCopyright © [深圳海关技术处]");
                            alert(errorArray.join(""));
                        }
                    },
                    complete: function() {
                        a.show();
                        span.hide();
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding-top:200px;">
        <a >生成</a>
        <span>请稍后...</span>
    </div>
    </form>
</body>
</html>
