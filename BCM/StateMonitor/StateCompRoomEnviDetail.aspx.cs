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
        public string perf = "0";
        public string Leak = "0";
        public string DUANXIAN = "0";
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
            switch (_objDev.Performance)
            {
                case "正常":
                    perf = "0";
                    break;
                case "故障":
                    perf = "1";
                    break;
                case "报警":
                    perf = "2";
                    break;
                case "未启动":
                    perf = "3";
                    break;
            }
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            switch (_Obj.Leak)
            {
                case "正常":
                    Leak = "0";
                    break;
                case "异常":
                    Leak = "1";
                    break;
            }
            switch (_Obj.DUANXIAN)
            {
                case "正常":
                    DUANXIAN = "0";
                    break;
                case "异常":
                    DUANXIAN = "1";
                    break;
            }
            lblLeak.Text = _Obj.Leak;
            lblDUANXIAN.Text = _Obj.Leak;
            lblWEIZHI.Text = _Obj.WEIZHI;
        }
    }
}