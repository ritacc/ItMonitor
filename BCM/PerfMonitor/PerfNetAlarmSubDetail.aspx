<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfNetAlarmSubDetail.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfNetAlarmSubDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div_box_title">资源告警信息</div>        
        <table class="gridview_skin">
             <tr class="RowStyle">
                <td colspan="2" style="text-align:left;">
                    性能图标说明：
                    <img src='../images/Common/stata4.gif' alt="状态不可用" />状态不可用
                    <img src='../images/Common/stata0.gif' alt="严重警告" />严重警告
                    <img src='../images/Common/stata2.gif' alt="一般警告" />一般警告
                    <img src='../images/Common/stata1.gif' alt="正常" />正常
                </td>
            </tr>            
            <tr class="AlternatingRowStyle">
                <td>
                    来源:
                </td>
                <td>
                    <asp:Label ID="lblPort" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>发生时间:</td>
                <td>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>最新采集时间:</td>
                <td>
                    <asp:Label ID="lblIpAddresses" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>性能:</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>消息:</td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
