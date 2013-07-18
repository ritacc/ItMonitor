<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfSystemFailureList.aspx.cs" Inherits="GDK.BCM.AlertAdmin.PerfSystemFailureList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var layout = $.getLayout();
            var overflow_grid = $(".overflow_grid");
            var height = layout.innerHeight - 248;
            overflow_grid.height(height);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <div class="divgrid">
        <table class="gridheader_table" cellpadding="0" cellspacing="0">
            <tr>
                <td width="6">
                    <img src="../images/gridview/gridheader_03.gif" alt="" />
                </td>
                <td>
                    系统故障列表
                </td>
                <td width="6">
                    <img src="../images/gridview/gridheader_06.gif" alt="" />
                </td>
            </tr>
        </table>
        <div class="overflow_grid">
            <asp:GridView ID="gvDataList" AutoGenerateColumns="False" runat="server" class="gridview_skin">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle BackColor="#bdeaff" Width="25" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="来源">
                        <ItemTemplate>
                            <a href="PerfSystemFailureDetail.aspx?id=<%#Eval("AlarmLogID") %>"><span class="sercers">
                                <%#Eval("DeviceName")%></span></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="警报信息" DataField="Content" />
                    <asp:BoundField HeaderText="发生时间" DataField="HappenTime" />
                    <asp:BoundField HeaderText="联系人" DataField="DISPLAY_NAME" />
                </Columns>
                <EmptyDataTemplate>
                    <table class="empty_gridview" cellspacing="0">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>来源</th>
                            <th>警报信息</th>
                            <th>发生时间</th>
                            <th>联系人</th>
                        </tr>
                        <tr>
                            <td colspan="5">
                                没有数据
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        
    </div>
    <uc2:pagenavigate ID="pg" runat="server" />
    </form>
</body>
</html>
