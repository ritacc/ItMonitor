<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpLoadFile.ascx.cs" Inherits="GDK.BCM.UI.UpLoadFile" %>
<div id="div_file" >
    <span class="spanUpLoadFile" runat="server" id="spanIsShowTitle"  style="color:#4876FF; cursor:pointer; text-decoration:underline;font-size:10pt" title="添加小于8M的文件作为附件,或删除已上传附件"  ><img alt='' src="../images/Suffix/attachment.gif"  />上传文件</span>
    <div style="display: none;">
        <input type="text" id="txtFileList"  class="cssFileList" runat="server" />
        <input type="text" id="txtFileFolder" class="cssFileFolder" runat="server" />
        <input type="text" id="txtIsTp" class="cssIsTp" runat="server" />
    </div>
    <div style="width: 100%; text-align: left;"> 
        <asp:Label ID="lblShowadj"  CssClass="showSpan" runat="server"></asp:Label>
    </div>    
</div>
