using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDK.BCM.UI
{
    public partial class UpLoadFile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetFiles();
            Folder = "UpLoad";
        }
        public string FileList
        {
            set { txtFileList.Value = Server.HtmlEncode(value); GetFiles(); }
            get { return txtFileList.Value; }
        }

        public string IStp
        {
            set { txtIsTp.Value = Server.HtmlEncode(value); }
        }
        public string Folder
        {
            set { txtFileFolder.Value = Server.HtmlEncode(value); }
        }

        public bool IsShowTitle
        {
            set { if (!value) spanIsShowTitle.Visible = false; }
        }
       

        public void GetFiles()
        {
            string files = txtFileList.Value;
            string[] filesinfos = files.Split(new char[] { '|' });
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int len = filesinfos.Length / 3;
            string floder = txtFileFolder.Value;
            if (len > 0)
            {
                sb.Append("\n<div style=\"border:solid 1px #CCCCCC;font-size:11pt;text-align:left\">\n");
                sb.Append("\t<div style='background-color:#eaeff3;padding:5px;border-bottom:solid 1px #CCCCCC;'><span style='font-weight:bold;'>已上传文件</span>(");
                sb.Append(len);
                sb.Append("个)</div>\n");
                sb.Append("\t\t<div style='padding:5px 0 5px 0;'>\n");

                if (filesinfos.Length % 3 == 0)
                {
                    for (int i = 0; i < len * 3; i += 3)
                    {
                        sb.Append("\t\t\t<table  style='font-size:10pt;float:left'>\n");
                        sb.Append("\t\t\t\t<tr>\n");

                        sb.Append("\t\t\t\t\t<td rowspan='2' style='border:none;'>");
                        sb.Append("<a href='../Main/DownFile.aspx?path=");
                        sb.Append(Server.HtmlEncode(floder + "/" + filesinfos[i])); // 文件流水号
                        sb.Append("&name=");
                        sb.Append(Server.UrlEncode(filesinfos[i + 1])); // 文件名
                        sb.Append("' target='_blank' target='_blank' ><img style='width:32px;heigth:32px;border:0' src='");
                        sb.Append(Server.HtmlEncode(GetIco(filesinfos[i])));
                        sb.Append("'/></a>");
                        sb.Append("\t\t\t\t\t</td>\n");
                        sb.Append("\t\t\t\t\t<td style='border:none;'><span>");
                        sb.Append(Server.HtmlEncode(filesinfos[i + 1])); // 文件名
                        sb.Append("</span><span style='color:gray'>&nbsp;(");
                        sb.Append(Server.HtmlEncode(filesinfos[i + 2])); // 文件大小
                        sb.Append(")</span>");
                        sb.Append("\t\t\t\t\t</td>\n");
                        sb.Append("\t\t\t\t</tr>\n");
                        sb.Append("\t\t\t</table>\n");
                    }
                }
                else
                {
                    sb.Append("附件加载失败！");
                }
                sb.Append("\t\t<div style='clear:both'></div>\n");
                sb.Append("\t</div>\n");
                sb.Append("</div>\n");
            }
            lblShowadj.Text = sb.ToString();
        }

        private string GetIco(string file)
        {
            string[] strs = file.Split(new char[] { '.' });
            if (strs.Length > 1)
            {
                string suffix = strs[strs.Length - 1].ToLower();
                string[] imgs = { };
                if (".psd.jpg.gif.bmp.bmp.psd.jpg.gif.png".IndexOf(suffix) > -1)
                {
                    return "../images/Suffix/img.gif";
                }
                else if ("doc.docx.xls.xlsx.mdb.accdb.ppt.pptx.rar.zip.exe.txt.msc.iso.ini.inf.reg.bat.mht.html.htm.xml".IndexOf(suffix) > -1)
                {
                    return "../images/Suffix/" + suffix + ".gif";
                }
            }
            return "../images/Suffix/nosuffix.gif";
        }
        protected void UpLoadFile1_btnChangetV_Click(object sender, EventArgs e)
        {
            GetFiles();
        }
        protected void UpLoadFile2_btnChangetV_Click(object sender, EventArgs e)
        {
            GetFiles();
        }
    }
}