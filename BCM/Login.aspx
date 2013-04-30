<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GDK.BCM.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ITMonitor</title>
    <link href="Styles/login.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box">
        <div class="tablelogin">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    用户名：
                </td>
                <td>
                    <asp:TextBox ID="txtUersName"   runat="server" CssClass="tablelogin_input" Width="140"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    密码：

                </td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password"  runat="server" CssClass="tablelogin_input" Width="140"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="ibtnLogin" runat="server" ImageUrl="~/images/login/login_06.gif" onclick="ibtnLogin_Click" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
