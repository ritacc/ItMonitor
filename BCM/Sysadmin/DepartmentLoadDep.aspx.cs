using System;
using GDK.DAL.Sys;
using System.Data;

namespace GDK.BCM.Sysadmin
{
    public partial class DepartmentLoadDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserOrganizationsDal m_Orga = new UserOrganizationsDal();
            string GUID = Request.QueryString["GUID"].ToString();
            DataTable objOrg = m_Orga.GetOrgByParentID(GUID);
            if (null != objOrg)
            {
                rptMenu2.DataSource = objOrg;
                rptMenu2.DataBind();
            }
        }
    }
}