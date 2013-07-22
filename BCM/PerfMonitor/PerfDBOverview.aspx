<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBOverview.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBOverview" %>
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
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/RefDetail.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            SetRef(<%= deviceID %>);
        });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class=" div_box">
    <div class="div_box_title">监视器信息</div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                    <div class="div_box Padding_5">
                    <div class="div_box_title">监视器信息</div> 
                        <table class="gridview_skin">
                            <tr class="AlternatingRowStyle">
                                <td width="40%">数据库名称：</td>
                                <td><asp:Label ID="lblServName" runat="server"></asp:Label></td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>
                                    健康状况:
                                </td>
                                <td>
                                    <img  id="imgHealth" src='../images/Common/health<%= Health %>.gif' alt="状态" class="imgPerf" />
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>数据库类型:</td>
                                <td>
                                    <asp:Label ID="lblAuthType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>数据库版本:</td>
                                <td>
                                   <asp:Label ID="lblVersion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>数据库启动时间:</td>
                                <td>
                                   <asp:Label ID="lblStartUpTime" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>端口:</td>
                                <td>
                                   <asp:Label ID="lblPort" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="RowStyle">
                                <td>主机名称:</td>
                                <td>
                                   <asp:Label ID="lblHostName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="AlternatingRowStyle">
                                <td>操作系统:</td>
                                <td>
                                   <asp:Label ID="lblSystem" runat="server"></asp:Label>
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
                         <asp:Chart ID="chtPerf" Width="300" Height="215" runat="server"
                            ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                            <Legends>
                                <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                                    IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="True "
                                    Name="Default" Docking="Bottom" Alignment="Center">
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
                                 <asp:ChartArea Name="ChartArea1" BackSecondaryColor="White">
                                     <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                         WallWidth="0" IsClustered="False" />
                                     <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                                         <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="0" />
                                         <MajorGrid LineColor="64, 64, 64, 64" />
                                     </AxisY>
                                     <AxisX LineColor="64, 64, 64, 64" Interval="1" LabelAutoFitMaxFontSize="8">
                                         <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                                         <MajorGrid LineColor="64, 64, 64, 64" />
                                     </AxisX>
                                 </asp:ChartArea>
                             </ChartAreas>
                         </asp:Chart>
                        <br /><br />
                        当前可用状态：<img id="imgStatusSub" src='../images/Common/stata<%= State %>.gif' alt="状态" />
                         <asp:Label ID="lblState" runat="server"></asp:Label>
                        <br /><br />
                    </div>
                </td>
            </tr>
        </table>  
    </div>
     <div class="div_box">
        <div class="div_box_title">连接时间图-最后一小时图</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chLine" runat="server" Width="890" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="x轴-连接时间" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                         Alignment="Center" Docking="Bottom">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="连接时间" ChartType="Line" IsValueShownAsLabel="True"
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
                        <AxisX LineColor="64, 64, 64, 64" Interval="1" LabelAutoFitMaxFontSize="8">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
      </div>

      <div class="div_box">
            <div class="div_box_title">连接时间-最后一小时</div>
            <table cellpadding="0" cellspacing="0" width="100%" class="gridview_skin">
                <tr class="gridview_skin_header">
                    <th width="40%">属性</th>
                    <th>值</th>
                </tr>
                <tr class="RowStyle">
                    <td>连接时间</td>
                    <td><asp:Label ID="lblValue" runat="server"></asp:Label></td>
                </tr>
            </table>        
      </div>

    <div class="div_box">
        <div class="div_box_title">用户活动性-最后一小时图表</div>
        <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 496px;">
            <asp:Chart ID="chUserActivity" runat="server" Width="890" Height="496" BackColor="#f0fbff">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="x轴-用户数" Name="Title1" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                        Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"
                        Alignment="Center" Docking="Bottom">
                    </asp:Legend>
                </Legends>
                <Series>
                    <asp:Series Name="Series1" LegendText="用户数" ChartType="Line" IsValueShownAsLabel="True"
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
            <div class="div_box_title">用户活动性-最后一小时</div>
            <table cellpadding="0" cellspacing="0" width="100%" class="gridview_skin">
                <tr class="gridview_skin_header">
                    <th width="40%">属性</th>
                    <th>值</th>
                </tr>
                <tr class="RowStyle">
                    <td>用户数</td>
                    <td><asp:Label ID="lblUserNO" runat="server"></asp:Label></td>
                </tr>
            </table>           
      </div>

      <div class="div_box">
            <div class="div_box_title">最少可用字节的表空间</div>
            <asp:GridView ID="gvMinBytes" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="名称" DataField="DeviceName" />
                    <asp:BoundField HeaderText="可用字节（MB）" DataField="kyzj" />
                    <asp:BoundField HeaderText="%可用" DataField="ky" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>名称</th>
                            <th>可用字节（MB）</th>
                            <th>%可用</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="3">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pg" runat="server" />      
      </div>

      <div class="div_box">
            <div class="div_box_title">数据库的明细</div>
            <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_skin">
                <tr class="AlternatingRowStyle">
                    <td width="40%">数据库创建时间</td>
                    <td><asp:Label ID="lblServCreateTime" runat="server"></asp:Label></td>
                </tr>
                <tr class="RowStyle">
                    <td>Open模式</td>
                    <td><asp:Label ID="lblOpenStyle" runat="server"></asp:Label></td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>Open模式</td>
                    <td><asp:Label ID="lblLogStyle" runat="server"></asp:Label></td>
                </tr>
            </table>     
      </div>

      <div class="div_box">
            <div class="div_box_title">数据库的状态</div>
            <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_skin">
                <tr class="AlternatingRowStyle">
                    <td width="40%">数据库尺寸</td>
                    <td><asp:Label ID="lblServerSize" runat="server"></asp:Label></td>
                </tr>
                <tr class="RowStyle">
                    <td>平均执行时间</td>
                    <td><asp:Label ID="lblAverageExecutionTime" runat="server"></asp:Label></td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>读次数</td>
                    <td><asp:Label ID="lblReadingTimes" runat="server"></asp:Label></td>
                </tr>
                <tr class="RowStyle">
                    <td>写次数</td>
                    <td><asp:Label ID="lblWritingTimes" runat="server"></asp:Label></td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>块大小</td>
                    <td><asp:Label ID="lblBlockSize" runat="server"></asp:Label></td>
                </tr>
            </table>  
      </div>

      <div class="div_box">
            <div class="div_box_title">击中率</div>
            <div class="div_char">
                <div class="div_title">缓冲器</div>
                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                    width="60px" height="200px">
                    <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                    <param name="onError" value="onSilverlightError" />
                    <param name="background" value="white" />
                    <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                    <param name="initParams" value="Target=MeterTemperature,DeviceID=<% =deviceID %>,ChanncelNo=45101" />
                    <param name="minRuntimeVersion" value="4.0.50826.0" />
                    <param name="autoUpgrade" value="true" />
                    <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                        <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                    </a>
                </object>
                <iframe id="Iframe2" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>            
            </div>
            
            <div class="div_char">
                <div class="div_title">数据字典</div>
                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                    width="60px" height="200px">
                    <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                    <param name="onError" value="onSilverlightError" />
                    <param name="background" value="white" />
                    <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                    <param name="initParams" value="Target=MeterTemperature,DeviceID=<% =deviceID %>,ChanncelNo=45102" />
                    <param name="minRuntimeVersion" value="4.0.50826.0" />
                    <param name="autoUpgrade" value="true" />
                    <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                        <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                    </a>
                </object>
                <iframe id="Iframe1" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>            
            </div>
            
            <div class="div_char">
                <div class="div_title">库</div>
                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                    width="60px" height="200px">
                    <param name="source" value="../ClientBin/ITMonitorControl.xap" />
                    <param name="onError" value="onSilverlightError" />
                    <param name="background" value="white" />
                    <!--MeterMember MeterAll MeterHalf MeterTemperature-->
                    <param name="initParams" value="Target=MeterTemperature,DeviceID=<% =deviceID %>,ChanncelNo=45103" />
                    <param name="minRuntimeVersion" value="4.0.50826.0" />
                    <param name="autoUpgrade" value="true" />
                    <a href="../SLFile/Silverlight.zip" style="text-decoration: none">
                        <img src="../SLFile/SLMedallion_CHS.png" alt="获取 Microsoft Silverlight" style="border-style: none" />
                    </a>
                </object>
                <iframe id="Iframe3" style="visibility: hidden; height: 0px; width: 0px; border: 0px"></iframe>            
            </div>            
      </div>
      <div class="div_box Padding_5" style="clear:both;">
        <div class="div_box_title">共享的SGA</div>
            <div class="char_middle overflow_grid_select_NoPage Padding_5" style="height: 306px;">
                    <asp:Chart ID="chtSGA" Width="700" Height="300" runat="server"
                    ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                    <Legends>
                        <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                            IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="True "
                             Name="Default" Docking="Bottom" Alignment="Center">
                        </asp:Legend>
                    </Legends>
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold"
                            CustomProperties="DoughnutRadius=25,  PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20"
                            MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double"
                            Label="#PERCENT{P1}"  BorderWidth="2">
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
                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False"/>
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
