<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropdownDeviceList.aspx.cs" Inherits="GDK.BCM.DropdownDeviceList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <meta content="zh-cn" http-equiv="Content-Language" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater runat="server" ID="rpLevel1">
        <ItemTemplate>
            <span class="level1 level" id='level_<%# Eval("Guid") %>' guid='<%# Eval("Guid") %>'
                obj='<%# GetItem(Container.DataItem) %>'><span class="level1-title"><b></b><span
                    class="level-title">
                    <%# Eval("DisplayName") %></span></span><span class="level1-content"> </span>
            </span>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater runat="server" ID="rpLevel2">
        <ItemTemplate>
            <span class="level2 level" id='level_<%# Eval("Guid") %>' guid='<%# Eval("Guid") %>'
                obj='<%# GetItem(Container.DataItem) %>'><span class="level2-title"><span class="level-title">
                    <%# Eval("DisplayName") %></span></span><span class="level2-content"><asp:Repeater
                        runat="server" ID="rpLevel3" DataSource='<%# GetChild(Eval("Guid")) %>'>
                        <ItemTemplate>
                            <span class="level3 level" id='level_<%# Eval("Guid") %>' guid='<%# Eval("Guid") %>'
                                obj='<%# GetItem(Container.DataItem) %>'><span class="level3-title"><span class="level-title">
                                    <%# Eval("DisplayName") %></span> <span class="level-sub">
                                        <%# Eval("SubName") %></span></span><span class="level3-content">
                                        </span></span>
                        </ItemTemplate>
                    </asp:Repeater>
                    </span></span>
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
