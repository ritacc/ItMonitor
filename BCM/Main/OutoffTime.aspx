<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutoffTime.aspx.cs" Inherits="HCGL.main.OutoffTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>登陆超时，请重新登陆</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position: absolute; top: 50%; left: 0px; width: 100%; text-align: center">
        <a href="../login.aspx" title="登陆超时,请重新登陆">
            <asp:Label runat="server" ID="labMsg" Text="登陆超时,请重新登陆." /></a>
    </div>
    </form>
</body>
</html>
