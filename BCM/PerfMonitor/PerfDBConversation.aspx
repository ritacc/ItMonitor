<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBConversation.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBConversation" %>
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
            <div class="div_box_title">会话明细</div>
            <asp:GridView ID="gvConversationDetail" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="DeviceName" />
                    <asp:BoundField HeaderText="状态" DataField="State" />
                    <asp:BoundField HeaderText="机器" DataField="Machine" />
                    <asp:BoundField HeaderText="用户名" DataField="UserName" />
                    <asp:BoundField HeaderText="耗时" DataField="Processed" />
                    <asp:BoundField HeaderText="Cpu使用量" DataField="CpuUsage" />
                    <asp:BoundField HeaderText="内存排序" DataField="MemorySequence" />
                    <asp:BoundField HeaderText="表扫描" DataField="TableScan" />
                    <asp:BoundField HeaderText="物理读" DataField="PhysicalRead" />
                    <asp:BoundField HeaderText="逻辑读" DataField="LogicalRead" />
                    <asp:BoundField HeaderText="提交" DataField="Submit" />
                    <asp:BoundField HeaderText="光标" DataField="sqlCursor" />
                    <asp:BoundField HeaderText="缓冲区击中率" DataField="BufferHitRate" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>ID</th>
                            <th>状态</th>
                            <th>机器</th>
                            <th>用户名</th>
                            <th>耗时</th>
                            <th>Cpu使用量</th>
                            <th>内存排序</th>
                            <th>表扫描</th>
                            <th>物理读</th>
                            <th>逻辑读</th>
                            <th>提交</th>
                            <th>光标</th>
                            <th>缓冲区击中率</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="13">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pg" runat="server" />   
      </div>

        <div class="div_box Padding_5">
            <div class="div_box_title">会话汇总</div>
            <asp:GridView ID="gvConversationCollect" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="机器" DataField="DeviceName" />
                    <asp:BoundField HeaderText="程序" DataField="Program" />
                    <asp:BoundField HeaderText="状态" DataField="state" />
                    <asp:BoundField HeaderText="次数" DataField="Times" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>机器</th>
                            <th>程序</th>
                            <th>状态</th>
                            <th>次数</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="4">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgConversationCollect" runat="server" />      
      </div>
      
      <div class="div_box Padding_5">
            <div class="div_box_title">等待会话数</div>
            <asp:GridView ID="gvConversationNO" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="等待会话ID" DataField="DeviceName" />
                    <asp:BoundField HeaderText="用户名" DataField="UserName" />
                    <asp:BoundField HeaderText="事件" DataField="sqlEvent" />
                    <asp:BoundField HeaderText="状态" DataField="State" />
                    <asp:BoundField HeaderText="等待时间" DataField="WaitTime" />
                    <asp:BoundField HeaderText="等待秒数" DataField="Waits" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>等待会话ID</th>
                            <th>用户名</th>
                            <th>事件</th>
                            <th>状态</th>
                            <th>等待时间</th>
                            <th>等待秒数</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="6">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc1:pagenavigate ID="pgConversationNO" runat="server" />      
      </div>   
    </form>
</body>
</html>
