<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAuthRose.aspx.cs" Inherits="Role_UserAuthRose" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户授予角色</title>
     <link href="../styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../styles/page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Js/jquery-1[1].3.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.funkyUI.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page_Middle">
    
        <table style="margin: 20px auto;" width="80%">
            <tr>
                <td align="center">
                    用户姓名:
                    <asp:Label ID="txt_name" runat="server"></asp:Label>
                </td>
                <td align="center">
                    系统登录名:
                    <asp:Label ID="txt_UserName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr style="width: 100%" />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>请选择要授予的角色：</strong>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="AlternatingRowStyle">
                    <asp:CheckBoxList ID="cblRoseList" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btn_Save" OnClick="btn_Save_Click" runat="server" Text="保存" CssClass="normal_button" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
