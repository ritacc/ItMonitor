<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MissingParameter.aspx.cs"
    Inherits="HCGL.main.MissingParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>缺少参数</title>
      <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript">
    <!--
        function aClick() {
            var formCount = window.top.$.Layers.length;
             if (formCount > 0) {
               $.popup.close();
            } else {
                window.location = "../login.aspx";
            }
        }
    -->
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="position: absolute; top: 50%; left: 0px; width: 100%; text-align: center">
        <a href="javascript:void(0);" onclick="aClick();" title="没有足够的参数">
            <asp:Label runat="server" ID="labMsg" Text="没有足够的参数" /></a>
    </div>
    </form>
</body>
</html>
