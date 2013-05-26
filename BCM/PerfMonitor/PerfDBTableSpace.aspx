<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfDBTableSpace.aspx.cs" Inherits="GDK.BCM.PerfMonitor.PerfDBTableSpace" %>
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
            <div class="div_box_title">表空间明细</div>
            <asp:GridView ID="gvTableSpaceDetail" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="名称" DataField="DeviceName" />
                    <asp:BoundField HeaderText="表空间使用情况" DataField="syqk" />
                    <asp:BoundField HeaderText="已分配字节数（MB）" DataField="yfpzj" />
                    <asp:BoundField HeaderText="可用字节（MB）" DataField="bkjqk" />
                    <asp:BoundField HeaderText="%可用" DataField="ky" />
                    <asp:BoundField HeaderText="已分配块空间" DataField="yfpkkj" />
                    <asp:BoundField HeaderText="可用块数" DataField="kyks" />
                    <asp:BoundField HeaderText="数据文件" DataField="datafile" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>名称</th>
                            <th>表空间使用情况</th>
                            <th>已分配字节数（MB）</th>
                            <th>可用字节（MB）</th>
                            <th>%可用</th>
                            <th>已分配块空间</th>
                            <th>可用块数</th>
                            <th>数据文件</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="8">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pg" runat="server" />      
      </div>
      <div class="div_box Padding_5">
            <div class="div_box_title">表空间状态</div>
            <asp:GridView ID="gvTableSpaceState" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="名称" DataField="DeviceName" />
                    <asp:BoundField HeaderText="状态" DataField="state" />
                    <asp:BoundField HeaderText="读次数/分" DataField="readed" />
                    <asp:BoundField HeaderText="写次数/分" DataField="Write" />
                    <asp:BoundField HeaderText="读时间" DataField="readedTime" />
                    <asp:BoundField HeaderText="写时间" DataField="WriteTime" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>名称</th>
                            <th>状态</th>
                            <th>读次数/分</th>
                            <th>写次数/分</th>
                            <th>读时间</th>
                            <th>写时间</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="6">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pgTableSpaceState" runat="server" />      
      </div>
      
      <div class="div_box Padding_5">
            <div class="div_box_title">数据文件的性能指标</div>
            <asp:GridView ID="gvTableSpaceData" runat="server" AutoGenerateColumns="false" CssClass="gridview_skin">
                <Columns>
                    <asp:BoundField HeaderText="数据文件名" DataField="DeviceName" />
                    <asp:BoundField HeaderText="表空间名" DataField="TableSpaceName" />
                    <asp:BoundField HeaderText="状态" DataField="State" />
                    <asp:BoundField HeaderText="数据文件大小(MB)" DataField="DataFileSize" />
                    <asp:BoundField HeaderText="读次数" DataField="ReadTimes" />
                    <asp:BoundField HeaderText="写次数" DataField="WriteTimes" />
                    <asp:BoundField HeaderText="平均读时间(ms)" DataField="AverageReadingTime" />
                    <asp:BoundField HeaderText="平均写时间(ms)" DataField="AverageWriteTime" />
                </Columns>
                <EmptyDataTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%" class="gridheader_table">
                        <tr class="gridview_skin_header">
                            <th>数据文件名</th>
                            <th>表空间名</th>
                            <th>状态</th>
                            <th>数据文件大小(MB)</th>
                            <th>读次数</th>
                            <th>写次数</th>
                            <th>平均读时间(ms)</th>
                            <th>平均写时间(ms)</th>
                        </tr>
                        <tr class="AlternatingRowStyle">
                            <td colspan="8">没有数据</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>              
        <uc2:pagenavigate ID="pgTableSpaceData" runat="server" />      
      </div>
    </form>
</body>
</html>
