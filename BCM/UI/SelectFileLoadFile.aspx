<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectFileLoadFile.aspx.cs" Inherits="GDK.BCM.UI.SelectFileLoadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/Common.css" rel="Stylesheet" />

    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
     <script type="text/javascript" language="javascript">
         $(document).ready(function () {
             var gv = $("#gvFileList");
             var inputArr = gv.find("input");

             gv.find("tr").each(function (i, o) {
                 var obj = $(o);
                 obj.click(function () {
                     inputArr.attr("checked", false);
                     SetCurentRow(o);
                 });

                 obj.dblclick(function () {
                     $.popup.close(GetValue());
                 });
             });

            

            function GetValue() {
                 var selectObj = $(".ObjSelectItem");
                 if (selectObj.length == 0) {
                     return null;
                 }
                 var selectItem = selectObj.find(".val");
                 return selectItem.attr("GUID");
             }
         });

    </script>
<style type="text/css">
    body{margin:0px; padding:0px; overflow:hidden;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMain" style=" overflow-y:scroll; overflow-x:hidden;  height:405px; padding:2px; ">
              <asp:GridView ID="gvFileList" runat="server"  AutoGenerateColumns="False">
                <Columns>
                <asp:TemplateField HeaderText="文件名">
                <ItemTemplate>
                    <span  title="双击选择文件" class="val" GUID='<%# Eval("FilePath")%>' >
                    <%# Eval("FilePath")%></span>
                </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="FileSize" HeaderText="文件大小">
                    </asp:BoundField>
                    <asp:BoundField DataField="AlertTime" HeaderText="最后修改时间" />
                </Columns>
                <EmptyDataTemplate>
                    <table class="empty_gridview" cellspacing="0">
                        <tr>
                            <th>
                                文件标题
                            </th>
                            <th>
                                文件大小
                            </th>
                            <th>最后修改时间</th>
                        </tr>
                        <tr>
                            <td colspan='2'>
                                请上传小于8M的文件作为附件
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
    </div>
    </form>
</body>
</html>
