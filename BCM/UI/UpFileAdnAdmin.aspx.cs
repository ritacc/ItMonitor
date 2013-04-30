using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GDK.BCM.UI
{
    public partial class UpFileAdnAdmin : PageBase
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
            if (!Page.IsPostBack)
            {
                //folder="+FileFolder+"&iscz=

                if (null == Request.QueryString["fileList"] ||
                    null == Request.QueryString["iscz"] ||
                    null == Request.QueryString["folder"])
                {
                    return;
                }
                txtFilePathList.Text = Server.HtmlEncode(Request.QueryString["fileList"].ToString());
                txtTp.Text = Server.HtmlEncode(Request.QueryString["iscz"].ToString());
                txtFolder.Text = Server.HtmlEncode(Request.QueryString["folder"].ToString());
                showAdjunct();
            }
        }

        private bool _isCzFj = false;

        public bool IsCzFj
        {
            set { _isCzFj = value; }
            get { return _isCzFj; }
        }

        private void showAdjunct()
        {
            string fileList = txtFilePathList.Text;
            string[] strArr = fileList.Split('|');
            DataTable dt = getDataBable();
            if (strArr.Length > 1)
            {
                for (int i = 0; i < strArr.Length; i += 3)
                {
                    if (strArr[i] != "" && strArr[i] != null)
                    {
                        DataRow dr = dt.NewRow();
                        dr["fileid"] = strArr[i];
                        dr["fileName"] = strArr[i + 1];
                        dr["fileSize"] = strArr[i + 2];
                        dt.Rows.Add(dr);
                    }
                }
            }
            gvFileList.DataSource = dt;
            if (dt.Rows.Count == 10)
            {
                btnup.Enabled = false;
                upFile.Disabled = true;
            }
            else
            {
                upFile.Disabled = false;
                btnup.Enabled = true;
            }
            gvFileList.DataBind();
        }

        private DataTable getDataBable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fileid", typeof(string));
            dt.Columns.Add("fileName", typeof(string));
            dt.Columns.Add("fileSize", typeof(string));
            return dt;
        }

        private void deleteFileEx(string path)
        {
            string strFolder = txtFolder.Text;
            string fullpath = "../" + strFolder + "/" + path;
            fullpath = Server.MapPath(fullpath);

            try
            {
                System.IO.FileInfo Fi = new System.IO.FileInfo(fullpath);
                if (Fi.Exists)
                {
                    Fi.Delete();
                }
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }

        private int getIndex(string[] strArr, string name)
        {
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == name)
                    return i;
            }
            return -1;
        }

        private void deleteFile(string path)
        {
            string full = txtFilePathList.Text;
            string[] strArr = full.Split('|');
            if (strArr.Length > 0)
            {
                int i_index = getIndex(strArr, path);
                if (i_index != -1)
                {
                    strArr[i_index] = "";
                    strArr[i_index + 1] = "";
                    strArr[i_index + 2] = "";
                }
                full = combinArr(strArr);
                txtFilePathList.Text = Server.HtmlEncode(full);
                deleteFileEx(path);
            }
        }

        private string combinArr(string[] strArr)
        {
            string temp = "";
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] != "" && strArr[i] != null)
                {
                    if (temp == "")
                    {
                        temp = strArr[i];
                    }
                    else
                    {
                        temp += "|" + strArr[i];
                    }
                }
            }
            return temp;
        }

        string ErroMsg = "";

        public bool isImg(string FileName)
        {
            //string[] extendFileName = { ".TIF", ".TIIF", ".psd", ".jpg", ".gif", "png", ".bmp", ".BMP", ".PSD", ".JPG", ".GIF", "PNG" };
            string extendFileName = ".tif.tiff.psd.jpg.gif.png.bmp.psd.jpg.gif.png.rar";
           
            FileName = FileName.ToLower();
            string[] arr = FileName.Split('.');
            if (arr.Length == 0)
                return false;
            string cjm = arr[arr.Length - 1];


            return extendFileName.IndexOf(cjm) > -1;
        }


        private string UpLoadFiles()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            int filesCount = files.Count;
            string[] pathArr = new string[filesCount * 3];
            if (filesCount == 0)
                return "";
            string folder = txtFolder.Text;
            for (int iFile = 0; iFile < filesCount; iFile++)
            {
                if (files[iFile].ContentLength > 8388608)//5242880 5M
                {
                    ErroMsg = "上传文件“" + files[iFile].FileName + "”大于8M，不能上传。";
                    return null;
                }

                if (txtTp.Text == "1")
                {
                    string fileName = files[iFile].FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName);
                    if (!isImg(fileName))
                    {
                        ErroMsg = "请上传正确图片文件!";
                        return null;
                    }
                }
            }
            try
            {
                for (int iFile = 0; iFile < filesCount; iFile++)
                {
                    HttpPostedFile postedFile = files[iFile];
                    string fileName = "", fileExtension = "", file_id = "", str_fileSize = "";


                    string my_file_id = System.Guid.NewGuid().ToString();

                    fileName = System.IO.Path.GetFileName(postedFile.FileName);
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    file_id = my_file_id + fileExtension;
                    if (txtTitle.Text != "")
                    {
                        fileName = txtTitle.Text + fileExtension;
                    }
                    if (fileName != "")
                    {
                        str_fileSize = CommonHead.GetFileLengStr(postedFile.ContentLength);

                        pathArr[iFile * 3] = file_id;
                        pathArr[iFile * 3 + 1] = fileName;
                        pathArr[iFile * 3 + 2] = str_fileSize;
                        try
                        {
                            string ss = System.Web.HttpContext.Current.Request.MapPath("../" + folder + "/") + file_id;
                            postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../" + folder + "/") + file_id);
                        }
                        catch (Exception ex)
                        {
                            ErroMsg = ex.Message;
                            return null;
                        }
                    }
                }

                string adjunctPath = getAdjunctPath(pathArr);
                return adjunctPath;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取上传附件路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string getAdjunctPath(string[] filePath)
        {
            int adjAccount = filePath.Length;
            if (adjAccount == 0)
            {
                return "";
            }
            string adjunctPat = "";
            if (filePath[0] != "" && filePath[0] != null)
            {
                adjunctPat = filePath[0];
            }
            for (int i = 1; i < adjAccount; i++)
            {
                if (filePath[i] != "" && filePath[i] != null)
                    if (adjunctPat == "")
                    {
                        adjunctPat = filePath[i];
                    }
                    else
                    {
                        adjunctPat = adjunctPat + "|" + filePath[i];
                    }
            }
            return adjunctPat;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool isHaveDelete = false;
            foreach (GridViewRow row in this.gvFileList.Rows)
            {

                CheckBox cb = new CheckBox();
                cb = (CheckBox)row.FindControl("cbMailID");
                if (cb != null)
                    if (cb.Checked == true)
                    {
                        string fileID = row.Cells[3].Text.ToString();
                        deleteFile(fileID);
                        isHaveDelete = true;
                    }
            }
            if (isHaveDelete)
                showAdjunct();
        }
        protected void btnup_Click(object sender, EventArgs e)
        {
            string upFileList = UpLoadFiles();
           
            if (upFileList == null)
            {
                base.Alert(ErroMsg);
                return;
            }
            string m_strHaveUpload = txtFilePathList.Text;
            if (m_strHaveUpload != "")
                m_strHaveUpload += "|" + upFileList;
            else
                m_strHaveUpload = upFileList;
            txtFilePathList.Text = Server.HtmlEncode(m_strHaveUpload);
            txtTitle.Text = "";
            showAdjunct();
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