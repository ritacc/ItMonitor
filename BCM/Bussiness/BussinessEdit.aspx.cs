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
        public string AppName = string.Empty;
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
            if (!IsPostBack)
            {
                BindGraid();
            }
            string type = Request.QueryString["type"];
            switch (type)
            {
                case "top":
                    AppName = "应用系统";
                    break;
                case "host":
                    AppName = "服务器";
                    break;
                case "use":
                    AppName = "应用层";
                    break;
                case "web":
                    AppName = "Web层";
                    break;
                case "db":
                    AppName = "数据库层";
                    break;
            }

        }

        private void BindGraid()
        {
            DataTable dt = null;
			if (Request.QueryString["type"] == "top")
			{
				dt = BusDA.GetTopBuss();//(pg.PageIndex, pg.PageSize, out pageCount);
			}
			else
			{
                string id = Request.QueryString["GUID"];
				switch (Request.QueryString["type"])
				{
                    case "host":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), 1);
						break;
					case "use":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), 10);
						break;
					case "web":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), " (dt.typeid=2 or dt.typeid=3 )");
						break;
					case "db":
						dt = new PerfApplicationDA().GetSysLay(Convert.ToInt32(id), 4);
						break;
				}
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