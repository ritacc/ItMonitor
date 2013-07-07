<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generate.aspx.cs" Inherits="GDK.BCM.CompReport.Generate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Chart ID="chLine" runat="server" Width="520" Height="260" BackColor="#f0fbff">
                <Titles>
                            <asp:Title Docking="Left" Font="Trebuchet MS, 14.25pt, style=Bold"  Name="titY"
                                Text="Response Time/ms" TextOrientation="Rotated90">
                            </asp:Title>
                             <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="今天" Name="titTop" ForeColor="26, 59, 105"></asp:Title>
                </Titles>
                <Legends>
                    <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"   Alignment="Center"
                    Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Docking="Bottom"   Name="Default">
                    </asp:Legend>
                 </Legends>
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
    </form>
</body>
</html>
