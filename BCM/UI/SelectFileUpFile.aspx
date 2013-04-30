<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectFileUpFile.aspx.cs" Inherits="GDK.BCM.UI.SelectFileUpFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文件上传</title>
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnOK").click(function () {
                $.popup.close($("#txtFilePathList").val());
            });
        });
        

        function checkDate() {
            var fileid = $("#upFile").val();

            if (fileid == "") {
                alert("请选择要上传的文件");
                return false;
            }

            return true;
        }
    </script>
    <style type="text/css">
    body
    {
         margin:0px; padding:0px;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div id="wdiv" class="wdiv">
        <table class="window_table" cellspacing="0">
            <tr class="normal_table">
                <th colspan="2">
                    文件上传
                </th>
            </tr>
            <tr>
                <td>
                    文件标题：
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" MaxLength="30" runat="server" Width="243px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    选择文件：
                </td>
                <td>
                    <input type="file" runat="server" contenteditable="false" name="upfile" id="upFile"
                        style="width: 321px; height: 26px;" />&nbsp;
                    <asp:Button ID="btnup" CssClass="btnHeight" OnClientClick="return checkDate()" runat="server"
                        Text="上传" OnClick="btnup_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>