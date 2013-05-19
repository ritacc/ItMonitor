<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfNetDetail.aspx.cs"
    Inherits="GDK.BCM.PerfMonitor.NetDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/MonitorDetail.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="gridview_skin">
            <tr class="gridview_skin_header">
                <th colspan="2">监控器信息</th>
            </tr>
            <tr class="AlternatingRowStyle">
                <td colspan="2"><asp:Label ID="lblDeviceName" runat="server"></asp:Label></td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>
                    IP:
                </td>
                <td>
                    <asp:Label ID="lblIP" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>厂商:</td>
                <td>
                    <asp:Label ID="lblFirm" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>分类:</td>
                <td>
                   <asp:Label ID="lblClass" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>类型:</td>
                <td>
                   <asp:Label ID="lblType" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>流量计算器:</td>
                <td>
                   <asp:Label ID="lblFlowCalculator" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>依赖性:</td>
                <td>
                   <asp:Label ID="lblDependence" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>轮询协议:</td>
                <td>
                   <asp:Label ID="lblPollingProtocol" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>监控:</td>
                <td>
                   无此字段
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>系统描述:</td>
                <td>
                   <asp:Label ID="lblSystemDescription" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="div_box" style=" height:270px;">
            <div class="div_box_title">今天的使用率 响应时间 丢包率</div>

            <div class="div_char">
                <div class="div_title">今天的使用率</div>
                <asp:Chart ID="chtPerf" Width="300" Height="200" runat="server"
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
            <div class="div_char">
                <div class="div_title">响应时间</div>
                <div class="div_text"><asp:Label ID="lblResponseTime" runat="server"></asp:Label> ms</div>
            </div>
            <div class="div_char">
                <div class="div_title">今天的丢包率</div>
                <div class="div_text"><asp:Label ID="lblPacketLossRate" runat="server"></asp:Label> % 无此字段</div>
            </div>
       
                
        </div>
        <div class="div_box" style=" height:270px;">
            <div class="div_box_title">CPU、内存和背板的使用率</div>
            <div class="div_char">
                <div class="div_title"> CPU使用率</div>
                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                    width="300px" height="200px">
                    <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                    <param name="onError" value="onSilverlightError" />
                    <param name="background" value="white" />
                    <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                    <param name="initParams" value="Target=MeterAll,DeviceID=<%= deviceID %>,ChanncelNo=8" />
                    <param name="minRuntimeVersion" value="4.0.50826.0" />
                    <param name="autoUpgrade" value="true" />
                    <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                        <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                    </a>
                </object>
                <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
            </div>
            <div class="div_char">
                <div class="div_title">内存使用率</div>
                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                    width="300px" height="200px">
                    <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                    <param name="onError" value="onSilverlightError" />
                    <param name="background" value="white" />
                    <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                    <param name="initParams" value="Target=MeterAll,DeviceID=<%= deviceID %>,ChanncelNo=9" />
                    <param name="minRuntimeVersion" value="4.0.50826.0" />
                    <param name="autoUpgrade" value="true" />
                    <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                        <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                    </a>
                </object>
                <iframe id="Iframe1" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
            </div>
            <div class="div_char">
                <div class="div_title">背板利用率</div>
                无此字段
            </div>
        </div>

        <div style=" clear:both;">
         <asp:GridView ID="gvPortList" AutoGenerateColumns="False" runat="server" class="gridview_skin">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle BackColor="#bdeaff" Width="25" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="性能">
                        <ItemTemplate>
                            <img src='../images/Common/stata<%# Eval("performance") %>.gif' alt="设备状态" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称">
                        <ItemTemplate>
                            <a href="PerfNetPortDetail.aspx?id=<%#Eval("DeviceID") %>"><span class="sercers">
                                <%#Eval("DeviceName")%></span></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="描述" DataField="descInfo" />
                    <asp:BoundField HeaderText="接收流量" DataField="resave" />
                    <asp:BoundField HeaderText="发送流量" DataField="fsm" />
                    <asp:BoundField HeaderText="错误数" DataField="cwsm" />
                </Columns>
            </asp:GridView>
        </div>

    </div>
    </form>
</body>
</html>
