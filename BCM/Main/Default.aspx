<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GDK.BCM.Main.Default" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     $(document).ready(function () {
         $(".yj_icon").each(function (i, o) {
             var obj = $(o);
             //obj.mo
         });

         $("#imgSetRealTime").click(function () {
             var m_url = "SysMainRealTimeSetEdit.aspx";
             $.popup({ title: "参数设置", url: m_url, borderStyle: { height: 400, width: 400 }, ok: function () {
                 $("#iframLoad").attr("src", "MainChartLoad.aspx?toWhere=RealtimeCurve");
             }
             }); //$.popup
         });
     });

     function changeSize() {
         $("#divloading").remove();
         $("#iframLoad").show();
     } 
</script>
  
<style type="text/css">
<!--
.divfloat
{
    width:50%;
    float:left;
}
.divright_padding
{
    padding-left:2px;
}
.divMSChart
{
    background-color: #FAFAFA;
    width:100%;
    height:275px; 
    overflow:hidden;
}
.divGridViwe
{
    overflow:hidden;
    height:193px;
}
.divgrid
{
    margin-bottom:2px;
}
    
-->
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divfloat">
        <table class="gridheader_table" cellpadding="0" cellspacing="0" style=" width:100%;">
            <tr>
                <td width="6">
                    <img src="../images/gridview/gridheader_03.gif" alt="" />
                </td>
                <td>
                    实时曲线
                </td>
                <td  style=" width:20px;">
                    <img id="imgSetRealTime" src="../images/icon/options.png" alt="设置实时曲线参数"/>
                </td>
                <td width="6">
                    <img src="../images/gridview/gridheader_06.gif" alt="" />
                </td>
            </tr>
        </table>
        <div class="divgrid">
            <div style="width: 70px; height: 250px;">
                    <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                        width="50px" height="250px">
                        <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                        <param name="onError" value="onSilverlightError" />
                        <param name="background" value="white" />
                        <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                        <param name="initParams" value="Target=MeterTemperature,DeviceID=123,ChanncelNo=3" />
                        <param name="minRuntimeVersion" value="4.0.50826.0" />
                        <param name="autoUpgrade" value="true" />
                        <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                            <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                        </a>
                    </object>
                    <iframe id="Iframe3" style="visibility: hidden; height: 0px; width: 0px;
                        border: 0px"></iframe>
                </div>
        </div>

        <table class="gridheader_table" cellpadding="0" cellspacing="0">
            <tr>
                <td width="6">
                    <img src="../images/gridview/gridheader_03.gif" alt="" />
                </td>
                <td>
                    告警列表
                </td>
                <td width="40">
                    <a href="../SerMonitor/AlarmLog.aspx">
                    <img style=" border:0px;" src="../images/Common/more.png" alt="查看更多告警记录" /> </a>
                </td>
                <td width="6">
                    <img src="../images/gridview/gridheader_06.gif" alt="" />
                </td>
                
            </tr>
        </table>
        <div class="divgrid divGridViwe" id="div2">
                <asp:GridView ID="gvErrorApp" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="机房名" DataField="StationName" />
                        <asp:BoundField  HeaderText="设备" DataField="DeviceName" />
                        <asp:BoundField HeaderText="事件名称" DataField="EventsName" />
                        <asp:BoundField HeaderText="级别" DataField="AlarmLevel" />
                        <asp:BoundField HeaderText="发生时间" DataField="HappenTime" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField HeaderText="报警类型" DataField="AlarmType" />
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellspacing="0" class="empty_gridview">
                            <tr>
                                <th>
                                    机房名
                                </th>
                                <th>
                                    事件名称
                                </th>
                                <th>
                                    级别
                                </th>
                                <th>
                                    发生时间
                                </th>
                                <th>报警类型</th>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    没有异常项目
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
        </div>
    </div>
    <div class="divfloat">
        <div class="divright_padding">
            <table class="gridheader_table" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="6">
                        <img src="../images/gridview/gridheader_03.gif" alt="" />
                    </td>
                    <td>
                        服务器资产统计
                    </td>
                    <td width="6">
                        <img src="../images/gridview/gridheader_06.gif" alt="" />
                    </td>
                </tr>
            </table>
            <div class="divgrid">
                <div class="divMSChart" id="div1">
                    <asp:Chart ID="chtServerBuytime" runat="server" Width="510" Height="270px" BackColor="#FAFAFA">
                        <%-- BackColor="WhiteSmoke"  BorderWidth="2"
            BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom"--%>
                        <Legends>
                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default">
                            </asp:Legend>
                        </Legends>
                        <%--        <BorderSkin SkinStyle="Emboss"></BorderSkin>--%>
                        <Series>
                            <asp:Series Name="Series1" IsValueShownAsLabel="True" LabelFormat="{0}台" BorderColor="180, 26, 59, 105">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="64, 0, 0, 0" BackGradientStyle="TopBottom">
                                <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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

            <table class="gridheader_table" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="6">
                        <img src="../images/gridview/gridheader_03.gif" alt="" />
                    </td>
                    <td>
                        服务器资产列表
                    </td>
                    <td width="6">
                        <img src="../images/gridview/gridheader_06.gif" alt="" />
                    </td>
                </tr>
            </table>
            <div class="divgrid divGridViwe" id="div4">
            <asp:GridView ID="gvErrorServer" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="机房" DataField="Room_NO" />
                    <asp:BoundField HeaderText="卡位" DataField="Card_Position" />
                    <asp:BoundField HeaderText="服务器" DataField="Server_Name" />
                    <asp:BoundField HeaderText="IP地址" DataField="SERVER_IP" />
                    <asp:BoundField HeaderText="负责人" DataField="ADMINNAME" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" class="empty_gridview">
                        <tr>
                            <th>
                                机房
                            </th>
                            <th>
                                卡位
                            </th>
                            <th>
                                服务器
                            </th>
                            <th>
                                IP地址
                            </th>
                            <th>
                                负责人
                            </th>
                        </tr>
                        <tr>
                            <td colspan="5">
                                没有异常服务器
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>

            
            </div>
        </div>
    </div>
</asp:Content>
