<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBSelect.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBSelect" %>

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
            <div class="div_box_title">磁盘读数-前10查询</div>
            <asp:GridView ID="gvDiskReading" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="磁盘读数" DataField="DiskReading" />
                    <asp:BoundField HeaderText="执行数" DataField="PerformSeveral" />
                    <asp:BoundField HeaderText="每次执行的磁盘读数" DataField="EachReading" />
                    <asp:BoundField HeaderText="查询" DataField="DBSelect" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>磁盘读数</th>
                            <th>执行数</th>
                            <th>每次执行的磁盘读数</th>
                            <th>查询</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="4">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>                  
      </div>
      <div class="div_box Padding_5">
            <div class="div_box_title">缓冲区读数-前10查询</div>
            <asp:GridView ID="gvBufferReading" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="缓冲区取得数" DataField="BufferReading" />
                    <asp:BoundField HeaderText="执行数" DataField="PerformSeveral" />
                    <asp:BoundField HeaderText="每次执行的缓冲区取得数" DataField="EachReading" />
                    <asp:BoundField HeaderText="查询" DataField="DBSelect" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>缓冲区取得数</th>
                            <th>执行数</th>
                            <th>每次执行的缓冲区取得数</th>
                            <th>查询</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="4">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>                  
      </div>      
    </form>
</body>
</html>
