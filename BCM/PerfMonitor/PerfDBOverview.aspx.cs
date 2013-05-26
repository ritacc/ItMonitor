using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;
using GDK.DAL.PerfMonitor;
using System.Data;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfDBOverview : PageBase
    {
        public int deviceID = 0;
        public string perf = "0";
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
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            PerfDBOR _Obj = new PerfDBDA().SelectDeviceDetail(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            perf = _objDevEx.Perf;
            lblPerf.Text = _objDevEx.Perf;

            lblServName.Text = _Obj.ServName;
            lblHealthStatus.Text = _Obj.HealthStatus;
            lblAuthType.Text = _Obj.ServType;
            lblVersion.Text = _Obj.Version;
            lblStartUpTime.Text = _Obj.StartUpTime;
            lblPort.Text = _Obj.Port;
            lblHostName.Text = _Obj.HostName;
            lblSystem.Text = _Obj.System;
            lblLastPollingTime.Text = _Obj.LastPollingTime;
            lblNextPollingTime.Text = _Obj.NextPollingTime;

            lblValue.Text = _Obj.ConnectionTime;
            lblUserNO.Text = _Obj.UserNO;






            #region 绑定 可用性
            DataPoint dp = new DataPoint();
            dp.LegendText = string.Format("{0}({1}%)", "可用", _objDev.AvailableRate);
            double[] d = { Convert.ToDouble(_objDev.AvailableRate) };
            dp.Color = Color.Green;
            dp.YValues = d;
            chtPerf.Series["Series1"].Points.Add(dp);

            dp = new DataPoint();
            dp.LegendText = string.Format("{0}({1}%)", "不可用", 100 - _objDev.AvailableRate);
            double[] dno = { Convert.ToDouble(100 - _objDev.AvailableRate) };
            dp.Color = Color.Red;
            dp.YValues = dno;
            chtPerf.Series["Series1"].Points.Add(dp);
            #endregion

        }
    }
}