<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfVirtualMachineDetail.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfVirtualMachineDetail" %>

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
    <script type="text/javascript" src="../Scripts/MonitorList.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_box Padding_5">
    <div class="div_box_title">监视器信息</div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                    <div class="Padding_5">
                    <div class="div_box_title">监视器信息</div> 
                        <table class="gridview_skin">
                            <tr class="AlternatingRowStyle">
                                <td width="40%">监视器名称：</td>
                                <td><asp:Label ID="lblMonitorName" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="RowStyle">
                                <td>描述:</td>
                                <td>
                               <asp:Label ID="lblDescribe" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    健康状况:
                                </td>
                                <td>
                                    <asp:Label ID="lblHealthStatus" runat="server"></asp:Label>
                                </td>
                            </tr>  
                            <tr class="RowStyle">
                                <td>最后轮询时间:</td>
                                <td>
                               <asp:Label ID="lblLastPollingTime" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>下次轮询时间:</td>
                                <td>
                                   <asp:Label ID="lblNextPollingTime" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>当前可用状态:</td>
                                <td>
                                    <img src='../images/Common/stata<%= perf %>.gif' />
                                    <asp:Label ID="lblPerformance" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                      </div>
                </td>
                <td valign="top" width="500">                    
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
                        <br /><br />
                    当前可用状态：<img src='../images/Common/stata<%= perf %>.gif' /> <asp:Label ID="lblPerf" runat="server"></asp:Label>
                        <br /><br />
                    </div>
                </td>
            </tr>
        </table>  
    </div>

    <div class="div_box Padding_5">
        <div class="div_box_title">CPU、内存利用率</div>
        <div class="div_char" style="width:48%;">
            <div class="div_title">CPU使用率</div>
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="300px" height="200px">
            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
            <param name="initParams" value="Target=MeterHalf,DeviceID=<%= deviceID %>,ChanncelNo=91103" />
            <param name="minRuntimeVersion" value="4.0.50826.0" />
            <param name="autoUpgrade" value="true" />
            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
            </a>
        </object>
        <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
        </div>
        <div class="div_char" style="width:48%;">
         <div class="div_title">内存使用率</div>
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="300px" height="200px">
            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
            <param name="initParams" value="Target=MeterHalf,DeviceID=<%= deviceID %>,ChanncelNo=91204" />
            <param name="minRuntimeVersion" value="4.0.50826.0" />
            <param name="autoUpgrade" value="true" />
            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
            </a>
        </object>
        <iframe id="Iframe1" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
        </div>
        <table cellpadding="0" cellspacing="0" class="gridview_skin">
            <tr class="gridview_skin_header">
                <th width="40%">属性</th>
                <th>值</th>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>CPU利用率：</td>
                <td><asp:Label ID="lblCPUUtilizationRatio" runat="server"></asp:Label></td>
            </tr>
            <tr class="RowStyle">
                <td>CPU利用情况:</td>
                <td>
                <asp:Label ID="lblCPUUtilization" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>内存利用率：</td>
                <td><asp:Label ID="lblMemoryUtilization" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
        
    <div class="div_box Padding_5">
        <div class="div_box_title">磁盘、网络使用情况图表</div>
        <asp:Chart ID="chLine" runat="server" Width="890" Height="496" BackColor="#f0fbff">
            <Titles>
                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                    Text="x轴-网络使用率、磁盘使用率" Name="Title1" ForeColor="26, 59, 105">
                </asp:Title>
            </Titles>
            <Legends>
                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                    Alignment="Near" LegendStyle="Column">
                </asp:Legend>
            </Legends>
            <Series>
                <asp:Series Name="Series1" LegendText="网络使用率" ChartType="Line" IsValueShownAsLabel="True"
                    LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                </asp:Series>
            </Series>
            <Series>
                <asp:Series Name="Series2" LegendText="磁盘使用率" ChartType="Line" IsValueShownAsLabel="True"
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

    </form>
</body>
</html>
