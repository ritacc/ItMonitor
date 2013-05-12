using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.SerMonitor;
using GDK.Entity.PerfMonitor;

namespace GDK.BCM.StateMonitor
{
    public partial class StateListDetail : PageBase
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
            string mDeviceID = Request.QueryString["id"];
            
            DeviceOREx _objDev = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            lblClass.Text = _objDev.ClassName;
            lblType.Text = _objDev.TypeName;
            

          
        }

    }
}