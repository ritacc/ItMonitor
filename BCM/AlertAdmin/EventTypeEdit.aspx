<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventTypeEdit.aspx.cs" Inherits="GDK.BCM.AlertAdmin.EventTypeEdit" %>

<%@ Register src="../UI/SelectFile.ascx" tagname="SelectFile" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>事件定义信息</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table"
            runat="server">
            <tr>
                <td class="tdRight">
                    事件名称：
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtEventname" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    事件级别：
                </td>
                <td class="tdLeft">
                    <asp:DropDownList ID="dpdAlarmlevel" runat="server"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="tdRight">
                   
                </td>
                <td class="tdLeft">
                    
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    报警方式：
                </td>
                <td class="tdLeft">
                    <asp:CheckBox  ID="check_Sms" Text="短信报警" runat="server"/>
                    <asp:CheckBox  ID="check_Phone" Text="电话报警" runat="server"/>
                    <asp:CheckBox  ID="check_Media" Text="多媒体报警" runat="server"/>
                    <asp:CheckBox  ID="check_Emali" Text="E_mail" runat="server"/>
                    <asp:CheckBox ID="txtIsenablefrequency" Text="是否班次报警"  runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    电话语音文件：
                </td>
                <td class="tdLeft">
                    <uc1:SelectFile ID="txtAlarmaudiofile" Floder="UpLoad\Audio" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    电话解出语音文件：
                </td>
                <td class="tdLeft">                    
                    <uc1:SelectFile ID="txtDisalarmaudiofile" Floder="UpLoad\Audio" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdRight">
                    短信邮件语音报警内容:
                </td>
                <td class="tdLeft">
                    <asp:TextBox runat="server" ID="txtSmsmsg" CssClass="textbox_skin" />
                </td>
            </tr>
            <tr>
               
                <td  colspan="2">
                    <table cellspacing="0">
                        <tr>
                            <td>
                                报警组：
                            </td>
                            <td>
                                撤防时间：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow-y:scroll; overflow-x:hidden; width:200px;  height:100px; padding:2px;">
                                    <asp:CheckBoxList ID="cbAlertGroup" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                            <td>
                                <div style="overflow-y:scroll; overflow-x:hidden; width:200px; height:100px; padding:2px;">
                                    <asp:CheckBoxList ID="cbDisarmid" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        </table>
    </div>
    <div class="window_footer_div">
        <div style="padding-top:5px;">
        <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow" OnClick="lbtSave_Click" OnClientClick="return $.yz.getErrorList()">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
        </asp:LinkButton>&nbsp;
        <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
            <img src="../images/icon/delete.gif" border="0" alt="" />关闭
        </a>
        </div>
    </div>
    </form>
</body>
</html>

