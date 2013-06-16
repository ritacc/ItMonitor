using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.PerfMonitor;

namespace GDK.BCM.CompReport
{
    public partial class ReportConfig : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                lblDepart.Text = base.CurrentUser.DepartmentName;
               
                //加载，应用系统
                DataTable dt = new PerfApplicationDA().GetTopBuss();
                dpdSystem.DataSource = dt;
                dpdSystem.DataTextField = "DeviceName";
                dpdSystem.DataValueField = "DeviceID";
                dpdSystem.DataBind();
            }
        }
    }
}