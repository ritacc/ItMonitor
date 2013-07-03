<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BussinessEdit.aspx.cs" Inherits="GDK.BCM.Bussiness.BussinessEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/menu.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
	 
	<script language="javascript" type="text/javascript">
	 $(document).ready(function () {
		
		$(".headerBtnAdd").click(function () {
			var strVar = 'RoleEdit.aspx';
			$.popup({ title: "添加角色", url: strVar, borderStyle: { height: 300, width: 400 }, ok: function (obj) {

				$.popup.Refrsh();
			}
			}); //$.popup

		});

	});
    </script>

	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" display:none;">
    
        <asp:TextBox ID="txtDeviceID" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
    
    </div>

     <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>应用系统列表</td>
        <td width="60"><a class="headerBtnAdd" id="aBtnAdd" runat="server"><img src="../images/Common/add_btn.gif" /></a></td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
    <div class="divgrid">
    <div class="overflow_grid">
    <asp:GridView ID="gvDataList" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("GUID") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
			<asp:BoundField HeaderText="类型" DataField="MonitorName" />
            <asp:BoundField HeaderText="名称" DataField="DeviceName" />
            <asp:BoundField HeaderText="描述" DataField="descInfo" />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                    <th>
                        序号
                    </th>
                    <th>
                        名称
                    </th>
                    <th>
                        描述
                    </th>
                </tr>
                <tr>
                    <td colspan="3">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
    <uc2:pagenavigate ID="pg" runat="server" />
    </div>


    </form>
</body>
</html>
