using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;
using GDK.Entity.Sys;


namespace GDK.BCM.Role
{
    public partial class RoleList : PageBase
    {
        private RolesDA m_Rose = new RolesDA();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pagenavigate1.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                if (null != Session["ListPageIndexRoleList"])
                {
                    pagenavigate1.PageIndex = Convert.ToInt32(Session["ListPageIndexRoleList"]);
                }

                InitPage();
                BindGraid();
                
            }
        }

        private void InitPage()
        {
            //btnAdd.Visible = base.HasPermission("Admin");
            aBtnAdd.Visible = gvDataList.Columns[2].Visible = base.HasPermission("Edit");
            gvDataList.Columns[1].Visible = base.HasPermission("Set");
            gvDataList.Columns[3].Visible = base.HasPermission("Delete");
           
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            Session.Clear();
            Session["ListPageIndexRoleList"] = pagenavigate1.PageIndex;

            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            int PageCount = 0;
            this.gvDataList.DataSource = m_Rose.selectAllDateByWhere(this.pagenavigate1.PageIndex, this.pagenavigate1.PageSize, out PageCount, string.Empty); ;

            this.gvDataList.DataBind();
            this.pagenavigate1.RecordCount = PageCount;
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
           // string loginUserId = base.CurrentUser.LogonName;
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete")
            {
                if (!m_Rose.Delete(id))
                {
                    base.Alert("删除失败!");
                }
               
                BindGraid();
            }
        }
    }

}