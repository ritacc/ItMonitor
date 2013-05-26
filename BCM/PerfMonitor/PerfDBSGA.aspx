<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBSGA.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBSGA" %>

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
    <div class="div_box Padding_5">
    <div class="div_box_title">SGA的指标</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chLine" runat="server" Width="890" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="x轴-缓冲区击中率,数据字典击中率,缓冲库击中率" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Near" LegendStyle="Column">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="缓冲区击中率" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                    <asp:Series Name="Series2" LegendText="数据字典击中率" ChartType="Line" IsValueShownAsLabel="True"
                        LabelFormat="{0}" BorderColor="180, 26, 59, 105" BorderWidth="2">
                    </asp:Series>
                    <asp:Series Name="Series3" LegendText="缓冲库击中率" ChartType="Line" IsValueShownAsLabel="True"
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
        <div class="div_box_title">SGA明细</div>
            <table class="gridview_skin">
                <tr class="AlternatingRowStyle">
                    <td width="40%">
                        缓冲区大小:
                    </td>
                    <td>
                        <asp:Label ID="lblBufferSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>共享池大小:</td>
                    <td>
                        <asp:Label ID="lblShareSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>重做日志缓冲器大小:</td>
                    <td>
                        <asp:Label ID="lblLogBufferSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>库缓存大小:</td>
                    <td>
                        <asp:Label ID="lblDatabaseSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>数据字典缓存大小:</td>
                    <td>
                        <asp:Label ID="lblDictionarySize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>SQL区大小:</td>
                    <td>
                        <asp:Label ID="lblSqlSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>固有区大小:</td>
                    <td>
                        <asp:Label ID="lblInherentSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>JAVA池大小:</td>
                    <td>
                    <asp:Label ID="lblJavaSize" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>Large池大小:</td>
                    <td>
                        <asp:Label ID="lblLargeSize" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <div class="div_box Padding_5">
        <div class="div_box_title">SGA状态</div>
            <table class="gridview_skin">
                <tr class="AlternatingRowStyle">
                    <td width="40%">
                        缓冲区击中率:
                    </td>
                    <td>
                        <asp:Label ID="lblBufferHitRate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>数据字典击中率:</td>
                    <td>
                        <asp:Label ID="lblDictionaryHitRate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>缓存库击中率:</td>
                    <td>
                        <asp:Label ID="lblDatabaseHitRate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>可用内存:</td>
                    <td>
                        <asp:Label ID="lblAvailableMemory" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
