<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpFileAdnAdmin.aspx.cs" Inherits="GDK.BCM.UI.UpFileAdnAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>文件上传</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <link href="../Styles/gridview.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    
    <script type="text/javascript">

    $(document).ready(function(){
        $("#btnOK").click(function(){
            $.popup.close($("#txtFilePathList").val());
        });

        $("#btnDelete").click(function(){
            var container=$("#gvFileList");
            var checkBoxList=container.find("input:checked");
            var isSelect=false;
            if(checkBoxList.length> 0)
                isSelect=true;
            if(!isSelect)    
            {
                alert('请选择要删除的文件!');
                return false;  
            }
        });
    });
function isHaveSelect()
{
    var container=$("#gvFileList");
    var checkBoxList=container.find("input");
    var v=$("#cbselect").attr("checked");
    checkBoxList.attr("checked",v);
}

function checkDate() {
    var fileid = $("#upFile").val();
   
    if(fileid=="")
    {
        alert("请选择要上传的文件");
        return false;
    }
    if(!imgTs())
    {
    alert("请选择正确的图片文件,系统可支持:\n“BMP；PSD；JPG；GIF；PNG,TIF,TIFF,RAR”格式的文件");
    return false;
    }
    return true;    
}

function imgTs()
{
    var isTp=$("#txtTp").val();
    if(isTp=="1")
    {
        var upFileName=$("#upFile").val();
        var arr=upFileName.split('.');
        if(arr)
        {
            if(isimp(arr[arr.length-1]))
            {
                return true;
            }
            else
			{
			return false;
			}
		}
    }
    return true;
}

function isimp(imgName)
{

    var arrList = ["psd", "jpg", "gif", "bmp", "BMP", "PSD", "JPG", "GIF","PNG","png","tif","tiff","TIF","TIFF","RAR","rar"]
    for(var i=0;i<arrList.length;i++)
    {
        if(arrList[i]==imgName)
            return true;
    }
    return false;
}
</script>
    
    
    <%--<style type="text/css">
    #gvFileList td{font-size:12px}
    .btnHeight{height:26px;}
      #show_feedBack_message
         {
			display: table-cell;
			vertical-align:middle;
			 /*设置水平居中*/
			text-align:center;

			/* 针对IE的Hack */
			*display: block;
			*font-size: 12px;/*约为高度的0.873，200*0.873 约为175*/
			*font-family:Arial;/*防止非utf-8引起的hack失效问题，如gbk编码*/
			border:1px solid #f00;
			background:#fc0;
			height:21px;
			line-height:18px;
			padding-top:3px;
			padding-right:3px;
			padding-left:3px;
			}
			#show_feedBack_message img {
				/*设置图片垂直居中*/
				vertical-align:middle;
				border:none;
				margin-bottom:3px;
			}
    </style>--%>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div  id="wdiv" class="wdiv">
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
                    <asp:TextBox ID="txtTitle"  MaxLength="30" runat="server" Width="243px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    选择文件：
                </td>
                <td>
                    <input type="file" runat="server" contenteditable="false" name="upfile" id="upFile" style="width: 321px; height: 26px;" />&nbsp;
                    <asp:Button ID="btnup" CssClass="btnHeight" OnClientClick="return checkDate()" runat="server" Text="上传" OnClick="btnup_Click" />
                </td>
            </tr>
        </table>

        <div class="window_div_noborder">
            <table class="gridheader_table" cellpadding="0" cellspacing="0">
                <tr>
                <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
                <td>文件列表</td>
                <td width="60"><asp:Button ID="btnDelete" runat="server"  Text="删除" OnClick="btnDelete_Click" /></td>
                <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
                </tr>
            </table>
            
            <asp:GridView ID="gvFileList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvFileList_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input type="checkbox" title="全选/全不选" onclick="isHaveSelect()" id="cbselect" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbMailID" Visible="True" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="fileName" HeaderText="文件标题">
                        <ItemStyle Width="280px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fileSize" HeaderText="文件大小">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fileid" />
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
                        </tr>
                        <tr>
                            <td colspan='2'>
                                请上传小于8M的文件作为附件
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
                    
        
        <div style="display: none;">
            <asp:TextBox ID="txtFilePathList" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtFolder" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtTp" runat="server"></asp:TextBox>
        </div>
        </div>

    </div>

    <div class="window_footer_div">
        <div style="padding-top: 5px;">
         <span id="btnOK" class="ibtnwindow" style="cursor:pointer;"> 确定</span>&nbsp;
            <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
                <img src="../images/icon/delete.gif" border="0" alt="" />关闭 </a>
        </div>
    </div>
    </form>
</body>
</html>
