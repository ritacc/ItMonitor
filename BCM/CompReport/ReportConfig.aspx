<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true"
    CodeBehind="ReportConfig.aspx.cs" Inherits="GDK.BCM.CompReport.ReportConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>部门</td><td></td>
                <td>业务类型</td><td></td>
            </tr>
            <tr>
                <td colspan="2">主机运行状况整体分析配置</td>
                <td colspan="2">数据库运行状态整体分析配置</td>
            </tr>
            <tr>
                <td>监控指标</td><td>是否选中</td>
                <td>监控指标</td><td>是否选中</td>
            </tr>
            <tr>
                <td>主机磁盘利用率汇总统计</td>
                <td><asp:CheckBox ID="CheckBox1" runat="server"/></td>
                <td>表空间汇总统计</td>
                <td><asp:CheckBox ID="CheckBox2"  runat="server"/></td>
            </tr>
            <tr>
                <td>主机内存利用率汇总统计</td>
                <td><asp:CheckBox ID="CheckBox3" runat="server"/></td>
                <td>命中率汇总统计</td>
                <td><asp:CheckBox ID="CheckBox4"  runat="server"/></td>
            </tr>
            <tr>
                <td>主机CPU利用率汇总统计</td>
                <td><asp:CheckBox ID="CheckBox5" runat="server"/></td>
                <td>连接时间汇总统计</td>
                <td><asp:CheckBox ID="CheckBox6"  runat="server"/></td>
            </tr>
            <tr>
                <td colspan="2">中间件运行状况整体分析配置</td>
                <td colspan="2">业务系统运行状况整体分析配置</td>
            </tr>
            <tr>
                <td>监控指标</td><td>是否选中</td>
                <td>监控指标</td><td>是否选中</td>
            </tr>
            <tr>
                <td>会话数汇总统计</td>
                <td><asp:CheckBox ID="CheckBox7" runat="server"/></td>
                <td>系统停机状况统计</td>
                <td><asp:CheckBox ID="CheckBox8"  runat="server"/></td>
            </tr>
             <tr>
                <td>JVM堆使用汇总统计</td>
                <td><asp:CheckBox ID="CheckBox9" runat="server"/></td>
                <td>停机状况统计</td>
                <td><asp:CheckBox ID="CheckBox10"  runat="server"/></td>
            </tr>
            <tr>
                <td>数据库连接池汇总统计</td>
                <td><asp:CheckBox ID="CheckBox11" runat="server"/></td>
                <td>可用性汇总统计</td>
                <td><asp:CheckBox ID="CheckBox12"  runat="server"/></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button Text="提交" ID="btnSubmit" runat="server" />
                    <asp:Button Text="返回" ID="btnReturn" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
