using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.PerfMonitor;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfDBBack : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                BindGraidDetail();
            }
        }


        #region  绑定列表 - 回退段
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidDetail();
        }
        private void BindGraidDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectDBBack(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvDBBack.DataSource = dt;
            gvDBBack.DataBind();
            this.pg.RecordCount = PageCount;
        }
        #endregion
    }
}