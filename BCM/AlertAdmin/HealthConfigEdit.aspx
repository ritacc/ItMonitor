<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HealthConfigEdit.aspx.cs"
    Inherits="GDK.BCM.AlertAdmin.HealthConfigEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>健康度配置</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table  id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table" runat="server">
            <tr>
                <td class="tdRight">
                    Deviceid：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtDeviceid" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    Sdid：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtSdid" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    Pdid：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtPdid" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    Channelno：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtChannelno" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    Effectlevel：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtEffectlevel" CssClass="textbox_skin" />
                </td>
            </tr>
        </table>
    </div>
    <div class="window_footer_div">
        <div style="padding-top: 5px;">
            <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow" OnClick="lbtSave_Click"
                OnClientClick="return $.yz.getErrorList()">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>