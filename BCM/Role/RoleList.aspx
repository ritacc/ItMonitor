<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="GDK.BCM.Role.RoleList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'RoleEdit.aspx';
                $.popup({ title: "添加角色", url: strVar, borderStyle: { height: 300, width: 400 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'RoleEdit.aspx?opType=alert&id=' + obj.attr("Guid");
                    $.popup({ title: "修改角色", url: m_url, borderStyle: { height: 300, width: 400 }, ok: function () {
                        $.popup.Refrsh();
                    }
                    }); //$.popup
                });
            });

            var editArr = $(".deleteTS");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    return confirm("删除此角色，可能导致某些用户无法登录，你确定要删除吗？");
                });
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>角色列表</td>
        <td width="60"><a class="headerBtnAdd" id="aBtnAdd" runat="server"><img src="../images/Common/add_btn.gif" /></a></td>
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
            <asp:TemplateField HeaderText="权限设置" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href="RoleSet.aspx?guid=<%# Server.UrlEncode(Eval("GUID").ToString().Trim()) %>">
                        <img src="../images/Common/roseSetRight.gif" style="border: 0px;" alt="权限设置" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("Guid") %>" class="gvEdit"><img src="../images/Common/edit.gif" style="border: 0px;" alt="权限设置" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("GUID") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="名称" DataField="ROLE_NAME">
                <ItemStyle Width="230" />
            </asp:BoundField>
            <asp:BoundField HeaderText="描述" DataField="ROLE_DESC" />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                    <th>
                        序号
                    </th>
                    <th>
                        名称
                    </th>
                    <th>
                        描述
                    </th>
                </tr>
                <tr>
                    <td colspan="3">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
    <uc2:pagenavigate ID="pagenavigate1" runat="server" />
    </div>
</asp:Content>
