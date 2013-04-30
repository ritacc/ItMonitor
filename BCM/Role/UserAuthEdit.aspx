<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAuthEdit.aspx.cs" Inherits="GDK.BCM.Role.UserAuthEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户授予角色</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <style type="text/css">
        .iframe_top
        {
            height: 29px;
            line-height: 29px;
            background: #e3f0f6;
            font-family: Arial,宋体;
            border:1px solid #8fb6df;
            padding:0px 5px;
        }
        .role_table
        {
            background-color:#fafafc;
            border:1px solid #cdced0;
	        font-size:12px;
	        width:95%;
	        margin:10px auto;
        }
        .CheckBoxList td
        {
            padding:8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
            <div class="iframe_top">
                用户姓名:<asp:Label ID="txt_name" runat="server"></asp:Label>
                &nbsp; 系统登录名:<asp:Label ID="txt_UserName" runat="server"></asp:Label>
            </div>
            <div class="role_table">
                <strong style="line-height:30px; margin:10px;">请选择要授予的角色：</strong>
            <asp:CheckBoxList RepeatDirection="Vertical" Width="100%" RepeatColumns="2" ID="cblRoseList" runat="server" CellPadding="0" CellSpacing="0" CssClass="CheckBoxList">
            </asp:CheckBoxList>
            </div>
    </div>
    <div class="window_footer_div">
        <div style="padding-top: 5px;">
            <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow" OnClick="btn_Save_Click">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>
