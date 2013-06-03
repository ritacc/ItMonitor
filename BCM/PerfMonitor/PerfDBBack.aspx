<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBBack.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBBack" %>
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
            <div class="div_box_title">回退段</div>
            <asp:GridView ID="gvDBBack" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="段名" DataField="DeviceName" />
                    <asp:BoundField HeaderText="表空间名" DataField="TableSpaceName" />
                    <asp:BoundField HeaderText="状态" DataField="State" />
                    <asp:BoundField HeaderText="当前大小(MB)" DataField="CurrentSize" />
                    <asp:BoundField HeaderText="初始长度(MB)" DataField="InitialLength" />
                    <asp:BoundField HeaderText="下一个长度(MB)" DataField="NextLength" />
                    <asp:BoundField HeaderText="最小长度" DataField="MinLength" />
                    <asp:BoundField HeaderText="最大长度" DataField="MaxLength" />
                    <asp:BoundField HeaderText="击中率%" DataField="HitRate" />
                    <asp:BoundField HeaderText="HEW大小(MB)" DataField="HWMSize" />
                    <asp:BoundField HeaderText="搜索" DataField="Search" />
                    <asp:BoundField HeaderText="Wraps" DataField="Wraps" />
                    <asp:BoundField HeaderText="扩展" DataField="Expand" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>段名</th>
                            <th>表空间名</th>
                            <th>状态</th>
                            <th>当前大小(MB)</th>
                            <th>初始长度(MB</th>
                            <th>下一个长度(MB)</th>
                            <th>最小长度</th>
                            <th>最大长度</th>
                            <th>击中率%</th>
                            <th>HEW大小(MB)</th>
                            <th>搜索</th>
                            <th>Wraps</th>
                            <th>扩展</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="13">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pg" runat="server" />   
      </div>
    </form>
</body>
</html>
