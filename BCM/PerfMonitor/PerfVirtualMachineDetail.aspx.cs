using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using GDK.DAL.SerMonitor;
using GDK.Entity.PerfMonitor;
using GDK.DAL.PerfMonitor;
using System.Data;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfVirtualMachineDetail : PageBase
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
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            this.pgVirtualSystem.OnPageChanged += new EventHandler(PageChangedVirtualSystem);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            BindGraidDiskUsage();
            BindGraidVirtualSystem();
            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            PerfDBOR _Obj = new PerfDBDA().SelectDeviceDetail(mDeviceID);
            PerfVirtualOR _pv = new PerfVirtualMachineDA().SelectVirtualDetail(mDeviceID);


            lblMonitorName.Text = _objDev.DeviceName;
            lblDescribe.Text = _objDev.Describe;
            lblHealthStatus.Text = _Obj.HealthStatus;   // 因没有对应的字段及通道号，该字段值取于数据库，可能不对
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblNextPollingTime.Text = _objDev.NextPollingTime.ToString();
            lblPerformance.Text = _objDev.Performance;
            perf = _objDev.Performance;
            lblPerf.Text = _objDev.Performance;

            lblCPUUtilizationRatio.Text = _pv.CPUUtilizationRatio.ToString();
            lblMemoryUtilization.Text = _pv.MemoryUtilization.ToString();
            if (_pv.CPUUtilizationRatio > 50)
            {
                lblCPUUtilization.Text = "异常";
            }
            else if (_pv.CPUUtilizationRatio < 50)
            {
                lblCPUUtilization.Text = "正常";
            }

            
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

            //绑定，曲线
            HistoryValueDA mDA = new HistoryValueDA();
            #region 今天接收、发送
            DateTime StartTime = Convert.ToDateTime(string.Format("{0} 00:00:00", DateTime.Now.ToString("yyyy-MM-dd")));
            DateTime EndTime = Convert.ToDateTime(string.Format("{0} 23:59:59", DateTime.Now.ToString("yyyy-MM-dd")));


            // 磁盘、网络使用情况 
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 91303, StartTime, EndTime);//磁盘使用率
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 91403, StartTime, EndTime);//网络使用率
            if (dte != null)
            {
                chLine.Series["Series2"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            #endregion
        }

        #region  绑定列表 -  磁盘、网络使用情况
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidDiskUsage();
        }
        private void BindGraidDiskUsage()
        {
            int PageCount = 0;
            DataTable dt = new PerfVirtualMachineDA().selectDiskUsage(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvUtilization.DataSource = dt;
            gvUtilization.DataBind();
            this.pg.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 -  虚拟机操作系统
        private void PageChangedVirtualSystem(object sender, EventArgs e)
        {
            BindGraidVirtualSystem();
        }
        private void BindGraidVirtualSystem()
        {
            int PageCount = 0;
            DataTable dt = new PerfVirtualMachineDA().selectVirtualSystem(pgVirtualSystem.PageIndex, pgVirtualSystem.PageSize, out PageCount, Request.QueryString["id"]);
            gvVirtualSystem.DataSource = dt;
            gvVirtualSystem.DataBind();
            this.pgVirtualSystem.RecordCount = PageCount;
        }
        #endregion
    }
}