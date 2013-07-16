<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlarmLevelSetEdit.aspx.cs" Inherits="GDK.BCM.AlertAdmin.AlarmLevelSetEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>告警等级信息</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtLevelname").yz({ title: "等级名称", type: "string", canEmpty: false });
            $("#txtUpinterval").yz({ title: "自动升级间隔时间", type: "int", canEmpty: false });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table  id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table" runat="server">
<tr><td class="tdRight">级别：</td><td class="tdLeft" >
 <asp:DropDownList runat="server" ID="dpdPriority">
 <asp:ListItem Text="1" Value="1"></asp:ListItem>
 <asp:ListItem Text="2" Value="2"></asp:ListItem>
 <asp:ListItem Text="3" Value="3"></asp:ListItem>
 <asp:ListItem Text="4" Value="4"></asp:ListItem>
 <asp:ListItem Text="5" Value="5"></asp:ListItem>
 <asp:ListItem Text="6" Value="6"></asp:ListItem>
 <asp:ListItem Text="7" Value="7"></asp:ListItem>
 <asp:ListItem Text="8" Value="8"></asp:ListItem>
 <asp:ListItem Text="9" Value="9"></asp:ListItem>
 <asp:ListItem Text="10" Value="10"></asp:ListItem>
 </asp:DropDownList>
 
 </td></tr>
<tr><td class="tdRight">等级名称：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLevelname" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">自动升级间隔时间：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtUpinterval" CssClass="textbox_skin" /> </td></tr>

        </table>
    </div>
    <div class="window_footer_div">
        <div style="padding-top:5px;">
        <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow" OnClick="lbtSave_Click" OnClientClick="return $.yz.getErrorList()">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
        </asp:LinkButton>&nbsp;
        <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
            <img src="../images/icon/delete.gif" border="0" alt="" />关闭
        </a>
        </div>
    </div>
    </form>
</body>
</html>

