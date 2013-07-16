<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlarmPolicyManagementEdit.aspx.cs"
    Inherits="GDK.BCM.AlertAdmin.AlarmPolicyManagementEdit" %>

<%@ Register Src="../UI/SelectFile.ascx" TagName="SelectFile" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><#ClassTitle>信息</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($("#txt_ChannelValueType").val() == "模拟量") {
                $("#txt_MaxValue").yz({ title: "高限", canEmpty: false, type: "float" });
                $("#txt_MinValue").yz({ title: "低限", canEmpty: false, type: "float" });
                $("#txtAlarmtimes").yz({ title: "告警次数", canEmpty: false, type: "float" });
                $("#txtAlarmfiltertimes").yz({ title: "报警过滤次数", canEmpty: false, type: "float" });
                
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table"
            runat="server">
            <tr>
                <td colspan="4">
                    测点信息
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    机房名称：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server"  Enabled="false" ID="txtStationid" CssClass="textbox_skin" />
                </td>
                <td class="tdRight">
                    设备类型：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server"  Enabled="false" ID="txtDevicetypeid" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    设备名称：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server"  Enabled="false" ID="txtDeviceid" CssClass="textbox_skin" />
                </td>
                <td class="tdRight">
                    通道：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server"  Enabled="false" ID="txtDevicechannelid" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td>测点类型：</td>
                <td colspan="3">
                    <asp:TextBox runat="server"  Enabled="false" ID="txt_ChannelValueType" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    报警条件：
                </td>
            </tr>
            <tr>
                <td>
                    高限:
                </td>
                <td class="tdRight">
                    <asp:TextBox runat="server" ID="txt_MaxValue" CssClass="textbox_skin" />
                    <asp:CheckBox ID="check_EqualMax" runat="server" Text="高于高限触发" />
                </td>
                <td>
                    事件：
                </td>
                <td>
                    <asp:DropDownList ID="cmbEventHi" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    低限:
                </td>
                <td class="tdRight">
                    <asp:TextBox runat="server" ID="txt_MinValue" CssClass="textbox_skin" />
                    <asp:CheckBox ID="check_EqualMinValue" runat="server" Text="低于触发" />
                </td>
                <td>
                    事件：
                </td>
                <td>
                    <asp:DropDownList ID="cmbEventLo" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    开关量告警值:
                </td>
                <td class="tdLeft">
                    <asp:DropDownList ID="cmb_AlarmValue" runat="server">
                    <asp:ListItem Text="" ></asp:ListItem>
                    <asp:ListItem Text="高电平" ></asp:ListItem>
                    <asp:ListItem Text="低电平" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    事件：
                </td>
                <td>
                    <asp:DropDownList ID="cmbEvent" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    告警次数：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAlarmtimes" CssClass="textbox_skin" />
                </td>
                <td>
                    报警过滤次数：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAlarmfiltertimes" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    电话报警语音文件：
                </td>
                <td class="tdLeft"  colspan="3">
                    <uc1:SelectFile ID="txtAlarmaudiofile" Floder="UpLoad\Audio" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    电话解除语音文件：
                </td>
                <td class="tdLeft"  colspan="3">
                    <uc1:SelectFile ID="txtDisalarmaudiofile" Floder="UpLoad\Audio" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    短信邮件语音报警内容：
                </td>
                <td class="tdLeft"  colspan="3">
                    <asp:TextBox runat="server" ID="txtSmsmsg" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbDefultAlert" runat="server" Text="默认报警内容" AutoPostBack="True"
                        OnCheckedChanged="cbDefultAlert_CheckedChanged" />
                </td>
                <td class="tdLeft" colspan="3">
                    <asp:TextBox runat="server" ID="txt_defaultSmsMsg" Enabled="false"></asp:TextBox><asp:Button ID="btnAlertDefult"
                        runat="server" OnClick="btnAlertDefult_Click" Style="height: 21px" Text="修改默认内容" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    报警时声光告警器：
                </td>
                <td class="tdLeft"  colspan="3">
                    <asp:DropDownList ID="LightID" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    解除时声光告警器：
                </td>
                <td class="tdLeft" colspan="3">
                    <asp:DropDownList ID="ReleaseLightID" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    &nbsp;
                </td>
                <td class="tdLeft">
                    <asp:CheckBox ID="cbIsenable" runat="server" Text="启用本策略" />
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
