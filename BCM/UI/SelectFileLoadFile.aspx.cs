using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GDK.BCM.UI
{
    public partial class SelectFileLoadFile : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string root = Server.MapPath("~");
           // string FileList =
            //Response.Write(FileList);
            gvFileList.DataSource = GetFileList(root);
            gvFileList.DataBind();
        }

        public List<MyFileInfo> GetFileList(string RootFilePath)
        {
            if (!RootFilePath.EndsWith("\\"))
                RootFilePath+="\\";
            string folder = Request.QueryString["Folder"];
            RootFilePath += folder;
            if(!Directory.Exists(RootFilePath))
            {
                AlertNormal(string.Format("文件夹{0}不存在！",RootFilePath));
                return null;
            }
            string[] strArr = System.IO.Directory.GetDirectories(RootFilePath);
            //string temp = string.Empty;
            DirectoryInfo info = new DirectoryInfo(RootFilePath);

            FileInfo[] finfoArr = info.GetFiles();
            List<MyFileInfo> listFile = new List<MyFileInfo>();
            foreach (FileInfo fobj in finfoArr)
            {
                MyFileInfo mfInfo = new MyFileInfo(fobj.Name, fobj.Length.ToString(), fobj.LastWriteTime);
                listFile.Add(mfInfo);
            }
            return listFile;
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
    }

    public class MyFileInfo
    {
        public MyFileInfo(string _FilePath, string _FileSize, DateTime _AlertTime)
        {
            mFilePath = _FilePath;
            mFileSize = _FileSize;
            mAlertTime = _AlertTime;
        }
        private string mFilePath;

        public string FilePath
        {
            get { return mFilePath; }
            set { mFilePath = value; }
        }
        private string mFileSize;

        public string FileSize
        {
            get { return mFileSize; }
            set { mFileSize = value; }
        }
        private DateTime mAlertTime;

        public DateTime AlertTime
        {
            get { return mAlertTime; }
            set { mAlertTime = value; }
        }
    }
}