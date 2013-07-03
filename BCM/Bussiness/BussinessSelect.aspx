<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BussinessSelect.aspx.cs" Inherits="GDK.BCM.Bussiness.BussinessSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../Styles/PopuWindow.css" rel="Stylesheet" />
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
				
		});
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="wdiv" class="wdiv">
    
    </div>
	 <div class="window_footer_div">
        <div style="padding-top: 5px;">
            <asp:LinkButton ID="lbtSave" runat="server" OnClientClick="return $.yz.getErrorList();" CssClass="ibtnwindow" OnClick="lbtSave_Click">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>
