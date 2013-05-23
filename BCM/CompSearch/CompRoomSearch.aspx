<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="CompRoomSearch.aspx.cs" Inherits="GDK.BCM.CompSearch.CompRoomShearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table class="gridheader_table" cellpadding="0" cellspacing="0">
		<tr>
			<td width="6">
				<img src="../images/gridview/gridheader_03.gif" alt="" />
			</td>
			<td>
				机房报表
			</td>
			<td width="60">
				<a class="headerBtnAdd" id="aBtnAdd" runat="server">
					<img src="../images/Common/add_btn.gif" /></a>
			</td>
			<td width="6">
				<img src="../images/gridview/gridheader_06.gif" alt="" />
			</td>
		</tr>
	</table>
    <div class="divgrid">
		<table class="searchtable" cellspacing="0">
			<tr>
				<td>
					机房
				</td>
				<td>
					<asp:DropDownList ID="dpdStationID" Width="180px" runat="server" AutoPostBack="true"
						OnSelectedIndexChanged="dpdStationID_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td>设备类型</td>
				<td class="tdLeft">
					<asp:DropDownList ID="dpdDeviceType" runat="server" AutoPostBack="true"
						OnSelectedIndexChanged="dpdStationID_SelectedIndexChanged"></asp:DropDownList></td>
				<td class="tdRight">
					设备名称：
				</td>
				<td class="tdLeft">
					<asp:DropDownList ID="dpdDeviceid" AutoPostBack="true" Width="180px" runat="server"
						OnSelectedIndexChanged="dpdDeviceid_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td>
					报表详细度
				</td>
				<td>
					<asp:DropDownList ID="dpdDtaill" runat="server">
						<asp:ListItem Text="----当天----"></asp:ListItem>
						<asp:ListItem Text="当天(精确到小时)" Value="Now"></asp:ListItem>
						<asp:ListItem Text="----历史----"></asp:ListItem>
						<asp:ListItem Text="一小时" Value="Now"></asp:ListItem>
						<asp:ListItem Text="一天" Value="Day"></asp:ListItem>
						<asp:ListItem Text="一月" Value="Month"></asp:ListItem>
						<asp:ListItem Text="一年" Value="year"></asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
			<td class="tdRight">
					通道名称：
				</td>
				<td class="tdLeft">
					<asp:ListBox ID="dpdchannelno" Width="180px" runat="server">
					</asp:ListBox>
				</td>
				<td>
					<asp:Button Text="->" ID="btnAddAItem"  runat="server"/>
					<asp:Button Text=">>" ID="btnAddAll"  runat="server"/>
					<asp:Button Text="<-" ID="btnMoveAItem"  runat="server"/>
					<asp:Button Text="<<" ID="btnMoveAll"  runat="server"/>
				</td>
			</tr>
		</table>
    <div class="overflow_grid">
   

    </div>
   
    </div>
</asp:Content>
