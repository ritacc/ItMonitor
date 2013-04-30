<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectFileMain.aspx.cs" Inherits="GDK.BCM.UI.SelectFileMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/Common.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <style type="text/css">

        .staticCss{ background-image:url(../images/selected.gif);}
        
        .Ulcss{ list-style-type:none;margin:0px; padding:0px; height:29px; line-height:29px;}
        .Ulcss li{background-image:url(../images/unselected.gif); float:left; width:135px; text-align:center; cursor:pointer;}
        .Ulcss a{ text-decoration:none; color:Black; display:block;}
        
        /*鼠标移入时菜单项的样式*/
        .hoverCss{ background-image:url(../images/selected.gif); }
        .divpadding
        {
            overflow:hidden;
        }
        .divborder
        {
            border-top:2px solid #399EE7;
            background-color:White;
            width:600px;
            min-height:400px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("li").each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    $(".cssShowOrHide").hide();
                    $("#" + obj.attr("divName")).show();
                    $("li").css("background-image", "");
                    obj.css("background-image", "url(../images/selected.gif)");
                });
            });

            var layout = $.getLayout(window);
            var height = layout.innerHeight - 38;
            $("#ifram2").height(height);
            $("#ifram1").height(height);
            //src="SelectFileUpFile.aspx"
            //src = "SelectFileLoadFile.aspx"
            var mFolder = request("Folder");
            var str = "?Folder=" + mFolder;
            $("#ifram1").attr("src", "SelectFileUpFile.aspx" + str);
            $("#ifram2").attr("src", "SelectFileLoadFile.aspx" + str);
        })

        function SaveClase(strFileName) {
            if (strFileName == "") {
                alert("请选择文件。");
                return;
            }
        }

        
    </script>
    
</head>
<body>
     <form id="form1" runat="server">
    <div>

        <div class="divpadding">
            <ul class="Ulcss">
                <li id="cp" divName="divUpFile" style="background-image:url(../images/selected.gif);" runat="server"><a>上传文件</a></li>
                <li id="xn" divName="divSelectFile"  runat="server"><a>选择文件</a></li>
               
            </ul>
            <div class="divborder">
                <div class="divborder_padding">
                    <div id="divUpFile"   class="cssShowOrHide" runat="server"  >
                    <iframe  id="ifram1" frameborder="0" style="  width:100%;" ></iframe>
                    </div>
                    <div id="divSelectFile"   class="cssShowOrHide"   runat="server" style="display:none;">
                        <iframe  id="ifram2"    frameborder="0" style="width:100%;"  ></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
