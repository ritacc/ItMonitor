<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Net.aspx.cs" Inherits="GDK.BCM.PerfMonitor.Net" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/gridview.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        function resizeFrame() {
            var content_iframe = window.parent.document.getElementById("iframTrapepage"); //获取iframeID
            var div_height = 0;
            div_height = document.getElementById("child").offsetHeight + 50;
            content_iframe.height = div_height;
        }
    </script>
    <style type="text/css">
        a
        {
            text-decoration: none;
            font-size: 12px;
            color: Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="overflow_grid">
        <asp:GridView ID="gridnet" AutoGenerateColumns="False" runat="server" class="gridview_skin">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemStyle BackColor="#bdeaff" Width="25" />
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <a href="NetDetail.aspx?id=<%#Eval("DeviceID") %>" target="_blank"><span class="sercers">
                            <%#Eval("DeviceName")%></span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="类型" DataField="TypeName" />
                <asp:BoundField HeaderText="分类" DataField="ServName" />
                <asp:BoundField HeaderText="性能" DataField="performance" />
                <asp:BoundField HeaderText="IP" DataField="IP" />
                <asp:BoundField HeaderText="描述" DataField="descInfo" />
            </Columns>
        </asp:GridView>
        <uc2:pagenavigate ID="gvpg" runat="server" PageSize="15" />
    </div>
    </form>
</body>
</html>
