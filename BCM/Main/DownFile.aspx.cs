using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GDK.BCM.Main
{
    public partial class DownFile : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {

            if (base.User != null)
            {
                IsAuthenticate = false;
            }
            base.OnLoad(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            try
            {
                //.BMP;.PNG;.JPEG;.GIF;.TIFF;.DXF;.CGM;.CDR;.WMF;.EPS;.EMF;.PICT;
                string[] extendFileName = { ".psd", ".jpg", ".gif", ".bmp", ".BMP", ".PSD", ".JPG", ".GIF" };

                if (null == Request.QueryString["path"] || null == Request.QueryString["name"])
                {
                    return;
                }

                string path = Request.QueryString["path"].ToString();
                string name = Request.QueryString["name"].ToString();
                string fileName = name;//客户端保存的文件名
                string filePath = Server.MapPath("../" + path);//路径
                string[] arr = fileName.Split('.');
                string cjm = "." + arr[arr.Length - 1];
                bool isimg = false;
                for (int i = 0; i < extendFileName.Length && !isimg; i++)
                {
                    if (cjm == extendFileName[i])
                        isimg = true;
                }
                if (isimg && Request.QueryString["isopen"] == null)
                {
                    imgShow.ImageUrl = "../" + path;
                    imgShow.Visible = true;
                    return;
                }

                //以字符流的形式下载文件
                if (File.Exists(filePath))
                {
                    Response.ContentType = "application/octet-stream";
                    //通知浏览器下载文件而不是打开
                    Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));

                    fs = new FileStream(filePath, FileMode.Open);
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
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write("<span style='font-weight:bold'>温馨提示：</span><br/>该文件不存在，或路径错误。");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<span style='font-weight:bold'>温馨提示：</span><br/>错误信息：" + ex.Message + "<br />请与系统管理员联系。");

            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
    }
}