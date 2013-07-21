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
    public partial class PerfHostDetail : PageBase
    {
        public int deviceID = 0;
        public string state = "0";
        public string health = "0";
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            //this.pg.OnPageChanged += new EventHandler(PageChanged);
            this.pgProcessDetail.OnPageChanged += new EventHandler(PageChangedProcessDetail);
            this.pgDiskUtilization.OnPageChanged += new EventHandler(PageChangedDisk);
            this.pgPageSpace.OnPageChanged += new EventHandler(PageChangedPageSpace);
            this.pgDiskStatistics.OnPageChanged += new EventHandler(PageChangedDiskStatistics);
            this.pgNetworkPort.OnPageChanged += new EventHandler(PageChangedNetworkPort);
            this.pgServiceDetail.OnPageChanged += new EventHandler(PageChangedServiceDetail);
            this.pgEvent.OnPageChanged += new EventHandler(PageChangedEvent);
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
            divNetworkPort.Visible = false;
            divServiceDetail.Visible = false;
            divEvent.Visible = false;

            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);

            // 判断操作系统是否为Windows2000
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            if (_objDevEx.TypeName == "Windows2000") 
            {
                BindGraidPort();
                BindGraidServiceDetail();
                BindGraidEvent();

                divNetworkPort.Visible = true;
                divServiceDetail.Visible = true;
                divEvent.Visible = true;
            }

            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            PerfHostOR _ph = new PerfHostDA().SelectHostDetail(mDeviceID);

            state = _objDevEx.StatusVal;
            //switch (_objDevEx.State)
            //{
            //    case "正常":
            //        state = "1";
            //        break;
            //    case "故障":
            //        state = "0";
            //        break;
            //    case "未启动":
            //        state = "3";
            //        break;
            //}
            health = _objDevEx.HealthStatusVal;
            //switch (_objDevEx.HealthStatus)
            //{
            //    case "正常":
            //        health = "1";
            //        break;
            //    case "故障":
            //        health = "0";
            //        break;
            //    case " 报警":
            //        health = "2";
            //        break;
            //}

            lblPerf.Text = _objDevEx.State;
            lblPerformance.Text = _objDevEx.State;
            lblDescribe.Text = _objDev.Describe;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblNextPollingTime.Text = _objDev.NextPollingTime.ToString();

            lblMonitorName.Text = _objDev.DeviceName;
            lblHostName.Text = _ph.HostName;
            lblOperatingSystem.Text = _ph.System;
            lblIP.Text = _objDev.IP;
            lblResponseTime.Text = _ph.ResponseTime;

            lblSwapMemoryUtilization.Text = _ph.SwapMemoryUtilization;
            lblSwapMemoryUtilizationMB.Text = _ph.SwapMemoryUtilizationMB;
            lblCPUMemoryUtilization.Text = _ph.CPUMemoryUtilization;
            lblPhysicalpMemoryUtilization.Text = _ph.PhysicalpMemoryUtilization;
            lblPhysicalpMemoryUtilizationMB.Text = _ph.PhysicalpMemoryUtilizationMB;
            lblFreePhysicalpMemory.Text = _ph.FreePhysicalpMemory;


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
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 14202, StartTime, EndTime);//交换内存使用率
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 14203, StartTime, EndTime);//物理内存使用率
            if (dte != null)
            {
                chLine.Series["Series2"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 14102, StartTime, EndTime);//CPU使用率
            if (dte != null)
            {
                chLine.Series["Series3"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 系统负荷 - 近一小时
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 13101, SystemStartTime, EndTime);//每分钟的Job数
            if (dt != null)
            {
                chSystemLoad.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }
            dt = mDA.GetDeviceChanncelValue(iDeviceID, 13102, SystemStartTime, EndTime);//5分钟的Job数
            if (dt != null)
            {
                chSystemLoad.Series["Series2"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }
            dt = mDA.GetDeviceChanncelValue(iDeviceID, 13103, SystemStartTime, EndTime);//15分钟的Job数
            if (dt != null)
            {
                chSystemLoad.Series["Series3"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }

            #endregion
        }


        #region  绑定列表 - 系统负荷 - 最近一小时
        //private void PageChanged(object sender, EventArgs e)
        //{
        //    BindGraidSystem();
        //}
        private void BindGraidSystem()
        {
            DataTable dt = new PerfHostDA().selecSystemLoad(Convert.ToInt32(Request.QueryString["id"]));
            gvSystemLoad.DataSource = dt;
            gvSystemLoad.DataBind();
            //this.pg.RecordCount = PageCount;
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
            DataTable dt = new PerfHostDA().selecProcessDetail(pgProcessDetail.PageIndex, pgProcessDetail.PageSize, out PageCount, Request.QueryString["id"]);
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
            DataTable dt = new PerfHostDA().selecDiskUtilization(pgDiskUtilization.PageIndex, pgDiskUtilization.PageSize, out PageCount, Request.QueryString["id"]);
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
            DataTable dt = new PerfHostDA().selecPageSpace(pgPageSpace.PageIndex, pgPageSpace.PageSize, out PageCount, Request.QueryString["id"]);
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
            DataTable dt = new PerfHostDA().selecDiskStatistics(pgDiskStatistics.PageIndex, pgDiskStatistics.PageSize, out PageCount, Request.QueryString["id"]);
            gvDiskStatistics.DataSource = dt;
            gvDiskStatistics.DataBind();
            this.pgDiskStatistics.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 网络接口
        private void PageChangedNetworkPort(object sender, EventArgs e)
        {
            BindGraidPort();
        }
        private void BindGraidPort()
        {
            int PageCount = 0;
            DataTable dt = new PerfHostDA().selecNetworksPort(pgNetworkPort.PageIndex, pgNetworkPort.PageSize, out PageCount, Request.QueryString["id"]);
            gvNetworkPort.DataSource = dt;
            gvNetworkPort.DataBind();
            this.pgNetworkPort.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 服务明细
        private void PageChangedServiceDetail(object sender, EventArgs e)
        {
            BindGraidServiceDetail();
        }
        private void BindGraidServiceDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfHostDA().selecServiceDetail(pgServiceDetail.PageIndex, pgServiceDetail.PageSize, out PageCount, Request.QueryString["id"]);
            gvServiceDetail.DataSource = dt;
            gvServiceDetail.DataBind();
            this.pgServiceDetail.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 - 最近从事件日志来的事件
        private void PageChangedEvent(object sender, EventArgs e)
        {
            BindGraidEvent();
        }
        private void BindGraidEvent()
        {
            int PageCount = 0;
            DataTable dt = new PerfHostDA().selecEvent(pgEvent.PageIndex, pgEvent.PageSize, out PageCount, Request.QueryString["id"]);
            gvEvent.DataSource = dt;
            gvEvent.DataBind();
            this.pgEvent.RecordCount = PageCount;
        }
        #endregion
    }
}