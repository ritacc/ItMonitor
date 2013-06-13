<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="PerfMonitorIndex.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfMonitorIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body { overflow:hidden; }
        .Ulcss
        {
            list-style-type: none;
            margin: 0px;
            padding: 0px;
            height: 29px;
            line-height: 29px;
        }
        .Ulcss li
        {
            background-image: url('../images/unselected80.gif');
            background-repeat: repeat;
            float: left;
            width: 80px;
            text-align: center;
            cursor: pointer;
        }
        .Ulcss a
        {
            text-decoration: none;
            color: Black;
            display: block;
        }
        #frmMain
        {
            padding:0px;
            margin:0px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function SetReLoadSelectItem() {
            var divName = $("#<%= txtSelectItem.ClientID %>").val();
            if (divName) {
                $(".Ulcss").find("li").each(function (i, o) {
                    var obj = $(o);
                    obj.css("background-image", "");
                    if (obj.attr("divName") == divName) {
                        obj.css("background-image", "url(../images/selected80.gif)");
                    }
                });
                $(this).css("background-image", "url(../images/selected80.gif)");
            }
        }

        var timer = null;
        var lastClickObj = null;
        $(document).ready(function () {
            //刷新更新加载项
            SetReLoadSelectItem();

            $("li").click(function () {
                $("#frmMain").attr("src", $(this).attr("divName"))
                $(this).siblings().css("background-image", "");
                $(this).css("background-image", "url(../images/selected80.gif)");
                $("#<%= txtSelectItem.ClientID %>").val($(this).attr("divName"));
            }); //end li click
            autoSize();
            function autoSize() {
                var divFrm = $("#divFrm");
                var frmMain = $("#frmMain");
                if (!timer) {
                    window.clearTimeout(timer);
                }
                timer = window.setTimeout(
                function () {
                    var layout = $.getLayout();
                    var height = layout.innerHeight - 208;
                    frmMain.height(height);
                    divFrm.height(height);
                }, 100);
            }

            $(window).resize(autoSize);

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: none;">
        <asp:TextBox ID="txtSelectItem" runat="server"></asp:TextBox>
    </div>
    <ul class="Ulcss">
        <li id="net" divname="PerfNet.aspx" style="background-image: url(../images/selected80.gif);">
            <a>网络</a></li>
        <li id="sy" divname="PerfVirtualMachine.aspx"><a>虚拟机</a></li>
        <li id="tx" divname="PerfHost.aspx"><a>主机</a></li>
        <li id="xn" divname="PerfDB.aspx"><a>数据库</a></li>
        <li id="others" divname="PerfDomain.aspx"><a>DOMAIN</a></li>
        <li id="showSounds" divname="PerfMiddleware.aspx">中间件性能</li>
        <li id="ljwd" divname="PerfSystemFailure.aspx"><a>系统故障</a></li>
        <li id="gzms" divname="PerfApplication.aspx"><a>应用系统</a></li>
    </ul>
    <div  id="divFrm" style="vertical-align: top; border: 1px solid #CCCCCC;">
        <iframe id="frmMain" frameborder="0" style="overflow:auto;overflow-x:hidden;" height="100%" width="100%" src="PerfNet.aspx"></iframe>
    </div>
</asp:Content>
