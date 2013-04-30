using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using GDK.Entity.Sys;
using GDK.DAL.Sys;
using System.Web.UI.WebControls;

using System.Data;
using System.Web;
using System.Data.OleDb;
using System.Collections.Specialized;
using System.Collections;

namespace GDK.BCM
{
   
    public partial class  PageBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            
            string url = PageUrl.ToUpper().Trim();

            if (_IsAuthenticate)
            {
                string rawUrl = PageRawUrl.ToUpper().Trim();
                if (!Permissions.Any(p => p.MOD_URL.ToUpper().Trim() == url
                    || p.MOD_URL.ToUpper().Trim() == rawUrl))
                {
                    b_MissingParameter("无权访问该页面.");
                }
            }

            base.OnLoad(e);
        }
       

        public PageBase()
        {
            //权限控制
           //// Access();
        }

        #region 权限管理

        /// <summary>
        /// 当前用户的登陆名
        /// </summary>
        public string UserId
        {
            get
            {
                return CurrentUser.Guid;
            }
        }

        private void Access()
        {
            if (null == Session["CurrentUser"])
            {
                Server.Transfer("~/Login.aspx");
            }
        }
        /// <summary>
        /// 当前用户的显示名称
        /// </summary>
        public string UserName
        {
            get
            {
                return CurrentUser.DisplayName;
            }
        }

        private UsersOR _CurrentUser;
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public UsersOR CurrentUser
        {
            get
            {
                if (null == _CurrentUser)
                {
                    if (null == Session["CurrentUser"])
                    {
                        if (null != HttpContext.Current.Request.Cookies["CurrentUser"]
                            && null != HttpContext.Current.Request.Cookies["CurrentUser"].Values["UserID"]
                            && (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["CurrentUser"].Values["UserID"])))
                        {
                            _CurrentUser = new UsersDA().selectARowDateByGuid(HttpContext.Current.Request.Cookies["CurrentUser"].Values["UserID"]);
                            Session["CurrentUser"] = _CurrentUser;
                        }
                        else
                        {
                            if (_IsAjaxPage)
                            {
                                throw new Exception("无法获取当前登录用户的信息,请重新登陆.");
                            }
                            else
                            {
                                HttpContext.Current.Response.Redirect("~/main/OutOffTime.aspx");
                            }
                        }
                    }
                    else
                    {
                        _CurrentUser = (UsersOR)Session["CurrentUser"];
                    }
                }
                return _CurrentUser;
            }
        }

        private bool _IsAuthenticate = true;
        /// <summary>
        /// 是事进行权限验证
        /// </summary>
        protected bool IsAuthenticate
        {
            set { _IsAuthenticate = value; }
        }

        private bool _IsAjaxPage = false;

        protected bool IsAjaxPage
        {
            set { _IsAjaxPage = value; }
        }

        private List<VHC_USER_PERMISSIONS> _Permissions;

        /// <summary>
        /// 当前用户的权限列表
        /// </summary>
        public List<VHC_USER_PERMISSIONS> Permissions
        {
            get
            {
                if (null == _Permissions)
                {
                    if (null == Session["UserPermissions"])
                    {
                        _Permissions = new UserPermissionsDA().GetListByUserID(UserId);
                        if (_Permissions.Count == 0)
                        {
                            b_Reload("未授权，无法访问该系统.");
                        }
                        Session["UserPermissions"] = _Permissions;
                    }
                    else
                    {
                        _Permissions = (List<VHC_USER_PERMISSIONS>)Session["UserPermissions"];
                    }
                }
                return _Permissions;
            }
        }

        private bool? _CanAdd;
        /// <summary>
        /// 是否拥有添加权限
        /// </summary>
        protected bool CanAdd
        {
            get
            {
                if (!_CanAdd.HasValue)
                {
                    _CanAdd = HasPermission("Edit");
                }
                return _CanAdd.Value;
            }
        }

        private bool? _CanDelete;
        /// <summary>
        /// 是否有删除权限
        /// </summary>
        protected bool CanDelete
        {
            get
            {
                if (!_CanDelete.HasValue)
                {
                    _CanDelete = HasPermission("Delete");
                    if (!_CanDelete.Value
                        && Regex.IsMatch(PageUrl,
                        "Add.aspx",
                        RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    {
                        string url = Regex.Replace(PageUrl, "Add.aspx", "List.aspx?Delete", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToUpper().Trim();
                        _CanDelete = HasPermissionFullWord(url);
                    }
                }
                return _CanDelete.Value;
            }
        }

        private bool? m_IsAdmin;
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                if (!m_IsAdmin.HasValue)
                {
                    m_IsAdmin = Permissions.Any(p => p.MOD_URL == "admin");
                }
                return m_IsAdmin.Value;

            }
        }



        private bool? _CanApproval;
        /// <summary>
        /// 是否有审核权限
        /// </summary>
        protected bool CanApproval
        {
            get
            {
                if (!_CanApproval.HasValue)
                {
                    _CanApproval = HasPermission("Approval");
                }
                return _CanApproval.Value;
            }
        }

        /// <summary>
        /// 判断当前用户是否拥有指定的权限
        /// </summary>
        /// <param name="permission">权限名称</param>
        /// <returns></returns>
        protected bool HasPermission(string permission)
        {
            string url = Regex.Replace(PageUrl, "List.aspx", permission + ".aspx", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToUpper().Trim();

            if (Permissions.Any(p => p.MOD_URL.ToUpper() == (PageUrl + "?" + permission).ToUpper()))
            {
                return true;
            }
            else if (Permissions.Any(p => p.MOD_URL.ToUpper().Trim() == url))
            {
                return true;
            }
            else if (Permissions.Any(p => p.MOD_URL == permission))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断当前用户是否拥有指定的权限，全字匹配
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        protected bool HasPermissionFullWord(string permission)
        {
            if (Permissions.Any(p => p.MOD_URL.ToUpper().Trim() == permission.ToUpper().Trim()))
            {
                return true;
            }
            return false;
        }

        
        private string _PageUrl;
        protected string PageUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_PageUrl))
                {
                    _PageUrl = GetPageUrl();
                }
                return _PageUrl;
            }
        }

        private string _PageRawUrl;
        protected string PageRawUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_PageRawUrl))
                {
                    _PageRawUrl = GetPageRawUrl();
                }
                return _PageRawUrl;
            }
        }


        /// <summary>
        /// 获取页面的相对路径
        /// </summary>
        /// <returns></returns>
        protected string GetPageUrl()
        {
            Regex reg = new Regex("(?i)(?<=Root).*$");
            string appl_md_path = Request.ServerVariables.Get("APPL_MD_PATH").ToString();
            string virtualDirectory = reg.Match(appl_md_path).Value;
            string filePath = Regex.Replace(Request.FilePath, virtualDirectory, "", RegexOptions.IgnoreCase);
           
            filePath = Regex.Replace(filePath, "^[/]?", "");
            return filePath;
        }

        /// <summary>
        /// 获取页面的相对路径
        /// 包括QueryString
        /// </summary>
        /// <returns></returns>
        protected string GetPageRawUrl()
        {
            Regex reg = new Regex("(?i)(?<=Root).*$");
            string appl_md_path = Request.ServerVariables.Get("APPL_MD_PATH").ToString();
            string virtualDirectory = reg.Match(appl_md_path).Value;
            string filePath = Regex.Replace(Request.RawUrl, virtualDirectory, "", RegexOptions.IgnoreCase);
            filePath = Regex.Replace(filePath, "^[/]?", "");
            return filePath;
        }

        #endregion

        #region 公用方法

        private JavaScriptSerializer _Serializer;

        public TSource Deserialize<TSource>(string input)
        {
            if (null == _Serializer)
            {
                _Serializer = new JavaScriptSerializer();
            }
            return _Serializer.Deserialize<TSource>(Server.UrlDecode(input));
        }

        /// <summary>
        /// 页面缺乏参数时，跳转到提示页面
        /// </summary>
        protected void b_MissingParameter()
        {
            Server.Transfer("~/main/MissingParameter.aspx");
        }

        /// <summary>
        /// 页面缺乏参数时，跳转到提示页面
        /// </summary>
        /// <param name="msg"></param>
        protected void b_MissingParameter(string msg)
        {
            Server.Transfer("~/main/MissingParameter.aspx?msg=" + Server.UrlEncode(msg));
        }

        /// <summary>
        /// 页面缺乏参数时，跳转到提示页面
        /// </summary>
        /// <param name="msg"></param>
        protected void b_Reload(string msg)
        {
            Server.Transfer("~/main/OutoffTime.aspx?msg=" + Server.UrlEncode(msg));
        }

        protected string RenderControl(Control control)
        {
            Page page = new Page();
            HtmlForm form = new HtmlForm();
            control.EnableViewState = false;
            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;
            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();            
            page.Controls.Add(form);
            form.Controls.Add(control);
            StringBuilder sBuilder = new StringBuilder();
            using (StringWriter sWriter = new StringWriter(sBuilder))
            {
                using (HtmlTextWriter html = new HtmlTextWriter(sWriter))
                {
                    string id = control.ID;
                    page.RenderControl(html);
                    return sBuilder.ToString();
                }
            }
        }

        /// <summary>
        /// 关闭当前窗口，可设置是否刷新父窗体(只限JQuery打开的窗体)或返回值
        /// 如果参数为System.Boolean类型则表示是否刷新父窗体(只限JQuery打开的窗体)
        /// 如果参数为System.String类型则表示有返回值
        /// </summary>
        /// <param name="arg0"></param>
        protected void Close(object arg0)
        {
            string str = arg0.ToString();
            string type = arg0.GetType().FullName;

            if (type == "System.Boolean")
            {
                str = str.ToLower();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function(){$.popup.close(" + str + ");});</script>");
            }
            else if (type == "System.String")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function(){$.popup.close('" + str + "');});</script>");
            }
            else
            {
                throw new Exception("PageBase.Colse(object)的参数类型只能为System.Boolean或System.String类型");
            }
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
        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void Alert(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){if($('#wdiv')){autoSize()};window.setTimeout(function () {alert('" + msg + "');}, 200);});</script>");
        }
        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void Alert(Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){if($('#wdiv')){autoSize()};window.setTimeout(function () {alert('" + msg + "');}, 200);});</script>");
        }
        #endregion

        #region 页面主题
        void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "Default";
        }
        #endregion


        public  string GetStr(string sObj, int intLen)
        {
            if (sObj.Length > intLen)
            {
                return sObj.Substring(0, intLen) + "…";
            }
            return sObj;
        }

        //protected bool LoadDataDire(DropDownList dpd, string keyWord)
        //{
        //    dpd.Items.Add(new ListItem("--请选择--", ""));
        //    DataTable dt = null;
        //    try
        //    {
        //        dt = new DataDictDA().SelectDictTypeByKeyWord(keyWord);
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert(ex);
        //        return false;
        //    }
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string mName = dr["name"].ToString();
        //            dpd.Items.Add(new ListItem(mName, mName));
        //        }
        //    }
        //    dpd.SelectedValue = "";
        //    return true;
        //}

        //protected bool LoadDataDire(RadioButtonList rbl, string keyWord)
        //{
            
        //    DataTable dt = null;
        //    try
        //    {
        //        dt = new DataDictDA().SelectDictTypeByKeyWord(keyWord);
        //    }
        //    catch (Exception ex)
        //    {
        //        Alert(ex);
        //        return false;
        //    }
        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string mName = dr["name"].ToString();
        //            rbl.Items.Add(new ListItem(mName, mName));
        //        }
        //        if (rbl.Items.Count > 0)
        //            rbl.Items[0].Selected = true;
        //    }
        //    return true;
        //}


        public void DataTableToExcel(DataTable dtDataS, Hashtable keyNameShow)
        {   
            //keyNameShow.Add(
            string dePath = Server.MapPath("../KnowledgeBase/Teplate.xls");
            string toPath = Server.MapPath("../UpLoad");
            string temurl = Guid.NewGuid().ToString() + ".xls";
            toPath += toPath.EndsWith("\\") ? "" : "\\" + temurl;

            System.IO.File.Copy(dePath, toPath);
            string clounInfo = string.Empty;
            string strCreateTable = "CREATE TABLE Sheet1 (";
            int counter = 0;
            foreach (string  dcValue in keyNameShow.Values)
            {
                    if (counter == 0)
                    {
                        clounInfo = "[" + dcValue + "]";
                        strCreateTable += string.Format("[{0}] char(255)", dcValue);
                    }
                    else
                    {
                        clounInfo += ",[" + dcValue + "]";
                        strCreateTable += string.Format(",[{0}] char(255)", dcValue);
                    }
                    counter++;
               
            }
            strCreateTable += ")";
            
            List<string> listSql = new List<string>();
            foreach (DataRow dr in dtDataS.Rows)
            {
                counter = 0;
                string strSql = string.Format("INSERT INTO [Sheet1$] ({0})  values (", clounInfo);
                foreach (string dcValus in keyNameShow.Keys)
                {
                    string html = dr[dcValus].ToString();
                    if (counter == 0)
                    {
                        strSql += string.Format("'{0}'", html);
                    }
                    else
                    {
                        strSql += string.Format(",'{0}'", html);
                    }
                    counter++;

                }//for
                strSql += ")";
                listSql.Add(strSql);
            }

            string mystring = "Provider=Microsoft.Jet.Oledb.4.0;Data Source = " + toPath + ";Extended Properties=Excel 8.0";
            OleDbConnection cnnxls = new OleDbConnection(mystring);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnnxls;
            cnnxls.Open();
            cmd.CommandText = strCreateTable;
            cmd.ExecuteNonQuery();
            foreach (string strSql in listSql)
            {
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
            }
            if (cnnxls.State == ConnectionState.Open)
                cnnxls.Close();
            if (cmd != null)
                cmd.Dispose();
            cnnxls.Dispose();

            string path = "../UpLoad\\" + temurl;
            Response.Redirect("../KnowledgeBase/downFile.aspx?path=" + path + "&name=fileName.xls");
            //DownFile("F:\\HCGL\\HCGL\\UploadFile\\", "文件名.xls");

        }

        public void DataTableToExcel(DataTable dtDataS, int startIndex)
        {
            string dePath = Server.MapPath("../KnowledgeBase/Teplate.xls");
            string toPath = Server.MapPath("../UpLoad");
            string temurl = Guid.NewGuid().ToString() + ".xls";
            toPath += toPath.EndsWith("\\") ? "" : "\\" + temurl;

            System.IO.File.Copy(dePath, toPath);

            string clounInfo = string.Empty;
            string strCreateTable = "CREATE TABLE Sheet1 (";
            int counter = 0;
            foreach (DataColumn dc in dtDataS.Columns)
            {



                if (counter == 0)
                {
                    clounInfo = "[" + dc.ColumnName + "]";
                    strCreateTable += string.Format("[{0}] char(255)", dc.ColumnName);
                }
                else
                {
                    clounInfo += ",[" + dc.ColumnName + "]";
                    strCreateTable += string.Format(",[{0}] char(255)", dc.ColumnName);
                }
                counter++;

            }
            strCreateTable += ")";

            List<string> listSql = new List<string>();
            foreach (DataRow dr in dtDataS.Rows)
            {
                counter = 0;
                string strSql = string.Format("INSERT INTO [Sheet1$] ({0})  values (", clounInfo);
                foreach (DataColumn dc in dtDataS.Columns)
                {
                    string html = dr[dc.ColumnName].ToString().Trim();
                    if (counter == 0)
                    {
                        strSql += string.Format("'{0}'", html);
                    }
                    else
                    {
                        strSql += string.Format(",'{0}'", html);
                    }
                    counter++;

                }//for
                strSql += ")";
                listSql.Add(strSql);
            }

            string mystring = "Provider=Microsoft.Jet.Oledb.4.0;Data Source = " + toPath + ";Extended Properties=Excel 8.0";
            OleDbConnection cnnxls = new OleDbConnection(mystring);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnnxls;
            cnnxls.Open();
            cmd.CommandText = strCreateTable;
            cmd.ExecuteNonQuery();
            foreach (string strSql in listSql)
            {
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
            }
            if (cnnxls.State == ConnectionState.Open)
                cnnxls.Close();
            if (cmd != null)
                cmd.Dispose();
            cnnxls.Dispose();

            string path = "../UpLoad\\" + temurl;
            Response.Redirect("../KnowledgeBase/downFile.aspx?path=" + path + "&name=fileName.xls");
        }


        private string getDrName(Hashtable h,string Word)
        {
            foreach (IDictionary d in h)
            {
                if (d.Keys.ToString() == Word)
                {
                    return d.Values.ToString();
                }
            }
            return null;
        }
       
    }
}
