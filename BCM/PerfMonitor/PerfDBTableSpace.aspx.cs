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
    public partial class PerfDBTableSpace : PageBase
    {
        public int deviceID = 0;
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            this.pgTableSpaceState.OnPageChanged += new EventHandler(PageChangedTableSpaceState);
            this.pgTableSpaceData.OnPageChanged += new EventHandler(PageChangedTableSpaceData);
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        #region  绑定列表 - 表空间明细
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidDetail();
        }
        private void BindGraidDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectTableSpaceDetailList(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvTableSpaceDetail.DataSource = dt;
            gvTableSpaceDetail.DataBind();
        }
        #endregion

        #region  绑定列表 - 表空间状态
        private void PageChangedTableSpaceState(object sender, EventArgs e)
        {
            BindGraidState();
        }
        private void BindGraidState()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectTableSpaceState(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvTableSpaceState.DataSource = dt;
            gvTableSpaceState.DataBind();
        }
        #endregion

        #region  绑定列表 - 数据文件的性能指标
        private void PageChangedTableSpaceData(object sender, EventArgs e)
        {
            BindGraidData();
        }
        private void BindGraidData()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectTableSpaceData(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvTableSpaceData.DataSource = dt;
            gvTableSpaceData.DataBind();
        }
        #endregion

        private void InitData()
        {
            BindGraidDetail();
            BindGraidState();
            BindGraidData();
        }

    }
}