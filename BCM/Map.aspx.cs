using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Web.Script.Serialization;
using DBUtility;
using Entity;

using System.Data;


namespace GDK.BCM
{
    public partial class Map : System.Web.UI.Page
    {
        private const string DELETE_MODES_SQL = "DELETE T_SYS_Function";
                
        private const string INSERT_MODES_SQL = "INSERT INTO T_SYS_Function (MOD_URL ,MOD_NAME ,PARENT_URL ,SORT ,MOD_LEVEL, MOD_DESC, ENABLED, IMAGE_PATH, isFunction) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','Y','{6}', '{7}')";
        
       
        private List<string> sqls = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["type"]
                && Request.QueryString["type"] == "build")
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                AjaxContext context = new AjaxContext();
                context.Html = string.Empty;
                try
                {
                    context.IsSuccess = true;
                  
                    BuildModelsAndPermissions();
                }
                catch (Exception ex)
                {
                    context.IsSuccess = false;
                    context.Source = ex.Source;
                    context.Message = ex.Message;
                    context.TargetSite = ex.TargetSite.ToString();
                    context.StackTrace = ex.StackTrace;
                    if (null != ex.InnerException)
                    {
                        context.InnerException = ex.InnerException.ToString();
                    }
                }
                string error = jss.Serialize(context);
                Response.Write(error);

                Response.Flush();
                Response.End();
            }
        }

        private void BuildModelsAndPermissions()
        {
            string path = MapPath("~/Web.sitemap");
            if (File.Exists(path))
            {

                sqls.Clear();

                // 删除模块表


                sqls.Add(DELETE_MODES_SQL);

                XmlDocument document = new XmlDocument();
                document.Load(path);
                XmlNode xnRoot = document.ChildNodes[1].FirstChild;
                InsertNode(xnRoot, "root", 0, 0);
                SqlHelper dal = new SqlHelper();
                dal.ExecuteNoQueryTran(sqls);
            }
        }

        private void InsertNode(XmlNode xn, string parentUrl, int iSort, int iLevel)
        {
            string imagePath = string.Empty;
           
            if (null != xn.Attributes["imagePath"])
            {
                imagePath = xn.Attributes["imagePath"].Value;
            }
            bool flag = false;
            if (null != xn.Attributes["isFunction"])
            {
                flag = Convert.ToBoolean(xn.Attributes["isFunction"].Value);
            }
            if (xn.Attributes["url"].Value != "Task/TaskList.aspx?id=task" && parentUrl != "Task/TaskList.aspx?id=task")
            {
                this.sqls.Add(string.Format(INSERT_MODES_SQL, new object[] { xn.Attributes["url"].Value, xn.Attributes["title"].Value, parentUrl, iSort, iLevel, xn.Attributes["description"].Value, imagePath, flag ? 'Y' : 'N' }));
                int num = 0;
                foreach (XmlNode xnChild in xn.ChildNodes)
                {
                    InsertNode(xnChild, xn.Attributes["url"].Value, num++, iLevel + 1);
                }
            }
            

            
        }
  
        }
}
