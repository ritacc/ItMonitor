<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBLock.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PrefDBLock" %>
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
</head>
<body>
    <form id="form1" runat="server">
     <div class="div_box Padding_5">
            <div class="div_box_title">拥有锁的会话数</div>
            <asp:GridView ID="gvLockedNO" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序列" DataField="Array" />
                    <asp:BoundField HeaderText="机器" DataField="Machine" />
                    <asp:BoundField HeaderText="程序" DataField="Program" />
                    <asp:BoundField HeaderText="锁等待" DataField="LockWaiting" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>ID</th>
                            <th>序列</th>
                            <th>机器</th>
                            <th>程序</th>
                            <th>锁等待</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="5">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pg" runat="server" />      
      </div>
      <div class="div_box Padding_5">
            <div class="div_box_title">锁的会话等待数</div>
            <asp:GridView ID="gvLockedWaitingNO" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="等待中的会话ID" DataField="WaitingID" />
                    <asp:BoundField HeaderText="挂起的会话ID" DataField="PendingID" />
                    <asp:BoundField HeaderText="锁类型" DataField="LockType" />
                    <asp:BoundField HeaderText="持有方式" DataField="HoldMode" />
                    <asp:BoundField HeaderText="请求方式" DataField="AskMode" />
                    <asp:BoundField HeaderText="锁ID1" DataField="LockID1" />
                    <asp:BoundField HeaderText="锁ID2" DataField="LockID2" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>等待中的会话ID</th>
                            <th>挂起的会话ID</th>
                            <th>锁类型</th>
                            <th>持有方式</th>
                            <th>请求方式</th>
                            <th>锁ID1</th>
                            <th>锁ID2</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="7">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pgLockedWaitingNO" runat="server" />      
      </div>
      
      <div class="div_box Padding_5">
            <div class="div_box_title">锁明细</div>
            <asp:GridView ID="gvLockDetail" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="对话名" DataField="DialogueName" />
                    <asp:BoundField HeaderText="会话ID" DataField="ConversationID" />
                    <asp:BoundField HeaderText="序列" DataField="Program" />
                    <asp:BoundField HeaderText="锁模式" DataField="LockMode" />
                    <asp:BoundField HeaderText="状态" DataField="State" />
                    <asp:BoundField HeaderText="OS进程ID" DataField="OsProcessID" />
                    <asp:BoundField HeaderText="登陆时间" DataField="LoginTime" />
                    <asp:BoundField HeaderText="最后调用时间" DataField="LastCallTime" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>对话名</th>
                            <th>会话ID</th>
                            <th>序列</th>
                            <th>锁模式</th>
                            <th>状态</th>
                            <th>OS进程ID</th>
                            <th>登陆时间</th>
                            <th>最后调用时间</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="8">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pgLockDetail" runat="server" />      
      </div>
</form>
</body>
</html>
