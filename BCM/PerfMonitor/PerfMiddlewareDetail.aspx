<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfMiddlewareDetail.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfMiddlewareDetail" %>
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
                                <td width="40%">名称</td>
                                <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="RowStyle">
                                <td>告警状态</td>
                                <td>
                                    <img id="imgHealth" src='../images/Common/health<%= health %>.gif' alt="告警状态" class="imgPerf" />
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    类型
                                </td>
                                <td>
                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                </td>
                            </tr>  
                            <tr class="RowStyle">
                                <td>Weblogic版本</td>
                                <td>
                               <asp:Label ID="lblWeblogic" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    监听端口
                                </td>
                                <td>
                                    <asp:Label ID="lblPort" runat="server"></asp:Label>
                                </td>
                            </tr>  
                            <tr class="RowStyle">
                                <td>主机名称</td>
                                <td>
                               <asp:Label ID="lblHostName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    操作系统
                                </td>
                                <td>
                                    <asp:Label ID="lblSystem" runat="server"></asp:Label>
                                </td>
                            </tr>  
                            <tr class="RowStyle">
                                <td>最后轮询时间</td>
                                <td>
                               <asp:Label ID="lblLastPollingTime" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>下次轮询时间</td>
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
                                    Name="Default"  Docking="Bottom" Alignment="Center">
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
                            当前可用状态：<img id="imgStatusSub" alt="状态" src='../images/Common/stata<%= State %>.gif' /> 
                            <asp:Label ID="lblState" runat="server"></asp:Label>
                        <br /><br />
                    </div>
                </td>
            </tr>
        </table>  
    </div>

        
    <div class="div_box Padding_5">
        <div class="div_box_title">Web应用 -最近1小时最高用户会话（前5位）</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chLine" runat="server" Width="890" Height="496px" BackColor="#FAFAFA">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="x轴-请求数" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series Name="Series1" IsValueShownAsLabel="True" LabelFormat="{0}" BorderColor="180, 26, 59, 105">
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
                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
    </div>
     </div>

    
    <div class="div_box Padding_5">
        <div class="div_box_title">Web应用的会话明细</div>
        <asp:GridView ID="gvConversationDetail" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="Web应用名" DataField="DeviceName" />
                <asp:BoundField HeaderText="活动会话数" DataField="ActivityNO" />
                <asp:BoundField HeaderText="最大会话数" DataField="MaxNO" />
                <asp:BoundField HeaderText="总计会话数" DataField="TotalNO" />
                <asp:BoundField HeaderText="Servlet数" DataField="ServletNO" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>Web应用名</th>
                        <th>活动会话数</th>
                        <th>最大会话数</th>
                        <th>总计会话数</th>
                        <th>Servlet数</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="5">没有数据</td>
                    </tr>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pg" runat="server" />   
    </div>
        
    <div class="div_box Padding_5">
        <div class="div_box_title">线程明细</div>
        <asp:GridView ID="gvThreadDetail" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="线程名称" DataField="DeviceName" />
                <asp:BoundField HeaderText="总线程数" DataField="ThreadNO" />
                <asp:BoundField HeaderText="空闲线程" DataField="FreeThreadNO" />
                <asp:BoundField HeaderText="吞吐量" DataField="Throughput" />
                <asp:BoundField HeaderText="未决的请求数目" DataField="UndecidedNO" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>线程名称</th>
                        <th>总线程数</th>
                        <th>空闲线程</th>
                        <th>吞吐量</th>
                        <th>未决的请求数目</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="5">没有数据</td>
                    </tr>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgThreadDetail" runat="server" />   
    </div> 

    <div class="div_box Padding_5">
        <div class="div_box_title">线程使用-最后1小时</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
        <asp:Chart ID="chThread" runat="server" Width="890" Height="496" BackColor="#f0fbff">
            <Titles>
                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                    Text="x轴-线程池使用情况" Name="Title1" ForeColor="26, 59, 105">
                </asp:Title>
            </Titles>
            <Series>
               <asp:Series Name="Series1" IsValueShownAsLabel="True" LabelFormat="{0}" BorderColor="180, 26, 59, 105">
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
                        <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
              </ChartAreas>
        </asp:Chart>
    </div>
     </div>
     
    <div class="div_box Padding_5">
        <div class="div_box_title">数据库连接池使用情况-最后1小时</div>
    </div> 
     
    <div class="div_box Padding_5">
        <div class="div_box_title">数据库连接池明细</div>
        <asp:GridView ID="gvConnectionPoolingDetails" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="名称" DataField="DeviceName" />
                <asp:BoundField HeaderText="连接池大小" DataField="ConnectionPoolingSize" />
                <asp:BoundField HeaderText="活动连接" DataField="ActiveConnection" />
                <asp:BoundField HeaderText="活动连接数%" DataField="ActiveConnectionNO" />
                <asp:BoundField HeaderText="遗漏的连接" DataField="MissedConnection" />
                <asp:BoundField HeaderText="线程等待" DataField="ThreadWait" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>名称</th>
                        <th>连接池大小</th>
                        <th>活动连接</th>
                        <th>活动连接数%</th>
                        <th>遗漏的连接</th>
                        <th>线程等待</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="6">没有数据</td>
                    </tr>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgConnectionPoolingDetails" runat="server" />   
    </div> 

     
    <div class="div_box Padding_5">
        <div class="div_box_title">最近1小时的服务器应答时间</div>
        <asp:GridView ID="gvServerResponseTime" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="最小应答时间(毫秒)" DataField="MinMs" />
                <asp:BoundField HeaderText="最大应答时间(毫秒)" DataField="MaxMs" />
                <asp:BoundField HeaderText="平均应答时间(毫秒)" DataField="AverageMs" />
                <asp:BoundField HeaderText="应答时间(毫秒) " DataField="ResponseTime" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>最小应答时间(毫秒)</th>
                        <th>最大应答时间(毫秒)</th>
                        <th>平均应答时间(毫秒)</th>
                        <th>应答时间(毫秒)</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="4">没有数据</td>
                    </tr>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgServerResponseTime" runat="server" />   
    </div> 

    <div class="div_box Padding_5">
        <div class="div_box_title">最近1小时的未决请求数</div>
        <asp:GridView ID="gvUndecided" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="线程名称" DataField="DeviceName" />
                <asp:BoundField HeaderText="总线程数" DataField="ThreadNO" />
                <asp:BoundField HeaderText="空闲线程" DataField="FreeThreadNO" />
                <asp:BoundField HeaderText="吞吐量" DataField="Throughput" />
                <asp:BoundField HeaderText="未决的请求数目" DataField="UndecidedNO" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>线程名称</th>
                        <th>总线程数</th>
                        <th>空闲线程</th>
                        <th>吞吐量</th>
                        <th>未决的请求数目</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="5">没有数据</td>
                    </tr>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgUndecided" runat="server" />   
    </div> 

    <div class="div_box Padding_5">
        <div class="div_box_title">线程等待</div>
        <asp:GridView ID="gvThreadWait" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="ATTRIBUTENAME" DataField="DeviceName" />
                <asp:BoundField HeaderText="ATTRIBUTEVALUE" DataField="ATTRIBUTEVALUE" />
                <asp:BoundField HeaderText="CONLLECTIONTIME" DataField="CONLLECTIONTIME" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>ATTRIBUTENAME</th>
                        <th>ATTRIBUTEVALUE</th>
                        <th>CONLLECTIONTIME</th>
                    </tr>
                    <tr class="AlternatingRowStyle">
                        <td colspan="3">没有数据</td>
                    </tr>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgThreadWait" runat="server" />   
    </div> 
    
    <div class="div_box Padding_5">
        <div class="div_box_title">最近1小时的JVM堆使用情况图表</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
        <asp:Chart ID="chJVMHeap" runat="server" Width="890" Height="496" BackColor="#f0fbff">
            <Titles>
                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                    Text="x轴-堆使用情况" Name="Title1" ForeColor="26, 59, 105">
                </asp:Title>
            </Titles>
            <Legends>
                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                     Alignment="Center" Docking="Bottom">
                </asp:Legend>
            </Legends>
            <Series>
                <asp:Series Name="Series1" LegendText="堆使用情况" ChartType="Line" IsValueShownAsLabel="True"
                    LabelFormat="{0}KB" BorderColor="180, 26, 59, 105" BorderWidth="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                    BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="64, 0, 0, 0" BackGradientStyle="TopBottom">
                    <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                        WallWidth="0" IsClustered="False" />
                    <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="{0}KB" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64" Interval="1"    LabelAutoFitMaxFontSize="8">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
     </div>
     
    <div class="div_box Padding_5">
        <div class="div_box_title">最近1小时的JVM堆使用情况</div>
        <asp:GridView ID="gvJVMHeap" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
            <Columns>
                <asp:BoundField HeaderText="最小 堆大小(kb)" DataField="MinHeap" />
                <asp:BoundField HeaderText="最大 堆大小(kb)" DataField="MaxHeap" />
                <asp:BoundField HeaderText="平均 堆大小(kb)" DataField="AverageHeap" />
                <asp:BoundField HeaderText="总计 堆大小(kb)" DataField="TotalHeap" />
                <asp:BoundField HeaderText="当前 堆大小(kb)" DataField="CurrentHeap" />
            </Columns>
            <EmptyDataTemplate>
                <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                    <tr class="gridview_skin_header">
                        <th>最小 堆大小(kb)</th>
                        <th>最大 堆大小(kb)</th>
                        <th>平均 堆大小(kb)</th>
                        <th>总计 堆大小(kb)</th>
                        <th>当前 堆大小(kb)</th>
                    </tr>
                   <%-- <tr class="AlternatingRowStyle">
                        <td colspan="5">没有数据</td>
                    </tr>--%>
                </table>                
                </EmptyDataTemplate>
            </asp:GridView>
    </div> 
        
    </form>
</body>
</html>
