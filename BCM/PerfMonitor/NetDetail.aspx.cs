using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using System.Data;

namespace GDK.BCM.PerfMonitor
{
    public partial class NetDetail : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //BindData();
            }
        }
        public void BindData() 
        {
            try
            {        
                string id=Request.QueryString["id"].ToString();
                DataTable dt = new DataTable();
                dt = new DeviceDA().selectDetailDateByWhere(id);
                rptnetdetail.DataSource = dt;
                rptnetdetail.DataBind();
            }
            catch (Exception e)
            {
                base.Alert(e.Message);
                return;
            }
        }
    }
}