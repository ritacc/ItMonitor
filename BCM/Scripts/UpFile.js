

$(document).ready(function () {
   $(".spanUpLoadFile").each(function (i, o) {
        var topDiv = $(o).parents("div:first");
        $(o).click(function () {
            var vFileList = topDiv.find(".cssFileList:first");
            var vFileFolder = topDiv.find(".cssFileFolder:first").val();
            var vIsTp = topDiv.find(".cssIsTp:first").val();
            var strVar = "../UI/upfileAdnAdmin.aspx?fileList=" + escape(vFileList.val()) + "&folder=" + vFileFolder + "&iscz=" + vIsTp;
            $.popup({ title: "文件上传管理", url: strVar, borderStyle: { height: 450, width: 520 }, ok: function (va) {
                if (va == "tr")
                    va = "";
                vFileList.val(va);
                refreshShow(va, topDiv.find(".showSpan"), vFileFolder);
            }
            }); //$.popup
        }); //click
    }); //.each
});     //ready

function refreshShow(strValue, lblShowadj, m_folder) {
    var arr = strValue.split("|");
    lblShowadj.html("");
    if (arr.length < 3) {        
        lblShowadj.html("");
        return;
    }
    var len = arr.length / 3;

    var tabletmp = "";
    var tempTop = "<div style=\"border:solid 1px #CCCCCC;font-size:11pt;text-align:left\">";
    tempTop += "\t<div style='background-color:#eaeff3;padding:5px;border-bottom:solid 1px #CCCCCC;'><span style='font-weight:bold;'>已上传文件</span>(";
    tempTop += len + "个)</div><div>";
    
    for (i = 0; i < arr.length; i += 3) {
        tempTop += "\t\t\t<table  style=\'font-size:10pt;float:left\'>\n";

        tempTop += "\t\t\t\t<tr>\n";
        tempTop += "\t\t\t\t\t<td rowspan=\'2\' style='border:none;'>";
        tempTop += "<a href=\'../Main/DownFile.aspx?path=" + m_folder + "/";
        tempTop += arr[i]; // 文件流水号

        tempTop += "&name=";
        tempTop += escape(arr[i + 1]); // 文件名

        tempTop += "\' target=\'_blank\'\' target=\'_blank\' ><img style=\'width:32px;heigth:32px;border:0\' src=\'";
        // tabletmp+="<img style=\'width:32px;heigth:32px;border:0\' src=\'";
        tempTop += GetIco(arr[i], m_folder);
        tempTop += "\'/>";
        tempTop += "</a>";
        tempTop += "\t\t\t\t\t</td>\n";

        tempTop += "\t\t\t\t\t<td style='border:none;'><span>";
        tempTop += arr[i + 1]; // 文件名

        tempTop += "</span><span style=\'color:gray\'>&nbsp;(";
        tempTop += arr[i + 2]; // 文件大小
        tempTop += ")</span>";
        tempTop += "\t\t\t\t\t</td>\n";
        tempTop += "\t\t\t\t</tr>\n";
        tempTop += "\t\t\t</table>\n";

    }
    tempTop += "\t\t<div style=\'clear:both\'></div>\n\t</div></div>\n";
    lblShowadj.append(tempTop);
}

function GetIco(file, m_folder) {
    var strs = file.split(".");
    if (strs.length > 1) {
        suffix = strs[strs.length - 1];

        if (".psd.jpg.gif.bmp.bmp.psd.jpg.gif.png".indexOf(suffix) > -1) {
            return "../images/Suffix/img.gif";
        }
        if ("doc.docx.xls.xlsx.mdb.accdb.ppt.pptx.rar.zip.exe.txt.msc.iso.ini.inf.reg.bat.mht.html.htm.xml".indexOf(suffix) > -1) {
            return "../images/Suffix/" + suffix + ".gif";
        }
    }
    return "../images/Suffix/nosuffix.gif";
}