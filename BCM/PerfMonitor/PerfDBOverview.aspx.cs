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
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        #region  绑定列表 - 最少可用表空间
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }
        private void BindGraid()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectMinBytesList(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvMinBytes.DataSource = dt;
            gvMinBytes.DataBind();
        }
        #endregion

        private void InitData()
        {
            BindGraid();
            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
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

            lblServerSize.Text = _Obj.ServerSize;
            lblAverageExecutionTime.Text = _Obj.AverageExecutionTime;
            lblReadingTimes.Text = _Obj.ReadingTimes;
            lblWritingTimes.Text = _Obj.WritingTimes;
            lblBlockSize.Text = _Obj.BlockSize;




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


            #region 绑定 共享的SGA
            DataPoint dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}%)", "库存储器大小", _Obj.LibraryMemorySize);
            double[] dSGA = { Convert.ToDouble(_objDev.AvailableRate) };
            dpSGA.Color = Color.Green;
            dpSGA.YValues = dSGA;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}%)", "数据字典存储器", _Obj.DataDictionaryMemory);
            double[] dSGA2 = { Convert.ToDouble(100 - _objDev.AvailableRate) };
            dpSGA.Color = Color.Red;
            dpSGA.YValues = dSGA2;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}%)", "SG区域大小", _Obj.SGSize);
            double[] dSGA3 = { Convert.ToDouble(100 - _objDev.AvailableRate) };
            dpSGA.Color = Color.Blue;
            dpSGA.YValues = dSGA3;
            chtSGA.Series["Series1"].Points.Add(dpSGA);
            
            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}%)", "固定的区域大小", _Obj.FixedRegionSize);
            double[] dSGA4 = { Convert.ToDouble(100 - _objDev.AvailableRate) };
            dpSGA.Color = Color.Yellow;
            dpSGA.YValues = dSGA4;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}%)", "缓冲存储器大小", _Obj.BufferMemorySize);
            double[] dSGA5 = { Convert.ToDouble(100 - _objDev.AvailableRate) };
            dpSGA.Color = Color.Orange;
            dpSGA.YValues = dSGA5;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}%)", "共享池大小", _Obj.ShareSize);
            double[] dSGA6 = { Convert.ToDouble(100 - _objDev.AvailableRate) };
            dpSGA.Color = Color.OldLace;
            dpSGA.YValues = dSGA6;
            chtSGA.Series["Series1"].Points.Add(dpSGA);
            #endregion


            //绑定，曲线
            HistoryValueDA mDA = new HistoryValueDA();
            #region 今天接收、发送
            DateTime StartTime = DateTime.Now.AddHours(-1);
            DateTime EndTime = DateTime.Now;


            // 连接时间-最后一小时
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 41101, StartTime, EndTime);//流入错误数
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 用户活动性-最后一小时
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 41201, StartTime, EndTime);//流入错误数
            if (dt != null)
            {
                chUserActivity.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }
            


            #endregion
        }
    }
}