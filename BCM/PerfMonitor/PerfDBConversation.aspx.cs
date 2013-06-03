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
    public partial class PerfDBConversation : PageBase
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
            this.pgConversationCollect.OnPageChanged += new EventHandler(PageChangedConversationCollect);
            this.pgConversationNO.OnPageChanged += new EventHandler(PageChangedConversationNO);
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            BindGraidDetail();
            BindGraidCollect();
            BindGraidNO();
        }

        #region  绑定列表 - 会话明细
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidDetail();
        }
        private void BindGraidDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectConversationDetailList(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvConversationDetail.DataSource = dt;
            gvConversationDetail.DataBind();
        }
        #endregion

        #region  绑定列表 - 会话汇总
        private void PageChangedConversationCollect(object sender, EventArgs e)
        {
            BindGraidCollect();
        }
        private void BindGraidCollect()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectConversationCollect(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvConversationCollect.DataSource = dt;
            gvConversationCollect.DataBind();
        }
        #endregion

        #region  绑定列表 - 等待会话数
        private void PageChangedConversationNO(object sender, EventArgs e)
        {
            BindGraidNO();
        }
        private void BindGraidNO()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectConversationNO(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvConversationNO.DataSource = dt;
            gvConversationNO.DataBind();
        }
        #endregion
    }
}