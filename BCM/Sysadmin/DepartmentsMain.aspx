<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentsMain.aspx.cs" Inherits="GDK.BCM.Sysadmin.DepartmentsMain" %>

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
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#imgNewUser").click(function () {
                var strVar = "UserEdit.aspx?opType=add&parentGUID=" + request("GUID");
                $.popup({ title: "添加用户", url: strVar, borderStyle: { height: 520, width: 450 }, ok: function () {
                    $.popup.Refrsh();
                }
                }); //$.popup
            }); //$("#btnSelectSate").click

            $("#imgNewOrg").click(function () {
                var strVar = "DepartmentsEdit.aspx?opType=add&parentGUID=" + request("GUID");
                $.popup({ url: strVar, title: "新建组织机构", borderStyle: { height: 350, width: 400 },
                    ok: function () { refreshParent(); $.popup.Refrsh(); }
                }); //$.popup                           
            }); //$("#btnSelectSate").click

            $("#imgTransh").click(function () {
                var arrGridlist = $("#<%= gvDataList.ClientID %>");
                var selectOBJ = arrGridlist.find("input:checked");
                if (selectOBJ.length === 0) {
                    alert("请选择要操作的项！");
                    return false;
                }
                if (!confirm("你确定要删除所选择的对象吗？")) {
                    return;
                }
                $("#txtOpInfo").val(selectOBJ.attr("dataType") + "|" + selectOBJ.val());
                $("#<%= btnDelete.ClientID %>").click();

            }); //$("#btnSelectSate").click
            if ('<%= OrgEdit %>' == 'True' || '<%= UserEdit %>' == 'True') {
                var arrList = $(".GridItem");
                arrList.each(function (i, o) {
                    var obj = $(o);
                    /*
                    obj.click(function () {
                    SetCurentRow(o);
                    });
                    */
                    obj.dblclick(function () {//EditCurentRow
                        Update(obj);
                    }); //obj.dblclick

                }); //each
                $("#imgUpdate").click(function () {
                    var arrGridlist = $("#<%= gvDataList.ClientID %>");
                    var selectOBJ = arrGridlist.find("input:checked");
                    if (selectOBJ.length == 0) {
                        alert("请选择要操作的项!"); return false;
                    }
                    var obj = selectOBJ.parentsUntil(".GridItem");
                    Update(obj);
                });


            }

            function Update(obj) {
                var obj = $(obj);
                var inputObj = obj.find("input:first");
                if (inputObj.attr("dataType") == "org") {
                    if ('<%= OrgEdit %>' == 'True') {
                        var editPageUrl = "DepartmentsEdit.aspx?opType=alert&parentGUID=" + request("GUID") + "&GUID=" + inputObj.val();
                        $.popup({ url: editPageUrl, title: "组织机构信息", borderStyle: { height: 350, width: 400 },
                            ok: function () { refreshParent(); $.popup.Refrsh(); }
                        }); //$.popup
                    } //if ('<%= OrgEdit %>' == 'True')
                } else {
                    if ('<%= UserEdit %>' == 'True') {//是否有用户编辑权限
                        var editPageUrl = "UserEdit.aspx?opType=alert&parentGUID=" + request("GUID") + "&GUID=" + inputObj.val();
                        $.popup({ url: editPageUrl, title: "用户信息", borderStyle: { height: 520, width: 450 },
                            ok: function () { $.popup.Refrsh(); }
                        }); //$.popup
                    } //if ('<%= UserEdit %>' == 'True')
                }
            }
        });

        function refreshParent() {
            window.parent.selectObjectReLoad();
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="box">
    <div class="NoShow">
        <asp:Button ID="btnRefresh" runat="server" Text="刷新" OnClick="btnRefresh_Click" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除" />
        <asp:TextBox ID="txtOpInfo" runat="server"></asp:TextBox>
    </div>
    <div>
        <img id="imgNewUser" runat="server" src="../images/sysAdmin/user_add.gif" alt="新建用户" style="cursor: pointer" />&nbsp;&nbsp;
        <img id="imgNewOrg" runat="server" src="../images/sysAdmin/organization_add.gif" alt="新建机构" style="cursor: pointer" />&nbsp;&nbsp;
        <img id="imgUpdate" runat="server" src="../images/sysAdmin/update.png" alt="修改" style="cursor: pointer" />&nbsp;&nbsp;
        <img id="imgTransh" runat="server" src="../images/sysAdmin/recycle.gif" alt="将所选择对象放入回收站" style="cursor: pointer"  />
    </div>
    <asp:GridView ID="gvDataList" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField>
                <ItemStyle CssClass="NoShow" />
                <HeaderStyle CssClass="NoShow" />
                <ItemTemplate>
                    <input id="radioMain" type="radio" name="rdname" value="<%# Eval("GUID")%>" datatype="<%# Eval("dataType")%>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <div style="text-align:left; margin-left:15px;">
                        <img src="../images/sysAdmin/<%# Eval("dataType") %>.gif" alt="" />&nbsp; <span guid="<%# Eval("GUID") %>">
                            <%# Eval("display_name") %></span>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Rank_Code" HeaderText="职务/级别" />
            <asp:BoundField DataField="EnableTime" HeaderText="可用时间" />
            <asp:BoundField DataField="description" HeaderText="备注" />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr >
                    <th>
                        名称
                    </th>
                    <th>
                        职务/级别
                    </th>
                    <th>
                        可用时间
                    </th>
                    <th>
                        备注
                    </th>
                </tr>
                <tr>
                    <td colspan="4">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
