<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="StateMonitorIndex.aspx.cs" Inherits="GDK.BCM.StateMonitor.StateMonitorIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
        <li id="net" divname="StateList.aspx" style="background-image: url(../images/selected80.gif);">
            <a>状态列表</a></li>
        <li id="sy" divname="StateNet.aspx"><a>网络状态</a></li>
        <li id="tx" divname="StateHost.aspx"><a>主机状态</a></li>
        <li id="xn" divname="StateApplication.aspx"><a>应用状态</a></li>
        <li id="others" divname="StateCompRoomEnvi.aspx"><a>机房环境状态</a></li>
        <li id="showSounds" divname="StateVirtualMachine.aspx">虚拟机</li>
    </ul>
    <div  id="divFrm" style="vertical-align: top; border: 1px solid #CCCCCC;">
        <iframe id="frmMain" frameborder="0" style="overflow:hidden;overflow-x:hidden;" height="100%" width="100%" src="StateList.aspx"></iframe>
    </div>
</asp:Content>
