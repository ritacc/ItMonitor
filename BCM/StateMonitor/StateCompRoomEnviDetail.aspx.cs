using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;
using GDK.DAL.PerfMonitor;
using GDK.Entity.StateMonitor;
using GDK.DAL.StateMonitor;

namespace GDK.BCM.StateMonitor
{
    public partial class StateCompRoomEnviDetail : PageBase
    {
        public int deviceID = 0;
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            StateCompRoomEnviOR _Obj = new StateCompRoomEnviDA().SelectDeviceDetail(mDeviceID);
            lblName.Text = _objDev.DeviceName;
            lblState.Text = _objDev.Performance;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblLeak.Text = _Obj.Leak;
            lblDUANXIAN.Text = _Obj.DUANXIAN;
            lblWEIZHI.Text = _Obj.WEIZHI;
        }
    }
}