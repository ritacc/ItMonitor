<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="DBSearchDetail.aspx.cs" Inherits="GDK.BCM.CompSearch.DBSearchDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="searchtable" cellspacing="0">
        <tr>
            <td>报表名称：</td>
            <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
            <td>生成时间：</td>
            <td><asp:Label ID="lblTime" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>报表详细度：</td>
            <td><asp:Label ID="lblType" runat="server"></asp:Label></td>
            <td>属性：</td>
            <td><asp:Label ID="lblProp" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
