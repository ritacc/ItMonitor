<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagenavigate.ascx.cs" Inherits="GDK.BCM.UI.pagenavigate" %>
<script type="text/javascript">
<!--
    $(document).ready(function () {
        var pageIndex = Number($("#<%= lab_PageIndex.ClientID %>").text());
        var pageCount = Number($("#<%= lab_PageCount.ClientID %>").text());
        var img_first = $("#<%= img_first.ClientID %>").click(function () {
            if (pageIndex == 0) {
                alert("当前没有任何记录！");
                return false;
            } else if (pageIndex == 1) {
                alert("已经是第一页了！");
                return false;
            }
            return true;
        });
        $("#<%= img_prev.ClientID %>").click(function () {
            if (pageIndex == 0) {
                alert("当前没有任何记录！");
                return false;
            } else if (pageIndex == 1) {
                alert("已经是第一页了");
                return false;
            } else if (pageIndex < 0) {
                alert("页码不能为负数！");
                return false;
            }
            return true;
        });
        $("#<%= img_next.ClientID %>").click(function () {
            if (pageIndex == 0) {
                alert("当前没有任何记录！");
                return false;
            } if (pageIndex == pageCount) {
                alert("已经是最后一页了");
                return false;
            } else if (pageIndex > pageCount) {
                alert("页数超出范围！");
                return false;
            }
            return true;
        });
        var img_last = $("#<%= img_last.ClientID %>").click(function () {
            if (pageIndex == 0) {
                alert("当前没有任何记录！");
                return false;
            } else if (pageIndex == pageCount) {
                alert("已经是最后一页了！");
                return false;
            }
            return true;
        });

        $("#<%= img_gopage.ClientID %>").click(function () {
            var txt_gopage = $("#<%= txt_gopage.ClientID %>");
            var gopage = Number(txt_gopage.val());
            if (isNaN(gopage)) {
                alert("请输入正确的页数！");
                return false;
            } else if (gopage < 1) {
                txt_gopage.val(1);
                alert("请输入正确的页数！");
                return false;
            }
            if (gopage > pageCount) {
                txt_gopage.val(pageCount);
                alert("请输入正确的页数！");
                return false;
            }
            if (pageIndex == gopage) {
                alert("请输入要跳转的页数！");
                return false;
            }
            return true;
        });
    });
-->
</script>
<table width="100%" cellpadding="0" cellspacing="0" id="PN" runat="server" style=" background:url(../images/Pagenavigate/Pagenavigate_bg.gif) repeat-x; height:28px; line-height:28px; margin-top:2px;">
    <tr>
        <td style=" background:url(../images/Pagenavigate/Pagenavigate_left.gif) no-repeat; width:6px; height:28px;">
          <%--<img src="../images/Pagenavigate/Pagenavigate_left.gif" alt="" />--%>
        </td>
        <td>
            共有<asp:Label ID="lab_RecordCount" runat="server" ForeColor="#557CF2">0</asp:Label>
            条记录，当前第<asp:Label ID="lab_PageIndex" runat="server" ForeColor="#557CF2" Text="0"></asp:Label>
            /<asp:Label ID="lab_PageCount" runat="server" ForeColor="#557CF2" Text="0"></asp:Label>
            页，每页
            <asp:DropDownList ID="ddlPageSize" runat="server" Width="50">
                <asp:ListItem Selected="True">10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem >20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
            条
        </td>
        <td>
            <asp:ImageButton ID="img_first" runat="server" ImageUrl="~/Images/Pagenavigate/first.gif" CausesValidation="False" ToolTip="首页"></asp:ImageButton>
        </td>
        <td>
            <asp:ImageButton ID="img_prev" runat="server" ImageUrl="~/Images/Pagenavigate/previous.gif" CausesValidation="False" ToolTip="上一页"></asp:ImageButton>
        </td>
        <td>
            <asp:ImageButton ID="img_next" runat="server" ImageUrl="~/Images/Pagenavigate/next.gif" CausesValidation="False" ToolTip="下一页"></asp:ImageButton>
        </td>
        <td>
            <asp:ImageButton ID="img_last" runat="server" ImageUrl="~/Images/Pagenavigate/last.gif" CausesValidation="False" ToolTip="尾页"></asp:ImageButton>
        </td>
        <td style="text-align: right; padding-right:10px;">
            转到
            <asp:TextBox ID="txt_gopage" runat="server" Width="21px" Height="16px" BorderWidth="1" Font-Size="12px"
                ForeColor="#557CF2" BorderColor="#888888" Style="text-align: center" Text="1"></asp:TextBox>
            页
        </td>
        <td width="31">
            <asp:ImageButton ID="img_gopage" runat="server" ImageUrl="~/Images/Pagenavigate/go.gif" CausesValidation="False" ToolTip="转到" style=" vertical-align:middle"></asp:ImageButton>
        </td>
        <td style=" background:url(../images/Pagenavigate/Pagenavigate_right.gif) no-repeat; width:6px; height:28px;">
        </td>
    </tr>
</table>