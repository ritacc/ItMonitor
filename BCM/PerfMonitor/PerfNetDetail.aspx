<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfNetDetail.aspx.cs"
    Inherits="GDK.BCM.PerfMonitor.NetDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    IP:
                </td>
                <td>
                    <asp:Label ID="lblIP" runat="server"></asp:Label>
                </td>
                <td>厂商</td>
                <td>
                    <asp:Label ID="lblFirm" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

        <div>
         <asp:GridView ID="gvPortList" AutoGenerateColumns="False" runat="server" class="gridview_skin">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle BackColor="#bdeaff" Width="25" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称">
                        <ItemTemplate>
                            <a href="PerfNetDetail.aspx?id=<%#Eval("DeviceID") %>"><span class="sercers">
                                <%#Eval("DeviceName")%></span></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="类型" DataField="TypeName" />
                    <asp:BoundField HeaderText="分类" DataField="ServName" />
                    <asp:TemplateField HeaderText="性能">
                        <ItemTemplate>
                            <img src='../images/Common/stata<%# Eval("performance") %>.gif' alt="设备状态" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="IP" DataField="IP" />
                    <asp:BoundField HeaderText="描述" DataField="descInfo" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
