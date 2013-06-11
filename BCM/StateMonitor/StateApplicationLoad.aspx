<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateApplicationLoad.aspx.cs" Inherits="GDK.BCM.StateMonitor.StateApplicationLoad" %>

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
                            <table class="tableContent">
                                <tr>
                                    <td class="w60"> <span class="divTitle Title2">&nbsp;</span></td>
                                    <td>
                                        <span class="spanLadDate">
                                            <%# Eval("DISPLAY_NAME")%>
                                        </span>
                                    </td>
                                    <td class="w120">
                                        业务系统
                                    </td>
                                    <td class="w120">
                                        状态
                                    </td>
                                    <td class="w120">
                                        预警
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
