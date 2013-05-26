<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="DBSearchDetail.aspx.cs" Inherits="GDK.BCM.CompSearch.DBSearchDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .tdTitle
        {
            font-weight: bold;
            font-size: 12px;
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
            <td width="6">
                <img src="../images/gridview/gridheader_03.gif" alt="" />
            </td>
            <td>
                客户等待时间分时段分布图
            </td>
            <td width="92">
                <a divname="divPerformance" class="divItemChange">
                    <img src="../images/Common/list.gif" alt="显示列表" title="显示列表" class="vertical_middle" /></a>
            </td>
            <td width="92">
                <a divname="divLine" class="divItemChange">
                    <img src="../images/Common/char_Line.gif" alt="显示曲线图" title="显示曲线图" class="vertical_middle" /></a>
                <input id="txtHide" class="txtHide" type="hidden" runat="server" />
            </td>  
            <td width="6">
                <img src="../images/gridview/gridheader_06.gif" alt="" />
            </td>
        </tr>
    </table>

     <div class="divgrid">
        <div class="overflow_grid_NoPage11" style="text-align: center;">
            <table class="searchtable" cellspacing="0">
                <tr>
                    <td class="tdTitle">
                        报表名称：
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                    <td class="tdTitle">
                        生成时间：
                    </td>
                    <td>
                        <asp:Label ID="lblTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdTitle">
                        报表详细度：
                    </td>
                    <td>
                        <asp:Label ID="lblType" runat="server"></asp:Label>
                    </td>
                    <td class="tdTitle">
                        属性：
                    </td>
                    <td>
                        <asp:Label ID="lblProp" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Chart ID="chtReport" runat="server" Width="990px" Height="550px" BackColor="240, 251, 255">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="报表" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series ChartArea="ChartArea1" LegendText="最小值" Name="srMain" ChartType="Column"
                        BorderColor="180, 26, 59, 105">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" LegendText="最大值" ChartType="Column" Legend="Default"
                        Name="srMax">
                    </asp:Series>
                    <asp:Series ChartArea="ChartArea1" LegendText="平均值" ChartType="Column" Legend="Default"
                        Name="sravg">
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
</asp:Content>
