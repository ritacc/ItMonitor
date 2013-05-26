<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="DBSearch.aspx.cs" Inherits="GDK.BCM.CompSeartch.DBSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%= dpdStationID.ClientID  %>").yz({ title: "机房名称", type: "string"});
        $("#<%= dpdDeviceType.ClientID  %>").yz({ title: "设备类型", type: "string" });
        $("#<%= dpdDeviceid.ClientID  %>").yz({ title: "设备", type: "string" });

        $("#<%= txtStartTime.ClientID  %>").yz({ title: "开始日期", type: "date" });
        $("#<%= txtEndTime.ClientID  %>").yz({ title: "结束日期", type: "date" });

        
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table class="gridheader_table" cellpadding="0" cellspacing="0">
		<tr>
			<td width="6">
				<img src="../images/gridview/gridheader_03.gif" alt="" />
			</td>
			<td>
				综合查询报表
			</td>
			<td width="6">
				<img src="../images/gridview/gridheader_06.gif" alt="" />
			</td>
		</tr>
	</table>
    <div class="divgrid">
		<table class="searchtable" cellspacing="0">
			<tr>
				<td style=" width:80px;">机房名称：</td>
				<td style=" width:180px;">
					<asp:DropDownList ID="dpdStationID" Width="180px" runat="server" AutoPostBack="true"
						OnSelectedIndexChanged="dpdStationID_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td style=" width:80px;">设备类型：</td>
				<td class="tdLeft" style=" width:180px;">
					<asp:DropDownList ID="dpdDeviceType" Width="180px" runat="server" AutoPostBack="true"
						OnSelectedIndexChanged="dpdStationID_SelectedIndexChanged"></asp:DropDownList></td>
				<td  style=" width:90px;" class="tdRight">
					设备名称：
				</td>
				<td  class="tdLeft">
					<asp:DropDownList ID="dpdDeviceid" AutoPostBack="true" Width="180px" runat="server"
						OnSelectedIndexChanged="dpdDeviceid_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
			</tr>
            <tr>
                <td>
                    开始日期：
                </td>
                <td>
                    <asp:TextBox runat="server"  onfocus="WdatePicker();" Width="100px" ID="txtStartTime"></asp:TextBox>
                </td>
                <td>
                    结束日期：
                </td>
                <td>
                    <asp:TextBox runat="server" Width="100px" onfocus="WdatePicker();"  ID="txtEndTime"></asp:TextBox>
                </td>
                <td>
					报表详细度：
				</td>
				<td>
					<asp:DropDownList ID="dpdDtaill" runat="server">
						<asp:ListItem Text="当天(精确到小时)" Value="dayNow"></asp:ListItem>
						<asp:ListItem Text="历史(一小时)" Value="Now"></asp:ListItem>
						<asp:ListItem Text="历史(一天)" Value="Day"></asp:ListItem>
						<asp:ListItem Text="历史(一月)" Value="Month"></asp:ListItem>
						<asp:ListItem Text="历史(一年)" Value="year"></asp:ListItem>
					</asp:DropDownList>
				</td>
            </tr>
            <tr>
                <td colspan="6" style=" font-weight:bold; font-size:14px;">报表对象</td>
            </tr>
            <tr>
                <td></td>
                <td>可选择对象</td>
                <td></td>
                <td>已选择对象</td>
                <td colspan="2"></td>
            </tr>
            <tr>
			<td class="tdRight" >
					 
				</td>
				<td class="tdLeft">
					<asp:ListBox ID="lbChannelnoList" Height="200px" Width="180px" runat="server">
					</asp:ListBox>
				</td>
				<td>
                <div style=" text-align:center;">
					<asp:Button Text="->" Width="30px" ID="btnAddAItem"  runat="server" 
                        onclick="btnAddAItem_Click"/><br />
					<asp:Button Text=">>" Width="30px" ID="btnAddAll"  runat="server" 
                        onclick="btnAddAll_Click"/><br />
					<asp:Button Text="<-" Width="30px" ID="btnMoveAItem"  runat="server" 
                        onclick="btnMoveAItem_Click"/><br />
					<asp:Button Text="<<" Width="30px" ID="btnMoveAll"  runat="server" 
                        onclick="btnMoveAll_Click"/>
                    </div>
				</td>
                <td class="tdLeft" colspan="2">
					<asp:ListBox ID="listSelectChannelNo" Height="200px" Width="180px" runat="server">
					</asp:ListBox>
				</td>
			</tr>
            <tr>
            <td colspan="3"></td>
            <td colspan="3">
                <asp:Button ID="btnSearch" Text="查询"  CssClass="btn_bg"   runat="server"
                 OnClientClick="return $.yz.getErrorList()" onclick="btnSearch_Click" />
            </td>
            </tr>
		</table>
    <div class="overflow_grid">
   

    </div>
   
    </div>
</asp:Content>
