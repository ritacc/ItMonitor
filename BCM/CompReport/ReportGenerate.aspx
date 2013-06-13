<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="ReportGenerate.aspx.cs" Inherits="GDK.BCM.CompReport.ReportGenerate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>报告生成管理</td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
        <div class="iframe_top">
            当前用户：<asp:Label ID="lblName" runat="server" ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
            所属部门：<asp:Label ID="lblDepart" runat="server"></asp:Label>
        </div>
        
    <table class="gridview_skin">
        <tr class="gridview_skin_header"><th colspan="5" style=" text-align:left;">
            报告类型确定    
        </th></tr>
        <tr class="RowStyle">
            <td>
                报告类型
            </td>
            <td style=" text-align:left;" colspan="4">
                <asp:RadioButton  ID="rdiM" Checked="true" GroupName="reprotType" Text="月" runat="server"/>
                <asp:RadioButton  ID="rdiS"  GroupName="reprotType" Text="选定" runat="server"/>
               <span id="divMonth">
                <asp:DropDownList ID="dpdYear" Width="60px" runat="server"></asp:DropDownList>年
                <asp:DropDownList ID="dpdMonth" Width="50px" runat="server"></asp:DropDownList>月
                </span>
                <span id="divSelect">
                    <asp:TextBox ID="txtStartTime"  onfocus="WdatePicker();" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtEndTime"  onfocus="WdatePicker();" runat="server"></asp:TextBox>
                </span>
            </td>
        </tr>
        <tr class="AlternatingRowStyle">
            <td rowspan="3">
                其它
            </td>
            <td>
                报告标题
            </td>
            <td style="text-align:left;">
                <asp:DropDownList ID="dpdSystem" Width="200px" runat="server"></asp:DropDownList>
            </td>
            <td>
                报告副标题
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtSubTitle" Width="200px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr class="RowStyle">
            <td>
                报告描述
            </td>
            <td colspan="3"  style="text-align:left;">
                <asp:TextBox ID="reportDesc" TextMode="MultiLine" Width="712px" Height="150px" runat="server"></asp:TextBox>
            </td>
        </tr>
       <tr class="AlternatingRowStyle">
            <td colspan="4" style=" text-align:center;">
                <asp:Button ID="btnGeneratePDF" runat="server" Text="生成报告" OnClick="btnGeneratePDF_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
