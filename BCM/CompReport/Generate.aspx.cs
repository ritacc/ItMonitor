using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GDK.BCM.CompReport
{
    public partial class Generate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePDF PDF = new GeneratePDF();
            PDF.SystemTitle = "辑私协查系统";
            PDF.SubTitle = "做了三年啊，我的个天A";
            PDF.ReportData = "2013年11月";
            PDF.UserPart = "信息中心主任科室";
            PDF.chLine = chLine;

            PDF.SavePath = Server.MapPath("../Upload/PDF/");

            string filePath = PDF.Generate();
            DownLoadFile(filePath);
            //PDF.DeleteFile(filePath);
        }

        public void DownLoadFile(string filePath)
        {
            //以字符流的形式下载文件
            string fileName = string.Format("{0}{1}{2}{3}{4}.pdf", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                DateTime.Now.Hour, DateTime.Now.Minute);
            if (File.Exists(filePath))
            {
                Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开
                Response.AddHeader("Content-Disposition", "attachment;  filename=" 
                    + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));

                FileStream fs = new FileStream(filePath, FileMode.Open);
                while (true)
                {
                    //开辟缓冲区空间
                    byte[] buffer = new byte[1024];
                    //读取文件的数据
                    int leng = fs.Read(buffer, 0, 1024);
                    if (leng == 0)//到文件尾，结束
                        break;
                    if (leng == 1024)//读出的文件数据长度等于缓冲区长度，直接将缓冲区数据写入
                        Response.BinaryWrite(buffer);
                    else
                    {
                        //读出文件数据比缓冲区小，重新定义缓冲区大小，只用于读取文件的最后一个数据块
                        byte[] b = new byte[leng];
                        for (int i = 0; i < leng; i++)
                            b[i] = buffer[i];
                        Response.BinaryWrite(b);
                    }
                }
                fs.Close();
            }
            else
            {
                Response.Write("<span style='font-weight:bold'>温馨提示：</span><br/>该文件不存在，或路径错误。");
            }


        }
    }
}