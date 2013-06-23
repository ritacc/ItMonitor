<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfNetPortDetail.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfNetPortDetail" %>

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
    <div class="div_box">
    <div class="div_box_title">接收明细 流量明细 使用率图 今天的可用性</div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                    <div class="div_box Padding_5">
                    <div class="div_box_title">接口明细</div>
                        <table class="gridview_skin">
                            <tr class="gridview_skin_header">
                                <th>属性名称</th>
                                <th>属性值</th>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td><a href="PerfNetAlarmDetail.aspx?id=<%= deviceID %>"><img src='../images/Common/stata<%= perf %>.gif' alt="性能" title="<%= Performance %>" /></a></td>
                                <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    接口:
                                </td>
                                <td>
                                    <asp:Label ID="lblPort" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>描述:</td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>IP地址:</td>
                                <td>
                                   <asp:Label ID="lblIpAddresses" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>电路ID:</td>
                                <td>
                                   <asp:Label ID="lblCircuitID" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>上级名:</td>
                                <td>
                                   <asp:Label ID="lblSuperiorName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>索引:</td>
                                <td>
                                   <asp:Label ID="lblIndex" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>物理地址:</td>
                                <td>
                                   <asp:Label ID="lblPhysicalAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>类型:</td>
                                <td>
                               <asp:Label ID="lblType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>管理状态:</td>
                                <td>
                                   <asp:Label ID="lblManagementState" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>操作状态:</td>
                                <td>
                               <asp:Label ID="lblOperatingStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="gridview_skin">
                            <tr class="gridview_skin_header">
                                <th>流量明细</th>
                                <th>接收</th>
                                <th>发送</th>
                            </tr>
                            <tr class="RowStyle">
                                <td>流量宽带</td>
                                <td><asp:Label ID="lblReceiveBroadband" runat="server"></asp:Label></td>
                                <td><asp:Label ID="lblSendBroadband" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="RowStyle">
                                <td>当前流量</td>
                                <td><asp:Label ID="lblCurrentlyReceivingTraffic" runat="server"></asp:Label></td>
                                <td><asp:Label ID="lblCurrentSendTraffic" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="RowStyle">
                                <td>使用率</td>
                                <td><asp:Label ID="lblReceiveUtilization" runat="server"></asp:Label> </td>
                                <td><asp:Label ID="lblSendUtilization" runat="server"></asp:Label> </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>每秒包数量</td>
                                <td><asp:Label ID="lblReceivePacketsNumber" runat="server"></asp:Label> </td>
                                <td><asp:Label ID="lblSendPacketsNumber" runat="server"></asp:Label> </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>数据包平均尺寸</td>
                                <td><asp:Label ID="lblReceiveAverageSize" runat="server"></asp:Label> </td>
                                <td><asp:Label ID="lblSendAverageSize" runat="server"></asp:Label> </td>
                            </tr>
                        </table>
                      </div>
                </td>
                <td valign="top" width="500">
                    
                    <div class="div_box Padding_5" style=" text-align:center;">
                    <div class="div_box_title">使用率图</div>
                       <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                            width="200px" height="200px">
                            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                            <param name="onError" value="onSilverlightError" />
                            <param name="background" value="white" />
                            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                            <param name="initParams" value="Target=MeterMember,DeviceID=<%= deviceID %>,ChanncelNo=35003" />
                            <param name="minRuntimeVersion" value="4.0.50826.0" />
                            <param name="autoUpgrade" value="true" />
                            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                            </a>
                        </object>
                        <iframe id="Iframe1" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
                        
                       <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                            width="200px" height="200px">
                            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                            <param name="onError" value="onSilverlightError" />
                            <param name="background" value="white" />
                            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                            <param name="initParams" value="Target=MeterMember,DeviceID=<%= deviceID %>,ChanncelNo=35004" />
                            <param name="minRuntimeVersion" value="4.0.50826.0" />
                            <param name="autoUpgrade" value="true" />
                            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                            </a>
                        </object>
                        <iframe id="Iframe2" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
                    </div>

                    <div class="div_box Padding_5" style=" text-align:center;">
                    <div class="div_box_title">今天的可用性</div>
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
                </td>
            </tr>
        </table>
    </div>    
    <div class="div_box">
    <div class="div_box_title">流量-今天</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chLine" runat="server" Width="890" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="流量（每秒比特数）-今天" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Near" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="接收" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                    <asp:Series Name="Series2" LegendText="发送" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                        BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="64, 0, 0, 0" BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False" />
                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="0" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64" Interval="2" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>

    <div class="div_box">
    <div class="div_box_title">错误数和丢包数—今天</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
        <asp:Chart ID="chtErrorSum" runat="server" Width="890" Height="496" BackColor="#f0fbff">
            <Titles>
                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                    Text="错误数和丢包数—今天" Name="Title1" ForeColor="26, 59, 105">
                </asp:Title>
            </Titles>
            <Legends>
                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                    Alignment="Near" LegendStyle="Column">
                </asp:Legend>
            </Legends>
            <Series>
                <asp:Series Name="Series1" LegendText="流入错误数" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                </asp:Series>
                <asp:Series Name="Series2" LegendText="流出错误数" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                </asp:Series>
                <asp:Series Name="Series3" LegendText="流入丢包数" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                </asp:Series>
                <asp:Series Name="Series4" LegendText="流出丢包数" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                        BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="64, 0, 0, 0" BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False" />
                        <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="0" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64" Interval="2" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
        </asp:Chart>
        </div>
    </div>

    <div class="div_box">
    <div class="div_box_title">发送字数总量—今天</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
        <asp:Chart ID="chtSendSum" runat="server" Width="890" Height="496" BackColor="#f0fbff">
            <Titles>
                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                    Text="发送字数总量（字节）—今天" Name="Title1" ForeColor="26, 59, 105">
                </asp:Title>
            </Titles>
            <Legends>
                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                    Alignment="Near" LegendStyle="Column">
                </asp:Legend>
            </Legends>
            <Series>
                <asp:Series Name="Series1" LegendText="InBytes" IsValueShownAsLabel="True" LabelFormat="{0}分"
                    BorderColor="180, 26, 59, 105"  BorderWidth="2">
                </asp:Series>
                <asp:Series Name="Series2" LegendText="OutBytes" IsValueShownAsLabel="True" LabelFormat="{0}分"
                    BorderColor="180, 26, 59, 105"  BorderWidth="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                    BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="64, 0, 0, 0" BackGradientStyle="TopBottom">
                    <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                        WallWidth="0" IsClustered="False" />
                    <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="0" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64" Interval="2" LabelAutoFitMaxFontSize="8">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        </div>
    </div>

    </form>
</body>
</html>
