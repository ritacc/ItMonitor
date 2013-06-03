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
    public partial class PerfDBSelect : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            BindGraidDetail();
            BindGraidBuffer();
        }

        #region  绑定列表 - 磁盘读数-前10查询
        private void BindGraidDetail()
        {
            DataTable dt = new PerfDBDA().selectDiskReading(Request.QueryString["id"]);
            gvDiskReading.DataSource = dt;
            gvDiskReading.DataBind();
        }
        #endregion

        #region  绑定列表 - 缓冲区读数-前10查询
        private void BindGraidBuffer()
        {
            DataTable dt = new PerfDBDA().selectBufferReading(Request.QueryString["id"]);
            gvBufferReading.DataSource = dt;
            gvBufferReading.DataBind();
        }
        #endregion
        
    }
}