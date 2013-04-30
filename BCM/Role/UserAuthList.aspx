<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="UserAuthList.aspx.cs" Inherits="GDK.BCM.Role.UserAuthList" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var authArr = $(".imgUserAuth");
            authArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = "UserAuthEdit.aspx?userid=" + obj.attr("userid");
                    $.popup({ url: m_url, title: "用户授权", borderStyle: { width: "600", height: "500" }, ok: function () { $.popup.Refrsh(); } });
                }); //click
            }); //each
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>用户授权列表</td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
    <div class="divgrid">
    <div class="overflow_grid">
    <asp:GridView ID="gvDataList" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="授权" HeaderStyle-Width="60">
                <ItemTemplate>
                    <img src="../images/Common/roseSetRight.gif" style="border: 0px;" alt="授权" class="imgUserAuth"
                        userid="<%# Server.UrlEncode(Eval("GUID").ToString().Trim()) %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="姓名" DataField="USER_NAME" />
            <asp:BoundField HeaderText="登录名" DataField="LOGON_NAME" />
            <asp:BoundField HeaderText="部门" DataField="deptNmae" />
            <asp:BoundField HeaderText="行政级别" DataField="joblevel" />
            <asp:BoundField HeaderText="角色" DataField="roseNameList" />
        </Columns>
    </asp:GridView>
    </div>
    <uc2:pagenavigate ID="pagenavigate1" PageSize="20" runat="server" />
    </div>
</asp:Content>
