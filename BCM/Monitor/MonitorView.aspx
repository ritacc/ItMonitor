<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="MonitorView.aspx.cs" Inherits="GDK.BCM.Monitor.MonitorView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/Silverlight.js"></script>
    <script type="text/javascript" src="../Scripts/fullScreen.js"></script>
    <script type="text/javascript" src="../Scripts/SL.js"></script>
    
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

        var timer = null;
        $(document).ready(function () {

            function autoSize() {
                //var divFrm = $("#silverlightControlHost");
                var frmMain = $("#objServerRoom");
                    if (!timer) {
                        window.clearTimeout(timer);
                    }
                     timer = window.setTimeout(function () {
                        var layout = $.getLayout();
                        var height = layout.innerHeight - 180;
                    
                        frmMain.height(height);
                        //divFrm.height(height);
                        //alert(height);
                    }, 100);
            }
            autoSize();
            $(window).resize(autoSize);

        });
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
            <param name="source" value="../ClientBin/NetStatus.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <param name="initParams" value="type=view" />
            <param name="minRuntimeVersion" value="4.0.50826.0" />
            <param name="autoUpgrade" value="true" />
            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight"
                    style="border-style: none" />
            </a>
        </object>
        <%--<iframe id="_sl_historyFrame" style="visibility: hidden; border: 0px"></iframe>--%>
    </div>
</asp:Content>

