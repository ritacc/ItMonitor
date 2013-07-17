<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="EventTypeList.aspx.cs" Inherits="GDK.BCM.AlertAdmin.EventTypeList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'EventTypeEdit.aspx';
                $.popup({ title: "添加事件定义", url: strVar, borderStyle: { height: 500, width: 600 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'EventTypeEdit.aspx?opType=alert&id=' + obj.attr("Guid");
                    $.popup({ title: "修改事件定义", url: m_url, borderStyle: { height: 500, width: 600 }, ok: function () {
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>事件定义列表</td>
        <td width="60"><a class="headerBtnAdd" id="aBtnAdd" runat="server"><img src="../images/Common/add_btn.gif" /></a></td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
    <div class="divgrid">
    
    <div class="overflow_grid">
    <asp:GridView ID="gvEventType" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("Eventid") %>" class="gvEdit"><img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("Eventid") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
			<asp:BoundField DataField="EventName" HeaderText="事件名称"  />
			<asp:BoundField DataField="AlarmLevel" HeaderText="事件级别"  />
			<asp:BoundField DataField="AlarmTarget" HeaderText="报警组"  />
			<asp:BoundField DataField="AlarmWay" HeaderText="报警方式"  />
			<asp:BoundField DataField="IsEnableFrequency" HeaderText="是否班次报警"  />
			<asp:BoundField DataField="AlarmAudioFile" HeaderText="电话语音文件"  />
			<asp:BoundField DataField="DisAlarmAudioFile" HeaderText="电话语音文件"  />			
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                    <th>
                        事件名称
                    </th>
                    <th>
                        事件级别
                    </th>
                    <th>
                        报警组
                    </th>
                    <th>
                        报警方式
                    </th>
                    <th>
                        是否班次报警
                    </th>
                    <th>
                        电话语音文件
                    </th>
                    <th>
                        电话语音文件
                    </th>
                    <th>
                        短信、Email、语音报警内容格式
                    </th>
                    <th>
                        撤防时间
                    </th>
                </tr>
                <tr>
                    <td colspan="9">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
    <uc2:pagenavigate ID="pg" runat="server" />
    </div>
</asp:Content>

