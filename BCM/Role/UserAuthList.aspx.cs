using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;

namespace GDK.BCM.Role
{
    public partial class UserAuthList : PageBase
    {
        private UserRolesDA m_UserR = new UserRolesDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pagenavigate1.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                if (null != Session["ListPageIndexUserAuth"])
                {
                    pagenavigate1.PageIndex = Convert.ToInt32(Session["ListPageIndexUserAuth"]);
                }
                InitPage();
                BindGraid();
            }
        }

        private void InitPage()
        {
            gvDataList.Columns[1].Visible = base.CanAdd;
        }

        private void BindGraid()
        {
            int recourtCount = 0;
            this.gvDataList.DataSource = m_UserR.GetUserRosetList(this.pagenavigate1.PageIndex, this.pagenavigate1.PageSize, out recourtCount, string.Empty); ;
            this.gvDataList.DataBind();
            this.pagenavigate1.RecordCount = recourtCount;
        }
        protected void PageChanged(object sender, EventArgs e)
        {
            Session.Clear();
            Session["ListPageIndexUserAuth"] = pagenavigate1.PageIndex;

            BindGraid();/*加查询条件string.Empty*/
        }

    }

}