<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HealthConfigMain.aspx.cs"
    Inherits="GDK.BCM.AlertAdmin.HealthConfigMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../styles/permission .css" rel="Stylesheet" />
    <link href="../styles/right.css" rel="Stylesheet" />


    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <style type="text/css">
        body
        {
            background-color: #F8F8F8;
            font-size: 12px;
        }
        #box
        {
            padding: 5px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'HealthConfigEdit.aspx?opType=add&DeviceID=' + request("DeviceID");
                $.popup({ title: "添加健康度配置", url: strVar, borderStyle: { height: 300, width: 400 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'HealthConfigEdit.aspx?opType=alert&id=' + obj.attr("Guid");
                    $.popup({ title: "修改健康度配置", url: m_url, borderStyle: { height: 300, width: 400 }, ok: function () {
                        $.popup.Refrsh();
                    }
                    }); //$.popup
                });
            });

            var editArr = $(".deleteTS");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    return confirm("你确定要删除此数据吗？");
                });
            });

        });
        function refreshParent() {
            window.parent.selectObjectReLoad();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
            <td width="6">
                <img src="../images/gridview/gridheader_03.gif" alt="" />
            </td>
            <td>
                健康度配置列表
            </td>
            <td width="60">
                <a class="headerBtnAdd" id="aBtnAdd" runat="server">
                    <img src="../images/Common/add_btn.gif" /></a>
            </td>
            <td width="6">
                <img src="../images/gridview/gridheader_06.gif" alt="" />
            </td>
        </tr>
    </table>
    <div class="divgrid">
      <div class="iframe_top">设备：<asp:Label ID="lblName" runat="server" ></asp:Label>
        </div>
        <div class="overflow_grid">
            <asp:GridView ID="gvHealthConfig" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle BackColor="#bdeaff" Width="25" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                        <ItemTemplate>
                            <a guid="<%# Eval("ID") %>" class="gvEdit">
                                <img src="../images/Common/edit.gif" style="border: 0px;" alt="权限设置" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click"
                                CommandArgument='<%#Eval("ID") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DeviceName" HeaderText="设备" />
                    <asp:BoundField DataField="ChannelName" HeaderText="通道" />
                    <asp:BoundField DataField="EffectLevel" HeaderText="影响度" />
                </Columns>
                <EmptyDataTemplate>
                    <table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all" border="0"
                        id="ContentPlaceHolder1_gvDataList" style="border-collapse: collapse;">
                        <tr class="gridview_skin_header">
                            <th>
                                设备
                            </th>
                            <th>
                                通道
                            </th>
                            <th>
                                影响度
                            </th>
                        </tr>
                        <tr>
                            <td colspan="3"  align="center">
                                没有数据
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
