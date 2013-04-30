<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentLoadDep.aspx.cs" Inherits="GDK.BCM.Sysadmin.DepartmentLoadDep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divContent">
            <div class="divContent">
                <asp:Repeater ID="rptMenu2" runat="server">
                    <ItemTemplate>
                        <div class="divTitleMu" guid='<%# Eval("GUID")%>'>
                            <span class="divTitle">
                                &nbsp;</span>
                            <span class="spanLadDate">
                                <%# Eval("DISPLAY_NAME")%>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
