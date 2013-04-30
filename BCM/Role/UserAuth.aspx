<%@ Page Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserAuth.aspx.cs" Inherits="Role_UserAuth"  %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript">
$(document).ready(function(){
    var authArr=$(".imgUserAuth");
    authArr.each(function(i,o){
        var obj=$(o);
        obj.click(function(){
            var m_url="UserAuthRose.aspx?userid="+obj.attr("userid");
            $.funkyUI({url:m_url,title: "用户授权",
			    showButtonRow: false,css:{width:"400",height:"300"}
		    });
        });//click
    });//each
});
</script>
    <div id="page_Top">
        <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td id="page_Top_Left">
                    &nbsp;
                </td>
                <td id="page_Top_Middle">
                    <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <div id="nav1">
                                    <span class="STYLE3">你当前的位置</span>：[<asp:SiteMapPath ID="SiteMapPath1" runat="server"
                                        PathSeparator="]-[">
                                    </asp:SiteMapPath>
                                    ]</div>
                            </td>
                            <td style="text-align: right">
                                &nbsp;<asp:TextBox CssClass="hidden tbxFrequency"  Text="15" runat="server" ID="tbxFrequency"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td id="page_Top_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="page_Middle">
        <table style="width: 100%;" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td id="page_Middle_Left">
                    &nbsp;
                </td>
                <td id="page_Middle_Middle">
                    <div id="page">
                        <div id="pageBody">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="序号">
                                        <ItemStyle Width="40px" />
                                        <ItemTemplate>
                                            <div style="text-align: center">
                                                <%# Container.DataItemIndex+1 %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="授权" HeaderStyle-Width="40px">
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
                            <uc2:pagenavigate ID="pagenavigate1" PageSize="20" runat="server" />
                        </div>
                    </div>
                </td>
                <td id="page_Middle_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
