using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;
using System.Data;
using GDK.DAL.PerfMonitor;

namespace GDK.BCM.Bussiness
{
    public partial class BussinessEdit : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

		PerfApplicationDA BusDA = new PerfApplicationDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDeviceID.Text = Request.QueryString["GUID"];
            txtType.Text = Request.QueryString["type"];

            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                if (null != Session["ListPageIndexRoleList"])
                {
                    pg.PageIndex = Convert.ToInt32(Session["ListPageIndexRoleList"]);
                }

                
                BindGraid();
            }

        }
        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }

       

        private void BindGraid()
        {
            int pageCount = 0;
            DataTable dt = null;
			string mType = "";
			if (Request.QueryString["type"] == "top")
			{
				dt = BusDA.GetTopBuss();//(pg.PageIndex, pg.PageSize, out pageCount);
			}
			else
			{
				switch (Request.QueryString["type"])
				{
					case "server":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), 1);
						break;
					case "use":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), 10);
						break;
					case "web":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), " (dt.typeid=2 or dt.typeid=3 )");
						break;
					case "DB":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), 4);
						break;
				}
				string strWhere = string.Empty;
				BusDA.GetSysLay(Convert.ToInt32(Request.QueryString["GUID"]), strWhere);
			}
            this.gvDataList.DataSource = dt;
            gvDataList.DataBind();
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
            // string loginUserId = base.CurrentUser.LogonName;
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete")
            {

				if (!new BussinessDA().Delete(id))
                {
                    base.Alert("删除失败!");
                }
                BindGraid();
            }
        }

    }
}