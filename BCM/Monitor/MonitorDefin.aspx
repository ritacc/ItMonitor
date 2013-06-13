<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="MonitorDefin.aspx.cs" Inherits="GDK.BCM.Monitor.MonitorDefin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/Silverlight.js"></script>
    <script type="text/javascript" src="../Scripts/fullScreen.js"></script>
    
    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Silverlight 应用程序中未处理的错误 " + appSource + "\n";

            errMsg += "代码: " + iErrorCode + "    \n";
            errMsg += "类别: " + errorType + "       \n";
            errMsg += "消息: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "文件: " + args.xamlFile + "     \n";
                errMsg += "行: " + args.lineNumber + "     \n";
                errMsg += "位置: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "行: " + args.lineNumber + "     \n";
                    errMsg += "位置: " + args.charPosition + "     \n";
                }
                errMsg += "方法名称: " + args.methodName + "     \n";
            }

            alert(errMsg);
        }

        function ShowDoubleCurve() {
            var url = "DailyreportContent.aspx";
            $.popup({ title: "多测点历史曲线", url: url, borderStyle: { height: 700, width: 1110} });
        }

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

        $(document).ready(function () {
            setHostSize();
            $(window).resize(function () {
                if (!originStyle.isFullScreenMode) {
                    setHostSize();
                }
            });

            $("#my_menu").resize(function () {
                if (!originStyle.isFullScreenMode) {
                    setHostSize();
                }
            });

        });

        function setHostSize() {

            var host = $("#silverlightControlHost");
            var layout = $.getLayout(window);
            var height = layout.innerHeight - 180;

            //alert($("#my_menu").height());
            if ($("#my_menu").height() < height)
                host.height(height);
            else
                host.height($("#my_menu").height());
        }
    </script>

    <style type="text/css">
        body
        {
            padding: 0;
            margin: 0;
           
        }
        #silverlightControlHost,#objServerRoom
        {            
            width:100%;
            height:100%;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="silverlightControlHost">
        <object id="objServerRoom" data="data:application/x-silverlight-2," type="application/x-silverlight-2">
            <param name="source" value="../ClientBin/NetStatus.xap?type=admin" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <param name="minRuntimeVersion" value="4.0.50826.0" />
            <param name="autoUpgrade" value="true" />
            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight"
                    style="border-style: none" />
            </a>
        </object>
        <iframe id="_sl_historyFrame" style="visibility: hidden; border: 0px"></iframe>
    </div>
</asp:Content>

