<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfApplicationDeatil.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfApplicationDeatil" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc1" %>
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
                                <td>主机名称:</td>
                                <td>
                               <asp:Label ID="lblHostName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    操作系统:
                                </td>
                                <td>
                                    <asp:Label ID="lblOperatingSystem" runat="server"></asp:Label>
                                </td>
                            </tr>  
                            <tr class="RowStyle">
                                <td>IP地址:</td>
                                <td>
                               <asp:Label ID="lblIP" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>描述:</td>
                                <td>
                               <asp:Label ID="lblDescribe" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    告警状态:
                                </td>
                                <td>
                                    <asp:Label ID="lblWarningStatus" runat="server"></asp:Label>
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
                            <tr class="AlternatingRowStyle">
                                <td>响应时间:</td>
                                <td>
                                   <asp:Label ID="lblResponseTime" runat="server"></asp:Label>
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

    <div class="div_box Padding_5" style="height:270px;">
        <div class="div_box_title">CPU、内存利用率</div>
        <div class="div_char">
            <div class="div_title">CPU使用率</div>
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="300px" height="200px">
            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
            <param name="initParams" value="Target=MeterHalf,DeviceID=<%= deviceID %>,ChanncelNo=25201" />
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
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="300px" height="200px">
            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
            <param name="initParams" value="Target=MeterHalf,DeviceID=<%= deviceID %>,ChanncelNo=25202" />
            <param name="minRuntimeVersion" value="4.0.50826.0" />
            <param name="autoUpgrade" value="true" />
            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
            </a>
        </object>
        <iframe id="Iframe1" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
        </div>
        <div class="div_char">
         <div class="div_title">硬盘使用率</div>
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="300px" height="200px">
            <param name="source" value="../ClientBin/ITMonitorControl.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <!--MeterMember MeterAll MeterHalf MeterTemperature-->
            <param name="initParams" value="Target=MeterHalf,DeviceID=<%= deviceID %>,ChanncelNo=25203" />
            <param name="minRuntimeVersion" value="4.0.50826.0" />
            <param name="autoUpgrade" value="true" />
            <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
            </a>
        </object>
        <iframe id="Iframe2" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>
        </div>
    </div>

    <div class="div_box Padding_5">
        <div class="div_box_title">CPU及内存使用率</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chLine" runat="server" Width="890" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="Y轴-交换内存使用率、物理内存使用率、CPU使用率" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Near" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="交换内存使用率" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                </Series>
                <Series>
                    <asp:Series Name="Series2" LegendText="物理内存使用率" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                </Series>
                <Series>
                    <asp:Series Name="Series3" LegendText="CPU使用率" ChartType="Line" IsValueShownAsLabel="True"
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


    <div class="div_box Padding_5">
        <div class="div_box_title">CPU及内存使用率 - 最近六小时内列表</div>
        <table cellpadding="0" cellspacing="0" class="gridview_skin">
            <tr class="gridview_skin_header">
                <th width="40%">内存利用情况</th>
                <th>%</th>
                <th>MB</th>
                <th>CPU利用情况</th>
                <th>%</th>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>交换内存利用率</td>
                <td><asp:Label ID="lblSwapMemoryUtilization" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblSwapMemoryUtilizationMB" runat="server"></asp:Label></td>
                <td>CPU使用率</td>
                <td><asp:Label ID="lblCPUMemoryUtilization" runat="server"></asp:Label></td>
            </tr>
            <tr class="RowStyle">
                <td>物理内存利用率</td>
                <td><asp:Label ID="lblPhysicalpMemoryUtilization" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblPhysicalpMemoryUtilizationMB" runat="server"></asp:Label></td>
                <td colspan="2"></td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>空间物理内存（MB）</td>
                <td><asp:Label ID="lblFreePhysicalpMemory" runat="server"></asp:Label></td>
                <td colspan="3"></td>
            </tr>
        </table>
    </div>
    
    <div class="div_box Padding_5">
        <div class="div_box_title">系统负荷 - 最近一小时</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chSystemLoad" runat="server" Width="890" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="Y轴-每分钟的Job数、5分钟的Job数、15分钟的Job数" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Near" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="每分钟的Job数" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                </Series>
                <Series>
                    <asp:Series Name="Series2" LegendText="5分钟的Job数" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                </Series>
                <Series>
                    <asp:Series Name="Series3" LegendText="15分钟的Job数" ChartType="Line" IsValueShownAsLabel="True"
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

      <div class="div_box Padding_5">
        <div class="div_box_title">系统负荷 - 最近一小时列表</div>
        <asp:GridView ID="gvSystemLoad" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="每分钟的Job数" DataField="OneJob" />
                <asp:BoundField HeaderText="5分钟的Job数" DataField="FiveJob" />
                <asp:BoundField HeaderText="15分钟的Job数" DataField="FifteenJob" />
                <asp:BoundField HeaderText="每分钟的Job数峰值" DataField="OneJobPeak" />
                <asp:BoundField HeaderText="5分钟的Job数峰值" DataField="FiveJobPeak" />
                <asp:BoundField HeaderText="15分钟的Job数峰值" DataField="FifteenJobPeak" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>每分钟的Job数</th>
                        <th>5分钟的Job数</th>
                        <th>15分钟的Job数</th>
                        <th>每分钟的Job数峰值</th>
                        <th>5分钟的Job数峰值</th>
                        <th>15分钟的Job数峰值</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="6">没有数据</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>              
        <uc1:pagenavigate ID="pg" runat="server" />   
     </div>

      <div class="div_box Padding_5">
        <div class="div_box_title">进程明细</div>
        <asp:GridView ID="gvProcessDetail" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="进程" DataField="Process" />
                <asp:BoundField HeaderText="健康状况" DataField="HealthStatus" />
                <asp:BoundField HeaderText="当前可用状态" DataField="CurrentlyState" />
                <asp:BoundField HeaderText="实例编号" DataField="ExampleNO" />
                <asp:BoundField HeaderText="内存（%）" DataField="Memory" />
                <asp:BoundField HeaderText="CPU（%）" DataField="CPU" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>进程</th>
                        <th>健康状况</th>
                        <th>当前可用状态</th>
                        <th>实例编号</th>
                        <th>内存（%）</th>
                        <th>CPU（%）</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="6">没有数据</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>              
        <uc1:pagenavigate ID="pgProcessDetail" runat="server" />   
     </div>

      <div class="div_box Padding_5">
        <div class="div_box_title">磁盘使用率</div>
        <asp:GridView ID="gvDiskUtilization" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="磁盘名称" DataField="DiskName" />
                <asp:TemplateField HeaderText="磁盘使用率">
                    <ItemTemplate>
                        <div style="height:12px; border:1px solid #3da0ce; background:white;">
                            <span style="display:block; width:<%# Eval("DiskUsage") %>px; height:10px; background:url(../images/ProgressBarBg.gif);border:1px solid #FFFFFF;"></span>
                         </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="已用（%）" DataField="Used" />
                <asp:BoundField HeaderText="已用（MB）" DataField="UsedMB" />
                <asp:BoundField HeaderText="空闲（%）" DataField="Free" />
                <asp:BoundField HeaderText="空闲（MB）" DataField="FreeMB" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>磁盘名称</th>
                        <th>磁盘使用率</th>
                        <th>已用（%）</th>
                        <th>已用（MB）</th>
                        <th>空闲（%）</th>
                        <th>空闲（MB）</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="6">没有数据</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>              
        <uc1:pagenavigate ID="pgDiskUtilization" runat="server" />   
     </div>

      <div class="div_box Padding_5">
        <div class="div_box_title">页面空间</div>
        <asp:GridView ID="gvPageSpace" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="页面空间" DataField="PageSpace" />
                <asp:BoundField HeaderText="大小" DataField="PageSpaceSize" />
                <asp:BoundField HeaderText="已用（%）" DataField="Used" />
                <asp:BoundField HeaderText="已用（MB）" DataField="UsedMB" />
                <asp:BoundField HeaderText="空闲（%）" DataField="Free" />
                <asp:BoundField HeaderText="空闲（MB）" DataField="FreeMB" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>每分钟的Job数</th>
                        <th>5分钟的Job数</th>
                        <th>15分钟的Job数</th>
                        <th>每分钟的Job数峰值</th>
                        <th>5分钟的Job数峰值</th>
                        <th>15分钟的Job数峰值</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="6">没有数据</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>              
        <uc1:pagenavigate ID="pgPageSpace" runat="server" />   
     </div>

      <div class="div_box Padding_5">
        <div class="div_box_title">磁盘IO统计列表</div>
        <asp:GridView ID="gvDiskStatistics" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="设备" DataField="Equipment" />
                <asp:BoundField HeaderText="读/秒" DataField="ReadS" />
                <asp:BoundField HeaderText="写/秒" DataField="WriteS" />
                <asp:BoundField HeaderText="传输/秒" DataField="TransportS" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>设备</th>
                        <th>读/秒</th>
                        <th>写/秒</th>
                        <th>传输/秒</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="4">没有数据</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>              
        <uc1:pagenavigate ID="pgDiskStatistics" runat="server" />   
     </div>        
    </form>
</body>
</html>
