﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfSystemFailure.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfSystemFailure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="../Scripts/MonitorList.js"></script>
</head>
<body style="overflow-x: hidden">
    <form id="form1" runat="server">
    <div class="divgrid">
        <table class="gridheader_table" cellpadding="0" cellspacing="0">
            <tr>
                <td width="6">
                    <img src="../images/gridview/gridheader_03.gif" alt="" />
                </td>
                <td>
                    系统故障列表
                </td>
                <td width="6">
                    <img src="../images/gridview/gridheader_06.gif" alt="" />
                </td>
            </tr>
        </table>
        <div class="overflow_grid">
            <div id="divShowMsg">
            </div>
            <table class="searchtable" cellspacing="0">
                <tr>
                    <td>
                        状态图标说明：
                        <img src="../images/Common/stata1.gif" alt="设备状态" style="vertical-align:middle;" /> 正常 &nbsp;
                        <img src="../images/Common/stata0.gif" alt="设备状态" style="vertical-align:middle;" /> 故障  &nbsp;
                        <img src="../images/Common/stata2.gif" alt="设备状态" style="vertical-align:middle;" /> 报警  &nbsp;
                        <img src="../images/Common/stata3.gif" alt="设备状态" style="vertical-align:middle;" /> 未启动  &nbsp;
                    </td>
                    <td style="width: 88px; text-align: left;">
                        请选择查询条件:
                    </td>
                    <td style="width: 130px; text-align: right;">
                        <asp:RadioButton GroupName="shearch" Checked="true" Text="来源" ID="rdbSource" runat="server" />
                        <asp:RadioButton GroupName="shearch" Text="报警信息" ID="rdbinfo" runat="server" />
                    </td>
                    <td style="width: 250px;">
                        <asp:TextBox ID="txtValue" Width="250px" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 40px;">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索" CssClass="btn_bg"/>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvDataList" AutoGenerateColumns="False" runat="server" class="gridview_skin">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle BackColor="#bdeaff" Width="25" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="来源">
                        <ItemTemplate>
                            <a href="PerfApplicationUrl.aspx?id=<%#Eval("DeviceID") %>"><span class="sercers">
                                <%#Eval("DeviceName")%></span></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="类型" DataField="TypeName" />
                    <asp:TemplateField HeaderText="性能">
                        <ItemTemplate>
                            <img src='../images/Common/stata<%# Eval("perfValue") %>.gif' alt="设备状态" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="警报信息" DataField="Content" />
                    <asp:BoundField HeaderText="发生时间" DataField="HappenTime" />
                    <asp:BoundField HeaderText="联系人" DataField="DISPLAY_NAME" />
                </Columns>
            </asp:GridView>
        </div>
        <uc2:pagenavigate ID="pg" runat="server" />
    </div>
    </form>
</body>
</html>
