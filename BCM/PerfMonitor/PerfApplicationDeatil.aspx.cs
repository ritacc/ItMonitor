using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.PerfMonitor;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using GDK.DAL.SerMonitor;
using System.Data;
using GDK.DAL.PerfMonitor;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfApplicationDeatil : PageBase
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
            this.pgProcessDetail.OnPageChanged += new EventHandler(PageChangedProcessDetail);
            this.pgDiskUtilization.OnPageChanged += new EventHandler(PageChangedDisk);
            this.pgPageSpace.OnPageChanged += new EventHandler(PageChangedPageSpace);
            this.pgDiskStatistics.OnPageChanged += new EventHandler(PageChangedDiskStatistics);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            BindGraidSystem();
            BindGraidDetail();
            BindGraidDisk();
            BindGraidPageSpace();
            BindGraidDiskStatistics();

            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            PerfApplicationOR _pa = new PerfApplicationDA().SelectPerfApplication(mDeviceID);


            perf = _objDev.Performance;
            lblPerf.Text = _objDev.Performance;
            lblPerformance.Text = _objDev.Performance;
            lblDescribe.Text = _objDev.Describe;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblNextPollingTime.Text = _objDev.NextPollingTime.ToString();

            lblMonitorName.Text = _pa.MonitorName;
            lblHostName.Text = _pa.HostName;
            lblOperatingSystem.Text =_objDev.OperSystem;
            lblIP.Text = _objDev.IP;
            lblWarningStatus.Text = _objDevEx.WarningStatus;

            lblSwapMemoryUtilization.Text = _pa.SwapMemoryUtilization;
            lblSwapMemoryUtilizationMB.Text = _pa.SwapMemoryUtilizationMB;
            lblCPUMemoryUtilization.Text = _pa.CPUMemoryUtilization;
            lblPhysicalpMemoryUtilization.Text = _pa.PhysicalpMemoryUtilization;
            lblPhysicalpMemoryUtilizationMB.Text = _pa.PhysicalpMemoryUtilizationMB;
            lblFreePhysicalpMemory.Text = _pa.FreePhysicalpMemory;


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

            DateTime StartTime = DateTime.Now.AddHours(-6);
            DateTime EndTime = DateTime.Now;

            DateTime SystemStartTime = DateTime.Now.AddHours(-1);


            // CPU及内存使用率 - 最近六小时内
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 25301, StartTime, EndTime);//交换内存使用率
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 25302, StartTime, EndTime);//物理内存使用率
            if (dte != null)
            {
                chLine.Series["Series2"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 25303, StartTime, EndTime);//CPU使用率
            if (dte != null)
            {
                chLine.Series["Series3"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 系统负荷 - 近一小时
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 25501, SystemStartTime, EndTime);//每分钟的Job数
            if (dt != null)
            {
                chSystemLoad.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }
            dt = mDA.GetDeviceChanncelValue(iDeviceID, 25502, SystemStartTime, EndTime);//5分钟的Job数
            if (dt != null)
            {
                chSystemLoad.Series["Series2"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }
            dt = mDA.GetDeviceChanncelValue(iDeviceID, 25503, SystemStartTime, EndTime);//15分钟的Job数
            if (dt != null)
            {
                chSystemLoad.Series["Series3"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }

            #endregion
        }


        #region  绑定列表 - 系统负荷 - 最近一小时
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidSystem();
        }
        private void BindGraidSystem()
        {
            int PageCount = 0;
            DataTable dt = new PerfApplicationDA().selecSystemLoad(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvSystemLoad.DataSource = dt;
            gvSystemLoad.DataBind();
            this.pg.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 进程明细
        private void PageChangedProcessDetail(object sender, EventArgs e)
        {
            BindGraidDetail();
        }
        private void BindGraidDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfApplicationDA().selecProcessDetail(pgProcessDetail.PageIndex, pgProcessDetail.PageSize, out PageCount, Request.QueryString["id"]);
            gvProcessDetail.DataSource = dt;
            gvProcessDetail.DataBind();
            this.pgProcessDetail.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 磁盘使用率
        private void PageChangedDisk(object sender, EventArgs e)
        {
            BindGraidDisk();
        }
        private void BindGraidDisk()
        {
            int PageCount = 0;
            DataTable dt = new PerfApplicationDA().selecDiskUtilization(pgDiskUtilization.PageIndex, pgDiskUtilization.PageSize, out PageCount, Request.QueryString["id"]);
            gvDiskUtilization.DataSource = dt;
            gvDiskUtilization.DataBind();
            this.pgDiskUtilization.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 页面空间
        private void PageChangedPageSpace(object sender, EventArgs e)
        {
            BindGraidPageSpace();
        }
        private void BindGraidPageSpace()
        {
            int PageCount = 0;
            DataTable dt = new PerfApplicationDA().selecPageSpace(pgPageSpace.PageIndex, pgPageSpace.PageSize, out PageCount, Request.QueryString["id"]);
            gvPageSpace.DataSource = dt;
            gvPageSpace.DataBind();
            this.pgPageSpace.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 磁盘IO统计列表
        private void PageChangedDiskStatistics(object sender, EventArgs e)
        {
            BindGraidDiskStatistics();
        }
        private void BindGraidDiskStatistics()
        {
            int PageCount = 0;
            DataTable dt = new PerfApplicationDA().selecDiskStatistics(pgDiskStatistics.PageIndex, pgDiskStatistics.PageSize, out PageCount, Request.QueryString["id"]);
            gvDiskStatistics.DataSource = dt;
            gvDiskStatistics.DataBind();
            this.pgDiskStatistics.RecordCount = PageCount;
        }
        #endregion
    }
}