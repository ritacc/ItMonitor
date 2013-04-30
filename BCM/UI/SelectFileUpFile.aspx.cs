using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GDK.BCM.UI
{
    public partial class SelectFileUpFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool _isCzFj = false;

        public bool IsCzFj
        {
            set { _isCzFj = value; }
            get { return _isCzFj; }
        }


       


        /// <summary>
        /// 弹出提示窗口，没有加修改大小
        /// </summary>
        /// <param name="msg"></param>
        protected void Close(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){$.popup.close('" + msg + "');});</script>");
        }
        /// <summary>
        /// 弹出提示窗口，没有加修改大小
        /// </summary>
        /// <param name="msg"></param>
        protected void AlertNormal(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){alert('" + msg + "');});</script>");
        }

        protected void btnup_Click(object sender, EventArgs e)
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            int filesCount = files.Count;
            if (filesCount == 0)
                return;
            string folder = Request.QueryString["Folder"];
           
                if (files[0].ContentLength > 8388608)//5242880 5M
                {
                    AlertNormal( "上传文件“" + files[0].FileName + "”大于8M，不能上传。");
                    return;
                }

                HttpPostedFile postedFile = files[0];
                string fileName = "", fileExtension = "";

                fileName = System.IO.Path.GetFileName(postedFile.FileName);
                fileExtension = System.IO.Path.GetExtension(fileName);
                if (txtTitle.Text != "")
                {
                    fileName = txtTitle.Text + fileExtension;
                }
                if (fileName != "")
                {
                    try
                    {
                        string Root = Server.MapPath("~");
                        if (!Root.EndsWith("\\"))
                            Root += "\\";
                        if (!Directory.Exists(Root))
                        {
                            AlertNormal(string.Format("文件夹{0}不存在！", folder));
                            return ;
                        }
                        string Path = Root + folder + "\\" + fileName;
                        if (File.Exists(Path))
                        {
                            AlertNormal(string.Format("文件：{0}，已经存在！请修改其名称！", fileName));
                            return;
                        }

                        
                        postedFile.SaveAs(Path);
                        Close(fileName);
                    }
                    catch (Exception ex)
                    {
                        AlertNormal(ex.Message);
                    }
                }
               
        }
        protected void gvFileList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Visible = false;
            }
        }
    }
}