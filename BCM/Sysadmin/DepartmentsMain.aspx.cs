using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;

using GDK.Entity.Sys;


namespace GDK.BCM.Sysadmin
{
    public partial class DepartmentsMain : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }
        public bool OrgEdit = false;
        public bool OrgDelete = false;

        public bool UserEdit = false;
        public bool UserDelete = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            if (!Page.IsPostBack)
            {                
                LoadDate();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void InitPage()
        {
            try
            {
                OrgEdit = base.HasPermissionFullWord("SysAdmin/DepartmentsEdit.aspx");
                OrgDelete = base.HasPermissionFullWord("SysAdmin/DepartmentsMain.aspx?Delete");
                UserEdit = base.HasPermissionFullWord("SysAdmin/UserEdit.aspx");
                UserDelete = base.HasPermissionFullWord("SysAdmin/DepartmentsMain.aspx?Delete");
                if (!OrgDelete && !UserDelete)
                    imgTransh.Visible = false;
                imgNewUser.Visible = UserEdit;
                imgNewOrg.Visible = OrgEdit;
            }
            catch (Exception e) {
                Alert(e.Message);
            }

        }

        private void LoadDate()
        {
            if (Request.QueryString["GUID"] != null)
            {
                string guid = Request.QueryString["GUID"].ToString();
                UserOrganizationsDal uorgDal = new UserOrganizationsDal();
                gvDataList.DataSource = uorgDal.GetOrgUserListByParentID(guid);
                gvDataList.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strInfo = txtOpInfo.Text;
            string[] arr = strInfo.Split('|');
            if (arr.Length == 2)
            {
                UserOrganizationsDal uorgDal = new UserOrganizationsDal();
                try
                {
                    if (arr[0] == "org")
                    {
                        uorgDal.DeleteOrganizations(arr[1]);
                       
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function(){refreshParent();});</script>");
                    }
                    else
                    {
                        uorgDal.DeleteUser(arr[1]);
                        
                    }
                }
                catch (Exception ex)
                {
                    Alert(ex);
                    return;
                }
                LoadDate();
            }
        }
    }
}