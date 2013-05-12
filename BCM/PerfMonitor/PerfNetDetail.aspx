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
        可用性：
        <br />
                <asp:Chart ID="chtPerf" Width="350" Height="250" BackColor="#f0fbff" runat="server"
                        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                        <Legends>
                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="True "
                                Name="Default">
                                <Position Height="10" Width="95" X="2" Y="92" />
                            </asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold"
                                CustomProperties="DoughnutRadius=25,  PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                                MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                                Label="#PERCENT{P1}" BorderWidth="2">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                                BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                <AxisY2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY2>
                                <AxisX2>
                                    <MajorGrid Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX2>
                                <Area3DStyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25"
                                    IsClustered="False" />
                                <AxisY LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisY>
                                <AxisX LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    <MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
                                    <MajorTickMark Enabled="False" />
                                </AxisX>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
        </div>
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
