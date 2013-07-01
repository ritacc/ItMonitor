using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.Sys;

namespace GDK.BCM.Sysadmin
{
    public partial class DepartmentsList : System.Web.UI.Page
    {
        UserOrganizationsDal m_Orga = new UserOrganizationsDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = m_Orga.GetOrgTop();
                if (null != dt)
                {
                    rpDepartment.DataSource = dt;
                    rpDepartment.DataBind();
                }
            }
        }
        //private void LoadChildNode(TreeNode tn, string GUID)
        //{
        //    DataTable listOrg = m_Orga.GetOrgByParentID(GUID);
        //    foreach (DataRow dr in listOrg.Rows)
        //    {
        //        TreeNode tnC = new TreeNode();
        //        tnC.Value = dr["GUID"].ToString();
        //        tnC.Text = dr["DISPLAY_NAME"].ToString();
        //        tn.NavigateUrl = "javascript:LoadDepartments('" + dr["GUID"].ToString() + "');";
        //        //tnC.NavigateUrl = "DepartmentsMain.aspx?Url=" + org.GUID;
        //        tn.ChildNodes.Add(tnC);
        //    }
        //}
    }
}