using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using System.Data;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfApplicationUrl : PageBase
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
            BindGraid();
            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            
            lblName.Text = _objDev.DeviceName;
            lblHealthStatus.Text = _objDevEx.HealthStatus;
            lblType.Text = _objDevEx.TypeName;
            lblInterval.Text = _objDev.Interval;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblNextPollingTime.Text = _objDev.NextPollingTime.ToString();

            //lblAverageResponseTime.Text = 
            //lblResponseTime.Text = 


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

            #region 绑定，曲线
            HistoryValueDA mDA = new HistoryValueDA();

            DateTime StartTime = DateTime.Now.AddHours(-1);
            DateTime EndTime = DateTime.Now;


            // 最近一小时性能
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 26101, StartTime, EndTime);
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 特定URL响应时间(应答时间/ms)本视图5分钟自动最新数据
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 24201, StartTime, EndTime);//应答时间/ms
            if (dt != null)
            {
                chtURL.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }           

            #endregion
        }

        #region  绑定列表 - URL序列
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }
        private void BindGraid()
        {
            int PageCount = 0;
            DataTable dt = new PerfApplicationDA().selectURL(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvURL.DataSource = dt;
            gvURL.DataBind();
            this.pg.RecordCount = PageCount;
        }
        #endregion
    }
}