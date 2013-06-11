using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using GDK.DAL.StateMonitor;
using System.Data;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfApplication : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataTable dt = new PrefApplicationDA().GetTopBuss();
                if (null != dt)
                {
                    rpApp.DataSource = dt;
                    rpApp.DataBind();
                }
            }
        }

    }
}