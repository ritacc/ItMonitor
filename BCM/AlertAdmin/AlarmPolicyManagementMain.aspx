<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlarmPolicyManagementMain.aspx.cs" Inherits="GDK.BCM.AlertAdmin.AlarmPolicyManagementMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
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
            padding:5px;
            overflow-x:hidden;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".gvEdit").each(function (i, o) {
                var obj = $(o);
                if (obj.attr("ISHavePolice") == "0") {
                    obj.remove();
                }
                obj.click(function () {
                    var strVar = "AlarmPolicyManagementEdit.aspx?StationID=" + request("StationID")
                    + "&DeviceTypeID=" + request("DeviceTypeID")
                    + "&DeviceID=" + request("DeviceID")
                    + "&ChanncelID=" + obj.attr("guid")
                    +"&id=temp";

                    $.popup({ title: "修改配置", url: strVar, borderStyle: { height: 570, width: 720 }, ok: function () {
                        $.popup.Refrsh();
                    }
                    }); //$.popup
                });
            });

            $(".gvAdd").each(function (i, o) {
                var obj = $(o);
                if (obj.attr("ISHavePolice") == "1") {
                    obj.remove();
                }
                obj.click(function () {
                    var strVar = "AlarmPolicyManagementEdit.aspx?StationID=" + request("StationID")
                    + "&DeviceTypeID=" + request("DeviceTypeID")
                    + "&DeviceID=" + request("DeviceID")
                    + "&ChanncelID=" + obj.attr("guid");

                    $.popup({ title: "添加配置", url: strVar, borderStyle: { height: 570, width: 750 }, ok: function () {
                        $.popup.Refrsh();
                    }
                    }); //$.popup
                });
            });

            $(".gvDelete").each(function (i, o) {
                var obj = $(o);
                if (obj.attr("ISHavePolice") == "0") {
                    obj.remove();
                }
                obj.click(function () {
                    return confirm("你确定要删除此告警配置吗？");
                });
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>设备测点列表</td>
        <td width="60"><a class="headerBtnAdd" id="aBtnAdd" runat="server">
        </a></td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
    <div class="divgrid">
    
    <div class="overflow_grid">
    <asp:GridView ID="gvAlarmGroups" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="添加" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("channelNo") %>"   ISHavePolice="<%#Eval("ISHavePolice")%>"  class="gvAdd"><img src="../images/Common/add.gif" style="border: 0px;" alt="添加" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField    HeaderText="修改" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("channelNo") %>"  ISHavePolice="<%#Eval("ISHavePolice")%>" class="gvEdit">
                    <img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                <div class="gvDelete" ISHavePolice="<%#Eval("ISHavePolice")%>" >
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="deleteTS" OnCommand="GView_LinkButton_Click" 
                    CommandArgument='<%#Eval("channelNo")%>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField   ItemStyle-HorizontalAlign="Left" DataField="channelname" HeaderText="测点"  />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                    <th>
                        测点
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
    
    </div>
    </div>
    </form>
</body>
</html>
