<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="GDK.BCM.Sysadmin.UserEdit" %>

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
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script  type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">        
        var txtDisplayObj;
        $(document).ready(function () {
            //验证处理
            var displayName = $("#<%= txtDisplayName.ClientID  %>");
            displayName.yz({ title: "姓名", type: "string" });
            displayName.focus();
            $("#<%= txtLogonName.ClientID  %>").yz({ title: "登录名", type: "string" });
            $("#<%= txtUserPwd.ClientID  %>").yz({ title: "密码", type: "string" });
            $("#<%= txtPersonId.ClientID  %>").yz({ title: "人员编号", type: "int", canEmpty: true, max: 9999999, min: 1000000 });

            $("#<%= txtStartTime.ClientID  %>").yz({ title: "启用时间", type: "date" });
            $("#<%= txtEndTime.ClientID  %>").yz({ title: "结束时间", type: "date" });
            //其它事件处理
            txtDisplayObj = $("#txtDisplayName");
            txtDisplayObj.change(function () {
                $("#txtAllPathName").val($("#lblAllpath").html() + "\\" + txtDisplayObj.val());
            });

            $("#txtAllPathName").click(function () {
                $("#txtAllPathName").val($("#lblAllpath").html() + "\\" + txtDisplayObj.val());
            });


        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table border="0" cellpadding="0" cellspacing="0" class="window_table">
            <tr>
                <td align="right" width="40%">
                    姓名：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDisplayName" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    担任职务：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRankName" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    登录名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLogonName" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    密码：
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="txtUserPwd" Width="149" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    人员编号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPersonId" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    IC卡编号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtIcCard" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    系统位置：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAllPathName" />
                    <asp:Label ID="lblAllpath" CssClass="NoShow" runat="server"></asp:Label>
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
            <tr>
                <td align="right">
                    邮件地址：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEMail" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    启用时间：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtStartTime" onfocus="WdatePicker();" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    结束时间：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEndTime" onfocus="WdatePicker();" />
                </td>
            </tr>
            <tr>
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
            <asp:LinkButton ID="lbtSave" runat="server" OnClientClick="return $.yz.getErrorList();" CssClass="ibtnwindow" OnClick="lbtSave_Click">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>
