<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateCompRoomEnviDetail.aspx.cs" Inherits="GDK.BCM.StateMonitor.StateCompRoomEnviDetail" %>

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
    <div class="div_box_title">监控对象信息</div> 
        <table class="gridview_skin">
            <tr class="AlternatingRowStyle">
                <td width="40%">
                    名称:
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>当前状态:</td>
                <td>
                    <asp:Label ID="lblState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>最新采集时间:</td>
                <td>
                    <asp:Label ID="lblLastPollingTime" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        </div>

        <div class="div_box Padding_5">
        <div class="div_box_title">监控对象属性</div> 
            <table class="gridview_skin">
                <tr class="gridview_skin_header">
                    <th>属性名</th>
                    <th>属性值</th>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td width="40%">
                        泄漏:
                    </td>
                    <td>
                        <asp:Label ID="lblLeak" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="RowStyle">
                    <td>DUANXIAN:</td>
                    <td>
                        <asp:Label ID="lblDUANXIAN" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr class="AlternatingRowStyle">
                    <td>WEIZHI:</td>
                    <td>
                        <asp:Label ID="lblWEIZHI" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
