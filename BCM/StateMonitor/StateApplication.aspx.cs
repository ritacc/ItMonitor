using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.StateMonitor;
using System.Data;
using GDK.DAL.Sys;

namespace GDK.BCM.StateMonitor
{
    public partial class StateApplication : PageBase
    {

        protected override void OnPreLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnPreLoad(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataTable dt = new StateApplicationDA().GetTopBuss();
                if (null != dt)
                {
                    rpApp.DataSource = dt;
                    rpApp.DataBind();
                }
            }
        }
    }
}