<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="StateMonitorIndex.aspx.cs" Inherits="GDK.BCM.StateMonitor.StateMonitorIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <style type="text/css">
        .spanLadDate
        {
            padding: 4px 6px;
        }
        .NoShow
        {
            display: none;
        }
        
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
        .cssShowOrHide
        {
            border-top: 2px solid #399EE7;
            padding: 3px;
            overflow: hidden;
        }
        .ControlTable td
        {
            border: 0px solid #399EE7;
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

            $("#imgSelectWd").click(function () {
                var strVar = "../SysAdmin/SelectYHHH.aspx";
                $.popup({ title: "选择网点", url: strVar, borderStyle: { height: 400, width: 600 }, ok: function (va) {
                    $("#dpdWdbh").val(va);
                }
                }); //$.popup
            });

        $("li").click(function () {
            $("#frmMain").attr("src", $(this).attr("divName"))
                $(this).siblings().css("background-image", "");
                $(this).css("background-image", "url(../images/selected80.gif)");
                $("#<%= txtSelectItem.ClientID %>").val($(this).attr("divName"));
            });

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
        <li id="sy" divname="divSounds"><a>网络状态</a></li>
        <li id="tx" divname="divtx"><a>主机状态</a></li>
        <li id="xn" divname="divCall"><a>应用状态</a></li>
        <li id="others" divname="divOther"><a>机房环境状态</a></li>
        <li id="showSounds" divname="divshowSounds">虚拟主机</li>
    </ul>
    <div>
        <iframe id="frmMain" src="StateList.aspx"></iframe>
    </div>
</asp:Content>
