<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="GDK.BCM.Role.RoleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>角色信息</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtName.ClientID  %>").yz({ title: "角色名称", type: "string", max: 50, isSave: true });
            $("#<%= txtROLE_DESC.ClientID  %>").yz({ title: "角色描述", type: "string", max: 250, isSave: true });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table  id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table" runat="server">
            <tr>
                <td width="35%" align="right">
                    角色名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    描述：
                </td>
                <td>
                    <asp:TextBox runat="server"  MaxLength="250" Width="200" Height="80" ID="txtROLE_DESC" TextMode="MultiLine"  />
                </td>
            </tr>
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
