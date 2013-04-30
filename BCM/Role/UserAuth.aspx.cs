using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DAL.Sys;


namespace ZCGL
{
    public partial class Role_UserAuth : PageBase
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

                BindGraid();
            }
        }



        private void BindGraid()
        {
            int recourtCount = 0;
            this.GridView1.DataSource = m_UserR.GetUserRosetList(this.pagenavigate1.PageIndex, this.pagenavigate1.PageSize, out recourtCount, string.Empty); ;
            this.GridView1.DataBind();
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