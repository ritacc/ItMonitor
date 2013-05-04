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
    public partial class Net : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gvpg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack) {
                BindGraid();
            }
        }

        public void BindGraid()
        {
            try
            {
                string where = string.Empty;
                int pageIndex = this.gvpg.PageIndex;
                int pageSize = this.gvpg.PageSize;
                int sourceCount = 0;
                DataTable dt = new DataTable();
          
                dt = new DeviceDA().selectAllDateByWhere(pageIndex, pageSize, out sourceCount, where);
                gridnet.DataSource = dt;
                gridnet.DataBind();
                gvpg.RecordCount = sourceCount;
            }
            catch (Exception e)
            {
                //base.Alert(e.Message);
                return;
            }
        }

        private void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }

    }
}