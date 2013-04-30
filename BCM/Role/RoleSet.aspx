<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="RoleSet.aspx.cs" Inherits="GDK.BCM.Role.RoseSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/permission .css" rel="Stylesheet" />
<link href="../styles/right.css" rel="Stylesheet" />
<style type="text/css">
#tbChild
{
    border-collapse:collapse;
}

</style>
    <script type="text/javascript">
    <!--
        $(document).ready(function () {

            $(".permissions0").find("input").click(function () {
                var p = $(this);

                var check = false;
                if (p.attr("checked")) check = true;
                p.parents(".div0").find("input").attr("checked", check);
            });

            $(".permissions1").find("input").click(function () {
                var p = $(this);
                var checked = false;
                if( p.attr('checked')) checked=true;
                var childLeftItem = p.parents("tr:first").find("input").attr('checked', checked);
                var top = p.parents(".div0:first").find("input:first");
                if (checked && !top.attr('checked')) {
                    top.attr('checked', true);
                } else if (!checked && p.parents("table:first").find("input:checked").length == 0) {
                    top.attr('checked', false);
                }
            });

            $(".permissions2").find("input").click(function () {
                var p = $(this);
                var checked = p.attr('checked');
                if (checked) {
                    p.parents("tr:first").find("input:first").attr('checked', checked);
                    p.parents(".div0:first").find("input:first").attr('checked', checked);
                }
            });

            /*隐藏显示元素*/
            $(".cssHref").click(function () {
                var p = $(this).parent().next();
                var par = $(this).children();
                if (p.attr('class') == "tb") {
                    par.attr("src", "../images/Common/add.gif");
                    p.attr("class", "tbNoShow");
                }
                else {
                    par.attr("src", "../images/Common/add-.gif")
                    p.attr("class", "tb");
                }
            })
        });
    -->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>权限设置信息</td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
        <div class="iframe_top">角色名称：<asp:Label ID="lblName" runat="server" ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
            描述：<asp:Label ID="lblDesc" runat="server"></asp:Label>
        </div>

    <div class="DivRole">
        <asp:Repeater ID="rptMenu0" runat="server">
            <ItemTemplate>
                <div class="div0">
                    <div style="margin-top: 10px;" title='<%# Eval("MOD_NAME") %>'>
                        <a  class="cssHref">
                            <img src="../images/Common/add-.gif" alt="" border="0" /></a>
                        <asp:CheckBox ID="cb0" CssClass="permissions0" runat="server" Checked='<%# Eval("IsChecked") %>'
                            Text='<%# Eval("MOD_NAME")%>' />
                        <asp:Label runat="server" ID="lb0" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                        <hr />
                    </div>
                    <table cellpadding="0" cellspacing="0" id="tbChild" class="tb" width="100%">
                        <asp:Repeater ID="rptMenu1" DataSource='<%# GetMenuList(Eval("MOD_URL")) %>' runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="lefttd">
                                        <asp:CheckBox ID="cb1" CssClass="permissions1" runat="server" Checked='<%# Eval("IsChecked") %>'
                                            Text='<%# Eval("MOD_NAME")%>' ToolTip='<%# Eval("MOD_DESC") %>' />
                                        <asp:Label runat="server" ID="lb1" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                                    </td>
                                    <td class="secondtd">
                                        <asp:Repeater ID="rptMenu2" runat="server" DataSource='<%# GetMenuList(Eval("MOD_URL")) %>'>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="cb2" CssClass="permissions2" Checked='<%# Eval("IsChecked") %>'
                                                    Text='<%# Eval("MOD_NAME")%>' ToolTip='<%# Eval("MOD_DESC") %>' />
                                                <asp:Label runat="server" ID="lb2" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptMenut" runat="server">
          <ItemTemplate>
                <div class="div0">
                    <div style="margin-top: 10px;" title='<%# Eval("MOD_NAME") %>'>
                        <a  class="cssHref">
                            <img src="../images/Common/add-.gif" alt="" border="0" /></a>
                        <asp:CheckBox ID="cbt0" CssClass="permissions0" runat="server" Checked='<%# Eval("IsChecked") %>'
                            Text='<%# Eval("MOD_NAME")%>' />
                        <asp:Label runat="server" ID="lbt0" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                        <hr />
                    </div>
                    <table cellpadding="0" cellspacing="0" id="tbChild" class="tb" width="100%">
                        <asp:Repeater ID="rptMenut1" DataSource='<%# GetMenuList(Eval("MOD_URL")) %>' runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="lefttd">
                                        <asp:CheckBox ID="cbt1" CssClass="permissions1" runat="server" Checked='<%# Eval("IsChecked") %>'
                                            Text='<%# Eval("MOD_NAME")%>' ToolTip='<%# Eval("MOD_DESC") %>' />
                                        <asp:Label runat="server" ID="lbt1" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                                    </td>
                                    <td class="secondtd">
                                        <asp:Repeater ID="rptMenut2" runat="server" DataSource='<%# GetMenuList(Eval("MOD_URL")) %>'>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="cbt2" CssClass="permissions2" Checked='<%# Eval("IsChecked") %>'
                                                    Text='<%# Eval("MOD_NAME")%>' ToolTip='<%# Eval("MOD_DESC") %>' />
                                                <asp:Label runat="server" ID="lbt2" Visible="false" Text='<%# Eval("TASK_URL") %>' />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <div class="divbotton">
            <asp:Button ID="btn_Save" OnClick="btn_Save_Click" runat="server" Text="保存" CssClass="btn_bg" />
        </div>
    </div>
</asp:Content>
