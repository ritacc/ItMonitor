using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.AlertAdmin;

namespace GDK.BCM.AlertAdmin
{
    public partial class PerfSystemFailure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new AlertDA().SlectAlertMonitor();
                rpAlertType.DataSource = dt;
                rpAlertType.DataBind();
            }
        }

        
    }
}