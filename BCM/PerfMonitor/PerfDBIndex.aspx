<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="PerfDBIndex.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/MonitorDetail.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>

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

        	if (top.location != self.location)
        		top.location = self.location;

        	$("#imgRef").click(function () {
        		var murl = window.frmMain.location.href;
        		var index = murl.indexOf('&r');
        		if (index > 0) {
        			murl = murl.substring(0, index);
        			if (murl.indexOf("?") > 0)
        				murl = murl + "&r=" + Math.random();
        			else
        				murl = murl + "?r=" + Math.random();
        		}
        		else {
        			if (murl.indexOf("?") > 0)
        				murl = murl + "&r=" + Math.random();
        			else
        				murl = murl + "?r=" + Math.random();
        		}
        		window.frmMain.location.href = murl;
        	});

        	$("#imgReturn").click(function () {
        		history.back();
        	});

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
    <div style="padding: 0px; margin: 0px; line-height: 29px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%; padding: 0px; margin: 0px;
            line-height: 29px; height: 29px;">
            <tr>
                <td style="height: 29px;">
                    <ul class="Ulcss">
                        <li id="net" divname="PerfDBOverview.aspx?id=<% =deviceID %>" style="background-image: url(../images/selected80.gif);">
                            <a>概览</a></li>
                        <li id="sy" divname="PerfDBTableSpace.aspx?id=<% =deviceID %>"><a>表空间</a></li>
                        <li id="tx" divname="PerfDBConversation.aspx?id=<% =deviceID %>"><a>会话</a></li>
                        <li id="xn" divname="PerfDBBack.aspx?id=<% =deviceID %>"><a>回退</a></li>
                        <li id="others" divname="PerfDBSGA.aspx?id=<% =deviceID %>"><a>SGA</a></li>
                        <li id="showSounds" divname="PerfDBSelect.aspx?id=<% =deviceID %>">查询</li>
                        <li id="ljwd" divname="PerfDBLock.aspx?id=<% =deviceID %>"><a>锁</a></li>
                    </ul>
                </td>
				<td style="width: 24px;" >
                    <image id="imgReturn" style="cursor:pointer;" alt="返回" src="../images/Common/cancel.gif" />
                </td>
                <td style="width: 24px;" style="cursor:pointer;">
                    <image id="imgRef" alt="刷新" style="cursor:pointer;"  src="../images/Common/refresh.gif" />
                </td>
            </tr>
        </table>
    </div>
    <div  id="divFrm" style="vertical-align: top; border: 1px solid #CCCCCC;">
        <iframe id="frmMain"  name="frmMain" frameborder="0" style="overflow-y:auto;overflow-x:hidden;" height="100%" width="100%" src="PerfDBOverview.aspx?id=<% =deviceID %>"></iframe>
    </div>

</asp:Content>
