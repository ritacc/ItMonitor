using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;

namespace GDK.BCM.PerfMonitor
{
    public partial class PrefSystemFailure : PageBase
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
                BindGraid();
            }
        }

        private void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }
        public void BindGraid()
        {
            string mWhere = string.Empty;
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                string filds = "d.IP";
                if (rdbName.Checked)
                {
                    filds = "d.DeviceName";
                }
                mWhere = string.Format(" {0} like '%{1}%'", filds, txtValue.Text);
            }
            try
            {
                int PageCount = 0;
                this.gvDataList.DataSource = new PrefSystemFailureDA().selectDeviceList(pg.PageIndex, pg.PageSize, out PageCount, mWhere);

                this.gvDataList.DataBind();
                this.pg.RecordCount = PageCount;
            }
            catch (Exception ex)
            {
                AlertNormal(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGraid();
        }
    }
}