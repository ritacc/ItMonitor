<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentsEdit.aspx.cs"
    Inherits="GDK.BCM.Sysadmin.DepartmentsEdit" %>

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
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
     <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script language="javascript" type="text/javascript">
        var txtDisplayObj;
        $(document).ready(function () {
            $("#btnCANCEL").click(function () {
                $.popup.cancel();
            }); //click cancel           
            txtDisplayObj = $("#txtDisplayName");
            txtDisplayObj.change(function () {
                $("#txtAllPathName").val($("#lblAllpath").html() + "\\" + txtDisplayObj.val());
            });

            $("#txtAllPathName").click(function () {
                $("#txtAllPathName").val($("#lblAllpath").html() + "\\" + txtDisplayObj.val());
            });

            $("#txtDisplayName").yz({ title: "名称", type: "string" });
            $("#txtCustomsCode").yz({ title: "关区代码", type: "int", max: 9999, min: 1000,canEmpty:true });
            $("#txtAllPathName").yz({ title: "系统位置", type: "string" });
            $("#<%= txtDisplayName.ClientID %>").focus();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table border="0" cellpadding="0" cellspacing="0" class="window_table">
            <tr class="AlternatingRowStyle">
                <td align="right" width="35%">
                    名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDisplayName" />
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td align="right">
                    关区代码：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustomsCode" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    行政级别：
                </td>
                <td>
                    <asp:DropDownList ID="dpdRankCode" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td align="right">
                    机构类别：
                </td>
                <td>
                    <asp:DropDownList ID="dplOrgClass" runat="server">
                        <asp:ListItem Value="0" Text="----"></asp:ListItem>
                        <asp:ListItem Value="128" Text="内设机构"></asp:ListItem>
                        <asp:ListItem Value="1" Text="总署"></asp:ListItem>
                        <asp:ListItem Value="2" Text="分署"></asp:ListItem>
                        <asp:ListItem Value="8" Text="特派办"></asp:ListItem>
                        <asp:ListItem Value="4" Text="总署"></asp:ListItem>
                        <asp:ListItem Value="32" Text="隶属海关"></asp:ListItem>
                        <asp:ListItem Value="64" Text="派驻机构"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    机构属性：
                </td>
                <td>
                    <asp:DropDownList ID="dplOrgType" runat="server">
                        <asp:ListItem Text="----" Value="0"></asp:ListItem>
                        <asp:ListItem Text="虚拟机构" Value="1"></asp:ListItem>
                        <asp:ListItem Text="一般部门" Value="2"></asp:ListItem>
                        <asp:ListItem Text="办公室（厅）" Value="4"></asp:ListItem>
                        <asp:ListItem Text="综合处" Value="8"></asp:ListItem>
                        <asp:ListItem Text="辑私局" Value="16"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td align="right">
                    系统位置：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAllPathName" />
                    <asp:Label ID="lblAllpath"  CssClass="NoShow" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="AlternatingRowStyle">
                <td align="right">
                    备注信息：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" />
                </td>
            </tr>
        </table>
    </div>
    <div class="window_footer_div">
        <div style="padding-top: 5px;">
            <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow"  OnClientClick="return $.yz.getErrorList();" OnClick="lbtSave_Click">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>
