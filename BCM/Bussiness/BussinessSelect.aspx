<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BussinessSelect.aspx.cs" Inherits="GDK.BCM.Bussiness.BussinessSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../Styles/PopuWindow.css" rel="Stylesheet" />
        <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/Site.css" rel="Stylesheet" />
    <link href="../Styles/menu.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    

    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script  type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>
	 <script language="javascript" type="text/javascript">
	 	$(document).ready(function () {
	 		$("#lbtSave").click(function () {
	 			var selectItem = $(".gvDataList").find("input:checked");
	 			if (selectItem) {
	 				$("#txtValue").val(selectItem.val());
	 				return true;
	 			}
	 			return false;
	 		});
	 	});
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="wdiv" class="wdiv">
     <div style=" display:none;">
        <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
     </div>
         <div>
             <asp:GridView ID="gvDataList" AutoGenerateColumns="false" runat="server">
                 <Columns>
                     <asp:TemplateField HeaderText="选择">
                         <ItemStyle BackColor="#bdeaff" Width="25" />
                         <ItemTemplate>
                            <asp:RadioButton NAME="ddd" runat="server" />
                            <%--<input type="radio"  group="items" value="<%# Eval("DeviceID") %>" />--%>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField HeaderText="类型" DataField="TypeName" />
                     <asp:BoundField HeaderText="名称" DataField="DeviceName" />
                     <asp:BoundField HeaderText="描述" DataField="descInfo" />
                 </Columns>
                 <EmptyDataTemplate>
                     <table class="empty_gridview" cellspacing="0">
                         <tr>
                             <th>序号</th>
                             <th>类型</th>
                             <th>名称</th>
                             <th>描述</th>
                         </tr>
                         <tr>
                             <td colspan="4">
                                 没有数据
                             </td>
                         </tr>
                     </table>
                 </EmptyDataTemplate>
             </asp:GridView>
        </div>
    <uc2:pagenavigate ID="pg" runat="server" />
    </div>
	 <div class="window_footer_div">
        <div style="padding-top: 5px;">
            <asp:LinkButton ID="lbtSave" runat="server"   CssClass="ibtnwindow" OnClick="lbtSave_Click">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>
