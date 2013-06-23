﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfNetAlarmDetail.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfNetAlarmDetail" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/MonitorDetail.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class=" Padding_5">
        <div class="div_box_title">资源告警信息</div>
        
        <table class="gridview_skin">
             <tr class="RowStyle">
                <td colspan="2" style="text-align:left;">
                    性能图标说明：
                    <img src="../images/Common/stata0.gif" alt="设备状态" class="imgPerf" /> 正常 &nbsp;
                    <img src="../images/Common/stata1.gif" alt="设备状态" class="imgPerf" /> 故障  &nbsp;
                    <img src="../images/Common/stata2.gif" alt="设备状态" class="imgPerf" /> 报警  &nbsp;
                    <img src="../images/Common/stata3.gif" alt="设备状态" class="imgPerf" /> 未启动  &nbsp;
                </td>
            </tr>            
            <tr class="AlternatingRowStyle">
                <td width="40%">
                    来源:
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>发生时间:</td>
                <td>
                    <asp:Label ID="lblHappenTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>最新采集时间:</td>
                <td>
                    <asp:Label ID="lblLastPollingTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="RowStyle">
                <td>性能:</td>
                <td>
                    <asp:Label ID="lblPerformance" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td>消息:</td>
                <td>
                    <asp:Label ID="lblContent" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    
    <div class="Padding_5">
    <div class="div_box_title">依从指标的告警信息列表</div>
    <asp:GridView ID="gvAlarmList" runat="server" AutoGenerateColumns="False" class="gridview_skin">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="指标">
                <ItemTemplate>
                    <a href="PerfNetAlarmSubDetail.aspx?id=<%#Eval("DeviceID") %>"><span class="sercers">
                        <%#Eval("DeviceName")%></span></a>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="性能">
                <ItemTemplate>
                    <img src='../images/Common/stata<%= perf %>.gif' alt="性能" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="警告信息" DataField="Content" />
            <asp:BoundField HeaderText="发生时间" DataField="HappenTime" />
        </Columns>
        <EmptyDataTemplate>
            <table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all" border="0"
                id="ContentPlaceHolder1_gvDataList" style="border-collapse: collapse;">
                <tr class="gridview_skin_header">
                    <th>
                        指标
                    </th>
                    <th>
                        性能
                    </th>
                    <th>
                        警告信息
                    </th>
                    <th>
                        发生时间
                    </th>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    <uc2:pagenavigate ID="pg" runat="server" />  
    </div>  
    </form>
</body>
</html>    
