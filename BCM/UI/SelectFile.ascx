<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectFile.ascx.cs" Inherits="GDK.BCM.UI.SelectFile" %>

<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $("#<%= selectFIle.ClientID %>").click(function () {
            var mFolder = $("#<%= txtFloder.ClientID %>").val();
            if (mFolder == "") {
                alert("没有设置文件夹！");
                return;
            }
            var strVar = "../UI/SelectFileMain.aspx?Folder=" + mFolder;
            $.popup({ title: "选择文件", url: strVar, borderStyle: { height: 450, width: 600 }, ok: function (va) {
                $("#<%= txtFileName.ClientID %>").val(va);
            }
            }); //$.popup
        });

    });
</script>

<div><asp:TextBox runat="server"  Width="200px" ID="txtFileName"></asp:TextBox> 
<div style=" display:none;">
<asp:TextBox runat="server"  Width="200px" ID="txtFloder"></asp:TextBox>
</div>
    <asp:Image   ID="selectFIle" runat="server"  ImageUrl="~/images/icon/changeList.png">
    </asp:Image>
</div>