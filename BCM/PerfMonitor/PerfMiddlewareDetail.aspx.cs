using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using GDK.DAL.PerfMonitor;
using System.Data;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfMiddlewareDetail : PageBase
    {
        public int deviceID = 0;
        public string State = "0";
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            this.pgThreadDetail.OnPageChanged += new EventHandler(PageChangedThreadDetail);
            this.pgConnectionPoolingDetails.OnPageChanged += new EventHandler(PageChangedPoolingDetails);
            this.pgServerResponseTime.OnPageChanged += new EventHandler(PageChangedServerResponseTime);
            //this.pgUndecided.OnPageChanged += new EventHandler(PageChangedUndecided);
            this.pgThreadWait.OnPageChanged += new EventHandler(PageChangedThreadWait);
            //this.pgJVMHeap.OnPageChanged += new EventHandler(PageChangedJVMHeap);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            BindGraidConversationDetail();
            BindGraidThreadDetail();
            BindGraidPoolingDetails();
            BindGraidServerResponseTime();
            //BindGraidUndecided();
            BindGraidThreadWait();
            BindGraidJVMHeap();


            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            PerfMiddlewareOR _pm = new PerfMiddlewareDA().SelectDeviceDetail(mDeviceID);
            lblState.Text = _objDev.Performance;
            switch (_objDevEx.State)
            {
                case "正常":
                    State = "1";
                    break;
                case "故障":
                    State = "0";
                    break;
                case "未启动":
                    State = "3";
                    break;
            }
            lblName.Text = _objDev.DeviceName;
            lblWarningStatus.Text = _objDevEx.WarningStatus;
            lblType.Text = _objDevEx.TypeName;
            lblWeblogic.Text = _objDev.Version;
            lblPort.Text = _objDev.Port;
            lblHostName.Text = _pm.HostName;
            lblSystem.Text = _objDev.ServName;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblNextPollingTime.Text = _objDev.NextPollingTime.ToString();


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
            DateTime StartTime = DateTime.Now.AddHours(-1);
            DateTime EndTime = DateTime.Now;


            // Web应用 -最近1小时最高用户会话（前5位）
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 91303, StartTime, EndTime);//磁盘使用率
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            //最近1小时的JVM堆使用情况图表
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 22505, StartTime, EndTime);//网络使用率
            if (dte != null)
            {
                chJVMHeap.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            #endregion
        }

        #region  绑定列表 -  Web应用的会话明细
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraidConversationDetail();
        }
        private void BindGraidConversationDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfMiddlewareDA().selectConversationDetail(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvConversationDetail.DataSource = dt;
            gvConversationDetail.DataBind();
            this.pg.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 -  线程明细
        private void PageChangedThreadDetail(object sender, EventArgs e)
        {
            BindGraidThreadDetail();
        }
        private void BindGraidThreadDetail()
        {
            int PageCount = 0;
            DataTable dt = new PerfMiddlewareDA().selectThreadDetail(pgThreadDetail.PageIndex, pgThreadDetail.PageSize, out PageCount, Request.QueryString["id"]);
            gvThreadDetail.DataSource = dt;
            gvThreadDetail.DataBind();
            this.pgThreadDetail.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 -  数据库连接池明细
        private void PageChangedPoolingDetails(object sender, EventArgs e)
        {
            BindGraidPoolingDetails();
        }
        private void BindGraidPoolingDetails()
        {
            int PageCount = 0;
            DataTable dt = new PerfMiddlewareDA().selectPoolingDetails(pgConnectionPoolingDetails.PageIndex, pgConnectionPoolingDetails.PageSize, out PageCount, Request.QueryString["id"]);
            gvConnectionPoolingDetails.DataSource = dt;
            gvConnectionPoolingDetails.DataBind();
            this.pgConnectionPoolingDetails.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 -  最近1小时的服务器应答时间
        private void PageChangedServerResponseTime(object sender, EventArgs e)
        {
            BindGraidServerResponseTime();
        }
        private void BindGraidServerResponseTime()
        {
            int PageCount = 0;
            DataTable dt = new PerfMiddlewareDA().selectServerResponseTime(pgServerResponseTime.PageIndex, pgServerResponseTime.PageSize, out PageCount, Request.QueryString["id"]);
            gvServerResponseTime.DataSource = dt;
            gvServerResponseTime.DataBind();
            this.pgServerResponseTime.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 -  最近1小时的未决请求数
                //页面无显示内容，无法取字段
        #endregion

        #region  绑定列表 -  线程等待
        private void PageChangedThreadWait(object sender, EventArgs e)
        {
            BindGraidThreadWait();
        }
        private void BindGraidThreadWait()
        {
            int PageCount = 0;
            DataTable dt = new PerfMiddlewareDA().selectThreadWait(pgThreadWait.PageIndex, pgThreadWait.PageSize, out PageCount, Request.QueryString["id"]);
            gvThreadWait.DataSource = dt;
            gvThreadWait.DataBind();
            this.pgThreadWait.RecordCount = PageCount;
        }
        #endregion

        #region  绑定列表 -  最近1小时的JVM堆使用情况
        private void PageChangedJVMHeap(object sender, EventArgs e)
        {
            BindGraidJVMHeap();
        }
        private void BindGraidJVMHeap()
        {
            int PageCount = 0;
            DataTable dt = new PerfMiddlewareDA().selectJVMHeap(Convert.ToInt32(Request.QueryString["id"]));//pgJVMHeap.PageIndex, pgJVMHeap.PageSize, out PageCount, Request.QueryString["id"]);
            gvJVMHeap.DataSource = dt;
            gvJVMHeap.DataBind();
            //this.pgJVMHeap.RecordCount = PageCount;
        }
        #endregion
    }
}