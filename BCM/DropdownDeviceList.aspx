<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropdownDeviceList.aspx.cs" Inherits="GDK.BCM.DropdownDeviceList" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <meta content="zh-cn" http-equiv="Content-Language" />
</head>
<body>
    <form id="form1" runat="server">
    
   
			<asp:Chart ID="chLine" runat="server" Width="510" Height="270px" BackColor="#FAFAFA">
                        <Legends>
                            <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default">
                            </asp:Legend>
                        </Legends>
                        <Series>
                            <asp:Series Name="Series1"   IsValueShownAsLabel="True" LabelFormat="{0}台" BorderColor="180, 26, 59, 105">
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
    
   
    </form>
</body>
</html>
