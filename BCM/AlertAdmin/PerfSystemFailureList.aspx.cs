using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.PerfMonitor;
using GDK.DAL.AlertAdmin;

namespace GDK.BCM.AlertAdmin
{
    public partial class PerfSystemFailureList : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!Page.IsPostBack)
            {
                BindGraid();
            }
        }

        private void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }
        private void BindGraid()
        {
            int PageCount = 0;
            DataTable dt = new AlertDA().SelectErrorList(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["typeid"]);
            gvDataList.DataSource = dt;
            gvDataList.DataBind();
            this.pg.RecordCount = PageCount;
        }
    }
}