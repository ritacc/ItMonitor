<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfApplicationUrl.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfApplicationUrl" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
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
                    <div class="div_box Padding_5">
                    <div class="div_box_title">URL序列监控器信息</div> 
                        <table class="gridview_skin">
                            <tr class="AlternatingRowStyle">
                                <td width="40%">名称：</td>
                                <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
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
                                <td>类型:</td>
                                <td>
                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                </td>
                            </tr>                           
                            <tr class="AlternatingRowStyle">
                                <td>轮询间隔:</td>
                                <td>
                                   <asp:Label ID="lblInterval" runat="server"></asp:Label>
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
                                <asp:Series Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold"  IsValueShownAsLabel="false"
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

     <div class="div_box Padding_5">
        <div class="div_box_title">性能</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chLine" runat="server" Width="950" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="最近一小时性能（应答时间/S）" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                    <asp:Title Docking="Left" Font="Trebuchet MS, 14.25pt, style=Bold" Text="Response Time/ms" TextOrientation="Rotated90">
                            </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Near" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="应答时间/S" ChartType="Line" IsValueShownAsLabel="True"
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
        <table class="gridview_skin">
            <tr class="gridview_skin_header">
                <th width="40%">属性</th>
                <th>值</th>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>
                    平均 应答时间：
                </td>
                <td>
                    <asp:Label ID="lblAverageResponseTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>当前 应答时间：</td>
                <td>
                    <asp:Label ID="lblResponseTime" runat="server"></asp:Label>
                </td>
            </tr>     
        </table>         
      </div>
            
      <div class="div_box Padding_5">
            <div class="div_box_title">URL序列</div>
            <asp:GridView ID="gvURL" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="名称" DataField="DeviceName" />
                    <asp:TemplateField HeaderText="可用性">
                        <ItemTemplate>
                            <img src='../images/Common/stata<%# Eval("Perf")%>.gif' alt="" style="vertical-align:middle;" />
                            <%# Eval("Performance")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="健康状况" DataField="HealthStatus" />
                    <asp:BoundField HeaderText="应答时间(m/s)" DataField="ResponseTime" />
                    <asp:BoundField HeaderText="页面大小(字节)" DataField="PageSize" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>名称</th>
                            <th>可用性</th>
                            <th>健康状况</th>
                            <th>应答时间(m/s)</th>
                            <th>页面大小(字节)</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="5">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pg" runat="server" />      
      </div>

      <div class="div_box Padding_5">
        <div class="div_box_title">特定URL响应时间(应答时间/ms)本视图5分钟自动最新数据</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chtURL" runat="server" Width="950" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="特定URL响应时间(应答时间/ms)本视图5分钟自动最新数据" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Near" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="应答时间/S" ChartType="Line" IsValueShownAsLabel="True"
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
    </form>
</body>
</html>
