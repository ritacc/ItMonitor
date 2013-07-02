using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;
using GDK.DAL.PerfMonitor;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfNetAlarmSubDetail : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        public string perf = "0";
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
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            PerfNetAlarmOR _obj = new PerfNetDA().SelectErrorNews(mDeviceID);
            switch (_objDev.Performance)
            {
                case "正常":
                    perf = "1";
                    break;
                case "故障":
                    perf = "0";
                    break;
                case "报警":
                    perf = "2";
                    break;
                case "未启动":
                    perf = "3";
                    break;
            }
            lblName.Text = _objDev.DeviceName;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblPerformance.Text = _objDev.Performance;
            if (_obj != null)
            {
                lblContent.Text = _obj.Content;
                lblHappenTime.Text = _obj.HappenTime.ToString();
            }
            else
            {
                return;
            }
        }
    }
}