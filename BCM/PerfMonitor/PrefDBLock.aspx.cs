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
    public partial class PrefDBLock : PageBase
    {
        public string deviceID = null;
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            this.pgLockedWaitingNO.OnPageChanged += new EventHandler(PageChangedWaitingNO);
            this.pgLockDetail.OnPageChanged += new EventHandler(PageChangedLockDetail);
            deviceID = Request.QueryString["id"].ToString();
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            BindGraidLockedNO();
            BindGraidWaitingNO();
            BindGraidDetail();
        }

        #region  绑定列表 - 拥有锁的会话数
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidLockedNO();
        }
        private void BindGraidLockedNO()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectLockedNO(pg.PageIndex, pg.PageSize, out PageCount, deviceID);
            gvLockedNO.DataSource = dt;
            gvLockedNO.DataBind();
        }
        #endregion

        #region  绑定列表 - 锁的会话等待数
        private void PageChangedWaitingNO(object sender, EventArgs e)
        {
            BindGraidWaitingNO();
        }
        private void BindGraidWaitingNO()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectLockedWaitingNO(pg.PageIndex, pg.PageSize, out PageCount, deviceID);
            gvLockedWaitingNO.DataSource = dt;
            gvLockedWaitingNO.DataBind();
        }
        #endregion

        #region  绑定列表 - 锁明细
        private void PageChangedLockDetail(object sender, EventArgs e)
        {
            BindGraidDetail();
        }
        private void BindGraidDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectLockDetail(pg.PageIndex, pg.PageSize, out PageCount, deviceID);
            gvLockDetail.DataSource = dt;
            gvLockDetail.DataBind();
        }
        #endregion

    }
}